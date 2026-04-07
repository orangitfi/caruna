Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml
Imports System.IO
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class KTExcel

  Private arrColumns As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", _
                                    "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", _
                                    "W", "X", "Y", "Z"}
  Private _strTemplatePath As String
  Private _strFilePath As String
  Private _dsDatasource As DataSet
  Private _booShowHeader As Boolean
  Private _lstHeaders As List(Of KTExcelHeaderItem)
  Private _intHeaderRowNumber As Nullable(Of Integer)
  Private _intFirstRowNumber As Nullable(Of Integer)
  Private _lstAdditionalCells As List(Of KTExcelAdditionalCell)
  Private _booAddTotalRow As Boolean
  Private _htUsedReferences As Hashtable
  Private _dateFormatIndex As UInt32Value
  Private _decimalFormatIndex As UInt32Value
  Private _styleCount As Integer
  Private _lstDatasourceCollection As List(Of DataSet)
  Private _lstHeaderCollection As List(Of List(Of KTExcelHeaderItem))

  Public Sub New()

  End Sub

  Public Sub New(ByVal templatePath As String, ByVal filePath As String, ByVal datasource As DataSet, ByVal showHeader As Boolean)
    _strTemplatePath = templatePath
    _strFilePath = filePath
    _dsDatasource = datasource
    _booShowHeader = showHeader
    _lstHeaders = New List(Of KTExcelHeaderItem)
    _lstAdditionalCells = New List(Of KTExcelAdditionalCell)
    _htUsedReferences = New Hashtable()
    _styleCount = 0
    _lstDatasourceCollection = New List(Of DataSet)
    _lstHeaderCollection = New List(Of List(Of KTExcelHeaderItem))
  End Sub

  Public Property TemplatePath() As String
    Get
      Return _strTemplatePath
    End Get
    Set(ByVal value As String)
      _strTemplatePath = value
    End Set
  End Property

  Public Property FilePath() As String
    Get
      Return _strFilePath
    End Get
    Set(ByVal value As String)
      _strFilePath = value
    End Set
  End Property

  Public Property ShowHeader() As Boolean
    Get
      Return _booShowHeader
    End Get
    Set(ByVal value As Boolean)
      _booShowHeader = value
    End Set
  End Property

  Public Property Datasource() As DataSet
    Get
      Return _dsDatasource
    End Get
    Set(ByVal value As DataSet)
      _dsDatasource = value
    End Set
  End Property

  Public Property Headers() As List(Of KTExcelHeaderItem)
    Get
      Return _lstHeaders
    End Get
    Set(ByVal value As List(Of KTExcelHeaderItem))
      _lstHeaders = value
    End Set
  End Property

  Public Property HeaderRowNumber() As Nullable(Of Integer)
    Get
      Return _intHeaderRowNumber
    End Get
    Set(ByVal value As Nullable(Of Integer))
      _intHeaderRowNumber = value
    End Set
  End Property

  Public Property FirstRowNumber() As Nullable(Of Integer)
    Get
      Return _intFirstRowNumber
    End Get
    Set(ByVal value As Nullable(Of Integer))
      _intFirstRowNumber = value
    End Set
  End Property

  Public Property AdditionalCells() As List(Of KTExcelAdditionalCell)
    Get
      Return _lstAdditionalCells
    End Get
    Set(ByVal value As List(Of KTExcelAdditionalCell))
      _lstAdditionalCells = value
    End Set
  End Property

  Public Property AddTotalRow() As Boolean
    Get
      Return _booAddTotalRow
    End Get
    Set(ByVal value As Boolean)
      _booAddTotalRow = value
    End Set
  End Property

  Public Property DatasourceCollection() As List(Of DataSet)
    Get
      Return _lstDatasourceCollection
    End Get
    Set(ByVal value As List(Of DataSet))
      _lstDatasourceCollection = value
    End Set
  End Property

  Public Property HeaderCollection() As List(Of List(Of KTExcelHeaderItem))
    Get
      Return _lstHeaderCollection
    End Get
    Set(ByVal value As List(Of List(Of KTExcelHeaderItem)))
      _lstHeaderCollection = value
    End Set
  End Property

  Public Function CreateFile() As Boolean

    If File.Exists(_strFilePath) Then
      File.Delete(_strFilePath)
    End If

    If _booShowHeader Then
      If Not _intHeaderRowNumber.HasValue Or (_intHeaderRowNumber.HasValue AndAlso _intHeaderRowNumber.Value < 1) Then
        _intHeaderRowNumber = 1
      End If
    Else
      _intHeaderRowNumber = 0
    End If

    If _intFirstRowNumber.HasValue AndAlso _intFirstRowNumber > 0 Then
      If _intFirstRowNumber <= _intHeaderRowNumber Then
        _intFirstRowNumber = _intHeaderRowNumber + 1
      End If
    Else
      _intFirstRowNumber = _intHeaderRowNumber + 1
    End If

    'kopio templatesta
    File.Copy(_strTemplatePath, _strFilePath)
    'avataan luotu tiedosto
    Dim myWorkBook As SpreadsheetDocument = SpreadsheetDocument.Open(_strFilePath, True)

    'haetaan ensimmäinen worksheet(jostain syystä xml:ssä viimeinen)
    Dim myWorkBookPart As WorkbookPart = myWorkBook.WorkbookPart
    Dim myWorkSheetPart As WorksheetPart = myWorkBookPart.WorksheetParts.Last

    Dim myStyleSheet As Stylesheet = myWorkBookPart.WorkbookStylesPart.Stylesheet

    _dateFormatIndex = CreateCellFormat(myStyleSheet, KTExcelColumnDatatypes.Date)
    _decimalFormatIndex = CreateCellFormat(myStyleSheet, KTExcelColumnDatatypes.Decimal)

    'haetaan worksheetdata
    Dim mySheetData As SheetData = myWorkSheetPart.Worksheet.GetFirstChild(Of SheetData)()

    mySheetData = AppendAdditionalRowsBeforeFirstRow(mySheetData)

    If _booShowHeader Then
      'tehdään headerrivi
      mySheetData = AppendHeaderRow(mySheetData)
    End If
    'tehdään datarivit
    mySheetData = AppendRows(mySheetData)

    'tallennetaan ja suljetaan
    myWorkBook.Close()

    Return True
  End Function

  Public Function CreateFileSAX() As Boolean
    'kirjoittaa excelin käyttäen xmlwriteria, käytä tätä jos teet iiiisoja exceleitä, vie vähemmän muistia

    If File.Exists(_strFilePath) Then
      File.Delete(_strFilePath)
    End If

    If _booShowHeader Then
      If Not _intHeaderRowNumber.HasValue Or (_intHeaderRowNumber.HasValue AndAlso _intHeaderRowNumber.Value < 1) Then
        _intHeaderRowNumber = 1
      End If
    Else
      _intHeaderRowNumber = 0
    End If

    If _intFirstRowNumber.HasValue AndAlso _intFirstRowNumber > 0 Then
      If _intFirstRowNumber <= _intHeaderRowNumber Then
        _intFirstRowNumber = _intHeaderRowNumber + 1
      End If
    Else
      _intFirstRowNumber = _intHeaderRowNumber + 1
    End If

    'kopio templatesta
    File.Copy(_strTemplatePath, _strFilePath)
    'avataan luotu tiedosto
    Dim myWorkBook As SpreadsheetDocument = SpreadsheetDocument.Open(_strFilePath, True)

    'haetaan ensimmäinen worksheet(jostain syystä xml:ssä viimeinen)
    Dim myWorkBookPart As WorkbookPart = myWorkBook.WorkbookPart
    Dim myWorkSheetPart As WorksheetPart = myWorkBookPart.WorksheetParts.Last

    Dim myStyleSheet As Stylesheet = myWorkBookPart.WorkbookStylesPart.Stylesheet

    _dateFormatIndex = CreateCellFormat(myStyleSheet, KTExcelColumnDatatypes.Date)
    _decimalFormatIndex = CreateCellFormat(myStyleSheet, KTExcelColumnDatatypes.Decimal)

    Dim originalSheetId As String = myWorkBookPart.GetIdOfPart(myWorkSheetPart)

    Dim newPart As WorksheetPart = myWorkBookPart.AddNewPart(Of WorksheetPart)()

    Dim newPartId As String = myWorkBookPart.GetIdOfPart(newPart)

    Dim reader As OpenXmlReader = OpenXmlReader.Create(myWorkSheetPart)
    Dim writer As OpenXmlWriter = OpenXmlWriter.Create(newPart)

    While reader.Read()

      If reader.ElementType = GetType(SheetData) Then

        If reader.IsEndElement Then
          Continue While
        End If

        writer.WriteStartElement(New SheetData())

        Dim i As Integer = 0

        If _lstDatasourceCollection.Count > 0 Then

          For Each ds As DataSet In _lstDatasourceCollection

            _dsDatasource = ds

            If _lstHeaderCollection.Count = _lstDatasourceCollection.Count Then
              _lstHeaders = _lstHeaderCollection(i)
            End If

            writer = AppendHeaderRow(writer)

            writer = AppendRows(writer)

            i += 1

          Next

        Else

          writer = AppendHeaderRow(writer)

          writer = AppendRows(writer)

        End If

        writer.WriteEndElement()

      Else

        If reader.IsStartElement Then

          writer.WriteStartElement(reader)

        ElseIf reader.IsEndElement Then

          writer.WriteEndElement()

        End If

      End If

    End While

    reader.Close()
    writer.Close()

    Dim mySheet As Sheet = (From s As Sheet In myWorkBookPart.Workbook.Descendants(Of Sheet)() _
                           Where s.Id.Value.Equals(originalSheetId)).First()

    mySheet.Id.Value = newPartId

    myWorkBookPart.DeletePart(myWorkSheetPart)

    'tallennetaan ja suljetaan
    myWorkBook.Close()

    Return True
  End Function

  Private Function CreateCellFormat(ByVal styleSheet As Stylesheet, ByVal datatype As KTExcelColumnDatatypes) As UInt32Value

    Dim myCellFormat As New CellFormat()

    Select Case datatype

      Case KTExcelColumnDatatypes.Date

        myCellFormat.NumberFormatId = UInt32Value.FromUInt32(14)
        myCellFormat.ApplyNumberFormat = BooleanValue.FromBoolean(True)

        styleSheet.CellFormats.Append(myCellFormat)

        _styleCount += 1

      Case KTExcelColumnDatatypes.Decimal

        myCellFormat.NumberFormatId = UInt32Value.FromUInt32(2)
        myCellFormat.ApplyNumberFormat = BooleanValue.FromBoolean(True)

        styleSheet.CellFormats.Append(myCellFormat)

        _styleCount += 1

    End Select

    Return UInt32Value.FromUInt32(_styleCount)

  End Function

  Private Function AppendHeaderRow(ByVal sheetData As SheetData) As SheetData

    'rivi
    Dim myRow As New Row
    'solu
    Dim myCell As Cell
    'jos sarakkeita on enemmän kuin aakkosia, tarvitaan suffixi headerille(tyyliin AA, AB, AC etc.)
    Dim strHeaderSuffix As String = ""
    'kerroin, kuinka mones suffixikierros menossa
    Dim intHeaderSuffixMultiplier As Integer = 1
    'headerkirjaimen indexi taulukossa
    Dim intHeaderIndex As Integer = 0

    Dim intRowIndex As Integer = _intHeaderRowNumber.Value

    myRow.RowIndex = intRowIndex

    'käydään headerit läpi
    For i As Integer = 0 To _lstHeaders.Count - 1

      'katotaan riittääkö headerit ja jos ei, lisätään suffixi(ekalla kerralla ei mitään, tokalla A, kolmanella B, etc.)
      If i > (arrColumns.Count * intHeaderSuffixMultiplier) - 1 Then
        'tarvitaan uusi suffixi, haetaan se headertaulukosta kertoimen mukaan
        strHeaderSuffix = arrColumns(intHeaderSuffixMultiplier - 1).ToString
        'kasvatetaan kerrointa
        intHeaderSuffixMultiplier += 1
        'nollataan kirjaimen indeksi
        intHeaderIndex = 0
      End If

      'tehdään solu, annetaan headerteksti, soluviite(headerrivillä A1, B1, C1, etc.), datatyyppi(headerrivillä aina text)
      myCell = CreateCell(_lstHeaders(i).HeaderText, strHeaderSuffix & arrColumns(intHeaderIndex).ToString & intRowIndex, KTExcelColumnDatatypes.Text, True)
      'lisätään solu riviin
      myRow.AppendChild(myCell)
      'kasvatetaan headerkirjaimen indeksiä
      intHeaderIndex += 1
    Next

    'lisätään rivi sheettiin
    sheetData.AppendChild(myRow)

    'palautetaan sheetti
    Return sheetData
  End Function

  Private Function AppendRows(ByVal sheetData As SheetData) As SheetData

    'rivi
    Dim row As Row
    'paljonko rivin indeksiin lisätään, että saadaan rivinumero aikaiseks
    Dim intRowIndexExtra As Integer
    Dim intRowNumber As Integer
    Dim ieAdditionalCellRows As IEnumerable(Of Integer)


    intRowIndexExtra = _intFirstRowNumber.Value

    'käydään datasetti läpi
    For i As Integer = 0 To _dsDatasource.Tables(0).Rows.Count - 1
      intRowNumber = i + intRowIndexExtra

      'tehdään rivi, annetaan rivi-index, datasetrivi, headerit
      row = CreateRow(intRowNumber, _dsDatasource.Tables(0).Rows(i))
      'lisätään rivi sheettiin
      sheetData.AppendChild(row)
    Next

    ieAdditionalCellRows = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
                           Where ac.RowNumber > intRowNumber _
                           Order By ac.RowNumber _
                           Select ac.RowNumber Distinct


    If _booAddTotalRow Then
      row = CreateTotalRow()
      sheetData.AppendChild(row)
    End If

    For Each i As Integer In ieAdditionalCellRows
      row = CreateAdditionalRow(i)
      sheetData.AppendChild(row)
    Next

    'palautetaan sheetti
    Return sheetData
  End Function

  Private Function AppendAdditionalRowsBeforeFirstRow(ByVal sheetData As SheetData) As SheetData

    Dim ieAdditionalCellRows As IEnumerable(Of Integer)
    Dim intRowNumber As Integer = 1
    Dim row As Row

    If _booShowHeader Then
      intRowNumber = _intHeaderRowNumber.Value
    Else
      intRowNumber = _intFirstRowNumber.Value
    End If

    ieAdditionalCellRows = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
                           Where ac.RowNumber < intRowNumber _
                           Order By ac.RowNumber _
                           Select ac.RowNumber Distinct

    For Each i As Integer In ieAdditionalCellRows
      row = CreateAdditionalRow(i)
      sheetData.AppendChild(row)
    Next

    Return sheetData
  End Function

  Private Function AppendHeaderRow(ByVal writer As OpenXmlWriter) As OpenXmlWriter

    'rivi
    Dim myRow As New Row
    'solu
    Dim myCell As Cell
    'jos sarakkeita on enemmän kuin aakkosia, tarvitaan suffixi headerille(tyyliin AA, AB, AC etc.)
    Dim strHeaderSuffix As String = ""
    'kerroin, kuinka mones suffixikierros menossa
    Dim intHeaderSuffixMultiplier As Integer = 1
    'headerkirjaimen indexi taulukossa
    Dim intHeaderIndex As Integer = 0

    Dim intRowIndex As Integer = _intHeaderRowNumber.Value

    writer.WriteStartElement(myRow)

    'käydään headerit läpi
    For i As Integer = 0 To _lstHeaders.Count - 1

      'katotaan riittääkö headerit ja jos ei, lisätään suffixi(ekalla kerralla ei mitään, tokalla A, kolmanella B, etc.)
      If i > (arrColumns.Count * intHeaderSuffixMultiplier) - 1 Then
        'tarvitaan uusi suffixi, haetaan se headertaulukosta kertoimen mukaan
        strHeaderSuffix = arrColumns(intHeaderSuffixMultiplier - 1).ToString()
        'kasvatetaan kerrointa
        intHeaderSuffixMultiplier += 1
        'nollataan kirjaimen indeksi
        intHeaderIndex = 0
      End If

      'tehdään solu, annetaan headerteksti, soluviite(headerrivillä A1, B1, C1, etc.), datatyyppi(headerrivillä aina text)
      myCell = CreateCell(_lstHeaders(i).HeaderText, strHeaderSuffix & arrColumns(intHeaderIndex).ToString & intRowIndex, KTExcelColumnDatatypes.Text, False)
      'lisätään solu riviin
      writer.WriteElement(myCell)
      'kasvatetaan headerkirjaimen indeksiä
      intHeaderIndex += 1
    Next

    'lisätään rivi sheettiin
    writer.WriteEndElement()

    'palautetaan sheetti
    Return writer
  End Function

  Private Function AppendRows(ByVal writer As OpenXmlWriter) As OpenXmlWriter

    'paljonko rivin indeksiin lisätään, että saadaan rivinumero aikaiseks
    Dim intRowIndexExtra As Integer
    Dim intRowNumber As Integer
    Dim ieAdditionalCellRows As IEnumerable(Of Integer)

    intRowIndexExtra = _intFirstRowNumber.Value

    Dim intti As Integer = 0

    'käydään datasetti läpi
    For i As Integer = 0 To _dsDatasource.Tables(0).Rows.Count - 1
      intRowNumber = i + intRowIndexExtra

      'tehdään rivi, annetaan rivi-index, datasetrivi, headerit
      writer = CreateRow(intRowNumber, _dsDatasource.Tables(0).Rows(i), writer)

      intti += 1

    Next

    If _lstDatasourceCollection.Count > 1 Then
      writer = CreateEmptyRow(intRowNumber + 1, writer)

      _intHeaderRowNumber = intRowNumber + 2
      _intFirstRowNumber = _intHeaderRowNumber.Value + 1
    End If

    ieAdditionalCellRows = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
                           Where ac.RowNumber > intRowNumber _
                           Order By ac.RowNumber _
                           Select ac.RowNumber Distinct


    'If _booAddTotalRow Then
    '  row = CreateTotalRow()
    '  sheetData.AppendChild(row)
    'End If

    'For Each i As Integer In ieAdditionalCellRows
    '  row = CreateAdditionalRow(i)
    '  sheetData.AppendChild(row)
    'Next

    'palautetaan sheetti
    Return writer
  End Function

  'Private Function AppendAdditionalRowsBeforeFirstRow(ByVal writer As OpenXmlWriter) As OpenXmlWriter

  '  Dim ieAdditionalCellRows As IEnumerable(Of Integer)
  '  Dim intRowNumber As Integer = 1
  '  Dim row As Row

  '  If _booShowHeader Then
  '    intRowNumber = _intHeaderRowNumber.Value
  '  Else
  '    intRowNumber = _intFirstRowNumber.Value
  '  End If

  '  ieAdditionalCellRows = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
  '                         Where ac.RowNumber < intRowNumber _
  '                         Order By ac.RowNumber _
  '                         Select ac.RowNumber Distinct

  '  For Each i As Integer In ieAdditionalCellRows
  '    row = CreateAdditionalRow(i)
  '    SheetData.AppendChild(row)
  '  Next

  '  Return SheetData
  'End Function

  Private Function CreateRow(ByVal rowIndex As Integer, ByVal dsRow As DataRow) As Row

    'rivi
    Dim myRow As New Row()
    'rivin index
    myRow.RowIndex = rowIndex

    'jos sarakkeita on enemmän kuin aakkosia, tarvitaan suffixi headerille(tyyliin AA, AB, AC etc.)
    Dim strHeaderSuffix As String = ""
    'kerroin, kuinka mones suffixikierros menossa
    Dim intHeaderSuffixMultiplier As Integer = 1
    'headerkirjaimen indexi taulukossa
    Dim intHeaderIndex As Integer = 0

    Dim strText As String
    Dim strFormula As String
    Dim strCellReference As String
    Dim ieAdditionalCells As IEnumerable(Of Cell)

    'käydään headerit läpi
    For i As Integer = 0 To _lstHeaders.Count - 1
      'katotaan riittääkö headerit ja jos ei, lisätään suffixi(ekalla kerralla ei mitään, tokalla A, kolmannella B, etc.)
      If i > (arrColumns.Count * intHeaderSuffixMultiplier) - 1 Then
        'tarvitaan uusi suffixi, haetaan se headertaulukosta kertoimen mukaan
        strHeaderSuffix = arrColumns(intHeaderSuffixMultiplier - 1).ToString()
        'kasvatetaan kerrointa
        intHeaderSuffixMultiplier += 1
        'nollataan kirjaimen indeksi
        intHeaderIndex = 0
      End If

      Dim myCell As Cell

      strText = dsRow(_lstHeaders(i).HeaderColumnName).ToString()
      strCellReference = strHeaderSuffix & arrColumns(intHeaderIndex).ToString() & rowIndex

      If Headers(i).ColumnDatatype = KTExcelColumnDatatypes.Formula Then
        strFormula = _lstHeaders(i).Formula.Replace("#", rowIndex)

        Dim regEx As New Regex("\[[a-zA-Z0-9]*\]")

        For Each m As Match In regEx.Matches(strFormula)
          strFormula = strFormula.Replace(m.Value, dsRow(m.Value.Replace("[", "").Replace("]", "")).ToString())
        Next

        myCell = CreateCell(strText, strCellReference, _lstHeaders(i).ColumnDatatype, True, strFormula)
      Else
        'tehdään solu, annetaan solun teksti, soluviite(header ja rivinumero tyyllin A1, A2, A3, etc.), datatyyppi
        myCell = CreateCell(strText, strCellReference, _lstHeaders(i).ColumnDatatype, True)
      End If

      'lisätään solu riviin
      myRow.AppendChild(myCell)
      'kasvatetaan headerkirjaimen indeksiä
      intHeaderIndex += 1
    Next

    If _lstAdditionalCells.Count > 0 Then

      ieAdditionalCells = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
                          Where ac.RowNumber = rowIndex _
                          Select ac.Cell

      For Each addCell As Cell In ieAdditionalCells
        myRow.AppendChild(addCell)
      Next

    End If

    'palautetaan rivi
    Return myRow
  End Function

  Private Function CreateRow(ByVal rowIndex As Integer, ByVal dsRow As DataRow, ByVal writer As OpenXmlWriter) As OpenXmlWriter

    'rivi
    Dim myRow As New Row()

    writer.WriteStartElement(myRow)

    'jos sarakkeita on enemmän kuin aakkosia, tarvitaan suffixi headerille(tyyliin AA, AB, AC etc.)
    Dim strHeaderSuffix As String = ""
    'kerroin, kuinka mones suffixikierros menossa
    Dim intHeaderSuffixMultiplier As Integer = 1
    'headerkirjaimen indexi taulukossa
    Dim intHeaderIndex As Integer = 0

    Dim strText As String
    Dim strFormula As String
    Dim strCellReference As String
    Dim ieAdditionalCells As IEnumerable(Of Cell)

    'käydään headerit läpi
    For i As Integer = 0 To _lstHeaders.Count - 1
      'katotaan riittääkö headerit ja jos ei, lisätään suffixi(ekalla kerralla ei mitään, tokalla A, kolmannella B, etc.)
      If i > (arrColumns.Count * intHeaderSuffixMultiplier) - 1 Then
        'tarvitaan uusi suffixi, haetaan se headertaulukosta kertoimen mukaan
        strHeaderSuffix = arrColumns(intHeaderSuffixMultiplier - 1).ToString()
        'kasvatetaan kerrointa
        intHeaderSuffixMultiplier += 1
        'nollataan kirjaimen indeksi
        intHeaderIndex = 0
      End If

      Dim myCell As Cell

      strText = dsRow(_lstHeaders(i).HeaderColumnName).ToString()
      strCellReference = strHeaderSuffix & arrColumns(intHeaderIndex).ToString() & rowIndex

      If Headers(i).ColumnDatatype = KTExcelColumnDatatypes.Formula Then
        strFormula = _lstHeaders(i).Formula.Replace("#", rowIndex)

        Dim regEx As New Regex("\[[a-zA-Z0-9]*\]")

        For Each m As Match In regEx.Matches(strFormula)
          strFormula = strFormula.Replace(m.Value, dsRow(m.Value.Replace("[", "").Replace("]", "")).ToString())
        Next

        myCell = CreateCell(strText, strCellReference, _lstHeaders(i).ColumnDatatype, False, strFormula)
      Else
        'tehdään solu, annetaan solun teksti, soluviite(header ja rivinumero tyyllin A1, A2, A3, etc.), datatyyppi
        myCell = CreateCell(strText, strCellReference, _lstHeaders(i).ColumnDatatype, False)
      End If

      'lisätään solu riviin
      writer.WriteElement(myCell)
      'kasvatetaan headerkirjaimen indeksiä
      intHeaderIndex += 1
    Next

    If _lstAdditionalCells.Count > 0 Then

      ieAdditionalCells = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
                          Where ac.RowNumber = rowIndex _
                          Select ac.Cell

      For Each addCell As Cell In ieAdditionalCells
        writer.WriteElement(addCell)
      Next

    End If

    writer.WriteEndElement()

    Return writer
  End Function

  Private Function CreateEmptyRow(ByVal rowIndex As Integer, ByVal writer As OpenXmlWriter) As OpenXmlWriter

    'rivi
    Dim myRow As New Row()

    writer.WriteStartElement(myRow)

    'jos sarakkeita on enemmän kuin aakkosia, tarvitaan suffixi headerille(tyyliin AA, AB, AC etc.)
    Dim strHeaderSuffix As String = ""
    'kerroin, kuinka mones suffixikierros menossa
    Dim intHeaderSuffixMultiplier As Integer = 1
    'headerkirjaimen indexi taulukossa
    Dim intHeaderIndex As Integer = 0

    Dim strCellReference As String

    'käydään headerit läpi
    For i As Integer = 0 To _lstHeaders.Count - 1
      'katotaan riittääkö headerit ja jos ei, lisätään suffixi(ekalla kerralla ei mitään, tokalla A, kolmannella B, etc.)
      If i > (arrColumns.Count * intHeaderSuffixMultiplier) - 1 Then
        'tarvitaan uusi suffixi, haetaan se headertaulukosta kertoimen mukaan
        strHeaderSuffix = arrColumns(intHeaderSuffixMultiplier - 1).ToString()
        'kasvatetaan kerrointa
        intHeaderSuffixMultiplier += 1
        'nollataan kirjaimen indeksi
        intHeaderIndex = 0
      End If

      Dim myCell As Cell

      strCellReference = strHeaderSuffix & arrColumns(intHeaderIndex).ToString() & rowIndex

      'tehdään solu, annetaan solun teksti, soluviite(header ja rivinumero tyyllin A1, A2, A3, etc.), datatyyppi
      myCell = CreateCell("", strCellReference, _lstHeaders(i).ColumnDatatype, False)

      'lisätään solu riviin
      writer.WriteElement(myCell)
      'kasvatetaan headerkirjaimen indeksiä
      intHeaderIndex += 1
    Next

    writer.WriteEndElement()

    Return writer
  End Function

  Private Function CreateAdditionalRow(ByVal rowIndex As Integer) As Row

    'rivi
    Dim myRow As New Row()
    'rivin index
    myRow.RowIndex = rowIndex

    Dim ieCells As IEnumerable(Of Cell)

    ieCells = From ac As KTExcelAdditionalCell In _lstAdditionalCells _
              Where ac.RowNumber = rowIndex _
              Select ac.Cell

    For Each addCell As Cell In ieCells
      myRow.AppendChild(addCell)
    Next

    'palautetaan rivi
    Return myRow
  End Function

  Private Function CreateTotalRow() As Row

    Dim intLastRow As Integer

    intLastRow = _dsDatasource.Tables(0).Rows.Count - 1 + _intFirstRowNumber

    Dim intRowIndex As Integer = intLastRow + 1

    'rivi
    Dim myRow As New Row()
    'jos sarakkeita on enemmän kuin aakkosia, tarvitaan suffixi headerille(tyyliin AA, AB, AC etc.)
    Dim strHeaderSuffix As String = ""
    'kerroin, kuinka mones suffixikierros menossa
    Dim intHeaderSuffixMultiplier As Integer = 1
    'headerkirjaimen indexi taulukossa
    Dim intHeaderIndex As Integer = 0
    Dim strText As String
    Dim strFormula As String
    Dim strCellReference As String
    Dim strColumnName As String

    'rivin index
    myRow.RowIndex = intRowIndex

    For i As Integer = 0 To _lstHeaders.Count - 1

      If _lstHeaders(i).Sum Then

        'katotaan riittääkö headerit ja jos ei, lisätään suffixi(ekalla kerralla ei mitään, tokalla A, kolmannella B, etc.)
        If i > (arrColumns.Count * intHeaderSuffixMultiplier) - 1 Then
          'tarvitaan uusi suffixi, haetaan se headertaulukosta kertoimen mukaan
          strHeaderSuffix = arrColumns(intHeaderSuffixMultiplier - 1).ToString
          'kasvatetaan kerrointa
          intHeaderSuffixMultiplier += 1
          'nollataan kirjaimen indeksi
          intHeaderIndex = 0
        End If

        Dim myCell As Cell

        strText = 0
        strColumnName = strHeaderSuffix & arrColumns(intHeaderIndex).ToString
        strCellReference = strColumnName & intRowIndex

        strFormula = "SUM(" & strColumnName & _intFirstRowNumber & ":" & strColumnName & intLastRow & ")"

        myCell = CreateCell(strText, strCellReference, KTExcelColumnDatatypes.Formula, True, strFormula)

        'lisätään solu riviin
        myRow.AppendChild(myCell)

      End If

      'kasvatetaan headerkirjaimen indeksiä
      intHeaderIndex += 1
    Next

    'palautetaan rivi
    Return myRow

  End Function

  Public Sub AddCell(ByVal cellReference As String, ByVal value As String, ByVal datatype As KTExcelColumnDatatypes, Optional ByVal formula As String = "")

    Dim myCell As Cell
    Dim strRowIndex As String

    If datatype = KTExcelColumnDatatypes.Formula Then
      myCell = CreateCell(value, cellReference, datatype, formula)
    Else
      myCell = CreateCell(value, cellReference, datatype, True)
    End If

    strRowIndex = cellReference

    While Not IsNumeric(strRowIndex)
      strRowIndex = Right(strRowIndex, 1)
    End While

    Dim addCell As New KTExcelAdditionalCell(strRowIndex, myCell)

    _lstAdditionalCells.Add(addCell)

  End Sub

  Private Function CreateCell(ByVal value As String, ByVal cellReference As String, ByVal datatype As KTExcelColumnDatatypes, ByVal includeCellReference As Boolean, Optional ByVal formula As String = "") As Cell

    'solu
    Dim myCell As New Cell
    'soluviite (tyyliin A1, A2, A3)
    If includeCellReference Then
      myCell.CellReference = cellReference
    End If

    'lisätään soluviite hashtableen, kaatuu, jos viite on jo käytössä
    _htUsedReferences.Add(cellReference, "")

    Select Case datatype

      Case KTExcelColumnDatatypes.Numeric 'numeerinen solu
        'solun(arvo)
        Dim myCellValue As New CellValue()

        myCellValue.Text = value.Replace(",", ".")

        'lisätään solun arvo soluun
        myCell.AppendChild(myCellValue)
      Case KTExcelColumnDatatypes.Decimal 'numeerinen solu
        'solun(arvo)
        Dim myCellValue As New CellValue()

        myCellValue.Text = value.Replace(",", ".")

        myCell.StyleIndex = _decimalFormatIndex

        'lisätään solun arvo soluun
        myCell.AppendChild(myCellValue)
      Case KTExcelColumnDatatypes.Date

        'solun(arvo)
        Dim myCellValue As New CellValue()

        If value <> "" Then

          myCellValue.Text = CDate(value).Date.ToOADate().ToString()

        Else

          myCellValue.Text = ""

        End If

        myCell.StyleIndex = _dateFormatIndex

        'lisätään solun arvo soluun
        myCell.AppendChild(myCellValue)

      Case KTExcelColumnDatatypes.Formula
        If formula <> "" Then
          Dim myFormula As New CellFormula()

          myFormula.CalculateCell = True

          myFormula.Text = formula

          myCell.AppendChild(myFormula)
        End If

        Dim myCellValue As New CellValue()

        myCellValue.Text = value

        myCell.StyleIndex = _decimalFormatIndex

        myCell.AppendChild(myCellValue)

      Case Else 'tekstisolu
        'määritellään datatyypiksi inlinestring
        myCell.DataType = CellValues.InlineString

        Dim myInlineString As New InlineString
        'teksti()
        Dim myText As New Text
        myText.Text = value

        'lisätään teksti inlinestringiin
        myInlineString.AppendChild(myText)

        'InlineString(soluun)
        myCell.AppendChild(myInlineString)
    End Select

    'palautetaan solu
    Return myCell
  End Function



