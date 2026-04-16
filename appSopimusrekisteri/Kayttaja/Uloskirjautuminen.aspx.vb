
Public Class Uloskirjautuminen

  Inherits BasePage

  Protected Overloads Sub OnInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    FormsAuthentication.SignOut()
    Roles.DeleteCookie()
    Session.Abandon()
    Response.Redirect("~/Etusivu.aspx", True)

  End Sub

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

    End If

  End Sub

End Class