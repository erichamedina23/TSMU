Public Class frmSales
    Dim ObjSales As sales_model
    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False)
        ProgBar.Visible = False
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                Dim save As New SaveFileDialog
                save.Filter = "Excel File|*.xlsx"
                save.Title = "Save an Excel File"
                If save.ShowDialog = DialogResult.OK Then
                    Grid.ExportToXlsx(save.FileName)
                End If
                'getPath()
                '    Dim Filename As String = path & "\Forecast_.xls"
                '    'Dim FileName As String = "D:\Grid.xls"
                '    Grid.ExportToXls(Filename)

            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            'Try
            '    getPath()
            '    If path <> "" Then
            '        If DataGridView1.Rows.Count > 0 Then
            '            ExcelLib.ExportToExcel(path & "\", DataGridView1, "convert_")
            '        Else
            '            Throw New Exception("Grid Kosong")
            '        End If

            '    End If
            '    ShowMessage("File Stored at : " & path)
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'End Try
            'Exit Sub

            If _txtPerpost.Text = "" Then
                _txtPerpost.Focus()
                Throw New Exception("Harap Isi Perpost !")
            End If
            If ProgBar.Visible = True Then
                Throw New Exception("Proses already running, Please wait !")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGrid())
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GetDataGrid()
        Try
            Dim perpost As String = ""
            Invoke(Sub()
                       perpost = _txtPerpost.Text
                   End Sub)
            ObjSales = New sales_model
            Dim dt As New DataTable
            dt = ObjSales.SalesLoadDataGrid(perpost)
            setDataSource(dt)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Friend Delegate Sub SetDataSourceDelegate(table As DataTable)
    Private Sub setDataSource(table As DataTable)
        Try
            ' Invoke method if required:
            If Me.InvokeRequired Then
                Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)
            Else
                Grid.DataSource = table
                ProgBar.Visible = False
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub
End Class
