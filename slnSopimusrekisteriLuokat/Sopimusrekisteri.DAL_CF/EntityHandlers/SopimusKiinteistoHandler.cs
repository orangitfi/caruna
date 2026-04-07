using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class SopimusKiinteistoHandler : EntityHandlerBase<SopimusKiinteisto>
  {

    public SopimusKiinteistoHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(SopimusKiinteisto entity)
    {

      base.SaveEntity(entity);

    }

    public override SopimusKiinteisto LoadEntity(object id)
    {
      return this.DataContext.SopimusKiinteistot.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(SopimusKiinteisto entity)
    {
      return entity.Id == 0;
    }

    public void LisaaKiinteistoSopimukselle(int sopimusId, int kiinteistoId)
    {

      SopimusKiinteisto sopimusKiinteisto = new SopimusKiinteisto();

      sopimusKiinteisto.SopimusId = sopimusId;
      sopimusKiinteisto.KiinteistoId = kiinteistoId;

      this.SaveEntity(sopimusKiinteisto);

    }

  }
}