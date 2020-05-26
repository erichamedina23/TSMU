Imports DevExpress.XtraEditors

Public Class frmSystemPathConfig
    Private Sub frmSystemPathConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        LoadSetting()
    End Sub
    Private Sub LoadSetting()
        TxtFilename.Text = My.Settings.Filename
        TxtFilePath.Text = My.Settings.FilePath
    End Sub
    Public Overrides Sub Proc_SaveData()
        If TxtFilename.Text <> "" AndAlso TxtFilePath.Text <> "" Then
            My.Settings.Filename = TxtFilename.Text
            My.Settings.FilePath = TxtFilePath.Text
            My.Settings.Save()
            XtraMessageBox.Show("Setting sudah di simpan.")
        Else
            XtraMessageBox.Show("Filename atau File Path tidak boleh kosong.")
        End If
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadSetting()
    End Sub

    Private Sub TxtFilePath_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles TxtFilePath.ButtonClick
        Dim simpan As FolderBrowserDialog = New FolderBrowserDialog
        Dim result As DialogResult = simpan.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            TxtFilePath.Text = simpan.SelectedPath
        End If

        'Dim OpenD As OpenFileDialog = New OpenFileDialog
        'Dim result As DialogResult = OpenD.ShowDialog()
        'If result = System.Windows.Forms.DialogResult.OK Then
        '    TxtFilePath.Text = System.IO.Path.GetFullPath(OpenD.FileName)
        'End If
    End Sub
End Class
