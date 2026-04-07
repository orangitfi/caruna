Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class TahoTyyppi

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlps_TahoTyyppi.OrderBy(Function(x) x.TATTahoTyyppi)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlps_TahoTyyppi)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlps_TahoTyyppi)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.TATId
    hakutulos.Nimi = muunnettava.TATTahoTyyppi
    hakutulos.Tyyppi = "TahoTyyppi"
    Return hakutulos

  End Function

#End Region

End Class
