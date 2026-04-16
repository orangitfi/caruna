Imports appSopimusrekisteri.DTO

Public Class MaksualueenMuokkaus

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.Maksualue()
                Dim muokattava = tietokanta.HaeMaksualue(Request.Params("id"))
                If Not muokattava Is Nothing Then
                    TaytaLomake(muokattava)
                    TaytaMuokkaustiedot(muokattava)
                Else
                    ' TODO: Virheilmoitus!
                End If
            Else
                ' TODO: Virheilmoitus!
            End If

        End If

    End Sub

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_Maksualue)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.MALPaivitetty)
        lblPaivittaja.Text = muokattava.MALPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.MALLuotu)
        lblLuoja.Text = muokattava.MALLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_Maksualue)

        txtNimi.Text = muokattava.MALMaksualue

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_Maksualue

        Dim tallennettava = New Entities.hlp_Maksualue()
        tallennettava.MALMaksualue = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Maksualue()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.MALId = Request.Params("id")
                tallennettava = tietokanta.MuokkaaMaksualuetta(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Maksualue/Tiedot.aspx?id={0}", tallennettava.MALId))
                End If
            Else
                tallennettava = tietokanta.LisaaMaksualue(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Maksualue/Tiedot.aspx?id={0}", tallennettava.MALId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/Maksualue/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/Maksualue/Tiedot.aspx", True)

    End Sub

End Class