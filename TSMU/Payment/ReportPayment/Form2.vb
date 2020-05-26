Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid

Public Class Form2

    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing
    Dim laporan As New XtraReport1


    'Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
    '    Try
    '        If ProgBar.Visible = True Then
    '            Throw New Exception("Process already running, Please wait!")
    '        End If
    '        ProgBar.Visible = True
    '        ProgBar.Style = ProgressBarStyle.Marquee
    '        Await Task.Run(Sub() DXReportUploadToMizuho())
    '    Catch ex As Exception
    '        ProgBar.Visible = False
    '        MsgBox(ex.Message)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try
    'End Sub

    'Private Sub DXReportUploadToMizuho()
    '    Dim date1 As String = ""
    '    Dim date2 As String = ""
    '    'Dim date1 As DateTime
    '    'Dim date2 As DateTime
    '    Invoke(Sub()
    '               date1 = DateEdit1.Text
    '               date2 = DateEdit2.Text
    '           End Sub)
    '    'Dim ds As New DataSet
    '    'ds = pay_class.DXReportUploadToMizuho(date1, date2)
    '    'vbSet(ds, DocumentViewer1)

    '    Dim ds As New DataSet
    '    ds = pay_class.DXReportUploadToMizuho(date1, date2)
    '    ''pay_class.data

    '    With DocumentViewer1
    '        .DocumentSource = pay_class
    '        ''.Refresh()
    '    End With

    '    Invoke(Sub()
    '               ProgBar.Visible = False
    '           End Sub)
    'End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
        ''Init()
        ProgBar.Visible = False
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        '    Dim ds As New DataSet

        '    Dim date1 As String = ""
        '    Dim date2 As String = ""
        '    'Dim date1 As DateTime
        '    'Dim date2 As DateTime
        '    Invoke(Sub()
        '               date1 = DateEdit1.Text
        '               date2 = DateEdit2.Text
        '           End Sub)

        '    ds = pay_class.DXReportUploadToMizuho
        '    laporan.

        '    With DocumentViewer1
        '        .DocumentSource = laporan
        '        .Refresh()
        '    End With

        '    Invoke(Sub()
        '               ProgBar.Visible = False
        '           End Sub)
        'End Sub
        ''Private Sub Init()
        ''    XpDataView1.LoadOrderedData = Nothing
    End Sub


End Class