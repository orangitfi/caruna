Imports System.Globalization
Imports Sopimusrekisteri.BLL_CF.Models

Public Class IFRS_Kausi
    Inherits System.Web.UI.UserControl

    Private _formaatti As NumberFormatInfo

    Protected Property Kausi As IFRSKausi

    Protected ReadOnly Property Formaatti As NumberFormatInfo
        Get
            If _formaatti Is Nothing Then
                _formaatti = New NumberFormatInfo With {.NumberGroupSeparator = " ", .NumberDecimalSeparator = ","}
            End If
            Return _formaatti
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub TaytaTiedot(data As IFRSKausi)

        Kausi = data

        lblErottelu.Text = data.IFRSLaskenta.Count() & " kpl"

        lstTiedot.DataSource = data.IFRSLaskenta.OrderBy(Function(x) x.Sopimusnumero).ToArray()
        lstTiedot.DataBind()

        lstYhteensa.DataSource = data.YhteensaVuokratyypeittain.ToArray()
        lstYhteensa.DataBind()

        phYhteensa.Visible = data.Laskenta.Any()

        lstYhteenvedot.DataSource = data.YhteenvetoVuokratyypeittain.ToArray()
        lstYhteenvedot.DataBind()

    End Sub

End Class