Public Class Luvut

  Public Shared Function HaeNullableInteger(teksti As String) As Integer?

    If String.IsNullOrWhiteSpace(teksti) Then
      Return Nothing
    End If

    If IsNumeric(teksti) Then
      Return CType(teksti, Integer)
    End If

    Return Nothing

  End Function

  Public Shared Function HaeNullableDecimal(teksti As String) As Decimal?

    If String.IsNullOrWhiteSpace(teksti) Then
      Return Nothing
    End If

    If IsNumeric(teksti) Then
      Return CType(teksti, Decimal)
    End If

    Return Nothing

  End Function

  Public Shared Function EsitaNullableInteger(luku As String) As String

    If luku <> String.Empty And IsNumeric(luku) Then
      Return EsitaNullableInteger(CType(luku, Integer))
    Else
      Return String.Empty
    End If

  End Function

  Public Shared Function EsitaNullableInteger(luku As Integer?) As String

    If luku Is Nothing Then
      Return String.Empty
    End If

    Return luku.ToString()

  End Function

  Public Shared Function EsitaNullableDecimal(luku As String) As String

    If luku <> String.Empty And IsNumeric(luku) Then
      Return EsitaNullableDecimal(CType(luku, Decimal))
    Else
      Return String.Empty
    End If

  End Function

  Public Shared Function EsitaNullableDecimal(luku As Decimal?, Optional desimaalit As Integer = 2) As String

    If luku Is Nothing Then
      Return String.Empty
    End If

    Return Math.Round(luku.Value, desimaalit).ToString("f" & desimaalit)

  End Function

  Public Shared Function EsitaDecimal(luku As Object) As Object

    If IsNumeric(luku) Then
      Return CDec(luku).ToString("f2")
    End If

    Return Nothing

  End Function

End Class
