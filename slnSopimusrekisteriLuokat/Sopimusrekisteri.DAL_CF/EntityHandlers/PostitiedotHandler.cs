using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class PostitiedotHandler : EntityHandlerBase<Postitiedot>
  {

    public PostitiedotHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(Postitiedot entity)
    {

      base.SaveEntity(entity);

    }

    public override Postitiedot LoadEntity(object id)
    {
      return this.DataContext.Postitiedot.Single(x => x.Id == (int)id);
    }

    public Postitiedot LoadEntity(string postinumero)
    {
      return this.DataContext.Postitiedot.Single(x => x.Postinumero == postinumero);
    }

    public override bool IsNewEntity(Postitiedot entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<Postitiedot> OrderEntities(IQueryable<Postitiedot> entities)
    {
      return entities.OrderBy(x => x.Postitoimipaikka);
    }

  }
}