Imports System.Data.SqlTypes

Partial Public Class AktiviteetinLaji

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_AktiviteetinLaji

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_AktiviteetinLaji.FirstOrDefault(Function(x) x.ALId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_AktiviteetinLaji)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_AktiviteetinLaji.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_AktiviteetinLaji) As Entities.hlp_AktiviteetinLaji

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.ALLuoja = "Tuntematon"
            lisattava.ALLuotu = SqlDateTime.MinValue
            lisattava.ALPaivitetty = SqlDateTime.MinValue
            lisattava.ALPaivittaja = "Tuntematon"

            tietokanta.hlp_AktiviteetinLaji.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_AktiviteetinLaji) As Entities.hlp_AktiviteetinLaji

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.ALId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_AktiviteetinLaji.FirstOrDefault(Function(x) x.ALId = muokattava.ALId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.ALLuoja = "Tuntematon"
                kantaversio.ALLuotu = SqlDateTime.MinValue
                kantaversio.ALPaivitetty = SqlDateTime.MinValue
                kantaversio.ALPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_AktiviteetinLaji

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Aktiviteetti.Any(Function(x) x.AKAktiviteetinLajiId = id) Then

                Dim poistettava = tietokanta.hlp_AktiviteetinLaji.FirstOrDefault(Function(x) x.ALId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_AktiviteetinLaji.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
