Imports appSopimusrekisteri.DTO

Public Class TunnisteyksikonTyypinMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.TunnisteyksikonTyyppi()
                Dim muokattava = tietokanta.HaeTunnisteyksikonTyyppi(Request.Params("id"))
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_TunnisteyksikkoTyyppi)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.TTYPaivitetty)
        lblPaivittaja.Text = muokattava.TTYPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.TTYLuotu)
        lblLuoja.Text = muokattava.TTYLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_TunnisteyksikkoTyyppi)

        txtNimi.Text = muokattava.TTYTunnisteYksikkoTyyppi

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_TunnisteyksikkoTyyppi

        Dim tallennettava = New Entities.hlp_TunnisteyksikkoTyyppi()
        tallennettava.TTYTunnisteYksikkoTyyppi = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.TunnisteyksikonTyyppi()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.TTYId = Request.Params("id")
                tallennettava = tietokanta.MuokkaaTunnisteyksikonTyyppiä(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/TunnisteyksikonTyyppi/Tiedot.aspx?id={0}", tallennettava.TTYId))
                End If
            Else
                tallennettava = tietokanta.LisaaTunnisteyksikonTyyppi(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/TunnisteyksikonTyyppi/Tiedot.aspx?id={0}", tallennettava.TTYId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/TunnisteyksikonTyyppi/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/TunnisteyksikonTyyppi/Tiedot.aspx", True)

    End Sub

End Class