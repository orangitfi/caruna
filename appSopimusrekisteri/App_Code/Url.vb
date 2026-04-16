Public Module Url

  Public Function LuoParametrit(parametrit As Dictionary(Of String, String)) As String

    Dim urlParametrit = String.Empty
    For Each parametri In parametrit
      Dim urlParametri = String.Format("{0}={1}", HttpUtility.UrlEncode(parametri.Key), HttpUtility.UrlEncode(parametri.Value))
      urlParametrit = urlParametrit + urlParametri
    Next
    Return urlParametrit

  End Function

  Public Function KoostaQueryString(parametrit As NameValueCollection) As String

    Dim strQueryString As String = String.Empty

    Dim lstQueryStringParametrit As New List(Of String)()

    For Each parametri As String In parametrit
      lstQueryStringParametrit.Add(String.Format("{0}={1}", parametri, parametrit(parametri)))
    Next

    If lstQueryStringParametrit.Count > 0 Then
      strQueryString = "?" & Join(lstQueryStringParametrit.ToArray(), "&")
    End If

    Return strQueryString

  End Function

End Module
