Imports System.Data.SqlTypes
Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO
Imports LinqKit
Imports Enumerable = System.Linq.Enumerable

Partial Public Class Korvauslaskelma

#Region "Hakumetodit"

  Public Function HaeHinta(korvaushinnastoId As Integer) As Decimal

    Using tietokanta As New Entities.FortumEntities()

      Dim korvaushinnasto = tietokanta.KorvausHinnasto.FirstOrDefault(Function(x) x.KHIId = korvaushinnastoId)
      If Not korvaushinnasto Is Nothing Then
        If Not korvaushinnasto.KHIYksikkkohinta Is Nothing Then
          Return korvaushinnasto.KHIYksikkkohinta
        End If
      End If

      Return 0

    End Using

  End Function

  Public Function HaeKorvauslaskelmat(hakuehdot As Expressions.Expression(Of Func(Of Entities.Korvauslaskelma, Boolean))) As List(Of iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit As IEnumerable(Of Tietotyyppi.Korvauslaskelma)

      If hakuehdot Is Nothing Then
        rivit = tietokanta.Korvauslaskelma.Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      Else
        rivit = tietokanta.Korvauslaskelma.AsExpandable().Where(hakuehdot).Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
      End If

      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

  Public Function HaeSopimuksenKorvauslaskelmat(sopimusId As Integer) As List(Of DTO.Korvauslaskelma)

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmat = New List(Of DTO.Korvauslaskelma)
      Dim sopimuksenKorvauslaskelmat = tietokanta.Korvauslaskelma _
                                       .Include("Taho") _
                                       .Include("KorvauslaskelmaRivi") _
                                       .Where(Function(x) x.KORSopimusId = sopimusId)

      Dim korvauslaskelma As DTO.Korvauslaskelma

      For Each sopimuksenKorvauslaskelma As Entities.Korvauslaskelma In sopimuksenKorvauslaskelmat

        korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(sopimuksenKorvauslaskelma)

        If Not sopimuksenKorvauslaskelma.Taho Is Nothing Then
          korvauslaskelma.Saaja = Konversiot.Taho.MuutaDTOksi(sopimuksenKorvauslaskelma.Taho)
        End If

        korvauslaskelmat.Add(korvauslaskelma)

      Next

      Return korvauslaskelmat

    End Using

  End Function

  Public Function HaeKorvauslaskelma(id As Integer) As Entities.Korvauslaskelma

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmat As Tietotyyppi.Korvauslaskelma
      korvauslaskelmat = Enumerable.FirstOrDefault(tietokanta.Korvauslaskelma, Function(x) x.KORId = id)
      Return korvauslaskelmat

    End Using

  End Function

  Public Function HaeKorvauslaskelmaDTO(id As Integer) As DTO.Korvauslaskelma

    Using tietokanta As New Entities.FortumEntities()

      Dim haettava As Entities.Korvauslaskelma
      haettava = Enumerable.FirstOrDefault(tietokanta.Korvauslaskelma, Function(x) x.KORId = id)

      Dim korvauslaskelma As DTO.Korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava)

      If Not haettava.Sopimus Is Nothing Then
        korvauslaskelma.Sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava.Sopimus)
      End If

      If Not haettava.Taho Is Nothing Then
        korvauslaskelma.Saaja = Konversiot.Taho.MuutaDTOksi(haettava.Taho)
      End If

      korvauslaskelma.Rivit = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava.KorvauslaskelmaRivi)

      Return korvauslaskelma

    End Using

  End Function

  Public Function HaeKorvauslaskelmatDTO(id As IEnumerable(Of Integer)) As IEnumerable(Of DTO.Korvauslaskelma)

    Using tietokanta As New Entities.FortumEntities()

      Dim haettava As IEnumerable(Of Entities.Korvauslaskelma)
      haettava = Enumerable.Where(tietokanta.Korvauslaskelma, Function(x) id.Contains(x.KORId))

      Dim tulos As New List(Of DTO.Korvauslaskelma)
      For Each laskelma In haettava
        Dim korvauslaskelma As DTO.Korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(laskelma)

        If Not laskelma.Sopimus Is Nothing Then
          korvauslaskelma.Sopimus = Konversiot.Sopimus.MuutaDTOksi(laskelma.Sopimus)
        End If

        If Not laskelma.Taho Is Nothing Then
          korvauslaskelma.Saaja = Konversiot.Taho.MuutaDTOksi(laskelma.Taho)
        End If

        korvauslaskelma.Rivit = Konversiot.Korvauslaskelma.MuutaDTOksi(laskelma.KorvauslaskelmaRivi)

        tulos.Add(korvauslaskelma)
      Next

      Return tulos
    End Using

  End Function

  Public Function HaeKorvauslaskelmanRivit(korvauslaskelmaId As Integer) As List(Of DTO.KorvauslaskelmanRivi)

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmat As IEnumerable(Of Entities.KorvauslaskelmaRivi)
      korvauslaskelmat = tietokanta.KorvauslaskelmaRivi.Include("KorvausHinnasto.hlp_Yksikko").Where(Function(x) x.KLRKorvauslaskelmaId = korvauslaskelmaId)
      Return Konversiot.Korvauslaskelma.MuutaDTOksi(korvauslaskelmat)

    End Using

  End Function

  Public Function HaeKorvauslaskelmanRivi(id As Integer) As DTO.KorvauslaskelmanRivi

    Using tietokanta As New Entities.FortumEntities()

      Dim haettava As Entities.KorvauslaskelmaRivi

      haettava = tietokanta.KorvauslaskelmaRivi.Include("KorvausHinnasto.hlp_Yksikko").FirstOrDefault(Function(x) x.KLRId = id)

      Dim korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi

      korvauslaskelmanRivi = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava)

      If Not haettava.Korvauslaskelma Is Nothing Then
        korvauslaskelmanRivi.Korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava.Korvauslaskelma)
      End If

      Return korvauslaskelmanRivi

    End Using

  End Function

  Public Function HaeMaksettavatKorvauslaskelmatKertakorvaus() As List(Of DTO.Korvauslaskelma)

    Using tietokanta As New Entities.FortumEntities()

      Dim haettavat As IEnumerable(Of Entities.Korvauslaskelma)
            haettavat = tietokanta.Korvauslaskelma _
      .Include("KorvauslaskelmaRivi") _
      .Include("Taho") _
      .Include("Sopimus") _
      .Where(Function(x) _
                 (x.KORKorvauslaskelmaStatusId = DTO.Enumeraattorit.KorvauslaskelmaStatus.Hyvaksytty) _
                 And x.KOREnsimmainenSallittuMaksuPvm <= Date.Now _
                 And (x.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.VerkonhaltijaSuorittaaKorvauksen Or x.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.AsiakkaanLahettamaLaskuTosite) _
                 And x.Sopimus.SOPLuonnos = False _
                 And (x.Sopimus.SOPSopimuksenTilaId = DTO.Enumeraattorit.SopimuksenTila.Voimassa) _
                 And (Not x.Sopimus.SOPIrtisanomispvm.HasValue OrElse x.Sopimus.SOPIrtisanomispvm > Date.Now) _
                 And x.KORKorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus _
                 And (Not x.KORMaksuKuukausiId.HasValue Or x.KORMaksuKuukausiId = Date.Now.Month))

            Dim korvauslaskelmat As New List(Of DTO.Korvauslaskelma)()

      For Each haettava As Entities.Korvauslaskelma In haettavat

        Dim korvauslaskelma As DTO.Korvauslaskelma

        korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava)

        If Not haettava.Taho Is Nothing Then
          korvauslaskelma.Saaja = Konversiot.Taho.MuutaDTOksi(haettava.Taho)
        End If

        If Not haettava.Sopimus Is Nothing Then
          korvauslaskelma.Sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava.Sopimus)

          If Not haettava.Sopimus.Taho1 Is Nothing Then
            korvauslaskelma.Sopimus.JuridinenYhtio = Konversiot.Taho.MuutaDTOksi(haettava.Sopimus.Taho1)
          End If

        End If

        If Not haettava.KorvauslaskelmaRivi Is Nothing Then
          korvauslaskelma.Rivit = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava.KorvauslaskelmaRivi)
        End If

        korvauslaskelmat.Add(korvauslaskelma)

      Next


      Return korvauslaskelmat

    End Using

  End Function

  Public Function HaeMaksettavatKorvauslaskelmatVuosimaksu() As List(Of DTO.Korvauslaskelma)

    Using tietokanta As New Entities.FortumEntities()

      Dim kuluvaPaiva As Date = Date.Now.Date

      Dim haettavat As IEnumerable(Of Entities.Korvauslaskelma)
            haettavat = tietokanta.Korvauslaskelma _
      .Include("KorvauslaskelmaRivi") _
      .Include("Taho") _
      .Include("Sopimus") _
      .Where(Function(x) _
                 (x.KORKorvauslaskelmaStatusId = DTO.Enumeraattorit.KorvauslaskelmaStatus.Hyvaksytty) _
                 And x.KOREnsimmainenSallittuMaksuPvm <= Date.Now _
                 And (x.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.VerkonhaltijaSuorittaaKorvauksen Or x.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.AsiakkaanLahettamaLaskuTosite) _
                 And x.Sopimus.SOPLuonnos = False _
                 And (x.Sopimus.SOPSopimuksenTilaId = DTO.Enumeraattorit.SopimuksenTila.Voimassa) _
                 And (Not x.Sopimus.SOPIrtisanomispvm.HasValue OrElse x.Sopimus.SOPIrtisanomispvm > Date.Now) _
                 And x.KORMaksuKuukausiId = Date.Now.Month _
                 And x.KORKorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Vuosimaksu _
                 And (Not x.KORViimeisinMaksuPvm.HasValue Or x.KORViimeisinMaksuPvm.Value.Year < Date.Now.Year) _
                 And (Not x.KORViimeinenMaksuPvm.HasValue Or x.KORViimeinenMaksuPvm >= kuluvaPaiva)
                 )

            Dim korvauslaskelmat As New List(Of DTO.Korvauslaskelma)()

      For Each haettava As Entities.Korvauslaskelma In haettavat

        Dim korvauslaskelma As DTO.Korvauslaskelma

        korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava)

        If Not haettava.Taho Is Nothing Then
          korvauslaskelma.Saaja = Konversiot.Taho.MuutaDTOksi(haettava.Taho)
        End If

        If Not haettava.Sopimus Is Nothing Then
          korvauslaskelma.Sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava.Sopimus)

          If Not haettava.Sopimus.Taho1 Is Nothing Then
            korvauslaskelma.Sopimus.JuridinenYhtio = Konversiot.Taho.MuutaDTOksi(haettava.Sopimus.Taho1)
          End If

        End If

        If Not haettava.KorvauslaskelmaRivi Is Nothing Then
          korvauslaskelma.Rivit = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava.KorvauslaskelmaRivi)
        End If

        korvauslaskelmat.Add(korvauslaskelma)

      Next


      Return korvauslaskelmat

    End Using

  End Function

  Public Function HaeMaksettavatKorvauslaskelmatKuukausivuokra() As List(Of DTO.Korvauslaskelma)

    Using tietokanta As New Entities.FortumEntities()

      Dim kuluvaPaiva As Date = Date.Now.Date

      Dim haettavat As IEnumerable(Of Entities.Korvauslaskelma)
            haettavat = tietokanta.Korvauslaskelma _
      .Include("KorvauslaskelmaRivi") _
      .Include("Taho") _
      .Include("Sopimus") _
      .Where(Function(x) _
                 (x.KORKorvauslaskelmaStatusId = DTO.Enumeraattorit.KorvauslaskelmaStatus.Hyvaksytty) _
                 And x.KOREnsimmainenSallittuMaksuPvm <= Date.Now _
                 And (x.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.VerkonhaltijaSuorittaaKorvauksen Or x.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.AsiakkaanLahettamaLaskuTosite) _
                 And x.Sopimus.SOPLuonnos = False _
                 And (x.Sopimus.SOPSopimuksenTilaId = DTO.Enumeraattorit.SopimuksenTila.Voimassa) _
                 And (Not x.Sopimus.SOPIrtisanomispvm.HasValue OrElse x.Sopimus.SOPIrtisanomispvm > Date.Now) _
                 And x.KORKorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kuukausivuokra _
                 And (Not x.KORViimeisinMaksuPvm.HasValue Or x.KORViimeisinMaksuPvm.Value.Month < Date.Now.Month) _
                 And (Not x.KORViimeinenMaksuPvm.HasValue Or x.KORViimeinenMaksuPvm >= kuluvaPaiva)
                 )

            Dim korvauslaskelmat As New List(Of DTO.Korvauslaskelma)()

      For Each haettava As Entities.Korvauslaskelma In haettavat

        Dim korvauslaskelma As DTO.Korvauslaskelma

        korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava)

        If Not haettava.Taho Is Nothing Then
          korvauslaskelma.Saaja = Konversiot.Taho.MuutaDTOksi(haettava.Taho)
        End If

        If Not haettava.Sopimus Is Nothing Then
          korvauslaskelma.Sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava.Sopimus)

          If Not haettava.Sopimus.Taho1 Is Nothing Then
            korvauslaskelma.Sopimus.JuridinenYhtio = Konversiot.Taho.MuutaDTOksi(haettava.Sopimus.Taho1)
          End If

        End If

        If Not haettava.KorvauslaskelmaRivi Is Nothing Then
          korvauslaskelma.Rivit = Konversiot.Korvauslaskelma.MuutaDTOksi(haettava.KorvauslaskelmaRivi)
        End If

        korvauslaskelmat.Add(korvauslaskelma)

      Next


      Return korvauslaskelmat

    End Using

  End Function

  Public Function HaeMaksettavatKorvauslaskelmarivit() As List(Of DTO.KorvauslaskelmanRivi)

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmarivit = tietokanta.KorvauslaskelmaRivi _
      .Include("Korvauslaskelma") _
      .Include("Korvauslaskelma.Taho") _
      .Include("Korvauslaskelma.Sopimus") _
      .Where(Function(x) _
                 (x.Korvauslaskelma.KORKorvauslaskelmaStatusId = DTO.Enumeraattorit.KorvauslaskelmaStatus.Hyvaksytty) _
                 And x.Korvauslaskelma.KOREnsimmainenSallittuMaksuPvm <= Date.Now _
                 And (x.Korvauslaskelma.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.VerkonhaltijaSuorittaaKorvauksen Or x.Korvauslaskelma.KORMaksunSuoritusId = DTO.Enumeraattorit.MaksunSuoritus.AsiakkaanLahettamaLaskuTosite))

      Return Konversiot.Korvauslaskelma.MuutaDTOksi(korvauslaskelmarivit)

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaKorvauslaskelma(korvauslaskelma As Entities.Korvauslaskelma) As Entities.Korvauslaskelma

    If korvauslaskelma Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Try

        korvauslaskelma.KOREnsimmainenSallittuMaksuPvm = If(korvauslaskelma.KOREnsimmainenSallittuMaksuPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KOREnsimmainenSallittuMaksuPvm)
        korvauslaskelma.KORIndeksiVuosi = If(korvauslaskelma.KORIndeksiVuosi = 0 Or korvauslaskelma.KORIndeksiVuosi Is Nothing, Nothing, korvauslaskelma.KORIndeksiVuosi)
        korvauslaskelma.KORNykyinenIndeksiArvo = If(korvauslaskelma.KORNykyinenIndeksiArvo = 0 Or korvauslaskelma.KORNykyinenIndeksiArvo Is Nothing, Nothing, korvauslaskelma.KORNykyinenIndeksiArvo)
        korvauslaskelma.KORVanhaSopimusPaattyyiPvm = If(korvauslaskelma.KORVanhaSopimusPaattyyiPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KORVanhaSopimusPaattyyiPvm)
        korvauslaskelma.KORViimeinenMaksuPvm = If(korvauslaskelma.KORViimeinenMaksuPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KORViimeinenMaksuPvm)
        korvauslaskelma.KORSopimushetkenIndeksiArvo = If(korvauslaskelma.KORSopimushetkenIndeksiArvo = 0 Or korvauslaskelma.KORSopimushetkenIndeksiArvo Is Nothing, Nothing, korvauslaskelma.KORSopimushetkenIndeksiArvo)

        tietokanta.Korvauslaskelma.Add(korvauslaskelma)
        tietokanta.SaveChanges()
        Return korvauslaskelma

      Catch ex As Exception

        Throw

      End Try

    End Using

  End Function

  Public Function LisaaKorvauslaskelma(korvauslaskelma As DTO.Korvauslaskelma) As DTO.Korvauslaskelma

    If korvauslaskelma Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim lisattava As Entities.Korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDBOksi(korvauslaskelma)

      Try

        tietokanta.Korvauslaskelma.Add(lisattava)
        tietokanta.SaveChanges()

        Return Konversiot.Korvauslaskelma.MuutaDTOksi(lisattava)

      Catch ex As Exception

        Throw

      End Try

    End Using

  End Function

  Public Function MuokkaaKorvauslaskelmaa(korvauslaskelma As Entities.Korvauslaskelma) As Entities.Korvauslaskelma

    If korvauslaskelma Is Nothing Then
      Return Nothing
    Else
      If korvauslaskelma.KORId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = korvauslaskelma.KORId)

      If Not muokattava Is Nothing Then

        Try
          muokattava.KOREnsimmainenSallittuMaksuPvm = If(korvauslaskelma.KOREnsimmainenSallittuMaksuPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KOREnsimmainenSallittuMaksuPvm)
          muokattava.KORIndeksiKuukausiId = korvauslaskelma.KORIndeksiKuukausiId
          muokattava.KORIndeksiVuosi = If(korvauslaskelma.KORIndeksiVuosi = 0 Or korvauslaskelma.KORIndeksiVuosi Is Nothing, Nothing, korvauslaskelma.KORIndeksiVuosi)
          muokattava.KORIndeksityyppiId = korvauslaskelma.KORIndeksityyppiId
          muokattava.KORInfo = korvauslaskelma.KORInfo
          muokattava.KORKorvauksenProjektinumero = korvauslaskelma.KORKorvauksenProjektinumero
          muokattava.KORKorvausProsentti = korvauslaskelma.KORKorvausProsentti
          muokattava.KORKorvauslaskelmaStatusId = korvauslaskelma.KORKorvauslaskelmaStatusId
          muokattava.KORKorvaustyyppiId = korvauslaskelma.KORKorvaustyyppiId
          muokattava.KORLaskennallinenKorvaus = korvauslaskelma.KORLaskennallinenKorvaus
          muokattava.KORMaksettavaKorvaus = korvauslaskelma.KORMaksettavaKorvaus
          muokattava.KORMaksettavaKorvausAlkuperainen = korvauslaskelma.KORMaksettavaKorvausAlkuperainen
          muokattava.KORMaksuKuukausiId = korvauslaskelma.KORMaksuKuukausiId
          muokattava.KORMaksualueId = korvauslaskelma.KORMaksualueId
          muokattava.KORMaksunSuoritusId = korvauslaskelma.KORMaksunSuoritusId
          muokattava.KORNykyinenIndeksiArvo = If(korvauslaskelma.KORNykyinenIndeksiArvo = 0 Or korvauslaskelma.KORNykyinenIndeksiArvo Is Nothing, Nothing, korvauslaskelma.KORNykyinenIndeksiArvo)
          muokattava.KORPaivitetty = korvauslaskelma.KORPaivitetty
          muokattava.KORPaivittaja = korvauslaskelma.KORPaivittaja
          muokattava.KORProjektinumero = korvauslaskelma.KORProjektinumero
          muokattava.KORKorvauksenProjektinumero = korvauslaskelma.KORKorvauksenProjektinumero
          muokattava.KORPuustonOmistajuusId = korvauslaskelma.KORPuustonOmistajuusId
          muokattava.KORPuustonPoistoId = korvauslaskelma.KORPuustonPoistoId
          muokattava.KORSopimushetkenIndeksiArvo = If(korvauslaskelma.KORSopimushetkenIndeksiArvo = 0 Or korvauslaskelma.KORSopimushetkenIndeksiArvo Is Nothing, Nothing, korvauslaskelma.KORSopimushetkenIndeksiArvo)
          'muokattava.KORTahoId = korvauslaskelma.KORTahoId
          muokattava.KORVanhaSopimusPaattyyiPvm = If(korvauslaskelma.KORVanhaSopimusPaattyyiPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KORVanhaSopimusPaattyyiPvm)
          muokattava.KORViesti = korvauslaskelma.KORViesti
          muokattava.KORViimeinenMaksuPvm = If(korvauslaskelma.KORViimeinenMaksuPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KORViimeinenMaksuPvm)
          muokattava.KORViite = korvauslaskelma.KORViite
          muokattava.KORKirjanpidonKustannuspaikkaId = korvauslaskelma.KORKirjanpidonKustannuspaikkaId
          muokattava.KORKirjanpidonTiliId = korvauslaskelma.KORKirjanpidonTiliId
          muokattava.KORVanhaSopimusPaattyyiPvm = If(korvauslaskelma.KORVanhaSopimusPaattyyiPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KORVanhaSopimusPaattyyiPvm)
          muokattava.KOREnsimmainenSallittuMaksuPvm = If(korvauslaskelma.KOREnsimmainenSallittuMaksuPvm = SqlDateTime.MinValue, Nothing, korvauslaskelma.KOREnsimmainenSallittuMaksuPvm)

          muokattava.KORInvCostId = korvauslaskelma.KORInvCostId
          muokattava.KORLocal1Id = korvauslaskelma.KORLocal1Id
          muokattava.KORPurposeId = korvauslaskelma.KORPurposeId
          muokattava.KORRegulationId = korvauslaskelma.KORRegulationId

          muokattava.KORMaksetaanAlv = korvauslaskelma.KORMaksetaanAlv
          muokattava.KOROnIndeksi = korvauslaskelma.KOROnIndeksi
          muokattava.KORMaksuehdotId = korvauslaskelma.KORMaksuehdotId

          muokattava.KORViimeisinMaksuPvm = korvauslaskelma.KORViimeisinMaksuPvm
          muokattava.KORViimeisinMaksu = korvauslaskelma.KORViimeisinMaksu
          muokattava.KORViimeisinIndeksi = korvauslaskelma.KORViimeisinIndeksi
          muokattava.KORViimeisinMaksuIndeksi = korvauslaskelma.KORViimeisinMaksuIndeksi

          tietokanta.SaveChanges()
          Return muokattava

        Catch ex As Exception

          Throw

        End Try

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function MuokkaaKorvauslaskelmaa(korvauslaskelma As DTO.Korvauslaskelma, Optional kaikkiTiedot As Boolean = True) As DTO.Korvauslaskelma

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = korvauslaskelma.Id)

      Dim muokattu As Entities.Korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDBOksi(korvauslaskelma, muokattava, kaikkiTiedot)

      If Not muokattava Is Nothing Then

        Try

          tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)

          tietokanta.SaveChanges()

          Return Konversiot.Korvauslaskelma.MuutaDTOksi(muokattava)

        Catch ex As Exception

          Throw

        End Try

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaKorvauslaskelma(id As Integer) As Entities.Korvauslaskelma

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope()

        Dim poistettavaKorvauslaskelma = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = id)

        If Not poistettavaKorvauslaskelma Is Nothing Then

          Dim poistettavatKorvauslaskelmanRivit = tietokanta.KorvauslaskelmaRivi.Where(Function(x) x.KLRKorvauslaskelmaId = id)
          For Each korvauslaskelmanRivi As Entities.KorvauslaskelmaRivi In poistettavatKorvauslaskelmanRivit
            tietokanta.KorvauslaskelmaRivi.Remove(korvauslaskelmanRivi)
          Next

          tietokanta.Korvauslaskelma.Remove(poistettavaKorvauslaskelma)
          tietokanta.SaveChanges()
          transaktio.Complete()
          Return poistettavaKorvauslaskelma

        Else

          Return Nothing

        End If

      End Using

    End Using

  End Function

  Public Function PoistaKorvauslaskelmaSopimukselta(korvauslaskelmaId As Integer, sopimusId As Integer) As Entities.Korvauslaskelma

    If korvauslaskelmaId = 0 Or sopimusId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelma As Entities.Korvauslaskelma
      korvauslaskelma = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = korvauslaskelmaId And x.KORSopimusId = sopimusId)

      If Not korvauslaskelma Is Nothing Then

        korvauslaskelma.KORSopimusId = Nothing
        tietokanta.SaveChanges()
        Return korvauslaskelma

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaKorvauslaskelmaTaholta(korvauslaskelmaId As Integer, tahoId As Integer) As Entities.Korvauslaskelma


    If korvauslaskelmaId = 0 Or tahoId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelma As Entities.Korvauslaskelma
      korvauslaskelma = tietokanta.Korvauslaskelma.FirstOrDefault(Function(x) x.KORId = korvauslaskelmaId And x.KORTahoId = tahoId)

      If Not korvauslaskelma Is Nothing Then

        korvauslaskelma.KORTahoId = Nothing
        tietokanta.SaveChanges()
        Return korvauslaskelma

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function PoistaRiviKorvauslaskelmalta(korvauslaskelmanRiviId As Integer, korvauslaskelmaId As Integer) As Entities.KorvauslaskelmaRivi

    If korvauslaskelmanRiviId = 0 Or korvauslaskelmaId = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.KorvauslaskelmaRivi.FirstOrDefault(Function(x) x.KLRId = korvauslaskelmanRiviId)

      If Not poistettava Is Nothing Then

        tietokanta.KorvauslaskelmaRivi.Remove(poistettava)
        tietokanta.SaveChanges()
        Return poistettava

      End If

    End Using

    Return Nothing

  End Function

  Public Function LisaaKorvauslaskelmanRivi(korvauslaskelmanRivi As Entities.KorvauslaskelmaRivi) As Entities.KorvauslaskelmaRivi

    If korvauslaskelmanRivi Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Try

        korvauslaskelmanRivi.KLRKokonaispintaAla = If(korvauslaskelmanRivi.KLRKokonaispintaAla = 0 Or korvauslaskelmanRivi.KLRKokonaispintaAla Is Nothing, Nothing, korvauslaskelmanRivi.KLRKokonaispintaAla)
        korvauslaskelmanRivi.KLRKuvionLeveys = If(korvauslaskelmanRivi.KLRKuvionLeveys = 0 Or korvauslaskelmanRivi.KLRKuvionLeveys Is Nothing, Nothing, korvauslaskelmanRivi.KLRKuvionLeveys)
        korvauslaskelmanRivi.KLRKuvionPituus = If(korvauslaskelmanRivi.KLRKuvionPituus = 0 Or korvauslaskelmanRivi.KLRKuvionPituus Is Nothing, Nothing, korvauslaskelmanRivi.KLRKuvionPituus)
        korvauslaskelmanRivi.KLRMaara = If(korvauslaskelmanRivi.KLRMaara = 0 Or korvauslaskelmanRivi.KLRMaara Is Nothing, Nothing, korvauslaskelmanRivi.KLRMaara)
        korvauslaskelmanRivi.KLRKorvaus = If(korvauslaskelmanRivi.KLRKorvaus = 0 Or korvauslaskelmanRivi.KLRKorvaus Is Nothing, Nothing, korvauslaskelmanRivi.KLRKorvaus)
        korvauslaskelmanRivi.KLRVanhaSopimusPaattyiPvm = If(korvauslaskelmanRivi.KLRVanhaSopimusPaattyiPvm = SqlDateTime.MinValue, Nothing, korvauslaskelmanRivi.KLRVanhaSopimusPaattyiPvm)
        korvauslaskelmanRivi.KLRYksikkohinta = If(korvauslaskelmanRivi.KLRYksikkohinta = 0 Or korvauslaskelmanRivi.KLRYksikkohinta Is Nothing, Nothing, korvauslaskelmanRivi.KLRYksikkohinta)

        tietokanta.KorvauslaskelmaRivi.Add(korvauslaskelmanRivi)
        tietokanta.SaveChanges()
        Return korvauslaskelmanRivi

      Catch ex As Exception

        Throw

      End Try

    End Using


  End Function

  Public Function LisaaKorvauslaskelmanRivi(korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi) As DTO.KorvauslaskelmanRivi

    Using tietokanta As New Entities.FortumEntities()

      Dim lisattava As Entities.KorvauslaskelmaRivi = Konversiot.Korvauslaskelma.MuutaDBOksi(korvauslaskelmanRivi)

      tietokanta.KorvauslaskelmaRivi.Add(lisattava)
      tietokanta.SaveChanges()

      Return Konversiot.Korvauslaskelma.MuutaDTOksi(lisattava)

    End Using


  End Function

  Public Function MuokkaaKorvauslaskelmanRivia(korvauslaskelmanRivi As Entities.KorvauslaskelmaRivi) As Entities.KorvauslaskelmaRivi

    If korvauslaskelmanRivi Is Nothing Then
      Return Nothing
    Else
      If korvauslaskelmanRivi.KLRId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.KorvauslaskelmaRivi.FirstOrDefault(Function(x) x.KLRId = korvauslaskelmanRivi.KLRId)

      If Not muokattava Is Nothing Then

        Try

          muokattava.KLRInfo = korvauslaskelmanRivi.KLRInfo
          muokattava.KLRKokonaispintaAla = If(korvauslaskelmanRivi.KLRKokonaispintaAla = 0 Or korvauslaskelmanRivi.KLRKokonaispintaAla Is Nothing, Nothing, korvauslaskelmanRivi.KLRKokonaispintaAla)
          muokattava.KLRKokonaispintaAlaYksikkoId = korvauslaskelmanRivi.KLRKokonaispintaAlaYksikkoId
          muokattava.KLRKorvaus = korvauslaskelmanRivi.KLRKorvaus
          muokattava.KLRKorvausProsentti = korvauslaskelmanRivi.KLRKorvausProsentti
          muokattava.KLRKorvaushinnastoId = korvauslaskelmanRivi.KLRKorvaushinnastoId
          muokattava.KLRKorvauslaskelmaId = korvauslaskelmanRivi.KLRKorvauslaskelmaId
          muokattava.KLRKuvionKorvattavaLeveys = If(korvauslaskelmanRivi.KLRKuvionKorvattavaLeveys = 0 Or korvauslaskelmanRivi.KLRKuvionKorvattavaLeveys Is Nothing, Nothing, korvauslaskelmanRivi.KLRKuvionKorvattavaLeveys)
          muokattava.KLRKuvionLeveys = If(korvauslaskelmanRivi.KLRKuvionLeveys = 0 Or korvauslaskelmanRivi.KLRKuvionLeveys Is Nothing, Nothing, korvauslaskelmanRivi.KLRKuvionLeveys)
          muokattava.KLRKuvionPituus = If(korvauslaskelmanRivi.KLRKuvionPituus = 0 Or korvauslaskelmanRivi.KLRKuvionPituus Is Nothing, Nothing, korvauslaskelmanRivi.KLRKuvionPituus)
          muokattava.KLRKuvionTunnus = korvauslaskelmanRivi.KLRKuvionTunnus
          muokattava.KLRMaara = korvauslaskelmanRivi.KLRMaara
          'muokattava.KLRMaaraYksikkoId = korvauslaskelmanRivi.KLRMaaraYksikkoId
          muokattava.KLRPaivitetty = korvauslaskelmanRivi.KLRPaivitetty
          muokattava.KLRPaivittaja = korvauslaskelmanRivi.KLRPaivittaja
          muokattava.KLRVanhaSopimusPaattyiPvm = If(korvauslaskelmanRivi.KLRVanhaSopimusPaattyiPvm = SqlDateTime.MinValue, Nothing, korvauslaskelmanRivi.KLRVanhaSopimusPaattyiPvm)
          muokattava.KLRKirjanpidonKustannuspaikkaId = korvauslaskelmanRivi.KLRKirjanpidonKustannuspaikkaId
          muokattava.KLRKirjanpidonTiliId = korvauslaskelmanRivi.KLRKirjanpidonTiliId
          muokattava.KLRYksikkohinta = korvauslaskelmanRivi.KLRYksikkohinta

          muokattava.KLRInvCostId = korvauslaskelmanRivi.KLRInvCostId
          muokattava.KLRRegulationId = korvauslaskelmanRivi.KLRRegulationId
          muokattava.KLRPurposeId = korvauslaskelmanRivi.KLRPurposeId
          muokattava.KLRLocal1Id = korvauslaskelmanRivi.KLRLocal1Id

          tietokanta.SaveChanges()
          Return muokattava

        Catch ex As Exception

          Throw

        End Try

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function MuokkaaKorvauslaskelmanRivia(korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi) As DTO.KorvauslaskelmanRivi

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattu As Entities.KorvauslaskelmaRivi = Konversiot.Korvauslaskelma.MuutaDBOksi(korvauslaskelmanRivi)

      Dim muokattava = tietokanta.KorvauslaskelmaRivi.FirstOrDefault(Function(x) x.KLRId = korvauslaskelmanRivi.Id)

      If Not muokattava Is Nothing Then

        Try

          muokattava.KLRInfo = muokattu.KLRInfo
          muokattava.KLRKokonaispintaAla = muokattu.KLRKokonaispintaAla
          muokattava.KLRKokonaispintaAlaYksikkoId = muokattu.KLRKokonaispintaAlaYksikkoId
          muokattava.KLRKorvaus = muokattu.KLRKorvaus
          muokattava.KLRKorvausProsentti = muokattu.KLRKorvausProsentti
          muokattava.KLRKorvaushinnastoId = muokattu.KLRKorvaushinnastoId
          muokattava.KLRKorvauslaskelmaId = muokattu.KLRKorvauslaskelmaId
          muokattava.KLRKuvionKorvattavaLeveys = muokattu.KLRKuvionKorvattavaLeveys
          muokattava.KLRKuvionLeveys = muokattu.KLRKuvionLeveys
          muokattava.KLRKuvionPituus = muokattu.KLRKuvionPituus
          muokattava.KLRKuvionTunnus = muokattu.KLRKuvionTunnus
          muokattava.KLRMaara = muokattu.KLRMaara
          muokattava.KLRPaivitetty = muokattu.KLRPaivitetty
          muokattava.KLRPaivittaja = muokattu.KLRPaivittaja
          muokattava.KLRKirjanpidonKustannuspaikkaId = muokattu.KLRKirjanpidonKustannuspaikkaId
          muokattava.KLRKirjanpidonTiliId = muokattu.KLRKirjanpidonTiliId
          muokattava.KLRYksikkohinta = muokattu.KLRYksikkohinta
          muokattava.KLRInvCostId = muokattu.KLRInvCostId
          muokattava.KLRRegulationId = muokattu.KLRRegulationId
          muokattava.KLRPurposeId = muokattu.KLRPurposeId
          muokattava.KLRLocal1Id = muokattu.KLRLocal1Id

          tietokanta.SaveChanges()

          Return Konversiot.Korvauslaskelma.MuutaDTOksi(muokattava)

        Catch ex As Exception

          Throw

        End Try

      Else

        Return Nothing

      End If

    End Using

  End Function

