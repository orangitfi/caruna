Imports Sopimusrekisteri.BLL_CF

Namespace Sopimus.Suostumus

    Public Class Tiedot
        Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Sopimus)

        Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then

                Me.AlustaSivu()

                Me.AsetaNakyvyydet()

                Me.TaytaLomake()

            End If

        End Sub

        Private Sub AlustaSivu()

            imgPrint.Attributes.Add("onclick", "window.open('Tulosta.ashx?id=" & Me.EntityId.ToString() & "');return false;")
            JavascriptAvustaja.LisaaTuplaklikinEstoVarmistuksella(btnPoista, Me, "Haluatko varmasti poistaa sopimuksen lopullisesti? Kaikki sopimukseen liittyvät tiedot poistetaan myös. Tietoja ei voida palauttaa.")

        End Sub

        Private Sub AsetaNakyvyydet()

            phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusLaaja)
            phIFRS.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.IFRS)
            Kiinteistot1.Visible = (Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoSuppea) Or Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoLaaja))
            Asiakkaat1.Visible = (Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasSuppea) Or Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasLaaja))
            Tiedostot1.Visible = (Roles.IsUserInRole(Konfiguraatio.Roolit.TiedostoSuppea) Or Roles.IsUserInRole(Konfiguraatio.Roolit.TiedostoLaaja))
            Aktiviteetit1.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.Aktiviteetit)

            btnMuokkaa.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusMuokkaus)
            btnLisaaAlasopimus.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusMuokkaus) And Me.Entity.YlasopimuksenTyyppiId.HasValue
            btnPoista.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusMuokkaus) And Entity.SopimuksenTilaId = SopimusTilat.Poistettu
            btnKopioi.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusMuokkaus)

        End Sub

        Private Sub TaytaLomake()

            Me.FormMapper.FillForm(Me.headerData, Me.Entity, "h")
            Me.FormMapper.FillForm(Me.formData, Me.Entity)

            If Me.Entity.PaasopimusId.HasValue Then
                Me.Paasopimus_Nimi.NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.Entity.PaasopimusId.ToString())
            End If

            lblIFRS.Text = UiHelper.RivitaHtml(If(Entity.FAS, "FAS: Kyllä", "FAS: Ei"),
                                               If(Entity.IFRS, "IFRS16: Kyllä", "IFRS16: Ei"),
                                               If(Not Entity.Vuokratyyppi Is Nothing, "Vuokratyyppi: " & Entity.Vuokratyyppi.Nimi, Nothing),
                                               If(Entity.Korkoprosentti.HasValue, "Korkoprosentti: " & Entity.Korkoprosentti.Value.ToString("0.00") & " %", Nothing))

            Me.TaytaTunnisteyksikot()
            Me.TaytaAsiakkaat()
            Me.TaytaKiinteistot()
            Me.TaytaTiedostot()
            Me.TaytaAktiviteetit()
            Me.TaytaAlasopimukset()

        End Sub

        Private Sub TaytaAktiviteetit()

            Aktiviteetit1.SopimusId = Me.EntityId.Value

        End Sub

        Private Sub TaytaKiinteistot()

            Kiinteistot1.SopimusId = Me.EntityId.Value

        End Sub

        Private Sub TaytaAsiakkaat()

            Asiakkaat1.EntityId = Me.EntityId.Value
            Asiakkaat1.ListaaData(Me.Entity.Asiakkaat)

        End Sub

        Private Sub TaytaTunnisteyksikot()

            Tunnisteyksikot1.SopimusId = Me.EntityId.Value

        End Sub

        Private Sub TaytaTiedostot()

            Tiedostot1.SopimusId = Me.EntityId.Value

        End Sub

        Private Sub TaytaAlasopimukset()

            Alasopimukset.Visible = Entity.YlasopimuksenTyyppiId.HasValue

            If Alasopimukset.Visible Then
                Alasopimukset.SopimusId = Me.EntityId.Value
                Alasopimukset.TaytaData()
            End If

        End Sub

        Protected Sub btnMuokkaa_Click(sender As Object, e As EventArgs) Handles btnMuokkaa.Click

            Response.Redirect(String.Format("Muokkaa.aspx?id={0}", Me.EntityId.ToString()))

        End Sub

        Protected Sub btnLisaaAlasopimus_Click(sender As Object, e As EventArgs) Handles btnLisaaAlasopimus.Click

            Response.Redirect(String.Format("~/Sopimus/Alasopimus.aspx?id={0}", Me.EntityId.ToString()))

        End Sub

        Protected Sub btnKopioi_Click(sender As Object, e As EventArgs) Handles btnKopioi.Click

            Response.Redirect(String.Format("~/Sopimus/Suostumus/Muokkaa.aspx?kopioId={0}&tyyppi={1}", Me.EntityId.ToString(), CInt(Me.Entity.SopimustyyppiId).ToString()))

        End Sub

        Private Sub ItemDeletedEventHandler() Handles Asiakkaat1.ItemDeleted

            Me.TaytaAsiakkaat()

        End Sub

        Protected Sub btnPoista_Click(sender As Object, e As EventArgs)
            lblPoistoVirhe.Visible = False
            Dim palaute = SopimusAvustaja.PoistaLopullisesti(Entity)

            If palaute.Ok Then
                Response.Redirect("~/")
            Else
                lblPoistoVirhe.Visible = True
                lblPoistoVirhe.Text = palaute.Viesti
            End If
        End Sub

    End Class

End Namespace