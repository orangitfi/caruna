Public Class Maksu

  Public Property Id As Integer?
  Public Property MaksuEraTunniste As Integer?
  Public Property KorvauslaskelmaId As Integer?
  Public Property Ajopvm As Date?
  Public Property MaksuStatusId As Integer?
  Public Property Maksupvm As Date?
  Public Property Summa As Decimal?
  Public Property Alv As Decimal?
  Public Property Viite As String
  Public Property Viesti As String
  Public Property Vuosi As Integer?
  Public Property Tilinumero As String
  Public Property BicKoodi As String
  Public Property SaajaId As Integer?
  Public Property Saaja As String
  Public Property Luoja As String
  Public Property Luotu As Date?
  Public Property OnIndeksi As Boolean = False
  Public Property Indeksi As Integer?
  Public Property MaksuIndeksi As Integer?
  Public Property IndeksikuukausiId As Integer?
  Public Property Indeksikuukausi As String
  Public Property IndeksityyppiId As Integer?
  Public Property Indeksityyppi As String
  Public Property Info As String
  Public Property AlvOsuus As Decimal?
  Public Property JuridinenYhtioId As Integer?
  Public Property MaksajanNimi As String
  Public Property MaksajanTilinro As String
  Public Property MaksajanBicKoodi As String
  Public Property SopimusId As Integer?
  Public Property SummaIlmanAlv As Decimal?
  Public Property Indeksivuosi As Integer?

  Public Property Palvelutunnus As String
  Public Property Kirjanpidontunniste As String
  Public Property KirjanpidonProjektitunniste As String
  Public Property JuridinenYhtio As Taho

  Public Property Korvauslaskelma As Korvauslaskelma
  Public Property Tiliointi As MaksunTiliointi()

End Class
