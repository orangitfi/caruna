Imports appSopimusrekisteri.DTO
Imports appSopimusrekisteri.BLL
Imports Microsoft.Ajax.Utilities

Public Class Tahohaku
  Inherits BasePage2

  Dim ASCENDING As String = "ASC"
  Dim DESCENDING As String = "DESC"

  Private Property Jarjestyssuunta As SortDirection
    Get
      If String.IsNullOrEmpty(ViewState("sortDirection")) Then
        ViewState("sortDirection") = SortDirection.Descending
      End If

      Return CType(ViewState("sortDirection"), SortDirection)
    End Get
    Set(ByVal value As SortDirection)
      ViewState("sortDirection") = value
    End Set
  End Property

  Private Property Jarjestyssarake As String
    Get
      If String.IsNullOrEmpty(ViewState("sortExpression")) Then
        ViewState("sortExpression") = String.Empty
      End If

      Return CType(ViewState("sortExpression"), String)
    End Get
    Set(ByVal value As String)
      ViewState("sortExpression") = value
    End Set
  End Property

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    btnLisaaHenkilo.Visible = False
    btnLisaaOrganisaatio.Visible = False

    If Not Page.IsPostBack Then

      txtTAHEtunimi.Text = String.Empty
      txtTAHSukunimi.Text = String.Empty
      txtTAHTahoId.Text = String.Empty
      txtTAHPostitusosoite.Text = String.Empty
      txtTAHPostituspostinro.Text = String.Empty
      txtTAHPostituspostitmp.Text = String.Empty
      'txtTAHEmail.Text = String.Empty
      'txtKIIOsoite.Text = String.Empty
      'txtKIIKyla.Text = String.Empty
      'txtKIIKunta.Text = String.Empty
      txtSOPMuuTunnus.Text = String.Empty
      txtSOPId.Text = String.Empty
      txtTAHTahoId.Text = String.Empty

      ' Asiakas ei halunnut, että softa muistaa hakuvalintoja.
      'txtTAHEtunimi.Text = Session("tahohaku-etunimi")
      'txtTAHSukunimi.Text = Session("tahohaku-sukunimi")
      'txtTAHEmail.Text = Session("tahohaku-email")
      'txtTAHTahoId.Text = Session("tahohaku-tunniste")
      'txtKIIOsoite.Text = Session("tahohaku-kiinteistonosoite")
      'txtKIIKyla.Text = Session("tahohaku-kiinteistonkyla")
      'txtKIIKunta.Text = Session("tahohaku-kiinteistonkunta")
      'txtSOPMuuTunnus.Text = Session("tahohaku-sopimusmuutunnus")
      'txtSOPId.Text = Session("tahohaku-sopimustunniste")

      If Request.Params("action") <> String.Empty Then

        If Request.Params("ehto") <> String.Empty Then

          If Not Session("tahohaku-hakujoukko") Is Nothing Then

            TeePerushaku()

          Else

            TeeTarkennettuHaku()

          End If

        End If
      End If

      btnPeruuta.Visible = IsNumeric(Request.Params("sopimusid"))

    End If

  End Sub

  Protected Sub btnHaku_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHaku.Click

    ' Asiakas ei halunnut, että softa muistaa hakuvalintoja.
    'Session("tahohaku-etunimi") = txtTAHEtunimi.Text.Trim()
    'Session("tahohaku-sukunimi") = txtTAHSukunimi.Text.Trim()
    'Session("tahohaku-email") = txtTAHEmail.Text.Trim()
    'Session("tahohaku-tunniste") = txtTAHTahoId.Text.Trim()
    'Session("tahohaku-kiinteistonosoite") = txtKIIOsoite.Text.Trim()
    'Session("tahohaku-kiinteistonkyla") = txtKIIKyla.Text.Trim()
    'Session("tahohaku-kiinteistonkunta") = txtKIIKunta.Text.Trim()
    'Session("tahohaku-sopimusmuutunnus") = txtSOPMuuTunnus.Text.Trim()
    'Session("tahohaku-sopimustunniste") = txtSOPId.Text.Trim()

    TeeTarkennettuHaku()

  End Sub

  Private Sub TeePerushaku()

    ViewState("Perushaku") = True

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    Dim tahot = New List(Of DTO.Taho)()

    If Jarjestyssarake = String.Empty Then
      tahot = tietokanta.HaeKaikkiTahot(Request.Params("ehto"))
    Else
      tahot = tietokanta.HaeKaikkiTahot(Request.Params("ehto"), Jarjestyssarake, If(Jarjestyssuunta = SortDirection.Ascending, ASCENDING, DESCENDING))
    End If

    gwTulokset.DataSource = tahot.ToList()
    gwTulokset.DataBind()

    btnLisaaHenkilo.Visible = True
    btnLisaaOrganisaatio.Visible = True
    lblLukumaara.Text = "Tuloksia löytyi yhteensä " & tahot.Count & " kappaletta."

  End Sub

  Private Sub TeeTarkennettuHaku()

    ViewState("Perushaku") = False

    Dim hakuehdot = New DTO.TahojenHaku
    hakuehdot.Etunimi = txtTAHEtunimi.Text.Trim()
    hakuehdot.Sukunimi = txtTAHSukunimi.Text.Trim()
    hakuehdot.Asiakasnumero = txtTAHTahoId.Text.Trim()
    hakuehdot.AsiakkaanOsoite = txtTAHPostitusosoite.Text
    hakuehdot.AsiakkaanPostinumero = txtTAHPostituspostinro.Text()
    hakuehdot.AsiakkaanPostitoimipaikka = txtTAHPostituspostitmp.Text
    'hakuehdot.Email = txtTAHEmail.Text.Trim()
    'hakuehdot.KiinteistonOsoite = txtKIIOsoite.Text.Trim()
    'hakuehdot.KiinteistonKyla = txtKIIKyla.Text.Trim()
    'hakuehdot.KiinteistonKunta = txtKIIKunta.Text.Trim()
    hakuehdot.SopimuksenTunniste = txtSOPId.Text.Trim()
    hakuehdot.SopimuksenMuuTunniste = txtSOPMuuTunnus.Text.Trim()

    Dim tietokanta = New BLL.Haku()
    Dim tahot = New List(Of DTO.Taho)()

    If Jarjestyssarake = String.Empty Then
      tahot = tietokanta.HaeKaikkiTahot(hakuehdot)
    Else
      tahot = tietokanta.HaeKaikkiTahot(hakuehdot, Jarjestyssarake, If(Jarjestyssuunta = SortDirection.Ascending, ASCENDING, DESCENDING))
    End If

    gwTulokset.DataSource = tahot
    gwTulokset.DataBind()

    btnLisaaHenkilo.Visible = True
    btnLisaaOrganisaatio.Visible = True
    lblLukumaara.Text = "Tuloksia löytyi yhteensä " & tahot.Count & " kappaletta."

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

      ' Mahdollista henkilön tai organisaation valinta kiinteistölle, sopimukselle tai korvauslaskelmalle.
      If IsNumeric(Request.Params("korvauslaskelmaid")) And IsNumeric(Request.Params("sopimusid")) Then
        CType(e.Row.FindControl("hlValitseKorvauslaskelmalle"), HyperLink).NavigateUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}&tahoid={2}", Request.Params("korvauslaskelmaid"), Request.Params("sopimusid"), rivi.Id)
        CType(e.Row.FindControl("hlValitseKorvauslaskelmalle"), HyperLink).Visible = True
      ElseIf IsNumeric(Request.Params("kiinteistoid")) Then
        CType(e.Row.FindControl("hlValitseKiinteistölle"), HyperLink).NavigateUrl = String.Format("~/Kiinteisto/Tiedot.aspx?id={0}&tahoid={1}", Request.Params("kiinteistoid"), rivi.Id)
        CType(e.Row.FindControl("hlValitseKiinteistölle"), HyperLink).Visible = True
      ElseIf IsNumeric(Request.Params("sopimusid")) Then
        CType(e.Row.FindControl("hlValitseSopimukselle"), HyperLink).NavigateUrl = String.Format("~/Taho/Sopimustaho.aspx?sopimusId={0}&tahoId={1}", Request.Params("sopimusid"), rivi.Id)
        CType(e.Row.FindControl("hlValitseSopimukselle"), HyperLink).Visible = True
      End If

      'CType(e.Row.FindControl("hlMuokkaa"), HyperLink).NavigateUrl = String.Format("~/Taho/{0}/Muokkaa.aspx?id={1}&sopimusid={2}&tyyppi={3}", url, rivi.ID, Request.Params("sopimusid"), Request.Params("tyyppi"))

    End If

  End Sub

  Protected Sub btnLisaaHenkilo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLisaaHenkilo.Click
    If IsNumeric(Request.Params("sopimusid")) Then
      Response.Redirect(String.Format("~/Taho/Henkilo/Muokkaa.aspx?sopimusId={0}", Request.Params("sopimusid")))
    Else
      Response.Redirect("~/Taho/Henkilo/Muokkaa.aspx")
    End If
  End Sub

  Protected Sub btnLisaaOrganisaatio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLisaaOrganisaatio.Click
    If IsNumeric(Request.Params("sopimusid")) Then
      Response.Redirect(String.Format("~/Taho/Organisaatio/Muokkaa.aspx?sopimusId={0}", Request.Params("sopimusid")))
    Else
      Response.Redirect("~/Taho/Organisaatio/Muokkaa.aspx")
    End If
  End Sub

  Protected Sub gwTulokset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwTulokset.PageIndexChanging

    gwTulokset.PageIndex = e.NewPageIndex

    If ViewState("Perushaku") = True Then
      TeePerushaku()
    Else
      TeeTarkennettuHaku()
    End If

  End Sub

  Protected Sub gwTulokset_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gwTulokset.Sorting

    Jarjestyssarake = e.SortExpression
    If (Jarjestyssuunta = SortDirection.Ascending) Then
      Jarjestyssuunta = SortDirection.Descending
    Else
      Jarjestyssuunta = SortDirection.Ascending
    End If

    If ViewState("Perushaku") = True Then
      TeePerushaku()
    Else
      TeeTarkennettuHaku()
    End If

  End Sub

  Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

    If IsNumeric(Request.Params("sopimusid")) Then
      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Request.Params("sopimusid")))
    End If

  End Sub

End Class