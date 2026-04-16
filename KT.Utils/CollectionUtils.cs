using KT.Utils.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


namespace KT.Utils
{
    public class CollectionUtils
    {

        #region Casting an parsing

        public static IEnumerable<T> CastCollection<T>(IEnumerable values)
        {
            List<T> results = new List<T>();

            foreach (object obj in values)
                results.Add((T)obj);

            return results;
        }

        public static IEnumerable<T> ParseCollection<T>(IEnumerable<String> stringValues, Func<String, T> parseFunc)
        {
            List<T> values = new List<T>(stringValues.Count());

            foreach (string stringValue in stringValues)
            {
                values.Add(parseFunc(stringValue));
            }

            return values;
        }



        #endregion

        #region Csv

        public static string CollectionToCsv<T>(IEnumerable<T> values)
        {
            return CollectionToCsv<T>(values, ",");
        }

        public static string CollectionToCsv<T>(IEnumerable<T> values, string separator)
        {

            StringBuilder sb = new StringBuilder();

            foreach (T item in values)
            {
                if ((item == null))
                    continue;
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(item.ToString());
            }

            return sb.ToString();

        }

        public static string ParamArrayToCsv<T>(string separator, params T[] values)
        {
            return CollectionToCsv(values, separator);
        }

        public static string DataTableFieldToCsv(DataTable dt, string columnName, string separator)
        {

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(dr[columnName].ToString());
            }

            return sb.ToString();

        }

        #endregion

        #region MyRegion

        public static void RemoveRange<T>(ICollection<T> col, IEnumerable<T> entitiesToRemove)
        {
            foreach (T entity in entitiesToRemove)
            {
                col.Remove(entity);
            }
        }

        #endregion

        #region DataTable

        public static T[] DataTableFieldToArray<T>(DataTable dt, string fieldName)
        {

            T[] values = new T[dt.Rows.Count];

            int i = 0;

            foreach (DataRow dr in dt.Rows)
            {
                values[i] = (T)dr[fieldName];
                i += 1;
            }

            return values;

        }

        #endregion

        public static DataTable CreateDatatable(Type[] types, IEnumerable<CollectionColumn> columns)
        {

            DataTable dt = new DataTable();
            PropertyInfo pInfo = null;
            Type pType;

            GenericPropertyAccessor propertyAccessor = new GenericPropertyAccessor();

            foreach (CollectionColumn col in columns)
            {

                foreach (Type type in types)
                {

                    pInfo = propertyAccessor.GetPropertyInfoFromType(type, col.DataField);

                    if (pInfo != null)
                    {
                        break;
                    }

                }

                if (pInfo == null)
                {
                    throw new ArgumentException(string.Format("Could not resolve column '{0}'.", col.DataField));
                }

                pType = pInfo.PropertyType;

                if (pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {

                    pType = Nullable.GetUnderlyingType(pType);

                }

                if (!dt.Columns.Contains(col.HeaderText))
                {
                    dt.Columns.Add(col.HeaderText, pType);
                }

            }

            return dt;

        }

        public static DataTable GenerateDatatableFromCollection(Type[] types, IEnumerable<object> collection, IEnumerable<CollectionColumn> columns)
        {

            DataTable dt = CreateDatatable(types, columns);

            DataRow dr;

            GenericPropertyAccessor propertyAccessor = new GenericPropertyAccessor();

            foreach (object row in collection)
            {

                dr = dt.NewRow();

                foreach (CollectionColumn col in columns)
                {

                    if (propertyAccessor.GetPropertyInfoFromType(row.GetType(), col.DataField) != null)
                    {

                        KeyValuePair<object, System.Reflection.PropertyInfo> propertyData = propertyAccessor.GetPropertyInfoAndEntity(row.GetType(), row, col.DataField);

                        if (propertyData.Key != null && propertyData.Value != null)
                        {
                            if (propertyData.Value.GetValue(propertyData.Key, null) != null)
                            {
                                dr[col.HeaderText] = propertyData.Value.GetValue(propertyData.Key, null);
                            }

                        }

                    }

                }

                dt.Rows.Add(dr);

            }

            return dt;

        }

        public static DataTable GenerateDatatableFromCollection<T>(IEnumerable<T> collection, IEnumerable<CollectionColumn> columns)
        {
            return GenerateDatatableFromCollection(new Type[] { typeof(T) }, collection.Cast<object>(), columns);
        }

    }
}
