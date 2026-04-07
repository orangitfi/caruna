Public Class SopimusarkistoLoki

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

  Public Function LisaaLoki(loki As DTO.SopimusarkistoLoki) As DTO.SopimusarkistoLoki

    Dim tietokanta = New DAL.SopimusarkistoLoki()

    loki.Luoja = _konteksti.Kayttajatunnus
    loki.Luotu = Date.Now

    Return tietokanta.LisaaLoki(loki)

  End Function

End Class
