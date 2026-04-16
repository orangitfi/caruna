Imports System.Web
Imports System.Web.Services
Imports Sopimusrekisteri.BLL_CF

Public Class SopimusRedirect
  Inherits BaseHandler(Of Sopimusrekisteri.BLL_CF.Sopimus)

  Overrides Sub ProcessRequest(ByVal context As HttpContext)
    MyBase.ProcessRequest(context)

    Dim strUrl As String = "~/Sopimus/{0}/Tiedot.aspx"

    If Me.EntityId.HasValue Then

      context.Response.Redirect(Hakemistot.HaeSopimusHakemisto(Me.Entity.SopimustyyppiId) & "Tiedot.aspx" & Url.KoostaQueryString(context.Request.QueryString))

    End If

  End Sub

End Class