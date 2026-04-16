Public Class Lisaa
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      If IsNumeric(Request.Params("sopimusId")) Then
        Me.SopimusId = CInt(Request.Params("sopimusId"))
      End If

      If IsNumeric(Request.Params("korvauslaskelmaId")) Then
        Me.KorvauslaskelmaId = CInt(Request.Params("korvauslaskelmaId"))
      End If

      TaytaOletusTiedot()

    End If

  End Sub

  Private Sub TaytaOletusTiedot()

    If Me.KorvauslaskelmaId.HasValue Then

      Dim tietokantaKorvauslaskelma As New BLL.Korvauslaskelma(_konteksti)

      Dim korvauslaskelma As DTO.Korvauslaskelma = tietokantaKorvauslaskelma.HaeKorvauslaskelmaDTO(Me.KorvauslaskelmaId.Value)

      Dim tietokantaMaksu As New BLL.Maksu(_konteksti)

      Dim maksu As DTO.Maksu = tietokantaMaksu.LuoMaksut({korvauslaskelma}.ToList()).First()

      txtMAKSumma.Text = Luvut.EsitaNullableDecimal(maksu.Summa)
      txtMAKSumma.Enabled = False

    End If

    ddMAKMaksuStatusId.Items.Add(Pudotusvalikko.LuoValinta(DTO.Enumeraattorit.MaksuStatus.Maksettu, "Maksettu"))
    ddMAKMaksuStatusId.Enabled = False

  End Sub

  Private Function LuoMaksu() As DTO.Maksu

    Dim maksu As DTO.Maksu

    Dim tietokantaKorvauslaskelma As New BLL.Korvauslaskelma(_konteksti)

    Dim korvauslaskelma As DTO.Korvauslaskelma = tietokantaKorvauslaskelma.HaeKorvauslaskelmaDTO(Me.KorvauslaskelmaId.Value)

    Dim tietokantaMaksu As New BLL.Maksu(_konteksti)

    maksu = tietokantaMaksu.LuoMaksut({korvauslaskelma}.ToList()).First()

    maksu.Maksupvm = Paivaykset.PalautaPaivays(txtMAKMaksupaiva.Text)
    maksu.Info = txtMAKInfo.Text

    Return maksu
  End Function

  Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click

    If Page.IsValid() Then
      Dim tietokanta = New appSopimusrekisteri.BLL.Maksu(_konteksti)

      Dim maksu As DTO.Maksu = LuoMaksu()

      tietokanta.LisaaMaksu(maksu)

      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.SopimusId.Value))

    End If

  End Sub

  Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

    Response.Redirect(String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusId={1}", Me.KorvauslaskelmaId, Me.SopimusId))

  End Sub

  Public Property SopimusId As Integer?
    Set(value As Integer?)
      hdnSopimusId.Value = value
    End Set
    Get
      If IsNumeric(hdnSopimusId.Value) Then
        Return CInt(hdnSopimusId.Value)
      End If

      Return Nothing
    End Get
  End Property

  Public Property KorvauslaskelmaId As Integer?
    Set(value As Integer?)
      hdnKorvauslaskelmaId.Value = value
    End Set
    Get
      If IsNumeric(hdnKorvauslaskelmaId.Value) Then
        Return CInt(hdnKorvauslaskelmaId.Value)
      End If

      Return Nothing
    End Get
  End Property

End Class