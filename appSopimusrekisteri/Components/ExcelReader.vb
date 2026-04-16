Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class ExcelReader

    Private Shared Function AvaaSpreadsheet(path As String) As SpreadsheetDocument
        Return SpreadsheetDocument.Open(path, False)
    End Function

    Public Shared Function GetSheetNames(path As String) As String()
        Dim Spreadsheet As SpreadsheetDocument = AvaaSpreadsheet(path)
        Dim sheetit = GetSheetNames(Spreadsheet)
        Spreadsheet.Close()
        Return sheetit
    End Function

    Private Shared Function GetSheetNames(Spreadsheet As SpreadsheetDocument) As String()
        Return Spreadsheet.WorkbookPart.Workbook.Sheets.Elements(Of Sheet)().Select(Function(x) x.Name.ToString()).ToArray()
    End Function

    Public Shared Function ExcelToDatasetClosedXML(path As String) As DataSet

        Dim ds = New DataSet()

        Using doc = New XLWorkbook(path)

            For Each sheet In doc.Worksheets

                ' Muutetaan tablet rangeksi (muuten kaatuu)
                While sheet.Tables.Any()
                    sheet.Tables.Remove(sheet.Tables.First().Name)
                End While

                Dim range = sheet.RangeUsed()

                If range IsNot Nothing Then

                    Dim table = range.AsTable().AsNativeDataTable()

                    table.TableName = sheet.Name

                    ds.Tables.Add(table)

                End If

            Next

        End Using

        Return ds

    End Function

    ''' <summary>
    ''' Muuntaa excelin datasetiksi. Huom! Ensimmäisestä sarakkeesta tulee datatablen sarakkeiden otsikot. Näiden tulee olla uniikkeja. Toimii vaan xlsx exceleilla. 
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="offset">kuinka monta riviä skipataan</param>
    ''' <returns></returns>
    Public Shared Function ExcelToDataset(path As String, Optional offset As Integer = 0) As DataSet
        Dim Spreadsheet As SpreadsheetDocument = Nothing
        Dim dataset = New DataSet()
        Try
            Spreadsheet = AvaaSpreadsheet(path)

            ' Loopataan sheettien läpi ja luodaan niistä datatable
            For Each sheet In Spreadsheet.WorkbookPart.Workbook.Descendants(Of Sheet)

                ' Haetaan worksheetpart ja sheetdata
                Dim worksheetPart = CType(Spreadsheet.WorkbookPart.GetPartById(sheet.Id), WorksheetPart)
                Dim sheetData = worksheetPart.Worksheet.Elements(Of SheetData).FirstOrDefault()

                If Not sheetData Is Nothing Then
                    Dim table As DataTable = New DataTable(sheet.Name)

                    ' Luodaan headerit / sarakkeet tableen
                    Dim firstRow = sheetData.Elements(Of Row).Skip(offset).FirstOrDefault()
                    If Not firstRow Is Nothing Then
                        For Each cell In firstRow.Elements(Of Cell)
                            Dim arvo = GetCellValue(cell, Spreadsheet.WorkbookPart)
                            If Not String.IsNullOrEmpty(arvo) Then table.Columns.Add(New DataColumn(arvo))
                        Next
                    End If

                    ' Luetaan data
                    For Each row In sheetData.Elements(Of Row).Skip(offset + 1)
                        Dim dr = table.NewRow()
                        Dim nth As Integer = 0
                        Dim cells = row.Elements(Of Cell)
                        For Each column In firstRow.Elements(Of Cell)
                            Dim cellReference = Regex.Replace(column.CellReference.ToString().ToUpper(), "[\d]", String.Empty)
                            Dim cell = cells.FirstOrDefault(Function(x) Regex.Replace(x.CellReference.ToString().ToUpper(), "[\d]", String.Empty) = cellReference)
                            If Not cell Is Nothing Then
                                If nth < table.Columns.Count Then
                                    Dim arvo = GetCellValue(cell, Spreadsheet.WorkbookPart)
                                    If Not String.IsNullOrEmpty(arvo) Then
                                        dr(nth) = arvo
                                    Else
                                        dr(nth) = DBNull.Value
                                    End If
                                End If
                            End If
                            nth += 1
                        Next
                        nth = 0
                        table.Rows.Add(dr)
                    Next

                    dataset.Tables.Add(table)
                End If
            Next

            Spreadsheet.Close()
            Return dataset


        Catch ex As Exception
            If Not Spreadsheet Is Nothing Then Spreadsheet.Close()
            Throw ex ' Heitetään uudestaan sama. Haluttiin vain sulkea spreadsheet jos se on auki
        End Try

        Return dataset
    End Function

    Public Shared Function GetSheetColumns(path As String, sheetName As String, Optional offset As Integer = 0) As String()
        Dim Spreadsheet As SpreadsheetDocument = AvaaSpreadsheet(path)
        Dim columns As List(Of String) = New List(Of String)

        Dim sheet = Spreadsheet.WorkbookPart.Workbook.Descendants(Of Sheet).FirstOrDefault(Function(x) x.Name = sheetName)

        If Not sheet Is Nothing Then
            Dim worksheetPart = CType(Spreadsheet.WorkbookPart.GetPartById(sheet.Id), WorksheetPart)
            Dim sheetData = worksheetPart.Worksheet.Elements(Of SheetData).FirstOrDefault()

            If Not sheetData Is Nothing Then
                ' Luodaan headerit / sarakkeet tableen
                Dim firstRow = sheetData.Elements(Of Row).Skip(offset).FirstOrDefault()
                If Not firstRow Is Nothing Then
                    For Each cell In firstRow.Elements(Of Cell)
                        Dim arvo = GetCellValue(cell, Spreadsheet.WorkbookPart)
                        If Not String.IsNullOrEmpty(arvo) Then columns.Add(arvo)
                    Next
                End If
            End If
        End If

        Spreadsheet.Close()
        Return columns.ToArray()
    End Function

    Private Shared Function GetCellValue(cell As Cell, workbookPart As WorkbookPart)
        If cell Is Nothing Then
            Return Nothing
        End If

        Dim val = If(cell.CellFormula Is Nothing, cell.InnerText.Trim(), cell.CellValue.InnerText)

        If cell.DataType Is Nothing Then
            Return val
        End If

        If cell.DataType.Value = CellValues.SharedString Then
            Dim stringTable = workbookPart.GetPartsOfType(Of SharedStringTablePart)().FirstOrDefault()
            If Not stringTable Is Nothing Then
                Return stringTable.SharedStringTable.ElementAt(Integer.Parse(val)).InnerText
            End If
        ElseIf cell.DataType.Value = CellValues.Date Then
            Return Date.FromOADate(Convert.ToDouble(val)).ToShortDateString("dd.MM.yyyy")
        End If

        Return val
    End Function

End Class
