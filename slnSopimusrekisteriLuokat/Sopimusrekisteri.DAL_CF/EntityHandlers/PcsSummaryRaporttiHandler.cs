using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;
using System.Transactions;
using System.Data.Entity.Infrastructure;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class PcsSummaryRaporttiHandler : EntityHandlerBase<PcsSummaryRaportti>
  {

    public PcsSummaryRaporttiHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override PcsSummaryRaportti LoadEntity(object id)
    {

      return this.GetAll().Single(x => x.Id == (int)id);

    }

    public override bool IsNewEntity(PcsSummaryRaportti entity)
    {
      return entity.Id == 0;
    }

    protected override IQueryable<PcsSummaryRaportti> OrderEntities(IQueryable<PcsSummaryRaportti> entities)
    {
      return entities.OrderBy(a => a.Id);
    }

    public override IQueryable<PcsSummaryRaportti> GetAll()
    {
      return this.OrderEntities(base.GetAll());
    }

    public int SaveReport(IEnumerable<PcsSummaryRaportti> entities)
    {

      using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
      {

        string batch = Guid.NewGuid().ToString();

        ((IObjectContextAdapter)this.DataContext).ObjectContext.CommandTimeout = 180;

        List<Korvauslaskelma> paivitettavat;

        foreach (PcsSummaryRaportti entity in entities)
        {

          entity.Era = batch;

        }

        this.SaveEntityRange(entities);
       
        paivitettavat = this.PaivitaKorvauslaskelmat(this.GetAll().Where(x => x.Era == batch)).ToList();

        paivitettavat.AddRange(this.PaivitaSopimustenKorvauslaskelmat(this.GetAll().Where(x => x.Era == batch)));

        this.Handlers.Korvauslaskelmat.BulkOperationMode = true;

        this.Handlers.Korvauslaskelmat.SaveEntityRange(paivitettavat);

        scope.Complete();

        return paivitettavat.Count();

      }

    }

    public override void AddOrUpdateEntity(PcsSummaryRaportti entity)
    {
      entity.Luoja = this.DataContext.Kayttooikeustiedot.Username;
      entity.Luotu = DateTime.Now;

      base.AddOrUpdateEntity(entity);
    }


    public IEnumerable<Korvauslaskelma> PaivitaKorvauslaskelmat(IQueryable<PcsSummaryRaportti> raportit)
    {

      IQueryable<Korvauslaskelma> korvauslaskelmat = this.Handlers.Korvauslaskelmat.GetAll();

      var liitokset = raportit.Join(korvauslaskelmat, x => x.ProjectNo, z => z.KorvauksenProjektinumero, (x, z) =>
                      new { Raportti = x, Korvauslaskelma = z });

      foreach (var liitos in liitokset)
      {

        this.PaivitaKorvauslaskelma(liitos.Raportti, liitos.Korvauslaskelma);

      }

      return liitokset.Select(x => x.Korvauslaskelma).ToList();

    }

    public IEnumerable<Korvauslaskelma> PaivitaSopimustenKorvauslaskelmat(IQueryable<PcsSummaryRaportti> raportit)
    {

      IQueryable<Sopimus> sopimukset = this.Handlers.Sopimukset.GetAll();

      var liitokset = raportit.Join(sopimukset, x => x.ProjectNo, z => z.PCSNumero, (x, z) =>
                      new { Raportti = x, Korvauslaskelmat = z.Korvauslaskelmat });

      List<Korvauslaskelma> korvauslaskelmat = new List<Korvauslaskelma>();

      foreach (var liitos in liitokset)
      {

        foreach (Korvauslaskelma korvauslaskelma in liitos.Korvauslaskelmat)
        {

          if (string.IsNullOrEmpty(korvauslaskelma.KorvauksenProjektinumero))
          {
            this.PaivitaKorvauslaskelma(liitos.Raportti, korvauslaskelma);

            korvauslaskelmat.Add(korvauslaskelma);
          }

        }

      }

      return korvauslaskelmat;

    }

    public void PaivitaKorvauslaskelma(PcsSummaryRaportti raportti, Korvauslaskelma korvauslaskelma)
    {

      korvauslaskelma.EnsimmainenSallittuMaksuPvm = raportti.FieldWorkStartedA;
      korvauslaskelma.Projectno = raportti.ProjectNo;
      korvauslaskelma.Name = raportti.Name;
      korvauslaskelma.TypeOfProject = raportti.TypeOfProject;
      korvauslaskelma.Type = raportti.Type;
      korvauslaskelma.Owner = raportti.Owner;
      korvauslaskelma.Concession = raportti.Concession;
      korvauslaskelma.CertDate = raportti.CertDate;
      korvauslaskelma.FieldWorkStarted = raportti.FieldWorkStartedA;
      korvauslaskelma.ProjectClosedA = raportti.ProjectClosedA;
      korvauslaskelma.Category = raportti.Category;

    }

  }
}
