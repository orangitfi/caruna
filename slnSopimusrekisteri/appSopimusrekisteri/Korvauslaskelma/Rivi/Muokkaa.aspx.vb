Imports System.IO

Public Class KorvauslaskelmarivinMuokkaus
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      AsetaOikeudet()
      Infopallurat.AsetaInfopallurat(Me)

      Dim id As String = Request.Params("id")

      If IsNumeric(id) Then

        Dim tietokanta = New appSopimusrekisteri.BLL.Korvauslaskelma(_konteksti)
        Dim korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi = tietokanta.HaeKorvauslaskelmanRivi(id)

        If Not korvauslaskelmanRivi Is Nothing Then

          TaytaPudotusvalikot(Nothing, korvauslaskelmanRivi)
          TaytaKorvaushinnastonTiedot()
          TaytaLomake(korvauslaskelmanRivi)
          TaytaMuokkaustiedot(korvauslaskelmanRivi)

        End If

      Else

        ' Peritään kirjanpidon tilin ja kustannuspaikan arvot korvauslaskelmalta.
        Dim tietokanta As New appSopimusrekisteri.BLL.Korvauslaskelma(_konteksti)
        Dim korvauslaskelma As DTO.Korvauslaskelma = tietokanta.HaeKorvauslaskelmaDTO(Request.Params("korvauslaskelmaid"))
        TaytaPudotusvalikot(korvauslaskelma)

      End If

    End If

  End Sub

  Private Sub AsetaOikeudet()

    phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaLaaja)

  End Sub

  Protected Overrides Sub OnPreRender(e As EventArgs)

    btTallenna.Visible = pnlHinnastoValittu.Visible
    MyBase.OnPreRender(e)

  End Sub

  Private Sub TaytaKorvaushinnastonTiedot()

    Dim tietokanta = New BLL.Korvaushinnasto()

    Dim korvaushinnasto As Entities.KorvausHinnasto = tietokanta.HaeKorvaushinnasto(gvHinnastot.SelectedDataKey.Value)

    If korvaushinnasto Is Nothing Then
      Return
    End If

    Dim korvausyksikonTyyppi As Integer

    If Not korvaushinnasto.hlp_Yksikko Is Nothing Then
      korvausyksikonTyyppi = korvaushinnasto.hlp_Yksikko.YKSKorvausyksikonTyyppiId
    End If

    If korvausyksikonTyyppi = DTO.Enumeraattorit.KorvausyksikonTyyppi.PintaAla Then
      phPintaAla.Visible = True
      btLaskeMaaraPintaalasta.Visible = True
      lblPintaAlaYksikko.Text = korvaushinnasto.hlp_Yksikko.YKSKorvausyksikko
    Else
      phPintaAla.Visible = False
      btLaskeMaaraPintaalasta.Visible = False
    End If

    If korvausyksikonTyyppi = DTO.Enumeraattorit.KorvausyksikonTyyppi.Prosentti Then
      txtKLRKorvaus.Visible = False
      btnLaskeKorvaus.Visible = False
      lblProsenttiKorvaus.Visible = True

      txtKLRMaara.Text = 1
      txtKLRMaara.Enabled = False

    Else
      txtKLRKorvaus.Visible = True
      btnLaskeKorvaus.Visible = True
      lblProsenttiKorvaus.Visible = False

      txtKLRMaara.Text = String.Empty
      txtKLRMaara.Enabled = True

    End If

    hfYKSKerroin.Value = korvaushinnasto.hlp_Yksikko.YKSKerroin

    If korvaushinnasto.KHIYksikkkohinta Is Nothing Or korvaushinnasto.KHIYksikkkohinta = 0 Then
      txtKLRYksikkohinta.Text = Luvut.EsitaNullableDecimal(korvaushinnasto.KHIYksikkkohinta)
      txtKLRYksikkohinta.Enabled = True
    Else
      txtKLRYksikkohinta.Text = Luvut.EsitaNullableDecimal(korvaushinnasto.KHIYksikkkohinta)
      txtKLRYksikkohinta.Enabled = False
    End If

  End Sub

  Private Sub TaytaMuokkaustiedot(korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi)

    lblKLRPaivitetty.Text = Paivaykset.PalautaPaivays(korvauslaskelmanRivi.Paivitetty)
    lblKLRPaivittaja.Text = korvauslaskelmanRivi.Paivittaja
    lblKLRLuotu.Text = Paivaykset.PalautaPaivays(korvauslaskelmanRivi.Luotu)
    lblKLRLuoja.Text = korvauslaskelmanRivi.Luoja
    phPaivitystiedot.Visible = True

  End Sub

  Private Sub TaytaPudotusvalikot(Optional korvauslaskelma As DTO.Korvauslaskelma = Nothing, Optional korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi = Nothing)

    Dim tietokanta As New appSopimusrekisteri.BLL.Haku()

    ddKLRKirjanpidonTiliId.DataSource = tietokanta.HaeKirjanpidonTilit()
    ddKLRKirjanpidonTiliId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKLRKirjanpidonTiliId.DataBind()

    ddKLRKirjanpidonKustannuspaikkaId.DataSource = tietokanta.HaeKirjanpidonKustannuspaikat()
    ddKLRKirjanpidonKustannuspaikkaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKLRKirjanpidonKustannuspaikkaId.DataBind()

    ddKLRInvCostId.DataSource = tietokanta.HaeInvcostit()
    ddKLRInvCostId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKLRInvCostId.DataBind()

    ' Peritään kirjanpidon tilin ja kustannuspaikan arvot korvauslaskelmalta.
    If Not korvauslaskelma Is Nothing Then
      Pudotusvalikko.Valitse(ddKLRKirjanpidonTiliId, korvauslaskelma.KirjanpidonTiliId)
      Pudotusvalikko.Valitse(ddKLRKirjanpidonKustannuspaikkaId, korvauslaskelma.KustannuspaikkaId)
      Pudotusvalikko.Valitse(ddKLRInvCostId, korvauslaskelma.InvCostId)
    End If

    ddKHIHinnastoKategoriaId.DataSource = tietokanta.HaeHinnastonKategoriat()
    ddKHIHinnastoKategoriaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIHinnastoKategoriaId.DataBind()

    ' Katsotaan mikä korvausrivin korvaushinnaston tiedot ovat...
    Dim korvaushinnasto As Entities.KorvausHinnasto = New Entities.KorvausHinnasto()
    If Not korvauslaskelmanRivi Is Nothing Then
      Dim korvaushinnastot = New BLL.Korvaushinnasto()
      korvaushinnasto = korvaushinnastot.HaeKorvaushinnasto(korvauslaskelmanRivi.KorvaushinnastoId)
    End If

    Pudotusvalikko.Valitse(ddKHIHinnastoKategoriaId, korvaushinnasto.KHIHinnastoKategoriaId)

    If ddKHIHinnastoKategoriaId.SelectedIndex > 0 Then

      phKategoriaValittu.Visible = True
      ddKHIHinnastoAlakategoriaId.DataSource = tietokanta.HaeHinnastonAlakategoriat()
      ddKHIHinnastoAlakategoriaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
      ddKHIHinnastoAlakategoriaId.DataBind()

      Pudotusvalikko.Valitse(ddKHIHinnastoAlakategoriaId, korvaushinnasto.KHIHinnastoAlakategoriaId)

      If ddKHIHinnastoAlakategoriaId.SelectedIndex > 0 Then

        phAlakategoriaValittu.Visible = True
        ddKHIMaksualueId.DataSource = tietokanta.HaeAlakategorianMaksualueet(Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoAlakategoriaId))
        ddKHIMaksualueId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddKHIMaksualueId.DataBind()

        Pudotusvalikko.Valitse(ddKHIMaksualueId, korvaushinnasto.KHIMaksuAlueId)

        If ddKHIMaksualueId.SelectedIndex > 0 Then

          phMaksualueValittu.Visible = True
          Dim korvaushinnastot = New BLL.Korvaushinnasto()
          gvHinnastot.DataSource = korvaushinnastot.HaeKorvaushinnastot(Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoAlakategoriaId), Pudotusvalikko.HaeValittuArvo(ddKHIMaksualueId), korvaushinnasto.KHIId)
          gvHinnastot.DataBind()

          If korvaushinnasto.KHIId <> 0 Then

            For Each rivi As GridViewRow In gvHinnastot.Rows

              If gvHinnastot.DataKeys(rivi.RowIndex)("KHIId") = korvaushinnasto.KHIId Then

                gvHinnastot.SelectedIndex = rivi.RowIndex
                pnlHinnastoValittu.Visible = True
                btTallenna.Visible = True
                btTallennaJaLisaaUusi.Visible = True
                AsetaValitunRivinTyyli()
                NaytaValitunRivinTiedot()

              End If
            Next

            If gvHinnastot.SelectedRow Is Nothing Then
              pnlHinnastoValittu.Visible = False
            End If

          Else

            pnlHinnastoValittu.Visible = False

          End If

        End If

      Else

        pnlHinnastoValittu.Visible = False
        phMaksualueValittu.Visible = False
        phAlakategoriaValittu.Visible = False

      End If

    Else

      phKategoriaValittu.Visible = False
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = False
      phAlakategoriaValittu.Visible = False

    End If

  End Sub

  Private Sub TaytaLomake(korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi)

    txtKLRInfo.Text = korvauslaskelmanRivi.Lisatieto
    txtKLRKokonaispintaAla.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.KokonaisPintaAla, 3)
    txtKLRKorvaus.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.Korvaus)
    txtKLRKuvionKorvattavaLeveys.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.KuvionKorvattavaLeveys, 3)
    txtKLRKuvionLeveys.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.KuvionLeveys, 3)
    txtKLRKuvionPituus.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.KuvionPituus, 3)
    txtKLRKuvionTunnus.Text = korvauslaskelmanRivi.KuvionTunnus
    txtKLRYksikkohinta.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.Yksikkohinta)
    txtKLRMaara.Text = Luvut.EsitaNullableDecimal(korvauslaskelmanRivi.Maara, 3)

    Pudotusvalikko.Valitse(ddKLRInvCostId, korvauslaskelmanRivi.InvCostId)

    Pudotusvalikko.Valitse(ddKLRKirjanpidonKustannuspaikkaId, korvauslaskelmanRivi.KustannuspaikkaId)
    Pudotusvalikko.Valitse(ddKLRKirjanpidonTiliId, korvauslaskelmanRivi.KirjanpidonTiliId)

  End Sub

  Private Sub NaytaValitunRivinTiedot()

    If Not gvHinnastot.SelectedRow Is Nothing Then

      ' Näytetään valitun rivin tiedot.
      lblKHIKorvauslaji.Text = gvHinnastot.SelectedRow.Cells(1).Text
      lblKHIPuustonIka.Text = gvHinnastot.SelectedRow.Cells(4).Text
      lblKHITaimistonValtapituus.Text = gvHinnastot.SelectedRow.Cells(5).Text
      lblKHITiheyskerroin.Text = gvHinnastot.SelectedRow.Cells(6).Text
      lblKHIYksikkkohinta.Text = gvHinnastot.SelectedRow.Cells(7).Text
      lblMTYMetsatyyppi.Text = gvHinnastot.SelectedRow.Cells(2).Text
      lblPLAPuustolaji.Text = gvHinnastot.SelectedRow.Cells(3).Text
      lblYKSKorvausyksikko.Text = gvHinnastot.SelectedRow.Cells(8).Text

      If gvHinnastot.SelectedRow.Cells(7).Text <> "&nbsp;" Then
        txtKLRYksikkohinta.Text = gvHinnastot.SelectedRow.Cells(7).Text
      End If

      hfYKSKerroin.Value = CType(gvHinnastot.SelectedRow.Cells(9).FindControl("hfKerroin"), HiddenField).Value
      imgInfo.ToolTip = CType(gvHinnastot.SelectedRow.Cells(8).FindControl("imgInfo"), Image).ToolTip

    End If

  End Sub


  Private Function LuoKorvauslaskelmaRivi() As DTO.KorvauslaskelmanRivi

    Dim korvauslaskelmanRivi = New DTO.KorvauslaskelmanRivi()

    korvauslaskelmanRivi.Lisatieto = txtKLRInfo.Text
    korvauslaskelmanRivi.KokonaisPintaAla = Luvut.HaeNullableDecimal(txtKLRKokonaispintaAla.Text)
    korvauslaskelmanRivi.Korvaus = Luvut.HaeNullableDecimal(txtKLRKorvaus.Text)
    korvauslaskelmanRivi.KuvionKorvattavaLeveys = Luvut.HaeNullableDecimal(txtKLRKuvionKorvattavaLeveys.Text)
    korvauslaskelmanRivi.KuvionLeveys = Luvut.HaeNullableDecimal(txtKLRKuvionLeveys.Text)
    korvauslaskelmanRivi.KuvionPituus = Luvut.HaeNullableDecimal(txtKLRKuvionPituus.Text)
    korvauslaskelmanRivi.KuvionTunnus = txtKLRKuvionTunnus.Text
    korvauslaskelmanRivi.Maara = Luvut.HaeNullableDecimal(txtKLRMaara.Text)
    korvauslaskelmanRivi.Yksikkohinta = Luvut.HaeNullableInteger(txtKLRYksikkohinta.Text)
    korvauslaskelmanRivi.KorvaushinnastoId = gvHinnastot.SelectedValue
    korvauslaskelmanRivi.KustannuspaikkaId = Pudotusvalikko.HaeValittuArvo(ddKLRKirjanpidonKustannuspaikkaId)
    korvauslaskelmanRivi.KirjanpidonTiliId = Pudotusvalikko.HaeValittuArvo(ddKLRKirjanpidonTiliId)
    korvauslaskelmanRivi.Yksikkohinta = Luvut.HaeNullableDecimal(txtKLRYksikkohinta.Text)

    korvauslaskelmanRivi.InvCostId = Pudotusvalikko.HaeValittuArvo(ddKLRInvCostId)

    Return korvauslaskelmanRivi

  End Function

  Protected Sub btLaskeMaaraPintaalasta_Click(sender As Object, e As EventArgs) Handles btLaskeMaaraPintaalasta.Click

    Dim korvattavaLeveys As Decimal
    Dim korvattavaPituus As Decimal

    If IsNumeric(txtKLRKuvionKorvattavaLeveys.Text) And IsNumeric(txtKLRKuvionPituus.Text) Then

      korvattavaLeveys = txtKLRKuvionKorvattavaLeveys.Text
      korvattavaPituus = txtKLRKuvionPituus.Text
      txtKLRMaara.Text = Luvut.EsitaNullableDecimal((korvattavaLeveys * korvattavaPituus), 3)

    End If

  End Sub

  Protected Sub btnLaskeKorvaus_Click(sender As Object, e As EventArgs) Handles btnLaskeKorvaus.Click

    Dim hinta As Decimal
    Dim maara As Decimal

    If IsNumeric(txtKLRMaara.Text) Then

      If IsNumeric(txtKLRYksikkohinta.Text) Then

        hinta = txtKLRYksikkohinta.Text
        maara = txtKLRMaara.Text
        txtKLRKorvaus.Text = Luvut.EsitaNullableDecimal((hinta * maara))

        'Dim tietokanta = New BLL.Korvauslaskelma()
        'hinta = Math.Round(tietokanta.HaeHinta(gwHinnastot.SelectedValue), 2)
        'maara = Math.Round(CType(txtKLRMaara.Text, Decimal), 2)
        'txtKLRKorvaus.Text = (hinta * maara).ToString("f2")

      End If

    End If

  End Sub

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    If Page.IsValid() Then

      Tallenna()

      If IsNumeric(Request.Params("korvauslaskelmaid")) Then
        Response.Redirect(String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", Request.Params("korvauslaskelmaid"), Request.Params("sopimusid")))
      Else
        ' TODO: Error.
      End If

    Else
      'TODO: Error message.
    End If

  End Sub

  Private Sub Tallenna()

    Dim tietokanta = New appSopimusrekisteri.BLL.Korvauslaskelma(_konteksti)
    Dim korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi = LuoKorvauslaskelmaRivi()

    ' Hae URL:ista korvauslaskelman rivin tunnisteen, jonka pohjalta päätämme 
    ' lisäämmekö sen tietokantaan vai muokkaammeko sitä.
    If IsNumeric(Request.Params("id")) Then
      korvauslaskelmanRivi.Id = Request.Params("id")
      korvauslaskelmanRivi.KorvauslaskelmaId = Request.Params("korvauslaskelmaid")
      korvauslaskelmanRivi = tietokanta.MuokkaaKorvauslaskelmanRivia(korvauslaskelmanRivi)
    Else
      korvauslaskelmanRivi.KorvauslaskelmaId = Request.Params("korvauslaskelmaid")
      korvauslaskelmanRivi = tietokanta.LisaaKorvauslaskelmanRivi(korvauslaskelmanRivi)
    End If

  End Sub

  Protected Sub ddKHIHinnastoKategoriaId_Selected(sender As Object, e As EventArgs) Handles ddKHIHinnastoKategoriaId.SelectedIndexChanged

    If ddKHIHinnastoKategoriaId.SelectedIndex > 0 Then

      'Session("korvauslaskelmanrivi-hinnastokategoriaid") = Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoKategoriaId)
      Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
      phKategoriaValittu.Visible = True
      phAlakategoriaValittu.Visible = False
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = False
      ddKHIHinnastoAlakategoriaId.DataSource = tietokanta.HaeHinnastonAlakategoriat()
      ddKHIHinnastoAlakategoriaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
      ddKHIHinnastoAlakategoriaId.DataBind()

    Else

      'Session.Remove("korvauslaskelmanrivi-hinnastokategoriaid")
      phKategoriaValittu.Visible = False
      phAlakategoriaValittu.Visible = False
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = False
      ddKHIHinnastoAlakategoriaId.DataSource = Nothing
      ddKHIHinnastoAlakategoriaId.DataBind()
      ddKHIMaksualueId.DataSource = Nothing
      ddKHIMaksualueId.DataBind()
      gvHinnastot.DataSource = Nothing
      gvHinnastot.DataBind()

    End If

  End Sub

  Protected Sub ddKHIHinnastoAlakategoriaId_Selected(sender As Object, e As EventArgs) Handles ddKHIHinnastoAlakategoriaId.SelectedIndexChanged

    If ddKHIHinnastoAlakategoriaId.SelectedIndex > 0 Then

      'Session("korvauslaskelmanrivi-hinnastoalakategoriaid") = Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoAlakategoriaId)
      Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
      phKategoriaValittu.Visible = True
      phAlakategoriaValittu.Visible = True
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = False
      ddKHIMaksualueId.DataSource = tietokanta.HaeAlakategorianMaksualueet(Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoAlakategoriaId))
      ddKHIMaksualueId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
      ddKHIMaksualueId.DataBind()

    Else

      'Session.Remove("korvauslaskelmanrivi-hinnastoalakategoriaid")
      phKategoriaValittu.Visible = True
      phAlakategoriaValittu.Visible = False
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = False
      ddKHIMaksualueId.DataSource = Nothing
      ddKHIMaksualueId.DataBind()
      gvHinnastot.DataSource = Nothing
      gvHinnastot.DataBind()

    End If

  End Sub

  Protected Sub ddKHIMaksualueId_Selected(sender As Object, e As EventArgs) Handles ddKHIMaksualueId.SelectedIndexChanged

    If ddKHIMaksualueId.SelectedIndex > 0 Then
      'Session("korvauslaskelmanrivi-maksualueid") = Pudotusvalikko.HaeValittuArvo(ddKHIMaksualueId)
      phKategoriaValittu.Visible = True
      phAlakategoriaValittu.Visible = True
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = True
      Dim korvaushinnastot = New BLL.Korvaushinnasto()
      gvHinnastot.DataSource = korvaushinnastot.HaeKorvaushinnastot(Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoAlakategoriaId), Pudotusvalikko.HaeValittuArvo(ddKHIMaksualueId))
      gvHinnastot.DataBind()

    Else
      'Session.Remove("korvauslaskelmanrivi-maksualueid")
      phKategoriaValittu.Visible = True
      phAlakategoriaValittu.Visible = True
      pnlHinnastoValittu.Visible = False
      phMaksualueValittu.Visible = True
      gvHinnastot.DataSource = Nothing
      gvHinnastot.DataBind()

    End If

  End Sub

  Private Sub gvHinnastot_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHinnastot.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim rivi = DirectCast(e.Row.DataItem, Entities.KorvausHinnasto)
      Dim tooltip = String.Empty
      If rivi.KHIYksikkohinnanTarkenne <> String.Empty Then
        tooltip = rivi.KHIYksikkohinnanTarkenne
      End If
      If rivi.KHIArvonPeruste <> String.Empty Then
        If rivi.KHIYksikkohinnanTarkenne <> String.Empty Then
          tooltip = tooltip + vbCrLf
        End If
        tooltip += rivi.KHIArvonPeruste
      End If
      If rivi.KHIKuvaus <> String.Empty Then
        If rivi.KHIArvonPeruste <> String.Empty Then
          tooltip = tooltip + vbCrLf
        End If
        tooltip += rivi.KHIKuvaus
      End If
      If tooltip <> String.Empty Then
        CType(e.Row.FindControl("imgInfo"), Image).Visible = True
        CType(e.Row.FindControl("imgInfo"), Image).ToolTip = tooltip

      End If

    End If

  End Sub

  Protected Sub gvHinnastot_Selected(sender As Object, e As EventArgs) Handles gvHinnastot.SelectedIndexChanged

    AsetaValitunRivinTyyli()
    txtKLRKorvaus.Text = String.Empty
    NaytaValitunRivinTiedot()
    TaytaKorvaushinnastonTiedot()

  End Sub

  Protected Sub gvHinnastot_Selecting(sender As Object, e As GridViewSelectEventArgs) Handles gvHinnastot.SelectedIndexChanging

    'Session("korvauslaskelmanrivi-korvaushinnastoid") = gwHinnastot.DataKeys(e.NewSelectedIndex)("KHIId")
    pnlHinnastoValittu.Visible = True
    btTallenna.Visible = True
    btTallennaJaLisaaUusi.Visible = True
    PoistaValitunRivinTyyli()

  End Sub

  Protected Sub PoistaValitunRivinTyyli()
    If Not gvHinnastot.SelectedIndex <> -1 Then
      If Not gvHinnastot.SelectedRow Is Nothing Then
        gvHinnastot.SelectedRow.Font.Underline = False
      End If
    End If
  End Sub

  Protected Sub AsetaValitunRivinTyyli()

    gvHinnastot.SelectedRow.Font.Underline = True

  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    If IsNumeric(Request.Params("korvauslaskelmaid")) Then
      Response.Redirect(String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", Request.Params("korvauslaskelmaid"), Request.Params("sopimusid")), True)
    End If

    Response.Redirect("~/Etusivu.aspx", True)

  End Sub

  Protected Sub btTallennaJaLisaaUusi_Click(sender As Object, e As EventArgs) Handles btTallennaJaLisaaUusi.Click

    If Page.IsValid() Then

      Tallenna()

      If IsNumeric(Request.Params("korvauslaskelmaid")) Then
        Response.Redirect(String.Format("~/Korvauslaskelma/Rivi/Muokkaa.aspx?korvauslaskelmaid={0}&sopimusid={1}&tyyppi={2}", Request.Params("korvauslaskelmaid"), Request.Params("sopimusid"), Request.Params("tyyppi")))
      Else
        ' TODO: Error.
      End If

    Else
      'TODO: Error message.
    End If

  End Sub

End Class