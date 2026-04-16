Imports appSopimusrekisteri.BLL
Imports appSopimusrekisteri.DTO

Public Class TunnisteyksikonTiedot

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()

      Dim id As String = Request.Params("id")

      If IsNumeric(id) Then

        Dim tietokanta = New appSopimusrekisteri.BLL.Tunnisteyksikko(_konteksti)
        Dim tunnisteyksikko = tietokanta.HaeTunnisteyksikko(id)
        If Not tunnisteyksikko Is Nothing Then
          TaytaPerustiedot(tunnisteyksikko)
          TaytaLomake(tunnisteyksikko)
          btnMuokkaa.PostBackUrl = String.Format("Muokkaa.aspx?id={0}&sopimusid={1}&tyyppi={2}", id, Request.Params("sopimusid"), Request.Params("tyyppi"))
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

    phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TunnisteYksikkoLaaja)

    btnMuokkaa.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TunnisteYksikkoMuokkaus)
    btnMuokkaa.Enabled = btnMuokkaa.Visible

  End Sub

  Private Sub TaytaPerustiedot(tunnisteyksikko As Entities.Tunnisteyksikko)

    lblNimi.Text = tunnisteyksikko.TUYNimi
    lblNimiOtsikko.Text = lblNimi.Text

    If Not tunnisteyksikko.TUYSopimusId Is Nothing Then

      Dim tietokanta = New BLL.Sopimus(_konteksti)
      Dim sopimus = tietokanta.HaeSopimus(tunnisteyksikko.TUYSopimusId)
      Dim tunniste = (sopimus.SOPMuuTunniste + " " + sopimus.SOPSopimusvuosi).Trim()
      lblSopimus.Text = sopimus.SOPId.ToString() + If(String.IsNullOrWhiteSpace(tunniste), String.Empty, String.Format(" ({0})", tunniste))

    End If

  End Sub

  Private Sub TaytaLomake(tunnisteyksikko As Entities.Tunnisteyksikko)

    lblTUYTunnus.Text = tunnisteyksikko.TUYTunnus
    lblTUYInfo.Text = tunnisteyksikko.TUYInfo
    lblTUYPGKoordinaatti1.Text = Luvut.EsitaNullableInteger(tunnisteyksikko.TUYPGKoordinaatti1)
    lblTUYPGKoordinaatti2.Text = Luvut.EsitaNullableInteger(tunnisteyksikko.TUYPGKoordinaatti2)
    lblTUYPGTunniste.Text = tunnisteyksikko.TUYPGTunniste
    lblTUYPGTunnus.Text = tunnisteyksikko.TUYPGTunnus

    ' TODO: Koska bisnesobjektit ovat vielä EF:n objekteja joudumme hakemaan nämä tiedot erikseen!
    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    lblTUYTunnisteyksikkoTyyppiId.Text = Lista.HaeListasta(tunnisteyksikko.TUYTunnisteyksikkoTyyppiId, tietokanta.HaeTunnisteyksikonTyypit())

  End Sub

End Class