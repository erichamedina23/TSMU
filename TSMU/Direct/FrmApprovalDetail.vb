Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmApprovalDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim ObjSuspendHeader As New SuspendApprovalHeaderModel
    Dim ObjSuspendDetail As New SuspendApprovalDetailModel
    Dim GridDtl As GridControl
    Dim GridDtl2 As GridControl
    Dim f As FrmSuspend_Detail2
    Dim dt As New DataTable
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable

    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _SuspendID As String = ""

    Dim level As Integer = 0
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
    Private Sub FrmApprovalDetail_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, True)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        'Call CreateTable()
        Call InitialSetForm()

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
                Me.Text = "Approval " & fs_Code
            Else
                Me.Text = "Approval"
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
            Dim dtGrid As New DataTable
            dtGrid = ObjSuspendDetail.GetDataDetailByID(TxtNoSuspend.Text.TrimEnd)
            Grid.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView1)
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

                level = ObjSuspendHeader.GetUsernameLevel
            Else
                TxtNoSuspend.Text = ""
                TxtPrNo.Text = ""
                TxtCurrency.Text = ""
                TxtDep.Text = ""
                TxtRemark.Text = ""
                TxtStatus.Text = "Open"
                TxtTgl.EditValue = DateTime.Today
                TxtTotal.Text = "0"
                TxtPrNo.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub
    Public Overrides Sub Proc_Approve()
        Try
            Dim result As DialogResult = XtraMessageBox.Show("Approve Advance " & "'" & TxtNoSuspend.Text & "'" & " ?", "Confirmation", MessageBoxButtons.YesNoCancel)
            If result = System.Windows.Forms.DialogResult.Yes Then

                Dim IsTrue As Boolean = ObjSuspendHeader.IsSuspendIsApprovedStepAhead(TxtNoSuspend.Text)
                If IsTrue Then
                    Throw New Exception("Suspend ID '" & TxtNoSuspend.Text & "' sudah di approve oleh atasan anda !, tidak bisa di update")
                End If

                ObjSuspendHeader.ApproveData(TxtNoSuspend.Text, level)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                GridDtl.DataSource = ObjSuspendHeader.GetDataGrid()
                FrmParent.tsBtn_refresh.PerformClick()
                IsClosed = True
                Me.Hide()
            ElseIf result = System.Windows.Forms.DialogResult.No Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjSuspendDetail = New SuspendApprovalDetailModel
                        With ObjSuspendDetail
                            .Ket = GridView1.GetRowCellValue(i, "Ket").ToString().TrimEnd
                        End With
                        ObjSuspendHeader.ObjDetails.Add(ObjSuspendDetail)
                    End If
                Next

                Dim IsTrue As Boolean = ObjSuspendHeader.IsSuspendIsApprovedStepAhead(TxtNoSuspend.Text)
                If IsTrue Then
                    Throw New Exception("Suspend ID '" & TxtNoSuspend.Text & "' sudah di approve oleh atasan anda !, tidak bisa di update")
                End If
                ObjSuspendHeader.CancelApproveData(TxtNoSuspend.Text, level)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                'GridDtl.DataSource = ObjSuspendHeader.GetDataGrid()
                'GridDtl2.DataSource = ObjSuspendHeader.GetDataGrid2()
                FrmParent.tsBtn_refresh.PerformClick()
                IsClosed = True
                Me.Hide()
            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ReposKet_EditValueChanged(sender As Object, e As EventArgs) Handles ReposKet.EditValueChanged
        Grid.FocusedView.PostEditor()
    End Sub
End Class
