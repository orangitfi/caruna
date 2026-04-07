Imports System.Web
Imports System.Web.Services
Imports Sopimusrekisteri.BLL_CF
Imports TemplateHandler

Namespace Sopimus.Muuntamo

  Public Class Tulosta
    Inherits BaseHandler(Of Sopimusrekisteri.BLL_CF.Sopimus)

    Overrides Sub ProcessRequest(ByVal context As HttpContext)
      MyBase.ProcessRequest(context)

      If Me.EntityId.HasValue Then

        Dim template As String = Io.YhdistaKansioJaTiedosto(Hakemistot.TemplateHakemisto, HaePohja())

        Dim tiedostonimi As String = Me.EntityId & "_Muuntamosopimus.pdf"

        Dim tuloste As SopimusTuloste = Me.Handlers.Sopimustulosteet.HaeSopimuksenTuloste(Me.EntityId)

        Dim data As Byte()

        If Not Me.Entity.Hyvaksytty Or tuloste Is Nothing Then

          Dim ctx As ITemplateContext
          Dim entityTemplate As ITemplateEntity

          Dim liitepolku As String = String.Empty

          If Me.Entity.SopimustyyppiId = Sopimustyypit.Muuntamosopimus Then
            ctx = New MuuntamonSijoitussopimusContext()
            entityTemplate = New MuuntamonSijoitussopimusTemplate(ctx)
            liitepolku = Io.YhdistaKansioJaTiedosto(Hakemistot.LiiteHakemisto, Me.HaeLiite())
          Else
            ctx = New MuuntamosopimusTemplateContext()
            entityTemplate = New MuuntamosopimusTemplate(ctx)
          End If

          Dim sisalto As String = System.IO.File.ReadAllText(template)

          sisalto = TemplateHandler.TemplateHandler.GetRelpacedContent(sisalto, entityTemplate, Me.Entity, ctx)

          data = PdfHelper.GeneratePDFFromHTML(sisalto, 750, EvoPdf.HtmlToPdf.PdfPageOrientation.Portrait, Konfiguraatiot.PdfLisenssi, Hakemistot.Juuri, liitepolku)

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

      If Me.Entity.SopimustyyppiId = Sopimustyypit.Kiinteistomuuntamosopimus Then
        Return Me.HaeKiinteistoMuuntamosopimuksenPohja()
      Else Me.Entity.SopimustyyppiId = Sopimustyypit.Muuntamosopimus
        Return Me.HaeMuuntamosopimuksenPohja()
      End If

    End Function

    Private Function HaeKiinteistoMuuntamosopimuksenPohja() As String

      If Me.Entity.KieliId = Kielet.Ruotsi Then

        If Me.Entity.Korvauslaskelmat.All(Function(x) x.KorvaustyyppiId = Korvaustyypit.Kertakorvaus) Then
          Return Tiedostot.KiinteistoMuuntamosopimuspohjaKertaRuotsiksi
        End If

        Return Tiedostot.KiinteistoMuuntamosopimuspohjaVuosiRuotsiksi

      End If

      If Me.Entity.Korvaukseton Then
        Return Tiedostot.KiinteistoMuuntamosopimuspohjaIlmanKorvausta
      End If

      If Me.Entity.Korvauslaskelmat.All(Function(x) x.KorvaustyyppiId = Korvaustyypit.Kertakorvaus) Then
        Return Tiedostot.KiinteistoMuuntamosopimuspohjaKerta
      End If

      Return Tiedostot.KiinteistoMuuntamosopimuspohjaVuosi

    End Function

    Private Function HaeMuuntamosopimuksenPohja() As String

      If Me.Entity.KieliId = Kielet.Ruotsi Then
        Return Tiedostot.MuuntamoalueSijoitussopimuspohjaRuotsiksi
      End If

      Return Tiedostot.MuuntamoalueSijoitussopimuspohja

      'If Me.Entity.Korvaukseton Then
      '  Return Tiedostot.MuuntamoaluesopimuspohjaIlmanKorvausta
      'End If

      'Return Tiedostot.Muuntamoaluesopimuspohja

    End Function

    Private Function HaeLiite() As String

      If Me.Entity.KieliId = Kielet.Ruotsi Then
        Return Tiedostot.JASLiiteIkahyvitysRuotsi
      End If

      Return Tiedostot.JASLiiteIkahyvitys

    End Function

  End Class

End Namespace