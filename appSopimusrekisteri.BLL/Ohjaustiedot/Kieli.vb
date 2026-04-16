Imports System.ComponentModel

Public Class Kieli

#Region "Hakumetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
  Public Function Hae() As List(Of Entities.hlp_Kieli)

    Dim tietokanta = New DAL.Kieli()
    Return tietokanta.Hae()

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function Hae(id As Integer) As Entities.hlp_Kieli

    Dim tietokanta = New DAL.Kieli()
    Return tietokanta.Hae(id)

  End Function

#End Region

#Region "Muokkausmetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
  Public Function Lisaa(lisattava As Entities.hlp_Kieli) As Entities.hlp_Kieli

    Dim tietokanta = New DAL.Kieli()
    Return tietokanta.Lisaa(lisattava)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
  Public Function Muokkaa(muokattava As Entities.hlp_Kieli) As Entities.hlp_Kieli

    Dim tietokanta = New DAL.Kieli()
    Return tietokanta.Muokkaa(muokattava)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
  Public Function Poista(id As Integer) As Entities.hlp_Kieli

    Dim tietokanta = New DAL.Kieli()
    Return tietokanta.Poista(id)

  End Function

#End Region

End Class
