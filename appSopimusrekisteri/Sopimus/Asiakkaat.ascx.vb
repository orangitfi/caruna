Imports Sopimusrekisteri.BLL_CF

Public Class Asiakkaat
  Inherits ListControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()

    End If

  End Sub

  Private Sub AsetaOikeudet()

    btLisaaHenkiloasiakas.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)
    btLisaaYritysasiakas.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)
    btLisaaOlemassaolevaAsiakas.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)

  End Sub

  Public Sub ListaaData(data As IEnumerable(Of SopimusTaho))

    gvAsiakkaat.DataSource = data
    gvAsiakkaat.DataBind()

  End Sub

  Private Sub gvAsiakkaat_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAsiakkaat.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then

      Dim sopimusTaho As Sopimusrekisteri.BLL_CF.SopimusTaho = CType(e.Row.DataItem, Sopimusrekisteri.BLL_CF.SopimusTaho)

      CType(e.Row.FindControl("hlValitse"), HyperLink).Text = sopimusTaho.TahoId.ToString()
      If sopimusTaho.Taho.TyyppiId = TahoTyypit.Henkilo Then
        CType(e.Row.FindControl("hlValitse"), HyperLink).NavigateUrl = String.Format("~/Taho/Henkilo/Tiedot.aspx?id={0}&sopimusId={1}", sopimusTaho.TahoId, Me.EntityId.ToString())
      Else
        CType(e.Row.FindControl("hlValitse"), HyperLink).NavigateUrl = String.Format("~/Taho/Organisaatio/Tiedot.aspx?id={0}&sopimusId={1}", sopimusTaho.TahoId, Me.EntityId.ToString())
      End If

      CType(e.Row.FindControl("hlMuokkaa"), HyperLink).NavigateUrl = String.Format("~/Taho/Sopimustaho.aspx?id={0}", sopimusTaho.Id.ToString())

      CType(e.Row.FindControl("hlMuokkaa"), HyperLink).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)
      CType(e.Row.FindControl("lbPoista"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)

    End If

  End Sub

  Private Sub gvAsiakkaat_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAsiakkaat.RowDeleting

    Dim id As Integer = CInt(gvAsiakkaat.DataKeys.Item(e.RowIndex).Value)

    If Me.Handlers.SopimusTahot.IsDeleteOk(id) Then

      Me.Handlers.SopimusTahot.DeleteEntityAndSave(id)

      MyBase.RaiseItemDeletedEvent()

    Else

      JavascriptAvustaja.LisaaAlert(Me.Page, "Asiakasta ei voi poistaa")

    End If

  End Sub

  Protected Sub btLisaaHenkiloasiakas_Click(sender As Object, e As EventArgs) Handles btLisaaHenkiloasiakas.Click

    Response.Redirect(String.Format("~/Taho/Henkilo/Muokkaa.aspx?sopimusId={0}", Me.EntityId.ToString()))

  End Sub

  Protected Sub btLisaaYritysasiakas_Click(sender As Object, e As EventArgs) Handles btLisaaYritysasiakas.Click

    Response.Redirect(String.Format("~/Taho/Organisaatio/Muokkaa.aspx?sopimusId={0}", Me.EntityId.ToString()))

  End Sub

  Protected Sub btLisaaOlemassaolevaAsiakas_Click(sender As Object, e As EventArgs) Handles btLisaaOlemassaolevaAsiakas.Click

    Response.Redirect(String.Format("~/Taho/Haku.aspx?sopimusId={0}", Me.EntityId.ToString()))

  End Sub

End Class