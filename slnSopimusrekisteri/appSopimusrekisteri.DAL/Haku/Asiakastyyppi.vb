Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Partial Public Class Asiakastyyppi

#Region "Hakumetodit"
    Implements iHaettava

    Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit = tietokanta.hlp_Asiakastyyppi.OrderBy(Function(x) x.ATYAsiakastyyppi)
            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_Asiakastyyppi)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_Asiakastyyppi)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.ATYId
        hakutulos.Nimi = muunnettava.ATYAsiakastyyppi
        hakutulos.Tyyppi = "Asiakastyyppi"
        Return hakutulos

    End Function

#End Region

End Class
