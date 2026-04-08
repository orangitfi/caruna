Imports System.Data.SqlTypes

Partial Public Class AktiviteettiYhteystapa

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_AktiviteettiYhteystapa

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_AktiviteettiYhteystapa.FirstOrDefault(Function(x) x.YTAId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_AktiviteettiYhteystapa)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_AktiviteettiYhteystapa.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_AktiviteettiYhteystapa) As Entities.hlp_AktiviteettiYhteystapa

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.YTALuoja = "Tuntematon"
            lisattava.YTALuotu = SqlDateTime.MinValue
            lisattava.YTAPaivitetty = SqlDateTime.MinValue
            lisattava.YTAPaivittaja = "Tuntematon"

            tietokanta.hlp_AktiviteettiYhteystapa.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_AktiviteettiYhteystapa) As Entities.hlp_AktiviteettiYhteystapa

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.YTAId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_AktiviteettiYhteystapa.FirstOrDefault(Function(x) x.YTAId = muokattava.YTAId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.YTALuoja = "Tuntematon"
                kantaversio.YTALuotu = SqlDateTime.MinValue
                kantaversio.YTAPaivitetty = SqlDateTime.MinValue
                kantaversio.YTAPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_AktiviteettiYhteystapa

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Aktiviteetti.Any(Function(x) x.AKYhteystapaId = id) Then

                Dim poistettava = tietokanta.hlp_AktiviteettiYhteystapa.FirstOrDefault(Function(x) x.YTAId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_AktiviteettiYhteystapa.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
