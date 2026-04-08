Public Class JavascriptAvustaja

  Public Shared Sub LisaaAlert(sivu As Page, viesti As String)

    ScriptManager.RegisterClientScriptBlock(sivu, sivu.GetType(), "alertMessage", String.Format("<script>alert('{0}');</script>", SanitoiTeksti(viesti)), False)

  End Sub

  Public Shared Sub LisaaTuplaklikinEsto(kontrolli As WebControl, sivu As Page)

    kontrolli.Attributes.Add("onclick", "this.disabled=true;" & sivu.ClientScript.GetPostBackEventReference(kontrolli, "").ToString())

  End Sub

  Public Shared Sub LisaaTuplaklikinEstoVarmistuksella(kontrolli As WebControl, sivu As Page, varmistusviesti As String)

    kontrolli.Attributes.Add("onclick", "if(confirm('" & varmistusviesti & "')){this.disabled=true;" & sivu.ClientScript.GetPostBackEventReference(kontrolli, "").ToString() & "}else{return false;}")

  End Sub

  Public Shared Function SanitoiTeksti(teksti As String) As String

    If Not String.IsNullOrEmpty(teksti) Then

      teksti = teksti.Replace(vbCrLf, String.Empty)
      teksti = teksti.Replace("'", """")

    End If

    Return teksti

  End Function

End Class
