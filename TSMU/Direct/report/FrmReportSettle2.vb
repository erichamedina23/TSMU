Public Class FrmReportSettle2
    Dim laporan As New settle2
    Dim report As New SettleHeader
    Private Sub FrmReportSettle2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Sub loadreport()
        report.SettleID = TxtNosettle.Text
        Dim ds As New DataSet
        ds = report.loadreport2a
        'ds = report.reportsj
        'laporan.PrintToPrinter(1, False, 0, 0)

        laporan.SetDataSource(ds)
        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub
End Class