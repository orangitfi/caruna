Namespace Liittymat.IFS

  Public Class Invoice

    Private _lstInvoiceLines As List(Of InvoiceLine)
    Private _lstPostings As List(Of Posting)

    Public Sub New()
      Me._lstInvoiceLines = New List(Of InvoiceLine)()
      Me._lstPostings = New List(Of Posting)()
    End Sub

    Public Property Header As InvoiceHeader
    Public Property Supplier As Supplier

    Public Sub AddInvoiceLine(invoiceline As InvoiceLine)
      Me._lstInvoiceLines.Add(invoiceline)
    End Sub

    Public Sub AddPosting(posting As Posting)
      Me._lstPostings.Add(posting)
    End Sub

    Public ReadOnly Property InvoiceLines As IEnumerable(Of InvoiceLine)
      Get
        Return _lstInvoiceLines
      End Get
    End Property

    Public ReadOnly Property Postings As IEnumerable(Of Posting)
      Get
        Return _lstPostings
      End Get
    End Property

    Public ReadOnly Property TotalAmount As Decimal
      Get
        Return Me._lstInvoiceLines.Sum(Function(x) x.NetCurrAmount + x.VatCurrAmount)
      End Get
    End Property

  End Class

End Namespace
