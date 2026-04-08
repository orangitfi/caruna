using Sopimusrekisteri.BLL_CF.Class;
using System;

namespace Sopimusrekisteri.Yllapitoajo.Models
{
    public class LaskennallinenPaattymispvmModel : LaskennallinenPaattymispvm
    {

        public int? SopimusId { get; set; }
        public DateTime? Nykyarvo { get; set; }

    }
}
