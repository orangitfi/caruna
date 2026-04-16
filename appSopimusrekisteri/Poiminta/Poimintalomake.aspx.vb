Public Class Poimintalomake
  Inherits BasePage

  Protected Shadows Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      If Boolean.TryParse(Request.Params("poisto"), Nothing) Then
        Me.Poisto = CBool(Request.Params("poisto"))
      End If

      TaytaOperaattoriPudotusvalikot()
      TaytaPudotusValikot()

      If IsNumeric(Request.Params("eid")) Then
        KaytaTallennettujaEhtoja(Request.Params("eid"))
      End If
    End If

  End Sub

  Private Sub KaytaTallennettujaEhtoja(ehtoId As Integer)
    Dim ehtoJoukko As Entities.TallennettuPoimintaehto = New BLL.Poiminta().HaePoimintaEhdot(ehtoId)
    For Each ehto As Entities.TallennettuPoimintaehto_Ehto In ehtoJoukko.TallennettuPoimintaehto_Ehto
      Dim operaattori As DropDownList = Kontrollit.HaeKontrollit(Of DropDownList)(Page).First(Function(x) x.ID = "opr" & ehto.TPEEKentta)
      If Not IsNothing(operaattori) Then
        operaattori.SelectedValue = ehto.TPEEOperaattori
      End If
      If ehto.TPEETekstikentta Then
        Dim arvokentta As TextBox = Kontrollit.HaeKontrollit(Of TextBox)(Page).First(Function(x) x.ID = ehto.TPEEKentta)
        If Not IsNothing(arvokentta) Then
          arvokentta.Text = ehto.TPEEArvo
        End If
      Else
        Dim arvokentta As DropDownList = Kontrollit.HaeKontrollit(Of DropDownList)(Page).First(Function(x) x.ID = ehto.TPEEKentta)
        If Not IsNothing(arvokentta) Then
          arvokentta.SelectedValue = ehto.TPEEArvo
        End If
      End If
    Next
    rblPoimintaTyyppi.SelectedValue = ehtoJoukko.TPEPoimintaTyyppi
  End Sub

  Private Sub TaytaOperaattoriPudotusvalikot()

    For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(Me).Where(Function(x) x.ID.StartsWith("opr"))

      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.YhtaSuuri.ToString(), "="))
      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.EriSuuri.ToString(), "<>"))
      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.PienempiTaiYhtaSuuri.ToString(), "<="))
      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri.ToString(), ">="))
      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.Tyhja.ToString(), "Tyhjä"))
      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.EiTyhja.ToString(), "Ei tyhjä"))
      valikko.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.Valilla.ToString(), "Välillä"))

    Next

  End Sub

  Private Sub TaytaBooleanPudotusvalikko(valikko As DropDownList)

    valikko.Items.Add(Pudotusvalikko.LuoTyhjaValinta())
    valikko.Items.Add(Pudotusvalikko.LuoValinta(0, "Ei"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta(1, "Kyllä"))

  End Sub

  Private Sub TaytaPudotusValikot()

    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
    JuridinenYhtioId.DataSource = tietokanta.HaeJuridisetYhtiot()
    JuridinenYhtioId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    JuridinenYhtioId.DataBind()
    SopimustyyppiId.DataSource = tietokanta.HaeSopimusTyypit()
    SopimustyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    SopimustyyppiId.DataBind()
    YlasopimuksenTyyppiId.DataSource = tietokanta.HaeYlasopimuksenTyypit()
    YlasopimuksenTyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    YlasopimuksenTyyppiId.DataBind()
    PuustonOmistajuusId.DataSource = tietokanta.HaePuustonOmistajuudet()
    PuustonOmistajuusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    PuustonOmistajuusId.DataBind()
    PuustonPoistoId.DataSource = tietokanta.HaePuustonPoistot()
    PuustonPoistoId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    PuustonPoistoId.DataBind()
    DFRooliId.DataSource = tietokanta.HaeRoolit()
    DFRooliId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    DFRooliId.DataBind()
    SopimuksenAlaluokkaId.DataSource = tietokanta.HaeSopimuksenAlaluokat()
    SopimuksenAlaluokkaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    SopimuksenAlaluokkaId.DataBind()
    SopimuksenEhtoversioId.DataSource = tietokanta.HaeSopimusehdot()
    SopimuksenEhtoversioId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    SopimuksenEhtoversioId.DataBind()
    VastaosapuoliSiirtoOikeusId.DataSource = tietokanta.HaeVastapuolenSiirtoOikeudet()
    VastaosapuoliSiirtoOikeusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    VastaosapuoliSiirtoOikeusId.DataBind()
    VerkonhaltijaSiirtoOikeusId.DataSource = tietokanta.HaeVerkonhaltijanSiirtoOikeudet()
    VerkonhaltijaSiirtoOikeusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    VerkonhaltijaSiirtoOikeusId.DataBind()
    JulkisuusasteId.DataSource = tietokanta.HaeJulkisuusasteet()
    JulkisuusasteId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    JulkisuusasteId.DataBind()
    AlkuperainenYhtioId.DataSource = tietokanta.HaeAlkuperaisetYhtiot()
    AlkuperainenYhtioId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    AlkuperainenYhtioId.DataBind()
    KohdekategoriaId.DataSource = tietokanta.HaeKohdekategoriat()
    KohdekategoriaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    KohdekategoriaId.DataBind()
    KieliId.DataSource = tietokanta.HaeKielet()
    KieliId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    KieliId.DataBind()

    TaytaBooleanPudotusvalikko(Luonnos)

    'Kiinteistö

    'Korvauslaskelma
    MaksunSuoritusId.DataSource = tietokanta.HaeMaksunSuoritukset()
    MaksunSuoritusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    MaksunSuoritusId.DataBind()
    KorvaustyyppiId.DataSource = tietokanta.HaeKorvaustyypit()
    KorvaustyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    KorvaustyyppiId.DataBind()
    MaksukuukausiId.DataSource = tietokanta.HaeKuukaudet()
    MaksukuukausiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    MaksukuukausiId.DataBind()
    KorvausStatusId.DataSource = tietokanta.HaeKorvauslaskelmanStatukset()
    KorvausStatusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    KorvausStatusId.DataBind()
    IndeksityyppiId.DataSource = tietokanta.HaeIndeksityypit()
    IndeksityyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    IndeksityyppiId.DataBind()
    IndeksikuukausiId.DataSource = tietokanta.HaeKuukaudet()
    IndeksikuukausiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    IndeksikuukausiId.DataBind()
    MaksuehdotId.DataSource = tietokanta.HaeMaksuehdot()
    MaksuehdotId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    MaksuehdotId.DataBind()
    KirjanpidonTiliId.DataSource = tietokanta.HaeKirjanpidonTilit()
    KirjanpidonTiliId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    KirjanpidonTiliId.DataBind()
    KustannuspaikkaId.DataSource = tietokanta.HaeKirjanpidonKustannuspaikat()
    KustannuspaikkaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    KustannuspaikkaId.DataBind()

    InvCostId.DataSource = tietokanta.HaeInvcostit()
    InvCostId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    InvCostId.DataBind()
    RegulationId.DataSource = tietokanta.HaePurposet()
    RegulationId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    RegulationId.DataBind()
    PurposeId.DataSource = tietokanta.HaeRegulationit()
    PurposeId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    PurposeId.DataBind()
    Local1Id.DataSource = tietokanta.HaeLocal1t()
    Local1Id.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    Local1Id.DataBind()

    TahoTyyppiId.DataSource = tietokanta.HaeTahoTyypit()
    TahoTyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    TahoTyyppiId.DataBind()
    OrganisaationTyyppiId.DataSource = tietokanta.HaeOrganisaatioidenTyypit(DTO.Enumeraattorit.KayttooikeusTaso.Laaja)
    OrganisaationTyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    OrganisaationTyyppiId.DataBind()

    stAsiakastyyppiId.DataSource = tietokanta.HaeAsiakastyypit()
    stAsiakastyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    stAsiakastyyppiId.DataBind()
    stDFRooliId.DataSource = tietokanta.HaeRoolit()
    stDFRooliId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    stDFRooliId.DataBind()

    TaytaBooleanPudotusvalikko(MaksetaanAlv)
    TaytaBooleanPudotusvalikko(OnIndeksi)

    'Taho

  End Sub

  Private Function HaeHakuehdot() As List(Of DTO.Hakuehto)

    Dim hakuehdot As New List(Of DTO.Hakuehto)()

    hakuehdot.AddRange(HaeHakuehdot(pnlSopimus, DTO.Hakutyyppi.Sopimus, "Sop_"))
    hakuehdot.AddRange(HaeHakuehdot(pnlKiinteisto, DTO.Hakutyyppi.Kiinteisto, "Kii_"))
    hakuehdot.AddRange(HaeHakuehdot(pnlKorvauslaskelma, DTO.Hakutyyppi.Korvauslaskelma, "Kor_"))
    hakuehdot.AddRange(HaeHakuehdot(pnlTaho, DTO.Hakutyyppi.Taho, "Tah_"))
    hakuehdot.AddRange(HaeHakuehdot(pnlSopimus_Taho, DTO.Hakutyyppi.Sopimus_Taho, "st"))
    hakuehdot.AddRange(HaeHakuehdot(pnlMaksu, DTO.Hakutyyppi.Maksu, "m"))

    Return hakuehdot

  End Function

  Private Sub TeeSopimusPoiminta()

    Dim hakuehdot As List(Of DTO.Hakuehto) = HaeHakuehdot()

    Dim tietokanta As New BLL.Poiminta()

    If Me.Poisto Then
      tietokanta.PoistaPoiminnastaSopimuksia(hakuehdot.ToArray(), Session.SessionID)
    Else
      tietokanta.LisaaPoimintaanSopimuksia(hakuehdot.ToArray(), Session.SessionID)
    End If

  End Sub

  Private Sub TeeKiinteistoPoiminta()

    Dim hakuehdot As List(Of DTO.Hakuehto) = HaeHakuEhdot()

    Dim tietokanta As New BLL.Poiminta()

    If Me.Poisto Then
      tietokanta.PoistaPoiminnastaKiinteistoja(hakuehdot.ToArray(), Session.SessionID)
    Else
      tietokanta.LisaaPoimintaanKiinteistoja(hakuehdot.ToArray(), Session.SessionID)
    End If

  End Sub

  Private Sub TeeTahoPoiminta()

    Dim hakuehdot As List(Of DTO.Hakuehto) = HaeHakuehdot()

    Dim tietokanta As New BLL.Poiminta()

    If Me.Poisto Then
      tietokanta.PoistaPoiminnastaTahoja(hakuehdot.ToArray(), Session.SessionID)
    Else
      tietokanta.LisaaPoimintaanTahoja(hakuehdot.ToArray(), Session.SessionID)
    End If

  End Sub

  Private Function HaeEhtoNaytolle(kontrolli As Control) As IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto)
    Dim lstHakuehdot As New List(Of Entities.TallennettuPoimintaehto_Ehto)
    Dim lstOperaattoriKontrollit As List(Of DropDownList) = Kontrollit.HaeKontrollit(Of DropDownList)(kontrolli).Where(Function(x) x.ID.StartsWith("opr")).ToList()
    Dim lstKenttaSelitteet As List(Of Label) = Kontrollit.HaeKontrollit(Of Label)(kontrolli).Where(Function(x) x.ID.StartsWith("lbl")).ToList()
    For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(kontrolli).Where(Function(x) Not x.ID.StartsWith("opr"))

      Dim operaattori As DropDownList = lstOperaattoriKontrollit.FirstOrDefault(Function(x) x.ID = "opr" & valikko.ID)

      If Not IsNothing(operaattori) Then
        If valikko.SelectedValue <> -1 OrElse operaattori.SelectedValue = DTO.Hakuoperaattori.Tyhja.ToString() OrElse operaattori.SelectedValue = DTO.Hakuoperaattori.EiTyhja.ToString() Then

          Dim uusiEhto As New Entities.TallennettuPoimintaehto_Ehto

          uusiEhto.TPEEOperaattori = operaattori.SelectedValue
          uusiEhto.TPEEKentta = valikko.ID
          uusiEhto.TPEEArvo = valikko.SelectedValue
          uusiEhto.TPEETekstikentta = False

          uusiEhto.TPEEKenttaNaytolle = lstKenttaSelitteet.First(Function(x) x.ID = "lbl" & valikko.ID).Text
          uusiEhto.TPEEOperaattoriNaytolle = operaattori.SelectedItem.Text
          uusiEhto.TPEEArvoNaytolle = valikko.SelectedItem.Text

          lstHakuehdot.Add(uusiEhto)

        End If
      End If
    Next

    Dim txtKontrollit As IEnumerable(Of TextBox) = Kontrollit.HaeKontrollit(Of TextBox)(kontrolli)
    Dim arvo2 As TextBox

    For Each tekstikentta As TextBox In txtKontrollit

      Dim operaattori As DropDownList = lstOperaattoriKontrollit.FirstOrDefault(Function(x) x.ID = "opr" & tekstikentta.ID)

      If Not IsNothing(operaattori) Then
        If tekstikentta.Text <> "" OrElse operaattori.SelectedValue = DTO.Hakuoperaattori.Tyhja.ToString() OrElse operaattori.SelectedValue = DTO.Hakuoperaattori.EiTyhja.ToString() Then

          Dim uusiEhto As New Entities.TallennettuPoimintaehto_Ehto

          uusiEhto.TPEEOperaattori = operaattori.SelectedValue
          uusiEhto.TPEEKentta = tekstikentta.ID
          uusiEhto.TPEEArvo = tekstikentta.Text
          uusiEhto.TPEETekstikentta = True

          uusiEhto.TPEEKenttaNaytolle = lstKenttaSelitteet.First(Function(x) x.ID = "lbl" & tekstikentta.ID).Text

          uusiEhto.TPEEOperaattoriNaytolle = operaattori.SelectedItem.Text

          uusiEhto.TPEEArvoNaytolle = tekstikentta.Text

          If operaattori.SelectedValue = DTO.Hakuoperaattori.Valilla.ToString() Then

            uusiEhto.TPEEOperaattoriNaytolle = " " & uusiEhto.TPEEOperaattoriNaytolle & " "

            arvo2 = txtKontrollit.FirstOrDefault(Function(x) x.ID = tekstikentta.ID & "2")

            If Not arvo2 Is Nothing Then

              uusiEhto.TPEEArvoNaytolle &= " - " & arvo2.Text

            End If

          End If

          lstHakuehdot.Add(uusiEhto)

        End If

      End If
    Next

    Return lstHakuehdot
  End Function

  Private Function HaeHakuEhdot(kontrolli As Control, tyyppi As DTO.Hakutyyppi, Optional prefiksi As String = "") As DTO.Hakuehto()

    Dim operaattori As DTO.Hakuoperaattori
    Dim lstHakuehdot As New List(Of DTO.Hakuehto)()
    Dim lstOperaattoriKontrollit As List(Of DropDownList) = Kontrollit.HaeKontrollit(Of DropDownList)(kontrolli).Where(Function(x) x.ID.StartsWith("opr")).ToList()

    For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(kontrolli).Where(Function(x) Not x.ID.StartsWith("opr"))

      If lstOperaattoriKontrollit.Any(Function(x) x.ID = "opr" & valikko.ID) Then

        operaattori = [Enum].Parse(GetType(DTO.Hakuoperaattori), lstOperaattoriKontrollit.First(Function(x) x.ID = "opr" & valikko.ID).SelectedValue)

        If operaattori = DTO.Hakuoperaattori.EiTyhja Or operaattori = DTO.Hakuoperaattori.Tyhja Then
          lstHakuehdot.Add(New DTO.Hakuehto(tyyppi, PoistaPrefiksi(valikko.ID, prefiksi), operaattori))
        ElseIf valikko.SelectedValue > 0 Then
          lstHakuehdot.Add(New DTO.Hakuehto(tyyppi, PoistaPrefiksi(valikko.ID, prefiksi), operaattori, CInt(valikko.SelectedValue)))
        End If

      End If

    Next

    Dim txtKontrollit As IEnumerable(Of TextBox) = Kontrollit.HaeKontrollit(Of TextBox)(kontrolli)
    Dim arvo2 As TextBox

    For Each tekstikentta As TextBox In txtKontrollit

      If lstOperaattoriKontrollit.Any(Function(x) x.ID = "opr" & tekstikentta.ID) Then

        operaattori = [Enum].Parse(GetType(DTO.Hakuoperaattori), lstOperaattoriKontrollit.First(Function(x) x.ID = "opr" & tekstikentta.ID).SelectedValue)

        If operaattori = DTO.Hakuoperaattori.EiTyhja Or operaattori = DTO.Hakuoperaattori.Tyhja Then
          lstHakuehdot.Add(New DTO.Hakuehto(tyyppi, PoistaPrefiksi(tekstikentta.ID, prefiksi), operaattori))
        ElseIf operaattori = DTO.Hakuoperaattori.Valilla Then

          If Not String.IsNullOrEmpty(tekstikentta.Text) Then
            lstHakuehdot.Add(New DTO.Hakuehto(tyyppi, PoistaPrefiksi(tekstikentta.ID, prefiksi), DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri, tekstikentta.Text))
          End If

          arvo2 = txtKontrollit.FirstOrDefault(Function(x) x.ID = tekstikentta.ID & "2")

          If Not arvo2 Is Nothing AndAlso Not String.IsNullOrEmpty(arvo2.Text) Then
            lstHakuehdot.Add(New DTO.Hakuehto(tyyppi, PoistaPrefiksi(tekstikentta.ID, prefiksi), DTO.Hakuoperaattori.PienempiTaiYhtaSuuri, arvo2.Text))
          End If

        ElseIf Not String.IsNullOrEmpty(tekstikentta.Text) Then
          lstHakuehdot.Add(New DTO.Hakuehto(tyyppi, PoistaPrefiksi(tekstikentta.ID, prefiksi), operaattori, tekstikentta.Text))
        End If

      End If

    Next

    Return lstHakuehdot.ToArray()

  End Function

  Private Function PoistaPrefiksi(id As String, prefiksi As String) As String

    If id.StartsWith(prefiksi) Then
      Return id.Remove(0, prefiksi.Length)
    Else
      Return id
    End If

  End Function

  Private Sub btPoimi_Click(sender As Object, e As EventArgs) Handles btPoimi.Click

    If rblPoimintaTyyppi.SelectedValue = "sopimus" Then
      TeeSopimusPoiminta()
    ElseIf rblPoimintaTyyppi.SelectedValue = "kiinteisto" Then
      TeeKiinteistoPoiminta()
    ElseIf rblPoimintaTyyppi.SelectedValue = "taho" Then
      TeeTahoPoiminta()
    End If

    Dim ehdotNaytolle As IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto)
    ehdotNaytolle = HaeEhtoNaytolle(pnlSopimus)
    ehdotNaytolle = ehdotNaytolle.Union(HaeEhtoNaytolle(pnlKiinteisto))
    ehdotNaytolle = ehdotNaytolle.Union(HaeEhtoNaytolle(pnlKorvauslaskelma))
    ehdotNaytolle = ehdotNaytolle.Union(HaeEhtoNaytolle(pnlTaho))
    ehdotNaytolle = ehdotNaytolle.Union(HaeEhtoNaytolle(pnlSopimus_Taho))
    ehdotNaytolle = ehdotNaytolle.Union(HaeEhtoNaytolle(pnlMaksu))

    Session("poimintaEhdot") = ehdotNaytolle
    Session("poimintaTyyppi") = rblPoimintaTyyppi.SelectedValue

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

  Public Property Poisto As Boolean
    Set(value As Boolean)
      ViewState("poisto") = value
    End Set
    Get
      If Boolean.TryParse(ViewState("poisto"), Nothing) Then
        Return CBool(ViewState("poisto"))
      Else
        Return False
      End If
    End Get
  End Property

End Class