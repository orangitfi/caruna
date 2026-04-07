using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Aktiviteetti : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public int? TahoId {get; set;}
		public int? TSopimusId {get; set;}
		public int? YhteystapaId {get; set;}
		public DateTime? Paivamaara {get; set;}
		public string Kuvaus {get; set;}
		public int? AktiviteetinLajiId {get; set;}
		public DateTime? SeuraavaYhteyspaiva {get; set;}
		public int? StatusId {get; set;}
		public string LiitetiedostoPolku {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public string Paivittaja {get; set;}
		

		#endregion

		#region Entiteettiviittaukset

		public virtual Taho Taho {get; set;}
		public virtual Sopimus TSopimus {get; set;}
		public virtual AktiviteettiYhteystapa Yhteystapa {get; set;}
		public virtual AktiviteetinLaji AktiviteetinLaji {get; set;}
		public virtual AktiviteetinStatus Status {get; set;}
		//public virtual aspnet_Users Kontaktoija {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Aktiviteetti;
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
