Namespace Liittymat.IFS

  Public MustInherit Class InvoiceRow

    Private Const DELIMITER As String = ";"

    Public MustOverride ReadOnly Property Fields As IEnumerable(Of String)

    Public Overrides Function ToString() As String
      Return Join(Me.Fields.ToArray(), DELIMITER)
    End Function

  End Class

End Namespace
