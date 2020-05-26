Public Class frmAbout
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Close()
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = "VERSION " & Application.ProductVersion
    End Sub
End Class