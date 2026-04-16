Imports KT.Utils

Public Class KorkoprosentinTiedot
    Inherits BasePage2

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            AlustaSivu()

        End If

    End Sub

    Private Sub AlustaSivu()

        lstTulokset.DataSource = DataContext.Korkoprosentit.OrderBy(Function(x) x.Vuodet).ThenBy(Function(x) x.Prosentti).ToList()
        lstTulokset.DataBind()

        lblTiedot.Text = lstTulokset.Items.Count & " kpl"

    End Sub

    Protected Sub lstTulokset_ItemEditing(sender As Object, e As ListViewEditEventArgs)

        Dim id = WebUtils.GetListViewDataKeyValue(Of Integer)(lstTulokset, lstTulokset.Items(e.NewEditIndex), "Id")

        Response.Redirect(String.Format("~/Ohjaustiedot/Korkoprosentti/Muokkaa.aspx?id={0}", id))

    End Sub

    Protected Sub lstTulokset_ItemDeleting(sender As Object, e As ListViewDeleteEventArgs)

        Dim id = WebUtils.GetListViewDataKeyValue(Of Integer)(lstTulokset, lstTulokset.Items(e.ItemIndex), "Id")
        Dim korko = DataContext.Korkoprosentit.FirstOrDefault(Function(x) x.Id = id)

        If Not korko Is Nothing Then

            Dim sopimukset = DataContext.Sopimukset.Where(Function(x) x.LahdeKorkoprosenttiId = id).ToList()

            For Each sop In sopimukset
                sop.LahdeKorkoprosenttiId = Nothing
            Next

            DataContext.Korkoprosentit.Remove(korko)
            DataContext.SaveChanges()

            AlustaSivu()

        End If

    End Sub

End Class