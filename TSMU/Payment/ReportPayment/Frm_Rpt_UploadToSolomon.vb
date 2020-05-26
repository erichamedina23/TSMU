Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid

Public Class Frm_Rpt_UploadToSolomon

    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing

    Private Sub Frm_Rpt_UploadMizuho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, True, False)
        Init()
        ProgBar.Visible = False
        ''_totalchk.Text = totalsupllier()
    End Sub




    Private Sub totalsupllier()
        Try
            Dim tgl1 As String
            Dim tgl2 As String
            Dim query As String
            tgl1 = DateEdit1.Text
            tgl2 = DateEdit2.Text
            query = "SELECT COUNT(*) FROM payment_header1 where tgl>='" & tgl1 & "' and tgl>='" & tgl2 & "' "
            MainModul.ExecQueryByCommandSolomon(query)
        Catch ex As Exception
            Throw
        End Try
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
        save.Filter = "EXCEL File|*.xls"
        save.Title = "Save an EXCEL File"
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
            Await Task.Run(Sub() GetDataGridReportUploadSolomon())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GetDataGridReportUploadSolomon()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridReportUploadSolomon(date1, date2)
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


    ''Public Overrides Sub Proc_PrintPreview()
    'Try
    '    If XtraTabControl1.SelectedTabPageIndex = 1 Then
    '        If GridView2.RowCount = 0 Then
    '            Throw New Exception("Tidak ada data yang di akan print.")
    '        End If
    '        Dim IsNoTranEmpty As Boolean = False
    '        Dim ValidateNotran As Boolean = True
    '        For i As Integer = 0 To GridView2.RowCount - 1
    '            IsNoTranEmpty = SuratJalan.CheckNoTran(GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan")))
    '            If IsNoTranEmpty Then
    '                ValidateNotran = False
    '                Exit For
    '            End If
    '        Next

    '        No = GetAutoNo()

    '        If ValidateNotran Then
    '            pay_class.NoTran = No

    '            For i As Integer = 0 To GridView2.RowCount - 1
    '                SuratJalan.ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
    '                SuratJalan.UpdateNoTran()
    '            Next

    '        Else
    '            MsgBox("No Trans '[" & No & "]' sudah ada atau sudah pernah di print !")
    '            Exit Sub
    '        End If

    '        Dim ds As DataSet = New DataSet
    '        Dim dt As DataTable = New DataTable
    '        ds = SuratJalan.PrintPO(IIf(_BtnCust.Text = "", "ALL", _BtnCust.Text), Format(_TglSJFrom.EditValue, gs_FormatSQLDate), Format(_TglSJTo.EditValue, gs_FormatSQLDate), _TxtLokasi.Text, Format(_TxtTglKirimFrom.EditValue, gs_FormatSQLDate), Format(_TglKirimTo.EditValue, gs_FormatSQLDate))

    '        dt = ds.Tables("PrintPO")

    '        Dim Laporan As PrintPO = New PrintPO
    '        With Laporan
    '            .param1 = No
    '            .param2 = No
    '            .DataSource = dt
    '            '.DataMember = ds.Tables("PrintPO").TableName
    '        End With

    '        Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
    '            PrintTool.ShowPreviewDialog()
    '            PrintTool.ShowPreview(UserLookAndFeel.Default)
    '        End Using
    '        SuratJalan.UpdateNo(DateTime.Now.Year, DateTime.Now.Month, 1, _TxtLokasi.Text)
    '    End If
    '    LoadDataEdit()
    'Catch ex As Exception
    '    MsgBox(ex.Message)
    'End Try
    ''End Sub

    Private Sub tsBtn_preview_Click(sender As Object, e As EventArgs) Handles tsBtn_preview.Click

    End Sub

    Private Sub tsBtn_print_Click(sender As Object, e As EventArgs) Handles tsBtn_print.Click
        Try
            Dim newform As New Frm_Rpt_APSolomon(DateEdit1.Text, DateEdit2.Text)
            newform.StartPosition = FormStartPosition.CenterScreen
            newform.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Dim ds As New DataSet
        'ds = Report.getalldatauploadbytgl
        'laporan.SetDataSource(ds)

        'With CrystalReportViewer1
        '    .ReportSource = laporan
        '    .Refresh()
        'End With

    End Sub
End Class