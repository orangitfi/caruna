Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class barcode1
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '9.2.2011 Janne Hakkarainen
    'luo viivakoodikuvan annettujen tietojen perusteella ja palauttaa kuvan responsessa

    Try

      'koodi
      Dim strCode As String = Request.Params("code")

      'lisätiedot, käytetään oletuksia, jos ei saada arvoja
      Dim intThickness As Integer = 1
      Dim intHeight As Integer = 50
      Dim intQuietZone As Integer = 20

      If IsNumeric(Request.Params("thickness")) Then
        intThickness = CInt(Request.Params("thickness"))
      End If

      If IsNumeric(Request.Params("height")) Then
        intHeight = CInt(Request.Params("height"))
      End If

      If IsNumeric(Request.Params("quietZone")) Then
        intQuietZone = CInt(Request.Params("quietZone"))
      End If

      If strCode <> "" Then

        Dim objBarcode As New BLL.Barcode(strCode)

        objBarcode.LineThickness = intThickness
        objBarcode.Height = intHeight
        objBarcode.QuietZone = intQuietZone

        Dim objBitmap As Bitmap = objBarcode.GetBarcodeImage()

        Response.Clear()

        Response.ContentType = "image/png"

        Dim ms As New MemoryStream()

        objBitmap.Save(ms, ImageFormat.Png)

        ms.WriteTo(Response.OutputStream)

        Response.End()

      End If

    Catch ex As Exception

    End Try

  End Sub

End Class