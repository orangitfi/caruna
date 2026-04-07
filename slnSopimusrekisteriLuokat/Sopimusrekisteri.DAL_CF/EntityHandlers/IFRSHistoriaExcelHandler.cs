using Sopimusrekisteri.BLL_CF;
using Sopimusrekisteri.BLL_CF.Models;
using System;
using System.IO;
using System.Linq;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class IFRSHistoriaExcelHandler : EntityHandlerBase<IFRSHistoriaExcel>
    {

        public IFRSHistoriaExcelHandler(KiltaDataContext dataContext)
          : base(dataContext)
        {
        }

        public override IFRSHistoriaExcel LoadEntity(object id)
        {

            return this.GetAll().Single(x => x.Id == (int)id);

        }

        public override bool IsNewEntity(IFRSHistoriaExcel entity)
        {
            return entity.Id == 0;
        }

        protected override IQueryable<IFRSHistoriaExcel> OrderEntities(IQueryable<IFRSHistoriaExcel> entities)
        {
            return entities.OrderByDescending(a => a.Pvm);
        }

        public IQueryable<IFRSHistoriaExcelModel> HaeExcelit()
        {
            return GetAll().Select(x => new IFRSHistoriaExcelModel
            {
                Id = x.Id,
                Pvm = x.Pvm,
                Luotu = x.Luotu,
                Luoja = x.Luoja,
                Nimi = x.Nimi
            });
        }

        public bool TallennaExcel(string polku, DateTime pvm)
        {
            if (!File.Exists(polku))
                return false;

            var excel = new IFRSHistoriaExcel
            {
                Nimi = Path.GetFileName(polku),
                Sisalto = File.ReadAllBytes(polku),
                Pvm = pvm,
                Luotu = DateTime.Now,
                Luoja = DataContext.Kayttooikeustiedot.Username
            };

            SaveEntity(excel);

            return true;
        }


    }
}