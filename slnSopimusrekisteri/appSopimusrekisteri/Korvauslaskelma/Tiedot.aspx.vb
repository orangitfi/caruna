Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils

Namespace Korvauslaskelma

    Public Class Tiedot
        Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)

        Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then

                If Not Me.Request.UrlReferrer Is Nothing AndAlso Me.Request.UrlReferrer.AbsolutePath = "/Taho/Valitse.aspx" Then
                    Me.LiitaSaaja()
                End If

                Me.AlustaSivu()

                Me.AsetaNakyvyydet()

                Me.TaytaLomake()

            End If

        End Sub
        Private Sub LiitaSaaja()

            If Me.TahoId.HasValue And Not Me.Entity.SaajaId.HasValue Then

                Me.Entity.SaajaId = Me.TahoId

                Me.EntityHandler.SaveEntity(Me.Entity)

            End If

        End Sub

        Private Sub AlustaSivu()

            hlSopimus.NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.Entity.SopimusId.ToString())
            hlSopimus.Text = Me.Entity.SopimusId.ToString() & " " & Me.Entity.Sopimus.MuuTunniste & " (" & Me.Entity.Sopimus.Sopimusvuosi.ToString() & ")"

            btnTakaisin.PostBackUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.Entity.SopimusId.ToString())

            btnMuokkaa.PostBackUrl = String.Format("Muokkaa.aspx?id={0}&sopimusid={1}", Me.EntityId.ToString(), Me.Entity.SopimusId.ToString())

            btLisaaRiviKorvauslaskelmalle.PostBackUrl = String.Format("~/Korvauslaskelma/Rivi/Muokkaa.aspx?korvauslaskelmaid={0}&sopimusid={1}", Me.EntityId.ToString(), Me.Entity.SopimusId.ToString())

        End Sub

        Private Sub AsetaNakyvyydet()

            phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaLaaja)

            btnMuokkaa.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)
            btnLisaaMaksu.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaMuokkaus)

            If Me.Entity.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Maksettu Then
                btnMuokkaa.Visible = RooliAvustaja.OikeusMuokataMaksettuaKorvauslaskelmaa(Context.User.Identity.Name)
                btnMuokkaa.Enabled = RooliAvustaja.OikeusMuokataMaksettuaKorvauslaskelmaa(Context.User.Identity.Name)
            End If

            phAlv.Visible = (Me.Entity.Sopimus.SopimustyyppiId = Sopimustyypit.Muuntamosopimus Or Me.Entity.Sopimus.SopimustyyppiId = Sopimustyypit.Kiinteistomuuntamosopimus)
            phLisaMaksutiedot.Visible = (Me.Entity.Sopimus.SopimustyyppiId = Sopimustyypit.Muuntamosopimus Or Me.Entity.Sopimus.SopimustyyppiId = Sopimustyypit.Vuokrasopimus Or Me.Entity.Sopimus.SopimustyyppiId = Sopimustyypit.SuurjanniteverkkoVuokrasopimus)

            btLisaaKorvauksenSaaja.Visible = (Not Me.Entity.SaajaId.HasValue)
            btPoistaKorvauksenSaaja.Visible = Me.Entity.SaajaId.HasValue

            If Me.Entity.KorvaustyyppiId.HasValue AndAlso Me.Entity.KorvaustyyppiId.Value = Korvaustyypit.Kertakorvaus Then
                btnLisaaMaksu.Visible = (Me.Entity.KorvauslaskelmaStatusId.HasValue AndAlso Me.Entity.KorvauslaskelmaStatusId.Value = KorvauslaskelmaStatukset.Hyvaksytty And Roles.IsUserInRole(Konfiguraatio.Roolit.Maksut))
            ElseIf Me.Entity.KorvaustyyppiId.HasValue AndAlso (Me.Entity.KorvaustyyppiId.Value = Korvaustyypit.Kuukausivuokra Or Me.Entity.KorvaustyyppiId.Value = Korvaustyypit.Vuosimaksu) Then
                btnLisaaMaksu.Visible = ((Me.Entity.KorvauslaskelmaStatusId.HasValue AndAlso (Me.Entity.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Hyvaksytty Or Me.Entity.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Maksettu)) And Roles.IsUserInRole(Konfiguraatio.Roolit.Maksut))
            Else
                btnLisaaMaksu.Visible = False
            End If

        End Sub

        Private Sub TaytaLomake()

            lblNimi.Text = "Korvauslaskelma " + Me.EntityId.ToString()

            Me.FormMapper.FillForm(Me.formData, Me.Entity)

            If Not Me.Entity.Alv Is Nothing Then
                lblAlv.Text = "(" & Luvut.EsitaNullableDecimal(Me.Entity.Alv.Prosentti) & " %)"
            End If

            If Me.Entity.OnIndeksi Then
                Dim maksuunMenevaArvo As Decimal? = LaskeMaksuunMenevaSumma()
                MaksuunMenevaSumma.Text = Luvut.EsitaNullableDecimal(maksuunMenevaArvo)
            End If

            Me.TaytaRivit()
            Me.TaytaHistoria()

        End Sub

        Private Function LaskeMaksuunMenevaSumma()
            Dim ohjaustietohandleri = New Sopimusrekisteri.DAL_CF.EntityHandlers.OhjaustietoHandler(Me.DataContext)
            Dim korvauslaskelmahandleri = New Sopimusrekisteri.DAL_CF.EntityHandlers.KorvauslaskelmaHandler(Me.DataContext)
            Dim indeksit As List(Of Indeksi) = ohjaustietohandleri.HaeVuodenIndeksit(DateTime.Now.Year).ToList()
            Dim maksuunMenevaArvo = korvauslaskelmahandleri.haeMaksuunMenevaArvo(indeksit, Me.Entity)
            Return maksuunMenevaArvo
        End Function

        Private Sub TaytaRivit()
            Dim t = Me.Entity.Rivit
            gwKorvauslaskelmatRivit.DataSource = Me.Entity.Rivit
            gwKorvauslaskelmatRivit.DataBind()

        End Sub

        Private Sub TaytaHistoria()

            If Not Me.Entity.Historia Is Nothing Then

                imgStatus.ToolTip = Join(Me.Entity.Historia.Where(Function(x) x.StatusId.HasValue).OrderBy(Function(x) x.Luotu).Select(Function(x) x.Status.Nimi & " " & x.Luoja & " " & x.Luotu.ToShortDateString()).ToArray(), vbCrLf)

            End If

        End Sub

        Private Sub gwKorvauslaskelmatRivit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwKorvauslaskelmatRivit.RowDataBound

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim rivi As KorvauslaskelmaRivi = CType(e.Row.DataItem, KorvauslaskelmaRivi)
                CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Korvauslaskelma/Rivi/Muokkaa.aspx?id={0}&korvauslaskelmaid={1}&sopimusid={2}", rivi.Id.ToString(), Me.EntityId.ToString(), Me.Entity.SopimusId.ToString())
                CType(e.Row.FindControl("hlPoista"), LinkButton).CommandArgument = rivi.Id.ToString()
            End If

        End Sub

        Private Sub gwKorvauslaskelmatRivit_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gwKorvauslaskelmatRivit.RowDeleting

            Dim rivi As GridViewRow = gwKorvauslaskelmatRivit.Rows(e.RowIndex)

            Dim id As Integer = CInt(CType(rivi.FindControl("hlPoista"), LinkButton).CommandArgument)

            Dim korvauslaskemaRivi As KorvauslaskelmaRivi = Me.Handlers.Korvauslaskelmarivit.LoadEntity(id)

            Me.Handlers.Korvauslaskelmarivit.DeleteEntityAndSave(korvauslaskemaRivi)

            TaytaRivit()

        End Sub

        Protected Sub btLisaaKorvauksenSaaja_Click(sender As Object, e As EventArgs) Handles btLisaaKorvauksenSaaja.Click

            Response.Redirect(String.Format("~/Taho/Valitse.aspx?korvauslaskelmaid={0}&sopimusid={1}", Me.EntityId.ToString(), Me.Entity.SopimusId.ToString()), True)

        End Sub

        Protected Sub btPoistaKorvauksenSaaja_Click(sender As Object, e As EventArgs) Handles btPoistaKorvauksenSaaja.Click

            Me.Entity.SaajaId = Nothing

            Me.EntityHandler.SaveEntity(Me.Entity)

            Response.Redirect(Me.Request.Url.AbsoluteUri)

        End Sub

        Private Sub imgPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles imgPrint.Click

            Server.Transfer(String.Format("~/Korvauslaskelma/Tulosta.aspx?id={0}&sopimusid={1}", Me.EntityId.ToString(), Me.Entity.SopimusId.ToString()))

        End Sub

        Protected Sub btnLisaaMaksu_Click(sender As Object, e As EventArgs) Handles btnLisaaMaksu.Click

            Response.Redirect(String.Format("~/Maksut/Lisaa.aspx?korvauslaskelmaId={0}&sopimusid={1}", Me.EntityId.ToString(), Me.Entity.SopimusId.ToString()))

        End Sub

        Protected ReadOnly Property TahoId As Integer?
            Get
                If Not String.IsNullOrEmpty(ViewState("tahoId")) Then
                    Return CInt(ViewState("tahoId"))
                End If

                If IsNumeric(Request.QueryString("tahoId")) Then
                    ViewState("tahoId") = Request.QueryString("tahoId")
                    Return CInt(ViewState("tahoId"))
                End If

                Return Nothing
            End Get
        End Property

    End Class

End Namespace