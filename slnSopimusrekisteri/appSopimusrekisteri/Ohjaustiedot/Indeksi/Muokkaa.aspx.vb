Public Class Muokkaa1
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      TaytaPudotusvalikot()

      If IsNumeric(Request.Params("id")) Then

        Me.OId = CInt(Request.Params("id"))

        Dim tietokanta As New appSopimusrekisteri.BLL.Indeksi(_konteksti)

        Dim muokattava = tietokanta.Hae(Me.OId.Value)

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

  Private Sub TaytaPudotusvalikot()

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

    ddIndeksityyppiId.DataSource = tietokanta.HaeIndeksityypit()
    ddIndeksityyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddIndeksityyppiId.DataBind()

    ddKuukausiId.DataSource = tietokanta.HaeKuukaudet()
    ddKuukausiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKuukausiId.DataBind()

  End Sub

  Private Sub TaytaMuokkaustiedot(muokattava As DTO.Indeksi)

    lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.Paivitetty)
    lblPaivittaja.Text = muokattava.Paivittaja
    lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.Luotu)
    lblLuoja.Text = muokattava.Luoja

  End Sub

  Private Sub TaytaLomake(muokattava As DTO.Indeksi)

    Pudotusvalikko.Valitse(ddIndeksityyppiId, muokattava.IndeksityyppiId)

    txtVuosi.Text = Luvut.EsitaNullableInteger(muokattava.Vuosi)
    Pudotusvalikko.Valitse(ddKuukausiId, muokattava.KuukausiId)
    txtArvo.Text = Luvut.EsitaNullableInteger(muokattava.Arvo)

  End Sub

  Private Function LuoTallennettavaObjekti() As DTO.Indeksi

    Dim tallennettava As New DTO.Indeksi()

    tallennettava.IndeksityyppiId = Pudotusvalikko.HaeValittuArvo(ddIndeksityyppiId)
    tallennettava.Vuosi = Luvut.HaeNullableInteger(txtVuosi.Text)
    tallennettava.KuukausiId = Pudotusvalikko.HaeValittuArvo(ddKuukausiId)
    tallennettava.Arvo = Luvut.HaeNullableInteger(txtArvo.Text)

    Return tallennettava

  End Function

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    If Page.IsValid() Then

      Dim tietokanta As New appSopimusrekisteri.BLL.Indeksi(_konteksti)
      Dim tallennettava As DTO.Indeksi = LuoTallennettavaObjekti()
      ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
      ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
      If Me.OId.HasValue Then
        tallennettava.Id = Me.OId.Value
        tallennettava = tietokanta.Muokkaa(tallennettava)
        If Not tallennettava Is Nothing Then
          Response.Redirect(String.Format("~/Ohjaustiedot/Indeksi/Tiedot.aspx?id={0}", tallennettava.Id))
        End If
      Else
        tallennettava = tietokanta.Lisaa(tallennettava)
        If Not tallennettava Is Nothing Then
          Response.Redirect(String.Format("~/Ohjaustiedot/Indeksi/Tiedot.aspx?id={0}", tallennettava.Id))
        End If
      End If
    Else
      'TODO: Error message.
    End If
  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    Response.Redirect("~/Ohjaustiedot/Indeksi/Tiedot.aspx", True)

  End Sub

  Public Property OId As Integer?
    Set(value As Integer?)
      hdnId.Value = value.Value
    End Set
    Get
      If Not String.IsNullOrEmpty(hdnId.Value) Then
        Return CInt(hdnId.Value)
      End If

      Return Nothing
    End Get
  End Property

End Class