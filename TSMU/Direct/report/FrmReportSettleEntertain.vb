Public Class FrmReportSettleEntertain

    Dim laporan As New SettleEntertain
    Dim report As New SettleHeader
    Dim entertain As New Object
    Dim _NoSettle As String
    Private Sub FrmReportSettleEntertain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub
    Public Sub New(ByVal NoSettle As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _NoSettle = NoSettle
    End Sub
    Sub loadreport()
        'report.SettleID = TxtNosettle.Text
        'Dim ds As New DataSet
        'ds = report.loadreport2
        ''ds = report.reportsj
        ''laporan.PrintToPrinter(1, False, 0, 0)

        'laporan.SetDataSource(ds)
        'With CrystalReportViewer1
        '    .ReportSource = laporan
        '    .RefreshReport()
        'End With

        Try
            If _NoSettle = "" Then
                Throw New Exception("Settle ID tidak boleh kosong")
            End If
            report.SettleID = _NoSettle
            Dim ds As New DataSet
            ds = report.loadreport2
            'ds = report.reportsj
            'laporan.PrintToPrinter(1, False, 0, 0)

            Dim dsSub As New DataSet
            dsSub = report.SubReport

            laporan.SetDataSource(ds.Tables("settle"))
            laporan.Subreports(0).SetDataSource(dsSub.Tables("SettleRelasi"))

            With CrystalReportViewer1
                .ReportSource = laporan
                .RefreshReport()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
End Class