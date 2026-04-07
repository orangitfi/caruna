Imports System.ComponentModel

Public Class Sopimusformaatti

#Region "Hakumetodit"
    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_SopimusFormaatti)

        Dim tietokanta = New DAL.Sopimusformaatti()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_SopimusFormaatti

        Dim tietokanta = New DAL.Sopimusformaatti()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(lisattava As Entities.hlp_SopimusFormaatti) As Entities.hlp_SopimusFormaatti

        Dim tietokanta = New DAL.Sopimusformaatti()
        Return tietokanta.Lisaa(lisattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_SopimusFormaatti) As Entities.hlp_SopimusFormaatti

        Dim tietokanta = New DAL.Sopimusformaatti()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(SFOId As Integer) As Entities.hlp_SopimusFormaatti

        Dim tietokanta = New DAL.Sopimusformaatti()
        Return tietokanta.Poista(SFOId)

    End Function

#End Region

End Class
