Public Class Kiinteistot
  Inherits BaseControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then
      AsetaOikeudet()
      TaytaData()
    End If

  End Sub

  Private Sub AsetaOikeudet()
    btLisaaKiinteisto.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
    btLisaaOlemassaolevaKiinteisto.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
  End Sub

  Public Sub TaytaData()

    If Me.SopimusId.HasValue Then

      Dim tietokanta = New appSopimusrekisteri.BLL.Kiinteisto(_konteksti)
      Dim kiinteistot = tietokanta.HaeSopimuksenKiinteistot(Me.SopimusId)
      btLisaaKiinteisto.PostBackUrl = String.Format("~/Kiinteisto/Muokkaa.aspx?sopimusid={0}", Me.SopimusId)
      btLisaaOlemassaolevaKiinteisto.PostBackUrl = String.Format("~/Kiinteisto/Haku.aspx?sopimusid={0}", Me.SopimusId)

      gvKiinteistot.DataSource = kiinteistot
      gvKiinteistot.DataBind()
      gvKiinteistot.Visible = True

    Else

      gvKiinteistot.Visible = False

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

  Private Sub gvKiinteistot_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvKiinteistot.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim rivi = DirectCast(e.Row.DataItem, DTO.Kiinteisto)
      CType(e.Row.FindControl("hlValitse"), LinkButton).Text = rivi.Id
      CType(e.Row.FindControl("hlValitse"), LinkButton).PostBackUrl = String.Format("~/Kiinteisto/Tiedot.aspx?id={0}&sopimusid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Kiinteisto/Muokkaa.aspx?id={0}&sopimusid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlPoista"), LinkButton).CommandArgument = rivi.Id

      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
      CType(e.Row.FindControl("hlPoista"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
    End If

  End Sub

  Private Sub gvKiinteistot_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvKiinteistot.RowDeleting

    Dim poistettavaRivi = gvKiinteistot.Rows(e.RowIndex)

    Dim poistettavanId = CType(poistettavaRivi.FindControl("hlPoista"), LinkButton).CommandArgument

    Dim tietokanta = New BLL.Kiinteisto(_konteksti)

    tietokanta.PoistaKiinteistoSopimukselta(poistettavanId, Me.SopimusId)

    TaytaData()

  End Sub

End Class