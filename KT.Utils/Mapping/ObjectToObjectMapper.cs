using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KT.Utils.Mapping
{

    public class ObjectToObjectMapper
    {
        private Dictionary<string, PropertyInfo> _sourceProperties;
        private Dictionary<string, PropertyInfo> _targetProperties;

        #region Konstruktorit

        public ObjectToObjectMapper(Type targetType, Type sourceType)
        {
            this.TargetType = targetType;
            this.SourceType = sourceType;
        }

        #endregion

        #region Propertyt

        public Type TargetType { get; private set; }
        public Type SourceType { get; private set; }

        private Dictionary<string, PropertyInfo> SourceProperties
        {
            get
            {
                if (this._sourceProperties == null) this._sourceProperties = new Dictionary<string, PropertyInfo>();
                return this._sourceProperties;
            }
        }

        private Dictionary<string, PropertyInfo> TargetProperties
        {
            get
            {
                if (this._targetProperties == null) this._targetProperties = new Dictionary<string, PropertyInfo>();
                return this._targetProperties;
            }
        }

        #endregion

        #region Metodit

        private PropertyInfo GetPropertyInfo(string propertyName, Type t, Dictionary<string, PropertyInfo> collection)
        {
            if (!collection.ContainsKey(propertyName)) collection[propertyName] = t.GetProperty(propertyName);
            return collection[propertyName];
        }

        private object GetConvertedValue(object value, Type targetType, Type sourceType)
        {
            if (targetType == sourceType) return value;

            if (targetType.IsEnum)
            {
                return Enum.Parse(targetType, value.ToString());
            }

            return Convert.ChangeType(value, targetType);
        }

        public void WriteToTarget<T, U>(T targetObject, U sourceObject, ClassMapping classMapping)
        {
            this.WriteToTarget(targetObject, sourceObject, classMapping, null);
        }

        public void WriteToTarget<T, U>(T targetObject, U sourceObject, ClassMapping classMapping, bool? identityFields)
        {
            FieldMappingCollection mappings = classMapping.FieldMappings;

            foreach (FieldMapping mapping in mappings.Mappings.Where(x => !identityFields.HasValue || x.IsIdentityField == identityFields.Value))
            {
                if (mapping.MappingDirection == MappingDirection.Write) continue;

                PropertyInfo targetPropertyInfo = this.GetPropertyInfo(mapping.TargetFieldInfo.FieldName, this.TargetType, this.TargetProperties);

                PropertyInfo sourcePropertyInfo = this.GetPropertyInfo(mapping.SourceFieldInfo.FieldName, this.SourceType, this.SourceProperties);

                object sourceValue = sourcePropertyInfo.GetValue(sourceObject, null);

                object value = null;

                if (sourceValue == null) value = mapping.TargetFieldInfo.DefaultValue; // Arvotyypit? Miten tarkastetaan onko tyhjä? Toisaalta arvotyypin arvo ei varsinaisesti voi olla tyhjä.
                else
                {
                    if (mapping.TargetFieldInfo.EmptyValue != null && sourceValue.Equals(mapping.TargetFieldInfo.EmptyValue)) sourceValue = Activator.CreateInstance(mapping.TargetFieldInfo.FieldType);
                    value = this.GetConvertedValue(sourceValue, mapping.TargetFieldInfo.FieldType, mapping.SourceFieldInfo.FieldType);
                }

                targetPropertyInfo.SetValue(targetObject, value, null);
            }
        }

        public void WriteToSource<T, U>(U sourceObject, T targetObject, ClassMapping classMapping)
        {
            this.WriteToSource(sourceObject, targetObject, classMapping, null);
        }

        public void WriteToSource<T, U>(U sourceObject, T targetObject, ClassMapping classMapping, bool? identityFields)
        {
            FieldMappingCollection mappings = classMapping.FieldMappings;

            foreach (FieldMapping mapping in mappings.Mappings.Where(x => !identityFields.HasValue || x.IsIdentityField == identityFields.Value))
            {
                if (mapping.MappingDirection == MappingDirection.Read) continue;

                PropertyInfo targetPropertyInfo = this.GetPropertyInfo(mapping.TargetFieldInfo.FieldName, this.TargetType, this.TargetProperties);

                PropertyInfo sourcePropertyInfo = this.GetPropertyInfo(mapping.SourceFieldInfo.FieldName, this.SourceType, this.SourceProperties);

                object targetValue = targetPropertyInfo.GetValue(targetObject, null);

                object value = null;

                if (targetValue == null) value = mapping.SourceFieldInfo.DefaultValue; // Arvotyypit? Miten tarkastetaan onko tyhjä? Toisaalta arvotyypin arvo ei varsinaisesti voi olla tyhjä.
                else
                {
                    if (mapping.SourceFieldInfo.EmptyValue != null && targetValue.Equals(mapping.SourceFieldInfo.EmptyValue)) targetValue = Activator.CreateInstance(mapping.SourceFieldInfo.FieldType);
                    else value = this.GetConvertedValue(targetValue, mapping.SourceFieldInfo.FieldType, mapping.TargetFieldInfo.FieldType);
                }

                sourcePropertyInfo.SetValue(sourceObject, value, null);
            }
        }


        #endregion
    }

    public class ObjectToObjectMapper<T, U> : ObjectToObjectMapper
    {
        //private Dictionary<string, PropertyInfo> _sourceProperties;
        //private Dictionary<string, PropertyInfo> _targetProperties;

        #region Konstruktorit

        public ObjectToObjectMapper() : base(typeof(T), typeof(U))
        {
            //this.TargetType = typeof(T);
            //this.SourceType = typeof(U);
        } 

        #endregion

        //#region Propertyt

        //public Type TargetType { get; private set; }
        //public Type SourceType { get; private set; }

        //private Dictionary<string, PropertyInfo> SourceProperties
        //{
        //    get
        //    {
        //        if (this._sourceProperties == null) this._sourceProperties = new Dictionary<string, PropertyInfo>();
        //        return this._sourceProperties;
        //    }
        //}

        //private Dictionary<string, PropertyInfo> TargetProperties
        //{
        //    get
        //    {
        //        if (this._targetProperties == null) this._targetProperties = new Dictionary<string, PropertyInfo>();
        //        return this._targetProperties;
        //    }
        //}

        //#endregion

        #region Metodit

        /*private PropertyInfo GetPropertyInfo(string propertyName, Type t, Dictionary<string, PropertyInfo> collection)
        {
            if (!collection.ContainsKey(propertyName)) collection[propertyName] = t.GetProperty(propertyName);
            return collection[propertyName];
        }

        private object GetConvertedValue(object value, Type targetType, Type sourceType)
        {
            if (targetType == sourceType) return value;

            if (targetType.IsEnum)
            {
                return Enum.Parse(targetType, value.ToString());
            }

            return Convert.ChangeType(value, targetType);
        }*/

        public void WriteToTarget(T targetObject, U sourceObject, ClassMapping classMapping)
        {
            this.WriteToTarget(targetObject, sourceObject, classMapping, null);
        }

        public void WriteToTarget(T targetObject, U sourceObject, ClassMapping classMapping, bool? identityFields)
        {
            this.WriteToTarget<T, U>(targetObject, sourceObject, classMapping, identityFields);
            /*FieldMappingCollection mappings = classMapping.FieldMappings;

            foreach (FieldMapping mapping in mappings.Mappings.Where(x => !identityFields.HasValue || x.IsIdentityField == identityFields.Value))
            {
                if (mapping.MappingDirection == MappingDirection.Write) continue;

                PropertyInfo targetPropertyInfo = this.GetPropertyInfo(mapping.TargetFieldInfo.FieldName, this.TargetType, this.TargetProperties);

                PropertyInfo sourcePropertyInfo = this.GetPropertyInfo(mapping.SourceFieldInfo.FieldName, this.SourceType, this.SourceProperties);

                object sourceValue = sourcePropertyInfo.GetValue(sourceObject, null);

                object value = null;

                if (sourceValue == null) value = mapping.TargetFieldInfo.DefaultValue; // Arvotyypit? Miten tarkastetaan onko tyhjä? Toisaalta arvotyypin arvo ei varsinaisesti voi olla tyhjä.
                else
                {
                    if (mapping.TargetFieldInfo.EmptyValue != null && sourceValue.Equals(mapping.TargetFieldInfo.EmptyValue)) sourceValue = Activator.CreateInstance(mapping.TargetFieldInfo.FieldType);
                    value = this.GetConvertedValue(sourceValue, mapping.TargetFieldInfo.FieldType, mapping.SourceFieldInfo.FieldType);
                }

                targetPropertyInfo.SetValue(targetObject, value, null);
            }*/
        }

        public void WriteToSource(U sourceObject, T targetObject, ClassMapping classMapping)
        {
            this.WriteToSource(sourceObject, targetObject, classMapping, null);
        }

        public void WriteToSource(U sourceObject, T targetObject, ClassMapping classMapping, bool? identityFields)
        {
            this.WriteToSource<T, U>(sourceObject, targetObject, classMapping, identityFields);
            /*FieldMappingCollection mappings = classMapping.FieldMappings;

            foreach (FieldMapping mapping in mappings.Mappings.Where(x => !identityFields.HasValue || x.IsIdentityField == identityFields.Value))
            {
                if (mapping.MappingDirection == MappingDirection.Read) continue;

                PropertyInfo targetPropertyInfo = this.GetPropertyInfo(mapping.TargetFieldInfo.FieldName, this.TargetType, this.TargetProperties);

                PropertyInfo sourcePropertyInfo = this.GetPropertyInfo(mapping.SourceFieldInfo.FieldName, this.SourceType, this.SourceProperties);

                object targetValue = targetPropertyInfo.GetValue(targetObject, null);

                object value = null;

                if (targetValue == null) value = mapping.SourceFieldInfo.DefaultValue; // Arvotyypit? Miten tarkastetaan onko tyhjä? Toisaalta arvotyypin arvo ei varsinaisesti voi olla tyhjä.
                else
                {
                    if (mapping.SourceFieldInfo.EmptyValue != null && targetValue.Equals(mapping.SourceFieldInfo.EmptyValue)) targetValue = Activator.CreateInstance(mapping.SourceFieldInfo.FieldType);
                    else value = this.GetConvertedValue(targetValue, mapping.SourceFieldInfo.FieldType, mapping.TargetFieldInfo.FieldType);
                }

                sourcePropertyInfo.SetValue(sourceObject, value, null);
            }*/
        }
        
        
        #endregion
    }
}
