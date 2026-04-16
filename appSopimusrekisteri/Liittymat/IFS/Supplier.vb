Namespace Liittymat.IFS

  Public Class Supplier
    Inherits InvoiceRow

    Public ReadOnly Property LineType As String
      Get
        Return "O"
      End Get
    End Property

    Public Property InvoiceNo As String
    Public Property Name As String
    Public Property Address1 As String
    Public Property Address2 As String
    Public Property ZipCode As String
    Public Property City As String
    Public Property Country As String
    Public Property Account As String
    Public Property BicCode As String

    Public Overrides ReadOnly Property Fields As IEnumerable(Of String)
      Get
        Dim lstFields As New List(Of String)()

        lstFields.Add(Me.LineType)
        lstFields.Add(Me.InvoiceNo)
        lstFields.Add(Me.Name)
        lstFields.Add(Left(Me.Address1, 35))
        lstFields.Add(Left(Me.Address2, 35))
        lstFields.Add(Me.ZipCode)
        lstFields.Add(Me.City)
        lstFields.Add(Me.Country)
        lstFields.Add(Me.Account)
        lstFields.Add(Me.BicCode)

        Return lstFields
      End Get
    End Property

  End Class

End Namespace
