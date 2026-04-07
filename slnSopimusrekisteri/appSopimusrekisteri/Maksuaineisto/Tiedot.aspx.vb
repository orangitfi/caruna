Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils.Mapping

Public Class MaksunTiedot

  Inherits BasePage(Of Maksu)

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      Me.TaytaTiedot()

      If (IsNumeric(Request.Params("sopimusid"))) Then
        btnTakaisin.PostBackUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Request.Params("sopimusid"))
        btnTakaisin.Visible = True
      End If

    End If


  End Sub

  Public Sub TaytaTiedot()

    Me.FormMapper.FillForm(Me.pnlLomake, Me.Entity)

  End Sub

End Class
