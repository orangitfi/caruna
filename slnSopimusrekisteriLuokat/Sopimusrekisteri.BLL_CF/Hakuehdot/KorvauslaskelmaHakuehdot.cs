using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF.Hakuehdot
{
  public class KorvauslaskelmaHakuehdot : Hakuehdot<Korvauslaskelma>
  {
    public Korvaustyypit? KorvaustyyppiId { get; set; }
    public int? StatusId { get; set; }
    public int? MaksuSuoritusId { get; set; }
    public int? Sopimusnumero { get; set; }
    public string Viite { get; set; }
    public string Projektinumero { get; set; }
    public DateTime? EnsimmainenSallittuMaksupaivaAlku { get; set; }
    public DateTime? EnsimmainenSallittuMaksupaivaLoppu { get; set; }
    public string KirjanpidonTili { get; set; }
    public string KirjanpidonKustannuspaikka { get; set; }
    public int? InvCostId { get; set; }
    public int? RegulationId { get; set; }
    public int? PurposeId { get; set; }
    public int? Local1Id { get; set; }
    public int? MaksukuukausiId { get; set; }

    public SopimusHakuehdot SopimusHakuehdot { get; set; }

  }
}
