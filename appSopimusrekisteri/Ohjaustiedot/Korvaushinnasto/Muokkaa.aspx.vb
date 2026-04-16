Imports appSopimusrekisteri.DTO

Public Class KorvaushinnastonMuokkaus
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      TaytaPudotusvalikot()
      Dim id As String = Request.Params("id")

      If IsNumeric(id) Then

        Dim tietokanta = New appSopimusrekisteri.BLL.Korvaushinnasto()
        Dim korvaushinnasto = tietokanta.HaeKorvaushinnasto(id)
        If Not korvaushinnasto Is Nothing Then
          TaytaLomake(korvaushinnasto)
          TaytaMuokkaustiedot(korvaushinnasto)
        Else
          ' TODO: Virheilmoitus!
        End If
      Else
        ' TODO: Virheilmoitus!
      End If
    Else
      ' TODO: Virheilmoitus!
    End If


  End Sub

  Private Sub TaytaMuokkaustiedot(korvaushinnasto As Entities.KorvausHinnasto)

    lblKHIPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(korvaushinnasto.KHIPaivitetty)
    lblKHIPaivittaja.Text = korvaushinnasto.KHIPaivittaja
    lblKHILuotu.Text = Paivaykset.PalautaTasmallinenPaivays(korvaushinnasto.KHILuotu)
    lblKHILuoja.Text = korvaushinnasto.KHILuoja
    phPaivitystiedot.Visible = True

  End Sub

  Private Sub TaytaPudotusvalikot()

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    ddKHIHinnastoKategoriaId.DataSource = tietokanta.HaeHinnastonKategoriat()
    ddKHIHinnastoKategoriaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIHinnastoKategoriaId.DataBind()
    ddKHIHinnastoAlakategoriaId.DataSource = tietokanta.HaeHinnastonAlakategoriat()
    ddKHIHinnastoAlakategoriaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIHinnastoAlakategoriaId.DataBind()
    ddKHIMaksuAlueId.DataSource = tietokanta.HaeMaksualueet()
    ddKHIMaksuAlueId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIMaksuAlueId.DataBind()
    ddKHIMetsatyyppiId.DataSource = tietokanta.HaeMetsatyypit()
    ddKHIMetsatyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIMetsatyyppiId.DataBind()
    ddKHIPuustolajiId.DataSource = tietokanta.HaePuustolajit()
    ddKHIPuustolajiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIPuustolajiId.DataBind()
    ddKHISopimustyyppiId.DataSource = tietokanta.HaeSopimusTyypit()
    ddKHISopimustyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHISopimustyyppiId.DataBind()
    ddKHIYksikkoId.DataSource = tietokanta.HaeKokonaispintaalanYksikot()
    ddKHIYksikkoId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKHIYksikkoId.DataBind()
  End Sub

  Private Sub TaytaLomake(korvaushinnasto As Entities.KorvausHinnasto)

    cbKHIAktiivinen.Checked = korvaushinnasto.KHIAktiivinen
    txtKHIAlkuPvm.Text = Paivaykset.PalautaPaivays(korvaushinnasto.KHIAlkuPvm)
    txtKHIArvonPeruste.Text = korvaushinnasto.KHIArvonPeruste
    txtKHIInfo.Text = korvaushinnasto.KHIInfo
    txtKHIKorvauslaji.Text = korvaushinnasto.KHIKorvauslaji
    txtKHIKuvaus.Text = korvaushinnasto.KHIKuvaus
    txtKHILoppuPvm.Text = Paivaykset.PalautaPaivays(korvaushinnasto.KHILoppuPvm)
    txtKHIPuustonIka.Text = Luvut.EsitaNullableInteger(korvaushinnasto.KHIPuustonIka)
    txtKHITaimistonValtapituus.Text = Luvut.EsitaNullableDecimal(korvaushinnasto.KHITaimistonValtapituus)
    txtKHITiheyskerroin.Text = Luvut.EsitaNullableDecimal(korvaushinnasto.KHITiheyskerroin)
    txtKHIYksikkkohinta.Text = Luvut.EsitaNullableDecimal(korvaushinnasto.KHIYksikkkohinta)
    txtKHIYksikkohinnanTarkenne.Text = korvaushinnasto.KHIYksikkohinnanTarkenne

    Pudotusvalikko.Valitse(ddKHIHinnastoKategoriaId, korvaushinnasto.KHIHinnastoKategoriaId)
    Pudotusvalikko.Valitse(ddKHIHinnastoAlakategoriaId, korvaushinnasto.KHIHinnastoAlakategoriaId)
    Pudotusvalikko.Valitse(ddKHIMaksuAlueId, korvaushinnasto.KHIMaksuAlueId)
    Pudotusvalikko.Valitse(ddKHIMetsatyyppiId, korvaushinnasto.KHIMetsatyyppiId)
    Pudotusvalikko.Valitse(ddKHIPuustolajiId, korvaushinnasto.KHIPuustolajiId)
    Pudotusvalikko.Valitse(ddKHISopimustyyppiId, korvaushinnasto.KHISopimustyyppiId)
    Pudotusvalikko.Valitse(ddKHIYksikkoId, korvaushinnasto.KHIYksikkoId)

  End Sub

  Private Function LuoKorvaushinnasto() As Entities.KorvausHinnasto

    Dim korvaushinnasto = New Entities.KorvausHinnasto()
    korvaushinnasto.KHIAktiivinen = cbKHIAktiivinen.Checked
    korvaushinnasto.KHIAlkuPvm = Paivaykset.PalautaPaivays(txtKHIAlkuPvm.Text)
    korvaushinnasto.KHIArvonPeruste = txtKHIArvonPeruste.Text
    korvaushinnasto.KHIHinnastoKategoriaId = Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoKategoriaId)
    korvaushinnasto.KHIHinnastoAlakategoriaId = Pudotusvalikko.HaeValittuArvo(ddKHIHinnastoAlakategoriaId)
    korvaushinnasto.KHIInfo = txtKHIInfo.Text
    korvaushinnasto.KHIKorvauslaji = txtKHIKorvauslaji.Text
    korvaushinnasto.KHIKuvaus = txtKHIKuvaus.Text
    korvaushinnasto.KHILoppuPvm = Paivaykset.PalautaPaivays(txtKHILoppuPvm.Text)
    korvaushinnasto.KHIMaksuAlueId = Pudotusvalikko.HaeValittuArvo(ddKHIMaksuAlueId)
    korvaushinnasto.KHIMetsatyyppiId = Pudotusvalikko.HaeValittuArvo(ddKHIMetsatyyppiId)
    korvaushinnasto.KHIPuustolajiId = Pudotusvalikko.HaeValittuArvo(ddKHIPuustolajiId)
    korvaushinnasto.KHIPuustonIka = Luvut.HaeNullableInteger(txtKHIPuustonIka.Text)
    korvaushinnasto.KHISopimustyyppiId = Pudotusvalikko.HaeValittuArvo(ddKHISopimustyyppiId)
    korvaushinnasto.KHITaimistonValtapituus = Luvut.HaeNullableDecimal(txtKHITaimistonValtapituus.Text)
    korvaushinnasto.KHITiheyskerroin = Luvut.HaeNullableDecimal(txtKHITiheyskerroin.Text)
    korvaushinnasto.KHIYksikkkohinta = Luvut.HaeNullableDecimal(txtKHIYksikkkohinta.Text)
    korvaushinnasto.KHIYksikkoId = Pudotusvalikko.HaeValittuArvo(ddKHIYksikkoId)
    korvaushinnasto.KHIYksikkohinnanTarkenne = txtKHIYksikkohinnanTarkenne.Text
    Return korvaushinnasto

  End Function

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    If Page.IsValid() Then

      Dim tietokanta = New appSopimusrekisteri.BLL.Korvaushinnasto()
      Dim korvaushinnasto = LuoKorvaushinnasto()

      ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
      ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
      If IsNumeric(Request.Params("id")) Then
        korvaushinnasto.KHIId = Request.Params("id")
        korvaushinnasto = tietokanta.MuokkaaKorvaushinnastoa(korvaushinnasto)
        If Not korvaushinnasto Is Nothing Then
          Response.Redirect(String.Format("~/Ohjaustiedot/Korvaushinnasto/Tiedot.aspx?id={0}", korvaushinnasto.KHIId))
        End If
      Else
        korvaushinnasto = tietokanta.LisaaKorvaushinnasto(korvaushinnasto)
        If Not korvaushinnasto Is Nothing Then
          Response.Redirect(String.Format("~/Ohjaustiedot/Korvaushinnasto/Tiedot.aspx?id={0}", korvaushinnasto.KHIId))
        End If
      End If

    Else
      'TODO: Error message.
    End If
  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    If IsNumeric(Request.Params("id")) Then
      Response.Redirect(String.Format("~/Ohjaustiedot/Korvaushinnasto/Tiedot.aspx?id={0}", Request.Params("id")))
    End If

    Response.Redirect("~/Etusivu.aspx", True)

  End Sub

End Class