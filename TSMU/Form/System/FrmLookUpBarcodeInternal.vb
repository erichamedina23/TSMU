Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI

Public Class FrmLookUpBarcodeInternal
    Dim Obj As KanbanInternal
    Dim dtTemp As DataTable

    Dim PrintTool As ReportPrintTool
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Id")
        dtTemp.Columns.Add("NoUrut")
        dtTemp.Columns.Add("Cust")
        dtTemp.Columns.Add("PONumber")
        dtTemp.Columns.Add("InventoryId")
        dtTemp.Columns.Add("PartName")
        dtTemp.Columns.Add("Type")
        dtTemp.Columns.Add("NoPO")
        dtTemp.Columns.Add("OrderDate")
        dtTemp.Columns.Add("DeliveryDate")
        dtTemp.Columns.Add("QtyOrder")
        dtTemp.Columns.Add("RH_LH")
        dtTemp.Columns.Add("PalletizeMark")
        dtTemp.Columns.Add("PartNoLabel")
        dtTemp.Columns.Add("RackLabel")
        dtTemp.Columns.Add("RackPart")
        dtTemp.Columns.Add("ItemNo")
        dtTemp.Clear()
    End Sub
    Private Sub GenerateRow()
        Try
            Dim a As Integer
            Dim b As Integer
            a = TxtFrom.Text
            b = TxtTo.Text

            For i As Integer = a To b - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = "Level 0"
                'dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level0") & "")
            Next
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            Dim Username = String.Empty
            Dim _param As String = String.Empty
            If TxtKodePart.Text = "" OrElse TxtFrom.Text = "" OrElse TxtTo.Text = "" Then
                Throw New Exception("Silahkan lengkapi data")
            ElseIf TxtFrom.Text = "0" OrElse TxtTo.Text = "0" Then
                TxtFrom.Focus()
                TxtFrom.SelectAll()
                Throw New Exception("No Passcard From/To tidak boleh '0'")
            End If

            Dim ds As DataSet = New DataSet
            Dim dt As DataTable = New DataTable

            Obj = New KanbanInternal
            ds = Obj.PrintQRCOdeCkr()

            dt = ds.Tables("KanbanInternal")

            Dim a As Integer
            Dim b As Integer
            a = TxtFrom.Text
            b = TxtTo.Text

            If dt.Rows.Count = 0 Then
                Throw New Exception("No Urut '[" & TxtKodePart.Text & "]' tidak ditemukan, Silahkan No Urut yang lain")
            Else
                _param = dt.Rows(0)("Cust").ToString()
            End If
            TempTable()

            For i As Integer = a To b
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = Trim(dt.Rows(0).Item("Id") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = Trim(dt.Rows(0).Item("NoUrut") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(0).Item("Cust") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(dt.Rows(0).Item("PONumber") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(dt.Rows(0).Item("InventoryId") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Trim(dt.Rows(0).Item("PartName") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Trim(dt.Rows(0).Item("Type") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = Trim(dt.Rows(0).Item("NoPO") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = Trim(dt.Rows(0).Item("OrderDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(8) = Trim(dt.Rows(0).Item("DelDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(9) = Trim(dt.Rows(0).Item("QtyOrder") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(10) = Trim(dt.Rows(0).Item("RH_LH") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(11) = Trim(dt.Rows(0).Item("PalletizeMark") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(12) = Trim(dt.Rows(0).Item("PartNoLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(13) = Trim(dt.Rows(0).Item("RackLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(14) = Trim(dt.Rows(0).Item("RackPart") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(15) = Trim(dt.Rows(0).Item("ItemNo") & "")
            Next

            Dim Laporan As New PrintKanbanInternalTes()
            With Laporan
                '.param1 = _param
                .DataSource = dtTemp
                AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
            End With

            PrintTool = New ReportPrintTool(Laporan)
            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            'PrintTool.ShowPreviewDialog()
            PrintTool.ShowPreview(UserLookAndFeel.Default)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmLookUpBarcodeInternal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtKodePart.Focus()
    End Sub

    Private Sub PrintingSystem_EndPrint(sender As Object, e As EventArgs)
        Try
            For i As Integer = 0 To dtTemp.Rows.Count - 1
                Obj = New KanbanInternal
                Obj.UpdateData(dtTemp.Rows(i)("Id"))
                PrintTool.ClosePreview()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
