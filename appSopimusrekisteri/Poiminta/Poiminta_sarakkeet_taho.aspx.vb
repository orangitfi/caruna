Public Class Poiminta_sarakkeet_taho
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(Me).Where(Function(x) x.ID.Contains("Sarake"))
        LisaaKiinteistoSarakkeet(valikko)
      Next

    End If

  End Sub

  Private Sub LisaaKiinteistoSarakkeet(valikko As DropDownList)

    valikko.Items.Add(Pudotusvalikko.LuoValinta("Nimi", "Nimi"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Etunimi", "Etunimi"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Sukunimi", "Sukunimi"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimustenTunnisteet", "Sopimusten tunnisteet"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimustenMuutTunnisteet", "Sopimusten muut tunnisteet"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Tyyppi", "Tyyppi"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Ytunnus", "Y-tunnus"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Osoite", "Osoite"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Postinumero", "Postinumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Postitoimipaikka", "Postitoimipaikka"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Puhelin", "Puhelin"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Email", "Email"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Rooli", "Rooli"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Tilinumero", "Tilinumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Bic", "Bic"))

    Pudotusvalikko.Jarjesta(valikko)

    valikko.Items.Insert(0, Pudotusvalikko.LuoTyhjaValinta())

  End Sub

  Protected Sub btnTallenna_Click(sender As Object, e As EventArgs) Handles btnTallenna.Click

    Dim dicSarakkeet As New Dictionary(Of String, String)()

    dicSarakkeet.Add("Nimi", "Nimi")

    For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(Me).Where(Function(x) x.ID.Contains("Sarake"))

      If valikko.SelectedValue <> "-1" Then
        If Not dicSarakkeet.ContainsKey(valikko.SelectedValue) Then
          dicSarakkeet.Add(valikko.SelectedValue, valikko.SelectedItem.Text)
        End If
      End If

    Next

    Sessio.PoiminnanSarakkeetTaholle(Session) = dicSarakkeet

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

  Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

End Class