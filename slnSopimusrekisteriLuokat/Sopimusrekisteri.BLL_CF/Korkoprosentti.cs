using System;

namespace Sopimusrekisteri.BLL_CF
{
    public class Korkoprosentti : IEditable
    {

        public static readonly int OletusKorkoprosenttiVuodelta= 35;

        #region Propertyt

        public int Id { get; private set; }
        public decimal Prosentti { get; set; }
        public int Vuodet { get; set; }
        public DateTime Luotu { get; set; }
        public string Luoja { get; set; }
        public DateTime? Paivitetty { get; set; }
        public string Paivittaja { get; set; }

        #endregion

        #region Metodit

        public override bool Equals(object obj)
        {
            var tmp = obj as Korkoprosentti;
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
