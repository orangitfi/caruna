Imports System.ComponentModel

Public Class Julkisuusaste

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Julkisuusaste)

        Dim tietokanta = New DAL.Julkisuusaste()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Julkisuusaste

        Dim tietokanta = New DAL.Julkisuusaste()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Julkisuusaste) As Entities.hlp_Julkisuusaste

        Dim tietokanta = New DAL.Julkisuusaste()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Julkisuusaste) As Entities.hlp_Julkisuusaste

        Dim tietokanta = New DAL.Julkisuusaste()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(JASId As Integer) As Entities.hlp_Julkisuusaste

        Dim tietokanta = New DAL.Julkisuusaste()
        Return tietokanta.Poista(JASId)

    End Function

#End Region

End Class
