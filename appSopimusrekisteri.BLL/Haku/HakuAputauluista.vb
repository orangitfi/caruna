
Imports appSopimusrekisteri.DTO

' Tässä tiedostossa on osatoteutus Hakuluokasta.
' Tämän tiedoston hakumetodit palauttavat hlp- 
' ja hlps-taulujen tietoja iHakutulos-muodossa.

Partial Public Class Haku

#Region "Hakumetodit"

  Public Function HaeAsiakastyypit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Asiakastyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeTunnisteyksikonTyypit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.TunnisteyksikonTyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeOrganisaatioidenTyypit(kayttoOikeustaso As DTO.Enumeraattorit.KayttooikeusTaso) As List(Of iHakutulos)

    Dim tietokanta = New DAL.OrganisaationTyyppi()
    Return tietokanta.HaeTulokset(Nothing, kayttoOikeustaso)

  End Function

  Public Function HaeMaat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Maa()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKunnat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Kunta()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKylat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Kyla()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeRoolit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Roolit()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeSiirtooikeudet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Siirtooikeus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeJuridisetYhtiot() As List(Of DTO.iHakutulos)

    ' Haetaan sopimuksista raamisopimukset ja lunastusluvat.
    Dim tietokanta = New DAL.Taho()
    Dim hakutulokset = tietokanta.HaeTahot(Hakuarvot.Tahotyyppi.Organisaatio, Hakuarvot.Organisaatiotyyppi.JuridinenYhtio)
    Return hakutulokset

  End Function

  Public Function HaeAlkuperaisetYhtiot() As List(Of DTO.iHakutulos)

    ' Haetaan sopimuksista raamisopimukset ja lunastusluvat.
    Dim tietokanta = New DAL.Taho()
    Dim hakutulokset = tietokanta.HaeTahot(Hakuarvot.Tahotyyppi.Organisaatio, Hakuarvot.Organisaatiotyyppi.Yhtio)
    Return hakutulokset

  End Function

  Public Function HaeSopimusluokat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Sopimusluokka()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeSopimusehdot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.SopimuksenEhtoversio()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeSopimuksenTilat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.SopimuksenTila()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeYksikot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Yksikko()
    Return tietokanta.HaeYksikot().Select(Function(x) CType(New Hakutulos(x.YKSId, x.YKSKorvausyksikko, "Yksikkö"), iHakutulos)).ToList()

  End Function

  Public Function HaeSopimusTyypit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Sopimustyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeVastapuolenSiirtoOikeudet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Siirtooikeus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeVerkonhaltijanSiirtoOikeudet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Siirtooikeus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeYlatasonSopimukset() As List(Of iHakutulos)

    ' Luodaan hakuehdot sopimuksille, jotta niistä saadaan vain ylätason sopimukset.        
    Dim parametrit = New List(Of Integer)
    parametrit.Add(Hakuarvot.Sopimustyyppi.Raamisopimus)
    parametrit.Add(Hakuarvot.Sopimustyyppi.Lunastuslupa)
    Dim hakuehdot = DAL.Hakuehdot.Sopimusluokka(Hakuarvot.Sopimustyyppi.Raamisopimus, Hakuarvot.Sopimustyyppi.Lunastuslupa)

    ' Haetaan sopimuksista raamisopimukset ja lunastusluvat.
    Dim tietokanta = New DAL.Sopimus()
    Dim hakutulokset = tietokanta.HaeTulokset(hakuehdot)
    Return hakutulokset

  End Function

  Public Function HaeLiiketoiminnanTarpeet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.LiiketoiminnanTarve()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeSaannot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Saanto()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeMaaraalatarkenteet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Maaraalatarkenne()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeMaksualueet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Maksualue()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeAlakategorianMaksualueet(hinnastonAlakategoriaId As Integer) As List(Of iHakutulos)

    Dim tietokanta = New DAL.Maksualue()
    Return tietokanta.HaeAlakategorianMaksualueet(hinnastonAlakategoriaId)

  End Function

  Public Function HaeKorvaustyypit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Korvaustyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKorvauslaskelmanStatukset() As List(Of iHakutulos)

    Dim tietokanta = New DAL.KorvauslaskelmanStatus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKuukaudet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Kuukausi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeIndeksityypit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Indeksityyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeIndeksikuukaudet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Kuukausi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeMaksunSuoritukset() As List(Of iHakutulos)

    Dim tietokanta = New DAL.MaksunSuoritus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaePuustonOmistajuudet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.PuustonOmistajuus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaePuustonPoistot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.PuustonPoisto()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKirjanpidonTilit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.KirjanpidonTili()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKirjanpidonKustannuspaikat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.KirjanpidonKustannuspaikka()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKokonaispintaalanYksikot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.KokonaispintaalanYksikko()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKorvaushinnastot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Korvaushinnasto()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeMaarayksikot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Maarayksikko()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeHinnastonKategoriat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.HinnastonKategoria()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeHinnastonAlakategoriat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.HinnastonAlakategoria()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeMetsatyypit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Metsatyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaePuustolajit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Puustolaji()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeInvcostit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.InvCost()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaePurposet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Purpose()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeRegulationit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Regulation()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeLocal1t() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Local1()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeJulkisuusasteet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Julkisuusaste()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeSopimuksenAlaluokat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.SopimuksenAlaluokka()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKohdekategoriat() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Kohdekategoria()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeBicKoodit() As List(Of iHakutulos)

    Dim tietokanta = New DAL.BicKoodi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeMaksuehdot() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Maksuehdot()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeKielet() As List(Of iHakutulos)

    Dim tietokanta = New DAL.Kieli()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeLupatahot() As List(Of iHakutulos)
    Dim tietokanta = New DAL.Lupataho()
    Return tietokanta.HaeTulokset(Nothing)
  End Function

  Public Function HaeIndeksit() As List(Of iHakutulos)

    Dim tietokanta As New DAL.Indeksi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeInfopallurat() As List(Of iHakutulos)

    Dim tietokanta As New DAL.Infopallura()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeYlasopimuksenTyypit() As List(Of iHakutulos)

    Dim tietokanta As New DAL.YlasopimuksenTyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeAktiviteetinYhteystavat() As List(Of iHakutulos)

    Dim tietokanta As New DAL.AktiviteettiYhteystapa()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeAktiviteetinLajit() As List(Of iHakutulos)

    Dim tietokanta As New DAL.AktiviteetinLaji()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeAktiviteetinStatukset() As List(Of iHakutulos)

    Dim tietokanta As New DAL.AktiviteetinStatus()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

  Public Function HaeTahoTyypit() As List(Of iHakutulos)

    Dim tietokanta As New DAL.TahoTyyppi()
    Return tietokanta.HaeTulokset(Nothing)

  End Function

#End Region

End Class
