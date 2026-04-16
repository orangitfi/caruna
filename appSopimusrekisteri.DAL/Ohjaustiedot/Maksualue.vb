Imports System.Data.SqlTypes

Partial Public Class Maksualue

#Region "Hakumetodit"

    Public Function HaeMaksualue(id As Integer) As Entities.hlp_Maksualue

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Maksualue.FirstOrDefault(Function(x) x.MALId = id)

        End Using

    End Function

    Public Function HaeMaksualueet() As List(Of Entities.hlp_Maksualue)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Maksualue.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"


    Public Function LisaaMaksualue(lisattava As Entities.hlp_Maksualue) As Entities.hlp_Maksualue

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.MALLuoja = "Tuntematon"
            lisattava.MALLuotu = SqlDateTime.MinValue
            lisattava.MALPaivitetty = SqlDateTime.MinValue
            lisattava.MALPaivittaja = "Tuntematon"

            tietokanta.hlp_Maksualue.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function MuokkaaMaksualuetta(muokattava As Entities.hlp_Maksualue) As Entities.hlp_Maksualue

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.MALId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Maksualue.FirstOrDefault(Function(x) x.MALId = muokattava.MALId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.MALLuoja = "Tuntematon"
                kantaversio.MALLuotu = SqlDateTime.MinValue
                kantaversio.MALPaivitetty = SqlDateTime.MinValue
                kantaversio.MALPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function PoistaMaksualue(id As Integer) As Entities.hlp_Maksualue

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.KorvausHinnasto.Any(Function(x) x.KHIMaksuAlueId = id) Then
                If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORMaksualueId = id) Then

                    Dim poistettava = tietokanta.hlp_Maksualue.FirstOrDefault(Function(x) x.MALId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Maksualue.Remove(poistettava)
                        tietokanta.SaveChanges()
                        Return poistettava

                    End If

                End If
            End If


        End Using

        Return Nothing

    End Function

#End Region

End Class
