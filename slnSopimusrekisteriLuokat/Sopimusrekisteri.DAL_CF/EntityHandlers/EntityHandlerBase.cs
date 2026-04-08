using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{

  public abstract class EntityHandlerBase
  {

    private KiltaDataContext _dataContext;
    private HandlerContext _handlers;


    public EntityHandlerBase(KiltaDataContext dataContext)
    {
      this._dataContext = dataContext;
    }

    public bool BulkOperationMode { get; set; }

    protected KiltaDataContext DataContext
    {
      get { return this._dataContext; }
    }

    protected HandlerContext Handlers
    {
      get
      {
        if (this._handlers == null) { this._handlers = new HandlerContext(this.DataContext); }
        return this._handlers;
      }
    }

  }

  public abstract class EntityHandlerBase<T> : EntityHandlerBase where T : class
  {
    public delegate void CheckPreviousValuesDelegate(object sender, InspectPreviousValuesEventArgs<T> args);

    public event CheckPreviousValuesDelegate CheckingPreviousValues;

    public EntityHandlerBase(KiltaDataContext dataContext)
        : base(dataContext)
    {
    }

    public virtual T CreateEntity()
    {
      return Activator.CreateInstance<T>();
    }

    public abstract T LoadEntity(object id);

    public abstract bool IsNewEntity(T entity);

    public virtual bool IsDeleteOk(object id)
    {
      return true;
    }

    public virtual IQueryable<T> GetAll()
    {
      return this.OrderEntities(this.DataContext.Set<T>());
    }

    public virtual IQueryable<T> GetAllFiltered()
    {
      return this.OrderEntities(this.FilterEntities(this.DataContext.Set<T>()));
    }

    protected virtual IQueryable<T> FilterEntities(IQueryable<T> entities)
    {
      return entities;
    }

    public virtual void AddOrUpdateEntity(T entity)
    {
      if (this.CheckingPreviousValues != null && !this.IsNewEntity(entity))
      {
        var currentData = this.DataContext.Entry(entity).CurrentValues.Clone();
        this.DataContext.Entry(entity).Reload();
        InspectPreviousValuesEventArgs<T> args = new InspectPreviousValuesEventArgs<T>() { CurrentValues = currentData, Entity = entity };
        this.CheckingPreviousValues(this, args);

        if (args.RestoreCurrentValues) this.DataContext.Entry(entity).CurrentValues.SetValues(currentData);

        this.DataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
      }

      this.DataContext.AddOrUpdateEntity<T>(entity, this.IsNewEntity(entity));
    }

    public virtual void SaveEntity(T entity)
    {
      this.AddOrUpdateEntity(entity);
      this.DataContext.SaveChanges();
    }

    public virtual void SaveEntityRange(IEnumerable<T> entities)
    {
      this.AddOrUpdateEntityRange(entities);

      this.DataContext.SaveChanges();
    }

    public virtual void AddOrUpdateEntityRange(IEnumerable<T> entities)
    {
      foreach (T entity in entities)
      {
        this.AddOrUpdateEntity(entity);
      }
    }

    protected virtual IQueryable<T> OrderEntities(IQueryable<T> entities)
    {
      return entities;
    }

    public DbQuery<T> GetDBQuery(IEnumerable<string> includePaths)
    {
      DbQuery<T> query = this.DataContext.Set<T>();

      if (includePaths != null)
      {
        foreach (string path in includePaths)
        {
          query = query.Include(path);
        }
      }

      return query;
    }

    #region Poisto

    public void DeleteEntity(object id)
    {
      this.DeleteEntity(this.LoadEntity(id));
    }

    public virtual void DeleteEntity(T entity)
    {
      this.DataContext.DeleteEntity<T>(entity);
    }

    public void DeleteEntityAndSave(object id)
    {
      this.DeleteEntityAndSave(this.LoadEntity(id));
    }

    public void DeleteEntityAndSave(T entity)
    {
      this.DeleteEntity(entity);
      this.DataContext.SaveChanges();
    }

    public virtual void DeleteEntityRange(IEnumerable<T> entities)
    {
      this.DataContext.DeleteEntityRange<T>(entities);
    }

    public void DeleteEntityRangeAndSave(IEnumerable<T> entities)
    {
      this.DeleteEntityRange(entities);
      this.DataContext.SaveChanges();
    }

    #endregion

  }
}
