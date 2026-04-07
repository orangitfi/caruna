Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF

Public Class KorkoprosentinMuokkaus
    Inherits BasePage(Of Korkoprosentti)

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

        Response.Redirect("~/Ohjaustiedot/Korkoprosentti/Tiedot.aspx", True)

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

    Protected Sub cusVuodet_ServerValidate(source As Object, args As ServerValidateEventArgs)

        Dim vuosi = DataUtils.ParseIntOrNull(Vuodet.Text)

        If vuosi.HasValue Then

            args.IsValid = Not DataContext.Korkoprosentit.Any(Function(x) x.Vuodet = vuosi.Value AndAlso x.Id <> EntityId)

        End If

    End Sub

    Protected Sub cusProsentti_ServerValidate(source As Object, args As ServerValidateEventArgs)

        Dim luku = DataUtils.ParseDecimal(Prosentti.Text, 0)

        args.IsValid = luku >= 0 AndAlso luku <= 100

    End Sub


End Class