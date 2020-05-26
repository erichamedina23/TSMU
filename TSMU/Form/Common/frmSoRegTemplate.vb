Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmSoRegTemplate
    Dim dtGrid As DataTable
    Dim ObjSoReg As SoRegTemplateModel
    Dim ObjSoRegColl As SORegModelColl
    Private Sub frmSoRegTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            ObjSoReg = New SoRegTemplateModel
            dtGrid = New DataTable
            dtGrid = ObjSoReg.GetDataGrid
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
                ObjSoReg.ObjCollection.Clear()

                For Each row As DataRow In dtFilter.Rows
                    ObjSoRegColl = New SORegModelColl
                    With ObjSoRegColl
                        .AlternateID = If(row("AlternateID") Is DBNull.Value, "", row("AlternateID").ToString)
                        .CustID = If(row("CustID") Is DBNull.Value, "", row("CustID").ToString())
                        .Description = If(row("Descr") Is DBNull.Value, "", row("Descr").ToString())
                        .InvtID = If(row("InvtID") Is DBNull.Value, "", row("InvtID").ToString())
                        .Jam = If(row("Jam") Is DBNull.Value, "", row("Jam").ToString())
                        .No = If(row("NO") Is DBNull.Value, 0, Convert.ToInt32(row("NO")))
                        .PO = If(row("PO") Is DBNull.Value, "", row("PO").ToString())
                        .PromDate = If(row("Promdate") Is DBNull.Value, Convert.ToDateTime("1990-01-01"), row("Promdate"))
                        .Qty = If(row("Quantity") Is DBNull.Value, "", Convert.ToInt32(row("Quantity")))
                        .SiteID = If(row("SiteID") Is DBNull.Value, 0, row("SiteID"))
                        .SO = If(row("SO") Is DBNull.Value, "", row("SO").ToString())
                        .Tujuan = If(row("Tujuan") Is DBNull.Value, "", row("Tujuan").ToString())
                    End With
                    ObjSoReg.ObjCollection.Add(ObjSoRegColl)
                Next
                ObjSoReg.InsertData()
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
