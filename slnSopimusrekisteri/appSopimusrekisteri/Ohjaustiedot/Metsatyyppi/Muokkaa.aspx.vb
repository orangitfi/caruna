Imports appSopimusrekisteri.DTO

Public Class MetsatyypinMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.Metsatyyppi()
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_Metsatyyppi)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.MTYPaivitetty)
        lblPaivittaja.Text = muokattava.MTYPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.MTYLuotu)
        lblLuoja.Text = muokattava.MTYLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_Metsatyyppi)

        txtNimi.Text = muokattava.MTYMetsatyyppi

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_Metsatyyppi

        Dim tallennettava = New Entities.hlp_Metsatyyppi()
        tallennettava.MTYMetsatyyppi = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Metsatyyppi()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.MTYId = Request.Params("id")
                tallennettava = tietokanta.Muokkaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Metsatyyppi/Tiedot.aspx?id={0}", tallennettava.MTYId))
                End If
            Else
                tallennettava = tietokanta.Lisaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Metsatyyppi/Tiedot.aspx?id={0}", tallennettava.MTYId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/Metsatyyppi/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/Metsatyyppi/Tiedot.aspx", True)

    End Sub

End Class