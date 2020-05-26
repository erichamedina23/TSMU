Public Class FrmReportTravel
    Dim laporan As New CRTravel
    Dim report As New TravelHeaderModel

    Private Sub FrmReportTravel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Sub loadreport()
        Dim dt As New DataTable
        report.TravelID = txtTravelID.Text

        dt = report.LoadReportTravel
        laporan.SetDataSource(dt)

        dt = New DataTable
        Dim FilteredRows As DataRow()
        dt = report.LoadReportTravelDetail
        FilteredRows = dt.Select("ID = 1")
        laporan.Subreports("CRTravelDetailTicket.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dt.Select("ID = 2")
        laporan.Subreports("CRTravelDetailTransport.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dt.Select("ID = 3")
        laporan.Subreports("CRTravelDetailStaying.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dt.Select("ID = 5")
        laporan.Subreports("CRTravelDetailAllowance.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dt.Select("ID IN (4, 6, 7)")
        laporan.Subreports("CRTravelDetailSafetyMoney.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub

End Class