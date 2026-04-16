Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class SopimuksenEhtoversio

#Region "Hakumetodit"
    Implements iHaettava

    Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit = tietokanta.hlp_SopimuksenEhtoversio.OrderBy(Function(x) x.SEHSopimuksenEhtoversio)
            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_SopimuksenEhtoversio)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_SopimuksenEhtoversio)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.SEHId
        hakutulos.Nimi = muunnettava.SEHSopimuksenEhtoversio
        hakutulos.Tyyppi = "Sopimuksen ehtoversio"
        Return hakutulos

    End Function

#End Region

End Class
