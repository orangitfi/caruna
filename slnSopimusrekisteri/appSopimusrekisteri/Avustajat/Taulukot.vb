Public Class Taulukot

  Public Shared Function YhdistaTaulukko(taulukko As String(), erotin As String) As String

    If Not taulukko Is Nothing Then

      Return Join(taulukko, erotin)

    End If

    Return Nothing
  End Function

End Class
