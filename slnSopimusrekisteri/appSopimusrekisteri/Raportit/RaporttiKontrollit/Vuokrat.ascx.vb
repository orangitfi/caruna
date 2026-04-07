Imports KT.Utils
Imports KT.Utils.Mapping
Imports Sopimusrekisteri.BLL_CF

Namespace RaporttiKontrollit

  Public Class Vuokrat
    Inherits ReportControlBase(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)

    Private indeksit As List(Of Indeksi)

    Protected Const Col_Yhtio As String = "Yhtio"
    Protected Const Col_Sopimustyyppi As String = "Sopimustyyppi"
    Protected Const Col_Sopimusnro As String = "Sopimusnro"
    Protected Const Col_MuuTunniste As String = "MuuTunniste"
    Protected Const Col_Alkupvm As String = "Alkupvm"
    Protected Const Col_Paattymispvm As String = "Paattymispvm"
    Protected Const Col_Irtisanomispvm As String = "Irtisanomispvm"
    Protected Const Col_Jatkoaika As String = "Jatkoaika"
    Protected Const Col_Irtisanomisaika As String = "Irtisanomisaika"
    Protected Const Col_Korvaustyyppi As String = "Korvaustyyppi"
    Protected Const Col_Korvaussumma As String = "Korvaussumma"
    Protected Const Col_KorvaussummaSisAlv As String = "KorvaussummaSisAlv"
    Protected Const Col_Vuosivuokra As String = "Vuosivuokra"
    Protected Const Col_Maksukuukausi As String = "Maksukuukausi"
    Protected Const Col_Indeksityyppi As String = "Indeksityyppi"
    Protected Const Col_SopimushetkenIndeksi As String = "SopimushetkenIndeksi"
    Protected Const Col_Indeksivuosi As String = "Indeksivuosi"
    Protected Const Col_Indeksikuukausi As String = "Indeksikuukausi"
    Protected Const Col_ViimeisinIndeksi As String = "ViimeisinIndeksi"
    Protected Const Col_Status As String = "Status"
    Protected Const Col_EnsimmainenSallittuMaksupvm As String = "EnsimmainenSallittuMaksupvm"
    Protected Const Col_SaajanEtunimi As String = "SaajanEtunimi"
    Protected Const Col_SaajanSukunimi As String = "SaajanSukunimi"
    Protected Const Col_AlkuperainenOsapuoli As String = "AlkuperainenOsapuoli"
    Protected Const Col_Kiinteistotunnus As String = "Kiinteistotunnus"
    Protected Const Col_KiinteistonKunta As String = "KiinteistonKunta"
    Protected Const col_MaksuunMenevaSumma As String = "MaksuunMenevaSumma"

    Public Overrides ReadOnly Property Automaattihaku As Boolean
      Get
        Return False
      End Get
    End Property

    Public Overrides ReadOnly Property HasSubReport As Boolean
      Get
        Return False
      End Get
    End Property

    Public Overrides ReadOnly Property Otsikko As String
      Get
        Return "Vuokrat"
      End Get
    End Property

    Public Overrides ReadOnly Property ReportDataBindControl As Control
      Get
        Return lstReport
      End Get
    End Property

    Protected Overrides ReadOnly Property ReportContainerControl As Control
      Get
        Return reportContainer
      End Get
    End Property

    Protected Overrides ReadOnly Property SubReportContainerControl As Control
      Get
        Throw New NotImplementedException()
      End Get
    End Property

    Protected Overrides ReadOnly Property SubReportDataBindControl As Control
      Get
        Throw New NotImplementedException()
      End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Not Page.IsPostBack Then
        AsetaDropit()
      End If
    End Sub

    Private Sub AsetaDropit()
      WebUtils.DataBindList(KorvaustyyppiId, Handlers.Korvaustyypit.GetAll(), AddressOf UiHelper.LuoListItemKorvaustyyppi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(SopimustyyppiId, Handlers.Sopimustyypit.GetAll(), AddressOf UiHelper.LuoListItemSopimustyyppi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(MaksukuukausiId, Handlers.Kuukaudet.GetAll(), AddressOf UiHelper.LuoListItemKuukausi, AddressOf UiHelper.LuoTyhjaListItem)
    End Sub

    Public Overrides Function GetSubReportData() As DataTable
      Throw New NotImplementedException()
    End Function

    Protected Overrides Function GetColumnMappings(tc As TypeCache) As IEnumerable(Of KT.Utils.Mapping.DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma))
      Dim handleri = New Sopimusrekisteri.DAL_CF.EntityHandlers.KorvauslaskelmaHandler(Me.DataContext)
      Return New DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)() _
      {
          CreateColumnMapping(Col_Yhtio, tc.StringType, Function(x) If(Not x.Sopimus.JuridinenYhtio Is Nothing, x.Sopimus.JuridinenYhtio.Nimi, String.Empty)),
          CreateColumnMapping(Col_Sopimustyyppi, tc.StringType, Function(x) x.Sopimus.SopimustyypinNimi),
          CreateColumnMapping(Col_Sopimusnro, tc.StringType, Function(x) x.Sopimus.Id),
          CreateColumnMapping(Col_MuuTunniste, tc.StringType, Function(x) x.Sopimus.MuuTunniste),
          CreateColumnMapping(Col_Alkupvm, tc.DateTimeType, Function(x) x.Sopimus.Alkaa),
          CreateColumnMapping(Col_Paattymispvm, tc.DateTimeType, Function(x) x.Sopimus.Paattyy),
          CreateColumnMapping(Col_Irtisanomispvm, tc.DateTimeType, Function(x) x.Sopimus.Irtisanomispvm),
          CreateColumnMapping(Col_Jatkoaika, tc.IntegerType, Function(x) x.Sopimus.Jatkoaika),
          CreateColumnMapping(Col_Irtisanomisaika, tc.IntegerType, Function(x) x.Sopimus.SopimuksenIrtisanomisaika),
          CreateColumnMapping(Col_Korvaustyyppi, tc.StringType, Function(x) If(Not x.Korvaustyyppi Is Nothing, x.Korvaustyyppi.Nimi, String.Empty)),
          CreateColumnMapping(Col_Korvaussumma, tc.DecimalType, Function(x) x.Summa),
          CreateColumnMapping(Col_KorvaussummaSisAlv, tc.DecimalType, Function(x) x.VerollinenSumma),
          CreateColumnMapping(Col_Vuosivuokra, tc.DecimalType, Function(x) x.VerollinenSumma),
          CreateColumnMapping(col_MaksuunMenevaSumma, tc.DecimalType, Function(x) handleri.haeMaksuunMenevaArvo(indeksit, x)),
          CreateColumnMapping(Col_Maksukuukausi, tc.StringType, Function(x) If(Not x.MaksuKuukausi Is Nothing, x.MaksuKuukausi.Nimi, String.Empty)),
          CreateColumnMapping(Col_Indeksityyppi, tc.StringType, Function(x) If(Not x.Indeksityyppi Is Nothing, x.Indeksityyppi.Nimi, String.Empty)),
          CreateColumnMapping(Col_SopimushetkenIndeksi, tc.IntegerType, Function(x) x.SopimushetkenIndeksiArvo),
          CreateColumnMapping(Col_Indeksivuosi, tc.IntegerType, Function(x) x.IndeksiVuosi),
          CreateColumnMapping(Col_Indeksikuukausi, tc.StringType, Function(x) If(Not x.IndeksiKuukausi Is Nothing, x.IndeksiKuukausi.Nimi, String.Empty)),
          CreateColumnMapping(Col_ViimeisinIndeksi, tc.IntegerType, Function(x) x.ViimeisinIndeksi),
          CreateColumnMapping(Col_Status, tc.StringType, Function(x) If(Not x.KorvauslaskelmaStatus Is Nothing, x.KorvauslaskelmaStatus.Nimi, String.Empty)),
          CreateColumnMapping(Col_EnsimmainenSallittuMaksupvm, tc.DateTimeType, Function(x) x.EnsimmainenSallittuMaksuPvm),
          CreateColumnMapping(Col_SaajanEtunimi, tc.StringType, Function(x) If(Not x.Saaja Is Nothing, x.Saaja.Etunimi, String.Empty)),
          CreateColumnMapping(Col_SaajanSukunimi, tc.StringType, Function(x) If(Not x.Saaja Is Nothing, x.Saaja.Sukunimi, String.Empty)),
          CreateColumnMapping(Col_AlkuperainenOsapuoli, tc.StringType, Function(x) String.Join(",", x.Sopimus.AlkuperaisetOsapuolet)),
          CreateColumnMapping(Col_Kiinteistotunnus, tc.StringType, Function(x) String.Join(",", x.Sopimus.Kiinteistotunnukset)),
          CreateColumnMapping(Col_KiinteistonKunta, tc.StringType, Function(x) String.Join(",", x.Sopimus.Kunnat))
      }
    End Function

    Private Function MuodostaHakuehdot() As Hakuehdot.KorvauslaskelmaHakuehdot
      Dim ehdot As New Hakuehdot.KorvauslaskelmaHakuehdot

      ehdot.KorvaustyyppiId = DataUtils.ParseNullableEnum(Of Korvaustyypit)(KorvaustyyppiId.SelectedValue)
      ehdot.MaksukuukausiId = DataUtils.ParseValue(Of Integer?)(MaksukuukausiId.SelectedValue)

      ehdot.SopimusHakuehdot = New Hakuehdot.SopimusHakuehdot()

      ehdot.SopimusHakuehdot.SopimustyyppiId = DataUtils.ParseNullableEnum(Of Sopimustyypit)(SopimustyyppiId.SelectedValue)

      ehdot.IncludePaths = New String() {"Rivit", "Sopimus", "Sopimus.SopimusKiinteistot", "Sopimus.Asiakkaat"}

      Return ehdot
    End Function

    Protected Overrides Function GetReportEntities() As IEnumerable(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)
      Dim handleri = New Sopimusrekisteri.DAL_CF.EntityHandlers.KorvauslaskelmaHandler(Me.DataContext)
      Dim korvauslaskelmat = handleri.HaeKorvauslaskelmat(MuodostaHakuehdot()).ToList()
      Dim ohjaustietohandleri = New Sopimusrekisteri.DAL_CF.EntityHandlers.OhjaustietoHandler(Me.DataContext)
      indeksit = ohjaustietohandleri.HaeVuodenIndeksit(DateTime.Now.Year)
      Return korvauslaskelmat
    End Function
  End Class

End Namespace
