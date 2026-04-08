Imports System.ServiceModel.Description

Namespace Liittymat.Sharepoint

  Public Class Pyynto

    Public Sub New(kayttajatunnus As String, salasana As String, heratysUrl As String)
      Me.Kayttajatunnus = kayttajatunnus
      Me.Salasana = salasana

      Heratys.Herata(heratysUrl, kayttajatunnus, salasana)

    End Sub

    Public Property Kayttajatunnus As String
    Public Property Salasana As String
    Public Property Testi As Boolean = False

    Public Sub AsetaKredentiaalit(kredentiaalit As ClientCredentials)

      If Not String.IsNullOrEmpty(Me.Kayttajatunnus) And Not String.IsNullOrEmpty(Me.Salasana) Then
        kredentiaalit.Windows.ClientCredential.UserName = Konfiguraatiot.ServiceTunnus
        kredentiaalit.Windows.ClientCredential.Password = Konfiguraatiot.ServiceTunnusSalasana
      Else
        kredentiaalit.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation
      End If

    End Sub

    Public Function KasitteleVirhe(Of T)(virhe As Exception) As Vastaus(Of T)

      Dim objVastaus As New Vastaus(Of T)

      objVastaus.Virheilmoitus = virhe.Message

      While Not virhe.InnerException Is Nothing

        objVastaus.Virheilmoitus &= " " & virhe.InnerException.Message

        virhe = virhe.InnerException

      End While

      If TypeOf (virhe) Is System.ServiceModel.FaultException Then

        Dim soapVirhe As System.ServiceModel.Channels.MessageFault = CType(virhe, System.ServiceModel.FaultException).CreateMessageFault()

        Try

          objVastaus.Virheilmoitus &= soapVirhe.GetDetail(Of XElement).ToString()

        Catch ex As Exception

        End Try

      End If

      Return objVastaus

    End Function

  End Class

End Namespace
