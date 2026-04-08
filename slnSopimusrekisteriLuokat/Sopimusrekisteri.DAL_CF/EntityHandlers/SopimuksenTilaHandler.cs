using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class SopimuksenTilaHandler : EntityHandlerBase<SopimuksenTila>
  {

    public SopimuksenTilaHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(SopimuksenTila entity)
    {

      base.SaveEntity(entity);

    }

    public override SopimuksenTila LoadEntity(object id)
    {
      return this.DataContext.SopimuksenTilat.Single(x => x.Id == (SopimusTilat)id);
    }

    public override bool IsNewEntity(SopimuksenTila entity)
    {
      return entity.Id == 0;
    }

  }
}