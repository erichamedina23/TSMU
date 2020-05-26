Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmUploadKanbanAdm
    Dim dtGrid As DataTable
    Dim Obj As New KanbanAdmModel
    Private Sub frmUploadKanbanAdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            dtGrid = Obj.GetAllDataGrid()
            Grid.DataSource = dtGrid

            If GridView1.RowCount > 0 Then
                With GridView1
                    .BestFitColumns()
                    .Columns(0).Visible = False
                    .FixedLineWidth = 2
                    .Columns(11).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    .Columns(12).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                End With
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

            If dtFilter.Rows.Count > 0 Then

                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    Try
                        With Obj
                            If dtFilter.Rows(i)("Plant Code") Is DBNull.Value OrElse dtFilter.Rows(i)("Plant Code").ToString = "" Then
                                .PlantCode = ""
                            Else
                                .PlantCode = dtFilter.Rows(i)("Plant Code").ToString
                            End If
                            If dtFilter.Rows(i)("Shop Code") Is DBNull.Value OrElse dtFilter.Rows(i)("Shop Code").ToString = "" Then
                                .ShopCode = ""
                            Else
                                .ShopCode = dtFilter.Rows(i)("Shop Code").ToString
                            End If
                            If dtFilter.Rows(i)("Part Category") Is DBNull.Value OrElse dtFilter.Rows(i)("Part Category").ToString = "" Then
                                .PartCategory = ""
                            Else
                                .PartCategory = dtFilter.Rows(i)("Part Category").ToString
                            End If
                            If dtFilter.Rows(i)("Route") Is DBNull.Value OrElse dtFilter.Rows(i)("Route").ToString = "" Then
                                .Route = ""
                            Else
                                .Route = dtFilter.Rows(i)("Route").ToString
                            End If

                            If dtFilter.Rows(i)("LP") Is DBNull.Value OrElse dtFilter.Rows(i)("LP").ToString = "" Then
                                .LP = ""
                            Else
                                .LP = dtFilter.Rows(i)("LP").ToString
                            End If
                            If dtFilter.Rows(i)("Trip") Is DBNull.Value OrElse dtFilter.Rows(i)("Trip").ToString = "" Then
                                .Lane = ""
                            Else
                                .Lane = dtFilter.Rows(i)("Trip").ToString
                            End If
                            If dtFilter.Rows(i)("Vendor Code") Is DBNull.Value OrElse dtFilter.Rows(i)("Vendor Code").ToString = "" Then
                                .VendorCode = ""
                            Else
                                .VendorCode = dtFilter.Rows(i)("Vendor Code").ToString
                            End If
                            If dtFilter.Rows(i)("Vendor Alias") Is DBNull.Value OrElse dtFilter.Rows(i)("Vendor Alias").ToString = "" Then
                                .VendorAlias = ""
                            Else
                                .VendorAlias = dtFilter.Rows(i)("Vendor Alias").ToString
                            End If

                            If dtFilter.Rows(i)("Vendor Site") Is DBNull.Value OrElse dtFilter.Rows(i)("Vendor Site").ToString = "" Then
                                .VendorSite = ""
                            Else
                                .VendorSite = dtFilter.Rows(i)("Vendor Site").ToString
                            End If
                            If dtFilter.Rows(i)("Vendor Site Alias") Is DBNull.Value OrElse dtFilter.Rows(i)("Vendor Site Alias").ToString = "" Then
                                .VendorSiteAlias = ""
                            Else
                                .VendorSiteAlias = dtFilter.Rows(i)("Vendor Site Alias").ToString
                            End If
                            If dtFilter.Rows(i)("Order No").ToString = "" OrElse dtFilter.Rows(i)("Order No") Is DBNull.Value Then
                                .OrderNo = ""
                            Else
                                .OrderNo = dtFilter.Rows(i)("Order No").ToString
                            End If

                            If dtFilter.Rows(i)("PO Number").ToString = "" OrElse dtFilter.Rows(i)("PO Number") Is DBNull.Value Then
                                .PONo = ""
                            Else
                                .PONo = dtFilter.Rows(i)("PO Number").ToString
                            End If

                            If dtFilter.Rows(i)("Calc# Date").ToString = "" OrElse dtFilter.Rows(i)("Calc# Date") Is DBNull.Value Then
                                .CalcDate = ""
                            Else
                                .CalcDate = Convert.ToDateTime(dtFilter.Rows(i)("Calc# Date"))
                            End If
                            If dtFilter.Rows(i)("Order Date").ToString = "" OrElse dtFilter.Rows(i)("Order Date") Is DBNull.Value Then
                                .OrderDate = ""
                            Else
                                .OrderDate = Convert.ToDateTime(dtFilter.Rows(i)("Order Date"))
                            End If
                            If dtFilter.Rows(i)("Order Time").ToString = "" OrElse dtFilter.Rows(i)("Order Time") Is DBNull.Value Then
                                .OrderTime = ""
                            Else
                                .OrderTime = dtFilter.Rows(i)("Order Time")
                            End If
                            If dtFilter.Rows(i)("Del# Date").ToString = "" OrElse dtFilter.Rows(i)("Del# Date") Is DBNull.Value Then
                                .DelDate = ""
                            Else
                                .DelDate = Convert.ToDateTime(dtFilter.Rows(i)("Del# Date"))
                            End If
                            If dtFilter.Rows(i)("Del# Time").ToString = "" OrElse dtFilter.Rows(i)("Del# Time") Is DBNull.Value Then
                                .DelTime = ""
                            Else
                                .DelTime = dtFilter.Rows(i)("Del# Time")
                            End If

                            If dtFilter.Rows(i)("Del# Cycle").ToString = "" OrElse dtFilter.Rows(i)("Del# Cycle") Is DBNull.Value Then
                                .DelCycle = 0
                            Else
                                .DelCycle = Integer.Parse(dtFilter.Rows(i)("Del# Cycle").ToString)
                            End If
                            If dtFilter.Rows(i)("Doc No").ToString = "" OrElse dtFilter.Rows(i)("Doc No") Is DBNull.Value Then
                                .DocNo = ""
                            Else
                                .DocNo = dtFilter.Rows(i)("Doc No")
                            End If
                            '=======
                            If dtFilter.Rows(i)("Rec Status") Is DBNull.Value OrElse dtFilter.Rows(i)("Rec Status").ToString = "" Then
                                .RecStatus = ""
                            Else
                                .RecStatus = dtFilter.Rows(i)("Rec Status").ToString
                            End If
                            If dtFilter.Rows(i)("DN Type") Is DBNull.Value OrElse dtFilter.Rows(i)("DN Type").ToString = "" Then
                                .DNType = ""
                            Else
                                .DNType = dtFilter.Rows(i)("DN Type").ToString
                            End If
                            If dtFilter.Rows(i)("Part No") Is DBNull.Value OrElse dtFilter.Rows(i)("Part No").ToString = "" Then
                                .PartNo = ""
                            Else
                                .PartNo = dtFilter.Rows(i)("Part No").ToString
                            End If
                            If dtFilter.Rows(i)("Part Name") Is DBNull.Value OrElse dtFilter.Rows(i)("Part Name").ToString = "" Then
                                .PartName = ""
                            Else
                                .PartName = dtFilter.Rows(i)("Part Name").ToString
                            End If

                            If dtFilter.Rows(i)("Job No") Is DBNull.Value OrElse dtFilter.Rows(i)("Job No").ToString = "" Then
                                .JobNo = ""
                            Else
                                .JobNo = dtFilter.Rows(i)("Job No").ToString
                            End If
                            If dtFilter.Rows(i)("Lane") Is DBNull.Value OrElse dtFilter.Rows(i)("Lane").ToString = "" Then
                                .Lane = 0
                            Else
                                .Lane = Integer.Parse(dtFilter.Rows(i)("Lane").ToString)
                            End If
                            If dtFilter.Rows(i)("Qty/Kbn") Is DBNull.Value OrElse dtFilter.Rows(i)("Qty/Kbn").ToString = "" Then
                                .QtyKbn = 0
                            Else
                                .QtyKbn = Integer.Parse(dtFilter.Rows(i)("Qty/Kbn").ToString)
                            End If
                            If dtFilter.Rows(i)("Order(Kbn)") Is DBNull.Value OrElse dtFilter.Rows(i)("Order(Kbn)").ToString = "" Then
                                .OrderKbn = 0
                            Else
                                .OrderKbn = Integer.Parse(dtFilter.Rows(i)("Order(Kbn)").ToString)
                            End If

                            If dtFilter.Rows(i)("Order(Pcs)") Is DBNull.Value OrElse dtFilter.Rows(i)("Order(Pcs)").ToString = "" Then
                                .OrderPcs = 0
                            Else
                                .OrderPcs = Integer.Parse(dtFilter.Rows(i)("Order(Pcs)").ToString)
                            End If
                            If dtFilter.Rows(i)("Qty Receive") Is DBNull.Value OrElse dtFilter.Rows(i)("Qty Receive").ToString = "" Then
                                .QtyReceive = 0
                            Else
                                .QtyReceive = Integer.Parse(dtFilter.Rows(i)("Qty Receive").ToString)
                            End If
                            If dtFilter.Rows(i)("Qty Balance").ToString = "" OrElse dtFilter.Rows(i)("Qty Balance") Is DBNull.Value Then
                                .QtyBalance = 0
                            Else
                                .QtyBalance = Integer.Parse(dtFilter.Rows(i)("Qty Balance").ToString)
                            End If

                            If dtFilter.Rows(i)("Cancel Status").ToString = "" OrElse dtFilter.Rows(i)("Cancel Status") Is DBNull.Value Then
                                .CancelStatus = ""
                            Else
                                .CancelStatus = dtFilter.Rows(i)("Cancel Status").ToString
                            End If

                            If dtFilter.Rows(i)("Remark").ToString = "" OrElse dtFilter.Rows(i)("Remark") Is DBNull.Value Then
                                .Remark = ""
                            Else
                                .Remark = dtFilter.Rows(i)("Remark").ToString
                            End If

                            .UploadedDate = DateTime.Now
                            .UploadedBy = gh_Common.Username
                            .InsertData()

                        End With

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Console.WriteLine(ex.Message)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        Continue For
                    End Try
                Next

                Dim dtKanban As New DataTable
                If gh_Common.Site.ToLower = "tng" Then
                    dtKanban = Obj.GetKanban
                    For i As Integer = 0 To dtKanban.Rows.Count - 1
                        Try
                            Dim Tgl As String = dtKanban.Rows(i)(0).ToString
                            Dim Cycle As Integer = Convert.ToInt32(dtKanban.Rows(i)(1))
                            Dim Kanban As Integer = Convert.ToInt32(dtKanban.Rows(i)(2))
                            Dim shopCode As String = Convert.ToString(dtKanban.Rows(i)(3))

                            Dim IsExist As Boolean = Obj.IsKanbanExist(Tgl, Cycle, shopCode)
                            If Not IsExist Then
                                '    Obj.UpdateKanbanSum(Tgl, Cycle, Kanban)
                                'Else
                                Obj.SaveKanbanSum(Tgl, Cycle, Kanban, shopCode)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            Continue For
                        End Try
                    Next
                Else
                    dtKanban = Obj.GetKanbanCKR
                    For i As Integer = 0 To dtKanban.Rows.Count - 1
                        Try
                            Dim Tgl As String = dtKanban.Rows(i)(0).ToString
                            Dim Cycle As Integer = Convert.ToInt32(dtKanban.Rows(i)(1))
                            Dim Kanban As Integer = Convert.ToInt32(dtKanban.Rows(i)(3))
                            Dim Remark As String = Convert.ToString(dtKanban.Rows(i)(2))
                            Dim TotDN As Integer = Convert.ToInt32(dtKanban.Rows(i)(4))
                            Dim shopCode As String = Convert.ToString(dtKanban.Rows(i)(5))
                            Dim plantCode As String = Convert.ToString(dtKanban.Rows(i)(6))

                            Dim IsExist As Boolean = Obj.IsKanbanExistCkr(Tgl, Cycle, Remark, shopCode)
                            If Not IsExist Then
                                '    Obj.UpdateKanbanSum(Tgl, Cycle, Kanban)
                                'Else
                                Obj.SaveKanbanSumCKR(Tgl, Cycle, Kanban, Remark, TotDN, shopCode, plantCode)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            Continue For
                        End Try
                    Next
                End If
                'dtKanban = Obj.GetKanban

                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub
    'Public Overrides Sub Proc_PrintPreview()
    '    Try

    '        Dim ds As DataSet = New DataSet
    '        Dim dt As DataTable = New DataTable
    '        ds = SuratJalan.PrintPO(IIf(_BtnCust.Text = "", "ALL", _BtnCust.Text), Format(_TglSJFrom.EditValue, gs_FormatSQLDate), Format(_TglSJTo.EditValue, gs_FormatSQLDate), _TxtLokasi.Text, Format(_TxtTglKirimFrom.EditValue, gs_FormatSQLDate), Format(_TglKirimTo.EditValue, gs_FormatSQLDate))

    '        dt = ds.Tables("PrintPO")

    '        Dim Laporan As Testing = New Testing
    '        With Laporan
    '            .DataSource = dt
    '            '.DataMember = ds.Tables("PrintPO").TableName
    '        End With

    '        Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
    '            PrintTool.ShowPreviewDialog()
    '            PrintTool.ShowPreview(UserLookAndFeel.Default)
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub

    Private Sub CMSExport_Click(sender As Object, e As EventArgs) Handles CMSExport.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Grid Kosong !")
        End If
    End Sub
End Class
