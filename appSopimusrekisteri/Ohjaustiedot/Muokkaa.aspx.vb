Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers

Namespace Ohjaustiedot

  Public Class Muokkaa
    Inherits BasePage(Of IOhjaustieto)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      If Not IsPostBack Then

        Me.AsetaTyyppi(Me.Request.QueryString("tyyppi"))

        Me.AlustaSivu()

        If Not Me.IsNewEntity Then

          Me.TaytaLomake()

        End If

      End If

    End Sub

    Private Sub AlustaSivu()

      If Me.Tyyppi.HasValue Then
        Me.lblOtsikko.Text = Me.OhjaustietoHandler.HaeOhjaustiedonNimi(Me.Tyyppi.Value)
      End If

    End Sub

    Private Sub TaytaLomake()

      Me.FormMapper.FillForm(Me.formData, Me.Entity)

    End Sub

    Private Sub Tallenna()

      Me.FormMapper.FillObject(formData, Me.Entity, String.Empty)

      If Me.Tyyppi.HasValue Then
        Me.OhjaustietoHandler.SaveEntity(Me.Entity, Me.Tyyppi.Value)
      End If

    End Sub

    Protected Overrides Function LoadEntity() As IOhjaustieto

      If Me.Tyyppi.HasValue Then
        Return Me.OhjaustietoHandler.LoadEntity(Me.EntityId, Me.Tyyppi.Value)
      End If

      Return MyBase.LoadEntity()

    End Function

    Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click

      If Me.IsValid Then

        Me.Tallenna()

        Response.Redirect("Tiedot.aspx?tyyppi=" & Me.Tyyppi.ToString())

      End If

    End Sub

    Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

      Response.Redirect("Tiedot.aspx?tyyppi=" & Me.Tyyppi.ToString())

    End Sub

    Protected Overrides Function CreateEntity() As IOhjaustieto

      If Me.Tyyppi.HasValue Then
        Return Me.OhjaustietoHandler.GetNewEntity(Me.Tyyppi)
      End If

      Return MyBase.CreateEntity()

    End Function

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