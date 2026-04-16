Imports System.Data.SqlTypes

Partial Public Class Kyla

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Kyla

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Kyla.FirstOrDefault(Function(x) x.KYLId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Kyla)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Kyla.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Kyla) As Entities.hlp_Kyla

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.KYLLuoja = "Tuntematon"
            lisattava.KYLLuotu = SqlDateTime.MinValue
            lisattava.KYLPaivitetty = SqlDateTime.MinValue
            lisattava.KYLPaivittaja = "Tuntematon"

            tietokanta.hlp_Kyla.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Kyla) As Entities.hlp_Kyla

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.KYLId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Kyla.FirstOrDefault(Function(x) x.KYLId = muokattava.KYLId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.KYLLuoja = "Tuntematon"
                kantaversio.KYLLuotu = SqlDateTime.MinValue
                kantaversio.KYLPaivitetty = SqlDateTime.MinValue
                kantaversio.KYLPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Kyla

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Kiinteisto.Any(Function(x) x.KIIKylaId = id) Then

                Dim poistettava = tietokanta.hlp_Kyla.FirstOrDefault(Function(x) x.KYLId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_Kyla.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
