Imports System.Data.SqlTypes

Partial Public Class SopimuksenEhtoversio

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_SopimuksenEhtoversio

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimuksenEhtoversio.FirstOrDefault(Function(x) x.SEHId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_SopimuksenEhtoversio)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimuksenEhtoversio.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_SopimuksenEhtoversio) As Entities.hlp_SopimuksenEhtoversio

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.SEHLuoja = "Tuntematon"
            lisattava.SEHLuotu = SqlDateTime.MinValue
            lisattava.SEHPaivitetty = SqlDateTime.MinValue
            lisattava.SEHPaivittaja = "Tuntematon"

            tietokanta.hlp_SopimuksenEhtoversio.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_SopimuksenEhtoversio) As Entities.hlp_SopimuksenEhtoversio

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.SEHId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_SopimuksenEhtoversio.FirstOrDefault(Function(x) x.SEHId = muokattava.SEHId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.SEHLuoja = "Tuntematon"
                kantaversio.SEHLuotu = SqlDateTime.MinValue
                kantaversio.SEHPaivitetty = SqlDateTime.MinValue
                kantaversio.SEHPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_SopimuksenEhtoversio

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Sopimus.Any(Function(x) x.SOPSopimuksenEhtoversioId = id) Then

                Dim poistettava = tietokanta.hlp_SopimuksenEhtoversio.FirstOrDefault(Function(x) x.SEHId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_SopimuksenEhtoversio.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
