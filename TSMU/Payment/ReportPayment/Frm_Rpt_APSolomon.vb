Public Class Frm_Rpt_APSolomon

    Dim laporan As New Rpt_upload
    Dim report As New SettleHeader
    Dim entertain As New Object
    Dim _Date1 As Date
    Dim _Date2 As Date

    Private Sub Frm_Rpt_APSolomon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Public Sub New(ByVal Date1 As Date, ByVal Date2 As Date)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _Date1 = Date1
        _Date2 = Date2
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
            'If _Date1 = "" And _Date2 = "" Then
            '    Throw New Exception("Tanggal Tidak Boleh Kosong")
            'End If
            report.Date1 = _Date1
            report.Date2 = _Date2

            Dim ds As New DataSet
            ds = report.loadreportAPSolomon
            'ds = report.reportsj
            'laporan.PrintToPrinter(1, False, 0, 0)

            ''Dim dsSub As New DataSet
            ''dsSub = report.SubReport

            laporan.SetDataSource(ds.Tables("dataupload"))
            ''laporan.Subreports(0).SetDataSource(dsSub.Tables("SettleRelasi"))

            With CrystalReportViewer1
                .ReportSource = laporan
                .RefreshReport()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub



End Class