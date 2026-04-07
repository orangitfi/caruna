Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class AsiakirjaTarkenne

#Region "Hakumetodit"
    Implements iHaettava

    Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit = tietokanta.hlp_AsiakirjaTarkenne.OrderBy(Function(x) x.ATAAsiakirjaTarkenne)
            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_AsiakirjaTarkenne)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_AsiakirjaTarkenne)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.ATAId
        hakutulos.Nimi = muunnettava.ATAAsiakirjaTarkenne
        hakutulos.Tyyppi = "Asiakirjatarkenne"
        Return hakutulos

    End Function

#End Region

End Class
