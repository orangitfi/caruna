using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
    public class AutomappingSettings
    {
        public AutomappingSettings()
        {

        }

        public bool IncludeReferenceTypes { get; set; }

        public IEnumerable<string> ExcludeProperties { get; set; }

        public IEnumerable<string> IncludeProperties { get; set; }

    }
    
}
