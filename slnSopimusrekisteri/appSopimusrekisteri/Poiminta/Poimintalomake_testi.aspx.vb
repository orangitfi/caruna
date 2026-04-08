Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers
Imports Sopimusrekisteri.BLL_CF.Poiminnat
Imports KT.Utils

Public Class Poimintalomake_testi
  Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Poiminta)

  Private _otsikot As IEnumerable(Of Label)
  Private _operaattorit As IEnumerable(Of PoimintaOperaattori)

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      Me.AlustaSivu()

    End If

  End Sub

  Private Sub AlustaSivu()

    Sessio.Poimintaehdot.Add(New PoimintaehdotSopimus With {.Toiminto = Me.Toiminto})

    Me.TaytaPudotusvalikot()

  End Sub

  Private Sub TaytaPudotusvalikot()

    'DataBindDropDownList(Me.s_sopimustyyppi, Me.DataContext.Korvaustyypit.OrderBy(Function(x) x.KorvaustyyppiNimi).ToArray(), "0", "KorvaustyyppiNimi", "Id")

    DataBindDropDownList(Me.s_SopimustyyppiId, Me.DataContext.Sopimustyypit.OrderBy(Function(x) x.SopimustyyppiNimi).ToArray(), "0", "SopimustyyppiNimi", "Id")

  End Sub

  Public Shared Sub DataBindDropDownList(ddl As DropDownList, datasource As Object, emptyIdValue As String, dataTextField As String, dataValueField As String)

    If Not String.IsNullOrEmpty(dataTextField) Then ddl.DataTextField = dataTextField
    If Not String.IsNullOrEmpty(dataValueField) Then ddl.DataValueField = dataValueField

    ddl.DataSource = datasource
    ddl.DataBind()

    LuoTyhjaValintaPudotusvalikkoon(ddl, emptyIdValue)

  End Sub

  Public Shared Sub LuoTyhjaValintaPudotusvalikkoon(ddl As DropDownList, idarvo As String)
    ddl.Items.Insert(0, New ListItem("Valitse", idarvo))
  End Sub

  Protected Overrides Function CreateDataContext() As Sopimusrekisteri.DAL_CF.KiltaDataContext

    Dim dataContext As Sopimusrekisteri.DAL_CF.KiltaDataContext = MyBase.CreateDataContext()

    dataContext.Configuration.AutoDetectChangesEnabled = False
    dataContext.Configuration.ValidateOnSaveEnabled = False
    dataContext.SessioId = Me.Session.SessionID

    Return dataContext

  End Function

  Protected ReadOnly Property Toiminto As Poimintatoiminto
    Get

      Dim arvo As String = Me.Request.QueryString("action")

      If String.IsNullOrEmpty(arvo) Then Return Sopimusrekisteri.BLL_CF.Poimintatoiminto.UusiPoiminta

      Return DataUtils.ParseEnum(Of Poimintatoiminto)(arvo)

    End Get
  End Property

  Private Sub TeePoiminta()

    Dim kysely As IQueryable(Of Sopimusrekisteri.BLL_CF.Sopimus) = Me.DataContext.Sopimukset

    Me.LuoEhdot()

    kysely = Me.Ehdot.MuodostaPoiminta(kysely)

    Me.PoimintaHandler.TeePoiminta(kysely, Me.Toiminto)

  End Sub

  Private Sub LuoEhdot()

    Me.Ehdot.DataContext = Me.DataContext

    Me.LisaaEhdot(pnlSopimus, "s_", Me.Ehdot)
    'this.LisaaEhdot(pJasenyys, "j_", this.Ehdot.Jasenyysehdot);

    'if (this.Ehdot.Jasenyysehdot != null && this.Ehdot.Jasenyysehdot.Ehdot.Count > 0)
    '{
    '  this.Ehdot.LisaaEhto(PoimintaehdotTaho.Key_Jasenyys, true.ToString(), TypeFormatterFunctions.FormatBooleanStr(true));
    '}

  End Sub

  Private Sub LisaaEhdot(paneeli As Panel, etuliite As String, ehdot As IPoimintaehdot)

    For Each textBoxControl As TextBox In WebUtils.GetChildControlsByType(Of TextBox)(paneeli)
      Me.LisaaTextBoxEhto(textBoxControl, StringUtils.RemovePrefix(textBoxControl.ID, etuliite), ehdot)
    Next

    For Each dropDownListControl As DropDownList In WebUtils.GetChildControlsByType(Of DropDownList)(paneeli).Where(Function(x) x.Parent.GetType().BaseType <> GetType(PoimintaOperaattori))
      Me.LisaaDropDownListEhto(dropDownListControl, StringUtils.RemovePrefix(dropDownListControl.ID, etuliite), ehdot)
    Next

    '    foreach (DateTextBox dateTextBoxControl in WebUtils.GetChildControlsByType<DateTextBox>(paneeli))
    '{

    '  this.LisaaDateEhto(dateTextBoxControl, Utils.StringUtils.RemovePrefix(dateTextBoxControl.ID, etuliite), ehdot);

    '}

    For Each checkBoxControl As CheckBox In WebUtils.GetChildControlsByType(Of CheckBox)(paneeli).Where(Function(x) x.Checked)
      Me.LisaaBooleanEhtoCheckBox(checkBoxControl, StringUtils.RemovePrefix(checkBoxControl.ID, etuliite), ehdot)
    Next

    For Each listBoxControl As ListBox In WebUtils.GetChildControlsByType(Of ListBox)(paneeli)
      Me.LisaaListaehto(listBoxControl, StringUtils.RemovePrefix(listBoxControl.ID, etuliite), ehdot)
    Next

  End Sub

  Private Sub LisaaTextBoxEhto(textbox As TextBox, avain As String, ehdot As IPoimintaehdot)

    Dim operaattori As Sopimusrekisteri.BLL_CF.PoimintaOperaattori = Me.HaeOperaattori(textbox)

    If Not String.IsNullOrEmpty(textbox.Text) Or Me.NullOperaattorit.Contains(operaattori) Then
      ehdot.LisaaEhto(avain, textbox.Text, Me.HaeOtsikko(textbox), operaattori)
    End If

  End Sub

  Private Sub LisaaDropDownListEhto(ddl As DropDownList, avain As String, ehdot As IPoimintaehdot)

    Dim operaattori As Sopimusrekisteri.BLL_CF.PoimintaOperaattori = Me.HaeOperaattori(ddl)

    If (Not String.IsNullOrEmpty(ddl.SelectedValue) AndAlso ddl.SelectedValue <> "0") Or Me.NullOperaattorit.Contains(operaattori) Then
      ehdot.LisaaEhto(avain, ddl.SelectedValue, ddl.SelectedItem.Text, Me.HaeOtsikko(ddl), operaattori)
    End If

  End Sub

  Private Sub LisaaBooleanEhtoCheckBox(checkbox As CheckBox, avain As String, ehdot As IPoimintaehdot)

    'ehdot.LisaaEhto(avain, checkbox.Checked.ToString(), Muuttujat.EsitaBoolean(checkbox.Checked))

  End Sub

  Private Sub LisaaListaehto(lista As ListBox, avain As String, ehdot As IPoimintaehdot)

    Dim arvot As IEnumerable(Of String) = WebUtils.GetListBoxSelectedValues(lista)

    If arvot.Any() Then

      'ehdot.LisaaEhto(avain, CollectionUtils.CollectionToCsv(arvot, ","), Me.GetListboxSelectedTexts(lista))

    End If

  End Sub

  Private Function GetListboxSelectedTexts(lista As ListBox) As String

    Return CollectionUtils.CollectionToCsv(WebUtils.GetListBoxSelectedItems(lista).Select(Function(x) x.Text), ", ")

  End Function

  Private Function HaeOtsikko(kontrolli As Control) As String

    If Me.Otsikot.Any(Function(x) x.AssociatedControlID = kontrolli.ID) Then
      Return Me.Otsikot.First(Function(x) x.AssociatedControlID = kontrolli.ID).Text
    End If

    Return String.Empty
  End Function

  Private Function HaeOperaattori(kontrolli As Control) As Sopimusrekisteri.BLL_CF.PoimintaOperaattori

    If Me.Operaattorit.Any(Function(x) x.AssociatedControlId = kontrolli.ID) Then

      Return [Enum].Parse(GetType(Sopimusrekisteri.BLL_CF.PoimintaOperaattori), Me.Operaattorit.First(Function(x) x.AssociatedControlId = kontrolli.ID).SelectedValue)

    End If

    Return Sopimusrekisteri.BLL_CF.PoimintaOperaattori.YhtaSuuri
  End Function

  Private ReadOnly Property Otsikot As IEnumerable(Of Label)
    Get
      If Me._otsikot Is Nothing Then
        Me._otsikot = WebUtils.GetChildControlsByType(Of Label)(Me).Where(Function(x) Not String.IsNullOrEmpty(x.AssociatedControlID))
      End If

      Return Me._otsikot
    End Get
  End Property

  Private ReadOnly Property Operaattorit As IEnumerable(Of PoimintaOperaattori)
    Get
      If Me._operaattorit Is Nothing Then
        Me._operaattorit = WebUtils.GetChildControlsByType(Of PoimintaOperaattori)(Me)
      End If

      Return Me._operaattorit
    End Get
  End Property

  Private ReadOnly Property Ehdot As PoimintaehdotSopimus
    Get
      Return Sessio.Poimintaehdot.Last()
    End Get
  End Property

  Private ReadOnly Property PoimintaHandler As PoimintaHandler
    Get
      Return CType(Me.EntityHandler, PoimintaHandler)
    End Get
  End Property

  Private ReadOnly Property NullOperaattorit As IEnumerable(Of Sopimusrekisteri.BLL_CF.PoimintaOperaattori)
    Get
      Return {Sopimusrekisteri.BLL_CF.PoimintaOperaattori.Tyhja, Sopimusrekisteri.BLL_CF.PoimintaOperaattori.EiTyhja}
    End Get
  End Property

  Protected Sub btPoimi_Click(sender As Object, e As EventArgs) Handles btPoimi.Click

    Me.TeePoiminta()

    Response.Redirect("Poimintajoukko_testi.aspx")

  End Sub

  Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

    Response.Redirect("Poimintajoukko_testi.aspx")

  End Sub

End Class