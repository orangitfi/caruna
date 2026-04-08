Imports System.Data.SqlTypes

Partial Public Class AktiviteetinStatus

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_AktiviteetinStatus

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_AktiviteetinStatus.FirstOrDefault(Function(x) x.ASId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_AktiviteetinStatus)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_AktiviteetinStatus.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_AktiviteetinStatus) As Entities.hlp_AktiviteetinStatus

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.ASLuoja = "Tuntematon"
            lisattava.ASLuotu = SqlDateTime.MinValue
            lisattava.ASPaivitetty = SqlDateTime.MinValue
            lisattava.ASPaivittaja = "Tuntematon"

            tietokanta.hlp_AktiviteetinStatus.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_AktiviteetinStatus) As Entities.hlp_AktiviteetinStatus

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.ASId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_AktiviteetinStatus.FirstOrDefault(Function(x) x.ASId = muokattava.ASId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.ASLuoja = "Tuntematon"
                kantaversio.ASLuotu = SqlDateTime.MinValue
                kantaversio.ASPaivitetty = SqlDateTime.MinValue
                kantaversio.ASPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_AktiviteetinStatus

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Aktiviteetti.Any(Function(x) x.AKStatusId = id) Then

                Dim poistettava = tietokanta.hlp_AktiviteetinStatus.FirstOrDefault(Function(x) x.ASId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_AktiviteetinStatus.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
