Imports appSopimusrekisteri.DAL

Public Class Maksuaineisto

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

  ' KSTId   KSTKorvauslaskelmaStatus
  ' 1       Hyväksymättä
  ' 2       Hyväksytty
  ' 3       Kieltäytynyt korvauksesta
  ' 4       Maksettu

  ' KTYId	  KTYKorvaustyyppi
  ' 1	      Kertakorvaus
  ' 2	      Vuosimaksu
  ' 3	      Ei korvausta

  Public Function TuoMaksuaineisto(maksuaineisto As List(Of DTO.MaksuaineistonTuonti)) As DTO.Palautusarvo

    Dim tietokanta = New DAL.Maksu(_konteksti)
    Return tietokanta.TuoMaksuaineisto(maksuaineisto)

  End Function


  Public Function HaeMaksuaineisto(id As Integer) As Entities.Maksu
    If Not id = 0 Then
      Dim tietokanta = New DAL.Maksu()
      Return tietokanta.HaeMaksu(id)
    Else
      Return Nothing
    End If
  End Function

  Public Function HaeMaksuaineistot(sopimusId As Integer) As List(Of Entities.Maksu)
    If Not sopimusId = 0 Then
      Dim tietokanta = New DAL.Maksu()
      Return tietokanta.HaeMaksut(sopimusId)
    Else
      Return Nothing
    End If
  End Function

End Class
