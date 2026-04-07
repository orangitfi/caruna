Public Class Maksualue

#Region "Hakumetodit"

    Public Function HaeMaksualue(id As Integer) As Entities.hlp_Maksualue

        Dim tietokanta = New DAL.Maksualue()
        Return tietokanta.HaeMaksualue(id)

    End Function

    Public Function HaeMaksualueet() As List(Of Entities.hlp_Maksualue)

        Dim tietokanta = New DAL.Maksualue()
        Return tietokanta.HaeMaksualueet()

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function LisaaMaksualue(tunnisteyksikonTyyppi As Entities.hlp_Maksualue) As Entities.hlp_Maksualue

        Dim tietokanta = New DAL.Maksualue()
        Return tietokanta.LisaaMaksualue(tunnisteyksikonTyyppi)

    End Function

    Public Function MuokkaaMaksualuetta(tunnisteyksikonTyyppi As Entities.hlp_Maksualue) As Entities.hlp_Maksualue

        Dim tietokanta = New DAL.Maksualue()
        Return tietokanta.MuokkaaMaksualuetta(tunnisteyksikonTyyppi)

    End Function

    Public Function PoistaMaksualue(MALId As Integer) As Entities.hlp_Maksualue

        Dim tietokanta = New DAL.Maksualue()
        Return tietokanta.PoistaMaksualue(MALId)

    End Function

#End Region

End Class
