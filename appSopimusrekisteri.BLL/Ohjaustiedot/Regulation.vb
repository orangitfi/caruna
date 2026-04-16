Imports System.ComponentModel

Public Class Regulation

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Regulation)

        Dim tietokanta = New DAL.Regulation()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Regulation

        Dim tietokanta = New DAL.Regulation()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Regulation) As Entities.hlp_Regulation

        Dim tietokanta = New DAL.Regulation()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Regulation) As Entities.hlp_Regulation

        Dim tietokanta = New DAL.Regulation()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(REGId As Integer) As Entities.hlp_Regulation

        Dim tietokanta = New DAL.Regulation()
        Return tietokanta.Poista(REGId)

    End Function

#End Region

End Class
