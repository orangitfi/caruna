using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{
    public class CollectionColumn
    {

        public CollectionColumn(string dataField, string headerText)
        {
            this.DataField = dataField;
            this.HeaderText = headerText;
        }

        public string DataField { get; set; }
        public string HeaderText { get; set; }

    }
}
