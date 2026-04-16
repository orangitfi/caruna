Imports System.Data.SqlTypes

Partial Public Class MaksunSuoritus

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_MaksunSuoritus

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_MaksunSuoritus.FirstOrDefault(Function(x) x.MSUId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_MaksunSuoritus)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_MaksunSuoritus.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_MaksunSuoritus) As Entities.hlp_MaksunSuoritus

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.MSULuoja = "Tuntematon"
            lisattava.MSULuotu = SqlDateTime.MinValue
            lisattava.MSUPaivitetty = SqlDateTime.MinValue
            lisattava.MSUPaivittaja = "Tuntematon"

            tietokanta.hlp_MaksunSuoritus.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_MaksunSuoritus) As Entities.hlp_MaksunSuoritus

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.MSUId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_MaksunSuoritus.FirstOrDefault(Function(x) x.MSUId = muokattava.MSUId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.MSULuoja = "Tuntematon"
                kantaversio.MSULuotu = SqlDateTime.MinValue
                kantaversio.MSUPaivitetty = SqlDateTime.MinValue
                kantaversio.MSUPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_MaksunSuoritus

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORMaksunSuoritusId = id) Then

                Dim poistettava = tietokanta.hlp_MaksunSuoritus.FirstOrDefault(Function(x) x.MSUId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_MaksunSuoritus.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
