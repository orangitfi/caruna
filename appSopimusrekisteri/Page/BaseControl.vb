Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers

Public Class BaseControl
  Inherits System.Web.UI.UserControl

  Friend _konteksti As New DTO.DataKonteksti(Context.User.Identity.Name)
  Private _dataContext As KiltaDataContext
  Private _handlerContext As HandlerContext

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

      If Me._handlerContext Is Nothing Then
        Me._handlerContext = New HandlerContext(Me.DataContext)
      End If

      Return Me._handlerContext
    End Get

  End Property

  Protected Overridable Function CreateDataContext() As KiltaDataContext

    Return New KiltaDataContext(Konfiguraatiot.ConnectionString, New Kayttooikeustiedot(Context.User.Identity.Name))

  End Function

End Class
