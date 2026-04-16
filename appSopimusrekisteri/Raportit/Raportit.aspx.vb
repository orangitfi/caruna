Public Class Raportit
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Jostain syystä nämä on mapatty rooliin poiminta site.masterissa, joten laitetaan täälläkin näin
        ulKorvauslaskelma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.Poiminta)
        ulVuokrat.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.Poiminta)

        ulIFRS.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.IFRS)

    End Sub

End Class