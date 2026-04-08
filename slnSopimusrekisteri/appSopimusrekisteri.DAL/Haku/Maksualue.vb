Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class Maksualue

#Region "Hakumetodit"
    Implements iHaettava

    Public Function HaeAlakategorianMaksualueet(hinnastonAlakategoriaId As Integer) As List(Of iHakutulos)

        Using tietokanta As New Entities.FortumEntities()

            Dim hinnastonRivit = tietokanta.KorvausHinnasto.Where(Function(x) x.KHIHinnastoAlakategoriaId = hinnastonAlakategoriaId)
            If hinnastonRivit.Any() Then

                Dim maksualueenTunnisteet = hinnastonRivit.Select(Function(x) x.KHIMaksuAlueId)
                Dim maksualueenRivit = tietokanta.hlp_Maksualue.Where(Function(x) maksualueenTunnisteet.Contains(x.MALId))
                Return MuutaHakutulokseksi(maksualueenRivit.OrderBy(Function(x) x.MALMaksualue))

            End If

        End Using

        Return New List(Of iHakutulos)

    End Function

    Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit = tietokanta.hlp_Maksualue
            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_Maksualue)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_Maksualue)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.MALId
        hakutulos.Nimi = muunnettava.MALMaksualue
        hakutulos.Tyyppi = "Maksualue"
        Return hakutulos

    End Function

#End Region

End Class
