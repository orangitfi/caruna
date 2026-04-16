Imports System.Web
Imports System.Web.Services
Imports Sopimusrekisteri.BLL_CF
Imports TemplateHandler

Namespace Sopimus.Suostumus

  Public Class Tulosta
    Inherits BaseHandler(Of Sopimusrekisteri.BLL_CF.Sopimus)

    Overrides Sub ProcessRequest(ByVal context As HttpContext)
      MyBase.ProcessRequest(context)

      If Me.EntityId.HasValue Then

        Dim template As String = Io.YhdistaKansioJaTiedosto(Hakemistot.TemplateHakemisto, HaePohja())

        Dim tiedostonimi As String = Me.EntityId & "_Suostumus.pdf"

        Dim tuloste As SopimusTuloste = Me.Handlers.Sopimustulosteet.HaeSopimuksenTuloste(Me.EntityId)

        Dim data As Byte()

        If Not Me.Entity.Hyvaksytty Or tuloste Is Nothing Then

          Dim ctx As New SuostumusTemplateContext()

          Dim sisalto As String = System.IO.File.ReadAllText(template)

          sisalto = TemplateHandler.TemplateHandler.GetRelpacedContent(sisalto, New SuostumusTemplate(ctx), Me.Entity, ctx)

          Dim liite As String = Me.HaeLiite()

          If Not String.IsNullOrEmpty(liite) Then
            data = PdfHelper.GeneratePDFFromHTML(sisalto, 750, EvoPdf.HtmlToPdf.PdfPageOrientation.Portrait, Konfiguraatiot.PdfLisenssi, Hakemistot.Juuri, Io.YhdistaKansioJaTiedosto(Hakemistot.LiiteHakemisto, Me.HaeLiite()))
          Else
            data = PdfHelper.GeneratePDFFromHTML(sisalto, 750, EvoPdf.HtmlToPdf.PdfPageOrientation.Portrait, Konfiguraatiot.PdfLisenssi, Hakemistot.Juuri)
          End If


          If tuloste Is Nothing Then

            tuloste = New SopimusTuloste()
            tuloste.SopimusId = Me.EntityId

          End If

          tuloste.Tuloste = data

          Me.Handlers.Sopimustulosteet.SaveEntity(tuloste)

        Else

          data = tuloste.Tuloste

        End If

        If Not data Is Nothing Then

          HttpContext.Current.Response.Clear()
          HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=" + tiedostonimi)
          HttpContext.Current.Response.AddHeader("Content-Length", data.Length.ToString())
          HttpContext.Current.Response.ContentType = Konfiguraatiot.PdfContentType
          HttpContext.Current.Response.BinaryWrite(data)
          HttpContext.Current.Response.Flush()
          HttpContext.Current.Response.End()

        End If

      End If

    End Sub

    Private Function HaePohja() As String

      If Me.Entity.SopimustyyppiId = Sopimustyypit.CCAPylvaidenLuovutuskirja Then
        Return Tiedostot.CCAPylvaidenLuovutuskirja
      End If

      If Me.Entity.KieliId = Kielet.Ruotsi Then
        Return Tiedostot.SuostumuspohjaRuotsi
      End If

      Return Tiedostot.Suostumuspohja
    End Function

    Private Function HaeLiite() As String

      If Me.Entity.SopimustyyppiId = Sopimustyypit.CCAPylvaidenLuovutuskirja Then
        Return Tiedostot.CCALiite
      End If

      Return String.Empty

    End Function

  End Class

End Namespace