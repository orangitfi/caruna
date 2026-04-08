Namespace Liittymat.IFS

  Public Class Posting
    Inherits InvoiceRow

    Public ReadOnly Property LineType As String
      Get
        Return "P"
      End Get
    End Property

    Public Property InvoiceNo As String
    Public Property ItemId As Integer
    Public Property CodeA As String
    Public Property CodeB As String
    Public Property CodeC As String
    Public Property CodeF As String = "INVCAT1"
    Public Property CodeG As String
    Public Property CurrAmount As Decimal

    Public Overrides ReadOnly Property Fields As IEnumerable(Of String)
      Get
        Dim lstFields As New List(Of String)()

        lstFields.Add(Me.LineType)
        lstFields.Add(Me.InvoiceNo)
        lstFields.Add(Me.ItemId.ToString())
        lstFields.Add(Me.CodeA)
        lstFields.Add(Me.CodeB)
        lstFields.Add(Me.CodeC)
        lstFields.Add(Me.CodeF)
        lstFields.Add(Me.CodeG)
        lstFields.Add(Formatter.DecimalToString(Me.CurrAmount))

        Return lstFields
      End Get
    End Property

  End Class

End Namespace
