Imports System.Data.SqlTypes

Partial Public Class Local1

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Local1

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Local1.FirstOrDefault(Function(x) x.LOCId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Local1)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Local1.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Local1) As Entities.hlp_Local1

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.LOCLuoja = "Tuntematon"
            lisattava.LOCLuotu = SqlDateTime.MinValue
            lisattava.LOCPaivitetty = SqlDateTime.MinValue
            lisattava.LOCPaivittaja = "Tuntematon"

            tietokanta.hlp_Local1.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Local1) As Entities.hlp_Local1

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.LOCId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Local1.FirstOrDefault(Function(x) x.LOCId = muokattava.LOCId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.LOCLuoja = "Tuntematon"
                kantaversio.LOCLuotu = SqlDateTime.MinValue
                kantaversio.LOCPaivitetty = SqlDateTime.MinValue
                kantaversio.LOCPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If
            
        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Local1

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORLocal1Id = id) Then

                If Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRLocal1Id = id) Then

                    Dim poistettava = tietokanta.hlp_Local1.FirstOrDefault(Function(x) x.LOCId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Local1.Remove(poistettava)
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
