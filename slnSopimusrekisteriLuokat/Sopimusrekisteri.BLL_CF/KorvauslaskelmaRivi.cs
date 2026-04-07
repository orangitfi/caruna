using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class KorvauslaskelmaRivi : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public int? KorvauslaskelmaId {get; set;}
		public int? KorvaushinnastoId {get; set;}
		public decimal? Korvaus {get; set;}
		public DateTime? VanhaSopimusPaattyiPvm {get; set;}
		public int? KorvausProsentti {get; set;}
		public string KuvionTunnus {get; set;}
		public decimal? KuvionPituus {get; set;}
		public decimal? KuvionLeveys {get; set;}
		public decimal? KuvionKorvattavaLeveys {get; set;}
		public decimal? KokonaispintaAla {get; set;}
		public int? KokonaispintaAlaYksikkoId {get; set;}
		public decimal? Maara {get; set;}
		public string Info {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public string Paivittaja {get; set;}
		public int? KirjanpidonTiliId {get; set;}
		public int? KirjanpidonKustannuspaikkaId {get; set;}
		public decimal? Yksikkohinta {get; set;}
		public int? InvCostId {get; set;}
		public int? RegulationId {get; set;}
		public int? PurposeId {get; set;}
		public int? Local1Id {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual Korvauslaskelma Korvauslaskelma {get; set;}
		public virtual KorvausHinnasto Korvaushinnasto {get; set;}
		public virtual Yksikko KokonaispintaAlaYksikko {get; set;}
		public virtual Kirjanpidontili KirjanpidonTili {get; set;}
		public virtual KirjanpidonKustannuspaikka KirjanpidonKustannuspaikka {get; set;}
		public virtual InvCost InvCost {get; set;}
		public virtual Regulation Regulation {get; set;}
		public virtual Purpose Purpose {get; set;}
		public virtual Local1 Local1 {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as KorvauslaskelmaRivi;
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
