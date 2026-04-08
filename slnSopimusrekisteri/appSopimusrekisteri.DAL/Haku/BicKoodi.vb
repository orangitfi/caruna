Imports appSopimusrekisteri.DTO
Imports appSopimusrekisteri.Entities

Public Class BicKoodi

#Region "Hakumetodit"
    Implements iHaettava

    Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit = tietokanta.hlp_BicKoodi.OrderBy(Function(x) x.BKKoodi)
            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

    Public Function HaeBicKoodi(rahalaitostunnus As String) As List(Of iHakutulos)

        Using tietokanta As New Entities.FortumEntities()

            Dim bicKoodit As List(Of hlp_BicKoodi) = tietokanta.hlp_BicKoodi.ToList()
            Return MuutaHakutulokseksi(bicKoodit.Where(Function(x) x.BKRahalaitosTunnus.Split(",").Contains(rahalaitostunnus)))

        End Using

    End Function

    Public Function HaeRahalaitosTunnus(tilinumero As String) As String
        If Common.Tilinumerot.OnIbanTilinumero(tilinumero) Then
            tilinumero = Right(tilinumero, tilinumero.Length - 4)
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim bicKoodit = tietokanta.hlp_BicKoodi.ToList()
            For Each bic As hlp_BicKoodi In bicKoodit
                For Each s As String In bic.BKRahalaitosTunnus.Split(",")
                    If tilinumero.StartsWith(s.Trim) Then
                        Return s.Trim
                    End If
                Next
            Next

            Return String.Empty
        End Using
    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Entities.hlp_BicKoodi)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Entities.hlp_BicKoodi)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.BKId
        hakutulos.Nimi = muunnettava.BKPankki & " " & muunnettava.BKKoodi
        hakutulos.Tyyppi = "BicKoodi"
        Return hakutulos

    End Function

#End Region

End Class
