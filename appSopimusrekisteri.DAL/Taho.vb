Imports System.Data.SqlTypes
Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO
Imports LinqKit

Public Class Taho

  Private _konteksti As DTO.DataKonteksti

  Public Sub New()

  End Sub

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeKaikkiTulokset(hakuehdot As Expressions.Expression(Of Func(Of Entities.Taho, Boolean)), Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Taho)

    Using tietokanta As New Entities.FortumEntities()

      If jarjestyssarake = String.Empty Then

        Dim rivit = tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot)
        Return Konversiot.Taho.MuutaDTOksi(rivit)
      Else

        ' HACK: Dynaamista järjestämistä Reflectionin avulla ei saatu toimimaan
        ' ja koska sarakkeita on rajoitettu määrä tässä oikaistiin mutka.

        Select Case jarjestyssarake

          Case "ID"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.TAHTahoId))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.TAHTahoId))
            End Select

          Case "Etunimi"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.TAHEtunimi))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.TAHEtunimi))

            End Select

          Case "Sukunimi"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.TAHSukunimi))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.TAHSukunimi))

            End Select

          Case "Tyyppi"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.TAHTyyppiId))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.TAHTyyppiId))

            End Select

          Case "Osoite"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Kiinteisto.OrderBy(Function(y) y.KIIKatuosoite)))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.Kiinteisto.OrderByDescending(Function(y) y.KIIKatuosoite)))

            End Select

          Case "Postinumero"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Kiinteisto.OrderBy(Function(y) y.KIIPostinumero)))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.Kiinteisto.OrderByDescending(Function(y) y.KIIPostinumero)))

            End Select

          Case "Postitoimipaikka"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Kiinteisto.OrderByDescending(Function(y) y.KIIPostitoimipaikka)))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.Kiinteisto.OrderBy(Function(y) y.KIIPostitoimipaikka)))

            End Select

          Case "SopimustenTunnisteet"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Sopimus.OrderBy(Function(y) y.SOPId)))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.Sopimus.OrderByDescending(Function(y) y.SOPId)))

            End Select

          Case "SopimustenMuutTunnisteet"

            Select Case jarjestyssuunta

              Case "ASC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Sopimus.Any(Function(y) y.SOPMuuTunniste)))

              Case "DESC"
                Return Konversiot.Taho.MuutaDTOksi(tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.Sopimus").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.Sopimus.Any(Function(y) y.SOPMuuTunniste)))

            End Select

        End Select

      End If

    End Using

  End Function


  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of Entities.Taho, Boolean))) As List(Of iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit As IEnumerable(Of Tietotyyppi.Taho)

      If hakuehdot Is Nothing Then
        rivit = tietokanta.Taho.Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      Else
        rivit = tietokanta.Taho.AsExpandable().Where(hakuehdot).Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      End If

      Return MuutaHakutuloksiksi(rivit)

    End Using

  End Function

  Public Function HaeTuloksetSopimuksille(sopimusId As Integer) As List(Of DTO.Taho)

    Using tietokanta As New Entities.FortumEntities()

      Dim sopimukset = tietokanta.Sopimus_Taho.Where(Function(x) x.SOTSopimusId = sopimusId).Select(Function(y) y.SOTTahoId)
      Dim tahot = tietokanta.Taho.Where(Function(x) sopimukset.Contains(x.TAHTahoId))
      Return Konversiot.Taho.MuutaDTOksi(tahot)

    End Using

  End Function

  Public Function HaeTahojenMaara(hakuehdot As Expressions.Expression(Of Func(Of Entities.Taho, Boolean))) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Taho.AsExpandable().Count(hakuehdot)

    End Using

  End Function

  Public Function HaeTahot(tyyppiId As Integer, organisaationTyyppiId As Integer?) As List(Of DTO.iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim taho
      If organisaationTyyppiId Is Nothing Then
        taho = tietokanta.Taho.Where(Function(x) x.TAHTyyppiId = tyyppiId)
      Else
        taho = tietokanta.Taho.Where(Function(x) x.TAHTyyppiId = tyyppiId And x.TAHOrganisaationTyyppiId = organisaationTyyppiId)
      End If

      Return MuutaHakutuloksiksi(taho)

    End Using

  End Function

  Public Function HaeTaho(id As Integer) As Tietotyyppi.Taho

    Using tietokanta As New Entities.FortumEntities()

      Dim taho As Tietotyyppi.Taho
      taho = tietokanta.Taho.FirstOrDefault(Function(x) x.TAHTahoId = id)
      Return taho

    End Using

  End Function

  Public Function HaeTahoDTO(id As Integer) As DTO.Taho
    Using tietokanta As New Entities.FortumEntities()

      Dim taho As Tietotyyppi.Taho
      taho = tietokanta.Taho.FirstOrDefault(Function(x) x.TAHTahoId = id)
      Return Konversiot.Taho.MuutaDTOksi(taho)

    End Using
  End Function

  Public Function HaeSopimusTaho(sopimusId As Integer, tahoId As Integer) As Entities.Sopimus_Taho

    If sopimusId = 0 Or tahoId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Sopimus_Taho.FirstOrDefault(Function(x) x.SOTTahoId = tahoId And x.SOTSopimusId = sopimusId)

    End Using

  End Function

  Public Function HaeSopimuksenTahot(sopimusId As Integer) As List(Of DTO.Taho)

    Using tietokanta As New Entities.FortumEntities()

      Dim tahot = tietokanta.Taho.Include("Sopimus_Taho").Include("Sopimus_Taho.hlp_Asiakastyyppi").Where(Function(x) x.Sopimus_Taho.Any(Function(y) y.SOTSopimusId = sopimusId And y.SOTTahoId = x.TAHTahoId))

      Return Konversiot.Taho.MuutaDTOksi(tahot, sopimusId)

    End Using

    Return Nothing

  End Function

  Public Function HaeKiinteistonOmistaja(kiinteistoId As Integer) As DTO.Taho

    Using tietokanta As New Entities.FortumEntities()

      Dim kiinteistonOmistaja = tietokanta.Kiinteisto.FirstOrDefault(Function(x) x.KIIId = kiinteistoId)
      If Not kiinteistonOmistaja Is Nothing Then
        If Not kiinteistonOmistaja.KIITahoId Is Nothing Then
          Dim omistaja = tietokanta.Taho.Where(Function(x) x.TAHTahoId = kiinteistonOmistaja.KIITahoId)
          Return Konversiot.Taho.MuutaDTOksi(omistaja.FirstOrDefault())
        End If

      End If

    End Using

    Return Nothing

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaTaho(taho As Entities.Taho) As Entities.Taho

    If taho Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      tietokanta.Taho.Add(taho)
      tietokanta.SaveChanges()
      Return taho

    End Using

  End Function

  Public Function MuokkaaSopimustahoa(sopimustaho As Entities.Sopimus_Taho) As Entities.Sopimus_Taho

    If sopimustaho Is Nothing Then
      Return Nothing
    Else
      If sopimustaho.SOTTahoId = 0 Or sopimustaho.SOTSopimusId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Sopimus_Taho.FirstOrDefault(Function(x) x.SOTTahoId = sopimustaho.SOTTahoId And x.SOTSopimusId = sopimustaho.SOTSopimusId)

      If Not muokattava Is Nothing Then

        muokattava.SOTDFRooliId = sopimustaho.SOTDFRooliId
        muokattava.SOTAsiakastyyppiId = sopimustaho.SOTAsiakastyyppiId
        muokattava.SOTPaivittaja = sopimustaho.SOTPaivittaja
        muokattava.SOTPaivitetty = sopimustaho.SOTPaivitetty
        muokattava.SOTTulostetaanSopimukseen = sopimustaho.SOTTulostetaanSopimukseen
        tietokanta.SaveChanges()
        Return muokattava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function LisaaTahoSopimukselle(tahoId As Integer, sopimusId As Integer) As Entities.Sopimus_Taho

    If tahoId = 0 Or sopimusId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim lisattava = tietokanta.Sopimus_Taho.FirstOrDefault(Function(x) x.SOTSopimusId = sopimusId And x.SOTTahoId = tahoId)

      If lisattava Is Nothing Then

        lisattava = New Entities.Sopimus_Taho()
        lisattava.SOTSopimusId = sopimusId
        lisattava.SOTTahoId = tahoId
        lisattava.SOTLuoja = _konteksti.Kayttajatunnus
        lisattava.SOTLuotu = Date.Now
        lisattava.SOTPaivittaja = _konteksti.Kayttajatunnus
        lisattava.SOTPaivitetty = Date.Now
        lisattava.SOTTulostetaanSopimukseen = True
        tietokanta.Sopimus_Taho.Add(lisattava)
        tietokanta.SaveChanges()
        Return lisattava


      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function MuokkaaTahoa(taho As Entities.Taho) As Entities.Taho

    If taho Is Nothing Then
      Return Nothing
    Else
      If taho.TAHTahoId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Taho.FirstOrDefault(Function(x) x.TAHTahoId = taho.TAHTahoId)

      If Not muokattava Is Nothing Then

        muokattava.TAHEtunimi = taho.TAHEtunimi
        muokattava.TAHSukunimi = taho.TAHSukunimi
        muokattava.TAHAlvVelvollinen = taho.TAHAlvVelvollinen
        muokattava.TAHEmail = taho.TAHEmail
        muokattava.TAHPostitusosoite = taho.TAHPostitusosoite
        muokattava.TAHPostituspostinro = taho.TAHPostituspostinro
        muokattava.TAHPostituspostitmp = taho.TAHPostituspostitmp
        muokattava.TAHPuhelin = taho.TAHPuhelin
        muokattava.TAHTilinumero = taho.TAHTilinumero
        muokattava.TAHYtunnus = taho.TAHYtunnus
        muokattava.TAHMaaId = taho.TAHMaaId
        muokattava.TAHKuntaId = taho.TAHKuntaId
        muokattava.TAHBic = taho.TAHBic
        muokattava.TAHOrganisaationTyyppiId = taho.TAHOrganisaationTyyppiId
        muokattava.TAHNimitarkenne = taho.TAHNimitarkenne
        muokattava.TAHInfo = taho.TAHInfo
        muokattava.TAHBicKoodiId = taho.TAHBicKoodiId
        muokattava.TAHPaivittaja = taho.TAHPaivittaja
        muokattava.TAHPaivitetty = taho.TAHPaivitetty
        muokattava.TAHKirjanpidonYritystunniste = taho.TAHKirjanpidonYritystunniste
        muokattava.TAHKirjanpidonProjektitunniste = taho.TAHKirjanpidonProjektitunniste
        muokattava.TAHConcession = taho.TAHConcession
        tietokanta.SaveChanges()
        Return muokattava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaTaho(tahoId As Integer) As Entities.Taho

    If tahoId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.Taho.FirstOrDefault(Function(x) x.TAHTahoId = tahoId)

      If Not poistettava Is Nothing Then

        tietokanta.Taho.Remove(poistettava)
        tietokanta.SaveChanges()
        Return poistettava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaTahoSopimuksesta(tahoId As Integer, sopimusId As Integer) As Integer

    If tahoId = 0 Or sopimusId = 0 Then
      Return 0
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.Sopimus_Taho.FirstOrDefault(Function(x) x.SOTSopimusId = sopimusId And x.SOTTahoId = tahoId)

      If Not poistettava Is Nothing Then

        tietokanta.Sopimus_Taho.Remove(poistettava)
        tietokanta.SaveChanges()
        Return tahoId

      Else

        Return 0

      End If

    End Using

  End Function


  Public Function PoistaTahoKorvauslaskelmalta(korvauslaskelmaId As Integer) As Integer

    If korvauslaskelmaId = 0 Then
      Return 0
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = korvauslaskelmaId)

      If Not poistettava Is Nothing Then

        poistettava.KORTahoId = Nothing
        tietokanta.SaveChanges()
        Return 1

      Else

        Return 0

      End If

    End Using

  End Function

  Public Function LiitaTahoKorvauslaskelmalle(tahoId As Integer, korvauslaskelmaId As Integer) As Integer

    If tahoId = 0 Or korvauslaskelmaId = 0 Then
      Return 0
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelma = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = korvauslaskelmaId) ' And x.KORTahoId Is Nothing)

      If Not korvauslaskelma Is Nothing Then

        korvauslaskelma.KORTahoId = tahoId
        tietokanta.SaveChanges()
        Return korvauslaskelma.KORTahoId

      Else

        Return 0

      End If

    End Using

  End Function

  Public Function LiitaTahoKiinteistolle(tahoId As Integer, kiinteistoId As Integer) As Integer

    If tahoId = 0 Or kiinteistoId = 0 Then
      Return 0
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kiinteisto = tietokanta.Kiinteisto.FirstOrDefault(Function(x) x.KIIId = kiinteistoId) ' And x.KIITahoId Is Nothing)

      If Not kiinteisto Is Nothing Then

        kiinteisto.KIITahoId = tahoId
        tietokanta.SaveChanges()
        Return kiinteisto.KIITahoId

      Else

        Return 0

      End If

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutuloksiksi(muunnettavat As IEnumerable(Of Tietotyyppi.Taho)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.Taho)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.TAHTahoId
    hakutulos.Nimi = (muunnettava.TAHEtunimi + " " + muunnettava.TAHSukunimi).Trim()
    hakutulos.Tyyppi = If(muunnettava.TAHTyyppiId = Enumeraattorit.TahoTyyppi.Henkilo, "Henkilö", "Organisaatio")
    Return hakutulos

  End Function

#End Region

End Class
