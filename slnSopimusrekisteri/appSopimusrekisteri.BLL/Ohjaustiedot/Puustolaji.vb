Imports System.ComponentModel

Public Class Puustolaji

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Puustolaji)

        Dim tietokanta = New DAL.Puustolaji()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Puustolaji

        Dim tietokanta = New DAL.Puustolaji()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Puustolaji) As Entities.hlp_Puustolaji

        Dim tietokanta = New DAL.Puustolaji()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Puustolaji) As Entities.hlp_Puustolaji

        Dim tietokanta = New DAL.Puustolaji()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(PLAId As Integer) As Entities.hlp_Puustolaji

        Dim tietokanta = New DAL.Puustolaji()
        Return tietokanta.Poista(PLAId)

    End Function

#End Region

End Class
