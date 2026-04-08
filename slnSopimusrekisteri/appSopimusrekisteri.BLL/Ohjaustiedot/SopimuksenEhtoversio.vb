Imports System.ComponentModel

Public Class SopimuksenEhtoversio

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_SopimuksenEhtoversio)

        Dim tietokanta = New DAL.SopimuksenEhtoversio()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_SopimuksenEhtoversio

        Dim tietokanta = New DAL.SopimuksenEhtoversio()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_SopimuksenEhtoversio) As Entities.hlp_SopimuksenEhtoversio

        Dim tietokanta = New DAL.SopimuksenEhtoversio()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_SopimuksenEhtoversio) As Entities.hlp_SopimuksenEhtoversio

        Dim tietokanta = New DAL.SopimuksenEhtoversio()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(SEHId As Integer) As Entities.hlp_SopimuksenEhtoversio

        Dim tietokanta = New DAL.SopimuksenEhtoversio()
        Return tietokanta.Poista(SEHId)

    End Function

#End Region

End Class
