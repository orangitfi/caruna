using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public abstract class Poiminta
  {
		#region Propertyt

		public int Poimintaid {get; private set;}
		public int? EntityId {get; set;}
		public string Session {get; set;}
		
		public DateTime? Luotu {get; set;}
		public string Tyyppi {get; set;}

		#endregion

		#region Entiteettiviittaukset

    public IPoimittava Entity { get; set; }

		#endregion

		#region Metodit

    //public override bool Equals(object obj)
    //{
    //  var tmp = obj as Poiminta;
    //  if (tmp == null) return false;
    //  return tmp.Id == Id;
    //}

    //public override int GetHashCode()
    //{
    //  return Id.GetHashCode();
    //}

    //public override string ToString()
    //{
    //  return Id.ToString();
    //}

		#endregion
  }
}
