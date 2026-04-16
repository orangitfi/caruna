
Public Class Taho

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeTaho(id As Integer) As Entities.Taho

    Dim taho = New DAL.Taho()
    Return taho.HaeTaho(id)

  End Function

  Public Function HaeTahoDTO(id As Integer) As DTO.Taho
    Dim taho = New DAL.Taho()
    Return taho.HaeTahoDTO(id)
  End Function

  Public Function HaeSopimuksenTahot(sopimusId As Integer) As List(Of DTO.Taho)

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeSopimuksenTahot(sopimusId)

  End Function

  Public Function HaeSopimusTaho(sopimusId As Integer, tahoId As Integer) As Entities.Sopimus_Taho

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeSopimusTaho(sopimusId, tahoId)

  End Function

  Public Function HaeKiinteistonOmistaja(kiinteistoId As Integer) As DTO.Taho

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeKiinteistonOmistaja(kiinteistoId)

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaTaho(taho As Entities.Taho) As Entities.Taho

    Dim tietokanta = New DAL.Taho()

    taho.TAHLuoja = _konteksti.Kayttajatunnus
    taho.TAHLuotu = Date.Now
    taho.TAHPaivittaja = _konteksti.Kayttajatunnus
    taho.TAHPaivitetty = Date.Now

    Return tietokanta.LisaaTaho(taho)

  End Function

  Public Function MuokkaaTahoa(taho As Entities.Taho) As Entities.Taho

    Dim tietokanta = New DAL.Taho()

    taho.TAHPaivittaja = _konteksti.Kayttajatunnus
    taho.TAHPaivitetty = Date.Now

    Return tietokanta.MuokkaaTahoa(taho)

  End Function

  Public Function PoistaTaho(tahoId As Integer) As Entities.Taho

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.PoistaTaho(tahoId)

  End Function

  Public Function PoistaTahoSopimukselta(tahoId As Integer, sopimusId As Integer) As Integer

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.PoistaTahoSopimuksesta(tahoId, sopimusId)

  End Function

  Public Function PoistaTahoKorvauslaskelmalta(korvauslaskelmaId As Integer) As Integer

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.PoistaTahoKorvauslaskelmalta(korvauslaskelmaId)

  End Function

  Public Function LiitaTahoKorvauslaskelmalle(tahoId As Integer, korvauslaskelmaId As Integer) As Integer

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.LiitaTahoKorvauslaskelmalle(tahoId, korvauslaskelmaId)

  End Function

  Public Function LiitaTahoKiinteistolle(tahoId As Integer, kiinteistoId As Integer) As Integer

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.LiitaTahoKiinteistolle(tahoId, kiinteistoId)

  End Function

  Public Function LisaaTahoSopimukselle(tahoId As Integer, sopimusId As Integer) As Entities.Sopimus_Taho

    Dim tietokanta = New DAL.Taho(_konteksti)
    Return tietokanta.LisaaTahoSopimukselle(tahoId, sopimusId)

  End Function

  Public Function MuokkaaSopimustahoa(sopimustaho As Entities.Sopimus_Taho) As Entities.Sopimus_Taho

    Dim tietokanta = New DAL.Taho()

    sopimustaho.SOTPaivittaja = _konteksti.Kayttajatunnus
    sopimustaho.SOTPaivitetty = Date.Now

    Return tietokanta.MuokkaaSopimustahoa(sopimustaho)

  End Function

#End Region

End Class
