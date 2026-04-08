Imports Sopimusrekisteri.BLL_CF

Public Class VuokratyypinMuokkaus
    Inherits BasePage(Of Vuokratyyppi)

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            AlustaSivu()

            If Not IsNewEntity Then

                TaytaLomake()

            End If

        End If

    End Sub

    Private Sub AlustaSivu()

    End Sub

    Private Sub TaytaLomake()

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(Entity.Paivitetty)
        lblPaivittaja.Text = Entity.Paivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(Entity.Luotu)
        lblLuoja.Text = Entity.Luoja

        FormMapper.FillForm(form, Entity, String.Empty)

    End Sub

    Private Sub Tallenna()

        FormMapper.FillObject(form, Entity, String.Empty)

        EntityHandler.SaveEntity(Entity)

    End Sub

    Private Sub Palaa()

        Response.Redirect("~/Ohjaustiedot/Vuokratyyppi/Tiedot.aspx", True)

    End Sub

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Tallenna()
            Palaa()

        End If

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        Palaa()

    End Sub


End Class