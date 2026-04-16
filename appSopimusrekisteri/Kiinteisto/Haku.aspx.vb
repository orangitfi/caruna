Imports appSopimusrekisteri.DTO

Public Class Kiinteistohaku

  Inherits BasePage

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

    btnLisaaKiinteisto.Visible = False

    If Not Page.IsPostBack Then

      'txtKIIKatuosoite.Text = Session("kiinteistohaku-katuosoite")
      'txtKIIPostinumero.Text = Session("kiinteistohaku-postinumero")
      'txtKIIPostitoimipaikka.Text = Session("kiinteistohaku-postitoimipaikka")
      txtKIIKiinteisto.Text = String.Empty
      txtKIIKiinteistotunnusLyhyt.Text = String.Empty
      txtKIIKunta.Text = String.Empty
      txtKIIKyla.Text = String.Empty
      txtKIIRekisterinumero.Text = String.Empty

      ' Asiakas ei halunnut, että softa muistaa hakuvalintoja.
      'txtKIIKatuosoite.Text = Session("kiinteistohaku-katuosoite")
      'txtKIIKiinteisto.Text = Session("kiinteistohaku-kiinteisto")
      'txtKIIPostinumero.Text = Session("kiinteistohaku-postinumero")
      'txtKIIPostitoimipaikka.Text = Session("kiinteistohaku-postitoimipaikka")

      If Request.Params("action") <> String.Empty Then

        If Request.Params("ehto") <> String.Empty Then

          TeePerushaku()

        Else

          TeeTarkennettuHaku()

        End If


      End If

      btnPeruuta.Visible = IsNumeric(Request.Params("sopimusid"))

    End If

  End Sub

  Protected Sub btnHaku_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHaku.Click

    ' Resetoidaan järjestysparametrit ja suunnat.
    Jarjestyssarake = String.Empty
    Jarjestyssuunta = SortDirection.Ascending

    ' Asiakas ei halunnut, että softa muistaa hakuvalintoja.
    'Session("kiinteistohaku-katuosoite") = txtKIIKatuosoite.Text.Trim()
    'Session("kiinteistohaku-kiinteisto") = txtKIIKiinteisto.Text.Trim()
    'Session("kiinteistohaku-postinumero") = txtKIIPostinumero.Text.Trim()
    'Session("kiinteistohaku-postitoimipaikka") = txtKIIPostitoimipaikka.Text.Trim()

    TeeTarkennettuHaku()

  End Sub

  Private Sub TeePerushaku()

    ViewState("Perushaku") = True

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

    Dim kiinteistot As List(Of DTO.Kiinteisto)

    If Jarjestyssarake = String.Empty Then
      kiinteistot = tietokanta.HaeKaikkiKiinteistot(Request.Params("ehto"))
    Else
      kiinteistot = tietokanta.HaeKaikkiKiinteistot(Request.Params("ehto"), Jarjestyssarake, If(Jarjestyssuunta = SortDirection.Ascending, ASCENDING, DESCENDING))
    End If

    gwTulokset.DataSource = kiinteistot.ToList()
    gwTulokset.DataBind()

    btnLisaaKiinteisto.Visible = True
    lblLukumaara.Text = "Tuloksia löytyi yhteensä " & kiinteistot.Count & " kappaletta."

  End Sub

  Private Sub TeeTarkennettuHaku()

    ViewState("Perushaku") = False

    Dim hakuehdot = New DTO.KiinteistojenHaku()
    hakuehdot.Kiinteisto = txtKIIKiinteisto.Text.Trim()
    'hakuehdot.Katuosoite = txtKIIKatuosoite.Text.Trim()
    'hakuehdot.Postinumero = txtKIIPostinumero.Text.Trim()
    'hakuehdot.Postitoimipaikka = txtKIIPostitoimipaikka.Text.Trim()
    hakuehdot.Rekisterinumero = txtKIIRekisterinumero.Text.Trim()
    hakuehdot.LyhytKiinteistotunnus = txtKIIKiinteistotunnusLyhyt.Text.Trim()
    hakuehdot.Kunta = txtKIIKunta.Text.Trim()
    hakuehdot.Kyla = txtKIIKyla.Text.Trim()

    Dim tietokanta = New BLL.Haku()
    Dim kiinteistot As List(Of DTO.Kiinteisto)

    If Jarjestyssarake = String.Empty Then
      kiinteistot = tietokanta.HaeKaikkiKiinteistot(hakuehdot)
    Else
      kiinteistot = tietokanta.HaeKaikkiKiinteistot(hakuehdot, Jarjestyssarake, If(Jarjestyssuunta = SortDirection.Ascending, ASCENDING, DESCENDING))
    End If

    gwTulokset.DataSource = kiinteistot.ToList()
    gwTulokset.DataBind()

    btnLisaaKiinteisto.Visible = True
    lblLukumaara.Text = "Tuloksia löytyi yhteensä " & kiinteistot.Count & " kappaletta."

  End Sub


  Private Sub gwTulokset_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwTulokset.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then

      Dim rivi = DirectCast(e.Row.DataItem, DTO.Kiinteisto)
      'CType(e.Row.FindControl("hlMuokkaa"), HyperLink).NavigateUrl = String.Format("~/Kiinteisto/Muokkaa.aspx?id={0}", rivi.Id)

      If IsNumeric(Request.Params("sopimusid")) Then
        CType(e.Row.FindControl("hlValitseSopimukselle"), HyperLink).NavigateUrl = String.Format("~/Kiinteisto/LiitaSopimukselle.ashx?sopimusId={0}&kiinteistoId={1}", Request.Params("sopimusid"), rivi.Id)
        CType(e.Row.FindControl("hlValitseSopimukselle"), HyperLink).Visible = True
      End If

    End If

  End Sub

  Protected Sub btnLisaaKiinteisto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLisaaKiinteisto.Click
    If IsNumeric(Request.Params("sopimusid")) Then
      Response.Redirect(String.Format("~/Kiinteisto/Muokkaa.aspx?sopimusId={0}", Request.Params("sopimusid")))
    Else
      Response.Redirect("~/Kiinteisto/Muokkaa.aspx")
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