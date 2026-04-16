Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions
Imports System.IO

Public Class Tiedostot

  <DllImport("advapi32.DLL", SetLastError:=True)> _
  Public Shared Function LogonUser(ByVal lpszUsername As String, ByVal lpszDomain As String, _
        ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
        ByRef phToken As IntPtr) As Integer
  End Function

  Public Shared Sub Kopioi(lahdePolku As String, kohdePolku As String, kayttajatunnus As String, salasana As String, domain As String)

    Dim token As IntPtr
    Dim identity As WindowsIdentity = Nothing
    Dim context As WindowsImpersonationContext = Nothing

    Try

      If LogonUser(kayttajatunnus, domain, salasana, 9, 0, token) <> 0 Then

        identity = New WindowsIdentity(token)

        context = identity.Impersonate()

        File.Copy(lahdePolku, kohdePolku, True)

      Else

        Throw New Security.SecurityException("Ei oikeuksia polkuun " & kohdePolku)

      End If

    Finally

      If Not context Is Nothing Then
        context.Undo()
      End If

    End Try

  End Sub

  Public Shared Function HaeYksilollinenTiedostonimi(kansiopolku As String, tiedosto As String) As String

    Dim i As Integer = 1

    If Not kansiopolku.EndsWith("\") Then

      kansiopolku &= "\"

    End If

    While File.Exists(kansiopolku & tiedosto)

      tiedosto = Path.GetFileNameWithoutExtension(tiedosto) & "(" & i & ")" & Path.GetExtension(tiedosto)

      i += 1

    End While


    Return tiedosto

  End Function

End Class
