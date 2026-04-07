using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appIFSIntegraatio
{
  class Program
  {
    static void Main(string[] args)
    {

      try
      {

        Integration integration = new Integration();

        integration.UpdatePaymentdata();

        Logging.LogInformation("Maksut päivitetty");

      }
      catch (Exception ex)
      {
        Logging.LogException(ex);
      }

    }
  }
}
