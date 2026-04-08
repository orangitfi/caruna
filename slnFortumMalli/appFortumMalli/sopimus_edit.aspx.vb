Public Class sopimus_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            asetaKestot()
            asetaYhtiot()
        End If
    End Sub

    Private Sub asetaKestot()
        ddlKesto.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlKesto.Items.Insert(1, New ListItem("30v", "30v"))
        ddlKesto.Items.Insert(2, New ListItem("50v", "50v"))
        ddlKesto.Items.Insert(3, New ListItem("Pysyvä", "Pysyvä"))
    End Sub

    Private Sub asetaYhtiot()
        ddlYhtio.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlYhtio.Items.Insert(1, New ListItem("Fortum sähkönsiirto", "Fortum sähkönsiirto"))
        ddlYhtio.Items.Insert(2, New ListItem("Fortum Espoo distribution", "Fortum Espoo distribution"))
    End Sub

    Protected Sub btnJatka_Click(sender As Object, e As EventArgs) Handles btnJatka.Click
        Response.Redirect("~/perusnaytto_sopimus.aspx")
    End Sub
End Class