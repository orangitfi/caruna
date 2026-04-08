Imports System.ComponentModel

Public Class Postitiedot

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Postitiedot)

        Dim tietokanta = New DAL.Postitiedot()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Postitiedot

        Dim tietokanta = New DAL.Postitiedot()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Postitiedot) As Entities.hlp_Postitiedot

        Dim tietokanta = New DAL.Postitiedot()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Postitiedot) As Entities.hlp_Postitiedot

        Dim tietokanta = New DAL.Postitiedot()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(PPostiId As Integer) As Entities.hlp_Postitiedot

        Dim tietokanta = New DAL.Postitiedot()
        Return tietokanta.Poista(PPostiId)

    End Function

#End Region

End Class
