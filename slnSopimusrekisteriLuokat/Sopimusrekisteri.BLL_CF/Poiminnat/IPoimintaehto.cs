using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF.Poiminnat
{
  public interface IPoimintaehto
  {

    string Avain { get; set; }

    string Otsikko { get; set; }

    string TulostettavaArvo { get; set; }

    string Arvo { get; set; }

  }
}
