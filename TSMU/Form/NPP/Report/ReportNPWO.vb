Public Class ReportNPWO
    Dim laporan As New CRNpwo
    Dim laporanRev As New NPP_RevInformasi
    Dim report As New Cls_NPP_Detail
    Public NPP_No As String = ""
    Public REV As String = ""


    Private Sub ReportNPWO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Sub loadreport()

        'report.H_No_Npwo = "001"
        Dim ds As New DataSet
        ds = report.NPPReport(NPP_No, REV)

        'Dim dsRev As New DataSet
        'dsRev = report.NPPReportRev(NPP_No)
        'laporanRev.SetDataSource(dsRev)
        'ds = report.reportsj
        'laporan.PrintToPrinter(1, False, 0, 0)

        laporan.SetDataSource(ds)


        With CrystalReportViewer1
            .ReportSource = (laporan)
            .RefreshReport()
            .Zoom(90)
        End With


    End Sub

End Class