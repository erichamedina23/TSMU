Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmBarcodeGenerate
    Dim dtGrid As DataTable
    Dim Obj As New BarcodeGenerate
    Dim ObjDet As New BarcodeDet
    Private Sub frmBarcodeGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            If gh_Common.Site.ToLower = "tng" Then
                dtGrid = Obj.GetAllDataGrid()
            Else
                dtGrid = Obj.GetAllDataGridCKR()
            End If

            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Barcode"
        Dim Bulan As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcelBarcode
        frmExcel = New FrmSystemExcelBarcode(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        Try
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable
            'Exit Sub
            If dtFilter.Rows.Count > 0 Then

                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")

                Obj.ObjDetails.Clear()
                For Each row As DataRow In dtFilter.Rows
                    ObjDet = New BarcodeDet
                    With ObjDet
                        .KodePart = If(row("KODE PART") Is DBNull.Value, "", row("KODE PART").ToString)
                        .CustomerID = If(row("CUST") Is DBNull.Value, "", row("CUST").ToString())
                        .CustomerName = If(row("CUST LENGKAP") Is DBNull.Value, "", row("CUST LENGKAP").ToString())
                        .InventoryID = If(row("INVENTORY ID") Is DBNull.Value, "", row("INVENTORY ID").ToString())
                        .SFGFG = If(row("SFG/FG") Is DBNull.Value, "", row("SFG/FG").ToString())
                        .PartName = If(row("PART NAME") Is DBNull.Value, "", row("PART NAME").ToString())
                        .PartNo = If(row("NO PART") Is DBNull.Value, "", row("NO PART").ToString())
                        .Colour = If(row("COLOUR") Is DBNull.Value, "", row("COLOUR").ToString())
                        .JobNo = If(row("JOB NO") Is DBNull.Value, "", row("JOB NO").ToString())
                        .QtyLabel = If(row("QTY LABEL") Is DBNull.Value, 0, Convert.ToInt32(row("QTY LABEL")))
                        .WarnaPasscard = If(row("WARNA PASCARD") Is DBNull.Value, "", row("WARNA PASCARD").ToString())
                        .LokalExport = If(row("LOKAL / EXPORT") Is DBNull.Value, "", row("LOKAL / EXPORT").ToString())
                        .KodeWarna = If(row("KODE WARNA") Is DBNull.Value, "", row("KODE WARNA").ToString())
                        .TglUpload = DateTime.Now
                        .UploadBy = gh_Common.Username
                        .Site = gh_Common.Site
                    End With
                    Obj.ObjDetails.Add(ObjDet)
                Next
                Obj.InsertData()
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Public Overrides Sub Proc_PrintPreview()
        Try
            Dim f As New FrmLookUpBarcode
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'If GridView1.RowCount = 0 Then
            '    Throw New Exception("Tidak ada data yang di akan print.")
            'End If

            'Dim ds As DataSet = New DataSet
            'Dim dt As DataTable = New DataTable
            'ds = Obj.PrintQRCOde()

            'dt = ds.Tables("QRCode")

            'Dim Laporan As Testing = New Testing
            'With Laporan
            '    '.param1 = No
            '    '.param2 = No
            '    .DataSource = dt
            '    '.DataMember = ds.Tables("PrintPO").TableName
            'End With

            'Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
            '    PrintTool.ShowPreviewDialog()
            '    PrintTool.ShowPreview(UserLookAndFeel.Default)
            'End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Data Kosong !")
        End If
    End Sub

    Private Sub Grid_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub
End Class
