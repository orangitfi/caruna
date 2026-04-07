Imports System.Data.SqlTypes
Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO
Imports LinqKit

Public Class Tunnisteyksikko

#Region "Hakumetodit"

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of Entities.Tunnisteyksikko, Boolean))) As List(Of iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit As IEnumerable(Of Tietotyyppi.Tunnisteyksikko)

      If hakuehdot Is Nothing Then
        rivit = tietokanta.Tunnisteyksikko.Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      Else
        rivit = tietokanta.Tunnisteyksikko.AsExpandable().Where(hakuehdot).Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      End If

      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

  Public Function HaeTunnisteyksikko(id As Integer) As Tietotyyppi.Tunnisteyksikko

    Using tietokanta As New Entities.FortumEntities()

      Dim tunnisteyksikko As Tietotyyppi.Tunnisteyksikko
      tunnisteyksikko = tietokanta.Tunnisteyksikko.FirstOrDefault(Function(x) x.TUYId = id)
      Return tunnisteyksikko

    End Using

  End Function

  Public Function HaeSopimuksenTunnisteyksikot(sopimusId As Integer) As List(Of DTO.Tunnisteyksikko)

    Using tietokanta As New Entities.FortumEntities()

      Dim tunnisteyksikot = tietokanta.Tunnisteyksikko.Where(Function(x) x.TUYSopimusId.HasValue And x.TUYSopimusId = sopimusId)
      Return MuutaDTOksi(tunnisteyksikot)

    End Using

    Return Nothing

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LiitaSopimukseen(tunnisteyksikko As Entities.Tunnisteyksikko, sopimusId As Integer) As Entities.Tunnisteyksikko

    If tunnisteyksikko Is Nothing Then
      Return Nothing
    Else
      If tunnisteyksikko.TUYId = 0 Then
        Return Nothing
      Else
        If sopimusId = 0 Then
          Return Nothing
        End If
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Tunnisteyksikko.FirstOrDefault(Function(x) x.TUYId = tunnisteyksikko.TUYId)

      If Not muokattava Is Nothing Then

        muokattava.TUYSopimusId = sopimusId
        tietokanta.SaveChanges()
        Return muokattava

      End If

    End Using

    Return Nothing

  End Function

  Public Function LisaaTunnisteyksikko(tunnisteyksikko As Entities.Tunnisteyksikko) As Entities.Tunnisteyksikko

    If tunnisteyksikko Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      tietokanta.Tunnisteyksikko.Add(tunnisteyksikko)
      tietokanta.SaveChanges()
      Return tunnisteyksikko

    End Using

    Return Nothing

  End Function

  Public Function PoistaSopimukselta(tunnisteyksikko As Entities.Tunnisteyksikko) As Entities.Tunnisteyksikko

    If tunnisteyksikko Is Nothing Then
      Return Nothing
    Else
      If tunnisteyksikko.TUYId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Tunnisteyksikko.FirstOrDefault(Function(x) x.TUYId = tunnisteyksikko.TUYId)

      If Not muokattava Is Nothing Then

        muokattava.TUYSopimusId = Nothing
        tietokanta.SaveChanges()
        Return muokattava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function MuokkaaTunnisteyksikkoa(tunnisteyksikko As Entities.Tunnisteyksikko) As Entities.Tunnisteyksikko

    If tunnisteyksikko Is Nothing Then
      Return Nothing
    Else
      If tunnisteyksikko.TUYId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Tunnisteyksikko.FirstOrDefault(Function(x) x.TUYId = tunnisteyksikko.TUYId)

      If Not muokattava Is Nothing Then

        muokattava.TUYAktiivinen = tunnisteyksikko.TUYAktiivinen
        muokattava.TUYInfo = tunnisteyksikko.TUYInfo
        muokattava.TUYKohdetieto = tunnisteyksikko.TUYKohdetieto
        muokattava.TUYKoordinaatit = tunnisteyksikko.TUYKoordinaatit
        muokattava.TUYLinjaOsa = tunnisteyksikko.TUYLinjaOsa
        muokattava.TUYNimi = tunnisteyksikko.TUYNimi
        muokattava.TUYPGKoordinaatti1 = tunnisteyksikko.TUYPGKoordinaatti1
        muokattava.TUYPGKoordinaatti2 = tunnisteyksikko.TUYPGKoordinaatti2
        muokattava.TUYPGTunniste = tunnisteyksikko.TUYPGTunniste
        muokattava.TUYPGTunnus = tunnisteyksikko.TUYPGTunnus
        muokattava.TUYPaivitetty = tunnisteyksikko.TUYPaivitetty
        muokattava.TUYPaivittaja = tunnisteyksikko.TUYPaivittaja
        muokattava.TUYSopimusId = tunnisteyksikko.TUYSopimusId
        muokattava.TUYTunnisteyksikkoTyyppiId = tunnisteyksikko.TUYTunnisteyksikkoTyyppiId
        muokattava.TUYTunnus = tunnisteyksikko.TUYTunnus

        tietokanta.SaveChanges()
        Return muokattava

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaTunnisteyksikko(id As Integer) As Entities.Tunnisteyksikko

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.Tunnisteyksikko.FirstOrDefault(Function(x) x.TUYId = id)

      If Not poistettava Is Nothing Then

        tietokanta.Tunnisteyksikko.Remove(poistettava)
        tietokanta.SaveChanges()
        Return poistettava

      Else

        Return Nothing

      End If

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaDTOksi(muunnettavat As IEnumerable(Of Tietotyyppi.Tunnisteyksikko)) As List(Of DTO.Tunnisteyksikko)

    Dim tulokset = New List(Of DTO.Tunnisteyksikko)
    For Each muunnettava In muunnettavat
      tulokset.Add(MuutaDTOksi(muunnettava))
    Next
    Return tulokset

  End Function

  Private Function MuutaDTOksi(muunnettava As Tietotyyppi.Tunnisteyksikko) As DTO.Tunnisteyksikko

    Dim tulos = New DTO.Tunnisteyksikko()
    tulos.Id = muunnettava.TUYId
    tulos.Nimi = muunnettava.TUYNimi
    tulos.PGTunnus = muunnettava.TUYPGTunnus
    tulos.Tyyppi = If(muunnettava.TUYTunnisteyksikkoTyyppiId.HasValue, muunnettava.hlp_TunnisteyksikkoTyyppi.TTYTunnisteYksikkoTyyppi, String.Empty)
    tulos.SopimusId = If(muunnettava.TUYSopimusId.HasValue, muunnettava.TUYSopimusId, -1)
    tulos.Tunnus = muunnettava.TUYTunnus
    Return tulos

  End Function

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.Tunnisteyksikko)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.Tunnisteyksikko)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.TUYId
    hakutulos.Nimi = muunnettava.TUYNimi
    hakutulos.Tyyppi = "Tunnisteyksikkö"
    Return hakutulos

  End Function

#End Region

End Class
