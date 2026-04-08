Imports appSopimusrekisteri.BLL
Imports appSopimusrekisteri.DTO

Public Class Hakualue

    Inherits BaseControl

    Public Property TyhjaaSessionHakuehto As Boolean = False

    Private rivienNakyvaMaara As Integer = CType(ConfigurationManager.AppSettings("HakutulostenListanPituus"), Integer)
    Private rivienMaksimimaara As Integer = CType(ConfigurationManager.AppSettings("HakutulostenMaksimimaara"), Integer)

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If TyhjaaSessionHakuehto Then
                Session("hakuehto") = String.Empty
            End If

            If Not Session("hakuehto") = String.Empty Then
                rblHakutyyppi.SelectedValue = Session("hakutyyppi")
            End If

            If Not Session("hakuehto") = String.Empty Then
                txtHaku.Text = Session("hakuehto")
            End If

            If Not Session("hakujoukko") Is Nothing And Not Session("hakuehto") = String.Empty Then
                SuoritaHaku()
            End If

        End If

    End Sub

    Private Sub SuoritaHaku()

        '31.12.2013 Ari Vaara - Hakutoiminnallisuuden luominen

        Session("hakutyyppi") = rblHakutyyppi.SelectedValue

        Dim data As List(Of iHakutulos)

        If txtHaku.Text <> Session("hakuehto") Or rblHakutyyppi.SelectedValue <> Session("hakuehto") Then
            ' Jos hakuehtoja on muutettu haetaan uudet tulokset kannasta.
            data = HaeTuloksetKannasta()

        Else
            ' Jos sessiosta löytyy tavaraa se haetaan sieltä hakulistaa varten.
            data = If(Session("hakujoukko") Is Nothing, New List(Of iHakutulos), Session("hakujoukko"))

            If Not data.Any() Then
                ' Jos hakuehtoja on muutettu haetaan uudet tulokset kannasta.
                data = HaeTuloksetKannasta()
            End If

        End If

        If data.Where(Function(x) Not x.Disabloitu).Count = 1 Then
            Response.Redirect(Me.HaeUrl(data.First(Function(x) Not x.Disabloitu)))
        ElseIf data.Count = 0 Then
            Response.Redirect("~/Etusivu.aspx")
        End If

        If data.Count > rivienNakyvaMaara Then
            If String.IsNullOrWhiteSpace(txtHaku.Text) Then
                hlLisaHakutulokset.NavigateUrl = HaeHakemistopolku() + "Haku.aspx?action=haku&kaikki=true"
            Else
                hlLisaHakutulokset.NavigateUrl = HaeHakemistopolku() + "Haku.aspx?action=haku&ehto=" & Server.UrlEncode(txtHaku.Text)
            End If
            hlLisaHakutulokset.Visible = True
        Else
            hlLisaHakutulokset.Visible = False
        End If

        lstwHaku.DataSource = data.Take(rivienNakyvaMaara)
        lstwHaku.DataBind()

    End Sub

    Private Function HaeHakemistopolku() As String

        Select Case rblHakutyyppi.SelectedValue

            Case Enumeraattorit.Hakutyyppi.Taho

                Return "~/Taho/"

            Case Enumeraattorit.Hakutyyppi.Kiinteisto

                Return "~/Kiinteisto/"

            Case Enumeraattorit.Hakutyyppi.Sopimus

                Return "~/Sopimus/"

        End Select

        Return String.Empty ' Let's keep the compiler happy!

    End Function

    Private Function HaeTuloksetKannasta() As List(Of iHakutulos)

        Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
        Dim data As List(Of DTO.iHakutulos) = Nothing
        Dim tulostenMaara As Integer
        Dim hakutyyppi As String = String.Empty

        Select Case rblHakutyyppi.SelectedValue

            Case Enumeraattorit.Hakutyyppi.Taho

                hakutyyppi = "tahohaku"
                data = tietokanta.HaeTahot(txtHaku.Text)
                tulostenMaara = tietokanta.HaeTahojenMaara(txtHaku.Text)

            Case Enumeraattorit.Hakutyyppi.Kiinteisto

                hakutyyppi = "kiinteistohaku"
                data = tietokanta.HaeKiinteistot(txtHaku.Text)
                tulostenMaara = tietokanta.HaeKiinteistojenMaara(txtHaku.Text)

            Case Enumeraattorit.Hakutyyppi.Sopimus

                hakutyyppi = "sopimushaku"
                data = tietokanta.HaeSopimukset(txtHaku.Text)
                tulostenMaara = tietokanta.HaeSopimustenMaara(txtHaku.Text)

        End Select

        If tulostenMaara = 0 Then
            lblLkm.Text = "Haulla ei löytynyt tuloksia"
        Else
            lblLkm.Text = String.Format("Tuloksia löytyi yhteensä {0} kappaletta", tulostenMaara)
        End If

        ' Runnotaan aina onnistuneen haun jälkeen tavaraa sessioon.
        Session(String.Format("{0}-hakujoukko", hakutyyppi)) = data.ToList()
        Session("hakutyyppi") = rblHakutyyppi.SelectedValue
        Session("hakuehto") = txtHaku.Text
        Return data

    End Function

    Private Sub lstwHaku_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lstwHaku.ItemDataBound

        Dim rivi = DirectCast(e.Item.DataItem, iHakutulos)
        Dim url = Me.HaeUrl(rivi)

        Dim linkki = CType(e.Item.FindControl("hlLinkki"), HyperLink)
        If Not String.IsNullOrEmpty(url) Then
            linkki.NavigateUrl = url
            linkki.Text = If(String.IsNullOrWhiteSpace(rivi.Nimi), "Nimetön " + rivi.Tyyppi.ToLower(), rivi.Nimi)
        Else
            linkki.Visible = False
        End If

        If rivi.Disabloitu Then
            linkki.Enabled = False
        Else
            linkki.Enabled = True
        End If

    End Sub

    Private Function HaeUrl(rivi As iHakutulos) As String

        Dim url As String = String.Empty

        Select Case rivi.Tyyppi

            Case "Henkilö"

                url = "~/Taho/Henkilo/Tiedot.aspx?id="

            Case "Organisaatio"

                url = "~/Taho/Organisaatio/Tiedot.aspx?id="

            Case "Kiinteistö"

                url = "~/Kiinteisto/Tiedot.aspx?id="

            Case "Sopimus"

                url = "~/Sopimus/Sopimus.ashx?id="

        End Select

        Return url & rivi.ID

    End Function

    Private Sub btnHae_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHae.Click

        txtHaku.Text = txtHaku.Text.Trim()
        Session("hakuehto") = txtHaku.Text
        Session("hakutyyppi") = rblHakutyyppi.SelectedValue
        SuoritaHaku()

    End Sub

    Private Sub btnHaeTahoja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHaeTahoja.Click

        ' Force page reload... to clear the parameters...
        If Request.Url.AbsolutePath.Contains("Taho/Haku") Then
            Response.Redirect(Request.RawUrl)
        Else
            Response.Redirect("~/Taho/Haku.aspx", True)
        End If

    End Sub

    Private Sub btnHaeKiinteistoja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHaeKiinteistoja.Click

        ' Force page reload... to clear the parameters...
        If Request.Url.AbsolutePath.Contains("Kiinteisto/Haku") Then
            Response.Redirect(Request.RawUrl)
        Else
            Response.Redirect("~/Kiinteisto/Haku.aspx", True)
        End If

    End Sub

    Private Sub btnHaeSopimuksia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHaeSopimuksia.Click

        ' Force page reload... to clear the parameters...
        If Request.Url.AbsolutePath.Contains("Sopimus/Haku") Then
            Response.Redirect(Request.RawUrl)
        Else
            Response.Redirect("~/Sopimus/Haku.aspx", True)
        End If

    End Sub
End Class