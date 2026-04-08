Public Class Poiminta
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Aktiviteetit) Then
      Response.Redirect("etusivu.aspx")
      Return
    End If

    If Not Page.IsPostBack Then
      TaytaPudotusValikot()
    End If
  End Sub

  Private Sub TaytaPudotusValikot()
    Dim tietokanta = New appSopimusrekisteri.BLL.Haku()

    'Tahot haetaan erikseen
    'Sopimukset haetaan erikseen

    ddAKKontaktoijaId.DataSource = New List(Of ListItem)
    For Each Kayttaja As MembershipUser In Membership.GetAllUsers()
      ddAKKontaktoijaId.DataSource.Add(Pudotusvalikko.LuoValinta(DirectCast(Kayttaja.ProviderUserKey, Guid).ToString(), Kayttaja.UserName))
    Next
    ddAKKontaktoijaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaValinta())
    ddAKKontaktoijaId.DataBind()

    ddAKAktiviteetinLajiId.DataSource = tietokanta.HaeAktiviteetinLajit()
    ddAKAktiviteetinLajiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKAktiviteetinLajiId.DataBind()

    ddAKYhteystapaId.DataSource = tietokanta.HaeAktiviteetinYhteystavat()
    ddAKYhteystapaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKYhteystapaId.DataBind()

    ddAKStatusId.DataSource = tietokanta.HaeAktiviteetinStatukset()
    ddAKStatusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKStatusId.DataBind()

  End Sub

  Protected Sub btnTahoFiltteri_Click(sender As Object, e As EventArgs)
    Dim tietokanta = New BLL.Haku()
    Dim tahot = tietokanta.HaeTahot(txtAKTahoId.Text)
    ddAKTahoId.DataSource = tahot
    ddAKTahoId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKTahoId.DataBind()
  End Sub

  Protected Sub btnSopimusFiltteri_Click(sender As Object, e As EventArgs)
    Dim tietokanta = New BLL.Haku()
    Dim tahot = tietokanta.HaeSopimukset(txtAKSopimusId.Text)
    ddAKSopimusId.DataSource = tahot
    ddAKSopimusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
    ddAKSopimusId.DataBind()
  End Sub

  Protected Sub btnHae_Click(sender As Object, e As EventArgs)
    Dim hakuehdot = New List(Of DTO.Hakuehto)
    If txtTunnus.Text <> "" Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "Id", DTO.Hakuoperaattori.YhtaSuuri, CInt(txtTunnus.Text)))
    End If
    If Pudotusvalikko.HaeValittuArvo(ddAKTahoId).HasValue Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "TahoId", DTO.Hakuoperaattori.YhtaSuuri, CInt(Pudotusvalikko.HaeValittuArvo(ddAKTahoId))))
    End If
    If Pudotusvalikko.HaeValittuArvo(ddAKSopimusId).HasValue Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "SopimusId", DTO.Hakuoperaattori.YhtaSuuri, CInt(Pudotusvalikko.HaeValittuArvo(ddAKSopimusId))))
    End If
    'kontaktoija
    If ddAKKontaktoijaId.SelectedValue <> "-1" Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "KontaktoijaGuid", DTO.Hakuoperaattori.YhtaSuuri, New Guid(ddAKKontaktoijaId.SelectedValue)))
    End If
    If Pudotusvalikko.HaeValittuArvo(ddAKYhteystapaId).HasValue Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "YhteydenottotapaId", DTO.Hakuoperaattori.YhtaSuuri, CInt(Pudotusvalikko.HaeValittuArvo(ddAKYhteystapaId))))
    End If
    If Pudotusvalikko.HaeValittuArvo(ddAKAktiviteetinLajiId).HasValue Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "LajiId", DTO.Hakuoperaattori.YhtaSuuri, CInt(Pudotusvalikko.HaeValittuArvo(ddAKAktiviteetinLajiId))))
    End If
    If txtAKPaivamaaraAlku.Text <> "" Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "Paivamaara", DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri, CDate(txtAKPaivamaaraAlku.Text)))
    End If
    If txtAKPaivamaaraLoppu.Text <> "" Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "Paivamaara", DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri, CDate(txtAKPaivamaaraLoppu.Text)))
    End If
    If txtAKSeuraavaYhteyspaivaAlku.Text <> "" Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "SeuraavaYhteydenottoPaivamaara", DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri, CDate(txtAKSeuraavaYhteyspaivaAlku.Text)))
    End If
    If txtAKSeuraavaYhteyspaivaLoppu.Text <> "" Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "SeuraavaYhteydenottoPaivamaara", DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri, CDate(txtAKSeuraavaYhteyspaivaLoppu.Text)))
    End If
    If Pudotusvalikko.HaeValittuArvo(ddAKStatusId).HasValue Then
      hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "StatusId", DTO.Hakuoperaattori.YhtaSuuri, CInt(Pudotusvalikko.HaeValittuArvo(ddAKStatusId))))
    End If
    gvAktiviteetit.DataSource = New BLL.Poiminta().TeeAktiviteettiPoiminta(hakuehdot.ToArray())
    gvAktiviteetit.DataBind()
  End Sub

  Private Sub gvAktiviteetit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAktiviteetit.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim riviIlmanViittauksia = DirectCast(e.Row.DataItem, DTO.Aktiviteetti)
      'viitataan sopimukseen ja tahoon joten halutaan että ne ovat ladattu
      Dim rivi = New BLL.Aktiviteetti(_konteksti).HaeAktiviteetti(riviIlmanViittauksia.Id)
      CType(e.Row.FindControl("hlValitse"), LinkButton).PostBackUrl = String.Format("~/Aktiviteetti/Tiedot.aspx?id={0}&sid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Aktiviteetti/Muokkaa.aspx?id={0}&sid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlValitse"), LinkButton).Text = rivi.Id
      CType(e.Row.FindControl("lblPaivamaara"), Label).Text = Paivaykset.PalautaPaivays(rivi.Paivamaara)
      CType(e.Row.FindControl("lblJatkopaivamaara"), Label).Text = Paivaykset.PalautaPaivays(rivi.SeuraavaYhteydenottoPaivamaara)
      CType(e.Row.FindControl("lblKontaktoija"), Label).Text = Membership.GetUser(rivi.KontaktoijaGuid).UserName
      CType(e.Row.FindControl("hlSopimus"), HyperLink).Text = rivi.Sopimus.Nimi
      CType(e.Row.FindControl("hlSopimus"), HyperLink).NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", rivi.SopimusId)
      If Not rivi.Taho Is Nothing Then
        CType(e.Row.FindControl("hlTaho"), HyperLink).Text = rivi.Taho.Nimi
        CType(e.Row.FindControl("hlTaho"), HyperLink).NavigateUrl = String.Format("~/Taho/SopimusTaho.aspx?id={0}", rivi.TahoId)
      End If
    End If

  End Sub

End Class