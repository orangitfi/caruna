Public Class AktiviteetinTiedot
  Inherits BasePage

  Private _id As Integer?

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Aktiviteetit) Then
      Response.Redirect("etusivu.aspx")
      Return
    End If

    If Not IsPostBack Then
      If IsNumeric(Request.Params("id")) Then

        _id = CInt(Request.Params("id"))

        Dim tietokanta = New appSopimusrekisteri.BLL.Aktiviteetti(_konteksti)

        Dim aktiviteetti = tietokanta.HaeAktiviteetti(_id.Value)
        If Not aktiviteetti Is Nothing Then
          TaytaPerusTiedot(aktiviteetti)
          btnMuokkaa.PostBackUrl = String.Format("Muokkaa.aspx?id={0}&sid={1}", _id.Value, aktiviteetti.SopimusId)
        Else
          ' TODO: Virheilmoitus!
        End If
      Else
        ' TODO: Virheilmoitus!
      End If

      If IsNumeric(Request.Params("sid")) Then
        btnTakaisin.Visible = True
        btnTakaisin.PostBackUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Request.Params("sid"))
      End If

    End If
  End Sub

  Private Sub TaytaPerusTiedot(ByVal aktiviteetti As DTO.Aktiviteetti)
    lblAKTahoId.Text = If(IsNothing(aktiviteetti.Taho), "", aktiviteetti.Taho.Nimi)
    lblAKSopimusId.Text = If(IsNothing(aktiviteetti.Sopimus), "", aktiviteetti.Sopimus.Nimi)
    lblAKKontaktoijaId.Text = If(IsNothing(aktiviteetti.KontaktoijaGuid), "", Membership.GetUser(aktiviteetti.KontaktoijaGuid).UserName)
    lblAKPaivamaara.Text = If(IsNothing(aktiviteetti.Paivamaara), "", aktiviteetti.Paivamaara)
    lblAKSeuraavaYhteyspaiva.Text = If(IsNothing(aktiviteetti.SeuraavaYhteydenottoPaivamaara), "", aktiviteetti.SeuraavaYhteydenottoPaivamaara)
    lblAKAktiviteetinLajiId.Text = If(IsNothing(aktiviteetti.Laji), "", aktiviteetti.Laji)
    lblAKKuvaus.Text = If(IsNothing(aktiviteetti.Kuvaus), "", aktiviteetti.Kuvaus)
    lblAKStatusId.Text = If(IsNothing(aktiviteetti.Status), "", aktiviteetti.Status)
    lblAKYhteystapaId.Text = If(IsNothing(aktiviteetti.Yhteydenottotapa), "", aktiviteetti.Yhteydenottotapa)
  End Sub

End Class