Imports System.ComponentModel

Public Class Kyla

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Kyla)

        Dim tietokanta = New DAL.Kyla()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Kyla

        Dim tietokanta = New DAL.Kyla()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Kyla) As Entities.hlp_Kyla

        Dim tietokanta = New DAL.Kyla()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Kyla) As Entities.hlp_Kyla

        Dim tietokanta = New DAL.Kyla()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(KYLId As Integer) As Entities.hlp_Kyla

        Dim tietokanta = New DAL.Kyla()
        Return tietokanta.Poista(KYLId)

    End Function

#End Region

End Class
