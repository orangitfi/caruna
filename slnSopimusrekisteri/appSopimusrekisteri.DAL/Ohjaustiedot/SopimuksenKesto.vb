Imports System.Data.SqlTypes

Partial Public Class SopimuksenKesto

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_SopimuksenKesto

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimuksenKesto.FirstOrDefault(Function(x) x.SKEId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_SopimuksenKesto)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SopimuksenKesto.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_SopimuksenKesto) As Entities.hlp_SopimuksenKesto

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.SKELuoja = "Tuntematon"
            lisattava.SKELuotu = SqlDateTime.MinValue
            lisattava.SKEPaivitetty = SqlDateTime.MinValue
            lisattava.SKEPaivittaja = "Tuntematon"

            tietokanta.hlp_SopimuksenKesto.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_SopimuksenKesto) As Entities.hlp_SopimuksenKesto

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.SKEId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_SopimuksenKesto.FirstOrDefault(Function(x) x.SKEId = muokattava.SKEId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.SKELuoja = "Tuntematon"
                kantaversio.SKELuotu = SqlDateTime.MinValue
                kantaversio.SKEPaivitetty = SqlDateTime.MinValue
                kantaversio.SKEPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_SopimuksenKesto

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Sopimus.Any(Function(x) x.SOPKestoId = id) Then

                Dim poistettava = tietokanta.hlp_SopimuksenKesto.FirstOrDefault(Function(x) x.SKEId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_SopimuksenKesto.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
