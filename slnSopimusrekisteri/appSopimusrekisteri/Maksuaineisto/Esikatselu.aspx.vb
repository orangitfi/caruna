Imports System.Runtime.InteropServices

Public Class MaksuaineistonEsikatselu

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ValitseValilehti()
            HaeMaksuaineisto()

        End If

    End Sub

    Private Sub ValitseValilehti()

        If Request.Params("valinta") <> "" Then
            If Request.Params("valinta") = "Virheelliset" Then
                TabAineisto.ActiveTabIndex = 1
            ElseIf Request.Params("valinta") = "Tarkistettavat" Then
                TabAineisto.ActiveTabIndex = 2
            ElseIf Request.Params("valinta") = "Maksettavat" Then
                TabAineisto.ActiveTabIndex = 3
            End If
        End If
        
    End Sub

    Private Sub HaeMaksuaineisto()

        Dim haku = New BLL.Haku()
        Dim tyypit = haku.HaeKorvaustyypit()
        Dim tyyppi = tyypit.FirstOrDefault((Function(x) x.Nimi = Request.Params("tyyppi")))

        If Not tyyppi Is Nothing Then

            If IsNumeric(tyyppi.ID) Then
                Dim tietokanta = New BLL.Maksuaineisto()
                gwTulokset.DataSource = tietokanta.HaeMaksuaineistot(tyyppi.ID, 2)
                gwTulokset.DataBind()
            Else
                ' TODO: Error
            End If

        End If

    End Sub

    Private Sub gwTulokset_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwTulokset.RowDataBound

    End Sub

    Private Sub btnTeeMaksuaineisto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTeeMaksuaineisto.Click

    End Sub

    Private Sub lbTakaisin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbTakaisin.Click

        Response.Redirect("Maksuaineistot.aspx?tyyppi=" + Request.Params("tyyppi"))

    End Sub

End Class