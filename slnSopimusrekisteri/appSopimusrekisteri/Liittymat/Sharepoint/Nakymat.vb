Imports appSopimusrekisteri.SopimusarkistoViews
Imports System.ServiceModel

Namespace Liittymat.Sharepoint

  Public Class Nakymat
    Inherits Pyynto

    'Private _client As ViewsSoapClient

    Public Sub New(kayttajatunnus As String, salasana As String, url As String)
      MyBase.New(kayttajatunnus, salasana, url)

      '_client = New ViewsSoapClient()

    End Sub

    Public Function HaeNakymat(listaId As String) As Vastaus(Of Nakyma)

      Dim objVastaus As Vastaus(Of Nakyma)

      Try

        Dim xmlNakymat As XElement

        ''Using New OperationContextScope(_client.InnerChannel)
        ''
        ''  Autentikoi()
        ''
        ''  xmlNakymat = _client.GetViewCollection(listaId)
        ''
        ''End Using

        Dim lstNakymat As New List(Of Nakyma)()
        Dim objNakyma As Nakyma

        For Each el As XElement In xmlNakymat.Elements

          objNakyma = New Nakyma()

          objNakyma.Nimi = el.Attribute("DisplayName").Value
          objNakyma.Guid = el.Attribute("Name").Value

          lstNakymat.Add(objNakyma)

        Next

        objVastaus = New Vastaus(Of Nakyma)()

        objVastaus.Objektit = lstNakymat.ToArray()
        objVastaus.Ok = True

      Catch ex As Exception

        objVastaus = Me.KasitteleVirhe(Of Nakyma)(ex)

      End Try

      Return objVastaus

    End Function

  End Class

End Namespace
