using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KorvaustyyppiHandler : EntityHandlerBase<Korvaustyyppi>
  {

    public KorvaustyyppiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override Korvaustyyppi LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (Korvaustyypit)id);

    }

    public override bool IsNewEntity(Korvaustyyppi entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Korvaustyyppi> OrderEntities(IQueryable<Korvaustyyppi> entities)
    {
      return entities.OrderBy(a => a.Nimi);
    }

    public override IQueryable<Korvaustyyppi> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

  }
}