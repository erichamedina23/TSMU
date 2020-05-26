Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmJogres
    Dim dtGrid As DataTable
    Dim objJogres As JogresModel
    Dim service As JogressService
    Private Sub frmJogres_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            service = New JogressService
            dtGrid = New DataTable
            dtGrid = service.GetDataGrid
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
        Dim ls_Judul As String = "SO REG"

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
                service.ObjCollection.Clear()

                For Each row As DataRow In dtFilter.Rows
                    objJogres = New JogresModel
                    With objJogres
                        .AlternateId = If(row("Alt") Is DBNull.Value, "", row("Alt"))
                        .DeliveryDate = If(row("Delivery Date") Is DBNull.Value, "2000-01-01", Convert.ToDateTime(row("Delivery Date")))
                        .DeliveryTime = If(row("Delivery Time (to)") Is DBNull.Value, "", row("Delivery Time (to)"))
                        .InvtId = If(row("Inv") Is DBNull.Value, "", row("Inv").ToString())
                        .ItemName = If(row("Item Name") Is DBNull.Value, "", row("Item Name"))
                        .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No"))
                        .Plan = If(row("Plant") Is DBNull.Value, "", row("Plant"))
                        .PlantOK = If(row("PlantOK") Is DBNull.Value, "", row("PlantOK"))
                        .PO = If(row("PO") Is DBNull.Value, "", row("PO"))
                        .Qty = If(row("Qty") Is DBNull.Value, 0, Convert.ToInt32(row("Qty")))
                        .SO = If(row("So") Is DBNull.Value, "", row("So"))
                        .Time = If(row("Time") Is DBNull.Value, "", row("Time"))
                        .TimeOK = If(row("TimeOK") Is DBNull.Value, "", row("TimeOK"))
                        .Tujuan = If(row("Tujuan") Is DBNull.Value, "", row("Tujuan"))
                    End With
                    service.ObjCollection.Add(objJogres)
                Next
                service.InsertData()
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
