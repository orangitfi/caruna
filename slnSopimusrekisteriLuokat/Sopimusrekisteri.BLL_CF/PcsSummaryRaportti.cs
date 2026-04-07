using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class PcsSummaryRaportti
  {

    public int Id { get; private set; }
    public string ProjectNo { get; set; }
    public string Name { get; set; }
    public string TypeOfProject { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public string Owner { get; set; }
    public string Concession { get; set; }
    public string CertDate { get; set; }
    public DateTime? FieldWorkStartedA { get; set; }
    public DateTime? ProjectClosedA { get; set; }
    public string Era { get; set; }
    public string Luoja { get; set; }
    public DateTime Luotu { get; set; }

    #region Metodit

    public override bool Equals(object obj)
    {
      var tmp = obj as PcsSummaryRaportti;
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
