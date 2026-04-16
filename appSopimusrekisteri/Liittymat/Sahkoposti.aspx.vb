Imports System.Net.Mail
Imports System.Net

Public Class Sahkoposti
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Protected Sub btnLahetaTesti_Click(sender As Object, e As EventArgs) Handles btnLahetaTesti.Click

    Dim smtp As New SmtpClient(Konfiguraatiot.SmtpPalvelin)

    smtp.Credentials = New NetworkCredential(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana)

    Dim viesti As New MailMessage(Konfiguraatiot.SahkopostinLahettaja, txtSaaja.Text)

    viesti.Subject = "Testiviesti sopimusrekisteristä"

    viesti.Body = "Hei, tämä on testiviesti Carunan sopimusrekisteristä"

    smtp.Send(viesti)

  End Sub
End Class