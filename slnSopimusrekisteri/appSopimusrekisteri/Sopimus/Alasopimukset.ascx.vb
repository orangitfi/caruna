Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF.Hakuehdot

Public Class Alasopimukset
    Inherits BaseControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            AsetaOikeudet()
            TaytaData()
        End If

    End Sub

    Private Sub AsetaOikeudet()
        btnLisaaAlasopimus.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusMuokkaus)
    End Sub

    Public Sub TaytaData()

        If Me.SopimusId.HasValue Then

            Dim hakuehdot = New SopimusHakuehdot With {
                .IncludePaths = New List(Of String) From {
                    "Sopimustyyppi"
                },
                .PaasopimusId = SopimusId
            }
            Dim sopimukset = Handlers.Sopimukset.HaeSopimukset(hakuehdot).ToList()

            gvAlasopimukset.DataSource = sopimukset
            gvAlasopimukset.DataBind()
            gvAlasopimukset.Visible = True

        Else

            gvAlasopimukset.Visible = False

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

    Private Sub Poista(id As Integer)

        Dim sopimus = Handlers.Sopimukset.LoadEntity(id)

        If sopimus IsNot Nothing Then
            sopimus.PaasopimusId = Nothing
            Handlers.Sopimukset.SaveEntity(sopimus)
        End If

    End Sub

    Protected Sub gvAlasopimukset_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim sopimus = CType(e.Row.DataItem, Sopimusrekisteri.BLL_CF.Sopimus)
            Dim hlPoista = CType(e.Row.FindControl("hlPoista"), LinkButton)
            Dim hlSopimusnumero = CType(e.Row.FindControl("hlSopimusnumero"), HyperLink)

            hlPoista.CommandArgument = sopimus.Id.ToString()
            hlSopimusnumero.NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", sopimus.Id)

        End If

    End Sub

    Protected Sub gvAlasopimukset_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Poista" Then

            Dim id = DataUtils.ParseIntOrNull(e.CommandArgument)

            If id.HasValue Then
                Poista(id.Value)
                TaytaData()
            End If

        End If

    End Sub

    Protected Sub btnLisaaAlasopimus_Click(sender As Object, e As EventArgs)

        Response.Redirect(String.Format("~/Sopimus/Alasopimus.aspx?id={0}", Me.SopimusId?.ToString()))

    End Sub

End Class