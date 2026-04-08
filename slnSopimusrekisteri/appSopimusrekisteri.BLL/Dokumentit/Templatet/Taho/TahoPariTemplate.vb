Public Class TahoPariTemplate
  Inherits TemplateEntityBase(Of Tuple(Of DTO.Taho, DTO.Taho))

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Tuple(Of DTO.Taho, DTO.Taho)) As String

    Return Nothing

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Select Case key
      Case "Item1"
        Return entity.Item1
      Case "Item2"
        Return entity.Item2
    End Select

    Return Nothing

  End Function

  Public Overrides ReadOnly Property SubEntityKeys() As IEnumerable(Of String)
    Get
      Return {"Item1", "Item2"}
    End Get
  End Property

End Class
