Public Interface IReportControl
  ReadOnly Property Otsikko As String
  ReadOnly Property Hakuohje As String
  ReadOnly Property Ohjeteksti As String
  ReadOnly Property Tyhjateksti As String
  ReadOnly Property LkmTeksti As String
  ReadOnly Property Automaattihaku As Boolean
  ReadOnly Property SivutusKaytossa As Boolean
  ReadOnly Property SivunKoko As Integer
  ReadOnly Property ReportData As DataTable
  Property SortField As String
  Property SortOrder As String
  ReadOnly Property HasSubReport As Boolean
  ReadOnly Property ReportDataBindControl As Control
  ReadOnly Property ReportDataBindControlId As String

  Sub RenderReport(writer As HtmlTextWriter)
  Sub RenderSubReport(writer As HtmlTextWriter)

  Event OrderChanging As Delegates.SortDelegate
  Sub OnOrderChanging(sender As Object, args As String)

End Interface