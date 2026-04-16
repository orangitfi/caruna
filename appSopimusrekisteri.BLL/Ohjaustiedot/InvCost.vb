Imports System.ComponentModel

Public Class InvCost

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_InvCost)

        Dim tietokanta = New DAL.InvCost()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_InvCost

        Dim tietokanta = New DAL.InvCost()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_InvCost) As Entities.hlp_InvCost

        Dim tietokanta = New DAL.InvCost()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_InvCost) As Entities.hlp_InvCost

        Dim tietokanta = New DAL.InvCost()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(ICOId As Integer) As Entities.hlp_InvCost

        Dim tietokanta = New DAL.InvCost()
        Return tietokanta.Poista(ICOId)

    End Function

#End Region

End Class
