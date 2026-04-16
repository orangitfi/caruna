using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.Mapping
{
  public class ColumnBinding
  {

    public ColumnBinding(string headerText, string dataField, Type type)
    {

      this.HeaderText = headerText;
      this.DataField = dataField;
      this.Type = type;

    }

    public string HeaderText { get; set; }
    public string DataField { get; set; }
    public Type Type { get; set; }
  }
}
