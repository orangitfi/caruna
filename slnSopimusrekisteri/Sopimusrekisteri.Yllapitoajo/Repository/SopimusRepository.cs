using Dapper;
using Sopimusrekisteri.Yllapitoajo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sopimusrekisteri.Yllapitoajo.Repository
{
    public class SopimusRepository
    {

        private string ConnectionString { get; }
        private int Timeout { get; }

        public SopimusRepository(string connectionString, int timeout = 300)
        {
            ConnectionString = connectionString;
            Timeout = timeout;
        }

        public IEnumerable<LaskennallinenPaattymispvmModel> HaeLaskennallisetPaattymispaivat(int offset, int limit)
        {
            string sql = $@"SELECT 
                            GETDATE() AS Nyt,
                            SOPId AS SopimusId,
                            SOPPaattyy AS Paattyy,
                            SOPIrtisanomispvm AS Irtisanottu,
                            SOPJatkoaika AS Jatkoaika,
                            SOPSopimuksenIrtisanomisaika AS Irtisanomisaika,
                            SOPLaskennallinenPaattymispvm AS Nykyarvo
                            FROM Sopimus
                            ORDER BY SOPId
                            OFFSET {offset} ROWS
                            FETCH NEXT {limit} ROWS ONLY ";

            using (var conn = OpenConnection())
            {
                return conn.Query<LaskennallinenPaattymispvmModel>(sql, commandTimeout: Timeout);
            }
        }

        public SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public void PaivitaLaskennallinenPaattymispaiva(SqlConnection conn, int sopimusId, DateTime? pvm)
        {
            string sql = $@"UPDATE Sopimus 
                            SET SOPLaskennallinenPaattymispvm = @pvm 
                            WHERE SOPId = @sopimusId";

            conn.Execute(sql, new { sopimusId, pvm }, commandTimeout: Timeout);
        }

    }
}
