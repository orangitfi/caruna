Imports System.Data.SqlTypes

Partial Public Class PuustonOmistajuus

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_PuustonOmistajuus

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_PuustonOmistajuus.FirstOrDefault(Function(x) x.POMId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_PuustonOmistajuus)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_PuustonOmistajuus.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_PuustonOmistajuus) As Entities.hlp_PuustonOmistajuus

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.POMLuoja = "Tuntematon"
            lisattava.POMLuotu = SqlDateTime.MinValue
            lisattava.POMPaivitetty = SqlDateTime.MinValue
            lisattava.POMPaivittaja = "Tuntematon"

            tietokanta.hlp_PuustonOmistajuus.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_PuustonOmistajuus) As Entities.hlp_PuustonOmistajuus

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.POMId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_PuustonOmistajuus.FirstOrDefault(Function(x) x.POMId = muokattava.POMId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.POMLuoja = "Tuntematon"
                kantaversio.POMLuotu = SqlDateTime.MinValue
                kantaversio.POMPaivitetty = SqlDateTime.MinValue
                kantaversio.POMPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_PuustonOmistajuus

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORPuustonOmistajuusId = id) Then

                Dim poistettava = tietokanta.hlp_PuustonOmistajuus.FirstOrDefault(Function(x) x.POMId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_PuustonOmistajuus.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
