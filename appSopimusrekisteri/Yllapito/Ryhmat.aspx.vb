Public Class Ryhmat

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      TaytaRoolit()
      TaytaRyhmat()

    End If

  End Sub

  Private Sub TaytaRyhmat()

    Dim ryhmalista = New DataTable()
    ryhmalista.Columns.Add("GroupId")
    ryhmalista.Columns.Add("GroupName")
    ryhmalista.Columns.Add("Roolit")

    Dim tietokanta = New BLL.Kayttajienhallinta()
    For Each ryhma In tietokanta.HaeKaikkiRyhmat()

      Dim lista As String = String.Empty
      Dim roolit = tietokanta.HaeRyhmanRoolit(ryhma.GroupName)
      For Each rooli As Entities.aspnet_Roles In roolit
        lista += rooli.RoleName + ", "
      Next
      If lista.EndsWith(", ") Then
        lista = lista.Remove(lista.Length - 2)
      End If

      Dim ryhmarivi = {ryhma.GroupId, ryhma.GroupName, lista}
      ryhmalista.Rows.Add(ryhmarivi)

    Next

    gwTulokset.DataSource = ryhmalista
    gwTulokset.DataBind()

  End Sub

  Private Sub TaytaRoolit()

    For Each rooli As String In Roles.GetAllRoles()
      ddRooli.Items.Add(New ListItem(rooli, rooli))
    Next
    ddRooli.Items.Insert(0, New ListItem("-- Valitse rooli --", "-1"))

  End Sub

  Private Sub gwTulokset_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gwTulokset.RowDeleting

    Dim poistettavaRivi = gwTulokset.Rows(e.RowIndex)
    Dim poistettavaRyhma = CType(poistettavaRivi.FindControl("lblId"), Literal).Text

    Dim tietokanta = New BLL.Kayttajienhallinta()
    tietokanta.PoistaRyhma(New Guid(poistettavaRyhma))

    TaytaRyhmat()

  End Sub


  Private Sub btLisaaRooliValittuihinRyhmiin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btLisaaRooliValittuihinRyhmiin.Click

    If ddRooli.SelectedIndex <> -1 Then

      Dim valitutRyhmat = HaeValitutRyhmat()

      If valitutRyhmat.Any() Then

        Dim tietokanta = New BLL.Kayttajienhallinta()
        tietokanta.LisaaRooliRyhmiin(ddRooli.SelectedValue, valitutRyhmat)

        For Each ryhma As String In valitutRyhmat

          Dim ryhmanKayttajat As List(Of Entities.aspnet_Users) = tietokanta.HaeRyhmanKayttajat(ryhma)

          For Each kayttaja As Entities.aspnet_Users In ryhmanKayttajat

            If Not Roles.IsUserInRole(kayttaja.UserName, ddRooli.SelectedValue) Then
              Roles.AddUserToRole(kayttaja.UserName, ddRooli.SelectedValue)
            End If

          Next

        Next

      End If

      TaytaRyhmat()

    End If
  End Sub

  Private Sub btPoistaRooliValituistaRyhmista_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btPoistaRooliValituistaRyhmista.Click

    If ddRooli.SelectedIndex <> -1 Then

      Dim valitutRyhmat = HaeValitutRyhmat()

      If valitutRyhmat.Any() Then

        Dim tietokanta = New BLL.Kayttajienhallinta()
        tietokanta.PoistaRooliRyhmista(ddRooli.SelectedValue, valitutRyhmat)

        For Each ryhma As String In valitutRyhmat

          Dim ryhmanKayttajat As List(Of Entities.aspnet_Users) = tietokanta.HaeRyhmanKayttajat(ryhma)

          For Each kayttaja As Entities.aspnet_Users In ryhmanKayttajat

            If Roles.IsUserInRole(kayttaja.UserName, ddRooli.SelectedValue) Then
              Roles.RemoveUserFromRole(kayttaja.UserName, ddRooli.SelectedValue)

              'jos henkilölle kuuluu rooli jonkun muun ryhmän kautta, lisätään rooli takaisin
              If RooliAvustaja.OnRooli(kayttaja.UserName, ddRooli.SelectedValue) Then
                Roles.AddUserToRole(kayttaja.UserName, ddRooli.SelectedValue)
              End If

            End If

          Next

        Next

      End If

      TaytaRyhmat()

    End If

  End Sub

  Private Function HaeValitutRyhmat() As List(Of String)

    Dim valitutRyhmat = New List(Of String)

    For Each rivi As GridViewRow In gwTulokset.Rows
      If rivi.RowType = DataControlRowType.DataRow Then
        If CType(rivi.FindControl("cbValittu"), CheckBox).Checked Then
          valitutRyhmat.Add(CType(rivi.FindControl("lblGroupName"), Literal).Text)
        End If
      End If
    Next

    Return valitutRyhmat

  End Function

  Protected Sub cbValitseKaikki_Checked(sender As Object, e As EventArgs)

    Dim valinta = CType(sender, CheckBox).Checked

    For Each rivi As GridViewRow In gwTulokset.Rows
      If rivi.RowType = DataControlRowType.DataRow Then
        CType(rivi.FindControl("cbValittu"), CheckBox).Checked = valinta
      End If
    Next

  End Sub

End Class