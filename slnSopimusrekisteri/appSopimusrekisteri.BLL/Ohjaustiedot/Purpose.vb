Imports System.ComponentModel

Public Class Purpose

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Purpose)

        Dim tietokanta = New DAL.Purpose()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Purpose

        Dim tietokanta = New DAL.Purpose()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Purpose) As Entities.hlp_Purpose

        Dim tietokanta = New DAL.Purpose()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Purpose) As Entities.hlp_Purpose

        Dim tietokanta = New DAL.Purpose()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(PURId As Integer) As Entities.hlp_Purpose

        Dim tietokanta = New DAL.Purpose()
        Return tietokanta.Poista(PURId)

    End Function

#End Region

End Class
