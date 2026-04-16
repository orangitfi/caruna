Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class TahoPariTemplate
  Inherits TemplateEntityBase(Of Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho))

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho)) As String

    Dim tahoPari As Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho) = CType(entity, Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho))

    Select Case key
      Case "MaanomistajaAllekirjoitusOtsikko2"
        If Not tahoPari.Item2 Is Nothing Then
          Return "Maanomistajan allekirjoitus"
        Else
          Return String.Empty
        End If
      Case "NimenSelvennosOtsikko2"
        If Not tahoPari.Item2 Is Nothing Then
          Return "Nimen selvennös"
        Else
          Return String.Empty
        End If
      Case "MaanomistajaAllekirjoitusOtsikko2Ruotsi"
        If Not tahoPari.Item2 Is Nothing Then
          Return "Markägarens underskrift"
        Else
          Return String.Empty
        End If
      Case "NimenSelvennosOtsikko2Ruotsi"
        If Not tahoPari.Item2 Is Nothing Then
          Return "Namnförtydligande"
        Else
          Return String.Empty
        End If
      Case "Allekirjoitus2"
        If Not tahoPari.Item2 Is Nothing Then
          Return "<hr />"
        Else
          Return String.Empty
        End If
    End Select

    Return Nothing

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Dim tahoPari As Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho) = CType(entity, Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho))

    Select Case key
      Case "Item1"
        Return tahoPari.Item1
      Case "Item2"
        Return tahoPari.Item2
    End Select

    Return Nothing

  End Function

  Public Overrides ReadOnly Property SubEntityKeys() As IEnumerable(Of String)
    Get
      Return {"Item1", "Item2"}
    End Get
  End Property

End Class
