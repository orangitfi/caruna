Public Class Tunnisteyksikko

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeTunnisteyksikko(id As Integer) As Entities.Tunnisteyksikko

    Dim tietokanta = New DAL.Tunnisteyksikko()
    Return tietokanta.HaeTunnisteyksikko(id)

  End Function

  Public Function HaeSopimuksenTunnisteyksikot(sopimusId As Integer) As List(Of DTO.Tunnisteyksikko)

    Dim tietokanta = New DAL.Tunnisteyksikko()
    Return tietokanta.HaeSopimuksenTunnisteyksikot(sopimusId)

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaTunnisteyksikko(tunnisteyksikko As Entities.Tunnisteyksikko) As Entities.Tunnisteyksikko

    Dim tietokanta = New DAL.Tunnisteyksikko()

    tunnisteyksikko.TUYLuoja = _konteksti.Kayttajatunnus
    tunnisteyksikko.TUYLuotu = Date.Now
    tunnisteyksikko.TUYPaivittaja = _konteksti.Kayttajatunnus
    tunnisteyksikko.TUYPaivitetty = Date.Now

    Return tietokanta.LisaaTunnisteyksikko(tunnisteyksikko)

  End Function

  Public Function MuokkaaTunnisteyksikkoa(tunnisteyksikko As Entities.Tunnisteyksikko) As Entities.Tunnisteyksikko

    Dim tietokanta = New DAL.Tunnisteyksikko()

    tunnisteyksikko.TUYPaivittaja = _konteksti.Kayttajatunnus
    tunnisteyksikko.TUYPaivitetty = Date.Now

    Return tietokanta.MuokkaaTunnisteyksikkoa(tunnisteyksikko)

  End Function

  Public Function PoistaTunnisteyksikko(tunnisteyksikkoId As Integer) As Entities.Tunnisteyksikko

    Dim tietokanta = New DAL.Tunnisteyksikko()
    Return tietokanta.PoistaTunnisteyksikko(tunnisteyksikkoId)

  End Function

#End Region

End Class
