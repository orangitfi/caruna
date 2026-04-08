Imports System.Web.UI.WebControls.Expressions
Imports ClosedXML.Excel
Imports evointernal
Imports Microsoft.Ajax.Utilities
Imports Sopimusrekisteri.BLL_CF.Models

Public Class IFRSExcelMaturiteetti
    Implements IIFRSExcelWorksheet

#Region "Konstruktori ja vakiot"

    Private Const EsimerkkiRivi = 3 ' Rivi, jossa on esimerkkikaavat yhtä korvauslaskelmaa varten
    Private Const OletettuInflaatioSolu = "G2" ' Solu jossa on raportilla annettu metadata "Oletettu inflaatio"
    Private Const VuosivuokraOtsikkoSolu = "F2" ' Solu jossa on otsikko sarakkeelle "Vuosivuokra". Tähän sarakkeeseen lisätään vuosiluku perään

    Public Sub New(sheet As IXLWorksheet, oletettuInflaatio As Decimal)

        Me.OletettuInflaatio = oletettuInflaatio
        Worksheet = sheet
        LaskentaRivit = New Dictionary(Of Integer, IXLRow)
        LaskentaRivitEiKorvauslaskelmaa = New List(Of IXLRow)
        SopimusnumerotEiKorvauslaskelmaa = New List(Of Integer)

    End Sub

#End Region


#Region "Propertyt"

    Private Property Worksheet As IXLWorksheet
    Private Property LaskentaRivit As Dictionary(Of Integer, IXLRow)
    Private Property LaskentaRivitEiKorvauslaskelmaa As List(Of IXLRow)
    Private Property OletettuInflaatio As Decimal
    Private Property SopimusnumerotEiKorvauslaskelmaa As List(Of Integer)

#End Region

#Region "Tietojen käsittely"

    Public Sub TaytaTiedot(data As IEnumerable(Of IFRSKausi)) Implements IIFRSExcelWorksheet.TaytaTiedot

        AsetaOletettuInflaatio(OletettuInflaatio)
        AsetaPohjaData(data)

    End Sub

    Private Sub AsetaOletettuInflaatio(inflaatio As Decimal)

        Worksheet.Cell(OletettuInflaatioSolu).Value = inflaatio / 100

    End Sub

    Private Sub AsetaPohjaData(data As IEnumerable(Of IFRSKausi))

        Dim esimerkki = Worksheet.Row(EsimerkkiRivi)
        Dim uusin = data.OrderByDescending(Function(x) x.Pvm).FirstOrDefault()
        Dim vanhin = data.OrderBy(Function(x) x.Pvm).FirstOrDefault()

        ' Asetetaan sarakkeen otsikko
        Worksheet.Cell(VuosivuokraOtsikkoSolu).Value = "Vuosivuokra (" & uusin.Pvm.Year & ")"

        For Each kausi In data

            For Each laskenta In kausi.Laskenta.Select(Function(x) x.Value)

                LisaaRivi(laskenta, esimerkki, uusin, vanhin)

            Next

            For Each laskenta In kausi.LaskentaEiKorvauslaskelmaa

                If Not SopimusnumerotEiKorvauslaskelmaa.Contains(laskenta.Sopimusnumero) Then
                    LisaaRivi(laskenta, esimerkki, uusin, vanhin, True)
                    SopimusnumerotEiKorvauslaskelmaa.Add(laskenta.Sopimusnumero)
                End If

            Next

        Next

        ' Poistetaan esimerkkirivin tiedot ja piilotetaan se
        esimerkki.Clear()
        esimerkki.Hide()

    End Sub

    Private Function LisaaRivi(laskenta As IFRSLaskenta, esimerkki As IXLRow, uusinKausi As IFRSKausi, vanhinKausi As IFRSKausi, Optional ByVal korvauslaskelmaton As Boolean = False) As IXLRow

        If korvauslaskelmaton OrElse Not LaskentaRivit.ContainsKey(laskenta.KorvauslaskelmaId) Then

            Dim uusinLaskenta As IFRSLaskenta = Nothing
            Dim vanhinLaskenta As IFRSLaskenta = Nothing

            If korvauslaskelmaton Then
                uusinLaskenta = uusinKausi.LaskentaEiKorvauslaskelmaa.FirstOrDefault(Function(x) x.Sopimusnumero = laskenta.Sopimusnumero)
                vanhinLaskenta = vanhinKausi.LaskentaEiKorvauslaskelmaa.FirstOrDefault(Function(x) x.Sopimusnumero = laskenta.Sopimusnumero)
            Else
                uusinLaskenta = ValueOrNull(uusinKausi.Laskenta, laskenta.KorvauslaskelmaId)
                vanhinLaskenta = ValueOrNull(vanhinKausi.Laskenta, laskenta.KorvauslaskelmaId)
            End If


            Dim uusiRivi = Worksheet.Row(EsimerkkiRivi + LaskentaRivit.Count).InsertRowsBelow(1).First()

            esimerkki.CopyTo(uusiRivi)

            uusiRivi.Cell("A").Value = laskenta.Yhtio ' Yhtiö
            uusiRivi.Cell("B").Value = laskenta.Laskuttaja ' Laskuttaja
            uusiRivi.Cell("C").Value = laskenta.Sopimusnumero ' Sopimusnumero
            uusiRivi.Cell("D").Value = laskenta.Vuokratyyppi ' Vuokratyyppi
            uusiRivi.Cell("E").Value = laskenta.Paattyy ' Päättymispvm
            uusiRivi.Cell("F").Value = uusinLaskenta?.UusiVuokra ' Vuosivuokra
            uusiRivi.Cell("O").Value = laskenta.IFRS ' IFRS16 true/false
            uusiRivi.Cell("P").Value = If(laskenta.IFRS, vanhinLaskenta?.UusiNykyarvo, 0) ' Leasingvelka

            If korvauslaskelmaton Then
                LaskentaRivitEiKorvauslaskelmaa.Add(uusiRivi)
            Else
                LaskentaRivit.Add(laskenta.KorvauslaskelmaId, uusiRivi)
            End If

            Return uusiRivi

        End If

        Return LaskentaRivit(laskenta.KorvauslaskelmaId)

    End Function

    ''' <summary>
    ''' Dictionaryssä ei ole suoraan arvo tai null funkkaria, joten tässä tälläinen
    ''' </summary>
    Private Function ValueOrNull(Of TKey, TValue As {Class})(dic As Dictionary(Of TKey, TValue), key As TKey) As TValue

        Dim value As TValue = Nothing

        If dic.TryGetValue(key, value) Then
            Return value
        End If

        Return Nothing

    End Function

#End Region

End Class