End Class

Public Class KTExcelAdditionalCell

  Private _intRowNumber As Integer
  Private _cell As Cell

  Public Sub New(ByVal rowNumber As Integer, ByVal cell As Cell)
    _intRowNumber = rowNumber
    _cell = cell
  End Sub

  Public Property RowNumber() As Integer
    Get
      Return _intRowNumber
    End Get
    Set(ByVal value As Integer)
      _intRowNumber = value
    End Set
  End Property

  Public Property Cell() As Cell
    Get
      Return _cell
    End Get
    Set(ByVal value As Cell)
      _cell = Cell
    End Set
  End Property

End Class

Public Class KTExcelHeaderItem

  Private strHeaderColumnName As String
  Private strHeaderText As String
  Private enumColumnDatatype As KTExcelColumnDatatypes
  Private strFormula As String
  Private booSum As Boolean

  Public Sub New(ByVal headerColumnName As String, ByVal headerText As String, ByVal columnDatatype As KTExcelColumnDatatypes, ByVal sum As Boolean)
    strHeaderColumnName = headerColumnName
    strHeaderText = headerText
    enumColumnDatatype = columnDatatype
    booSum = sum
  End Sub

  Public Sub New(ByVal headerColumnName As String, ByVal headerText As String, ByVal columnDatatype As KTExcelColumnDatatypes, ByVal formula As String, ByVal sum As Boolean)
    strHeaderColumnName = headerColumnName
    strHeaderText = headerText
    enumColumnDatatype = columnDatatype
    strFormula = formula
    booSum = sum
  End Sub

  Public Property HeaderColumnName() As String
    Get
      Return strHeaderColumnName
    End Get
    Set(ByVal value As String)
      strHeaderColumnName = value
    End Set
  End Property

  Public Property HeaderText() As String
    Get
      Return strHeaderText
    End Get
    Set(ByVal value As String)
      strHeaderText = value
    End Set
  End Property

  Public Property ColumnDatatype() As KTExcelColumnDatatypes
    Get
      Return enumColumnDatatype
    End Get
    Set(ByVal value As KTExcelColumnDatatypes)
      enumColumnDatatype = value
    End Set
  End Property

  Public Property Formula() As String
    Get
      Return strFormula
    End Get
    Set(ByVal value As String)
      strFormula = value
    End Set
  End Property

  Public Property Sum() As Boolean
    Get
      Return booSum
    End Get
    Set(ByVal value As Boolean)
      booSum = value
    End Set
  End Property

End Class

Public Enum KTExcelColumnDatatypes
  Formula
  Numeric
  Text
  [Date]
  [Decimal]
End Enum
