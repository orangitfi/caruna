using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class KorvausHinnasto : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public DateTime? AlkuPvm {get; set;}
		public DateTime? LoppuPvm {get; set;}
		public Sopimustyypit? SopimustyyppiId {get; set;}
		public int? HinnastoKategoriaId {get; set;}
		public int? HinnastoAlakategoriaId {get; set;}
		public string Korvauslaji {get; set;}
		public string Kuvaus {get; set;}
		public string ArvonPeruste {get; set;}
		public int? MaksuAlueId {get; set;}
		public int? MetsatyyppiId {get; set;}
		public int? PuustolajiId {get; set;}
		public int? PuustonIka {get; set;}
		public decimal? TaimistonValtapituus {get; set;}
		public decimal? Tiheyskerroin {get; set;}
		public decimal? Yksikkkohinta {get; set;}
		public int? YksikkoId {get; set;}
		public string YksikkohinnanTarkenne {get; set;}
		public bool Aktiivinen {get; set;}
		public string Info {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public string Paivittaja {get; set;}
		public DateTime? Paivitetty {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual Sopimustyyppi Sopimustyyppi {get; set;}
		public virtual HinnastoKategoria HinnastoKategoria {get; set;}
		public virtual HinnastoAlakategoria HinnastoAlakategoria {get; set;}
		public virtual Maksualue MaksuAlue {get; set;}
		public virtual Metsatyyppi Metsatyyppi {get; set;}
		public virtual Puustolaji Puustolaji {get; set;}
		public virtual Yksikko Yksikko {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as KorvausHinnasto;
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
