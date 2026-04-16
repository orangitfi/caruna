Imports appSopimusrekisteri.DTO

Public Class YksikonMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.Yksikko()
                Dim muokattava = tietokanta.HaeYksikko(Request.Params("id"))
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_Yksikko)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.YKSPaivitetty)
        lblPaivittaja.Text = muokattava.YKSPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.YKSLuotu)
        lblLuoja.Text = muokattava.YKSLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_Yksikko)

        txtNimi.Text = muokattava.YKSKorvausyksikko

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_Yksikko

        Dim tallennettava = New Entities.hlp_Yksikko()
        tallennettava.YKSKorvausyksikko = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Yksikko()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.YKSId = Request.Params("id")
                tallennettava = tietokanta.MuokkaaYksikkoa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Tunnisteyksikko/Tiedot.aspx?id={0}", tallennettava.YKSId))
                End If
            Else
                tallennettava = tietokanta.LisaaYksikko(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Tunnisteyksikko/Tiedot.aspx?id={0}", tallennettava.YKSId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/Tunnisteyksikko/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/Tunnisteyksikko/Tiedot.aspx", True)

    End Sub

End Class