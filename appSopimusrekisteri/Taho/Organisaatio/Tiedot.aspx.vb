Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils

Namespace Taho.Organisaatio

  Public Class Tiedot
    Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Taho)

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      If Not IsPostBack Then

        Me.AlustaSivu()

        Me.AsetaNakyvyydet()

        Me.TaytaLomake()

      End If

    End Sub

    Private Sub AlustaSivu()

    End Sub

    Private Sub AsetaNakyvyydet()

      btnMuokkaa.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasMuokkaus)

    End Sub

    Private Sub TaytaLomake()

      lblPostiosoite.Text = UiHelper.RivitaOsoite(Me.Entity)
      lblPostitusosoite.Text = UiHelper.RivitaOsoite(Me.Entity)

      lblNimi.Text = Me.Entity.Nimi

      If Not String.IsNullOrEmpty(Me.Entity.Ytunnus) Then
        lblNimi.Text &= " " & Me.Entity.Ytunnus
      End If

      Me.FormMapper.FillForm(Me.headerData, Me.Entity, "h")
      Me.FormMapper.FillForm(Me.formData, Me.Entity)

      Me.TaytaKiinteistot()
      Me.TaytaSopimukset(Me.EntityId)

    End Sub

    Private Sub TaytaKiinteistot()

      Kiinteistot1.EntityId = Me.EntityId
      Kiinteistot1.ListaaData(Me.Entity.Kiinteistot)

    End Sub

    Private Sub TaytaSopimukset(organisaatioId As Integer)

      Sopimukset1.TahoId = organisaatioId

    End Sub

    Protected Sub btnMuokkaa_Click(sender As Object, e As EventArgs) Handles btnMuokkaa.Click
      Response.Redirect(String.Format("Muokkaa.aspx?id={0}&sopimusid={1}", Me.EntityId.ToString(), Me.SopimusId.ToString()))
    End Sub

    Protected ReadOnly Property SopimusId As Integer?
      Get

        Return DataUtils.ParseValue(Of Integer?)(Request.Params("sopimusid"))

      End Get
    End Property

  End Class

End Namespace