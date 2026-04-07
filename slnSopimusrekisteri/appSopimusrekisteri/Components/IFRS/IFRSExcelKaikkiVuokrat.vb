Imports ClosedXML.Excel
Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.BLL_CF.Models

Public Class IFRSExcelKaikkiVuokrat
    Implements IIFRSExcelWorksheet

#Region "Konstruktori ja vakiot"

    Private Const SarakkeitaPerVuosi = 12 ' Montako saraketta on jokaiselle vuodelle (siniset sarakkeet)
    Private Const SarakkeitaPohjaData = 9 ' Montako saraketta pohja-data vie (virheät sarakkeet)
    Private Const EsimerkkiRivi = 3 ' Rivi, jossa on esimerkkikaavat yhtä korvauslaskelmaa varten

    Private Const YhteenvetoVuokratyypeittainEsimerkkiRivi = 7 ' Rivi jossa on esimerkkinä yhden vuokratyypin yhteensä-laskelma
    Private Const YhteenvetoYhteensaRivi = 8 ' Rivi jossa on yhteensä tiedot
    Private Const YhteenvetoCreditDebitEsimerkkiriviAlku = 11 ' Rivi jossa on esimerkkinä credit ja debit erottelu, aloitus
    Private Const YhteenvetoCreditDebitEsimerkkiriviLoppu = 27 ' Rivi jossa on esimerkkinä credit ja debit erottelu, lopetus

    Public Sub New(sheet As IXLWorksheet, vuokratyypit As IEnumerable(Of Vuokratyyppi))

        Me.Vuokratyypit = vuokratyypit
        Worksheet = sheet
        KausiAnkkurit = New Dictionary(Of IFRSKausi, IXLCell)
        LaskentaRivit = New Dictionary(Of Integer, IXLRow)
        LaskentaRivitEiKorvauslaskelmaa = New List(Of IXLRow)
        VuokratyyppienYhteenvedot = New Dictionary(Of Vuokratyyppi, IXLRow)
        SopimusnumerotEiKorvauslaskelmaa = New List(Of Integer)

    End Sub

#End Region

#Region "Propertyt"

    Private Property Worksheet As IXLWorksheet
    Private Property KausiAnkkurit As Dictionary(Of IFRSKausi, IXLCell)
    Private Property LaskentaRivit As Dictionary(Of Integer, IXLRow)
    Private Property LaskentaRivitEiKorvauslaskelmaa As List(Of IXLRow)
    Private Property VuokratyyppienYhteenvedot As Dictionary(Of Vuokratyyppi, IXLRow)
    Private Property Vuokratyypit As IEnumerable(Of Vuokratyyppi)
    Private Property SopimusnumerotEiKorvauslaskelmaa As List(Of Integer)

#End Region

