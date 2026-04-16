Public Class IFRS
    Inherits BaseHandler(Of Sopimusrekisteri.BLL_CF.IFRSHistoriaExcel)

    Overrides Sub ProcessRequest(ByVal context As HttpContext)
        MyBase.ProcessRequest(context)

        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.IFRS) Then
            context.Response.End()
            Return
        End If

        If Me.EntityId.HasValue Then

            Dim tiedosto As Sopimusrekisteri.BLL_CF.IFRSHistoriaExcel = Me.Handlers.IFRSHistoriaExcel.LoadEntity(Me.EntityId.Value)

            context.Response.Clear()
            context.Response.AddHeader("content-disposition", "inline; filename=""" & tiedosto.Nimi & """")
            context.Response.AddHeader("Content-Length", tiedosto.Sisalto.Length)
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            context.Response.BinaryWrite(tiedosto.Sisalto)
            context.Response.Flush()
            context.Response.End()

        End If

    End Sub

End Class