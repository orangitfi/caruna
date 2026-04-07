using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KorvauslaskelmaLokiHandler : EntityHandlerBase<KorvauslaskelmaLoki>
  {

    public KorvauslaskelmaLokiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override KorvauslaskelmaLoki LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (int)id);

    }

    public override bool IsNewEntity(KorvauslaskelmaLoki entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<KorvauslaskelmaLoki> OrderEntities(IQueryable<KorvauslaskelmaLoki> entities)
    {
      return entities.OrderBy(a => a.Id);
    }

    public override IQueryable<KorvauslaskelmaLoki> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

  }
}