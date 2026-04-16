Imports Sopimusrekisteri.BLL_CF.Poiminnat

Public Class Sessio

  Private Shared ReadOnly Property Session As HttpSessionState
    Get
      Return HttpContext.Current.Session
    End Get
  End Property

  Public Shared Property PoiminnanSarakkeetSopimukselle(sessio As HttpSessionState) As Dictionary(Of String, String)
    Get
      Return sessio("poiminnanSarakkeetSopimus")
    End Get
    Set(value As Dictionary(Of String, String))
      sessio("poiminnanSarakkeetSopimus") = value
    End Set
  End Property

  Public Shared Property PoiminnanSarakkeetKiinteistolle(sessio As HttpSessionState) As Dictionary(Of String, String)
    Get
      Return sessio("poiminnanSarakkeetKiinteisto")
    End Get
    Set(value As Dictionary(Of String, String))
      sessio("poiminnanSarakkeetKiinteisto") = value
    End Set
  End Property

  Public Shared Property PoiminnanSarakkeetTaholle(sessio As HttpSessionState) As Dictionary(Of String, String)
    Get
      Return sessio("poiminnanSarakkeetTaho")
    End Get
    Set(value As Dictionary(Of String, String))
      sessio("poiminnanSarakkeetTaho") = value
    End Set
  End Property

  Public Shared ReadOnly Property Poimintaehdot As ICollection(Of IPoimintaehdot)
    Get

      Dim ehdot As ICollection(Of IPoimintaehdot) = Session("poiminta_ehdot")

      If ehdot Is Nothing Then
        ehdot = New List(Of IPoimintaehdot)()
        Session("poiminta_ehdot") = ehdot
      End If

      Return ehdot
    End Get
  End Property

  Public Shared ReadOnly Property Poimintasarakkeet As IEnumerable(Of KT.Utils.Mapping.ColumnBinding)
    Get

      Dim sarakkeet As IEnumerable(Of KT.Utils.Mapping.ColumnBinding) = Session("poiminta_sarakkeet")

      If sarakkeet Is Nothing Then
        sarakkeet = New List(Of KT.Utils.Mapping.ColumnBinding)()
        Session("poiminta_sarakkeet") = sarakkeet
      End If

      Return sarakkeet
    End Get
  End Property

End Class
