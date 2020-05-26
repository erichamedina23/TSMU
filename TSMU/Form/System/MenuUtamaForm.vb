Imports System.Reflection
Imports System.Windows.Forms

Public Class MenuUtamaForm

    Dim fs_AssProduct As String = ""
    Dim HasLoad As Boolean = False
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click

    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Exit Application ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit ?") = MsgBoxResult.Yes Then
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub MenuUtamaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.MaximizeBox = False
        'HasLoad = True
        LblLogin.Text = ""
        lblGroup.Text = ""
        'LblPeriod.Text = ""
        LblDatabase.Text = ""
        StatMsg.Text = " Shortcut : F1 - View Detail"

        fs_AssProduct = My.Application.Info.AssemblyName

        Dim separatorFormat As New System.Globalization.NumberFormatInfo()
        If System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "," Then
            'Dim frmInformationBox As New InformationBox()
            'frmInformationBox.Captions("Comma Decimal Separator Format", "Volts currently supports and displays a dot(.) as a decimal separator.", "Information", "Okay")
            'frmInformationBox.ShowDialog()
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            separatorFormat.NumberDecimalSeparator = "."
        End If

        Call gf_GetDatabaseVariables()

        '# Add event handlers for menu items...
        For Each AppMenu As ToolStripMenuItem In Me.MenuStrip.Items
            Call AddMenuHandler(AppMenu)
        Next

        '# List forms...
        Call ListAppForms()

        FileMenu.Enabled = True
        tsmLogin.Enabled = True

        '# Load Crystal Report ( just load )
        '# This is done to load the crystal report assemblies so subsequent calls to report
        '# won't take a long time...
        'Dim tes As New Doc_Invoice

        If gs_TerminalUsername <> "" AndAlso gs_TerminalPassword <> "" AndAlso gs_AutomaticForm <> "" Then
            FrmLogin.UsernameTextBox.Text = gs_TerminalUsername
            FrmLogin.PasswordTextBox.Text = gs_TerminalPassword
            Call FrmLogin.OK_Click(Me, New System.EventArgs)

            If gs_Error <> "" Then
                Exit Sub
            End If

            LblDatabase.Text = "Database : " & gs_Database & " (" & gs_DBServer & ")"
            tsnChangePass.Enabled = False

            Dim openForm As Form = Nothing
            openForm = MyAss.CreateInstance(fs_AssProduct & "." & gs_AutomaticForm)
            openForm.ShowDialog()
        Else
            FrmLogin.ShowDialog()
        End If
    End Sub

    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    Const WM_NCLBUTTONDOWN As Integer = 161
    '    Const WM_SYSCOMMAND As Integer = 274
    '    Const HTCAPTION As Integer = 2
    '    Const SC_MOVE As Integer = 61456
    '    Const WM_NCLBUTTTONDBLCLK As Integer = &HA3
    '    If (m.Msg = WM_SYSCOMMAND) And (m.WParam.ToInt32() = SC_MOVE) Then
    '        Return
    '    End If

    '    If (m.Msg = WM_NCLBUTTONDOWN) And (m.WParam.ToInt32() = HTCAPTION) Then
    '        Return
    '    End If

    '    If m.Msg = WM_NCLBUTTTONDBLCLK Then
    '        Exit Sub
    '    End If
    '    MyBase.WndProc(m)
    'End Sub

    Private Sub frmConsole_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Me.WindowState = FormWindowState.Minimized Then
            Me.MaximizeBox = True
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            If HasLoad Then
                Me.MaximizeBox = False
            End If
        End If
    End Sub
    Private Sub AddMenuHandler(ByVal AppMenu As ToolStripMenuItem)
        Dim MenuItem As ToolStripItem = Nothing
        Dim AppMenuItem As ToolStripMenuItem = Nothing

        For Each MenuItem In AppMenu.DropDownItems
            If TypeOf (MenuItem) Is ToolStripMenuItem Then
                AppMenuItem = MenuItem
                '# Hanya tambahkan untuk menu yang berkaitan dengan form inputan...
                If MenuItem.Name.Substring(0, 3).ToLower = "frm" Then
                    MyMenus.Add(AppMenuItem)
                End If
                AddHandler AppMenuItem.Click, AddressOf katadaMenu
                If AppMenuItem.DropDownItems.Count > 0 Then
                    Call AddMenuHandler(AppMenuItem)
                End If
            End If
        Next
    End Sub
    Private Sub BeginApp()
        tsmLogin.Text = "Log Out"
        For Each DaftarMenu As ToolStripMenuItem In MenuStrip.Items
            DaftarMenu.Enabled = True
        Next
        tsnChangePass.Enabled = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CloseApp()
        tsmLogin.Text = "Log In"
        For Each DaftarMenu As ToolStripMenuItem In MenuStrip.Items
            If DaftarMenu.Name <> "FileToolStripMenuItem" Then DaftarMenu.Enabled = False
        Next
        FileMenu.Enabled = True
        tsmLogin.Enabled = True
        ExitToolStripMenuItem.Enabled = True
        tsnChangePass.Enabled = False
        LblLogin.Text = ""
        lblGroup.Text = ""
        'LblPeriod.Text = ""
        LblDatabase.Text = ""
        'Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub ListAppForms()

        '# Load default forms...
        Dim frm As Form = Nothing
        Dim ObjType As Type = Nothing
        Try
            For Each MyType As Type In MyAss.GetTypes
                ObjType = MyType.BaseType
                Do While ObjType IsNot Nothing AndAlso ObjType.Name <> "Form"
                    ObjType = ObjType.BaseType
                Loop
                If ObjType IsNot Nothing AndAlso ObjType.Name = "Form" Then
                    If MyType.BaseType.Name.ToLower.Trim = "baseform" Then
                        Try
                            frm = MyAss.CreateInstance(MyType.FullName)
                        Catch ex As Exception
                            frm = Nothing
                        End Try
                        If frm IsNot Nothing Then
                            MyForms.Add(frm)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            If TypeOf ex Is System.Reflection.ReflectionTypeLoadException Then
                Dim typeLoadException = TryCast(ex, ReflectionTypeLoadException)
                Dim loaderExceptions = typeLoadException.LoaderExceptions
            End If
        End Try

        '# Additional forms...
        Try
            frm = MyAss.CreateInstance(fs_AssProduct & ".FrmTrans_Closing")
            If frm IsNot Nothing Then
                MyForms.Add(frm)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub katadaMenu(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MenuItem As Object = sender
        Dim openForm As Form = Nothing
        Try
            For Each iForm As System.Windows.Forms.Form In My.Application.OpenForms
                If iForm.Name = MenuItem.Name Then
                    My.Application.OpenForms(iForm.Name).Focus()
                    Exit Sub
                End If
            Next
            openForm = MyAss.CreateInstance(fs_AssProduct & "." & MenuItem.Name)
        Catch ex As Exception

        End Try
        If openForm Is Nothing Then
            Select Case MenuItem.Name
                Case tsmLogin.Name
                    If tsmLogin.Text = "Log In" Then
                    ElseIf tsmLogin.Text = "Log Out" Then
                        tsmLogin.Text = "Log In"
                        '# Close opened forms...
                        For iCount As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                            If Application.OpenForms(iCount).IsMdiChild Then
                                Application.OpenForms(iCount).Dispose()
                            End If
                        Next
                        RemoveMenuNavBar()
                    End If
                    FrmLogin.ShowDialog()
                Case tsnChangePass.Name
                    FrmSystem_ChangePassword.Show()
                Case ExitToolStripMenuItem.Name
                    If MsgBox("Exit Application ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit ?") = MsgBoxResult.Yes Then
                        For Each ChildForm As Form In Me.MdiChildren
                            ChildForm.Close()
                        Next
                        End
                    End If
            End Select
        End If

        If openForm IsNot Nothing Then
            Try
                Call CheckDBConnection()
                If gs_Error = "" Then
                    Dim query As String = "SELECT COALESCE(FlagFullScreen,0) AS [FlagFullScreen] FROM S_UserMenu WHERE MenuCode = '" & openForm.Name & "'"
                    Dim dtTable As DataTable = MainModul.GetDataTable(query)
                    If dtTable.Rows(0).Item("FlagFullScreen") = "1" Then
                        openForm.StartPosition = FormStartPosition.CenterScreen
                        openForm.ShowDialog()
                    Else
                        openForm.MdiParent = Me
                        openForm.WindowState = FormWindowState.Maximized
                        'openForm.StartPosition = FormStartPosition.WindowsDefaultBounds
                        openForm.Show()
                    End If
                Else
                    ShowMessage("Lost Connection to Database, Please re-Connect and Restart Application", MessageTypeEnum.ErrorMessage)
                End If
            Catch ex As Exception
                ShowMessage("", MessageTypeEnum.NotBoxMessage)
            End Try

            'openForm.MdiParent = Me
            'openForm.Show()
            'openForm.Activate()
            'ShowMessage("", MessageTypeEnum.NotBoxMessage)
        End If
    End Sub

    Public Sub AddMenuNavBar()
        Try
            Dim ls_Sqls As String = ""
            Dim ls_Error As String = ""
            'Dim lTSIa_Master() As System.Windows.Forms.ToolStripItem = Nothing
            'Dim lTSIa_Operasional() As System.Windows.Forms.ToolStripItem = Nothing
            'Dim lTSIa_Keuangan() As System.Windows.Forms.ToolStripItem = Nothing
            'Dim lTSIa_Laporan() As System.Windows.Forms.ToolStripItem = Nothing
            'Dim lTSIa_Setting() As System.Windows.Forms.ToolStripItem = Nothing
            'Dim lTSIa_Others() As System.Windows.Forms.ToolStripItem = Nothing
            'Dim li_MenuCount As Integer = 0

            '#############Contoh Penambahan Menu Manual##################################
            'Dim TSMenuD1 As New System.Windows.Forms.ToolStripMenuItem
            'TSMenuD1.Enabled = False
            'TSMenuD1.Name = "TSMenuLaporan"
            'TSMenuD1.ShortcutKeys = CType((((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            '            Or System.Windows.Forms.Keys.Shift) _
            '            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
            'TSMenuD1.Size = New System.Drawing.Size(234, 22)
            'TSMenuD1.Text = "Lapor"

            'If lTSIa_Master IsNot Nothing Then
            '    li_MenuCount = lTSIa_Master.Length
            'Else
            '    li_MenuCount = 0
            'End If
            'ReDim Preserve lTSIa_Master(li_MenuCount)
            'lTSIa_Master(lTSIa_Master.Length - 1) = TSMenuD1

            'Dim TSSMenu As New System.Windows.Forms.ToolStripSeparator
            'TSSMenu.Name = "ToolStripSeparator2"
            'TSSMenu.Size = New System.Drawing.Size(231, 6)
            'If lTSIa_Master IsNot Nothing Then
            '    li_MenuCount = lTSIa_Master.Length
            'Else
            '    li_MenuCount = 0
            'End If
            'ReDim Preserve lTSIa_Master(li_MenuCount)
            'lTSIa_Master(lTSIa_Master.Length - 1) = TSSMenu

            'Dim TSMenuD2 As New System.Windows.Forms.ToolStripMenuItem
            'TSMenuD2.Enabled = False
            'TSMenuD2.Name = "TSMenuMaster"
            'TSMenuD2.Size = New System.Drawing.Size(234, 22)
            'TSMenuD2.Text = "Master File"
            'If lTSIa_Master IsNot Nothing Then
            '    li_MenuCount = lTSIa_Master.Length
            'Else
            '    li_MenuCount = 0
            'End If
            'ReDim Preserve lTSIa_Master(li_MenuCount)
            'lTSIa_Master(lTSIa_Master.Length - 1) = TSMenuD2

            'Me.TSMMaster.DropDownItems.AddRange(lTSIa_Master)
            '#############Contoh Penambahan Menu Manual##################################

            'ls_Sqls = "Select ta.MenuCode, tm.NamaMenu, tm.NamaForm, ta.HakAkses, ParentMenu = Coalesce(tm.ParentMenu, ''), Keterangan = Coalesce(tm.KeteranganMenu, '') " & vbCrLf & _
            '          "From S_UserMenu tm " & vbCrLf & _
            '          "Left Join S_UserPermission ta On tm.KodeMenu = ta.KodeMenu " & vbCrLf & _
            '          "Where " & vbCrLf & _
            '          "((ta.UserName = " & QVal(gh_Common.Username) & " And Coalesce(ta.HakAkses, '0') = '1') " & vbCrLf & _
            '          "  Or (tm.ParentMenu = 'Setting' And 1 = " & IIf(gh_Common.AdminStatus, "1", "0") & " )) " & vbCrLf & _
            '          "And Coalesce(tm.ParentMenu, '') <> '' And tm.FlagActive = '1' " & vbCrLf & _
            '          "Order By Coalesce(tm.ParentMenu, ''), tm.SeqMenu ASC "
            ls_Sqls = "SELECT " & vbCrLf &
                "	su.MenuCode " & vbCrLf &
                "	, su.Title " & vbCrLf &
                "	, su.ParentMenuChild " & vbCrLf &
                "	, sup.Access " & vbCrLf &
                "	, ParentMenu = Coalesce(su.ParentMenu, '') " & vbCrLf &
                "/*	, Description = Coalesce(su.Description, '') */ " & vbCrLf &
                "FROM " & vbCrLf &
                "	S_UserMenu su " & vbCrLf &
                "	LEFT JOIN S_UserPermission sup " & vbCrLf &
                "		ON su.MenuCode = sup.MenuCode " & vbCrLf &
                "WHERE " & vbCrLf &
                "	( " & vbCrLf &
                "		(sup.UserName = " & QVal(gh_Common.Username) & " AND COALESCE(sup.Access, '0') = '1') " & vbCrLf &
                "	) " & vbCrLf &
                "	AND COALESCE(su.ParentMenu, '') <> '' " & vbCrLf &
                "	AND su.FlagActive = '1' " & vbCrLf &
                "ORDER BY " & vbCrLf &
                "	COALESCE(su.seqParentMenu, '') " & vbCrLf &
                "	, su.SeqMenu ASC "
            '   "	OR (su.ParentMenu = 'Setting' AND 1 = " & IIf(gh_Common.AdminStatus, "1", "0") & " ) " & vbCrLf &

            Dim dt_Menu As DataTable = MainModul.GetDataTable(ls_Sqls)
            If dt_Menu.Rows.Count > 0 Then
                '# Ambil Menu yang diperbolehkan untuk edit...
                Dim TSMenuD As System.Windows.Forms.ToolStripMenuItem
                For li_Count As Integer = 0 To dt_Menu.Rows.Count - 1
                    TSMenuD = New System.Windows.Forms.ToolStripMenuItem
                    TSMenuD.Name = dt_Menu.Rows(li_Count).Item("MenuCode").ToString.Trim
                    TSMenuD.Text = dt_Menu.Rows(li_Count).Item("Title").ToString.Trim
                    TSMenuD.ToolTipText = dt_Menu.Rows(li_Count).Item("Title").ToString.Trim
                    AddHandler TSMenuD.Click, AddressOf katadaMenu
                    Dim childMenu As String = dt_Menu.Rows(li_Count).Item("ParentMenuChild").ToString.Trim
                    Select Case dt_Menu.Rows(li_Count).Item("ParentMenu").ToString.Trim
                        Case "Master"
                            tsMenuMaster.DropDownItems.Add(TSMenuD)
                            'Case "SC"
                            '    TSMSC.DropDownItems.Add(TSMenuD)
                            'Case "PC"
                            '    TSMPC.DropDownItems.Add(TSMenuD)
                            'Case "PLM"
                            '    TSMPLM.DropDownItems.Add(TSMenuD)
                        Case "Asakai"
                            tsMenuAsakai.DropDownItems.Add(TSMenuD)
                        Case "Circulation"
                            tsMenuCirculation.DropDownItems.Add(TSMenuD)
                        Case "Sales"
                            If childMenu Is DBNull.Value OrElse childMenu = "" Then
                            ElseIf childMenu = "Budget" Then
                                BudgetTSM.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Forecast" Then
                                ForecastTSM.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Price" Then
                                PriceTSM.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "SO" Then
                                SoTsm.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Calculate" Then
                                CalculateTM.DropDownItems.Add(TSMenuD)

                            End If
                            'tsbForecast.DropDownItems.Add(TSMenuD)
                        Case "Report"
                            tsReport.DropDownItems.Add(TSMenuD)
                        Case "Setting"
                            tsMenuSetting.DropDownItems.Add(TSMenuD)
                            'Case "Hitung Sales Budget"
                            '    HitungSalesBudgetToolStripMenuItem.DropDownItems.Add(TSMenuD)
                        Case "Sales Budget"
                            BudgetTSM.DropDownItems.Add(TSMenuD)
                        Case "Sales Forecast"
                            ForecastTSM.DropDownItems.Add(TSMenuD)
                        Case "Sales Price"
                            PriceTSM.DropDownItems.Add(TSMenuD)
                        Case "Calculate"
                            CalculateTM.DropDownItems.Add(TSMenuD)
                        Case "Payment"
                            If childMenu Is DBNull.Value OrElse childMenu = "" Then
                            ElseIf childMenu = "Transaction" Then
                                tsTransaction.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Report" Then
                                tsReport1.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Direct Payment" Then
                                tsDirect.DropDownItems.Add(TSMenuD)
                                'ElseIf childMenu = "Price" Then
                                '    PriceTSM.DropDownItems.Add(TSMenuD)
                            End If
                        Case "Surat Jalan"
                            If childMenu Is DBNull.Value OrElse childMenu = "" Then
                            ElseIf childMenu = "WHJ" Then
                                WHJtsb.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Finance" Then
                                Fintsb.DropDownItems.Add(TSMenuD)
                            End If
                        Case "Tax"
                            If childMenu Is DBNull.Value OrElse childMenu = "" Then
                            ElseIf childMenu = "Transaction" Then
                                tstaxtransaction.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Report" Then
                                tstaxreport.DropDownItems.Add(TSMenuD)
                                'ElseIf childMenu = "Price" Then
                                '    PriceTSM.DropDownItems.Add(TSMenuD)
                            End If
                        Case "Direct Payment"
                            If childMenu Is DBNull.Value OrElse childMenu = "" Then
                                tsDirect1.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Advance" Then
                                tsSuspend.DropDownItems.Add(TSMenuD)
                            ElseIf childMenu = "Settlement" Then
                                tsSettlement.DropDownItems.Add(TSMenuD)
                                'ElseIf childMenu = "Report Entertainment" Then
                                '    tsReportEntertainment.DropDownItems.Add(TSMenuD)
                            End If
                        Case "PO Checking"
                            If childMenu Is DBNull.Value OrElse childMenu = "" Then
                            ElseIf childMenu = "TMMIN" Then
                                tsMenuTMMIN.DropDownItems.Add(TSMenuD)
                            Else
                                tsMenuTAM.DropDownItems.Add(TSMenuD)
                            End If
                        Case Else

                    End Select
                Next
            End If
            If tsMenuMaster.DropDownItems.Count > 0 Then tsMenuMaster.Visible = True Else tsMenuMaster.Visible = False
            If tsMenuAsakai.DropDownItems.Count > 0 Then tsMenuAsakai.Visible = True Else tsMenuAsakai.Visible = False
            'If TSMPC.DropDownItems.Count > 0 Then TSMPC.Visible = True Else TSMPC.Visible = False
            'If TSMPLM.DropDownItems.Count > 0 Then TSMPLM.Visible = True Else TSMPLM.Visible = False

            If BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
                AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = True
                CalculateTM.Visible = True
                SoTsm.Visible = True

            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
                AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = False
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
                AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = False
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
                AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = False
                PriceTSM.Visible = True
                CalculateTM.Visible = False
                CalculateTM.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
                AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = False
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
                AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = False
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
                AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = False
                PriceTSM.Visible = True
                CalculateTM.Visible = False
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
                AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = False
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
                AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = True
                PriceTSM.Visible = True
                CalculateTM.Visible = False
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = False
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = False
                PriceTSM.Visible = True
                CalculateTM.Visible = True
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = False
                PriceTSM.Visible = True
                CalculateTM.Visible = False
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = True
                CalculateTM.Visible = False
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count = 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = True
                CalculateTM.Visible = True
                SoTsm.Visible = False
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count = 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = True
                CalculateTM.Visible = False
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count = 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = True
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count > 0 AndAlso ForecastTSM.DropDownItems.Count = 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = True
                ForecastTSM.Visible = False
                PriceTSM.Visible = False
                CalculateTM.Visible = True
                SoTsm.Visible = True
            ElseIf BudgetTSM.DropDownItems.Count = 0 AndAlso ForecastTSM.DropDownItems.Count > 0 AndAlso PriceTSM.DropDownItems.Count > 0 _
            AndAlso CalculateTM.DropDownItems.Count > 0 AndAlso SoTsm.DropDownItems.Count > 0 Then
                tsbForecast.Visible = True
                BudgetTSM.Visible = False
                ForecastTSM.Visible = True
                PriceTSM.Visible = True
                CalculateTM.Visible = True
                SoTsm.Visible = True
            Else
                tsbForecast.Visible = False
            End If
            'If tsbForecast.DropDownItems.Count > 0 Then tsbForecast.Visible = True Else tsbForecast.Visible = False
            If tsReport.DropDownItems.Count > 0 Then tsReport.Visible = True Else tsReport.Visible = False
            If tsMenuSetting.DropDownItems.Count > 0 Then tsMenuSetting.Visible = True Else tsMenuSetting.Visible = False
            'If tsPayment.DropDownItems.Count > 0 Then tsPayment.Visible = True Else tsPayment.Visible = False
            If tsTransaction.DropDownItems.Count > 0 AndAlso tsReport1.DropDownItems.Count > 0 AndAlso tsDirect.DropDownItems.Count > 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = True
                tsReport1.Visible = True
                tsDirect.Visible = True
            ElseIf tsTransaction.DropDownItems.Count > 0 AndAlso tsReport1.DropDownItems.Count = 0 AndAlso tsDirect.DropDownItems.Count = 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = True
                tsReport1.Visible = False
                tsDirect.Visible = False
            ElseIf tsTransaction.DropDownItems.Count = 0 AndAlso tsReport1.DropDownItems.Count > 0 AndAlso tsDirect.DropDownItems.Count = 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = False
                tsReport1.Visible = True
                tsDirect.Visible = False
            ElseIf tsTransaction.DropDownItems.Count = 0 AndAlso tsReport1.DropDownItems.Count = 0 AndAlso tsDirect.DropDownItems.Count > 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = False
                tsReport1.Visible = False
                tsDirect.Visible = True
            ElseIf tsTransaction.DropDownItems.Count = 0 AndAlso tsReport1.DropDownItems.Count > 0 AndAlso tsDirect.DropDownItems.Count > 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = False
                tsReport1.Visible = True
                tsDirect.Visible = True
            ElseIf tsTransaction.DropDownItems.Count > 0 AndAlso tsReport1.DropDownItems.Count = 0 AndAlso tsDirect.DropDownItems.Count > 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = True
                tsReport1.Visible = False
                tsDirect.Visible = True
            ElseIf tsTransaction.DropDownItems.Count > 0 AndAlso tsReport1.DropDownItems.Count > 0 AndAlso tsDirect.DropDownItems.Count = 0 Then
                tsPayment.Visible = True
                tsTransaction.Visible = True
                tsReport1.Visible = True
                tsDirect.Visible = False
            Else
                tsPayment.Visible = False
            End If
            If tstaxtransaction.DropDownItems.Count > 0 AndAlso tstaxreport.DropDownItems.Count > 0 Then
                tstax.Visible = True
                tstaxtransaction.Visible = True
                tstaxreport.Visible = True
            ElseIf tstaxtransaction.DropDownItems.Count > 0 AndAlso tstaxreport.DropDownItems.Count = 0 Then
                tstax.Visible = True
                tstaxtransaction.Visible = True
                tstaxreport.Visible = False
            ElseIf tstaxtransaction.DropDownItems.Count = 0 AndAlso tstaxreport.DropDownItems.Count > 0 Then
                tstax.Visible = True
                tstaxtransaction.Visible = False
                tstaxreport.Visible = True
            Else
                tstax.Visible = False
            End If
            If WHJtsb.DropDownItems.Count > 0 AndAlso Fintsb.DropDownItems.Count > 0 Then
                SJtsb.Visible = True
                WHJtsb.Visible = True
                Fintsb.Visible = True
            ElseIf WHJtsb.DropDownItems.Count > 0 AndAlso Fintsb.DropDownItems.Count = 0 Then
                SJtsb.Visible = True
                WHJtsb.Visible = True
                Fintsb.Visible = False
            ElseIf WHJtsb.DropDownItems.Count = 0 AndAlso Fintsb.DropDownItems.Count > 0 Then
                SJtsb.Visible = True
                WHJtsb.Visible = False
                Fintsb.Visible = True
            Else
                SJtsb.Visible = False
            End If
            If tsSuspend.DropDownItems.Count > 0 AndAlso tsSettlement.DropDownItems.Count > 0 Then
                tsDirect1.Visible = True
                tsSuspend.Visible = True
                tsSettlement.Visible = True
            ElseIf tsSuspend.DropDownItems.Count > 0 AndAlso tsSettlement.DropDownItems.Count = 0 Then
                tsDirect1.Visible = True
                tsSuspend.Visible = True
                tsSettlement.Visible = False
            ElseIf tsSuspend.DropDownItems.Count = 0 AndAlso tsSettlement.DropDownItems.Count > 0 Then
                tsDirect1.Visible = True
                tsSuspend.Visible = False
                tsSettlement.Visible = True
            Else
                tsDirect1.Visible = False
            End If

            If tsMenuTMMIN.DropDownItems.Count > 0 AndAlso tsMenuTAM.DropDownItems.Count > 0 Then
                tsMenuPOCheck.Visible = True
                tsMenuTAM.Visible = True
                tsMenuTMMIN.Visible = True
            ElseIf tsMenuTAM.DropDownItems.Count > 0 AndAlso tsMenuTAM.DropDownItems.Count = 0 Then
                tsMenuPOCheck.Visible = True
                tsMenuTAM.Visible = False
                tsMenuTMMIN.Visible = True
                tsMenuTMMIN.Visible = True
            ElseIf tsMenuTAM.DropDownItems.Count = 0 AndAlso tsMenuTAM.DropDownItems.Count > 0 Then
                tsMenuPOCheck.Visible = True
                tsMenuTAM.Visible = True
                tsMenuTMMIN.Visible = False
            Else

                tsMenuPOCheck.Visible = False
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Sub RemoveMenuNavBar()
        If Me.tsMenuMaster.DropDownItems.Count > 0 Then
            Me.tsMenuMaster.DropDownItems.Clear()
        End If
        If Me.tsMenuTMMIN.DropDownItems.Count > 0 Then
            Me.tsMenuTMMIN.DropDownItems.Clear()
        End If
        If Me.tsMenuTAM.DropDownItems.Count > 0 Then
            Me.tsMenuTAM.DropDownItems.Clear()
        End If
        If Me.SoTsm.DropDownItems.Count > 0 Then
            Me.SoTsm.DropDownItems.Clear()
        End If
        'If Me.TSMPLM.DropDownItems.Count > 0 Then
        '    Me.TSMPLM.DropDownItems.Clear()
        'End If
        'If Me.tsbForecast.DropDownItems.Count > 0 Then
        '    Me.tsbForecast.DropDownItems.Clear()
        'End If
        If Me.tsReport.DropDownItems.Count > 0 Then
            Me.tsReport.DropDownItems.Clear()
        End If
        If Me.BudgetTSM.DropDownItems.Count > 0 Then
            Me.BudgetTSM.DropDownItems.Clear()
        End If
        If Me.ForecastTSM.DropDownItems.Count > 0 Then
            Me.ForecastTSM.DropDownItems.Clear()
        End If
        If Me.PriceTSM.DropDownItems.Count > 0 Then
            Me.PriceTSM.DropDownItems.Clear()
        End If
        If Me.CalculateTM.DropDownItems.Count > 0 Then
            Me.CalculateTM.DropDownItems.Clear()
        End If

        If Me.tsTransaction.DropDownItems.Count > 0 Then
            Me.tsTransaction.DropDownItems.Clear()
        End If

        If Me.tsReport1.DropDownItems.Count > 0 Then
            Me.tsReport1.DropDownItems.Clear()
        End If

        If Me.tsDirect.DropDownItems.Count > 0 Then
            Me.tsDirect.DropDownItems.Clear()
        End If
        If Me.tstaxtransaction.DropDownItems.Count > 0 Then
            Me.tstaxtransaction.DropDownItems.Clear()
        End If

        If Me.tstaxreport.DropDownItems.Count > 0 Then
            Me.tstaxreport.DropDownItems.Clear()
        End If

        If Me.tsMenuSetting.DropDownItems.Count > 0 Then
            Me.tsMenuSetting.DropDownItems.Clear()
        End If
        If Me.WHJtsb.DropDownItems.Count > 0 Then
            Me.WHJtsb.DropDownItems.Clear()
        End If
        If Me.Fintsb.DropDownItems.Count > 0 Then
            Me.Fintsb.DropDownItems.Clear()
        End If
        If Me.tsSettlement.DropDownItems.Count > 0 Then
            Me.tsSettlement.DropDownItems.Clear()
        End If

        If Me.tsSuspend.DropDownItems.Count > 0 Then
            Me.tsSuspend.DropDownItems.Clear()
        End If
        If Me.tsMenuAsakai.DropDownItems.Count > 0 Then
            Me.tsMenuAsakai.DropDownItems.Clear()
        End If

        If Me.tsMenuCirculation.DropDownItems.Count > 0 Then
            Me.tsMenuCirculation.DropDownItems.Clear()
        End If

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    'Private Sub ToolStripButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) _
    'Handles btnSave.Click, btnNew.Click

    '    Dim base As New baseForm

    '    Application.DoEvents()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim TSBtn As ToolStripButton = sender
    '    Select Case TSBtn.Name
    '        Case btnSave.Name
    '            If CType(Me.ActiveMdiChild, Object) Is Nothing Then
    '            Else
    '                If CType(Me.ActiveMdiChild, Object).ValidateSave() Then
    '                    Dim lb_Berhasil As Boolean = True
    '                    Call CType(Me.ActiveMdiChild, Object).Proc_SaveData(lb_Berhasil)
    '                    If lb_Berhasil = True Then
    '                        Call CType(Me.ActiveMdiChild, Object).Proc_SaveData()
    '                        base.ChangePerformed = False
    '                        CType(Me.ActiveMdiChild, Object).ResetInputState()
    '                    End If
    '                End If
    '            End If

    '            'CType(Me.ActiveMdiChild, Object).FirtsRecord()

    '        Case btnOpen.Name
    '            If MsgBox("Are you sure to delete data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
    '                If CType(Me.ActiveMdiChild, Object).ValidateDelete() Then
    '                    Call CType(Me.ActiveMdiChild, Object).Proc_DeleteData()
    '                End If
    '            End If
    '        Case btnNew.Name
    '            'TSBtn_Delete.Enabled = False
    '            '# Reset input state...                
    '            If CType(Me.ActiveMdiChild, Object) Is Nothing Then
    '            Else
    '                CType(Me.ActiveMdiChild, Object).Proc_InputNewData()
    '                base.ChangePerformed = False
    '            End If


    '        Case btnPrint.Name
    '            If CType(Me.ActiveMdiChild, Object) Is Nothing Then
    '            Else
    '                Call CType(Me.ActiveMdiChild, Object).Proc_Print()
    '            End If
    '        Case btnPreview.Name
    '            If CType(Me.ActiveMdiChild, Object) Is Nothing Then
    '            Else
    '                Call CType(Me.ActiveMdiChild, Object).Proc_PrintPreview()
    '            End If
    '        Case btnHelp.Name
    '            If CType(Me.ActiveMdiChild, Object) Is Nothing Then
    '            Else
    '                Call CType(Me.ActiveMdiChild, Object).Proc_Filter()
    '            End If
    '            'Case TSBtn_Refresh.Name
    '            '    Call ShowMessage("", MessageTypeEnum.NotBoxMessage)
    '            '    Call Proc_Refresh()
    '            'Case TSBtn_Excel.Name
    '            '    Call Proc_Excel()
    '            'Case TSBtn_Prev.Name
    '            '    Call Proc_PrevItem()
    '            'Case TSBtn_Next.Name
    '            '    Call Proc_NextItem()
    '    End Select
    '    Me.Cursor = Cursors.Default
    'End Sub
    Public Function EndApplication() As Boolean
        'Delete These 3 Variables If You Need To...
        Dim warnings As Boolean = True
        Dim Message As String = String.Empty
        Dim DialogCaption As String = "Dialog Message"
        If warnings Then
            Message = "You have elected to close " & My.Application.Info.ProductName & " is this what you want?"
            If MessageBox.Show(Message, DialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        Return False
    End Function

End Class
