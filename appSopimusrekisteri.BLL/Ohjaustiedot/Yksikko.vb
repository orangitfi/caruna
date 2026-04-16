Public Class Yksikko

#Region "Hakumetodit"

    Public Function HaeYksikko(id As Integer) As Entities.hlp_Yksikko

        Dim tietokanta = New DAL.Yksikko()
        Return tietokanta.HaeYksikko(id)

    End Function

    Public Function HaeYksikot() As List(Of Entities.hlp_Yksikko)

        Dim tietokanta = New DAL.Yksikko()
        Return tietokanta.HaeYksikot()

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function LisaaYksikko(lisattava As Entities.hlp_Yksikko) As Entities.hlp_Yksikko

        Dim tietokanta = New DAL.Yksikko()
        Return tietokanta.LisaaYksikko(lisattava)

    End Function

    Public Function MuokkaaYksikkoa(muokattava As Entities.hlp_Yksikko) As Entities.hlp_Yksikko

        Dim tietokanta = New DAL.Yksikko()
        Return tietokanta.MuokkaaYksikkoa(muokattava)

    End Function

    Public Function PoistaYksikko(YKSId As Integer) As Entities.hlp_Yksikko

        Dim tietokanta = New DAL.Yksikko()
        Return tietokanta.PoistaYksikko(YKSId)

    End Function

#End Region

End Class
