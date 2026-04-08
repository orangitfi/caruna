Public Class TunnisteyksikonTyyppi

#Region "Hakumetodit"
    
    Public Function HaeTunnisteyksikonTyyppi(id As Integer) As Entities.hlp_TunnisteyksikkoTyyppi

        Dim tietokanta = New DAL.TunnisteyksikonTyyppi()
        Return tietokanta.HaeTunnisteyksikonTyyppi(id)

    End Function

    Public Function HaeTunnisteyksikonTyypit() As List(Of Entities.hlp_TunnisteyksikkoTyyppi)

        Dim tietokanta = New DAL.TunnisteyksikonTyyppi()
        Return tietokanta.HaeTunnisteyksikonTyypit()

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function LisaaTunnisteyksikonTyyppi(tunnisteyksikonTyyppi As Entities.hlp_TunnisteyksikkoTyyppi) As Entities.hlp_TunnisteyksikkoTyyppi

        Dim tietokanta = New DAL.TunnisteyksikonTyyppi()
        Return tietokanta.LisaaTunnisteyksikonTyyppi(TunnisteyksikonTyyppi)

    End Function

    Public Function MuokkaaTunnisteyksikonTyyppiä(tunnisteyksikonTyyppi As Entities.hlp_TunnisteyksikkoTyyppi) As Entities.hlp_TunnisteyksikkoTyyppi

        Dim tietokanta = New DAL.TunnisteyksikonTyyppi()
        Return tietokanta.MuokkaaTunnisteyksikonTyyppiä(tunnisteyksikonTyyppi)

    End Function

    Public Function PoistaTunnisteyksikonTyyppi(TTYId As Integer) As Entities.hlp_TunnisteyksikkoTyyppi

        Dim tietokanta = New DAL.TunnisteyksikonTyyppi()
        Return tietokanta.PoistaTunnisteyksikonTyyppi(TTYId)

    End Function

#End Region

End Class
