using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Postitiedot : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public string Postinumero {get; set;}
		public string Postitoimipaikka {get; set;}
		public string PostitoimipaikkaRUO {get; set;}
		public int? Kuntaid {get; set;}
		public string Luoja {get; set;}
		public DateTime Luotu {get; set;}
		public string Paivittaja {get; set;}
		public DateTime? Paivitetty {get; set;}

		#endregion

		#region Entiteettiviittaukset

		

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Postitiedot;
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
