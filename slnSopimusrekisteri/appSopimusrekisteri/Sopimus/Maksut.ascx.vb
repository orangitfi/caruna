Public Class Maksut
  Inherits BaseControl

  Dim summa As Decimal

  Private _passivointiOikeus As Boolean = False

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    _passivointiOikeus = Roles.IsUserInRole(Konfiguraatio.Roolit.MaksutMuokkaus)

    If Not IsPostBack Then
      TaytaData()
    End If

  End Sub

  Public Sub TaytaData()

    If Me.SopimusId.HasValue Then

      Dim tietokanta = New appSopimusrekisteri.BLL.Maksuaineisto(_konteksti)

      Dim maksuaineistot = tietokanta.HaeMaksuaineistot(Me.SopimusId.Value).OrderByDescending(Function(x) x.MAKMaksupaiva)

      gvMaksut.DataSource = maksuaineistot
      gvMaksut.DataBind()
      gvMaksut.Visible = True

    Else

      gvMaksut.Visible = False

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

  Private Sub gvMaksut_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMaksut.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim rivi = DirectCast(e.Row.DataItem, Entities.Maksu)

      Dim maksunSumma = If(rivi.MAKSumma Is Nothing, 0, rivi.MAKSumma.Value)

      summa += maksunSumma

      CType(e.Row.FindControl("lblMaksuaineistonSumma"), Label).Text = Decimal.Round(maksunSumma, 2)
      CType(e.Row.FindControl("hlValitseKorvauslaskelma"), LinkButton).Text = rivi.MAKKorvauslaskelmaId
      CType(e.Row.FindControl("hlValitseKorvauslaskelma"), LinkButton).PostBackUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}&tyyppi=JAS", rivi.MAKKorvauslaskelmaId, Request.Params("id"))
      CType(e.Row.FindControl("hlValitseMaksuaineisto"), LinkButton).Text = rivi.MAKId
      CType(e.Row.FindControl("hlValitseMaksuaineisto"), LinkButton).PostBackUrl = String.Format("~/Maksuaineisto/Tiedot.aspx?id={0}&sopimusid={1}&tyyppi=JAS", rivi.MAKId, Request.Params("id"))

      CType(e.Row.FindControl("lbPassivoi"), LinkButton).Visible = _passivointiOikeus
      CType(e.Row.FindControl("lbPassivoi"), LinkButton).Enabled = _passivointiOikeus

    ElseIf e.Row.RowType = DataControlRowType.Footer Then
      CType(e.Row.FindControl("lblMaksuaineistojenSumma"), Label).Text = Decimal.Round(summa, 2)
    End If

  End Sub

  Protected Sub gvMaksut_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvMaksut.RowCommand
    If e.CommandName = "passivoi" Then
      Dim tietokanta = New appSopimusrekisteri.BLL.Maksu(_konteksti)
      tietokanta.PassivoiMaksu(e.CommandArgument)
      TaytaData()
    End If
  End Sub
End Class