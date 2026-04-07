using System;
using System.Data.SqlClient;
using System.Transactions;

namespace Sopimusrekisteri.DAL_CF.Repositories
{
    public class SopimusRepository : Repository
    {
        public SopimusRepository(string connectionString, int timeout = 300) : base(connectionString, timeout)
        {
        }

        /// <summary>
        /// Poistaa sopimuksen lopullisesti tietokannasta.
        /// </summary>
        public void PoistaLopullisesti(int sopimusId)
        {
            var options = new TransactionOptions 
            { 
                IsolationLevel = IsolationLevel.RepeatableRead, 
                Timeout = new TimeSpan(0, 10, 0) 
            };

            var kyselyt = new[]
            {
                "DELETE Tunnisteyksikko WHERE TUYSopimusId = @SopimusId",
                "DELETE TiedostoImport WHERE TIISopimusId = @SopimusId",
                "DELETE Tiedosto WHERE TIESopimusId = @SopimusId",
                "DELETE Poiminta WHERE POEntityId = @SopimusId AND POTyyppi = 'sopimus'",
                "DELETE TallennettuPoimintajoukko_Taho WHERE TPJTEsineId = @SopimusId AND TPJTEsineTyyppi = 'sopimus'",
                "DELETE Sopimus_Tuloste WHERE STLSopimusId = @SopimusId",
                "DELETE Sopimus_Taho WHERE SOTSopimusId = @SopimusId",
                "DELETE Sopimus_Kiinteisto WHERE SKSopimusId = @SopimusId",
                "DELETE Maksu_Tiliointi FROM Maksu INNER JOIN Maksu_Tiliointi ON MAKId = MTLMaksuId WHERE MAKSopimusId = @SopimusId",
                "DELETE Maksu WHERE MAKSopimusId = @SopimusId",
                "DELETE KorvauslaskelmaRivi FROM Korvauslaskelma INNER JOIN KorvauslaskelmaRivi ON KORId = KLRKorvauslaskelmaId WHERE KORSopimusId = @SopimusId",
                "DELETE IFRS_Historia WHERE IFRSSopimusId = @SopimusId",
                "DELETE IFRS_Historia FROM Korvauslaskelma INNER JOIN IFRS_Historia ON KORId = IFRSKorvauslaskelmaId WHERE KORSopimusId = @SopimusId",
                "DELETE KorvauslaskelmaLoki FROM Korvauslaskelma INNER JOIN KorvauslaskelmaLoki ON KORId = KLLKorvauslaskelmaId WHERE KORSopimusId = @SopimusId",
                "DELETE Maksu_Tiliointi FROM Korvauslaskelma INNER JOIN Maksu ON MAKKorvauslaskelmaId = KORId INNER JOIN Maksu_Tiliointi ON MAKId = MTLMaksuId WHERE KORSopimusId = @SopimusId",
                "DELETE Maksu FROM Korvauslaskelma INNER JOIN Maksu ON MAKKorvauslaskelmaId = KORId WHERE KORSopimusId = @SopimusId",
                "DELETE Korvauslaskelma WHERE KORSopimusId = @SopimusId",
                "DELETE Aktiviteetti WHERE AKTSopimusId = @SopimusId",
                "DELETE ExcelTuonti_Asiakkaat WHERE ETASopimusnumero = @SopimusId",
                "DELETE ExcelTuonti_Kiinteistot WHERE ETKSopimusnumero = @SopimusId",
                "DELETE ExcelTuonti_Sopimukset WHERE ETSSopimusnumero = @SopimusId",
                "DELETE Sopimus WHERE SOPId = @SopimusId"
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                foreach (var sql in kyselyt)
                {
                    ExecuteNonQuery(sql, new SqlParameter("@SopimusId", sopimusId));
                }

                scope.Complete();
            }
        }

    }
}
