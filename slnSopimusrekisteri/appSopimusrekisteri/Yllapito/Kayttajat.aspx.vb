Public Class Kayttajat

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      TaytaKayttajat()
      TaytaRoolit()
      TaytaRyhmat()

    End If

  End Sub

  Private Sub TaytaRyhmat()

    Dim tietokanta = New BLL.Kayttajienhallinta()

    For Each ryhma As Entities.aspnet_RoleGroups In tietokanta.HaeKaikkiRyhmat()
      ddRyhma.Items.Add(New ListItem(ryhma.GroupName, ryhma.GroupId.ToString()))
    Next
    ddRyhma.Items.Insert(0, New ListItem("-- Valitse ryhmä --", "-1"))

  End Sub

  Private Sub TaytaRoolit()

    For Each rooli As String In Roles.GetAllRoles()
      ddRooli.Items.Add(New ListItem(rooli, rooli))
    Next
    ddRooli.Items.Insert(0, New ListItem("-- Valitse oikeus --", "-1"))

  End Sub

  Private Sub TaytaKayttajat()

    Dim kayttajalista = New DataTable()
    kayttajalista.Columns.Add("Käyttäjä")
    kayttajalista.Columns.Add("Etunimi")
    kayttajalista.Columns.Add("Sukunimi")
    kayttajalista.Columns.Add("KäyttäjänRyhmät")
    kayttajalista.Columns.Add("KäyttäjänRoolit")

    Dim tietokanta As New BLL.Kayttajienhallinta()

    For Each kayttaja As MembershipUser In Membership.GetAllUsers()

      Dim kayttajanTiedot = ProfileBase.Create(kayttaja.UserName)
      Dim etunimi = kayttajanTiedot("Etunimi")
      Dim sukunimi = kayttajanTiedot("Sukunimi")

      Dim kayttajanRyhmat = String.Empty
      For Each ryhma In tietokanta.HaeKayttajanRyhmanimet(kayttaja.UserName)
        kayttajanRyhmat += ryhma + ", "
      Next
      If kayttajanRyhmat.EndsWith(", ") Then
        kayttajanRyhmat = kayttajanRyhmat.Remove(kayttajanRyhmat.Length - 2, 2)
      End If

      Dim kayttajanRoolit = String.Empty
      For Each rooli In Roles.GetRolesForUser(kayttaja.UserName)
        kayttajanRoolit += rooli + ", "
      Next
      If kayttajanRoolit.EndsWith(", ") Then
        kayttajanRoolit = kayttajanRoolit.Remove(kayttajanRoolit.Length - 2, 2)
      End If

      Dim kayttajarivi = {kayttaja, etunimi, sukunimi, kayttajanRyhmat, kayttajanRoolit}
      kayttajalista.Rows.Add(kayttajarivi)

    Next

    gwTulokset.DataSource = kayttajalista
    gwTulokset.DataBind()

  End Sub

  Private Sub gwTulokset_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gwTulokset.RowDataBound

    If e.Row.RowType = DataControlRowType.DataRow Then
      CType(e.Row.FindControl("hlMuokkaa"), LinkButton).PostBackUrl = String.Format("~/Yllapito/Kayttaja.aspx?id={0}", CType(e.Row.FindControl("lblKayttaja"), Literal).Text)
    End If

  End Sub

  Private Sub gwTulokset_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gwTulokset.RowDeleting

    Dim poistettavaRivi = gwTulokset.Rows(e.RowIndex)
    Dim poistettavaNimi = CType(poistettavaRivi.FindControl("lblKayttaja"), Literal).Text

    Dim tietokanta = New BLL.Kayttajienhallinta()

    Dim ryhmat As List(Of Entities.aspnet_RoleGroups)

    ryhmat = tietokanta.HaeKayttajanRyhmat(poistettavaNimi)

    For Each r As Entities.aspnet_RoleGroups In ryhmat

      tietokanta.PoistaKayttajaRyhmasta(poistettavaNimi, r.GroupId)

    Next

    Membership.DeleteUser(poistettavaNimi)

    TaytaKayttajat()

  End Sub

  Private Sub btLisaaValitutKayttajatRooliin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btLisaaValitutKayttajatRooliin.Click

    If ddRooli.SelectedIndex <> -1 Then

      Dim valitutKayttajat = HaeValitutKayttajat()

      If valitutKayttajat.Any() Then

        If Roles.RoleExists(ddRooli.SelectedValue) Then
          For Each valittuKayttaja As String In valitutKayttajat
            If Not Roles.IsUserInRole(valittuKayttaja, ddRooli.SelectedValue) Then
              Roles.AddUserToRole(valittuKayttaja, ddRooli.SelectedValue)
            End If
          Next
        End If

        TaytaKayttajat()

      End If

    End If

  End Sub

  Private Sub btPoistaValitutKayttajatRoolista_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btPoistaValitutKayttajatRoolista.Click

    If ddRooli.SelectedIndex <> -1 Then

      Dim valitutKayttajat = HaeValitutKayttajat()

      If valitutKayttajat.Any() Then

        If Roles.RoleExists(ddRooli.SelectedValue) Then
          For Each valittuKayttaja As String In valitutKayttajat
            If Roles.IsUserInRole(valittuKayttaja, ddRooli.SelectedValue) Then
              Roles.RemoveUserFromRole(valittuKayttaja, ddRooli.SelectedValue)
            End If
          Next
        End If

        TaytaKayttajat()

      End If

    End If

  End Sub

  Private Function HaeValitutKayttajat() As List(Of String)

    Dim valitutKayttajat = New List(Of String)

    For Each rivi As GridViewRow In gwTulokset.Rows
      If rivi.RowType = DataControlRowType.DataRow Then
        If CType(rivi.FindControl("cbValittu"), CheckBox).Checked Then
          valitutKayttajat.Add(CType(rivi.FindControl("lblKayttaja"), Literal).Text)
        End If
      End If
    Next

    Return valitutKayttajat

  End Function

  Protected Sub cbValitseKaikki_Checked(sender As Object, e As EventArgs)

    Dim valinta = CType(sender, CheckBox).Checked

    For Each rivi As GridViewRow In gwTulokset.Rows
      If rivi.RowType = DataControlRowType.DataRow Then
        CType(rivi.FindControl("cbValittu"), CheckBox).Checked = valinta
      End If
    Next

  End Sub



  Private Sub btLisaaValitutKayttajatRyhmaan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btLisaaValitutKayttajatRyhmaan.Click

    If ddRyhma.SelectedIndex <> -1 Then

      Dim valitutKayttajat = HaeValitutKayttajat()

      If valitutKayttajat.Any() Then

        Dim tietokanta = New BLL.Kayttajienhallinta()
        Dim roolit = tietokanta.LisaaKayttajatRyhmaan(valitutKayttajat, Guid.Parse(ddRyhma.SelectedValue))

        For Each rooli As Entities.aspnet_Roles In roolit

          For Each valittuKayttaja As String In valitutKayttajat

            If Not Roles.IsUserInRole(valittuKayttaja, rooli.RoleName) Then
              Roles.AddUserToRole(valittuKayttaja, rooli.RoleName)
            End If

          Next
        Next

        TaytaKayttajat()

      End If

    End If

  End Sub

  Private Sub btPoistaValitutKayttajatRyhmasta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btPoistaValitutKayttajatRyhmasta.Click

    If ddRyhma.SelectedIndex <> -1 Then

      Dim valitutKayttajat = HaeValitutKayttajat()

      If valitutKayttajat.Any() Then

        Dim tietokanta = New BLL.Kayttajienhallinta()
        Dim roolit = tietokanta.PoistaKayttajatRyhmasta(valitutKayttajat, Guid.Parse(ddRyhma.SelectedValue))

        For Each Rooli As Entities.aspnet_Roles In roolit

          For Each valittuKayttaja As String In valitutKayttajat

            If Roles.IsUserInRole(valittuKayttaja, Rooli.RoleName) Then
              Roles.RemoveUserFromRole(valittuKayttaja, Rooli.RoleName)

              'jos henkilölle kuuluu rooli jonkun muun ryhmän kautta, lisätään rooli takaisin
              If RooliAvustaja.OnRooli(valittuKayttaja, Rooli.RoleName) Then
                Roles.AddUserToRole(valittuKayttaja, Rooli.RoleName)
              End If

            End If

          Next
        Next

        TaytaKayttajat()

      End If

    End If

  End Sub


End Class