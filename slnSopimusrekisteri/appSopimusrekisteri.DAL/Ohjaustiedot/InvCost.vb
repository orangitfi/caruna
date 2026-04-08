Imports System.Data.SqlTypes

Partial Public Class InvCost

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_InvCost

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_InvCost.FirstOrDefault(Function(x) x.ICOId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_InvCost)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_InvCost.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_InvCost) As Entities.hlp_InvCost

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.ICOLuoja = "Tuntematon"
            lisattava.ICOLuotu = SqlDateTime.MinValue
            lisattava.ICOPaivitetty = SqlDateTime.MinValue
            lisattava.ICOPaivittaja = "Tuntematon"

            tietokanta.hlp_InvCost.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_InvCost) As Entities.hlp_InvCost

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.ICOId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_InvCost.FirstOrDefault(Function(x) x.ICOId = muokattava.ICOId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.ICOLuoja = "Tuntematon"
                kantaversio.ICOLuotu = SqlDateTime.MinValue
                kantaversio.ICOPaivitetty = SqlDateTime.MinValue
                kantaversio.ICOPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_InvCost

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORInvCostId = id) Then

                If Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRInvCostId = id) Then

                    Dim poistettava = tietokanta.hlp_InvCost.FirstOrDefault(Function(x) x.ICOId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_InvCost.Remove(poistettava)
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
