using Sopimusrekisteri.BLL_CF;
using System.Linq;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class IFRSHistoriaHandler : EntityHandlerBase<IFRSHistoria>
    {

        public IFRSHistoriaHandler(KiltaDataContext dataContext)
          : base(dataContext)
        {
        }

        public override IFRSHistoria LoadEntity(object id)
        {

            return this.GetAll().Single(x => x.Id == (int)id);

        }

        public override bool IsNewEntity(IFRSHistoria entity)
        {
            return entity.Id == 0;
        }

        protected override IQueryable<IFRSHistoria> OrderEntities(IQueryable<IFRSHistoria> entities)
        {
            return entities.OrderBy(a => a.Pvm).ThenBy(x => x.SopimusId);
        }

    }
}