Imports System.IO
Imports ClosedXML.Excel
Imports Sopimusrekisteri.BLL_CF.Models

Public Class IFRSExcel
    Implements IDisposable

#Region "Konstruktori ja vakiot"

    Public Const ExcelPolku = "~/Export/IFRS/"
    Public Const ExcelPohja = "~/Dokumentit/IFRS/IFRS_Pohja.xlsx"

    Public Const ValilehtiKaikkiVuokratNimi = "IFRS16 vuokrat"
    Public Const ValilehtiMaturiteettiNimi = "Maturiteetti"

    Public Sub New(asetukset As IFRSExcelAsetukset)

        Me.Asetukset = asetukset

        Document = New XLWorkbook(Server.MapPath(ExcelPohja))
        Tiedostonimi = "IFRS_" & asetukset.Katselupvm.ToString("yyyy-MM-dd") & "_" & Date.Now.ToString("yyyy-MM-dd") & "_" & Date.Now.ToString("HH-mm-ss") & ".xlsx"

        ' Välilehdet
        KaikkiVuokrat = New IFRSExcelKaikkiVuokrat(Document.Worksheet(ValilehtiKaikkiVuokratNimi), asetukset.Vuokratyypit)
        Maturiteetti = New IFRSExcelMaturiteetti(Document.Worksheet(ValilehtiMaturiteettiNimi), asetukset.OletettuInflaatio)

    End Sub

#End Region

#Region "Propertyt"

    Private ReadOnly Property Server As HttpServerUtility
        Get
            Return HttpContext.Current.Server
        End Get
    End Property

    Private ReadOnly Property Data As IEnumerable(Of IFRSKausi)
        Get
            Return Asetukset.Data
        End Get
    End Property

    Private Property Asetukset As IFRSExcelAsetukset
    Private Property Tiedostonimi As String
    Private Property Document As XLWorkbook
    Private Property KaikkiVuokrat As IFRSExcelKaikkiVuokrat
    Private Property Maturiteetti As IFRSExcelMaturiteetti

#End Region

#Region "Muodostus"

    Public Function MuodostaExcel() As String

        ' Täytetään välilehtien tiedot
        KaikkiVuokrat.TaytaTiedot(Data)
        Maturiteetti.TaytaTiedot(Data)

        ' Tallennetaan Excel
        Return Tallenna()

    End Function

    Private Function Tallenna() As String

        Dim polku = Server.MapPath(ExcelPolku)

        If Not Directory.Exists(polku) Then
            Directory.CreateDirectory(polku)
        End If

        Document.SaveAs(polku & Tiedostonimi)

        Return ExcelPolku & Tiedostonimi

    End Function

#End Region

#Region "IDisposable"

    Public Sub Dispose() Implements IDisposable.Dispose
        Document.Dispose()
    End Sub

#End Region

End Class
