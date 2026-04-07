using Sopimusrekisteri.Yllapitoajo.Toiminnot;

namespace Sopimusrekisteri.Yllapitoajo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Asetukset.PaivitaLaskennallisetPaattymispaivat)
            {
                var toiminto = new PaivitaLaskennallisetPaattymispaivatToiminto(Asetukset.ConnectionString);
                toiminto.Aja();
            }
        }
    }
}
