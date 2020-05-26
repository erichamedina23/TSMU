Imports System.Xml

Public Class FrmSystem_ConfigDB
    Dim AppSettingFileName As String = Application.StartupPath & "\AS.XML"
    'Dim SPSettingFileName As String = Application.StartupPath & "\SettingScanPoint.XML"

    Dim _ChangeRBInstruction As Boolean = False

    Private Sub FrmSystemConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChkWinMode.Enabled = False
        ChkWinMode.Visible = False
        ChkWinMode.Checked = False
        TxtServer.Enabled = False
        TxtDatabase.Enabled = False
        TxtUserName.Enabled = False
        TxtPassword.Enabled = False
        'TxtNsisLS.Enabled = False
        'TxtNsisDB.Enabled = False

        Me.Text = "System Configuration (" & Application.ProductVersion & ")"
        Dim ls_Server As String = ""
        'If gs_Error <> "" Then Exit Sub
        Dim ls_Database As String = ""
        Dim ls_UserName As String = ""
        Dim ls_Password As String = ""
        Dim ls_AuthMode As String = ""

        'Dim ls_NsisLS As String = ""
        'Dim ls_NsisDB As String = ""

        Dim ls_Product As String = My.Application.Info.ProductName.Trim
        Dim ls_Description As String = My.Application.Info.Description.Trim
        If ls_Description = "" Then ls_Description = "Takagi"
        btnApplySetting.Enabled = False
        'BtnSave.Enabled = False
        '--------------------------------------------------------------------------------------------------- Terminal

        'Fill Content
        Dim FileInfo As New IO.FileInfo(AppSettingFileName)

        'check existing file
        If FileInfo.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(AppSettingFileName)

            dtTableAppSetting = DS.Tables("AS")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 9 Then
                    ls_Server = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    ls_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    ls_UserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    ls_Password = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    ls_AuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                Else
                    ls_Server = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    ls_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    ls_UserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    ls_Password = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    ls_AuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    Kill(AppSettingFileName)

                    Dim settings As XmlWriterSettings = New XmlWriterSettings()
                    settings.Indent = True

                    Using writer As XmlWriter = XmlWriter.Create(AppSettingFileName, settings)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("AS") ' Root.

                        With writer
                            .WriteStartElement("AS")
                            .WriteElementString("S", DataEncrypt(ls_Server.Trim))
                            .WriteElementString("D", DataEncrypt(ls_Database.Trim))
                            .WriteElementString("U", DataEncrypt(ls_UserName.Trim))
                            .WriteElementString("PW", DataEncrypt(ls_Password.Trim))
                            .WriteElementString("AU", DataEncrypt(ls_AuthMode.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using

                End If
            End If
        Else
            ls_Server = ""
            ls_Database = ""
            ls_UserName = ""
            ls_Password = ""
            ls_AuthMode = ""
        End If

        TxtServer.Text = ls_Server
        TxtDatabase.Text = ls_Database
        TxtUserName.Text = ls_UserName
        If ls_Password.Trim = "" Then ls_Password = gs_DBPasswordDefault
        TxtPassword.Text = ls_Password
        If TxtServer.Text.Trim = "" Then
            ChkWinMode.Checked = False
        Else
            ChkWinMode.Checked = IIf(ls_AuthMode = "win", True, False)
        End If
        ChkWinMode.Checked = False

    End Sub

    Private Sub FrmSystemConfig_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim lF_Input As FrmSystem_ConfigInputBox = Nothing
            lF_Input = New FrmSystem_ConfigInputBox("Input confirmation password", "Confirmation", , "*")
            lF_Input.ShowDialog()
            If Not lF_Input.isCancel AndAlso lF_Input.rs_ReturnCode <> "" Then
                Dim ls_Results As String
                ls_Results = lF_Input.rs_ReturnCode
                If ls_Results <> "" Then
                    If String.Compare(ls_Results, "takagi") = 0 Then
                        TxtPassword.Enabled = True
                        ChkWinMode.Visible = True
                        ChkWinMode.Enabled = True
                        TxtServer.Enabled = True
                        TxtDatabase.Enabled = True
                        TxtUserName.Enabled = True
                    End If
                End If
            End If
            lF_Input.Close()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Call ProcessSave()
            DialogResult = System.Windows.Forms.DialogResult.OK
            '# Closes form...
            'Me.Close()
            Me.Dispose()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Private Sub FrmSystemConfig_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Dim result As MsgBoxResult = MsgBox("Save setting ?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                Call ProcessSave()
                DialogResult = DialogResult.OK
            ElseIf result = MsgBoxResult.Cancel Then
                e.Cancel = True
                DialogResult = DialogResult.Cancel
            End If
        End If
    End Sub

    Private Sub ProcessSave()
        '# Save database settings...
        Dim ls_Product As String = My.Application.Info.ProductName.Trim
        Dim ls_Description As String = My.Application.Info.Description.Trim
        If ls_Description = "" Then ls_Description = "Takagi"


        Dim FileInfo As New IO.FileInfo(AppSettingFileName)

        'check existing file
        If FileInfo.Exists Then
            'delete file
            Kill(AppSettingFileName)

            'then create file
            CreateAppSettingFile()
        Else
            CreateAppSettingFile()
        End If

        gs_DBPassword = TxtPassword.Text.Trim
        Call gf_GetDatabaseVariables()
    End Sub

    Private Sub CreateAppSettingFile()
        Try
            'check terminal
            Dim TerminalUsername As String = ""
            Dim TerminalPassword As String = ""
            Dim SPSetting As XmlWriterSettings = New XmlWriterSettings()
            SPSetting.Indent = True


            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True

            Using writer As XmlWriter = XmlWriter.Create(AppSettingFileName, settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("AS") ' Root.

                With writer
                    .WriteStartElement("AS")
                    .WriteElementString("S", DataEncrypt(TxtServer.Text.Trim))
                    .WriteElementString("D", DataEncrypt(TxtDatabase.Text.Trim))
                    .WriteElementString("U", DataEncrypt(TxtUserName.Text.Trim))
                    .WriteElementString("PW", DataEncrypt(TxtPassword.Text.Trim))
                    .WriteElementString("AU", DataEncrypt(IIf(ChkWinMode.Checked, "win", "mixed")))
                    .WriteElementString("TU", DataEncrypt(TerminalUsername))
                    .WriteElementString("TPW", DataEncrypt(TerminalPassword))

                    .WriteElementString("IS", DataEncrypt(""))


                    .WriteEndElement()
                End With

                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using


        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage, Err.Description)
        End Try
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        Dim ls_con As String
        Dim con As New SqlClient.SqlConnection
        Dim ls_Server, ls_Database, ls_User, ls_Pass As String

        ls_Server = TxtServer.Text.Trim
        ls_Database = TxtDatabase.Text.Trim
        ls_User = TxtUserName.Text.Trim
        ls_Pass = TxtPassword.Text.Trim

        If ChkWinMode.Checked = False Then
            ls_con = "Data Source=" & ls_Server & ";Initial Catalog=" & ls_Database & ";User ID=" & ls_User & ";pwd=" & ls_Pass & ""
        Else
            ls_con = "Data Source=" & ls_Server & ";Initial Catalog=" & ls_Database & ";Integrated Security=True"
        End If
        con.ConnectionString = ls_con

        Try
            con.Open()
        Catch ex As Exception
            MsgBox("Test Failed !", MsgBoxStyle.Exclamation, "Information")
            TabControl1.TabIndex = 0
            Exit Sub
        End Try
        con.Close()
        MsgBox("Test Succeded !", MsgBoxStyle.Information, "Information")
        btnApplySetting.Enabled = True
    End Sub


    Private Sub btnApplySetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySetting.Click
        Try

            Dim FileInfo As New IO.FileInfo(AppSettingFileName)

            'check existing file
            If FileInfo.Exists Then
                'delete file
                Kill(AppSettingFileName)

                'then create file
                CreateAppSettingFile()
            Else
                CreateAppSettingFile()
            End If

            gs_DBPassword = TxtPassword.Text.Trim
            Call gf_GetDatabaseVariables()

            MsgBox("Setting applied.", MsgBoxStyle.Information, "Information")

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub TxtServer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtServer.TextChanged, TxtDatabase.TextChanged, TxtPassword.TextChanged, _
    TxtUserName.TextChanged
        Try
            btnApplySetting.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Information")
        End Try
    End Sub

End Class