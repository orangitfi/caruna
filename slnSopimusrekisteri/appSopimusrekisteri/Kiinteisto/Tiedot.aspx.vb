Public Class KiinteistonTiedot

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()

      Dim id As String = Request.Params("id")
      Dim tahoId As String = Request.Params("tahoid")

      If IsNumeric(id) Then

        ' Varmistetaan ettei käyttäjä onnistu sotkemaan asioita menemällä 
        ' selaimen historiassa olevaan URL:iin ja liittämällä taho kiinteistöön!
        If IsNumeric(tahoId) Then
          If Request.UrlReferrer <> Nothing Then
            If Request.UrlReferrer.PathAndQuery.Contains(String.Format("Taho/Haku.aspx?kiinteistoid={0}", Request.Params("id"))) Then
              Dim tahot = New BLL.Taho(_konteksti)
              tahot.LiitaTahoKiinteistolle(tahoId, id)
            End If
          End If
        End If

        Dim tietokanta = New appSopimusrekisteri.BLL.Kiinteisto(_konteksti)
        Dim kiinteisto = tietokanta.HaeKiinteisto(id)
        If Not kiinteisto Is Nothing Then
          TaytaPerustiedot(kiinteisto)
          TaytaLomake(kiinteisto)
          TaytaOmistaja(kiinteisto.KIIId)
          TaytaSopimukset(kiinteisto.KIIId)
          btnMuokkaa.PostBackUrl = String.Format("Muokkaa.aspx?id={0}", id)
          If IsNumeric(Request.Params("sopimusid")) Then
            btnMuokkaa.PostBackUrl += String.Format("&sopimusid={0}", Request.Params("sopimusid"))
          End If
        Else
          ' TODO: Virheilmoitus!
        End If
      Else
        ' TODO: Virheilmoitus!
      End If

      If (IsNumeric(Request.Params("sopimusid"))) Then
        btnTakaisin.PostBackUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Request.Params("sopimusid"))
        btnTakaisin.Visible = True
      End If

    End If

  End Sub

  Private Sub AsetaOikeudet()

    phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoLaaja)

    btLisaaOmistaja.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
    btPoistaOmistaja.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
    btnMuokkaa.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
    btLisaaSopimusKiinteistölle.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)

  End Sub

  Private Sub TaytaPerustiedot(kiinteisto As Entities.Kiinteisto)

    lblNimi.Text = kiinteisto.KIIKiinteisto
    lblPostiosoite.Text = kiinteisto.KIIKatuosoite + "<br/>" + kiinteisto.KIIPostinumero + " " + kiinteisto.KIIPostitoimipaikka

  End Sub

  Private Sub TaytaOmistaja(kiinteistoId As Integer)

    Dim tietokanta = New appSopimusrekisteri.BLL.Taho(_konteksti)
    Dim omistaja = tietokanta.HaeKiinteistonOmistaja(kiinteistoId)
    If Not omistaja Is Nothing Then

      lblOmistajanPostiosoite.Text = omistaja.Nimi + "<br/>" + (omistaja.Osoite + "<br/>" + omistaja.Postinumero + " " + omistaja.Postitoimipaikka).Trim()
      lblOmistajanPuhelin.Text = "Puhelin: " + omistaja.Puhelin
      lblOmistajanEmail.Text = "Sähköposti: " + omistaja.Email
      'btLisaaOmistaja.Visible = False
      'btPoistaOmistaja.Visible = True
      phOmistaja.Visible = True
    Else
      'btLisaaOmistaja.Visible = True
      'btPoistaOmistaja.Visible = False
      phOmistaja.Visible = False
    End If
  End Sub

  Private Sub TaytaSopimukset(kiinteistoId As Integer)


    Dim tietokanta = New appSopimusrekisteri.BLL.Sopimus(_konteksti)
    Dim sopimukset = tietokanta.HaeKiinteistonSopimukset(kiinteistoId)
    btLisaaSopimusKiinteistölle.PostBackUrl = String.Format("~/Sopimus/Valitse.aspx?kiinteistoid={0}", kiinteistoId)
    gwSopimukset.DataSource = sopimukset
    gwSopimukset.DataBind()

    phSopimukset.Visible = sopimukset.Count()

  End Sub

  Private Sub TaytaLomake(kiinteisto As Entities.Kiinteisto)

    lblKIIKiinteisto.Text = lblNimi.Text
    lblKIIPostitusosoite.Text = lblPostiosoite.Text
    lblKIIKortteli.Text = kiinteisto.KIIKortteli
    lblKIITontti.Text = kiinteisto.KIITontti
    lblKIIMaaraAla.Text = kiinteisto.KIIMaaraAla
    lblKIIMaapintaAla.Text = If(kiinteisto.KIIMaapintaAla.HasValue = True, kiinteisto.KIIMaapintaAla, String.Empty)
    lblKIIVesipintaAla.Text = If(kiinteisto.KIIVesipintaAla.HasValue = True, kiinteisto.KIIVesipintaAla, String.Empty)
    lblKIIPintaAla.Text = If(kiinteisto.KIIPintaAla.HasValue = True, kiinteisto.KIIPintaAla, String.Empty)
    lblKIIKiinteistoverotettuVuosi.Text = If(kiinteisto.KIIKiinteistoverotettuVuosi.HasValue = True, kiinteisto.KIIKiinteistoverotettuVuosi, String.Empty)
    lblKIIAssetTunniste.Text = If(kiinteisto.KIIAssetTunniste.HasValue = True, kiinteisto.KIIAssetTunniste, String.Empty)
    lblKIIOmistusosuus.Text = If(kiinteisto.KIIOmistusosuus.HasValue = True, kiinteisto.KIIOmistusosuus, String.Empty)
    lblKIIRasitteet.Text = kiinteisto.KIIRasitteet
    lblKIIKiinnitykset.Text = kiinteisto.KIIKiinnitykset
    lblKIIInfo.Text = kiinteisto.KIIInfo
    lblKIIKiinteisto.Text = kiinteisto.KIIKiinteisto
    lblKIIRekisterinumero.Text = kiinteisto.KIIRekisterinumero
    lblKIIKiinteistotunnus.Text = kiinteisto.KIIKiinteistotunnus
    lblKIIKiinteistotunnusLyhyt.Text = kiinteisto.KIIKiinteistotunnusLyhyt
    lblKIIKylanumero.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIKylanumero)
    lblKIIKyla.Text = kiinteisto.KIIKyla
    lblKIIKuntanumero.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIKuntanumero)
    lblKIIOmistusosuusTotal.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIOmistusosuusTotal)
    lblKIIAlueTarkenne.Text = kiinteisto.KIIAlueTarkenne

    ' TODO: Koska bisnesobjektit ovat vielä EF:n objekteja joudumme hakemaan nämä tiedot erikseen!
    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    lblKIIMaaId.Text = Lista.HaeListasta(kiinteisto.KIIMaaId, tietokanta.HaeMaat())
    lblKIIKuntaId.Text = Lista.HaeListasta(kiinteisto.KIIKuntaId, tietokanta.HaeKunnat())
    'lblKIIKylaId.Text = Lista.HaeListasta(kiinteisto.KIIKylaId, tietokanta.HaeKylat())
    lblKIISaantoId.Text = Lista.HaeListasta(kiinteisto.KIISaantoId, tietokanta.HaeSaannot())
    lblKIILiiketoiminnanTarveId.Text = Lista.HaeListasta(kiinteisto.KIILiiketoiminnanTarveId, tietokanta.HaeLiiketoiminnanTarpeet())

  End Sub

  Protected Sub btLisaaOmistaja_Click(sender As Object, e As EventArgs) Handles btLisaaOmistaja.Click

    Response.Redirect(String.Format("~/Taho/Haku.aspx?kiinteistoid={0}", Request.Params("id")), True)

  End Sub

  Protected Sub btPoistaOmistaja_Click(sender As Object, e As EventArgs) Handles btPoistaOmistaja.Click

    Dim tietokanta = New BLL.Kiinteisto(_konteksti)
    tietokanta.PoistaKiinteistonOmistaja(Request.Params("id"))
    TaytaOmistaja(Request.Params("id"))

  End Sub

  Private Sub gwSopimukset_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwSopimukset.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim rivi = DirectCast(e.Row.DataItem, DTO.Sopimus)
      CType(e.Row.FindControl("hlValitse"), LinkButton).PostBackUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", rivi.Id)

      CType(e.Row.FindControl("hlPoista"), LinkButton).CommandArgument = rivi.Id
      CType(e.Row.FindControl("hlPoista"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoMuokkaus)
    End If

  End Sub

  Private Sub gwSopimukset_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gwSopimukset.RowDeleting

    Dim poistettavaRivi = CType(gwSopimukset.Rows(e.RowIndex), GridViewRow)
    Dim poistettavanId = CType(poistettavaRivi.FindControl("hlPoista"), LinkButton).CommandArgument
    Dim tietokanta = New BLL.Sopimus(_konteksti)
    tietokanta.PoistaSopimusKiinteistolta(poistettavanId, Request.Params("id"))
    TaytaSopimukset((Request.Params("id")))

  End Sub

End Class