using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appIFSIntegraatio
{
  public interface IServiceClient
  {
    string GetPaymentdata(string url, string username, string password);
  }
}
