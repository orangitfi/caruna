using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KT.Utils;
using System.Linq.Expressions;

namespace Sopimusrekisteri.BLL_CF.Poiminnat
{
  public abstract class Poimintaehdot<T> : IPoimintaehdot
  {

    private Dictionary<int, IPoimintaehdot> _alipoiminnat;

    #region Konstruktorit

    public Poimintaehdot()
    {
      this.Ehdot = new List<Poimintaehto<T>>();
    }

    #endregion

    #region Propertyt

    public Poimintatoiminto Toiminto { get; set; }

    public ICollection<Poimintaehto<T>> Ehdot { get; private set; }

    #endregion

    #region Yleiset metodit

    public IEnumerable<IPoimintaehto> AnnaEhdot()
    {
      return this.Ehdot;
    }

    public Dictionary<int, IPoimintaehdot> Alipoiminnat
    {
      get
      {
        if (this._alipoiminnat == null) this._alipoiminnat = new Dictionary<int, IPoimintaehdot>();
        return this._alipoiminnat;
      }
    }

    public virtual IEnumerable<PoiminnanValintateksti> AnnaValintatekstit()
    {
      List<PoiminnanValintateksti> valinnat = new List<PoiminnanValintateksti>();

      foreach (Poimintaehto<T> ehto in this.Ehdot)
      {
        valinnat.Add(new PoiminnanValintateksti(ehto.Otsikko, ehto.TulostettavaArvo ?? ehto.Arvo));
      }

      return valinnat;
    }

    public void LisaaEhto(string avain, string arvo, string otsikko, PoimintaOperaattori operaattori)
    {
      this.LisaaEhto(avain, arvo, null, otsikko, operaattori);
    }

    public void LisaaEhto(string avain, string arvo, string tulostettavaArvo, string otsikko, PoimintaOperaattori operaattori)
    {
      Poimintaehto<T> ehto = this.LuoEhtoAvaimella(avain, arvo, tulostettavaArvo, operaattori);

      ehto.Otsikko = otsikko;

      this.Ehdot.Add(ehto);
    }

    public IQueryable<T> MuodostaPoiminta(IQueryable<T> kysely)
    {
      foreach (Poimintaehto<T> ehto in this.Ehdot)
      {
        if (ehto.Suodatusfunktio != null) kysely = kysely.Where(ehto.Suodatusfunktio);
        if (ehto.Suodatusfunktio2 != null) kysely = ehto.Suodatusfunktio2(kysely);
      }

      return kysely;
    }

    public void TyhjennaEhdot()
    {
      this.Ehdot.Clear();
    }

    #endregion

    #region Ehtojen luonti

    private Poimintaehto<T> LuoEhtoAvaimella(string avain, string arvo, string tulostettavaArvo, PoimintaOperaattori operaattori)
    {
      Poimintaehto<T> ehto = new Poimintaehto<T>() { Avain = avain, Arvo = arvo, TulostettavaArvo = tulostettavaArvo };

      //this.AsetaEhdonTiedot(ehto);

      ehto.Suodatusfunktio = this.MuodostaSuodatusFunktio(avain, ehto, operaattori);

      return ehto;
    }

    protected abstract void AsetaEhdonTiedot(Poimintaehto<T> ehto);

    #endregion

    #region Apufunktiot

    protected IEnumerable<U> ParseValues<U>(string stringValue)
    {
      return CollectionUtils.ParseCollection<U>(stringValue.Split(','), x => DataUtils.ParseValue<U>(x));
    }

    protected IEnumerable<U> ParseEnumValues<U>(string stringValue)
    {
      return CollectionUtils.ParseCollection<U>(stringValue.Split(','), x => DataUtils.ParseEnum<U>(x));
    }

    #endregion

    protected virtual Expression<Func<T, bool>> MuodostaSuodatusFunktio(string kentta, Poimintaehto<T> ehto, PoimintaOperaattori operaattori)
    {

      ParameterExpression parametri = Expression.Parameter(typeof(T), "x");

      Expression propertyExpression = Expression.Property(parametri, kentta);

      Expression arvoExpression;

      if (operaattori == PoimintaOperaattori.Tyhja || operaattori == PoimintaOperaattori.EiTyhja)
      {
        arvoExpression = Expression.Constant(null);
      }
      else
      {
        if (propertyExpression.Type.IsEnum)
        {
          arvoExpression = Expression.Constant(Enum.Parse(propertyExpression.Type, ehto.Arvo));
        }
        else
        {
          arvoExpression = Expression.Constant(ehto.Arvo);
        }
      }

      Expression hakuExpression;

      switch (operaattori)
      {
        case PoimintaOperaattori.YhtaSuuri:
        case PoimintaOperaattori.Tyhja:
          hakuExpression = Expression.Equal(propertyExpression, arvoExpression);
          break;
        case PoimintaOperaattori.EriSuuri:
        case PoimintaOperaattori.EiTyhja:
          hakuExpression = Expression.NotEqual(propertyExpression, arvoExpression);
          break;
        case PoimintaOperaattori.PienempiTaiYhtaSuuri:
          hakuExpression = Expression.LessThanOrEqual(propertyExpression, arvoExpression);
          break;
        case PoimintaOperaattori.SuurempiTaiYhtaSuuri:
          hakuExpression = Expression.GreaterThanOrEqual(propertyExpression, arvoExpression);
          break;
        default:
          throw new NotImplementedException();
      }

      return Expression.Lambda<Func<T, bool>>(hakuExpression, parametri);

    }

  }
}