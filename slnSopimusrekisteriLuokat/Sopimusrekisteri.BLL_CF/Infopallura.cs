using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Infopallura : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public string Lomake {get; set;}
		public string Kentta {get; set;}
		public string Teksti {get; set;}
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
			var tmp = obj as Infopallura;
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
