Public Class TypeFormatters

  Public Shared Function FormatDecimal(value As Decimal?) As String
    If value.HasValue Then
      Return FormatDecimal(value)
    End If

    Return String.Empty
  End Function

  Public Shared Function FormatDecimal(value As Decimal) As String
    Return value.ToString("f2")
  End Function

End Class
