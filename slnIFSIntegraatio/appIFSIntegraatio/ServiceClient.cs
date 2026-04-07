using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace appIFSIntegraatio
{
  public class ServiceClient : IServiceClient
  {

    public string GetPaymentdata(string url, string username, string password)
    {

      try
      {
        
        WebClient client = new WebClient();

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
          client.Credentials = new NetworkCredential(username, password);
        }

        return client.DownloadString(url);

      }
      catch (Exception ex)
      {
        Logging.LogException(ex);
      }

      return string.Empty;

    }

  }
}
