Imports System.Data.SqlTypes

Partial Public Class Purpose

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Purpose

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Purpose.FirstOrDefault(Function(x) x.PURId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Purpose)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Purpose.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Purpose) As Entities.hlp_Purpose

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.PURLuoja = "Tuntematon"
            lisattava.PURLuotu = SqlDateTime.MinValue
            lisattava.PURPaivitetty = SqlDateTime.MinValue
            lisattava.PURPaivittaja = "Tuntematon"

            tietokanta.hlp_Purpose.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Purpose) As Entities.hlp_Purpose

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.PURId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Purpose.FirstOrDefault(Function(x) x.PURId = muokattava.PURId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.PURLuoja = "Tuntematon"
                kantaversio.PURLuotu = SqlDateTime.MinValue
                kantaversio.PURPaivitetty = SqlDateTime.MinValue
                kantaversio.PURPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Purpose

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORPurposeId = id) Then

                If Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRPurposeId = id) Then

                    Dim poistettava = tietokanta.hlp_Purpose.FirstOrDefault(Function(x) x.PURId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Purpose.Remove(poistettava)
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
