Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraEditors.Controls

Public Class frmSalesForecastCalculatedSum
    Dim ObjSales As New clsSalesForecastCalculate
    Dim fdtl_Config As DataTable = Nothing

    Private Sub frmSalesForecastCalculatedSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
        LoadTxtBox()
        ProgBar.Visible = False
    End Sub
    Sub LoadTxtBox()
        FillComboTahun()
        FillComboBulan()
        TxtInvtid.Text = "ALL"
        CmbTahun.SelectedIndex = 0
        CmbBulan.SelectedIndex = 0
        Grid.DataSource = Nothing
    End Sub
    Private Sub FillComboBulan()
        Dim tahun() As String = {"ALL", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "November", "Desember"}
        CmbBulan.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"ALL", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            CmbTahun.Properties.Items.Add(var)
        Next
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Dim path As String
    Private Sub getPath()
        Try
            Dim folderBrowser As New FolderBrowserDialog
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
            If (folderBrowser.ShowDialog() = DialogResult.OK) Then
                path = folderBrowser.SelectedPath
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                Dim save As New SaveFileDialog
                save.Filter = "Excel File|*.xlsx"
                save.Title = "Save an Excel File"
                If save.ShowDialog = DialogResult.OK Then
                    Grid.ExportToXlsx(save.FileName)
                    Process.Start(save.FileName)
                End If
                'getPath()

                'If path <> "" Then
                '    ExcelLib.ExportToExcel(path & "\", Grid, "SalesPrice_")
                '    ShowMessage("File Stored at : " & path)
                'End If
            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub frmSalesForecastCalculatedSum_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CmbTahun.Focus()
    End Sub
    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            'Dim dt As New DataTable
            'dt = fc_class.SP_LoadDataGrid(cmbSite.Text, _cmbYear.Text, _txtItem.Text, _txtCustomer.Text)
            'Grid.DataSource = dt

            If ProgBar.Visible = True Then
                Throw New Exception("Proses already running, Please wait !")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGrid())
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GetDataGrid()
        Try
            Dim Tahun As String = ""
            Dim Bulan As String = ""
            Invoke(Sub()
                       Tahun = CmbTahun.Text
                       Bulan = CmbBulan.Text
                       Dim dt As New DataTable
                       dt = ObjSales.GetCalculatedForecastSummary(Tahun, Bulan, TxtInvtid.Text)
                       setDataSource(dt)
                       If dt.Rows.Count > 0 Then
                           FormatGridView(GridView1)
                           GridView1.BestFitColumns()
                           GridView1.Columns("Qty Forecast").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                           GridView1.Columns("Qty Forecast").DisplayFormat.FormatString = gs_FormatDecimal1
                           GridView1.Columns("Qty PO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                           GridView1.Columns("Qty PO").DisplayFormat.FormatString = gs_FormatDecimal1
                       End If
                   End Sub)

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
            Throw ex
        End Try

    End Sub

    Private Sub TxtInvtid_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtInvtid.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjSales.GetInventoryID
            ls_OldKode = TxtInvtid.Text.Trim
            ls_Judul = "Inventory ID"


            dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            dtSearch.Rows(0).Item(0) = "ALL"
            dtSearch.Rows(0).Item(1) = "ALL"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                If ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    TxtInvtid.Text = ls_Kode
                End If
            End If

            lF_SearchData.Close()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
