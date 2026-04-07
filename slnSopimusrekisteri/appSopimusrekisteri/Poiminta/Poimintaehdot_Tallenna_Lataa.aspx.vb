Public Class Poimintaehdot_Tallenna_Lataa
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsPostBack Then
      AsetaEhdot()
      ValitseNakyykoTallennus()
    End If
  End Sub

  Private Sub ValitseNakyykoTallennus()
    If Not IsNothing(CType(Session("poimintaEhdot"), IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto))) AndAlso Not IsNothing(Session("poimintaTyyppi")) Then
      btnTallenna.Visible = True
      RequiredFieldValidator1.Visible = True
      txtNimi.Visible = True

      lblEhdot.Text = "Nykyinen poiminta: " & Session("poimintaTyyppi") & ", ehdot: " & String.Join("; ", CType(Session("poimintaEhdot"), IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto)).Select(Function(x) x.TPEEKenttaNaytolle & x.TPEEOperaattoriNaytolle & x.TPEEArvoNaytolle))
    End If
  End Sub

  Private Sub AsetaEhdot()
    Dim kanta As New BLL.Poiminta()
    Dim joukot As IEnumerable(Of Entities.TallennettuPoimintaehto) = kanta.HaePoimintaEhtojoukot()
    lvTallennetutEhdot.DataSource = joukot
    lvTallennetutEhdot.DataBind()

    lblInfo.Text = "Tallennettuja poimintajoukkoja " & joukot.Count() & " kpl."
  End Sub

  Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click
    Dim kanta As New BLL.Poiminta()
    kanta.TallennaPoimintaEhdot(txtNimi.Text, Session("poimintaEhdot"), Session("poimintaTyyppi"), Context.User.Identity.Name)

    AsetaEhdot()
  End Sub

  Protected Sub lvTallennetutEhdot_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles lvTallennetutEhdot.RowCommand
    Dim poimintaehdotId = e.CommandArgument
    If e.CommandName = "poimi" Then
      Dim tietokanta = New BLL.Poiminta()

      Response.Redirect("~/Poiminta/Poimintalomake.aspx?eid=" & poimintaehdotId)
    End If
    If e.CommandName = "poista" Then
      Dim tietokanta = New BLL.Poiminta()

      tietokanta.PoistaPoimintaEhdot(poimintaehdotId)

      AsetaEhdot()
    End If
  End Sub

End Class