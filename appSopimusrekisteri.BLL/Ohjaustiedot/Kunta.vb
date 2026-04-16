Imports System.ComponentModel

Public Class Kunta

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Kunta)

        Dim tietokanta = New DAL.Kunta()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Kunta

        Dim tietokanta = New DAL.Kunta()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Kunta) As Entities.hlp_Kunta

        Dim tietokanta = New DAL.Kunta()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Kunta) As Entities.hlp_Kunta

        Dim tietokanta = New DAL.Kunta()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(KKuntaId As Integer) As Entities.hlp_Kunta

        Dim tietokanta = New DAL.Kunta()
        Return tietokanta.Poista(KKuntaId)

    End Function

#End Region

End Class
