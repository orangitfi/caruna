Imports System.Xml.Serialization
Imports System.IO
Imports System.Data

Namespace CorporatePaymentsStatusV02

  Public Class CorporatePaymentsStatusV02Parser

    Private _doc As Document

    Public Sub New(filepath As String)

      Dim xmlSer As New XmlSerializer(GetType(CorporatePaymentsStatusV02.Document))

      Dim reader As New StreamReader(filepath)

      _doc = xmlSer.Deserialize(reader)

      reader.Close()

    End Sub

    Public Function GetGroupStatus() As TransactionGroupStatus1Code

      Return _doc.pain00200102.OrgnlGrpInfAndSts.GrpSts

    End Function

    Public Function GetAllTransactions() As DataTable

      Dim dt As DataTable = GetTransactionDatatable()

      Dim dr As DataRow

      If Not _doc.pain00200102.TxInfAndSts Is Nothing Then

        For Each txInfo As PaymentTransactionInformation1 In _doc.pain00200102.TxInfAndSts
          dr = dt.NewRow()

          dr("PaymentGroupId") = txInfo.OrgnlPmtInfId
          dr("TransactionId") = txInfo.OrgnlEndToEndId
          dr("Status") = txInfo.TxSts

          If Not txInfo.StsRsnInf Is Nothing AndAlso txInfo.StsRsnInf.Length > 0 Then
            If Not txInfo.StsRsnInf(0).StsRsn Is Nothing Then

              dr("RejectionCode") = CType(txInfo.StsRsnInf(0).StsRsn.Item, TransactionRejectReason2Code)
              dr("RejectionReason") = txInfo.StsRsnInf(0).AddtlStsRsnInf

            End If
          End If

          dt.Rows.Add(dr)

        Next

      End If

      Return dt

    End Function

    Public Function GetDocument() As Document
      Return _doc
    End Function

    Private Function GetTransactionDatatable() As DataTable

      Dim dt As New DataTable()

      dt.Columns.Add("PaymentGroupId")
      dt.Columns.Add("TransactionId")
      dt.Columns.Add("Status")
      dt.Columns.Add("RejectionCode")
      dt.Columns.Add("RejectionReason")

      Return dt

    End Function

  End Class

End Namespace