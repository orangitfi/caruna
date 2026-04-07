Public Class poimintalomake
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            asetaKunnat()
            asetaKylat()
            asetaPostinrot()
            asetaKestot()
            asetatyypit()
        End If
    End Sub

    Private Sub asetaKunnat()
        ddlKiinteistonKunta.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlKiinteistonKunta.Items.Insert(1, New ListItem("Helsinki", "Helsinki"))
    End Sub

    Private Sub asetaKylat()
        ddlKiinteistonKyla.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlKiinteistonKyla.Items.Insert(1, New ListItem("Oulunkylä", "Oulunkylä"))
    End Sub

    Private Sub asetaPostinrot()
        ddlKiinteistonPostinro.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlKiinteistonPostinro.Items.Insert(1, New ListItem("00600", "00600"))
    End Sub

    Private Sub asetatyypit()
        ddlSopimuksenTyyppi.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlSopimuksenTyyppi.Items.Insert(1, New ListItem("Johtoaluesopimus", "Johtoaluesopimus"))
        ddlSopimuksenTyyppi.Items.Insert(2, New ListItem("Maakaapeli sijoituslupa", "Maakaapeli sijoituslupa"))
        ddlSopimuksenTyyppi.Items.Insert(3, New ListItem("Muuntamosopimus", "Muuntamosopimus"))
    End Sub

    Private Sub asetaKestot()
        ddlKesto.Items.Insert(0, New ListItem("Valitse", "Valitse"))
        ddlKesto.Items.Insert(1, New ListItem("30v", "30v"))
        ddlKesto.Items.Insert(2, New ListItem("50v", "50v"))
        ddlKesto.Items.Insert(3, New ListItem("Pysyvä", "Pysyvä"))
    End Sub

    Protected Sub btnPeru_Click(sender As Object, e As EventArgs) Handles btnPeru.Click
        Response.Redirect("~/default2.aspx")
    End Sub

    Protected Sub btnPoimi_Click(sender As Object, e As EventArgs) Handles btnPoimi.Click
        Response.Redirect("~/poimintajoukko.aspx")
    End Sub
End Class