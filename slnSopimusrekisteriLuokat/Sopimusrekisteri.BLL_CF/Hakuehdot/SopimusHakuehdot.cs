using System;

namespace Sopimusrekisteri.BLL_CF.Hakuehdot
{
    public class SopimusHakuehdot : Hakuehdot<Sopimus>
    {
        
        public SopimusTilat? SopimuksenTilaId { get; set; }
        public Sopimustyypit? SopimustyyppiId { get; set; }
        public int? Sopimusnumero { get; set; }
        public int? SopimusnumeroAlku { get; set; }
        public int? SopimusnumeroLoppu { get; set; }
        public int? PaasopimusId { get; set; }
        public bool? Paasopimus { get; set; }
        public DateTime? AlkupvmAlku { get; set; }
        public DateTime? AlkupvmLoppu { get; set; }
        public DateTime? PaattymispvmAlku { get; set; }
        public DateTime? PaattymispvmLoppu { get; set; }

    }
}
