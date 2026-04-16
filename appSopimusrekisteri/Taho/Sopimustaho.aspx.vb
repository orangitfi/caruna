Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils

Namespace Taho

  Public Class Sopimustaho
    Inherits BasePage(Of Sopimusrekisteri.BLL_CF.SopimusTaho)

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      If Not IsPostBack Then

        Me.AlustaSivu()

        If Not Me.IsNewEntity Then

          Me.TaytaLomake()

        End If

      End If

    End Sub

    Private Sub AlustaSivu()

      WebUtils.DataBindList(Of Asiakastyyppi)(AsiakastyyppiId, Me.Handlers.Asiakastyypit.GetAll(), AddressOf UiHelper.LuoListItemAsiakastyyppi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of DFRooli)(DFRooliId, Me.Handlers.DFRoolit.GetAll(), AddressOf UiHelper.LuoListItemDFRooli, AddressOf UiHelper.LuoTyhjaListItem)

    End Sub

    Private Sub TaytaLomake()

      Me.FormMapper.FillForm(Me.formData, Me.Entity)

    End Sub

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

      If Page.IsValid() Then

        Me.Tallenna()

        Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.SopimusId.ToString()))

      End If

    End Sub

    Private Sub Tallenna()

      Me.FormMapper.FillObject(formData, Me.Entity, String.Empty)

      If Me.IsNewEntity Then
        Me.Entity.SopimusId = Me.SopimusId
        Me.Entity.TahoId = Me.TahoId
      End If

      Me.EntityHandler.SaveEntity(Me.Entity)

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.SopimusId.ToString()))

    End Sub

    Protected ReadOnly Property SopimusId As Integer?
      Get

        If Not Me.IsNewEntity Then
          Return Me.Entity.SopimusId
        End If

        If Not String.IsNullOrEmpty(ViewState("sopimusId")) Then
          Return CInt(ViewState("sopimusId"))
        End If

        If IsNumeric(Request.QueryString("sopimusId")) Then
          ViewState("sopimusId") = Request.QueryString("sopimusId")
          Return CInt(ViewState("sopimusId"))
        End If

        Return Nothing
      End Get
    End Property

    Protected ReadOnly Property TahoId As Integer?
      Get

        If Not Me.IsNewEntity Then
          Return Me.Entity.TahoId
        End If

        If Not String.IsNullOrEmpty(ViewState("tahoId")) Then
          Return CInt(ViewState("tahoId"))
        End If

        If IsNumeric(Request.QueryString("tahoId")) Then
          ViewState("tahoId") = Request.QueryString("tahoId")
          Return CInt(ViewState("tahoId"))
        End If

        Return Nothing
      End Get
    End Property

  End Class

End Namespace