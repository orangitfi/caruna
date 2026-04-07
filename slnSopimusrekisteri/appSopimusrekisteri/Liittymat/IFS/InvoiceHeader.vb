Namespace Liittymat.IFS

  Public Class InvoiceHeader
    Inherits InvoiceRow

    Public ReadOnly Property LineType As String
      Get
        Return "H"
      End Get
    End Property

    Public Property InvoiceNo As String
    Public Property TransactionDate As Date
    Public Property InvoiceDate As Date
    Public Property PlanPaymentDate As Date
    Public Property CreatorsReference As String
    Public Property YourReference As String
    Public Property PaymentReference As String
    Public Property GrossCurrAmount As Decimal

    Public Overrides ReadOnly Property Fields As IEnumerable(Of String)
      Get

        Dim lstFields As New List(Of String)()

        lstFields.Add(Me.LineType)
        lstFields.Add(Me.InvoiceNo)
        lstFields.Add(Formatter.DateToString(Me.TransactionDate))
        lstFields.Add(Formatter.DateToString(Me.InvoiceDate))
        lstFields.Add(Formatter.DateToString(Me.PlanPaymentDate))
        lstFields.Add(Me.CreatorsReference)
        lstFields.Add(Me.YourReference)
        lstFields.Add(Me.PaymentReference)
        lstFields.Add(Formatter.DecimalToString(Me.GrossCurrAmount))

        Return lstFields

      End Get
    End Property

  End Class

End Namespace
