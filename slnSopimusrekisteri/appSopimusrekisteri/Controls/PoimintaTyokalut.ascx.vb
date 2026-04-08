Public Class PoimintaTyokalut
  Inherits BaseControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      lbNollaaSarakkeet.Visible = Not Sessio.PoiminnanSarakkeetSopimukselle(Session) Is Nothing

      If New BLL.Poiminta().HaePoimintaSopimustenLkm(Context.Session.SessionID) > 0 Then
        phJoukkolisays.Visible = True
      End If
    End If

  End Sub

  Protected Sub lbNollaaSarakkeet_Click(sender As Object, e As EventArgs) Handles lbNollaaSarakkeet.Click

    Sessio.PoiminnanSarakkeetSopimukselle(Session) = Nothing
    Sessio.PoiminnanSarakkeetKiinteistolle(Session) = Nothing
    Sessio.PoiminnanSarakkeetTaholle(Session) = Nothing

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

End Class