Imports System.Data.SqlTypes

Partial Public Class PuustonPoisto

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_PuustonPoisto

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_PuustonPoisto.FirstOrDefault(Function(x) x.PPOId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_PuustonPoisto)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_PuustonPoisto.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_PuustonPoisto) As Entities.hlp_PuustonPoisto

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.PPOLuoja = "Tuntematon"
            lisattava.PPOLuotu = SqlDateTime.MinValue
            lisattava.PPOPaivitetty = SqlDateTime.MinValue
            lisattava.PPOPaivittaja = "Tuntematon"

            tietokanta.hlp_PuustonPoisto.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_PuustonPoisto) As Entities.hlp_PuustonPoisto

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.PPOId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_PuustonPoisto.FirstOrDefault(Function(x) x.PPOId = muokattava.PPOId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.PPOLuoja = "Tuntematon"
                kantaversio.PPOLuotu = SqlDateTime.MinValue
                kantaversio.PPOPaivitetty = SqlDateTime.MinValue
                kantaversio.PPOPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_PuustonPoisto

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORPuustonPoistoId = id) Then

                Dim poistettava = tietokanta.hlp_PuustonPoisto.FirstOrDefault(Function(x) x.PPOId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_PuustonPoisto.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
