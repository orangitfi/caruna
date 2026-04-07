Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF

Public Class Tiedosto
    Inherits BaseHandler(Of Sopimusrekisteri.BLL_CF.Tiedosto)

    Overrides Sub ProcessRequest(ByVal context As HttpContext)
        MyBase.ProcessRequest(context)

        If Me.EntityId.HasValue Then

            Dim tiedosto As Sopimusrekisteri.BLL_CF.Tiedosto = Me.Handlers.Tiedostot.LoadEntity(Me.EntityId.Value)
            Dim sharepoint = DataUtils.ParseBoolean(context.Request.Params("sharepoint"), False) ' Voidaan pakottaa sharepointista hakemisen

            ' M-Files (uusi)
            If tiedosto.Sijainti = TiedostonSijainti.MFiles AndAlso Not sharepoint Then

                Dim url = String.Format(Konfiguraatiot.MFilesHttpLink, tiedosto.MFilesLink)
                context.Response.Redirect(url)

            Else ' Sharepoint (vanha)

                Dim sisalto As Byte() = Liittymat.Sopimusarkisto.Operaatiot.LueTiedosto(tiedosto)

                context.Response.Clear()

                If Not sisalto Is Nothing Then

                    HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=" + tiedosto.TiedostoNimi)
                    HttpContext.Current.Response.AddHeader("Content-Length", sisalto.Length.ToString())
                    context.Response.ContentType = Konfiguraatiot.PdfContentType
                    context.Response.BinaryWrite(sisalto)

                Else

                    context.Response.Write("Tiedostoa ei löydy")

                End If

            End If

            context.Response.Flush()
            context.Response.End()

        End If

    End Sub

End Class