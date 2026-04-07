Imports System.Data.SqlTypes

Partial Public Class HinnastonKategoria

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_HinnastoKategoria

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_HinnastoKategoria.FirstOrDefault(Function(x) x.HKAId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_HinnastoKategoria)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_HinnastoKategoria.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_HinnastoKategoria) As Entities.hlp_HinnastoKategoria

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.HKALuoja = "Tuntematon"
            lisattava.HKALuotu = SqlDateTime.MinValue
            lisattava.HKAPaivitetty = SqlDateTime.MinValue
            lisattava.HKAPaivittaja = "Tuntematon"

            tietokanta.hlp_HinnastoKategoria.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_HinnastoKategoria) As Entities.hlp_HinnastoKategoria

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.HKAId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_HinnastoKategoria.FirstOrDefault(Function(x) x.HKAId = muokattava.HKAId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.HKALuoja = "Tuntematon"
                kantaversio.HKALuotu = SqlDateTime.MinValue
                kantaversio.HKAPaivitetty = SqlDateTime.MinValue
                kantaversio.HKAPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_HinnastoKategoria

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.KorvausHinnasto.Any(Function(x) x.KHIHinnastoKategoriaId = id) Then

                Dim poistettava = tietokanta.hlp_HinnastoKategoria.FirstOrDefault(Function(x) x.HKAId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_HinnastoKategoria.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
