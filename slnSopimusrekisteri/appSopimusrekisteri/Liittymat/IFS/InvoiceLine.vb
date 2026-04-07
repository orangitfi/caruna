Namespace Liittymat.IFS

  Public Class InvoiceLine
    Inherits InvoiceRow

    Public ReadOnly Property LineType As String
      Get
        Return "I"
      End Get
    End Property

    Public Property InvoiceNo As String
    Public Property ItemId As Integer
    Public Property VatCode As Decimal?
    Public Property NetCurrAmount As Decimal
    Public Property VatCurrAmount As Decimal

    Public Overrides ReadOnly Property Fields As IEnumerable(Of String)
      Get

        Dim lstFields As New List(Of String)()

        lstFields.Add(Me.LineType)
        lstFields.Add(Me.InvoiceNo)
        lstFields.Add(Me.ItemId.ToString())
        lstFields.Add(Formatter.VatCodeToString(Me.VatCode))
        lstFields.Add(Formatter.DecimalToString(Me.NetCurrAmount))
        lstFields.Add(Formatter.DecimalToString(Me.VatCurrAmount))

        Return lstFields
      End Get
    End Property

  End Class

End Namespace
