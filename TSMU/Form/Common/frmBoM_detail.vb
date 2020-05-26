Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Public Class frmBoM_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsBoM
    Dim fc_ClassBoM As New clsBoMTrans
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim ff_detail As frmBoM_detail_input
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim dtGrid1 As New DataTable
    Dim intRevisi As Integer
    Dim NoReg As String = String.Empty
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Private Sub frmBoM_detai_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If GridDetail.SelectedRows.Count > 0 Then
                If e.KeyCode = Keys.F3 Then
                    'Dim objGrid As DataGridView = sender
                    CallFrmLookUp(GridDetail.SelectedRows(0).Cells(0).Value.ToString)
                    'Dim f As frmBoMLookUpLevel = New frmBoMLookUpLevel()
                    'f.StartPosition = FormStartPosition.CenterScreen
                    'f.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub frmBoM_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                intRevisi = fc_Class.getRevisi(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "MASTER->BOM->" & fs_Code
            Else
                Me.Text = "MASTER->BOM->NEW"
            End If
            Call LoadGridDetil()
            Call LoadGridDetil1()

            If gh_Common.Group = "NPD TANGERANG" OrElse gh_Common.Group = "NPD CIKARANG" Then
                FillComboProjectNPD()
            ElseIf gh_Common.Group = "Administrator" Then
                FillComboAdmin()
            Else
                FillComboProjectNotNPD()
            End If
            Call fillComboSite()
            fillComboWC()
            FillComboRefType()
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub FillComboProjectNPD()
        Dim status() As String = {"", "PROJECT"}
        _cmbStatus.Properties.Items.Clear()
        For Each var As String In status
            _cmbStatus.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub FillComboAdmin()
        Dim status() As String = {"", "PROJECT", "REGULAR"}
        _cmbStatus.Properties.Items.Clear()
        For Each var As String In status
            _cmbStatus.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboProjectNotNPD()
        Dim status() As String = {"", "REGULAR"}
        _cmbStatus.Properties.Items.Clear()
        For Each var As String In status
            _cmbStatus.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub FillComboRefType()
        Dim Tipe() As String = {"", "ECI", "PPAP", "PECR"}
        _TxtRefType.Properties.Items.Clear()
        For Each var As String In Tipe
            _TxtRefType.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtBoMID.Text = .BoMID
                    _txtDate.Text = Format(.Tgl, "dd-MM-yyyy")
                    _txtInvID.Text = .InvtID
                    _txtDesc.Text = .Desc
                    _cmbSite.EditValue = .SiteID

                    _txtRunner.Text = .Runner
                    _txtCycle.Text = .CycleTime
                    _cmbMesin.EditValue = .MC
                    _TxtCavity.Text = .cavity
                    _CmbWC.EditValue = .WC
                    _txtAllowance.Text = .Allowance.ToString
                    _txtMan.Text = .MP
                    _cmbStatus.Text = .Status
                    If .Active = 1 Then
                        _cmbAktif.EditValue = "Inhouse"
                    ElseIf .Active = 0 Then
                        _cmbAktif.EditValue = "Subcon"
                    Else
                        _cmbAktif.EditValue = "Discontinue"
                    End If
                    _cmbStatus.Focus()
                    _TxtRefType.EditValue = .RefType
                    _TxtRefNo.Text = .RefNo
                    _TxtRefType.Properties.ReadOnly = False
                    _TxtRefNo.Properties.ReadOnly = False

                End With
                If _cmbStatus.Text <> "REGULAR" Then
                    ChekRegular.Enabled = True
                Else
                    ChekRegular.Enabled = False
                End If

            Else
                _TxtRefType.Properties.ReadOnly = True
                _TxtRefNo.Properties.ReadOnly = True
                'If _cmbStatus.EditValue = "Regular" Then
                '    KodeOtomatis()
                'Else
                '    _txtBoMID.Text = fc_Class.ProjectAutoNo()
                'End If
                _TxtRefType.EditValue = ""
                _TxtRefNo.Text = ""
                _txtBoMID.Text = ""
                _txtDate.Text = Format(Date.Now, "dd-MM-yyyy")
                _txtInvID.Text = ""
                '_cmbSite.Text = ""
                _txtRunner.Text = "0"
                _txtCycle.Text = "0"
                '_cmbMesin.Text = ""
                _txtMan.Text = "0"
                _txtAllowance.Text = "0"
                _txtDesc.Text = ""
                _cmbAktif.SelectedIndex = 0
                _cmbStatus.Focus()
                ChekRegular.Enabled = False
            End If
            If gh_Common.Group <> "NPD" OrElse gh_Common.Group <> "COSTING" OrElse gh_Common.Group <> "Administrator" Then
                _cmbAktif.Properties.ReadOnly = False
            Else
                _cmbAktif.Properties.ReadOnly = True
            End If
            'Grid3.Visible = False
            GroupBox2.Text = "Level 3"
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetil()
    End Sub

    Public Sub LoadGridDetil()
        Try
            dtGrid = fc_Class.getDetailBoM(fs_Code)
            GridDetail.DataSource = dtGrid
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub LoadGridDetil1()
        Try
            Dim dtGrid1 As New DataTable
            dtGrid1.Columns.AddRange(New DataColumn(3) {New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Qty", GetType(String)),
                                                            New DataColumn("Unit", GetType(String))})
            If GridDetail.Rows.Count > 0 Then
                Dim strInvtId As String
                strInvtId = GridDetail.SelectedRows(0).Cells(0).Value.ToString
                'Dim dt As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(strInvtId)
                'Grid1.DataSource = dt
                Dim dt As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(InvtId)
                dt = fc_Class.getRoutingBoM(strInvtId)
                Dim str As String = String.Empty

                For rw = 0 To dt.Rows.Count - 1
                    Dim parent As String = dt.Rows(rw)("parentid").ToString
                    If parent <> "" Then
                        If parent = strInvtId Then
                            str = "level 1 - " & dt.Rows(rw)("invtid").ToString
                            dtGrid1.Rows.Add()
                            dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(0) = dt.Rows(rw)("invtid")
                            dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(1) = dt.Rows(rw)("descr")
                            dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(2) = dt.Rows(rw)("qty")
                            dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(3) = dt.Rows(rw)("unit")
                        End If
                    End If
                Next
            End If

            Grid1.DataSource = dtGrid1

            Dim dtGrid2 As New DataTable
            dtGrid2.Columns.AddRange(New DataColumn(3) {New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Qty", GetType(String)),
                                                            New DataColumn("Unit", GetType(String))})
            If Grid1.Rows.Count > 0 Then
                Dim strInvtId2 As String
                strInvtId2 = Grid1.SelectedRows(0).Cells(0).Value.ToString
                'Dim dt As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(strInvtId)
                'Grid1.DataSource = dt
                Dim dt2 As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(InvtId)
                dt2 = fc_Class.getRoutingBoM(strInvtId2)
                Dim str2 As String = String.Empty

                For rw = 0 To dt2.Rows.Count - 1
                    Dim parent As String = dt2.Rows(rw)("parentid").ToString
                    If parent <> "" Then
                        If parent = strInvtId2 Then
                            'str = "level 1 - " & dt2.Rows(rw)("invtid").ToString
                            dtGrid2.Rows.Add()
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(0) = dt2.Rows(rw)("invtid")
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(1) = dt2.Rows(rw)("descr")
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(2) = dt2.Rows(rw)("qty")
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(3) = dt2.Rows(rw)("unit")
                        End If
                    End If
                Next
            End If
            Grid2.DataSource = dtGrid2
            Grid3.Visible = False
            GroupBox2.Text = "Level 3"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub KodeOtomatis()
        Try
            Dim dt As New DataTable
            dt = fc_Class.AutoNoBoMID()
            If dt.Rows.Count > 0 Then
                Dim bomId As String = dt.Rows(0).Item("bomid").ToString
                If Len(bomId) = "1" Then
                    _txtBoMID.Text = "000000" & bomId
                ElseIf Len(bomId) = "2" Then
                    _txtBoMID.Text = "00000" & bomId
                ElseIf Len(bomId) = "3" Then
                    _txtBoMID.Text = "0000" & bomId
                ElseIf Len(bomId) = "4" Then
                    _txtBoMID.Text = "000" & bomId
                ElseIf Len(bomId) = "5" Then
                    _txtBoMID.Text = "00" & bomId
                ElseIf Len(bomId) = "6" Then
                    _txtBoMID.Text = "0" & bomId
                ElseIf Len(bomId) = "7" Then
                    _txtBoMID.Text = bomId
                End If
            Else
                _txtBoMID.Text = "0000001"
                '    _txtBoMID.Text = "0000001"
                'Else
                '    _txtBoMID.Text = Val(Microsoft.VisualBasic.Mid(dt.Rows(0).Item("bomid").ToString, 3, 2)) + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnDelete.Click
        Try
            If sender.name = btnAdd.Name Then
                CallForm()
            ElseIf sender.name = btnDelete.Name Then
                If GridDetail.Rows.Count = 0 Then Exit Sub
                GridDetail.Rows.Remove(GridDetail.SelectedRows(0))
                'If GridDetail.Rows.Count > 1 Then GridDetail.RowCount = 1
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Sub CallForm(Optional ByVal InvtId As String = "",
                        Optional ByVal Desc As String = "",
                        Optional ByVal Qty As String = "",
                        Optional ByVal Unit As String = "",
                          Optional ByVal isnew As Boolean = True)

        ff_detail = New frmBoM_detail_input(InvtId, Desc, Qty, Unit, Me.Text, GridDetail, dtGrid, isnew)
        ff_detail.StartPosition = FormStartPosition.CenterScreen
        ff_detail.MaximizeBox = False
        ff_detail.ShowDialog()
    End Sub
    Public Sub CallFrmLookUp(Optional ByVal InvtId As String = "")
        Dim f As frmBoMLookUpLevel = New frmBoMLookUpLevel()
        f = New frmBoMLookUpLevel(InvtId)
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub GridDetail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridDetail.CellClick
        Call LoadGridDetil1()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If String.IsNullOrEmpty(_cmbStatus.Text) Then
                errProvider.SetError(_cmbStatus, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbStatus, "")
            End If
            If String.IsNullOrEmpty(_txtInvID.Text) Then
                errProvider.SetError(_txtInvID, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtInvID, "")
            End If
            If String.IsNullOrEmpty(_cmbSite.Text) Then
                errProvider.SetError(_cmbSite, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbSite, "")
            End If
            If String.IsNullOrEmpty(_CmbWC.Text) Then
                errProvider.SetError(_CmbWC, "Value cannot be empty.")
            Else
                errProvider.SetError(_CmbWC, "")
            End If


            If String.IsNullOrEmpty(_cmbMesin.Text) Then
                errProvider.SetError(_cmbMesin, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbMesin, "")
            End If

            'If Not IsNumeric(_txtAllowance.Text) Then
            '    errProvider.SetError(_txtAllowance, "Value must be a numeric.")
            'Else
            '    errProvider.SetError(_txtAllowance, "")
            'End If

            Dim success As Boolean = True
            For Each c As Control In LayoutControl1.Controls
                If errProvider.GetError(c).Length > 0 Then
                    success = False
                End If
            Next


            If success Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Please check your input field !")
            End If
            If lb_Validated = True Then
                With fc_ClassBoM
                    Dim tgl As DateTime = DateTime.ParseExact(_txtDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    .BoMID = _txtBoMID.Text.Trim
                    .Tgl = tgl
                    .InvtID = _txtInvID.Text.Trim
                    .Desc = _txtDesc.Text.Trim
                    .SiteID = _cmbSite.EditValue
                    .Runner = _txtRunner.Text.Trim
                    .CycleTime = _txtCycle.Text.Trim
                    .MC = _cmbMesin.EditValue
                    .cavity = _TxtCavity.Text.Trim
                    .WC = _CmbWC.EditValue
                    .Allowance = _txtAllowance.Text.Trim
                    .MP = _txtMan.Text
                    .Status = _cmbStatus.Text
                    .RefType = _TxtRefType.EditValue
                    .RefNo = _TxtRefNo.Text
                    .Converted = ChekRegular.CheckState
                    If _cmbAktif.EditValue = "Inhouse" Then
                        .Active = 1
                    ElseIf _cmbAktif.EditValue = "Subcon" Then
                        .Active = 0
                    Else
                        .Active = 2
                    End If

                    If isUpdate = False Then
                        fc_Class.InvtID = _txtInvID.Text.Trim
                        fc_Class.BoMID = _txtBoMID.Text.Trim
                        fc_Class.ValidateInsert()
                    Else
                        fc_Class.BoMID = _txtBoMID.Text.Trim
                        fc_Class.ValidateUpdate()
                    End If
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try
            If ChekRegular.CheckState = CheckState.Checked Then
                NoReg = fc_Class.RegularAutoNo()
                fc_ClassBoM.fc_classdetail.Clear()
                For i As Integer = 0 To GridDetail.Rows.Count - 1
                    Dim fc_ClassBomDetails As New clsBoMdetails
                    With fc_ClassBomDetails
                        .BoMID = NoReg
                        .Parentid = _txtInvID.Text.Trim
                        .inventId = Trim(GridDetail.Rows(i).Cells(0).Value.ToString & "")
                        .Descr_detail = Trim(GridDetail.Rows(i).Cells(1).Value.ToString & "")
                        .Qty = Trim(GridDetail.Rows(i).Cells(2).Value.ToString & "")
                        .Unit = Trim(GridDetail.Rows(i).Cells(3).Value.ToString & "")
                    End With
                    fc_ClassBoM.fc_classdetail.Add(fc_ClassBomDetails)
                Next
            Else
                fc_ClassBoM.fc_classdetail.Clear()
                For i As Integer = 0 To GridDetail.Rows.Count - 1
                    Dim fc_ClassBomDetails As New clsBoMdetails
                    With fc_ClassBomDetails
                        .BoMID = _txtBoMID.Text.Trim
                        .Parentid = _txtInvID.Text.Trim
                        .inventId = Trim(GridDetail.Rows(i).Cells(0).Value.ToString & "")
                        .Descr_detail = Trim(GridDetail.Rows(i).Cells(1).Value.ToString & "")
                        .Qty = Trim(GridDetail.Rows(i).Cells(2).Value.ToString & "")
                        .Unit = Trim(GridDetail.Rows(i).Cells(3).Value.ToString & "")
                    End With
                    fc_ClassBoM.fc_classdetail.Add(fc_ClassBomDetails)
                Next
            End If

            If isUpdate = False Then
                fc_ClassBoM.InsertBoM(_cmbStatus.Text)
            Else
                If ChekRegular.CheckState = CheckState.Checked Then
                    fc_ClassBoM.UpdateBoM(intRevisi, True, "REGULAR")
                Else
                    fc_ClassBoM.UpdateBoM(intRevisi, False, _cmbStatus.Text)
                    'If _TxtRefType.Text <> "" AndAlso _TxtRefNo.Text <> "" Then
                    '    fc_ClassBoM.UpdateBoM(intRevisi, False, _cmbStatus.Text)
                    'Else
                    '    _TxtRefType.Focus()
                    '    Throw New Exception("Silahkan pilih No. Referensi !")
                    'End If

                End If
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            'Dim targetString As String = _txtBoMID.Text
            'For Each row As DataGridViewRow In Me.GridDtl.Rows
            '    If row.Cells(0).Value = targetString Then
            '        Me.GridDtl.ClearSelection()
            '        Me.GridDtl.Rows(row.Index).Selected = True
            '        Exit For
            '    End If
            'Next
            IsClosed = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub fillComboMesin()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getIdMesin(_cmbSite.EditValue.ToString)
            _cmbMesin.Properties.DataSource = Nothing
            '_cmbMesin.Properties.Items.Clear()
            _cmbMesin.Properties.DataSource = dt
            _cmbMesin.Properties.ValueMember = "Deskripsi"
            _cmbMesin.Properties.DisplayMember = "Deskripsi"

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub fillComboSite()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getSite

            _cmbSite.Properties.DataSource = Nothing

            _cmbSite.Properties.DataSource = dt
            _cmbSite.Properties.ValueMember = "ID Lokasi"
            _cmbSite.Properties.DisplayMember = "Deskripsi"

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub fillComboWC()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getWC
            _CmbWC.Properties.DataSource = Nothing
            _CmbWC.Properties.DataSource = dt
            _CmbWC.Properties.ValueMember = "Value"
            _CmbWC.Properties.DisplayMember = "Text"

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Grid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellClick
        Try
            Dim dtGrid2 As New DataTable
            dtGrid2.Columns.AddRange(New DataColumn(3) {New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Qty", GetType(String)),
                                                            New DataColumn("Unit", GetType(String))})
            If Grid1.Rows.Count > 0 Then
                Dim strInvtId2 As String
                strInvtId2 = Grid1.SelectedRows(0).Cells(0).Value.ToString
                'Dim dt As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(strInvtId)
                'Grid1.DataSource = dt
                Dim dt2 As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(InvtId)
                dt2 = fc_Class.getRoutingBoM(strInvtId2)
                Dim str2 As String = String.Empty

                For rw = 0 To dt2.Rows.Count - 1
                    Dim parent As String = dt2.Rows(rw)("parentid").ToString
                    If parent <> "" Then
                        If parent = strInvtId2 Then
                            'str2 = "level 1 - " & dt2.Rows(rw)("invtid").ToString
                            dtGrid2.Rows.Add()
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(0) = dt2.Rows(rw)("invtid")
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(1) = dt2.Rows(rw)("descr")
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(2) = dt2.Rows(rw)("qty")
                            dtGrid2.Rows(dtGrid2.Rows.Count - 1).Item(3) = dt2.Rows(rw)("unit")
                        End If
                    End If
                Next
            End If
            Grid2.DataSource = dtGrid2
            Grid3.Visible = False
            GroupBox2.Text = "Level 3"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridDetail.CellDoubleClick
        Try
            CallForm(GridDetail.SelectedRows(0).Cells(0).Value.ToString,
                 GridDetail.SelectedRows(0).Cells(1).Value.ToString,
                 GridDetail.SelectedRows(0).Cells(2).Value.ToString,
                 GridDetail.SelectedRows(0).Cells(3).Value.ToString, False)
        Catch ex As Exception
            ex = Nothing
        End Try

    End Sub
    Dim strInvtId3 As String = String.Empty

    Private Sub Grid2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid2.CellDoubleClick

        Try
            Dim dtGrid3 As New DataTable
            dtGrid3.Columns.AddRange(New DataColumn(3) {New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Qty", GetType(String)),
                                                            New DataColumn("Unit", GetType(String))})
            If Grid2.Rows.Count > 0 Then
                strInvtId3 = Grid2.SelectedRows(0).Cells(0).Value.ToString
                'Dim dt As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(strInvtId)
                'Grid1.DataSource = dt
                Dim dt3 As New DataTable
                'dt = fc_Class.getDetailBoM_Part_n(InvtId)
                dt3 = fc_Class.getRoutingBoM(strInvtId3)
                Dim str2 As String = String.Empty

                For rw = 0 To dt3.Rows.Count - 1
                    Dim parent As String = dt3.Rows(rw)("parentid").ToString
                    If parent <> "" Then
                        If parent = strInvtId3 Then
                            'str2 = "level 1 - " & dt2.Rows(rw)("invtid").ToString
                            dtGrid3.Rows.Add()
                            dtGrid3.Rows(dtGrid3.Rows.Count - 1).Item(0) = dt3.Rows(rw)("invtid")
                            dtGrid3.Rows(dtGrid3.Rows.Count - 1).Item(1) = dt3.Rows(rw)("descr")
                            dtGrid3.Rows(dtGrid3.Rows.Count - 1).Item(2) = dt3.Rows(rw)("qty")
                            dtGrid3.Rows(dtGrid3.Rows.Count - 1).Item(3) = dt3.Rows(rw)("unit")
                        End If
                    End If
                Next
            End If
            GroupBox2.Text = "Level 4 - " & strInvtId3
            Grid3.DataSource = dtGrid3
            Grid3.Visible = True

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _cmbSite_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub _cmbAktif_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub _cmbMesin_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub _cmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub _txtInvID_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles _txtInvID.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If _cmbStatus.EditValue = "" Then
                MsgBox("Pilih Status BoM")
                _cmbStatus.Focus()
            Else
                dtSearch = fc_Class.getInvtItem
                ls_OldKode = _txtInvID.Text.Trim
                ls_Judul = "Items"

            End If

            'dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            'dtSearch.Rows(0).Item(0) = "ALL"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                _txtInvID.Text = ls_Kode
                _txtDesc.Text = ls_Nama

                dtGrid = fc_Class.getDetailBoMByinvtId(ls_Kode)
                GridDetail.DataSource = dtGrid
                LoadGridDetil1()
            End If
            _txtMan.Focus()
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _cmbSite_EditValueChanged(sender As Object, e As EventArgs) Handles _cmbSite.EditValueChanged
        Try
            fillComboMesin()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub _cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbStatus.SelectedIndexChanged
        If fs_Code = "" Then
            If _cmbStatus.Text = "REGULAR" Then
                _txtBoMID.Text = fc_Class.RegularAutoNo()

            ElseIf _cmbStatus.Text = "PROJECT" Then
                _txtBoMID.Text = fc_Class.ProjectAutoNo()
            End If
        End If
    End Sub
End Class
