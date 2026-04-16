Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions

Public Class LevyJaot
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  <DllImport("advapi32.DLL", SetLastError:=True)> _
  Public Shared Function LogonUser(ByVal lpszUsername As String, ByVal lpszDomain As String, _
        ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
        ByRef phToken As IntPtr) As Integer
  End Function

  Protected Sub btnKopioi_Click(sender As Object, e As EventArgs) Handles btnKopioi.Click

    Dim admin_token As IntPtr
    Dim wid_current As WindowsIdentity = WindowsIdentity.GetCurrent()
    Dim wid_admin As WindowsIdentity = Nothing
    Dim wic As WindowsImpersonationContext = Nothing
    Try

      If LogonUser(Konfiguraatiot.ServiceTunnus, ConfigurationManager.AppSettings("ServiceTunnusDomain"), Konfiguraatiot.ServiceTunnusSalasana, 9, 0, admin_token) <> 0 Then
        wid_admin = New WindowsIdentity(admin_token)
        wic = wid_admin.Impersonate()
        System.IO.File.Copy(txtLahde.Text, txtKohde.Text, True)
        Label1.Text = "OK"
      Else
        Label1.Text = "Ei OK"
      End If
    Catch se As System.Exception
      Dim ret As Integer = Marshal.GetLastWin32Error()
      Label1.Text = "Ei todellakaan OK" & se.Message
    Finally
      If wic IsNot Nothing Then
        wic.Undo()
      End If
    End Try

  End Sub

End Class