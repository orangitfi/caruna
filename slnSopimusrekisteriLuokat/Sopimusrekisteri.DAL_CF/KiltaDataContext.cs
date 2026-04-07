using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Sopimusrekisteri.BLL_CF;
using System.Data.Entity.Core.Objects.DataClasses;
using Sopimusrekisteri.DAL_CF.EntityConfigurations;
using System.Data.Entity.Infrastructure;

namespace Sopimusrekisteri.DAL_CF
{

    public class KiltaDataContext : DbContext
    {

        #region Vakiot

        private const string ExceptionNoDirectCalls = "Direct calls are not supported.";

        #endregion

        #region Kontekstin luonti

        public KiltaDataContext(string connString, Kayttooikeustiedot kayttooikeustiedot)
          : base(connString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Kayttooikeustiedot = kayttooikeustiedot;
            this.ConnectionString = connString;
            Database.CommandTimeout = 300;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Lisätään kaikki luodut entiteetit.

            modelBuilder.Configurations.Add(new AktiviteetinLajiCfg());
            modelBuilder.Configurations.Add(new AktiviteetinStatusCfg());
            modelBuilder.Configurations.Add(new AktiviteettiCfg());
            modelBuilder.Configurations.Add(new AktiviteettiYhteystapaCfg());
            modelBuilder.Configurations.Add(new AlvCfg());
            modelBuilder.Configurations.Add(new ArkistonSijaintiCfg());
            modelBuilder.Configurations.Add(new AsiakastyyppiCfg());
            modelBuilder.Configurations.Add(new AsiakirjaTarkenneCfg());
            modelBuilder.Configurations.Add(new BicKoodiCfg());
            modelBuilder.Configurations.Add(new DFRooliCfg());
            modelBuilder.Configurations.Add(new HinnastoAlakategoriaCfg());
            modelBuilder.Configurations.Add(new HinnastoKategoriaCfg());
            modelBuilder.Configurations.Add(new IFSPaymentCfg());
            modelBuilder.Configurations.Add(new IndeksiCfg());
            modelBuilder.Configurations.Add(new IndeksityyppiCfg());
            modelBuilder.Configurations.Add(new InfopalluraCfg());
            modelBuilder.Configurations.Add(new InvCostCfg());
            modelBuilder.Configurations.Add(new JulkisuusasteCfg());
            modelBuilder.Configurations.Add(new KieliCfg());
            modelBuilder.Configurations.Add(new KiinteistoCfg());
            modelBuilder.Configurations.Add(new KirjanpidonAineistoCfg());
            modelBuilder.Configurations.Add(new KirjanpidonAineistoRiviCfg());
            modelBuilder.Configurations.Add(new KirjanpidonKustannuspaikkaCfg());
            modelBuilder.Configurations.Add(new KirjanpidontiliCfg());
            modelBuilder.Configurations.Add(new KohdekategoriaCfg());
            modelBuilder.Configurations.Add(new KorvausHinnastoCfg());
            modelBuilder.Configurations.Add(new KorvauslaskelmaCfg());
            modelBuilder.Configurations.Add(new KorvauslaskelmaLokiCfg());
            modelBuilder.Configurations.Add(new KorvauslaskelmaRiviCfg());
            modelBuilder.Configurations.Add(new KorvauslaskemaStatusCfg());
            modelBuilder.Configurations.Add(new KorvaustyyppiCfg());
            modelBuilder.Configurations.Add(new KorvausyksikonTyyppiCfg());
            modelBuilder.Configurations.Add(new KuntaCfg());
            modelBuilder.Configurations.Add(new KuukausiCfg());
            modelBuilder.Configurations.Add(new KylaCfg());
            modelBuilder.Configurations.Add(new LiiketoiminnanTarveCfg());
            modelBuilder.Configurations.Add(new Local1Cfg());
            modelBuilder.Configurations.Add(new LupatahoCfg());
            modelBuilder.Configurations.Add(new MaaCfg());
            modelBuilder.Configurations.Add(new MaaraAlaTarkenneCfg());
            modelBuilder.Configurations.Add(new MaksuaineistoCfg());
            modelBuilder.Configurations.Add(new MaksualueCfg());
            modelBuilder.Configurations.Add(new MaksuCfg());
            modelBuilder.Configurations.Add(new MaksuehdotCfg());
            modelBuilder.Configurations.Add(new MaksunSuoritusCfg());
            modelBuilder.Configurations.Add(new MaksuStatusCfg());
            modelBuilder.Configurations.Add(new MaksuTiliointiCfg());
            modelBuilder.Configurations.Add(new MetsatyyppiCfg());
            modelBuilder.Configurations.Add(new OrganisaationTyyppiCfg());
            modelBuilder.Configurations.Add(new PassivoinninSyyCfg());
            modelBuilder.Configurations.Add(new PcsSummaryRaporttiCfg());
            modelBuilder.Configurations.Add(new PoimintaCfg());
            modelBuilder.Configurations.Add(new PostitiedotCfg());
            modelBuilder.Configurations.Add(new PurposeCfg());
            modelBuilder.Configurations.Add(new PuustolajiCfg());
            modelBuilder.Configurations.Add(new PuustonOmistajuusCfg());
            modelBuilder.Configurations.Add(new PuustonPoistoCfg());
            modelBuilder.Configurations.Add(new RegulationCfg());
            modelBuilder.Configurations.Add(new SaantoCfg());
            modelBuilder.Configurations.Add(new SiirtoOikeusCfg());
            modelBuilder.Configurations.Add(new SopimuksenAlaluokkaCfg());
            modelBuilder.Configurations.Add(new SopimuksenEhtoversioCfg());
            modelBuilder.Configurations.Add(new SopimuksenKestoCfg());
            modelBuilder.Configurations.Add(new SopimuksenTilaCfg());
            modelBuilder.Configurations.Add(new SopimusarkistoLokiCfg());
            modelBuilder.Configurations.Add(new SopimusCfg());
            modelBuilder.Configurations.Add(new SopimusFormaattiCfg());
            modelBuilder.Configurations.Add(new SopimusKiinteistoCfg());
            modelBuilder.Configurations.Add(new SopimusluokkaCfg());
            //modelBuilder.Configurations.Add(new SopimusPoimintaCfg());
            modelBuilder.Configurations.Add(new SopimusTahoCfg());
            modelBuilder.Configurations.Add(new SopimusTulosteCfg());
            modelBuilder.Configurations.Add(new SopimustyyppiCfg());
            modelBuilder.Configurations.Add(new TahoCfg());
            modelBuilder.Configurations.Add(new TahoTyyppiCfg());
            modelBuilder.Configurations.Add(new TiedostoCfg());
            modelBuilder.Configurations.Add(new TiedostolahdeCfg());
            modelBuilder.Configurations.Add(new TunnisteyksikkoCfg());
            modelBuilder.Configurations.Add(new TunnisteyksikkoTyyppiCfg());
            modelBuilder.Configurations.Add(new YksikkoCfg());
            modelBuilder.Configurations.Add(new YlasopimuksenTyyppiCfg());
            modelBuilder.Configurations.Add(new VuokratyyppiCfg());
            modelBuilder.Configurations.Add(new KorkoprosenttiCfg());
            modelBuilder.Configurations.Add(new IFRSHistoriaCfg());
            modelBuilder.Configurations.Add(new IFRSHistoriaExcelCfg());

        }

