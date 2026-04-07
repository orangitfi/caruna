using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class MaksuHandler : EntityHandlerBase<Maksu>
  {

    public MaksuHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void AddOrUpdateEntity(Maksu entity)
    {

      DateTime timestamp = DateTime.Now;

      entity.Luoja = this.DataContext.Kayttooikeustiedot.Username;
      entity.Luotu = timestamp;

      foreach (MaksuTiliointi tiliointi in entity.Tilioinnit)
      {
        tiliointi.Luoja = this.DataContext.Kayttooikeustiedot.Username;
        tiliointi.Luotu = timestamp;
      }

      base.AddOrUpdateEntity(entity);

    }
    public override void AddOrUpdateEntityRange(IEnumerable<Maksu> entities)
    {

      DateTime timestamp = DateTime.Now;

      this.Handlers.Korvauslaskelmat.BulkOperationMode = true;

      foreach (Maksu entity in entities)
      {

        entity.Luoja = this.DataContext.Kayttooikeustiedot.Username;
        entity.Luotu = timestamp;

        foreach (MaksuTiliointi tiliointi in entity.Tilioinnit)
        {
          tiliointi.Luoja = this.DataContext.Kayttooikeustiedot.Username;
          tiliointi.Luotu = timestamp;
        }

        this.Handlers.Korvauslaskelmat.PaivitaKorvauslaskelmaMaksetuksi(entity.Korvauslaskelma, entity);

      }

      base.AddOrUpdateEntityRange(entities);
    }

    public override Maksu LoadEntity(object id)
    {
      return this.DataContext.Maksut.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(Maksu entity)
    {
      return entity.Id == 0;
    }

    public IEnumerable<Maksu> LuoMaksut(IEnumerable<Korvauslaskelma> korvauslaskelmat, DateTime maksupvm, MaksuaineistoOletustiedot oletukset)
    {

      OhjaustietoHandler ohjaustietoHandler = new OhjaustietoHandler(this.DataContext);
      IEnumerable<Indeksi> lstIndeksit = ohjaustietoHandler.HaeVuodenIndeksit(DateTime.Now.Year);

      List<Maksu> maksut = new List<Maksu>();
      Maksu maksu;
      Alv oletusAlv = this.DataContext.Alvt.Where(x => x.Oletus.HasValue && x.Oletus.Value == true).FirstOrDefault();

      foreach (Korvauslaskelma korvauslaskelma in korvauslaskelmat)
      {

        maksu = new Maksu();

        maksu.KorvauslaskelmaId = korvauslaskelma.Id;
        maksu.Korvauslaskelma = korvauslaskelma;

        if (korvauslaskelma.MaksetaanAlv && oletusAlv != null)
          maksu.Alv = oletusAlv.Prosentti;

        maksu.Maksupaiva = maksupvm;

        maksu.Viite = korvauslaskelma.Viite;
        maksu.Viesti = korvauslaskelma.Viesti;

        maksu.SopimusId = korvauslaskelma.SopimusId;
        maksu.Vuosi = DateTime.Now.Year;

        maksu.SaajaId = korvauslaskelma.SaajaId;
        maksu.Saaja = korvauslaskelma.Saaja;

        this.PaivitaSaajanTiedotMaksulle(maksu);

        if (korvauslaskelma.Sopimus != null)
        {
          maksu.JuridinenYhtioId = korvauslaskelma.Sopimus.JuridinenYhtioId;
          maksu.JuridinenYhtio = korvauslaskelma.Sopimus.JuridinenYhtio;

          this.PaivitaMaksajanTiedotMaksulle(maksu);

        }

        maksu.IndeksityyppiId = korvauslaskelma.IndeksityyppiId;
        maksu.Indeksityyppi = korvauslaskelma.Indeksityyppi;
        maksu.IndeksiKuukausiId = korvauslaskelma.IndeksiKuukausiId;
        maksu.IndeksiKuukausi = korvauslaskelma.IndeksiKuukausi;
        maksu.OnIndeksi = korvauslaskelma.OnIndeksi;

        if (maksu.OnIndeksi)
        {
          if (korvauslaskelma.ViimeisinMaksuPvm.HasValue)
          {

            if (korvauslaskelma.IndeksityyppiId.HasValue && korvauslaskelma.IndeksiKuukausiId.HasValue)
            {

              if (lstIndeksit.Any(x => x.KuukausiId == korvauslaskelma.IndeksiKuukausiId.Value && x.IndeksityyppiId == korvauslaskelma.IndeksityyppiId.Value))
              {
                maksu.Indeksi = lstIndeksit.First(x => x.KuukausiId == korvauslaskelma.IndeksiKuukausiId.Value && x.IndeksityyppiId == korvauslaskelma.IndeksityyppiId.Value).Arvo;
              }

            }

          }
          else
          {
            maksu.Indeksi = korvauslaskelma.SopimushetkenIndeksiArvo;
          }

          if (maksu.Indeksi.HasValue)
          {

            maksu.IndeksiVuosi = DateTime.Now.Year;

            if (maksu.Indeksi < korvauslaskelma.ViimeisinMaksuIndeksi)
              maksu.MaksuIndeksi = korvauslaskelma.ViimeisinMaksuIndeksi;
            else
              maksu.MaksuIndeksi = maksu.Indeksi;
            
          }


        }

        maksu.Tilioinnit = (from KorvauslaskelmaRivi r in korvauslaskelma.Rivit
                            group r by new { r.KirjanpidonTili, r.KirjanpidonKustannuspaikka, r.InvCost, r.Regulation, r.Purpose, r.Local1 } into tilioidytRivit
                            select new MaksuTiliointi()
                            {
                              Kirjanpidontili = tilioidytRivit.Key.KirjanpidonTili != null ? tilioidytRivit.Key.KirjanpidonTili.Nimi : string.Empty,
                              Kustannuspaikka = tilioidytRivit.Key.KirjanpidonKustannuspaikka != null ? tilioidytRivit.Key.KirjanpidonKustannuspaikka.Nimi : string.Empty,
                              InvCost = tilioidytRivit.Key.InvCost != null ? tilioidytRivit.Key.InvCost.Nimi : string.Empty,
                              Regulation = tilioidytRivit.Key.Regulation != null ? tilioidytRivit.Key.Regulation.Nimi : string.Empty,
                              Local1 = tilioidytRivit.Key.Local1 != null ? tilioidytRivit.Key.Local1.Nimi : string.Empty,
                              Summa = tilioidytRivit.Sum(x => x.Korvaus.GetValueOrDefault(0))
                            }).ToList();


        foreach (MaksuTiliointi tiliointi in maksu.Tilioinnit)
        {
          if (!string.IsNullOrEmpty(korvauslaskelma.KorvauksenProjektinumero))
            tiliointi.Projektinro = korvauslaskelma.KorvauksenProjektinumero;
          else if (korvauslaskelma.Sopimus != null)
            tiliointi.Projektinro = korvauslaskelma.Sopimus.PCSNumero;

          if (maksu.JuridinenYhtio != null)
            tiliointi.Projektinro = maksu.JuridinenYhtio.KirjanpidonProjektitunniste + tiliointi.Projektinro;

          if (korvauslaskelma.KorvaustyyppiId == Korvaustyypit.Kuukausivuokra || korvauslaskelma.KorvaustyyppiId == Korvaustyypit.Vuosimaksu)
            tiliointi.Category = oletukset.VuokraCategory;
          else
            tiliointi.Category = korvauslaskelma.Category;
        }

        if (maksu.OnIndeksi && maksu.MaksuIndeksi.HasValue && korvauslaskelma.SopimushetkenIndeksiArvo.HasValue)
        {
          foreach (MaksuTiliointi tiliointi in maksu.Tilioinnit)
          {

            tiliointi.Summa = Math.Round((decimal)(tiliointi.Summa * maksu.MaksuIndeksi / korvauslaskelma.SopimushetkenIndeksiArvo), 2);

          }
        }

        foreach (MaksuTiliointi tiliointi in maksu.Tilioinnit)
        {

          tiliointi.SummaIlmanAlv = tiliointi.Summa;

          if (maksu.Alv.HasValue)
          {

            tiliointi.AlvOsuus = Math.Round((decimal)(tiliointi.Summa * (maksu.Alv / 100)), 2);
            tiliointi.Summa = tiliointi.Summa + tiliointi.AlvOsuus;

          }

        }

        maksu.SummaIlmanAlv = maksu.Tilioinnit.Sum(x => x.SummaIlmanAlv);
        maksu.Summa = maksu.Tilioinnit.Sum(x => x.Summa);
        maksu.AlvOsuus = maksu.Tilioinnit.Sum(x => x.AlvOsuus.GetValueOrDefault(0));
        maksut.Add(maksu);
      }

      return maksut;

    }


    public void PaivitaSaajanTiedotMaksulle(Maksu maksu)
    {

      if (maksu.Saaja != null)
      {
        maksu.Tilinumero = maksu.Saaja.Tilinumero;
        maksu.Bic = maksu.Saaja.Bic;
        maksu.SaajaNimi = maksu.Saaja.Nimi;
      }

    }

    public void PaivitaMaksajanTiedotMaksulle(Maksu maksu)
    {

      if (maksu.JuridinenYhtio != null)
      {
        maksu.MaksajanNimi = maksu.JuridinenYhtio.Nimi;
        maksu.MaksajanTilinro = maksu.JuridinenYhtio.Tilinumero;
        maksu.MaksajanBicKoodi = maksu.JuridinenYhtio.Bic;
        maksu.KirjanpidonTunniste = maksu.JuridinenYhtio.KirjanpidonYritystunniste;
        maksu.Palvelutunnus = maksu.JuridinenYhtio.Ytunnus;
      }

    }

    public bool ValidoiMaksu(Maksu maksu)
    {

      if (string.IsNullOrEmpty(maksu.Tilinumero))
        return false;

      foreach (MaksuTiliointi tiliointi in maksu.Tilioinnit)
      {

        if (string.IsNullOrEmpty(tiliointi.Kirjanpidontili))
          return false;

        if (string.IsNullOrEmpty(tiliointi.Kustannuspaikka))
          return false;

        if (string.IsNullOrEmpty(tiliointi.Projektinro))
          return false;

      }

      return true;

    }

  }
}
