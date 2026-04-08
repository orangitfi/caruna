using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Korvauslaskelma : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public int? SopimusId {get; set;}
		public int? SaajaId {get; set;}
		public int? MaksualueId {get; set;}
		public Korvaustyypit? KorvaustyyppiId {get; set;}
		public KorvauslaskelmaStatukset? KorvauslaskelmaStatusId {get; set;}
		public decimal? LaskennallinenKorvaus {get; set;}
		public decimal? MaksettavaKorvaus {get; set;}
		public decimal? MaksettavaKorvausAlkuperainen {get; set;}
		public DateTime? VanhaSopimusPaattyyiPvm {get; set;}
		public decimal? KorvausProsentti {get; set;}
		public int? MaksuKuukausiId {get; set;}
		public DateTime? ViimeisinMaksuPvm {get; set;}
		public DateTime? ViimeinenMaksuPvm {get; set;}
		public DateTime? EnsimmainenSallittuMaksuPvm {get; set;}
		public int? SopimushetkenIndeksiArvo {get; set;}
		public int? NykyinenIndeksiArvo {get; set;}
		public int? IndeksityyppiId {get; set;}
		public int? IndeksiKuukausiId {get; set;}
		public int? IndeksiVuosi {get; set;}
		public string Viite {get; set;}
		public string Viesti {get; set;}
		public string Projektinumero {get; set;}
		public string KorvauksenProjektinumero {get; set;}
		public MaksunSuoritukset? MaksunSuoritusId {get; set;}
		public int? PuustonOmistajuusId {get; set;}
		public int? PuustonPoistoId {get; set;}
		public string Info {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public string Paivittaja {get; set;}
		public int? KirjanpidonTiliId {get; set;}
		public int? KirjanpidonKustannuspaikkaId {get; set;}
		public int? InvCostId {get; set;}
		public int? RegulationId {get; set;}
		public int? PurposeId {get; set;}
		public int? Local1Id {get; set;}
		public string Projectno {get; set;}
		public string Name {get; set;}
		public string TypeOfProject {get; set;}
		public string Type {get; set;}
		public string Owner {get; set;}
		public string Concession {get; set;}
		public string CertDate {get; set;}
		public DateTime? FieldWorkStarted {get; set;}
		public DateTime? ProjectClosedA {get; set;}
		public bool MaksetaanAlv {get; set;}
		public bool OnIndeksi {get; set;}
		public int? MaksuehdotId {get; set;}
		public decimal? ViimeisinMaksu {get; set;}
		public int? ViimeisinIndeksi {get; set;}
		public int? ViimeisinMaksuIndeksi {get; set;}
		public bool? EnsimmainenMaksupaivaAsetettuKasin {get; set;}
		public int? ViimeisinIndeksiVuosi {get; set;}
		public int? AlvId {get; set;}
    public string Category { get; set; }

    #endregion

		#region Entiteettiviittaukset

		public virtual Sopimus Sopimus {get; set;}
		public virtual Taho Saaja {get; set;}
		public virtual Maksualue Maksualue {get; set;}
		public virtual Korvaustyyppi Korvaustyyppi {get; set;}
		public virtual KorvauslaskelmaStatus KorvauslaskelmaStatus {get; set;}
		public virtual Kuukausi MaksuKuukausi {get; set;}
		public virtual Indeksityyppi Indeksityyppi {get; set;}
		public virtual Kuukausi IndeksiKuukausi {get; set;}
		public virtual MaksunSuoritus MaksunSuoritus {get; set;}
		public virtual PuustonOmistajuus PuustonOmistajuus {get; set;}
		public virtual PuustonPoisto PuustonPoisto {get; set;}
		public virtual Kirjanpidontili KirjanpidonTili {get; set;}
		public virtual KirjanpidonKustannuspaikka KirjanpidonKustannuspaikka {get; set;}
		public virtual InvCost InvCost {get; set;}
		public virtual Regulation Regulation {get; set;}
		public virtual Purpose Purpose {get; set;}
		public virtual Local1 Local1 {get; set;}
		public virtual Maksuehdot Maksuehdot {get; set;}
		public virtual Alv Alv {get; set;}

    public virtual ICollection<KorvauslaskelmaRivi> Rivit { get; set; }

    public virtual ICollection<KorvauslaskelmaLoki> Historia { get; set; }

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Korvauslaskelma;
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

        public decimal Summa
        {
            get
            {
                return Rivit.Sum(x => x.Korvaus.GetValueOrDefault(0));
            }
        }
        public decimal AlvSumma
        {
            get
            {
                if (MaksetaanAlv && Alv != null && Alv.Prosentti.HasValue)
                {
                    return Summa * Alv.Prosentti.Value/100;
                }
                return 0;
            }
        }
        public decimal VerollinenSumma
        {
            get
            {
                return Summa + AlvSumma;
            }
        }
  }
}
