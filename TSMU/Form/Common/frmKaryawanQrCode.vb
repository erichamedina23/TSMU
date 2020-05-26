Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmKaryawanQrCode
    Dim dtGrid As DataTable
    Dim Obj As New KaryawanModel
    Private Sub frmKaryawanQrCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = New DataTable
            dtGrid = Obj.GetDataGrid()
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
        Dim ls_Judul As String = "Karyawan"
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

                For Each row As DataRow In dtFilter.Rows
                    Try
                        Obj = New KaryawanModel
                        With Obj
                            .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString)
                            .NIK = If(row("NIK") Is DBNull.Value, "", row("NIK").ToString())
                            .NoAnggota = If(row("No Anggota") Is DBNull.Value, "", row("No Anggota").ToString())
                            .Nama = If(row("Nama") Is DBNull.Value, "", row("Nama").ToString())
                            .Seksi = If(row("Seksi") Is DBNull.Value, "", row("Seksi").ToString())
                        End With
                        Obj.Insert()
                    Catch ex As Exception
                        Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        Continue For
                    End Try
                Next
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
        End Try
    End Sub
    Dim dtTemp As DataTable
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Site", GetType(String))
        dtTemp.Columns.Add("NIK", GetType(String))
        dtTemp.Columns.Add("NoAnggota", GetType(String))
        dtTemp.Columns.Add("Nama", GetType(String))
        dtTemp.Columns.Add("Seksi", GetType(String))
        dtTemp.Clear()
    End Sub
    Public Overrides Sub Proc_PrintPreview()
        Try
            'TempTable()
            Dim dtR As New dsLaporan.KarayawanDtDataTable
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "NoAnggota") Is DBNull.Value OrElse GridView1.GetRowCellValue(i, "NoAnggota").ToString = "" Then
                Else
                    dtR.Rows.Add()
                    dtR.Rows(dtR.Rows.Count - 1).Item(0) = Trim(GridView1.GetRowCellValue(i, "Site") & "")
                    dtR.Rows(dtR.Rows.Count - 1).Item(1) = Trim(GridView1.GetRowCellValue(i, "NIK") & "")
                    dtR.Rows(dtR.Rows.Count - 1).Item(2) = Trim(GridView1.GetRowCellValue(i, "NoAnggota") & "")
                    dtR.Rows(dtR.Rows.Count - 1).Item(3) = Trim(GridView1.GetRowCellValue(i, "Nama") & "")
                    dtR.Rows(dtR.Rows.Count - 1).Item(4) = Trim(GridView1.GetRowCellValue(i, "Seksi") & "")
                End If
            Next
            If dtR.Rows.Count = 0 Then
                Throw New Exception("Tidak ada data yang di print !")
            End If

            'Dim ds As DataSet = New DataSet
            'Dim dt As DataTable = New DataTable
            'ds = Obj.PrintQRCOde()

            'dt = ds.Tables("QRCode")


            Dim Laporan As New QRKaryawan
            With Laporan
                '.param1 = No
                '.param2 = No
                .DataSource = dtR
                '.DataMember = ds.Tables("PrintPO").TableName
            End With

            Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                PrintTool.ShowPreviewDialog()
                PrintTool.ShowPreview(UserLookAndFeel.Default)
            End Using
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
