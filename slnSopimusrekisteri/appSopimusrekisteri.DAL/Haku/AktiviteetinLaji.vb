Imports appSopimusrekisteri.DTO

Public Class AktiviteetinLaji

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_AktiviteetinLaji.OrderBy(Function(x) x.ALLaji)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Entities.hlp_AktiviteetinLaji)) As List(Of iHakutulos)
    Return muunnettavat.Select(Function(x) MuutaHakutulokseksi(x)).ToList()
  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Entities.hlp_AktiviteetinLaji) As iHakutulos

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.ALId
    hakutulos.Nimi = muunnettava.ALLaji
    hakutulos.Tyyppi = "Aktiviteetin laji"
    Return hakutulos

  End Function

#End Region

End Class
