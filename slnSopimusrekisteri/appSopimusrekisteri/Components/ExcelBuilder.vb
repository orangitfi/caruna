Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports KT.Utils


Namespace Components
    Public Class ExcelBuilder

#Region "Muuttujat ja vakiot"

        Private Shared numericTypes As Type() = {
               GetType(Integer),
               GetType(Decimal),
               GetType(Double),
               GetType(Byte),
               GetType(Short),
               GetType(Long)
            }

        Public Const MimeTypeXlsx As String = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"

#End Region

#Region "Excelin elementtien luonti"

        Public Shared Sub AddExcelSheet(spreadsheetDocument As SpreadsheetDocument, dt As DataTable, addHeaders As Boolean, Optional name As String = Nothing, Optional addDescriptions As Boolean = False)
            ' Add a WorksheetPart to the WorkbookPart.
            Dim worksheetPart As WorksheetPart = spreadsheetDocument.WorkbookPart.AddNewPart(Of WorksheetPart)()
            worksheetPart.Worksheet = New Worksheet(New SheetData())

            Dim nth As Integer = spreadsheetDocument.WorkbookPart.Workbook.Sheets.Count() + 1

            Dim sheet = New Sheet() With
            {
                .Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                .SheetId = nth,
                .Name = If(Not String.IsNullOrEmpty(name), name, "Sheet" & nth.ToString())
            }

            ' Adding data to the sheet
            If addDescriptions Then AddDescriptionsFromDataTable(spreadsheetDocument, worksheetPart.Worksheet, dt)
            If addHeaders Then AddHeadersFromDataTable(worksheetPart.Worksheet, dt)
            CopyDataTableToSheet(worksheetPart.Worksheet, dt)

            spreadsheetDocument.WorkbookPart.Workbook.Sheets.Append(sheet)
        End Sub

        Private Shared Sub AddStylesPart(spreadsheetDocument As SpreadsheetDocument)
            Dim stylesPart = spreadsheetDocument.WorkbookPart.AddNewPart(Of WorkbookStylesPart)()
            stylesPart.Stylesheet = New Stylesheet With {
                .Fonts = New Fonts(),
                .Fills = New Fills(),
                .Borders = New Borders(),
                .CellFormats = New CellFormats()
            }

            ' Defaults
            stylesPart.Stylesheet.Fonts.Append(New Font())
            stylesPart.Stylesheet.Fills.Append(New Fill())
            stylesPart.Stylesheet.Borders.Append(New Border())
            stylesPart.Stylesheet.CellFormats.Append(New CellFormat With {
                .FormatId = 0,
                .FontId = 0,
                .FillId = 0,
                .BorderId = 0
            })
            stylesPart.Stylesheet.Save()
        End Sub

        Private Shared Function AddCellFormat(spreadsheetDocument As SpreadsheetDocument, cellFormat As CellFormat) As UInt32Value
            cellFormat.FormatId = spreadsheetDocument.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.ChildElements.Count
            spreadsheetDocument.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.Append(cellFormat)
            Return cellFormat.FormatId
        End Function

        Private Shared Function AddFont(spreadsheetDocument As SpreadsheetDocument, font As Font) As UInt32Value
            spreadsheetDocument.WorkbookPart.WorkbookStylesPart.Stylesheet.Fonts.Append(font)
            Return spreadsheetDocument.WorkbookPart.WorkbookStylesPart.Stylesheet.Fonts.ChildElements.Count - 1
        End Function

        Public Shared Function CreateExcelDocument(fileName As String) As SpreadsheetDocument
            Dim spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook)

            ' Add a WorkbookPart to the document.
            Dim workbookpart As WorkbookPart = spreadsheetDocument.AddWorkbookPart()
            workbookpart.Workbook = New Workbook()

            ' Styles
            AddStylesPart(spreadsheetDocument)

            Dim stringTablePart As SharedStringTablePart = spreadsheetDocument.WorkbookPart.AddNewPart(Of SharedStringTablePart)()
            stringTablePart.SharedStringTable = New SharedStringTable()
            stringTablePart.SharedStringTable.Save()

            ' Add Sheets to the Workbook.
            spreadsheetDocument.WorkbookPart.Workbook.AppendChild(New Sheets())

            Return spreadsheetDocument
        End Function

        Public Shared Function AddRow(sheet As Worksheet) As Row

            Dim SheetData As SheetData = sheet.GetFirstChild(Of SheetData)()
            Dim Row As Row = New Row()
            SheetData.Append(Row)

            Return Row
        End Function

        Public Shared Function AddCell(Row As Row, dataType As CellValues) As Cell
            Return AddCell(Row, dataType, Nothing)
        End Function

        Public Shared Function AddCell(row As Row, dataType As CellValues, value As String) As Cell
            Dim Cell As Cell = New Cell() With {.DataType = New EnumValue(Of CellValues)(dataType)}

            If (Not IsNothing(value)) Then Cell.Append(New CellValue(value))

            row.Append(Cell)

            Return Cell
        End Function

        Public Shared Function AddCellWithStyle(row As Row, dataType As CellValues, value As String, styleIndex As UInt32Value) As Cell
            Dim Cell As Cell = New Cell() With {.DataType = New EnumValue(Of CellValues)(dataType), .StyleIndex = styleIndex}

            If (Not IsNothing(value)) Then Cell.Append(New CellValue(value))

            row.Append(Cell)

            Return Cell
        End Function

