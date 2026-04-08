using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class SopimusarkistoHandler : EntityHandlerBase<SopimusarkistoLoki>
  {

    public SopimusarkistoHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(SopimusarkistoLoki entity)
    {

      entity.Luoja = this.DataContext.Kayttooikeustiedot.Username;
      entity.Luotu = DateTime.Now;

      base.SaveEntity(entity);

    }

    public override SopimusarkistoLoki LoadEntity(object id)
    {
      return this.DataContext.Sopimusarkistolokit.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(SopimusarkistoLoki entity)
    {
      return entity.Id == 0;
    }

  }
}
