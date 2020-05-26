Public Class FrmReportEntertain
    Dim laporan As New entertain1
    Dim report As New SuspendHeaderModel
    Dim entertain As New Object
    Dim _NoSuspend As String

    Private Sub FrmReportEntertain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub
    Public Sub New(ByVal NoSuspend As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoSuspend = NoSuspend
    End Sub
    Sub Loadreport()
        Try
            If _NoSuspend = "" Then
                Throw New Exception("Suspend ID tidak boleh kosong")
            End If
            report.SuspendID = _NoSuspend
            Dim ds As New DataSet
            ds = report.loadreport2
            'ds = report.reportsj
            'laporan.PrintToPrinter(1, False, 0, 0)

            Dim dsSub As New DataSet
            dsSub = report.SubReport

            laporan.SetDataSource(ds.Tables("suspend"))
            laporan.Subreports(0).SetDataSource(dsSub.Tables("SuspendRelasi"))

            With CrystalReportViewer1
                .ReportSource = laporan
                .RefreshReport()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class