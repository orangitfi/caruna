Imports System.IO

Public Class KorvaushinnastoTuonti
  Inherits System.Web.UI.Page

  Private _sopimustyypit As Dictionary(Of String, Integer)
  Private _yksikot As Dictionary(Of String, Integer)
  Private _metsatyypit As Dictionary(Of String, Integer)
  Private _puustolajit As Dictionary(Of String, Integer)
  Private _hinnastokategoriat As Dictionary(Of String, Integer)
  Private _hinnastoalakategoriat As Dictionary(Of String, Integer)
  Private _maksualueet As Dictionary(Of String, Integer)

  Private Function parsiDecimaali(str As String) As Decimal?

    Dim tulos As Decimal
    If Decimal.TryParse(str, tulos) Then
      Return tulos
    End If
    Return Nothing
  End Function

  Private Function parsiBooli(str As String) As Boolean
    If (str = "Kyllä") Then Return True
    Return False
  End Function

  Private Class KorvaushinnastoFormattiVirhe
    Inherits Exception
    Public Sub New(msg As String)
      MyBase.New(msg)
    End Sub
  End Class

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Private Sub haeAputaulut()

    Dim aputauluKanta = New BLL.Haku()
    _sopimustyypit = aputauluKanta.HaeSopimusTyypit().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)
    _yksikot = aputauluKanta.HaeYksikot().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)
    _metsatyypit = aputauluKanta.HaeMetsatyypit().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)
    _puustolajit = aputauluKanta.HaePuustolajit().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)
    _hinnastokategoriat = aputauluKanta.HaeHinnastonKategoriat().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)
    _hinnastoalakategoriat = aputauluKanta.HaeHinnastonAlakategoriat().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)
    _maksualueet = aputauluKanta.HaeMaksualueet().ToDictionary(Function(x) x.Nimi.Trim(), Function(x) x.ID)

  End Sub

  Private Function HaeID(rivi As Integer, otsake As String, aputaulu As Dictionary(Of String, Integer), nimi As String) As Integer?
    If String.IsNullOrEmpty(nimi) Then
      Return Nothing
    End If

    If Not aputaulu.ContainsKey(nimi) Then
      Throw New KorvaushinnastoFormattiVirhe("Rivin " & rivi & " sarakkeen " & otsake & " tietoa " & nimi & " ei löydy järjestelmästä")
    End If

    Return aputaulu(nimi)
  End Function

  Private Function LuoRivi(rivinro As Integer, headerinSarakkeet As List(Of String), rivinSarakkeet As List(Of String)) As DTO.Korvaushinnasto

    If rivinSarakkeet.All(Function(x) String.IsNullOrWhiteSpace(x)) Then Return Nothing

    If rivinSarakkeet.Count >= 14 Then

      Dim riviDTO = New DTO.Korvaushinnasto()
      riviDTO.Luoja = Context.User.Identity.Name
      riviDTO.Luotu = Date.Now
      riviDTO.Paivittaja = riviDTO.Luoja
      riviDTO.Paivitetty = riviDTO.Luotu

      riviDTO.Aktiivinen = parsiBooli(rivinSarakkeet(0))
      Dim ajat As String() = rivinSarakkeet(1).Split("-")
      If ajat.Length > 0 Then
        riviDTO.Alkupvm = Paivaykset.PalautaPaivays(ajat(0))
      End If
      If ajat.Length > 1 Then
        riviDTO.Loppupvm = Paivaykset.PalautaPaivays(ajat(1))
      End If
      riviDTO.HinnastoKategoriaId = HaeID(rivinro, headerinSarakkeet(2), _hinnastokategoriat, rivinSarakkeet(2))
      riviDTO.HinnastoAlakategoriaId = HaeID(rivinro, headerinSarakkeet(3), _hinnastoalakategoriat, rivinSarakkeet(3))
      riviDTO.Korvauslaji = rivinSarakkeet(4)
      riviDTO.Kuvaus = rivinSarakkeet(5)
      riviDTO.MaksuAlueId = HaeID(rivinro, headerinSarakkeet(6), _maksualueet, rivinSarakkeet(6))
      riviDTO.MetsatyyppiId = HaeID(rivinro, headerinSarakkeet(7), _metsatyypit, rivinSarakkeet(7))
      riviDTO.PuustolajiId = HaeID(rivinro, headerinSarakkeet(8), _puustolajit, rivinSarakkeet(8))
      riviDTO.PuustonIka = parsiDecimaali(rivinSarakkeet(9))
      riviDTO.TaimistonValtapituus = parsiDecimaali(rivinSarakkeet(10))
      riviDTO.Tiheyskerroin = parsiDecimaali(rivinSarakkeet(11))
      riviDTO.Yksikkohinta = parsiDecimaali(rivinSarakkeet(12))
      riviDTO.YksikkoId = HaeID(rivinro, headerinSarakkeet(13), _yksikot, rivinSarakkeet(13).Replace("€/", "").Trim())
      riviDTO.YksikkohinnanTarkenne = rivinSarakkeet(14)
      If rivinSarakkeet.Count = 15 Then Return riviDTO

      riviDTO.SopimustyyppiId = HaeID(rivinro, headerinSarakkeet(15), _sopimustyypit, rivinSarakkeet(15))
      If rivinSarakkeet.Count = 16 Then Return riviDTO

      riviDTO.Info = rivinSarakkeet(16)
      If rivinSarakkeet.Count = 17 Then Return riviDTO

      riviDTO.ArvonPeruste = rivinSarakkeet(17)

      Return riviDTO

    Else

      Throw New KorvaushinnastoFormattiVirhe("Rivillä " & rivinro & " puuttuu sarakkeita")

    End If

  End Function

  Private Function GetSheetName(ByVal connString As String) As String
    '19.11.2008 Janne Hakkarainen

    'luodaan oledb-yhteys
    Dim conn As New OleDb.OleDbConnection(connString)
    Dim myDt As DataTable
    Dim sheet As String = ""
    Try
      'avataan yhteys
      conn.Open()
      'haetaan tiedoston taulut(välilehdet)
      myDt = conn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
      If myDt.Rows.Count > 0 Then
        'otetaan ensimmäisen välilehden nimi ylös
        sheet = myDt.Rows(0)("TABLE_NAME").ToString
      End If
      'suljetaan yhteys
      conn.Close()
    Catch
      'jos sattui virhe ja yhteys jäi päälle, suljetaan se
      If conn.State <> ConnectionState.Closed Then conn.Close()
    End Try
    Return sheet
  End Function

  Private Function HaeLisattavatExcel() As List(Of DTO.Korvaushinnasto)

    Dim tulos As New List(Of DTO.Korvaushinnasto)

    Dim strFilename As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
    Dim strFileDirectory As String = Server.MapPath(".") & "\import\siirtotiedostot\"
    Dim strFilepath As String = strFileDirectory & strFilename

    If Not Directory.Exists(strFileDirectory) Then Directory.CreateDirectory(strFileDirectory)
    FileUpload1.SaveAs(strFilepath)

    ' tiedonsiirto tauluun
    Dim ExcelConnString As String = ConfigurationManager.ConnectionStrings("ExcelConnectionString").ConnectionString
    ' korjataan fyysinen polku tiedostoon
    ExcelConnString = ExcelConnString.Replace("_POLKU_", strFilepath)
    ' excel-sheetin nimi
    Dim excelSheet As String = GetSheetName(ExcelConnString)
    ' yhteydet ja siirto
    Dim myConn As New OleDb.OleDbConnection(ExcelConnString)

    Dim intCount As Integer = 0

    Dim headerit As New List(Of String)
    headerit.Add("Active")
    headerit.Add("Voimassaoloaika")
    headerit.Add("Kategoria")
    headerit.Add("Alakategoria")
    headerit.Add("Korvauslaji")
    headerit.Add("Kuvaus")
    headerit.Add("Maksualue")
    headerit.Add("Metsätyyppi")
    headerit.Add("Puustolaji")
    headerit.Add("Puuston ikä")
    headerit.Add("Taimiston valtapituus")
    headerit.Add("Tiheyskerroin")
    headerit.Add("Yksikköhinta")
    headerit.Add("Korvausyksikkö")
    headerit.Add("Yksikköhinnan tarkenne")
    headerit.Add("Sopimustyyppi")
    headerit.Add("Lisätieto")
    headerit.Add("Arvon peruste")

    Try
      myConn.Open()
      Dim strSQL As String
      strSQL = "SELECT * " & _
               "FROM [" & excelSheet & "];"

      Dim myComm As OleDb.OleDbCommand = New OleDb.OleDbCommand(strSQL, myConn)

      Dim myR As Data.OleDb.OleDbDataReader = myComm.ExecuteReader

      Dim rivinro As Integer = 1
      Dim rivi As List(Of String)

      While myR.Read()
        rivi = New List(Of String)
        For i As Integer = 0 To headerit.Count - 1
          rivi.Add(myR(headerit(i)).ToString().Trim())
        Next
        Dim riviTulos As DTO.Korvaushinnasto = LuoRivi(rivinro, headerit, rivi)
        If Not IsNothing(riviTulos) Then
          tulos.Add(riviTulos)
          rivinro += 1
        End If
      End While

      myConn.Close()

    Catch ex As Exception
      If myConn.State <> ConnectionState.Closed Then myConn.Close()
      Throw New KorvaushinnastoFormattiVirhe("Tiedoston avaus ei onnistunut: " & ex.Message)
    End Try

    Return tulos
  End Function

  Protected Sub btnLataa_Click(sender As Object, e As EventArgs) Handles btnLataa.Click
    Dim lisattavat As List(Of DTO.Korvaushinnasto)

    haeAputaulut()

    Try
      lisattavat = HaeLisattavatExcel()
    Catch virhe As KorvaushinnastoFormattiVirhe
      lblInfo.Text = "Korvaushinnastojen tuonti ei onnistunut. Tarkista tiedosto: " & virhe.Message
      lblInfo.Visible = True
      Return
    End Try

    Dim tietokanta As New BLL.Korvaushinnasto()

    tietokanta.PassivoiKaikki()
    tietokanta.LisaaKorvaushinnastot(lisattavat)
    lblInfo.Text = lisattavat.Count & " korvaushinnastoa tuotu."
    lblInfo.Visible = True
  End Sub

End Class