Imports System.Reflection

Public Class Sopimusarkisto
  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Protected Sub btnListat_Click(sender As Object, e As EventArgs) Handles btnListat.Click

    Dim pyynto As New Liittymat.Sharepoint.Listat(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.SopimusarkistoHeratysUrl)

    Dim vastaus As Liittymat.Sharepoint.Vastaus(Of Liittymat.Sharepoint.Lista)

    vastaus = pyynto.HaeListat()

    If vastaus.Ok Then

      litListat.Text = String.Empty

      For Each l As Liittymat.Sharepoint.Lista In vastaus.Objektit

        litListat.Text &= l.Nimi & " | " & l.Guid & "<br />"

      Next

    Else

      litListat.Text = vastaus.Virheilmoitus

    End If

  End Sub

  Protected Sub btnNakymat_Click(sender As Object, e As EventArgs) Handles btnNakymat.Click

    Dim pyynto As New Liittymat.Sharepoint.Nakymat(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.SopimusarkistoHeratysUrl)

    Dim vastaus As Liittymat.Sharepoint.Vastaus(Of Liittymat.Sharepoint.Nakyma)

    vastaus = pyynto.HaeNakymat(txtNakymatListaId.Text)

    If vastaus.Ok Then

      litNakymat.Text = String.Empty

      For Each n As Liittymat.Sharepoint.Nakyma In vastaus.Objektit

        litNakymat.Text &= n.Nimi & " | " & n.Guid & "<br />"

      Next

    Else

      litNakymat.Text = vastaus.Virheilmoitus

    End If

  End Sub

  Protected Sub btnListanKentat_Click(sender As Object, e As EventArgs) Handles btnListanKentat.Click

    Dim pyynto As New Liittymat.Sharepoint.Listat(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.SopimusarkistoHeratysUrl)

    Dim vastaus As Liittymat.Sharepoint.Vastaus(Of String)

    vastaus = pyynto.HaeListanKentat(txtKentatListaId.Text, txtKentatNakymaId.Text)

    If vastaus.Ok Then

      litListanKentat.Text = String.Empty

      For Each s As String In vastaus.Objektit

        litListanKentat.Text &= s & "<br />"

      Next

    Else

      litListanKentat.Text = vastaus.Virheilmoitus

    End If

  End Sub

  Protected Sub btnHaeSopimus_Click(sender As Object, e As EventArgs) Handles btnHaeSopimus.Click

    Dim tiedostot As Liittymat.Sopimusarkisto.Tiedosto()

    tiedostot = Liittymat.Sopimusarkisto.Operaatiot.HaeSopimuksenTiedostot(txtSopimustunnus.Text)

    For Each tiedosto As Liittymat.Sopimusarkisto.Tiedosto In tiedostot

      lblSopimus.Text &= tiedosto.ID & " " & tiedosto.Rekisterinumero0 & " " & tiedosto.Kiinteist_x00f6_tunnus & " " & tiedosto.Asiakirjatarkenne

    Next

  End Sub

  Protected Sub btnPaivitaSopimus_Click(sender As Object, e As EventArgs) Handles btnPaivitaSopimus.Click

    Liittymat.Sopimusarkisto.Operaatiot.PaivitaSopimus(txtSopimustunnus.Text, New DTO.DataKonteksti("Sopimusarkisto"))

  End Sub

  Protected Sub btnPaivitaSopimusarkisto_Click(sender As Object, e As EventArgs) Handles btnPaivitaSopimusarkisto.Click

    Liittymat.Sopimusarkisto.Operaatiot.PaivitaSopimusarkisto()

  End Sub

  Protected Sub btnHaeKaikkiTiedot_Click(sender As Object, e As EventArgs) Handles btnHaeKaikkiTiedot.Click

    Dim sopimus As Liittymat.Sopimusarkisto.Tiedosto

    sopimus = Liittymat.Sopimusarkisto.Operaatiot.HaeSopimuksenTiedostot(txtSopimustunnus.Text).First()

    For Each pInfo As PropertyInfo In GetType(Liittymat.Sopimusarkisto.Tiedosto).GetProperties()

      litKaikkiTiedot.Text &= pInfo.Name & " = "
      If Not pInfo.GetValue(sopimus) Is Nothing Then
        litKaikkiTiedot.Text &= pInfo.GetValue(sopimus).ToString()
      End If

      litKaikkiTiedot.Text &= "<br />"

    Next

  End Sub

  Protected Sub btnHerata_Click(sender As Object, e As EventArgs) Handles btnHerata.Click

    Liittymat.Sharepoint.Heratys.Herata(Konfiguraatiot.SopimusarkistoHeratysUrl, Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana)

  End Sub

  Protected Sub btnNakymatHeratys_Click(sender As Object, e As EventArgs) Handles btnNakymatHeratys.Click

    Liittymat.Sharepoint.Heratys.Herata(Konfiguraatiot.SopimusarkistoHeratysUrl, Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana)

    Dim pyynto As New Liittymat.Sharepoint.Nakymat(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.SopimusarkistoHeratysUrl)

    Dim vastaus As Liittymat.Sharepoint.Vastaus(Of Liittymat.Sharepoint.Nakyma)

    vastaus = pyynto.HaeNakymat(txtNakymatListaId.Text)

    If vastaus.Ok Then

      litNakymat.Text = String.Empty

      For Each n As Liittymat.Sharepoint.Nakyma In vastaus.Objektit

        litNakymat.Text &= n.Nimi & " | " & n.Guid & "<br />"

      Next

    Else

      litNakymat.Text = vastaus.Virheilmoitus

    End If

  End Sub
End Class