Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers

Namespace Ohjaustiedot

  Public Class Tiedot
    Inherits BasePage(Of IOhjaustieto)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      If Not IsPostBack Then

        Me.AsetaTyyppi(Me.Request.QueryString("tyyppi"))

        Me.AlustaSivu()

        Me.TaytaLomake()

      End If

    End Sub

    Private Sub AlustaSivu()

      If Me.Tyyppi.HasValue Then
        Me.lblOtsikko.Text = Me.OhjaustietoHandler.HaeOhjaustiedonNimi(Me.Tyyppi.Value)
      End If

      Me.btnLisaa.PostBackUrl = "Muokkaa.aspx?tyyppi=" & Me.Tyyppi.ToString()

    End Sub

    Private Sub TaytaLomake()

      If Me.Tyyppi.HasValue Then

        Dim ohjaustiedot As IEnumerable(Of IOhjaustieto) = Me.OhjaustietoHandler.GetAllEntities(Me.Tyyppi)

        gvData.DataSource = ohjaustiedot.ToArray()
        gvData.DataBind()

      End If

    End Sub

    Private Sub gvData_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvData.RowDataBound

      If e.Row.RowType = DataControlRowType.DataRow Then

        CType(e.Row.FindControl("hlMuokkaa"), HyperLink).NavigateUrl = String.Format("Muokkaa.aspx?id={0}&tyyppi={1}", gvData.DataKeys(e.Row.DataItemIndex).Value, Me.Tyyppi.ToString())

      End If

    End Sub

    Private Sub gvData_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvData.RowDeleting

      Dim id As Integer = CInt(gvData.DataKeys(e.RowIndex).Value)

      If Me.OhjaustietoHandler.DeleteEntity(id, Me.Tyyppi.Value) Then
        Me.TaytaLomake()
      Else
        JavascriptAvustaja.LisaaAlert(Me, "Ohjaustietoa ei voitu poistaa, koska se on käytössä.")
      End If

    End Sub

    Private ReadOnly Property OhjaustietoHandler As OhjaustietoHandler
      Get

        Return CType(Me.EntityHandler, OhjaustietoHandler)

      End Get
    End Property

    Private Sub AsetaTyyppi(tyyppi As String)

      If Not tyyppi Is Nothing AndAlso [Enum].IsDefined(GetType(Sopimusrekisteri.BLL_CF.Ohjaustiedot), tyyppi) Then

        Me.Tyyppi = [Enum].Parse(GetType(Sopimusrekisteri.BLL_CF.Ohjaustiedot), tyyppi)

      End If

    End Sub

    Private Property Tyyppi As Sopimusrekisteri.BLL_CF.Ohjaustiedot?
      Set(value As Sopimusrekisteri.BLL_CF.Ohjaustiedot?)
        Me.hdnTyyppi.Value = value.ToString()
      End Set
      Get

        If [Enum].IsDefined(GetType(Sopimusrekisteri.BLL_CF.Ohjaustiedot), Me.hdnTyyppi.Value) Then

          Return [Enum].Parse(GetType(Sopimusrekisteri.BLL_CF.Ohjaustiedot), Me.hdnTyyppi.Value)

        End If

        Return Nothing
      End Get
    End Property

  End Class

End Namespace