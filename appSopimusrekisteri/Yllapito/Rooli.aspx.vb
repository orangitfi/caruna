
Public Class Rooli

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
         
        End If

    End Sub

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Roles.RoleExists(txtNimi.Text) Then

            Dim virhe As New CustomValidator()
            virhe.ErrorMessage = "Järjestelmässä on jo " + txtNimi.Text + "-niminen rooli"
            virhe.IsValid = False
            Page.Validators.Add(virhe)

        Else

            Roles.CreateRole(txtNimi.Text)
            Response.Redirect("~/Yllapito/Roolit.aspx", True)

        End If

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        Response.Redirect("~/Yllapito/Roolit.aspx", True)

    End Sub

End Class