using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF.Poiminnat
{
  public class PoiminnanValintateksti
  {

    public PoiminnanValintateksti(string otsikko, string arvo)
    {
      this.Otsikko = otsikko;
      this.Arvo = arvo;
    }

    public string Otsikko;

    public string Arvo;

    public override string ToString()
    {
      return this.Otsikko + ": " + this.Arvo;
    }

  }
}
