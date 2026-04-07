using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Maksu
  {
		#region Propertyt

		public int Id {get; private set;}
		public int? MaksuaineistoId {get; set;}
		public int? KorvauslaskelmaId {get; set;}
		public DateTime? Maksupaiva {get; set;}
		public decimal? Summa {get; set;}
		public decimal? Vero {get; set;}
		public string Tilinumero {get; set;}
		public string Bic {get; set;}
		public string Viite {get; set;}
		public string Viesti {get; set;}
		public int? IndeksiKuukausiId {get; set;}
		public int? Indeksi {get; set;}
		public int? KirjanpidonTiliId {get; set;}
		public string Kustannuspaikka {get; set;}
		public int? MaksuStatusId {get; set;}
		public string LaskunNumero {get; set;}
		public string EraTunniste {get; set;}
		public DateTime? AjoPvm {get; set;}
		public int? Vuosi {get; set;}
		public string Info {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public int? SaajaId {get; set;}
    public string SaajaNimi {get; set;}
		public bool OnIndeksi {get; set;}
		public int? IndeksityyppiId {get; set;}
		public int? MaksuIndeksi {get; set;}
		public decimal? AlvOsuus {get; set;}
		public int? JuridinenYhtioId {get; set;}
		public string MaksajanNimi {get; set;}
		public string MaksajanTilinro {get; set;}
		public string MaksajanBicKoodi {get; set;}
		public int? SopimusId {get; set;}
		public string KirjanpidonTunniste {get; set;}
		public string Palvelutunnus {get; set;}
		public bool Passivoitu {get; set;}
		public decimal? SummaIlmanAlv {get; set;}
		public int? IndeksiVuosi {get; set;}
    public DateTime? IfsMaksupvm { get; set; }
    public string IfsLaskunro { get; set; }

    public decimal? Alv { get; set; }

		#endregion

		#region Entiteettiviittaukset

		public virtual Maksuaineisto Maksuaineisto {get; set;}
		public virtual Korvauslaskelma Korvauslaskelma {get; set;}
		public virtual Kuukausi IndeksiKuukausi {get; set;}
		public virtual Kirjanpidontili KirjanpidonTili {get; set;}
		public virtual MaksuStatus MaksuStatus {get; set;}
		public virtual Taho Saaja {get; set;}
		public virtual Indeksityyppi Indeksityyppi {get; set;}
		public virtual Taho JuridinenYhtio {get; set;}
		public virtual Sopimus Sopimus {get; set;}

    public virtual ICollection<MaksuTiliointi> Tilioinnit { get; set; }

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Maksu;
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
