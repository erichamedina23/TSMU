Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class baseForm
    Public ChangePerformed As Boolean = False
    Public BaseFlexGrid As DataGridView = Nothing
    Public DevControl As GridControl = Nothing
    Public GridDev As GridView = Nothing
    Dim InputFieldsChanged As New Dictionary(Of Control, String)
    Protected GridInputStateChanged As Boolean = False
    Protected bb_SetDisplayChangeConfirmation As Boolean = True
    'Prev Next Variable
    Protected FrmParent As baseForm = Nothing
    Protected bi_GridParentRow As Integer = -1
    Protected fs_Code As String = ""
    Protected fbbt_ColCode As Byte = 0
    Protected fb_2PK As Boolean = False
    Protected fs_Code2 As String = ""
    Protected fs_Code3 As String = ""
    Protected sts_screen As Byte = 1
    Protected fbbt_ColCode2 As Byte = 1
    Protected columnIndex As Integer = 1
    ''' <summary>
    ''' Untuk Format Pecahan 4 Digit Belakang Koma di FlexGrid
    ''' Peletakan di Form Load dan Sebelum Load Grid
    ''' Ex : bia_FormatPecahan = New Integer() {1,5,10}
    ''' Untuk {1,5,10} = Index2 Kolom dalam Grid yang mau diganti formatnya
    ''' </summary>
    Protected bia_FormatPecahan() As Integer = Nothing
    Protected bia_FormatBulat() As Integer = Nothing
    Protected FilterData As FrmSystem_FilterData = Nothing
    Protected bs_Filter As String = ""
    Protected bbs_KonfirmasiDelete As String = "Are You sure to delete the data ?"
    Protected bs_MainFormName As String = ""
    Protected bb_IsUpdate As Boolean = False
    Protected bs_JenisForm As String = ""
    Protected AllowEditPrice As Boolean = False
    Protected AllowEditQty As Boolean = False

    Private Sub baseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConfigFormat(Me)
        Call AdditionalHandlers(Me)
    End Sub
    Private Sub ConfigFormat(ByVal container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf (ctrl) Is DataGridView Then
                BaseFlexGrid = ctrl
                AturGrid(BaseFlexGrid, Me)
                'With BaseFlexGrid
                '    .ReadOnly = False
                '    .BorderStyle = BorderStyle.Fixed3D
                '    .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
                '    .ColumnHeadersHeight = 40
                '    '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                '    '.BackColor = gcl_GridFixedBack
                '    '.ForeColor = gcl_GridFixedFore
                '    .Font = New System.Drawing.Font(gs_AppFontName, gsi_AppFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                '    .AllowUserToAddRows = False
                '    .BorderStyle = BorderStyle.FixedSingle
                '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'End With
            ElseIf TypeOf (ctrl) Is DateTimePicker Then
                Dim dt As DateTimePicker = ctrl
                If dt.Name.ToLower.Trim = "dtto" Then
                    dt.Value = Format(CDate(Format(Now.AddMonths(1), "yyyy-MM-01")).AddSeconds(-1), "yyyy-MM-dd")
                ElseIf dt.Name.ToLower.Trim = "dtfrom" Then
                    dt.Value = Format(Now, "yyyy-MM-01")
                Else
                    dt.Value = Now
                End If
            ElseIf ctrl.HasChildren Then
                Call ConfigFormat(ctrl)
            End If
        Next
    End Sub
    Private Sub AdditionalHandlers(ByVal container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf (ctrl) Is TextBox Then
                '# Add validation handler...
                AddHandler ctrl.Validated, AddressOf TextBoxValidate
                AddHandler ctrl.KeyDown, AddressOf TextboxKeyDown
                AddHandler ctrl.KeyPress, AddressOf TextboxKeyPress
                AddHandler ctrl.TextChanged, AddressOf TextBoxTextChanged
                '# Add focus handler...
            ElseIf TypeOf (ctrl) Is ComboBox Then
                '# Add validation handler...
                AddHandler ctrl.KeyDown, AddressOf TextboxKeyDown
                AddHandler ctrl.KeyPress, AddressOf TextboxKeyPress
            ElseIf TypeOf (ctrl) Is DataGridView Then
                BaseFlexGrid = ctrl
                Dim dt As DataTable = BaseFlexGrid.DataSource
                Dim dv As DataView = New DataView(dt)
                AddHandler dv.ListChanged, AddressOf dataGridFormat
                'AddHandler BaseFlexGrid.MouseClick, AddressOf GridRightClick
                AddHandler BaseFlexGrid.DoubleClick, AddressOf GridDoubleClick
                AddHandler BaseFlexGrid.GotFocus, AddressOf GridGotFocus
                AddHandler BaseFlexGrid.RowsAdded, AddressOf GridAfterAddRow
                AddHandler BaseFlexGrid.RowsRemoved, AddressOf GridAfterDeleteRow
            ElseIf TypeOf (ctrl) Is GridControl Then
                DevControl = ctrl
                Dim dt As DataTable = DevControl.DataSource
                Dim dv As DataView = New DataView(dt)
                'Dim dt As DataTable = New DataTable()
                AddHandler DevControl.Enter, AddressOf GridControlFocus
            ElseIf ctrl.HasChildren Then
                Call AdditionalHandlers(ctrl)

            End If
            If Not TypeOf (ctrl) Is DataGridView AndAlso Not TypeOf (ctrl) Is TabPage Then
                AddHandler ctrl.GotFocus, AddressOf ControlFocus
                AddHandler ctrl.LostFocus, AddressOf ControlFocus
                AddHandler ctrl.Click, AddressOf ControlClick
            End If
        Next
    End Sub
    Public Sub TextBoxValidate(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = sender
        If TypeOf (ctrl) Is TextBox Then
            Dim txt As TextBox = ctrl
            If txt.Text.Trim <> "" Then
                If txt.Tag IsNot Nothing Then
                    If txt.Tag.GetType Is GetType(String) Then
                        Select Case Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower
                            Case "number"
                                If NumValue(txt.Text) < 0 Then txt.Text = "0"
                                txt.Text = Format(NumValue(txt.Text), gs_FormatDecimal)
                            Case "numberbulat"
                                If NumValue(txt.Text) < 0 Then txt.Text = "0"
                                txt.Text = Format(NumValue(txt.Text), gs_FormatBulat)
                            Case "numberpecahan"
                                If NumValue(txt.Text) < 0 Then txt.Text = "0"
                                txt.Text = Format(NumValue(txt.Text), gs_FormatPecahan)
                            Case "numbermin"
                                txt.Text = Format(NumValue(txt.Text), gs_FormatDecimal)
                            Case "numberbulatmin"
                                txt.Text = Format(NumValue(txt.Text), gs_FormatBulat)
                            Case "numberpecahanmin"
                                txt.Text = Format(NumValue(txt.Text), gs_FormatPecahan)
                        End Select
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBoxTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = sender
        If TypeOf (ctrl) Is TextBox Then
            Dim txt As TextBox = ctrl
            If txt.Text.Trim <> "" Then
                If txt.Tag IsNot Nothing Then
                    If txt.Tag.GetType Is GetType(String) Then
                        Dim lb_Valid As Boolean = False
                        Select Case Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower
                            Case "number"
                                lb_Valid = True
                            Case "numberbulat"
                                lb_Valid = True
                            Case "numberpecahan"
                                lb_Valid = True
                            Case "numbermin"
                                lb_Valid = True
                            Case "numberbulatmin"
                                lb_Valid = True
                            Case "numberpecahanmin"
                                lb_Valid = True
                        End Select
                        If lb_Valid Then
                            Dim ld_Max As Double = 0
                            Select Case txt.MaxLength
                                Case SQL_MaxLHarga
                                    ld_Max = SQL_MaxVHarga
                                Case SQL_MaxLQty
                                    ld_Max = SQL_MaxVQty
                                Case SQL_MaxLPercent
                                    ld_Max = SQL_MaxVPercent
                                Case SQL_MaxLNomor
                                    ld_Max = SQL_MaxVNomor
                            End Select
                            If ld_Max > 0 Then
                                If NumValue(txt.Text) > ld_Max Then txt.Text = Format(ld_Max, gs_FormatDecimal)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TextboxKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If sender.GetType Is GetType(TextBox) Then
                'SendKeys.SendWait(vbTab)
                If CType(sender, TextBox).Multiline Then
                    'Nothing
                Else
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
            ElseIf sender.GetType Is GetType(ComboBox) Then
                Me.SelectNextControl(sender, True, True, True, True)
            End If
        ElseIf e.KeyCode = Keys.Back Then
            'If CType(sender, TextBox).Text.Trim = "" Then
            'Me.SelectNextControl(sender, False, True, True, True)
            'End If
        Else
            If Not (Me.Name.Contains("FrmInq") Or Me.Name.Contains("FrmRpt")) Then
                '# Ada perubahan yang dilakukan user...
                ChangePerformed = True
            End If
        End If
    End Sub

    Private Sub TextboxKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If sender.GetType Is GetType(TextBox) AndAlso CType(sender, TextBox).Multiline Then
            If e.KeyChar = "'" Then e.Handled = True
        Else
            If e.KeyChar = Chr(Keys.Enter) OrElse e.KeyChar = "'" Then e.Handled = True
        End If
    End Sub

    Public Sub dataGridFormat(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            Dim fgrid As DataGridView = sender
            With fgrid
                For i As Integer = 0 To .Columns.Count
                    If .Columns(i).ValueType Is GetType(DateTime) Then
                        If .Columns(i).DefaultCellStyle.Format <> "dd MMM yyyy" AndAlso .Columns(i).DefaultCellStyle.Format <> "dd MMMM yyyy" Then .Columns(i).DefaultCellStyle.Format = "dd MMM yyyy - HH:mm:ss"
                    ElseIf .Columns(i).ValueType Is GetType(Decimal) Then
                        Dim lb_Nothing As Boolean = True
                        .Columns(i).ValueType = GetType(String)
                        If bia_FormatPecahan IsNot Nothing AndAlso bia_FormatPecahan.Length > 0 Then
                            Array.Sort(bia_FormatPecahan)
                            Dim li_Found As Integer = Array.BinarySearch(bia_FormatPecahan, .Columns(i).Index)
                            If li_Found > -1 Then
                                .Columns(i).DefaultCellStyle.Format = gs_FormatPecahan
                                lb_Nothing = False
                            End If
                        End If
                        If lb_Nothing = True AndAlso bia_FormatBulat IsNot Nothing AndAlso bia_FormatBulat.Length > 0 Then
                            Array.Sort(bia_FormatBulat)
                            Dim li_Found As Integer = Array.BinarySearch(bia_FormatBulat, .Columns(i).Index)
                            If li_Found > -1 Then
                                .Columns(i).DefaultCellStyle.Format = gs_FormatBulat
                                lb_Nothing = False
                            End If
                        End If
                        If lb_Nothing = True Then
                            .Columns(i).DefaultCellStyle.Format = gs_FormatDecimal
                        End If
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If

                Next
                .Refresh()
                FrmMain.LblRecords.Caption = CStr(.Rows.Count) & " record(s)"

            End With
        End If
    End Sub
    Public Sub dataGridFormat1(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            Dim fgrid As GridView = sender
            With fgrid
                For i As Integer = 0 To .Columns.Count
                    If .Columns(i).DisplayFormat Is GetType(DateTime) Then
                        If .Columns(i).DisplayFormat.FormatString <> "dd MMM yyyy" AndAlso .Columns(i).DisplayFormat.FormatString <> "dd MMMM yyyy" Then .Columns(i).DisplayFormat.FormatString = "dd MMM yyyy - HH:mm:ss"
                    ElseIf .Columns(i).DisplayFormat Is GetType(Decimal) Then
                        Dim lb_Nothing As Boolean = True
                        .Columns(i).DisplayFormat.Format = GetType(String)
                        If bia_FormatPecahan IsNot Nothing AndAlso bia_FormatPecahan.Length > 0 Then
                            Array.Sort(bia_FormatPecahan)
                            Dim li_Found As Integer = Array.BinarySearch(bia_FormatPecahan, .Columns(i).ColumnHandle)
                            If li_Found > -1 Then
                                .Columns(i).DisplayFormat.FormatString = gs_FormatPecahan
                                lb_Nothing = False
                            End If
                        End If
                        If lb_Nothing = True AndAlso bia_FormatBulat IsNot Nothing AndAlso bia_FormatBulat.Length > 0 Then
                            Array.Sort(bia_FormatBulat)
                            Dim li_Found As Integer = Array.BinarySearch(bia_FormatBulat, .Columns(i).ColumnHandle)
                            If li_Found > -1 Then
                                .Columns(i).DisplayFormat.FormatString = gs_FormatBulat
                                lb_Nothing = False
                            End If
                        End If
                        If lb_Nothing = True Then
                            .Columns(i).DisplayFormat.FormatString = gs_FormatDecimal
                        End If
                        .Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    End If

                Next
                .RefreshData()
                FrmMain.LblRecords.Caption = CStr(.RowCount) & " record(s)"

            End With
        End If
    End Sub

    Public Overridable Sub GridDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub InputBeginState(ByVal container As Control)
        For Each ctrl As Control In container.Controls
            '# Initialize...
            If TypeOf ctrl Is DateTimePicker OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is CheckBox Then
                If InputFieldsChanged.ContainsKey(ctrl) Then
                    InputFieldsChanged.Remove(ctrl)
                End If
                If TypeOf ctrl Is DateTimePicker Then
                    Dim ctrldate As DateTimePicker
                    ctrldate = ctrl
                    InputFieldsChanged.Add(ctrl, ctrldate.Value)
                ElseIf TypeOf ctrl Is CheckBox Then
                    Dim ctlrChek As CheckBox
                    ctlrChek = ctrl
                    InputFieldsChanged.Add(ctrl, ctlrChek.CheckState)
                Else
                    InputFieldsChanged.Add(ctrl, ctrl.Text)
                End If
            ElseIf ctrl.HasChildren Then
                Call InputBeginState(ctrl)
            End If
        Next
    End Sub
    Private Sub GridControlFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        FrmMain.LblRecords.Caption = CStr(view.RowCount) & " record(s)"
    End Sub
    Private Sub GridGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        FrmMain.LblRecords.Caption = CStr(sender.Rows.Count) & " record(s)"
    End Sub
    Private Sub GridAfterAddRow(ByVal sender As Object, ByVal e As System.EventArgs)
        FrmMain.LblRecords.Caption = CStr(sender.Rows.Count) & " record(s)"
    End Sub
    Private Sub GridAfterDeleteRow(ByVal sender As Object, ByVal e As System.EventArgs)
        FrmMain.LblRecords.Caption = CStr(sender.Rows.Count) & " record(s)"
    End Sub

    Public Sub ControlFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = sender
        If gs_ControlFocusName <> ctrl.Name Then
            gs_ControlFocusName = ctrl.Name
            gi_ControlFocusCounter = 0
        End If
        If ctrl.Focused Then
            '# Special Case...
            If TypeOf (ctrl) Is TextBox Then
                Dim txt As TextBox = ctrl
                If Not txt.ReadOnly Then
                    ctrl.BackColor = Color.LightBlue
                    If txt.Tag IsNot Nothing AndAlso txt.Tag.GetType Is GetType(String) Then
                        If Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "number" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberbulat" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberpecahan" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numbermin" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberbulatmin" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberpecahanmin" Then
                            txt.Text = NumValue(txt.Text)
                        End If
                    End If
                Else
                    txt.BackColor = System.Drawing.SystemColors.Control
                End If
                txt.SelectAll()
            ElseIf TypeOf (ctrl) Is CheckBox OrElse TypeOf (ctrl) Is RadioButton OrElse TypeOf (ctrl) Is Panel Then
                '# Do nothing...
            Else
                ctrl.BackColor = Color.LightBlue
            End If
        Else
            If TypeOf (ctrl) Is TextBox Then
                Dim txt As TextBox = ctrl
                If txt.ReadOnly = False Then
                    txt.BackColor = Color.White
                Else
                    txt.BackColor = System.Drawing.SystemColors.Control
                    txt.SelectAll()
                End If
            ElseIf TypeOf (ctrl) Is CheckBox OrElse TypeOf (ctrl) Is RadioButton OrElse TypeOf (ctrl) Is Panel Then
                '# Do nothing...
            ElseIf TypeOf (ctrl) Is Button Then
                Dim lbt As Button = ctrl
                lbt.BackColor = System.Drawing.SystemColors.Control
                lbt.UseVisualStyleBackColor = True
            Else
                ctrl.BackColor = Color.White
            End If
        End If
        gb_ControlFocus = True
    End Sub
    Public Sub ControlClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = sender
        If gs_ControlClickFocusName <> ctrl.Name Then
            If gs_ControlClickFocusName <> gs_ControlFocusName Then 'AndAlso ctrl.Name <> gs_ControlFocusName Then
                gi_ControlFocusCounter += 1
            Else
                gi_ControlFocusCounter = 2
            End If
            gs_ControlClickFocusName = ctrl.Name
        Else
            gi_ControlFocusCounter += 1
        End If
        If ctrl.Focused Then
            '# Special Case...
            If TypeOf (ctrl) Is TextBox Then
                Dim txt As TextBox = ctrl
                If Not txt.ReadOnly Then
                    ctrl.BackColor = Color.LightBlue
                    If txt.Tag IsNot Nothing AndAlso txt.Tag.GetType Is GetType(String) Then
                        If Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "number" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberbulat" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberpecahan" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numbermin" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberbulatmin" _
                            OrElse Split(Trim(txt.Tag & ""), ";")(TagEnum.DataType).ToLower = "numberpecahanmin" Then
                            txt.Text = NumValue(txt.Text)
                        End If
                    End If
                    If gb_ControlFocus = True AndAlso gi_ControlFocusCounter <= 1 Then txt.SelectAll()
                Else
                    txt.BackColor = System.Drawing.SystemColors.Control
                End If
            ElseIf TypeOf (ctrl) Is CheckBox OrElse TypeOf (ctrl) Is RadioButton OrElse TypeOf (ctrl) Is Panel Then
                '# Do nothing...
            Else
                ctrl.BackColor = Color.LightBlue
            End If
        Else
            If TypeOf (ctrl) Is TextBox Then
                Dim txt As TextBox = ctrl
                If txt.ReadOnly = False Then
                    txt.BackColor = Color.White
                Else
                    txt.BackColor = System.Drawing.SystemColors.Control
                    If gb_ControlFocus = True AndAlso gi_ControlFocusCounter <= 1 Then txt.SelectAll()
                End If
            ElseIf TypeOf (ctrl) Is CheckBox OrElse TypeOf (ctrl) Is RadioButton OrElse TypeOf (ctrl) Is Panel OrElse TypeOf (ctrl) Is GroupBox OrElse TypeOf (ctrl) Is Label Then
                '# Do nothing...
            ElseIf TypeOf (ctrl) Is Button Then
                Dim lbt As Button = ctrl
                lbt.BackColor = System.Drawing.SystemColors.Control
                lbt.UseVisualStyleBackColor = True
            Else
                ctrl.BackColor = Color.White
            End If
        End If
        gb_ControlFocus = True
        'gi_ControlFocusCounter += 1
    End Sub
    Public Sub Proc_PrevItem()
        If FrmParent IsNot Nothing AndAlso FrmParent.Visible = True Then
            If FrmParent.BaseFlexGrid IsNot Nothing Then
                If FrmParent.BaseFlexGrid.Rows.Count > 0 Then
                    Call Proc_CheckChange()
                    If ChangePerformed Then
                        ShowMessage("", MessageTypeEnum.NotBoxMessage)
                        If MsgBox("Data has not been saved. Do you want to open previous data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                    If bi_GridParentRow = -1 Then
                        bi_GridParentRow = 2
                    Else
                        If bi_GridParentRow <= 2 Then
                            bi_GridParentRow = FrmParent.BaseFlexGrid.Rows.Count - 1
                        Else
                            bi_GridParentRow -= 1
                        End If
                    End If
                    fs_Code = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode).Value.ToString.Trim

                    If fb_2PK Then
                        fs_Code2 = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode2).Value.ToString.Trim
                        'fs_Code3 = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode2).Value.ToString.Trim
                    End If
                    Call InitialSetForm()
                    Call bf_ValidateHakAkses()
                End If
            End If
            If FrmParent.DevControl IsNot Nothing Then
                If FrmParent.DevControl.FocusedView.RowCount > 0 Then
                    'Call Proc_CheckChange()
                    'If ChangePerformed Then
                    '    ShowMessage("", MessageTypeEnum.NotBoxMessage)
                    '    If MsgBox("The data you changed has not been saved. Do you want to move to next data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    '        Exit Sub
                    '    End If
                    'End If
                    If bi_GridParentRow = -1 Then
                        bi_GridParentRow = 2
                    Else
                        If bi_GridParentRow <= 2 Then
                            bi_GridParentRow = FrmParent.DevControl.FocusedView.RowCount - 1
                        Else
                            bi_GridParentRow -= 1
                        End If
                    End If
                    Dim gridView = TryCast(FrmParent.DevControl.FocusedView, GridView)
                    'fs_Code = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode).Value.ToString.Trim
                    fs_Code = gridView.GetRowCellValue(bi_GridParentRow, gridView.Columns(0))
                    fs_Code2 = gridView.GetRowCellValue(bi_GridParentRow, gridView.Columns(columnIndex))
                    'If fb_2PK Then
                    '    fs_Code2 = gridView.GetRowCellValue(bi_GridParentRow, gridView.Columns(1))
                    'End If
                    Call InitialSetForm()
                    Call bf_ValidateHakAkses()
                End If
            End If
        End If
    End Sub
    Protected Sub bf_ValidateHakAkses()
        Try
            AllowEditPrice = False
            AllowEditQty = False
            Dim query As String = ""
            Dim ls_Error As String = ""
            Dim ls_NamaMenu As String = ""
            Dim ls_KeteranganMenu As String = ""
            Dim ls_NamaForm As String = IIf(bs_MainFormName.Trim = "", Me.Name.Trim, bs_MainFormName.Trim)

            query =
                "SELECT Top 1 ParentMenu, Title, MenuDescription FROM S_UserMenu tm " & vbCrLf &
                "WHERE MenuCode = " & QVal(ls_NamaForm) & vbCrLf &
                ""
            Dim dtable As DataTable = MainModul.GetDataTable(query)
            If dtable.Rows.Count > 0 Then
                bs_JenisForm = dtable.Rows(0)("ParentMenu").ToString.Trim.ToUpper
                ls_NamaMenu = dtable.Rows(0)("Title").ToString.Trim.ToUpper
                ls_KeteranganMenu = dtable.Rows(0)("MenuDescription").ToString.Trim.ToUpper
            End If
            'Me.BtnJudul.Text = Me.Text
            If bs_MainFormName.Trim = "" Then
                If bs_JenisForm <> "" Then Me.Text = bs_JenisForm & ""
                If ls_NamaMenu <> "" Then
                    If bs_JenisForm <> "" Then
                        Me.Text = Me.Text & "->" & ls_NamaMenu
                        'Me.Text = ls_NamaMenu
                    Else
                        Me.Text = ls_NamaMenu
                    End If
                End If
                'If ls_KeteranganMenu <> "" Then
                '    Me.BtnJudul.Text = ls_KeteranganMenu
                'ElseIf ls_NamaMenu <> "" Then
                '    Me.BtnJudul.Text = ls_NamaMenu
                'ElseIf Me.Tag <> "" Then
                '    Me.BtnJudul.Text = Me.Tag
                'Else
                '    Me.BtnJudul.Text = Me.Text
                'End If
            End If
            If bs_JenisForm <> "Setting" _
               AndAlso bs_JenisForm <> "Report" _
               AndAlso bs_JenisForm <> "" Then
                query =
                "SELECT HakAkses =Coalesce([Access], '0'), HakInsert = Coalesce([Insert], '0'), HakUpdate = Coalesce([Update], '0'), HakDelete = Coalesce([Delete], '0'), Special = Coalesce([Special], '0'), Price = Coalesce([Price], '0'), Qty = Coalesce([Qty], '0') FROM S_UserPermission " & vbLf &
                "WHERE Username = " & QVal(gh_Common.Username) & vbLf &
                "   AND MenuCode = " & QVal(ls_NamaForm) & vbLf &
                ""
                dtable = MainModul.GetDataTable(query)
                If dtable.Rows.Count = 0 Then
                    'frmMain.btnNew.ToolTipText = IIf(frmMain.btnNew.Enabled, "Access permission required!", "")
                    tsBtn_newData.ToolTipText = IIf(tsBtn_newData.Enabled, "Access permission required!", "")
                    If bb_IsUpdate Then
                        'frmMain.btnSave.ToolTipText = IIf(frmMain.btnSave.Enabled, "Update permission required!", "")
                        tsBtn_save.ToolTipText = IIf(tsBtn_save.Enabled, "Update permission required!", "")
                    Else
                        tsBtn_save.ToolTipText = IIf(tsBtn_save.Enabled, "Insert permission required!", "")
                        'frmMain.btnSave.ToolTipText = IIf(frmMain.btnSave.Enabled, "Insert permission required!", "")
                    End If
                    tsBtn_delete.ToolTipText = IIf(tsBtn_delete.Enabled, "Delete permission required!", "")
                    tsBtn_approve.ToolTipText = IIf(tsBtn_approve.Enabled, "Approve permission required!", "")
                    tsBtn_newData.Enabled = False
                    tsBtn_save.Enabled = False
                    AllowEditPrice = False
                    AllowEditQty = False
                    'TSBtn_Delete.Enabled = False
                Else
                    If dtable.Rows(0)(0) = True Then
                        'Dim lb_HakInsert As Boolean = CBool(dtable.Rows(0)(0))
                        'Dim lb_HakUpdate As Boolean = CBool(dtable.Rows(0)(1))
                        'Dim lb_HakDelete As Boolean = CBool(dtable.Rows(0)(2))

                        Dim lb_HakInsert As Boolean = dtable.Rows(0)(1)
                        Dim lb_HakUpdate As Boolean = dtable.Rows(0)(2)
                        Dim lb_HakDelete As Boolean = dtable.Rows(0)(3)
                        Dim lb_HakSpecial As Boolean = dtable.Rows(0)(4)
                        Dim EditPrice As Boolean = dtable.Rows(0)(5)
                        Dim EditQty As Boolean = dtable.Rows(0)(6)
                        'frmMain.btnNew.ToolTipText = IIf(frmMain.btnNew.Enabled AndAlso lb_HakInsert = False, "Insert permission required!", "")
                        tsBtn_newData.ToolTipText = IIf(tsBtn_newData.Enabled AndAlso lb_HakInsert = False, "Insert permission required!", "")

                        If bb_IsUpdate Then
                            'frmMain.btnSave.ToolTipText = IIf(frmMain.btnSave.Enabled AndAlso lb_HakUpdate = False, "Update permission required!", "")
                            tsBtn_save.ToolTipText = IIf(tsBtn_save.Enabled AndAlso lb_HakUpdate = False, "Update permission required!", "")
                        Else
                            'frmMain.btnSave.ToolTipText = IIf(frmMain.btnSave.Enabled AndAlso lb_HakInsert = False, "Insert permission required!", "")
                            tsBtn_save.ToolTipText = IIf(tsBtn_save.Enabled AndAlso lb_HakInsert = False, "Insert permission required!", "")
                        End If
                        tsBtn_delete.ToolTipText = IIf(tsBtn_delete.Enabled AndAlso lb_HakDelete = False, "Delete permission required!", "")
                        tsBtn_approve.ToolTipText = IIf(tsBtn_approve.Enabled AndAlso lb_HakSpecial = False, "Approve permission required!", "")

                        'frmMain.btnNew.Enabled = IIf(frmMain.btnNew.Enabled, lb_HakInsert, frmMain.btnNew.Enabled)
                        tsBtn_newData.Enabled = IIf(tsBtn_newData.Enabled, lb_HakInsert, tsBtn_newData.Enabled)
                        If bb_IsUpdate Then
                            'frmMain.btnSave.Enabled = IIf(frmMain.btnSave.Enabled, lb_HakUpdate, frmMain.btnSave.Enabled)
                            tsBtn_save.Enabled = IIf(tsBtn_save.Enabled, lb_HakUpdate, tsBtn_save.Enabled)
                        Else
                            'frmMain.btnSave.Enabled = IIf(frmMain.btnSave.Enabled, lb_HakInsert, frmMain.btnSave.Enabled)
                            tsBtn_save.Enabled = IIf(tsBtn_save.Enabled, lb_HakInsert, tsBtn_save.Enabled)
                        End If
                        tsBtn_delete.Enabled = IIf(tsBtn_delete.Enabled, lb_HakDelete, tsBtn_delete.Enabled)
                        tsBtn_approve.Enabled = IIf(tsBtn_approve.Enabled, lb_HakSpecial, tsBtn_approve.Enabled)
                        AllowEditPrice = EditPrice
                        AllowEditQty = EditQty
                    Else
                        'frmMain.btnNew.ToolTipText = IIf(frmMain.btnNew.Enabled, "Insert permission required!", "")
                        tsBtn_newData.ToolTipText = IIf(tsBtn_newData.Enabled, "Insert permission required!", "")
                        If bb_IsUpdate Then
                            'frmMain.btnSave.ToolTipText = IIf(frmMain.btnSave.Enabled, "Update permission required!", "")
                            tsBtn_save.ToolTipText = IIf(tsBtn_save.Enabled, "Update permission required!", "")
                        Else
                            'frmMain.btnSave.ToolTipText = IIf(frmMain.btnSave.Enabled, "Insert permission required!", "")
                            tsBtn_save.ToolTipText = IIf(tsBtn_save.Enabled, "Insert permission required!", "")
                        End If
                        tsBtn_delete.ToolTipText = IIf(tsBtn_delete.Enabled, "Delete permission required!", "")
                        tsBtn_approve.ToolTipText = IIf(tsBtn_approve.Enabled, "Approve permission required!", "")
                        'frmMain.btnNew.Enabled = False
                        tsBtn_newData.Enabled = False
                        'frmMain.btnSave.Enabled = False
                        tsBtn_save.Enabled = False
                        tsBtn_delete.Enabled = False
                        tsBtn_approve.Enabled = False
                        AllowEditPrice = False
                        AllowEditQty = False
                    End If
                End If
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Public Sub Proc_NextItem()
        If FrmParent IsNot Nothing AndAlso FrmParent.Visible = True Then
            If FrmParent.BaseFlexGrid IsNot Nothing Then
                If FrmParent.BaseFlexGrid.Rows.Count > 0 Then
                    Call Proc_CheckChange()
                    If ChangePerformed Then
                        ShowMessage("", MessageTypeEnum.NotBoxMessage)
                        If MsgBox("The data you changed has not been saved. Do you want to move to next data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                    If bi_GridParentRow = -1 Then
                        bi_GridParentRow = 0
                    Else
                        If bi_GridParentRow >= FrmParent.BaseFlexGrid.Rows.Count - 1 Then
                            bi_GridParentRow = 0
                        Else
                            bi_GridParentRow += 1
                        End If
                    End If
                    fs_Code = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode).Value.ToString.Trim

                    If fb_2PK Then
                        fs_Code2 = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode2).Value.ToString.Trim
                    End If
                    Call InitialSetForm()
                    Call bf_ValidateHakAkses()
                End If
            End If

            If FrmParent.DevControl IsNot Nothing Then
                If FrmParent.DevControl.FocusedView.RowCount > 0 Then
                    'Call Proc_CheckChange()
                    'If ChangePerformed Then
                    '    ShowMessage("", MessageTypeEnum.NotBoxMessage)
                    '    If MsgBox("The data you changed has not been saved. Do you want to move to next data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    '        Exit Sub
                    '    End If
                    'End If
                    If bi_GridParentRow = -1 Then
                        bi_GridParentRow = 0
                    Else
                        If bi_GridParentRow >= FrmParent.DevControl.FocusedView.RowCount - 1 Then
                            bi_GridParentRow = 0
                        Else
                            bi_GridParentRow += 1
                        End If
                    End If
                    Dim gridView = TryCast(FrmParent.DevControl.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
                    'fs_Code = FrmParent.BaseFlexGrid.Rows(bi_GridParentRow).Cells(fbbt_ColCode).Value.ToString.Trim
                    fs_Code = gridView.GetRowCellValue(bi_GridParentRow, gridView.Columns(0))
                    fs_Code2 = gridView.GetRowCellValue(bi_GridParentRow, gridView.Columns(columnIndex))
                    'If fb_2PK Then
                    '    fs_Code2 = gridView.GetRowCellValue(bi_GridParentRow, gridView.Columns(1))
                    'End If
                    Call InitialSetForm()
                    Call bf_ValidateHakAkses()
                End If
            End If
        End If
    End Sub

    Public Overridable Sub InitialSetForm()

    End Sub
    Private Sub Proc_CheckChange()
        Dim enumerator As System.Collections.Generic.Dictionary(Of Control, String).Enumerator = InputFieldsChanged.GetEnumerator

        ChangePerformed = False
        If bb_SetDisplayChangeConfirmation = True Then
            If GridInputStateChanged = True Then
                ChangePerformed = True
            Else
                Do While enumerator.MoveNext
                    If TypeOf enumerator.Current.Key Is DateTimePicker Then
                        Dim ctrlnow As DateTimePicker
                        ctrlnow = enumerator.Current.Key
                        If CDate(ctrlnow.Value.ToString.Trim) <> CDate(enumerator.Current.Value.Trim) Then
                            ChangePerformed = True
                            Exit Do
                        End If
                    ElseIf TypeOf enumerator.Current.Key Is ComboBox Then
                        Dim ctrlCombo As ComboBox
                        ctrlCombo = enumerator.Current.Key
                        If ctrlCombo.Text.ToString.Trim <> enumerator.Current.Value.Trim Then
                            ChangePerformed = True
                            Exit Do
                        End If
                    ElseIf TypeOf enumerator.Current.Key Is CheckBox Then
                        Dim ctrlChek As CheckBox
                        ctrlChek = enumerator.Current.Key
                        If ctrlChek.CheckState <> enumerator.Current.Value.Trim Then
                            ChangePerformed = True
                            Exit Do
                        End If
                    Else
                        If enumerator.Current.Key.Text.Trim <> enumerator.Current.Value.Trim Then
                            ChangePerformed = True
                            Exit Do
                        End If
                    End If
                Loop
            End If
        End If
    End Sub

    Public Sub Proc_EnableButtons(
        Optional ByVal NewData As Boolean = True _
        , Optional ByVal Save As Boolean = True _
        , Optional ByVal Delete As Boolean = True _
        , Optional ByVal Refresh As Boolean = True _
        , Optional ByVal Excel As Boolean = True _
        , Optional ByVal Filter As Boolean = True _
        , Optional ByVal Preview As Boolean = True _
        , Optional ByVal Print As Boolean = True _
        , Optional ByVal BtnPrev As Boolean = False _
        , Optional ByVal BtnNext As Boolean = False _
        , Optional ByVal BtnAprove As Boolean = False
    )
        'frmMain.btnNew.Enabled = NewData
        'frmMain.btnSave.Enabled = Save
        'frmMain.TSBtn_Delete.Enabled = Delete
        'frmMain.TSBtn_Refresh.Enabled = Refresh
        'frmMain.TSBtn_Excel.Enabled = Excel
        'frmMain.btnf.Enabled = Filter
        'frmMain.btnPreview.Enabled = Preview
        'frmMain.btnPrint.Enabled = Print
        'frmMain.TSBtn_Prev.Enabled = BtnPrev
        'frmMain.TSBtn_Next.Enabled = BtnNext

        tsBtn_newData.Enabled = NewData
        tsBtn_save.Enabled = Save
        tsBtn_delete.Enabled = Delete
        tsBtn_refresh.Enabled = Refresh
        tsBtn_excel.Enabled = Excel
        tsBtn_filter.Enabled = Filter
        tsBtn_preview.Enabled = Preview
        tsBtn_print.Enabled = Print
        tsBtn_prev.Enabled = BtnPrev
        tsBtn_next.Enabled = BtnNext
        tsBtn_approve.Enabled = BtnAprove
    End Sub

    ''' <summary>
    ''' Prosedur untuk menyimpan data
    ''' </summary>
    ''' <remarks>
    ''' [2009.04.04] : Create by JOSH
    ''' </remarks>
    Public Overridable Sub Proc_SaveData(ByRef lb_Berhasil As Boolean)
    End Sub
    Public Overridable Sub Proc_SaveData()
    End Sub

    ''' <summary>
    ''' Prosedur untuk approve data
    ''' </summary>
    ''' <remarks>
    ''' [22018.12.27] : Create by Haris
    ''' </remarks>
    Public Overridable Sub Proc_Approve()
    End Sub
    ''' <summary>
    ''' Prosedur untuk menghapus data
    ''' </summary>
    ''' <remarks>
    ''' [2009.04.04] : Create by JOSH
    ''' </remarks>
    Public Overridable Sub Proc_DeleteData()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan input data baru
    ''' </summary>
    ''' <remarks>
    ''' [2009.04.21] Create by JOSH
    ''' </remarks>
    Public Overridable Sub Proc_InputNewData()
        Call Proc_CheckChange()
        If ChangePerformed Then
            ShowMessage("", MessageTypeEnum.NotBoxMessage)
            If MsgBox("The data you changed has not been saved. Do you want to input new data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Call Proc_InputNewData_Child()
        Call ResetInputState()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan input data baru ( form child )
    ''' </summary>
    ''' <remarks>
    ''' [2009.09.10] Create by JOSH
    ''' </remarks>
    Public Overridable Sub Proc_InputNewData_Child()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan edit data
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_EditData()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan Export data ke Excel...
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_ExportExcel()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan Printing...
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_Print()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan Preview Printing...
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_PrintPreview()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan filter
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_Filter()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan refresh
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_Refresh()
    End Sub
    ''' <summary>
    ''' Prosedur untuk melakukan proses export ke excel
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Proc_Excel()
    End Sub
    ''' <summary>
    ''' Fungsi validasi untuk menyimpan data
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' [2009.04.04] : Create by JOSH
    ''' </remarks>
    Public Overridable Function ValidateSave() As Boolean
        Return True
    End Function
    ''' <summary>
    ''' Fungsi validasi untuk menghapus data
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function ValidateDelete() As Boolean
        Return True
    End Function
    ''' <summary>
    ''' Reset input state to beginning...
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetInputState()
        InputFieldsChanged.Clear()
        Call InputBeginState(Me)
    End Sub

    Private Sub tsBtn_newData_Click(sender As Object, e As EventArgs) Handles _
        tsBtn_save.Click, tsBtn_delete.Click, tsBtn_newData.Click,
        tsBtn_print.Click, tsBtn_preview.Click, tsBtn_filter.Click, tsBtn_refresh.Click,
        tsBtn_excel.Click, tsBtn_prev.Click, tsBtn_next.Click, tsBtn_approve.Click

        Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        Dim TSBtn As ToolStripButton = sender
        Select Case TSBtn.Name
            Case tsBtn_save.Name
                If ValidateSave() Then
                    Dim lb_Berhasil As Boolean = True
                    Call Proc_SaveData(lb_Berhasil)
                    If lb_Berhasil = True Then
                        Call Proc_SaveData()
                        ChangePerformed = False
                        ResetInputState()
                    End If
                End If
            Case tsBtn_delete.Name
                If MsgBox(bbs_KonfirmasiDelete, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    If ValidateDelete() Then
                        Call Proc_DeleteData()
                    End If
                End If
            Case tsBtn_newData.Name
                'TSBtn_Delete.Enabled = False
                '# Reset input state...                
                Call Proc_InputNewData()
                ChangePerformed = False
            Case tsBtn_print.Name
                Call Proc_Print()
            Case tsBtn_preview.Name
                Call Proc_PrintPreview()
            Case tsBtn_filter.Name
                Call Proc_Filter()
            Case tsBtn_refresh.Name
                Call ShowMessage("", MessageTypeEnum.NotBoxMessage)
                Call Proc_Refresh()
            Case tsBtn_excel.Name
                Call Proc_Excel()
            Case tsBtn_prev.Name
                Call Proc_PrevItem()
            Case tsBtn_next.Name
                Call Proc_NextItem()
            Case tsBtn_approve.Name
                Call Proc_Approve()
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub baseForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not Me.DesignMode Then
            '===================================================================================
            '# VALIDASI HAK AKSES...
            '===================================================================================
            Call bf_ValidateHakAkses()
            '# Untuk form laporan, disable button yang tidak diperlukan...
            If bs_JenisForm = "Laporan" Then
                tsBtn_delete.Enabled = False
                tsBtn_excel.Enabled = True
                tsBtn_newData.Enabled = False
                tsBtn_filter.Enabled = False
                tsBtn_preview.Enabled = False
                tsBtn_print.Enabled = False
                tsBtn_save.Enabled = False
                tsBtn_approve.Enabled = False
            Else
                '# Iterate to set inital state of input controls...
                Call InputBeginState(Me)
            End If
        End If
    End Sub

    Private Sub baseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            '# Check for input changes...
            Call Proc_CheckChange()
            If ChangePerformed Then
                If Me.Name = "frmReport_Sales_Budget" OrElse Me.Name = "frmReport_BoM" _
                       OrElse Me.Name = "frmReport_Sales_Forecast" OrElse Me.Name = "frmReport_Sales_Order" OrElse Me.Name = "frmReport_Sales_Price" Then
                Else
                    If MsgBox("The data you changed has not been saved, close this form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then e.Cancel = True
                    ShowMessage("", MessageTypeEnum.NotBoxMessage)
                End If
            End If
        End If
    End Sub

End Class
