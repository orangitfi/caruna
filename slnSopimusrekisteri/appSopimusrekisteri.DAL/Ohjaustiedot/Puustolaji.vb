Imports System.Data.SqlTypes

Partial Public Class Puustolaji

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Puustolaji

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Puustolaji.FirstOrDefault(Function(x) x.PLAId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Puustolaji)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Puustolaji.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Puustolaji) As Entities.hlp_Puustolaji

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.PLALuoja = "Tuntematon"
            lisattava.PLALuotu = SqlDateTime.MinValue
            lisattava.PLAPaivitetty = SqlDateTime.MinValue
            lisattava.PLAPaivittaja = "Tuntematon"

            tietokanta.hlp_Puustolaji.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Puustolaji) As Entities.hlp_Puustolaji

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.PLAId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Puustolaji.FirstOrDefault(Function(x) x.PLAId = muokattava.PLAId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.PLALuoja = "Tuntematon"
                kantaversio.PLALuotu = SqlDateTime.MinValue
                kantaversio.PLAPaivitetty = SqlDateTime.MinValue
                kantaversio.PLAPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Puustolaji

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.KorvausHinnasto.Any(Function(x) x.KHIPuustolajiId = id) Then

                Dim poistettava = tietokanta.hlp_Puustolaji.FirstOrDefault(Function(x) x.PLAId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_Puustolaji.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
