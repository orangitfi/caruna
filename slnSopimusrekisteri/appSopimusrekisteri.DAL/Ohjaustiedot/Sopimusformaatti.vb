Imports System.Data.SqlTypes

Partial Public Class Sopimusformaatti

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_SopimusFormaatti

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimusFormaatti.FirstOrDefault(Function(x) x.SFOId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_SopimusFormaatti)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimusFormaatti.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_SopimusFormaatti) As Entities.hlp_SopimusFormaatti

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.SFOLuoja = "Tuntematon"
            lisattava.SFOLuotu = SqlDateTime.MinValue
            lisattava.SFOPaivitetty = SqlDateTime.MinValue
            lisattava.SFOPaivittaja = "Tuntematon"

            tietokanta.hlp_SopimusFormaatti.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_SopimusFormaatti) As Entities.hlp_SopimusFormaatti

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.SFOId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_SopimusFormaatti.FirstOrDefault(Function(x) x.SFOId = muokattava.SFOId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.SFOLuoja = "Tuntematon"
                kantaversio.SFOLuotu = SqlDateTime.MinValue
                kantaversio.SFOPaivitetty = SqlDateTime.MinValue
                kantaversio.SFOPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_SopimusFormaatti

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Tiedosto.Any(Function(x) x.TIESopimusFormaattiId = id) Then

                Dim poistettava = tietokanta.hlp_SopimusFormaatti.FirstOrDefault(Function(x) x.SFOId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_SopimusFormaatti.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
