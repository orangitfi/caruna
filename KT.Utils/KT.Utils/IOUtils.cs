using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KT.Utils
{

  public class IOUtils
  {

    #region Vakiot

    private const char FileExtensionDelimiter = '.';

    #endregion

    public static string CombinePaths(string path1, string path2)
    {
      if (!path1.EndsWith(@"\"))
        path1 = path1 + @"\";

      return path1 + path2;
    }
    
    public static string CreateUniqueFileName(string filename, string path)
    {
      return CreateUniqueFileName(filename, path, 1, false);
    }

    public static string CreateUniqueFileName(string filename, string path, int startNumber, bool createIdentifierAllways)
    {
      return CreateUniqueFileName(filename, path, startNumber, createIdentifierAllways, "_{0}");
    }

    public static string CreateUniqueFileName(string filename, string path, int startIdentifier, bool createIdentifierAllways, string idPattern)
    {
      return CreateUniqueFileName(filename, path, startIdentifier, createIdentifierAllways, idPattern, 10000);
    }

    public static string CreateUniqueFileName(string initialFilename, string path, int startIdentifier, bool createIdentifierAllways, string idPattern, int maxIterations)
    {

      string filenamePattern = null;

      if (initialFilename.Contains("{0}"))
      {
        filenamePattern = initialFilename;

      }
      else
      {
        int dotIndex = initialFilename.LastIndexOf(".");
        if (dotIndex >= 0)
        {
          filenamePattern = initialFilename.Substring(0, dotIndex) + "{0}" + initialFilename.Substring(dotIndex);
        }
        else
        {
          filenamePattern = initialFilename + "{0}";
        }

      }

      int counter = startIdentifier;


      while (counter <= maxIterations)
      {
        string newFilename = null;
        string identifierString = null;

        if (counter == startIdentifier && !createIdentifierAllways)
          identifierString = string.Empty;
        else
          identifierString = string.Format(idPattern, counter);

        newFilename = string.Format(filenamePattern, identifierString);

        if (!File.Exists(path + "\\" + newFilename))
          return newFilename;

        counter += 1;
      }

      return null;

    }

    public static byte[] GetBytesFromStream(Stream s)
    {

      byte[] bytes = new byte[s.Length];

      if (s.Length > Int32.MaxValue) throw new ArgumentException("Stream can't be longer than " + Int32.MaxValue + " bytes.");

      s.Read(bytes, 0, (int)s.Length);

      return bytes;

    }

    public static string GetFileExtension(string filename)
    {
      if (!filename.Contains(FileExtensionDelimiter) || filename.LastIndexOf(FileExtensionDelimiter) == (filename.Length - 1)) return null;
      return filename.Substring(filename.LastIndexOf(FileExtensionDelimiter) + 1);
    }

    public static string ReadTextFile(string filename)
    {

      return ReadTextFile(filename, System.Text.Encoding.Default);

    }

    public static string ReadTextFile(string filename, System.Text.Encoding encoding)
    {

      string content = null;

      using (StreamReader reader = new StreamReader(filename, encoding))
      {

        content = reader.ReadToEnd();

      }

      return content;

    }


    public static void WriteBytesToFile(byte[] fileContent, string filename, FileMode filemode)
    {
      using (System.IO.FileStream stream = new System.IO.FileStream(filename, filemode))
      {

        using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream))
        {
          writer.Write(fileContent);
          writer.Close();
        }

        stream.Close();
      }

    }

  }
}
