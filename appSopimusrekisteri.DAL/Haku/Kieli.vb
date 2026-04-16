Imports appSopimusrekisteri.DTO

Public Class Kieli

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_Kieli.OrderBy(Function(x) x.KIEKieli)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Entities.hlp_Kieli)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Entities.hlp_Kieli)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.KIEId
    hakutulos.Nimi = muunnettava.KIEKieli
    hakutulos.Tyyppi = "Kieli"
    Return hakutulos

  End Function

#End Region

End Class
