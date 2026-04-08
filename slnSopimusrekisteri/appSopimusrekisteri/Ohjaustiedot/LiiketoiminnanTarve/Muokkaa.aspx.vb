Imports appSopimusrekisteri.DTO

Public Class LiiketoiminnanTarpeenMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.LiiketoiminnanTarve()
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_LiiketoiminnanTarve)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.LTOPaivitetty)
        lblPaivittaja.Text = muokattava.LTOPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.LTOLuotu)
        lblLuoja.Text = muokattava.LTOLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_LiiketoiminnanTarve)

        txtNimi.Text = muokattava.LTOLiiketoiminnanTarve

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_LiiketoiminnanTarve

        Dim tallennettava = New Entities.hlp_LiiketoiminnanTarve()
        tallennettava.LTOLiiketoiminnanTarve = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.LiiketoiminnanTarve()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.LTOId = Request.Params("id")
                tallennettava = tietokanta.Muokkaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/LiiketoiminnanTarve/Tiedot.aspx?id={0}", tallennettava.LTOId))
                End If
            Else
                tallennettava = tietokanta.Lisaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/LiiketoiminnanTarve/Tiedot.aspx?id={0}", tallennettava.LTOId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/LiiketoiminnanTarve/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/LiiketoiminnanTarve/Tiedot.aspx", True)

    End Sub

End Class