        #endregion

        #region Muut propertyt

        internal Kayttooikeustiedot Kayttooikeustiedot { get; private set; }
        internal string ConnectionString { get; private set; }
        public string SessioId { get; set; }

        #endregion

        #region DBSetit

        public DbSet<Alv> Alvt { get; set; }
        public DbSet<Asiakastyyppi> Asiakastyypit { get; set; }
        public DbSet<BicKoodi> BicKoodit { get; set; }
        public DbSet<DFRooli> DFRoolit { get; set; }
        public DbSet<IFSPayment> IFSPayments { get; set; }
        public DbSet<Indeksi> Indeksit { get; set; }
        public DbSet<Indeksityyppi> Indeksityypit { get; set; }
        public DbSet<InvCost> InvCostit { get; set; }
        public DbSet<Julkisuusaste> Julkisuusasteet { get; set; }
        public DbSet<Local1> Local1t { get; set; }
        public DbSet<Lupataho> Lupatahot { get; set; }
        public DbSet<Kieli> Kielet { get; set; }
        public DbSet<KirjanpidonKustannuspaikka> KirjanpidonKustannuspaikat { get; set; }
        public DbSet<Kirjanpidontili> Kirjanpidontilit { get; set; }
        public DbSet<Kohdekategoria> Kohdekategoriat { get; set; }
        public DbSet<KorvauslaskelmaLoki> KorvauslaskelmaLokit { get; set; }
        public DbSet<Korvauslaskelma> Korvauslaskelmat { get; set; }
        public DbSet<KorvauslaskelmaStatus> KorvauslaskelmaStatukset { get; set; }
        public DbSet<Korvaustyyppi> Korvaustyypit { get; set; }
        public DbSet<Kunta> Kunnat { get; set; }
        public DbSet<Kuukausi> Kuukaudet { get; set; }
        public DbSet<Korkoprosentti> Korkoprosentit { get; set; }
        public DbSet<Maa> Maat { get; set; }
        public DbSet<Maksuehdot> Maksuehdot { get; set; }
        public DbSet<MaksunSuoritus> MaksunSuoritukset { get; set; }
        public DbSet<Maksu> Maksut { get; set; }
        public DbSet<MaksuTiliointi> MaksuTilioinnit { get; set; }
        public DbSet<OrganisaationTyyppi> OrganisaationTyypit { get; set; }
        public DbSet<PcsSummaryRaportti> PcsSummaryRaportit { get; set; }
        public DbSet<Poiminta> Poiminnat { get; set; }
        public DbSet<Postitiedot> Postitiedot { get; set; }
        public DbSet<Purpose> Purposet { get; set; }
        public DbSet<PuustonOmistajuus> PuustonOmistajuudet { get; set; }
        public DbSet<PuustonPoisto> PuustonPoistot { get; set; }
        public DbSet<Regulation> Regulationit { get; set; }
        public DbSet<SiirtoOikeus> SiirtoOikeudet { get; set; }
        public DbSet<SopimuksenAlaluokka> SopimuksenAlaluokat { get; set; }
        public DbSet<SopimuksenEhtoversio> SopimuksenEhtoversiot { get; set; }
        public DbSet<SopimuksenTila> SopimuksenTilat { get; set; }
        public DbSet<Sopimus> Sopimukset { get; set; }
        public DbSet<SopimusarkistoLoki> Sopimusarkistolokit { get; set; }
        public DbSet<SopimusKiinteisto> SopimusKiinteistot { get; set; }
        public DbSet<SopimusPoiminta> SopimusPoiminnat { get; set; }
        public DbSet<SopimusTaho> SopimusTahot { get; set; }
        public DbSet<SopimusTuloste> SopimusTulosteet { get; set; }
        public DbSet<Sopimustyyppi> Sopimustyypit { get; set; }
        public DbSet<Taho> Tahot { get; set; }
        public DbSet<Tiedosto> Tiedostot { get; set; }
        public DbSet<YlasopimuksenTyyppi> YlasopimuksenTyypit { get; set; }
        public DbSet<Vuokratyyppi> Vuokratyypit { get; set; }



