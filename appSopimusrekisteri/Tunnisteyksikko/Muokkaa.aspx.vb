Imports System.Data.SqlTypes
Imports System.Diagnostics.Eventing.Reader
Imports System.Runtime.InteropServices
Imports appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class TunnisteyksikonMuokkaus
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()
      Infopallurat.AsetaInfopallurat(Me)

      Dim id As String = Request.Params("id")
      Dim sopimusId As String = Request.Params("sopimusid")

      TaytaPudotusvalikot()
      TaytaSopimuksenTiedot()

      If IsNumeric(id) Then
        Dim tietokanta = New appSopimusrekisteri.BLL.Tunnisteyksikko(_konteksti)
        Dim tunnisteyksikko = tietokanta.HaeTunnisteyksikko(id)
        If Not tunnisteyksikko Is Nothing Then
          TaytaLomake(tunnisteyksikko)
          TaytaMuokkaustiedot(tunnisteyksikko)
          lblTUYSopimusId.Visible = True
          'lblTUYSopimusId.Visible = False
          'ddTUYSopimusId.Visible = True
        Else
          'TODO: Virheilmoitus!
        End If
      Else
        If IsNumeric(sopimusId) Then
          lblTUYSopimusId.Visible = True
        Else
          'TODO: Virheilmoitus!
        End If
      End If

    End If

  End Sub

  Private Sub AsetaOikeudet()

    phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TunnisteYksikkoLaaja)

  End Sub

  Private Sub TaytaMuokkaustiedot(tunnisteyksikko As Entities.Tunnisteyksikko)

    lblTUYPaivitetty.Text = Paivaykset.PalautaPaivays(tunnisteyksikko.TUYPaivitetty)
    lblTUYPaivittaja.Text = tunnisteyksikko.TUYPaivittaja
    lblTUYLuotu.Text = Paivaykset.PalautaPaivays(tunnisteyksikko.TUYLuotu)
    lblTUYLuoja.Text = tunnisteyksikko.TUYLuoja
    phPaivitystiedot.Visible = True

  End Sub

  Private Sub TaytaPudotusvalikot()

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    ddTUYTunnisteyksikkoTyyppiId.DataSource = tietokanta.HaeTunnisteyksikonTyypit()
    ddTUYTunnisteyksikkoTyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddTUYTunnisteyksikkoTyyppiId.DataBind()
    'TODO: Sopimuksia tulisi liikaa, jos niitä lähtee vain hakemaan.
    'ddTUYSopimusId.DataSource = tietokanta.HaeSopimukset()
    'ddTUYSopimusId.DataBind()

  End Sub

  Private Sub TaytaSopimuksenTiedot()

    If IsNumeric(Request.Params("sopimusid")) Then

      Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
      Dim sopimus As iHakutulos = tietokanta.HaeSopimus(Request.Params("sopimusid"))
      If Not sopimus Is Nothing Then
        lblTUYSopimusId.Text = sopimus.Nimi
      End If

    End If

  End Sub

  Private Sub TaytaLomake(tunnisteyksikko As Entities.Tunnisteyksikko)

    txtTUYNimi.Text = tunnisteyksikko.TUYNimi
    txtTUYPGKoordinaatti1.Text = Luvut.EsitaNullableInteger(tunnisteyksikko.TUYPGKoordinaatti1)
    txtTUYPGKoordinaatti2.Text = Luvut.EsitaNullableInteger(tunnisteyksikko.TUYPGKoordinaatti2)
    txtTUYPGTunniste.Text = tunnisteyksikko.TUYPGTunniste
    txtTUYPGTunnus.Text = tunnisteyksikko.TUYPGTunnus
    txtTUYTunnus.Text = tunnisteyksikko.TUYTunnus
    txtTUYInfo.Text = tunnisteyksikko.TUYInfo

    Pudotusvalikko.Valitse(ddTUYTunnisteyksikkoTyyppiId, tunnisteyksikko.TUYTunnisteyksikkoTyyppiId)

    Dim tietokanta = New BLL.Sopimus(_konteksti)
    Dim sopimus = tietokanta.HaeSopimus(tunnisteyksikko.TUYSopimusId)
    If Not sopimus Is Nothing Then
      Dim tunniste = (sopimus.SOPMuuTunniste + " " + sopimus.SOPSopimusvuosi).Trim()
      lblTUYSopimusId.Text = sopimus.SOPId.ToString() + If(String.IsNullOrWhiteSpace(tunniste), String.Empty, String.Format(" ({0})", tunniste))
    End If

  End Sub

  Private Function LuoTunnisteyksikko() As Entities.Tunnisteyksikko

    Dim tunnisteyksikko = New Entities.Tunnisteyksikko()
    'tunnisteyksikko.TUYAktiivinen = txtTUYAktiivinen.Text
    'tunnisteyksikko.TUYId = txtKIITontti.Text
    tunnisteyksikko.TUYInfo = txtTUYInfo.Text
    'tunnisteyksikko.TUYKohdetieto = txtTUYKohdetieto.Text
    'tunnisteyksikko.TUYKoordinaatit = txtTUYKoordinaatit.Text
    'tunnisteyksikko.TUYLinjaOsa = txtTUYLinjaOsa.Text
    'tunnisteyksikko.TUYLuoja = 
    tunnisteyksikko.TUYLuotu = SqlDateTime.MinValue
    tunnisteyksikko.TUYNimi = txtTUYNimi.Text
    tunnisteyksikko.TUYPGKoordinaatti1 = Luvut.HaeNullableInteger(txtTUYPGKoordinaatti1.Text)
    tunnisteyksikko.TUYPGKoordinaatti2 = Luvut.HaeNullableInteger(txtTUYPGKoordinaatti2.Text)
    tunnisteyksikko.TUYPGTunniste = txtTUYPGTunniste.Text
    tunnisteyksikko.TUYPGTunnus = txtTUYPGTunnus.Text
    tunnisteyksikko.TUYPaivitetty = SqlDateTime.MinValue
    'tunnisteyksikko.TUYPaivittaja = 
    'tunnisteyksikko.TUYSopimusId = 
    tunnisteyksikko.TUYTunnisteyksikkoTyyppiId = Pudotusvalikko.HaeValittuArvo(ddTUYTunnisteyksikkoTyyppiId)
    tunnisteyksikko.TUYTunnus = txtTUYTunnus.Text
    Return tunnisteyksikko

  End Function

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    Dim tietokanta = New appSopimusrekisteri.BLL.Tunnisteyksikko(_konteksti)
    Dim tunnisteyksikko = LuoTunnisteyksikko()

    ' Hae URL:ista kiinteistön tunniste, jonka pohjalta päätämme 
    ' lisäämmekö sen tietokantaan vai muokkaammeko sitä.
    If IsNumeric(Request.Params("id")) Then
      tunnisteyksikko.TUYId = Request.Params("id")
      tunnisteyksikko.TUYSopimusId = Request.Params("sopimusid")
      tunnisteyksikko = tietokanta.MuokkaaTunnisteyksikkoa(tunnisteyksikko)
      If Not tunnisteyksikko Is Nothing Then
        Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}&tunnisteyksikkoid={1}", Request.Params("sopimusid"), tunnisteyksikko.TUYId))
      End If
    Else
      If IsNumeric(Request.Params("sopimusid")) Then

        ' Tunnisteyksikön lisäys olemassaolevaan sopimukseen!
        tunnisteyksikko.TUYSopimusId = Request.Params("sopimusid")
        tunnisteyksikko = tietokanta.LisaaTunnisteyksikko(tunnisteyksikko)

        If Not tunnisteyksikko Is Nothing Then
          Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}&tunnisteyksikkoid={1}", Request.Params("sopimusid"), tunnisteyksikko.TUYId))
        End If

      Else

        ' Tunnisteyksikön lisäys ja sen mahdollinen valinta sopimukselle!
        Return ' TODO: Tässä vaiheessa emme halua muokata tunnisteyksikköjä.
      End If
    End If


  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    If IsNumeric(Request.Params("sopimusid")) Then
      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Request.Params("sopimusid")))
    End If

    If IsNumeric(Request.Params("id")) Then
      Response.Redirect(String.Format("~/Tunnisteyksikko/Tiedot.aspx?id={0}", Request.Params("id")), True)
    End If

    Response.Redirect("~/Etusivu.aspx", True)

  End Sub

End Class