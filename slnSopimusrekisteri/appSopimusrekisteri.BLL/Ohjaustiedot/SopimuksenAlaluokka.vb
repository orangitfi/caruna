Imports System.ComponentModel

Public Class SopimuksenAlaluokka

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_SopimuksenAlaluokka)

        Dim tietokanta = New DAL.SopimuksenAlaluokka()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_SopimuksenAlaluokka

        Dim tietokanta = New DAL.SopimuksenAlaluokka()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_SopimuksenAlaluokka) As Entities.hlp_SopimuksenAlaluokka

        Dim tietokanta = New DAL.SopimuksenAlaluokka()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_SopimuksenAlaluokka) As Entities.hlp_SopimuksenAlaluokka

        Dim tietokanta = New DAL.SopimuksenAlaluokka()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(SALId As Integer) As Entities.hlp_SopimuksenAlaluokka

        Dim tietokanta = New DAL.SopimuksenAlaluokka()
        Return tietokanta.Poista(SALId)

    End Function

#End Region

End Class
