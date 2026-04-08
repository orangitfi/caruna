Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Reflection
Imports System.Web
Imports System.Web.UI
Imports appSopimusrekisteri.Delegates
Imports KT.Utils
Imports KT.Utils.Mapping

Public MustInherit Class ReportControlBase(Of T)
  Inherits BaseControl
  Implements IReportControl

#Region "Attribuutit ja vakiot"

  Private _reportData As DataTable

  Private _reportEntities As IEnumerable(Of T)

  Public event OrderChanging As SortDelegate Implements IReportControl.OrderChanging

#End Region


  Public Overridable Sub OnOrderChanging(sender As Object, args As String) Implements IReportControl.OnOrderChanging
    RaiseEvent OrderChanging(sender, args)
  End Sub

  Public ReadOnly Property ReportData As DataTable Implements IReportControl.ReportData
    Get

      If IsNothing(_reportData) Then
        _reportData = CreateReportData()
      End If
      Return _reportData
    End Get
  End Property

  Public Function GetReportData() As DataTable

    Dim data As DataTable = ReportData

    If (Not IsNothing(SortField)) Then
      Dim View As DataView = data.DefaultView

      View.Sort = SortField

      data = View.ToTable()
    End If

    '//return this.ReportData;
    Return data
  End Function

  Public Property SortField As String Implements IReportControl.SortField
  Public Property SortOrder As String Implements IReportControl.SortOrder

  Public MustOverride Function GetSubReportData() As DataTable

  Private Function CreateReportData() As DataTable
    Return KT.Utils.Mapping.DataTableMapper.EntitiesToDataTable(Of T)(ReportEntities, GetColumnMappings(New TypeCache()))
  End Function

  Protected Function CreateColumnMapping(columnName As String, dataType As Type, valueFunction As Func(Of T, Object)) As DataColumnMapping(Of T)
    Return New DataColumnMapping(Of T)(columnName, dataType, valueFunction)
  End Function

  Protected MustOverride Function GetColumnMappings(tc As TypeCache) As IEnumerable(Of DataColumnMapping(Of T))

  Protected MustOverride Function GetReportEntities() As IEnumerable(Of T)

  Protected ReadOnly Property ReportEntities As IEnumerable(Of T)
    Get

      If (IsNothing(_reportEntities)) Then
        _reportEntities = GetReportEntities().ToArray()
      End If
      Return _reportEntities
    End Get
  End Property

  Protected MustOverride ReadOnly Property ReportContainerControl As Control

  Protected MustOverride ReadOnly Property SubReportContainerControl As Control

  Public MustOverride ReadOnly Property ReportDataBindControl As Control Implements IReportControl.ReportDataBindControl

  Protected MustOverride ReadOnly Property SubReportDataBindControl As Control

  Public ReadOnly Property ReportDataBindControlId As String Implements IReportControl.ReportDataBindControlId
    Get
      Return ReportDataBindControl.UniqueID
    End Get
  End Property

  Public Overridable Sub RenderReport(writer As HtmlTextWriter) Implements IReportControl.RenderReport
    RenderReport(writer, ReportContainerControl, ReportDataBindControl, GetReportData())
  End Sub

  Public Overridable Sub RenderSubReport(writer As HtmlTextWriter) Implements IReportControl.RenderSubReport
    If (HasSubReport) Then
      RenderReport(writer, SubReportContainerControl, SubReportDataBindControl, GetSubReportData())
    End If
  End Sub

  Private Sub RenderReport(writer As HtmlTextWriter, reportContainer As Control, reportControl As Control, data As DataTable)
    Dim dataBindControlType As Type = reportControl.GetType()

    Dim pi As PropertyInfo = dataBindControlType.GetProperty("DataSource")
    Dim mi As MethodInfo = dataBindControlType.GetMethod("DataBind")

    reportContainer.Visible = True

    pi.SetValue(reportControl, data)

    mi.Invoke(reportControl, Nothing)

    reportContainer.RenderControl(writer)

    reportContainer.Visible = False

  End Sub

  Public Overridable ReadOnly Property SivutusKaytossa As Boolean Implements IReportControl.SivutusKaytossa
    Get
      Return False
    End Get
  End Property

  Public Overridable ReadOnly Property SivunKoko As Integer Implements IReportControl.SivunKoko

    Get
      Return 40
    End Get
  End Property

  Public Overridable ReadOnly Property LkmTeksti As String Implements IReportControl.LkmTeksti

    Get
      Return String.Format("{0} kpl", Rivimaara)
    End Get
  End Property

  Public Overridable ReadOnly Property Rivimaara As Integer

    Get
      Return ReportData.Rows.Count
    End Get
  End Property

  Public Overridable ReadOnly Property Tyhjateksti As String Implements IReportControl.Tyhjateksti

    Get
      Return "Ei tietoja."
    End Get
  End Property

  Public Overridable ReadOnly Property Ohjeteksti As String Implements IReportControl.Ohjeteksti
    Get
      Return String.Empty
    End Get
  End Property

  Public Overridable ReadOnly Property Hakuohje As String Implements IReportControl.Hakuohje
    Get
      Return String.Empty
    End Get
  End Property

  Public MustOverride ReadOnly Property HasSubReport As Boolean Implements IReportControl.HasSubReport

  Public MustOverride ReadOnly Property Otsikko As String Implements IReportControl.Otsikko

  Public MustOverride ReadOnly Property Automaattihaku As Boolean Implements IReportControl.Automaattihaku

End Class