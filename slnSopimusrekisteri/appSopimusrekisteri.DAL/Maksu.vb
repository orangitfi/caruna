Imports appSopimusrekisteri.Entities
Imports System.Data.SqlTypes
Imports System.Transactions
Imports appSopimusrekisteri.DTO

Partial Public Class Maksu

  Private _konteksti As DTO.DataKonteksti

  Public Sub New()

  End Sub

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

  Public Sub PassivoiMaksu(maksuId As Integer)

    Using tietokanta As New Entities.FortumEntities()

      tietokanta.Maksu.First(Function(x) x.MAKId = maksuId).MAKPassivoitu = 1

      tietokanta.SaveChanges()

    End Using

  End Sub

  Public Function HaeMaksu(id As Integer) As Entities.Maksu

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Maksu.FirstOrDefault(Function(x) x.MAKId = id)

    End Using

  End Function

  Public Function HaeMaksut(sopimusId As Integer) As List(Of Entities.Maksu)

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmat = tietokanta.Korvauslaskelma.Where(Function(x) x.KORSopimusId = sopimusId).Select(Function(x) x.KORId)
      Dim maksut = tietokanta.Maksu.Where(Function(x) korvauslaskelmat.Contains(x.MAKKorvauslaskelmaId) And x.MAKPassivoitu = False)
      Return maksut.OrderBy(Function(x) x.MAKKorvauslaskelmaId).ToList()

    End Using

  End Function

  Public Function HaeMaksuaineistonMaksut(maksuaineistoId As Integer) As Entities.Maksu

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Maksu.Where(Function(x) x.MAKMaksuaineistoId = maksuaineistoId And x.MAKPassivoitu = False)

    End Using

  End Function

  Public Function LisaaMaksu(maksu As DTO.Maksu) As DTO.Maksu

    Return Me.LisaaMaksut({maksu}.ToList()).First()

  End Function

  Public Function LisaaMaksut(maksut As List(Of DTO.Maksu)) As List(Of DTO.Maksu)

    Dim lisattavat As List(Of Entities.Maksu) = Konversiot.Maksu.MuutaDBOksi(maksut)

    Using tietokanta As New Entities.FortumEntities()

      For Each maksu As Entities.Maksu In lisattavat

        tietokanta.Maksu.Add(maksu)

      Next

      tietokanta.SaveChanges()

    End Using

    Return Konversiot.Maksu.MuutaDTOksi(lisattavat)

  End Function

  'Public Function LuoMaksuaineisto(korvaustyyppiId As Integer) As List(Of DTO.Maksuaineisto)

  '  Dim maksuaineistot = New List(Of DTO.Maksuaineisto)

  '  Using tietokanta As New Entities.FortumEntities()

  '    Using transaktio As New Transactions.TransactionScope()

  '      ' Luodaan maksuaineisto ja saadaan yhteinen 
  '      ' tunniste siihen liittyvälle materiaalille. 
  '      Dim maksuaineisto = UusiMaksuaineisto()
  '      Dim kirjanpito = New KirjanpidonAineisto()
  '      Try ' Vevy vevy quietly for now...
  '        kirjanpito.LuoKirjanpidonAineisto(maksuaineisto.MAIId)
  '      Catch ex As Exception
  '      End Try

  '      Try

  '        For Each korvauslaskelma As Entities.Korvauslaskelma In HaeMaksuaineistonKorvauslaskelmat(tietokanta, korvaustyyppiId)

  '          korvauslaskelma.KORKorvauslaskelmaStatusId = 4
  '          korvauslaskelma.KORViimeisinMaksuPvm = DateTime.Today
  '          Dim maksu = LuoMaksuobjektit(maksuaineisto.MAIId, korvauslaskelma)
  '          Dim maksut = MuunnaMaksuaineistoksi(maksu)
  '          ' -----------------------------------------------
  '          If Not korvauslaskelma.Taho Is Nothing Then
  '            maksut.Saaja = korvauslaskelma.Taho.TAHEtunimi + " " + korvauslaskelma.Taho.TAHSukunimi
  '          Else
  '            maksut.Saaja = "Ei saajaa"
  '          End If
  '          ' -----------------------------------------------
  '          Try ' Vevy vevy quietly for now...
  '            kirjanpito.LuoKirjanpidonAineistonRivi(maksuaineisto.MAIId, maksut)
  '          Catch ex As Exception
  '          End Try
  '          ' -----------------------------------------------
  '          maksuaineistot.Add(maksut)
  '          tietokanta.Maksu.Add(maksu)

  '        Next

  '        tietokanta.SaveChanges()
  '        transaktio.Complete()

  '      Catch ex As Exception

  '        Throw

  '      End Try

  '    End Using

  '  End Using

  '  Return maksuaineistot

  'End Function

  Private Function HaeMaksuaineistonKorvauslaskelmat(tietokanta As Entities.FortumEntities, korvaustyyppiId As Integer) As IEnumerable(Of Entities.Korvauslaskelma)

    Dim korvauslaskelmat = tietokanta.Korvauslaskelma _
    .Include("Taho") _
    .Include("KorvauslaskelmaRivi") _
    .Where(Function(x) _
               (x.KORViite <> String.Empty Or x.KORViesti <> String.Empty) And _
               x.KorvauslaskelmaRivi.Any(Function(y) y.KLRKorvaus > 0) And
               x.Taho.TAHSukunimi <> String.Empty And _
               x.Taho.TAHTilinumero <> String.Empty And _
               x.Taho.TAHBic <> String.Empty And _
               x.KORKorvaustyyppiId = korvaustyyppiId And _
               x.KORKorvauslaskelmaStatusId = 2)

    Return korvauslaskelmat

  End Function

  Public Function TuoMaksuaineisto(maksuaineisto As List(Of DTO.MaksuaineistonTuonti)) As DTO.Palautusarvo

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 10, 0))

        Dim palautusarvo = New Palautusarvo()
        palautusarvo.Tiedot = New List(Of MaksuaineistonTuonti)

        For Each maksu As MaksuaineistonTuonti In maksuaineisto

          Dim korvauslaskelmat = tietokanta.Korvauslaskelma.Where(Function(x) x.Sopimus.SOPPCSNumero = maksu.Projectno Or x.KORKorvauksenProjektinumero = maksu.Projectno)

          For Each korvauslaskelma As Entities.Korvauslaskelma In korvauslaskelmat

            Try

              korvauslaskelma.KOREnsimmainenSallittuMaksuPvm = maksu.FieldWorkStartedA
              korvauslaskelma.KORProjectno = maksu.Projectno
              korvauslaskelma.KORName = maksu.Name
              korvauslaskelma.KORTypeOfProject = maksu.TypeOfProject
              korvauslaskelma.KORType = maksu.Type
              korvauslaskelma.KOROwner = maksu.Owner
              korvauslaskelma.KORConcession = maksu.Concession
              korvauslaskelma.KORCertDate = maksu.CertDate
              korvauslaskelma.KORFieldWorkStarted = maksu.FieldWorkStartedA
              korvauslaskelma.KORProjectClosedA = maksu.ProjectClosedA
              korvauslaskelma.KORPaivitetty = Date.Now
              korvauslaskelma.KORPaivittaja = _konteksti.Kayttajatunnus

            Catch ex As Exception

              Dim virhe = New Virhe()
              virhe.Data = maksu
              virhe.Virhe = ex
              palautusarvo.Virheet.Add(virhe)

            End Try

          Next

        Next

        tietokanta.SaveChanges()

        transaktio.Complete()
        Return palautusarvo

      End Using

    End Using

  End Function

  ' HUOM: Semanttisia virheitä ei enää pitäisi tapahtua täällä (saaja puuttuu, tilinumero puuttuu tms.)
  Private Function LuoMaksuobjektit(eratunniste As String, korvauslaskelma As Entities.Korvauslaskelma) As Entities.Maksu

    Dim maksu = New Entities.Maksu()
    maksu.MAKSumma = 0
    maksu.MAKMaksuaineistoId = eratunniste
    ' --------------------------------
    maksu.MAKKorvauslaskelmaId = korvauslaskelma.KORId
    maksu.MAKAjoPvm = DateTime.Today
    maksu.MAKEraTunniste = eratunniste.PadLeft(19, "0")
    maksu.MAKIndeksi = ""
    maksu.MAKIndeksiKuukausiId = DateTime.Now.Month
    maksu.MAKInfo = ""
    maksu.MAKKirjanpidonTiliId = Nothing
    maksu.MAKKustannuspaikka = ""
    maksu.MAKLaskunNumero = ""
    maksu.MAKMaksuStatusId = 1 ' Maksetaan
    maksu.MAKMaksupaiva = Nothing ' Käyttöliittymästä
    maksu.MAKVero = Nothing
    maksu.MAKViite = korvauslaskelma.KORViite
    maksu.MAKViesti = If(String.IsNullOrWhiteSpace(korvauslaskelma.KORViite), korvauslaskelma.KORViesti, String.Empty)
    maksu.MAKVuosi = DateTime.Now.Year
    maksu.MAKPassivoitu = False
    ' --------------------------------
    If korvauslaskelma.Taho Is Nothing Then
      maksu.MAKTilinumero = "Saaja puuttuu"
      maksu.MAKBic = "Saaja puuttuu"
    Else
      If String.IsNullOrWhiteSpace(korvauslaskelma.Taho.TAHTilinumero) Then
        maksu.MAKTilinumero = "Tilinumero puuttuu"
      Else
        maksu.MAKTilinumero = korvauslaskelma.Taho.TAHTilinumero
      End If

      If String.IsNullOrWhiteSpace(korvauslaskelma.Taho.TAHBic) Then
        maksu.MAKBic = "BIC puuttuu"
      Else
        maksu.MAKBic = korvauslaskelma.Taho.TAHBic
      End If

    End If
    ' --------------------------------
    For Each korvauslaskelmanRivi In korvauslaskelma.KorvauslaskelmaRivi
      maksu.MAKSumma += korvauslaskelmanRivi.KLRKorvaus
    Next
    ' --------------------------------
    maksu.MAKLuoja = "Tuntematon"
    maksu.MAKPaivittaja = "Tuntematon"
    maksu.MAKLuotu = SqlDateTime.MinValue 'sopimus.MAKLuotu
    maksu.MAKPaivitetty = DateTime.Now
    ' --------------------------------

    Return maksu

  End Function


End Class
