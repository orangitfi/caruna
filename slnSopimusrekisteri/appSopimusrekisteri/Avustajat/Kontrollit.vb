Public Class Kontrollit

  Public Shared Function HaeKontrollit(Of T As Control)(kontrolli As Control) As IEnumerable(Of T)

    Dim kontrollit As New List(Of T)()

    For Each alaKontrolli As Control In kontrolli.Controls

      If TypeOf (alaKontrolli) Is T Then
        kontrollit.Add(CType(alaKontrolli, T))
      End If

      If alaKontrolli.HasControls Then
        kontrollit.AddRange(HaeKontrollit(Of T)(alaKontrolli))
      End If

    Next

    Return kontrollit

  End Function

End Class
