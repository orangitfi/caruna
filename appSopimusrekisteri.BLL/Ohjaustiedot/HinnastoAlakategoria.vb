Imports System.ComponentModel

Partial Public Class HinnastonAlakategoria

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_HinnastoAlakategoria)

        Dim tietokanta = New DAL.HinnastoAlakategoria()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_HinnastoAlakategoria

        Dim tietokanta = New DAL.HinnastoAlakategoria()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_HinnastoAlakategoria) As Entities.hlp_HinnastoAlakategoria

        Dim tietokanta = New DAL.HinnastoAlakategoria()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_HinnastoAlakategoria) As Entities.hlp_HinnastoAlakategoria

        Dim tietokanta = New DAL.HinnastoAlakategoria()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(HAKId As Integer) As Entities.hlp_HinnastoAlakategoria

        Dim tietokanta = New DAL.HinnastoAlakategoria()
        Return tietokanta.Poista(HAKId)

    End Function

#End Region

End Class
