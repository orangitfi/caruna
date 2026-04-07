Imports System.Net.Mail

Public Class Email

  Public Shared Function Laheta(kohde As String, aihe As String, viesti As String) As DTO.Palautusarvo

    Return Laheta({kohde}, aihe, viesti)

  End Function

  Public Shared Function Laheta(kohteet As IEnumerable(Of String), aihe As String, viesti As String) As DTO.Palautusarvo

    Dim smtp As New SmtpClient(Konfiguraatiot.SmtpPalvelin)
    Dim objMail As New MailMessage()

    objMail.From = New MailAddress(Konfiguraatiot.SahkopostinLahettaja)

    For Each kohde As String In kohteet
      objMail.To.Add(kohde)
    Next

    objMail.Subject = aihe
    objMail.Body = viesti

    Dim objPalautusarvo As New DTO.Palautusarvo()

    Try

      smtp.Send(objMail)

    Catch ex As Exception

      Dim objVirhe As New DTO.Virhe()

      objVirhe.Virhe = ex
      objVirhe.Data = ex.Message

      objPalautusarvo.Virheet.Add(objVirhe)

    End Try

    Return objPalautusarvo
  End Function

End Class
