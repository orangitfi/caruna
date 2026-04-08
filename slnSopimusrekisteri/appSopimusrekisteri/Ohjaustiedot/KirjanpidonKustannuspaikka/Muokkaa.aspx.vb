Imports appSopimusrekisteri.DTO

Public Class KirjanpidonKustannuspaikanMuokkaus
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      If IsNumeric(Request.Params("id")) Then

        Dim tietokanta = New appSopimusrekisteri.BLL.KirjanpidonKustannuspaikka()
        Dim muokattava = tietokanta.Hae(Request.Params("id"))
        If Not muokattava Is Nothing Then
          TaytaLomake(muokattava)
          TaytaMuokkaustiedot(muokattava)
        Else
          ' TODO: Virheilmoitus!
        End If
      Else
        ' TODO: Virheilmoitus!
      End If

    End If

  End Sub

  Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_KirjanpidonKustannuspaikka)

    lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.KPKPaivitetty)
    lblPaivittaja.Text = muokattava.KPKPaivittaja
    lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.KPKLuotu)
    lblLuoja.Text = muokattava.KPKLuoja
    phPaivitystiedot.Visible = True

  End Sub

  Private Sub TaytaLomake(muokattava As Entities.hlp_KirjanpidonKustannuspaikka)

    txtNimi.Text = muokattava.KPKKirjanpidonKustannuspaikka
    txtSelite.Text = muokattava.KPKSelite

  End Sub

  Private Function LuoTallennettavaObjekti() As Entities.hlp_KirjanpidonKustannuspaikka

    Dim tallennettava = New Entities.hlp_KirjanpidonKustannuspaikka()
    tallennettava.KPKKirjanpidonKustannuspaikka = txtNimi.Text
    tallennettava.KPKSelite = txtSelite.Text
    Return tallennettava

  End Function

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    If Page.IsValid() Then

      Dim tietokanta = New appSopimusrekisteri.BLL.KirjanpidonKustannuspaikka()
      Dim tallennettava = LuoTallennettavaObjekti()

      ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
      ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
      If IsNumeric(Request.Params("id")) Then
        tallennettava.KPKId = Request.Params("id")
        tallennettava = tietokanta.Muokkaa(tallennettava)
        If Not tallennettava Is Nothing Then
          Response.Redirect(String.Format("~/Ohjaustiedot/KirjanpidonKustannuspaikka/Tiedot.aspx?id={0}", tallennettava.KPKId))
        End If
      Else
        tallennettava = tietokanta.Lisaa(tallennettava)
        If Not tallennettava Is Nothing Then
          Response.Redirect(String.Format("~/Ohjaustiedot/KirjanpidonKustannuspaikka/Tiedot.aspx?id={0}", tallennettava.KPKId))
        End If
      End If

    Else
      'TODO: Error message.
    End If
  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    If IsNumeric(Request.Params("id")) Then
      Response.Redirect(String.Format("~/Ohjaustiedot/KirjanpidonKustannuspaikka/Tiedot.aspx?id={0}", Request.Params("id")))
    End If

    Response.Redirect("~/Ohjaustiedot/KirjanpidonKustannuspaikka/Tiedot.aspx", True)

  End Sub

End Class