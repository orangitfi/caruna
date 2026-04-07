using Sopimusrekisteri.BLL_CF;
using System.Linq;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class VuokratyyppiHandler : EntityHandlerBase<Vuokratyyppi>
    {

        public VuokratyyppiHandler(KiltaDataContext dataContext)
          : base(dataContext)
        {
        }

        public override Vuokratyyppi LoadEntity(object id)
        {

            return this.GetAll().Single(x => x.Id == (int)id);

        }

        public override bool IsNewEntity(Vuokratyyppi entity)
        {
            return entity.Id == 0;
        }

    }
}