using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
    public class FieldMappingCollection
    {

        private List<FieldMapping> _mappings;

        public FieldMappingCollection()
        {
        }

        public FieldMappingCollection(IEnumerable<FieldMapping> mappings) : this()
        {
            this.AddMappings(mappings);
        }

        private List<FieldMapping> MappingsList
        {
            get
            {
                if (this._mappings == null) this._mappings = new List<FieldMapping>();
                return this._mappings;
            }
        }

        public IEnumerable<FieldMapping> Mappings
        {
            get { return this.MappingsList; }
        }

        public void AddMapping(FieldMapping mapping)
        {
            this.MappingsList.Add(mapping);
        }

        public void AddMappings(IEnumerable<FieldMapping> mappings)
        {
            foreach (FieldMapping mapping in mappings)
            {
                this.AddMapping(mapping);
            }
        }        

    }
}
