using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class TiedostoHandler : EntityHandlerBase<Tiedosto>
    {

        public TiedostoHandler(KiltaDataContext dataContext)
          : base(dataContext)
        {
        }

        public override void SaveEntity(Tiedosto entity)
        {

            base.SaveEntity(entity);

        }

        public override Tiedosto LoadEntity(object id)
        {
            return this.DataContext.Tiedostot.Single(x => x.Id == (int)id);
        }

        public override bool IsNewEntity(Tiedosto entity)
        {
            return entity.Id == 0;
        }

        /// <summary>
        /// Parsii M-files linkin tiedot, kun linkki annetaan jossain seuraavissa muodoissa:
        /// URL: https://ecm.caruna.fi/OpenMFilesUrl.html?MFilesURL=m-files://show/3C9E89D0-6BF0-4A98-A243-BACA48572717/0-339815?object=BA725068-94CC-4C55-9AAD-40D510CB4AAE
        /// MFILES: m-files://show/3C9E89D0-6BF0-4A98-A243-BACA48572717/0-339815?object=BA725068-94CC-4C55-9AAD-40D510CB4AAE
        /// MFILES: m-files://show/3C9E89D0-6BF0-4A98-A243-BACA48572717/0-339815
        /// </summary>
        public bool ParsiMFilesLinkki(string linkki, Tiedosto entity = null)
        {
            if (string.IsNullOrWhiteSpace(linkki))
                return true;

            if (!linkki.Contains("m-files://"))
                return false;

            string mFilesOsuus = linkki.Split(new string[] { "m-files://" }, StringSplitOptions.None)[1];

            if (string.IsNullOrWhiteSpace(mFilesOsuus))
                return false;

            // pieni hack... asetetaan file scheme jotta Uri luokka hyväksyy linkin
            var uri = new Uri("file://" + mFilesOsuus);

            if (uri.Segments == null || uri.Segments.Length < 3)
                return false;

            string strVault = uri.Segments[1].Replace("/", string.Empty).Replace("\\", string.Empty); // guid
            string[] typeJaId = uri.Segments[2].Replace("/", string.Empty).Replace("\\", string.Empty).Split('-'); // muodossa type-id (esim 0-339815)

            if (typeJaId.Length != 2)
                return false;

            // parsitaan type
            if (!int.TryParse(typeJaId[0], out int type))
                return false;

            // parsitaan id
            if (!int.TryParse(typeJaId[1], out int id))
                return false;

            // parsitaan vault
            if (!Guid.TryParse(strVault, out Guid vault))
                return false;

            if (entity != null)
            {
                entity.MFilesVault = vault;
                entity.MFilesType = type;
                entity.MFilesId = id;
                entity.MFilesObject = null;
            }

            if (!string.IsNullOrWhiteSpace(uri.Query))
            {
                var queryString = HttpUtility.ParseQueryString(uri.Query);
                string strObject = queryString.Get("object");

                // parsitaan object
                if (!Guid.TryParse(strObject, out Guid obj))
                    return false;

                if (entity != null)
                    entity.MFilesObject = obj;
            }

            return true;
        }

    }
}
