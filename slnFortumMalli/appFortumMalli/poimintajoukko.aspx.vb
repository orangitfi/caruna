Public Class poimintajoukko
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnUusiPoiminta_Click(sender As Object, e As EventArgs) Handles btnUusiPoiminta.Click
        Response.Redirect("~/poimintalomake.aspx")
    End Sub
End Class