
Public Class FrmReportBankTransfer
    Dim laporan As New RptBankTransfer3
    Dim laporan2 As New RptBankTransfer2
    Dim report As New TransferModel
    Dim banktransfer As New Object
    Dim _nobukti As String
    Dim _curyid1 As String
    Dim _curyid2 As String
    Private Sub FrmReportBankTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Loadreport()
    End Sub
    Public Sub New(ByVal nobukti As String, ByVal curyid1 As String, ByVal curyid2 As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nobukti = nobukti
        _curyid1 = curyid1
        _curyid2 = curyid2
    End Sub
    Sub Loadreport()
        Try


            If _nobukti = "" Then
                Throw New Exception("TransferID tidak boleh kosong")
            End If
            report.NoBukti = _nobukti
            Dim ds As New DataSet
            ds = report.loadreport2
            If _curyid1 <> _curyid2 Then
                laporan.SetDataSource(ds)
                With CrystalReportViewer1
                    .ReportSource = laporan
                    .RefreshReport()
                End With
            Else
                laporan2.SetDataSource(ds)
                With CrystalReportViewer1
                    .ReportSource = laporan2
                    .RefreshReport()
                End With
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class