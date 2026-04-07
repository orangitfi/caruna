using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class OhjaustietoHandler : EntityHandlerBase<IOhjaustieto>
  {
    public OhjaustietoHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(IOhjaustieto entity)
    {

      throw new NotImplementedException();

    }

    public void SaveEntity(IOhjaustieto entity, Ohjaustiedot tyyppi)
    {

      switch (tyyppi)
      {

        case Ohjaustiedot.Asiakastyyppi:
          this.DataContext.AddOrUpdateEntity<Asiakastyyppi>(entity as Asiakastyyppi, this.IsNewEntity(entity));
          break;
        case Ohjaustiedot.Lupataho:
          this.DataContext.AddOrUpdateEntity<Lupataho>(entity as Lupataho, this.IsNewEntity(entity));
          break;
        default:
          throw new NotImplementedException();
      }

      this.DataContext.SaveChanges();
    }

    public override IOhjaustieto LoadEntity(object id)
    {

      throw new NotImplementedException();

    }

    public IOhjaustieto LoadEntity(object id, Ohjaustiedot tyyppi)
    {

      switch (tyyppi)
      {
        case Ohjaustiedot.Asiakastyyppi:
          return this.DataContext.Asiakastyypit.Single(x => x.Id == (int)id);
        case Ohjaustiedot.Lupataho:
          return this.DataContext.Lupatahot.Single(x => x.Id == (int)id);
      }

      throw new NotImplementedException();

    }

    public bool DeleteEntity(object id, Ohjaustiedot tyyppi)
    {

      IOhjaustieto entity = this.LoadEntity(id, tyyppi);
      bool result;

      switch (tyyppi)
      {
        case Ohjaustiedot.Asiakastyyppi:
          this.DataContext.Asiakastyypit.Remove((Asiakastyyppi)entity);
          break;
        case Ohjaustiedot.Lupataho:
          this.DataContext.Lupatahot.Remove((Lupataho)entity);
          break;
        default:
          throw new NotImplementedException();
      }

      try
      {
        this.DataContext.SaveChanges();
        result = true;
      }
      catch
      {
        result = false;
      }

      return result;

    }

    public IEnumerable<IOhjaustieto> GetAllEntities(Ohjaustiedot tyyppi)
    {

      switch (tyyppi)
      {
        case Ohjaustiedot.Asiakastyyppi:
          return this.DataContext.Asiakastyypit.OrderBy(x => x.Nimi);
        case Ohjaustiedot.Lupataho:
          return this.DataContext.Lupatahot.OrderBy(x => x.Nimi);
      }

      throw new NotImplementedException();

    }

    public override bool IsNewEntity(IOhjaustieto entity)
    {
      return entity.Id == 0;
    }

    public IOhjaustieto GetNewEntity(Ohjaustiedot tyyppi)
    {
      switch (tyyppi)
      {
        case Ohjaustiedot.Asiakastyyppi:
          return new Asiakastyyppi();
        case Ohjaustiedot.Lupataho:
          return new Lupataho();
      }

      throw new NotImplementedException();
    }

    public string HaeOhjaustiedonNimi(Ohjaustiedot tyyppi)
    {

      switch (tyyppi)
      {
        case Ohjaustiedot.Asiakastyyppi:
          return "Asiakasrooli";
        case Ohjaustiedot.Lupataho:
          return "Lupataho";
      }

      throw new NotImplementedException();

    }

    public IEnumerable<Indeksi> HaeVuodenIndeksit(int vuosi)
    {
      return this.DataContext.Indeksit.Where(x => x.Vuosi == vuosi).ToList();
    }

  }

  public class OhjaustietoHandler<T> : EntityHandlerBase<T> where T : class, IOhjaustieto
  {

    public OhjaustietoHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override T LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (int)id);

    }

    public override bool IsNewEntity(T entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<T> OrderEntities(IQueryable<T> entities)
    {
      return entities.OrderBy(a => a.Nimi);
    }

    public override IQueryable<T> GetAll()
    {
      return this.OrderEntities(base.GetAll().OfType<T>());
    }

  }

  public class KuukausiHandler : OhjaustietoHandler<Kuukausi>
  {
    public KuukausiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    protected override IQueryable<Kuukausi> OrderEntities(IQueryable<Kuukausi> entities)
    {
      return entities.OrderBy(a => a.Id);
    }

  }

}
