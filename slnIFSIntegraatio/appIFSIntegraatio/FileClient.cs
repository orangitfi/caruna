using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace appIFSIntegraatio
{
    public class FileClient : IServiceClient
    {
        public string GetPaymentdata(string url, string username, string password)
        {
            return File.Exists(Config.FiledataPath)? File.ReadAllText(Config.FiledataPath): string.Empty;
        }

    }
}
