Public Class frmSales_Forecast_Calculated
    Dim dtGrid As DataTable
    'Dim _calculate As New clsSalesForecastCalculate
    Dim ObjBomCalculate As New clsSalesForecastCalculate

    Private Sub frmBoM_Calculated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
        AturGrid(Grid, Me)
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False)
    End Sub

    Dim dataTB As DataTable
    Private Sub FillHeader_fdtlConfig1()
        dataTB = New DataTable
        dataTB.Columns.Add("Level 0")
        dataTB.Columns.Add("Level 1")
        dataTB.Columns.Add("Level 2")
        dataTB.Columns.Add("Level 3")
        dataTB.Columns.Add("Level 4")
        dataTB.Columns.Add("Level 5")
        dataTB.Columns.Add("Level 6")
        dataTB.Columns.Add("Level 7")
        dataTB.Columns.Add("Description")
        dataTB.Columns.Add("Qty")
        dataTB.Columns.Add("Unit")
        dataTB.Clear()
    End Sub

    Public Enum IndexCol1 As Byte
        Level0 = 0
        Level1 = 1
        Level2 = 2
        Level3 = 3
        Level4 = 4
        Level5 = 5
        Level6 = 6
        Level7 = 7
        desc = 8
        qty = 9
        unit = 10
    End Enum

    Private Sub LoadData()
        Try
            Dim dt As New DataTable
            dt = ObjBomCalculate.GetBomToCalculate
            FillHeader_fdtlConfig1()

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0).ToString = "Level 0" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level0) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 1" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level1) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 2" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level2) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 3" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level3) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 4" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level4) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 5" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level5) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 6" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level6) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 7" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level7) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
            Next
            setDataSource(dataTB)
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
            frm.Text = "Calculate Forecast"
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowDialog()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
