Imports System.Xml
Public Class frm_system_config_db
    Dim AppSettingFileName As String = Application.StartupPath & "\AS.XML"
    Dim SolomonConfig As String = Application.StartupPath & "\Solomon.XML"
    Dim CKRConfig As String = Application.StartupPath & "\CKR.XML"
    Dim _ChangeRBInstruction As Boolean = False
    Private Sub frm_system_config_db_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        XtraTabControl1.SelectedTabPageIndex = 0
        'BoMServer.Enabled = False
        'BoMdb.Enabled = False
        'BoMUser.Enabled = False
        'BoMPass.Enabled = False


        Me.Text = "System Configuration (" & Application.ProductVersion & ")"
        Dim _BomServer As String = ""
        Dim _BomDB As String = ""
        Dim _BomUser As String = ""
        Dim _BomPass As String = ""
        Dim _BomAuth As String = ""

        Dim _SolomonServer As String = ""
        Dim _SolomonDb As String = ""
        Dim _SolomonUser As String = ""
        Dim _SolomonPass As String = ""
        Dim _SolomonAuth As String = ""

        Dim CKRServer As String = ""
        Dim CKRDB As String = ""
        Dim CKRUser As String = ""
        Dim CKRPass As String = ""
        Dim CKRAuth As String = ""

        Dim ls_Product As String = My.Application.Info.ProductName.Trim
        Dim ls_Description As String = My.Application.Info.Description.Trim
        If ls_Description = "" Then ls_Description = "Takagi"

        'Bom
        Dim FileInfo As New IO.FileInfo(AppSettingFileName)

        'check existing file
        If FileInfo.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(AppSettingFileName)

            dtTableAppSetting = DS.Tables("AS")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 9 Then
                    _BomServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    _BomDB = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    _BomUser = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    _BomPass = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    _BomAuth = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                Else
                    _BomServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    _BomDB = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    _BomUser = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    _BomPass = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    _BomAuth = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

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
                            .WriteElementString("S", DataEncrypt(_BomServer.Trim))
                            .WriteElementString("D", DataEncrypt(_BomDB.Trim))
                            .WriteElementString("U", DataEncrypt(_BomUser.Trim))
                            .WriteElementString("PW", DataEncrypt(_BomPass.Trim))
                            .WriteElementString("AU", DataEncrypt(_BomAuth.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using

                End If
            End If
        Else
            _BomServer = ""
            _BomDB = ""
            _BomUser = ""
            _BomPass = ""
            _BomAuth = ""
        End If

        BoMServer.Text = _BomServer
        BoMdb.Text = _BomDB
        BoMUser.Text = _BomUser
        If _BomPass.Trim = "" Then _BomPass = gs_DBPasswordDefault
        BoMPass.Text = _BomPass
        If BoMServer.Text.Trim = "" Then
            CheckBom.Checked = False
        Else
            CheckBom.Checked = IIf(_BomAuth = "win", True, False)
        End If
        CheckBom.Checked = False


        'Solomon
        Dim FileInfo1 As New IO.FileInfo(SolomonConfig)
        'check existing file
        If FileInfo1.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(SolomonConfig)

            dtTableAppSetting = DS.Tables("Solomon")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 9 Then
                    _SolomonServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    _SolomonDb = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    _SolomonUser = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    _SolomonPass = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    _SolomonAuth = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                Else
                    _SolomonServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    _SolomonDb = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    _SolomonUser = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    _SolomonPass = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    _SolomonAuth = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    Kill(SolomonConfig)

                    Dim settings As XmlWriterSettings = New XmlWriterSettings()
                    settings.Indent = True

                    Using writer As XmlWriter = XmlWriter.Create(SolomonConfig, settings)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("Solomon") ' Root.

                        With writer
                            .WriteStartElement("Solomon")
                            .WriteElementString("S", DataEncrypt(_SolomonServer.Trim))
                            .WriteElementString("D", DataEncrypt(_SolomonDb.Trim))
                            .WriteElementString("U", DataEncrypt(_SolomonUser.Trim))
                            .WriteElementString("PW", DataEncrypt(_SolomonPass.Trim))
                            .WriteElementString("AU", DataEncrypt(_SolomonAuth.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using

                End If
            End If
        Else
            _SolomonServer = ""
            _SolomonDb = ""
            _SolomonUser = ""
            _SolomonPass = ""
            _SolomonAuth = ""
        End If

        SolomonServer.Text = _SolomonServer
        SolomonDB.Text = _SolomonDb
        SolomonUser.Text = _SolomonUser
        If _SolomonPass.Trim = "" Then _SolomonPass = gs_DBPasswordDefault1
        SolomonPass.Text = _SolomonPass
        If SolomonServer.Text.Trim = "" Then
            CheckSolomon.Checked = False
        Else
            CheckSolomon.Checked = IIf(_SolomonAuth = "win", True, False)
        End If
        CheckSolomon.Checked = False


        '============DB CKR====================
        Dim FileInfoCKR As New IO.FileInfo(CKRConfig)

        'check existing file
        If FileInfo.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(CKRConfig)

            dtTableAppSetting = DS.Tables("CKR")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 8 Then
                    CKRServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    CKRDB = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    CKRUser = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    CKRPass = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    'CKRAuth = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    ' gs_DBAuthMode2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                Else
                    CKRServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    CKRDB = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    CKRUser = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    CKRPass = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    'CKRAuth = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    gs_DBServer2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    'gs_DBAuthMode2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))

                    Kill(CKRConfig)

                    Dim settings As XmlWriterSettings = New XmlWriterSettings()
                    settings.Indent = True

                    Using writer As XmlWriter = XmlWriter.Create(CKRConfig, settings)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("CKR") ' Root.

                        With writer
                            .WriteStartElement("CKR")
                            .WriteElementString("S", DataEncrypt(CKRServer.Trim))
                            .WriteElementString("D", DataEncrypt(CKRDB.Trim))
                            .WriteElementString("U", DataEncrypt(CKRUser.Trim))
                            .WriteElementString("PW", DataEncrypt(CKRPass.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using

                End If
            End If
        Else
            CKRServer = ""
            CKRDB = ""
            CKRUser = ""
            CKRPass = ""
            CKRAuth = ""
        End If

        TCKRServer.Text = CKRServer
        TCKRDatabase.Text = CKRDB
        TCKRUser.Text = CKRUser
        If CKRPass.Trim = "" Then CKRPass = gs_DBPasswordDefault2
        TCKRPassword.Text = CKRPass
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
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
            CreateAppSettingFileBOM()
        Else
            CreateAppSettingFileBOM()
        End If

        gs_DBPassword = BoMPass.Text.Trim
        Call gf_GetDatabaseVariables()

        Dim FileInfo1 As New IO.FileInfo(SolomonConfig)

        'check existing file
        If FileInfo1.Exists Then
            'delete file
            Kill(SolomonConfig)

            'then create file
            CreateAppSettingFileSolomon()
        Else
            CreateAppSettingFileSolomon()
        End If

        gs_DBPassword1 = SolomonPass.Text.Trim
        Call gf_GetDatabaseVariablesSolomon()

        Dim FileInfo2 As New IO.FileInfo(CKRConfig)

        'check existing file
        If FileInfo2.Exists Then
            'delete file
            Kill(CKRConfig)

            'then create file
            CreateAppSettingFileDbCKR()
        Else
            CreateAppSettingFileDbCKR()
        End If

        gs_DBPassword2 = TCKRPassword.Text.Trim
        Call gf_GetDatabaseVariablesDbCKR()

    End Sub
    Private Sub CreateAppSettingFileBOM()
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
                    .WriteElementString("S", DataEncrypt(BoMServer.Text.Trim))
                    .WriteElementString("D", DataEncrypt(BoMdb.Text.Trim))
                    .WriteElementString("U", DataEncrypt(BoMUser.Text.Trim))
                    .WriteElementString("PW", DataEncrypt(BoMPass.Text.Trim))
                    .WriteElementString("AU", DataEncrypt(IIf(CheckBom.Checked, "win", "mixed")))
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
    Private Sub CreateAppSettingFileSolomon()
        Try
            'check terminal
            Dim TerminalUsername As String = ""
            Dim TerminalPassword As String = ""
            Dim SPSetting As XmlWriterSettings = New XmlWriterSettings()
            SPSetting.Indent = True


            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True

            Using writer As XmlWriter = XmlWriter.Create(SolomonConfig, settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("Solomon") ' Root.

                With writer
                    .WriteStartElement("Solomon")
                    .WriteElementString("S", DataEncrypt(SolomonServer.Text.Trim))
                    .WriteElementString("D", DataEncrypt(SolomonDB.Text.Trim))
                    .WriteElementString("U", DataEncrypt(SolomonUser.Text.Trim))
                    .WriteElementString("PW", DataEncrypt(SolomonPass.Text.Trim))
                    .WriteElementString("AU", DataEncrypt(IIf(CheckSolomon.Checked, "win", "mixed")))
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

    Private Sub CreateAppSettingFileDbCKR()
        Try
            'check terminal
            Dim TerminalUsername As String = ""
            Dim TerminalPassword As String = ""
            Dim SPSetting As XmlWriterSettings = New XmlWriterSettings()
            SPSetting.Indent = True


            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True

            Using writer As XmlWriter = XmlWriter.Create(CKRConfig, settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("CKR") ' Root.

                With writer
                    .WriteStartElement("CKR")
                    .WriteElementString("S", DataEncrypt(TCKRServer.Text.Trim))
                    .WriteElementString("D", DataEncrypt(TCKRDatabase.Text.Trim))
                    .WriteElementString("U", DataEncrypt(TCKRUser.Text.Trim))
                    .WriteElementString("PW", DataEncrypt(TCKRPassword.Text.Trim))
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

    Private Sub frm_system_config_db_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
End Class