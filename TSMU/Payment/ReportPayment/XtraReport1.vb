Public Class XtraReport1
    Public param1, param2, param3 As String

    Private Sub XtraReport1_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'XrLabel6.Text = param1
        Frm_Rpt_UploadMizuho.DateEdit1.Text = param1
        Frm_Rpt_UploadMizuho.DateEdit2.Text = param2
    End Sub

End Class