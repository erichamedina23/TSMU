Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Public Class Frm_Rpt_PPh
    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing
    Private Sub Frm_Rpt_PPh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
        Init()
        ProgBar.Visible = False
    End Sub
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
        save.Filter = "Excel File|*.xls"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXls(save.FileName)
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

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridPPhTax())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GetDataGridPPhTax()
        Dim date1 As String = ""
        Dim date2 As String = ""
        Dim pph As String = ""
        Dim site As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
                   pph = cmb_pph.Text
                   site = cmb_site.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewPPhTax(date1, date2, pph, site)
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

End Class