
Public Class KorvauslaskelmanRivi

  Public Property Id As Integer?
  Public Property KorvauslaskelmaId As Integer?
  Public Property KorvaushinnastoId As Integer?
  Public Property Korvauslaji As String
  Public Property Korvaus As Decimal?
  Public Property KuvionTunnus As String
  Public Property KuvionPituus As Decimal?
  Public Property KuvionLeveys As Decimal?
  Public Property KuvionKorvattavaLeveys As Decimal?
  Public Property KokonaisPintaAla As Decimal?
  Public Property Maara As Decimal?
  Public Property Lisatieto As String
  Public Property Yksikkohinta As Decimal?
  Public Property Kuvaus As String
  Public Property ArvonPeruste As String
  Public Property Korvausyksikko As String
  Public Property KorvausyksikonKuvaus As String
  Public Property KorvausYksikonTyyppi As Enumeraattorit.KorvausyksikonTyyppi
  Public Property Korvauslaskelma As Korvauslaskelma

  Public Property KirjanpidonTiliId As Integer?
  Public Property KirjanpidonTili As String
  Public Property KustannuspaikkaId As Integer?
  Public Property Kustannuspaikka As String
  Public Property InvCostId As Integer?
  Public Property InvCost As String
  Public Property RegulationId As Integer?
  Public Property Regulation As String
  Public Property PurposeId As Integer?
  Public Property Purpose As String
  Public Property Local1Id As Integer?
  Public Property Local1 As String

  Public Property Luotu As Date?
  Public Property Luoja As String
  Public Property Paivitetty As Date?
  Public Property Paivittaja As String

End Class
