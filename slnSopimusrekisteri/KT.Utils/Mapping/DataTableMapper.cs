using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace KT.Utils.Mapping
{
    public class DataTableMapper
    {
        public DataTableMapper()
        {            
        }

        public static DataTable EntitiesToDataTable<T>(IEnumerable<T> entities, IEnumerable<DataColumnMapping<T>> columnMappings)
        {
            DataTable dt = new DataTable();
            TypeCache tc = new TypeCache();

            foreach (DataColumnMapping mapping in columnMappings)
            {
                dt.Columns.Add(mapping.ColumnName, mapping.DataType);
            }

            foreach (T item in entities)
            {
                DataRow dr = dt.NewRow();

                foreach (DataColumnMapping mapping in columnMappings)
                {
                    dr.SetField(mapping.ColumnName, mapping.GetValue(item));
                }

                dt.Rows.Add(dr);

            }

            return dt;
        }

        public static DataTable EntitiesToDataTable<T>(IEnumerable<T> entities)
        {
            return EntitiesToDataTable<T>(entities, string.Empty, null, null);
            //
        }

        public static DataTable EntitiesToDataTable<T>(IEnumerable<T> entities, string fieldPrefix)
        {
            return EntitiesToDataTable<T>(entities, fieldPrefix, null, null);
        }

        public static DataTable EntitiesToDataTable<T>(IEnumerable<T> entities, string fieldPrefix, IEnumerable<MappingKeyPair> mappings, DataTable targetTable)
        {
            Type t = typeof(T);
            DataTable dt = targetTable;
            if (dt == null) dt = new DataTable();
            GenericPropertyAccessor gpa = new GenericPropertyAccessor();
            gpa.AddPropertiesFromType(t, true);
            List<PropertyInfo> mappedProperties = new List<PropertyInfo>();

            if (mappings == null)
            {
                foreach (PropertyInfo pi in gpa.GetPropertyInfosByType(t))
                {
                    string fieldName = fieldPrefix + pi.Name;
                    if (!dt.Columns.Contains(fieldName)) dt.Columns.Add(fieldName, GetDataTableType(pi.PropertyType));
                    mappedProperties.Add(pi);
                }
            }
            else
            {
                foreach (MappingKeyPair pair in mappings)
                {
                    PropertyInfo pi = gpa.GetPropertyInfo(t, pair.SourceKey);
                    string fieldName = fieldPrefix + pi.Name;
                    if (!dt.Columns.Contains(fieldName)) dt.Columns.Add(fieldName, GetDataTableType(pi.PropertyType));
                    mappedProperties.Add(pi);
                }
            }

            foreach (T entity in entities)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);

                foreach (PropertyInfo pi in mappedProperties)
                {
                    string fieldName = fieldPrefix + pi.Name;
                    //dr[fieldName] = pi.GetValue(entity, null);
                    dr.SetField(fieldName, pi.GetValue(entity, null));
                }
            }

            return dt;
        }

        private static Type GetDataTableType(Type t)
        {
            if (t.IsEnum)
            {
                return typeof(int); // TODO: Pitäisi selvittää oikea tyyppi.
            }
            Type nullableBaseType = Nullable.GetUnderlyingType(t);
            if (nullableBaseType != null) return nullableBaseType;
            return t;
        }

    }
}
