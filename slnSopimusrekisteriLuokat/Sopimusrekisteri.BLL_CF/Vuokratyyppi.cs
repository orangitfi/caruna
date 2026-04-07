using System;

namespace Sopimusrekisteri.BLL_CF
{
    public class Vuokratyyppi : IEditable
    {
        #region Propertyt

        public int Id { get; private set; }
        public string Nimi { get; set; }
        public DateTime Luotu { get; set; }
        public string Luoja { get; set; }
        public DateTime? Paivitetty { get; set; }
        public string Paivittaja { get; set; }

        #endregion

        #region Metodit

        public override bool Equals(object obj)
        {
            var tmp = obj as Vuokratyyppi;
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
