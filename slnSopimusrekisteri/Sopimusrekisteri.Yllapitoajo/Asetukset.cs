using Sopimusrekisteri.DAL_CF;
using System.Configuration;

namespace Sopimusrekisteri.Yllapitoajo
{
    public static class Asetukset
    {

        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string Username => ConfigurationManager.AppSettings["Username"];
        public static bool PaivitaLaskennallisetPaattymispaivat => bool.Parse(ConfigurationManager.AppSettings["PaivitaLaskennallisetPaattymispaivat"]);

        public static KiltaDataContext GetDataContext()
        {
            var kayttooikeustiedot = new BLL_CF.Kayttooikeustiedot(Username)
            {
                Taso = BLL_CF.KayttooikeusTaso.Laaja
            };

            return new KiltaDataContext(ConnectionString, kayttooikeustiedot);
        }

    }
}
