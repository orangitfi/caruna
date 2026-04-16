Public Class Etusivu

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    tehtavalista1.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.Aktiviteetit)

    Haku.TyhjaaSessionHakuehto = True
  End Sub

End Class