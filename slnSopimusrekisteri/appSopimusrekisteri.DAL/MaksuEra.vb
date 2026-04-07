Imports appSopimusrekisteri.Entities

Public Class MaksuEra

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

#End Region

#Region "Muokkausmetodit"

  Public Shadows Function UusiMaksuEra() As DTO.MaksuEra

    Using tietokanta As New FortumEntities()

      Dim maksuaineisto = New Entities.Maksuaineisto()

      maksuaineisto.MAILuoja = _konteksti.Kayttajatunnus
      maksuaineisto.MAILuotu = Date.Now
      maksuaineisto.MAIPaivittaja = _konteksti.Kayttajatunnus
      maksuaineisto.MAIPaivitetty = Date.Now

      tietokanta.Maksuaineisto.Add(maksuaineisto)
      tietokanta.SaveChanges()

      Return Konversiot.MaksuEra.MuutaDTOksi(maksuaineisto)

    End Using
  End Function

#End Region

#Region "Konversiometodit"


#End Region
End Class
