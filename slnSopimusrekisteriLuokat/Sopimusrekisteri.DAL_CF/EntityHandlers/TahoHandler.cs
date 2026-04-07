using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class TahoHandler : EntityHandlerBase<Taho>
  {

    public TahoHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(Taho entity)
    {

      base.SaveEntity(entity);

    }

    public override Taho LoadEntity(object id)
    {
      return this.DataContext.Tahot.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(Taho entity)
    {
      return entity.Id == 0;
    }

    public IQueryable<Taho> GetJuridisetYhtiot()
    {
      return this.GetAll().Where(x => x.OrganisaationTyyppiId == Organisaatiotyypit.JuridinenYhtio);
    }

    public IQueryable<Taho> GetYhtiot()
    {
      return this.GetAll().Where(x => x.OrganisaationTyyppiId == Organisaatiotyypit.Yhtio);
    }

  }
}