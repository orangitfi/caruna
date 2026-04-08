Imports System.ComponentModel

Partial Public Class KirjanpidonKustannuspaikka

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_KirjanpidonKustannuspaikka)

        Dim tietokanta = New DAL.KirjanpidonKustannuspaikka()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_KirjanpidonKustannuspaikka

        Dim tietokanta = New DAL.KirjanpidonKustannuspaikka()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_KirjanpidonKustannuspaikka) As Entities.hlp_KirjanpidonKustannuspaikka

        Dim tietokanta = New DAL.KirjanpidonKustannuspaikka()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_KirjanpidonKustannuspaikka) As Entities.hlp_KirjanpidonKustannuspaikka

        Dim tietokanta = New DAL.KirjanpidonKustannuspaikka()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(KPKId As Integer) As Entities.hlp_KirjanpidonKustannuspaikka

        Dim tietokanta = New DAL.KirjanpidonKustannuspaikka()
        Return tietokanta.Poista(KPKId)

    End Function

#End Region

End Class
