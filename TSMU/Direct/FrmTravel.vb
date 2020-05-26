Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmTravel
    Dim ff_Detail As FrmTravel_Detail2
    Dim dtGrid As DataTable
    Dim dtGrid2 As DataTable
    Dim ObjTravel As TravelHeaderModel
    Dim ObjTravelSett As TravelSettlementHeaderModel
    Dim TabPage As String

    Private Sub FrmTravel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        Call LoadGrid()
        Call LoadGrid2()
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            ObjTravel = New TravelHeaderModel
            ObjTravel.Status = ""
            dtGrid = ObjTravel.GetDataGrid()
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

    Private Sub LoadGrid2()
        Try
            ObjTravel = New TravelHeaderModel
            ObjTravel.Status = "Approved"
            dtGrid2 = ObjTravel.GetDataGrid()
            'dtGrid2 = ObjTravel.GetDataGrid2()

            GridApprove.DataSource = dtGrid2
            GridView2.BestFitColumns()

            With GridView2
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView2)
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
        Call LoadGrid2()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            Dim Check As Boolean
            Dim TravelID As String
            ObjTravel = New TravelHeaderModel
            For i As Integer = 0 To GridView1.RowCount - 1
                Check = GridView2.GetRowCellValue(i, "CheckList")
                TravelID = GridView2.GetRowCellValue(i, "TravelID")
                If Check = True Then
                    ObjTravel.Status = "Approved"
                    ObjTravel.UpdateHeaderApprove(TravelID)
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        LoadGrid()
        LoadGrid2()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmTravel_Detail2(ls_Code, ls_Code2, "", Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty

        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "TravelID")
                End If
            Next rowHandle
            Dim dt As DataTable
            ObjTravelSett = New TravelSettlementHeaderModel
            dt = ObjTravelSett.GetTravelSettHeaderByTravelID(ID)
            Dim ada As Integer
            ada = dt.Rows.Count()
            If ada > 0 Then
                Err.Raise(ErrNumber, , "Travel ID " & ID & " dalam proses settlement !")
                'MessageBox.Show("Data dalam proses settlement", "Warning",
                '                MessageBoxButtons.OK,
                '                MessageBoxIcon.Exclamation,
                '                MessageBoxDefaultButton.Button1)
            Else
                ObjTravel.ID = ID
                ObjTravel.Delete()

                tsBtn_refresh.PerformClick()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim ID As String
    Dim Travelid As String

    Private Sub FrmTravel_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "TravelHeaderID")
                        Travelid = GridView1.GetRowCellValue(rowHandle, "TravelID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    Call CallFrm(ID,
                             Travelid,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
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

                ID = String.Empty
                Travelid = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "TravelHeaderID")
                        Travelid = GridView1.GetRowCellValue(rowHandle, "TravelID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                         Travelid,
                         GridView1.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "XtraTabPage1" Then
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
        Else
            Call Proc_EnableButtons(False, False, False, True, False, True, False, False, False, False, False)
        End If
    End Sub

    Private Sub GridApprove_DoubleClick(sender As Object, e As EventArgs) Handles GridApprove.DoubleClick
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

                ID = String.Empty
                Travelid = String.Empty
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView2.GetRowCellValue(rowHandle, "TravelHeaderID")
                        Travelid = GridView2.GetRowCellValue(rowHandle, "TravelID")
                    End If
                Next rowHandle

                If GridView2.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                         Travelid,
                         GridView1.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CCheckApprove_EditValueChanged(sender As Object, e As EventArgs) Handles CCheckApprove.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

End Class
