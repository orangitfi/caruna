Imports System.ComponentModel

Public Class PuustonPoisto

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_PuustonPoisto)

        Dim tietokanta = New DAL.PuustonPoisto()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_PuustonPoisto

        Dim tietokanta = New DAL.PuustonPoisto()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_PuustonPoisto) As Entities.hlp_PuustonPoisto

        Dim tietokanta = New DAL.PuustonPoisto()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_PuustonPoisto) As Entities.hlp_PuustonPoisto

        Dim tietokanta = New DAL.PuustonPoisto()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(PPOId As Integer) As Entities.hlp_PuustonPoisto

        Dim tietokanta = New DAL.PuustonPoisto()
        Return tietokanta.Poista(PPOId)

    End Function

#End Region

End Class
