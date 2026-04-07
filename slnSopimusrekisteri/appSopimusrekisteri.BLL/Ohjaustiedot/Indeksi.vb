Imports System.ComponentModel

Public Class Indeksi

  Private _konteksti As DTO.DataKonteksti

  Public Sub New()

  End Sub

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
  Public Function Hae() As List(Of DTO.Indeksi)

    Dim tietokanta = New DAL.Indeksi()
    Return tietokanta.Hae()

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function Hae(id As Integer) As DTO.Indeksi

    Dim tietokanta = New DAL.Indeksi()
    Return tietokanta.Hae(id)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Select, False)>
  Public Function HaeVuodenIndeksit(vuosi As Integer) As List(Of DTO.Indeksi)

    Dim tietokanta = New DAL.Indeksi()
    Return tietokanta.HaeVuodenIndeksit(vuosi)

  End Function

#End Region

#Region "Muokkausmetodit"

  <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)>
  Public Function Lisaa(indeksi As DTO.Indeksi) As DTO.Indeksi

    Dim tietokanta = New DAL.Indeksi()

    indeksi.Luotu = Date.Now
    indeksi.Luoja = _konteksti.Kayttajatunnus
    indeksi.Paivitetty = Date.Now
    indeksi.Paivittaja = _konteksti.Kayttajatunnus

    Return tietokanta.Lisaa(indeksi)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Update, True)>
  Public Function Muokkaa(indeksi As DTO.Indeksi) As DTO.Indeksi

    Dim tietokanta = New DAL.Indeksi()

    indeksi.Paivitetty = Date.Now
    indeksi.Paivittaja = _konteksti.Kayttajatunnus

    Return tietokanta.Muokkaa(indeksi)

  End Function

  <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)>
  Public Function Poista(id As Integer) As DTO.Indeksi

    Dim tietokanta = New DAL.Indeksi()
    Return tietokanta.Poista(id)

  End Function

#End Region

End Class
