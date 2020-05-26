Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmSuspend_Detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim ObjSuspendHeader As New SuspendHeaderModel
    Dim ObjSuspendDetail As New SuspendDetailModel
    Dim GridDtl As GridControl
    Dim f As FrmSuspend_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable

    Dim ObjSuspend As New ClsSuspend
    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _SuspendID As String = ""

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
    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(3) {New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})

        Grid.DataSource = DtScan
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub FrmSuspend_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        'Call CreateTable()
        Call InitialSetForm()

        'Dim dtGrid As New DataTable
        'Grid.DataSource = dtGrid
        'If dtGrid.Rows.Count > 0 Then
        '    TxtAmountReq.Enabled = False
        'End If
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjSuspendHeader.SuspendHeaderID = fs_Code
                ObjSuspendHeader.GetSuspenById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Advance " & fs_Code
            Else
                Me.Text = "Advance"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmSuspend"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGrid As New DataTable
                ObjSuspendDetail.SuspendID = TxtNoSuspend.Text
                dtGrid = ObjSuspendDetail.GetDataDetailByID()
                Grid.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridView1)
                End If
            Else
                Dim dtGrid As New DataTable
                ObjSuspendDetail.SuspendID = ""
                dtGrid = ObjSuspendDetail.GetDataDetailByID()
                Grid.DataSource = dtGrid
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjSuspendHeader
                    TxtNoSuspend.Text = .SuspendID
                    TxtPrNo.Text = .PRNo
                    TxtCurrency.SelectedText = .Currency
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtTgl.EditValue = .Tgl
                    TxtTotal.Text = Format(.Total, gs_FormatBulat)
                End With
                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True
            Else
                TxtNoSuspend.Text = ""
                TxtPrNo.Text = ""
                TxtCurrency.SelectedIndex = 0
                TxtDep.Text = gh_Common.GroupID
                TxtRemark.Text = ""
                TxtStatus.Text = "Open"
                TxtTgl.EditValue = DateTime.Today
                TxtTotal.Text = "0"
                TxtPrNo.Focus()
                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
        Total = 0
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated Then
                With ObjSuspendHeader
                    .Currency = TxtCurrency.Text
                    .DeptID = TxtDep.Text
                    .PRNo = TxtPrNo.Text
                    .Remark = TxtRemark.Text
                    .Status = TxtStatus.Text
                    .SuspendID = .SuspendAutoNo
                    _SuspendID = .SuspendAutoNo
                    .Tgl = TxtTgl.EditValue
                    .Tipe = "S"
                    .Total = TxtTotal.Text
                    'If isUpdate = False Then
                    '    .ValidateInsert()
                    'Else
                    '    .ValidateUpdate()
                    'End If
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Sub CallForm(Optional ByVal ID As String = "", Optional ByVal Nama As String = "", Optional ByVal IsNew As Boolean = True)

        f = New FrmSuspend_Detail2(ID, Nama, IsNew, dt, Grid)
        f.StartPosition = FormStartPosition.CenterScreen
        f.MaximizeBox = False
        f.ShowDialog()

    End Sub
    Public Overrides Sub Proc_Approve()
        CallForm()
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.MoveFirst()
                If GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString = "" OrElse
                   GridView1.GetRowCellValue(i, GridView1.Columns("SubAccount")).ToString = "" OrElse
                   GridView1.GetRowCellValue(i, GridView1.Columns("Amount")).ToString = "" Then
                    IsEmpty = True
                    GridView1.DeleteRow(i)
                End If
            Next
            'If IsEmpty Then
            '    Throw New Exception("Silahkan Hapus dulu baris yang kosong !")
            'End If

            If isUpdate = False Then
                ObjSuspendHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjSuspendDetail = New SuspendDetailModel
                        With ObjSuspendDetail
                            .SuspendID = _SuspendID
                            .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
                            .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                        End With
                        ObjSuspendHeader.ObjDetails.Add(ObjSuspendDetail)
                    End If
                Next
                ObjSuspendHeader.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjSuspendHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjSuspendDetail = New SuspendDetailModel
                        With ObjSuspendDetail
                            .SuspendID = TxtNoSuspend.Text
                            .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
                            .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                        End With
                        ObjSuspendHeader.ObjDetails.Add(ObjSuspendDetail)
                    End If
                Next

                Dim Result As Boolean = ObjSuspendHeader.IsSuspendOpen(fs_Code)
                If Result Then
                    Throw New Exception("Suspend ID '" & fs_Code2 & "' tidak bisa di edit !")
                End If
                ObjSuspendHeader.UpdateData(TxtNoSuspend.Text)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjSuspendHeader.GetDataGrid()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _tot As Decimal = 0
                _tot = GetTot()
                TxtTotal.Text = Format(_tot, gs_FormatBulat)
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter Then

                ObjSuspendDetail = New SuspendDetailModel
                If GridView1.FocusedColumn.FieldName = "SubAccount" Then
                    ObjSuspendDetail.SubAcct = GridView1.GetFocusedRowCellValue("SubAccount").ToString()
                    Dim dt As New DataTable
                    dt = ObjSuspendDetail.GetSubAccountbyid
                    If dt.Rows.Count > 0 Then
                        GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                        GridView1.ShowEditor()
                        GridView1.UpdateCurrentRow()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick
        Try
            ObjSuspendHeader = New SuspendHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjSuspendHeader.GetAccount
            ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account"))
            ls_Judul = "Account"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Function GetTot() As Decimal
        Dim _total As Decimal = 0

        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Amount")) Then
                    _total = _total + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                End If
            Next
            Return _total
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GSubAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GSubAccount.ButtonClick
        Try
            ObjSuspendHeader = New SuspendHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            dtSearch = ObjSuspendHeader.GetSubAccount
            ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount"))
            ls_Judul = "Sub Account"


            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "SubAccount", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtDep_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDep.ButtonClick
        Try
            ObjSuspendHeader = New SuspendHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjSuspendHeader.GetDept
            ls_OldKode = TxtDep.Text
            ls_Judul = "Departemen"


            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                TxtDep.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GSubAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GSubAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GAmount_EditValueChanged(sender As Object, e As EventArgs) Handles GAmount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        'Grid.FocusedView.PostEditor()
    End Sub

    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtPrNo.DoValidate()
        TxtDep.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtPrNo) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtDep) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub
    Dim Total As Double = 0
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim Total As Double = 0
        For i As Integer = 0 To GridView1.RowCount - 1
            If Not GridView1.GetRowCellValue(i, "Amount") Is DBNull.Value Then
                Total = Total + GridView1.GetRowCellValue(i, "Amount")
            End If
        Next
        TxtTotal.Text = Format(Total, gs_FormatBulat)
    End Sub

    Private Sub FrmSuspend_Detail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView1.AddNewRow()
            GridView1.OptionsNavigation.AutoFocusNewRow = True
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        End If
    End Sub

    Private Sub ReposAmount_EditValueChanged(sender As Object, e As EventArgs) Handles ReposAmount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub TxtAmountReq_TextChanged(sender As Object, e As EventArgs) Handles TxtAmountReq.TextChanged
        'If TxtTotal.Text <> "0" Then
        '    TxtTotal.Text = TxtAmountReq.Text
        'Else
        '    TxtTotal.Text = (Val(TxtTotal.Text) + TxtAmountReq.Text)
        'End If
        TxtTotal.Text = Format(Val(TxtAmountReq.Text), gs_FormatBulat)
    End Sub

    Private Sub btnAddDetail_Click(sender As Object, e As EventArgs) Handles btnAddDetail.Click
        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
    End Sub
    Public Overrides Sub Proc_print()
        FrmReportSuspend.StartPosition = FormStartPosition.CenterScreen
        FrmReportSuspend.TxtNoSuspend.Text = TxtNoSuspend.Text
        FrmReportSuspend.Show()
    End Sub
End Class
