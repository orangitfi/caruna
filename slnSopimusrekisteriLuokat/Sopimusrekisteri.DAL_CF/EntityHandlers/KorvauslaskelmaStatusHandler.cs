using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KorvauslaskelmaStatusHandler : EntityHandlerBase<KorvauslaskelmaStatus>
  {

    public KorvauslaskelmaStatusHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override KorvauslaskelmaStatus LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (KorvauslaskelmaStatukset)id);

    }

    public override bool IsNewEntity(KorvauslaskelmaStatus entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<KorvauslaskelmaStatus> OrderEntities(IQueryable<KorvauslaskelmaStatus> entities)
    {
      return entities.OrderBy(a => a.Nimi);
    }

    public override IQueryable<KorvauslaskelmaStatus> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

  }
}