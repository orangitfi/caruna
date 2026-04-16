Public Class Poiminta_sarakkeet_sopimus
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      For Each valikko As DropDownList In Kontrollit.HaeKontrollit(Of DropDownList)(Me).Where(Function(x) x.ID.Contains("Sarake"))
        LisaaSopimusSarakkeet(valikko)
      Next

    End If

  End Sub

  Private Sub LisaaSopimusSarakkeet(valikko As DropDownList)

    valikko.Items.Add(Pudotusvalikko.LuoValinta("Id", "Sopimusnumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Sopimustyyppi", "Sopimustyyppi"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("PCSNumero", "Projektinumero"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Projektinvalvoja", "Projektivalvoja"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("MuuTunniste", "Muu tunniste"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimuksenLaatija", "Sopimuksen laatija"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Korvaa", "Korvaa sopimuksen"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("DFRooli", "Verkkoyhtiön rooli sopimuksessa"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Karttaliite", "Karttaliite"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("AsiakkaanAllekirjoitusPvm", "Asiakkaan allekirjoituspäivämäärä"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("VerkonhaltijanAllekirjoitusPvm", "Verkonhaltijan allekirjoituspäivämäärä"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Alkupvm", "Alkupvm"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Paattymispvm", "Päättymispvm"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Jatkoaika", "Sopimuksen jatkoaika (kk)"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimuksenIrtisanomisaika", "Sopimuksen irtisanomisaika (kk)"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimuksenIrtisanomistoimet", "Sopimuksen irtisanomistoimet"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Kieli", "Kieli"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Luonnos", "Luonnos"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Erityisehdot", "Erityisehdot"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("YlasopimuksenTyyppi", "Yläsopimuksen tyyppi"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("AlkuperainenYhtio", "Alkuperäinen yhtiö"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Julkisuusaste", "Julkisuusaste"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimuksenAlaluokka", "Sopimuksen alaluokka"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("SopimuksenEhtoversio", "Sopimuksen ehtoversio"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Kuvaus", "Sisällön yleiskuvaus"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("VerkonhaltijaSiirtoOikeus", "Sopimuksen siirto-oikeus verkonhaltija"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("VastaosapuoliSiirtoOikeus", "Sopimuksen siirto-oikeus vastaosapuoli"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Irtisanomispvm", "Sopimuksen irtisanomispvm"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("Kohdekategoria", "Sopimuksen kohdekategoria"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("PuustonOmistajuus", "Puuston omistajuus"))
    valikko.Items.Add(Pudotusvalikko.LuoValinta("PuustonPoisto", "Puuston poisto"))

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

    Sessio.PoiminnanSarakkeetSopimukselle(Session) = dicSarakkeet

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

  Protected Sub btnPeruuta_Click(sender As Object, e As EventArgs) Handles btnPeruuta.Click

    Response.Redirect("Poimintajoukko.aspx")

  End Sub

End Class