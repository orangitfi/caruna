Namespace Liittymat.IFS

  Public Class Formatter

    Public Shared Function DateToString(value As Date) As String
      Return value.ToString("dd.MM.yyyy")
    End Function

    Public Shared Function DecimalToString(value As Decimal) As String
      Return value.ToString("f2")
    End Function

    Public Shared Function VatCodeToString(value As Decimal?) As String

      If value.HasValue Then
        Dim alv = value.Value * 10
        Return alv.ToString("f0")
      End If

      Return "N"

    End Function

  End Class

End Namespace
