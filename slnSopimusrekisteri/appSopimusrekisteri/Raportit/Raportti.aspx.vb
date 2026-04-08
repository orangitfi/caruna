Imports System.IO

Public Class Raportti
  Inherits BasePage

#Region "Attribuutit ja vakiot"

  Private _raporttikonrolli As IReportControl
  Private _pager As DataPager

#End Region


#Region "Sivun eventit ja asetukset"

  Private Sub Raportti_Init(sender As Object, e As EventArgs)
    If (Not String.IsNullOrEmpty(Raporttinimi)) Then
      Dim c As Control = LoadControl(Raporttinimi)
      phValinnat.Controls.Add(c)
      _raporttikonrolli = CType(c, IReportControl)
      heading.InnerHtml = Raporttikontrolli.Otsikko

      If (Raporttikontrolli.SivutusKaytossa) Then
        InitPager()
      End If
      AddHandler Raporttikontrolli.OrderChanging, AddressOf grd_OrderChanging
    End If
  End Sub

  Private Sub InitPager()
    _pager = New DataPager() With {.PagedControlID = Raporttikontrolli.ReportDataBindControlId, .PageSize = Raporttikontrolli.SivunKoko}

    _pager.Fields.Add(New NextPreviousPagerField() With {.FirstPageText = "&lt;&lt;", .LastPageText = String.Empty, .NextPageText = String.Empty, .PreviousPageText = "&lt;", .ShowFirstPageButton = True, .ShowNextPageButton = False})

    _pager.Fields.Add(New NumericPagerField() With {.NumericButtonCssClass = "pieni"})

    _pager.Fields.Add(New NextPreviousPagerField() With {.FirstPageText = String.Empty, .LastPageText = "&gt;&gt;", .NextPageText = "&gt;", .PreviousPageText = String.Empty, .ShowLastPageButton = True, .ShowPreviousPageButton = False})

    phPager.Controls.Add(_pager)

    Dim grd As GridView = CType(Raporttikontrolli.ReportDataBindControl, GridView)
    If (Not IsNothing(grd)) Then AddHandler grd.PageIndexChanging, AddressOf grd_PageIndexChanging

    Dim lst As ListView = CType(Raporttikontrolli.ReportDataBindControl, ListView)
    If (Not IsNothing(lst)) Then AddHandler lst.PagePropertiesChanging, AddressOf lst_PagePropertiesChanging

  End Sub

  Protected Sub lst_PagePropertiesChanging(sender As Object, e As PagePropertiesChangingEventArgs)
    _pager.SetPageProperties(e.StartRowIndex, Raporttikontrolli.SivunKoko, False)
    MuodostaRaportti()
  End Sub

  Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
    _pager.SetPageProperties(e.NewPageIndex * Raporttikontrolli.SivunKoko, Raporttikontrolli.SivunKoko, False) ' Ei testattu!
  End Sub

  Protected Sub grd_OrderChanging(sender As Object, args As String)
    _raporttikonrolli.SortField = args
    MuodostaRaportti()
  End Sub

  Protected Sub Page_Load(sender As Object, e As EventArgs)
    If (String.IsNullOrEmpty(Raporttinimi)) Then
      divForm.Visible = False
    End If

    If (Not IsPostBack) Then
      lblDate.Text = DateTime.Now.ToShortDateString()
      lblHakuohje.Text = Raporttikontrolli.Hakuohje
      Header.Title = "Raportti " + DateTime.Now.ToShortDateString()
      lblOhje.Text = Raporttikontrolli.Ohjeteksti
      If (Raporttikontrolli.Automaattihaku) Then
        MuodostaRaportti()
      End If
    End If
  End Sub

  Public Overrides Sub VerifyRenderingInServerForm(control As Control)
    'base.VerifyRenderingInServerForm(control)
  End Sub

#End Region

#Region "Propertyt"

  Private ReadOnly Property Raporttikontrolli As IReportControl
    Get
      Return _raporttikonrolli
    End Get
  End Property
  Private ReadOnly Property Raporttinimi As String
    Get
      Return Server.UrlDecode(Request.Params("reportControl"))
    End Get
  End Property

#End Region

#Region "Raportin muodostus"

  Private Function MuodostaRaporttiHTML() As String
    Dim sb = New StringBuilder()
    Using tw = New StringWriter(sb)
      Dim writer = New HtmlTextWriter(tw)

      Raporttikontrolli.RenderReport(writer)
      writer.Flush()
      tw.Flush()
    End Using

    Return sb.ToString()
  End Function

  Private Function MuodostaAlaRaporttiHTML() As String
    Dim sb = New StringBuilder()
    Using tw = New StringWriter(sb)

      Dim writer = New HtmlTextWriter(tw)

      Raporttikontrolli.RenderSubReport(writer)
      writer.Flush()
      tw.Flush()
    End Using

    Return sb.ToString()
  End Function

  Private Sub MuodostaRaportti()
    reportContainer.InnerHtml = MuodostaRaporttiHTML()

    If (Raporttikontrolli.ReportData.Rows.Count > 0) Then

      pnlReport.Visible = True
      pnlSubReport.Visible = True

      'if (this.Raporttikontrolli.SivutusKaytossa)
      '{
      '    lblInfo.Text = ((ListView)this.Raporttikontrolli.ReportDataBindControl).Items.Count() + " / " + this.Raporttikontrolli.LkmTeksti;
      '}
      'else
      lblInfo.Text = Raporttikontrolli.LkmTeksti

      If (Raporttikontrolli.HasSubReport) Then
        subReportContainer.Visible = True

        subReportContainer.InnerHtml = MuodostaAlaRaporttiHTML()
      End If

    Else
      pnlReport.Visible = False
      pnlSubReport.Visible = False
      lblInfo.Text = Raporttikontrolli.Tyhjateksti
    End If
  End Sub

#End Region


#Region "Tiedostojen luonti"

  Private Function MuodostaTiedostonimi() As String
    Return Raporttikontrolli.Otsikko + " " + String.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
  End Function


  Private Sub LataaExcel()
    Dim strFilename As String = MuodostaTiedostonimi() + ".xlsx"
    Dim strPolku As String = Server.MapPath("~/Dokumentit/Excel/")

    Dim Data As DataTable = Raporttikontrolli.ReportData

    Components.ExcelBuilder.CreateExcelFromDataTable(Data, strPolku + strFilename, True, True)

    Response.Redirect("~/Dokumentit/Excel/" + strFilename)
  End Sub

#End Region


#Region "Tapahtumakäsittelijät"

  Public Sub New()

    AddHandler Load, AddressOf Page_Load
    AddHandler Init, AddressOf Raportti_Init
  End Sub

  Protected Sub btnTeeExcel_Click(sender As Object, e As ImageClickEventArgs)

    LataaExcel()
  End Sub

#End Region

  Protected Sub btnHae_OnClick(sender As Object, e As EventArgs)
    If (IsValid) Then
      MuodostaRaportti()
    End If
  End Sub

End Class
