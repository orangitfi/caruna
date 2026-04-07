Public Class Infopallura
  Inherits BaseControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Public Property Kentta As String
  Public Property Teksti As String
    Set(value As String)
      imgInfo.ToolTip = value
    End Set
    Get
      Return imgInfo.ToolTip
    End Get
  End Property

End Class