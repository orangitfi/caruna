Imports System.Reflection

Namespace Liittymat.Sharepoint

  Public Class Era(Of T)

    Private _lstMetodit As List(Of Metodi)

    Public Sub New()
      _lstMetodit = New List(Of Metodi)()
    End Sub

    Public Function ToXml() As XElement
      Return Me.TeeEraXml()
    End Function

    Private Function TeeEraXml() As XElement

      Dim xmlEra As New XElement("Batch")
      xmlEra.Add(New XAttribute("OnError", "Return"))
      xmlEra.Add(New XAttribute("ListVersion", "1"))

      For Each m As Metodi In _lstMetodit
        xmlEra.Add(m.ToXml())
      Next

      Return xmlEra

    End Function

    Public Sub LisaaPaivitysMetodi(objekti As T)

      Dim objMetodi As New Metodi()

      objMetodi.Id = _lstMetodit.Count + 1
      objMetodi.Komento = "Update"

      Dim pInfo As PropertyInfo
      Dim pType As Type

      For Each pInfo In GetType(T).GetProperties()

        If Not pInfo.GetValue(objekti) Is Nothing Then

          If pInfo.GetCustomAttributes(GetType(KenttaAttribuutti), False).Count > 0 Then

            pType = pInfo.PropertyType

            If pType.IsGenericType AndAlso pType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then

              pType = Nullable.GetUnderlyingType(pType)

            End If

            Dim objKenttaAttribuutti As KenttaAttribuutti = CType(pInfo.GetCustomAttributes(GetType(KenttaAttribuutti), False).First(), KenttaAttribuutti)

            If objKenttaAttribuutti.Paivitettava = True Or objKenttaAttribuutti.Tunniste = True Then
              objMetodi.LisaaKentta(pInfo.Name, pInfo.GetValue(objekti), pType)
            End If

          End If

        End If

      Next

      _lstMetodit.Add(objMetodi)

    End Sub


  End Class

End Namespace
