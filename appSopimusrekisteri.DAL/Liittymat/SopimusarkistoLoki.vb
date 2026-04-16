Public Class SopimusarkistoLoki

  Public Function LisaaLoki(loki As DTO.SopimusarkistoLoki) As DTO.SopimusarkistoLoki

    Dim lisattava As Entities.SopimusarkistoLoki = Konversiot.SopimusarkistoLoki.MuutaDBOksi(loki)

    Using tietokanta As New Entities.FortumEntities()

      tietokanta.SopimusarkistoLoki.Add(lisattava)

      tietokanta.SaveChanges()

    End Using

    Return loki

  End Function

End Class
