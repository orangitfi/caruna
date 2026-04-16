Public Class SiteMaster
    Inherits MasterPage

    Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Dim _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As System.EventArgs)

        ' The code below helps to protect against XSRF attacks
        Dim requestCookie As HttpCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If ((Not requestCookie Is Nothing) AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue)) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie As HttpCookie = New HttpCookie(AntiXsrfTokenKey) With {.HttpOnly = True, .Value = _antiXsrfTokenValue}
            If (FormsAuthentication.RequireSSL And Request.IsSecureConnection) Then
                responseCookie.Secure = True
            End If
            Response.Cookies.Set(responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Private Sub master_Page_PreLoad(sender As Object, e As System.EventArgs)
        If (Not IsPostBack) Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, String.Empty)
        Else
            ' Validate the Anti-XSRF token
            If (Not DirectCast(ViewState(AntiXsrfTokenKey), String) = _antiXsrfTokenValue _
                Or Not DirectCast(ViewState(AntiXsrfUserNameKey), String) = If(Context.User.Identity.Name, String.Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Overrides Sub OnPreRender(e As EventArgs)

        lblKantaSelko.Text = Konfiguraatiot.Ymparisto?.ToUpper()
        lblKanta.Text = Konfiguraatiot.YmparistoKanta
        pnlTestiymparisto.Visible = Konfiguraatiot.TestiYmparisto

        'lblUsername.Text = Context.User.Identity.Name
        lblDate.Text = Now.ToShortDateString()

        Dim tblRow As New HtmlTableRow()

        'Etusivu
        Dim tblCellEtusivu As HtmlTableCell = CreateTableMenuItem("Etusivu", "~/Etusivu.aspx")
        tblRow.Cells.Add(tblCellEtusivu)


        If Roles.IsUserInRole(Konfiguraatio.Roolit.Poiminta) Then
            Dim tblCellMaksuajot As HtmlTableCell = CreateTableMenuItem("Poiminta", "~/Poiminta/Poimintajoukko.aspx")
            tblRow.Cells.Add(tblCellMaksuajot)
        End If

        'Raportit
        If Roles.IsUserInRole(Konfiguraatio.Roolit.Poiminta) OrElse Roles.IsUserInRole(Konfiguraatio.Roolit.IFRS) Then
            Dim tblCellRaportit As HtmlTableCell = CreateTableMenuItem("Raportit", "~/Raportit/Raportit.aspx")
            tblRow.Cells.Add(tblCellRaportit)
        End If

        'Maksuajot
        If Roles.IsUserInRole(Konfiguraatio.Roolit.Maksut) Then
            Dim tblCellMaksuajot As HtmlTableCell = CreateTableMenuItem("Maksuajot", "~/Maksuaineisto/Maksuajot.aspx")
            tblRow.Cells.Add(tblCellMaksuajot)
        End If

        'Ohjaustiedot
        If Roles.IsUserInRole(Konfiguraatio.Roolit.Ohjaustiedot) Then
            Dim tblCellOhjaustiedot As HtmlTableCell = CreateTableMenuItem("Ohjaustiedot", "~/Ohjaustiedot/Ohjaustiedot.aspx")
            tblRow.Cells.Add(tblCellOhjaustiedot)
        End If

        'Käyttäjien ylläpito
        If Roles.IsUserInRole(Konfiguraatio.Roolit.KayttajienHallinta) Then
            Dim tblCellYllapito As HtmlTableCell = CreateTableMenuItem("Käyttäjien hallinta", "~/Yllapito/KayttajaHallinta.aspx")
            tblRow.Cells.Add(tblCellYllapito)
        End If

        If Not String.IsNullOrWhiteSpace(Context.User.Identity.IsAuthenticated) Then
            'Logout
            Dim tblCellLogout As HtmlTableCell = CreateTableMenuItem("Kirjaudu ulos", "~/Kayttaja/Uloskirjautuminen.aspx")
            tblRow.Cells.Add(tblCellLogout)
        End If

        tblMenu.Rows.Add(tblRow)

        MyBase.OnPreRender(e)
    End Sub

    Public Function CreateTableMenuItem(ByVal name As String, ByVal url As String) As HtmlTableCell
        Dim tblCell As New HtmlTableCell()

        Dim hlLink As New HyperLink()
        hlLink.Text = name
        hlLink.NavigateUrl = url
        tblCell.Controls.Add(hlLink)

        Return tblCell
    End Function

    Public Function CreateEmptyTableMenuItem() As HtmlTableCell
        Dim tblCell As New HtmlTableCell()

        Return tblCell
    End Function

End Class