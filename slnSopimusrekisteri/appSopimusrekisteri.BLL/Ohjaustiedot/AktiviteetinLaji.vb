Imports System.ComponentModel

Public Class AktiviteetinLaji

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_AktiviteetinLaji)

        Dim tietokanta = New DAL.AktiviteetinLaji()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_AktiviteetinLaji

        Dim tietokanta = New DAL.AktiviteetinLaji()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_AktiviteetinLaji) As Entities.hlp_AktiviteetinLaji

        Dim tietokanta = New DAL.AktiviteetinLaji()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_AktiviteetinLaji) As Entities.hlp_AktiviteetinLaji

        Dim tietokanta = New DAL.AktiviteetinLaji()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(ALId As Integer) As Entities.hlp_AktiviteetinLaji

        Dim tietokanta = New DAL.AktiviteetinLaji()
        Return tietokanta.Poista(ALId)

    End Function

#End Region

End Class
