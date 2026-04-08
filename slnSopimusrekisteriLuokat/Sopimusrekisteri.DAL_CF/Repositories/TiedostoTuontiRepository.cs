using System;
using System.Data;
using System.Data.SqlClient;

namespace Sopimusrekisteri.DAL_CF.Repositories
{
    public class TiedostoTuontiRepository : Repository
    {
        public TiedostoTuontiRepository(string connectionString, int timeout = 300) : base(connectionString, timeout)
        {
        }

        public void TuoValitauluun(DataTable dt, string guid, string username)
        {
            var guidCol = dt.Columns.Add("_GUID", typeof(string));
            var userCol = dt.Columns.Add("_USERNAME", typeof(string));
            var creaCol = dt.Columns.Add("_CREATION", typeof(DateTime));

            foreach (DataRow dr in dt.Rows)
            {
                dr["_GUID"] = guid;
                dr["_USERNAME"] = username ?? "Tuntematon";
                dr["_CREATION"] = DateTime.Now;
            }

            dt.TableName = "TiedostoImport";

            BulkInsert(dt, new[] 
            { 
                new SqlBulkCopyColumnMapping(0, "TIISopimusId"),
                new SqlBulkCopyColumnMapping(1, "TIITiedostoId"),
                new SqlBulkCopyColumnMapping(2, "TIITiedostoNimi"),
                new SqlBulkCopyColumnMapping(3, "TIIMFilesVault"),
                new SqlBulkCopyColumnMapping(4, "TIIMFilesType"),
                new SqlBulkCopyColumnMapping(5, "TIIMFilesId"),
                new SqlBulkCopyColumnMapping(6, "TIIMFilesObject"),
                new SqlBulkCopyColumnMapping(guidCol.Ordinal, "TIISessio"),
                new SqlBulkCopyColumnMapping(userCol.Ordinal, "TIILuoja"),
                new SqlBulkCopyColumnMapping(creaCol.Ordinal, "TIILuotu")
            });

            TasmaaTiedostot(guid);
        }

        private void TasmaaTiedostot(string guid)
        {
            string sql = $@"UPDATE TiedostoImport
                            SET TIITiedostoId = TIEId
                            FROM TiedostoImport
                            INNER JOIN Tiedosto ON TIESopimusId = TIISopimusId AND TIETiedostoNimi = TIITiedostoNimi
                            WHERE TIITiedostoId IS NULL
                            AND TIISopimusId IS NOT NULL
                            AND TIITiedostoNimi IS NOT NULL 
                            AND TIISessio = @guid ";

            ExecuteNonQuery(sql, new SqlParameter("@guid", guid));
        }

        public void TuoTiedot(string sessio, string username)
        {
            PaivitaTiedostot(sessio, username);
            LisaaTiedostot(sessio, username);
        }

        private void PaivitaTiedostot(string sessio, string username)
        {
            string sql = $@"UPDATE Tiedosto SET 
                            TIETiedostoNimi = ISNULL(TIITiedostoNimi, TIETiedostoNimi),
                            TIEMFilesVault = TIIMFilesVault,
                            TIEMFilesType = TIIMFilesType,
                            TIEMFilesId = TIIMFilesId,
                            TIEMFilesObject = TIIMFilesObject,
                            TIEPaivitetty = GETDATE(),
                            TIEPaivittaja = @user
                            FROM Tiedosto
                            INNER JOIN TiedostoImport ON TIITiedostoId = TIEId
                            WHERE TIISessio = @guid
                            AND TIIKasitelty = 0 ";

            ExecuteNonQuery(sql,
                new SqlParameter("@guid", sessio),
                new SqlParameter("@user", username ?? "Tuntematon"));

            sql = "UPDATE TiedostoImport SET TIIKasitelty = 1 WHERE TIISessio = @guid AND TIITiedostoId IS NOT NULL ";
            ExecuteNonQuery(sql, new SqlParameter("@guid", sessio));
        }

        private void LisaaTiedostot(string sessio, string username)
        {
            string sql = $@"INSERT INTO Tiedosto 
                            (TIETiedostoNimi, TIESopimusId, TIEMFilesVault, TIEMFilesType, TIEMFilesId, TIEMFilesObject, TIELuotu, TIELuoja) 
                            SELECT 
                            TIITiedostoNimi, SOPId, TIIMFilesVault, TIIMFilesType, TIIMFilesId, TIIMFilesObject, GETDATE(), @user
                            FROM TiedostoImport
                            LEFT JOIN Sopimus ON SOPId = TIISopimusId 
                            WHERE TIISessio = @guid
                            AND TIITiedostoId IS NULL
                            AND TIIKasitelty = 0 ";

            ExecuteNonQuery(sql,
                new SqlParameter("@guid", sessio),
                new SqlParameter("@user", username ?? "Tuntematon"));

            sql = "UPDATE TiedostoImport SET TIIKasitelty = 1 WHERE TIISessio = @guid AND TIITiedostoId IS NULL ";
            ExecuteNonQuery(sql, new SqlParameter("@guid", sessio));
        }

        public int HaeLisattavienLkm(string guid)
        {
            string sql = "SELECT COUNT(1) FROM TiedostoImport WHERE TIITiedostoId IS NULL AND TIISessio = @guid";
            return (int?)ExecuteScalar(sql, new SqlParameter("@guid", guid)) ?? 0;
        }

        public int HaePaivitettavienLkm(string guid)
        {
            string sql = "SELECT COUNT(1) FROM TiedostoImport WHERE TIITiedostoId IS NOT NULL AND TIISessio = @guid";
            return (int?)ExecuteScalar(sql, new SqlParameter("@guid", guid)) ?? 0;
        }
    }
}
