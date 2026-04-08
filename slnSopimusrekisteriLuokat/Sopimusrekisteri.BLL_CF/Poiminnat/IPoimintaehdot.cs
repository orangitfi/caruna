using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF.Poiminnat
{
  public interface IPoimintaehdot
  {

    IEnumerable<IPoimintaehto> AnnaEhdot();

    void LisaaEhto(string avain, string arvo, string otsikko, PoimintaOperaattori operaattori);

    void LisaaEhto(string avain, string arvo, string tulostettavaArvo, string otsikko, PoimintaOperaattori operaattori);

    IEnumerable<PoiminnanValintateksti> AnnaValintatekstit();

  }
}
