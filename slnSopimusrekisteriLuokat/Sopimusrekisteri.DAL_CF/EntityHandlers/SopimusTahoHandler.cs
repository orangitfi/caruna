using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class SopimusTahoHandler : EntityHandlerBase<SopimusTaho>
  {

    public SopimusTahoHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(SopimusTaho entity)
    {

      base.SaveEntity(entity);

    }

    public override SopimusTaho LoadEntity(object id)
    {
      return this.DataContext.SopimusTahot.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(SopimusTaho entity)
    {
      return entity.Id == 0;
    }

    public void LisaaTahoSopimukselle(Sopimus sopimus, int tahoId)
    {

      SopimusTaho sopimusTaho = new SopimusTaho();

      sopimusTaho.Sopimus = sopimus;
      sopimusTaho.TahoId = tahoId;
      sopimusTaho.TulostetaanSopimukseen = true;

      this.SaveEntity(sopimusTaho);

    }

  }
}