        public DbSet<AktiviteetinLaji> AktiviteetinLaji { get; set; }
        public DbSet<AktiviteetinStatus> AktiviteetinStatus { get; set; }
        public DbSet<Aktiviteetti> Aktiviteetti { get; set; }
        public DbSet<AktiviteettiYhteystapa> AktiviteettiYhteystapa { get; set; }
        public DbSet<ArkistonSijainti> ArkistonSijainti { get; set; }
        public DbSet<AsiakirjaTarkenne> AsiakirjaTarkenne { get; set; }
        public DbSet<HinnastoAlakategoria> HinnastoAlakategoria { get; set; }
        public DbSet<HinnastoKategoria> HinnastoKategoria { get; set; }
        public DbSet<Infopallura> Infopallura { get; set; }
        public DbSet<Kiinteisto> Kiinteisto { get; set; }
        public DbSet<KirjanpidonAineisto> KirjanpidonAineisto { get; set; }
        public DbSet<KirjanpidonAineistoRivi> KirjanpidonAineistoRivi { get; set; }
        public DbSet<KorvausHinnasto> KorvausHinnasto { get; set; }
        public DbSet<KorvauslaskelmaRivi> KorvauslaskelmaRivi { get; set; }
        public DbSet<KorvausyksikonTyyppi> KorvausyksikonTyyppi { get; set; }
        public DbSet<Kyla> Kyla { get; set; }
        public DbSet<LiiketoiminnanTarve> LiiketoiminnanTarve { get; set; }
        public DbSet<MaaraAlaTarkenne> MaaraAlaTarkenne { get; set; }
        public DbSet<Maksuaineisto> Maksuaineisto { get; set; }
        public DbSet<Maksualue> Maksualue { get; set; }
        public DbSet<MaksuStatus> MaksuStatus { get; set; }
        public DbSet<Metsatyyppi> Metsatyyppi { get; set; }
        public DbSet<PassivoinninSyy> PassivoinninSyy { get; set; }
        public DbSet<Puustolaji> Puustolaji { get; set; }
        public DbSet<Saanto> Saanto { get; set; }
        public DbSet<SopimuksenKesto> SopimuksenKesto { get; set; }
        public DbSet<SopimusFormaatti> SopimusFormaatti { get; set; }
        public DbSet<Sopimusluokka> Sopimusluokka { get; set; }
        public DbSet<TahoTyyppi> TahoTyyppi { get; set; }
        public DbSet<Tiedostolahde> Tiedostolahde { get; set; }
        public DbSet<Tunnisteyksikko> Tunnisteyksikko { get; set; }
        public DbSet<TunnisteyksikkoTyyppi> TunnisteyksikkoTyyppi { get; set; }
        public DbSet<Yksikko> Yksikko { get; set; }
        public DbSet<IFRSHistoriaExcel> IFRSHistoriaExcel { get; set; }
        public DbSet<IFRSHistoria> IFRSHistoria { get; set; }

