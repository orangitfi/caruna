Public Class JASSopimus

  Public Property Korvaus As JasSopimusKorvaus
  Public Property JohdonOmistaja As JasSopimusJohdonOmistaja
  Public Property Maanomistaja As JasSopimusMaanomistaja
  Public Property Sopimusnumero As Integer?

  Sub New()

    Korvaus = New JasSopimusKorvaus()
    JohdonOmistaja = New JasSopimusJohdonOmistaja()
    Maanomistaja = New JasSopimusMaanomistaja()

  End Sub

End Class

Public Class JasSopimusKorvaus

  Public Property Korvaus As Decimal?
  Public Property PuustonPoisto As String
  Public Property PuustonOmistajuus As String

End Class

Public Class JasSopimusJohdonOmistaja

  Public Property Nimi As String
  Public Property Osoite As String
  Public Property Linjaosa As String
  Public Property Karttalehti As String
  Public Property Tyonumero As String

End Class

Public Class JasSopimusMaanomistaja

  Public Property Nimi As String
  Public Property Osoite As String
  Public Property Tilinumero As String
  Public Property MaanomistajanTilat As List(Of JasSopimusMaanomistajanTila)

  Sub New()

    MaanomistajanTilat = New List(Of JasSopimusMaanomistajanTila)()

  End Sub

End Class


Public Class JasSopimusMaanomistajanTila

  Public Property TilanNimi As String
  Public Property Kunta As String
  Public Property Kyla As String
  Public Property Rekisterinumero As String

  Sub New()

    TilanNimi = String.Empty
    Kunta = String.Empty
    Kyla = String.Empty
    Rekisterinumero = String.Empty

  End Sub

End Class