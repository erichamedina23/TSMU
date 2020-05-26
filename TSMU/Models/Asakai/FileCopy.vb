Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.Security.Principal
Imports System.Runtime.InteropServices
Partial Public Class FileCopy
    Inherits System.Web.UI.Page

    <DllImport("advapi32.DLL", SetLastError:=True)>
    Public Shared Function LogonUser(ByVal lpszUsername As String, ByVal lpszDomain As String, ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef phToken As IntPtr) As Integer

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim token As IntPtr = Nothing

        If LogonUser("administrator", "tsmu", "Password", 2, 0, token) <> 0 Then
            Dim identity As WindowsIdentity = New WindowsIdentity(token)
            Dim context As WindowsImpersonationContext = identity.Impersonate()

            Try
                File.Copy("\\\\10.10.38.25\d$\\Sourav\\Draft Report ITC-LRBD_Online Booking Portal_12082016.pdf", "d:\\Draft Report ITC-LRBD_Online Booking Portal_12082016.pdf", True)
            Finally
                context.Undo()
            End Try
        End If
    End Sub


End Class


