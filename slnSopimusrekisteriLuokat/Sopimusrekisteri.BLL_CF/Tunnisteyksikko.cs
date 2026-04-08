using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Tunnisteyksikko : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public string Tunnus {get; set;}
		public string Nimi {get; set;}
		public string LinjaOsa {get; set;}
		public string PGTunniste {get; set;}
		public string Koordinaatit {get; set;}
		public int? SopimusId {get; set;}
		public string Info {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public string Paivittaja {get; set;}
		public bool Aktiivinen {get; set;}
		public string PGTunnus {get; set;}
		public int? PGKoordinaatti1 {get; set;}
		public int? PGKoordinaatti2 {get; set;}
		public int? TunnisteyksikkoTyyppiId {get; set;}
		public string Kohdetieto {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual Sopimus Sopimus {get; set;}
		public virtual TunnisteyksikkoTyyppi TunnisteyksikkoTyyppi {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Tunnisteyksikko;
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
