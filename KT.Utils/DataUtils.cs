using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{
  public class DataUtils
  {
    #region Constants

    private const int HashBaseValue = 17;
    private const int HashCoefficientValue = 23;

    #endregion

    #region Misc

    /// <summary>
    /// Palauttaa olion vakioarvon, mikäli olion arvo on sama kuin määritelty vertailuarvo.
    /// </summary>
    /// <typeparam name="T">Tyyppiparametri</typeparam>
    /// <param name="value">Testattavan olion arvo</param>
    /// <param name="testValue">Käytettävä vertailuarvo</param>
    /// <returns>Olion tyypistä riippuva vakioarvo (viitetyypeillä null)</returns>
    /// <remarks></remarks>
    public static T NullIf<T>(T value, T testValue)
    {
      if (value == null || Convert.IsDBNull(value) || value.Equals(testValue)) return default(T);
      return value;
    }

    public static T Coalesce<T>(params T[] values)
    {
      foreach (T value in values)
      {
        if (value != null) return value;
      }
      return default(T);
    }

    #endregion

    #region Parse

    public static bool ParseBoolean(string value)
    {
      return ParseBoolean(value, false);
    }

    public static bool ParseBoolean(string value, bool defaultValue)
    {
      bool boolVal = false;
      if (bool.TryParse(value, out boolVal))
        return boolVal;
      return defaultValue;
    }

    public static byte ParseByte(string value)
    {
      return ParseByte(value, 0);
    }

    public static byte ParseByte(string value, byte defaultValue)
    {
      byte bytelVal = 0;
      if (byte.TryParse(value, out bytelVal))
        return bytelVal;
      return defaultValue;
    }

    public static char ParseChar(string value)
    {
      return ParseChar(value, ' ');
    }

    public static char ParseChar(string value, char defaultValue)
    {
      char charVal = ' ';
      if (char.TryParse(value, out charVal))
        return charVal;
      return defaultValue;
    }

    public static double ParseDouble(string value)
    {
      return ParseDouble(value, 0.0);
    }

    public static double ParseDouble(string value, double defaultValue)
    {
      double doubleVal = 0;
      if (double.TryParse(value, out doubleVal))
        return doubleVal;
      return defaultValue;
    }

    public static T ParseEnum<T>(string value)
    {

      return (T)Enum.Parse(typeof(T), value);

    }

    public static Nullable<T> ParseNullableEnum<T>(string value) where T : struct
    {

      if (Enum.IsDefined(typeof(T), value))
        return (T)Enum.Parse(typeof(T), value);

      return null;

    }

    public static int? ParseIntOrNull(string value)
    {
      int intVal = 0;
      if (Int32.TryParse(value, out intVal))
        return intVal;
      return null;
    }

    public static int ParseInt(string value)
    {
      return ParseInt(value, 0);
    }

    public static int ParseInt(string value, int defaultValue)
    {
      int intVal = 0;
      if (Int32.TryParse(value, out intVal))
        return intVal;
      return defaultValue;
    }

    public static T ParseValue<T>(string value)
    {

      if (string.IsNullOrEmpty(value)) return default(T);

      Type actualType = typeof(T);

      Type nullableBaseType = Nullable.GetUnderlyingType(actualType);

      if ((nullableBaseType != null))
      {
        return (T)Convert.ChangeType(value, nullableBaseType);
      }
      else
      {
        return (T)Convert.ChangeType(value, actualType);
      }

    }

    #endregion

    #region GetValue

    public static bool GetBooleanValue(object value)
    {
      return GetValue<bool>(value, false);
    }

    public static bool GetBooleanValue(object value, bool defaultValue)
    {
      return GetValue<bool>(value, defaultValue);
    }

    public static decimal GetDecimalValue(object value)
    {
      return GetValue<decimal>(value, 0m);
    }

    public static decimal GetDecimalValue(object value, decimal defaultValue)
    {
      return GetValue<decimal>(value, defaultValue);
    }

    public static double GetDoubleValue(object value)
    {
      return GetValue<double>(value, 0.0);
    }

    public static double GetDoubleValue(object value, double defaultValue)
    {
      return GetValue<double>(value, defaultValue);
    }

    public static int GetIntValue(object value)
    {
      return GetValue<int>(value, 0);
    }

    public static int GetIntValue(object value, int defaultValue)
    {
      return GetValue<int>(value, defaultValue);
    }

    public static string GetStringValue(object value)
    {
      return GetValue<string>(value, string.Empty);
    }

    public static string GetStringValue(object value, string defaultValue)
    {
      return GetValue<string>(value, defaultValue);
    }

    public static T GetValue<T>(object value, T defaultValue)
    {
      if ((value == null) || Convert.IsDBNull(value))
        return defaultValue;
      return (T)value;
    }

    #endregion

    #region Hash Codes

    public static int GetHashCodeForCompositeKey(params int[] keys)
    {
      int hash = HashBaseValue;

      foreach (int key in keys)
      {
        hash = hash * HashCoefficientValue + key.GetHashCode();
      }

      return hash;
    }
    #endregion
  }
}
