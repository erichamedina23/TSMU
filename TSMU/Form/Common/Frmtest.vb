Public Class Frmtest
    Private Sub Frmtest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = DateTime.Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As String = String.Format("{0:#,##0.0000}", 1234.4445)
        MsgBox(s)
    End Sub
End Class