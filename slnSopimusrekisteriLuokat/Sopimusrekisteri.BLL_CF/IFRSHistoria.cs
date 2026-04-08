using System;

namespace Sopimusrekisteri.BLL_CF
{
    public class IFRSHistoria
  {
		#region Propertyt

		public int Id { get; private set; }
		public DateTime Pvm { get; set; }
		public int SopimusId { get; set; }
		public DateTime? SopimusAlkaa { get; set; }
		public DateTime? SopimusPaattyy { get; set; }
		public int? SopimusJuridinenYhtioId { get; set; }
		public string SopimusJuridinenYhtioStr { get; set; }
		public int? SopimusVuokratyyppiId { get; set; }
		public bool SopimusIFRS { get; set; }
		public decimal? SopimusKorkoprosentti { get; set; } // 18,6
		public int? KorvauslaskelmaId { get; set; }
		public int? KorvauslaskelmaTahoId { get; set; }
		public string KorvauslaskelmaTahoStr { get; set; }
		public decimal? KorvauslaskelmaViimeisinMaksu { get; set; } // 18,6
		public DateTime Luotu { get; set; }
		public string Luoja { get; set; }

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as IFRSHistoria;
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
