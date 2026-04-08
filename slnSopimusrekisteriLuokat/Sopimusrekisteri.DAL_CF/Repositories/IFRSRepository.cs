using Sopimusrekisteri.BLL_CF;
using Sopimusrekisteri.BLL_CF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sopimusrekisteri.DAL_CF.Repositories
{
    public class IFRSRepository : Repository
    {
        private Dictionary<int, decimal> _korot;

        public IFRSRepository(string connectionString, int timeout = 300) : base(connectionString, timeout)
        {
        }

        private decimal HaeKorko(decimal vuodet)
        {
            if (_korot == null)
            {
                string strSQL = "SELECT KPVuodet, KPProsentti FROM hlp_Korkoprosentti";

                _korot = ExecuteDataSet(strSQL).Tables[0].Rows.Cast<DataRow>()
                    .ToDictionary(x => x.Field<int>("KPVuodet"), x => x.Field<decimal>("KPProsentti"));
            }

            decimal korko;
            if (_korot.TryGetValue((int)Math.Round(vuodet), out korko))
                return korko;

            return _korot[IFRSLaskenta.IFRS_Oletus_Vuodet];
        }

        public bool OnHistoriaPaivalle(DateTime pvm)
        {
            string strSQL = $@"SELECT 1 FROM IFRS_Historia his WHERE CAST(his.IFRSPvm AS DATE) = CAST(@pvm AS DATE)";

            return ExecuteDataSet(strSQL, new SqlParameter("@pvm", pvm.Date)).Tables[0].Rows.Count > 0;
        }

        public DataTable HaeKausiMenneisyys(DateTime pvm)
        {
            // haetaan päivämäärällä
            string strSQL = $@"SELECT 
                    IFRSPvm AS Pvm, 
                    IFRSSopimusId AS Sopimusnumero, 
                    IFRSSopimusJuridinenYhtioId AS YhtioId, 
                    IFRSSopimusJuridinenYhtio AS Yhtio, 
                    IFRSKorvauslaskelmaId AS KorvauslaskelmaId,
                    IFRSKorvauslaskelmaTahoId AS LaskuttajaId,
                    IFRSKorvauslaskelmaTaho AS Laskuttaja,
                    IFRSKorvauslaskelmaViimeisinMaksu AS Vuosivuokra, 
                    IFRSSopimusVuokratyyppiId AS VuokratyyppiId, 
                    vuokratyyppi.VTNimi AS Vuokratyyppi, 
                    kor.KORMaksunSuoritusId AS MaksunSuoritusId, 
                    ms.MSUMaksunSuoritus AS MaksunSuoritus, 
                    kor.KORMaksetaanAlv AS MaksetaanAlv, 
                    IFRSSopimusAlkaa AS Alkaa, 
                    IFRSSopimusPaattyy AS Paattyy, 
                    IFRSSopimusIFRS AS IFRS, 
                    IFRSSopimusKorkoprosentti AS Korko 
                    FROM IFRS_Historia his 
                    INNER JOIN Korvauslaskelma kor ON IFRSKorvauslaskelmaId = KORId
                    LEFT JOIN hlp_Vuokratyyppi vuokratyyppi ON IFRSSopimusVuokratyyppiId = VTId 
                    LEFT JOIN hlp_MaksunSuoritus ms ON kor.KORMaksunSuoritusId = MSUId 
                    WHERE CAST(IFRSPvm AS DATE) = CAST(@pvm AS DATE) 
                    ORDER BY IFRSSopimusIFRS DESC, IFRSSopimusId ";

            return ExecuteDataSet(strSQL, new SqlParameter("@pvm", pvm)).Tables[0];
        }

        public DataTable HaeKausiNykyhetki(DateTime katselupvm)
        {
            string strSQL = $@"SELECT
                @katselupvm AS Pvm, 
                SOPId AS Sopimusnumero, 
                SOPJuridinenYhtioId AS YhtioId, 
                yhtio.TAHSukunimi AS Yhtio, 
                laskuttaja.TAHTahoId AS LaskuttajaId,
                ISNULL(laskuttaja.TAHEtunimi + ' ', '') + ISNULL(laskuttaja.TAHSukunimi, '') AS Laskuttaja,
                ISNULL(kor.KORViimeisinMaksu, 0) AS Vuosivuokra, 
                kor.KORId AS KorvauslaskelmaId, 
                vuokratyyppi.VTId AS VuokratyyppiId, 
                vuokratyyppi.VTNimi AS Vuokratyyppi, 
                kor.KORMaksunSuoritusId AS MaksunSuoritusId, 
                ms.MSUMaksunSuoritus AS MaksunSuoritus, 
                kor.KORMaksetaanAlv AS MaksetaanAlv, 
                SOPAlkaa AS Alkaa, 
                ISNULL(SOPLaskennallinenPaattymispvm, SOPPaattyy) AS Paattyy, 
                SOPIFRS AS IFRS,
                SOPKorkoprosentti AS Korko
                FROM Sopimus 
                LEFT JOIN Korvauslaskelma kor ON kor.KORSopimusId = SOPId
                LEFT JOIN Taho yhtio ON SOPJuridinenYhtioId = yhtio.TAHTahoId
				LEFT JOIN Taho laskuttaja ON laskuttaja.TAHTahoId = kor.KORTahoId
                LEFT JOIN hlp_Vuokratyyppi vuokratyyppi ON vuokratyyppi.VTId = SOPVuokratyyppiId 
                LEFT JOIN hlp_MaksunSuoritus ms ON kor.KORMaksunSuoritusId = MSUId 
                WHERE (SOPIFRS = 1 OR SOPFAS = 1) 
                AND ISNULL(ISNULL(SOPLaskennallinenPaattymispvm, SOPPaattyy), '9999-12-31') >= CAST(@katselupvm AS date)
                AND ISNULL(SOPAlkaa, '1900-1-1') <= CAST(@katselupvm AS date) 
                AND ISNULL(KORKorvaustyyppiId, {(int)Korvaustyypit.Vuosimaksu}) IN ({(int)Korvaustyypit.Vuosimaksu})
                ORDER BY SOPIFRS DESC, SOPId ";

            return ExecuteDataSet(strSQL, new SqlParameter("@katselupvm", katselupvm)).Tables[0];
        }

        public void Historioi(IFRSKausi kausi, string luoja)
        {
            var table = GetDataTableSchema("IFRS_Historia");

            foreach (var laskenta in kausi.Laskenta.Select(x => x.Value))
            {
                int? korvauslaskelmaid = laskenta.KorvauslaskelmaId == 0 ? null : laskenta.KorvauslaskelmaId;
                var row = table.NewRow();

                row["IFRSPvm"] = laskenta.Pvm;
                row["IFRSSopimusId"] = laskenta.Sopimusnumero;
                row["IFRSSopimusAlkaa"] = ValueOrDBNull(laskenta.Alkaa);
                row["IFRSSopimusPaattyy"] = ValueOrDBNull(laskenta.Paattyy);
                row["IFRSSopimusJuridinenYhtioId"] = ValueOrDBNull(laskenta.YhtioId);
                row["IFRSSopimusJuridinenYhtio"] = ValueOrDBNull(laskenta.Yhtio);
                row["IFRSSopimusVuokratyyppiId"] = ValueOrDBNull(laskenta.VuokratyyppiId);
                row["IFRSSopimusIFRS"] = laskenta.IFRS;
                row["IFRSSopimusKorkoprosentti"] = laskenta.UusiKorko;
                row["IFRSKorvauslaskelmaId"] = ValueOrDBNull(korvauslaskelmaid);
                row["IFRSKorvauslaskelmaTahoId"] = ValueOrDBNull(laskenta.LaskuttajaId);
                row["IFRSKorvauslaskelmaTaho"] = ValueOrDBNull(laskenta.Laskuttaja);
                row["IFRSKorvauslaskelmaViimeisinMaksu"] = laskenta.UusiVuokra;
                row["IFRSLuotu"] = DateTime.Now;
                row["IFRSLuoja"] = luoja;

                table.Rows.Add(row);
            }

            if (table.Rows.Count > 0)
                BulkInsert(table);
        }

        public IFRSKausi MuodostaKausi(DataTable data, IFRSKausi edellinen, DateTime pvm)
        {
            var kausi = UusiTyhjaKausi(pvm, edellinen);

            foreach (DataRow row in data.Rows)
            {
                int? korvauslaskelmaId = row.Field<int?>("KorvauslaskelmaId");

                IFRSLaskenta edellinenLaskenta = null;
                if (korvauslaskelmaId.HasValue) edellinen?.Laskenta.TryGetValue(korvauslaskelmaId.Value, out edellinenLaskenta);

                var laskenta = new IFRSLaskenta
                {
                    Pvm = row.Field<DateTime>("Pvm"),
                    Alkaa = row.Field<DateTime?>("Alkaa"),
                    Paattyy = row.Field<DateTime?>("Paattyy"),
                    LaskuttajaId = row.Field<int?>("LaskuttajaId"),
                    Laskuttaja = row.Field<string>("Laskuttaja"),
                    IFRS = row.Field<bool>("IFRS"),
                    Sopimusnumero = row.Field<int>("Sopimusnumero"),
                    KorvauslaskelmaId = row.Field<int?>("KorvauslaskelmaId"),
                    YhtioId = row.Field<int?>("YhtioId"),
                    Yhtio = row.Field<string>("Yhtio"),
                    VuokratyyppiId = row.Field<int?>("VuokratyyppiId"),
                    Vuokratyyppi = row.Field<string>("Vuokratyyppi"),
                    MaksunSuoritusId = row.Field<int?>("MaksunSuoritusId"),
                    MaksunSuoritus = row.Field<string>("MaksunSuoritus"),
                    MaksetaanAlv = row.Field<bool?>("MaksetaanAlv"),
                    UusiVuokra = row.Field<decimal>("Vuosivuokra"),
                    VanhaAssets = edellinenLaskenta?.UusiAssets,
                    VanhaKorko = edellinenLaskenta?.UusiKorko,
                    VanhaVuodet = edellinenLaskenta?.UusiVuodet - kausi.KaudenKoko,
                    VanhaVuokra = edellinenLaskenta?.UusiVuokra,
                    Kausi = kausi
                };

                // jos sopimuksella on korko, otetaan se, muuten korkotaulukosta
                laskenta.UusiKorko = row.Field<decimal?>("Korko") ?? HaeKorko(laskenta.UusiVuodet);

                if (laskenta.KorvauslaskelmaId.HasValue)
                {
                    kausi.Laskenta.Add(laskenta.KorvauslaskelmaId.Value, laskenta);
                }
                else 
                { 
                    kausi.LaskentaEiKorvauslaskelmaa.Append(laskenta); 
                }
            }

            kausi.YhteensaVuokratyypeittain = MuodostaYhteensa(kausi);
            kausi.YhteenvetoVuokratyypeittain = MuodostaYhteenveto(kausi);

            return kausi;
        }

        private IEnumerable<IFRSYhteensaVuokratyypeittain> MuodostaYhteensa(IFRSKausi data)
        {
            var ifrs = data.IFRSLaskenta;
            ifrs.ToList().AddRange(data.IFRSLaskentaEiKorvauslaskelmaa);
            var yhteenveto = new List<IFRSYhteensaVuokratyypeittain>();

            // Vuokratyypeittäin
            var vuokratyypeittain = ifrs
                .GroupBy(x => x.VuokratyyppiId)
                .Select(x => MuodostaYhteensa(x.FirstOrDefault()?.Vuokratyyppi, x.Key, x));

            // Kaikista
            data.Yhteensa = MuodostaYhteensa("Yhteensä", null, ifrs);

            yhteenveto.AddRange(vuokratyypeittain);
            yhteenveto.Add(data.Yhteensa);

            return yhteenveto;
        }

        private IFRSYhteensaVuokratyypeittain MuodostaYhteensa(string nimi, int? vuokratyyppiId, IEnumerable<IFRSLaskenta> data)
        {
            var yhteensa = new IFRSYhteensaVuokratyypeittain()
            {
                VuokratyyppiId = vuokratyyppiId,
                Nimi = nimi,
                VanhaVuokra = data.Sum(y => y.VanhaVuokra ?? 0),
                VanhaNykyarvo = data.Sum(y => y.VanhaNykyarvo ?? 0),
                UusiVuokra = data.Sum(y => y.UusiVuokra),
                UusiNykyarvo = data.Sum(y => y.UusiNykyarvo),
                NykyarvoMuutos = data.Sum(y => y.NykyarvoMuutos),
                GroupKorko = data.Sum(y => y.GroupKorko ?? 0),
                GroupPoisto = data.Sum(y => y.GroupPoisto ?? 0),
                Assets = data.Sum(y => y.UusiAssets)
            };

            return yhteensa;
        }

        private IEnumerable<IFRSLaskentaYhteenveto> MuodostaYhteenveto(IFRSKausi data)
        {
            var yhteenveto = new List<IFRSLaskentaYhteenveto>();

            // Kaikista
            data.Yhteenveto = MuodostaYhteenveto(data.Yhteensa, data.EdellinenKausi?.Yhteenveto);
            data.Yhteenveto.Vuokratyyppi = "KAIKKI";
            yhteenveto.Add(data.Yhteenveto);

            // Vuokratyypeittäin
            foreach (var yhteensa in data.YhteensaVuokratyypeittain.Where(x => x.VuokratyyppiId.HasValue))
            {
                yhteenveto.Add(MuodostaYhteenveto(yhteensa, data.EdellinenKausi?.YhteenvetoVuokratyypeittain.FirstOrDefault(x => x.VuokratyyppiId == yhteensa.VuokratyyppiId)));
            }

            return yhteenveto;
        }

        private IFRSLaskentaYhteenveto MuodostaYhteenveto(IFRSYhteensaVuokratyypeittain yhteensa, IFRSLaskentaYhteenveto edellinen)
        {
            var yhteenveto = new IFRSLaskentaYhteenveto
            {
                Vuokratyyppi = yhteensa.Nimi,
                VuokratyyppiId = yhteensa.VuokratyyppiId,
                Assets = edellinen?.TarkistusAssets ?? yhteensa.Assets,
                Leasing = edellinen?.TarkistusLeasing ?? -yhteensa.Assets,
                Retained = edellinen?.TarkistusRetained,
                GroupKorkoPositiivinen = yhteensa.GroupKorko,
                GroupKorkoNegatiivinen = -yhteensa.GroupKorko,
                GroupPoistoPositiivinen = yhteensa.GroupPoisto,
                GroupPoistoNegatiivinen = -yhteensa.GroupPoisto,
                GroupVuokraPositiivinen = yhteensa.UusiVuokra,
                GroupVuokraNegatiivinen = -yhteensa.UusiVuokra,
                NykyarvoMuutosPositiivinen = yhteensa.NykyarvoMuutos,
                NykyarvoMuutosNegatiivinen = -yhteensa.NykyarvoMuutos
            };

            yhteenveto.TarkistusAssets = yhteenveto.Assets + (yhteenveto.GroupPoistoNegatiivinen ?? 0) + (yhteenveto.NykyarvoMuutosPositiivinen ?? 0);
            yhteenveto.TarkistusLeasing = yhteenveto.Leasing + (yhteenveto.GroupKorkoNegatiivinen ?? 0) + (yhteenveto.GroupVuokraPositiivinen ?? 0) + (yhteenveto.NykyarvoMuutosNegatiivinen ?? 0);
            yhteenveto.TarkistusRetained = (yhteenveto.Retained ?? 0) + (yhteenveto.GroupKorkoPositiivinen ?? 0) + (yhteenveto.GroupPoistoPositiivinen ?? 0) + (yhteenveto.GroupVuokraNegatiivinen ?? 0);

            return yhteenveto;
        }

        public IFRSKausi UusiTyhjaKausi(DateTime pvm, IFRSKausi edellinen)
        {
            return new IFRSKausi
            {
                Id = Guid.NewGuid().ToString(),
                Pvm = pvm,
                EdellinenKausi = edellinen,
                LaskentaEiKorvauslaskelmaa = new List<IFRSLaskenta>()
            };
        }

        public IFRSKausi LaskeKausiTulevaisuus(IFRSKausi edellinen, DateTime pvm)
        {
            var kausi = UusiTyhjaKausi(pvm, edellinen);

            foreach (var edellinenLaskenta in edellinen.Laskenta.Select(x => x.Value))
            {
                var laskenta = new IFRSLaskenta
                {
                    Pvm = pvm,
                    Alkaa = edellinenLaskenta.Alkaa,
                    Paattyy = edellinenLaskenta.Paattyy,
                    LaskuttajaId = edellinenLaskenta.LaskuttajaId,
                    Laskuttaja = edellinenLaskenta.Laskuttaja,
                    IFRS = edellinenLaskenta.IFRS,
                    Sopimusnumero = edellinenLaskenta.Sopimusnumero,
                    KorvauslaskelmaId = edellinenLaskenta.KorvauslaskelmaId,
                    YhtioId = edellinenLaskenta.YhtioId,
                    Yhtio = edellinenLaskenta.Yhtio,
                    VuokratyyppiId = edellinenLaskenta.VuokratyyppiId,
                    Vuokratyyppi = edellinenLaskenta.Vuokratyyppi,
                    MaksunSuoritusId = edellinenLaskenta.MaksunSuoritusId,
                    MaksunSuoritus = edellinenLaskenta.MaksunSuoritus,
                    MaksetaanAlv = edellinenLaskenta.MaksetaanAlv,
                    UusiVuokra = edellinenLaskenta.UusiVuokra, // Pysyy samana, ei voida ennustaa
                    UusiKorko = edellinenLaskenta.UusiKorko, // Pysyy samana, ei voida ennustaa
                    VanhaVuokra = edellinenLaskenta.UusiVuokra, // Pysyy samana, ei voida ennustaa
                    VanhaKorko = edellinenLaskenta.UusiKorko,
                    VanhaVuodet = edellinenLaskenta.UusiVuodet - kausi.KaudenKoko,
                    VanhaAssets = edellinenLaskenta.UusiAssets,
                    Kausi = kausi
                };

                // jos menee miinuksille vuodet, ei oteta mukaan
                if (laskenta.UusiVuodet < 0)
                    continue;

                if (laskenta.KorvauslaskelmaId.HasValue) kausi.Laskenta.Add(laskenta.KorvauslaskelmaId.Value, laskenta);
                else kausi.LaskentaEiKorvauslaskelmaa.Append(laskenta);
            }

            kausi.YhteensaVuokratyypeittain = MuodostaYhteensa(kausi);
            kausi.YhteenvetoVuokratyypeittain = MuodostaYhteenveto(kausi);

            return kausi;
        }

        public IEnumerable<IFRSMaturiteetti> LaskeMaturiteettiFAS(IEnumerable<IFRSKausi> data, decimal oletettuInflaatio)
        {
            var uusinKausi = data.OrderByDescending(x => x.Pvm).FirstOrDefault();
            var laskenta = uusinKausi.Laskenta.Select(x => x.Value);
            laskenta.ToList().AddRange(uusinKausi.LaskentaEiKorvauslaskelmaa);
            var inflaatio = (oletettuInflaatio / 100) + 1;
            var summatVuosittain = new Dictionary<int, decimal>();

            // lasketaan vuosille 1-6 summat käyttäen inflaatiota
            for (int i = 1; i <= 6; i++)
            {
                if (!summatVuosittain.Any()) // vuosi = 1
                    summatVuosittain.Add(i, laskenta.Sum(x => x.UusiVuokra * inflaatio));
                else // vuodet 2-6
                    summatVuosittain.Add(i, summatVuosittain[i - 1] * inflaatio);
            }

            return new List<IFRSMaturiteetti>
            {
                new IFRSMaturiteetti { Nimi = "Vuosi 1", Arvo = summatVuosittain[1] },
                new IFRSMaturiteetti { Nimi = "Vuosi 2-5", Arvo = summatVuosittain.Where(x => x.Key >= 2 && x.Key <= 5).Sum(x => x.Value) },
                new IFRSMaturiteetti { Nimi = "Vuosi 6", Arvo = summatVuosittain[6] },
                new IFRSMaturiteetti { Nimi = "Yhteensä", Arvo = summatVuosittain.Sum(x => x.Value) }
            };
        }

        public IEnumerable<IFRSMaturiteetti> LaskeMaturiteettiIFRS(IEnumerable<IFRSKausi> data, decimal oletettuInflaatio)
        {
            var uusinKausi = data.OrderByDescending(x => x.Pvm).FirstOrDefault();
            var vanhinKausi = data.OrderBy(x => x.Pvm).FirstOrDefault();

            var uusinLaskenta = uusinKausi.Laskenta.Select(x => x.Value).Where(x => x.IFRS);
            uusinLaskenta.ToList().AddRange(uusinKausi.LaskentaEiKorvauslaskelmaa.Where(x => x.IFRS));
            var vanhinLaskenta = vanhinKausi.Laskenta.Select(x => x.Value).Where(x => x.IFRS);
            vanhinLaskenta.ToList().AddRange(vanhinKausi.LaskentaEiKorvauslaskelmaa.Where(x => x.IFRS));

            var inflaatio = (oletettuInflaatio / 100) + 1;
            var leasing = vanhinLaskenta.Sum(x => x.UusiNykyarvo);
            var vuosi1 = uusinLaskenta.Sum(x => x.UusiVuokra);
            var vuosi2to5 = vuosi1 * 4;
            var vuosi6 = leasing - vuosi1 - vuosi2to5;

            return new List<IFRSMaturiteetti>
            {
                new IFRSMaturiteetti { Nimi = "Vuosi 1", Arvo = vuosi1 },
                new IFRSMaturiteetti { Nimi = "Vuosi 2-5", Arvo = vuosi2to5 },
                new IFRSMaturiteetti { Nimi = "Vuosi 6 ->", Arvo = vuosi6 },
                new IFRSMaturiteetti { Nimi = "Yhteensä", Arvo = vuosi1 + vuosi2to5 + vuosi6 }
            };
        }

    }
}
