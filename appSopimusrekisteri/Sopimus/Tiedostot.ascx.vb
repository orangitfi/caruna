Public Class Tiedostot1
    Inherits BaseControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            TaytaData()
            AsetaOikeudet()
        End If

    End Sub

    Private Sub AsetaOikeudet()
        btnLisaaTiedosto.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TiedostoMuokkaus)
    End Sub

    Public Sub TaytaData()

        If Me.SopimusId.HasValue Then

            Dim tietokanta = New BLL.Tiedosto(_konteksti)

            Dim tiedostot = tietokanta.HaeSopimuksenTiedostot(Me.SopimusId)

            gvTiedostot.DataSource = tiedostot
            gvTiedostot.DataBind()
            gvTiedostot.Visible = True

        Else

            gvTiedostot.Visible = False

        End If

    End Sub

    Public Property SopimusId As Integer?
        Set(value As Integer?)
            hdnSopimusId.Value = value
        End Set
        Get
            If IsNumeric(hdnSopimusId.Value) Then
                Return CInt(hdnSopimusId.Value)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub gvTiedostot_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTiedostot.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim rivi = DirectCast(e.Row.DataItem, DTO.Tiedosto)
            Dim hlTiedosto = CType(e.Row.FindControl("hlTiedosto"), HyperLink)
            Dim hlVanha = CType(e.Row.FindControl("hlVanha"), HyperLink)
            CType(e.Row.FindControl("lbPoista"), LinkButton).CommandArgument = rivi.Id
            CType(e.Row.FindControl("lbPoista"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TiedostoMuokkaus)
            CType(e.Row.FindControl("lbMuokkaa"), LinkButton).CommandArgument = rivi.Id
            CType(e.Row.FindControl("lbMuokkaa"), LinkButton).Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.TiedostoMuokkaus)
            hlTiedosto.NavigateUrl = "~/Tiedosto/Tiedosto.ashx?id=" & rivi.Id

            If rivi.Sijainti = DTO.Enumeraattorit.TiedostonSijainti.MFiles AndAlso Not String.IsNullOrEmpty(rivi.Url) Then
                hlVanha.Visible = Konfiguraatiot.NaytaVanhaSharepointLinkki
                hlVanha.NavigateUrl = "~/Tiedosto/Tiedosto.ashx?id=" & rivi.Id & "&sharepoint=True"
            End If

        End If

    End Sub

    Private Sub gvTiedostot_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvTiedostot.RowEditing

        Dim rivi = gvTiedostot.Rows(e.NewEditIndex)

        Dim id = CType(rivi.FindControl("lbMuokkaa"), LinkButton).CommandArgument

        Response.Redirect(String.Format("~/Tiedosto/Muokkaa.aspx?id={0}", id))

    End Sub

    Private Sub gvTiedostot_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvTiedostot.RowDeleting

        Dim poistettavaRivi = gvTiedostot.Rows(e.RowIndex)

        Dim poistettavanId = CType(poistettavaRivi.FindControl("lbPoista"), LinkButton).CommandArgument

        Dim tietokanta = New BLL.Tiedosto(_konteksti)

        tietokanta.PoistaTiedosto(poistettavanId)

        TaytaData()

    End Sub

    Protected Sub btnLisaaTiedosto_Click(sender As Object, e As EventArgs)

        Response.Redirect(String.Format("~/Tiedosto/Muokkaa.aspx?sopimusid={0}", Me.SopimusId))

    End Sub

End Class