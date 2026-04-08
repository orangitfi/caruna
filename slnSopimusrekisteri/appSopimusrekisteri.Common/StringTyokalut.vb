Public Class StringTyokalut

  Public Shared Function PoistaValilyonnit(teksti As String) As String

    If Not String.IsNullOrEmpty(teksti) Then
      Return teksti.Replace(" ", "")
    End If

    Return teksti
  End Function

End Class
