Public Class frmReportSo
    Dim dtGrid As DataTable
    Dim service As JogressService
    Private Sub frmReportSo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        _cmbSO.SelectedIndex = 0

        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, False, False, True, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            service = New JogressService
            dtGrid = New DataTable
            dtGrid = service.GetDataGridReport(_cmbSO.Text)
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1, False)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Data Kosong !")
        End If
    End Sub

    Private Sub _cmbSO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbSO.SelectedIndexChanged
        Try
            LoadGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _cmbSO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbSO.KeyPress
        e.Handled = True
    End Sub

    Private Sub Grid_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub
End Class
