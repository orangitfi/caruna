Imports System.Data.SqlTypes

Partial Public Class Regulation

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Regulation

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Regulation.FirstOrDefault(Function(x) x.REGId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Regulation)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Regulation.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Regulation) As Entities.hlp_Regulation

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.REGLuoja = "Tuntematon"
            lisattava.REGLuotu = SqlDateTime.MinValue
            lisattava.REGPaivitetty = SqlDateTime.MinValue
            lisattava.REGPaivittaja = "Tuntematon"

            tietokanta.hlp_Regulation.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Regulation) As Entities.hlp_Regulation

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.REGId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Regulation.FirstOrDefault(Function(x) x.REGId = muokattava.REGId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.REGLuoja = "Tuntematon"
                kantaversio.REGLuotu = SqlDateTime.MinValue
                kantaversio.REGPaivitetty = SqlDateTime.MinValue
                kantaversio.REGPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Regulation

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORRegulationId = id) Then

                If Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRRegulationId = id) Then

                    Dim poistettava = tietokanta.hlp_Regulation.FirstOrDefault(Function(x) x.REGId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Regulation.Remove(poistettava)
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
