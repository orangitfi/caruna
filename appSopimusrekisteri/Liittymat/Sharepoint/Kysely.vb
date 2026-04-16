Imports System.Reflection

Namespace Liittymat.Sharepoint

  Public Class Kysely(Of T)

    Public Sub New(hakuehdot As T)
      Me.Hakuehdot = hakuehdot
    End Sub

    Public Function ToXml() As XElement
      Return Me.TeeKyselyXml()
    End Function

    Public Property Hakuehdot As T

    Private Function TeeKyselyXml() As XElement

      Dim xmlKysely As New XElement("Query")

      Dim xmlEhdot As New XElement("Where")

      Dim xmlOperaattori As XElement

      Dim pInfo As PropertyInfo

      For Each pInfo In GetType(T).GetProperties()

        If Not String.IsNullOrEmpty(pInfo.GetValue(Me.Hakuehdot)) Then

          xmlOperaattori = Me.HaeOperaattoriXml()

          xmlOperaattori.Add(Me.HaeKenttaXml(pInfo.Name))

          xmlOperaattori.Add(Me.HaeArvoXml(pInfo.GetValue(Me.Hakuehdot)))

          xmlEhdot.Add(xmlOperaattori)

        End If

      Next

      If xmlEhdot.Descendants.Count > 0 Then
        xmlKysely.Add(xmlEhdot)
      End If

      Return xmlKysely

    End Function

    Private Function HaeKenttaXml(kentta As String) As XElement

      Dim xmlKentta As New XElement("FieldRef")

      xmlKentta.Add(New XAttribute("Name", kentta))

      Return xmlKentta

    End Function

    Private Function HaeArvoXml(arvo As String) As XElement

      Dim xmlArvo As New XElement("Value")

      xmlArvo.Add(New XAttribute("Type", "Text"))

      xmlArvo.Value = arvo

      Return xmlArvo

    End Function

    Private Function HaeOperaattoriXml() As XElement
      Return New XElement("Eq")
    End Function

  End Class

End Namespace
