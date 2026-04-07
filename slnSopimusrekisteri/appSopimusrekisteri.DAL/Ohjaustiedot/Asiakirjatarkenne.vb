Imports System.Data.SqlTypes

Partial Public Class Asiakirjatarkenne

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Asiakirjatarkenne

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Asiakirjatarkenne.FirstOrDefault(Function(x) x.ATAId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_AsiakirjaTarkenne)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Asiakirjatarkenne.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_AsiakirjaTarkenne) As Entities.hlp_AsiakirjaTarkenne

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.ATALuoja = "Tuntematon"
            lisattava.ATALuotu = SqlDateTime.MinValue
            lisattava.ATAPaivitetty = SqlDateTime.MinValue
            lisattava.ATAPaivittaja = "Tuntematon"

            tietokanta.hlp_Asiakirjatarkenne.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_AsiakirjaTarkenne) As Entities.hlp_AsiakirjaTarkenne

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.ATAId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Asiakirjatarkenne.FirstOrDefault(Function(x) x.ATAId = muokattava.ATAId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.ATALuoja = "Tuntematon"
                kantaversio.ATALuotu = SqlDateTime.MinValue
                kantaversio.ATAPaivitetty = SqlDateTime.MinValue
                kantaversio.ATAPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_AsiakirjaTarkenne

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Tiedosto.Any(Function(x) x.TIEAsiakirjaTarkenneId = id) Then

                Dim poistettava = tietokanta.hlp_AsiakirjaTarkenne.FirstOrDefault(Function(x) x.ATAId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_AsiakirjaTarkenne.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
