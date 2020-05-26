Public Class FrmSystem_ChangePassword
    'Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    '    TxtPwdLama.TextChanged, TxtPwdBaru.TextChanged, TxtKonfirmasi.TextChanged
    '    Dim txt As TextBox = sender
    '    txt.Text = Format(NumValue(txt.Text), "#")
    '    txt.Select(txt.TextLength, 0)
    'End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '# Validate...
        '## Input kosong...
        If TxtPwdLama.Text.Trim = "" Then
            ShowMessage("Please input current password!", MessageTypeEnum.ErrorMessage)
            TxtPwdLama.Focus()
            Exit Sub
        End If
        If TxtPwdBaru.Text.Trim = "" Then
            ShowMessage("Please input new password!", MessageTypeEnum.ErrorMessage)
            TxtPwdBaru.Focus()
            Exit Sub
        End If
        If TxtKonfirmasi.Text.Trim = "" Then
            ShowMessage("Please input password confirmation!", MessageTypeEnum.ErrorMessage)
            TxtKonfirmasi.Focus()
            Exit Sub
        End If

        '## Check password lama...
        Dim lc_User As New ClassSystemUser1
        lc_User.Username = gh_Common.Username
        lc_User.Password = TxtPwdLama.Text.Trim
        If lc_User.CheckLoginPasswordBinary(gh_Common.Username, TxtPwdLama.Text.Trim) = False Then
            ShowMessage("Current password not match!", MessageTypeEnum.ErrorMessage)
            Exit Sub
        End If

        '## Password baru & Konfirmasi harus sama...
        If TxtPwdBaru.Text.ToUpper <> TxtKonfirmasi.Text.ToUpper Then
            ShowMessage("Password and password confirmation must be same!", MessageTypeEnum.ErrorMessage)
            Exit Sub
        End If

        Dim ls_Error As String = ""
        Try
            lc_User.Password = TxtPwdBaru.Text.Trim
            lc_User.UpdatePassword()
            If ls_Error <> "" Then
                ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                Exit Sub
            Else
                ShowMessage(GetMessage(MessageEnum.SimpanBerhasil))
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Dispose()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub TxtPwdLama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles TxtPwdLama.KeyPress, TxtPwdBaru.KeyPress, TxtKonfirmasi.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmSystem_ChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MdiParent = FrmMain

        TxtPwdLama.Text = ""
        TxtPwdBaru.Text = ""
        TxtKonfirmasi.Text = ""
    End Sub

    Private Sub FrmSystem_ChangePassword_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TxtPwdLama.Focus()
    End Sub
End Class
