Public Class valitseTyyppi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddlTyyppi.Items.Insert(0, New ListItem("Valitse", "Valitse"))
            ddlTyyppi.Items.Insert(1, New ListItem("Johtoaluesopimus", "Johtoaluesopimus"))
            ddlTyyppi.Items.Insert(2, New ListItem("Maakaapeli sijoituslupa", "Maakaapeli sijoituslupa"))
            ddlTyyppi.Items.Insert(3, New ListItem("Muuntamosopimus", "Muuntamosopimus"))
        End If   
    End Sub

    Protected Sub btnJatka_Click(sender As Object, e As EventArgs) Handles btnJatka.Click
        Response.Redirect("~/sopimus_edit.aspx")
    End Sub
End Class