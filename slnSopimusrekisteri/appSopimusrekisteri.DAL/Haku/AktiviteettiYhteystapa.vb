Imports appSopimusrekisteri.DTO

Public Class AktiviteettiYhteystapa

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_AktiviteettiYhteystapa.OrderBy(Function(x) x.YTAYhteystapa)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Entities.hlp_AktiviteettiYhteystapa)) As List(Of iHakutulos)
    Return muunnettavat.Select(Function(x) MuutaHakutulokseksi(x)).ToList()
  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Entities.hlp_AktiviteettiYhteystapa) As iHakutulos

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.YTAId
    hakutulos.Nimi = muunnettava.YTAYhteystapa
    hakutulos.Tyyppi = "Aktiviteetin yhteystapa"
    Return hakutulos

  End Function

#End Region

End Class
