Imports System.ComponentModel

Public Class MaaraalaTarkenne

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_MaaraalaTarkenne)

        Dim tietokanta = New DAL.MaaraalaTarkenne()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_MaaraalaTarkenne

        Dim tietokanta = New DAL.MaaraalaTarkenne()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_MaaraalaTarkenne) As Entities.hlp_MaaraalaTarkenne

        Dim tietokanta = New DAL.MaaraalaTarkenne()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_MaaraalaTarkenne) As Entities.hlp_MaaraalaTarkenne

        Dim tietokanta = New DAL.MaaraalaTarkenne()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(MATId As Integer) As Entities.hlp_MaaraAlaTarkenne

        Dim tietokanta = New DAL.Maaraalatarkenne()
        Return tietokanta.Poista(MATId)

    End Function

#End Region

End Class
