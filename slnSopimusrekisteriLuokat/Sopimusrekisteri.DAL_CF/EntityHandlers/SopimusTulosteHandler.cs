using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class SopimusTulosteHandler : EntityHandlerBase<SopimusTuloste>
  {

    public SopimusTulosteHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(SopimusTuloste entity)
    {

      base.SaveEntity(entity);

    }

    public override SopimusTuloste LoadEntity(object id)
    {
      return this.DataContext.SopimusTulosteet.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(SopimusTuloste entity)
    {
      return entity.Id == 0;
    }

    public SopimusTuloste HaeSopimuksenTuloste(int sopimusId)
    {
      return this.DataContext.SopimusTulosteet.SingleOrDefault(x => x.SopimusId == sopimusId);
    }

  }
}