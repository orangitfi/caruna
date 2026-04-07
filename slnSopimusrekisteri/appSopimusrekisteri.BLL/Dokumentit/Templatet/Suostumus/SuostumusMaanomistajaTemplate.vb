Imports appSopimusrekisteri.DTO

Public Class SuostumusMaanomistajaTemplate
  Inherits TemplateEntityBase(Of DTO.SuostumussopimusMaanomistaja)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As DTO.SuostumussopimusMaanomistaja) As String

    Select Case key
      Case "Nimi"
        Return If(entity.Nimi Is Nothing, String.Empty, entity.Nimi)
      Case "Osoite"
        Return If(entity.Osoite Is Nothing, String.Empty, entity.Osoite)
      Case "TilanNimi"
        Return If(entity.TilanNimi Is Nothing, String.Empty, entity.TilanNimi)
      Case "TilanKyla"
        Return If(entity.TilanKyla Is Nothing, String.Empty, entity.TilanKyla)
      Case "TilanKunta"
        Return If(entity.TilanKunta Is Nothing, String.Empty, entity.TilanKunta)

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
