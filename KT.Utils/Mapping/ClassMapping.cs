using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
    public class ClassMapping
    {
        private FieldMappingCollection _fieldMappings;
        private List<EntityReference> _entityReferences;

        public ClassMapping(Type mappedType, Type sourceType)
        {
            this.MappedType = mappedType;
            this.SourceType = sourceType;
        }

        public Type MappedType { get; private set; }
        public Type SourceType { get; private set; }

        public FieldMappingCollection FieldMappings
        {
            get
            {
                if (this._fieldMappings == null)
                {
                    this._fieldMappings = new FieldMappingCollection();                    
                }
                return this._fieldMappings;
            }
        }

        private List<EntityReference> EntityReferencesList
        {
            get
            {
                if (this._entityReferences == null) this._entityReferences = new List<EntityReference>();
                return this._entityReferences;
            }
        }

        public IEnumerable<EntityReference> EntityReferences
        {
            get
            {
                return this.EntityReferencesList;
            }
        }

        public void AddEntityReference(EntityReference er)
        {
            this.EntityReferencesList.Add(er);
        }
        
    }

    public class ClassMapping<T, U> : ClassMapping
    {
        public ClassMapping() : base(typeof(T), typeof(U))
        {
        }
    }
}
