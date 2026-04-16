Imports System.Data.SqlTypes

Partial Public Class Kunta

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Kunta

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Kunta.FirstOrDefault(Function(x) x.KKuntaid = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Kunta)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Kunta.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Kunta) As Entities.hlp_Kunta

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.KLuoja = "Tuntematon"
            lisattava.KLuotu = SqlDateTime.MinValue
            lisattava.KPaivitetty = SqlDateTime.MinValue
            lisattava.KPaivittaja = "Tuntematon"

            tietokanta.hlp_Kunta.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Kunta) As Entities.hlp_Kunta

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.KKuntaid = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Kunta.FirstOrDefault(Function(x) x.KKuntaid = muokattava.KKuntaid)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.KLuoja = "Tuntematon"
                kantaversio.KLuotu = SqlDateTime.MinValue
                kantaversio.KPaivitetty = SqlDateTime.MinValue
                kantaversio.KPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Kunta

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Kiinteisto.Any(Function(x) x.KIIKuntaId = id) Then
                If Not tietokanta.Taho.Any(Function(x) x.TAHKuntaId = id) Then

                    Dim poistettava = tietokanta.hlp_Kunta.FirstOrDefault(Function(x) x.KKuntaid = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Kunta.Remove(poistettava)
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
