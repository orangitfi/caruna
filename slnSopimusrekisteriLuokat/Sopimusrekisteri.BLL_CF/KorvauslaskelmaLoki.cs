using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class KorvauslaskelmaLoki : IEditable
  {

    #region Propertyt

    public int Id { get; private set; }
    public int KorvauslaskelmaId { get; set; }
    public KorvauslaskelmaStatukset? StatusId { get; set; }
    public DateTime Luotu { get; set; }
    public string Luoja { get; set; }
    public DateTime? Paivitetty { get; set; }
    public string Paivittaja { get; set; }

    #endregion

    #region Entiteettiviittaukset

    public virtual Korvauslaskelma Korvauslaskelma { get; set; }
    public virtual KorvauslaskelmaStatus Status { get; set; }

    #endregion

    #region Metodit

    public override bool Equals(object obj)
    {
      var tmp = obj as KorvauslaskelmaLoki;
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
