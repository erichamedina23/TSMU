Public Class FrmLogin
    Dim fs_Product As String = ""

    Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            If UsernameTextBox.Text.Trim = "" Then
                UsernameTextBox.Focus()
                MsgBox("Please Input User Name!")
            ElseIf PasswordTextBox.Text.Trim = "" Then
                PasswordTextBox.Focus()
                MsgBox("Please Input Password!")
            Else
                gh_Common = New InstanceVariables.CommonHelper
                'gh_Trans = New InstanceVariables.TransactionHelper
                Dim ls_Error As String = ""
                Dim lc_User As New ClassSystemUser1
                lc_User.Username = UsernameTextBox.Text.Trim
                lc_User.Password = PasswordTextBox.Text.Trim
                If lc_User.CheckLoginPasswordBinary(lc_User.Username, PasswordTextBox.Text.Trim) Then
                    'gs_LoginUserID = lc_User.UserName
                    'gs_LoginNamaUser = lc_User.Nama
                    'gb_LoginAdminStatus = lc_User.StatusAdmin
                    gh_Common.Username = lc_User.Username
                    gh_Common.Name = lc_User.Name
                    gh_Common.AdminStatus = lc_User.AdminStatus
                    gh_Common.GroupID = lc_User.UserGroupCode
                    gh_Common.Group = lc_User.UserGroupName
                    gh_Common.Site = lc_User.Site
                    gh_Common.Level = lc_User.Level
                    lc_User.UpdateLastLogin()
                    If ls_Error <> "" Then ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    '# Ambil data tabel setting...
                    Call InitializeApp()
                    'Me.Dispose()
                    Me.Close()
                Else
                    UsernameTextBox.Focus()
                    MsgBox("Wrong Username or Password!")
                End If
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
            gs_Error = Err.Description
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call gf_GetDatabaseVariables()
        gf_GetDatabaseVariablesSolomon()
        gf_GetDatabaseVariablesDbCKR()
        fs_Product = My.Application.Info.ProductName
        _txtVersion.Text = "Version " & Application.ProductVersion
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            '# Every time Login window appears, disable all menu...
            Call CloseApp()
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()
            FrmMain.LblDatabase.Caption = "Database : " & gs_Database & " (" & gs_DBServer & ")"
        End If
        UsernameTextBox.Focus()
    End Sub
    Private Sub BeginApp()
        FrmMain.LoginBar.Caption = "Log Out"
        'Dim DaftarMenu As ToolStripMenuItem = Nothing
        'For Each DaftarMenu In FrmMain.MenuStrip.Items
        '    DaftarMenu.Enabled = True
        'Next
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CloseApp()
        FrmMain.LoginBar.Caption = "Log In"

        FrmMain.Ribbon.Enabled = True
        FrmMain.LoginBar.Enabled = True
        FrmMain.ExitBar.Enabled = True
        FrmMain.ChngePasBar.Enabled = False
        FrmMain.LblLogin.Caption = ""
        FrmMain.lblGroup.Caption = ""
        FrmMain.LblDatabase.Caption = ""
        FrmMain.WindowState = FormWindowState.Maximized
        ShowMessage("", MessageTypeEnum.NotBoxMessage)
    End Sub

    Private Sub FrmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then

            If frm_system_config_db.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
                UsernameTextBox.Focus()
                FrmMain.LblDatabase.Caption = "Database : " & gs_Database & " (" & gs_DBServer & ")"
            End If
        End If
    End Sub

    Private Sub FrmLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If UsernameTextBox.Text.Trim <> "" And PasswordTextBox.Text.Trim <> "" Then
                OK.PerformClick()
            Else
                Me.SelectNextControl(sender, True, True, True, True)
            End If
        End If
    End Sub
    Private Sub InitializeApp()
        Try
            Dim query As String = ""
            Dim ds As DataSet = Nothing
            Dim ls_Error As String = ""

            gc_Setting = New ClassSystemConfiguration
            fs_Product = "Bill of Material" 'My.Application.Info.AssemblyName

            gc_Setting.GetData()

            If gc_Setting.KodeSetting <> "" Then
                '# Nama & Unit Usaha...
                gs_CompanyName = gc_Setting.NamaPerusahaan.Trim
                gs_CompanyAddress = gc_Setting.Alamat.Trim
                gs_CompanyPhoneNo = gc_Setting.Telp.Trim
                gs_CompanyFaxNo = gc_Setting.Fax.Trim

                'gs_PhysicalFlow = "FIFO" ' gc_Setting.MetodeStok

                '# Nama Form Perusahaan...
                If gs_CompanyName <> "" Then
                    FrmMain.Text = fs_Product & " - " & gs_CompanyName
                Else
                    'FrmSystem_Menu.Text = fs_Product & " - [Company Name]"
                    'frmMain.Text = "TSMU - " & fs_Product
                    FrmMain.Text = "TSMU "
                End If
                'gd_SumRound = gc_Setting.JumlahRounding
                'gb_RoundUp = gc_Setting.RoundingUp
            Else
                gs_CompanyName = "TSMU"
                gs_CompanyAddress = ""
                gs_CompanyPhoneNo = ""
                gs_CompanyFaxNo = ""

                FrmMain.Text = "TSMU "

            End If


            query =
            "SELECT * FROM S_UserPermission WHERE UserName = " & QVal(gh_Common.Username) & vbLf &
            ""
            Dim dt As DataTable = MainModul.GetDataTable(query)
            '# Main Menu Display
            FrmMain.LoadMenu()

            '# User rights ( access, update )...
            'Dim dtRights As DataTable = ds.Tables(1)
            Dim dtRights As DataTable = dt
            dtRights.PrimaryKey = New DataColumn() {dtRights.Columns("KodeMenu")}
            If dtRights.Rows.Count > 0 Then
                Dim MenuItem As ToolStripItem = Nothing
                Dim findRow As DataRow = Nothing
                For Each MenuItem In MyMenus
                    findRow = dtRights.Rows.Find(MenuItem.Name)
                    If findRow IsNot Nothing Then
                        If findRow("HakAkses") = 1 OrElse MenuItem.Name = "FrmSystem_UserSetup" Then
                            MenuItem.Enabled = True
                        Else
                            MenuItem.Enabled = False
                        End If
                    End If
                Next
            End If
            '# Enable menu group...
            BeginApp()
            '# Menu Backup...
            FrmMain.ChngePasBar.Enabled = True
            '# Settings menu can only be accessed by Admin users...
            'FrmMenu.MenuSetting.Enabled = gb_AdminStatus
            'FrmMenu.FrmSystem_Configuration.Enabled = gb_AdminStatus
            'FrmMenu.FrmSystem_UserSetup.Enabled = gb_AdminStatus
            '# Menu Labels...
            FrmMain.LblLogin.Caption = "User : " & gh_Common.Username
            FrmMain.lblGroup.Caption = "Group : " & gh_Common.Group
            'FrmSystem_Menu.LblPeriod.Text = "Periode " & Format(ServerDate, "MMM-yyyy")
            'FrmMenu.LblDatabase.Text = "File : " & gs_Database & " (" & gs_DBServer & ")"
            '# Form name...

            ShowMessage("", MessageTypeEnum.NotBoxMessage)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