#Region "Tietojen käsittely"

    Public Sub TaytaTiedot(data As IEnumerable(Of IFRSKausi)) Implements IIFRSExcelWorksheet.TaytaTiedot

        AlustaYhteenveto()
        KopioiKaudet(data)
        AsetaPohjaData(data)

    End Sub

    Private Sub AlustaYhteenveto()

        AlustaYhteenvetoVuokratyypeittain()
        AlustaYhteenvetoCreditDebit()

    End Sub

    Private Sub AlustaYhteenvetoVuokratyypeittain()

        Dim esimerkki = Worksheet.Row(YhteenvetoVuokratyypeittainEsimerkkiRivi)

        For Each vuokratyyppi In Vuokratyypit

            Dim rivi = esimerkki.InsertRowsBelow(1).First()

            esimerkki.CopyTo(rivi)

            rivi.Cell("A").Value = vuokratyyppi.Nimi

            VuokratyyppienYhteenvedot.Add(vuokratyyppi, rivi)

        Next

        esimerkki.Delete()

    End Sub

    Private Sub AlustaYhteenvetoCreditDebit()

        Dim offset = VuokratyyppienYhteenvedot.Count - 1 ' Offset koska ollaan jo lisätty rivejä exceliin metodissa AlustaYhteenvetoVuokratyypeittain. -1 koska excel sisältää jo esimerkkirivin joka korvataan
        Dim loppu = offset + YhteenvetoCreditDebitEsimerkkiriviLoppu
        Dim esimerkki = Worksheet.Range(offset + YhteenvetoCreditDebitEsimerkkiriviAlku, 1, loppu, SarakkeitaPerVuosi + SarakkeitaPohjaData)

        For Each vuokratyyppi In VuokratyyppienYhteenvedot

            Dim rivi = Worksheet.Row(loppu)
            Dim rivit = rivi.InsertRowsBelow(esimerkki.RowCount() + 1)
            Dim ankkuri = rivi.RowBelow().RowBelow().Cell("A")

            esimerkki.CopyTo(ankkuri)

            ' Reloadataan ankkuri koska muuten vuokratyypin asettaminen bugaa jostain syystä
            ankkuri = rivi.RowBelow().RowBelow().Cell("A")

            ankkuri.Value = vuokratyyppi.Key.Nimi.ToUpper()

            Dim lopetus = Worksheet.Cell(ankkuri.Address.RowNumber + esimerkki.RowCount() - 1, SarakkeitaPerVuosi + SarakkeitaPohjaData)
            Dim range = Worksheet.Range(ankkuri.Address, lopetus.Address)

            Dim kaavalliset = range.Cells(True).Where(Function(x) x.HasFormula)

            For Each kaavallinen In kaavalliset

                kaavallinen.FormulaA1 = kaavallinen.FormulaA1.Replace("$" & (YhteenvetoYhteensaRivi + offset), "$" & vuokratyyppi.Value.RowNumber)

            Next

        Next

    End Sub

    ''' <summary>
    ''' Kopioi jokaiselle kaudelle omat sarakkeet
    ''' </summary>
    Private Sub KopioiKaudet(data As IEnumerable(Of IFRSKausi))

        ' H1 - S1000 (tulee sisältää mtyös yhteenvetolaskelmat)
        Dim esimerkkiKausi = Worksheet.Range(1, SarakkeitaPohjaData + 1, 1000, SarakkeitaPohjaData + SarakkeitaPerVuosi)
        Dim i = 0

        For Each kausi In data

            Dim alkuSarake = SarakkeitaPohjaData + (i * SarakkeitaPerVuosi) + 1
            Dim ankkuri = Worksheet.Cell(1, alkuSarake) ' Ankkuri, johon pastetaan

            If i > 0 Then

                esimerkkiKausi.CopyTo(ankkuri)

                ' Reloadataan ankkuri koska muuten vuosiluvun asettaminen bugaa jostain syystä (varmaan koska yhdistetty sarake)
                ankkuri = Worksheet.Cell(ankkuri.Address)

                ' Asetetaan sarake-leveydet koska ne ei jostain syystä kopioidu
                For Each sarake In esimerkkiKausi.Columns().Select(Function(x) x.WorksheetColumn())

                    Worksheet.Column(sarake.ColumnNumber() + (i * SarakkeitaPerVuosi)).Width = sarake.Width

                Next

            End If

            ankkuri.Value = kausi.Pvm

            i += 1

            ' Tallennetaan ankkurit myöhempää käyttöä varten
            KausiAnkkurit.Add(kausi, ankkuri)

        Next

    End Sub

    Private Sub AsetaPohjaData(data As IEnumerable(Of IFRSKausi))

        Dim esimerkki = Worksheet.Row(EsimerkkiRivi)
        Dim vanhoinKausi = data.OrderBy(Function(x) x.Pvm).FirstOrDefault()

        For Each kausi In data

            Dim ankkuri = KausiAnkkurit(kausi)

            For Each laskenta In kausi.IFRSLaskenta

                Dim rivi As IXLRow
                Dim uusiRivi As Boolean = False
                rivi = LisaaRivi(laskenta, esimerkki, uusiRivi)

                ' jos on lisätty uusi rivi ja kausi ei ole vanhin, niin tyhjennetään aiempien kausien kaavat ja luvut koska näille ei ole tietoja
                If uusiRivi AndAlso kausi IsNot vanhoinKausi Then
                    TyhjennaRivinEdellisetKaudet(rivi, data, kausi)
                End If

                AsetaLaskenta(laskenta, rivi, ankkuri.Address.ColumnNumber, uusiRivi)

            Next

            For Each laskenta In kausi.IFRSLaskentaEiKorvauslaskelmaa

                Dim rivi As IXLRow
                Dim uusiRivi As Boolean = False

                If Not SopimusnumerotEiKorvauslaskelmaa.Contains(laskenta.Sopimusnumero) Then
                    rivi = LisaaRivi(laskenta, esimerkki, uusiRivi, True)
                    SopimusnumerotEiKorvauslaskelmaa.Add(laskenta.Sopimusnumero)
                Else
                    rivi = LaskentaRivit.Values.FirstOrDefault(Function(x) x.Cell("C").Value = laskenta.Sopimusnumero)
                End If

                ' jos on lisätty uusi rivi ja kausi ei ole vanhin, niin tyhjennetään aiempien kausien kaavat ja luvut koska näille ei ole tietoja
                If uusiRivi AndAlso kausi IsNot vanhoinKausi Then
                    TyhjennaRivinEdellisetKaudet(rivi, data, kausi)
                End If

                AsetaLaskenta(laskenta, rivi, ankkuri.Address.ColumnNumber, uusiRivi)

            Next

        Next

        ' Poistetaan esimerkkirivin tiedot ja piilotetaan se
        esimerkki.Clear()
        esimerkki.Hide()

    End Sub

    Private Sub TyhjennaRivinEdellisetKaudet(rivi As IXLRow, kaikkiKaudet As IEnumerable(Of IFRSKausi), nykyKausi As IFRSKausi)

        Dim kaudet = kaikkiKaudet.Where(Function(x) x.Pvm < nykyKausi.Pvm)

        For Each kausi In kaudet

            Dim ankkuri = KausiAnkkurit(kausi).Address.ColumnNumber

            rivi.Cell(ankkuri + 6).Value = Nothing ' Nykyarvo edellisen kauden korolla, vuokralla ja kaudella
            rivi.Cell(ankkuri + 7).Value = Nothing ' Nykyarvo, uusi
            rivi.Cell(ankkuri + 8).Value = Nothing ' Nykyarvon muutos
            rivi.Cell(ankkuri + 9).Value = Nothing ' Group korko
            rivi.Cell(ankkuri + 10).Value = Nothing ' Group poisto
            rivi.Cell(ankkuri + 11).Value = Nothing ' Assets

        Next

    End Sub

    Private Function LisaaRivi(laskenta As IFRSLaskenta, esimerkki As IXLRow, ByRef uusi As Boolean, Optional ByVal korvauslaskelmaton As Boolean = False) As IXLRow

        If korvauslaskelmaton OrElse Not LaskentaRivit.ContainsKey(laskenta.KorvauslaskelmaId) Then

            Dim uusiRivi = Worksheet.Row(EsimerkkiRivi + LaskentaRivit.Count).InsertRowsBelow(1).First()

            esimerkki.CopyTo(uusiRivi)

            uusiRivi.Cell("A").Value = laskenta.Yhtio
            uusiRivi.Cell("B").Value = laskenta.Laskuttaja
            uusiRivi.Cell("C").Value = laskenta.Sopimusnumero
            uusiRivi.Cell("D").Value = laskenta.Vuokratyyppi
            uusiRivi.Cell("E").Value = laskenta.MaksunSuoritus
            uusiRivi.Cell("F").Value = laskenta.MaksetaanAlv
            uusiRivi.Cell("G").Value = laskenta.Alkaa
            If laskenta.Paattyy < DateTime.Now Then uusiRivi.Cell("H").Style.Font.FontColor = XLColor.Red
            uusiRivi.Cell("H").Value = laskenta.Paattyy
            uusiRivi.Cell("I").Value = laskenta.IFRS

            If korvauslaskelmaton Then
                LaskentaRivitEiKorvauslaskelmaa.Add(uusiRivi)
            Else
                LaskentaRivit.Add(laskenta.KorvauslaskelmaId, uusiRivi)
            End If

            uusi = True

            Return uusiRivi

        End If

        uusi = False

        Return LaskentaRivit(laskenta.KorvauslaskelmaId)

    End Function

    Private Sub AsetaLaskenta(laskenta As IFRSLaskenta, rivi As IXLRow, ankkuri As Integer, vanhoinKausi As Boolean)

        rivi.Cell(ankkuri + 1).Value = laskenta.UusiVuodet ' Jäljellä olevat kaudet, uusi
        rivi.Cell(ankkuri + 3).Value = laskenta.UusiKorkoProsentti ' Korko-%, uusi
        rivi.Cell(ankkuri + 5).Value = laskenta.UusiVuokra ' Vuokra, uusi

        ' Vanhoin kausi = stattiset arvot eikä haeta excel funktiolla
        If vanhoinKausi Then

            rivi.Cell(ankkuri).Value = laskenta.VanhaVuodet ' Jäljellä olevat kaudet, vanha
            rivi.Cell(ankkuri + 2).Value = laskenta.VanhaKorkoProsentti ' Korko-%, vanha
            rivi.Cell(ankkuri + 4).Value = laskenta.VanhaVuokra ' Vuokra, vanha
            rivi.Cell(ankkuri + 11).Value = laskenta.UusiAssets ' Right of use assets

            If Not laskenta.VanhaNykyarvo.HasValue Then
                rivi.Cell(ankkuri + 6).Value = Nothing ' Nykyarvo edellisen kauden korolla, vuokralla ja kaudella
                rivi.Cell(ankkuri + 8).Value = Nothing ' Nykyarvon muutos
                rivi.Cell(ankkuri + 9).Value = Nothing ' Group korko
                rivi.Cell(ankkuri + 10).Value = Nothing ' Group poisto
            End If

        Else

            Dim kausiKoko = laskenta.Kausi.KaudenKoko.ToString().Replace(",", ".")

            ' Haetaan funktioilla edellisen kauden uusi arvo
            rivi.Cell(ankkuri).FormulaR1C1 = "=RC[-" & (SarakkeitaPerVuosi - 1) & "]-" & kausiKoko ' Jäljellä olevat kaudet, vanha
            rivi.Cell(ankkuri + 2).FormulaR1C1 = "=RC[-" & (SarakkeitaPerVuosi - 1) & "]" ' Korko-%, vanha
            rivi.Cell(ankkuri + 4).FormulaR1C1 = "=RC[-" & (SarakkeitaPerVuosi - 1) & "]" ' Vuokra, vanha

            ' Kauden koko ei ole 1 vuosi, pitää muuttaa kaavoja
            If laskenta.Kausi.KaudenKoko <> 1 Then

                Dim nykyarvoVanha = rivi.Cell(ankkuri + 6) ' Nykyarvo edellisen kauden korolla, vuokralla ja kaudella
                Dim nykyarvoUusi = rivi.Cell(ankkuri + 7) ' Nykyarvo, uusi

                nykyarvoVanha.FormulaA1 = nykyarvoVanha.FormulaA1?.Replace("-1", "-" & kausiKoko)
                nykyarvoUusi.FormulaA1 = nykyarvoUusi.FormulaA1?.Replace("-1", "-" & kausiKoko)

            End If

        End If

    End Sub

#End Region

End Class
