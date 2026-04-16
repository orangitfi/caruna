Public Class Korvaushinnasto

  Public Property Id As Integer
  Public Property Korvauslaji As String
  Public Property Kuvaus As String
  Public Property SopimustyyppiId As Integer?
  Public Property YksikkoId As Integer?
  Public Property Yksikkohinta As Decimal?
  Public Property YksikkohinnanTarkenne As String
  Public Property MetsatyyppiId As Integer?
  Public Property PuustolajiId As Integer?
  Public Property HinnastoKategoriaId As Integer?
  Public Property HinnastoAlakategoriaId As Integer?
  Public Property ArvonPeruste As String
  Public Property MaksuAlueId As Integer?
  Public Property PuustonIka As Integer?
  Public Property TaimistonValtapituus As Decimal?
  Public Property Tiheyskerroin As Decimal?
  Public Property Alkupvm As DateTime?
  Public Property Loppupvm As DateTime?

  Public Property Aktiivinen As Boolean
  Public Property Info As String
  Public Property Luotu As DateTime
  Public Property Luoja As String
  Public Property Paivittaja As String
  Public Property Paivitetty As DateTime?

End Class
