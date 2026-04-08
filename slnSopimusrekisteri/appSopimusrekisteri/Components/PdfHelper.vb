Imports EvoPdf.HtmlToPdf
Imports System.Text.RegularExpressions

Public Class PdfHelper

  Public Shared Function GeneratePDFFromHTML(ByVal html As String, ByVal pdfWidth As Integer, ByVal orientation As PdfPageOrientation, Optional ByVal strLicensekey As String = "", Optional ByVal baseUrl As String = "", Optional ByVal liitepolku As String = "") As Byte()
    '29.12.2009 Janne Hakkarainen
    Dim strTrimmedHtml As String = ""
    strTrimmedHtml = Regex.Replace(html, "</?(a|A).*?>", "").Trim()

    Dim pdfConverter As PdfConverter = New PdfConverter()

    If strLicensekey <> "" Then
      pdfConverter.LicenseKey = strLicensekey
    End If

    pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression
    pdfConverter.PdfDocumentOptions.PdfPageOrientation = orientation
    pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4
    pdfConverter.PdfDocumentOptions.FitWidth = True
    pdfConverter.PdfDocumentOptions.AutoSizePdfPage = True
    pdfConverter.PdfDocumentOptions.ShowHeader = False
    pdfConverter.PdfDocumentOptions.ShowFooter = False

    pdfConverter.HtmlViewerWidth = pdfWidth
    pdfConverter.PdfFooterOptions.DrawFooterLine = False
    pdfConverter.PdfDocumentOptions.EmbedFonts = True

    Dim pdfBytes As Byte()

    If Not String.IsNullOrEmpty(liitepolku) Then
      pdfConverter.PdfDocumentOptions.AppendedPdfFile = liitepolku
    End If

    If baseUrl <> "" Then
      pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(strTrimmedHtml, baseUrl)
    Else
      pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(strTrimmedHtml)
    End If

    Return pdfBytes

  End Function

End Class
