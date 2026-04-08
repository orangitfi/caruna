using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class SopimustyyppiHandler : EntityHandlerBase<Sopimustyyppi>
  {

    public SopimustyyppiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(Sopimustyyppi entity)
    {

      base.SaveEntity(entity);

    }

    public override Sopimustyyppi LoadEntity(object id)
    {
      return this.DataContext.Sopimustyypit.Single(x => x.Id == (Sopimustyypit)id);
    }

    public override bool IsNewEntity(Sopimustyyppi entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Sopimustyyppi> OrderEntities(IQueryable<Sopimustyyppi> entities)
    {
      return entities.OrderBy(x => x.SopimustyyppiNimi);
    }

  }
}