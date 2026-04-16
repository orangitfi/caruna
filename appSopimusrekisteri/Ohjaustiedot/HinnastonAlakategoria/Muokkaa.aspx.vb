Imports appSopimusrekisteri.DTO

Public Class HinnastonAlakategorianMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.HinnastonAlakategoria()
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_HinnastoAlakategoria)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.HAKPaivitetty)
        lblPaivittaja.Text = muokattava.HAKPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.HAKLuotu)
        lblLuoja.Text = muokattava.HAKLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_HinnastoAlakategoria)

        txtNimi.Text = muokattava.HAKHinnastoAlakategoria

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_HinnastoAlakategoria

        Dim tallennettava = New Entities.hlp_HinnastoAlakategoria()
        tallennettava.HAKHinnastoAlakategoria = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.HinnastonAlakategoria()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.HAKId = Request.Params("id")
                tallennettava = tietokanta.Muokkaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/HinnastonAlakategoria/Tiedot.aspx?id={0}", tallennettava.HAKId))
                End If
            Else
                tallennettava = tietokanta.Lisaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/HinnastonAlakategoria/Tiedot.aspx?id={0}", tallennettava.HAKId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/HinnastonAlakategoria/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/HinnastonAlakategoria/Tiedot.aspx", True)

    End Sub

End Class