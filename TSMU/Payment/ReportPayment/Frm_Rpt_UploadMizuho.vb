Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Public Class Frm_Rpt_UploadMizuho

    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing
    Dim ObjMizuho As New MizuhoModels

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim GridDtl As GridControl

    Private Sub Frm_Rpt_UploadMizuho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
        Init()
        ProgBar.Visible = False
        loadgrid()
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
        Proc_Text()
    End Sub

    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Text File|*.txt"
        save.Title = "Save a Text File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToCsv(save.FileName, New DevExpress.XtraPrinting.CsvExportOptions(",", Encoding.Default))
        End If
    End Sub



    Private Sub SaveToExcel1(_Grid As GridControl)
        If My.Settings.FilePath = "" OrElse My.Settings.Filename = "" Then
            XtraMessageBox.Show("Setting dulu file path atau file name pada menu setting !")
        Else
            _Grid.ExportToXls(My.Settings.FilePath & "\" & My.Settings.Filename & Format(DateTime.Today, "yyyyMMdd") & ".xls")
            'New DevExpress.XtraPrinting.XlsExportOptions(",", Encoding.Default))
        End If
    End Sub

    Private Sub SaveToText(_Grid As GridControl)
        If My.Settings.FilePath = "" OrElse My.Settings.Filename = "" Then
            XtraMessageBox.Show("Setting dulu file path atau file name pada menu setting !")
        Else
            _Grid.ExportToCsv(My.Settings.FilePath & "\" & My.Settings.Filename & Format(DateTime.Today, "yyyyMMdd") & ".txt", New DevExpress.XtraPrinting.CsvExportOptions(",", Encoding.Default))
        End If
    End Sub

    Private Sub Proc_Excel()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                If GridView4.RowCount > 0 Then
                    SaveToExcel1(GridControl3)
                    'SaveToExcel(GridControl3)
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

    Private Sub Proc_Text()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                If GridView4.RowCount > 0 Then
                    SaveToText(GridControl3)
                    'SaveToExcel(GridControl3)
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
            Await Task.Run(Sub() GetDataGridREportUploadToSolomon())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub



    'Private Async Sub reportuploadtomizuho()
    '    Try
    '        If ProgBar.Visible = True Then
    '            Throw New Exception("Process already running, Please wait!")
    '        End If
    '        ProgBar.Visible = True
    '        ProgBar.Style = ProgressBarStyle.Marquee
    '        Await Task.Run(Sub() ReportMizuho())
    '    Catch ex As Exception
    '        ProgBar.Visible = False
    '        MsgBox(ex.Message)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try
    'End Sub

    Private Sub GetDataGridREportUploadToSolomon()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewUploadMizuho(date1, date2)
        setDataSource(dt, GridControl3)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    Private Sub GetDataSyncTemplate()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridSyncTemplate(date1, date2)
        setDataSource(dt, GridControl4)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    Private Sub GetDataSyncMizuho()
        Dim Date3 As String = ""
        Dim Date4 As String = ""
        ''Dim date1 As DateTime
        ''Dim date2 As DateTime
        Invoke(Sub()
                   Date3 = DateEdit3.Text
                   Date4 = DateEdit4.Text
               End Sub)
                   Dim dt As New DataTable
        dt = pay_class.DataGridSyncMizuho(Date3, Date4)
        setDataSource(dt, GridControl4)
        Invoke(Sub()
                   ProgBar5.Visible = False
               End Sub)
               End Sub

    Private Sub GetDataGridTemplateMizuho()
        'Dim date1 As String = ""
        'Dim date2 As String = ""
        ''Dim date1 As DateTime
        ''Dim date2 As DateTime
        'Invoke(Sub()
        '           date1 = DateEdit1.Text
        '           date2 = DateEdit2.Text
        '       End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewTemplateMizuho()
        setDataSource(dt, GridControl1)
        Invoke(Sub()
                   ProgBar3.Visible = False
               End Sub)
    End Sub


    'Private Sub ReportMizuho()
    '    Dim date1 As String = ""
    '    Dim date2 As String = ""
    '    'Dim date1 As DateTime
    '    'Dim date2 As DateTime
    '    Invoke(Sub()
    '               date1 = DateEdit1.Text
    '               date2 = DateEdit2.Text
    '           End Sub)
    '    Dim dt As New DataTable
    '    dt = pay_class.DataGridViewUploadMizuho(date1, date2)
    '    dt = ds.Tables("PrintPO")
    '    setDataSource(dt, "XtraReport1")
    '    Invoke(Sub()
    '               ProgBar.Visible = False
    '           End Sub)
    'End Sub

    Friend Delegate Sub SetDataSourceDelegate(table As DataTable, _Grid As GridControl)
    Private Sub setDataSource(table As DataTable, _Grid As GridControl)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table, _Grid)
        Else
            _Grid.DataSource = table
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub tsBtn_preview_Click(sender As Object, e As EventArgs) Handles tsBtn_preview.Click
        Proc_PrintPreview()
    End Sub


    Private Sub Proc_PrintPreview()
        Try
            If TabControl1.TabIndex = 1 Then
                If GridView4.RowCount = 0 Then
                    Throw New Exception("Tidak ada data yang di akan print.")
                End If

            Else
                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = New DataTable
                Dim date1 As String = ""
                Dim date2 As String = ""
                Invoke(Sub()
                           date1 = DateEdit1.Text
                           date2 = DateEdit2.Text
                       End Sub)

                ds = pay_class.Mizuho(Format(DateEdit1.EditValue, gs_FormatSQLDate), Format(DateEdit2.EditValue, gs_FormatSQLDate))
                dt = ds.Tables("mizuho")

                Dim Laporan As XtraReport4 = New XtraReport4
                With Laporan
                    ''.param1 = date1
                    ''.param2 = date2
                    .DataSource = dt
                End With

                Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                    PrintTool.ShowPreviewDialog()
                    PrintTool.ShowPreview(UserLookAndFeel.Default)
                End Using

            End If
            LoadData()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            If DateEdit1.Text = "" OrElse DateEdit2.Text = "" Then
                If DateEdit1.Text = "" Then
                    DateEdit1.Focus()
                ElseIf DateEdit2.Text = "" Then
                    DateEdit2.Focus()
                End If
                Throw New Exception("Silahkan pilih tanggal!")
            End If

            Cursor = Cursors.WaitCursor
            Dim dt As New DataTable
            GridControl3.DataSource = dt
            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Sub GetExcelSheetNames(ByVal FileName As String)
    '    Dim sConn As String
    '    sConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
    '            FileName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"

    '    Dim conn As New OleDbConnection(sConn)

    '    conn.Open()

    '    Dim dtSheets As DataTable =
    '    conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '    Dim drSheet As DataRow

    '    ListBox1.Items.Clear()
    '    For Each drSheet In dtSheets.Rows
    '        ListBox1.Items.Add(drSheet("TABLE_NAME").ToString())
    '    Next

    '    LoadExcel2Grid(FileName, ListBox1.Items(0).ToString)

    '    conn.Close()

    'End Sub

    Private Sub _btnBrowse_Click(sender As Object, e As EventArgs) Handles _btnBrowse.Click
        'With OpenFileDialog1
        '    .FileName = String.Empty
        '    .InitialDirectory = "C:\"
        '    .Title = "Open Excel File"
        '    .Filter = "Excel 97-2003|*.xls|Excel 2007|*.xlsx"
        'End With
        'Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        'If result = Windows.Forms.DialogResult.OK Then
        '    Try
        '        TextBox1.Text = OpenFileDialog1.FileName
        '        GetExcelSheetNames(TextBox1.Text)
        '    Catch ex As Exception
        '        MsgBox("Error : " & ex.Message)
        '    End Try
        'End If

        Using fold As New OpenFileDialog
            fold.Filter = "document files (*.csv)|*.csv|richtextformat files (*.rtf)|*.rtf|All files (*.*)|*.*"
            fold.Title = "Select file"
            If fold.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                'fold.FilterIndex = 2
                fold.RestoreDirectory = True
                ''MessageBox.Show("You selected " & fold.FileName)
                TextBox1.Text = fold.FileName
            End If
            'Dim result As DialogResult
            'If result = Windows.Forms.DialogResult.OK Then
            '    Try
            '        ''GetExcelSheetNames(TextBox1.Text)
            '    Catch ex As Exception
            '        MsgBox("Error : " & ex.Message)
            '    End Try
            ''End If

        End Using
    End Sub

    Private Sub _btnUpload_Click(sender As Object, e As EventArgs) Handles _btnUpload.Click
        If TextBox1.Text = "" Then
            MsgBox("Data Upload Belum Dipilih! Silahkan Pilih Dahulu.")
        Else
            Dim table As New DataTable
            Dim ls_Judul As String = "UPLOAD MIZUHO"
            ''Dim Bulan As String = ""
            ''Dim strTahun As String = ""
            ''Dim strSupplier As String = ""

            'Dim frmExcel As FrmSystemExcelBarcode
            'frmExcel = New FrmSystemExcelBarcode(table, 69)
            'frmExcel.Text = "IMPORT " & ls_Judul
            'frmExcel.StartPosition = FormStartPosition.CenterScreen
            'frmExcel.ShowDialog()

            Try
                ObjMizuho.DeleteMizuhoTemplate()
                Dim dv As DataView = New DataView(table)
                Dim dtFilter As New DataTable

                dtFilter = dv.ToTable

                If dtFilter.Rows.Count >= 0 Then

                    '' SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    '' SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    For Each row As DataRow In dtFilter.Rows
                        Try
                            ObjMizuho = New MizuhoModels
                            With ObjMizuho
                                .ref_no_sup = If(row("ref_no_sup") Is DBNull.Value, "", row("ref_no_sup").ToString())
                                .field = If(row("field") Is DBNull.Value, "", row("field").ToString())
                                .takagi_acct = If(row("takagi_acct") Is DBNull.Value, "", row("takagi_acct").ToString())
                                .rek_pt = If(row("rek_pt") Is DBNull.Value, "", row("rek_pt").ToString())
                                .payment_method = If(row("payment_method") Is DBNull.Value, "", row("payment_method").ToString())
                                .curyid = If(row("curyid") Is DBNull.Value, "", row("curyid").ToString())
                                .sp_amount = If(row("sp_amount") Is DBNull.Value, "", row("sp_amount").ToString())
                                .trans_amount = If(row("trans_amount") Is DBNull.Value, "", row("trans_amount").ToString())
                                .value_date = If(row("value_date") Is DBNull.Value, "", row("value_date").ToString())
                                .bankname = If(row("bankname") Is DBNull.Value, 0, Convert.ToString(row("bankname")))
                                .branch = If(row("branch") Is DBNull.Value, 0, Convert.ToInt32(row("branch")))
                                .address = If(row("address") Is DBNull.Value, "", row("address").ToString())
                                .address2 = If(row("address2") Is DBNull.Value, "", row("address2").ToString())
                                .norek_supplier = If(row("norek_supplier") Is DBNull.Value, "", row("norek_supplier").ToString())
                                .pt = If(row("pt") Is DBNull.Value, "", row("pt").ToString())
                                .pt2 = If(row("pt2") Is DBNull.Value, 0, Convert.ToInt32(row("pt2")))
                                .address_pt = If(row("address_pt") Is DBNull.Value, 0, Convert.ToInt32(row("address_pt")))
                                .address_pt2 = If(row("address_pt2") Is DBNull.Value, "", row("address_pt").ToString())
                                .space_kosong = If(row("space_kosong") Is DBNull.Value, "", row("space_kosong").ToString())
                                .bank_charges = If(row("bank_charges") Is DBNull.Value, "", row("bank_charges").ToString())
                                .applicant_acct = If(row("applicant_acct") Is DBNull.Value, "", row("applicant_acct").ToString())
                                .space_kosong2 = If(row("space_kosong2") Is DBNull.Value, "", row("space_kosong2").ToString())
                                .other = If(row("other") Is DBNull.Value, "", row("other").ToString())
                                .other1 = If(row("other1") Is DBNull.Value, "", row("other1").ToString())
                                .other2 = If(row("other2") Is DBNull.Value, "", row("other2").ToString())
                                .other3 = If(row("other3") Is DBNull.Value, "", row("other3").ToString())
                                .InsertDataTemplateMizuho()
                            End With

                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            Continue For
                        End Try
                    Next


                    'Dim dtUploadMizuho As New DataTable
                    'dtUploadMizuho = ObjMizuho.GetMizuhoUpload
                    'For i As Integer = 0 To dtUploadMizuho.Rows.Count - 1
                    '    Try
                    '        ''Dim _tgl As String = Convert.ToString(dtUploadMizuho.Rows(i)(0))
                    '        ''Dim _plant As String = Convert.ToString(dtUploadMizuho.Rows(i)(1))
                    '        ''Dim _user As String = Convert.ToString(dtUploadMizuho.Rows(i)(2))
                    '        '' Dim _qty As Integer = Convert.ToInt32(dtUploadMizuho.Rows(i)(3))

                    '        'Dim IsExist As Boolean = ObjMizuho.IsMizuhoUploadExist()
                    '        'If Not IsExist Then
                    '        '    '    Obj.UpdateKanbanSum(Tgl, Cycle, Kanban)
                    '        '    'Else
                    '        '    ObjMizuho.SaveMizuhoUpload()
                    '        'End If
                    '    Catch ex As Exception
                    '        MsgBox(ex.Message)
                    '        Console.WriteLine(ex.Message)
                    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    '        Continue For
                    ''End Try
                    ''Next

                    'dtKanban = Obj.GetKanban

                    ''SplashScreenManager.CloseForm()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    loadgrid()
                End If
            Catch ex As Exception
                Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'If TextBox1.Text = "" Then
        '    MsgBox("Data Upload Belum Dipilih! Silahkan Pilih Dahulu.")
        'Else
        '    Try
        '        If ProgBar3.Visible = True Then
        '            Throw New Exception("Process already running, Please wait!")
        '        End If
        '        ProgBar3.Visible = True
        '        ProgBar3.Style = ProgressBarStyle.Marquee
        '        Await Task.Run(Sub() GetDataGridTemplateMizuho())
        '    Catch ex As Exception
        '        ProgBar3.Visible = False
        '        MsgBox(ex.Message)
        '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        '    End Try
        'End If
    End Sub



    Private Sub loadgrid()
        Try
            ObjMizuho = New MizuhoModels
            Dim dtUploadMizuho As New DataTable
            dtUploadMizuho = ObjMizuho.GetAllDataMizuhoTEmplate()
            GridControl1.DataSource = dtUploadMizuho

            'If GridView2.RowCount > 0 Then
            '    With GridView2
            '        .BestFitColumns()
            '        .Columns(0).Visible = False
            '        .FixedLineWidth = 2
            '        .Columns(16).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '        .Columns(17).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '        .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '        .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            '    End With
            '    GridCellFormat(GridView2)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub _btnCompare_Click(sender As Object, e As EventArgs) Handles _btnCompare.Click

        Try
            ObjMizuho.DeleteMizuho()
            For i As Integer = 0 To GridView4.RowCount - 1
                ''If GridView1.GetRowCellValue(i, "Check") = True Then
                Dim Objmizuho As New MizuhoModels
                With Objmizuho
                    .ref_no_sup = GridView4.GetRowCellValue(i, "ref_no_sup").ToString().TrimEnd
                    .field = GridView4.GetRowCellValue(i, "field").ToString().TrimEnd
                    .takagi_acct = GridView4.GetRowCellValue(i, "takagi_acct").ToString().TrimEnd
                    .rek_pt = GridView4.GetRowCellValue(i, "rek_pt").ToString().TrimEnd
                    .payment_method = GridView4.GetRowCellValue(i, "payment_method").ToString().TrimEnd
                    .curyid = GridView4.GetRowCellValue(i, "curyid").ToString().TrimEnd
                    .sp_amount = GridView4.GetRowCellValue(i, "sp_amount").ToString().TrimEnd
                    .trans_amount = GridView4.GetRowCellValue(i, "trans_amount").ToString().TrimEnd
                    .value_date = GridView4.GetRowCellValue(i, "value_date").ToString().TrimEnd
                    .bankname = GridView4.GetRowCellValue(i, "bankname").ToString().TrimEnd
                    .branch = GridView4.GetRowCellValue(i, "branch").ToString().TrimEnd
                    .address = GridView4.GetRowCellValue(i, "address").ToString().TrimEnd
                    .address2 = GridView4.GetRowCellValue(i, "address2").ToString().TrimEnd
                    .norek_supplier = GridView4.GetRowCellValue(i, "norek_supplier")
                    .pt = GridView4.GetRowCellValue(i, "pt").ToString().TrimEnd
                    .pt2 = GridView4.GetRowCellValue(i, "pt2").ToString().TrimEnd
                    .address_pt = GridView4.GetRowCellValue(i, "address_pt").ToString().TrimEnd
                    .address_pt2 = GridView4.GetRowCellValue(i, "address_pt2").ToString().TrimEnd
                    .space_kosong = GridView4.GetRowCellValue(i, "space_kosong").ToString().TrimEnd
                    .bank_charges = GridView4.GetRowCellValue(i, "bank_charges").ToString().TrimEnd
                    .applicant_acct = GridView4.GetRowCellValue(i, "applicant_acct").ToString().TrimEnd
                    .space_kosong2 = GridView4.GetRowCellValue(i, "space_kosong2").ToString().TrimEnd
                    .other = GridView4.GetRowCellValue(i, "other").ToString().TrimEnd
                    .other1 = GridView4.GetRowCellValue(i, "other1").ToString().TrimEnd
                    .other2 = GridView4.GetRowCellValue(i, "other2").ToString().TrimEnd
                    .other3 = GridView4.GetRowCellValue(i, "other3").ToString().TrimEnd

                    Objmizuho.InsertData()
                End With
                ''Objmizuho(Objmizuho)

                ''End If
            Next

            ''If isUpdate = False Then
            ''ObjMizuho.DeleteMizuho()
            'ObjMizuho.InsertData()
            'Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            ''End If

            ''IsClosed = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Async Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            'If ProgBar.Visible = True Then
            '    Throw New Exception("Process already running, Please wait!")
            'End If
            'ProgBar.Visible = True
            'ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataSyncMizuho())
        Catch ex As Exception
            ''ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataSyncTemplate())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Proc_PrintPreview2()
    End Sub

    Private Sub Proc_PrintPreview2()
        Try
            If TabControl1.TabIndex = 3 Then
                If GridView7.RowCount = 0 Then
                    Throw New Exception("Tidak ada data yang di akan print.")
                End If

            Else

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = New DataTable
                Dim date1 As String = ""
                Dim date2 As String = ""
                Invoke(Sub()
                           date1 = DateEdit1.Text
                           date2 = DateEdit2.Text
                       End Sub)

                ds = pay_class.Mizuho(Format(DateEdit1.EditValue, gs_FormatSQLDate), Format(DateEdit2.EditValue, gs_FormatSQLDate))
                dt = ds.Tables("mizuho")

                Dim Laporan As XtraReport4 = New XtraReport4
                With Laporan
                    ''.param1 = date1
                    ''.param2 = date2
                    .DataSource = dt
                End With

                Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                    PrintTool.ShowPreviewDialog()
                    PrintTool.ShowPreview(UserLookAndFeel.Default)
                End Using

            End If
            LoadData2()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadData2()
        Try
            If DateEdit1.Text = "" OrElse DateEdit2.Text = "" Then
                If DateEdit1.Text = "" Then
                    DateEdit1.Focus()
                ElseIf DateEdit2.Text = "" Then
                    DateEdit2.Focus()
                End If
                Throw New Exception("Silahkan pilih tanggal!")
            End If

            Cursor = Cursors.WaitCursor
            Dim dt As New DataTable
            GridControl4.DataSource = dt
            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Async Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            If ProgBar5.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar5.Visible = True
            ProgBar5.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataSyncMizuho())
        Catch ex As Exception
            ProgBar5.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Proc_Excel()
    End Sub

    'Private Sub tsBtn_save_Click(sender As Object, e As EventArgs) Handles tsBtn_save.Click
    '    Try
    '        For i As Integer = 0 To GridView4.RowCount - 1
    '            ''If GridView1.GetRowCellValue(i, "Check") = True Then
    '            Dim Objmizuho As New MizuhoModels
    '            With Objmizuho
    '                .FPNo = _TxtNoTrans.Text.TrimEnd
    '                .No_Invoice = GridView4.GetRowCellValue(i, "invcNbr").ToString().TrimEnd
    '                .Tgl_Invoice = DateTime.Parse(GridView4.GetRowCellValue(i, "invcDate").ToString())
    '                .Jml_Invoice = GridView4.GetRowCellValue(i, "Amount")
    '                .curyid = GridView4.GetRowCellValue(i, "CuryId")
    '                .Ppn = GridView4.GetRowCellValue(i, "Ppn")
    '                .Dpp = GridView4.GetRowCellValue(i, "DPP")
    '                .No_Faktur = GridView4.GetRowCellValue(i, "fp").ToString().TrimEnd
    '                .link_barcode = "1"
    '                .Pph = GridView4.GetRowCellValue(i, "Pph")
    '                .No_Bukti_Potong = GridView4.GetRowCellValue(i, "NBP").ToString().TrimEnd
    '            End With
    '            ''ObjFPTransaction.ObjFPDetails.Add(ObjFPDetails)
    '            ''End If
    '        Next

    '        If isUpdate = False Then
    '            ObjFPTransaction.InsertData()
    '            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
    '        Else
    '            ObjFPTransaction.UpdateData()
    '            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
    '        End If

    '        GridDtl.DataSource = ObjFP.GetDataGridNew()

    '        IsClosed = True
    '        Me.Hide()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '        'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '    End Try
    'End Sub

End Class