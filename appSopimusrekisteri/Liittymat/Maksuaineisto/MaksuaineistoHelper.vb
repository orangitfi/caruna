Imports Sopimusrekisteri.BLL_CF
Imports appSopimusrekisteri.Liittymat.IFS

Namespace Liittymat.Maksuaineisto

  Public Class MaksuaineistoHelper

    Public Shared Function HaeMaksuaineisto(maksut As IEnumerable(Of Maksu)) As Maksuaineisto

      Dim maksuaineisto As New Maksuaineisto()
      Dim maksuraportit As IEnumerable(Of Maksuraportti)
      Dim maksuvalidaattori As MaksuValidaattori

      Dim lstMaksut As New List(Of Maksu)()
      Dim lstVirheelliset As New List(Of Maksuraportti)()
      Dim lstMaksettavat As New List(Of Maksuraportti)()
      Dim lstTarkistettavat As New List(Of Maksuraportti)()

      For Each maksu As Maksu In maksut

        maksuraportit = LuoMaksuraportit(maksu)

        maksuvalidaattori = New MaksuValidaattori()

        maksuvalidaattori.ValidoiMaksu(maksuraportit)

        If maksuvalidaattori.Ok Then
          lstMaksettavat.AddRange(maksuraportit)
          lstMaksut.Add(maksu)
        Else
          lstVirheelliset.AddRange(maksuraportit)
        End If

      Next

      maksuaineisto.Maksut = lstMaksut
      maksuaineisto.MaksettavaAineisto = lstMaksettavat
      maksuaineisto.VirheellinenAineisto = lstVirheelliset
      maksuaineisto.TarkistettavaAineisto = lstTarkistettavat

      Return maksuaineisto

    End Function

    Public Shared Function LuoMaksuaineistot(maksut As IEnumerable(Of Maksu), polku As String) As MaksuaineistoPalaute

      Dim palaute As New MaksuaineistoPalaute()
      Dim tiedostonimiTemplate As String = "{0}_" & Date.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

      Try

        Dim tiedosto As IFSIntegrationFile
        Dim invoice As Invoice
        Dim yhtiotunnus As String
        Dim yhtionimi As String
        Dim tiedostopolku As String
        Dim tiedostonimi As String
        Dim response As Response
        Dim lstTiedostot As New List(Of MaksuaineistoTiedosto)()
        Dim palauteTiedosto As MaksuaineistoTiedosto

        For Each yhtionMaksut As IEnumerable(Of Maksu) In maksut.GroupBy(Function(x) x.JuridinenYhtioId)

          tiedosto = New IFSIntegrationFile()
          yhtiotunnus = yhtionMaksut.First().JuridinenYhtio.KirjanpidonYritystunniste
          yhtionimi = yhtionMaksut.First().JuridinenYhtio.Nimi

          For Each maksu As Maksu In yhtionMaksut

            invoice = HaeIfsInvoice(maksu)

            tiedosto.AddInvoice(invoice)

          Next

          tiedostonimi = String.Format(tiedostonimiTemplate, yhtiotunnus)
          tiedostopolku = Io.YhdistaKansioJaTiedosto(polku, tiedostonimi)

          response = tiedosto.CreateFile(tiedostopolku)

          If Not response.Ok Then
            palaute.Ok = False
            palaute.Virheilmoitus = response.ErrorMessage
            Return palaute
          End If

          palauteTiedosto = New MaksuaineistoTiedosto()

          palauteTiedosto.Tiedosto = tiedostopolku
          palauteTiedosto.Tiedostonimi = tiedostonimi
          palauteTiedosto.YhtioTunnus = yhtiotunnus
          palauteTiedosto.YhtioNimi = yhtionimi
          palauteTiedosto.Maara = yhtionMaksut.Count()
          palauteTiedosto.Summa = yhtionMaksut.Sum(Function(x) x.Summa.GetValueOrDefault(0))

          lstTiedostot.Add(palauteTiedosto)

        Next

        palaute.Tiedostot = lstTiedostot
        palaute.Ok = True

      Catch ex As Exception

        palaute.Ok = False
        palaute.Virheilmoitus = "Maksuaineistojen muodostus epäonnistui: " & ex.Message

      End Try

      Return palaute

    End Function

    Public Shared Function HaeIfsInvoice(maksu As Maksu) As Invoice

      Dim invoice As Invoice
      Dim invoiceHeader As InvoiceHeader
      Dim invoiceLine As InvoiceLine
      Dim posting As Posting
      Dim supplier As Supplier
      Dim itemId As Integer

      invoice = New Invoice()
      invoiceHeader = New InvoiceHeader()
      supplier = New Supplier()

      invoiceHeader.InvoiceNo = maksu.Id.ToString()
      invoiceHeader.TransactionDate = Date.Now
      invoiceHeader.InvoiceDate = Date.Now

      If maksu.Maksupaiva.HasValue Then
        invoiceHeader.PlanPaymentDate = maksu.Maksupaiva
      End If

      invoiceHeader.CreatorsReference = maksu.Viesti
      invoiceHeader.YourReference = maksu.SopimusId.ToString()
      invoiceHeader.PaymentReference = maksu.Viite
      invoiceHeader.GrossCurrAmount = maksu.Summa

      invoice.Header = invoiceHeader

      supplier = New Supplier()

      supplier.InvoiceNo = maksu.Id.ToString()

      If Not maksu.Saaja Is Nothing Then

        supplier.Name = maksu.Saaja.Nimi
        supplier.Address1 = maksu.Saaja.Postitusosoite
        supplier.ZipCode = maksu.Saaja.Postituspostinro
        supplier.City = maksu.Saaja.Postituspostitmp

        If Not maksu.Saaja.Maa Is Nothing Then
          supplier.Country = maksu.Saaja.Maa.Koodi
        End If

        supplier.Account = maksu.Saaja.Tilinumero
        supplier.BicCode = maksu.Saaja.Bic

      End If

      TarkastaOsoitetiedot(supplier)

      invoice.Supplier = supplier

      itemId = 1

      For Each tiliointi As MaksuTiliointi In maksu.Tilioinnit

        invoiceLine = New InvoiceLine()

        invoiceLine.InvoiceNo = maksu.Id.ToString()
        invoiceLine.ItemId = itemId

        If maksu.Alv.HasValue Then
          invoiceLine.VatCode = maksu.Alv
        End If

        invoiceLine.NetCurrAmount = tiliointi.SummaIlmanAlv
        invoiceLine.VatCurrAmount = tiliointi.AlvOsuus.GetValueOrDefault(0)

        invoice.AddInvoiceLine(invoiceLine)

        posting = New Posting()

        posting.InvoiceNo = maksu.Id.ToString()
        posting.ItemId = itemId
        posting.CodeA = tiliointi.Kirjanpidontili
        posting.CodeB = tiliointi.Kustannuspaikka
        posting.CodeC = tiliointi.Projektinro
        posting.CodeF = tiliointi.InvCost
        posting.CodeG = tiliointi.Category
        posting.CurrAmount = tiliointi.SummaIlmanAlv

        invoice.AddPosting(posting)

        itemId += 1

      Next

      Return invoice

    End Function

    Public Shared Sub TarkastaOsoitetiedot(supplier As Supplier)

      If String.IsNullOrEmpty(supplier.Address1) Then
        supplier.Address1 = Konfiguraatiot.MaksuaineistoOletusOsoite
      End If

      If String.IsNullOrEmpty(supplier.ZipCode) Then
        supplier.ZipCode = Konfiguraatiot.MaksuaineistoOletusPostinro
      End If

      If String.IsNullOrEmpty(supplier.City) Then
        supplier.City = Konfiguraatiot.MaksuaineistoOletusPostitmp
      End If

    End Sub

    Public Shared Function LuoMaksuraportit(maksu As Maksu) As IEnumerable(Of Maksuraportti)

      Dim lstMaksuraportti As New List(Of Maksuraportti)()
      Dim maksuraportti As Maksuraportti

      Do

        maksuraportti = New Maksuraportti()

        maksuraportti.SaajaId = maksu.SaajaId
        maksuraportti.Saaja = maksu.SaajaNimi
        maksuraportti.BicKoodi = maksu.Bic
        maksuraportti.Tilinumero = maksu.Tilinumero

        maksuraportti.Viite = maksu.Viite
        maksuraportti.Viesti = maksu.Viesti
        maksuraportti.OnIndeksi = maksu.OnIndeksi
        If Not maksu.IndeksiKuukausi Is Nothing Then
          maksuraportti.Indeksikuukausi = maksu.IndeksiKuukausi.Nimi
        End If

        If Not maksu.Indeksityyppi Is Nothing Then
          maksuraportti.Indeksityyppi = maksu.Indeksityyppi.Nimi
        End If

        maksuraportti.MaksajanTilinro = maksu.MaksajanTilinro
        maksuraportti.MaksajanBicKoodi = maksu.MaksajanBicKoodi
        maksuraportti.Palvelutunnus = maksu.Palvelutunnus
        maksuraportti.Kirjanpidontunniste = maksu.KirjanpidonTunniste

        If Not maksu.JuridinenYhtio Is Nothing Then
          maksuraportti.JuridinenYhtioConcession = maksu.JuridinenYhtio.Concession
        End If

        If maksu.Indeksi.HasValue Then
          maksuraportti.Indeksi = maksu.Indeksi.Value
        End If

        If Not maksu.Korvauslaskelma Is Nothing Then

          If Not maksu.Korvauslaskelma.Sopimus Is Nothing Then

            maksuraportti.SopimusId = maksu.Korvauslaskelma.Sopimus.Id
            maksuraportti.SopimustyyppiId = maksu.Korvauslaskelma.Sopimus.SopimustyyppiId
            maksuraportti.Projektinumero = maksu.Korvauslaskelma.Sopimus.PCSNumero
            maksuraportti.Sopimustyyppi = maksu.Korvauslaskelma.Sopimus.Sopimustyyppi.SopimustyyppiNimi

          End If

          maksuraportti.KorvauksenProjektinumero = maksu.Korvauslaskelma.KorvauksenProjektinumero
          maksuraportti.KorvauslaskelmaId = maksu.Korvauslaskelma.Id
          maksuraportti.Korvaustyyppi = maksu.Korvauslaskelma.Korvaustyyppi.Nimi
          maksuraportti.KorvausTyyppiId = maksu.Korvauslaskelma.KorvaustyyppiId
          maksuraportti.MaksunSuoritus = maksu.Korvauslaskelma.MaksunSuoritus.Nimi
          maksuraportti.TypeOfProject = maksu.Korvauslaskelma.TypeOfProject
          maksuraportti.Type = maksu.Korvauslaskelma.Type
          maksuraportti.Owner = maksu.Korvauslaskelma.Owner

          maksuraportti.Concession = maksu.Korvauslaskelma.Concession

          If maksu.Korvauslaskelma.KorvaustyyppiId = Korvaustyypit.Kuukausivuokra Or maksu.Korvauslaskelma.KorvaustyyppiId = Korvaustyypit.Vuosimaksu Then
            maksuraportti.Category = Konfiguraatiot.MaksuaineistoVuokraCategory
          Else
            maksuraportti.Category = maksu.Korvauslaskelma.Category
          End If

          maksuraportti.CertDate = maksu.Korvauslaskelma.CertDate
            maksuraportti.FieldWorkStartedA = maksu.Korvauslaskelma.FieldWorkStarted
            maksuraportti.ProjectClosedA = maksu.Korvauslaskelma.ProjectClosedA
            maksuraportti.EnsimmainenMaksupvm = maksu.Korvauslaskelma.EnsimmainenSallittuMaksuPvm

            maksuraportti.EnsimmainenMaksupvmSyotettyKasin = maksu.Korvauslaskelma.EnsimmainenMaksupaivaAsetettuKasin.GetValueOrDefault(False)

            If maksu.Tilioinnit.Count() > 0 Then
              If Not maksu.Tilioinnit(lstMaksuraportti.Count) Is Nothing Then
                'maksuraportti.KorvauksienMaara = maksu.Tilioinnit(lstMaksuraportti.Count).Maara
                maksuraportti.KorvauksienSumma = maksu.Tilioinnit(lstMaksuraportti.Count).Summa.GetValueOrDefault(0)
                maksuraportti.KorvauksienAlv = maksu.Tilioinnit(lstMaksuraportti.Count).AlvOsuus.GetValueOrDefault(0)
                maksuraportti.KorvauksienSummaIlmanAlv = maksu.Tilioinnit(lstMaksuraportti.Count).SummaIlmanAlv.GetValueOrDefault(0)

                maksuraportti.Kustannuspaikka = maksu.Tilioinnit(lstMaksuraportti.Count).Kustannuspaikka
                maksuraportti.Kirjanpidontili = maksu.Tilioinnit(lstMaksuraportti.Count).Kirjanpidontili
                maksuraportti.InvCost = maksu.Tilioinnit(lstMaksuraportti.Count).InvCost
              End If
            End If

          End If

          lstMaksuraportti.Add(maksuraportti)

      Loop While lstMaksuraportti.Count < maksu.Tilioinnit.Count()

      Return lstMaksuraportti

    End Function

  End Class

End Namespace
