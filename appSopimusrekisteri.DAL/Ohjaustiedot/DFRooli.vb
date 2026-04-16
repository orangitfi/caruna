Imports System.Data.SqlTypes

Partial Public Class DFRooli

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_DFRooli

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_DFRooli.FirstOrDefault(Function(x) x.DFRId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_DFRooli)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_DFRooli.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_DFRooli) As Entities.hlp_DFRooli

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.DFRLuoja = "Tuntematon"
            lisattava.DFRLuotu = SqlDateTime.MinValue
            lisattava.DFRPaivitetty = SqlDateTime.MinValue
            lisattava.DFRPaivittaja = "Tuntematon"

            tietokanta.hlp_DFRooli.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_DFRooli) As Entities.hlp_DFRooli

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.DFRId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_DFRooli.FirstOrDefault(Function(x) x.DFRId = muokattava.DFRId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.DFRLuoja = "Tuntematon"
                kantaversio.DFRLuotu = SqlDateTime.MinValue
                kantaversio.DFRPaivitetty = SqlDateTime.MinValue
                kantaversio.DFRPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_DFRooli

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Sopimus.Any(Function(x) x.SOPDFRooliId = id) Then

                Dim poistettava = tietokanta.hlp_DFRooli.FirstOrDefault(Function(x) x.DFRId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_DFRooli.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
