Imports System.ComponentModel

Public Class Asiakirjatarkenne

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Asiakirjatarkenne)

        Dim tietokanta = New DAL.Asiakirjatarkenne()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Asiakirjatarkenne

        Dim tietokanta = New DAL.Asiakirjatarkenne()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Asiakirjatarkenne) As Entities.hlp_Asiakirjatarkenne

        Dim tietokanta = New DAL.Asiakirjatarkenne()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Asiakirjatarkenne) As Entities.hlp_Asiakirjatarkenne

        Dim tietokanta = New DAL.Asiakirjatarkenne()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(ATAd As Integer) As Entities.hlp_AsiakirjaTarkenne

        Dim tietokanta = New DAL.AsiakirjaTarkenne()
        Return tietokanta.Poista(ATAd)

    End Function

#End Region

End Class
