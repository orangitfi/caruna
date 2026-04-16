Imports appSopimusrekisteri.DTO

Public Class Sopimushaku

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

        btnLisaaSopimus.Visible = False

        If Not Page.IsPostBack Then

            txtSopimusnumero.Text = String.Empty
            txtSopimusvuosi.Text = String.Empty
            txtSopimusTunniste.Text = String.Empty
            txtOmistajanNimi.Text = String.Empty
            txtKyla.Text = String.Empty
            txtKunta.Text = String.Empty
            txtOsoite.Text = String.Empty
            txtAsiakkaanNimi.Text = String.Empty
            txtPGTunnus.Text = String.Empty
            txtLisatieto.Text = String.Empty
            txtSOPPCSNumero.Text = String.Empty
            ' Asiakas ei halunnut, että softa muistaa hakuvalintoja.
            'txtSopimusnumero.Text = Session("sopimushaku-sopimuksennumero")
            'txtSopimusvuosi.Text = Session("sopimushaku-sopimuksenvuosi")
            'txtSopimusTunniste.Text = Session("sopimushaku-sopimuksenmuutunniste")
            'txtOmistajanNimi.Text = Session("sopimushaku-kiinteistonomistaja")
            'txtKyla.Text = Session("sopimushaku-kiinteistonkyla")
            'txtKunta.Text = Session("sopimushaku-kiinteistonkunta")
            'txtOsoite.Text = Session("sopimushaku-kiinteistonosoite")

            If Request.Params("action") <> String.Empty Then

                If Request.Params("ehto") <> String.Empty Then

                    If Not Session("sopimushaku-hakujoukko") Is Nothing Then

                        TeePerushaku()

                    Else

                        TeeTarkennettuHaku()

                    End If

                End If
            Else

            End If

        End If

    End Sub

    Protected Sub btnHaku_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHaku.Click

        ' Asiakas ei halunnut, että softa muistaa hakuvalintoja.
        'Session("sopimushaku-sopimuksennumero") = txtSopimusnumero.Text.Trim()
        'Session("sopimushaku-sopimuksenvuosi") = txtSopimusvuosi.Text.Trim()
        'Session("sopimushaku-sopimuksenmuutunniste") = txtSopimusTunniste.Text.Trim()
        'Session("sopimushaku-kiinteistonomistaja") = txtOmistajanNimi.Text.Trim()
        'Session("sopimushaku-kiinteistonkyla") = txtKyla.Text.Trim()
        'Session("sopimushaku-kiinteistonkunta") = txtKunta.Text.Trim()
        'Session("sopimushaku-kiinteistonosoite") = txtOsoite.Text.Trim()

        TeeTarkennettuHaku()

    End Sub

    Private Sub TeePerushaku()

        ViewState("Perushaku") = True

        Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

        Dim sopimukset = New List(Of DTO.Sopimus)()

        If Jarjestyssarake = String.Empty Then
            sopimukset = tietokanta.HaeKaikkiSopimukset(Request.Params("ehto"))
        Else
            sopimukset = tietokanta.HaeKaikkiSopimukset(Request.Params("ehto"), Jarjestyssarake, If(Jarjestyssuunta = SortDirection.Ascending, ASCENDING, DESCENDING))
        End If

        gwTulokset.DataSource = sopimukset.ToList()
        gwTulokset.DataBind()

        btnLisaaSopimus.Visible = True
        lblLukumaara.Text = "Tuloksia löytyi yhteensä " & sopimukset.Count & " kappaletta."

    End Sub

    Private Sub TeeTarkennettuHaku()

        ViewState("Perushaku") = False

        Dim hakuehdot = New DTO.SopimuksienHaku()
        hakuehdot.Sopimuksennumero = txtSopimusnumero.Text.Trim()
        hakuehdot.Sopimuksenvuosi = txtSopimusvuosi.Text.Trim()
        hakuehdot.SopimuksenMuuTunniste = txtSopimusTunniste.Text.Trim()
        hakuehdot.KiinteistonOmistaja = txtOmistajanNimi.Text.Trim()
        hakuehdot.KiinteistonKyla = txtKyla.Text.Trim()
        hakuehdot.KiinteistonKunta = txtKunta.Text.Trim()
        hakuehdot.KiinteistonOsoite = txtOsoite.Text.Trim()
        hakuehdot.AsiakkaanNimi = txtAsiakkaanNimi.Text.Trim()
        hakuehdot.PGTunnus = txtPGTunnus.Text.Trim()
        hakuehdot.PCSNumero = txtSOPPCSNumero.Text.Trim()
        hakuehdot.Projektivalvoja = txtProjektivalvoja.Text.Trim()
        hakuehdot.Lisatieto = txtLisatieto.Text.Trim()

        Dim tietokanta = New BLL.Haku()
        Dim sopimukset = New List(Of DTO.Sopimus)()

        If Jarjestyssarake = String.Empty Then
            sopimukset = tietokanta.HaeKaikkiSopimukset(hakuehdot)
        Else
            sopimukset = tietokanta.HaeKaikkiSopimukset(hakuehdot, Jarjestyssarake, If(Jarjestyssuunta = SortDirection.Ascending, ASCENDING, DESCENDING))
        End If

        gwTulokset.DataSource = sopimukset
        gwTulokset.DataBind()

        btnLisaaSopimus.Visible = True
        lblLukumaara.Text = "Tuloksia löytyi yhteensä " & sopimukset.Count & " kappaletta."

    End Sub

    Private Sub gwTulokset_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwTulokset.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim rivi = DirectCast(e.Row.DataItem, DTO.Sopimus)
            Dim nayttolinkki = CType(e.Row.FindControl("hlValitse"), HyperLink)
            'Dim muokkauslinkki = CType(e.Row.FindControl("hlMuokkaa"), HyperLink)


            nayttolinkki.NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", rivi.Id)
            'muokkauslinkki.NavigateUrl = String.Format("~/Sopimus/Suostumus/Muokkaa.aspx?id={0}", rivi.ID)

            If rivi.SopimustyyppiId.HasValue AndAlso rivi.SopimustyyppiId.Value = CInt(Enumeraattorit.Sopimustyyppi.Sopimuspohja) Then
                nayttolinkki.Enabled = False
            Else
                nayttolinkki.Enabled = True
            End If

        End If

    End Sub

    Protected Sub btnLisaaSopimus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLisaaSopimus.Click
        Response.Redirect("~/Sopimus/Valitse.aspx")
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

End Class