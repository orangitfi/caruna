Public Class TulostaKorvauslaskelmanTiedot

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      Dim id As String = Request.Params("id")
      Dim sopimusId As String = Request.Params("sopimusid")

      If IsNumeric(id) Then

        hlTakaisin.NavigateUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", id, sopimusId)

        Dim tietokanta = New BLL.Korvauslaskelma(_konteksti)
        Dim korvauslaskelma = tietokanta.HaeKorvauslaskelmaDTO(id)
        If Not korvauslaskelma Is Nothing Then
          TaytaLomake(korvauslaskelma)
          TaytaRivit(korvauslaskelma)
        End If

      Else

        hlTakaisin.NavigateUrl = "~/Etusivu.aspx"

      End If

    End If

  End Sub

  Private Sub TaytaLomake(korvauslaskelma As DTO.Korvauslaskelma)

    If Not korvauslaskelma.Sopimus Is Nothing Then

      litKorvauslaskelmanTiedot.Text = String.Format("{0} / Korvauslaskelma / {1}", korvauslaskelma.Sopimus.Sopimustyyppi, korvauslaskelma.SopimusId.ToString())

      Dim kiinteistot As New BLL.Kiinteisto(_konteksti)

      Dim sopimuksenKiinteistot As List(Of DTO.Kiinteisto) = kiinteistot.HaeSopimuksenKiinteistot(korvauslaskelma.SopimusId)

      rptKiinteistot.DataSource = sopimuksenKiinteistot
      rptKiinteistot.DataBind()

      litLaatija.Text = korvauslaskelma.Sopimus.SopimuksenLaatija

    End If

    If Not korvauslaskelma.Saaja Is Nothing Then

      litSaaja.Text = String.Format("{0} {1}, {2}", korvauslaskelma.Saaja.Etunimi, korvauslaskelma.Saaja.Sukunimi, korvauslaskelma.Saaja.Puhelin).Trim()

    End If

  End Sub

  Private Sub TaytaRivit(korvauslaskelma As DTO.Korvauslaskelma)

    repKorvauslaskelmanRivit.DataSource = korvauslaskelma.Rivit
    repKorvauslaskelmanRivit.DataBind()

    litPaivays.Text = Paivaykset.PalautaPaivays(DateTime.Now)

    litSumma.Text = Luvut.EsitaNullableDecimal(korvauslaskelma.Summa)

  End Sub

  Private Sub repKorvauslaskelmanRivit_ItemDataBound(sender As Object, e As Web.UI.WebControls.RepeaterItemEventArgs) Handles repKorvauslaskelmanRivit.ItemDataBound

    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

      Dim rivi As DTO.KorvauslaskelmanRivi = CType(e.Item.DataItem, DTO.KorvauslaskelmanRivi)

      If rivi.KorvausYksikonTyyppi = DTO.Enumeraattorit.KorvausyksikonTyyppi.Prosentti Then
        CType(e.Item.FindControl("litKorvausyksikko"), Literal).Text = String.Empty
        CType(e.Item.FindControl("litKorvausyksikonKuvaus"), Literal).Text = rivi.Korvausyksikko
      Else
        CType(e.Item.FindControl("litKorvausyksikko"), Literal).Text = rivi.Korvausyksikko
        CType(e.Item.FindControl("litKorvausyksikonKuvaus"), Literal).Text = rivi.KorvausyksikonKuvaus
      End If

    End If

  End Sub

End Class