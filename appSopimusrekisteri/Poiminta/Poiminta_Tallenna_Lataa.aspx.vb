Public Class Poiminta_Tallenna_Lataa
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsPostBack Then
      AsetaJoukot()
    End If
  End Sub

  Private Sub AsetaJoukot()
    Dim kanta As New BLL.Poiminta()
    Dim joukot As IEnumerable(Of Entities.TallennettuPoimintajoukko) = kanta.HaePoimintajoukot()
    lvTallennetutJoukot.DataSource = joukot
    lvTallennetutJoukot.DataBind()

    lblInfo.Text = "Tallennettuja poimintajoukkoja " & joukot.Count() & " kpl."
  End Sub

  Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click
    Dim kanta As New BLL.Poiminta()
    kanta.TallennaPoimintajoukko(txtNimi.Text, Context.User.Identity.Name, Context.Session.SessionID)

    AsetaJoukot()
  End Sub

  Protected Sub lvTallennetutJoukot_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles lvTallennetutJoukot.RowCommand
    Dim poimintajoukkoId = e.CommandArgument
    If e.CommandName = "lisaa" Then
      Dim tietokanta = New BLL.Poiminta()

      tietokanta.LisaaTallennettuPoimintaan(Context.Session.SessionID, poimintajoukkoId)
    End If
    If e.CommandName = "korvaa" Then
      Dim tietokanta = New BLL.Poiminta()

      tietokanta.TyhjennaPoiminta(Context.Session.SessionID)
      tietokanta.LisaaTallennettuPoimintaan(Context.Session.SessionID, poimintajoukkoId)
    End If
    If e.CommandName = "poista" Then
      Dim tietokanta = New BLL.Poiminta()

      tietokanta.PoistaPoimintajoukko(poimintajoukkoId)

      AsetaJoukot()
    End If
  End Sub

End Class