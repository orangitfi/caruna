using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace appIFSIntegraatio
{
  public class TestClient : IServiceClient
  {
    public string GetPaymentdata(string url, string username, string password)
    {
      return File.ReadAllText(Config.TestdataPath);
    }
  }
}
