Public Class Tiedosto

#Region "Hakumetodit"

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

  Public Function HaeTiedosto(id As Integer) As DTO.Tiedosto

    Dim tietokanta = New DAL.Tiedosto()
    Return tietokanta.HaeTiedosto(id)

  End Function

  Public Function HaeSopimuksenTiedostot(sopimusId As Integer) As List(Of DTO.Tiedosto)

    Dim tietokanta = New DAL.Tiedosto()
    Return tietokanta.HaeSopimuksenTiedostot(sopimusId)

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaTiedosto(tiedosto As DTO.Tiedosto) As DTO.Tiedosto

    Dim tietokanta = New DAL.Tiedosto()

    tiedosto.Luoja = _konteksti.Kayttajatunnus
    tiedosto.Luotu = Date.Now
    tiedosto.Paivittaja = _konteksti.Kayttajatunnus
    tiedosto.Paivitetty = Date.Now

    Return tietokanta.LisaaTiedosto(tiedosto)

  End Function

  Public Function MuokkaaTiedostoa(tiedosto As DTO.Tiedosto) As DTO.Tiedosto

    Dim tietokanta = New DAL.Tiedosto()

    tiedosto.Paivittaja = _konteksti.Kayttajatunnus
    tiedosto.Paivitetty = Date.Now

    Return tietokanta.MuokkaaTiedostoa(tiedosto)

  End Function

  Public Function PoistaTiedosto(tiedostoId As Integer) As DTO.Tiedosto

    Dim tietokanta = New DAL.Tiedosto()
    Return tietokanta.PoistaTiedosto(tiedostoId)

  End Function

#End Region

End Class
