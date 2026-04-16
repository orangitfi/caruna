Imports System.Data.SqlTypes

Partial Public Class TunnisteyksikonTyyppi

#Region "Hakumetodit"

    Public Function HaeTunnisteyksikonTyyppi(id As Integer) As Entities.hlp_TunnisteyksikkoTyyppi

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_TunnisteyksikkoTyyppi.FirstOrDefault(Function(x) x.TTYId = id)

        End Using

    End Function

    Public Function HaeTunnisteyksikonTyypit() As List(Of Entities.hlp_TunnisteyksikkoTyyppi)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_TunnisteyksikkoTyyppi.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

  
    Public Function LisaaTunnisteyksikonTyyppi(tunnisteyksikonTyyppi As Entities.hlp_TunnisteyksikkoTyyppi) As Entities.hlp_TunnisteyksikkoTyyppi

        If tunnisteyksikonTyyppi Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()
            
            tunnisteyksikonTyyppi.TTYLuoja = "Tuntematon"
            tunnisteyksikonTyyppi.TTYLuotu = SqlDateTime.MinValue
            tunnisteyksikonTyyppi.TTYPaivitetty = SqlDateTime.MinValue
            tunnisteyksikonTyyppi.TTYPaivittaja = "Tuntematon"

            tietokanta.hlp_TunnisteyksikkoTyyppi.Add(tunnisteyksikonTyyppi)
            tietokanta.SaveChanges()
            Return tunnisteyksikonTyyppi

        End Using

    End Function

    Public Function MuokkaaTunnisteyksikonTyyppiä(tunnisteyksikonTyyppi As Entities.hlp_TunnisteyksikkoTyyppi) As Entities.hlp_TunnisteyksikkoTyyppi

        If tunnisteyksikonTyyppi Is Nothing Then
            Return Nothing
        Else
            If tunnisteyksikonTyyppi.TTYId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim muokattava = tietokanta.hlp_TunnisteyksikkoTyyppi.FirstOrDefault(Function(x) x.TTYId = tunnisteyksikonTyyppi.TTYId)

            If Not muokattava Is Nothing Then

                tietokanta.Entry(muokattava).CurrentValues.SetValues(tunnisteyksikonTyyppi)
                muokattava.TTYLuoja = "Tuntematon"
                muokattava.TTYLuotu = SqlDateTime.MinValue
                muokattava.TTYPaivitetty = SqlDateTime.MinValue
                muokattava.TTYPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return muokattava

            Else

                Return Nothing

            End If
            
        End Using
        
    End Function

    Public Function PoistaTunnisteyksikonTyyppi(id As Integer) As Entities.hlp_TunnisteyksikkoTyyppi

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Tunnisteyksikko.Any(Function(x) x.TUYTunnisteyksikkoTyyppiId = id) Then
                
                Dim poistettava = tietokanta.hlp_TunnisteyksikkoTyyppi.FirstOrDefault(Function(x) x.TTYId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_TunnisteyksikkoTyyppi.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
