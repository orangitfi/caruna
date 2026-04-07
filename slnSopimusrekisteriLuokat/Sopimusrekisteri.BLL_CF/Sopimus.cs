using Sopimusrekisteri.BLL_CF.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
    public class Sopimus : IEditable, IPoimittava
    {
        #region Propertyt

        public int Id { get; set; }
        public Sopimustyypit SopimustyyppiId { get; set; }
        public int? PaasopimusId { get; set; }
        public DateTime? Alkaa { get; set; }
        public DateTime? Paattyy { get; set; }
        public int? KestoId { get; set; }
        public DateTime? ProjektiAloitusPvm { get; set; }
        public string MuuTunniste { get; set; }
        public string Iban { get; set; }
        public int? JuridinenYhtioId { get; set; }
        public string SopimuksenLaatija { get; set; }
        public int? VastuuyksikkoId { get; set; }
        public string Projektinumero { get; set; }
        public int? Pylvasmaara { get; set; }
        public bool Luonnonsuojelualue { get; set; }
        public string Pylvasvali { get; set; }
        public string MaantieteellinenVali { get; set; }
        public decimal? Muuntamoalue { get; set; }
        public int? JulkisuusasteId { get; set; }
        public string Korvaa { get; set; }
        public SopimusTilat? SopimuksenTilaId { get; set; }
        public string Info { get; set; }
        public DateTime Luotu { get; set; }
        public string Luoja { get; set; }
        public string Paivittaja { get; set; }
        public DateTime? Paivitetty { get; set; }
        public decimal? AlkuperainenKorvaus { get; set; }
        public int? DFRooliId { get; set; }
        public int? SopimusluokkaId { get; set; }
        public int? SopimuksenAlaluokkaId { get; set; }
        public int? SopimuksenEhtoversioId { get; set; }
        public string Karttaliite { get; set; }
        public string Kuvaus { get; set; }
        public DateTime? VerkonhaltijanAllekirjoitusPvm { get; set; }
        public DateTime? AsiakkaanAllekirjoitusPvm { get; set; }
        public int? SopimuksenIrtisanomisaika { get; set; }
        public string SopimuksenIrtisanomistoimet { get; set; }
        public int? VerkonhaltijaSiirtoOikeusId { get; set; }
        public int? VastaosapuoliSiirtoOikeusId { get; set; }
        public int? AlkuperainenYhtioId { get; set; }
        public DateTime? Irtisanomispvm { get; set; }
        public string PCSNumero { get; set; }
        public string Projektinvalvoja { get; set; }
        public int? PuustonPoistoId { get; set; }
        public int? PuustonOmistajuusId { get; set; }
        public int? Jatkoaika { get; set; }
        public int? KohdekategoriaId { get; set; }
        public bool TiedostoHaettu { get; set; }
        public bool MetatiedotPaivitetty { get; set; }
        public bool Luonnos { get; set; }
        public Kielet? KieliId { get; set; }
        public string Erityisehdot { get; set; }
        public int? YlasopimuksenTyyppiId { get; set; }
        public int? LupatahoId { get; set; }
        public bool Korvaukseton { get; set; }
        public string Mappitunniste { get; set; }
        public string CaceTehtava { get; set; }
        public DateTime? SopimusarkistosiirtoTehty { get; set; }
        public string Guid { get; set; }
        public int? VuokratyyppiId { get; set; }
        public decimal? Korkoprosentti { get; set; }

        /// <summary>
        /// Vain tiedoksi. Ei käytetä kyselyissä tai hauissa
        /// </summary>
        public int? LahdeKorkoprosenttiId { get; set; }

        /// <summary>
        /// Finnish Accounting Standards
        /// </summary>
        public bool FAS { get; set; }

        /// <summary>
        /// International Financial Reporting Standards
        /// </summary>
        public bool IFRS { get; set; }

        public int? Sopimusvuosi
        {
            get
            {
                if (this.Alkaa.HasValue)
                    return this.Alkaa.Value.Year;

                return null;
            }
        }

        /// <summary>
        /// Hakee laskennallisen päättymispäivän kannasta tallennettuna
        /// </summary>
        public DateTime? LaskennallinenPaattymispvm { get; set; }

        //public DateTime? LaskennallinenPaattymispvm
        //{
        //    get
        //    {
        //        if (this.Paattyy.HasValue)
        //        {

        //            DateTime paattymispvmIrtisanomisajalla = this.GetPvmIrtisanomisajalla(this.Paattyy.Value);

        //            if (paattymispvmIrtisanomisajalla < DateTime.Now.Date && paattymispvmIrtisanomisajalla < this.Irtisanomispvm.GetValueOrDefault(DateTime.MaxValue))
        //            {

        //                if (this.Jatkoaika.HasValue && this.Jatkoaika.Value > 0)
        //                {

        //                    DateTime laskennallinenPaattymispvm = this.Paattyy.Value.AddMonths(this.Jatkoaika.Value);

        //                    DateTime laskennallinenPaattymispvmIrtisanomisajalla = this.GetPvmIrtisanomisajalla(laskennallinenPaattymispvm);

        //                    while (laskennallinenPaattymispvmIrtisanomisajalla < DateTime.Now.Date && laskennallinenPaattymispvmIrtisanomisajalla < this.Irtisanomispvm.GetValueOrDefault(DateTime.MaxValue))
        //                    {

        //                        laskennallinenPaattymispvm = laskennallinenPaattymispvm.AddMonths(this.Jatkoaika.Value);
        //                        laskennallinenPaattymispvmIrtisanomisajalla = this.GetPvmIrtisanomisajalla(laskennallinenPaattymispvm);

        //                    }

        //                    return laskennallinenPaattymispvm;

        //                }

        //            }

        //            return this.Paattyy.Value;

        //        }

        //        return null;

        //    }
        //}

        private DateTime GetPvmIrtisanomisajalla(DateTime pvm)
        {
            return pvm.AddMonths(-1 * this.SopimuksenIrtisanomisaika.GetValueOrDefault(0));
        }

        /// <summary>
        /// Laskee laskennallisen päättymispäivät muista tiedoista
        /// </summary>
        public LaskennallinenPaattymispvm DynaaminenLaskennallinenPaattymispvm => new LaskennallinenPaattymispvm
        {
            Irtisanomisaika = SopimuksenIrtisanomisaika,
            Irtisanottu = Irtisanomispvm,
            Paattyy = Paattyy,
            Jatkoaika = Jatkoaika,
            Alkaa = Alkaa
        };

        public string Nimi
        {
            get { return this.Id.ToString() + string.Format("({0})", this.MuuTunniste); }
        }

        public string SopimustyypinNimi
        {
            get
            {
                if (this.YlasopimuksenTyyppi != null)
                    return this.YlasopimuksenTyyppi.Nimi;

                if (this.Sopimustyyppi != null)
                    return this.Sopimustyyppi.SopimustyyppiNimi;

                return string.Empty;
            }
        }

        public bool Hyvaksytty
        {
            get
            {
                return this.AsiakkaanAllekirjoitusPvm.HasValue;
            }
        }

        public IEnumerable<string> Kiinteistotunnukset
        {
            get
            {
                if (this.Kiinteistot != null)
                    return this.Kiinteistot.Where(x => !string.IsNullOrEmpty(x.KiinteistotunnusLyhyt)).Select(x => x.KiinteistotunnusLyhyt).Distinct();

                return null;
            }
        }

        public IEnumerable<string> Kunnat
        {
            get
            {
                if (this.Kiinteistot != null)
                    return this.Kiinteistot.Where(x => x.Kunta != null).Where(x => !string.IsNullOrEmpty(x.Kunta.KuntaNimi)).Select(x => x.Kunta.KuntaNimi).Distinct();

                return null;
            }
        }

        public IEnumerable<string> Kylat
        {
            get
            {
                if (this.Kiinteistot != null)
                    return this.Kiinteistot.Where(x => !string.IsNullOrEmpty(x.Kyla)).Select(x => x.Kyla).Distinct();

                return null;
            }
        }

        public IEnumerable<string> Rekisterinumerot
        {
            get
            {
                if (this.Kiinteistot != null)
                    return this.Kiinteistot.Where(x => !string.IsNullOrEmpty(x.Rekisterinumero)).Select(x => x.Rekisterinumero).Distinct();

                return null;
            }
        }

        public IEnumerable<string> Tilat
        {
            get
            {
                if (this.Kiinteistot != null)
                    return this.Kiinteistot.Where(x => !string.IsNullOrEmpty(x.KiinteistoNimi)).Select(x => x.KiinteistoNimi).Distinct();

                return null;
            }
        }

        public IEnumerable<string> Kohteet
        {
            get
            {
                if (this.Tunnisteyksikot != null)
                {
                    List<string> kohteet = new List<string>();

                    kohteet.AddRange(this.Tunnisteyksikot.Where(x => !string.IsNullOrEmpty(x.PGTunnus)).Select(x => x.PGTunnus).Distinct());
                    kohteet.AddRange(this.Tunnisteyksikot.Where(x => string.IsNullOrEmpty(x.PGTunnus) && !string.IsNullOrEmpty(x.Nimi)).Select(x => x.Nimi).Distinct());

                    return kohteet;
                }

                return null;
            }
        }

        public IEnumerable<string> Sopimusosapuolet
        {
            get
            {
                if (this.Asiakkaat != null)
                    return this.Asiakkaat.Where(x => x.Taho != null && !string.IsNullOrEmpty(x.Taho.Nimi)).Select(x => x.Taho.Nimi);

                return null;
            }
        }

        public IEnumerable<string> AlkuperaisetOsapuolet
        {
            get
            {
                if (this.Asiakkaat != null)
                    return this.Asiakkaat.Where(x => x.AsiakastyyppiId == (int)Asiakastyypit.AlkuperainenOsapuoli && x.Taho != null && !string.IsNullOrEmpty(x.Taho.Nimi)).Select(x => x.Taho.Nimi);

                return null;
            }
        }

        #endregion

        #region Entiteettiviittaukset

        public virtual Sopimustyyppi Sopimustyyppi { get; set; }
        public virtual Sopimus Paasopimus { get; set; }
        public virtual SopimuksenKesto Kesto { get; set; }
        public virtual Taho JuridinenYhtio { get; set; }
        public virtual Taho Vastuuyksikko { get; set; }
        public virtual Julkisuusaste Julkisuusaste { get; set; }
        public virtual SopimuksenTila SopimuksenTila { get; set; }
        public virtual DFRooli DFRooli { get; set; }
        public virtual Sopimusluokka Sopimusluokka { get; set; }
        public virtual SopimuksenAlaluokka SopimuksenAlaluokka { get; set; }
        public virtual SopimuksenEhtoversio SopimuksenEhtoversio { get; set; }
        public virtual SiirtoOikeus VerkonhaltijaSiirtoOikeus { get; set; }
        public virtual SiirtoOikeus VastaosapuoliSiirtoOikeus { get; set; }
        public virtual Taho AlkuperainenYhtio { get; set; }
        public virtual PuustonPoisto PuustonPoisto { get; set; }
        public virtual PuustonOmistajuus PuustonOmistajuus { get; set; }
        public virtual Kohdekategoria Kohdekategoria { get; set; }
        public virtual Kieli Kieli { get; set; }
        public virtual YlasopimuksenTyyppi YlasopimuksenTyyppi { get; set; }
        public virtual Lupataho Lupataho { get; set; }
        public virtual Vuokratyyppi Vuokratyyppi { get; set; }

        public virtual ICollection<SopimusKiinteisto> SopimusKiinteistot { get; set; }
        public virtual ICollection<SopimusTaho> Asiakkaat { get; set; }
        public virtual ICollection<Tunnisteyksikko> Tunnisteyksikot { get; set; }
        public virtual ICollection<Tiedosto> Tiedostot { get; set; }
        public virtual ICollection<Korvauslaskelma> Korvauslaskelmat { get; set; }

        public IEnumerable<Kiinteisto> Kiinteistot
        {
            get
            {
                if (this.SopimusKiinteistot != null)
                    return this.SopimusKiinteistot.Select(x => x.Kiinteisto);

                return null;
            }
        }

        #endregion

        #region Metodit

        public override bool Equals(object obj)
        {
            var tmp = obj as Sopimus;
            if (tmp == null) return false;
            return tmp.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        #endregion
    }
}
