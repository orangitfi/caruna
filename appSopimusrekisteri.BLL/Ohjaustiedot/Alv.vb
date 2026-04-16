Imports System.ComponentModel

Public Class Alv

  Private _konteksti As DTO.DataKonteksti

  Public Sub New()

  End Sub

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
  Public Function Hae() As List(Of DTO.Alv)

    Dim tietokanta = New DAL.Alv()
    Return tietokanta.Hae()

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function Hae(id As Integer) As DTO.Alv

    Dim tietokanta = New DAL.Alv()
    Return tietokanta.Hae(id)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function HaeOletusAlvId() As Integer?

    Dim tietokanta = New DAL.Alv()

    Dim alv As DTO.Alv = tietokanta.HaeOletusAlv()

    If Not alv Is Nothing Then
      Return alv.Id
    End If

    Return Nothing

  End Function

#End Region

#Region "Muokkausmetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
  Public Function Lisaa(alv As DTO.Alv) As DTO.Alv

    Dim tietokanta = New DAL.Alv()

    alv.Luotu = Date.Now
    alv.Luoja = _konteksti.Kayttajatunnus
    alv.Paivitetty = Date.Now
    alv.Paivittaja = _konteksti.Kayttajatunnus

    Return tietokanta.Lisaa(alv)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
  Public Function Muokkaa(alv As DTO.Alv) As DTO.Alv

    Dim tietokanta = New DAL.Alv()

    alv.Paivitetty = Date.Now
    alv.Paivittaja = _konteksti.Kayttajatunnus

    Return tietokanta.Muokkaa(alv)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
  Public Function Poista(id As Integer) As DTO.Alv

    Dim tietokanta = New DAL.Alv()
    Return tietokanta.Poista(id)

  End Function

#End Region

End Class