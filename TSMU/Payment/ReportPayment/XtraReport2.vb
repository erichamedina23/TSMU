Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Public Class XtraReport2
    Public param1, param2, param3 As String

    Private Sub XtraReport2_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        'XrTableCell33.Text = param2
        'XrTableCell33.Text = param1
    End Sub
End Class