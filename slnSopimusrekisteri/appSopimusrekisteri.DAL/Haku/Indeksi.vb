Imports appSopimusrekisteri.DTO

Public Class Indeksi

#Region "Hakumetodit"
  Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_Indeksi.OrderBy(Function(x) x.IKDId)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Entities.hlp_Indeksi)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Entities.hlp_Indeksi)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.IKDId
    hakutulos.Nimi = muunnettava.IKDArvo
    hakutulos.Tyyppi = "Indeksi"
    Return hakutulos

  End Function

#End Region

End Class
