Public Class FrmReportTravelSett
    Dim laporan As New CRTravelSettlement
    Dim report As New TravelHeaderModel
    Dim reportSett As New TravelSettlementHeaderModel

    Sub loadreport()
        Dim dt As New DataTable
        Dim dtSett As New DataTable
        Dim dtExpense As New DataTable
        report.TravelID = txtTravelID.Text
        reportSett.TravelID = txtTravelID.Text
        reportSett.TravelSettID = txtTravelSettleID.Text

        dtSett = reportSett.LoadReportTravelSett
        laporan.SetDataSource(dtSett)

        dtExpense = reportSett.LoadReportTravelSettExpense
        laporan.Subreports("CRTravelTotalExpenseSettRight.rpt").SetDataSource(dtExpense)

        Dim FilteredRows As DataRow()
        dt = report.LoadReportTravelDetail
        dtSett = reportSett.LoadReportTravelSettDetail
        FilteredRows = dt.Select("ID = 1")
        laporan.Subreports("CRTravelDetailTicketSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dtSett.Select("ID = 1")
        laporan.Subreports("CRTravelDetailTicketSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        FilteredRows = dt.Select("ID = 2")
        laporan.Subreports("CRTravelDetailTransportSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dtSett.Select("ID = 2")
        laporan.Subreports("CRTravelDetailTransportSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        FilteredRows = dt.Select("ID = 3")
        laporan.Subreports("CRTravelDetailStayingSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dtSett.Select("ID = 3")
        laporan.Subreports("CRTravelDetailStayingSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        FilteredRows = dt.Select("ID IN (4, 6, 7)")
        laporan.Subreports("CRTravelDetailSafetyMoneySett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dtSett.Select("ID IN (4, 6, 7)")
        laporan.Subreports("CRTravelDetailSafetyMoneySettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        FilteredRows = dt.Select("ID = 5")
        laporan.Subreports("CRTravelDetailAllowanceSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        FilteredRows = dtSett.Select("ID = 5")
        laporan.Subreports("CRTravelDetailAllowanceSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        'FilteredRows = dtSett.Select("ID = 5")
        laporan.Subreports("CRTravelTotalSuspenseSettRight.rpt").SetDataSource(dtSett)

        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub

    Private Sub FrmReportTravelSett_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub
End Class