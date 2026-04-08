using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KieliHandler : EntityHandlerBase<Kieli>
  {

    public KieliHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(Kieli entity)
    {

      base.SaveEntity(entity);

    }

    public override Kieli LoadEntity(object id)
    {
      return this.DataContext.Kielet.Single(x => x.Id == (Kielet)id);
    }

    public override bool IsNewEntity(Kieli entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Kieli> OrderEntities(IQueryable<Kieli> entities)
    {
      return entities.OrderBy(x => x.Nimi);
    }

  }
}