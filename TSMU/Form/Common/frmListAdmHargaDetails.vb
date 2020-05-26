Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Public Class frmListAdmHargaDetails
    Private _dt As DataTable
    Dim ObjForecast As forecast_price_models
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dt = New DataTable
        _dt = dt
    End Sub
    Private Sub frmListAdmHargaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False)
        GridControl1.DataSource = _dt
        If GridView1.RowCount > 0 Then
            With GridView1
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(1).Fixed = Columns.FixedStyle.Left
                .Columns(2).Fixed = Columns.FixedStyle.Left
                .Columns(3).Fixed = Columns.FixedStyle.Left
                .Columns(4).Fixed = Columns.FixedStyle.Left
            End With

        End If
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                ObjForecast = New forecast_price_models
                With ObjForecast
                    .JanHarga1 = GridView1.GetRowCellValue(i, "JanHarga1")
                    .JanHarga2 = GridView1.GetRowCellValue(i, "JanHarga2")
                    .JanHarga3 = GridView1.GetRowCellValue(i, "JanHarga3")
                    .FebHarga1 = GridView1.GetRowCellValue(i, "FebHarga1")
                    .FebHarga2 = GridView1.GetRowCellValue(i, "FebHarga2")
                    .FebHarga3 = GridView1.GetRowCellValue(i, "FebHarga3")
                    .MarHarga1 = GridView1.GetRowCellValue(i, "MarHarga1")
                    .MarHarga2 = GridView1.GetRowCellValue(i, "MarHarga2")
                    .MarHarga3 = GridView1.GetRowCellValue(i, "MarHarga3")
                    .AprHarga1 = GridView1.GetRowCellValue(i, "AprHarga1")
                    .AprHarga2 = GridView1.GetRowCellValue(i, "AprHarga2")
                    .AprHarga3 = GridView1.GetRowCellValue(i, "AprHarga3")
                    .MeiHarga1 = GridView1.GetRowCellValue(i, "MeiHarga1")
                    .MeiHarga2 = GridView1.GetRowCellValue(i, "MeiHarga2")
                    .MeiHarga3 = GridView1.GetRowCellValue(i, "MeiHarga3")
                    .JunHarga1 = GridView1.GetRowCellValue(i, "JunHarga1")
                    .JunHarga2 = GridView1.GetRowCellValue(i, "JunHarga2")
                    .JunHarga3 = GridView1.GetRowCellValue(i, "JunHarga3")
                    .JulHarga1 = GridView1.GetRowCellValue(i, "JulHarga1")
                    .JulHarga2 = GridView1.GetRowCellValue(i, "JulHarga2")
                    .JulHarga3 = GridView1.GetRowCellValue(i, "JulHarga3")
                    .AgtHarga1 = GridView1.GetRowCellValue(i, "AgtHarga1")
                    .AgtHarga2 = GridView1.GetRowCellValue(i, "AgtHarga2")
                    .AgtHarga3 = GridView1.GetRowCellValue(i, "AgtHarga3")
                    .SepHarga1 = GridView1.GetRowCellValue(i, "SepHarga1")
                    .SepHarga2 = GridView1.GetRowCellValue(i, "SepHarga2")
                    .SepHarga3 = GridView1.GetRowCellValue(i, "SepHarga3")
                    .OktHarga1 = GridView1.GetRowCellValue(i, "OktHarga1")
                    .OktHarga2 = GridView1.GetRowCellValue(i, "OktHarga2")
                    .OktHarga3 = GridView1.GetRowCellValue(i, "OktHarga3")
                    .NovHarga1 = GridView1.GetRowCellValue(i, "NovHarga1")
                    .NovHarga2 = GridView1.GetRowCellValue(i, "NovHarga2")
                    .NovHarga3 = GridView1.GetRowCellValue(i, "NovHarga3")
                    .DesHarga1 = GridView1.GetRowCellValue(i, "DesHarga1")
                    .DesHarga2 = GridView1.GetRowCellValue(i, "DesHarga2")
                    .DesHarga3 = GridView1.GetRowCellValue(i, "DesHarga3")
                    .Id = GridView1.GetRowCellValue(i, "Id")
                    .UpdateHarga()
                End With
            Next

            XtraMessageBox.Show("Data Saved !")
            frmListHargaADM.tsBtn_refresh.PerformClick()
            Me.Close()
        Catch ex As Exception
            XtraMessageBox.Show("Error Update Harga", ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        GridView1.ShowEditor()
        GridView1.UpdateCurrentRow()
    End Sub
End Class