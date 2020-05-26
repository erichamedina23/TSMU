Imports DevExpress.XtraGrid
Public Class frmBoM_detail1
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

    Private Sub frmBoM_detail1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub frmBoM_detail1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Me.Text = "Master BoM " & fs_Code
                btnCari.Enabled = False
            Else
                Me.Text = "Master New BoM"
            End If
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadGridDetil()
            Call LoadGridDetil1()
            If gh_Common.Group <> "NPD" AndAlso gh_Common.Group <> "Administrator" Then
                FillComboProjectNotNPD()
            Else
                FillComboProjectNPD()
            End If
            Call fillComboSite()
            fillComboWC()
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmBoM"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub FillComboProjectNPD()
        Dim status() As String = {"", "PROJECT", "REGULAR"}
        _cmbStatus.Items.Clear()
        For Each var As String In status
            _cmbStatus.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboProjectNotNPD()
        Dim status() As String = {"", "REGULAR"}
        _cmbStatus.Items.Clear()
        For Each var As String In status
            _cmbStatus.Items.Add(var)
        Next
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtBoMID.Text = .BoMID
                    _txtDate.Text = .Tgl.ToString("dd/MM/yyyy")
                    _txtInvID.Text = .InvtID
                    _txtDesc.Text = .Desc
                    _cmbSite.Text = .SiteID
                    'If .SiteID = "TSC1" Then
                    '    _cmbSite.Text = "TS"
                    'Else
                    '    _cmbSite.Text = "TANGERANG"
                    'End If

                    _txtRunner.Text = .Runner
                    _txtCycle.Text = .CycleTime
                    _cmbMesin.Text = .MC
                    TxtCavity.Text = .cavity
                    CmbWC.SelectedValue = .WC
                    _txtAllowance.Text = .Allowance.ToString
                    _txtMan.Text = .MP
                    _cmbStatus.Text = .Status
                    If .Active = 1 Then
                        _cmbAktif.Text = "Inhouse"
                    ElseIf .Active = 0 Then
                        _cmbAktif.Text = "Subcon"
                    Else
                        _cmbAktif.Text = "Discontinue"
                    End If
                    _cmbStatus.Focus()
                End With
            Else

                KodeOtomatis()
                '_txtBoMID.Text = 
                _txtDate.Text = Format(Date.Now, "dd/MM/yyyy")
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
            End If
            If gh_Common.Group <> "NPD" AndAlso gh_Common.Group <> "COSTING" AndAlso gh_Common.Group <> "Administrator" Then
                _cmbAktif.Enabled = False
            Else
                _cmbAktif.Enabled = True
            End If
            Grid3.Visible = False
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

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If _cmbStatus.Text = "" Then
                MsgBox("Pilih Status BoM")
                _cmbStatus.Focus()
            ElseIf _cmbStatus.Text = "REGULAR" Then
                If sender.Name = btnCari.Name Then
                    dtSearch = fc_Class.getInvtItem
                    ls_OldKode = _txtInvID.Text.Trim
                    ls_Judul = "Items"

                End If
            Else
                If sender.Name = btnCari.Name Then
                    dtSearch = fc_Class.getInvtItem_project
                    ls_OldKode = _txtInvID.Text.Trim
                    ls_Judul = "Items"

                End If
            End If

            'dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            'dtSearch.Rows(0).Item(0) = "ALL"

            Dim lF_SearchData As FrmSystem_Filter
            lF_SearchData = New FrmSystem_Filter(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                If sender.Name = btnCari.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _txtInvID.Text = ls_Kode
                    _txtDesc.Text = ls_Nama
                End If
            End If
            _txtMan.Focus()
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
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
            'If _txtInvID.Text.Trim = "" Then
            '    _txtInvID.Focus()
            '    Err.Raise(ErrNumber, , "Please fill inventory Id !")
            'ElseIf _cmbSite.Text.Trim = "" Then
            '    _cmbSite.Focus()
            '    Err.Raise(ErrNumber, , "Please choose site !")
            'ElseIf _txtRunner.Text.Trim = "" Then
            '    _txtRunner.Focus()
            '    Err.Raise(ErrNumber, , "Please fill runner !")
            'ElseIf _txtCycle.Text.Trim = "" Then
            '    _txtCycle.Focus()
            '    Err.Raise(ErrNumber, , "Please fill cylce time !")
            'ElseIf _cmbMesin.Text.Trim = "" Then
            '    _cmbMesin.Focus()
            '    Err.Raise(ErrNumber, , "Please fill m/c Ton !")
            'ElseIf _txtAllowance.Text.Trim = "" Then
            '    _txtAllowance.Focus()
            '    Err.Raise(ErrNumber, , "Please fill allowance !")
            'ElseIf _cmbStatus.Text.Trim = "" Then
            '    _cmbStatus.Focus()
            '    Err.Raise(ErrNumber, , "Please choose status !")
            'ElseIf GridDetail.Rows.Count = 0 Then
            '    Err.Raise(ErrNumber, , "Please add details BoM !")
            'Else
            '    lb_Validated = True
            'End If
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
            If String.IsNullOrEmpty(CmbWC.Text) Then
                errProvider.SetError(CmbWC, "Value cannot be empty.")
            Else
                errProvider.SetError(CmbWC, "")
            End If
            'If Not IsNumeric(_txtMan.Text) Then
            '    errProvider.SetError(_txtMan, "Value must be a numeric.")
            'Else
            '    errProvider.SetError(_txtMan, "")
            'End If
            'If Not IsNumeric(_txtCycle.Text) Then
            '    errProvider.SetError(_txtCycle, "Value must be a numeric.")
            'Else
            '    errProvider.SetError(_txtCycle, "")
            'End If

            'If Not IsNumeric(_txtRunner.Text) Then
            '    errProvider.SetError(_txtRunner, "Value must be a numeric.")
            'Else
            '    errProvider.SetError(_txtRunner, "")
            'End If

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
            For Each c As Control In TabPage1.Controls
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
                    Dim tgl As DateTime = DateTime.ParseExact(_txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    .BoMID = _txtBoMID.Text.Trim
                    .Tgl = tgl
                    .InvtID = _txtInvID.Text.Trim
                    .Desc = _txtDesc.Text.Trim
                    .SiteID = _cmbSite.SelectedValue
                    .Runner = _txtRunner.Text.Trim
                    .CycleTime = _txtCycle.Text.Trim
                    .MC = _cmbMesin.Text.Trim
                    .cavity = TxtCavity.Text.Trim
                    .WC = CmbWC.SelectedValue
                    .Allowance = _txtAllowance.Text.Trim
                    .MP = _txtMan.Text
                    .Status = _cmbStatus.Text.Trim
                    If _cmbAktif.Text = "Inhouse" Then
                        .Active = 1
                    ElseIf _cmbAktif.Text = "Subcon" Then
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

            If isUpdate = False Then
                fc_ClassBoM.InsertBoM(_cmbStatus.Text)
            Else
                fc_ClassBoM.UpdateBoM(intRevisi, False, _cmbStatus.Text)
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
            dt = fc_Class.getIdMesin(_cmbSite.SelectedValue.ToString)
            _cmbMesin.DataSource = Nothing
            _cmbMesin.Items.Clear()
            _cmbMesin.DataSource = dt
            _cmbMesin.ValueMember = "ID Mesin"
            _cmbMesin.DisplayMember = "Deskripsi"

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub fillComboSite()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getSite
            _cmbSite.DataSource = Nothing
            _cmbSite.Items.Clear()
            _cmbSite.DataSource = dt
            _cmbSite.ValueMember = "ID Lokasi"
            _cmbSite.DisplayMember = "Deskripsi"

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub fillComboWC()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getWC
            CmbWC.DataSource = Nothing
            CmbWC.Items.Clear()
            CmbWC.DataSource = dt
            CmbWC.ValueMember = "Value"
            CmbWC.DisplayMember = "Text"

        Catch ex As Exception
            Throw
        End Try
    End Sub
    'Private Sub _txtAllowance_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles _txtAllowance.Validating
    '    If Not IsNumeric(_txtAllowance.Text) Then
    '        errProvider.SetError(_txtAllowance, "Value must be a numeric.")
    '    Else
    '        errProvider.SetError(_txtAllowance, "")
    '    End If
    'End Sub

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

    Private Sub _cmbSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbSite.SelectedIndexChanged
        Try
            fillComboMesin()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _cmbSite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbSite.KeyPress
        e.Handled = True
    End Sub

    Private Sub _cmbAktif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbAktif.KeyPress
        e.Handled = True
    End Sub

    Private Sub _cmbMesin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbMesin.KeyPress
        e.Handled = True
    End Sub

    Private Sub _cmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbStatus.KeyPress
        e.Handled = True
    End Sub
End Class
