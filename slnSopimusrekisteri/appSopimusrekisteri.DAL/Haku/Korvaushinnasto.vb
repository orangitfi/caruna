Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Partial Public Class Korvaushinnasto
    Implements iHaettava

#Region "Hakumetodit"

    Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit = tietokanta.KorvausHinnasto.Where(Function(x) x.KHIAktiivinen = True).OrderBy(Function(x) x.KHIKorvauslaji)
            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.KorvausHinnasto)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.KorvausHinnasto)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.KHIId
        hakutulos.Nimi = muunnettava.KHIKorvauslaji
        hakutulos.Tyyppi = "Korvaushinnasto"
        Return hakutulos

    End Function

#End Region

End Class
