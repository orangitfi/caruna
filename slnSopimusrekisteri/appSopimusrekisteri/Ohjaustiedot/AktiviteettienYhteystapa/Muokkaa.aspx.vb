Imports appSopimusrekisteri.DTO

Public Class AktiviteetinYhteystavanMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.AktiviteettiYhteystapa()
                Dim muokattava = tietokanta.Hae(Request.Params("id"))
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_AktiviteettiYhteystapa)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.YTAPaivitetty)
        lblPaivittaja.Text = muokattava.YTAPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.YTALuotu)
        lblLuoja.Text = muokattava.YTALuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_AktiviteettiYhteystapa)

        txtNimi.Text = muokattava.YTAYhteystapa

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_AktiviteettiYhteystapa

        Dim tallennettava = New Entities.hlp_AktiviteettiYhteystapa()
        tallennettava.YTAYhteystapa = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.AktiviteettiYhteystapa()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.YTAId = Request.Params("id")
                tallennettava = tietokanta.Muokkaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/AktiviteettienYhteystapa/Tiedot.aspx?id={0}", tallennettava.YTAId))
                End If
            Else
                tallennettava = tietokanta.Lisaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/AktiviteettienYhteystapa/Tiedot.aspx?id={0}", tallennettava.YTAId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/AktiviteettienYhteystapa/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/AktiviteettienYhteystapa/Tiedot.aspx", True)

    End Sub

End Class