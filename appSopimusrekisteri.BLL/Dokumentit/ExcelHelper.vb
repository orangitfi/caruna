Imports System.Reflection
Imports System.Data
Imports System.Collections.Specialized

Public Class ExcelHelper

  Public Shared Function TeeDatasetListasta(Of T)(lista As List(Of T)) As DataSet

    Dim ds As New DataSet()

    Dim dt As New DataTable()

    Dim pType As Type

    For Each p As PropertyInfo In GetType(T).GetProperties()
      If p.PropertyType.IsGenericType AndAlso p.PropertyType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then
        pType = Nullable.GetUnderlyingType(p.PropertyType)
      Else
        pType = p.PropertyType
      End If

      If pType = GetType(Boolean) Then
        dt.Columns.Add(p.Name, GetType(String))
      Else
        dt.Columns.Add(p.Name, pType)
      End If

    Next

    Dim dr As DataRow

    For Each obj As T In lista

      dr = dt.NewRow()

      For Each p As PropertyInfo In GetType(T).GetProperties()
        If p.GetValue(obj) Is Nothing Then
          dr(p.Name) = DBNull.Value
        Else

          If p.PropertyType.IsGenericType AndAlso p.PropertyType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then
            pType = Nullable.GetUnderlyingType(p.PropertyType)
          Else
            pType = p.PropertyType
          End If

          If pType = GetType(Boolean) Then
            dr(p.Name) = CBool(p.GetValue(obj)).ToString().Replace("True", "Kyllä").Replace("False", "Ei")
          Else
            dr(p.Name) = p.GetValue(obj)
          End If

        End If
      Next

      dt.Rows.Add(dr)

    Next

    ds.Tables.Add(dt)

    Return ds

  End Function

  Public Shared Sub TeeExcelListasta(Of T)(lista As List(Of T), sarakkeet As NameValueCollection, templatePolku As String, excelPolku As String)

    Dim ds As DataSet = TeeDatasetListasta(Of T)(lista)

    Dim myExcel As New KTExcel(templatePolku, excelPolku, ds, True)

    For Each sarake As String In sarakkeet.AllKeys

      Select Case ds.Tables(0).Columns(sarake).DataType
        Case GetType(System.Decimal)
          myExcel.Headers.Add(New KTExcelHeaderItem(sarake, sarakkeet.Item(sarake), KTExcelColumnDatatypes.Decimal, False))
        Case GetType(System.DateTime)
          myExcel.Headers.Add(New KTExcelHeaderItem(sarake, sarakkeet.Item(sarake), KTExcelColumnDatatypes.Date, False))
        Case GetType(System.Int32)
          myExcel.Headers.Add(New KTExcelHeaderItem(sarake, sarakkeet.Item(sarake), KTExcelColumnDatatypes.Numeric, False))
        Case Else
          myExcel.Headers.Add(New KTExcelHeaderItem(sarake, sarakkeet.Item(sarake), KTExcelColumnDatatypes.Text, False))
      End Select

    Next

    'tehdään tiedosto
    myExcel.CreateFileSAX()

  End Sub

End Class
