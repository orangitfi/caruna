namespace Sopimusrekisteri.BLL_CF
{

    public enum Asiakastyypit : int
    {
        AlkuperainenOsapuoli = 1,
        NykyinenOsapuoli = 2,
        Haltija = 3,
        Vuokralainen = 4,
        Omistaja = 5
    }

    public enum Kielet : int
    {
        Suomi = 1,
        Ruotsi = 2,
        Englanti = 3
    }

    public enum KorvauslaskelmaStatukset : int
    {
        Hyvaksymatta = 1,
        Hyvaksytty = 2,
        KieltaytynytKorvauksesta = 3,
        Maksettu = 4,
        Numerotta = 5,
        ProjektiPeruttu = 6
    }

    public enum Korvaustyypit : int
    {
        Kertakorvaus = 1,
        Vuosimaksu = 2,
        EiKorvausta = 3,
        Kuukausivuokra = 4
    }

    public enum MaksunSuoritukset : int
    {
        AsiakkaanLahettamaLaskuBwIP = 1,
        VerkonhaltijaSuorittaaKorvauksen = 2,
        AsiakkaanLahettamaLaskuTosite = 3
    }

    public enum Ohjaustiedot
    {
        Asiakastyyppi,
        Lupataho
    }

    public enum Organisaatiotyypit
    {
        Yritys = 1,
        JuridinenYhtio = 2,
        Vastuuyksikko = 3,
        Yhtio = 8
    }

    public enum Poimintatoiminto
    {
        UusiPoiminta = 1,
        LisaaPoimintaan = 2,
        PoistaPoiminnasta = 3,
        TarkennaPoimintaa = 4
    }

    public enum PoimintaOperaattori
    {
        YhtaSuuri,
        EriSuuri,
        SuurempiTaiYhtaSuuri,
        PienempiTaiYhtaSuuri,
        Tyhja,
        EiTyhja,
        Valilla
    }

    public enum SopimusTilat : int
    {
        Paattynyt = 2,
        Voimassa = 3,
        Luonnos = 4,
        EiTiedossa = 5,
        Poistettu = 8
    }

    public enum Sopimustyypit : int
    {
        SopimustaEiLoydy = 1,
        Vuokrasopimus = 3,
        Sijoituslupa = 5,
        Rakennuslupa = 6,
        Toimenpidelupa = 7,
        Johtoaluesopimus = 8,
        Suostumus = 9,
        Muuntamosopimus = 10,
        Kiinteistomuuntamosopimus = 11,
        PylvaidenJaMaadYhteiskayttosopimus = 12,
        MuistioSuullisestaSopimuksesta = 13,
        Maankayttosopimus = 14,
        Risteilylupa = 19,
        JohtoaluesopimusMaakaapeli = 20,
        CCAPylvaidenLuovutuskirja = 21,
        Sopimuspohja = 23,
        Yksityistiesopimus = 24,
        SijoituslupaMRL161 = 25,
        KiinteistonKauppakirja = 26,
        YhteistoimintasopimusKunta = 27,
        YhteiskayttoPuitesopimus = 28,
        Naapurisuostumus = 29,
        SuurjanniteverkkoVuokrasopimus = 30
    }

    public enum TahoTyypit : int
    {
        Henkilo = 1,
        Organisaatio = 2
    }

    public enum TunnisteyksikkoTyypit : int
    {
        LinjaOsa = 6,
        Muuntamo = 8
    }

    public enum KayttooikeusTaso
    {
        Suppea,
        Laaja
    }

    // https://www.m-files.com/user-guide/latest/eng/Create_or_get_shortcut.html
    public enum MFilesAction
    {
        /// <summary>
        /// Displays the object in M-Files Desktop.
        /// </summary>
        Show,

        /// <summary>
        /// Shows the metadata card for the object.
        /// </summary>
        ShowMetadata,

        /// <summary>
        /// Shows the check-out dialog and opens the document in the default application.
        /// </summary>
        Open,

        /// <summary>
        /// Opens the document in the default application in read-only mode without prompting the user to check it out.
        /// </summary>
        View,

        /// <summary>
        /// Checks out the object and opens it for editing in the default application.
        /// </summary>
        Edit
    }

    public enum TiedostonSijainti
    {
        Sharepoint,
        MFiles
    }

}
