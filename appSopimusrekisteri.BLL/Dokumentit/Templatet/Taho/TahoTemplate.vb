Public Class TahoTemplate
  Inherits TemplateEntityBase(Of DTO.Taho)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As DTO.Taho) As String

    Select Case key
      Case "Nimi"
        Return If(String.IsNullOrEmpty(entity.Nimi), String.Empty, entity.Nimi)
      Case "Tilinumero"
        Return If(String.IsNullOrEmpty(entity.Tilinumero), String.Empty, entity.Tilinumero)
      Case "Osoite"
        Return entity.Osoite & " " & entity.Postinumero & " " & entity.Postitoimipaikka
    End Select

    Return Nothing

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Return Nothing

  End Function

  Public Overrides ReadOnly Property SubEntityKeys() As IEnumerable(Of String)
    Get
      Return Nothing
    End Get
  End Property

End Class
