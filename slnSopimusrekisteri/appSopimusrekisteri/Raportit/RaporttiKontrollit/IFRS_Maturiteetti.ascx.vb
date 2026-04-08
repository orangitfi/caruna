Imports System.Globalization
Imports Sopimusrekisteri.BLL_CF.Models

Public Class IFRS_Maturiteetti
    Inherits System.Web.UI.UserControl

    Private _formaatti As NumberFormatInfo

    Protected ReadOnly Property Formaatti As NumberFormatInfo
        Get
            If _formaatti Is Nothing Then
                _formaatti = New NumberFormatInfo With {.NumberGroupSeparator = " ", .NumberDecimalSeparator = ","}
            End If
            Return _formaatti
        End Get
    End Property

    Public Property Otsikko As String
        Get
            Return lblOtsikko.Text
        End Get
        Set(value As String)
            lblOtsikko.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub TaytaTiedot(data As IEnumerable(Of IFRSMaturiteetti))

        lstTiedot.DataSource = data.ToArray()
        lstTiedot.DataBind()

    End Sub

End Class