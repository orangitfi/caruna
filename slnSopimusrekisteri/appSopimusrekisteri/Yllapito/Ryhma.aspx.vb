
Public Class Ryhma

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

        End If

    End Sub

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        Dim id = Request.Params("id")
        Dim guid As Guid
        Dim ryhma = New Entities.aspnet_RoleGroups()
        ryhma.GroupName = txtNimi.Text

        If guid.TryParse(id, guid) Then
            ryhma.GroupId = guid
        End If

        Dim tietokanta = New BLL.Kayttajienhallinta()
        If Not tietokanta.TallennaRyhma(ryhma) Is Nothing Then
            Response.Redirect("~/Yllapito/Ryhmat.aspx", True)
        End If

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        Response.Redirect("~/Yllapito/Ryhmat.aspx", True)

    End Sub

End Class