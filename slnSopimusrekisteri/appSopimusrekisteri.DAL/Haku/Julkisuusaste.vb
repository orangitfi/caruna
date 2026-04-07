Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Partial Public Class Julkisuusaste

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_Julkisuusaste.OrderBy(Function(x) x.JASJulkisuusaste)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_Julkisuusaste)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_Julkisuusaste)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.JASId
    hakutulos.Nimi = muunnettava.JASJulkisuusaste
    hakutulos.Tyyppi = "Julkisuusaste"
    Return hakutulos

  End Function

#End Region

End Class
