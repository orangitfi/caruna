Imports System.ComponentModel

Public Class Infopallura

  Private _konteksti As DTO.DataKonteksti

  Public Sub New()

  End Sub

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
  Public Function Hae() As List(Of DTO.Infopallura)

    Dim tietokanta = New DAL.Infopallura()
    Return tietokanta.Hae()

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function Hae(id As Integer) As DTO.Infopallura

    Dim tietokanta = New DAL.Infopallura()
    Return tietokanta.Hae(id)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function HaeLomakkeenPallurat(lomake As String) As List(Of DTO.Infopallura)

    Dim tietokanta = New DAL.Infopallura()
    Return tietokanta.HaeLomakkeenPallurat(lomake)

  End Function

#End Region

#Region "Muokkausmetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
  Public Function Lisaa(infopallura As DTO.Infopallura) As DTO.Infopallura

    Dim tietokanta = New DAL.Infopallura()

    infopallura.Luotu = Date.Now
    infopallura.Luoja = _konteksti.Kayttajatunnus
    infopallura.Paivitetty = Date.Now
    infopallura.Paivittaja = _konteksti.Kayttajatunnus

    Return tietokanta.Lisaa(infopallura)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
  Public Function Muokkaa(infopallura As DTO.Infopallura) As DTO.Infopallura

    Dim tietokanta = New DAL.Infopallura()

    infopallura.Paivitetty = Date.Now
    infopallura.Paivittaja = _konteksti.Kayttajatunnus

    Return tietokanta.Muokkaa(infopallura)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
  Public Function Poista(id As Integer) As DTO.Infopallura

    Dim tietokanta = New DAL.Infopallura()
    Return tietokanta.Poista(id)

  End Function

#End Region

End Class
