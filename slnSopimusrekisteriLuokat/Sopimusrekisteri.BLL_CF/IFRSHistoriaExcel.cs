using System;

namespace Sopimusrekisteri.BLL_CF
{
    public class IFRSHistoriaExcel
  {
		#region Propertyt

		public int Id { get; private set; }
		public DateTime Pvm { get; set; }
		public string Nimi { get; set; }
		public byte[] Sisalto { get; set; }
		public DateTime Luotu { get; set; }
		public string Luoja { get; set; }

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as IFRSHistoriaExcel;
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
