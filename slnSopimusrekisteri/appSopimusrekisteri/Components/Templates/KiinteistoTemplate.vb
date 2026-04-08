Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class KiinteistoTemplate
  Inherits TemplateEntityBase(Of Kiinteisto)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Kiinteisto) As String

    Select Case key
      Case "Nimi"
        Return If(String.IsNullOrEmpty(entity.KiinteistoNimi), String.Empty, entity.KiinteistoNimi)
      Case "Osoite"
        Return If(String.IsNullOrEmpty(entity.Katuosoite), String.Empty, entity.Katuosoite)
      Case "Postiosoite"
        Return If(String.IsNullOrEmpty(Trim(entity.Postinumero & " " & entity.Postitoimipaikka)), String.Empty, Trim(entity.Postinumero & " " & entity.Postitoimipaikka))
      Case "Maa"
        If Not entity.Maa Is Nothing Then
          Return If(String.IsNullOrEmpty(entity.Maa.Nimi), String.Empty, entity.Maa.Nimi)
        Else
          Return String.Empty
        End If
      Case "Kyla"
        Return If(String.IsNullOrEmpty(entity.Kyla), String.Empty, entity.Kyla)
      Case "Kunta"
        If Not entity.Kunta Is Nothing Then
          Return If(String.IsNullOrEmpty(entity.Kunta.KuntaNimi), String.Empty, entity.Kunta.KuntaNimi)
        Else
          Return String.Empty
        End If
      Case "Rekisterinumero"
        Return If(String.IsNullOrEmpty(entity.KiinteistotunnusLyhyt), String.Empty, entity.KiinteistotunnusLyhyt)
      Case "KokonaisPintaAla"
        If entity.PintaAla.HasValue Then
          Return entity.PintaAla.Value.ToString("F2") & " m2"
        Else
          Return String.Empty
        End If
      Case "Kiinteistotunnus"
        Return entity.Kiinteistotunnus
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
