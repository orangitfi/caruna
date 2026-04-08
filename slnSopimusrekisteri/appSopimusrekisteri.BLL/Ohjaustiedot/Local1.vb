Imports System.ComponentModel

Public Class Local1

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Local1)

        Dim tietokanta = New DAL.Local1()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Local1

        Dim tietokanta = New DAL.Local1()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Local1) As Entities.hlp_Local1

        Dim tietokanta = New DAL.Local1()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Local1) As Entities.hlp_Local1

        Dim tietokanta = New DAL.Local1()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(LOCId As Integer) As Entities.hlp_Local1

        Dim tietokanta = New DAL.Local1()
        Return tietokanta.Poista(LOCId)

    End Function

#End Region

End Class
