using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KT.Utils.Mapping
{
    public class ObjectMapper
    {

        #region Attribuutit ja vakiot

        private Type targetType;
        private List<PropertyInfo> _properties;

        private Dictionary<string, TypeConverter> _converters;
        #endregion

        #region Konstruktorit

        public ObjectMapper(Type targetType)
        {
            this.targetType = targetType;
        }

        #endregion

        #region Propertyt

        private Dictionary<string, TypeConverter> Converters
        {
            get
            {
                if ((this._converters == null))
                    this._converters = new Dictionary<string, TypeConverter>();
                return this._converters;
            }
        }

        private List<PropertyInfo> Properties
        {
            get
            {

                if ((this._properties == null))
                {
                    this._properties = new List<PropertyInfo>();

                    foreach (PropertyInfo pi in this.targetType.GetProperties(System.Reflection.BindingFlags.Public | BindingFlags.Instance))
                    {                        
                        if (pi.PropertyType.IsValueType || pi.PropertyType.Name == "String") this._properties.Add(pi);
                    }

                }

                return this._properties;
            }
        }

        #endregion

        #region Mappaus

        #region Save / update

        public SqlCommand CreateSqlUpdateOrInsertCommand(string connectionString, object sourceObject, string tableName, string fieldPrefix, string idField, object idValue)
        {
            return CreateSqlUpdateOrInsertCommand(connectionString, sourceObject, tableName, fieldPrefix, idField, idValue, null);
        }

        public SqlCommand CreateSqlUpdateOrInsertCommand(string connectionString, object sourceObject, string tableName, string fieldPrefix, string idField, object idValue, KeyObjectValuePair[] additionalValues)
        {
            DbUtils dbu = new DbUtils(connectionString);
            DataTable schemaTable = dbu.GetTableSchema(tableName);
            SqlCommand cmd = new SqlCommand();
            StringBuilder valuesStr = new StringBuilder();
            StringBuilder setStr = new StringBuilder();
            bool update = (idValue != null);

            foreach (DataColumn column in schemaTable.Columns)
            {
                string columnName = column.ColumnName;
                if (columnName == idField)
                    continue;

                if ((additionalValues != null))
                {
                    KeyObjectValuePair valuePair = additionalValues.SingleOrDefault(f => f.Key == columnName);
                    if ((valuePair != null))
                    {                        
                        this.AddSqlParameterValue(cmd, update, valuePair.Value, column, setStr, valuesStr);
                        continue;
                    }
                }

                PropertyInfo pInfo = this.Properties.SingleOrDefault(f => fieldPrefix.ToLower() + f.Name.ToLower() == columnName.ToLower());
                if ((pInfo == null))
                    continue;

                object value = pInfo.GetValue(sourceObject, null);
                this.AddSqlParameterValue(cmd, update, value, column, setStr, valuesStr);

            }

            string insertUpdate = null;
            string whereStr = null;

            if (update)
            {
                insertUpdate = string.Format("update {0} SET ", tableName) + setStr.ToString();
                whereStr = string.Format(" where {0} = {1}", idField, idValue);
            }
            else
            {
                insertUpdate = string.Format("insert into {0} ({1}) VALUES ({2})", tableName, setStr.ToString(), valuesStr.ToString());
                whereStr = string.Empty;
            }

            SqlParameter returnParam = new SqlParameter("returnId", SqlDbType.VarChar, 100);
            returnParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnParam);

            cmd.CommandText = insertUpdate + whereStr + "; SET @returnId = scope_identity();";
            cmd.Connection = dbu.GetConnection();

            return cmd;
        }

        //public SqlCommand CreateSqlUpdateOrInsertCommand(SqlConnection connection, object sourceObject, string tableName, string fieldPrefix, string idField, object idValue, KeyObjectValuePair[] additionalValues)
        //{
        //    DbUtils dbu = new DbUtils(connection.ConnectionString);
        //    DataTable schemaTable = dbu.GetTableSchema(tableName);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = connection;
        //    StringBuilder valuesStr = new StringBuilder();
        //    StringBuilder setStr = new StringBuilder();
        //    bool update = (idValue != null);

        //    foreach (DataColumn column in schemaTable.Columns)
        //    {
        //        string columnName = column.ColumnName;
        //        if (columnName == idField)
        //            continue;

        //        if ((additionalValues != null))
        //        {
        //            KeyObjectValuePair valuePair = additionalValues.SingleOrDefault(f => f.Key == columnName);
        //            if ((valuePair != null))
        //            {
        //                this.AddSqlParameterValue(cmd, update, valuePair.Value, column, setStr, valuesStr);
        //                continue;
        //            }
        //        }

        //        PropertyInfo pInfo = this.Properties.SingleOrDefault(f => fieldPrefix.ToLower() + f.Name.ToLower() == columnName.ToLower());
        //        if ((pInfo == null))
        //            continue;

        //        object value = pInfo.GetValue(sourceObject, null);
        //        this.AddSqlParameterValue(cmd, update, value, column, setStr, valuesStr);

        //    }

        //    string insertUpdate = null;
        //    string whereStr = null;

        //    if (update)
        //    {
        //        insertUpdate = string.Format("update {0} SET ", tableName) + setStr.ToString();
        //        whereStr = string.Format(" where {0} = {1}", idField, idValue);
        //    }
        //    else
        //    {
        //        insertUpdate = string.Format("insert into {0} ({1}) VALUES ({2})", tableName, setStr.ToString(), valuesStr.ToString());
        //        whereStr = string.Empty;
        //    }

        //    SqlParameter returnParam = new SqlParameter("returnId", SqlDbType.VarChar, 100);
        //    returnParam.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(returnParam);

        //    cmd.CommandText = insertUpdate + whereStr + "; SET @returnId = scope_identity();";
        //    cmd.Connection = dbu.GetConnection();

        //    return cmd;
        //}

        public object SaveObjectToDataBase(string connectionString, object sourceObject, string tableName, string fieldPrefix, string idField, object idValue)
        {
            return SaveObjectToDataBase(connectionString, sourceObject, tableName, fieldPrefix, idField, idValue, null);
        }

        public object SaveObjectToDataBase(string connectionString, object sourceObject, string tableName, string fieldPrefix, string idField, object idValue, KeyObjectValuePair[] additionalValues)
        {
            object returnId = null;
            using (SqlCommand cmd = CreateSqlUpdateOrInsertCommand(connectionString, sourceObject, tableName, fieldPrefix, idField, idValue, additionalValues))
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                // If String.IsNullOrEmpty(idField) Then
                if ((idValue == null))
                {
                    returnId = cmd.Parameters["returnId"].Value;
                }
                else
                {
                    returnId = idValue;
                }
            }
            return returnId;
        }

        #endregion

        #region Olion arvojen asetus

        public void FillValuesFromDataRow(object target, DataRow source)
        {
            this.FillValuesFromDataRow(target, source, string.Empty);
        }


        public void FillValuesFromDataRow(object target, DataRow source, string fieldPrefix)
        {
            foreach (PropertyInfo pi in this.Properties)
            {
                if (!pi.CanWrite)
                    continue;
                // TODO: Tarkasta tämä kohta.
                string fieldName = fieldPrefix + pi.Name;

                if (source.Table.Columns.Contains(fieldName) && DbUtils.DataRowHasValue(source, fieldName))
                {
                    if (pi.PropertyType == source.Table.Columns[fieldName].DataType)
                    {
                        pi.SetValue(target, source[fieldName], null);
                    }
                    else
                    {
                        object value = null;
                        if (pi.PropertyType.IsEnum)
                        {
                            value = Enum.Parse(pi.PropertyType, Convert.ToString(source[fieldName]));
                        }
                        else
                        {
                            Type nullableType = Nullable.GetUnderlyingType(pi.PropertyType);
                            if (nullableType == null)
                            {
                                value = Convert.ChangeType(source[fieldName], pi.PropertyType);
                            }
                            else
                            {
                                if (nullableType.IsEnum)
                                {
                                    value = Enum.Parse(nullableType, Convert.ToString(source[fieldName]));
                                }
                                else
                                {
                                    TypeConverter converter = null;
                                    if (this.Converters.ContainsKey(nullableType.Name))
                                    {
                                        converter = this.Converters[nullableType.Name];
                                    }
                                    else
                                    {
                                        converter = TypeDescriptor.GetConverter(pi.PropertyType);
                                        this.Converters[nullableType.Name] = converter;
                                    }
                                    value = converter.ConvertFrom(source[fieldName]);
                                }
                            }

                        }
                        pi.SetValue(target, value, null);
                    }
                }

            }

        }

        #endregion

        #region DataTable konversio

        public DataTable ObjectsToDataTable(System.Collections.IEnumerable sourceObjectCollection, List<MappingKeyPair> mappings)
        {
            DataTable dt = new DataTable();
            this.ObjectsToDataTable(sourceObjectCollection, mappings, dt);
            return dt;
        }

        public void ObjectsToDataTable(System.Collections.IEnumerable sourceObjectCollection, List<MappingKeyPair> mappings, DataTable targetTable)
        {
            Dictionary<string, PropertyInfo> propertyList = new Dictionary<string, PropertyInfo>();

            if ((mappings != null))
            {
                foreach (MappingKeyPair m in mappings)
                {
                    string sourceKey = m.SourceKey;
                    if (!propertyList.ContainsKey(sourceKey))
                    {
                        PropertyInfo p = this.targetType.GetProperty(sourceKey, System.Reflection.BindingFlags.Public | BindingFlags.Instance);
                        propertyList[sourceKey] = p;
                    }
                    PropertyInfo pi = propertyList[sourceKey];

                    Type dtType = GetTypeForDataTableColumn(pi.PropertyType);

                    targetTable.Columns.Add(new DataColumn(m.TargetKey, dtType));
                }
            }
            else
            {
                foreach (PropertyInfo pi in this.targetType.GetProperties(System.Reflection.BindingFlags.Public | BindingFlags.Instance))
                {
                    propertyList.Add(pi.Name, pi);
                }

                foreach (PropertyInfo pi in propertyList.Values)
                {
                    Type dtType = GetTypeForDataTableColumn(pi.PropertyType);

                    targetTable.Columns.Add(new DataColumn(pi.Name, dtType));
                }
            }

            foreach (object obj in sourceObjectCollection)
            {
                DataRow row = targetTable.NewRow();
                this.ObjectToDataRow(obj, row, mappings, propertyList);
                targetTable.Rows.Add(row);
            }
        }

        private void ObjectToDataRow(object sourceObject, DataRow targetRow, List<MappingKeyPair> mappings, Dictionary<string, PropertyInfo> propertyList)
        {
            if ((mappings != null))
            {
                foreach (MappingKeyPair m in mappings)
                {
                    string sourceKey = m.SourceKey;
                    PropertyInfo pi = propertyList[sourceKey];
                    object value = GetPropertyValueForDataRow(pi, sourceObject);
                    targetRow[m.TargetKey] = value;
                }
            }
            else
            {
                foreach (PropertyInfo pi in propertyList.Values)
                {
                    object value = GetPropertyValueForDataRow(pi, sourceObject);
                    targetRow[pi.Name] = value;

                }
            }
        }

        #endregion

        #endregion

        #region Apumetodit

        private void AddSqlParameterValue(SqlCommand cmd, bool update, object value, DataColumn column, StringBuilder setStr, StringBuilder valuesStr)
        {
            SqlParameter param = default(SqlParameter);
            if ((value == null))
            {
                param = new SqlParameter(column.ColumnName, DBNull.Value);
                param.IsNullable = true;
            }
            else
            {
                param = new SqlParameter(column.ColumnName, Convert.ChangeType(value, column.DataType));
            }

            cmd.Parameters.Add(param);

            if (update)
            {
                if (setStr.Length > 0)
                    setStr.Append(", ");
                setStr.Append(column.ColumnName + " = " + "@" + column.ColumnName);
            }
            else
            {
                if (setStr.Length > 0)
                    setStr.Append(", ");
                setStr.Append(column.ColumnName);
                if (valuesStr.Length > 0)
                    valuesStr.Append(", ");
                valuesStr.Append("@" + column.ColumnName);
            }
        }

        private object GetPropertyValueForDataRow(PropertyInfo pi, object sourceObject)
        {
            object value = pi.GetValue(sourceObject, null);
            if ((value != null) && !pi.PropertyType.IsValueType && pi.PropertyType.Name != "String")
            {
                MethodInfo mi = value.GetType().GetMethod("ToString");
                if ((mi != null))
                    value = mi.Invoke(value, null);
                else
                    value = string.Empty;
            }
            if ((value == null))
                value = DBNull.Value;
            return value;
        }

        private Type GetTypeForDataTableColumn(Type propertyType)
        {
            Type dtType = null;
            if (propertyType.IsValueType || propertyType.Name == "String")
                dtType = propertyType;
            else
                dtType = typeof(string);
            Type nullableType = Nullable.GetUnderlyingType(propertyType);
            if ((nullableType != null))
                dtType = nullableType;
            return dtType;
        }


        #endregion

    }
}
