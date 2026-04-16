Public Class Maksuraportti

  Public Property SopimusId As Integer
  Public Property SopimustyyppiId As Integer
  Public Property SopimuksenNimi As String
  Public Property Projektinumero As String
  Public Property KorvauksenProjektinumero As String
  Public Property KorvauslaskelmaId As Integer
  Public Property SaajaId As Integer?
  Public Property Saaja As String
  Public Property BicKoodi As String
  Public Property Tilinumero As String
  Public Property Viite As String
  Public Property Viesti As String
  Public Property KorvauksienMaara As Integer
  Public Property Sopimustyyppi As String
  Public Property Korvaustyyppi As String
  Public Property KorvausTyyppiId As Integer?
  Public Property MaksunSuoritus As String
  Public Property TypeOfProject As String
  Public Property Type As String
  Public Property Owner As String
  Public Property Concession As String
  Public Property CertDate As String
  Public Property FieldWorkStartedA As Date?
  Public Property ProjectClosedA As Date?
  Public Property Kustannuspaikka As String
  Public Property Kirjanpidontili As String
  Public Property InvCost As String
  Public Property Country As String
  Public Property Regulation As String
  Public Property Purpose As String
  Public Property Local1 As String
  Public Property MaksuaineistonRyhma As MaksuaineistonRyhma = MaksuaineistonRyhma.MaksettavaAineisto
  Public Property OnIndeksi As Boolean = False
  Public Property Indeksikuukausi As String
  Public Property Indeksi As String
  Public Property Indeksityyppi As String
  Public Property EnsimmainenMaksupvm As Date?
  Public Property EnsimmainenMaksupvmSyotettyKasin As Boolean = False

  Public Property KorvauksienSummaIlmanAlv As Decimal
  Public Property KorvauksienAlv As Decimal
  Public Property KorvauksienSumma As Decimal

  Public Property MaksajanTilinro As String
  Public Property MaksajanBicKoodi As String
  Public Property Palvelutunnus As String
  Public Property Kirjanpidontunniste As String
  Public Property JuridinenYhtioConcession As String

End Class
