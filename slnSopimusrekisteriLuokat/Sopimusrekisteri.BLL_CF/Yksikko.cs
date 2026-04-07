using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Yksikko : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public string Korvausyksikko {get; set;}
		public decimal? Kerroin {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public string Paivittaja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public int? KorvausyksikonTyyppiId {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual KorvausyksikonTyyppi KorvausyksikonTyyppi {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Yksikko;
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
