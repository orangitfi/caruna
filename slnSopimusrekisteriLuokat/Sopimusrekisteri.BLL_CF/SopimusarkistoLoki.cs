using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class SopimusarkistoLoki
  {
		#region Propertyt

		public int Id {get; private set;}
		public string Tunnistetyyppi {get; set;}
		public string Tunniste {get; set;}
		public string Operaatio {get; set;}
		public string Tulos {get; set;}
		public string Luoja {get; set;}
		public DateTime? Luotu {get; set;}

		#endregion

		#region Entiteettiviittaukset

		

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as SopimusarkistoLoki;
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
