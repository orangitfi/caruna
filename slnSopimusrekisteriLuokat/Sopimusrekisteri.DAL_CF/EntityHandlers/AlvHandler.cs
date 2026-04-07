using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class AlvHandler : EntityHandlerBase<Alv>
  {

    public AlvHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override Alv LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (int)id);

    }

    public override bool IsNewEntity(Alv entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Alv> OrderEntities(IQueryable<Alv> entities)
    {
      return entities.OrderBy(a => a.Prosentti);
    }

    public override IQueryable<Alv> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

    public Alv HaeOletus()
    {
      return this.GetAll().SingleOrDefault(x => x.Oletus == true);
    }

  }
}