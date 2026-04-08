Imports System.ComponentModel

Public Class Indeksityyppi

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Indeksityyppi)

        Dim tietokanta = New DAL.Indeksityyppi()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Indeksityyppi

        Dim tietokanta = New DAL.Indeksityyppi()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Indeksityyppi) As Entities.hlp_Indeksityyppi

        Dim tietokanta = New DAL.Indeksityyppi()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Indeksityyppi) As Entities.hlp_Indeksityyppi

        Dim tietokanta = New DAL.Indeksityyppi()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(ITYId As Integer) As Entities.hlp_Indeksityyppi

        Dim tietokanta = New DAL.Indeksityyppi()
        Return tietokanta.Poista(ITYId)

    End Function

#End Region

End Class
