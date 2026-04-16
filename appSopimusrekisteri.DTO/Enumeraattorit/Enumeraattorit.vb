Public Class Enumeraattorit

    Enum SopimuksenTila
        Paattynyt = 2
        Voimassa = 3
        Luonnos = 4
        EiTiedossa = 5
        Poistettu = 8
    End Enum

    Enum AktiviteetinStatus
        Avoin = 1
        Valmis = 2
    End Enum

    Enum TahoTyyppi
        Henkilo = 1
        Organisaatio = 2
    End Enum

    Enum Hakutyyppi
        Taho = 1
        Kiinteisto = 2
        Sopimus = 3
    End Enum

    Enum YlatasonSopimukset
        Raamisopimus = 1
        Lunastuslupa = 2
    End Enum

    Enum Sopimustyyppi
        Vuokrasopimus = 3
        Sijoituslupa = 5
        Rakennuslupa = 6
        Toimenpidelupa = 7
        Johtoaluesopimus = 8
        Suostumus = 9
        Muuntamosopimus = 10
        KiinteistoMuuntamoSopimus = 11
        MuistioSuullisestaSopimuksesta = 13
        MaankayttoSopimus = 14
        Risteilylupa = 19
        Sopimuspohja = 23
        Yksityistiesopimus = 24
        SijoituslupaMRL161 = 25
        KiinteistonKauppakirja = 26
        YhteistoimintasopimusKunta = 27
        YhteiskayttoPuitesopimus = 28
        Naapurisuostumus = 29
        SuurjanniteverkkoVuokrasopimus = 30
    End Enum

    Enum KorvausyksikonTyyppi
        Prosentti = 1
        Maara = 2
        PintaAla = 3
        Erityiskorvaus = 4
    End Enum

    Enum MaaraAlaTarkenne
        Erottamaton = 1
    End Enum

    Enum Asiakastyyppi
        AlkuperainenOsapuoli = 1
        NykyinenOsapuoli = 2
        Haltija = 3
        Vuokralainen = 4
        Omistaja = 5
    End Enum

    Enum KorvauslaskelmaStatus
        Hyvaksymatta = 1
        Hyvaksytty = 2
        KieltaytynytKorvauksesta = 3
        Maksettu = 4
        Numerotta = 5
        ProjektiPeruttu = 6
    End Enum

    Enum Korvaustyyppi
        Kertakorvaus = 1
        Vuosimaksu = 2
        EiKorvausta = 3
        Kuukausivuokra = 4
    End Enum

    Enum MaksuStatus
        Maksetaan = 1
        Maksettu = 2
    End Enum

    Enum MaksunSuoritus
        AsiakkaanLahettamaLaskuBwIP = 1
        VerkonhaltijaSuorittaaKorvauksen = 2
        AsiakkaanLahettamaLaskuTosite = 3
    End Enum

    Enum TunnisteYksikkoTyyppi
        LinjaOsa = 6
        Muuntamo = 8
    End Enum

    Enum Kieli
        Suomi = 1
        Ruotsi = 2
    End Enum

    Enum KayttooikeusTaso
        Laaja
        Suppea
    End Enum

    Enum OrganisaatioTyyppi
        Yritys = 1
        JuridinenYhtio = 2
        Vastuuyksikko = 3
        Yhtio = 8
    End Enum

    ' https://www.m-files.com/user-guide/latest/eng/Create_or_get_shortcut.html
    Public Enum MFilesAction
        ''' <summary>
        ''' Displays the object in M-Files Desktop.
        ''' </summary>
        Show

        ''' <summary>
        ''' Shows the metadata card for the object.
        ''' </summary>
        ShowMetadata

        ''' <summary>
        ''' Shows the check-out dialog and opens the document in the default application.
        ''' </summary>
        Open

        ''' <summary>
        ''' Opens the document in the default application in read-only mode without prompting the user to check it out.
        ''' </summary>
        View

        ''' <summary>
        ''' Checks out the object and opens it for editing in the default application.
        ''' </summary>
        Edit
    End Enum

    Public Enum TiedostonSijainti
        Sharepoint
        MFiles
    End Enum

End Class
