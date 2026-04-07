using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class MaksuTiliointi
  {
		#region Propertyt

		public int Id {get; private set;}
		public int MaksuId {get; set;}
		public decimal? Summa {get; set;}
		public string Projektinro {get; set;}
		public string Kirjanpidontili {get; set;}
		public string Kustannuspaikka {get; set;}
		public string InvCost {get; set;}
		public string Regulation {get; set;}
		public string Purpose {get; set;}
		public string Local1 {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public decimal? AlvOsuus {get; set;}
		public decimal? SummaIlmanAlv {get; set;}
    public string Category { get; set; }

		#endregion

		#region Entiteettiviittaukset

		public virtual Maksu Maksu {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as MaksuTiliointi;
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
