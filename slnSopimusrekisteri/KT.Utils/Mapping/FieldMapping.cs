using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
    public class FieldMapping
    {
        #region Konstruktorit

        public FieldMapping(FieldMappingInfo targetFieldInfo, FieldMappingInfo sourceFieldInfo) : this(targetFieldInfo, sourceFieldInfo, false)
        {            
        }

        public FieldMapping(FieldMappingInfo targetFieldInfo, FieldMappingInfo sourceFieldInfo, bool isIdentityField)
        {
            this.TargetFieldInfo = targetFieldInfo;
            this.SourceFieldInfo = sourceFieldInfo;
        }

        public FieldMapping(string targetFieldName, string sourceFieldName, Type fieldType) : this(new FieldMappingInfo(targetFieldName, fieldType, null), new FieldMappingInfo(sourceFieldName, fieldType, null))
        {
        }

        public FieldMapping(string targetFieldName, string sourceFieldName, Type fieldType, bool isIdentityField)
            : this(new FieldMappingInfo(targetFieldName, fieldType, null), new FieldMappingInfo(sourceFieldName, fieldType, null), isIdentityField)
        {
        }

        #endregion

        #region Propertyt

        public FieldMappingInfo TargetFieldInfo { get; private set; }
        public FieldMappingInfo SourceFieldInfo { get; private set; }
        public MappingDirection MappingDirection { get; set; }

        public bool IsIdentityField { get; set; }

        #endregion

        #region Metodit

        public override string ToString()
        {
            return (this.SourceFieldInfo == null ? string.Empty : this.SourceFieldInfo.ToString()) + " ; " + (this.TargetFieldInfo == null ? string.Empty : this.TargetFieldInfo.ToString());
        }

        #endregion
    }


    public class FieldMapping<T> : FieldMapping
    {
        public FieldMapping(string targetFieldName, string sourceFieldName)
            : base(targetFieldName, sourceFieldName, typeof(T))
        {
        }

        public FieldMapping(string targetFieldName, string sourceFieldName, bool isIdentityField)
            : base(targetFieldName, sourceFieldName, typeof(T), isIdentityField)
        {
        }
    }

    public class FieldMapping<T, U> : FieldMapping
    {
        public FieldMapping(FieldMappingInfo<T> targetFieldInfo, FieldMappingInfo<U> sourceFieldInfo) : base(targetFieldInfo, sourceFieldInfo)
        {
        }

        public FieldMapping(FieldMappingInfo<T> targetFieldInfo, FieldMappingInfo<U> sourceFieldInfo, bool isIdentityField)
            : base(targetFieldInfo, sourceFieldInfo, isIdentityField)
        {
        }

        public FieldMapping(string targetFieldName, string sourceFieldName)
            : base(new FieldMappingInfo<T>(targetFieldName), new FieldMappingInfo<U>(sourceFieldName))
        {
        }

        public FieldMapping(string targetFieldName, string sourceFieldName, bool isIdentityField)
            : base(new FieldMappingInfo<T>(targetFieldName), new FieldMappingInfo<U>(sourceFieldName), isIdentityField)
        {
        }        
        
    }
}
