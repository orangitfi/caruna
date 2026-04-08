Imports System.Reflection
Imports System.IO

Namespace Liittymat.Sharepoint

  Public Class TestiClient

    Private Const LISTA_KENTTA_ETULIITE As String = "ows_"

    Public Sub New()

    End Sub

    Public Function UpdateListItems(listName As String, updates As XElement) As XElement

      Dim stream As New FileStream("C:\Temp\sharepoint\updatelistitems.xml", FileMode.Append)

      updates.Save(stream)

      stream.Flush()
      stream.Close()

      Return New XElement("Test")

    End Function

    Public Function GetListItems(Of T)(listName As String, viewName As String, query As XElement, viewFields As XElement, rowLimit As String, queryOptions As XElement, webID As String) As XElement

      Dim parent As New XElement("Parent")
      Dim elements As New XElement("Elements")
      Dim element As New XElement("Element")
      Dim attribute As XAttribute
      Dim pType As Type

      For Each pInfo As PropertyInfo In GetType(T).GetProperties()

        If pInfo.GetCustomAttributes(GetType(KenttaAttribuutti), False).Count > 0 Then

          Dim objKenttaAttribuutti As KenttaAttribuutti = CType(pInfo.GetCustomAttributes(GetType(KenttaAttribuutti), False).First(), KenttaAttribuutti)

          If objKenttaAttribuutti.Tunniste Then

            attribute = New XAttribute(LISTA_KENTTA_ETULIITE & pInfo.Name, 1)

            element.Add(attribute)

          End If

        End If

        If pInfo.Name = "Asiakirjatarkenne" Then

          attribute = New XAttribute(LISTA_KENTTA_ETULIITE & pInfo.Name, "Liite")

          element.Add(attribute)

        End If

      Next

      elements.Add(element)
      parent.Add(elements)

      Return parent

    End Function

  End Class

End Namespace