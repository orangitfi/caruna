Imports System.Data.SqlTypes

Partial Public Class PassivoinninSyy

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_PassivoinninSyy

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_PassivoinninSyy.FirstOrDefault(Function(x) x.PASId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_PassivoinninSyy)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_PassivoinninSyy.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_PassivoinninSyy) As Entities.hlp_PassivoinninSyy

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.PASLuoja = "Tuntematon"
            lisattava.PASLuotu = SqlDateTime.MinValue
            lisattava.PASPaivitetty = SqlDateTime.MinValue
            lisattava.PASPaivittaja = "Tuntematon"

            tietokanta.hlp_PassivoinninSyy.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_PassivoinninSyy) As Entities.hlp_PassivoinninSyy

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.PASId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_PassivoinninSyy.FirstOrDefault(Function(x) x.PASId = muokattava.PASId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.PASLuoja = "Tuntematon"
                kantaversio.PASLuotu = SqlDateTime.MinValue
                kantaversio.PASPaivitetty = SqlDateTime.MinValue
                kantaversio.PASPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_PassivoinninSyy

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Taho.Any(Function(x) x.TAHPassivoinninsyyId = id) Then

                Dim poistettava = tietokanta.hlp_PassivoinninSyy.FirstOrDefault(Function(x) x.PASId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_PassivoinninSyy.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
