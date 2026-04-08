Imports System.Data.SqlTypes

Partial Public Class SopimuksenAlaluokka

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_SopimuksenAlaluokka

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimuksenAlaluokka.FirstOrDefault(Function(x) x.SALId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_SopimuksenAlaluokka)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimuksenAlaluokka.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_SopimuksenAlaluokka) As Entities.hlp_SopimuksenAlaluokka

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.SALLuoja = "Tuntematon"
            lisattava.SALLuotu = SqlDateTime.MinValue
            lisattava.SALPaivitetty = SqlDateTime.MinValue
            lisattava.SALPaivittaja = "Tuntematon"

            tietokanta.hlp_SopimuksenAlaluokka.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_SopimuksenAlaluokka) As Entities.hlp_SopimuksenAlaluokka

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.SALId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_SopimuksenAlaluokka.FirstOrDefault(Function(x) x.SALId = muokattava.SALId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.SALLuoja = "Tuntematon"
                kantaversio.SALLuotu = SqlDateTime.MinValue
                kantaversio.SALPaivitetty = SqlDateTime.MinValue
                kantaversio.SALPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_SopimuksenAlaluokka

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Sopimus.Any(Function(x) x.SOPSopimuksenAlaluokkaId = id) Then

                Dim poistettava = tietokanta.hlp_SopimuksenAlaluokka.FirstOrDefault(Function(x) x.SALId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_SopimuksenAlaluokka.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
