Imports KT.Utils

Public Class VuokratyypinTiedot
    Inherits BasePage2

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            AlustaSivu()

        End If

    End Sub

    Private Sub AlustaSivu()

        lstTulokset.DataSource = DataContext.Vuokratyypit.OrderBy(Function(x) x.Nimi).ToList()
        lstTulokset.DataBind()

        lblTiedot.Text = lstTulokset.Items.Count & " kpl"

    End Sub

    Protected Sub lstTulokset_ItemEditing(sender As Object, e As ListViewEditEventArgs)

        Dim id = WebUtils.GetListViewDataKeyValue(Of Integer)(lstTulokset, lstTulokset.Items(e.NewEditIndex), "Id")

        Response.Redirect(String.Format("~/Ohjaustiedot/Vuokratyyppi/Muokkaa.aspx?id={0}", id))

    End Sub

    Protected Sub lstTulokset_ItemDeleting(sender As Object, e As ListViewDeleteEventArgs)

        Dim id = WebUtils.GetListViewDataKeyValue(Of Integer)(lstTulokset, lstTulokset.Items(e.ItemIndex), "Id")
        Dim tyyppi = DataContext.Vuokratyypit.FirstOrDefault(Function(x) x.Id = id)

        If Not tyyppi Is Nothing Then

            Dim onSopimuksia = DataContext.Sopimukset.Any(Function(x) x.VuokratyyppiId = id)

            If onSopimuksia Then
                JavascriptAvustaja.LisaaAlert(Page, "Rekisterissä on sopimuksia, joihin on valittu tämä vuokratyyppi. Vuokratyyppiä ei voida poistaa.")
                Return
            End If

            DataContext.Vuokratyypit.Remove(tyyppi)
            DataContext.SaveChanges()

            AlustaSivu()

        End If

    End Sub

End Class