Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class Testing
    Public param1, param2, param3, param4 As String
    Dim Obj As New BarcodeGenerate
    Private Sub Testing_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        LblKodePart.Text = param1
        LblBulan.Text = param2
        LblSite.Text = param3
        LblTgl.Text = param4
    End Sub

    Private Sub Testing_AfterPrint(sender As Object, e As EventArgs) Handles Me.AfterPrint
        'Obj.InsertLog(param1, param2, param3)
    End Sub

    Private Sub XrLabel20_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel20.BeforePrint
        Dim label As XRLabel = TryCast(sender, XRLabel)
        Dim Warna As String = GetCurrentColumnValue(Of String)("KodeWarna")

        If param3 = "TSC3" Then
            If Warna = "" Then
                Exit Sub
            ElseIf Warna = "FFFFFF" Then
                label.ForeColor = Color.Black
                label.BackColor = ColorTranslator.FromHtml("#" & Warna)
            ElseIf Warna = "000000" Then
                label.ForeColor = Color.White 'Color.FromName("#FFFFFF")
                label.BackColor = ColorTranslator.FromHtml("#" & Warna) 'Color.FromName("#FFFFFF")
            Else
                label.ForeColor = Color.Black
                label.BackColor = ColorTranslator.FromHtml("#" & Warna) 'Color.FromName("#FFFFFF")
            End If

            'If Warna = "Black" Then
            '    label.ForeColor = Color.White
            '    label.BackColor = Color.Black
            'Else
            '    label.ForeColor = Color.Black
            '    label.BackColor = Color.DarkGray
            'End If

        End If


    End Sub

    Private Sub XrLabel7_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel7.BeforePrint
        Dim label As XRLabel = TryCast(sender, XRLabel)
        Dim CustID As String = GetCurrentColumnValue(Of String)("CustomerID")

        If param3.ToLower = "tsc1" Then
            If CustID.ToLower = "yim" Then
                label.Text = "Project"
            End If
        End If
    End Sub
End Class