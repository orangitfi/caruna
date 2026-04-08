Public Class Kirjautuminen

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not String.IsNullOrWhiteSpace(Context.User.Identity.Name) Then
            Response.Redirect("~/Etusivu.aspx")
        End If

    End Sub

    Protected Sub Login1_LoginError(sender As Object, e As EventArgs) Handles Login1.LoginError

        Dim virhe As New CustomValidator()
        virhe.ErrorMessage = "Kirjautuminen epäonnistui. Tarkista käyttäjätunnuksesi ja salasanasi."
        virhe.IsValid = False
        Page.Validators.Add(virhe)

    End Sub

    Protected Sub Login1_LoggedIn(sender As Object, e As EventArgs) Handles Login1.LoggedIn

        Dim kayttaja = Membership.GetUser(Login1.UserName)
        If kayttaja.CreationDate = kayttaja.LastPasswordChangedDate Then
            Response.Redirect("~/Kayttaja/Profiili.aspx?action=changepassword")
        Else
            Response.Redirect("~/Etusivu.aspx")
        End If

        'FormsAuthentication.RedirectFromLoginPage(Login1.UserName, True)

    End Sub
End Class