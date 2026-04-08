Imports System.Data.SqlTypes

Partial Public Class HinnastoAlakategoria

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_HinnastoAlakategoria

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_HinnastoAlakategoria.FirstOrDefault(Function(x) x.HAKId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_HinnastoAlakategoria)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_HinnastoAlakategoria.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_HinnastoAlakategoria) As Entities.hlp_HinnastoAlakategoria

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.HAKLuoja = "Tuntematon"
            lisattava.HAKLuotu = SqlDateTime.MinValue
            lisattava.HAKPaivitetty = SqlDateTime.MinValue
            lisattava.HAKPaivittaja = "Tuntematon"

            tietokanta.hlp_HinnastoAlakategoria.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_HinnastoAlakategoria) As Entities.hlp_HinnastoAlakategoria

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.HAKId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_HinnastoAlakategoria.FirstOrDefault(Function(x) x.HAKId = muokattava.HAKId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.HAKLuoja = "Tuntematon"
                kantaversio.HAKLuotu = SqlDateTime.MinValue
                kantaversio.HAKPaivitetty = SqlDateTime.MinValue
                kantaversio.HAKPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_HinnastoAlakategoria

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.KorvausHinnasto.Any(Function(x) x.KHIHinnastoAlakategoriaId = id) Then

                Dim poistettava = tietokanta.hlp_HinnastoAlakategoria.FirstOrDefault(Function(x) x.HAKId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_HinnastoAlakategoria.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
