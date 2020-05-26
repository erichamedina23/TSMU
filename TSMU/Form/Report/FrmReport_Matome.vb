Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class FrmReport_Matome
    Dim ObjReportMatome As ClsReportMatome
    Public Sub New()
        ObjReportMatome = New ClsReportMatome
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmReport_Matome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Tahun As String = String.Empty
        Tahun = DateTime.Today.Year().ToString
        _txtTahun.Text = Tahun
        LoadGrid(Tahun)
    End Sub
    Private Sub LoadGrid(Tahun As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            'SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim dt As New DataTable
            dt = ObjReportMatome.Generate_Report_Matome(Tahun)
            Grid.DataSource = dt
            AdvBandedGridView1.BestFitColumns()

            'AdvBandedGridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'AdvBandedGridView1.Columns(3).DisplayFormat.Format = New CultureInfo("en")
            'AdvBandedGridView1.Columns(3).DisplayFormat.FormatString = "#,0.00"

            'AdvBandedGridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'AdvBandedGridView1.Columns(4).DisplayFormat.Format = New CultureInfo("en")
            'AdvBandedGridView1.Columns(4).DisplayFormat.FormatString = "#,0.00"

            'AdvBandedGridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'AdvBandedGridView1.Columns(5).DisplayFormat.Format = New CultureInfo("en")
            'AdvBandedGridView1.Columns(5).DisplayFormat.FormatString = "#,0.00"
            Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
            Cursor.Current = Cursors.Default
            'SplashScreenManager.CloseForm()
            'XtraMessageBox.Show("Proses selesai")
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            'SplashScreenManager.CloseForm()
            XtraMessageBox.Show(ex.Message)
        End Try

        'With AdvBandedGridView1
        '    .BestFitColumns()
        '    .FixedLineWidth = 2
        '    .Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        '    .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        'End With
    End Sub
    Public Overrides Sub Proc_Refresh()
        If _txtTahun.Text = "" Then
            XtraMessageBox.Show("Silahkan isi tahun !")
            _txtTahun.Focus()
        Else
            LoadGrid(_txtTahun.Text)
        End If
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If AdvBandedGridView1.RowCount > 0 Then
                Dim save As New SaveFileDialog
                save.Filter = "Excel File|*.xlsx"
                save.Title = "Save an Excel File"
                If save.ShowDialog = DialogResult.OK Then
                    Grid.ExportToXlsx(save.FileName)
                End If
                'getPath()
                '    Dim Filename As String = path & "\Forecast_.xls"
                '    'Dim FileName As String = "D:\Grid.xls"
                '    Grid.ExportToXls(Filename)

            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub _txtTahun_KeyDown(sender As Object, e As KeyEventArgs) Handles _txtTahun.KeyDown
        If e.KeyCode = Keys.Enter Then
            tsBtn_refresh.PerformClick()
        Else
            e.Handled = True

        End If
    End Sub
End Class
