Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO
Imports LinqKit
Imports System.Reflection.PropertyInfo
Imports System.Reflection

Public Class Kiinteisto

#Region "Hakumetodit"

  Public Function HaeKaikkiTulokset(hakuehdot As Expressions.Expression(Of Func(Of Entities.Kiinteisto, Boolean)), Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Kiinteisto)

    Using tietokanta As New Entities.FortumEntities()

      If jarjestyssarake = String.Empty Then

        Dim rivit = tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot)
        Return MuutaDTOksi(rivit)

      Else
        ' HACK: Dynaamista järjestämistä Reflectionin avulla ei saatu toimimaan
        ' ja koska sarakkeita on rajoitettu määrä tässä oikaistiin mutka.

        Select Case jarjestyssarake

          Case "KIIKiinteisto"

            Select Case jarjestyssuunta

              Case "ASC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.KIIKiinteisto))

              Case "DESC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.KIIKiinteisto))

            End Select

          Case "hlp_Kunta.KKunta"

            Select Case jarjestyssuunta

              Case "ASC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.hlp_Kunta.KKunta))

              Case "DESC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.hlp_Kunta.KKunta))

            End Select

          Case "KIIRekisterinumero"

            Select Case jarjestyssuunta

              Case "ASC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.KIIRekisterinumero))

              Case "DESC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.KIIRekisterinumero))

            End Select

          Case "KIIId"

            Select Case jarjestyssuunta

              Case "ASC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.KIIId))

              Case "DESC"
                Return MuutaDTOksi(tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.KIIId))

            End Select

        End Select

      End If

    End Using

  End Function

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of Entities.Kiinteisto, Boolean))) As List(Of DTO.iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit As IEnumerable(Of Tietotyyppi.Kiinteisto)

      If hakuehdot Is Nothing Then
        rivit = tietokanta.Kiinteisto.Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      Else
        rivit = tietokanta.Kiinteisto.AsExpandable().Where(hakuehdot).Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      End If

      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

  Public Function HaeKiinteistojenMaara(hakuehdot As Expressions.Expression(Of Func(Of Entities.Kiinteisto, Boolean))) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Kiinteisto.AsExpandable().Count(hakuehdot)

    End Using

  End Function

  Public Function HaeKiinteisto(id As Integer) As Tietotyyppi.Kiinteisto

    Using tietokanta As New Entities.FortumEntities()

      Dim kiinteisto As Tietotyyppi.Kiinteisto
      kiinteisto = tietokanta.Kiinteisto.FirstOrDefault(Function(x) x.KIIId = id)
      Return kiinteisto

    End Using

  End Function

  Public Function HaeSopimuksenKiinteistot(sopimusId As Integer) As List(Of DTO.Kiinteisto)

    Using tietokanta As New Entities.FortumEntities()

      Dim sopimukset = tietokanta.Sopimus_Kiinteisto.Where(Function(x) x.SKSopimusId = sopimusId).Select(Function(y) y.SKKiinteistoId)
      Dim kiinteistot = tietokanta.Kiinteisto.Where(Function(x) sopimukset.Contains(x.KIIId))
      Return MuutaDTOksi(kiinteistot)

    End Using

    Return Nothing

  End Function

  Public Function HaeTahonKiinteistot(tahoId As Integer) As List(Of DTO.Kiinteisto)

    Using tietokanta As New Entities.FortumEntities()

      Dim kiinteistot = tietokanta.Kiinteisto.Where(Function(x) x.KIITahoId = tahoId)
      Return MuutaDTOksi(kiinteistot)

    End Using

    Return Nothing

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaKiinteisto(kiinteisto As Entities.Kiinteisto) As Entities.Kiinteisto

    If kiinteisto Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      kiinteisto.KIIMaapintaAla = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIMaapintaAla Is Nothing, Nothing, kiinteisto.KIIMaapintaAla)
      kiinteisto.KIIVesipintaAla = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIVesipintaAla Is Nothing, Nothing, kiinteisto.KIIVesipintaAla)
      kiinteisto.KIIPintaAla = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIPintaAla Is Nothing, Nothing, kiinteisto.KIIPintaAla)
      kiinteisto.KIIKiinteistoverotettuVuosi = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIKiinteistoverotettuVuosi Is Nothing, Nothing, kiinteisto.KIIKiinteistoverotettuVuosi)
      kiinteisto.KIIAssetTunniste = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIAssetTunniste Is Nothing, Nothing, kiinteisto.KIIAssetTunniste)
      kiinteisto.KIIOmistusosuus = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIOmistusosuus Is Nothing, Nothing, kiinteisto.KIIOmistusosuus)

      tietokanta.Kiinteisto.Add(kiinteisto)
      tietokanta.SaveChanges()
      Return kiinteisto

    End Using

  End Function

  Public Function MuokkaaKiinteistoa(kiinteisto As Entities.Kiinteisto) As Entities.Kiinteisto

    If kiinteisto Is Nothing Then
      Return Nothing
    Else
      If kiinteisto.KIIId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Kiinteisto.FirstOrDefault(Function(x) x.KIIId = kiinteisto.KIIId)

      If Not muokattava Is Nothing Then

        muokattava.KIIKiinteisto = kiinteisto.KIIKiinteisto
        muokattava.KIIKortteli = kiinteisto.KIIKortteli
        muokattava.KIITontti = kiinteisto.KIITontti
        muokattava.KIIMaaraAla = kiinteisto.KIIMaaraAla
        muokattava.KIIKatuosoite = kiinteisto.KIIKatuosoite
        muokattava.KIIPostinumero = kiinteisto.KIIPostinumero
        muokattava.KIIPostitoimipaikka = kiinteisto.KIIPostitoimipaikka
        muokattava.KIIMaapintaAla = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIMaapintaAla Is Nothing, Nothing, kiinteisto.KIIMaapintaAla)
        muokattava.KIIVesipintaAla = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIVesipintaAla Is Nothing, Nothing, kiinteisto.KIIVesipintaAla)
        muokattava.KIIPintaAla = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIPintaAla Is Nothing, Nothing, kiinteisto.KIIPintaAla)
        muokattava.KIIKiinteistoverotettuVuosi = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIKiinteistoverotettuVuosi Is Nothing, Nothing, kiinteisto.KIIKiinteistoverotettuVuosi)
        muokattava.KIIAssetTunniste = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIAssetTunniste Is Nothing, Nothing, kiinteisto.KIIAssetTunniste)
        muokattava.KIIOmistusosuus = If(kiinteisto.KIIKiinteistoverotettuVuosi = 0 Or kiinteisto.KIIOmistusosuus Is Nothing, Nothing, kiinteisto.KIIOmistusosuus)
        muokattava.KIIRasitteet = kiinteisto.KIIRasitteet
        muokattava.KIISaantoId = kiinteisto.KIISaantoId
        muokattava.KIIAlueTarkenne = kiinteisto.KIIAlueTarkenne
        muokattava.KIIMaaraAlaTarkenneId = kiinteisto.KIIMaaraAlaTarkenneId
        muokattava.KIILiiketoiminnanTarveId = kiinteisto.KIILiiketoiminnanTarveId
        muokattava.KIIMaaId = kiinteisto.KIIMaaId
        muokattava.KIIKuntaId = kiinteisto.KIIKuntaId
        muokattava.KIIKylaId = kiinteisto.KIIKylaId
        muokattava.KIIKyla = kiinteisto.KIIKyla
        muokattava.KIIKylanumero = kiinteisto.KIIKylanumero
        muokattava.KIIInfo = kiinteisto.KIIInfo
        muokattava.KIIKiinnitykset = kiinteisto.KIIKiinnitykset

        muokattava.KIIRekisterinumero = kiinteisto.KIIRekisterinumero
        muokattava.KIIKiinteistotunnus = kiinteisto.KIIKiinteistotunnus
        muokattava.KIIKiinteistotunnusLyhyt = kiinteisto.KIIKiinteistotunnusLyhyt

        muokattava.KIIOmistusosuusTotal = kiinteisto.KIIOmistusosuusTotal
        muokattava.KIIKuntanumero = kiinteisto.KIIKuntanumero
        muokattava.KIIPaivitetty = kiinteisto.KIIPaivitetty
        muokattava.KIIPaivittaja = kiinteisto.KIIPaivittaja

        tietokanta.SaveChanges()
        Return muokattava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaKiinteisto(kiinteistoId As Integer) As Entities.Kiinteisto

    If kiinteistoId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.Kiinteisto.FirstOrDefault(Function(x) x.KIIId = kiinteistoId)

      If Not poistettava Is Nothing Then

        tietokanta.Kiinteisto.Remove(poistettava)
        tietokanta.SaveChanges()
        Return poistettava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaKiinteistonOmistaja(kiinteistoId As Integer) As Integer

    If kiinteistoId = 0 Then
      Return 0
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kiinteisto = tietokanta.Kiinteisto.FirstOrDefault(Function(x) x.KIIId = kiinteistoId)

      If Not kiinteisto Is Nothing Then

        Dim tahoId = kiinteisto.KIITahoId
        kiinteisto.KIITahoId = Nothing
        tietokanta.SaveChanges()
        Return tahoId

      Else

        Return 0

      End If

    End Using

  End Function

  Public Function PoistaKiinteistoSopimuksesta(kiinteistoId As Integer, sopimusId As Integer) As Integer

    If kiinteistoId = 0 Or sopimusId = 0 Then
      Return 0
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.Sopimus_Kiinteisto.FirstOrDefault(Function(x) x.SKSopimusId = sopimusId And x.SKKiinteistoId = kiinteistoId)

      If Not poistettava Is Nothing Then

        tietokanta.Sopimus_Kiinteisto.Remove(poistettava)
        tietokanta.SaveChanges()
        Return kiinteistoId

      Else

        Return 0

      End If

    End Using

  End Function


