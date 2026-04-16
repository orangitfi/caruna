Imports System.IO

Namespace Liittymat.IFS

  Public Class IFSIntegrationFile

    Private _lstInvoices As List(Of Invoice)

    Public Sub New()
      Me._lstInvoices = New List(Of Invoice)()
    End Sub

    Public Sub AddInvoice(invoice As Invoice)

      Me._lstInvoices.Add(invoice)

    End Sub

    Public Function CreateFile(path As String) As Response

      Dim response As New Response()

      Try

        Dim encoding As Encoding = New System.Text.UTF8Encoding(False)

        Dim writer As New StreamWriter(path, False, encoding)

        For Each invoice As Invoice In Me._lstInvoices

          writer.WriteLine(invoice.Header.ToString())

          For Each invoiceLine As InvoiceLine In invoice.InvoiceLines

            writer.WriteLine(invoiceLine.ToString())

          Next

          For Each posting As Posting In invoice.Postings

            writer.WriteLine(posting.ToString())

          Next

          writer.WriteLine(invoice.Supplier.ToString())

        Next

        writer.Flush()
        writer.Close()

        response.Ok = True

      Catch ex As Exception
        response.Ok = False
        response.ErrorMessage = ex.Message
      End Try

      Return response

    End Function

  End Class

End Namespace
