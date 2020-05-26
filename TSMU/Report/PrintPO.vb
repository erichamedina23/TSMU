Public Class PrintPO
    Public param1, param2, param3 As String

    Private Sub PrintPO_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'XrLabel6.Text = param1
        XrBarCode1.Text = param2
    End Sub

    Private Sub PrintPO_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

    End Sub
End Class