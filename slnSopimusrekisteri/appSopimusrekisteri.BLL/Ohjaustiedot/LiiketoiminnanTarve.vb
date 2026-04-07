Imports System.ComponentModel

Public Class LiiketoiminnanTarve

#Region "Hakumetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Hae() As List(Of Entities.hlp_LiiketoiminnanTarve)

        Dim tietokanta = New DAL.LiiketoiminnanTarve()
        Return tietokanta.Hae()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
    Public Function Hae(id As Integer) As Entities.hlp_LiiketoiminnanTarve

        Dim tietokanta = New DAL.LiiketoiminnanTarve()
        Return tietokanta.Hae(id)

    End Function

#End Region

#Region "Muokkausmetodit"

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
    Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_LiiketoiminnanTarve) As Entities.hlp_LiiketoiminnanTarve

        Dim tietokanta = New DAL.LiiketoiminnanTarve()
        Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
    Public Function Muokkaa(muokattava As Entities.hlp_LiiketoiminnanTarve) As Entities.hlp_LiiketoiminnanTarve

        Dim tietokanta = New DAL.LiiketoiminnanTarve()
        Return tietokanta.Muokkaa(muokattava)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
    Public Function Poista(LTOId As Integer) As Entities.hlp_LiiketoiminnanTarve

        Dim tietokanta = New DAL.LiiketoiminnanTarve()
        Return tietokanta.Poista(LTOId)

    End Function

#End Region

End Class
