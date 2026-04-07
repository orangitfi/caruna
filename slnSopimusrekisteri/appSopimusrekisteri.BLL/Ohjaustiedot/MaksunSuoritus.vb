Imports System.ComponentModel

Public Class MaksunSuoritus

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_MaksunSuoritus)

        Dim tietokanta = New DAL.MaksunSuoritus()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_MaksunSuoritus

        Dim tietokanta = New DAL.MaksunSuoritus()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_MaksunSuoritus) As Entities.hlp_MaksunSuoritus

        Dim tietokanta = New DAL.MaksunSuoritus()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_MaksunSuoritus) As Entities.hlp_MaksunSuoritus

        Dim tietokanta = New DAL.MaksunSuoritus()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(MSUId As Integer) As Entities.hlp_MaksunSuoritus

        Dim tietokanta = New DAL.MaksunSuoritus()
        Return tietokanta.Poista(MSUId)

    End Function

#End Region

End Class
