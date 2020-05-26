Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Public Class Frm_Rpt_ViewPayment
    Dim pay_class As New Cls_Report
    Dim pay_Config As DataTable = Nothing
    Private Sub Frm_Rpt_ViewPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
        Init()
        ProgBar.Visible = False
        Progbar_sup.Visible = False
    End Sub

    Sub LoadTxtBox()
        If TabControl1.SelectedTab Is TabPage1 Then
            If ProgBar.Visible = True Then
                MsgBox("Proses Loading Data masih berjalan!")
                Exit Sub
            End If
        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            If Progbar_sup.Visible = True Then
                MsgBox("Proses Loading Data masih berjalan!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Proc_Refresh()
        Try
            Call LoadTxtBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Proc_Excel()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                If GridView4.RowCount > 0 Then
                    SaveToExcel(GridControl3)
                    MsgBox("Data Sudah Berhasil Di Export.")
                Else
                    MsgBox("Grid Kosong!")
                End If

            ElseIf TabControl1.SelectedTab Is TabPage3 Then
                If GridView2.RowCount > 0 Then
                    SaveToExcel(GridControl1)
                    MsgBox("Data Sudah Berhasil Di Export.")
                Else
                    MsgBox("Grid Kosong!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
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

    Public Shared Sub SetGridViewSortState(ByVal dgv As DataGridView, ByVal sortMode As DataGridViewColumnSortMode)
        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = sortMode
        Next
    End Sub

    Private Sub cmbsupplier()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay_class.cmbsupplier()
            cmb_supplier.DataSource = dtgrid
            cmb_supplier.ValueMember = "Name"
            cmb_supplier.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Init()
        GridControl3.DataSource = Nothing
        GridControl1.DataSource = Nothing
    End Sub

    Private Sub GetDataGrid()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewPayment(date1, date2)
        setDataSource(dt, GridControl3)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    Private Sub GetDataGridSup()
        Dim datesup1 As String = ""
        Dim datesup2 As String = ""
        Dim suppliername As String = ""

        Invoke(Sub()
                   datesup1 = DateEdit1.Text
                   datesup2 = DateEdit2.Text
                   suppliername = cmb_supplier.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewPaymentSup(datesup1, datesup2, suppliername)
        setDataSource(dt, GridControl1)
        Invoke(Sub()
                   Progbar_sup.Visible = False
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

    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xls"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXls(save.FileName)
        End If
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

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGrid())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Async Sub btnLoad_sup_Click(sender As Object, e As EventArgs) Handles btnLoad_sup.Click
        Try
            If Progbar_sup.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            Progbar_sup.Visible = True
            Progbar_sup.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridSup())
        Catch ex As Exception
            Progbar_sup.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub cmb_supplier_DropDown(sender As Object, e As EventArgs) Handles cmb_supplier.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay_class.cmbsupplier()
            cmb_supplier.DataSource = dtgrid
            cmb_supplier.ValueMember = "Name"
            cmb_supplier.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub

End Class