Imports appSopimusrekisteri.DTO

Public Class SopimuksenEhtoversionMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.SopimuksenEhtoversio()
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_SopimuksenEhtoversio)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.SEHPaivitetty)
        lblPaivittaja.Text = muokattava.SEHPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.SEHLuotu)
        lblLuoja.Text = muokattava.SEHLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_SopimuksenEhtoversio)

        txtNimi.Text = muokattava.SEHSopimuksenEhtoversio

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_SopimuksenEhtoversio

        Dim tallennettava = New Entities.hlp_SopimuksenEhtoversio()
        tallennettava.SEHSopimuksenEhtoversio = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.SopimuksenEhtoversio()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.SEHId = Request.Params("id")
                tallennettava = tietokanta.Muokkaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/SopimuksenEhtoversio/Tiedot.aspx?id={0}", tallennettava.SEHId))
                End If
            Else
                tallennettava = tietokanta.Lisaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/SopimuksenEhtoversio/Tiedot.aspx?id={0}", tallennettava.SEHId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/SopimuksenEhtoversio/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/SopimuksenEhtoversio/Tiedot.aspx", True)

    End Sub

End Class