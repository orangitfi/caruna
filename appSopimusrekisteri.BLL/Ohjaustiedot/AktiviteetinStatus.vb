Imports System.ComponentModel

Public Class AktiviteetinStatus

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_AktiviteetinStatus)

        Dim tietokanta = New DAL.AktiviteetinStatus()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_AktiviteetinStatus

        Dim tietokanta = New DAL.AktiviteetinStatus()
        Return tietokanta.Hae(id)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(nimi As String) As Entities.hlp_AktiviteetinStatus

        Dim tietokanta = New DAL.AktiviteetinStatus()
        Return tietokanta.Hae().Find(Function(x) x.ASAktiviteetinStatus = nimi)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_AktiviteetinStatus) As Entities.hlp_AktiviteetinStatus

        Dim tietokanta = New DAL.AktiviteetinStatus()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_AktiviteetinStatus) As Entities.hlp_AktiviteetinStatus

        Dim tietokanta = New DAL.AktiviteetinStatus()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(ASId As Integer) As Entities.hlp_AktiviteetinStatus

        Dim tietokanta = New DAL.AktiviteetinStatus()
        Return tietokanta.Poista(ASId)

    End Function

#End Region

End Class
