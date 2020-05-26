Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Public Class Security
    Public Shared Sub ApplySecurity(ByVal _toolstrip As ToolStrip, ByVal form As String)
        Dim form_active As user_form = Nothing
        Dim toolstrip As ToolStrip = _toolstrip
        For Each f As user_form In user_info.form_user
            Console.WriteLine(f.FormName)
            Console.WriteLine(f.AllowAdd)
            Console.WriteLine(f.AllowEdit)
            Console.WriteLine(f.AllowDelete)
            Console.WriteLine(f.AllowPrint)
            If f.FormName = form Then
                form_active = f
            End If
        Next

        If form_active Is Nothing Then
            Exit Sub
        End If

        Dim item As ToolStripItemCollection = toolstrip.Items
        For i As Integer = 0 To item.Count - 1
            If TypeOf item(i) Is ToolStripButton Then
                Dim b = TryCast(item(i), ToolStripButton)
                If b.Text = "New" Then
                    b.Enabled = form_active.AllowAdd.Value
                End If

                If b.Text = "Edit" Then
                    b.Enabled = form_active.AllowEdit.Value
                End If

                If b.Text = "Delete" Then
                    b.Enabled = form_active.AllowDelete.Value
                End If

                If b.Text = "Save" Then
                    b.Enabled = form_active.AllowPrint.Value
                End If

                If b.Text = "Search" Then
                    b.Enabled = form_active.AllowSearch.Value
                End If
            End If
        Next
    End Sub

    Public Shared Sub UpdateSecurityRoles()
        user_info.form_user = New List(Of user_form)()
        Using db = New SqlConnection(MainModul.GetConnString)
            db.Open()
            Using reader As SqlDataReader = (New SqlCommand("SELECT uf.FormName,ua.AllowAdd,ua.AllowEdit,ua.AllowDelete,ua.AllowSearch,ua.AllowPrint FROM user_acess ua, form uf where ua.RoleID='" & user_info.login_role & "' and ua.FormID=uf.FormID", db)).ExecuteReader()
                While reader.Read()
                    Try
                        user_info.form_user.Add(New user_form() With {.FormName = reader(0).ToString(), .AllowAdd = If(reader("AllowAdd").ToString() = "True", True, False), .AllowEdit = If(reader("AllowEdit").ToString() = "True", True, False), .AllowDelete = If(reader("AllowDelete").ToString() = "True", True, False), .AllowSearch = If(reader("AllowSearch").ToString() = "True", True, False), .AllowPrint = If(reader("AllowPrint").ToString() = "True", True, False)})
                    Catch ex As Exception
                    End Try
                End While

                If Not reader.IsClosed Then
                    Try
                        reader.Close()
                    Catch
                    End Try
                End If

                For Each f As user_form In user_info.form_user
                    Console.WriteLine("Form Name:" & f.FormName)
                    Console.WriteLine("Form AllowAdd:" & f.AllowAdd)
                    Console.WriteLine("Form AllowEdit:" & f.AllowEdit)
                    Console.WriteLine("Form AllowDelete:" & f.AllowDelete)
                    Console.WriteLine("Form AllowPrint:" & f.AllowPrint)
                Next
            End Using
        End Using
    End Sub
End Class
