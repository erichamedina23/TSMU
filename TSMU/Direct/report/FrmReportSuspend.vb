Public Class FrmReportSuspend
    Dim laporan As New suspend11
    Dim report As New SuspendHeaderModel
    Private Sub FrmReportSuspend_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadreport()
    End Sub
    Sub loadreport()
        report.SuspendID = TxtNoSuspend.Text
        Dim ds As New DataSet
        ds = report.loadreport2
        'ds = report.reportsj
        'laporan.PrintToPrinter(1, False, 0, 0)

        laporan.SetDataSource(ds)
        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub
End Class