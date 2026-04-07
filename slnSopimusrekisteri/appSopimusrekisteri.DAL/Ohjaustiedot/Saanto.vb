Imports System.Data.SqlTypes

Partial Public Class Saanto

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Saanto

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Saanto.FirstOrDefault(Function(x) x.SAAId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Saanto)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Saanto.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Saanto) As Entities.hlp_Saanto

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.SAALuoja = "Tuntematon"
            lisattava.SAALuotu = SqlDateTime.MinValue
            lisattava.SAAPaivitetty = SqlDateTime.MinValue
            lisattava.SAAPaivittaja = "Tuntematon"

            tietokanta.hlp_Saanto.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Saanto) As Entities.hlp_Saanto

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.SAAId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Saanto.FirstOrDefault(Function(x) x.SAAId = muokattava.SAAId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.SAALuoja = "Tuntematon"
                kantaversio.SAALuotu = SqlDateTime.MinValue
                kantaversio.SAAPaivitetty = SqlDateTime.MinValue
                kantaversio.SAAPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Saanto

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Kiinteisto.Any(Function(x) x.KIISaantoId = id) Then

                Dim poistettava = tietokanta.hlp_Saanto.FirstOrDefault(Function(x) x.SAAId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_Saanto.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
