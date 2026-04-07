Public Class Aktiviteetti

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeAktiviteetti(ByVal id As Integer) As DTO.Aktiviteetti
    Return New DAL.Aktiviteetti().HaeAktiviteetti(id)
  End Function

  Public Function HaeSopimuksenAktiviteetit(ByVal sopimusId As Integer) As List(Of DTO.Aktiviteetti)
    Return New DAL.Aktiviteetti().HaeSopimuksenAktiviteetit(sopimusId)
  End Function

  Public Function HaeKayttajanAktiviteetit(ByVal kayttajaGuid As Guid) As List(Of DTO.Aktiviteetti)
    Return New DAL.Aktiviteetti().HaeKayttajanAktiviteetit(kayttajaGuid)
  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaAktiviteetti(ByVal aktiviteetti As DTO.Aktiviteetti) As DTO.Aktiviteetti
    aktiviteetti.Luoja = _konteksti.Kayttajatunnus
    aktiviteetti.Luotu = Date.Now
    aktiviteetti.Paivittaja = _konteksti.Kayttajatunnus
    aktiviteetti.Paivitetty = Date.Now
    Return New DAL.Aktiviteetti().LisaaAktiviteetti(aktiviteetti)
  End Function

  Public Function MuokkaaAktiviteettia(ByVal aktiviteetti As DTO.Aktiviteetti) As DTO.Aktiviteetti
    aktiviteetti.Paivittaja = _konteksti.Kayttajatunnus
    aktiviteetti.Paivitetty = Date.Now
    Return New DAL.Aktiviteetti().MuokkaaAktiviteettia(aktiviteetti)
  End Function

#End Region

End Class
