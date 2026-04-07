Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class TunnisteyksikkoTemplate
  Inherits TemplateEntityBase(Of Tunnisteyksikko)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Tunnisteyksikko) As String

    Select Case key
      Case "Tunnus"
        Return entity.PGTunnus
      Case "Osoite"
        Return String.Empty
      Case "PintaAla"
        Return String.Empty
      Case "Nimi"
        Return entity.Nimi
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
