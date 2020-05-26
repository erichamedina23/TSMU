Public Class FrmReportSuspend2
    Dim laporan As New suspendreport1
    Dim report As New SuspendHeaderModel
    Private Sub FrmReportSuspend2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdept.Text = gh_Common.GroupID
    End Sub
    Sub loadreport()
        report.DeptID = txtdept.Text
        report.Tgld = dari.Text
        report.Tgls = sampai.Text
        Dim ds As New DataSet

        ds = report.loadreport3
        'ds = report.reportsj
        'laporan.PrintToPrinter(1, False, 0, 0)




        ''  laporan.DataDefinition.FormulaFields("tgls").Text = sampai.Value

        laporan.DataDefinition.FormulaFields("tglawal").Text = "'" & dari.Value & "'"
        laporan.DataDefinition.FormulaFields("tglakhir").Text = "'" & sampai.Value & "'"

        laporan.SetDataSource(ds)
        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadreport()
    End Sub
End Class