Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo



Public Class FrmApprovalEntertain
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim ObjEntertainHeader As New EntertainApprovalHeaderModel
    Dim ObjEntertainDetail As New EntertainApprovalDetailModel
    Dim GridDtl As GridControl
    Dim f As FrmEntertain_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable
    Dim DtScan1 As DataTable

    Dim ObjSuspend As New ClsSuspend
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

    Private Sub FrmApprovalEntertain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, True)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        Call InitialSetForm()

    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjEntertainHeader.SuspendHeaderID = fs_Code
                ObjEntertainHeader.GetSuspenById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Approval Entertainment " & fs_Code
            Else
                Me.Text = "Approval Entertainment"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            Dim dtGrid As New DataTable
            dtGrid = ObjEntertainDetail.GetDataDetailByID(TxtNoSuspend.Text)
            Grid.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridView1.FocusedColumn = GridView1.VisibleColumns(0)
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjEntertainHeader
                    TxtNoSuspend.Text = .SuspendID
                    TxtPrNo.Text = .PRNo
                    TxtCurrency.SelectedText = .Currency
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtTgl.EditValue = .Tgl
                    TxtTotal.Text = .Total
                End With
                level = ObjEntertainHeader.GetUsernameLevel
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
            Dim result As DialogResult = XtraMessageBox.Show("Approve Suspend " & "'" & TxtNoSuspend.Text & "'" & " ?", "Confirmation", MessageBoxButtons.YesNoCancel)
            If result = System.Windows.Forms.DialogResult.Yes Then

                Dim IsTrue As Boolean = ObjEntertainHeader.IsEntertainIsApprovedStepAhead(TxtNoSuspend.Text)
                If IsTrue Then
                    Throw New Exception("Suspend ID '" & TxtNoSuspend.Text & "' sudah di approve oleh atasan anda !, tidak bisa di update")
                End If

                ObjEntertainHeader.ApproveData(TxtNoSuspend.Text, level)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                GridDtl.DataSource = ObjEntertainHeader.GetDataGrid()
                IsClosed = True
                Me.Hide()
            ElseIf result = System.Windows.Forms.DialogResult.No Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjEntertainDetail = New EntertainApprovalDetailModel
                        With ObjEntertainDetail
                            .Ket = GridView1.GetRowCellValue(i, "Ket").ToString().TrimEnd
                        End With
                        ObjEntertainHeader.ObjDetails.Add(ObjEntertainDetail)
                    End If
                Next
                Dim IsTrue As Boolean = ObjEntertainHeader.IsEntertainIsApprovedStepAhead(TxtNoSuspend.Text)
                If IsTrue Then
                    Throw New Exception("Suspend ID '" & TxtNoSuspend.Text & "' sudah di approve oleh atasan anda !, tidak bisa di update")
                End If
                ObjEntertainHeader.CancelApproveData(TxtNoSuspend.Text, level)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                GridDtl.DataSource = ObjEntertainHeader.GetDataGrid()
                IsClosed = True
                Me.Hide()
            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private ID As Integer
    Private SuspendID As String
    Private Sub ReposKet_EditValueChanged(sender As Object, e As EventArgs) Handles ReposKet.EditValueChanged
        Grid.FocusedView.PostEditor()
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click
        Try

            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = Grid.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                ID = 0
                SuspendID = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        SuspendID = Convert.ToString(GridView1.GetRowCellValue(rowHandle, "SuspendID"))
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    Dim dt As New DataTable
                    dt = ObjEntertainDetail.GetDataDetailRelasi(SuspendID)
                    GridControl1.DataSource = dt
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
