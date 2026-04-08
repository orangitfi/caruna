Public Class Lisaa_poimituille
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsPostBack Then
      TaytaPudotusvalikot()
      TaytaOletusTiedot()
    End If

  End Sub

  Private Sub TaytaPudotusvalikot()

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

    ddKorvaustyyppi.DataSource = tietokanta.HaeKorvaustyypit()
    ddKorvaustyyppi.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddKorvaustyyppi.DataBind()
    ddMaksukuukausi.DataSource = tietokanta.HaeKuukaudet()
    ddMaksukuukausi.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddMaksukuukausi.DataBind()
    ddMaksunSuoritus.DataSource = tietokanta.HaeMaksunSuoritukset()
    ddMaksunSuoritus.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddMaksunSuoritus.DataBind()

  End Sub

  Private Sub TaytaOletusTiedot()

    ddMAKMaksuStatusId.Items.Add(Pudotusvalikko.LuoValinta(DTO.Enumeraattorit.MaksuStatus.Maksettu, "Maksettu"))
    ddMAKMaksuStatusId.Enabled = False

  End Sub

  Private Function LuoMaksu(korvauslaskelma As DTO.Korvauslaskelma) As DTO.Maksu

    Dim maksu As DTO.Maksu

    Dim tietokantaKorvauslaskelma As New BLL.Korvauslaskelma(_konteksti)

    Dim tietokantaMaksu As New BLL.Maksu(_konteksti)

    maksu = tietokantaMaksu.LuoMaksut({korvauslaskelma}.ToList()).First()

    maksu.Maksupvm = Paivaykset.PalautaPaivays(txtMAKMaksupaiva.Text)
    maksu.Info = txtMAKInfo.Text

    Return maksu
  End Function

  Private Function LuoMaksut(idt As IEnumerable(Of Integer)) As Boolean
    Dim korvauslaskelmat As IEnumerable(Of DTO.Korvauslaskelma) = New BLL.Korvauslaskelma(_konteksti).HaeKorvauslaskelmatDTO(idt)
    Dim maksut As New List(Of DTO.Maksu)

    Dim maksujenSumma As Decimal = 0

    For Each laskelma As DTO.Korvauslaskelma In korvauslaskelmat
      Dim maksu As DTO.Maksu = LuoMaksu(laskelma)
      maksut.Add(maksu)
      maksujenSumma += maksu.Summa
    Next

    If maksujenSumma <> txtMAKSumma.Text Then
      custValSummaTasmaa.IsValid = False
      Return False
    End If

    Dim tietokanta = New appSopimusrekisteri.BLL.Maksu(_konteksti)

    For Each maksu As DTO.Maksu In maksut
      tietokanta.LisaaMaksu(maksu)
    Next

    custValSummaTasmaa.IsValid = True
    Return True
  End Function

  Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click

    If Page.IsValid() Then

      If LuoMaksut(ViewState("korvauslaskelmat")) Then
        Response.Redirect(String.Format("~/Etusivu.aspx"))
      End If

    End If

  End Sub

  Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

    Response.Redirect(String.Format("~/Etusivu.aspx"))

  End Sub

  Protected Sub btnHae_Click(sender As Object, e As EventArgs) Handles btnHae.Click

    Dim ehto As Func(Of DTO.Korvauslaskelma, Boolean) = Function(x) True

    If ddKorvaustyyppi.SelectedValue <> -1 Then
      ehto = Function(x) ehto(x) And x.KorvaustyyppiId = ddKorvaustyyppi.SelectedValue
    End If

    If ddMaksukuukausi.SelectedValue <> -1 Then
      ehto = Function(x) ehto(x) And x.MaksukuukausiId = ddMaksukuukausi.SelectedValue
    End If

    If ddMaksunSuoritus.SelectedValue <> -1 Then
      ehto = Function(x) ehto(x) And x.MaksunSuoritusId = ddMaksunSuoritus.SelectedValue
    End If

    Dim sopimukset As IEnumerable(Of DTO.Sopimus) = New BLL.Poiminta().HaePoimintaJoukkoSopimukset(Context.Session.SessionID)
    Dim korvauslaskelmat As IEnumerable(Of DTO.Korvauslaskelma) = BLL.Korvauslaskelma.HaeSopimustenKorvauslaskelmatJotkaTayttavatEhdon(sopimukset, Context.Session.SessionID, Function(x) True)

    ViewState("korvauslaskelmat") = korvauslaskelmat.Select(Function(x) x.Id).ToList()

    lblSopimus.Text = sopimukset.Count & " sopimusta"
    lblKorvauslaskelma.Text = korvauslaskelmat.Count & " korvauslaskelmaa"

  End Sub

  Protected Sub custValKorvauslaskelmiaOnOlemassa_ServerValidate(source As Object, args As ServerValidateEventArgs)
    If IsNothing(ViewState("korvauslaskelmat")) Then
      args.IsValid = False
      Return
    End If
    If ViewState("korvauslaskelmat") Is GetType(IEnumerable(Of Integer)) Then
      args.IsValid = False
      Return
    End If
    If CType(ViewState("korvauslaskelmat"), IEnumerable(Of Integer)).Count = 0 Then
      args.IsValid = False
    End If
  End Sub
End Class