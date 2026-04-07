Public Class Valitse
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then
      TeeHaku()
    End If

  End Sub

  Private Sub TeeHaku()

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

    Dim tahot As New List(Of DTO.Taho)

    If IsNumeric(Request.Params("korvauslaskelmaid")) And IsNumeric(Request.Params("sopimusid")) Then
      tahot = tietokanta.HaeSopimuksenTahot(Request.Params("sopimusid"))
    End If

    gwTulokset.DataSource = tahot
    gwTulokset.DataBind()

    If tahot.Count > 0 Then

      lblLukumaara.Visible = True
      lblLukumaara.Text = "Tuloksia löytyi yhteensä " & tahot.Count & " kappaletta."

    Else

      lblLukumaara.Visible = False

    End If

  End Sub

  Private Sub gwTulokset_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwTulokset.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then

      Dim rivi = DirectCast(e.Row.DataItem, DTO.Taho)
      Dim url As String = String.Empty

      If rivi.Tyyppi = "Henkilö" Then
        ' Häksy.
        CType(e.Row.Controls(2).Controls(0), HyperLink).NavigateUrl = CType(e.Row.Controls(2).Controls(0), HyperLink).NavigateUrl.Replace("TYYPPI", "Henkilo")
        url = "Henkilo"
      ElseIf rivi.Tyyppi = "Organisaatio" Then
        CType(e.Row.Controls(2).Controls(0), HyperLink).NavigateUrl = CType(e.Row.Controls(2).Controls(0), HyperLink).NavigateUrl.Replace("TYYPPI", "Organisaatio")
        url = "Organisaatio"
      Else
        'TODO: Virheilmoitus!
      End If

      If IsNumeric(Request.Params("korvauslaskelmaid")) And IsNumeric(Request.Params("sopimusid")) Then
        CType(e.Row.FindControl("hlValitseKorvauslaskelmalle"), HyperLink).NavigateUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}&tahoid={2}", Request.Params("korvauslaskelmaid"), Request.Params("sopimusid"), rivi.Id)
        CType(e.Row.FindControl("hlValitseKorvauslaskelmalle"), HyperLink).Visible = True
      End If

    End If

  End Sub

  Protected Sub btnPeruuta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPeruuta.Click
    If IsNumeric(Request.Params("korvauslaskelmaid")) And IsNumeric(Request.Params("sopimusid")) Then
      Response.Redirect(String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", Request.Params("korvauslaskelmaid"), Request.Params("sopimusid")))
    End If
  End Sub

  Protected Sub gwTulokset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwTulokset.PageIndexChanging

    gwTulokset.PageIndex = e.NewPageIndex

    TeeHaku()

  End Sub

End Class