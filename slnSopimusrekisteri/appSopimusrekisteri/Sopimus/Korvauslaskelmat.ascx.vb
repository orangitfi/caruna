Imports Sopimusrekisteri.BLL_CF

Public Class Korvauslaskelmat
  Inherits ListControl

  Dim summa As Decimal

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()

    End If

  End Sub

  Private Sub AsetaOikeudet()
    btLisaaKorvauslaskelma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)
  End Sub

  Public Sub ListaaData(data As IEnumerable(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma))

    gvKorvauslaskelma.DataSource = data
    gvKorvauslaskelma.DataBind()

  End Sub

  Private Sub gvKorvauslaskelma_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvKorvauslaskelma.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then

      Dim korvauslaskelma As Sopimusrekisteri.BLL_CF.Korvauslaskelma = CType(e.Row.DataItem, Sopimusrekisteri.BLL_CF.Korvauslaskelma)

      summa += korvauslaskelma.VerollinenSumma

      CType(e.Row.FindControl("hlValitse"), HyperLink).Text = korvauslaskelma.Id.ToString()
      CType(e.Row.FindControl("hlValitse"), HyperLink).NavigateUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusId={1}", korvauslaskelma.Id.ToString(), Me.EntityId.ToString())

      CType(e.Row.FindControl("hlMuokkaa"), HyperLink).NavigateUrl = String.Format("~/Korvauslaskelma/Muokkaa.aspx?id={0}&sopimusId={1}", korvauslaskelma.Id.ToString(), Me.EntityId.ToString())

      'CType(e.Row.FindControl("lbPoista"), LinkButton).CommandArgument = korvauslaskelma.Id.ToString()

      CType(e.Row.FindControl("lblKorvauslaskelmanSumma"), Label).Text = TypeFormatters.FormatDecimal(korvauslaskelma.VerollinenSumma)


      CType(e.Row.FindControl("hlMuokkaa"), HyperLink).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)
      CType(e.Row.FindControl("lbPoista"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)

      'ei näytetä muokkausnappia jos maksettu ja ei ole oikeuksia
      If korvauslaskelma.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Maksettu Then
        CType(e.Row.FindControl("hlMuokkaa"), HyperLink).Enabled = RooliAvustaja.OikeusMuokataMaksettuaKorvauslaskelmaa(Context.User.Identity.Name) And Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)
        CType(e.Row.FindControl("hlMuokkaa"), HyperLink).Visible = RooliAvustaja.OikeusMuokataMaksettuaKorvauslaskelmaa(Context.User.Identity.Name) And Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)
      End If

    ElseIf e.Row.RowType = DataControlRowType.Footer Then
      CType(e.Row.FindControl("lblKorvauslaskelmienSumma"), Label).Text = TypeFormatters.FormatDecimal(summa)
    End If

  End Sub

  Private Sub gvKorvauslaskelma_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvKorvauslaskelma.RowDeleting

    Dim id As Integer = CInt(gvKorvauslaskelma.DataKeys.Item(e.RowIndex).Value)

    If Me.Handlers.Korvauslaskelmat.IsDeleteOk(id) Then

      Me.Handlers.Korvauslaskelmat.DeleteEntityAndSave(id)

      MyBase.RaiseItemDeletedEvent()

    Else

      JavascriptAvustaja.LisaaAlert(Me.Page, "Korvauslaskelmaa ei voi poistaa")

    End If

  End Sub

  Protected Sub btLisaaKorvauslaskelma_Click(sender As Object, e As EventArgs) Handles btLisaaKorvauslaskelma.Click

    Response.Redirect(String.Format("~/Korvauslaskelma/Muokkaa.aspx?sopimusid={0}", Me.EntityId))

  End Sub

End Class