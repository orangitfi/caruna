Imports appSopimusrekisteri.DTO

Public Class YlasopimuksenTyyppi

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlps_YlasopimuksenTyyppi.OrderBy(Function(x) x.YSTYlasopimuksenTyyppi)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Entities.hlps_YlasopimuksenTyyppi)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Entities.hlps_YlasopimuksenTyyppi)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.YSTId
    hakutulos.Nimi = muunnettava.YSTYlasopimuksenTyyppi
    hakutulos.Tyyppi = "YlasopimuksenTyyppi"
    Return hakutulos

  End Function

#End Region


End Class
