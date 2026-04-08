using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
    public class SopimusTaho : IEditable
    {
        #region Propertyt

        public int Id { get; set; }
        public int SopimusId { get; set; }
        public int TahoId { get; set; }
        public int? AsiakastyyppiId { get; set; }
        public DateTime Luotu { get; set; }
        public string Luoja { get; set; }
        public DateTime? Paivitetty { get; set; }
        public string Paivittaja { get; set; }
        public int? DFRooliId { get; set; }
        public bool TulostetaanSopimukseen { get; set; }

        #endregion

        #region Entiteettiviittaukset

        public virtual Sopimus Sopimus { get; set; }
        public virtual Taho Taho { get; set; }
        public virtual Asiakastyyppi Asiakastyyppi { get; set; }
        public virtual DFRooli DFRooli { get; set; }

        #endregion

        #region Metodit

        public override bool Equals(object obj)
        {
            var tmp = obj as SopimusTaho;
            if (tmp == null) return false;
            return tmp.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        #endregion
    }
}
