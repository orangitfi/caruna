Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF

Public Class ValitseSopimus
    Inherits BasePage2

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Me.Sopimustyyppi.HasValue Then
                OhjaaSopimussivulle(Me.Sopimustyyppi.Value)
            End If

            TaytaPudotusvalikot()

        End If

    End Sub

    Private Sub TaytaPudotusvalikot()

        WebUtils.DataBindList(ddSopimustyyppi, Me.Handlers.Sopimustyypit.GetAll().Where(Function(x) x.Id <> Sopimustyypit.Sopimuspohja).ToList(), AddressOf UiHelper.LuoListItemSopimustyyppi, AddressOf UiHelper.LuoTyhjaListItem)

        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusLaaja) And Not Roles.IsUserInRole(Konfiguraatio.Roolit.Admin) And Not Roles.IsUserInRole(Konfiguraatio.Roolit.Suostumus) Then
            Dim suostumus As ListItem = ddSopimustyyppi.Items.FindByValue(Sopimustyypit.Suostumus.ToString())

            If Not suostumus Is Nothing Then
                ddSopimustyyppi.Items.Remove(suostumus)
            End If

        End If

        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.MuistioSuullisestaSopimuksesta) Then
            Dim muistio As ListItem = ddSopimustyyppi.Items.FindByValue(Sopimustyypit.MuistioSuullisestaSopimuksesta.ToString())
            If Not muistio Is Nothing Then
                ddSopimustyyppi.Items.Remove(muistio)
            End If
        End If

    End Sub

    Protected Sub OhjaaSopimussivulle(sopimustyyppi As Sopimustyypit)

        Dim strQueryString As String = String.Format("?tyyppi={0}", CInt(sopimustyyppi))

        If Me.YlasopimusId.HasValue Then
            strQueryString &= String.Format("&ylasopimusId={0}", Me.YlasopimusId.Value)
        End If

        If Me.KiinteistoId.HasValue Then
            strQueryString &= String.Format("&kiinteistoId={0}", Me.KiinteistoId.Value)
        End If

        Response.Redirect(String.Format(Hakemistot.HaeSopimusHakemisto(sopimustyyppi) & "Muokkaa.aspx" & strQueryString, CInt(sopimustyyppi)))

    End Sub

    Protected Sub btValitse_Click(sender As Object, e As EventArgs) Handles btValitse.Click

        OhjaaSopimussivulle(DataUtils.ParseEnum(Of Sopimustyypit)(ddSopimustyyppi.SelectedValue))

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If Me.YlasopimusId.HasValue Then
            Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.YlasopimusId.Value))
            Return
        End If

        If Me.KiinteistoId.HasValue Then
            Response.Redirect(String.Format("~/Kiinteisto/Tiedot.aspx?id={0}", Me.KiinteistoId.Value))
            Return
        End If

        Response.Redirect("~/Etusivu.aspx", True)

    End Sub

    Protected ReadOnly Property Sopimustyyppi As Sopimustyypit?
        Get

            If Not String.IsNullOrEmpty(Request.Params("tyyppi")) Then
                Return DataUtils.ParseNullableEnum(Of Sopimustyypit)(Request.Params("tyyppi"))
            End If

            Return Nothing

        End Get
    End Property

    Protected ReadOnly Property YlasopimusId As Integer?
        Get

            Return DataUtils.ParseValue(Of Integer?)(Request.Params("ylasopimusId"))

        End Get
    End Property

    Protected ReadOnly Property KiinteistoId As Integer?
        Get

            Return DataUtils.ParseValue(Of Integer?)(Request.Params("kiinteistoId"))

        End Get
    End Property

End Class