Public Class Aktiviteetit
    Inherits BaseControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            TaytaData()
        End If

    End Sub

    Public Sub TaytaData()

        If SopimusId.HasValue Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Aktiviteetti(_konteksti)

            Dim aktiviteetit = tietokanta.HaeSopimuksenAktiviteetit(SopimusId)

            btnLisaaAktiviteetti.PostBackUrl = String.Format("~/Aktiviteetti/Muokkaa.aspx?sid={0}", SopimusId)

            gvAktiviteetit.DataSource = aktiviteetit
            gvAktiviteetit.DataBind()
            gvAktiviteetit.Visible = True

        Else

            gvAktiviteetit.Visible = False

        End If

    End Sub

    Private Sub gvAktiviteetit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAktiviteetit.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
        Dim rivi = DirectCast(e.Row.DataItem, DTO.Aktiviteetti)
        CType(e.Row.FindControl("hlValitse"), LinkButton).PostBackUrl = String.Format("~/Aktiviteetti/Tiedot.aspx?id={0}&sid={1}", rivi.Id, SopimusId)
        CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Aktiviteetti/Muokkaa.aspx?id={0}&sid={1}", rivi.Id, SopimusId)
        CType(e.Row.FindControl("hlValitse"), LinkButton).Text = rivi.Id
        CType(e.Row.FindControl("lblPaivamaara"), Label).Text = Paivaykset.PalautaPaivays(rivi.Paivamaara)
        If rivi.KontaktoijaGuid.HasValue Then
            CType(e.Row.FindControl("lblKontaktoija"), Label).Text = Membership.GetUser(rivi.KontaktoijaGuid.Value).UserName
        Else
            CType(e.Row.FindControl("lblKontaktoija"), Label).Text = "Tuntematon"
        End If
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

End Class