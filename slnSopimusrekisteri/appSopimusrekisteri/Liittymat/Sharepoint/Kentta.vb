Namespace Liittymat.Sharepoint

  Public Class Kentta

    Public Property Nimi As String
    Public Property Arvo As String

    Public Function ToXml() As XElement
      Return Me.TeeKenttaXml()
    End Function

    Private Function TeeKenttaXml() As XElement

      Dim xmlKentta As New XElement("Field")

      xmlKentta.Add(New XAttribute("Name", Me.Nimi))

      xmlKentta.Value = Me.Arvo

      Return xmlKentta

    End Function

  End Class

End Namespace
