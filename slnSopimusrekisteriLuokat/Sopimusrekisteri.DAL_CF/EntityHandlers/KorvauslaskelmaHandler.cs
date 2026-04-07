using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;
using System.Data.Entity.Infrastructure;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class KorvauslaskelmaHandler : EntityHandlerBase<Korvauslaskelma>
  {

    public KorvauslaskelmaHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void AddOrUpdateEntity(Korvauslaskelma entity)
    {

      KorvauslaskelmaLoki loki = null;

      if (!this.BulkOperationMode)
      {
        KorvauslaskelmaStatukset? uusiStatus = null;
        KorvauslaskelmaStatukset? vanhaStatus = null;
        
        if (this.IsNewEntity(entity))
        {

          if (!entity.KorvauslaskelmaStatusId.HasValue)
            entity.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Hyvaksymatta;

          if (!entity.KorvaustyyppiId.HasValue)
            entity.KorvaustyyppiId = Korvaustyypit.Kertakorvaus;

          if (entity.KorvaustyyppiId == Korvaustyypit.Kertakorvaus)
            entity.MaksuKuukausiId = null;

          Sopimus sopimus = this.Handlers.Sopimukset.LoadEntity(entity.SopimusId);

          if (sopimus.Asiakkaat != null && sopimus.Asiakkaat.Count == 1)
            entity.SaajaId = sopimus.Asiakkaat.First().TahoId;
        }
        else
        {
          var currentData = this.DataContext.Entry(entity).CurrentValues.Clone();

          this.DataContext.Entry(entity).Reload();

          vanhaStatus = entity.KorvauslaskelmaStatusId;

          this.DataContext.Entry(entity).CurrentValues.SetValues(currentData);

          foreach (KorvauslaskelmaRivi rivi in entity.Rivit)
          {
            rivi.KirjanpidonTiliId = entity.KirjanpidonTiliId;
            rivi.KirjanpidonKustannuspaikkaId = entity.KirjanpidonKustannuspaikkaId;
            rivi.InvCostId = entity.InvCostId;
            rivi.PurposeId = entity.PurposeId;
            rivi.RegulationId = entity.RegulationId;
            rivi.Local1Id = entity.Local1Id;
          }

        }

        uusiStatus = entity.KorvauslaskelmaStatusId;

        if (vanhaStatus != uusiStatus || this.IsNewEntity(entity))
        {

          loki = new KorvauslaskelmaLoki();

          loki.Korvauslaskelma = entity;
          loki.StatusId = uusiStatus;

        }

        if (entity.MaksetaanAlv == true && !entity.AlvId.HasValue)
        {

          Alv oletusAlv = this.Handlers.Alvt.HaeOletus();

          if (oletusAlv != null)
            entity.AlvId = oletusAlv.Id;

        }

        base.AddOrUpdateEntity(entity);

      }


      if (!this.BulkOperationMode)
      {
        if (loki != null)
        {
          this.Handlers.Korvauslaskelmalokit.AddOrUpdateEntity(loki);
        }
      }
    }

    public override Korvauslaskelma LoadEntity(object id)
    {
      return this.DataContext.Korvauslaskelmat.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(Korvauslaskelma entity)
    {
      return entity.Id == 0;
    }

    public override void DeleteEntity(Korvauslaskelma entity)
    {

      this.Handlers.Korvauslaskelmarivit.DeleteEntityRange(entity.Rivit);

      this.Handlers.Korvauslaskelmalokit.DeleteEntityRange(entity.Historia);

      base.DeleteEntity(entity);
    }

    public override bool IsDeleteOk(object id)
    {

      return !this.Handlers.Maksut.GetAll().Any(x => x.KorvauslaskelmaId == (int)id);

    }

    public IEnumerable<Korvauslaskelma> HaeMaksettavatKorvauslaskelmat(int kuukausi)
    {

      List<Korvauslaskelma> korvauslaskelmat = new List<Korvauslaskelma>();

      korvauslaskelmat.AddRange(this.HaeMaksettavatKorvauslaskelmatKertakorvaus(kuukausi).ToList());
      korvauslaskelmat.AddRange(this.HaeMaksettavatKorvauslaskelmatVuosimaksu(kuukausi).ToList());
      korvauslaskelmat.AddRange(this.HaeMaksettavatKorvauslaskelmatKuukausivuokra().ToList());

      return korvauslaskelmat;

    }
    public IEnumerable<Korvauslaskelma> HaeMaksettavatKorvauslaskelmatKertakorvaus(int kuukausi)
    {

      IQueryable<Korvauslaskelma> korvauslaskelmat = this.DataContext.Korvauslaskelmat.Include("Saaja").Include("Sopimus").Include("Rivit").Where(x => this.DataContext.AktiivisetSopimukset.Contains(x.Sopimus));

      return korvauslaskelmat.Where(x => x.KorvauslaskelmaStatusId == KorvauslaskelmaStatukset.Hyvaksytty
         && x.EnsimmainenSallittuMaksuPvm <= DateTime.Now
         && (x.MaksunSuoritusId == MaksunSuoritukset.VerkonhaltijaSuorittaaKorvauksen || x.MaksunSuoritusId == MaksunSuoritukset.AsiakkaanLahettamaLaskuTosite)
         && x.KorvaustyyppiId == Korvaustyypit.Kertakorvaus
         && (!x.MaksuKuukausiId.HasValue || x.MaksuKuukausiId == kuukausi));

    }

    public IEnumerable<Korvauslaskelma> HaeMaksettavatKorvauslaskelmatVuosimaksu(int kuukausi)
    {

      IQueryable<Korvauslaskelma> korvauslaskelmat = this.DataContext.Korvauslaskelmat.Include("Saaja").Include("Sopimus").Include("Rivit").Where(x => this.DataContext.AktiivisetSopimukset.Contains(x.Sopimus));

      DateTime kuluvaPaiva = DateTime.Now.Date;

      return korvauslaskelmat.Where(x => x.KorvauslaskelmaStatusId == KorvauslaskelmaStatukset.Hyvaksytty
         && x.EnsimmainenSallittuMaksuPvm <= DateTime.Now
         && (x.MaksunSuoritusId == MaksunSuoritukset.VerkonhaltijaSuorittaaKorvauksen || x.MaksunSuoritusId == MaksunSuoritukset.AsiakkaanLahettamaLaskuTosite)
         && x.KorvaustyyppiId == Korvaustyypit.Vuosimaksu
         && (x.MaksuKuukausiId == kuukausi)
         && (!x.ViimeisinMaksuPvm.HasValue || x.ViimeisinMaksuPvm.Value.Year < DateTime.Now.Year)
         && (!x.ViimeinenMaksuPvm.HasValue || x.ViimeinenMaksuPvm.Value > kuluvaPaiva));
    }

    public IEnumerable<Korvauslaskelma> HaeMaksettavatKorvauslaskelmatKuukausivuokra()
    {

      IQueryable<Korvauslaskelma> korvauslaskelmat = this.DataContext.Korvauslaskelmat.Include("Saaja").Include("Sopimus").Include("Rivit").Where(x => this.DataContext.AktiivisetSopimukset.Contains(x.Sopimus));

      DateTime kuluvaPaiva = DateTime.Now.Date;

      return korvauslaskelmat.Where(x => x.KorvauslaskelmaStatusId == KorvauslaskelmaStatukset.Hyvaksytty
         && x.EnsimmainenSallittuMaksuPvm <= DateTime.Now
         && (x.MaksunSuoritusId == MaksunSuoritukset.VerkonhaltijaSuorittaaKorvauksen || x.MaksunSuoritusId == MaksunSuoritukset.AsiakkaanLahettamaLaskuTosite)
         && x.KorvaustyyppiId == Korvaustyypit.Kuukausivuokra
         && (!x.ViimeisinMaksuPvm.HasValue || x.ViimeisinMaksuPvm.Value.Year < DateTime.Now.Year)
         && (!x.ViimeinenMaksuPvm.HasValue || x.ViimeinenMaksuPvm.Value > kuluvaPaiva));

    }
    public decimal? haeMaksuunMenevaArvo(List<Indeksi> lstIndeksit, Korvauslaskelma korvauslaskelma)
    {
      decimal? maksuunMenevaSumma = 0.0M;
      decimal? indeksi = null;
      if (korvauslaskelma.OnIndeksi)
      {
        if (korvauslaskelma.ViimeisinMaksuPvm.HasValue)
        {
          if (korvauslaskelma.IndeksityyppiId.HasValue && korvauslaskelma.IndeksiKuukausiId.HasValue)
          {
            if (lstIndeksit.Any(x => x.KuukausiId == korvauslaskelma.IndeksiKuukausiId.Value && x.IndeksityyppiId == korvauslaskelma.IndeksityyppiId.Value))
            {
              indeksi = lstIndeksit.First(x => x.KuukausiId == korvauslaskelma.IndeksiKuukausiId.Value && x.IndeksityyppiId == korvauslaskelma.IndeksityyppiId.Value).Arvo;
            }
          }
        }
        else
        {
          indeksi = korvauslaskelma.SopimushetkenIndeksiArvo;
        }
        if (indeksi != null && indeksi < korvauslaskelma.ViimeisinMaksuIndeksi)
          indeksi = korvauslaskelma.ViimeisinMaksuIndeksi;
      }
      if (korvauslaskelma.OnIndeksi && indeksi != null && korvauslaskelma.SopimushetkenIndeksiArvo.HasValue)
      {
        maksuunMenevaSumma = korvauslaskelma.Rivit.Sum(x => x.Korvaus.GetValueOrDefault(0));
        maksuunMenevaSumma = Math.Round((decimal)(maksuunMenevaSumma * indeksi / korvauslaskelma.SopimushetkenIndeksiArvo), 2);
      }
      if (indeksi == null)
        maksuunMenevaSumma = korvauslaskelma.Summa;
      if (korvauslaskelma.Alv != null)
      {
        decimal AlvOsuus = Math.Round((decimal)(maksuunMenevaSumma * (korvauslaskelma.Alv.Prosentti / 100)), 2);
        maksuunMenevaSumma += AlvOsuus;
      }

      return maksuunMenevaSumma;
    }

    public void PaivitaKorvauslaskelmaMaksetuksi(Korvauslaskelma korvauslaskelma, Maksu maksu)
    {

      korvauslaskelma.ViimeisinMaksuPvm = maksu.Maksupaiva;
      korvauslaskelma.ViimeisinIndeksi = maksu.Indeksi;
      korvauslaskelma.ViimeisinMaksu = maksu.Summa;
      korvauslaskelma.ViimeisinMaksuIndeksi = maksu.MaksuIndeksi;
      korvauslaskelma.ViimeisinIndeksiVuosi = maksu.IndeksiVuosi;

      if (korvauslaskelma.KorvaustyyppiId == Korvaustyypit.Kertakorvaus)
      {
        korvauslaskelma.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Maksettu;

        KorvauslaskelmaLoki loki = new KorvauslaskelmaLoki();
        loki.Korvauslaskelma = korvauslaskelma;
        loki.StatusId = KorvauslaskelmaStatukset.Maksettu;

        this.Handlers.Korvauslaskelmalokit.AddOrUpdateEntity(loki);

      }    

    }

    public IQueryable<Korvauslaskelma> HaeKorvauslaskelmat(Sopimusrekisteri.BLL_CF.Hakuehdot.KorvauslaskelmaHakuehdot hakuehdot)
    {
      DbQuery<Korvauslaskelma> dbq = this.GetDBQuery(hakuehdot.IncludePaths);

      IQueryable<Korvauslaskelma> kysely = dbq;

      if (hakuehdot.KorvaustyyppiId.HasValue) kysely = kysely.Where(x => x.KorvaustyyppiId == hakuehdot.KorvaustyyppiId.Value);
      if (hakuehdot.StatusId.HasValue) kysely = kysely.Where(x => (int?)x.KorvauslaskelmaStatusId == hakuehdot.StatusId.Value);
      if (hakuehdot.MaksuSuoritusId.HasValue) kysely = kysely.Where(x => (int?)x.MaksunSuoritusId == hakuehdot.MaksuSuoritusId.Value);
      if (hakuehdot.Sopimusnumero.HasValue) kysely = kysely.Where(x => x.SopimusId == hakuehdot.Sopimusnumero.Value);
      if (!string.IsNullOrEmpty(hakuehdot.Viite)) kysely = kysely.Where(x => x.Viite.Contains(hakuehdot.Viite));
      if (!string.IsNullOrEmpty(hakuehdot.Projektinumero)) kysely = kysely.Where(x => x.KorvauksenProjektinumero == hakuehdot.Projektinumero || x.Sopimus.PCSNumero == hakuehdot.Projektinumero);
      if (hakuehdot.EnsimmainenSallittuMaksupaivaAlku.HasValue) kysely = kysely.Where(x => x.EnsimmainenSallittuMaksuPvm >= hakuehdot.EnsimmainenSallittuMaksupaivaAlku.Value);
      if (hakuehdot.EnsimmainenSallittuMaksupaivaLoppu.HasValue) kysely = kysely.Where(x => x.EnsimmainenSallittuMaksuPvm <= hakuehdot.EnsimmainenSallittuMaksupaivaLoppu.Value);
      if (!string.IsNullOrEmpty(hakuehdot.KirjanpidonTili)) kysely = kysely.Where(x => x.KirjanpidonTili.Nimi == hakuehdot.KirjanpidonTili);
      if (!string.IsNullOrEmpty(hakuehdot.KirjanpidonKustannuspaikka)) kysely = kysely.Where(x => x.KirjanpidonKustannuspaikka.Nimi == hakuehdot.KirjanpidonKustannuspaikka);
      if (hakuehdot.InvCostId.HasValue) kysely = kysely.Where(x => x.InvCostId == hakuehdot.InvCostId.Value);
      if (hakuehdot.RegulationId.HasValue) kysely = kysely.Where(x => x.RegulationId == hakuehdot.RegulationId.Value);
      if (hakuehdot.PurposeId.HasValue) kysely = kysely.Where(x => x.PurposeId == hakuehdot.PurposeId.Value);
      if (hakuehdot.Local1Id.HasValue) kysely = kysely.Where(x => x.Local1Id == hakuehdot.Local1Id.Value);
      if (hakuehdot.MaksukuukausiId.HasValue) kysely = kysely.Where(x => x.MaksuKuukausiId == hakuehdot.MaksukuukausiId.Value);

      if (hakuehdot.SopimusHakuehdot != null)
      {
        if (hakuehdot.SopimusHakuehdot.SopimustyyppiId.HasValue) kysely = kysely.Where(x => x.Sopimus.SopimustyyppiId == hakuehdot.SopimusHakuehdot.SopimustyyppiId);
      }

      return kysely;
    }
  }
}
