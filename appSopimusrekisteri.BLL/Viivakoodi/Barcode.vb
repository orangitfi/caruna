Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Barcode
  '9.2.2011 Janne Hakkarainen - tekee sekä pankkiviivakoodin että itse viivakoodi-kuvan
  'tällä hetkellä luo vain 128 C -koodin, jossa käytetään vain numeroita, koodi luetaan numeropareina eli koodin numeroiden määrän tulee olla parillinen

  Private _dicCharsCodeC As Dictionary(Of String, String)
  Private _strCode As String
  Private _imgFormat As ImageFormat
  Private _intHeight As Integer
  Private _intLineThickness As Integer
  Private _intQuietZone As Integer

  Public Sub New()

    FillCharsetC()

    _strCode = code
    _imgFormat = ImageFormat.Png
    _intHeight = 50
    _intLineThickness = 1
    _intQuietZone = 0

  End Sub

  Public Sub New(ByVal code As String)

    FillCharsetC()

    _strCode = code
    _imgFormat = ImageFormat.Png
    _intHeight = 50
    _intLineThickness = 1
    _intQuietZone = 0

  End Sub

  Private Sub FillCharsetC()
    'täyttää numeropareja vastaavat koodit tauluun
    'koodit siis binääriä, 1 vastaa mustaa viivaa, 0 valkosta viivaa

    _dicCharsCodeC = New Dictionary(Of String, String)

    _dicCharsCodeC.Add("00", "11011001100")
    _dicCharsCodeC.Add("01", "11001101100")
    _dicCharsCodeC.Add("02", "11001100110")
    _dicCharsCodeC.Add("03", "10010011000")
    _dicCharsCodeC.Add("04", "10010001100")
    _dicCharsCodeC.Add("05", "10001001100")
    _dicCharsCodeC.Add("06", "10011001000")
    _dicCharsCodeC.Add("07", "10011000100")
    _dicCharsCodeC.Add("08", "10001100100")
    _dicCharsCodeC.Add("09", "11001001000")
    _dicCharsCodeC.Add("10", "11001000100")
    _dicCharsCodeC.Add("11", "11000100100")
    _dicCharsCodeC.Add("12", "10110011100")
    _dicCharsCodeC.Add("13", "10011011100")
    _dicCharsCodeC.Add("14", "10011001110")
    _dicCharsCodeC.Add("15", "10111001100")
    _dicCharsCodeC.Add("16", "10011101100")
    _dicCharsCodeC.Add("17", "10011100110")
    _dicCharsCodeC.Add("18", "11001110010")
    _dicCharsCodeC.Add("19", "11001011100")
    _dicCharsCodeC.Add("20", "11001001110")
    _dicCharsCodeC.Add("21", "11011100100")
    _dicCharsCodeC.Add("22", "11001110100")
    _dicCharsCodeC.Add("23", "11101101110")
    _dicCharsCodeC.Add("24", "11101001100")
    _dicCharsCodeC.Add("25", "11100101100")
    _dicCharsCodeC.Add("26", "11100100110")
    _dicCharsCodeC.Add("27", "11101100100")
    _dicCharsCodeC.Add("28", "11100110100")
    _dicCharsCodeC.Add("29", "11100110010")
    _dicCharsCodeC.Add("30", "11011011000")
    _dicCharsCodeC.Add("31", "11011000110")
    _dicCharsCodeC.Add("32", "11000110110")
    _dicCharsCodeC.Add("33", "10100011000")
    _dicCharsCodeC.Add("34", "10001011000")
    _dicCharsCodeC.Add("35", "10001000110")
    _dicCharsCodeC.Add("36", "10110001000")
    _dicCharsCodeC.Add("37", "10001101000")
    _dicCharsCodeC.Add("38", "10001100010")
    _dicCharsCodeC.Add("39", "11010001000")
    _dicCharsCodeC.Add("40", "11000101000")
    _dicCharsCodeC.Add("41", "11000100010")
    _dicCharsCodeC.Add("42", "10110111000")
    _dicCharsCodeC.Add("43", "10110001110")
    _dicCharsCodeC.Add("44", "10001101110")
    _dicCharsCodeC.Add("45", "10111011000")
    _dicCharsCodeC.Add("46", "10111000110")
    _dicCharsCodeC.Add("47", "10001110110")
    _dicCharsCodeC.Add("48", "11101110110")
    _dicCharsCodeC.Add("49", "11010001110")
    _dicCharsCodeC.Add("50", "11000101110")
    _dicCharsCodeC.Add("51", "11011101000")
    _dicCharsCodeC.Add("52", "11011100010")
    _dicCharsCodeC.Add("53", "11011101110")
    _dicCharsCodeC.Add("54", "11101011000")
    _dicCharsCodeC.Add("55", "11101000110")
    _dicCharsCodeC.Add("56", "11100010110")
    _dicCharsCodeC.Add("57", "11101101000")
    _dicCharsCodeC.Add("58", "11101100010")
    _dicCharsCodeC.Add("59", "11100011010")
    _dicCharsCodeC.Add("60", "11101111010")
    _dicCharsCodeC.Add("61", "11001000010")
    _dicCharsCodeC.Add("62", "11110001010")
    _dicCharsCodeC.Add("63", "10100110000")
    _dicCharsCodeC.Add("64", "10100001100")
    _dicCharsCodeC.Add("65", "10010110000")
    _dicCharsCodeC.Add("66", "10010000110")
    _dicCharsCodeC.Add("67", "10000101100")
    _dicCharsCodeC.Add("68", "10000100110")
    _dicCharsCodeC.Add("69", "10110010000")
    _dicCharsCodeC.Add("70", "10110000100")
    _dicCharsCodeC.Add("71", "10011010000")
    _dicCharsCodeC.Add("72", "10011000010")
    _dicCharsCodeC.Add("73", "10000110100")
    _dicCharsCodeC.Add("74", "10000110010")
    _dicCharsCodeC.Add("75", "11000010010")
    _dicCharsCodeC.Add("76", "11001010000")
    _dicCharsCodeC.Add("77", "11110111010")
    _dicCharsCodeC.Add("78", "11000010100")
    _dicCharsCodeC.Add("79", "10001111010")
    _dicCharsCodeC.Add("80", "10100111100")
    _dicCharsCodeC.Add("81", "10010111100")
    _dicCharsCodeC.Add("82", "10010011110")
    _dicCharsCodeC.Add("83", "10111100100")
    _dicCharsCodeC.Add("84", "10011110100")
    _dicCharsCodeC.Add("85", "10011110010")
    _dicCharsCodeC.Add("86", "11110100100")
    _dicCharsCodeC.Add("87", "11110010100")
    _dicCharsCodeC.Add("88", "11110010010")
    _dicCharsCodeC.Add("89", "11011011110")
    _dicCharsCodeC.Add("90", "11011110110")
    _dicCharsCodeC.Add("91", "11110110110")
    _dicCharsCodeC.Add("92", "10101111000")
    _dicCharsCodeC.Add("93", "10100011110")
    _dicCharsCodeC.Add("94", "10001011110")
    _dicCharsCodeC.Add("95", "10111101000")
    _dicCharsCodeC.Add("96", "10111100010")
    _dicCharsCodeC.Add("97", "11110101000")
    _dicCharsCodeC.Add("98", "11110100010")
    _dicCharsCodeC.Add("99", "10111011110")
    _dicCharsCodeC.Add("100", "10111101110")
    _dicCharsCodeC.Add("101", "11101011110")
    _dicCharsCodeC.Add("102", "11110101110")
    _dicCharsCodeC.Add("103", "11010000100")
    _dicCharsCodeC.Add("104", "11010010000")
    'c-koodin alkumerkki
    _dicCharsCodeC.Add("105", "11010011100")
    'lopetusmerkki
    _dicCharsCodeC.Add("106", "1100011101011")

  End Sub

  Private Function GenerateBarcodeImage() As Image

    'kasataan ensin koodi yhdeksi stringiksi

    'alkuun aloitusmerkki
    Dim strCodeC As String = _dicCharsCodeC.Item("105")

    Dim intIndex As Integer = 0

    Dim intPosition As Integer = 1

    Dim strValue As String

    'tarkistetta varten pitää laskea summa, aloitetaan aloitusmerkin arvolla
    Dim intSum As Integer = 105

    'luupataan koodi läpi numeropareittain
    While intIndex + 2 <= _strCode.Length

      'otetaan numeropari talteen
      strValue = _strCode.Substring(intIndex, 2)

      'haetaan taulukosta numeroparia vastaava binäärikoodi koodin jatkoksi
      strCodeC &= _dicCharsCodeC.Item(strValue)

      'kasvatetaan indeksiä kahdella, eli numeroparin verran
      intIndex += 2

      'lisätään yhteissummaan numeroparin arvo kerottuna parin positiolla
      intSum += CInt(strValue) * intPosition

      'positio kasvaa
      intPosition += 1

    End While

    'summa jaetaan 103:lla, jakojäännös on tarkiste
    Dim intChecksum As Integer = intSum Mod 103

    'laitetaan tarkisteen eteen tarvittaessa nolla ja haetaan koodin jatkoksi arvoa vastaava koodi
    If intChecksum > 99 Then
      strCodeC &= _dicCharsCodeC.Item(intChecksum.ToString())
    Else
      strCodeC &= _dicCharsCodeC.Item(Right("00" & intChecksum, 2))
    End If

    'loppuun lopetusmerkki
    strCodeC &= _dicCharsCodeC.Item("106")

    'kuvan leveys on kokonaiskoodin pituus kerrottuna viivan paksuudella
    Dim intW As Integer = strCodeC.Length * LineThickness

    'koodin alkuun ja loppuun tulee tyhjä alue, joten kasvatetaan kuvan leveyttä niitä varten, käytetään vähintään 20:n tyhjää aluetta
    If _intQuietZone > 20 Then
      intW += _intQuietZone * 2
    Else
      intW += 40
    End If

    'kuvan korkeus, lisätään neljä, jotta saadaan vähän tyhjää ylä- ja alapuolelle
    Dim intH As Integer = _intHeight + 4

    'muodostetaan kuva
    Dim objBitmap As New Bitmap(intW, intH)

    Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)

    Dim objBrush As New SolidBrush(Color.White)

    objGraphics = Graphics.FromImage(objBitmap)

    'täytetään kuva valkoisella
    objGraphics.FillRectangle(objBrush, 0, 0, intW, intH)

    'viivojen alku- ja lopetuspisteet
    Dim point1 As Point
    Dim point2 As Point

    'viivan x-akselin arvo
    Dim x As Integer

    'x-akselin aloitusarvo riippuu alun tyhjästä alueesta
    If _intQuietZone > 20 Then

      x = _intQuietZone + 1

    Else

      x = 21

    End If

    'käydään koodi läpi
    For Each c As Char In strCodeC.ToCharArray()

      'jos numero on 1, piirretään musta viiva, jos valkoinen piirretään valkoinen viiva
      If c = "1" Then

        'piirretään viivoja paksuuden mukaan
        For i As Integer = 0 To _intLineThickness - 1

          'aloituspiste (x-akselin arvo ja 2 pistettä yläreunasta alaspäin)
          point1 = New Point(x, 2)
          'lopetuspiste (x-akselin arvo ja 2+viivan korkeus yläreunasta alaspäin)
          point2 = New Point(x, _intHeight + 2)

          'piirretään viiva
          objGraphics.DrawLine(Pens.Black, point1, point2)

          'x-akselin arvo kasvaa
          x += 1
        Next

      Else

        For i As Integer = 0 To _intLineThickness - 1

          point1 = New Point(x, 2)
          point2 = New Point(x, _intHeight + 2)

          objGraphics.DrawLine(Pens.White, point1, point2)

          x += 1
        Next

      End If

    Next

    'palautetaan kuva
    Return objBitmap

  End Function

  Public Function GenerateBankCodeVersion4(ByVal iban As String, ByVal sum As Decimal, ByVal referencenumber As String, ByVal duedate As Date) As String
    'luo pankkiviivakoodin symboliversion 4

    'viivakoodin versio
    _strCode = "4"

    'iban-koodi ilman FI-merkintää
    _strCode &= Right(iban, 16)

    'summa 6 + 2 merkkiä
    Dim strFormattedSum As String = sum.ToString("0.00")

    strFormattedSum = strFormattedSum.Replace(".", "").Replace(",", "")

    'maksimi summa 999999,99, jos suurempi, laitetaan nollaa
    If strFormattedSum.Length > 8 Then
      _strCode &= "00000000"
    Else
      'etunollat alkuun
      _strCode &= Right(New String("0", 8) & strFormattedSum, 8)
    End If

    'nollia varalla
    _strCode &= "000"

    'viitenumero etunollilla
    _strCode &= Right(New String("0", 20) & referencenumber, 20)

    'eräpvm
    _strCode &= duedate.ToString("yyMMdd")

    Return _strCode
  End Function

  Public Sub SaveBarcodeToImage(ByVal path As String)

    Dim objBitmap As Bitmap = GenerateBarcodeImage()

    objBitmap.Save(path, _imgFormat)

  End Sub

  Public Function GetBarcodeImage() As Bitmap

    Dim objBitmap As Bitmap = GenerateBarcodeImage()

    Return objBitmap

  End Function

  Public Property Code() As String
    Get
      Return _strCode
    End Get
    Set(ByVal value As String)
      _strCode = value
    End Set
  End Property

  Public Property Height() As Integer
    Get
      Return _intHeight
    End Get
    Set(ByVal value As Integer)
      _intHeight = value
    End Set
  End Property

  Public Property LineThickness() As Integer
    Get
      Return _intLineThickness
    End Get
    Set(ByVal value As Integer)
      _intLineThickness = value
    End Set
  End Property

  Public Property QuietZone() As Integer
    Get
      Return _intQuietZone
    End Get
    Set(ByVal value As Integer)
      _intQuietZone = value
    End Set
  End Property

  Public Property ImageFormat() As ImageFormat
    Get
      Return _imgFormat
    End Get
    Set(ByVal value As ImageFormat)
      _imgFormat = value
    End Set
  End Property

End Class