        #endregion

        #region Näkymät ja kyselyfunktiot (IQueryable)

        public IQueryable<Sopimus> AktiivisetSopimukset
        {
            get
            {
                return this.Sopimukset.Where(x => !x.Luonnos && (!x.Irtisanomispvm.HasValue || x.Irtisanomispvm.Value > DateTime.Now) && (x.SopimuksenTilaId == BLL_CF.SopimusTilat.Voimassa));
            }
        }

        #endregion

        #region Tallennus

        public void SaveEntity<T>(T entity, bool newEntity) where T : class
        {
            this.AddOrUpdateEntity<T>(entity, newEntity);
            this.SaveChanges();
        }

        public void SaveEntityRange<T>(IEnumerable<T> entities, Func<T, bool> isNewEntityFunc) where T : class
        {
            foreach (T entity in entities)
            {
                AddOrUpdateEntity<T>(entity, isNewEntityFunc(entity));
            }

            this.SaveChanges();
        }

        public void AddOrUpdateEntity<T>(T entity, bool newEntity) where T : class
        {
            IEditable editable = entity as IEditable;

            if (newEntity)
            {
                DbSet<T> db = this.Set<T>();
                db.Add(entity);

                if (editable != null)
                {
                    editable.Luoja = this.Kayttooikeustiedot.Username;
                    editable.Luotu = DateTime.Now;
                }
            }
            else
            {
                if (editable != null)
                {
                    editable.Paivittaja = this.Kayttooikeustiedot.Username;
                    editable.Paivitetty = DateTime.Now;
                }
            }
        }

        public void AddOrUpdateEntityRange<T>(IEnumerable<T> entities, Func<T, bool> isNewEntityFunc) where T : class
        {
            foreach (T entity in entities)
            {
                this.AddOrUpdateEntity<T>(entity, isNewEntityFunc(entity));
            }
        }

        #endregion

        #region Entityjen poisto

        /// <summary>
        /// Poistaa entiteetin mutta ei tallenna muutoksia.
        /// </summary>
        public void DeleteEntity<T>(T entity) where T : class
        {
            DbSet<T> db = this.Set<T>();
            db.Remove(entity);
        }

        /// <summary>
        /// Poistaa entiteetit mutta ei tallenna muutoksia.
        /// </summary>
        public void DeleteEntityRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T> db = this.Set<T>();
            db.RemoveRange(entities);
        }

        /// <summary>
        /// Poistaa entiteetin ja tallentaa muutokset.
        /// </summary>
        public void DeleteEntityAndSave<T>(T entity) where T : class
        {
            this.DeleteEntity<T>(entity);
            this.SaveChanges();
        }

        /// <summary>
        /// Poistaa entiteetit ja tallentaa muutokset.
        /// </summary>
        public void DeleteEntityRangeAndSave<T>(IEnumerable<T> entities) where T : class
        {
            this.DeleteEntityRange<T>(entities);
            this.SaveChanges();
        }

        #endregion

        #region Entity handler management

        public EntityHandlers.EntityHandlerBase<T> GetEntityHandler<T>() where T : class
        {
            System.Reflection.Assembly asm = this.GetType().Assembly;

            IEnumerable<Type> types = asm.GetTypes().Where(x => x.Namespace == "Sopimusrekisteri.DAL_CF.EntityHandlers");

            foreach (Type t in types)
            {
                if (t.IsSubclassOf(typeof(Sopimusrekisteri.DAL_CF.EntityHandlers.EntityHandlerBase<T>)))
                {
                    return (EntityHandlers.EntityHandlerBase<T>)Activator.CreateInstance(t, this);
                }
            }

            return null;
        }

        #endregion

        #region Tietokantafunktiot

        [EdmFunction("SqlServer", "PATINDEX")]
        public int PatIndex(string value, string pattern)
        {
            throw new NotSupportedException(ExceptionNoDirectCalls);
        }

        #endregion

    }
}
