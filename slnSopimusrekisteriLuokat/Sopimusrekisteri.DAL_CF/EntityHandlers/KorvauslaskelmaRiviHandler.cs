using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KorvauslaskelmaRiviHandler : EntityHandlerBase<KorvauslaskelmaRivi>
  {

    public KorvauslaskelmaRiviHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override KorvauslaskelmaRivi LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (int)id);

    }

    public override bool IsNewEntity(KorvauslaskelmaRivi entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<KorvauslaskelmaRivi> OrderEntities(IQueryable<KorvauslaskelmaRivi> entities)
    {
      return entities.OrderBy(a => a.Id);
    }

    public override IQueryable<KorvauslaskelmaRivi> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

  }
}