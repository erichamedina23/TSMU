Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmApproval
    Dim ff_Detail As FrmApprovalDetail
    Dim ApprovalEntertain As FrmApprovalEntertain
    Dim ApprovalTravel As FrmTravel_Detail2
    Dim dtGrid As DataTable
    Dim ObjSuspend As New SuspendApprovalHeaderModel
    Dim ObjTravel As New TravelHeaderModel
    Dim TabPage As String

    Private Sub FrmApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        XtraTabControl1.SelectedTabPage = XtraTabPage1
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = ObjSuspend.GetDataGrid()
            Grid.DataSource = dtGrid
            With GridView1
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridView1)

            Dim dt As New DataTable
            dt = ObjSuspend.GetDataGrid2()
            Grid2.DataSource = dt
            With GridView2
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridView2)

            ObjTravel = New TravelHeaderModel
            ObjTravel.Status = "Open"
            dt = ObjTravel.GetDataGrid()

            GridNewApprovalTravel.DataSource = dt
            GridView3.BestFitColumns()

            With GridView3
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView3)

            ObjTravel.Status = "Approved"
            dt = ObjTravel.GetDataGrid()

            GridApprovedTravel.DataSource = dt
            GridView4.BestFitColumns()

            With GridView4
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView4)

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGrid2()
        Try
            ''ObjSuspend = New SuspendHeaderModel

            dtGrid = ObjSuspend.GetDataGrid()
            Grid.DataSource = dtGrid
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If TabPage = "XtraTabPage1" Then
                Dim suspendid As String
                Dim status As String
                Dim a As Boolean
                Dim ObjSuspend As New SuspendApprovalHeaderModel
                Dim level As Integer = ObjSuspend.GetUsernameLevel
                For i As Integer = 0 To GridView1.RowCount - 1
                    suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                    a = GridView1.GetRowCellValue(i, "ceklist")
                    status = GridView1.GetRowCellValue(i, "Status")
                    If a = True Then
                        ObjSuspend.ApproveData(suspendid, level)
                    Else

                    End If
                Next
            Else
                Dim Check As Boolean
                Dim TravelID As String
                ObjTravel = New TravelHeaderModel
                For i As Integer = 0 To GridView3.RowCount - 1
                    Check = GridView3.GetRowCellValue(i, "CheckList")
                    TravelID = GridView3.GetRowCellValue(i, "TravelID")
                    If Check = True Then
                        ObjTravel.Status = "Approved"
                        ObjTravel.UpdateHeaderApprove(TravelID)
                    End If
                Next
                LoadGrid()
            End If

        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        ''GridView1.Columns.Clear()
        ''GridView1.RefreshData()
        LoadGrid2()
    End Sub

    Private Sub CallFrmEntertain(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ApprovalEntertain IsNot Nothing AndAlso ApprovalEntertain.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ApprovalEntertain.Close()
        End If
        ApprovalEntertain = New FrmApprovalEntertain(ls_Code, ls_Code2, Me, li_Row, Grid)
        ApprovalEntertain.MdiParent = FrmMain
        ApprovalEntertain.StartPosition = FormStartPosition.CenterScreen
        ApprovalEntertain.Show()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmApprovalDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub CallFrmTravel(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ApprovalTravel IsNot Nothing AndAlso ApprovalTravel.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ApprovalTravel.Close()
        End If
        ApprovalTravel = New FrmTravel_Detail2(ls_Code, ls_Code2, TabPage, Me, li_Row, Grid)
        ApprovalTravel.MdiParent = MenuUtamaForm
        ApprovalTravel.StartPosition = FormStartPosition.CenterScreen
        ApprovalTravel.Show()
    End Sub

    Dim ID As String
    Dim suspendid As String
    Dim Travelid As String

    Private Sub FrmApproval_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                If XtraTabControl1.SelectedTabPage Is XtraTabPage1 Then
                    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView1.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView1.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView1.GetSelectedRows.Length > 0 Then
                        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView1.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                             suspendid,
                             GridView1.RowCount)
                        End If
                    End If
                Else
                    Dim selectedRows1() As Integer = GridView2.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows1
                        If rowHandle >= 0 Then
                            ID = GridView2.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView2.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView2.GetSelectedRows.Length > 0 Then
                        If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView2.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                                 suspendid,
                                 GridView2.RowCount)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick, Grid2.DoubleClick, GridNewApprovalTravel.DoubleClick, GridApprovedTravel.DoubleClick
        Try
            If XtraTabControl1.SelectedTabPage Is XtraTabPage1 Then
                Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
                'Dim view As GridView = TryCast(sender, GridView)
                Dim view As BaseView = Grid.GetViewAt(ea.Location)
                If view Is Nothing Then
                    Return
                End If
                Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
                Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
                If info.InRow OrElse info.InRowCell Then

                    ID = String.Empty
                    suspendid = String.Empty
                    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView1.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView1.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView1.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView1.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                             suspendid,
                             GridView1.RowCount)
                        End If
                    End If


                End If
            ElseIf XtraTabControl1.SelectedTabPage Is XtraTabPage2 Then
                Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
                'Dim view As GridView = TryCast(sender, GridView)
                Dim view As BaseView = Grid2.GetViewAt(ea.Location)
                If view Is Nothing Then
                    Return
                End If
                Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
                Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
                If info.InRow OrElse info.InRowCell Then

                    ID = String.Empty
                    suspendid = String.Empty
                    Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView2.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView2.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView2.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView2.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                             suspendid,
                             GridView2.RowCount)
                        End If
                    End If
                End If
            ElseIf XtraTabControl1.SelectedTabPage Is XtraTabPage3 Then
                Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
                'Dim view As GridView = TryCast(sender, GridView)
                Dim view As BaseView = Grid.GetViewAt(ea.Location)
                If view Is Nothing Then
                    Return
                End If
                Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
                Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
                If info.InRow OrElse info.InRowCell Then

                    ID = String.Empty
                    Travelid = String.Empty
                    Dim selectedRows() As Integer = GridView3.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView3.GetRowCellValue(rowHandle, "TravelHeaderID")
                            Travelid = GridView3.GetRowCellValue(rowHandle, "TravelID")
                        End If
                    Next rowHandle

                    If GridView3.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        Call CallFrmTravel(ID,
                             Travelid,
                             GridView1.RowCount)
                    End If
                End If
            Else
                Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
                'Dim view As GridView = TryCast(sender, GridView)
                Dim view As BaseView = Grid.GetViewAt(ea.Location)
                If view Is Nothing Then
                    Return
                End If
                Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
                Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
                If info.InRow OrElse info.InRowCell Then

                    ID = String.Empty
                    Travelid = String.Empty
                    Dim selectedRows() As Integer = GridView4.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView4.GetRowCellValue(rowHandle, "TravelHeaderID")
                            Travelid = GridView4.GetRowCellValue(rowHandle, "TravelID")
                        End If
                    Next rowHandle

                    If GridView4.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        Call CallFrmTravel(ID,
                             Travelid,
                             GridView1.RowCount)
                    End If
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim query As String
            Dim checked As Boolean
            Dim suspendid As String
            Dim a As Boolean
            For i As Integer = 0 To GridView1.RowCount - 1
                suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                checked = GridView1.GetRowCellValue(i, "Check")
                a = GridView1.GetRowCellValue(i, "Check")
                If a = True Then
                    a = False
                    checked = GridView1.GetRowCellValue(i, "Check")
                    suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                    query = "update suspend_header set ceklist='" & checked & "' where suspendid='" & suspendid & "' "
                    MainModul.ExecQueryByCommandSolomon(query)
                Else
                    a = True
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView1.Columns.Clear()
        GridView1.RefreshData()
        LoadGrid()
    End Sub

    Private Sub RepositoryItemCheckEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "XtraTabPage2" Or TabPage = "XtraTabPage4" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False)
        Else
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        End If
    End Sub

    Private Sub CCheckApprove_EditValueChanged(sender As Object, e As EventArgs) Handles CCheckApprove.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

End Class
