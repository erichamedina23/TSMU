Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class PrintKanbanInternal_new
    Public param1 As ArrayList

    Private Sub XrLabel11_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel11.BeforePrint
        Dim label As XRLabel = TryCast(sender, XRLabel)
        Dim Warna As String = GetCurrentColumnValue(Of String)("Warna")
        label.ForeColor = Color.Black
        label.BackColor = ColorTranslator.FromHtml(Warna)
        'If Warna = "" Then
        '    Exit Sub
        'ElseIf Warna = "FFFFFF" Then
        '    label.ForeColor = Color.Black
        '    label.BackColor = ColorTranslator.FromHtml("#" & Warna)
        'ElseIf Warna = "000000" Then
        '    label.ForeColor = Color.White 'Color.FromName("#FFFFFF")
        '    label.BackColor = ColorTranslator.FromHtml("#" & Warna) 'Color.FromName("#FFFFFF")
        'Else
        '    label.ForeColor = Color.Black
        '    label.BackColor = ColorTranslator.FromHtml("#" & Warna) 'Color.FromName("#FFFFFF")
        'End If

    End Sub
End Class