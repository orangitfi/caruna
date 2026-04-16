Imports appSopimusrekisteri.DTO
Imports DocumentFormat.OpenXml.Math

Public Class SuostumusJohdonOmistajaTemplate
  Inherits TemplateEntityBase(Of DTO.SuostumussopimusJohdonOmistaja)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As SuostumussopimusJohdonOmistaja) As String

    Select Case key
      Case "Nimi"
        Return If(entity.Nimi Is Nothing, String.Empty, entity.Nimi)
      Case "Osoite"
        Return If(entity.Osoite Is Nothing, String.Empty, entity.Osoite)
      Case "Linjaosa"
        Return If(entity.Linjaosa Is Nothing, String.Empty, entity.Linjaosa)
      Case "Karttalehti"
        Return If(entity.Karttalehti Is Nothing, String.Empty, entity.Karttalehti)
      Case "Tyonumero"
        Return If(entity.Tyonumero Is Nothing, String.Empty, entity.Tyonumero)

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
