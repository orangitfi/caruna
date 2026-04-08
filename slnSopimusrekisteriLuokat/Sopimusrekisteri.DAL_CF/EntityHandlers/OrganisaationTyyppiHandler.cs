using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class OrganisaationTyyppiHandler : EntityHandlerBase<OrganisaationTyyppi>
  {

    public OrganisaationTyyppiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(OrganisaationTyyppi entity)
    {

      base.SaveEntity(entity);

    }

    public override OrganisaationTyyppi LoadEntity(object id)
    {
      return this.DataContext.OrganisaationTyypit.Single(x => x.Id == (Organisaatiotyypit)id);
    }

    public override bool IsNewEntity(OrganisaationTyyppi entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<OrganisaationTyyppi> OrderEntities(IQueryable<OrganisaationTyyppi> entities)
    {
      return entities.OrderBy(x => x.Tyyppi);
    }

    protected override IQueryable<OrganisaationTyyppi> FilterEntities(IQueryable<OrganisaationTyyppi> entities)
    {
      if (this.DataContext.Kayttooikeustiedot.Taso == KayttooikeusTaso.Suppea)
      {
        return entities.Where(x => x.Id != Organisaatiotyypit.JuridinenYhtio);
      }

      return entities;
    }

  }
}