Public Class Paivaykset

  Public Shared Function PalautaPaivays(paivays As String) As Date?

    If IsDate(paivays) Then
      Return Convert.ToDateTime(paivays)
    End If
    Return Nothing

  End Function

  Public Shared Function PalautaTasmallinenPaivays(paivays As DateTime?) As String

    If Not paivays Is Nothing Then
      Return String.Format("{0:dd.MM.yyyy hh:mm}", paivays)
    End If
    Return String.Empty

  End Function

  Public Shared Function PalautaPaivays(paivays As DateTime?) As String

    If Not paivays Is Nothing Then
      Return String.Format("{0:dd.MM.yyyy}", paivays)
    End If
    Return String.Empty

  End Function

  Public Shared Function PalautaAika(paivays As DateTime?) As String

    If Not paivays Is Nothing Then
      Return String.Format("{0:HH:mm}", paivays)
    End If
    Return String.Empty

  End Function

  Public Shared Function PalautaPaivays(arvo As Object) As Object

    If IsDate(arvo) Then
      Return PalautaPaivays(CDate(arvo))
    End If

    Return Nothing
  End Function

End Class
