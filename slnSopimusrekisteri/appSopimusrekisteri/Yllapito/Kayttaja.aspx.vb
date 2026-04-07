Imports System.Net.Mail

Public Class Kayttaja

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      If Not String.IsNullOrWhiteSpace(Request.Params("id")) Then

        Dim kayttajanTiedot = ProfileBase.Create(Request.Params("id"))
        txtKayttajatunnus.Enabled = False
        txtKayttajatunnus.Text = Request.Params("id")
        txtSahkoposti.Text = kayttajanTiedot("Email")
        txtEtunimi.Text = kayttajanTiedot("Etunimi")
        txtSukunimi.Text = kayttajanTiedot("Sukunimi")

      End If

    End If

  End Sub

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    ' Jos emme ole muokkaamassa käyttäjää...
    If String.IsNullOrWhiteSpace(Request.Params("id")) Then

      ' ...luomme uuden, jos sähköpostille ei ole rekisteröity käyttäjää
      If Membership.GetUser(txtKayttajatunnus.Text) Is Nothing Then

        'If Not TarkistaSalasananVahvuus(txtSalasana.Text) Then
        '  Return
        'End If

        Dim kayttaja = Membership.CreateUser(txtKayttajatunnus.Text, txtSalasana.Text)
        kayttaja.Email = txtSahkoposti.Text
        Membership.UpdateUser(kayttaja)

        Dim kayttajanTiedot = ProfileBase.Create(txtKayttajatunnus.Text)
        If Not kayttajanTiedot Is Nothing Then

          kayttajanTiedot("Etunimi") = txtEtunimi.Text
          kayttajanTiedot("Sukunimi") = txtSukunimi.Text
          kayttajanTiedot("Email") = txtSahkoposti.Text
          kayttajanTiedot.Save()

          If Konfiguraatiot.LahetaSahkopostiUudelleKayttajalle Then

            ' Lähetä tieto käyttäjätunnuksesta käyttäjälle
            Dim kohde As String = txtSahkoposti.Text
            Dim subject = "Sinulle on luotu käyttäjätunnus!"
            Dim body = String.Format("Hei {0}! Sinulle on luotu käyttäjätunnus {1} sopimusrekisteriin. Salasanasi on {2}.", txtEtunimi.Text, txtKayttajatunnus.Text, txtSalasana.Text)

            Dim objPalautusArvo As DTO.Palautusarvo

            objPalautusArvo = Email.Laheta({kohde}, subject, body)

            ' Lähetä viesti käyttäjälle
            If objPalautusArvo.Ok Then
              Response.Redirect("~/Yllapito/Kayttajat.aspx", True)
            Else
              ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "<script>alert('Sähköpostin lähettäminen käyttäjälle epäonnistui!');</script>", False)
            End If

          End If

        End If

      Else

        Dim virhe As New CustomValidator()
        virhe.ErrorMessage = "Järjestelmässä on jo käyttäjä " + txtKayttajatunnus.Text + "-tunnuksella"
        virhe.IsValid = False
        Page.Validators.Add(virhe)

      End If

    Else
      Dim kayttaja = Membership.GetUser(txtKayttajatunnus.Text)

      kayttaja.Email = txtSahkoposti.Text

      Membership.UpdateUser(kayttaja)

      If txtSalasana.Text.Length > 0 Then
        If Not TarkistaSalasananVahvuus(txtSalasana.Text) Then
          Return
        Else

          Dim salasana = kayttaja.ResetPassword()
          kayttaja.ChangePassword(salasana, txtSalasana.Text)
        End If
      End If

      Dim kayttajanTiedot = ProfileBase.Create(txtKayttajatunnus.Text)
      If Not kayttajanTiedot Is Nothing Then

        kayttajanTiedot("Etunimi") = txtEtunimi.Text
        kayttajanTiedot("Sukunimi") = txtSukunimi.Text
        kayttajanTiedot("Email") = txtSahkoposti.Text
        kayttajanTiedot.Save()

        Response.Redirect("~/Yllapito/Kayttajat.aspx", True)

      End If

    End If

  End Sub

  Private Function TarkistaSalasananVahvuus(salasana As String) As Boolean

    If String.IsNullOrWhiteSpace(salasana) Then
      Dim virhe As New CustomValidator()
      virhe.ErrorMessage = String.Format("Salasana ei voi olla tyhjä")
      virhe.IsValid = False
      Page.Validators.Add(virhe)
      Return False
    End If

    If salasana.Length < Membership.MinRequiredPasswordLength Then
      Dim virhe As New CustomValidator()
      virhe.ErrorMessage = String.Format("Salasanan tulee olla ainakin {0} merkkiä pitkä", Membership.MinRequiredPasswordLength)
      virhe.IsValid = False
      Page.Validators.Add(virhe)
      Return False
    End If

    Dim erikoismerkit = 0
    For Each merkki In salasana.ToCharArray()
      If Not Char.IsLetterOrDigit(merkki) Then
        erikoismerkit += 1
      End If
    Next

    If erikoismerkit < Membership.MinRequiredNonAlphanumericCharacters Then

      Dim virhe As New CustomValidator()
      virhe.ErrorMessage = String.Format("Salasanassa tulee olla ainakin {0} erikoismerkkiä", Membership.MinRequiredNonAlphanumericCharacters)
      virhe.IsValid = False
      Page.Validators.Add(virhe)
      Return False
    End If

    If Not Regex.IsMatch(salasana, Membership.PasswordStrengthRegularExpression) Then
      Return False
    End If

    Return True

  End Function

End Class