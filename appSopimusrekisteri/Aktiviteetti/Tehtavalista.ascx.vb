Public Class Tehtavalista
  Inherits BaseControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then
      TaytaData()
      hlKaikki.NavigateUrl = "~/Aktiviteetti/Poiminta.aspx"
    End If

  End Sub

  Public Sub TaytaData()

    Dim ID As Guid? = Membership.GetUser(Context.User.Identity.Name).ProviderUserKey
    Dim hakuehdot As List(Of DTO.Hakuehto) = New List(Of DTO.Hakuehto)()

    hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "KontaktoijaGuid", DTO.Hakuoperaattori.YhtaSuuri, ID))
    hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "Paivamaara", DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri, Date.Today))
    hakuehdot.Add(New DTO.Hakuehto(DTO.Hakutyyppi.Aktiviteetti, "StatusId", DTO.Hakuoperaattori.YhtaSuuri, CInt(DTO.Enumeraattorit.AktiviteetinStatus.Avoin)))

    Dim tietokanta As New BLL.Poiminta()

    Dim aktiviteetit As DTO.Aktiviteetti() = tietokanta.TeeAktiviteettiPoiminta(hakuehdot.ToArray())

    gvTehtavalista.DataSource = Aktiviteetit
    gvTehtavalista.DataBind()
    gvTehtavalista.Visible = True

  End Sub

  Private Sub gvAktiviteetit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTehtavalista.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim riviIlmanViittauksia = DirectCast(e.Row.DataItem, DTO.Aktiviteetti)
      'viitataan sopimukseen ja tahoon joten halutaan että ne ovat ladattu
      Dim rivi = New BLL.Aktiviteetti(_konteksti).HaeAktiviteetti(riviIlmanViittauksia.Id)
      CType(e.Row.FindControl("hlValitse"), LinkButton).PostBackUrl = String.Format("~/Aktiviteetti/Tiedot.aspx?id={0}&sid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Aktiviteetti/Muokkaa.aspx?id={0}&sid={1}", rivi.Id, rivi.SopimusId)
      CType(e.Row.FindControl("hlValitse"), LinkButton).Text = rivi.Id
      CType(e.Row.FindControl("lblPaivamaara"), Label).Text = Paivaykset.PalautaPaivays(rivi.Paivamaara)
      CType(e.Row.FindControl("hlSopimus"), HyperLink).NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", rivi.SopimusId)
      CType(e.Row.FindControl("hlSopimus"), HyperLink).Text = rivi.Sopimus.Nimi
      If Not rivi.Taho Is Nothing Then
        If rivi.Taho.TahoTyyppiId = DTO.Enumeraattorit.TahoTyyppi.Henkilo Then
          CType(e.Row.FindControl("hlTaho"), HyperLink).NavigateUrl = String.Format("~/Taho/Henkilo/Tiedot.aspx?id={0}", rivi.TahoId)
        Else
          CType(e.Row.FindControl("hlTaho"), HyperLink).NavigateUrl = String.Format("~/Taho/Organisaatio/Tiedot.aspx?id={0}", rivi.TahoId)
        End If
        CType(e.Row.FindControl("hlTaho"), HyperLink).Text = rivi.Taho.Nimi
      End If
    End If

  End Sub

End Class