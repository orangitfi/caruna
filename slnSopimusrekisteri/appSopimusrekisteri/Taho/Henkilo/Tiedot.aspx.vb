Imports appSopimusrekisteri.BLL
Imports appSopimusrekisteri.DTO

Public Class HenkilonTiedot

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()

      Dim id As String = Request.Params("id")

      If IsNumeric(id) Then

        Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo(_konteksti)
        Dim henkilo As Entities.Taho = tietokanta.HaeHenkilo(id)
        If Not henkilo Is Nothing Then
          If henkilo.TAHTyyppiId = Enumeraattorit.TahoTyyppi.Henkilo Then
            TaytaPerustiedot(henkilo)
            TaytaLomake(henkilo)
            TaytaKiinteistot(henkilo.TAHTahoId)
            TaytaSopimukset(henkilo.TAHTahoId)
            btnMuokkaa.PostBackUrl = String.Format("Muokkaa.aspx?id={0}", id)
            If IsNumeric(Request.Params("sopimusid")) Then
              btnMuokkaa.PostBackUrl += String.Format("&sopimusid={0}&tyyppi={1}", Request.Params("sopimusid"), Request.Params("tyyppi"))
            End If
          Else
            ' TODO: Virheilmoitus!
          End If
        Else
          ' TODO: Virheilmoitus!
        End If
      Else
        ' TODO: Virheilmoitus!
      End If

    End If

  End Sub

  Private Sub AsetaOikeudet()

    btnMuokkaa.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)

  End Sub

  Private Sub TaytaPerustiedot(henkilo As Entities.Taho)

    lblNimi.Text = henkilo.TAHEtunimi + " " + henkilo.TAHSukunimi
    lblPostiosoite.Text = lblNimi.Text + _
        If(String.IsNullOrWhiteSpace(henkilo.TAHPostitusosoite), String.Empty, "<br/>" + henkilo.TAHPostitusosoite) + _
        If(String.IsNullOrWhiteSpace(henkilo.TAHPostituspostinro), String.Empty, "<br/>" + henkilo.TAHPostituspostinro) + _
        If(String.IsNullOrWhiteSpace(henkilo.TAHPostituspostitmp), String.Empty, "<br/>" + henkilo.TAHPostituspostitmp)
    lblPuhelin.Text = henkilo.TAHPuhelin
    lblEmail.Text = henkilo.TAHEmail

  End Sub

  Private Sub TaytaKiinteistot(henkiloId As Integer)

    Dim tietokanta = New appSopimusrekisteri.BLL.Kiinteisto(_konteksti)
    Dim kiinteistot = tietokanta.HaeTahonKiinteistot(henkiloId)
    btLisaaKiinteisto.PostBackUrl = String.Format("~/Kiinteisto/Muokkaa.aspx?henkiloid={0}", henkiloId)
    gwKiinteistot.DataSource = kiinteistot
    gwKiinteistot.DataBind()

    phKiinteistot.Visible = kiinteistot.Count()

  End Sub

  Private Sub TaytaSopimukset(henkiloId As Integer)

    Sopimukset1.TahoId = henkiloId

  End Sub

  Private Sub TaytaLomake(henkilo As Entities.Taho)

    lblNimiOtsikko.Text = lblNimi.Text
    lblTAHPostitusosoite.Text = lblPostiosoite.Text
    'lblTAHEtunimi.Text = henkilo.TAHEtunimi
    'lblTAHSukunimi.Text = henkilo.TAHSukunimi
    lblTAHEmail.Text = henkilo.TAHEmail
    lblTAHPuhelin.Text = henkilo.TAHPuhelin
    'lblTAHPostituspostinro.Text = henkilo.TAHPostituspostinro
    'lblTAHPostituspostitmp.Text = henkilo.TAHPostituspostitmp
    lblTAHPuhelin.Text = henkilo.TAHPuhelin
    lblTAHTilinumero.Text = henkilo.TAHTilinumero
    lblTAHinfo.Text = henkilo.TAHInfo
    lblTAHNimitarkenne.Text = henkilo.TAHNimitarkenne

    ' TODO: Koska bisnesobjektit ovat vielä EF:n objekteja joudumme hakemaan nämä tiedot erikseen!
    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    lblTAHMaaId.Text = Lista.HaeListasta(henkilo.TAHMaaId, tietokanta.HaeMaat())
    lblTAHKuntaId.Text = Lista.HaeListasta(henkilo.TAHKuntaId, tietokanta.HaeKunnat())

    If henkilo.TAHBicKoodiId.HasValue Then
      lblTAHBic.Text = Lista.HaeListasta(henkilo.TAHBicKoodiId, tietokanta.HaeBicKoodit())
    Else
      lblTAHBic.Text = henkilo.TAHBic
    End If

  End Sub

End Class