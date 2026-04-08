using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;
using KT.Utils;
using System.Data;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class PoimintaHandler : EntityHandlerBase<Poiminta>
  {

    public PoimintaHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override Poiminta LoadEntity(object id)
    {
      throw new NotImplementedException();
    }

    public override bool IsNewEntity(Poiminta entity)
    {
      throw new NotImplementedException();
    }

    public void TeePoiminta(IQueryable<IPoimittava> kysely, Poimintatoiminto toiminto)
    {

      switch (toiminto)
      {
        case Poimintatoiminto.UusiPoiminta:
          this.UusiPoiminta(kysely); break;
        case Poimintatoiminto.LisaaPoimintaan:
          this.LisaaPuuttuvatPoimintaan(kysely); break;
        case Poimintatoiminto.PoistaPoiminnasta:
          this.PoistaPoiminnasta(kysely); break;
      }

      this.DataContext.SaveChanges();

    }

    public void UusiPoiminta(IQueryable<IPoimittava> kysely)
    {

      this.TyhjennaPoiminta();

      this.LisaaPoimintaan(kysely);

    }

    public void LisaaPuuttuvatPoimintaan(IQueryable<IPoimittava> kysely)
    {

      IQueryable<IPoimittava> lisattavat = kysely.Except(this.HaeAktiivisetPoiminnat().Select(x => x.Entity));

      this.LisaaPoimintaan(lisattavat);

    }

    public void LisaaPoimintaan(IQueryable<IPoimittava> kysely)
    {

      DateTime pvm = DateTime.Now;

      List<Poiminta> poiminnat = new List<Poiminta>();

      foreach (IPoimittava poimittava in kysely)
      {
        SopimusPoiminta p = new SopimusPoiminta();

        p.EntityId = poimittava.Id;
        p.Tyyppi = poimittava.GetType().BaseType.Name;
        p.Session = this.DataContext.SessioId;
        p.Luotu = pvm;

        poiminnat.Add(p);

      }

      this.LisaaPoimintarivit(poiminnat);

    }

    public IEnumerable<IPoimittava> HaeAktiivinenPoimintajoukko()
    {
      //return this.HaeAktiivisetPoiminnat().Select(x => x.Entity);

      IQueryable<Poiminta> poimitut = this.HaeAktiivisetPoiminnat();

      return this.DataContext.Sopimukset.Join(poimitut, x => x.Id, z => z.EntityId, (x, z) => x).ToList();

    }

    public IQueryable<Poiminta> HaeAktiivisetPoiminnat()
    {
      return this.DataContext.Poiminnat.Where(x => x.Session == this.DataContext.SessioId);
    }

    public void PoistaPoiminnasta(IQueryable<IPoimittava> kysely)
    {

      this.DataContext.Poiminnat.RemoveRange(this.HaeAktiivisetPoiminnat().Where(x => kysely.Contains(x.Entity)));

    }

    public void TyhjennaPoiminta()
    {

      this.DataContext.Database.SqlQuery<object>("DELETE FROM Poiminta WHERE POSession={0}", this.DataContext.SessioId).ToList();

    }

    public void LisaaPoimintarivit(IEnumerable<Poiminta> poiminnat)
    {

      DataTable dt = KT.Utils.Mapping.DataTableMapper.EntitiesToDataTable<Poiminta>(poiminnat);

      DbUtils dbu = new KT.Utils.DbUtils(this.DataContext.ConnectionString);

      dbu.BulkInsert(dt, "Poiminta", "PO");

    }

  }
}
