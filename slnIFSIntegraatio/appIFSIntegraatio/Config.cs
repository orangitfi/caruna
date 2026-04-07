using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KT.Utils;

namespace appIFSIntegraatio
{
    public class Config
    {

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["defaultSQLServer"].ConnectionString; }
        }

        public static string PaymentdataServiceUrl
        {
            get { return ConfigurationManager.AppSettings["PaymentdataServiceUrl"].ToString(); }
        }

        public static string PaymentdataServiceUsername
        {
            get { return ConfigurationManager.AppSettings["PaymentdataServiceUsername"].ToString(); }
        }

        public static string PaymentdataServicePassword
        {
            get { return ConfigurationManager.AppSettings["PaymentdataServicePassword"].ToString(); }
        }

        public static bool TestMode
        {
            get { return DataUtils.ParseBoolean(ConfigurationManager.AppSettings["TestMode"].ToString()); }
        }

        public static string TestdataPath
        {
            get { return ConfigurationManager.AppSettings["TestdataPath"].ToString(); }
        }

        //File-siirto 6.6.2022
        public static bool FileMode
        {
            get { return DataUtils.ParseBoolean(ConfigurationManager.AppSettings["FileMode"].ToString()); }
        }

        public static string FiledataPath
        {
            get { return ConfigurationManager.AppSettings["FiledataPath"].ToString(); }
        }

        public static string Filedata
        {
            get { return ConfigurationManager.AppSettings["Filedata"].ToString(); }
        }

        public static string FiledataArchivePath
        {
            get { return ConfigurationManager.AppSettings["FiledataArchivePath"].ToString(); }
        }

        public static string Username
        {
            get { return "IFS-integraatio"; }
        }

    }
}
