Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports AjaxControlToolkit

Namespace GeneralControls

  Public Class DateInput

    Inherits PlaceHolder
    Implements INamingContainer

    Private txtDate As TextBox
    Private imgPopup As Image
    Private calendar As CalendarExtender
    Private validaattori As CompareValidator

    Public Sub New()

      txtDate = New TextBox() With {.SkinID = "Datetime", .ID = "txtDate"}
      imgPopup = New Image() With {.SkinID = "CalendarImage", .AlternateText = "Valitse päivämäärä", .ID = "imgPopup"}
      validaattori = New CompareValidator() With {.ControlToValidate = txtDate.ID, .Operator = ValidationCompareOperator.DataTypeCheck, .Type = ValidationDataType.Date, .ErrorMessage = "Anna päivämäärä muodossa pp.mm.vvvv"}
      calendar = New CalendarExtender() With {.PopupButtonID = imgPopup.ID, .TargetControlID = txtDate.ID, .Format = "dd.MM.yyyy"}
    End Sub

    Protected Overrides Sub OnInit(e As EventArgs)
      MyBase.OnInit(e)

      Controls.Add(txtDate)
      Controls.Add(imgPopup)
      Controls.Add(calendar)
      Controls.Add(validaattori)
    End Sub

    Public Property Text As String
      Get
        Return txtDate.Text
      End Get
      Set
        txtDate.Text = Value
      End Set
    End Property

    Public Property DateValue As DateTime?
      Get
        If (String.IsNullOrEmpty(txtDate.Text)) Then
          Return Nothing
        End If
        Return DateTime.Parse(txtDate.Text)
      End Get
      Set
        If (Value.HasValue) Then
          txtDate.Text = Value.Value.ToShortDateString()
        End If
      End Set
    End Property

    Public Property ValidationGroup As String
      Get
        Return validaattori.ValidationGroup
      End Get
      Set
        validaattori.ValidationGroup = Value
      End Set
    End Property

    Public Property Enabled As Boolean
      Get
        Return txtDate.Enabled
      End Get
      Set
        txtDate.Enabled = Value
      End Set
    End Property
  End Class
End Namespace
