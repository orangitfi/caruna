Public Class KiinteistoTemplate
  Inherits TemplateEntityBase(Of DTO.Kiinteisto)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As DTO.Kiinteisto) As String

    Select Case key
      Case "Nimi"
        Return If(String.IsNullOrEmpty(entity.Nimi), String.Empty, entity.Nimi)
      Case "Osoite"
        Return If(String.IsNullOrEmpty(entity.Osoite), String.Empty, entity.Osoite)
      Case "Postiosoite"
        Return If(String.IsNullOrEmpty(Trim(entity.Postinumero & " " & entity.Postitoimipaikka)), String.Empty, Trim(entity.Postinumero & " " & entity.Postitoimipaikka))
      Case "Maa"
        Return If(String.IsNullOrEmpty(entity.Maa), String.Empty, entity.Maa)
      Case "Kyla"
        Return If(String.IsNullOrEmpty(entity.Kyla), String.Empty, entity.Kyla)
      Case "Kunta"
        Return If(String.IsNullOrEmpty(entity.Kunta), String.Empty, entity.Kunta)
      Case "Rekisterinumero"
        Return If(String.IsNullOrEmpty(entity.LyhytKiinteistotunnus), String.Empty, entity.LyhytKiinteistotunnus)
      Case "KokonaisPintaAla"
        If entity.KokonaisPintaAla.HasValue Then
          Return entity.KokonaisPintaAla.Value.ToString("F2") & " m2"
        Else
          Return String.Empty
        End If
      Case "Kiinteistotunnus"
        Return entity.KiinteistoTunnus
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
