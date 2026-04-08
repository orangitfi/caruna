Public Class Haku
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hlSopimus.Visible = False
        hlTontti.Visible = False
    End Sub


    Protected Sub btnHae_Click(sender As Object, e As EventArgs) Handles btnHae.Click
        If rbSopimus.Checked Then
            hlSopimus.Visible = True
        ElseIf rbTontti.Checked Then
            hlTontti.Visible = True
        Else
            hlSopimus.Visible = True
            hlTontti.Visible = True
        End If
    End Sub

    Protected Sub rbTontti_CheckedChanged(sender As Object, e As EventArgs) Handles rbTontti.CheckedChanged
        If rbTontti.Checked Then
            rbSopimus.Checked = False
        End If
    End Sub

    Protected Sub rbSopimus_CheckedChanged(sender As Object, e As EventArgs) Handles rbSopimus.CheckedChanged
        If rbSopimus.Checked Then
            rbTontti.Checked = False
        End If
    End Sub
End Class