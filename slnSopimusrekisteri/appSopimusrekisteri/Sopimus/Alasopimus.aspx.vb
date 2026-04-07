Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF

Public Class HaeAlasopimus
    Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Sopimus)

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusMuokkaus) Then
            Response.Redirect("~/Etusivu.aspx")
            Return
        End If

        If Not IsPostBack Then
            AlustaSivu()
        End If

    End Sub

    Private Sub AlustaSivu()
        lblSopimusnumero.Text = EntityId?.ToString()
    End Sub

    Private Function MuodostaHakuehdot() As Hakuehdot.SopimusHakuehdot

        Return New Hakuehdot.SopimusHakuehdot With {
            .IncludePaths = New List(Of String) From {
                "Sopimustyyppi"
            },
            .Sopimusnumero = DataUtils.ParseIntOrNull(cSopimusnumero.Text),
            .Paasopimus = False
        }

    End Function

    Private Sub Hae()
        Dim hakuehdot = MuodostaHakuehdot()
        Dim hakutulos = Handlers.Sopimukset.HaeSopimukset(hakuehdot).ToList()

        lblTiedot.Text = hakutulos.Count.ToString() & " kpl"

        gvHakutulos.DataSource = hakutulos
        gvHakutulos.DataBind()
    End Sub

    Private Sub Valitse(id As Integer)

        Dim sopimus = Handlers.Sopimukset.LoadEntity(id)

        If sopimus IsNot Nothing Then
            sopimus.PaasopimusId = EntityId
            Handlers.Sopimukset.SaveEntity(sopimus)
        End If

    End Sub

    Private Sub Palaa()

        Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.EntityId.ToString()))

    End Sub

    Protected Sub btnUusiSopimus_Click(sender As Object, e As EventArgs)

        Response.Redirect(String.Format("~/Sopimus/Valitse.aspx?ylaSopimusId={0}", Me.EntityId.ToString()))

    End Sub

    Protected Sub btnHae_Click(sender As Object, e As EventArgs)
        Page.Validate()

        If Page.IsValid Then
            Hae()
        End If
    End Sub

    Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs)

        Palaa()

    End Sub

    Protected Sub gvHakutulos_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Valitse" Then

            Dim id = DataUtils.ParseIntOrNull(e.CommandArgument)

            If id.HasValue Then
                Valitse(id.Value)
                Palaa()
            End If

        End If

    End Sub

    Protected Sub gvHakutulos_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim sopimus = CType(e.Row.DataItem, Sopimusrekisteri.BLL_CF.Sopimus)
            Dim hlValitse = CType(e.Row.FindControl("hlValitse"), LinkButton)

            hlValitse.CommandArgument = sopimus.Id.ToString()

        End If

    End Sub

End Class