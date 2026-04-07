using System;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class HandlerContext
    {

        #region Muuttujat

        private Lazy<AlvHandler> alvt;
        private Lazy<OhjaustietoHandler<Asiakastyyppi>> asiakastyypit;
        private Lazy<BicKoodiHandler> bicKoodit;
        private Lazy<OhjaustietoHandler<DFRooli>> dfRoolit;
        private Lazy<OhjaustietoHandler<Indeksityyppi>> indeksityypit;
        private Lazy<OhjaustietoHandler<InvCost>> invCostit;
        private Lazy<OhjaustietoHandler<Julkisuusaste>> julkisuusasteet;
        private Lazy<KieliHandler> kielet;
        private Lazy<OhjaustietoHandler<Kirjanpidontili>> kirjanpidontilit;
        private Lazy<OhjaustietoHandler<Kohdekategoria>> kohdekategoriat;
        private Lazy<KorvauslaskelmaLokiHandler> korvauslaskelmalokit;
        private Lazy<KorvauslaskelmaRiviHandler> korvauslaskelmarivit;
        private Lazy<KorvauslaskelmaStatusHandler> korvauslaskelmaStatukset;
        private Lazy<KorvauslaskelmaHandler> korvauslaskelmat;
        private Lazy<KorvaustyyppiHandler> korvaustyypit;
        private Lazy<KuntaHandler> kunnat;
        private Lazy<OhjaustietoHandler<KirjanpidonKustannuspaikka>> kustannuspaikat;
        private Lazy<KuukausiHandler> kuukaudet;
        private Lazy<OhjaustietoHandler<Local1>> locat1t;
        private Lazy<OhjaustietoHandler<Lupataho>> lupatahot;
        private Lazy<MaaHandler> maat;
        private Lazy<OhjaustietoHandler<Maksuehdot>> maksuehdot;
        private Lazy<MaksunSuoritusHandler> maksunSuoritukset;
        private Lazy<MaksuHandler> maksut;
        private Lazy<OrganisaationTyyppiHandler> organisaationTyypit;
        private Lazy<PcsSummaryRaporttiHandler> pcsSummaryRaportit;
        private Lazy<PostitiedotHandler> postitiedot;
        private Lazy<OhjaustietoHandler<Purpose>> purposet;
        private Lazy<OhjaustietoHandler<PuustonOmistajuus>> puustonOmistajuudet;
        private Lazy<OhjaustietoHandler<PuustonPoisto>> puustonPoistot;
        private Lazy<OhjaustietoHandler<Regulation>> regulationit;
        private Lazy<OhjaustietoHandler<SiirtoOikeus>> siirtoOikeudet;
        private Lazy<OhjaustietoHandler<SopimuksenAlaluokka>> sopimuksenAlaluokat;
        private Lazy<OhjaustietoHandler<SopimuksenEhtoversio>> sopimuksenEhtoversiot;
        private Lazy<SopimuksenTilaHandler> sopimuksenTilat;
        private Lazy<SopimusHandler> sopimukset;
        private Lazy<SopimusarkistoHandler> sopimusarkistot;
        private Lazy<SopimusKiinteistoHandler> sopimusKiinteistot;
        private Lazy<SopimusTahoHandler> sopimusTahot;
        private Lazy<SopimusTulosteHandler> sopimustulosteet;
        private Lazy<SopimustyyppiHandler> sopimustyypit;
        private Lazy<TahoHandler> tahot;
        private Lazy<TiedostoHandler> tiedostot;
        private Lazy<OhjaustietoHandler<YlasopimuksenTyyppi>> ylasopimuksenTyypit;
        private Lazy<KorkoprosenttiHandler> korkoprosentit;
        private Lazy<VuokratyyppiHandler> vuokratyypit;
        private Lazy<IFRSHistoriaExcelHandler> ifrsHistoriaExcel;
        private Lazy<IFRSHistoriaHandler> ifrsHistoria;

        #endregion

        #region Konstruktori

        public HandlerContext(KiltaDataContext dataContext)
        {
            this.alvt = new Lazy<AlvHandler>(() => new AlvHandler(dataContext));
            this.asiakastyypit = new Lazy<OhjaustietoHandler<Asiakastyyppi>>(() => new OhjaustietoHandler<Asiakastyyppi>(dataContext));
            this.bicKoodit = new Lazy<BicKoodiHandler>(() => new BicKoodiHandler(dataContext));
            this.dfRoolit = new Lazy<OhjaustietoHandler<DFRooli>>(() => new OhjaustietoHandler<DFRooli>(dataContext));
            this.indeksityypit = new Lazy<OhjaustietoHandler<Indeksityyppi>>(() => new OhjaustietoHandler<Indeksityyppi>(dataContext));
            this.invCostit = new Lazy<OhjaustietoHandler<InvCost>>(() => new OhjaustietoHandler<InvCost>(dataContext));
            this.julkisuusasteet = new Lazy<OhjaustietoHandler<Julkisuusaste>>(() => new OhjaustietoHandler<Julkisuusaste>(dataContext));
            this.kielet = new Lazy<KieliHandler>(() => new KieliHandler(dataContext));
            this.kirjanpidontilit = new Lazy<OhjaustietoHandler<Kirjanpidontili>>(() => new OhjaustietoHandler<Kirjanpidontili>(dataContext));
            this.kohdekategoriat = new Lazy<OhjaustietoHandler<Kohdekategoria>>(() => new OhjaustietoHandler<Kohdekategoria>(dataContext));
            this.korvauslaskelmalokit = new Lazy<KorvauslaskelmaLokiHandler>(() => new KorvauslaskelmaLokiHandler(dataContext));
            this.korvauslaskelmarivit = new Lazy<KorvauslaskelmaRiviHandler>(() => new KorvauslaskelmaRiviHandler(dataContext));
            this.korvauslaskelmaStatukset = new Lazy<KorvauslaskelmaStatusHandler>(() => new KorvauslaskelmaStatusHandler(dataContext));
            this.korvauslaskelmat = new Lazy<KorvauslaskelmaHandler>(() => new KorvauslaskelmaHandler(dataContext));
            this.korvaustyypit = new Lazy<KorvaustyyppiHandler>(() => new KorvaustyyppiHandler(dataContext));
            this.kunnat = new Lazy<KuntaHandler>(() => new KuntaHandler(dataContext));
            this.kustannuspaikat = new Lazy<OhjaustietoHandler<KirjanpidonKustannuspaikka>>(() => new OhjaustietoHandler<KirjanpidonKustannuspaikka>(dataContext));
            this.kuukaudet = new Lazy<KuukausiHandler>(() => new KuukausiHandler(dataContext));
            this.locat1t = new Lazy<OhjaustietoHandler<Local1>>(() => new OhjaustietoHandler<Local1>(dataContext));
            this.lupatahot = new Lazy<OhjaustietoHandler<Lupataho>>(() => new OhjaustietoHandler<Lupataho>(dataContext));
            this.maat = new Lazy<MaaHandler>(() => new MaaHandler(dataContext));
            this.maksuehdot = new Lazy<OhjaustietoHandler<Maksuehdot>>(() => new OhjaustietoHandler<Maksuehdot>(dataContext));
            this.maksunSuoritukset = new Lazy<MaksunSuoritusHandler>(() => new MaksunSuoritusHandler(dataContext));
            this.maksut = new Lazy<MaksuHandler>(() => new MaksuHandler(dataContext));
            this.organisaationTyypit = new Lazy<OrganisaationTyyppiHandler>(() => new OrganisaationTyyppiHandler(dataContext));
            this.postitiedot = new Lazy<PostitiedotHandler>(() => new PostitiedotHandler(dataContext));
            this.pcsSummaryRaportit = new Lazy<PcsSummaryRaporttiHandler>(() => new PcsSummaryRaporttiHandler(dataContext));
            this.purposet = new Lazy<OhjaustietoHandler<Purpose>>(() => new OhjaustietoHandler<Purpose>(dataContext));
            this.puustonOmistajuudet = new Lazy<OhjaustietoHandler<PuustonOmistajuus>>(() => new OhjaustietoHandler<PuustonOmistajuus>(dataContext));
            this.puustonPoistot = new Lazy<OhjaustietoHandler<PuustonPoisto>>(() => new OhjaustietoHandler<PuustonPoisto>(dataContext));
            this.regulationit = new Lazy<OhjaustietoHandler<Regulation>>(() => new OhjaustietoHandler<Regulation>(dataContext));
            this.siirtoOikeudet = new Lazy<OhjaustietoHandler<SiirtoOikeus>>(() => new OhjaustietoHandler<SiirtoOikeus>(dataContext));
            this.sopimuksenAlaluokat = new Lazy<OhjaustietoHandler<SopimuksenAlaluokka>>(() => new OhjaustietoHandler<SopimuksenAlaluokka>(dataContext));
            this.sopimuksenEhtoversiot = new Lazy<OhjaustietoHandler<SopimuksenEhtoversio>>(() => new OhjaustietoHandler<SopimuksenEhtoversio>(dataContext));
            this.sopimuksenTilat = new Lazy<SopimuksenTilaHandler>(() => new SopimuksenTilaHandler(dataContext));
            this.sopimukset = new Lazy<SopimusHandler>(() => new SopimusHandler(dataContext));
            this.sopimusarkistot = new Lazy<SopimusarkistoHandler>(() => new SopimusarkistoHandler(dataContext));
            this.sopimusKiinteistot = new Lazy<SopimusKiinteistoHandler>(() => new SopimusKiinteistoHandler(dataContext));
            this.sopimusTahot = new Lazy<SopimusTahoHandler>(() => new SopimusTahoHandler(dataContext));
            this.sopimustulosteet = new Lazy<SopimusTulosteHandler>(() => new SopimusTulosteHandler(dataContext));
            this.sopimustyypit = new Lazy<SopimustyyppiHandler>(() => new SopimustyyppiHandler(dataContext));
            this.tahot = new Lazy<TahoHandler>(() => new TahoHandler(dataContext));
            this.tiedostot = new Lazy<TiedostoHandler>(() => new TiedostoHandler(dataContext));
            this.ylasopimuksenTyypit = new Lazy<OhjaustietoHandler<YlasopimuksenTyyppi>>(() => new OhjaustietoHandler<YlasopimuksenTyyppi>(dataContext));
            this.korkoprosentit = new Lazy<KorkoprosenttiHandler>(() => new KorkoprosenttiHandler(dataContext));
            this.vuokratyypit = new Lazy<VuokratyyppiHandler>(() => new VuokratyyppiHandler(dataContext));
            this.ifrsHistoria = new Lazy<IFRSHistoriaHandler>(() => new IFRSHistoriaHandler(dataContext));
            this.ifrsHistoriaExcel = new Lazy<IFRSHistoriaExcelHandler>(() => new IFRSHistoriaExcelHandler(dataContext));
        }

        #endregion

        #region Propertyt

        public VuokratyyppiHandler Vuokratyypit
        {
            get
            {
                return this.vuokratyypit.Value;
            }
        }

        public KorkoprosenttiHandler Korkoprosentit
        {
            get
            {
                return this.korkoprosentit.Value;
            }
        }

        public AlvHandler Alvt
        {
            get
            {
                return this.alvt.Value;
            }
        }
        public OhjaustietoHandler<Asiakastyyppi> Asiakastyypit
        {
            get
            {
                return this.asiakastyypit.Value;
            }
        }
        public BicKoodiHandler BicKoodit
        {
            get
            {
                return this.bicKoodit.Value;
            }
        }
        public OhjaustietoHandler<DFRooli> DFRoolit
        {
            get
            {
                return this.dfRoolit.Value;
            }
        }
        public OhjaustietoHandler<Indeksityyppi> Indeksityypit
        {
            get
            {
                return this.indeksityypit.Value;
            }
        }
        public OhjaustietoHandler<InvCost> InvCostit
        {
            get
            {
                return this.invCostit.Value;
            }
        }
        public OhjaustietoHandler<Julkisuusaste> Julkisuusasteet
        {
            get
            {
                return this.julkisuusasteet.Value;
            }
        }
        public KieliHandler Kielet
        {
            get
            {
                return this.kielet.Value;
            }
        }
        public OhjaustietoHandler<Kirjanpidontili> Kirjanpidontilit
        {
            get
            {
                return this.kirjanpidontilit.Value;
            }
        }
        public OhjaustietoHandler<Kohdekategoria> Kohdekategoriat
        {
            get
            {
                return this.kohdekategoriat.Value;
            }
        }
        public KorvauslaskelmaLokiHandler Korvauslaskelmalokit
        {
            get
            {
                return this.korvauslaskelmalokit.Value;
            }
        }
        public KorvauslaskelmaRiviHandler Korvauslaskelmarivit
        {
            get
            {
                return this.korvauslaskelmarivit.Value;
            }
        }
        public KorvauslaskelmaStatusHandler KorvauslaskelmaStatukset
        {
            get
            {
                return this.korvauslaskelmaStatukset.Value;
            }
        }
        public KorvauslaskelmaHandler Korvauslaskelmat
        {
            get
            {
                return this.korvauslaskelmat.Value;
            }
        }
        public KorvaustyyppiHandler Korvaustyypit
        {
            get
            {
                return this.korvaustyypit.Value;
            }
        }
        public KuntaHandler Kunnat
        {
            get
            {
                return this.kunnat.Value;
            }
        }

        public OhjaustietoHandler<KirjanpidonKustannuspaikka> Kustannuspaikat
        {
            get
            {
                return this.kustannuspaikat.Value;
            }
        }
        public KuukausiHandler Kuukaudet
        {
            get
            {
                return this.kuukaudet.Value;
            }
        }
        public OhjaustietoHandler<Local1> Local1t
        {
            get
            {
                return this.locat1t.Value;
            }
        }

        public OhjaustietoHandler<Lupataho> Lupatahot
        {
            get
            {
                return this.lupatahot.Value;
            }
        }

        public MaaHandler Maat
        {
            get
            {
                return this.maat.Value;
            }
        }

        public OhjaustietoHandler<Maksuehdot> Maksuehdot
        {
            get
            {
                return this.maksuehdot.Value;
            }
        }
        public MaksunSuoritusHandler MaksunSuoritukset
        {
            get
            {
                return this.maksunSuoritukset.Value;
            }
        }
        public MaksuHandler Maksut
        {
            get
            {
                return this.maksut.Value;
            }
        }
        public OrganisaationTyyppiHandler OrganisaationTyypit
        {
            get
            {
                return this.organisaationTyypit.Value;
            }
        }
        public PcsSummaryRaporttiHandler PcsSummaryRaportit
        {
            get
            {
                return this.pcsSummaryRaportit.Value;
            }
        }
        public PostitiedotHandler Postitiedot
        {
            get
            {
                return this.postitiedot.Value;
            }
        }
        public OhjaustietoHandler<Purpose> Purposet
        {
            get
            {
                return this.purposet.Value;
            }
        }
        public OhjaustietoHandler<PuustonOmistajuus> PuustonOmistajuudet
        {
            get
            {
                return this.puustonOmistajuudet.Value;
            }
        }
        public OhjaustietoHandler<PuustonPoisto> PuustonPoistot
        {
            get
            {
                return this.puustonPoistot.Value;
            }
        }
        public OhjaustietoHandler<Regulation> Regulationit
        {
            get
            {
                return this.regulationit.Value;
            }
        }
        public OhjaustietoHandler<SiirtoOikeus> SiirtoOikeudet
        {
            get
            {
                return this.siirtoOikeudet.Value;
            }
        }
        public OhjaustietoHandler<SopimuksenAlaluokka> SopimuksenAlaluokat
        {
            get
            {
                return this.sopimuksenAlaluokat.Value;
            }
        }
        public OhjaustietoHandler<SopimuksenEhtoversio> SopimuksenEhtoversiot
        {
            get
            {
                return this.sopimuksenEhtoversiot.Value;
            }
        }

        public SopimuksenTilaHandler SopimuksenTilat
        {
            get
            {
                return this.sopimuksenTilat.Value;
            }
        }

        public SopimusHandler Sopimukset
        {
            get
            {
                return this.sopimukset.Value;
            }
        }

        public SopimusarkistoHandler Sopimusarkistot
        {
            get
            {
                return this.sopimusarkistot.Value;
            }
        }

        public SopimusKiinteistoHandler SopimusKiinteistot
        {
            get
            {
                return this.sopimusKiinteistot.Value;
            }
        }

        public SopimusTahoHandler SopimusTahot
        {
            get
            {
                return this.sopimusTahot.Value;
            }
        }

        public SopimusTulosteHandler Sopimustulosteet
        {
            get
            {
                return this.sopimustulosteet.Value;
            }
        }

        public SopimustyyppiHandler Sopimustyypit
        {
            get
            {
                return this.sopimustyypit.Value;
            }
        }

        public TahoHandler Tahot
        {
            get
            {
                return this.tahot.Value;
            }
        }

        public TiedostoHandler Tiedostot
        {
            get
            {
                return this.tiedostot.Value;
            }
        }
        public OhjaustietoHandler<YlasopimuksenTyyppi> YlasopimuksenTyypit
        {
            get
            {
                return this.ylasopimuksenTyypit.Value;
            }
        }

        public IFRSHistoriaExcelHandler IFRSHistoriaExcel
        {
            get
            {
                return this.ifrsHistoriaExcel.Value;
            }
        }

        public IFRSHistoriaHandler IFRSHistoria
        {
            get
            {
                return this.ifrsHistoria.Value;
            }
        }

        #endregion

    }
}
