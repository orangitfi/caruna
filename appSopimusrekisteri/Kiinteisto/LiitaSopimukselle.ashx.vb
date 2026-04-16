Imports System.Web
Imports System.Web.Services

Public Class LiitaSopimukselle
  Inherits BaseHandler

  Overrides Sub ProcessRequest(ByVal context As HttpContext)
    MyBase.ProcessRequest(context)

    If Me.SopimusId.HasValue And Me.KiinteistoId.HasValue Then

      Me.Handlers.SopimusKiinteistot.LisaaKiinteistoSopimukselle(Me.SopimusId.Value, Me.KiinteistoId.Value)

      Me.Context.Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.SopimusId.ToString()))

    End If

  End Sub

  Protected ReadOnly Property SopimusId As Integer?
    Get
      If IsNumeric(Me.Context.Request.Params("sopimusId")) Then
        Return CInt(Me.Context.Request.Params("sopimusId"))
      End If

      Return Nothing
    End Get
  End Property

  Protected ReadOnly Property KiinteistoId As Integer?
    Get
      If IsNumeric(Me.Context.Request.Params("kiinteistoId")) Then
        Return CInt(Me.Context.Request.Params("kiinteistoId"))
      End If

      Return Nothing
    End Get
  End Property

End Class