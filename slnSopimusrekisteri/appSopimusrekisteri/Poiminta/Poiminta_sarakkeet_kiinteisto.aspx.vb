  Public Class Poiminta_sarakkeet_kiinteisto
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      If Not IsPostBack Then

        For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(Me).Where(Function(x) x.ID.Contains("Sarake"))
        LisaaKiinteistoSarakkeet(valikko)
        Next

      End If

    End Sub

  Private Sub LisaaKiinteistoSarakkeet(valikko As DropDownList)

    valikko.Items.Add(Pudotusvalikko.LuoValinta("Id", "Sopimusnumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Ytunnus", "Y-tunnus"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Osoite", "Osoite"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Postinumero", "Postinumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Postitoimipaikka", "Postitoimipaikka"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Maa", "Maa"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Kyla", "Kylä"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Kunta", "Kunta"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Rekisterinumero", "Rekisterinumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("LyhytKiinteistotunnus", "Lyhyt kiinteistötunnus"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("KokonaisPintaAla", "Kokonaispinta-ala"))

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

    Sessio.PoiminnanSarakkeetKiinteistolle(Session) = dicSarakkeet

      Response.Redirect("Poimintajoukko.aspx")

    End Sub

    Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

      Response.Redirect("Poimintajoukko.aspx")

    End Sub

  End Class