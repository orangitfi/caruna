Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class Kunta

#Region "Hakumetodit"
    Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_Kunta.OrderBy(Function(x) x.KKunta)
      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

  Public Function HaeKunta(kuntanro As String) As List(Of iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit = tietokanta.hlp_Kunta.Where(Function(x) x.KKuntaNro = kuntanro)

      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_Kunta)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_Kunta)

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.KKuntaid
    hakutulos.Nimi = muunnettava.KKunta
    hakutulos.Tyyppi = "Kunta"
    Return hakutulos

  End Function

#End Region

End Class
