using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sopimusrekisteri.DAL_CF.Repositories
{
    public class Repository
    {

        public string ConnectionString { get; set; }
        public int Timeout { get; set; }

        public Repository(string connectionString, int timeout = 300)
        {
            ConnectionString = connectionString;
            Timeout = timeout;
        }

        public void BulkInsert(DataTable table, IEnumerable<SqlBulkCopyColumnMapping> mappings = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                BulkInsert(conn, table, mappings);
            }
        }

        public int ExecuteNonQuery(string strSQL, IEnumerable<SqlParameter> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                return ExecuteNonQuery(conn, strSQL, parameters);
            }
        }

        public int ExecuteNonQuery(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                return ExecuteNonQuery(conn, strSQL, parameters);
            }
        }

        public DataSet ExecuteDataSet(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                return ExecuteDataSet(conn, strSQL, parameters);
            }
        }

        public object ExecuteScalar(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                return ExecuteScalar(conn, strSQL, parameters);
            }
        }

        protected DataTable GetDataTableSchema(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var dt = ExecuteDataSet(conn, $"SELECT TOP 0 * FROM {table}").Tables[0];

                dt.TableName = table;

                return dt;
            }
        }

        public void BulkInsert(SqlConnection conn, DataTable table, IEnumerable<SqlBulkCopyColumnMapping> mappings = null)
        {
            using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
            {
                bulk.DestinationTableName = table.TableName;
                bulk.BulkCopyTimeout = Timeout;

                if (mappings != null)
                {
                    foreach (var mapping in mappings) bulk.ColumnMappings.Add(mapping);
                }
                else
                {
                    foreach (DataColumn column in table.Columns) bulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }

                if (conn.State != ConnectionState.Open) conn.Open();
                bulk.WriteToServer(table);
            }
        }

        protected SqlBulkCopyColumnMapping BulkMapping(string dtSarake, string kantaSarake)
        {
            return new SqlBulkCopyColumnMapping(dtSarake, kantaSarake);
        }

        protected SqlBulkCopyColumnMapping BulkMapping(int dtSarake, string kantaSarake)
        {
            return new SqlBulkCopyColumnMapping(dtSarake, kantaSarake);
        }

        public object ExecuteScalar(SqlConnection conn, string strSQL, IEnumerable<SqlParameter> parameters = null)
        {
            using (SqlCommand command = new SqlCommand(strSQL, conn))
            {
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                command.CommandTimeout = Timeout;

                if (conn.State != ConnectionState.Open) conn.Open();
                return command.ExecuteScalar();
            }
        }

        public int ExecuteNonQuery(SqlConnection conn, string strSQL, IEnumerable<SqlParameter> parameters = null)
        {
            using (SqlCommand command = new SqlCommand(strSQL, conn))
            {
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                command.CommandTimeout = Timeout;

                if (conn.State != ConnectionState.Open) conn.Open();
                return command.ExecuteNonQuery();
            }
        }

        public DataSet ExecuteDataSet(SqlConnection conn, string strSQL, IEnumerable<SqlParameter> parameters = null)
        {
            using (SqlCommand command = new SqlCommand(strSQL, conn))
            {
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                command.CommandTimeout = Timeout;
                var adapter = new SqlDataAdapter();
                var ds = new DataSet();

                adapter.SelectCommand = command;

                if (conn.State != ConnectionState.Open) conn.Open();

                adapter.Fill(ds);

                return ds;
            }
        }

        protected object ValueOrDBNull(object value)
        {
            if (value == null)
                return DBNull.Value;

            return value;
        }

        protected SqlParameter Parameter(string key, object value)
        {
            return new SqlParameter(key, value);
        }

    }
}
