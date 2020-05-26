Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmSuspendSettleDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim ObjSuspendHeader As New SuspendHeaderModel
    Dim ObjSuspendDetail As New SuspendDetailModel
    Dim ObjSettle As New SettleHeader
    Dim ObjSettleDetail As New SettleDetail
    Dim GridDtl As GridControl
    Dim f As FrmSuspend_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable

    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _SettleID As String = ""

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

    Private Sub FrmSuspendSettleDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        Call InitialSetForm()
        If TxtTotExpense.Text = "" Then
            MessageBox.Show("Silahkan Isi Amount !")
        End If
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjSettle.ID = fs_Code
                ObjSettle.GetSettleById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Settlement " & fs_Code
            Else
                Me.Text = "Settlement"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code = "" Then
                Dim dtGrid As New DataTable
                ObjSuspendDetail.SuspendID = ""
                dtGrid = ObjSuspendDetail.GetDataDetailByID()
                Grid.DataSource = dtGrid
                'If dtGrid.Rows.Count > 0 Then
                '    GridCellFormat(GridView1)
                'End If
            Else
                Dim dtGrid As New DataTable
                dtGrid = ObjSettleDetail.GetDataDetailByID(fs_Code2)
                Grid.DataSource = dtGrid
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjSettle
                    TxtNoSuspend.Text = .SuspendID
                    TxtCurrency.Text = .CuryID
                    TxtNoSettlement.Text = .SettleID
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtTgl.EditValue = .Tgl
                    TxtTotal.Text = Format(.TotalSuspend, gs_FormatBulat)
                    TxtTotExpense.Text = Format(.Total, gs_FormatBulat)
                End With
            Else
                TxtNoSuspend.Text = ""
                TxtCurrency.Text = ""
                TxtDep.Text = ""
                TxtRemark.Text = ""
                TxtStatus.Text = ""
                TxtTgl.Text = ""
                TxtTotal.Text = "0"
                TxtNoSuspend.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If TxtTotExpense.Text = "0" Then
                MessageBox.Show("Silahkan Isi Amount !")
            End If

            If lb_Validated Then
                With ObjSettle
                    .CuryID = TxtCurrency.Text
                    .DeptID = TxtDep.Text
                    .Remark = TxtRemark.Text
                    .Status = TxtStatus.Text
                    .SuspendID = TxtNoSuspend.Text
                    .SettleID = .SettleAutoNo
                    _SettleID = ObjSettle.SettleAutoNo
                    Dim oDate As DateTime = DateTime.ParseExact(TxtTgl.Text, "dd-MM-yyyy", provider)
                    .Tgl = oDate
                    .Total = TxtTotExpense.Text

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
    Public Overrides Sub Proc_SaveData()
        Try
            If TxtTotExpense.Text = "0" Then
                MessageBox.Show("Silahkan Isi Amount !")
            Else

                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim amount As String
                    amount = GridView1.GetRowCellValue(i, GridView1.Columns("Account")) = ""

                    If GridView1.GetRowCellValue(i, GridView1.Columns("Account")) = "" Then

                    End If
                Next

                Dim IsEmpty As Boolean = False
                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString = "" OrElse
                   GridView1.GetRowCellValue(i, GridView1.Columns("SubAccount")).ToString = "" OrElse
                   GridView1.GetRowCellValue(i, GridView1.Columns("ActualAmount")).ToString = "" Then
                        IsEmpty = True
                        GridView1.DeleteRow(i)
                    End If
                Next
                'If IsEmpty Then
                '    Throw New Exception("Silahkan Hapus dulu baris yang kosong !")
                'End If

                If isUpdate = False Then
                    ObjSettle.ObjDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "ActualAmount").ToString <> "" Then
                            ObjSettleDetail = New SettleDetail
                            With ObjSettleDetail
                                .SettleID = _SettleID
                                .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
                                .SuspendAmount = If(GridView1.GetRowCellValue(i, "Amount") Is DBNull.Value, 0, Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount")))
                                .SettleAmount = Convert.ToDouble(GridView1.GetRowCellValue(i, "ActualAmount"))
                                .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                                .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                                .Tgl = CDate(GridView1.GetRowCellValue(i, "Tgl"))
                            End With
                            ObjSettle.ObjDetails.Add(ObjSettleDetail)
                        End If
                    Next
                    ObjSettle.InsertData()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Else
                    ObjSettle.ObjDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "ActualAmount").ToString <> "" Then
                            ObjSettleDetail = New SettleDetail
                            With ObjSettleDetail
                                .SettleID = TxtNoSettlement.Text
                                .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
                                .SuspendAmount = If(GridView1.GetRowCellValue(i, "Amount") Is DBNull.Value, 0, Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount")))
                                .SettleAmount = Convert.ToDouble(GridView1.GetRowCellValue(i, "ActualAmount"))
                                .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                                .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                                .Tgl = CDate(GridView1.GetRowCellValue(i, "Tgl"))
                            End With
                            ObjSettle.ObjDetails.Add(ObjSettleDetail)
                        End If
                    Next
                    ObjSettle.UpdateData(TxtNoSettlement.Text)
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                End If
                GridDtl.DataSource = ObjSettle.GetDataGrid()
                IsClosed = True
                Me.Hide()

            End If

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
            If e.KeyData = Keys.Enter OrElse e.KeyData = Keys.Tab Then

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
                ElseIf GridView1.FocusedColumn.FieldName = "ActualAmount" Then
                    GridView1.MoveNext()
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
                If Not IsDBNull(GridView1.GetRowCellValue(i, "ActualAmount")) Then
                    _total = _total + Convert.ToDecimal(GridView1.GetRowCellValue(i, "ActualAmount"))
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

    Private Sub GSubAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GSubAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GridView1_Click(sender As Object, e As EventArgs) Handles GridView1.Click
        'GridView1.AddNewRow()
        'GridView1.OptionsNavigation.AutoFocusNewRow = True
        'GridView1.FocusedColumn = GridView1.VisibleColumns(0)
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtDep.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtNoSuspend) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub TxtNoSuspend_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoSuspend.ButtonClick
        Try
            ObjSettle = New SettleHeader
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjSettle.GetListSuspend
            ls_OldKode = TxtDep.Text
            ls_Judul = "Advance"


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
                TxtNoSuspend.Text = Value2

                Dim dt As New DataTable
                ObjSuspendHeader = New SuspendHeaderModel
                ObjSuspendHeader.SuspendHeaderID = Value1
                ObjSuspendHeader.GetSuspenById()
                With ObjSuspendHeader
                    TxtNoSuspend.Text = .SuspendID
                    TxtCurrency.SelectedText = .Currency
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtTgl.EditValue = .Tgl
                    TxtTotal.Text = Format(.Total, gs_FormatBulat)
                End With

                Dim dtGrid As New DataTable
                dtGrid = ObjSuspendDetail.GetDataDetailByID1(Value2)
                Grid.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridView1)
                    GridView1.MoveFirst()
                    GridView1.FocusedColumn = GridView1.VisibleColumns(5)
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ReposActual_EditValueChanged(sender As Object, e As EventArgs) Handles ReposActual.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub FrmSuspendSettleDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView1.AddNewRow()
            GridView1.OptionsNavigation.AutoFocusNewRow = True
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        End If
    End Sub

    Private Sub ReposDate_EditValueChanged(sender As Object, e As EventArgs) Handles ReposDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim Total As Double = 0
        For i As Integer = 0 To GridView1.RowCount - 1
            If Not GridView1.GetRowCellValue(i, "ActualAmount") Is DBNull.Value Then
                Total = Total + GridView1.GetRowCellValue(i, "ActualAmount")
            End If
        Next
        TxtTotExpense.Text = Format(Total, gs_FormatBulat)
    End Sub

    Public Overrides Sub Proc_print()
        FrmReportSettle.StartPosition = FormStartPosition.CenterScreen
        FrmReportSettle.TxtNosettle.Text = TxtNoSettlement.Text
        FrmReportSettle.Show()
    End Sub

    Private Sub TxtNoSuspend_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoSuspend.EditValueChanged

    End Sub
End Class
