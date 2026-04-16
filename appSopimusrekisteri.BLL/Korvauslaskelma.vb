Imports appSopimusrekisteri.DTO

Public Class Korvauslaskelma

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeHinta(korvaushinnastoId As Integer) As Decimal

    Dim korvauslaskelma = New DAL.Korvauslaskelma()
    Return korvauslaskelma.HaeHinta(korvaushinnastoId)

  End Function

  Public Function HaeSopimuksenKorvauslaskelmat(sopimusId As Integer) As List(Of DTO.Korvauslaskelma)

    Dim korvauslaskelma = New DAL.Korvauslaskelma()

    Dim lstKorvauslaskelmat As List(Of DTO.Korvauslaskelma) = korvauslaskelma.HaeSopimuksenKorvauslaskelmat(sopimusId)

    For Each kl As DTO.Korvauslaskelma In lstKorvauslaskelmat
      kl.Rivit = Me.HaeKorvauslaskelmanRivit(kl.Id)
    Next

    Return lstKorvauslaskelmat

  End Function

  Public Function HaeKorvauslaskelma(korvauslaskelmaId As Integer) As Entities.Korvauslaskelma

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.HaeKorvauslaskelma(korvauslaskelmaId)

  End Function

  Public Function HaeKorvauslaskelmaDTO(korvauslaskelmaId As Integer) As DTO.Korvauslaskelma

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.HaeKorvauslaskelmaDTO(korvauslaskelmaId)

  End Function

  Public Function HaeKorvauslaskelmatDTO(korvauslaskelmaId As IEnumerable(Of Integer)) As IEnumerable(Of DTO.Korvauslaskelma)

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.HaeKorvauslaskelmatDTO(korvauslaskelmaId)

  End Function

  Public Function HaeKorvauslaskelmanRivi(id As Integer) As DTO.KorvauslaskelmanRivi

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.HaeKorvauslaskelmanRivi(id)

  End Function

  Public Function HaeKorvauslaskelmanRivit(korvauslaskelmaId As Integer) As List(Of DTO.KorvauslaskelmanRivi)

    Dim tietokanta = New DAL.Korvauslaskelma()

    Dim lstRivit As List(Of DTO.KorvauslaskelmanRivi) = tietokanta.HaeKorvauslaskelmanRivit(korvauslaskelmaId)

    lstRivit = LaskeKorvaukset(lstRivit)

    Return lstRivit

  End Function

  Public Function HaeMaksettavatKorvauslaskelmat() As List(Of DTO.Korvauslaskelma)

    Dim tietokanta As New DAL.Korvauslaskelma()

    Dim lstKorvauslaskelmat As List(Of DTO.Korvauslaskelma) = tietokanta.HaeMaksettavatKorvauslaskelmatKertakorvaus()

    lstKorvauslaskelmat.AddRange(tietokanta.HaeMaksettavatKorvauslaskelmatVuosimaksu())
    lstKorvauslaskelmat.AddRange(tietokanta.HaeMaksettavatKorvauslaskelmatKuukausivuokra())

    For Each korvauslaskelma As DTO.Korvauslaskelma In lstKorvauslaskelmat

      korvauslaskelma.Rivit = LaskeKorvaukset(korvauslaskelma.Rivit)

    Next

    Return lstKorvauslaskelmat

  End Function

  Public Shared Function LaskeKorvaukset(rivit As List(Of DTO.KorvauslaskelmanRivi)) As List(Of DTO.KorvauslaskelmanRivi)

    For Each rivi As DTO.KorvauslaskelmanRivi In rivit.Where(Function(x) x.KorvausYksikonTyyppi = Enumeraattorit.KorvausyksikonTyyppi.Prosentti)

      rivi.Korvaus = rivit.Where(Function(x) x.KorvauslaskelmaId = rivi.KorvauslaskelmaId And x.KorvausYksikonTyyppi <> Enumeraattorit.KorvausyksikonTyyppi.Prosentti).Sum(Function(x) x.Korvaus.GetValueOrDefault(0)) * (rivi.Yksikkohinta / 100)

    Next

    Return rivit

  End Function

  Public Shared Function HaeSopimustenKorvauslaskelmatJotkaTayttavatEhdon(sopimukset As IEnumerable(Of DTO.Sopimus), sessioId As String, filtteri As Func(Of DTO.Korvauslaskelma, Boolean)) As List(Of DTO.Korvauslaskelma)

    Dim tietokanta As New DAL.Korvauslaskelma()
    Dim tulos As New List(Of DTO.Korvauslaskelma)

    For Each sopimus As DTO.Sopimus In sopimukset
      For Each korvauslaskelma As DTO.Korvauslaskelma In tietokanta.HaeSopimuksenKorvauslaskelmat(sopimus.Id)
        If filtteri(korvauslaskelma) Then
          tulos.Add(korvauslaskelma)
        End If
      Next
    Next

    Return tulos

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaKorvauslaskelma(korvauslaskelma As DTO.Korvauslaskelma) As DTO.Korvauslaskelma

    Dim tahot = New DAL.Taho()

    Dim sopimuksenTahot = tahot.HaeSopimuksenTahot(korvauslaskelma.SopimusId)

    If sopimuksenTahot.Count = 1 Then
      korvauslaskelma.SaajaId = sopimuksenTahot.First().Id
    End If

    If Not korvauslaskelma.KorvausStatusId.HasValue Then
      korvauslaskelma.KorvausStatusId = DTO.Enumeraattorit.KorvauslaskelmaStatus.Hyvaksymatta
    End If

    If Not korvauslaskelma.KorvaustyyppiId.HasValue Then
      korvauslaskelma.KorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus
    End If

    If korvauslaskelma.KorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
      korvauslaskelma.MaksukuukausiId = Nothing
    End If

    Dim tietokanta = New DAL.Korvauslaskelma()

    korvauslaskelma.Luoja = _konteksti.Kayttajatunnus
    korvauslaskelma.Luotu = Date.Now
    korvauslaskelma.Paivittaja = _konteksti.Kayttajatunnus
    korvauslaskelma.Paivitetty = Date.Now

    Dim tietokantaAlv As New BLL.Alv()

    If korvauslaskelma.MaksetaanAlv = True Then
      korvauslaskelma.AlvId = tietokantaAlv.HaeOletusAlvId()
    End If

    Return tietokanta.LisaaKorvauslaskelma(korvauslaskelma)

  End Function

  Public Function MuokkaaKorvauslaskelmaa(korvauslaskelma As DTO.Korvauslaskelma, Optional kaikkiTiedot As Boolean = True) As DTO.Korvauslaskelma

    Dim tietokanta = New DAL.Korvauslaskelma()

    Dim rivit As List(Of DTO.KorvauslaskelmanRivi) = Me.HaeKorvauslaskelmanRivit(korvauslaskelma.Id)

    For Each r As DTO.KorvauslaskelmanRivi In rivit
      r.KirjanpidonTiliId = korvauslaskelma.KirjanpidonTiliId
      r.KustannuspaikkaId = korvauslaskelma.KustannuspaikkaId
      r.InvCostId = korvauslaskelma.InvCostId
      r.RegulationId = korvauslaskelma.RegulationId
      r.PurposeId = korvauslaskelma.PurposeId
      r.Local1Id = korvauslaskelma.Local1Id

      Me.MuokkaaKorvauslaskelmanRivia(r)

    Next

    If korvauslaskelma.KorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
      korvauslaskelma.MaksukuukausiId = Nothing
    End If

    Dim tietokantaAlv As New BLL.Alv()

    If korvauslaskelma.MaksetaanAlv = True Then
      korvauslaskelma.AlvId = tietokantaAlv.HaeOletusAlvId()
    End If

    korvauslaskelma.Paivittaja = _konteksti.Kayttajatunnus
    korvauslaskelma.Paivitetty = Date.Now

    Return tietokanta.MuokkaaKorvauslaskelmaa(korvauslaskelma, kaikkiTiedot)

  End Function

  Public Function PoistaKorvauslaskelma(id As Integer) As Entities.Korvauslaskelma

    ' TODO: Add transaction...

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.PoistaKorvauslaskelma(id)

  End Function

  Public Function PoistaKorvauslaskelmaSopimukselta(korvauslaskelmaId As Integer, sopimusId As Integer) As Entities.Korvauslaskelma

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.PoistaKorvauslaskelmaSopimukselta(sopimusId, sopimusId)

  End Function

  Public Function PoistaKorvauslaskelmaTaholta(korvauslaskelmaId As Integer, tahoId As Integer) As Entities.Korvauslaskelma

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.PoistaKorvauslaskelmaTaholta(korvauslaskelmaId, tahoId)

  End Function

  Public Function LisaaKorvauslaskelmanRivi(korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi) As DTO.KorvauslaskelmanRivi

    Dim tietokanta = New DAL.Korvauslaskelma()

    korvauslaskelmanRivi.Luoja = _konteksti.Kayttajatunnus
    korvauslaskelmanRivi.Luotu = Date.Now
    korvauslaskelmanRivi.Paivittaja = _konteksti.Kayttajatunnus
    korvauslaskelmanRivi.Paivitetty = Date.Now

    Return tietokanta.LisaaKorvauslaskelmanRivi(korvauslaskelmanRivi)

  End Function

  Public Function MuokkaaKorvauslaskelmanRivia(korvauslaskelmanRivi As DTO.KorvauslaskelmanRivi) As DTO.KorvauslaskelmanRivi

    Dim tietokanta = New DAL.Korvauslaskelma()

    korvauslaskelmanRivi.Paivittaja = _konteksti.Kayttajatunnus
    korvauslaskelmanRivi.Paivitetty = Date.Now

    Return tietokanta.MuokkaaKorvauslaskelmanRivia(korvauslaskelmanRivi)

  End Function

  Public Function PoistaRiviKorvauslaskelmalta(korvauslaskelmanRiviId As Integer, korvauslaskelmaId As Integer) As Entities.KorvauslaskelmaRivi

    Dim tietokanta = New DAL.Korvauslaskelma()
    Return tietokanta.PoistaRiviKorvauslaskelmalta(korvauslaskelmanRiviId, korvauslaskelmaId)

  End Function

  'Public Function PaivitaKorvauslaskelmaMaksetuksi(korvauslaskelmaId As Integer, maksu As DTO.Maksu) As DTO.Korvauslaskelma

  '  Dim korvauslaskelma As DTO.Korvauslaskelma = HaeKorvauslaskelmaDTO(korvauslaskelmaId)

  '  If korvauslaskelma.KorvaustyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
  '    korvauslaskelma.KorvausStatusId = DTO.Enumeraattorit.KorvauslaskelmaStatus.Maksettu
  '  End If

  '  korvauslaskelma.ViimeisinMaksupvm = maksu.Maksupvm
  '  korvauslaskelma.ViimeisinIndeksi = maksu.Indeksi
  '  korvauslaskelma.ViimeisinMaksu = maksu.Summa
  '  korvauslaskelma.ViimeisinMaksuIndeksi = maksu.MaksuIndeksi

  '  Return MuokkaaKorvauslaskelmaa(korvauslaskelma)

  'End Function

  Public Sub PaivitaKorvauslaskelmaMaksetuksi(korvauslaskelmaId As Integer, maksu As DTO.Maksu)

    Dim tietokanta As New DAL.Korvauslaskelma()

    tietokanta.PaivitaKorvauslaskelmaMaksetuksi(korvauslaskelmaId, maksu, _konteksti)

  End Sub

#End Region

End Class
