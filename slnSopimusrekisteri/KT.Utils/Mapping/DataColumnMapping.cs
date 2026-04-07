using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
    public abstract class DataColumnMapping
    {
        public DataColumnMapping()
        {

        }

        public DataColumnMapping(string columnName, Type dataType)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
        }

        public string ColumnName { get; set; }

        public Type DataType { get; set; }

        public abstract object GetValue(object entity);
    }

    public class DataColumnMapping<T> : DataColumnMapping
    {
        public DataColumnMapping(string columnName, Type dataType) : base(columnName, dataType)
        {            
        }

        public DataColumnMapping(string columnName, Type dataType, Func<T, object> valueFunction)
            : this(columnName, dataType)
        {
            this.ValueFunction = valueFunction;
        }

        public Func<T, object> ValueFunction { get; set; }

        public override object GetValue(object entity)
        {
            return this.ValueFunction((T)entity);
        }

    }

}
