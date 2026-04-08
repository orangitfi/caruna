using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
    public class FieldMappingInfo
    {

        private Type _fieldType;

        #region Konstruktorit

        public FieldMappingInfo(string fieldName, Type fieldType, object defaultValue) : this(fieldName, fieldType, defaultValue, null)
        {
        }

        public FieldMappingInfo(string fieldName, Type fieldType, object defaultValue, object emptyValue)
        {
            this.FieldName = fieldName;
            this.FieldType = fieldType;
            this.DefaultValue = defaultValue;
        }

        public FieldMappingInfo(string fieldName, Type fieldType) : this(fieldName, fieldType, null, null)
        {
        }

        #endregion

        #region Propertyt

        public string FieldName { get; private set; }

        public Type FieldType
        {
            get { return this._fieldType; }
            private set
            {
                Type nullableBaseType = Nullable.GetUnderlyingType(value);
                this._fieldType = (nullableBaseType == null ? value : nullableBaseType);
            }
        }

        public object DefaultValue { get; set; }

        public object EmptyValue { get; set; }

        #endregion

        public override string ToString()
        {
            return this.FieldName;
        }
    }

    public class FieldMappingInfo<T> : FieldMappingInfo
    {
        public FieldMappingInfo(string fieldName, T defaultValue, T emptyValue) : base(fieldName, typeof(T), defaultValue, emptyValue)
        {
        }

        public FieldMappingInfo(string fieldName, T defaultValue)
            : base(fieldName, typeof(T), defaultValue, null)
        {
        }

        public FieldMappingInfo(string fieldName)
            : base(fieldName, typeof(T), null, null)
        {
        }
    }

}
