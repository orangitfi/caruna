Public Class Io

  Public Shared Function YhdistaKansioJaTiedosto(polku As String, tiedosto As String)

    If Not polku.EndsWith("\") Then
      polku &= "\"
    End If

    Return polku & tiedosto

  End Function

End Class
