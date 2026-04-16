Imports System.Web
Imports System.Web.Services
Imports Sopimusrekisteri.BLL_CF
Imports TemplateHandler

Namespace Sopimus.JAS

    Public Class Tulosta
        Inherits BaseHandler(Of Sopimusrekisteri.BLL_CF.Sopimus)

        Overrides Sub ProcessRequest(ByVal context As HttpContext)
            MyBase.ProcessRequest(context)

            If Me.EntityId.HasValue Then

                Dim template As String = Io.YhdistaKansioJaTiedosto(Hakemistot.TemplateHakemisto, HaePohja())

                Dim tiedostonimi As String = Me.EntityId & "_JAS.pdf"

                Dim tuloste As SopimusTuloste = Me.Handlers.Sopimustulosteet.HaeSopimuksenTuloste(Me.EntityId)

                Dim data As Byte()

                If Not Me.Entity.Hyvaksytty Or tuloste Is Nothing Then

                    Dim ctx As New JASTemplateContext()

                    Dim sisalto As String = System.IO.File.ReadAllText(template)

                    sisalto = TemplateHandler.TemplateHandler.GetRelpacedContent(sisalto, New JASTemplate(ctx), Me.Entity, ctx)

                    Dim liitepolku As String = Io.YhdistaKansioJaTiedosto(Hakemistot.LiiteHakemisto, Me.HaeLiite())

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

            If Me.Entity.SopimustyyppiId = Sopimustyypit.JohtoaluesopimusMaakaapeli Then

                If Me.Entity.Korvaukseton And Me.Entity.KieliId = Kielet.Ruotsi Then
                    Return Tiedostot.JASMaakaapeliPohjaKorvauksetonRuotsi
                End If

                If Me.Entity.Korvaukseton Then
                    Return Tiedostot.JASMaakaapeliPohjaKorvaukseton
                End If

                If Me.Entity.KieliId = Kielet.Ruotsi Then
                    Return Tiedostot.JASMaakaapeliPohjaRuotsi
                End If

                If Me.Entity.KieliId = Kielet.Englanti Then
                    Return Tiedostot.JASMaakaapeliPohjaEnglanti
                End If

                Return Tiedostot.JASMaakaapeliPohja

            ElseIf Me.Entity.SopimustyyppiId = Sopimustyypit.Maankayttosopimus Then

                Return Tiedostot.JASMaankayttoPohja

            ElseIf Me.Entity.SopimustyyppiId = Sopimustyypit.Yksityistiesopimus Then

                Return Tiedostot.JASYksityistiePohja

            Else

                If Me.Entity.Korvaukseton And Me.Entity.KieliId = Kielet.Ruotsi Then
                    Return Tiedostot.JASPohjaRuotsi
                End If

                If Me.Entity.Korvaukseton Then
                    Return Tiedostot.JASPohjaKorvaukseton
                End If

                If Me.Entity.KieliId = Kielet.Englanti Then
                    Return Tiedostot.JASPohjaEnglanti
                End If

                If Me.Entity.KieliId = Kielet.Ruotsi Then
                    Return Tiedostot.JASPohjaRuotsi
                End If

                Return Tiedostot.JASPohja

            End If

        End Function

        Private Function HaeLiite() As String

            If Me.Entity.KieliId = Kielet.Ruotsi Then
                Return Tiedostot.JASLiiteIkahyvitysRuotsi
            End If

            Return Tiedostot.JASLiiteIkahyvitys

        End Function

    End Class

End Namespace