#End Region

#Region "Konversiometodit"

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.Korvauslaskelma)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.Korvauslaskelma) As iHakutulos

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.KORId
    hakutulos.Nimi = "Korvauslaskelma " + muunnettava.KORId.ToString()
    hakutulos.Tyyppi = "Korvauslaskelma"
    Return hakutulos

  End Function

  Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.KorvauslaskelmaRivi)) As List(Of iHakutulos)

    Dim hakutulokset = New List(Of iHakutulos)
    For Each muunnettava In muunnettavat
      hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
    Next
    Return hakutulokset

  End Function

  Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.KorvauslaskelmaRivi) As iHakutulos

    Dim hakutulos = New Hakutulos()
    hakutulos.ID = muunnettava.KLRId
    hakutulos.Nimi = "Korvauslaskelman rivi " + muunnettava.KLRId.ToString()
    hakutulos.Tyyppi = "Korvauslaskelman rivi"
    Return hakutulos

  End Function

#End Region

#Region "Spessumetodit"

  Public Sub PaivitaKorvauslaskelmaMaksetuksi(id As Integer, maksu As DTO.Maksu, konteksti As DTO.DataKonteksti)

    Dim sql As String = "UPDATE Korvauslaskelma SET KORViimeisinMaksuPvm={0}, KORViimeisinIndeksi={1}, KORViimeisinMaksu={2}, KORViimeisinMaksuIndeksi={3}, KORViimeisinIndeksiVuosi={4}, " & _
                        "KORPaivitetty=GETDATE(), KORPaivittaja={5} " & _
                        "WHERE KORId={6}"

    Dim sql2 As String = "UPDATE Korvauslaskelma SET KORKorvauslaskelmaStatusId={0} " & _
                         "WHERE KORId={1} AND KORKorvaustyyppiId={2}"

    Dim sql3 As String = "INSERT INTO KorvauslaskelmaLoki (KLLKorvauslaskelmaId, KLLStatusId, KLLLuoja, KLLLuotu) " &
                         "SELECT KORId, {0}, {1}, GETDATE() " &
                         "FROM Korvauslaskelma " &
                         "WHERE KORId={2} AND KORKorvaustyyppiId={3}"

    Using tietokanta As New Entities.FortumEntities()

      tietokanta.Database.ExecuteSqlCommand(sql, maksu.Maksupvm, maksu.Indeksi, maksu.Summa, maksu.MaksuIndeksi, maksu.Indeksivuosi, konteksti.Kayttajatunnus, id)

      tietokanta.Database.ExecuteSqlCommand(sql2, DTO.Enumeraattorit.KorvauslaskelmaStatus.Maksettu, id, DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus)

      tietokanta.Database.ExecuteSqlCommand(sql3, DTO.Enumeraattorit.KorvauslaskelmaStatus.Maksettu, konteksti.Kayttajatunnus, id, DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus)

    End Using

  End Sub

#End Region

End Class
