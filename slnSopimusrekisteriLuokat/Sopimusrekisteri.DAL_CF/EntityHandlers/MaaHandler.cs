using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;


namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class MaaHandler : EntityHandlerBase<Maa>
  {

    public MaaHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(Maa entity)
    {

      base.SaveEntity(entity);

    }

    public override Maa LoadEntity(object id)
    {
      return this.DataContext.Maat.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(Maa entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Maa> OrderEntities(IQueryable<Maa> entities)
    {
      return entities.OrderBy(x => x.NimiSuomi);
    }

  }
}