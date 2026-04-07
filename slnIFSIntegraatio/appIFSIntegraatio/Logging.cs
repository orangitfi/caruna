using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace appIFSIntegraatio
{
  public class Logging
  {

    public static void LogInformation(string message)
    {

      try
      {

        Trace.TraceInformation(message);

        Trace.Flush();

      }
      catch (Exception ex)
      {
      }

    }

    public static void LogWarning(string message)
    {

      try
      {

        Trace.TraceWarning(message);

        Trace.Flush();

      }
      catch (Exception ex)
      {
      }

    }

    public static void LogException(Exception exception)
    {

      try
      {

        Trace.TraceError(exception.Message + " " + exception.StackTrace);

        Trace.Flush();

      }
      catch (Exception ex)
      { 
      }

    }

  }
  
}
