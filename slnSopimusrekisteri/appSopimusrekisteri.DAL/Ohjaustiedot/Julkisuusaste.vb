Imports System.Data.SqlTypes

Partial Public Class Julkisuusaste

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Julkisuusaste

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Julkisuusaste.FirstOrDefault(Function(x) x.JASid = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Julkisuusaste)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Julkisuusaste.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Julkisuusaste) As Entities.hlp_Julkisuusaste

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.JASLuoja = "Tuntematon"
            lisattava.JASLuotu = SqlDateTime.MinValue
            lisattava.JASPaivitetty = SqlDateTime.MinValue
            lisattava.JASPaivittaja = "Tuntematon"

            tietokanta.hlp_Julkisuusaste.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Julkisuusaste) As Entities.hlp_Julkisuusaste

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.JASid = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Julkisuusaste.FirstOrDefault(Function(x) x.JASid = muokattava.JASid)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.JASLuoja = "Tuntematon"
                kantaversio.JASLuotu = SqlDateTime.MinValue
                kantaversio.JASPaivitetty = SqlDateTime.MinValue
                kantaversio.JASPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Julkisuusaste

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim poistettava = tietokanta.hlp_Julkisuusaste.FirstOrDefault(Function(x) x.JASId = id)

            If Not poistettava Is Nothing Then

                tietokanta.hlp_Julkisuusaste.Remove(poistettava)
                tietokanta.SaveChanges()
                Return poistettava

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
