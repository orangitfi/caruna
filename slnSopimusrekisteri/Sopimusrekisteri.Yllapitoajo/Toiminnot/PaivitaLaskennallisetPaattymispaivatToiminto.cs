using Sopimusrekisteri.DAL_CF;
using Sopimusrekisteri.Yllapitoajo.Repository;
using System;
using System.Linq;

namespace Sopimusrekisteri.Yllapitoajo.Toiminnot
{
    public class PaivitaLaskennallisetPaattymispaivatToiminto
    {

        private SopimusRepository Repository { get; }

        public PaivitaLaskennallisetPaattymispaivatToiminto(string connectionString)
        {
            Repository = new SopimusRepository(connectionString);
        }

        public void Aja()
        {
            var offset = 0;
            var limit = 1000;
            var sopimukset = Repository.HaeLaskennallisetPaattymispaivat(offset, limit);

            do
            {
                Console.WriteLine($"Laskennallinen päättymispäivä asetettu {offset} sopimukselle.");

                using (var conn = Repository.OpenConnection())
                {
                    foreach (var sopimus in sopimukset)
                    {
                        // ei tarvitse päivittää jos laskettu arvo on sama kun nyt jo kannassa oleva.
                        if (sopimus.Nykyarvo == sopimus.Value)
                            continue;

                        Repository.PaivitaLaskennallinenPaattymispaiva(conn, sopimus.SopimusId ?? 0, sopimus.Value);
                    }
                }

                offset += limit;
                sopimukset = Repository.HaeLaskennallisetPaattymispaivat(offset, limit);
            }
            while (sopimukset.Any());
        }

    }
}
