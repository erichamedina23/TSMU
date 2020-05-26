Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class frmReport_SalesPrice
    Dim dtGrid As DataTable
    Dim service As clsReport
    Private Initializing As Boolean = False
    Sub New()
        Initializing = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmReport_SalesPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        FillComboTahun()
        _CmbTahun.SelectedIndex = 1
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            service = New clsReport
            dtGrid = New DataTable
            dtGrid = service.POAmount_report(_CmbTahun.Text)
            GridPO.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(1).Visible = False
                .FixedLineWidth = 2
                .Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(5).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(6).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .OptionsView.ShowFooter = True
                '.OptionsBehavior.Editable = False
                '.Columns(5).OptionsColumn.AllowEdit = True
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                    If col.Name.ToLower = "colinvtid" Then
                        col.OptionsColumn.AllowEdit = True
                    Else
                        col.OptionsColumn.AllowEdit = False
                    End If
                Next
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGrid1()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            service = New clsReport
            dtGrid = New DataTable
            dtGrid = service.ForecastPrice_report(_CmbTahun.Text)
            GridForecast.DataSource = dtGrid
            With GridView2
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(5).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .OptionsView.ShowFooter = True
                '.OptionsBehavior.Editable = False
                '.Columns(4).OptionsColumn.AllowEdit = True
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                    If col.Name.ToLower = "colinvtid" Then
                        col.OptionsColumn.AllowEdit = True
                    Else
                        col.OptionsColumn.AllowEdit = False
                    End If
                Next
            End With
            If GridView2.RowCount > 0 Then
                GridCellFormat(GridView2)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Try
            If _CmbTahun.EditValue = "" Then
                Throw New Exception("SIlahkna pilih tahun !")
            End If

            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                Call LoadGrid()
            Else
                LoadGrid1()

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            If GridView1.RowCount > 0 Then
                SaveToExcel(GridPO)
            Else
                MsgBox("Data Kosong !")
            End If
        Else
            If GridView2.RowCount > 0 Then
                SaveToExcel(GridForecast)
            Else
                MsgBox("Data Kosong !")
            End If
        End If

    End Sub

    Private Sub GridPO_MouseDown(sender As Object, e As MouseEventArgs) Handles GridPO.MouseDown
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    ContextMenuStrip1.Show(e.Location)
        'End If
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As Integer = {Date.Today.Year - 1, Date.Today.Year, Date.Today.Year + 1}
        _CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            _CmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub _CmbTahun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _CmbTahun.SelectedIndexChanged
        If Initializing Then
            Exit Sub
        End If
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            LoadGrid()
        Else
            LoadGrid1()
        End If
    End Sub

    Private Sub frmReport_SalesPrice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = False
        XtraTabControl1.SelectedTabPageIndex = 0
        Call LoadGrid()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If Initializing Then
            Exit Sub
        End If
        tsBtn_refresh.PerformClick()
    End Sub
End Class
