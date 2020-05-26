Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Public Class frmReport_Sales_Forecast_Price
    Dim fc_class As New clsReport
    Dim fdtl_Config As DataTable = Nothing

    Private Sub frmReport_Sales_Forecast_Pricet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False)
        LoadTxtBox()
        ProgBar.Visible = False
    End Sub
    Sub LoadTxtBox()
        FillComboTahun()

        cmbSite.SelectedIndex = 0
        _cmbYear.SelectedIndex = 0
        _txtItem.Text = "ALL"
        _txtCustomer.Text = "ALL"
        _cmbYear.Focus()

        Grid.DataSource = Nothing
    End Sub

    Private Sub FillComboTahun()
        Try
            _cmbYear.Items.Clear()
            Dim tahun() As String = {"ALL", (DateTime.Today.Year + 1).ToString, DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString}
            _cmbYear.Items.Clear()
            For Each var As String In tahun
                _cmbYear.Items.Add(var)
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Public Overrides Sub Proc_PrintPreview()
        Try
            PrintDokumen(True)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

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
                    'Process.Start(save.FileName)
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

    Public Shared Sub SetGridViewSortState(ByVal dgv As DataGridView, ByVal sortMode As DataGridViewColumnSortMode)
        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = sortMode
        Next
    End Sub

    Private Sub cmbSite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSite.KeyPress, _cmbYear.KeyPress
        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If tmp.KeyChar = ChrW(Keys.Enter) Then
        'Else
        '    e.Handled = True
        'End If
    End Sub

    Private Sub frmReport_Sales_Forecast_Price_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _cmbYear.Focus()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click, btnCari1.Click
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If sender.Name = btnCari.Name Then
                dtSearch = fc_class.getItem
                ls_OldKode = _txtItem.Text.Trim
                ls_Judul = "Part"
            ElseIf sender.Name = btnCari1.Name Then
                dtSearch = fc_class.getCustomer
                ls_OldKode = _txtItem.Text.Trim
                ls_Judul = "Item"
            End If

            dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            dtSearch.Rows(0).Item(0) = "ALL"
            dtSearch.Rows(0).Item(1) = "ALL"

            Dim lF_SearchData As FrmSystem_Filter
            lF_SearchData = New FrmSystem_Filter(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                If sender.Name = btnCari.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _txtItem.Text = ls_Kode
                    _txtItem.Focus()
                End If
                If sender.Name = btnCari1.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _txtCustomer.Text = ls_Kode
                End If
            End If

            lF_SearchData.Close()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            'Dim dt As New DataTable
            'dt = fc_class.SF_LoadDataGrid(cmbSite.Text, _cmbYear.Text, _txtItem.Text, _txtCustomer.Text)
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
            Dim strSite As String = ""
            Dim strYear As String = ""
            Dim strItem As String = ""
            Dim strCust As String = ""
            Invoke(Sub()
                       strSite = cmbSite.Text
                       strYear = _cmbYear.Text
                       strItem = _txtItem.Text
                       strCust = _txtCustomer.Text
                   End Sub)
            Dim dt As New DataTable
            dt = fc_class.Sales_ForecastPrice_report_DataGrid(strSite, strYear, strItem, strCust)
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
            Throw ex
        End Try

    End Sub

    Public Sub PrintDokumen(Optional ByVal fb_Preview As Boolean = False)

    End Sub
End Class
