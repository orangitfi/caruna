Imports System.Transactions

Public Class Maksu

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

  Public Sub PassivoiMaksu(maksuId As Integer)
    Dim tietokanta As New DAL.Maksu()
    tietokanta.PassivoiMaksu(maksuId)
  End Sub

  Public Function HaeMaksuaineisto() As DTO.Maksuaineisto

    Dim tietokanta As New BLL.Korvauslaskelma(_konteksti)

    Dim korvauslaskelmat As List(Of DTO.Korvauslaskelma) = tietokanta.HaeMaksettavatKorvauslaskelmat()

    Dim maksut As DTO.Maksu() = Me.LuoMaksut(korvauslaskelmat.Where(Function(x) x.Sopimus.LaskennallinenPaattymispvm.GetValueOrDefault(Date.MaxValue) > Date.Now).ToList())

    Dim maksuaineisto As New DTO.Maksuaineisto()

    For Each maksu As DTO.Maksu In maksut

      Maksutarkistus.TarkistaMaksu(maksuaineisto, maksu, Me.LuoMaksuraportit(maksu))

    Next

    Return maksuaineisto

  End Function

  Public Function LuoMaksuraportit(maksu As DTO.Maksu) As DTO.Maksuraportti()

    Dim lstMaksuraportti As New List(Of DTO.Maksuraportti)

    Dim maksuraportti As DTO.Maksuraportti

    Do

      maksuraportti = New DTO.Maksuraportti()

      maksuraportti.SaajaId = maksu.SaajaId
      maksuraportti.Saaja = maksu.Saaja
      maksuraportti.BicKoodi = maksu.BicKoodi
      maksuraportti.Tilinumero = maksu.Tilinumero
      maksuraportti.Viite = maksu.Viite
      maksuraportti.Viesti = maksu.Viesti
      maksuraportti.OnIndeksi = maksu.OnIndeksi
      maksuraportti.Indeksikuukausi = maksu.Indeksikuukausi
      maksuraportti.Indeksityyppi = maksu.Indeksityyppi

      maksuraportti.MaksajanTilinro = maksu.MaksajanTilinro
      maksuraportti.MaksajanBicKoodi = maksu.MaksajanBicKoodi
      maksuraportti.Palvelutunnus = maksu.Palvelutunnus
      maksuraportti.Kirjanpidontunniste = maksu.Kirjanpidontunniste

      If maksu.Indeksi.HasValue Then
        maksuraportti.Indeksi = maksu.Indeksi.Value
      End If

      If Not maksu.JuridinenYhtio Is Nothing Then
        maksuraportti.JuridinenYhtioConcession = maksu.JuridinenYhtio.PCSConcession
      End If

      If Not maksu.Korvauslaskelma Is Nothing Then

        If Not maksu.Korvauslaskelma.Sopimus Is Nothing Then

          maksuraportti.SopimusId = maksu.Korvauslaskelma.Sopimus.Id
          maksuraportti.SopimustyyppiId = maksu.Korvauslaskelma.Sopimus.SopimustyyppiId
          maksuraportti.SopimuksenNimi = maksu.Korvauslaskelma.Sopimus.Nimi
          maksuraportti.Projektinumero = maksu.Korvauslaskelma.Sopimus.PCSNumero
          maksuraportti.Sopimustyyppi = maksu.Korvauslaskelma.Sopimus.Sopimustyyppi

        End If

        maksuraportti.KorvauksenProjektinumero = maksu.Korvauslaskelma.KorvauksenProjektinumero
        maksuraportti.KorvauslaskelmaId = maksu.Korvauslaskelma.Id
        maksuraportti.Korvaustyyppi = maksu.Korvauslaskelma.Korvaustyyppi
        maksuraportti.KorvausTyyppiId = maksu.Korvauslaskelma.KorvaustyyppiId
        maksuraportti.MaksunSuoritus = maksu.Korvauslaskelma.MaksunSuoritus
        maksuraportti.TypeOfProject = maksu.Korvauslaskelma.TypeOfProject
        maksuraportti.Type = maksu.Korvauslaskelma.Type
        maksuraportti.Owner = maksu.Korvauslaskelma.Owner
        maksuraportti.Concession = maksu.Korvauslaskelma.Concession
        maksuraportti.CertDate = maksu.Korvauslaskelma.CertDate
        maksuraportti.FieldWorkStartedA = maksu.Korvauslaskelma.FieldWorkStartedA
        maksuraportti.ProjectClosedA = maksu.Korvauslaskelma.ProjectClosedA
        maksuraportti.EnsimmainenMaksupvm = maksu.Korvauslaskelma.EnsimmainenSallittuMaksupvm
        maksuraportti.EnsimmainenMaksupvmSyotettyKasin = maksu.Korvauslaskelma.EnsimmainenSallittuMaksupvmAsetettuKasin.GetValueOrDefault(False)

        If maksu.Tiliointi.Length > 0 Then
          If Not maksu.Tiliointi(lstMaksuraportti.Count) Is Nothing Then
            maksuraportti.KorvauksienMaara = maksu.Tiliointi(lstMaksuraportti.Count).Maara
            maksuraportti.KorvauksienSumma = maksu.Tiliointi(lstMaksuraportti.Count).Summa.GetValueOrDefault(0)
            maksuraportti.KorvauksienAlv = maksu.Tiliointi(lstMaksuraportti.Count).AlvOsuus.GetValueOrDefault(0)
            maksuraportti.KorvauksienSummaIlmanAlv = maksu.Tiliointi(lstMaksuraportti.Count).SummaIlmanAlv.GetValueOrDefault(0)

            maksuraportti.Kustannuspaikka = maksu.Tiliointi(lstMaksuraportti.Count).Kustannuspaikka
            maksuraportti.Kirjanpidontili = maksu.Tiliointi(lstMaksuraportti.Count).Kirjanpidontili
            maksuraportti.InvCost = maksu.Tiliointi(lstMaksuraportti.Count).InvCost
            maksuraportti.Regulation = maksu.Tiliointi(lstMaksuraportti.Count).Regulation
            maksuraportti.Purpose = maksu.Tiliointi(lstMaksuraportti.Count).Purpose
            maksuraportti.Local1 = maksu.Tiliointi(lstMaksuraportti.Count).Local1
          End If
        End If

        maksuraportti.Country = maksu.Korvauslaskelma.Country

      End If

      lstMaksuraportti.Add(maksuraportti)

    Loop While lstMaksuraportti.Count < maksu.Tiliointi.Length


    Return lstMaksuraportti.ToArray()

  End Function

  Public Function LuoMaksut(korvauslaskelmat As List(Of DTO.Korvauslaskelma)) As DTO.Maksu()

    Dim tietokantaIndeksit As New BLL.Indeksi()

    Dim lstIndeksit As List(Of DTO.Indeksi) = tietokantaIndeksit.HaeVuodenIndeksit(Date.Now.Year)

    Dim lstMaksut As New List(Of DTO.Maksu)()

    For Each korvauslaskelma In korvauslaskelmat

      Dim objMaksu As New DTO.Maksu()

      objMaksu.KorvauslaskelmaId = korvauslaskelma.Id

      If korvauslaskelma.MaksetaanAlv Then
        objMaksu.Alv = korvauslaskelma.AlvProsentti
      End If

      If Not String.IsNullOrEmpty(korvauslaskelma.Viite) Then
        objMaksu.Viite = korvauslaskelma.Viite
      End If

      If String.IsNullOrEmpty(objMaksu.Viite) Then
        objMaksu.Viesti = korvauslaskelma.Viesti
      End If

      objMaksu.Korvauslaskelma = korvauslaskelma
      objMaksu.SopimusId = korvauslaskelma.SopimusId
      objMaksu.Vuosi = Date.Now.Year

      If Not korvauslaskelma.Saaja Is Nothing Then

        objMaksu.Tilinumero = korvauslaskelma.Saaja.Tilinumero
        objMaksu.BicKoodi = korvauslaskelma.Saaja.Bic
        objMaksu.Saaja = korvauslaskelma.Saaja.Nimi
        objMaksu.SaajaId = korvauslaskelma.Saaja.Id

      End If

      If Not korvauslaskelma.Sopimus Is Nothing Then
        objMaksu.JuridinenYhtioId = korvauslaskelma.Sopimus.JuridinenYhtioId

        If Not korvauslaskelma.Sopimus.JuridinenYhtio Is Nothing Then

          objMaksu.JuridinenYhtio = korvauslaskelma.Sopimus.JuridinenYhtio

          objMaksu.MaksajanNimi = korvauslaskelma.Sopimus.JuridinenYhtio.Nimi
          objMaksu.MaksajanTilinro = korvauslaskelma.Sopimus.JuridinenYhtio.Tilinumero
          objMaksu.MaksajanBicKoodi = korvauslaskelma.Sopimus.JuridinenYhtio.Bic
          objMaksu.Palvelutunnus = korvauslaskelma.Sopimus.JuridinenYhtio.Ytunnus
          objMaksu.Kirjanpidontunniste = korvauslaskelma.Sopimus.JuridinenYhtio.KirjanpidonYritystunniste
          objMaksu.KirjanpidonProjektitunniste = korvauslaskelma.Sopimus.JuridinenYhtio.KirjanpidonProjektitunniste

        End If

      End If

      objMaksu.Tiliointi = (From r As DTO.KorvauslaskelmanRivi In korvauslaskelma.Rivit _
                            Group By r.KirjanpidonTili, r.Kustannuspaikka, r.InvCost, r.Regulation, r.Purpose, r.Local1 _
                            Into tilioidytRivit = Group _
                            Select New DTO.MaksunTiliointi With {.Kirjanpidontili = KirjanpidonTili, .Kustannuspaikka = Kustannuspaikka, .InvCost = InvCost, _
                                                                  .Regulation = Regulation, .Purpose = Purpose, .Local1 = Local1, .Summa = tilioidytRivit.Sum(Function(x) x.Korvaus.GetValueOrDefault(0)), .Maara = tilioidytRivit.Count()}).ToArray()

      For Each tiliointi As DTO.MaksunTiliointi In objMaksu.Tiliointi

        If Not String.IsNullOrEmpty(korvauslaskelma.KorvauksenProjektinumero) Then
          tiliointi.Projektinro = objMaksu.KirjanpidonProjektitunniste & korvauslaskelma.KorvauksenProjektinumero
        ElseIf Not korvauslaskelma.Sopimus Is Nothing Then
          tiliointi.Projektinro = objMaksu.KirjanpidonProjektitunniste & korvauslaskelma.Sopimus.PCSNumero
        End If

      Next

      objMaksu.IndeksityyppiId = korvauslaskelma.IndeksityyppiId
      objMaksu.Indeksityyppi = korvauslaskelma.Indeksityyppi
      objMaksu.IndeksikuukausiId = korvauslaskelma.IndeksikuukausiId
      objMaksu.Indeksikuukausi = korvauslaskelma.Indeksikuukausi
      objMaksu.OnIndeksi = korvauslaskelma.OnIndeksi

      If objMaksu.OnIndeksi Then

        If korvauslaskelma.ViimeisinMaksupvm.HasValue Then

          If korvauslaskelma.IndeksityyppiId.HasValue And korvauslaskelma.IndeksikuukausiId.HasValue Then
            If lstIndeksit.Any(Function(x) x.KuukausiId = korvauslaskelma.IndeksikuukausiId.Value And x.IndeksityyppiId = korvauslaskelma.IndeksityyppiId.Value) Then
              objMaksu.Indeksi = lstIndeksit.First(Function(x) x.KuukausiId = korvauslaskelma.IndeksikuukausiId.Value And x.IndeksityyppiId = korvauslaskelma.IndeksityyppiId.Value).Arvo
            End If
          End If

        Else

          objMaksu.Indeksi = korvauslaskelma.SopimushetkenIndeksi

        End If

        If objMaksu.Indeksi.HasValue Then

          objMaksu.Indeksivuosi = Date.Now.Year

          If objMaksu.Indeksi < korvauslaskelma.ViimeisinMaksuIndeksi Then
            objMaksu.MaksuIndeksi = korvauslaskelma.ViimeisinMaksuIndeksi
          Else
            objMaksu.MaksuIndeksi = objMaksu.Indeksi
          End If

          For Each t As DTO.MaksunTiliointi In objMaksu.Tiliointi

            t.Summa = Math.Round(CDec(t.Summa.Value * objMaksu.MaksuIndeksi / korvauslaskelma.SopimushetkenIndeksi), 2)

          Next

        End If

      End If

      For Each t As DTO.MaksunTiliointi In objMaksu.Tiliointi

        t.SummaIlmanAlv = t.Summa

        If objMaksu.Alv.HasValue Then

          t.AlvOsuus = Math.Round(CDec(t.Summa * ((objMaksu.Alv) / 100)), 2)
          t.Summa = t.Summa + t.AlvOsuus

        End If

      Next

      objMaksu.SummaIlmanAlv = objMaksu.Tiliointi.Sum(Function(x) x.SummaIlmanAlv)
      objMaksu.Summa = objMaksu.Tiliointi.Sum(Function(x) x.Summa)
      objMaksu.AlvOsuus = objMaksu.Tiliointi.Sum(Function(x) x.AlvOsuus.GetValueOrDefault(0))

      lstMaksut.Add(objMaksu)

    Next

    Return lstMaksut.ToArray()

  End Function

  Public Function LisaaMaksuPoimituille(maksu As DTO.Maksu, sessioId As String) As List(Of DTO.Maksu)

    Dim tietokantaPoiminta As New BLL.Poiminta()

    Dim poimitut As DTO.Sopimus() = tietokantaPoiminta.HaePoimintaJoukkoSopimukset(sessioId)

    Dim lstMaksut As New List(Of DTO.Maksu)()

    For Each sopimus As DTO.Sopimus In poimitut

      Dim objMaksu As DTO.Maksu = Common.Objektit.Kopioi(Of DTO.Maksu)(maksu)


    Next

  End Function

  Public Function LisaaMaksu(maksu As DTO.Maksu) As DTO.Maksu

    Using scope As New TransactionScope()

      Dim tietokanta As New DAL.Maksu()
      Dim tietokantaKorvauslaskelmat As New BLL.Korvauslaskelma(_konteksti)

      maksu.Luoja = _konteksti.Kayttajatunnus
      maksu.Luotu = Date.Now

      For Each tiliointi As DTO.MaksunTiliointi In maksu.Tiliointi
        tiliointi.Luoja = _konteksti.Kayttajatunnus
        tiliointi.Luotu = Date.Now
      Next

      tietokantaKorvauslaskelmat.PaivitaKorvauslaskelmaMaksetuksi(maksu.KorvauslaskelmaId, maksu)

      maksu = tietokanta.LisaaMaksu(maksu)

      scope.Complete()

    End Using

    Return maksu

  End Function

  Public Function LisaaMaksut(maksut As List(Of DTO.Maksu), maksupvm As Date) As List(Of DTO.Maksu)

    Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 10, 0))

      Dim objMaksuEra As DTO.MaksuEra = Me.UusiMaksuEra()

      Dim tietokanta As New DAL.Maksu()

      Dim tietokantaKorvauslaskelmat As New BLL.Korvauslaskelma(_konteksti)

      For Each maksu As DTO.Maksu In maksut

        maksu.MaksuEraTunniste = objMaksuEra.Tunniste
        maksu.Ajopvm = Date.Now
        maksu.MaksuStatusId = DTO.Enumeraattorit.MaksuStatus.Maksettu
        maksu.Maksupvm = maksupvm
        maksu.Luoja = _konteksti.Kayttajatunnus
        maksu.Luotu = Date.Now

        For Each tiliointi As DTO.MaksunTiliointi In maksu.Tiliointi
          tiliointi.Luoja = _konteksti.Kayttajatunnus
          tiliointi.Luotu = Date.Now
        Next

        tietokantaKorvauslaskelmat.PaivitaKorvauslaskelmaMaksetuksi(maksu.KorvauslaskelmaId, maksu)

      Next

      maksut = tietokanta.LisaaMaksut(maksut)

      scope.Complete()

    End Using

    Return maksut

  End Function

  Public Function UusiMaksuEra() As DTO.MaksuEra

    Dim tietokanta As New DAL.MaksuEra(_konteksti)

    Return tietokanta.UusiMaksuEra()

  End Function

  Public Function TeeMaksuaineistot(maksut As List(Of DTO.Maksu), tiedostoPolku As String) As DTO.Palautusarvo

    Dim strTiedosto As String = String.Empty
    Dim strEratunniste As String
    Dim strYritystunniste As String

    Dim objPalautusarvo As New DTO.Palautusarvo()
    Dim objPalaute As DTO.MaksuaineistoPalaute
    Dim lstAineistot As New List(Of DTO.MaksuaineistoPalaute)()

    Try

      For Each yhtionMaksut As IEnumerable(Of DTO.Maksu) In maksut.GroupBy(Function(x) x.JuridinenYhtioId)

        strEratunniste = yhtionMaksut.First().MaksuEraTunniste
        strYritystunniste = yhtionMaksut.First().Kirjanpidontunniste

        If String.IsNullOrEmpty(strYritystunniste) Then
          strYritystunniste = "0"
        End If

        ' Luodaan tarvittavat hakemistot erälle.
        strTiedosto = String.Format("{0}_{1}.xml", strEratunniste, strYritystunniste)

        ' Luodaan XML-aineisto levypinnalle maksuaineistosta. Käyttäjä ei pääse tähän käsiksi.
        Dim cPayments As New BLL.CorporatePaymentsV02.CorporatePaymentsV02Factory(yhtionMaksut.First().MaksajanNimi, yhtionMaksut.First().Palvelutunnus)

        ' Luodaan maksuaineistomateriaali levypinnalle.
        For Each rivi As DTO.Maksu In yhtionMaksut

          If Not String.IsNullOrEmpty(rivi.Viite) Then
            cPayments.AddSEPATransferWithReferencenumber(rivi.Id.GetValueOrDefault(0).ToString(), rivi.MaksajanTilinro, rivi.MaksajanBicKoodi, rivi.Maksupvm, rivi.Summa, rivi.Saaja, rivi.Tilinumero, rivi.BicKoodi, rivi.Viite)
          Else
            cPayments.AddSEPATransferWithMessage(rivi.Id.GetValueOrDefault(0).ToString(), rivi.MaksajanTilinro, rivi.MaksajanBicKoodi, rivi.Maksupvm, rivi.Summa, rivi.Saaja, rivi.Tilinumero, rivi.BicKoodi, rivi.Viesti)
          End If

        Next

        strTiedosto = Common.Tiedostot.HaeYksilollinenTiedostonimi(tiedostoPolku, strTiedosto)

        ' Tallennetaan tiedosto.
        cPayments.CreateFile(tiedostoPolku & strTiedosto)

        MaksuaineistonKustomoija.MuokkaaMaksuaineisto(tiedostoPolku & strTiedosto)

        objPalaute = New DTO.MaksuaineistoPalaute()

        objPalaute.Tiedosto = strTiedosto
        objPalaute.Yritystunniste = strYritystunniste
        objPalaute.Maara = yhtionMaksut.Count()
        objPalaute.Summa = yhtionMaksut.Sum(Function(x) x.Summa)
        objPalaute.Yhtio = yhtionMaksut.First().MaksajanNimi

        lstAineistot.Add(objPalaute)

      Next

    Catch ex As Exception

      Dim objVirhe As New DTO.Virhe()

      objVirhe.Virhe = ex
      objVirhe.Data = ex.Message

      objPalautusarvo.Virheet.Add(objVirhe)

    End Try

    objPalautusarvo.Tiedot = lstAineistot

    Return objPalautusarvo

  End Function

  Public Function TeeKirjanpidonaineistot(maksut As List(Of DTO.Maksu), tiedot As DTO.KirjanpitoTiedot, tiedostoPolku As String) As DTO.Palautusarvo

    Dim strTiedosto As String = String.Empty
    Dim intEratunniste As Integer
    Dim strYritystunniste As String

    Dim objPalautusarvo As New DTO.Palautusarvo()
    Dim objPalaute As DTO.MaksuaineistoPalaute
    Dim lstAineistot As New List(Of DTO.MaksuaineistoPalaute)()

    Try

      For Each yhtionMaksut As IEnumerable(Of DTO.Maksu) In maksut.GroupBy(Function(x) x.JuridinenYhtioId)

        intEratunniste = yhtionMaksut.First().MaksuEraTunniste

        strYritystunniste = yhtionMaksut.First().Kirjanpidontunniste

        If String.IsNullOrEmpty(strYritystunniste) Then
          strYritystunniste = "0"
        End If

        strTiedosto = String.Format("{0}_{1}.dat", intEratunniste, strYritystunniste)

        Dim objGlData As New BLL.GLData(tiedot.OhjelmistoTunniste, strYritystunniste)

        Dim objGlDataRow As BLL.GLDataRow

        For Each objMaksu As DTO.Maksu In yhtionMaksut

          For Each objTiliointi As DTO.MaksunTiliointi In objMaksu.Tiliointi

            objGlDataRow = New BLL.GLDataRow()

            objGlDataRow.Source = tiedot.OhjelmistoTunniste
            objGlDataRow.Document_number = intEratunniste
            objGlDataRow.Document_category = tiedot.Kategoria
            objGlDataRow.Gl_date = objMaksu.Maksupvm
            objGlDataRow.Company = objMaksu.Kirjanpidontunniste
            objGlDataRow.Response = objTiliointi.Kustannuspaikka
            objGlDataRow.Account = objTiliointi.Kirjanpidontili
            objGlDataRow.Project = objMaksu.KirjanpidonProjektitunniste & objTiliointi.Projektinro
            objGlDataRow.Invcost = objTiliointi.InvCost
            objGlDataRow.Country = "FI"
            objGlDataRow.Purpose = objTiliointi.Purpose
            objGlDataRow.Local1 = objTiliointi.Local1
            objGlDataRow.Currency_code = "EUR"
            objGlDataRow.Conversion_type = "USER"
            objGlDataRow.Currency_rate = 1
            objGlDataRow.Debet_sum = objTiliointi.Summa
            objGlDataRow.Description = "Sopimuskorvaus " & objMaksu.SopimusId.ToString()
            objGlDataRow.Contract = "1"

            If objMaksu.Alv.HasValue Then
              objGlDataRow.Tax_code = "M" & objMaksu.Alv.Value.ToString("F0")
            Else
              objGlDataRow.Tax_code = "NTJ"
            End If

            objGlData.AddRow(objGlDataRow)

          Next

          objGlDataRow = New BLL.GLDataRow()

          objGlDataRow.Source = tiedot.OhjelmistoTunniste
          objGlDataRow.Document_number = intEratunniste
          objGlDataRow.Document_category = tiedot.Kategoria
          objGlDataRow.Gl_date = objMaksu.Maksupvm
          objGlDataRow.Company = objMaksu.Kirjanpidontunniste
          objGlDataRow.Response = tiedot.ClearingKustannuspaikkaPrefix & objMaksu.Kirjanpidontunniste
          objGlDataRow.Account = tiedot.ClearingTili
          objGlDataRow.Country = "FI"
          objGlDataRow.Currency_code = "EUR"
          objGlDataRow.Conversion_type = "USER"
          objGlDataRow.Currency_rate = 1
          objGlDataRow.Credit_sum = objMaksu.Summa
          objGlDataRow.Description = "Sopimuskorvaus " & objMaksu.SopimusId.ToString()
          objGlDataRow.Contract = "1"

          If objMaksu.Alv.HasValue Then
            objGlDataRow.Tax_code = "M" & objMaksu.Alv.Value.ToString("F0")
          Else
            objGlDataRow.Tax_code = "NTJ"
          End If

          objGlData.AddRow(objGlDataRow)

        Next

        strTiedosto = Common.Tiedostot.HaeYksilollinenTiedostonimi(tiedostoPolku, strTiedosto)

        objGlData.CreateFile(tiedostoPolku & strTiedosto)

        objPalaute = New DTO.MaksuaineistoPalaute()

        objPalaute.Tiedosto = strTiedosto
        objPalaute.Yritystunniste = strYritystunniste
        objPalaute.Maara = yhtionMaksut.Count()
        objPalaute.Summa = yhtionMaksut.Sum(Function(x) x.Summa)
        objPalaute.Yhtio = yhtionMaksut.First().MaksajanNimi

        lstAineistot.Add(objPalaute)

      Next

    Catch ex As Exception

      Dim objVirhe As New DTO.Virhe()

      objVirhe.Virhe = ex
      objVirhe.Data = ex.Message

      objPalautusarvo.Virheet.Add(objVirhe)

    End Try

    objPalautusarvo.Tiedot = lstAineistot

    Return objPalautusarvo

  End Function

End Class
