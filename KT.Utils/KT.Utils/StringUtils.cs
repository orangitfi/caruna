using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{
  public class StringUtils
  {

    private static char[] OpenBrackets = { '(', '[', '{', '<' };
    private static char[] CloseBrackets = { ')', ']', '}', '>' };

    public enum BracketType
    {
      Parentheses = 0,
      Square = 1,
      Curly = 2,
      Angle = 3
    }

    public static string AddBrackets(string value)
    {
      return AddBrackets(value, BracketType.Parentheses);
    }

    public static string AddBrackets(string value, BracketType type)
    {
      return OpenBrackets[(int)type] + value + CloseBrackets[(int)type];
    }

    public static string Concat(params object[] values)
    {

      StringBuilder sb = new StringBuilder();

      foreach (object obj in values)
      {
        if ((obj == null) || Convert.IsDBNull(obj))
          return null;
        sb.Append(Convert.ToString(obj));
      }

      return sb.ToString();
    }

    public static int CountOccurences(string fullText, string searchedText)
    {
      int position = 0;
      int occurences = 0;

      while (position + searchedText.Length <= fullText.Length)
      {
        int foundAt = fullText.IndexOf(searchedText, position);
        if (foundAt >= 0)
        {
          occurences++;
          position = foundAt + searchedText.Length;
        }
        else return occurences;
      }

      return occurences;
    }

    public static string ReplaceFirst(string text, string oldValue, string newValue)
    {

      int index = text.IndexOf(oldValue);

      if (index < 0)
        return text;

      string firstPart = text.Substring(0, index);

      int lastPartStartIndex = index + oldValue.Length;

      if (lastPartStartIndex >= text.Length)
        return firstPart + newValue;

      string lastPart = text.Substring(lastPartStartIndex);

      return firstPart + newValue + lastPart;

    }

    public static string RemovePrefix(string value, string prefix)
    {
      if (!string.IsNullOrEmpty(value) && value.StartsWith(prefix))
        return value.Substring(prefix.Length);

      return value;
    }

  }

}
