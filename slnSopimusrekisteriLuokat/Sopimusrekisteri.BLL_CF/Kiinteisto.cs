using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Kiinteisto : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public string KiinteistoNimi {get; set;}
		public int? TahoId {get; set;}
		public string Katuosoite {get; set;}
		public string Postitoimipaikka {get; set;}
		public string Postinumero {get; set;}
		public int? MaaId {get; set;}
		public string Rekisterinumero {get; set;}
		public string Kyla {get; set;}
		public int? Kylanumero {get; set;}
		public int? KylaId {get; set;}
    //public string Kunta {get; set;}
		public int? Kuntanumero {get; set;}
		public int? KuntaId {get; set;}
		public string Kiinteistotunnus {get; set;}
		public string KiinteistotunnusLyhyt {get; set;}
		public decimal? PintaAla {get; set;}
		public decimal? MaapintaAla {get; set;}
		public decimal? VesipintaAla {get; set;}
		public string Kortteli {get; set;}
		public string Tontti {get; set;}
		public string MaaraAla {get; set;}
		public int? MaaraAlaTarkenneId {get; set;}
		public int? KiinteistoverotettuVuosi {get; set;}
		public int? AssetTunniste {get; set;}
		public string Rasitteet {get; set;}
		public string Kiinnitykset {get; set;}
		public int? Omistusosuus {get; set;}
		public int? OmistusosuusTotal {get; set;}
		public int? LiiketoiminnanTarveId {get; set;}
		public int? SaantoId {get; set;}
		public string Info {get; set;}
		public string Luoja {get; set;}
		public DateTime Luotu {get; set;}
		public string Paivittaja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public string AlueTarkenne {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual Taho Taho {get; set;}
		public virtual Maa Maa {get; set;}
		public virtual Kunta Kunta {get; set;}
		public virtual MaaraAlaTarkenne MaaraAlaTarkenne {get; set;}
		public virtual LiiketoiminnanTarve LiiketoiminnanTarve {get; set;}
		public virtual Saanto Saanto {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Kiinteisto;
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
