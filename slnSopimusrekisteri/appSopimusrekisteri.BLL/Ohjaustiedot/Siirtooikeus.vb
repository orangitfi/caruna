Imports System.ComponentModel

Public Class Siirtooikeus

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_Siirtooikeus)

        Dim tietokanta = New DAL.Siirtooikeus()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_Siirtooikeus

        Dim tietokanta = New DAL.Siirtooikeus()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_Siirtooikeus) As Entities.hlp_Siirtooikeus

        Dim tietokanta = New DAL.Siirtooikeus()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_Siirtooikeus) As Entities.hlp_Siirtooikeus

        Dim tietokanta = New DAL.Siirtooikeus()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(SOIId As Integer) As Entities.hlp_SiirtoOikeus

        Dim tietokanta = New DAL.Siirtooikeus()
        Return tietokanta.Poista(SOIId)

    End Function

#End Region

End Class
