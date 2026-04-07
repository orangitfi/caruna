Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class Postitiedot

#Region "Hakumetodit"

    Public Function HaeTulokset(postinumero As String) As appSopimusrekisteri.DTO.Postitiedot

        Using tietokanta As New Entities.FortumEntities()

            Dim rivi = tietokanta.hlp_Postitiedot.FirstOrDefault(Function(x) x.PPostinumero = postinumero)

            If Not rivi Is Nothing Then
                Return MuutaHakutulokseksi(rivi)
            Else
                Return Nothing
            End If

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlp_Postitiedot)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlp_Postitiedot)

        Dim hakutulos = New appSopimusrekisteri.DTO.Postitiedot()
        hakutulos.Postinumero = muunnettava.PPostinumero
        hakutulos.Postitoimipaikka = muunnettava.PPostitoimipaikka
        hakutulos.KuntaId = muunnettava.PKuntaid
        Return hakutulos

    End Function

#End Region

End Class
