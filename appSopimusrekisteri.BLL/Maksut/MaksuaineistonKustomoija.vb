Imports System.Xml

Public Class MaksuaineistonKustomoija

  Public Shared Sub MuokkaaMaksuaineisto(polku As String)

    Dim xmlDoc As New XmlDocument()

    xmlDoc.Load(polku)

    For Each element As XmlElement In xmlDoc.GetElementsByTagName("CreDtTm")

      If IsDate(element.InnerText) Then

        element.InnerText = CDate(element.InnerText).ToString("yyyy-MM-ddTHH:mm:ss")

      End If

    Next

    xmlDoc.Save(polku)

  End Sub

End Class
