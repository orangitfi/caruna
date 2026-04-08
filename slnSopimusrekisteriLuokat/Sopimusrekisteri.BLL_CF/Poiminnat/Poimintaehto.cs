using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF.Poiminnat
{
  public class Poimintaehto<T> : IPoimintaehto
  {

    public delegate IQueryable<T> PoimintaSuodatusfunktio(IQueryable<T> query);

    public Poimintaehto()
    {

    }

    public string Avain { get; set; }

    public PoimintaSuodatusfunktio Suodatusfunktio2 { get; set; }

    public System.Linq.Expressions.Expression<Func<T, bool>> Suodatusfunktio { get; set; }

    public string Otsikko { get; set; }

    public string TulostettavaArvo { get; set; }

    public string Arvo { get; set; }


    public bool BooleanValue
    {
      get
      {
        return KT.Utils.DataUtils.ParseBoolean(this.Arvo, false);
      }
    }

    public int IntValue
    {
      get
      {
        return KT.Utils.DataUtils.ParseInt(this.Arvo, 0);
      }
    }

    public decimal DecimalValue
    {
      get
      {
        return (decimal)KT.Utils.DataUtils.ParseDouble(this.Arvo, 0);
      }
    }

    public DateTime DateValue
    {
      get
      {
        DateTime dt;
        DateTime.TryParse(this.Arvo, out dt);
        return dt;
      }
    }

  }
}
