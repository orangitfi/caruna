Imports System.Data.SqlTypes

Partial Public Class Yksikko

#Region "Hakumetodit"

    Public Function HaeYksikko(id As Integer) As Entities.hlp_Yksikko

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Yksikko.FirstOrDefault(Function(x) x.YKSId = id)

        End Using

    End Function

    Public Function HaeYksikot() As List(Of Entities.hlp_Yksikko)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Yksikko.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"


    Public Function LisaaYksikko(lisattava As Entities.hlp_Yksikko) As Entities.hlp_Yksikko

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.YKSLuoja = "Tuntematon"
            lisattava.YKSLuotu = SqlDateTime.MinValue
            lisattava.YKSPaivitetty = SqlDateTime.MinValue
            lisattava.YKSPaivittaja = "Tuntematon"

            tietokanta.hlp_Yksikko.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function MuokkaaYksikkoa(muokattava As Entities.hlp_Yksikko) As Entities.hlp_Yksikko

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.YKSId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Yksikko.FirstOrDefault(Function(x) x.YKSId = muokattava.YKSId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.YKSLuoja = "Tuntematon"
                kantaversio.YKSLuotu = SqlDateTime.MinValue
                kantaversio.YKSPaivitetty = SqlDateTime.MinValue
                kantaversio.YKSPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function PoistaYksikko(id As Integer) As Entities.hlp_Yksikko

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.KorvausHinnasto.Any(Function(x) x.KHIYksikkoId = id) Then
                If Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRKokonaispintaAlaYksikkoId = id) Then

                    Dim poistettava = tietokanta.hlp_Yksikko.FirstOrDefault(Function(x) x.YKSId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_Yksikko.Remove(poistettava)
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
