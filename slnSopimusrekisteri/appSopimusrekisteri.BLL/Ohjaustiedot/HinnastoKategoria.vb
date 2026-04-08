Imports System.ComponentModel

Partial Public Class HinnastonKategoria

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_HinnastoKategoria)

        Dim tietokanta = New DAL.HinnastonKategoria()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_HinnastoKategoria

        Dim tietokanta = New DAL.HinnastonKategoria()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_HinnastoKategoria) As Entities.hlp_HinnastoKategoria

        Dim tietokanta = New DAL.HinnastonKategoria()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_HinnastoKategoria) As Entities.hlp_HinnastoKategoria

        Dim tietokanta = New DAL.HinnastonKategoria()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(HAKId As Integer) As Entities.hlp_HinnastoKategoria

        Dim tietokanta = New DAL.HinnastonKategoria()
        Return tietokanta.Poista(HAKId)

    End Function

#End Region

End Class
