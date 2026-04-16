Imports System.ComponentModel

Public Class SopimuksenKesto

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_SopimuksenKesto)

        Dim tietokanta = New DAL.SopimuksenKesto()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_SopimuksenKesto

        Dim tietokanta = New DAL.SopimuksenKesto()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(lisattava As Entities.hlp_SopimuksenKesto) As Entities.hlp_SopimuksenKesto

        Dim tietokanta = New DAL.SopimuksenKesto()
        Return tietokanta.Lisaa(lisattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_SopimuksenKesto) As Entities.hlp_SopimuksenKesto

        Dim tietokanta = New DAL.SopimuksenKesto()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(SKEId As Integer) As Entities.hlp_SopimuksenKesto

        Dim tietokanta = New DAL.SopimuksenKesto()
        Return tietokanta.Poista(SKEId)

    End Function

#End Region

End Class
