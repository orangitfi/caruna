Imports System.Data.SqlTypes

Partial Public Class KirjanpidonKustannuspaikka

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_KirjanpidonKustannuspaikka

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_KirjanpidonKustannuspaikka.FirstOrDefault(Function(x) x.KPKId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_KirjanpidonKustannuspaikka)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_KirjanpidonKustannuspaikka.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_KirjanpidonKustannuspaikka) As Entities.hlp_KirjanpidonKustannuspaikka

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.KPKLuoja = "Tuntematon"
            lisattava.KPKLuotu = SqlDateTime.MinValue
            lisattava.KPKPaivitetty = SqlDateTime.MinValue
            lisattava.KPKPaivittaja = "Tuntematon"

            tietokanta.hlp_KirjanpidonKustannuspaikka.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_KirjanpidonKustannuspaikka) As Entities.hlp_KirjanpidonKustannuspaikka

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.KPKId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_KirjanpidonKustannuspaikka.FirstOrDefault(Function(x) x.KPKId = muokattava.KPKId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.KPKLuoja = "Tuntematon"
                kantaversio.KPKLuotu = SqlDateTime.MinValue
                kantaversio.KPKPaivitetty = SqlDateTime.MinValue
                kantaversio.KPKPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_KirjanpidonKustannuspaikka

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORKirjanpidonKustannuspaikkaId = id) And Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRKirjanpidonKustannuspaikkaId = id) Then

                Dim poistettava = tietokanta.hlp_KirjanpidonKustannuspaikka.FirstOrDefault(Function(x) x.KPKId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_KirjanpidonKustannuspaikka.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
