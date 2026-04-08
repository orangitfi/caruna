using Sopimusrekisteri.BLL_CF;
using System;
using System.Linq;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class KorkoprosenttiHandler : EntityHandlerBase<Korkoprosentti>
    {

        public KorkoprosenttiHandler(KiltaDataContext dataContext)
          : base(dataContext)
        {
        }

        public override Korkoprosentti LoadEntity(object id)
        {

            return this.GetAll().Single(x => x.Id == (int)id);

        }

        public override bool IsNewEntity(Korkoprosentti entity)
        {
            return entity.Id == 0;
        }

        protected override IQueryable<Korkoprosentti> OrderEntities(IQueryable<Korkoprosentti> entities)
        {
            return entities.OrderBy(a => a.Vuodet).ThenBy(a => a.Prosentti);
        }

        public Korkoprosentti HaeKorkoprosentti(DateTime? alkupvm, DateTime? paattymispvm)
        {
            DateTime vertailu = DateTime.Now.Date; // jos alkupäivä on menneisyydessä, niin verrataan nykyiseen päivään
            int vuosiaJaljella = Korkoprosentti.OletusKorkoprosenttiVuodelta; // jos päättymispäivää ei ole niin 35 vuotta

            if (alkupvm.HasValue && alkupvm.Value > DateTime.Now.Date)
            {
                vertailu = alkupvm.Value;
            }

            if (paattymispvm.HasValue)
            {
                var paiviaVuodessa = 365;
                var ero = paattymispvm.Value - vertailu;
                vuosiaJaljella = (int)Math.Round((decimal)ero.TotalDays / (decimal)paiviaVuodessa);
            }

            return GetAll().FirstOrDefault(x => x.Vuodet == vuosiaJaljella);
        }
    }
}