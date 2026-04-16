Public Class Sopimus

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeSopimus(id As Integer) As Entities.Sopimus

    Dim sopimus = New DAL.Sopimus()
    Return sopimus.HaeSopimus(id)

  End Function

  Public Function HaeSopimusDTO(id As Integer) As DTO.Sopimus

    Dim tietokanta As New DAL.Sopimus()

    Dim sopimus As DTO.Sopimus = tietokanta.HaeSopimusDTO(id)

    For Each kl As DTO.Korvauslaskelma In sopimus.Korvauslaskelmat

      Korvauslaskelma.LaskeKorvaukset(kl.Rivit)

    Next

    Return sopimus

  End Function

  Public Function HaeKiinteistonSopimukset(kiinteistoId As Integer) As List(Of DTO.Sopimus)

    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeKiinteistonSopimukset(kiinteistoId)

  End Function

  Public Function HaeTahonSopimukset(henkiloId As Integer) As List(Of DTO.Sopimus)

    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeTahonSopimukset(henkiloId)

  End Function

  Public Function HaeJasSopimus(sopimusId As Integer) As DTO.JASSopimus

    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeJasSopimus(sopimusId)

  End Function

  Public Function HaeSuostumussopimus(sopimusId As Integer) As DTO.Suostumussopimus

    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeSuostumussopimus(sopimusId)

  End Function

  Public Function HaeSopimusarkistoonPaivitettavatSopimukset() As DTO.Sopimus()

    Dim tietokanta As New DAL.Sopimus()

    Return tietokanta.HaeSopimusarkistoonPaivitettavatSopimukset()

  End Function

  Public Function HaeTuloste(id As Integer) As DTO.SopimusTuloste

    Dim tietokanta As New DAL.Sopimus()
    Return tietokanta.HaeTuloste(id)

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaSopimus(sopimus As Entities.Sopimus) As Entities.Sopimus

    Dim tietokanta = New DAL.Sopimus()

    sopimus.SOPLuoja = _konteksti.Kayttajatunnus
    sopimus.SOPLuotu = Date.Now
    sopimus.SOPPaivittaja = _konteksti.Kayttajatunnus
    sopimus.SOPPaivitetty = Date.Now

    Return tietokanta.LisaaSopimus(sopimus)

  End Function

  Public Function LisaaSopimus(sopimus As DTO.Sopimus) As DTO.Sopimus

    Dim tietokanta = New DAL.Sopimus()

    sopimus.Luoja = _konteksti.Kayttajatunnus
    sopimus.Luotu = Date.Now
    sopimus.Paivittaja = _konteksti.Kayttajatunnus
    sopimus.Paivitetty = Date.Now

    Return tietokanta.LisaaSopimus(sopimus)

  End Function

  Public Function LisaaTuloste(tuloste As DTO.SopimusTuloste) As DTO.SopimusTuloste

    Dim tietokanta = New DAL.Sopimus()

    tuloste.Luoja = _konteksti.Kayttajatunnus
    tuloste.Luotu = Date.Now
    tuloste.Paivittaja = _konteksti.Kayttajatunnus
    tuloste.Paivitetty = Date.Now

    Return tietokanta.LisaaTuloste(tuloste)

  End Function

  Public Function LisaaSopimusKiinteistolle(sopimusId As Integer, kiinteistoId As Integer) As Entities.Sopimus_Kiinteisto

    Dim tietokanta = New DAL.Sopimus(_konteksti)
    Return tietokanta.LisaaSopimusKiinteistolle(sopimusId, kiinteistoId)

  End Function

  Public Function MuokkaaSopimusta(sopimus As DTO.Sopimus, Optional kaikkiTiedot As Boolean = True) As DTO.Sopimus

    Dim tietokanta = New DAL.Sopimus()

    sopimus.Paivittaja = _konteksti.Kayttajatunnus
    sopimus.Paivitetty = Date.Now

    Return tietokanta.MuokkaaSopimusta(sopimus, kaikkiTiedot)

  End Function

  Public Function MuokkaaTulostetta(tuloste As DTO.SopimusTuloste) As DTO.SopimusTuloste

    Dim tietokanta = New DAL.Sopimus()

    tuloste.Paivittaja = _konteksti.Kayttajatunnus
    tuloste.Paivitetty = Date.Now

    Return tietokanta.MuokkaaTulostetta(tuloste)

  End Function

  Public Function MuokkaaSopimusta(sopimus As Entities.Sopimus) As Entities.Sopimus

    Dim tietokanta = New DAL.Sopimus()

    sopimus.SOPPaivittaja = _konteksti.Kayttajatunnus
    sopimus.SOPPaivitetty = Date.Now

    Return tietokanta.MuokkaaSopimusta(sopimus)

  End Function

  Public Function PoistaSopimus(id As Integer) As Entities.Sopimus

    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.PoistaSopimus(id)

  End Function

  Public Function PoistaSopimusKiinteistolta(sopimusId As Integer, kiinteistoId As Integer) As Integer

    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.PoistaSopimusKiinteistolta(sopimusId, kiinteistoId)

  End Function

#End Region

  Public Function Kopioi(sopimus As DTO.Sopimus) As DTO.Sopimus

    Dim uusiSopimus As DTO.Sopimus

    uusiSopimus = Common.Objektit.Kopioi(Of DTO.Sopimus)(sopimus)

    uusiSopimus.Id = Nothing
    uusiSopimus.YlasopimuksenTyyppiId = Nothing
    uusiSopimus.SopimustyyppiId = Nothing

    uusiSopimus.Luoja = Nothing
    uusiSopimus.Luotu = Nothing
    uusiSopimus.Paivittaja = Nothing
    uusiSopimus.Paivitetty = Nothing

    Return uusiSopimus

  End Function

End Class
