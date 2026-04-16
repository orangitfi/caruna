Imports System.Data.SqlTypes

Partial Public Class MaaraalaTarkenne

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_MaaraAlaTarkenne

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_MaaraAlaTarkenne.FirstOrDefault(Function(x) x.MATId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_MaaraAlaTarkenne)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_MaaraAlaTarkenne.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_MaaraAlaTarkenne) As Entities.hlp_MaaraAlaTarkenne

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.MATLuoja = "Tuntematon"
            lisattava.MATLuotu = SqlDateTime.MinValue
            lisattava.MATPaivitetty = SqlDateTime.MinValue
            lisattava.MATPaivittaja = "Tuntematon"

            tietokanta.hlp_MaaraAlaTarkenne.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_MaaraAlaTarkenne) As Entities.hlp_MaaraAlaTarkenne

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.MATId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_MaaraAlaTarkenne.FirstOrDefault(Function(x) x.MATId = muokattava.MATId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.MATLuoja = "Tuntematon"
                kantaversio.MATLuotu = SqlDateTime.MinValue
                kantaversio.MATPaivitetty = SqlDateTime.MinValue
                kantaversio.MATPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_MaaraAlaTarkenne

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Kiinteisto.Any(Function(x) x.KIIMaaraAlaTarkenneId = id) Then

                Dim poistettava = tietokanta.hlp_MaaraAlaTarkenne.FirstOrDefault(Function(x) x.MATId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_MaaraAlaTarkenne.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
