Public Class Roolit

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            TaytaRoolit()

        End If

    End Sub

    Private Sub TaytaRoolit()

        Dim roolilista = New DataTable()
        roolilista.Columns.Add("Nimi")
        roolilista.Columns.Add("Käyttäjämäärä")

        For Each rooli In Roles.GetAllRoles()

            Dim roolirivi = {rooli, Roles.GetUsersInRole(rooli).Length}
            roolilista.Rows.Add(roolirivi)

        Next

        gwTulokset.DataSource = roolilista
        gwTulokset.DataBind()

    End Sub

    Private Sub gwTulokset_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gwTulokset.RowDeleting

        Dim poistettavaRivi = gwTulokset.Rows(e.RowIndex)
        Dim poistettavaRooli = CType(poistettavaRivi.FindControl("lblNimi"), Literal).Text

        If Roles.RoleExists(poistettavaRooli) Then

            Dim roolinKayttajat = Roles.GetUsersInRole(poistettavaRooli)
            If roolinKayttajat.Length > 0 Then

                Roles.RemoveUsersFromRole(roolinKayttajat, poistettavaRooli)

            End If
        End If

        Roles.DeleteRole(poistettavaRooli)

        TaytaRoolit()

    End Sub

End Class