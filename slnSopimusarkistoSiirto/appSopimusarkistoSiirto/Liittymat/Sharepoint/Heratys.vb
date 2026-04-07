Imports System.Net

Namespace Liittymat.Sharepoint

  Public Class Heratys

    Public Shared Sub Herata(url As String, kayttajaTunnus As String, salasana As String)

      Dim request As HttpWebRequest = HttpWebRequest.Create(url)

      request.Credentials = New NetworkCredential(kayttajaTunnus, salasana)

      request.GetResponse()

    End Sub

  End Class

End Namespace
