using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class BicKoodiHandler : EntityHandlerBase<BicKoodi>
  {

    public BicKoodiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(BicKoodi entity)
    {

      base.SaveEntity(entity);

    }

    public override BicKoodi LoadEntity(object id)
    {
      return this.DataContext.BicKoodit.Single(x => x.Id == (int)id);
    }

    public BicKoodi LoadEntity(string rahalaitostunnus)
    {
      return this.DataContext.BicKoodit.SingleOrDefault(x => x.RahalaitosTunnus == rahalaitostunnus || (x.RahalaitosTunnus.Contains(rahalaitostunnus) && x.RahalaitosTunnus.Contains(",")));
    }

    public override bool IsNewEntity(BicKoodi entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<BicKoodi> OrderEntities(IQueryable<BicKoodi> entities)
    {
      return entities.OrderBy(x => x.Koodi);
    }

  }
}