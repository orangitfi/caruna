Public Class KorvausTemplate
  Inherits TemplateEntityBase(Of DTO.Korvauslaskelma)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As DTO.Korvauslaskelma) As String

    Select Case key
      Case "Vuosivuokra"
        If entity.MaksetaanAlv Then
          Return String.Empty
        Else
          Return entity.Summa.ToString("f2")
        End If
      Case "VuosivuokraAlv"
        If entity.MaksetaanAlv Then
          Return entity.SummaAlv.ToString("f2")
        Else
          Return String.Empty
        End If
      Case "Perusvuokra"
        Return String.Empty
      Case "AlvVelvollinen"
        If entity.MaksetaanAlv Then
          Return "Kyllä"
        Else
          Return "Ei"
        End If
      Case "Indeksi"
        If entity.SopimushetkenIndeksi.HasValue Then
          Return entity.SopimushetkenIndeksi.Value
        Else
          Return String.Empty
        End If
      Case "Summa"
        Return entity.Summa.ToString("f2")
      Case "SummaAlv"
        Return entity.SummaAlv.ToString("f2")
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
