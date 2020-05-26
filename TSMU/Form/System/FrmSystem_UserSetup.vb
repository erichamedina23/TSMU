Public Class FrmSystem_UserSetup
    Dim ls_Error As String = ""
    Dim fc_User As New ClassSystemUser1
    Dim fs_Split As String = "'"
    Dim fi_Kode As Byte = 0
    Dim fi_Nama As Byte = 1
    Dim dataTB As DataTable = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FillHeader_fdtlConfig()
        dataTB = New DataTable
        dataTB.Columns.Add("bomid")
        dataTB.Columns.Add("FinishGood")
        dataTB.Columns.Add("invtid")
        dataTB.Columns.Add("qty")
        dataTB.Columns.Add("unit")
        dataTB.Clear()
    End Sub

    Public Enum IndexCol As Byte
        bomid = 0
        FinishGood = 1
        MenuChild = 2
        invtid = 3
        qty = 4
        unit = 5
    End Enum

    Sub FillDT()
        GridAkses.DataSource = Nothing
        Dim dtTable As DataTable = fc_User.getMenuAccess("")
        GridAkses.DataSource = dtTable


        'Dim dtHeader As DataTable = fc_User.GetParentMenu

        'If dtHeader Is Nothing Then
        '    Exit Sub
        'End If
        'Call FillHeader_fdtlConfig()
        'For i As Integer = 0 To dtHeader.Rows.Count - 1
        '    dataTB.Rows.Add()
        '    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.MenuMain) = Trim(dtHeader.Rows(i).Item("Main_Menu") & "")
        '    'dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.MenuChild) = Trim(dtHeader.Rows(i).Item("Insert") & "")
        '    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Access) = Trim(dtHeader.Rows(i).Item("Access") & "")
        '    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Insert) = Trim(dtHeader.Rows(i).Item("Insert") & "")
        '    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Update) = Trim(dtHeader.Rows(i).Item("Update") & "")
        '    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Delete) = Trim(dtHeader.Rows(i).Item("Delete") & "")
        '    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Special) = Trim(dtHeader.Rows(i).Item("Special") & "")
        '    Dim dtDetail As New DataTable
        '    dtDetail = fc_User.GetChildMenu(Trim(dtHeader.Rows(i).Item(IndexCol.MenuMain)))
        '    For j As Integer = 0 To dtDetail.Rows.Count - 1
        '        dataTB.Rows.Add()
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.MenuCode) = Trim(dtDetail.Rows(j).Item("MenuCode") & "")
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.MenuChild) = Trim(dtDetail.Rows(j).Item("Menu_Child") & "")
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Access) = Trim(dtDetail.Rows(j).Item("Access") & "")
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Insert) = Trim(dtDetail.Rows(j).Item("Insert") & "")
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Update) = Trim(dtDetail.Rows(j).Item("Update") & "")
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Delete) = Trim(dtDetail.Rows(j).Item("Delete") & "")
        '        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Special) = Trim(dtDetail.Rows(j).Item("Special") & "")
        '    Next
        'Next

        'With GridAkses
        '    .DataSource = dataTB
        '    .Columns(1).Visible = False
        'End With
        Dim chkAcces As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim chkInsert As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim chkUpdate As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim chkDelete As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim chkSpecial As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        With GridAkses
            .Columns(1).Visible = False
        End With
    End Sub
    Public Shared Sub SetGridViewSortState(ByVal dgv As DataGridView, ByVal sortMode As DataGridViewColumnSortMode)
        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = sortMode
        Next
    End Sub
    Private Sub FrmSystem_UserSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call Proc_EnableButtons(True, True, True, True, False, False, False, False)
            AturGrid(GridAkses, Me)
            AturGrid(GridUser, Me)
            TabControl1.TabPages(0).BackColor = tabcolour
            '# Override grid anchor...
            'GridUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles)
            Call FillComboUsers()
            Call FillComboGroupUser()
            Call FillGridUsers()
            'Call FillGridAkses("")
            FillDT()
            RemoveHandler TxtUsername.Validated, AddressOf TextBoxValidate
            RemoveHandler TxtPassword.Validated, AddressOf TextBoxValidate
            RemoveHandler TxtConfirmation.Validated, AddressOf TextBoxValidate
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Private Sub FillComboUsers()
        Try
            Dim dt As New DataTable
            dt = fc_User.GetAllDataTableComboAll()
            dt.PrimaryKey = New DataColumn() {dt.Columns("Username")}
            CboUsers.DataSource = dt
            CboUsers.ValueMember = "Username"
            CboUsers.DisplayMember = "Username"
            CboUsers.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillComboGroupUser()
        Try
            Dim dt2 As New DataTable
            dt2 = fc_User.GetComboGroup()
            'dt2.PrimaryKey = New DataColumn() {dt2.Columns("UserGroupCode")}
            cbGroupUser.DataSource = dt2
            cbGroupUser.ValueMember = "UserGroupCode"
            cbGroupUser.DisplayMember = "UserGroupName"
            cbGroupUser.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGridUsers()
        Try
            Dim dt As New DataTable
            GridUser.DataSource = Nothing
            dt = fc_User.GetAllNameListDataTable()
            GridUser.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridUser_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUser.CellDoubleClick
        If e.RowIndex > -1 Then
            'Call Proc_InputNewData()
            Cursor = Cursors.WaitCursor
            Call ViewData(GridUser.Item("Username", e.RowIndex).Value.ToString.Trim)
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub ViewData(ByVal UserName As String)
        Try
            If UserName.Trim = "" Then
                TxtUsername.Text = ""
                TxtUsername.ReadOnly = False
                TxtName.Text = ""
                ChChangePassword.Checked = True
                ChChangePassword.Enabled = False
                TxtPassword.Text = ""
                TxtPassword.Enabled = True
                TxtPassword.BackColor = Color.FromKnownColor(KnownColor.Window)
                TxtConfirmation.Text = ""
                TxtConfirmation.Enabled = True
                TxtConfirmation.BackColor = Color.FromKnownColor(KnownColor.Window)
                CboUsers.Text = ""
                ChAdmin.Checked = False
                ChActive.Checked = True
                TxtRemark.Text = ""
                _CmbSite.Text = ""
                _TxtLevel.Text = ""
                'LblHakAkses.Text = ""
                cbGroupUser.SelectedIndex = cbGroupUser.Items.Count - 1
                Call FillGridAkses("")
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                End If
                Exit Sub
            Else
                Dim lc_User As New ClassSystemUser1
                lc_User.GetData(UserName)
                With lc_User
                    TxtUsername.Text = .Username
                    TxtUsername.ReadOnly = True
                    TxtName.Text = .Name
                    ChChangePassword.Checked = False
                    ChChangePassword.Enabled = True
                    TxtPassword.Text = ""
                    TxtPassword.Enabled = False
                    TxtPassword.BackColor = Color.FromKnownColor(KnownColor.Control)
                    TxtConfirmation.Text = ""
                    TxtConfirmation.Enabled = False
                    TxtConfirmation.BackColor = Color.FromKnownColor(KnownColor.Control)
                    CboUsers.Text = ""
                    ChAdmin.Checked = .AdminStatus
                    ChActive.Checked = .FlagActive
                    TxtRemark.Text = .Remark
                    _CmbSite.Text = .Site
                    _TxtLevel.Text = .Level
                    'LblHakAkses.Text = "" & .Username
                    'cbGroupUser.SelectedValue = .UserGroupCode
                    cbGroupUser.Text = .UserGroupName
                    Call FillGridAkses(.Username)
                End With
            End If
            'Dim lc_User As New ClassSystemUser
            'lc_User.GetData(UserName)
            'If ls_Error <> "" Then
            '    TxtUsername.Text = ""
            '    TxtUsername.ReadOnly = False
            '    ChAdmin.Checked = ""
            '    TxtName.Text = ""
            '    TxtPassword.Text = ""
            '    TxtConfirmation.Text = ""
            '    CboUsers.Text = ""
            '    TxtRemark.Text = ""
            '    LblHakAkses.Text = ""
            '    Call FillGridAkses("")
            '    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
            '    Exit Sub
            'Else
            '    With lc_User
            '        TxtUsername.Text = .Username
            '        TxtUsername.ReadOnly = True
            '        ChAdmin.Checked = .AdminStatus
            '        TxtName.Text = .Name
            '        TxtPassword.Text = ""
            '        TxtConfirmation.Text = ""
            '        CboUsers.Text = ""
            '        TxtRemark.Text = .Remark
            '        LblHakAkses.Text = "" & .Username
            '        Call FillGridAkses(.Username)
            '    End With
            'End If
            Call ResetInputState()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub FillGridAkses(ByVal UserName As String)
        Try
            If UserName <> "" Then

                For k As Integer = 0 To GridAkses.RowCount - 1
                    GridAkses.Rows(k).Cells("Access").Value = False
                    GridAkses.Rows(k).Cells("Insert").Value = False
                    GridAkses.Rows(k).Cells("Update").Value = False
                    GridAkses.Rows(k).Cells("Delete").Value = False
                    GridAkses.Rows(k).Cells("Special").Value = False
                    GridAkses.Rows(k).Cells("Price").Value = False
                    GridAkses.Rows(k).Cells("Qty").Value = False
                Next k
                Dim tblHak As New DataTable
                tblHak = fc_User.getMenuAccess(UserName)
                If ls_Error <> "" Then ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage) : Exit Sub
                If tblHak.Rows.Count > 0 Then
                    For i As Integer = 0 To tblHak.Rows.Count - 1
                        For j As Integer = 0 To GridAkses.RowCount - 1

                            If tblHak.Rows(i)("title").ToString = GridAkses.Rows(j).Cells(2).Value.ToString And tblHak.Rows(i)("ParentMenu").ToString = GridAkses.Rows(j).Cells(0).Value.ToString Then
                                GridAkses.Rows(j).Cells("Access").Value = tblHak.Rows(i)(3)
                                GridAkses.Rows(j).Cells("Insert").Value = tblHak.Rows(i)(4)
                                GridAkses.Rows(j).Cells("Update").Value = tblHak.Rows(i)(5)
                                GridAkses.Rows(j).Cells("Delete").Value = tblHak.Rows(i)(6)
                                GridAkses.Rows(j).Cells("Special").Value = tblHak.Rows(i)(7)
                                GridAkses.Rows(j).Cells("Price").Value = tblHak.Rows(i)(8)
                                GridAkses.Rows(j).Cells("Qty").Value = tblHak.Rows(i)(9)
                                Exit For
                            End If
                        Next

                    Next
                Else
                    FillDT()
                End If
            Else
                FillDT()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        '# Validate input...
        '## Input cannot be empty...
        If TxtUsername.Text.Trim = "" Then TxtUsername.Focus() : ShowMessage("Please fill username!") : Return False
        If TxtName.Text.Trim = "" Then TxtName.Focus() : ShowMessage("Please fill name!") : Return False
        If TxtUsername.ReadOnly = False Then
            If TxtPassword.Text.Trim = "" Then TxtPassword.Focus() : ShowMessage("Password tidak boleh kosong!") : Return False
            If TxtConfirmation.Text.Trim = "" Then TxtConfirmation.Focus() : ShowMessage("Konfirmasi Password tidak boleh kosong!") : Return False
            If TxtPassword.Text.Trim.Equals(TxtConfirmation.Text.Trim, StringComparison.CurrentCulture) = False Then TxtConfirmation.Focus() : ShowMessage("Konfirmasi Password salah!") : Return False
        Else
            If TxtPassword.Text.Trim <> "" OrElse TxtConfirmation.Text.Trim <> "" Then
                If TxtPassword.Text.Trim = "" Then TxtPassword.Focus() : ShowMessage("Password tidak boleh kosong!") : Return False
                If TxtConfirmation.Text.Trim = "" Then TxtConfirmation.Focus() : ShowMessage("Konfirmasi Password tidak boleh kosong!") : Return False
                If TxtPassword.Text.Trim.Equals(TxtConfirmation.Text.Trim, StringComparison.CurrentCulture) = False Then TxtConfirmation.Focus() : ShowMessage("Konfirmasi Password salah!") : Return False
            End If
        End If

        fc_User = New ClassSystemUser1
        If TxtUsername.ReadOnly = True Then
            Try
                fc_User.GetData(TxtUsername.Text.Trim)
            Catch ex As Exception
                ShowMessage("Ambil data user gagal ! (" & ls_Error & ")", MessageTypeEnum.ErrorMessage)
                Return False
            End Try
            If TxtPassword.Text.Trim <> "" Then
                fc_User.Password = TxtPassword.Text.Trim
            End If
        Else
            fc_User.Username = TxtUsername.Text.Trim
            fc_User.Password = TxtPassword.Text.Trim
        End If

        fc_User.AdminStatus = IIf(TxtUsername.Text.Trim = "admin", True, ChAdmin.Checked)
        fc_User.FlagActive = ChActive.Checked
        fc_User.Name = TxtName.Text.Trim
        fc_User.Remark = TxtRemark.Text.Trim
        fc_User.UserGroupCode = cbGroupUser.SelectedValue.ToString.Trim
        fc_User.Site = _CmbSite.Text
        fc_User.Level = _TxtLevel.Text
        '##
        Return True
    End Function
    Public Overrides Sub Proc_InputNewData_Child()
        TxtUsername.Text = ""
        TxtUsername.ReadOnly = False
        TxtName.Text = ""
        ChChangePassword.Checked = True
        ChChangePassword.Enabled = False
        TxtPassword.Text = ""
        TxtPassword.Enabled = True
        TxtConfirmation.Text = ""
        TxtConfirmation.Enabled = True
        FillComboUsers()
        CboUsers.SelectedIndex = -1
        cbGroupUser.SelectedIndex = cbGroupUser.Items.Count - 1
        ChAdmin.Checked = False
        ChActive.Checked = True
        TxtRemark.Text = ""
        _CmbSite.Text = ""
        'LblHakAkses.Text = ""
        cbGroupUser.SelectedIndex = 0
        FillGridAkses("")
        TxtUsername.Focus()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Dim ls_Save As String = ""
        Dim ls_Delete As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    If TxtUsername.ReadOnly = True Then
                        fc_User.UpdateData()
                        If TxtPassword.Text.Trim <> "" Then
                            If TxtUsername.Text.Trim.ToLower <> "admin" Then
                                fc_User.UpdatePassword()
                                'If ls_Error <> "" Then Err.Raise(ErrNumber, , ls_Error)
                            ElseIf TxtUsername.Text.Trim = gh_Common.Username Then
                                fc_User.UpdatePassword()
                                'If ls_Error <> "" Then Err.Raise(ErrNumber, , ls_Error)
                            End If
                        End If
                    Else
                        fc_User.InsertData()
                    End If

                    '# Hapus data hak kemudian isi kembali...
                    ls_Delete =
                    "DELETE S_UserPermission WHERE AppID = '1' And Username = " & QVal(TxtUsername.Text.Trim) & vbLf &
                    ""

                    MainModul.ExecQuery(ls_Delete)
                    '# Simpan hak...
                    Dim ls_Privilege As String = ""
                    Dim price As Boolean = False
                    Dim harga As Boolean = False
                    For i As Integer = 0 To GridAkses.Rows.Count - 1
                        If CBool(DirectCast(GridAkses.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value) = True Then
                            If GridAkses.Rows(i).Cells(8).Value Is DBNull.Value Then
                                price = False
                            Else
                                price = QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(8), DataGridViewCheckBoxCell).Value))
                            End If
                            If GridAkses.Rows(i).Cells(9).Value Is DBNull.Value Then
                                harga = False
                            Else
                                harga = QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(9), DataGridViewCheckBoxCell).Value))
                            End If

                            ls_Privilege &=
                                "   SELECT Username = " & QVal(TxtUsername.Text.Trim) &
                                "       ,APPID = " & QVal(1) &
                                "       ,MenuCode = " & QVal(CStr(DirectCast(GridAkses.Rows(i).Cells(1), DataGridViewTextBoxCell).Value)) &
                                "       ,[Access] = " & QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value)) &
                                "       ,[Insert] = " & QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value)) &
                                "       ,[Update] = " & QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(5), DataGridViewCheckBoxCell).Value)) &
                                "       ,[Delete] = " & QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(6), DataGridViewCheckBoxCell).Value)) &
                                "       ,[Special] = " & QVal(CBool(DirectCast(GridAkses.Rows(i).Cells(7), DataGridViewCheckBoxCell).Value)) &
                                "       ,[Price] = " & QVal(price) &
                                "       ,[Qty] = " & QVal(harga) &
                                "   UNION "
                        End If
                    Next

                    If ls_Privilege.Trim <> "" Then
                        ls_Privilege = ls_Privilege.Remove(ls_Privilege.LastIndexOf("UNION"))
                        ls_Save =
                        "INSERT S_UserPermission (" & vbLf &
                        "  Username, AppID, MenuCode, [Access], [Insert], [Update], [Delete], [Special], [Price],[Qty] " & vbLf &
                        ")" & vbLf &
                        ls_Privilege
                        MainModul.ExecQuery(ls_Save)
                    End If


                    Trans1.Commit()
                    MainModul.gh_Trans.Command = Nothing
                    'Sudah Berhasil Save
                    Call FillGridUsers()
                    Call ResetInputState()
                    Call Proc_InputNewData()
                    Me.Cursor = Cursors.Default
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil))
                End Using
            End Using
        Catch ex As Exception
            MainModul.gh_Trans.Command = Nothing
            Me.Cursor = Cursors.Default
            ShowMessage("Simpan data user gagal ! [" & ex.Message & "]", MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Function ValidateDelete() As Boolean
        '# Validate input...
        '## Input cannot be empty...
        If TxtUsername.Text.Trim = "" Then TxtUsername.Focus() : ShowMessage("Pilih data yang akan dihapus!") : Return False
        If TxtUsername.Text.Trim = "admin" Then GridUser.Focus() : ShowMessage("Admin developer tidak bisa dihapus!") : Return False
        '##
        Return True
    End Function

    Public Overrides Sub Proc_DeleteData()
        Dim ls_Delete As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    'gSC_Command = New SqlClient.SqlCommand
                    'gSC_Command.Connection = Conn1
                    'gSC_Command.Transaction = Trans1

                    If MainModul.gh_Trans IsNot Nothing Then
                        MainModul.gh_Trans = Nothing
                    End If
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command = New SqlClient.SqlCommand
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    ls_Delete = "Delete From S_User Where UserName = '" & TxtUsername.Text.Trim & "' "
                    ls_Error = MainModul.ExecQuery(ls_Delete)
                    'If ls_Error <> "" Then Err.Raise(ErrNumber, , "Hapus data user gagal ! (" & ls_Error & ")")

                    ls_Delete = "Delete From S_UserPermission Where AppID = '1' And UserName = '" & TxtUsername.Text.Trim & "'"
                    ls_Error = MainModul.ExecQuery(ls_Delete)
                    'If ls_Error <> "" Then Err.Raise(ErrNumber, , "Hapus data user gagal ! (" & ls_Error & ")")

                    Trans1.Commit()
                    MainModul.gh_Trans.Command = Nothing
                    'Sudah Berhasil Hapus
                    Call FillGridUsers()
                    Call ResetInputState()
                    Call Proc_InputNewData()
                    Call ShowMessage("Hapus data berhasil!")
                End Using
            End Using
        Catch ex As Exception
            MainModul.gh_Trans.Command = Nothing
            Call ShowMessage("Hapus data gagal ! [" & ex.Message & "]", MessageTypeEnum.ErrorMessage, ex.StackTrace)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            Me.Cursor = Cursors.Default
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Try
            Call FillComboUsers()
            Call FillComboGroupUser()
            Call FillGridUsers()
            FillDT()
            Call ViewData(TxtUsername.Text.Trim)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub


    Private Sub KeyPresses(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        ShowMessage("", MessageTypeEnum.NotBoxMessage)
        Dim ctrl As Control = sender
        'If e.KeyChar = Chr(Keys.Enter) Then Me.SelectNextControl(ctrl, True, True, True, True)
        If e.KeyChar = "'" Then e.Handled = False : Exit Sub
        'Select Case ctrl.Name
        '    Case TxtUsername.Name
        '        'If e.KeyChar = Chr(Keys.Enter) AndAlso ctrl.Text.Trim <> "" Then Call ViewData(ctrl.Text.Trim)
        '    Case Else
        'End Select

    End Sub

    Private Sub CboUsersSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If CboUsers.Text <> "" Then
                Call FillGridAkses(CboUsers.Text.Trim)
            Else
                Call FillGridAkses("")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub ChChangePassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChChangePassword.CheckedChanged

        TxtPassword.Enabled = ChChangePassword.Checked
        TxtConfirmation.Enabled = ChChangePassword.Checked
        TxtPassword.BackColor = IIf(ChChangePassword.Checked, Color.FromKnownColor(KnownColor.Window), Color.FromKnownColor(KnownColor.Control))
        TxtConfirmation.BackColor = IIf(ChChangePassword.Checked, Color.FromKnownColor(KnownColor.Window), Color.FromKnownColor(KnownColor.Control))

    End Sub

    Private Sub cbGroupUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGroupUser.SelectedIndexChanged
        Try
            If cbGroupUser.SelectedValue.ToString.Trim.ToUpper = "ADMIN" Then
                ChAdmin.Checked = True
            Else
                ChAdmin.Checked = False
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridAkses_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles GridAkses.RowsAdded
        SetGridViewSortState(GridAkses, DataGridViewColumnSortMode.NotSortable)
    End Sub

    Private Sub GridAkses_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles GridAkses.CurrentCellDirtyStateChanged
        If GridAkses.IsCurrentCellDirty Then
            GridAkses.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub CboUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboUsers.SelectedIndexChanged
        Try
            If CboUsers.Text <> "" Then
                Try
                    fc_User.GetData(CboUsers.Text.Trim)
                Catch ex As Exception
                    ex = Nothing
                End Try

                cbGroupUser.Text = fc_User.UserGroupName
                Call FillGridAkses(CboUsers.Text.Trim)
            Else
                Call FillGridAkses("")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
End Class