#End Region

#Region "Konversiometodit"

  Public Function MuutaDTOksi(muunnettavat As IEnumerable(Of Tietotyyppi.Kiinteisto)) As List(Of DTO.Kiinteisto)

    Dim tulokset = New List(Of DTO.Kiinteisto)
    If muunnettavat.Any() Then

      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next

    End If
    Return tulokset

  End Function

  Private Function MuutaDTOksi(muunnettava As Tietotyyppi.Kiinteisto) As DTO.Kiinteisto

    Dim tulos = New DTO.Kiinteisto()
    tulos.Id = muunnettava.KIIId
    tulos.Nimi = muunnettava.KIIKiinteisto
    tulos.Osoite = muunnettava.KIIKatuosoite
    tulos.Postinumero = muunnettava.KIIPostinumero
    tulos.Postitoimipaikka = muunnettava.KIIPostitoimipaikka
    tulos.Kunta = If(muunnettava.hlp_Kunta Is Nothing, String.Empty, muunnettava.hlp_Kunta.KKunta)
    tulos.LyhytKiinteistotunnus = muunnettava.KIIKiinteistotunnusLyhyt
    tulos.Kyla = muunnettava.KIIKyla
    If muunnettava.Sopimus_Kiinteisto.Any() Then
      tulos.SopimusId = muunnettava.Sopimus_Kiinteisto.First().SKSopimusId
    Else
      tulos.SopimusId = -1
    End If
    tulos.Rekisterinumero = muunnettava.KIIRekisterinumero
    Return tulos

  End Function

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.Kiinteisto)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.Kiinteisto)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.KIIId
    hakutulos.Nimi = muunnettava.KIIKiinteisto + LuoOsoite(muunnettava)
    hakutulos.Tyyppi = "Kiinteistö"
    Return hakutulos

  End Function

#End Region

  Private Function LuoOsoite(muunnettava As Entities.Kiinteisto) As String

    Dim osoite = muunnettava.KIIKatuosoite + " " + muunnettava.KIIPostinumero + " " + muunnettava.KIIPostitoimipaikka
    If String.IsNullOrWhiteSpace(osoite) Then
      Return String.Empty
    Else
      Return String.Format(" ({0})", osoite)
    End If

  End Function

End Class
