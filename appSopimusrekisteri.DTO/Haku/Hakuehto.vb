Public Class Hakuehto

  Public Sub New()

  End Sub

  Public Sub New(tyyppi As Hakutyyppi, kentta As String, operaattori As Hakuoperaattori)
    Me.Kentta = kentta
    Me.Operaattori = operaattori
    Me.Tyyppi = tyyppi
  End Sub

  Public Sub New(tyyppi As Hakutyyppi, kentta As String, operaattori As Hakuoperaattori, arvo As Object)
    Me.New(tyyppi, kentta, operaattori)
    Me.Arvo = arvo
  End Sub

  Public Property Kentta As String
  Public Property Operaattori As Hakuoperaattori
  Public Property Arvo As Object
  Public Property Tyyppi As Hakutyyppi

End Class
