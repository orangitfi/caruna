Imports System.Data.SqlTypes

Partial Public Class Postitiedot

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Postitiedot

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Postitiedot.FirstOrDefault(Function(x) x.PPostiId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Postitiedot)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Postitiedot.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Postitiedot) As Entities.hlp_Postitiedot

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.PLuoja = "Tuntematon"
            lisattava.PLuotu = SqlDateTime.MinValue
            lisattava.PPaivitetty = SqlDateTime.MinValue
            lisattava.PPaivittaja = "Tuntematon"

            tietokanta.hlp_Postitiedot.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Postitiedot) As Entities.hlp_Postitiedot

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.PPostiId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Postitiedot.FirstOrDefault(Function(x) x.PPostiId = muokattava.PPostiId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.PLuoja = "Tuntematon"
                kantaversio.PLuotu = SqlDateTime.MinValue
                kantaversio.PPaivitetty = SqlDateTime.MinValue
                kantaversio.PPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Postitiedot

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim poistettava = tietokanta.hlp_Postitiedot.FirstOrDefault(Function(x) x.PPostiId = id)

            If Not poistettava Is Nothing Then

                tietokanta.hlp_Postitiedot.Remove(poistettava)
                tietokanta.SaveChanges()
                Return poistettava

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
