Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmTravelRequest
    Dim ff_Detail As FrmTravelRequestDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New TravelRequestModel

    Dim TabPage As String

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmTravelRequestDetail(ls_Code, ls_Code2, Me, li_Row, GridRequestAll)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub FrmTravelRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = GridApprovedReq.DataSource
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
        XtraTabControl1.SelectedTabPage = TabPageRequest
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            GridRequestAll.DataSource = dtGrid
            GridCellFormat(GridViewAll)
            dtGrid = fc_Class.GetTravelRequest()
            GridApprovedReq.DataSource = dtGrid
            GridCellFormat(GridViewApproved)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()

        Dim flag As Boolean = False
        Try
            Dim Approved As String = String.Empty
            Dim NoRequest As String
            fc_Class = New TravelRequestModel
            For i As Integer = 0 To GridViewApproved.RowCount - 1
                Approved = GridViewApproved.GetRowCellValue(i, "Approved")
                NoRequest = GridViewApproved.GetRowCellValue(i, "NoRequest")
                If Approved = "APPROVED" Then
                    fc_Class.Status = "Approved"
                    fc_Class.UpdateStatusHeader(NoRequest)
                    flag = True
                ElseIf Approved = "REVISED" Then
                    fc_Class.Status = "Revised"
                    fc_Class.UpdateStatusHeader(NoRequest)
                    flag = True
                ElseIf Approved = "REJECT" Then
                    fc_Class.Status = "Reject"
                    fc_Class.UpdateStatusHeader(NoRequest)
                    flag = True
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        If flag Then
            MessageBox.Show("Data Updated.")
            LoadGrid()
        End If

    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty
        Dim status As String = String.Empty
        Try
            Dim selectedRows() As Integer = GridViewAll.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridViewAll.GetRowCellValue(rowHandle, "NoRequest")
                    status = GridViewAll.GetRowCellValue(rowHandle, "Status")
                End If
            Next rowHandle

            If status = "Approved" Then
                'Err.Raise(ErrNumber, , "Travel ID " & ID & " dalam proses settlement !")
                MessageBox.Show("No Request " & ID & " sudah di Approve oleh atasan !", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf status = "Reject" Then
                MessageBox.Show("No Request " & ID & " sudah di Reject oleh atasan !", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Else
                fc_Class.NoRequest = ID
                fc_Class.Delete()

                tsBtn_refresh.PerformClick()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub

    Private Sub GridRequestAll_DoubleClick(sender As Object, e As EventArgs) Handles GridRequestAll.DoubleClick
        Try
            Dim NoRequest = String.Empty
            Dim NIK = String.Empty
            Dim selectedRows() As Integer = GridViewAll.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoRequest = GridViewAll.GetRowCellValue(rowHandle, "NoRequest")
                    NIK = GridViewAll.GetRowCellValue(rowHandle, "NIK")
                End If
            Next rowHandle

            If GridViewAll.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         NIK,
                         GridViewAll.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageRequest" Then
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
        Else
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False)
        End If
        LoadGrid()
    End Sub

    Private Sub CApproved_EditValueChanged(sender As Object, e As EventArgs) Handles CApproved.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

End Class
