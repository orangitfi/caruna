Imports appSopimusrekisteri.DTO

Public Class PuustolajinMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNumeric(Request.Params("id")) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.Puustolaji()
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

    Private Sub TaytaMuokkaustiedot(muokattava As Entities.hlp_Puustolaji)

        lblPaivitetty.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.PLAPaivitetty)
        lblPaivittaja.Text = muokattava.PLAPaivittaja
        lblLuotu.Text = Paivaykset.PalautaTasmallinenPaivays(muokattava.PLALuotu)
        lblLuoja.Text = muokattava.PLALuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaLomake(muokattava As Entities.hlp_Puustolaji)

        txtNimi.Text = muokattava.PLAPuustolaji

    End Sub

    Private Function LuoTallennettavaObjekti() As Entities.hlp_Puustolaji

        Dim tallennettava = New Entities.hlp_Puustolaji()
        tallennettava.PLAPuustolaji = txtNimi.Text
        Return tallennettava

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Puustolaji()
            Dim tallennettava = LuoTallennettavaObjekti()

            ' Hae URL:ista muokattavan tiedon tunniste, jonka pohjalta 
            ' päätämme lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                tallennettava.PLAId = Request.Params("id")
                tallennettava = tietokanta.Muokkaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Puustolaji/Tiedot.aspx?id={0}", tallennettava.PLAId))
                End If
            Else
                tallennettava = tietokanta.Lisaa(tallennettava)
                If Not tallennettava Is Nothing Then
                    Response.Redirect(String.Format("~/Ohjaustiedot/Puustolaji/Tiedot.aspx?id={0}", tallennettava.PLAId))
                End If
            End If

        Else
            'TODO: Error message.
        End If
    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Ohjaustiedot/Puustolaji/Tiedot.aspx?id={0}", Request.Params("id")))
        End If

        Response.Redirect("~/Ohjaustiedot/Puustolaji/Tiedot.aspx", True)

    End Sub

End Class