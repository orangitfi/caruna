Namespace Liittymat.Sharepoint

  Public Class Metodi

    Private _lstKentat As List(Of Kentta)

    Public Sub New()
      _lstKentat = New List(Of Kentta)()
    End Sub

    Public Property Komento As String
    Public Property Id As Integer
    Public ReadOnly Property Kentat As Kentta()
      Get
        Return _lstKentat.ToArray()
      End Get
    End Property

    Public Sub LisaaKentta(nimi As String, arvo As Object, type As Type)
      Dim objKentta As New Kentta()

      objKentta.Nimi = nimi

      If type = GetType(Date) Then
        objKentta.Arvo = CDate(arvo).ToString("yyyy-MM-ddTHH:mm:ssZ")
      Else
        objKentta.Arvo = arvo.ToString()
      End If

      _lstKentat.Add(objKentta)
    End Sub

    Public Function ToXml() As XElement
      Return Me.TeeMetodiXml()
    End Function

    Private Function TeeMetodiXml() As XElement

      Dim xmlMetodi As New XElement("Method")

      xmlMetodi.Add(New XAttribute("ID", Me.Id))
      xmlMetodi.Add(New XAttribute("Cmd", Me.Komento))

      For Each k As Kentta In Me.Kentat
        xmlMetodi.Add(k.ToXml())
      Next

      Return xmlMetodi

    End Function

  End Class

End Namespace
