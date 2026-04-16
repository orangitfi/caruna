Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Net
Imports System.Security

Namespace Liittymat.Sharepoint

  Public Class Pyynto

    Public Sub New(kayttajatunnus As String, salasana As String, url As String)
      Me.Kayttajatunnus = kayttajatunnus
      Me.Salasana = salasana
      Me.Url = url
    End Sub

    Public Property Kayttajatunnus As String
    Public Property Salasana As String
    Public Property Url As String
    Public Property Testi As Boolean = False

    Public Sub Autentikoi()

      Dim p As New HttpRequestMessageProperty()

      Dim securePassword As New SecureString()

      Me.Salasana.ToCharArray().ToList().ForEach(AddressOf securePassword.AppendChar)

      Dim cookieHeader As String = ""

      OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = p

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
