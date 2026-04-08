using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class MaksunSuoritusHandler : EntityHandlerBase<MaksunSuoritus>
  {

    public MaksunSuoritusHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override MaksunSuoritus LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (MaksunSuoritukset)id);

    }

    public override bool IsNewEntity(MaksunSuoritus entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<MaksunSuoritus> OrderEntities(IQueryable<MaksunSuoritus> entities)
    {
      return entities.OrderBy(a => a.Nimi);
    }

    public override IQueryable<MaksunSuoritus> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

  }
}