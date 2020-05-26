Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmKanbanInternal
    Dim dtGrid As DataTable
    Dim Obj As New KanbanInternal
    Dim ObjDet As New KanbanInternalDetails

    Dim PrintTool As ReportPrintTool

    Dim ds As DataSet
    Dim dt As DataTable
    Dim dtTemp As DataTable
    Dim dtTemp1 As DataTable
    Private Sub frmKanbanInternal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = New DataTable
            dtGrid = Obj.GetAllDataGridCKR()
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
        Dim ls_Judul As String = "Kanban Internal"
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
                    ObjDet = New KanbanInternalDetails
                    With ObjDet
                        .Customer = If(row("Cust") Is DBNull.Value, "", row("Cust").ToString())
                        .DeliveryDate = If(row("Delivery Date") Is DBNull.Value, DateTime.Today, Convert.ToDateTime(row("Delivery Date")))
                        .InventoryId = If(row("Inventori ID") Is DBNull.Value, "", row("Inventori ID").ToString())
                        .ItemNo = If(row("Item No") Is DBNull.Value, "", row("Item No").ToString())
                        .NoPO = If(row("No PO") Is DBNull.Value, "", row("No PO").ToString())
                        .NoUrut = If(row("No Urut") Is DBNull.Value, 0, Convert.ToInt32(row("No Urut").ToString()))
                        .OrderDate = If(row("Order Date") Is DBNull.Value, DateTime.Today, Convert.ToDateTime(row("Order Date")))
                        .PalletizeMark = If(row("Palletize Mark") Is DBNull.Value, "", row("Palletize Mark").ToString())
                        .PartName = If(row("Part Name") Is DBNull.Value, "", Convert.ToString(row("Part Name")))
                        .PartNo = If(row("Part No") Is DBNull.Value, "", Convert.ToString(row("Part No")))
                        .PartNoLabel = If(row("Part No Label") Is DBNull.Value, "", row("Part No Label").ToString())
                        .PONumber = If(row("PO Number") Is DBNull.Value, "", row("PO Number").ToString())
                        .QtyOrder = If(row("Qty Order") Is DBNull.Value, 0, Convert.ToInt32(row("Qty Order")))
                        .RackLabel = If(row("Rack Label") Is DBNull.Value, "", row("Rack Label").ToString())
                        .RackPart = If(row("Rack Part") Is DBNull.Value, "", row("Rack Part").ToString())
                        .RH_LH = If(row("RH/LH") Is DBNull.Value, "", row("RH/LH").ToString())
                        .Type = If(row("Type") Is DBNull.Value, "", row("Type").ToString())
                        .KanbanID = If(row("VENDOR CODE/KBN ID") Is DBNull.Value, "", row("VENDOR CODE/KBN ID").ToString())
                        .UploadedBy = gh_Common.Username
                    End With
                    Obj.ObjDetails.Add(ObjDet)
                Next
                Obj.InsertData()
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_PrintPreview()
        Try
            'Dim f As New FrmLookUpBarcode
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
            'Dim _param As ArrayList = New ArrayList()
            TempTable()

            For i As Integer = 0 To GridView1.RowCount - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = Trim(GridView1.GetRowCellValue(i, "Id") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(GridView1.GetRowCellValue(i, "NoUrut") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(GridView1.GetRowCellValue(i, "Customer") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(GridView1.GetRowCellValue(i, "PONumber") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Trim(GridView1.GetRowCellValue(i, "InventoryId") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Trim(GridView1.GetRowCellValue(i, "PartName") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = Trim(GridView1.GetRowCellValue(i, "PartNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = Trim(GridView1.GetRowCellValue(i, "Type") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(8) = Trim(GridView1.GetRowCellValue(i, "Kombinasi") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(9) = Trim(GridView1.GetRowCellValue(i, "OrderDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(10) = Trim(GridView1.GetRowCellValue(i, "DelDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(11) = Trim(GridView1.GetRowCellValue(i, "QtyOrder") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(12) = Trim(GridView1.GetRowCellValue(i, "RH_LH") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(13) = Trim(GridView1.GetRowCellValue(i, "PalletizeMark") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(14) = Trim(GridView1.GetRowCellValue(i, "PartNoLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(15) = Trim(GridView1.GetRowCellValue(i, "RackLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(16) = Trim(GridView1.GetRowCellValue(i, "RackPart") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(17) = Trim(GridView1.GetRowCellValue(i, "ItemNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(18) = Trim(GridView1.GetRowCellValue(i, "Warna") & "")
            Next

            'ds = New DataSet
            'ds = Obj.PrintQRCOdeCkr()

            'dt = New DataTable
            'dt = ds.Tables("KanbanInternal")

            If dtTemp.Rows.Count = 0 Then
                Throw New Exception("Tidak ada data yang di print !")
                'Else
                '    For i As Integer = 0 To dt.Rows.Count - 1
                '        _param.Add(dt.Rows(i)("Cust").ToString())
                '    Next
            End If
            Dim groups = From j In dtTemp
                         Group By x = New With {
                                Key .Cust = j.Field(Of String)("Cust"),
                                Key .PONumber = j.Field(Of String)("PONumber"),
                                Key .InventoryId = j.Field(Of String)("InventoryId"),
                                Key .PartName = j.Field(Of String)("PartName"),
                                Key .PartNo = j.Field(Of String)("PartNo"),
                                Key .Type = j.Field(Of String)("Type"),
                                Key .NoPO = j.Field(Of String)("NoPO"),
                                Key .OrderDate = j.Field(Of String)("OrderDate"),
                                Key .DelDate = j.Field(Of String)("DelDate"),
                                Key .RH_LH = j.Field(Of String)("RH_LH"),
                                Key .PalletizeMark = j.Field(Of String)("PalletizeMark"),
                                Key .PartNoLabel = j.Field(Of String)("PartNoLabel"),
                                Key .RackLabel = j.Field(Of String)("RackLabel"),
                                Key .RackPart = j.Field(Of String)("RackPart"),
                                Key .Warna = j.Field(Of String)("Warna")} Into g = Group
                         Select New With {
                            x.Cust,
                            x.PONumber,
                            x.InventoryId,
                            x.PartName,
                             x.PartNo,
                             x.Type,
                             x.NoPO,
                             x.OrderDate,
                             x.DelDate,
                             .QtyOrder = g.Sum(Function(dr) dr.Field(Of Integer)("QtyOrder")),
                             x.RH_LH,
                             x.PalletizeMark,
                             x.PartNoLabel,
                             x.RackLabel,
                             x.RackPart,
                             x.Warna
                        }

            'Dim test2 = dtTemp.AsEnumerable().GroupBy(Function(row) row.Item("PONumber")).Select(Function(group) New With {.Grp = group.Key, .Sum = group.Sum(Function(r) Double.Parse(r.Item("QtyOrder").ToString()))})

            TempTable1()
            Dim ObjKanban As New KanbanInternal
            Dim urut As Integer = 1
            For Each item In groups
                Dim dr As DataRow = dtTemp1.NewRow()
                dr("NoUrut") = urut
                dr("Cust") = item.Cust
                dr("PONumber") = item.PONumber
                dr("InventoryId") = item.InventoryId
                dr("PartName") = item.PartName
                dr("PartNo") = item.PartNo
                dr("Type") = item.Type
                dr("NoPO") = item.NoPO
                dr("OrderDate") = item.OrderDate
                dr("DelDate") = item.DelDate
                dr("QtyOrder") = item.QtyOrder
                dr("RH_LH") = item.RH_LH
                dr("PalletizeMark") = item.PalletizeMark
                dr("PartNoLabel") = item.PartNoLabel
                dr("RackLabel") = item.RackLabel
                dr("RackPart") = item.RackPart
                dr("Warna") = item.Warna
                dr("QRCode") = item.InventoryId & item.PartNoLabel
                dtTemp1.Rows.Add(dr)
                urut = urut + 1
            Next

            'Dim Laporan As New PrintKanbanInternalTes()
            Dim Laporan As New PrintKanbanInternal_new()
            With Laporan
                '.param1 = _param
                .DataSource = dtTemp1
                AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
            End With

            PrintTool = New ReportPrintTool(Laporan)
            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            'PrintTool.ShowPreviewDialog()
            PrintTool.ShowPreview(UserLookAndFeel.Default)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub PrintingSystem_EndPrint(sender As Object, e As EventArgs)
        Try
            For i As Integer = 0 To dtTemp.Rows.Count - 1
                Obj = New KanbanInternal
                Obj.UpdateData(dtTemp.Rows(i)("Id"))
                PrintTool.ClosePreview()
                tsBtn_refresh.PerformClick()

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Id", GetType(Integer))
        dtTemp.Columns.Add("NoUrut", GetType(Integer))
        dtTemp.Columns.Add("Cust", GetType(String))
        dtTemp.Columns.Add("PONumber", GetType(String))
        dtTemp.Columns.Add("InventoryId", GetType(String))
        dtTemp.Columns.Add("PartName", GetType(String))
        dtTemp.Columns.Add("PartNo", GetType(String))
        dtTemp.Columns.Add("Type", GetType(String))
        dtTemp.Columns.Add("NoPO", GetType(String))
        dtTemp.Columns.Add("OrderDate", GetType(String))
        dtTemp.Columns.Add("DelDate", GetType(String))
        dtTemp.Columns.Add("QtyOrder", GetType(Integer))
        dtTemp.Columns.Add("RH_LH", GetType(String))
        dtTemp.Columns.Add("PalletizeMark", GetType(String))
        dtTemp.Columns.Add("PartNoLabel", GetType(String))
        dtTemp.Columns.Add("RackLabel", GetType(String))
        dtTemp.Columns.Add("RackPart", GetType(String))
        dtTemp.Columns.Add("ItemNo", GetType(String))
        dtTemp.Columns.Add("Warna", GetType(String))
        dtTemp.Clear()
    End Sub

    Private Sub TempTable1()
        dtTemp1 = New DataTable
        dtTemp1.Columns.Add("Id", GetType(Integer))
        dtTemp1.Columns.Add("NoUrut", GetType(Integer))
        dtTemp1.Columns.Add("Cust", GetType(String))
        dtTemp1.Columns.Add("PONumber", GetType(String))
        dtTemp1.Columns.Add("InventoryId", GetType(String))
        dtTemp1.Columns.Add("PartName", GetType(String))
        dtTemp1.Columns.Add("PartNo", GetType(String))
        dtTemp1.Columns.Add("Type", GetType(String))
        dtTemp1.Columns.Add("NoPO", GetType(String))
        dtTemp1.Columns.Add("OrderDate", GetType(String))
        dtTemp1.Columns.Add("DelDate", GetType(String))
        dtTemp1.Columns.Add("QtyOrder", GetType(Integer))
        dtTemp1.Columns.Add("RH_LH", GetType(String))
        dtTemp1.Columns.Add("PalletizeMark", GetType(String))
        dtTemp1.Columns.Add("PartNoLabel", GetType(String))
        dtTemp1.Columns.Add("RackLabel", GetType(String))
        dtTemp1.Columns.Add("RackPart", GetType(String))
        dtTemp1.Columns.Add("ItemNo", GetType(String))
        dtTemp1.Columns.Add("Warna", GetType(String))
        dtTemp1.Columns.Add("QRCode", GetType(String))
        dtTemp1.Clear()
    End Sub
End Class
