Imports System.Data.SqlTypes

Partial Public Class ArkistonSijainti

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_ArkistonSijainti

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_ArkistonSijainti.FirstOrDefault(Function(x) x.ASIId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_ArkistonSijainti)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_ArkistonSijainti.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_ArkistonSijainti) As Entities.hlp_ArkistonSijainti

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.ASILuoja = "Tuntematon"
            lisattava.ASILuotu = SqlDateTime.MinValue
            lisattava.ASIPaivitetty = SqlDateTime.MinValue
            lisattava.ASIPaivittaja = "Tuntematon"

            tietokanta.hlp_ArkistonSijainti.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_ArkistonSijainti) As Entities.hlp_ArkistonSijainti

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.ASIId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_ArkistonSijainti.FirstOrDefault(Function(x) x.ASIId = muokattava.ASIId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.ASILuoja = "Tuntematon"
                kantaversio.ASILuotu = SqlDateTime.MinValue
                kantaversio.ASIPaivitetty = SqlDateTime.MinValue
                kantaversio.ASIPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_ArkistonSijainti

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Tiedosto.Any(Function(x) x.TIEArkistonSijaintiId = id) Then

                Dim poistettava = tietokanta.hlp_ArkistonSijainti.FirstOrDefault(Function(x) x.ASIId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_ArkistonSijainti.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
