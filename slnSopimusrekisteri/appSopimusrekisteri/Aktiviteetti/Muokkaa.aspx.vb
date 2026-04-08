Public Class AktiviteetinMuokkaus
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Aktiviteetit) Then
      Response.Redirect("etusivu.aspx")
      Return
    End If

    If Not IsPostBack Then
      If Request.Params("joukko") = "k" Then
        ViewState("joukko") = True
        AsetaMontaSopimustaTeksti()
        TaytaPudotusValikot(True)
        TaytaOletusTiedot()
      Else
        ViewState("joukko") = False
        If Not IsNumeric(Request.Params("sid")) Then
          Response.Redirect("~/Etusivu.aspx", True)
        End If

        SId = Request.Params("sid")
        ValitseSopimus(SId)

        TaytaPudotusValikot(False)

        If IsNumeric(Request.Params("id")) Then
          'muokataan vanhaa
          AId = CInt(Request.Params("id"))
          Dim tietokanta = New appSopimusrekisteri.BLL.Aktiviteetti(_konteksti)

          Dim aktiviteetti As DTO.Aktiviteetti = tietokanta.HaeAktiviteetti(AId)
          If Not aktiviteetti Is Nothing Then
            TaytaLomake(aktiviteetti)
            TaytaMuokkaustiedot(aktiviteetti)
          Else
            ' TODO: Virheilmoitus!
          End If
        Else
          'luodaan uusi
          TaytaOletusTiedot()
        End If
      End If
    End If
  End Sub

  Private Sub AsetaMontaSopimustaTeksti()
    phYksiSopimus.Visible = False
    phMontaSopimusta.Visible = True
    Dim tietokanta = New BLL.Poiminta()
    lblMontaSopimusta.Text = "Lisätään aktiviteetti " & tietokanta.HaePoimintaSopimustenLkm(Context.Session.SessionID) & " sopimukselle"
  End Sub

  Private Sub TaytaOletusTiedot()
    txtAKPaivamaara.Text = Date.Today
    ddAKStatusId.SelectedValue = New BLL.AktiviteetinStatus().Hae("Avoin").ASId
    ddAKKontaktoijaId.SelectedValue = DirectCast(Membership.GetUser(User.Identity.Name).ProviderUserKey, Guid).ToString()
  End Sub

  Private Sub ValitseSopimus(ByVal sopimusId As Integer)
    SId = sopimusId
    lblAKSopimusId.Text = New BLL.Sopimus(_konteksti).HaeSopimusDTO(sopimusId).Nimi
  End Sub

  Private Sub TaytaLomake(ByVal aktiviteetti As DTO.Aktiviteetti)

    If Not IsNothing(aktiviteetti.Taho) Then
      ddAKTahoId.SelectedValue = aktiviteetti.Taho.Id
    End If
    If Not IsNothing(aktiviteetti.Sopimus) Then
      ValitseSopimus(aktiviteetti.Sopimus.Id)
    End If
    If aktiviteetti.KontaktoijaGuid.HasValue Then
      ddAKKontaktoijaId.SelectedValue = aktiviteetti.KontaktoijaGuid.Value.ToString()
    End If
    If Not IsNothing(aktiviteetti.YhteydenottotapaId) Then
      ddAKYhteystapaId.SelectedValue = aktiviteetti.YhteydenottotapaId
    End If
    If Not IsNothing(aktiviteetti.LajiId) Then
      ddAKAktiviteetinLajiId.SelectedValue = aktiviteetti.LajiId
    End If
    If Not IsNothing(aktiviteetti.StatusId) Then
      ddAKStatusId.SelectedValue = aktiviteetti.StatusId
    End If

    If Not IsNothing(aktiviteetti.Paivamaara) Then
      txtAKPaivamaara.Text = aktiviteetti.Paivamaara
    End If
    If Not IsNothing(aktiviteetti.SeuraavaYhteydenottoPaivamaara) Then
      txtAKSeuraavaYhteyspaiva.Text = aktiviteetti.SeuraavaYhteydenottoPaivamaara
    End If
    If Not IsNothing(aktiviteetti.Kuvaus) Then
      txtAKKuvaus.Text = aktiviteetti.Kuvaus
    End If

  End Sub

  Private Sub TaytaMuokkaustiedot(aktiviteetti As DTO.Aktiviteetti)

    lblAKPaivitetty.Text = Paivaykset.PalautaPaivays(aktiviteetti.Paivitetty)
    lblAKPaivittaja.Text = aktiviteetti.Paivittaja
    lblAKLuotu.Text = Paivaykset.PalautaPaivays(aktiviteetti.Luotu)
    lblAKLuoja.Text = aktiviteetti.Luoja
    phPaivitystiedot.Visible = True

  End Sub

  Private Sub TaytaPudotusValikot(joukko As Boolean)
    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

    If joukko Then
      Dim tahot As New List(Of DTO.Hakutulos)
      For Each sopimus As DTO.Sopimus In New BLL.Poiminta().HaePoimintaJoukkoSopimukset(Context.Session.SessionID)
        tahot.AddRange(tietokanta.HaeSopimuksenTahot(sopimus.Id).Select(Function(x) Pudotusvalikko.LuoHakutulos(x.Id, x.Nimi)))
      Next
      'tahot = tahot.Distinct()
      ddAKTahoId.DataSource = tahot
      ddAKTahoId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
      ddAKTahoId.DataBind()
    Else
      ddAKTahoId.DataSource = tietokanta.HaeSopimuksenTahot(SId).Select(Function(x) Pudotusvalikko.LuoHakutulos(x.Id, x.Nimi)).ToList()
      ddAKTahoId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
      ddAKTahoId.DataBind()
    End If

    ddAKKontaktoijaId.DataSource = New List(Of ListItem)
    For Each Kayttaja As MembershipUser In Membership.GetAllUsers()
      ddAKKontaktoijaId.DataSource.Add(Pudotusvalikko.LuoValinta(DirectCast(Kayttaja.ProviderUserKey, Guid).ToString(), Kayttaja.UserName))
    Next
    ddAKKontaktoijaId.DataBind()

    ddAKAktiviteetinLajiId.DataSource = tietokanta.HaeAktiviteetinLajit()
    ddAKAktiviteetinLajiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKAktiviteetinLajiId.DataBind()

    ddAKYhteystapaId.DataSource = tietokanta.HaeAktiviteetinYhteystavat()
    ddAKYhteystapaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKYhteystapaId.DataBind()

    ddAKStatusId.DataSource = tietokanta.HaeAktiviteetinStatukset()
    ddAKStatusId.DataBind()

  End Sub

  Private Function LuoAktiviteetti(valitseSopimus As Boolean) As DTO.Aktiviteetti
    Dim tulos As DTO.Aktiviteetti = New DTO.Aktiviteetti()

    If AId.HasValue Then
      tulos.Id = AId.Value
    End If

    'haussa ei ollut kirjoitushetkellä yhden tahon hakua ID:n mukaan, haetaan täältä
    tulos.Taho = If(Pudotusvalikko.HaeValittuArvo(ddAKTahoId).HasValue, New appSopimusrekisteri.BLL.Taho(_konteksti).HaeTahoDTO(Pudotusvalikko.HaeValittuArvo(ddAKTahoId).Value), Nothing)
    If valitseSopimus Then
      tulos.Sopimus = New BLL.Sopimus(_konteksti).HaeSopimusDTO(SId)
    End If
    tulos.KontaktoijaGuid = New Guid(ddAKKontaktoijaId.SelectedValue)
    If txtAKPaivamaara.Text <> "" Then
      tulos.Paivamaara = txtAKPaivamaara.Text
    End If
    If txtAKSeuraavaYhteyspaiva.Text <> "" Then
      tulos.SeuraavaYhteydenottoPaivamaara = txtAKSeuraavaYhteyspaiva.Text
    End If
    tulos.Kuvaus = txtAKKuvaus.Text
    tulos.YhteydenottotapaId = Pudotusvalikko.HaeValittuArvo(ddAKYhteystapaId)
    tulos.LajiId = Pudotusvalikko.HaeValittuArvo(ddAKAktiviteetinLajiId)
    tulos.StatusId = Pudotusvalikko.HaeValittuArvo(ddAKStatusId)

    Return tulos
  End Function

  Private Sub TallennaJoukkoJaOhjaaUudelleen()
    Dim tietokanta = New appSopimusrekisteri.BLL.Aktiviteetti(_konteksti)
    Dim sopimukset = New BLL.Poiminta().HaePoimintaJoukkoSopimukset(Context.Session.SessionID)
    For Each sopimus As DTO.Sopimus In sopimukset
      Dim aktiviteetti As DTO.Aktiviteetti = LuoAktiviteetti(False)
      aktiviteetti.Sopimus = sopimus
      aktiviteetti.SopimusId = sopimus.Id
      tietokanta.LisaaAktiviteetti(aktiviteetti)
    Next
    Response.Redirect("~/Poiminta/Poimintalomake.aspx")
  End Sub

  Private Sub TallennaYksiJaOhjaaUudelleen()
    Dim tietokanta = New appSopimusrekisteri.BLL.Aktiviteetti(_konteksti)
    Dim aktiviteetti As DTO.Aktiviteetti = LuoAktiviteetti(True)

    If AId.HasValue Then
      aktiviteetti = tietokanta.MuokkaaAktiviteettia(aktiviteetti)
    Else
      aktiviteetti = tietokanta.LisaaAktiviteetti(aktiviteetti)
    End If
    If SId.HasValue Then
      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", SId.Value))
    End If

    If Not aktiviteetti Is Nothing Then
      Response.Redirect(String.Format("~/Aktiviteetti/Tiedot.aspx?id={0}", aktiviteetti.Id))
    End If
  End Sub

  Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click
    If Page.IsValid() Then
      If ViewState("joukko") Then
        TallennaJoukkoJaOhjaaUudelleen()
      Else
        TallennaYksiJaOhjaaUudelleen()
      End If
    End If
  End Sub

  Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

    If SId.HasValue Then
      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", SId.Value))
    End If

    If AId.HasValue Then
      Response.Redirect(String.Format("~/Aktiviteetti/Tiedot.aspx?id={0}", AId.Value), True)
    Else
      Response.Redirect("~/Etusivu.aspx", True)
    End If

  End Sub

  Public Property AId As Integer?
    Set(value As Integer?)
      hdnAId.Value = value.Value
    End Set
    Get
      If Not String.IsNullOrEmpty(hdnAId.Value) Then
        Return CInt(hdnAId.Value)
      End If
      Return Nothing
    End Get
  End Property

  Public Property SId As Integer?
    Set(value As Integer?)
      hdnSId.Value = value.Value
    End Set
    Get
      If Not String.IsNullOrEmpty(hdnSId.Value) Then
        Return CInt(hdnSId.Value)
      End If
      Return Nothing
    End Get
  End Property

  Protected Sub custvalAKYhteystapaId_ServerValidate(source As Object, args As ServerValidateEventArgs)
    If Not Pudotusvalikko.HaeValittuArvo(ddAKYhteystapaId).HasValue Then
      args.IsValid = False
    End If
  End Sub
End Class