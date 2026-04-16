Imports KT.Utils
Imports KT.Utils.Mapping
Imports Sopimusrekisteri.BLL_CF

Namespace RaporttiKontrollit

  Public Class Korvauslaskelma
    Inherits ReportControlBase(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)
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
        Return "Korvauslaskelma"
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
      WebUtils.DataBindDropDownList(StatusId, DataContext.KorvauslaskelmaStatukset.Select(Function(x) New With {.Id = x.Id, .Nimi = x.Nimi}).ToList(), Function(x) New ListItem(x.Nimi, x.Id), "Valitse", "")
      WebUtils.DataBindDropDownList(MaksunSuoritusId, DataContext.MaksunSuoritukset.Select(Function(x) New With {.Id = x.Id, .Nimi = x.Nimi}).ToList(), Function(x) New ListItem(x.Nimi, x.Id), "Valitse", "")
      WebUtils.DataBindDropDownList(InvCostId, DataContext.InvCostit.Select(Function(x) New With {.Id = x.Id, .Nimi = x.Nimi}).ToList(), Function(x) New ListItem(x.Nimi, x.Id), "Valitse", "")
      WebUtils.DataBindDropDownList(RegulationId, DataContext.Regulationit.Select(Function(x) New With {.Id = x.Id, .Nimi = x.Nimi}).ToList(), Function(x) New ListItem(x.Nimi, x.Id), "Valitse", "")
      WebUtils.DataBindDropDownList(PurposeId, DataContext.Purposet.Select(Function(x) New With {.Id = x.Id, .Nimi = x.Nimi}).ToList(), Function(x) New ListItem(x.Nimi, x.Id), "Valitse", "")
      WebUtils.DataBindDropDownList(Local1Id, DataContext.Local1t.Select(Function(x) New With {.Id = x.Id, .Nimi = x.Nimi}).ToList(), Function(x) New ListItem(x.Nimi, x.Id), "Valitse", "")
    End Sub

    Public Overrides Function GetSubReportData() As DataTable
      Throw New NotImplementedException()
    End Function

    Protected Overrides Function GetColumnMappings(tc As TypeCache) As IEnumerable(Of KT.Utils.Mapping.DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma))
      Return New DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)() _
      {
        CreateColumnMapping("Tunnus", tc.IntegerType, Function(x) x.Id),
        CreateColumnMapping("Sopimusnumero", tc.IntegerType, Function(x) x.SopimusId),
        CreateColumnMapping("Asiakas", tc.StringType, Function(x) If(Not IsNothing(x.Saaja), x.Saaja.Nimi, "")),
        CreateColumnMapping("VerotonSumma", tc.DecimalType, Function(x) x.Summa),
        CreateColumnMapping("Alv", tc.DecimalType, Function(x) If(Not IsNothing(x.Alv), x.Alv.Prosentti, 0.0)),
        CreateColumnMapping("VerollinenSumma", tc.DecimalType, Function(x) x.VerollinenSumma),
        CreateColumnMapping("MaksunSuoritus", tc.StringType, Function(x) If(Not IsNothing(x.MaksunSuoritus), x.MaksunSuoritus.Nimi, "")),
        CreateColumnMapping("Korvaustyyppi", tc.StringType, Function(x) If(Not IsNothing(x.Korvaustyyppi), x.Korvaustyyppi.Nimi, "")),
        CreateColumnMapping("Projektinumero", tc.StringType, Function(x) If(Not String.IsNullOrEmpty(x.KorvauksenProjektinumero), x.KorvauksenProjektinumero, x.Sopimus.PCSNumero)),
        CreateColumnMapping("Tila", tc.StringType, Function(x) If(Not IsNothing(x.KorvauslaskelmaStatus), x.KorvauslaskelmaStatus.Nimi, "")),
        CreateColumnMapping("KirjanpidonTili", tc.StringType, Function(x) If(Not IsNothing(x.KirjanpidonTili), x.KirjanpidonTili.Nimi, "")),
        CreateColumnMapping("KirjanpidonKustannuspaikka", tc.StringType, Function(x) If(Not IsNothing(x.KirjanpidonKustannuspaikka), x.KirjanpidonKustannuspaikka.Nimi, "")),
        CreateColumnMapping("InvCost", tc.StringType, Function(x) If(Not IsNothing(x.InvCost), x.InvCost.Nimi, "")),
        CreateColumnMapping("Regulation", tc.StringType, Function(x) If(Not IsNothing(x.Regulation), x.Regulation.Nimi, "")),
        CreateColumnMapping("Purpose", tc.StringType, Function(x) If(Not IsNothing(x.Purpose), x.Purpose.Nimi, "")),
        CreateColumnMapping("Local1", tc.StringType, Function(x) If(Not IsNothing(x.Local1), x.Local1.Nimi, ""))
      }
    End Function

    Private Function MuodostaHakuehdot() As Hakuehdot.KorvauslaskelmaHakuehdot
      Dim ehdot As New Hakuehdot.KorvauslaskelmaHakuehdot
      ehdot.KorvaustyyppiId = DataUtils.ParseNullableEnum(Of Korvaustyypit)(KorvaustyyppiId.SelectedValue)
      ehdot.StatusId = DataUtils.ParseIntOrNull(StatusId.SelectedValue)
      ehdot.MaksuSuoritusId = DataUtils.ParseIntOrNull(MaksunSuoritusId.SelectedValue)
      ehdot.Sopimusnumero = DataUtils.ParseIntOrNull(Sopimusnumero.Text)
      ehdot.Viite = Viite.Text
      ehdot.Projektinumero = Projektinumero.Text
      ehdot.EnsimmainenSallittuMaksupaivaAlku = EnsimmainenSallittuMaksupaivaAlku.DateValue
      ehdot.EnsimmainenSallittuMaksupaivaLoppu = EnsimmainenSallittuMaksupaivaLoppu.DateValue
      ehdot.KirjanpidonTili = Kirjanpidontili.Text
      ehdot.KirjanpidonKustannuspaikka = KirjanpidonKustannuspaikka.Text
      ehdot.InvCostId = DataUtils.ParseIntOrNull(InvCostId.SelectedValue)
      ehdot.RegulationId = DataUtils.ParseIntOrNull(RegulationId.SelectedValue)
      ehdot.PurposeId = DataUtils.ParseIntOrNull(PurposeId.SelectedValue)
      ehdot.Local1Id = DataUtils.ParseIntOrNull(Local1Id.SelectedValue)
      Return ehdot
    End Function

    Protected Overrides Function GetReportEntities() As IEnumerable(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)
      Dim handleri = New Sopimusrekisteri.DAL_CF.EntityHandlers.KorvauslaskelmaHandler(Me.DataContext)
      Dim korvauslaskelmat = handleri.HaeKorvauslaskelmat(MuodostaHakuehdot()).ToList()
      Return korvauslaskelmat
    End Function
  End Class

End Namespace