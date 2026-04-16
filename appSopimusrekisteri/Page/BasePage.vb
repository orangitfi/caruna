Imports Sopimusrekisteri.DAL_CF.EntityHandlers
Imports Sopimusrekisteri.DAL_CF
Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils.Mapping

Public Class BasePage
  Inherits System.Web.UI.Page

  Friend _konteksti As New DTO.DataKonteksti(Context.User.Identity.Name)

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    MaintainScrollPositionOnPostBack = True

  End Sub

End Class

Public Class BasePage2
  Inherits System.Web.UI.Page

  Private _dataContext As KiltaDataContext
  Private _handlers As HandlerContext

  Protected Friend ReadOnly Property DataContext As KiltaDataContext
    Get

      If Me._dataContext Is Nothing Then
        Me._dataContext = Me.CreateDataContext()
      End If

      Return Me._dataContext
    End Get

  End Property

  Protected Friend ReadOnly Property Handlers As HandlerContext
    Get

      If Me._handlers Is Nothing Then
        Me._handlers = New HandlerContext(Me.DataContext)
      End If

      Return Me._handlers

    End Get
  End Property

  Protected Overridable Function CreateDataContext() As KiltaDataContext

    Return New KiltaDataContext(Konfiguraatiot.ConnectionString, New Kayttooikeustiedot(Context.User.Identity.Name))

  End Function

End Class

Public MustInherit Class BasePage(Of T As Class)
  Inherits BasePage2

  Private _entity As T
  Private _entityHandler As EntityHandlerBase(Of T)
  Private _formMapper As FormMapper

  Protected ReadOnly Property FormMapper As FormMapper
    Get
      If Me._formMapper Is Nothing Then
        Me._formMapper = Me.GetFormMapper()
      End If

      Return Me._formMapper
    End Get
  End Property

  Protected Overridable Function GetFormMapper() As FormMapper
    Return Me.CreateDefaultFormMapper()
  End Function

  Protected Function CreateDefaultFormMapper() As FormMapper

    Dim mapper As New FormMapper()
    mapper.AddTypeFormatter("DateTime", AddressOf Paivaykset.PalautaPaivays)
    mapper.AddTypeFormatter("Decimal", AddressOf Luvut.EsitaDecimal)
    mapper.AddTypeFormatter("Boolean", AddressOf Muuttujat.EsitaBoolean)
    mapper.UseEnumIntValue = False

    mapper.AddTypeSetter(GetType(HyperLink), "Text")
    mapper.AddTypeSetter(GetType(Sopimusrekisteri.Controls.DateInput), "DateValue")

    Return mapper

  End Function

  Protected ReadOnly Property Entity As T
    Get
      If Me._entity Is Nothing Then
        If Me.IsNewEntity Then
          Me._entity = Me.CreateEntity()
        Else
          Me._entity = Me.LoadEntity()
        End If
      End If

      Return Me._entity
    End Get
  End Property

  Protected ReadOnly Property EntityHandler As EntityHandlerBase(Of T)
    Get
      If Me._entityHandler Is Nothing Then
        Me._entityHandler = Me.CreateEntityHandler()
      End If

      Return Me._entityHandler
    End Get
  End Property

  Protected Overridable Function CreateEntityHandler() As EntityHandlerBase(Of T)
    Return Me.DataContext.GetEntityHandler(Of T)()
  End Function

  Protected Overridable ReadOnly Property IsNewEntity
    Get
      Return Not Me.EntityId.HasValue
    End Get
  End Property

  Protected Overridable ReadOnly Property EntityId As Integer?
    Get

      If Not String.IsNullOrEmpty(ViewState("id")) Then
        Return CInt(ViewState("id"))
      End If

      If IsNumeric(Request.QueryString("id")) Then
        ViewState("id") = Request.QueryString("id")
        Return CInt(ViewState("id"))
      End If

      Return Nothing
    End Get
  End Property

  Protected Overridable Function LoadEntity() As T

    Return Me.EntityHandler.LoadEntity(Me.EntityId)

  End Function

  Protected Overridable Function CreateEntity() As T
    Return Activator.CreateInstance(Of T)()
  End Function

End Class
