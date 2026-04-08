Imports System.ComponentModel

Partial Public Class KirjanpidonTili

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Kirjanpidontili)

        Dim tietokanta = New DAL.KirjanpidonTili()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Kirjanpidontili

        Dim tietokanta = New DAL.KirjanpidonTili()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Kirjanpidontili) As Entities.hlp_Kirjanpidontili

        Dim tietokanta = New DAL.KirjanpidonTili()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Kirjanpidontili) As Entities.hlp_Kirjanpidontili

        Dim tietokanta = New DAL.KirjanpidonTili()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(KPTId As Integer) As Entities.hlp_Kirjanpidontili

        Dim tietokanta = New DAL.KirjanpidonTili()
        Return tietokanta.Poista(KPTId)

    End Function

#End Region

End Class
