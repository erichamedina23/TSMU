Public Class Frm_Rpt_NPWO

    Dim laporan As New Rpt_NPWO
    Dim laporanRev As New NPP_RevInformasi
    Dim report As New Cls_Npwo_Detail
    Dim dsSub As DataSet
    Public NPWO_No As String = ""
    Public REV As String = ""
    Private Sub Frm_Rpt_NPWO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadreport()
    End Sub

    Sub loadreport()
        'report.H_No_Npwo = "001"
        Dim ds As New DataSet
        ds = report.NpwoReport(NPWO_No, REV)

        'Dim dsRev As New DataSet
        'dsRev = report.NPPReportRev(NPP_No)
        'laporanRev.SetDataSource(dsRev)
        'ds = report.reportsj
        'laporan.PrintToPrinter(1, False, 0, 0)

        laporan.SetDataSource(ds)

        dsSub = report.NPWOReportRev(NPWO_No)
        laporan.Subreports("Rpt_Npwo_Rev.rpt").SetDataSource(dsSub)

        With CrystalReportViewer1
            .ReportSource = (laporan)
            .RefreshReport()
            .Zoom(90)
        End With
    End Sub
End Class