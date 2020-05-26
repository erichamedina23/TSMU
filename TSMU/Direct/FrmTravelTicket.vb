Public Class FrmTravelTicket
    Dim dtGrid As DataTable
    Dim fc_Class As New TravelTicketModel
    Dim ff_Detail As FrmTravelTicketDetail

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmTravelTicketDetail(ls_Code, ls_Code2, Me, li_Row, GridTicket)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub FrmTravelTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = GridRequest.DataSource
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetTravelRequest()
            GridRequest.DataSource = dtGrid
            GridCellFormat(GridView1)

            dtGrid = fc_Class.GetTravelTicket()
            GridTicket.DataSource = dtGrid
            GridCellFormat(GridView2)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim NoVoucher As String = String.Empty

        Try
            Dim selectedRows() As Integer = GridView2.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoVoucher = GridView2.GetRowCellValue(rowHandle, "NoVoucher")
                End If
            Next rowHandle

            'dt = ObjTravelSett.GetTravelSettHeaderByTravelID(ID)
            'Dim ada As Integer
            'ada = dt.Rows.Count()
            'If ada > 0 Then
            '    Err.Raise(ErrNumber, , "Travel ID " & ID & " dalam proses settlement !")
            '    'MessageBox.Show("Data dalam proses settlement", "Warning",
            '    '                MessageBoxButtons.OK,
            '    '                MessageBoxIcon.Exclamation,
            '    '                MessageBoxDefaultButton.Button1)
            'Else
            fc_Class.NoVoucher = NoVoucher
            fc_Class.DeleteData()

            tsBtn_refresh.PerformClick()
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Dim TabPage As String = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "XtraTabPage1" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False)
        Else
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
        End If
    End Sub

    Private Sub GridTicket_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
        Try
            Dim NoVoucher = String.Empty
            Dim selectedRows() As Integer = GridView2.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoVoucher = GridView2.GetRowCellValue(rowHandle, "NoVoucher")
                End If
            Next rowHandle

            If GridView2.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoVoucher,
                         GridView2.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
