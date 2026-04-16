using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{

    //public enum EntityReferenceCardinality
    //{
    //    OneToMany = 1,
    //    ManyToMany = 2
    //}
    
    public class EntityReference
    {
        public EntityReference(string propertyName, Type referencedType, string sourceObjectPropertyName)
        {
            this.PropertyName = propertyName;
            this.ReferencedType = referencedType;
            this.SourceObjectPropertyName = sourceObjectPropertyName;
        }

        public string PropertyName { get; private set; }

        public Type ReferencedType { get; private set; }

        public string SourceObjectPropertyName { get; private set; }

    }

    public class EntityReference<T> : EntityReference
    {
        public EntityReference(string propertyName, string sourceObjectPropertyName)
            : base(propertyName, typeof(T), sourceObjectPropertyName)
        {
        }
    }

}
