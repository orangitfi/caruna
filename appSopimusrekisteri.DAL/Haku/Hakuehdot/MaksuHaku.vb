Public Class MaksuHaku

  Public Shared Function HaeMaksuEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.Maksu)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Maksu)

    Dim hakukentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.Maksupvm)
        hakukentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.MAKMaksupaiva)
        hakukentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Summa)
        hakukentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.MAKSumma)
        hakukentta.Tyyppi = GetType(Decimal)
      Case Else
        hakukentta.Nimi = String.Empty
    End Select

    Return hakukentta

  End Function

End Class
