Imports System.Data.SqlTypes

Partial Public Class Metsatyyppi

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Metsatyyppi

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Metsatyyppi.FirstOrDefault(Function(x) x.MTYId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Metsatyyppi)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Metsatyyppi.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Metsatyyppi) As Entities.hlp_Metsatyyppi

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.MTYLuoja = "Tuntematon"
            lisattava.MTYLuotu = SqlDateTime.MinValue
            lisattava.MTYPaivitetty = SqlDateTime.MinValue
            lisattava.MTYPaivittaja = "Tuntematon"

            tietokanta.hlp_Metsatyyppi.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Metsatyyppi) As Entities.hlp_Metsatyyppi

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.MTYId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Metsatyyppi.FirstOrDefault(Function(x) x.MTYId = muokattava.MTYId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.MTYLuoja = "Tuntematon"
                kantaversio.MTYLuotu = SqlDateTime.MinValue
                kantaversio.MTYPaivitetty = SqlDateTime.MinValue
                kantaversio.MTYPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Metsatyyppi

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.KorvausHinnasto.Any(Function(x) x.KHIMetsatyyppiId = id) Then

                Dim poistettava = tietokanta.hlp_Metsatyyppi.FirstOrDefault(Function(x) x.MTYId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_Metsatyyppi.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
