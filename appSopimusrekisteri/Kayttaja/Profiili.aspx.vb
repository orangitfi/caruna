
Public Class Profiili

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      Dim kayttajanTiedot = ProfileBase.Create(Context.User.Identity.Name)
      txtKayttajatunnus.Text = Context.User.Identity.Name
      txtKayttajatunnus.Enabled = False
      txtSahkoposti.Text = kayttajanTiedot("Email")
      txtEtunimi.Text = kayttajanTiedot("Etunimi")
      txtSukunimi.Text = kayttajanTiedot("Sukunimi")

      If Request.Params("action") = "changepassword" Then
        lblViesti.Text = "Olet kirjautumassa ensimmäistä kertaa sisään järjestelmään. Suosittelemme sinua vaihtamaan salasanasi ennen jatkamista."
      End If

    Else

      lblAsetuksienTallentaminen.Text = ""
      CType(cpSalasananVaihtaminen.ChangePasswordTemplateContainer.FindControl("pError"), Panel).Visible = False

    End If

  End Sub

  Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

    ' Tallennetaan käyttäjän muut tiedot
    Dim kayttajanTiedot = ProfileBase.Create(txtSahkoposti.Text)
    If Not kayttajanTiedot Is Nothing Then

      kayttajanTiedot("Etunimi") = txtEtunimi.Text
      kayttajanTiedot("Sukunimi") = txtSukunimi.Text
      kayttajanTiedot("Email") = txtSahkoposti.Text
      kayttajanTiedot.Save()
      lblAsetuksienTallentaminen.Text = "Asetukset tallennettiin onnistuneesti!"
    End If

  End Sub

  Private Function TarkistaSalasananVahvuus(salasana As String) As Boolean

    If String.IsNullOrWhiteSpace(salasana) Then
      Return False
    End If

    If salasana.Length < Membership.MinRequiredPasswordLength Then
      Return False
    End If

    Dim erikoismerkit = 0
    For Each merkki In salasana.ToCharArray()
      If Char.IsLetterOrDigit(merkki) Then
        erikoismerkit += 1
      End If
    Next

    If erikoismerkit < Membership.MinRequiredNonAlphanumericCharacters Then
      Return False
    End If

    If Not Regex.IsMatch(salasana, Membership.PasswordStrengthRegularExpression) Then
      Return False
    End If

    Return True

  End Function

  Protected Sub cpSalasananVaihtaminen_ChangedPassword(sender As Object, e As EventArgs) Handles cpSalasananVaihtaminen.ChangedPassword

    lblAsetuksienTallentaminen.Text = ""

  End Sub

  Protected Sub cpSalasananVaihtaminen_ChangePasswordError(sender As Object, e As EventArgs) Handles cpSalasananVaihtaminen.ChangePasswordError

    CType(cpSalasananVaihtaminen.ChangePasswordTemplateContainer.FindControl("pError"), Panel).Visible = True
    Dim virhe As New CustomValidator()
    virhe.ErrorMessage = "Salasanan vaihto epäonnistui."
    virhe.IsValid = False
    Page.GetValidators("Salasanavalidaatio").Add(virhe)

  End Sub
End Class