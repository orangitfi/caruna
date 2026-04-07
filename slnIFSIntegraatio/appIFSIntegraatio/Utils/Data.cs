using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appIFSIntegraatio.Utils
{
  public class Data
  {

    public static decimal ParseDecimal(string value)
    {
      return ParseDecimal(value, 0);
    }

    public static decimal ParseDecimal(string value, decimal defaultValue)
    {

      if (!IsValidDecimal(value))
        return defaultValue;

      value = value.Replace(".", ",");

      return decimal.Parse(value);

    }

    public static bool IsValidDateTime(string value)
    {

      DateTime dateValue;

      if (DateTime.TryParse(value, out dateValue))
        return true;

      return false;

    }

    public static bool IsValidDecimal(string value)
    {
      
      if (string.IsNullOrEmpty(value)) return false;
      
      decimal decimalValue;

      value = value.Replace(".", ",");

      if (decimal.TryParse(value, out decimalValue))
        return true;

      return false;

    }

  }
}
