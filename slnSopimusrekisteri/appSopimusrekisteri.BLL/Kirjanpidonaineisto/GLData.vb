Imports System.IO

Public Class GLData

  Private Const DELIMITER As String = ";"

  Private _lstRows As List(Of GLDataRow)

  Public Sub New(application_id As String, org_id As String)

    Me.Application_id = application_id
    Me.Org_id = org_id

    Me._lstRows = New List(Of GLDataRow)()

  End Sub

  Public ReadOnly Property Record_type As String
    Get
      Return "001"
    End Get
  End Property
  Public ReadOnly Property Batch_id As String
    Get
      Return Me.Org_id & Me.Application_id & Date.Now.ToString("ddMMyyyyHHmm")
    End Get
  End Property
  Public Property Application_id As String
  Public Property Org_id As String
  Public ReadOnly Property Check_sum As Integer
    Get
      Return Me.Rows.Count + 1
    End Get
  End Property

  Public ReadOnly Property Rows As GLDataRow()
    Get
      Return Me._lstRows.ToArray()
    End Get
  End Property

  Public Sub AddRow(dataRow As GLDataRow)

    dataRow.Batch_id = Me.Batch_id
    dataRow.Org_id = Me.Org_id

    Me._lstRows.Add(dataRow)

  End Sub

  Public Sub CreateFile(path As String)

    Dim writer As New StreamWriter(path)

    writer.WriteLine(Me.CreateHeaderRow())

    For Each row As GLDataRow In Me.Rows
      writer.WriteLine(Me.CreateDataRow(row))
    Next

    writer.Flush()
    writer.Close()

  End Sub

  Private Function CreateHeaderRow() As String

    Dim arrFields As String() = {Me.Record_type, Me.Batch_id, Me.Application_id, Me.Org_id, Me.Check_sum.ToString()}

    Return Join(arrFields, DELIMITER)

  End Function

  Private Function CreateDataRow(row As GLDataRow) As String

    Dim arrFields As String() = { _
                                row.Record_type, _
                                row.Batch_id, _
                                row.Org_id, _
                                row.Source, _
                                row.Document_number.ToString(), _
                                row.Document_category, _
                                Me.DateToString(row.Gl_date), _
                                row.Company, _
                                row.Response, _
                                row.Account, _
                                row.Project, _
                                row.Invcost, _
                                row.Partner, _
                                row.Product, _
                                row.Customer, _
                                row.Country, _
                                row.Contract, _
                                row.Purpose, _
                                row.As, _
                                row.Taxper, _
                                row.Abc, _
                                row.Local1, _
                                row.Local2, _
                                row.Currency_code, _
                                row.Conversion_type, _
                                Me.DecimalToString(row.Currency_rate, "F7"), _
                                Me.DateToString(row.Conversion_date), _
                                Me.DecimalToString(row.Debet_sum, "F2"), _
                                Me.DecimalToString(row.Credit_sum, "F2"), _
                                Me.DecimalToString(row.Stat_amount, "F2"), _
                                row.Description, _
                                row.Gldata_attribute1, _
                                row.Gldata_attribute2, _
                                row.Gldata_attribute3, _
                                row.Gldata_attribute4, _
                                row.Gldata_attribute5, _
                                row.Gldata_attribute6, _
                                row.Gldata_attribute7, _
                                row.Gldata_attribute8, _
                                row.Gldata_attribute9, _
                                row.Gldata_attribute10, _
                                row.Flex_build_flag, _
                                row.Tax_code, _
                                row.Reserved1, _
                                row.Reserved2, _
                                row.Reserved3
                                }

    Return Join(arrFields, DELIMITER)

  End Function

  Private Function DecimalToString(value As Decimal?, format As String) As String

    If value.HasValue Then

      Return value.Value.ToString(format).Replace(",", "").Replace(" ", "")

    End If

    Return String.Empty

  End Function

  Private Function DateToString(value As Date?) As String

    If value.HasValue Then

      Return value.Value.ToString("ddMMyyyy")

    End If

    Return String.Empty

  End Function

End Class
