using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KT.Utils
{
    public class DbUtils
    {



        #region Attribuutit ja vakiot

        private static HashSet<char>[] accentEquivalents = new HashSet<char>[] { new HashSet<char> { 'a', 'á', 'à', 'â' }, new HashSet<char> { 'e', 'é', 'è', 'ê' },
                                                                                 new HashSet<char> { 'i', 'í', 'ì', 'î' }, new HashSet<char> { 'o', 'ó', 'ò', 'ô' },
                                                                                 new HashSet<char> { 'u', 'ú', 'ù', 'û', 'ü' }, new HashSet<char> { 'y', 'ý' } };
        #endregion

        #region Konstruktorit

        public DbUtils(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

        #region Propertyt

        public string ConnectionString { get; set; }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }
        
        #endregion

        #region Kyselyiden ja komentojen suoritus

        public void BulkInsert(DataTable data, string tableName, string fieldPrefix)
        {
            BulkInsert(data, tableName, fieldPrefix, 0, SqlBulkCopyOptions.Default);
        }

        /// <summary>
        /// Inserts data from a DataTable to a specified database table in an efficient way. The column names must match in the database table and the DataSet. Field prefixes may be used.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <param name="fieldPrefix"></param>
        /// <param name="timeout"></param>
        /// <param name="options"></param>
        /// <remarks></remarks>

        public void BulkInsert(DataTable data, string tableName, string fieldPrefix, int timeout, SqlBulkCopyOptions options)
        {
            using (SqlBulkCopy sqlCopy = new SqlBulkCopy(this.ConnectionString, options))
            {

                sqlCopy.DestinationTableName = tableName;

                foreach (DataColumn column in data.Columns)
                {
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(column.ColumnName, fieldPrefix + column.ColumnName));
                }

                sqlCopy.NotifyAfter = data.Rows.Count;
                if (timeout > 0)
                    sqlCopy.BulkCopyTimeout = timeout;
                sqlCopy.WriteToServer(data);
                sqlCopy.Close();
            }

        }

        public DataSet ExecuteDataSet(SqlCommand cmd, params SqlParameter[] @params)
        {
            DataSet ds = null;

            AddParameters(cmd, @params);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public DataSet ExecuteDataSet(string commandText, params SqlParameter[] @params)
        {
            DataSet ds = null;

            using (SqlConnection conn = this.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {

                    ds = ExecuteDataSet(cmd, @params);

                }

                conn.Close();
            }

            return ds;
        }        

        public int ExecuteNonQuery(string commandText, params SqlParameter[] @params)
        {
            int affected = 0;
            using (SqlConnection conn = this.GetConnection())
            {
                conn.Open();                

                affected = ExecuteNonQuery(conn, commandText, @params);

                conn.Close();
            }
            return affected;
        }

        public int ExecuteNonQuery(SqlConnection connection, string commandText, params SqlParameter[] @params)
        {
            int affected = 0;
            using (SqlCommand cmd = new SqlCommand(commandText, connection))
            {

                AddParameters(cmd, @params);

                affected = cmd.ExecuteNonQuery();

            }
            return affected;
        }

        public object ExecuteScalar(string commandText, params SqlParameter[] @params)
        {
            object returnVal = null;

            using (SqlConnection conn = this.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {

                    AddParameters(cmd, @params);

                    returnVal = cmd.ExecuteScalar();

                }

                conn.Close();
            }

            return returnVal;
        }
        
        #endregion

        #region Parametrit

        public static SqlParameter CreateSqlParameter(string paramName, object value)
        {
            return CreateSqlParameter(paramName, value, false);
        }

        public static SqlParameter CreateSqlParameter(string paramName, object value, bool nullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.IsNullable = nullable;
            if ((value == null))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            return param;
        }

        public static SqlParameter CreateSqlParameter(string paramName, SqlDbType type, object value, bool nullable)
        {
            SqlParameter p = CreateSqlParameter(paramName, value, nullable);
            p.SqlDbType = type;
            return p;
        }

        #endregion

        #region Skeema

        /// <summary>
        /// Returns an empty DataTable that contains only the schema information of the table in question.
        /// </summary>
        /// <param name="tableName">Name of the database table</param>
        /// <returns>DataTable that contains the schema information of the table</returns>
        /// <remarks></remarks>
        public DataTable GetTableSchema(string tableName)
        {

            string sql = "SET FMTONLY ON; SELECT * FROM " + tableName + "; SET FMTONLY OFF;";
            return this.ExecuteDataSet(sql).Tables[0];

        }

        #endregion

        #region Arvojen tarkistus ja käsittely

        public static bool DataRowHasValue(DataRow dr, string fieldName)
        {
            object value = dr[fieldName];
            return (value != null) && !Convert.IsDBNull(value);
        }

        public static bool DataSetHasValues(DataSet ds)
        {
            return ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }

        public static int GetIntValue(DataRow dr, string fieldName, int defaultValue)
        {
            if (DataRowHasValue(dr, fieldName))
                return Convert.ToInt32(dr[fieldName]);
            return defaultValue;
        }

        public static string GetStringValue(DataRow dr, string fieldName, string defaultValue)
        {
            if (DataRowHasValue(dr, fieldName))
                return Convert.ToString(dr[fieldName]);
            return defaultValue;
        }

        public static T GetValue<T>(DataRow dr, string fieldName, T defaultValue)
        {
            if (DataRowHasValue(dr, fieldName))
                return (T)dr[fieldName];
            return defaultValue;
        }

        #endregion

        #region Arvojen kopiointi / kloonaus

        public static DataRow CloneDataRow(DataRow source)
        {
            DataRow newRow = source.Table.NewRow();

            CopyDataRowValues(source, newRow);

            return newRow;
        }

        public static void CopyDataRowValues(DataRow sourceRow, DataRow targetRow)
        {
            foreach (DataColumn dc in sourceRow.Table.Columns)
            {
                if (targetRow.Table.Columns[dc.ColumnName] != null) targetRow[dc.ColumnName] = sourceRow[dc.ColumnName];
            }
        } 

        #endregion

        #region Sekalaiset

        public string GetTextValueByIdValue(int idValue, string tableName, string idFieldName, string textFieldName)
        {
            string sql = "select " + textFieldName + " from " + tableName + " where " + idFieldName + " = " + Convert.ToString(idValue);
            object obj = this.ExecuteScalar(sql);
            if ((obj == null))
                return string.Empty;
            return Convert.ToString(obj);
        }

        public static string SearchStringToAccentInsensitive(string targetString)
        {

            StringBuilder replacedString = new StringBuilder();


            foreach (char charValue in targetString)
            {
                replacedString.Append(CreateAccentCharacterReplacementString(charValue));

            }

            return replacedString.ToString();           

        }

        private static string CreateAccentCharacterReplacementString(char charValue)
        {
            foreach (HashSet<char> charSet in accentEquivalents)
            {

                if (charSet.Contains(charValue))
                {                    
                    return "[" + CollectionUtils.CollectionToCsv<char>(charSet, "|") + "]";
                }

            }

            return charValue.ToString();
        }

        #endregion

        #region Apufunktiot

        private static void AddParameters(SqlCommand cmd, params SqlParameter[] @params)
        {
            if ((@params == null))
                return;
            foreach (SqlParameter param in @params)
            {
                if ((param != null))
                    cmd.Parameters.Add(param);
            }
        }

        #endregion

    }
}
