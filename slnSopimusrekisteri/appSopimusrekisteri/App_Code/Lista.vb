Imports appSopimusrekisteri.DTO

Public Module Lista

  Public Function HaeListasta(id As Integer?, lista As List(Of iHakutulos)) As String

    If Not id Is Nothing Then
      For Each tulos In lista
        If tulos.ID = id Then
          Return tulos.Nimi
        End If
      Next
    End If

    Return String.Empty

  End Function


End Module
