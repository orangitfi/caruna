Public Class HenkiloTyokalut
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnOrganisaatio_Click(sender As Object, e As EventArgs) Handles btnOrganisaatio.Click
        Response.Redirect("~/valitseTyyppi.aspx")
    End Sub

End Class