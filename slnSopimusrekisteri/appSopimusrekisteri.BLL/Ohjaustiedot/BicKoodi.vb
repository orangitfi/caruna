Imports System.ComponentModel

Public Class BicKoodi

#Region "Hakumetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
  Public Function Hae() As List(Of Entities.hlp_BicKoodi)

    Dim tietokanta = New DAL.BicKoodi()
    Return tietokanta.Hae()

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function Hae(id As Integer) As Entities.hlp_BicKoodi

    Dim tietokanta = New DAL.BicKoodi()
    Return tietokanta.Hae(id)

  End Function

#End Region

#Region "Muokkausmetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
  Public Function Lisaa(tunnisteyksikonTyyppi As Entities.hlp_BicKoodi) As Entities.hlp_BicKoodi

    Dim tietokanta = New DAL.BicKoodi()
    Return tietokanta.Lisaa(tunnisteyksikonTyyppi)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
  Public Function Muokkaa(muokattava As Entities.hlp_BicKoodi) As Entities.hlp_BicKoodi

    Dim tietokanta = New DAL.BicKoodi()
    Return tietokanta.Muokkaa(muokattava)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
  Public Function Poista(DFRId As Integer) As Entities.hlp_BicKoodi

    Dim tietokanta = New DAL.BicKoodi()
    Return tietokanta.Poista(DFRId)

  End Function

#End Region

End Class
