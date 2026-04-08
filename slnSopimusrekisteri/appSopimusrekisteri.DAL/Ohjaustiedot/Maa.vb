Imports System.Data.SqlTypes

Partial Public Class Maa

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Maa

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Maa.FirstOrDefault(Function(x) x.MAAId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Maa)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Maa.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Maa) As Entities.hlp_Maa

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.MAALuoja = "Tuntematon"
            lisattava.MAALuotu = SqlDateTime.MinValue
            lisattava.MAAPaivitetty = SqlDateTime.MinValue
            lisattava.MAAPaivittaja = "Tuntematon"

            tietokanta.hlp_Maa.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Maa) As Entities.hlp_Maa

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.MAAId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Maa.FirstOrDefault(Function(x) x.MAAId = muokattava.MAAId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.MAALuoja = "Tuntematon"
                kantaversio.MAALuotu = SqlDateTime.MinValue
                kantaversio.MAAPaivitetty = SqlDateTime.MinValue
                kantaversio.MAAPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Maa

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Kiinteisto.Any(Function(x) x.KIIMaaId = id) Then
                If Not tietokanta.Taho.Any(Function(x) x.TAHMaaId = id) Then

                    Dim poistettava = tietokanta.hlp_Maa.FirstOrDefault(Function(x) x.MAAId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Maa.Remove(poistettava)
                        tietokanta.SaveChanges()
                        Return poistettava

                    End If

                End If
            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
