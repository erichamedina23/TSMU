Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_UploadToSolomon
    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing



    Private Sub Init()
        GridControl3.DataSource = Nothing
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub

    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "CSV File|*.csv"
        save.Title = "Save a CSV File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToCsv(save.FileName)
        End If
    End Sub
    Private Sub Proc_Excel()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                If GridView4.RowCount > 0 Then
                    SaveToExcel(GridControl3)
                    MsgBox("Data Berhasil di Export!")
                Else
                    MsgBox("Grid Kosong!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub tampilallchecked()
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomonCheck())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomon())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub tampilall()
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomon())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub tampilallupload()
        Try
            'If ProgBar2.Visible = True Then
            '    ''Throw New Exception("Process already running, Please wait!")
            'End If
            'ProgBar2.Visible = True
            'ProgBar2.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomonOk())
        Catch ex As Exception
            'ProgBar2.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GetDataGridUploadToSolomon()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridUploadToSolomon(date1, date2)
        setDataSource(dt, GridControl3)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    Private Sub GetDataGridUploadToSolomonOk()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit6.Text
                   date2 = DateEdit5.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridUploadToSolomonOk(date1, date2)
        setDataSource(dt, GridControl6)
        Invoke(Sub()
                   ProgBar3.Visible = False
               End Sub)
    End Sub

    Private Sub AR_UploadToSolomon()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit8.Text
                   date2 = DateEdit7.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.AR_UploadToSolomon(date1, date2)
        setDataSource(dt, GridControl6)
        Invoke(Sub()
                   ProgBar4.Visible = False
               End Sub)
    End Sub



    Private Sub GetDataGridUploadToSolomonUploaded()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit8.Text
                   date2 = DateEdit7.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridUploadToSolomonUploaded(date1, date2)
        setDataSource(dt, GridControl9)
        Invoke(Sub()
                   ProgBar4.Visible = False
               End Sub)
    End Sub

    Private Sub GetDataGridUploadToSolomonChecked()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit4.Text
                   date2 = DateEdit3.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridUploadToSolomonchecked(date1, date2)
        setDataSource(dt, GridControl1)
        Invoke(Sub()
                   ProgBar2.Visible = False
               End Sub)
    End Sub

    Private Sub GetDataGridUploadToSolomonCheck()
        Dim date1 As String = ""
        Dim date2 As String = ""
        Dim check As Boolean
        Dim vrno As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
                   For i As Integer = 0 To GridView4.RowCount - 1
                       check = GridView4.GetRowCellValue(i, "Pilih")
                       vrno = GridView4.GetRowCellValue(i, "Vrno")
                   Next
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridUploadToSolomonCheck(date1, date2, check, vrno)
        setDataSource(dt, GridControl3)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    Friend Delegate Sub SetDataSourceDelegate(table As DataTable, _Grid As GridControl)
    Private Sub setDataSource(table As DataTable, _Grid As GridControl)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table, _Grid)
        Else
            _Grid.DataSource = table
        End If
    End Sub

    Private Sub Frm_UploadToSolomon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
        Init()
        ProgBar.Visible = False
        ''TextEdit1.Text = GridView4.GetRowCellValue(1, 2)
    End Sub



    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        Try
            Dim query As String
            Dim prosespay As Boolean
            Dim vrno As String
            Dim a As Boolean
            For i As Integer = 0 To GridView4.RowCount - 1
                vrno = GridView4.GetRowCellValue(i, "vrno")
                prosespay = GridView4.GetRowCellValue(i, "prosespay")
                a = GridView4.GetRowCellValue(i, "Pilih")
                If a = True Then
                    a = False
                    prosespay = GridView4.GetRowCellValue(i, "Pilih")
                    vrno = GridView4.GetRowCellValue(i, "Vrno")
                    query = "update payment_header1 set prosespay='" & prosespay & "' where vrno='" & vrno & "' "
                    MainModul.ExecQueryByCommandSolomon(query)
                Else
                    a = True
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView4.Columns.Clear()
        GridView4.RefreshData()
        tampilall()
    End Sub



    Private Sub check()
        'Try
        '    If e.Column.FieldName = "Pilih" Then
        '        If GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Check") = True Then
        '            check()
        '        Else
        '            check()
        '        End If
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message)
        'End Try
        Dim a As Boolean
        Try
            For i As Integer = 0 To GridView4.RowCount - 1
                a = GridView4.GetRowCellValue(i, 10)
                If a = True Then
                    a = False
                    _totalchk.Text = _totalchk.Text - GridView4.GetRowCellValue(i, 10)
                Else
                    a = True
                    _totalchk.Text = _totalchk.Text - 1
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Try
            Dim query As String
            Dim uploaded, vrno As String
            For i As Integer = 0 To GridView4.RowCount
                uploaded = GridView4.GetRowCellValue(i, 10).value
                vrno = GridView4.GetRowCellValue(i, 0).value

                query = "update payment_header1 set uploaded='" & uploaded & "' where vrno='" & vrno & "' "
                MainModul.ExecQueryByCommandSolomon(query)
            Next
        Catch ex As Exception
            ''Throw
        End Try

        MessageBox.Show("Data Updated.")
        GridView4.Columns.Clear()
        GridView4.RefreshData()
        ''tampilall()

    End Sub

    Private Sub GridView4_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView4.CellValueChanged
        'Dim a As Boolean
        'Try
        '    For i As Integer = 0 To GridView4.RowCount
        '        a = GridView4.GetRowCellValue(i, 10)
        '        If GridView4.GetRowCellValue(i, 10) = True Then
        '            a = False
        '            _totalchk.Text = _totalchk.Text - GridView4.GetRowCellValue(i, 10)
        '        Else
        '            a = True
        '            _totalchk.Text = _totalchk.Text - 1
        '        End If
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub



    Private Async Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If ProgBar2.Visible = True Then
                ''Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar2.Visible = True
            ProgBar2.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomonChecked())
        Catch ex As Exception
            ProgBar2.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim query As String
            Dim uploaded As Boolean
            Dim vrno As String
            Dim a As Boolean
            For i As Integer = 0 To GridView9.RowCount - 1
                vrno = GridView9.GetRowCellValue(i, "vrno")
                uploaded = GridView9.GetRowCellValue(i, "Check If Uploaded")
                a = GridView9.GetRowCellValue(i, "Check If Uploaded")
                If a = True Then
                    a = False
                    uploaded = GridView9.GetRowCellValue(i, "Check If Uploaded")
                    vrno = GridView9.GetRowCellValue(i, "Vrno")
                    query = "update payment_header1 set uploaded='" & uploaded & "' where vrno='" & vrno & "' "
                    MainModul.ExecQueryByCommandSolomon(query)
                Else
                    a = True
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView9.Columns.Clear()
        GridView9.RefreshData()
        tampilallupload()
    End Sub

    Private Async Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            If ProgBar3.Visible = True Then
                ''Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar3.Visible = True
            ProgBar3.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomonOk())
        Catch ex As Exception
            ''ProgBar3.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If ProgBar4.Visible = True Then
                ''Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar4.Visible = True
            ProgBar4.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridUploadToSolomonUploaded())
        Catch ex As Exception
            ProgBar4.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    'Private Sub GridView4_Click(sender As Object, e As EventArgs) Handles GridView4.Click
    '    Dim a As Boolean
    '    Try
    '        For i As Integer = 0 To GridView4.RowCount - 1
    '            a = GridView4.GetRowCellValue(i, 10)
    '            If GridView4.GetRowCellValue(i, 10) = True Then
    '                a = False
    '                _totalchk.Text = _totalchk.Text - GridView4.GetRowCellValue(i, 10)
    '            Else
    '                a = True
    '                _totalchk.Text = _totalchk.Text - 1
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub
End Class