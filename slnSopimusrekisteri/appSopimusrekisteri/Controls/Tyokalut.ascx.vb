Public Class Tyokalut

    Inherits BaseControl

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnHenkilo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHenkilo.Click
        Response.Redirect("~/Taho/Henkilo/Muokkaa.aspx", True)
    End Sub

    Private Sub btnOrganisaatio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrganisaatio.Click
        Response.Redirect("~/Taho/Organisaatio/Muokkaa.aspx", True)
    End Sub

    Protected Sub btnKiinteisto_Click(sender As Object, e As EventArgs) Handles btnKiinteisto.Click
        Response.Redirect("~/Kiinteisto/Muokkaa.aspx", True)
    End Sub

    Protected Sub btnSopimus_Click(sender As Object, e As EventArgs) Handles btnSopimus.Click
        Response.Redirect("~/Sopimus/Valitse.aspx", True)
    End Sub
End Class