#End Region

#Region "Arvojen asettaminen"

        Public Shared Sub AddHeadersFromDataTable(sheet As Worksheet, dt As DataTable)

            Dim headerRow As Row = AddRow(sheet)

            For Each col As DataColumn In dt.Columns
                AddCell(headerRow, CellValues.String, col.ColumnName)
            Next
        End Sub

        Public Shared Sub AddDescriptionsFromDataTable(spreadsheetDocument As SpreadsheetDocument, sheet As Worksheet, dt As DataTable)

            'Lisätään cellformat descriptionia varten
            Dim fontIndex = AddFont(spreadsheetDocument, New Font With {.FontSize = New FontSize With {.Val = 8}})
            Dim styleIndex = AddCellFormat(spreadsheetDocument, New CellFormat With {.FontId = fontIndex})

            Dim headerRow As Row = AddRow(sheet)

            For Each col As DataColumn In dt.Columns
                AddCellWithStyle(headerRow, CellValues.String, col.Caption, styleIndex)
            Next
        End Sub

        Public Shared Function CreateExcel(Of T)(data As IEnumerable(Of T), filename As String, addHeaders As Boolean, closeFile As Boolean, columns As IEnumerable(Of CollectionColumn)) As SpreadsheetDocument

            Dim dt As DataTable = CollectionUtils.GenerateDatatableFromCollection(Of T)(data, columns)

            Return CreateExcelFromDataTable(dt, filename, addHeaders, closeFile)
        End Function

        Public Shared Function CreateExcelFromDataTable(dt As DataTable, fileName As String, addHeaders As Boolean, closeFile As Boolean) As SpreadsheetDocument
            Dim ss As SpreadsheetDocument = CreateExcelDocument(fileName)
            AddExcelSheet(ss, dt, addHeaders)

            ss.Save()

            If (closeFile) Then ss.Close()
            Return ss
        End Function

        Public Shared Function CreateExcelFromDataTables(dts As Dictionary(Of String, DataTable), fileName As String, addHeaders As Boolean, addDescriptions As Boolean, closeFile As Boolean) As SpreadsheetDocument
            Dim ss As SpreadsheetDocument = CreateExcelDocument(fileName)

            For Each pair As KeyValuePair(Of String, DataTable) In dts
                If pair.Key.Length > 31 Then Throw New ArgumentException("Sheetin nimen maksimipituus on 31 merkkiä (Excelin rajoitus). Tarkista Dictionaryn key arvojen pituudet.")
                AddExcelSheet(ss, pair.Value, addHeaders, pair.Key, addDescriptions)
            Next

            ss.Save()

            If (closeFile) Then ss.Close()
            Return ss
        End Function

        Public Shared Sub CopyDataTableToSheet(sheet As Worksheet, dt As DataTable)
            For Each dr As DataRow In dt.Rows

                Dim excelRow As Row = AddRow(sheet)

                For Each col As DataColumn In dr.Table.Columns

                    Dim excelDataType As CellValues = DetermineExcelDataType(col.DataType)
                    Dim excelCell As Cell = AddCell(excelRow, excelDataType)
                    SetCellValue(excelCell, col.DataType, dr(col))
                Next

            Next
        End Sub

        Public Shared Sub SetCellValue(cell As Cell, dataType As Type, value As Object)

            If (numericTypes.Contains(dataType)) Then
                cell.CellValue = New CellValue(value.ToString().Replace(","c, "."c))
            Else
                cell.CellValue = New CellValue(value.ToString())
            End If
        End Sub

        Protected Shared Function DetermineExcelDataType(dataType As Type) As CellValues
            If (numericTypes.Contains(dataType)) Then Return CellValues.Number

            Return CellValues.String
        End Function

#End Region

    End Class

End Namespace