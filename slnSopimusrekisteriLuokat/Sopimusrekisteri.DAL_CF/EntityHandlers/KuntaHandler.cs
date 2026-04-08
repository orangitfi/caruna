using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KuntaHandler : EntityHandlerBase<Kunta>
  {

    public KuntaHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(Kunta entity)
    {

      base.SaveEntity(entity);

    }

    public override Kunta LoadEntity(object id)
    {
      return this.DataContext.Kunnat.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(Kunta entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Kunta> OrderEntities(IQueryable<Kunta> entities)
    {
      return entities.OrderBy(x => x.KuntaNimi);
    }

  }
}