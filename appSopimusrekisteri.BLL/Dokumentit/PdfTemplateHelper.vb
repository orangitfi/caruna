'TEMPORARILY COMMENTED OUT - REQUIRES EVOPDF LIBRARY
'Imports EvoPdf.HtmlToPdf
Imports System.Text.RegularExpressions

Public Class PdfTemplateHelper

  'TEMPORARILY COMMENTED OUT - REQUIRES EVOPDF LIBRARY
  'Public Shared Function GeneratePDFFromHTML(ByVal path As String, ByVal html As String, ByVal pdfWidth As Integer, ByVal orientation As PdfPageOrientation, Optional ByVal strLicensekey As String = "", Optional ByVal baseUrl As String = "") As Integer
  Public Shared Function GeneratePDFFromHTML(ByVal path As String, ByVal html As String, ByVal pdfWidth As Integer, ByVal orientation As Object, Optional ByVal strLicensekey As String = "", Optional ByVal baseUrl As String = "") As Integer
    '29.12.2009 Janne Hakkarainen
    'TEMPORARILY DISABLED - REQUIRES EVOPDF LIBRARY
    Throw New NotImplementedException("PDF generation requires EvoPDF library. Contact your team to obtain it.")

    'Dim strTrimmedHtml As String = ""
    'strTrimmedHtml = Regex.Replace(html, "</?(a|A).*?>", "").Trim()

    'Dim pdfConverter As PdfConverter = New PdfConverter()

    'If strLicensekey <> "" Then
    '  pdfConverter.LicenseKey = strLicensekey
    'End If

    'pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression
    'pdfConverter.PdfDocumentOptions.PdfPageOrientation = orientation
    'pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4
    'pdfConverter.PdfDocumentOptions.FitWidth = True
    'pdfConverter.PdfDocumentOptions.AutoSizePdfPage = True
    'pdfConverter.PdfDocumentOptions.ShowHeader = False
    'pdfConverter.PdfDocumentOptions.ShowFooter = False

    'pdfConverter.HtmlViewerWidth = pdfWidth
    'pdfConverter.PdfFooterOptions.DrawFooterLine = False
    'pdfConverter.PdfDocumentOptions.EmbedFonts = True

    ''If ConfigurationManager.AppSettings("VuositukijaPdfConversionDelay") <> "" Then
    ''    pdfConverter.ConversionDelay = CInt(ConfigurationManager.AppSettings("VuositukijaPdfConversionDelay"))
    ''End If

    'Dim pdfBytes As Byte()

    'pdfConverter.PdfDocumentOptions.AppendedPdfFile = "C:\Temp\CarunaAineistot\testi.pdf"

    'If baseUrl <> "" Then
    '  pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(strTrimmedHtml, baseUrl)
    'Else
    '  pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(strTrimmedHtml)
    'End If

    'My.Computer.FileSystem.WriteAllBytes(path, pdfBytes, False)

    'Return pdfConverter.ConversionSummary.PdfPageCount

  End Function

  'TEMPORARILY COMMENTED OUT - REQUIRES EVOPDF LIBRARY
  'Public Shared Function GeneratePDFFromHTML(ByVal html As String, ByVal pdfWidth As Integer, ByVal orientation As PdfPageOrientation, Optional ByVal strLicensekey As String = "", Optional ByVal baseUrl As String = "") As Byte()
  Public Shared Function GeneratePDFFromHTML(ByVal html As String, ByVal pdfWidth As Integer, ByVal orientation As Object, Optional ByVal strLicensekey As String = "", Optional ByVal baseUrl As String = "") As Byte()
    '29.12.2009 Janne Hakkarainen
    'TEMPORARILY DISABLED - REQUIRES EVOPDF LIBRARY
    Throw New NotImplementedException("PDF generation requires EvoPDF library. Contact your team to obtain it.")

    'Dim strTrimmedHtml As String = ""
    'strTrimmedHtml = Regex.Replace(html, "</?(a|A).*?>", "").Trim()

    'Dim pdfConverter As PdfConverter = New PdfConverter()

    'If strLicensekey <> "" Then
    '  pdfConverter.LicenseKey = strLicensekey
    'End If

    'pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression
    'pdfConverter.PdfDocumentOptions.PdfPageOrientation = orientation
    'pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4
    'pdfConverter.PdfDocumentOptions.FitWidth = True
    'pdfConverter.PdfDocumentOptions.AutoSizePdfPage = True
    'pdfConverter.PdfDocumentOptions.ShowHeader = False
    'pdfConverter.PdfDocumentOptions.ShowFooter = False

    'pdfConverter.HtmlViewerWidth = pdfWidth
    'pdfConverter.PdfFooterOptions.DrawFooterLine = False
    'pdfConverter.PdfDocumentOptions.EmbedFonts = True

    'Dim pdfBytes As Byte()

    'If baseUrl <> "" Then
    '  pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(strTrimmedHtml, baseUrl)
    'Else
    '  pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(strTrimmedHtml)
    'End If

    'Return pdfBytes

  End Function

End Class
