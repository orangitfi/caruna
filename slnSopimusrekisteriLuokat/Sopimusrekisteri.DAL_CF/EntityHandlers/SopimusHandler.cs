using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;
using KT.Utils.Mapping;
using Sopimusrekisteri.BLL_CF.Hakuehdot;
using System.Data.Entity;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class SopimusHandler : EntityHandlerBase<Sopimus>
    {

        public SopimusHandler(KiltaDataContext dataContext)
          : base(dataContext)
        {
        }

        public override void SaveEntity(Sopimus entity)
        {
            if (entity.SopimuksenTilaId == SopimusTilat.Luonnos && entity.AsiakkaanAllekirjoitusPvm.HasValue && entity.VerkonhaltijanAllekirjoitusPvm.HasValue)
            {
                entity.SopimuksenTilaId = SopimusTilat.Voimassa;
            }

            if (!entity.Alkaa.HasValue && entity.VerkonhaltijanAllekirjoitusPvm.HasValue)
            {
                entity.Alkaa = entity.VerkonhaltijanAllekirjoitusPvm;
            }

            entity.LaskennallinenPaattymispvm = entity.DynaaminenLaskennallinenPaattymispvm.Value;

            base.SaveEntity(entity);
        }

        public override Sopimus LoadEntity(object id)
        {
            return this.DataContext.Sopimukset.Single(x => x.Id == (int)id);
        }

        public Sopimus LoadEntityOrNull(object id)
        {
            return this.DataContext.Sopimukset.SingleOrDefault(x => x.Id == (int)id);
        }

        public override bool IsNewEntity(Sopimus entity)
        {
            return entity.Id == 0;
        }

        public IEnumerable<Sopimus> HaeSopimusarkistoonPaivitettavatSopimukset()
        {

            return this.DataContext.Sopimukset.Include("SopimusKiinteistot.Kiinteisto").Include("Asiakkaat.Taho").Include("Tunnisteyksikot").Include("Tiedostot").Where(x => (!x.TiedostoHaettu || !x.MetatiedotPaivitetty) && x.AsiakkaanAllekirjoitusPvm.HasValue && !x.Luonnos).OrderBy(x => x.SopimusarkistosiirtoTehty ?? DateTime.MinValue);

        }

        public Sopimus CopyEntity(object id)
        {
            Sopimus newEntity = new Sopimus();

            AutomappingSettings mappingSettings = new AutomappingSettings();

            mappingSettings.ExcludeProperties = new string[] { "Id", "Luoja", "Luotu", "Paivittaja", "Paivitetty", "PaasopimusId", "YlasopimuksenTyyppiId", "Sopimusvuosi", "Nimi", "LaskennallinenPaattymispvm", "SopimustyypinNimi", "Hyvaksytty" };

            ClassMapping mapping = ObjectToObjectMapper.CreateAutoMapping<Sopimus, Sopimus>(mappingSettings);

            ObjectToObjectMapper<Sopimus, Sopimus> mapper = new ObjectToObjectMapper<Sopimus, Sopimus>();

            mapper.WriteToTarget(newEntity, this.LoadEntity(id), mapping);

            return newEntity;

        }

        public IQueryable<Sopimus> HaeSopimukset(SopimusHakuehdot ehdot)
        {
            IQueryable<Sopimus> sopimukset = GetDBQuery(ehdot.IncludePaths);

            if (ehdot.SopimustyyppiId.HasValue) sopimukset = sopimukset.Where(x => x.SopimustyyppiId == ehdot.SopimustyyppiId.Value);
            if (ehdot.Sopimusnumero.HasValue) sopimukset = sopimukset.Where(x => x.Id == ehdot.Sopimusnumero.Value);
            if (ehdot.SopimusnumeroAlku.HasValue) sopimukset = sopimukset.Where(x => x.Id >= ehdot.SopimusnumeroAlku.Value);
            if (ehdot.SopimuksenTilaId.HasValue) sopimukset = sopimukset.Where(x => x.SopimuksenTilaId.HasValue && x.SopimuksenTilaId.Value == ehdot.SopimuksenTilaId.Value);
            if (ehdot.SopimusnumeroLoppu.HasValue) sopimukset = sopimukset.Where(x => x.Id <= ehdot.SopimusnumeroLoppu.Value);
            if (ehdot.AlkupvmAlku.HasValue) sopimukset = sopimukset.Where(x => x.Alkaa.HasValue && DbFunctions.TruncateTime(x.Alkaa.Value) >= ehdot.AlkupvmAlku.Value);
            if (ehdot.AlkupvmLoppu.HasValue) sopimukset = sopimukset.Where(x => x.Alkaa.HasValue && DbFunctions.TruncateTime(x.Alkaa.Value) <= ehdot.AlkupvmLoppu.Value);
            if (ehdot.PaattymispvmAlku.HasValue) sopimukset = sopimukset.Where(x => x.Alkaa.HasValue && DbFunctions.TruncateTime(x.Alkaa.Value) >= ehdot.PaattymispvmAlku.Value);
            if (ehdot.PaattymispvmLoppu.HasValue) sopimukset = sopimukset.Where(x => x.Alkaa.HasValue && DbFunctions.TruncateTime(x.Alkaa.Value) <= ehdot.PaattymispvmLoppu.Value);
            if (ehdot.Paasopimus.HasValue) sopimukset = sopimukset.Where(x => x.YlasopimuksenTyyppiId.HasValue == ehdot.Paasopimus.Value);
            if (ehdot.PaasopimusId.HasValue) sopimukset = sopimukset.Where(x => x.PaasopimusId == ehdot.PaasopimusId.Value);

            return sopimukset;
        }

    }
}
