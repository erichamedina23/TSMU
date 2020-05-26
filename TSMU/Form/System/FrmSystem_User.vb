Public Class FrmSystem_User
    Dim dtGrid As DataTable
    Dim fc_User As New ClassSystemUser1
    Dim frmUser_detail As FrmSystem_User_detail
    Private Sub FrmSystem_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        FilterData = New FrmSystem_FilterData(dtGrid)
    End Sub
    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            dtGrid = New DataTable
            dtGrid = fc_User.getDataGrid(bs_Filter)
            Grid.DataSource = dtGrid
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter User"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub

    Private Sub FilterGrid()
        Try
            'Grid.all = False
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If frmUser_detail IsNot Nothing AndAlso frmUser_detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frmUser_detail.Close()
        End If
        frmUser_detail = New FrmSystem_User_detail(ls_Code, Me, li_Row, Grid)
        frmUser_detail.MdiParent = FrmMain
        'ff_Detail._cmbStatus.Focus()
        frmUser_detail.Show()
    End Sub
    Public Overrides Sub Proc_DeleteData()
        Try
            'Dim fc_Class1 As New clsBoMTrans
            fc_User.Username = Trim(Grid.SelectedRows(0).Cells(0).Value)
            fc_User.DeleteData()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub Grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Try
            Dim objGrid As DataGridView = sender
            If objGrid.Rows.Count > 0 Then
                Call CallFrm(objGrid.SelectedRows(0).Cells(0).Value.ToString,
                             objGrid.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub frmBoM_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If Grid.SelectedRows.Count > 0 Then
                If e.KeyCode = Keys.F1 Then
                    'Dim objGrid As DataGridView = sender
                    If Grid.Rows.Count > 0 Then
                        Call CallFrm(Grid.SelectedRows(0).Cells(0).Value.ToString,
                                     Grid.RowCount)
                    End If
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class
