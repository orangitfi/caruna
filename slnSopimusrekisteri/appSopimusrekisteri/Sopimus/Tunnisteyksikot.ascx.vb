Public Class Tunnisteyksikot
  Inherits BaseControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then
      AsetaOikeudet()
      TaytaData()
    End If

  End Sub

  Private Sub AsetaOikeudet()
    btnLisaaTunnisteyksikko.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TunnisteYksikkoMuokkaus)
  End Sub

  Public Sub TaytaData()

    If Me.SopimusId.HasValue Then

      Dim tietokanta = New appSopimusrekisteri.BLL.Tunnisteyksikko(_konteksti)

      Dim tunnisteyksikot = tietokanta.HaeSopimuksenTunnisteyksikot(Me.SopimusId)

      btnLisaaTunnisteyksikko.PostBackUrl = String.Format("~/Tunnisteyksikko/Muokkaa.aspx?sopimusid={0}", Me.SopimusId)

      gvTunnisteyksikot.DataSource = tunnisteyksikot
      gvTunnisteyksikot.DataBind()
      gvTunnisteyksikot.Visible = True

    Else

      gvTunnisteyksikot.Visible = False

    End If

  End Sub

  Public Property SopimusId As Integer?
    Set(value As Integer?)
      hdnSopimusId.Value = value
    End Set
    Get
      If IsNumeric(hdnSopimusId.Value) Then
        Return CInt(hdnSopimusId.Value)
      Else
        Return Nothing
      End If
    End Get
  End Property

  Private Sub gvTunnisteyksikot_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTunnisteyksikot.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim rivi = DirectCast(e.Row.DataItem, DTO.Tunnisteyksikko)
      CType(e.Row.FindControl("hlValitse"), LinkButton).Text = rivi.Id
      CType(e.Row.FindControl("hlValitse"), LinkButton).PostBackUrl = String.Format("~/Tunnisteyksikko/Tiedot.aspx?id={0}&sopimusid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Tunnisteyksikko/Muokkaa.aspx?id={0}&sopimusid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlPoista"), LinkButton).CommandArgument = rivi.Id

      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TunnisteYksikkoMuokkaus)
      CType(e.Row.FindControl("hlPoista"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TunnisteYksikkoMuokkaus)
    End If

  End Sub

  Private Sub gvTunnisteyksikot_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvTunnisteyksikot.RowDeleting

    Dim poistettavaRivi = gvTunnisteyksikot.Rows(e.RowIndex)

    Dim poistettavanId = CType(poistettavaRivi.FindControl("hlPoista"), LinkButton).CommandArgument

    Dim tietokanta = New BLL.Tunnisteyksikko(_konteksti)

    tietokanta.PoistaTunnisteyksikko(poistettavanId)

    TaytaData()

  End Sub

End Class