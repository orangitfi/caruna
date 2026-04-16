Imports Sopimusrekisteri.DAL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers
Imports KT.Utils

Public Class ListControl
  Inherits System.Web.UI.UserControl

  Public Event ItemDeleted()

  Public Sub New()
    MyBase.New()
  End Sub

  Protected ReadOnly Property BasePage As BasePage2
    Get
      Return CType(Me.Page, BasePage2)
    End Get
  End Property

  Public ReadOnly Property DataContext As KiltaDataContext
    Get
      Return Me.BasePage.DataContext
    End Get
  End Property

  Public ReadOnly Property Handlers As HandlerContext
    Get
      Return Me.BasePage.Handlers
    End Get
  End Property

  Public Property EntityId As Integer
    Set(value As Integer)
      Me.ViewState("entityId") = value
    End Set
    Get
      Return DataUtils.GetIntValue(Me.ViewState("entityId"), 0)
    End Get
  End Property

  Protected Sub RaiseItemDeletedEvent()

    RaiseEvent ItemDeleted()

  End Sub

End Class
