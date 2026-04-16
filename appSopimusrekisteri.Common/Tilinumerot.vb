Imports System.Text.RegularExpressions

Public Class Tilinumerot

  Public Shared Function OnIbanTilinumero(tilinumero As String) As Boolean

    Dim regEx As New Text.RegularExpressions.Regex("^[A-Z]{2}[0-9]{2}[1-9][0-9]{13}$")

    Return regEx.IsMatch(tilinumero)

  End Function

  Public Shared Function OnValidiSuomalainenTilinumero(tilinumero As String) As Boolean

    Dim regEx As New Text.RegularExpressions.Regex("^[1-9]{1}[0-9]{5}\-[0-9]{2,8}$")

    Dim boo As Boolean = False

    'mätsääkö tilinumeron muoto (6 numeroa, väliviiva, 2-8 numeroa)
    If regEx.IsMatch(tilinumero) Then

      Dim strKoneKielinenTilinro As String = MuunnaKonekieliseenMuotoon(tilinumero)

      Dim intKerroin As Integer = 2
      Dim intSumma As Integer
      Dim intLuku As Integer

      'käydään luvut 1-13 läpi
      For i As Integer = 0 To 12
        'kertotaan luku kertoimella (järjestys 2,1,2,1,2 jne..)
        intLuku = Integer.Parse(strKoneKielinenTilinro(i)) * intKerroin
        'jos luku on kaksinumeroinen, lopullinen luku on numeroiden summa eli 12 = 1 + 2, eli käytännössä vähennetään 9
        If intLuku > 9 Then
          intLuku -= 9
        End If

        'lisätään yhteissummaan
        intSumma += intLuku

        'kerroin muuttuu
        If intKerroin = 2 Then
          intKerroin = 1
        Else
          intKerroin = 2
        End If
      Next

      Dim intLahinKymppi As Integer
      Dim intTarkiste As Integer

      'otetaan summasta seuraava kymmenellä jaollinen luku
      intLahinKymppi = Math.Ceiling(intSumma / 10) * 10

      'tarkiste on lähimmän kympin ja summan erotus
      intTarkiste = intLahinKymppi - intSumma

      'jos tarkiste täsmää tilinumeron viimeisen luvun kanssa, on numero ok
      If intTarkiste = Integer.Parse(strKoneKielinenTilinro(13)) Then
        boo = True
      End If
    End If

    Return boo

  End Function

  Public Shared Function OnSuomalainenIbanTilinumero(tilinumero As String) As Boolean

    Return tilinumero.StartsWith("FI")

  End Function

  Public Shared Function OnValidiIbanTilinumero(tilinumero As String) As Boolean

    Dim boo As Boolean = False

    Dim regEx As New Text.RegularExpressions.Regex("^[A-Z]{2}[0-9]{2}[1-9][0-9]{13}$")

    If regEx.IsMatch(tilinumero) Then

      Dim strRunko As String
      Dim strMaaKoodi As String
      Dim strTarkiste As String
      Dim strMuokattuTilinumero As String

      strRunko = Right(tilinumero, 14)

      strMaaKoodi = tilinumero.Substring(0, 2)

      strTarkiste = tilinumero.Substring(2, 2)

      strMuokattuTilinumero = strRunko & Taulukko1(Left(strMaaKoodi, 1)).ToString() & Taulukko1(Right(strMaaKoodi, 1)).ToString() & strTarkiste

      Dim decIban As Decimal = CDec(strMuokattuTilinumero)

      If decIban Mod 97 = 1 Then
        boo = True
      End If

    End If

    Return boo

  End Function

  Public Shared Function MuunnaIBANMuotoon(tilinumero As String) As String

    If OnValidiSuomalainenTilinumero(tilinumero) Then

      Dim strKoneKielinenTilinro As String = MuunnaKonekieliseenMuotoon(tilinumero)
      Dim strMuokattuTilinumero As String

      strMuokattuTilinumero = strKoneKielinenTilinro & Taulukko1("F").ToString() & Taulukko1("I").ToString() & "00"

      Dim decIban As Decimal = CDec(strMuokattuTilinumero)
      Dim intJakojaannos As Integer = decIban Mod 97
      Dim intErotus As Integer = 98 - intJakojaannos

      Dim strTarkiste As String

      If intErotus < 10 Then
        strTarkiste = "0" & intErotus.ToString()
      Else
        strTarkiste = intErotus.ToString()
      End If

      Return "FI" & strTarkiste & strKoneKielinenTilinro

    End If

    Return String.Empty

  End Function

  Public Shared Function MuunnaKonekieliseenMuotoon(tilinumero As String) As String

    'ryhmät tilinumeron ensimmäisen numeron mukaan
    Dim arrRyhma1 As Char() = {"1", "2", "3", "6", "8"}
    Dim arrRyhma2 As Char() = {"4", "5"}

    Dim lstChars As New List(Of Char)()

    tilinumero = tilinumero.Replace("-", "")

    lstChars = tilinumero.ToCharArray().ToList()

    'eka numero talteen
    Dim cEkaNro As Char = lstChars(0)

    'indexi, joka määrittää mihin extranollat syötetään
    Dim intNollaIndex As Integer

    'nollaindeksi määräytyy ekan numeron mukaan
    If arrRyhma1.Contains(cEkaNro) Then
      'ryhmä 1, nollat syötetään heti väliviivan jälkeen
      intNollaIndex = 6
    ElseIf arrRyhma2.Contains(cEkaNro) Then
      'ryhmä 2, nollat syötetään väliviivaa seuraavan numeron jälkeen
      intNollaIndex = 7
    End If

    'syötetään nollia oikeaan välikköön niin paljon, että numeroita tulee yhteensä 14
    For i As Integer = 1 To 14 - lstChars.Count
      lstChars.Insert(intNollaIndex, "0")
    Next

    Return New String(lstChars.ToArray())

  End Function

    <Obsolete>
    Public Shared Function HaeRahalaitosTunnus(tilinumero As String) As String

    If OnIbanTilinumero(tilinumero) Then
      tilinumero = Right(tilinumero, tilinumero.Length - 4)
    End If

    For Each s As String In RahalaitosTunnukset
      If tilinumero.StartsWith(s) Then
        Return s
      End If
    Next

    Return String.Empty

  End Function

  Public Shared ReadOnly Property Taulukko1 As Dictionary(Of String, Integer)
    Get

      Dim dicTaulukko1 As New Dictionary(Of String, Integer)()

      dicTaulukko1.Add("A", 10)
      dicTaulukko1.Add("B", 11)
      dicTaulukko1.Add("C", 12)
      dicTaulukko1.Add("D", 13)
      dicTaulukko1.Add("E", 14)
      dicTaulukko1.Add("F", 15)
      dicTaulukko1.Add("G", 16)
      dicTaulukko1.Add("H", 17)
      dicTaulukko1.Add("I", 18)
      dicTaulukko1.Add("J", 19)
      dicTaulukko1.Add("K", 20)
      dicTaulukko1.Add("L", 21)
      dicTaulukko1.Add("M", 22)
      dicTaulukko1.Add("N", 23)
      dicTaulukko1.Add("O", 24)
      dicTaulukko1.Add("P", 25)
      dicTaulukko1.Add("Q", 26)
      dicTaulukko1.Add("R", 27)
      dicTaulukko1.Add("S", 28)
      dicTaulukko1.Add("T", 29)
      dicTaulukko1.Add("U", 30)
      dicTaulukko1.Add("V", 31)
      dicTaulukko1.Add("W", 32)
      dicTaulukko1.Add("X", 33)
      dicTaulukko1.Add("Y", 34)
      dicTaulukko1.Add("Z", 35)

      Return dicTaulukko1

    End Get
  End Property

    <Obsolete>
    Public Shared ReadOnly Property RahalaitosTunnukset As String()
    Get

      Dim arrTunnukset As String() = { _
                                      "713", _
                                      "8", _
                                      "34", _
                                      "37", _
                                      "31", _
                                      "715", _
                                      "1", _
                                      "2", _
                                      "5", _
                                      "33", _
                                      "39", _
                                      "38", _
                                      "4", _
                                      "36", _
                                      "6" _
                                      }

      Return arrTunnukset

    End Get
  End Property

End Class
