

' Henkilöt ovat osaotos Tahoista, joten tässä luokassa kutsutaan
' vain Taho-luokan metodeita. Mikäli Yritysten ja Henkilöiden 
' käsittely tulee olemaan identtistä nämä kaksi luokkaa voivat
' olla tarpeettomia.
Public Class Henkilo

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeHenkilo(id As Integer)

    Dim taho = New DAL.Taho()
    Return taho.HaeTaho(id)

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaHenkilo(taho As Entities.Taho) As Entities.Taho

    Dim tietokanta = New DAL.Taho()

    taho.TAHLuoja = _konteksti.Kayttajatunnus
    taho.TAHLuotu = Date.Now
    taho.TAHPaivittaja = _konteksti.Kayttajatunnus
    taho.TAHPaivitetty = Date.Now

    Return tietokanta.LisaaTaho(taho)

  End Function

  Public Function LisaaHenkiloSopimukselle(tahoId As Integer, sopimusId As Integer) As Entities.Sopimus_Taho

    Dim tietokanta = New DAL.Taho(_konteksti)
    Return tietokanta.LisaaTahoSopimukselle(tahoId, sopimusId)

  End Function

  Public Function MuokkaaHenkiloa(taho As Entities.Taho) As Entities.Taho

    Dim tietokanta = New DAL.Taho()

    taho.TAHPaivittaja = _konteksti.Kayttajatunnus
    taho.TAHPaivitetty = Date.Now

    Return tietokanta.MuokkaaTahoa(taho)

  End Function

  Public Function PoistaHenkilo(id As Integer) As Entities.Taho

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.PoistaTaho(id)

  End Function

#End Region

End Class
