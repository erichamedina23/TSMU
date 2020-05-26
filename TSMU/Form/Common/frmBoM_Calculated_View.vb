Public Class frmBoM_Calculated_View
    Dim dtGrid As DataTable
    Dim _calculate As New clsCalcultateBoM

    Private Sub frmBoM_Calculated_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
        AturGrid(Grid, Me)
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False)
    End Sub

    Dim dataTB As DataTable
    Private Sub FillHeader_fdtlConfig()
        dataTB = New DataTable
        dataTB.Columns.Add("Bom ID")
        dataTB.Columns.Add("Level 0")
        dataTB.Columns.Add("Level 1")
        dataTB.Columns.Add("Level 2")
        dataTB.Columns.Add("Level 3")
        dataTB.Columns.Add("Level 4")
        dataTB.Columns.Add("Description")
        dataTB.Columns.Add("Qty")
        dataTB.Columns.Add("Unit")
        dataTB.Clear()
    End Sub

    Public Enum IndexCol As Byte
        bomid = 0
        Level0 = 1
        Level1 = 2
        Level2 = 3
        Level3 = 4
        Level4 = 5
        desc = 6
        qty = 7
        unit = 8
    End Enum

    Private Sub LoadData()
        Try
            Dim dtHeader As DataTable = _calculate.level0("")

            If dtHeader Is Nothing Then
                Exit Sub
            End If
            Call FillHeader_fdtlConfig()
            For i As Integer = 0 To dtHeader.Rows.Count - 1
                dataTB.Rows.Add()
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.bomid) = Trim(dtHeader.Rows(i).Item("bomid") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level0) = Trim(dtHeader.Rows(i).Item("Level0") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level1) = Trim(dtHeader.Rows(i).Item("Level1") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level2) = Trim(dtHeader.Rows(i).Item("Level2") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level3) = Trim(dtHeader.Rows(i).Item("Level3") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level4) = Trim(dtHeader.Rows(i).Item("Level4") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.desc) = Trim(dtHeader.Rows(i).Item("descr") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.qty) = Trim(dtHeader.Rows(i).Item("qty") & "")
                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(dtHeader.Rows(i).Item("unit") & "")

                'LEVEL 1
                Dim level1 As New DataTable
                level1 = _calculate.level1(Trim(dtHeader.Rows(i).Item(IndexCol.bomid)))
                For j As Integer = 0 To level1.Rows.Count - 1
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level1) = Trim(level1.Rows(j).Item("Level1") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.desc) = Trim(level1.Rows(j).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.qty) = Trim(level1.Rows(j).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(level1.Rows(j).Item("unit") & "")
                    'LEVEL 2
                    Dim level2 As New DataTable
                    level2 = _calculate.level2(Trim(level1.Rows(j).Item(IndexCol.Level1)))
                    For k As Integer = 0 To level2.Rows.Count - 1
                        dataTB.Rows.Add()
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level2) = Trim(level2.Rows(k).Item("Level2") & "")
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.desc) = Trim(level2.Rows(k).Item("descr") & "")
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.qty) = Trim(level2.Rows(k).Item("qty") & "")
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(level2.Rows(k).Item("unit") & "")

                        'LEVEL 3
                        Dim level3 As New DataTable
                        level3 = _calculate.level3(Trim(level2.Rows(k).Item(IndexCol.Level2)))
                        For l As Integer = 0 To level3.Rows.Count - 1
                            dataTB.Rows.Add()
                            dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level3) = Trim(level3.Rows(l).Item("Level3") & "")
                            dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.desc) = Trim(level3.Rows(l).Item("descr") & "")
                            dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.qty) = Trim(level3.Rows(l).Item("qty") & "")
                            dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(level3.Rows(l).Item("unit") & "")

                            'LEVEL 4
                            Dim level4 As New DataTable
                            level4 = _calculate.level4(Trim(level3.Rows(l).Item(IndexCol.Level3)))
                            For m As Integer = 0 To level4.Rows.Count - 1
                                dataTB.Rows.Add()
                                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.Level3) = Trim(level4.Rows(m).Item("Level4") & "")
                                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.desc) = Trim(level4.Rows(m).Item("descr") & "")
                                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.qty) = Trim(level4.Rows(m).Item("qty") & "")
                                dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(level4.Rows(m).Item("unit") & "")

                            Next
                        Next
                    Next
                Next
            Next
            setDataSource(dataTB)
            'Grid.DataSource = dataTB
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetGridViewSortState(ByVal dgv As DataGridView, ByVal sortMode As DataGridViewColumnSortMode)
        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = sortMode
        Next
    End Sub

    Private Sub Grid_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles Grid.ColumnAdded
        SetGridViewSortState(Grid, DataGridViewColumnSortMode.NotSortable)
    End Sub

    Private Async Sub ShowCalculatedBoMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowCalculatedBoMToolStripMenuItem.Click
        Try
            If ProgressBar1.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            ProgressBar1.Visible = True
            ProgressBar1.Style = ProgressBarStyle.Marquee

            Await Task.Run(Sub() LoadData())
            'LoadData()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Friend Delegate Sub SetDataSourceDelegate(table As DataTable)
    Private Sub setDataSource(table As DataTable)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)
        Else
            Grid.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub btnFunction_MouseClick(sender As Object, e As MouseEventArgs) Handles btnFunction.MouseClick
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                ContextFunc.Show(btnFunction, New System.Drawing.Point(e.X, e.Y))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CalculateBoMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateBoMToolStripMenuItem.Click
        Try
            If Grid.Rows.Count = 0 Then
                Throw New Exception("Data Empty, Please Load data to calculate !")
            End If
            If ProgressBar1.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            Dim frm As FrmSystemLookUpCalculateSales
            frm = New FrmSystemLookUpCalculateSales(dataTB)
            frm.Text = "Calculate BoM"
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowDialog()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
