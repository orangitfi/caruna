Imports Sopimusrekisteri.DAL_CF.EntityHandlers
Imports Sopimusrekisteri.DAL_CF
Imports Sopimusrekisteri.BLL_CF

Public MustInherit Class BaseHandler
  Implements System.Web.IHttpHandler

  Private _dataContext As KiltaDataContext
  Private _handlers As HandlerContext

  Public Overridable ReadOnly Property IsReusable As Boolean Implements IHttpHandler.IsReusable
    Get
      Return False
    End Get
  End Property

  Public Overridable Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest

    Me.Context = context

  End Sub

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

  Protected Property Context As HttpContext

  Protected Overridable Function CreateDataContext() As KiltaDataContext

    Return New KiltaDataContext(Konfiguraatiot.ConnectionString, New Kayttooikeustiedot(Me.Context.User.Identity.Name))

  End Function

End Class

Public MustInherit Class BaseHandler(Of T As Class)
  Inherits BaseHandler

  Private _entity As T
  Private _entityHandler As EntityHandlerBase(Of T)

  Protected ReadOnly Property Entity As T
    Get
      If Me._entity Is Nothing Then
        Me._entity = Me.LoadEntity()
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

  Protected Overridable ReadOnly Property EntityId As Integer?
    Get
      If IsNumeric(Context.Request.Params("id")) Then
        Return CInt(Context.Request.Params("id"))
      End If

      Return Nothing
    End Get
  End Property

  Protected Overridable Function LoadEntity() As T

    Return Me.EntityHandler.LoadEntity(Me.EntityId)

  End Function

End Class
