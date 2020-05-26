Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Public Class frmListHargaADM
    Private _dt As DataTable
    Dim _judul As String
    Dim _tipe As Integer
    Dim ObjForecast As New forecast_price_models
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal dt As DataTable, Judul As String, Tipe As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dt = New DataTable
        _dt = dt
        _judul = Judul
        _tipe = Tipe
    End Sub
    Private Sub frmListHargaADM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
        GetDataGrid()
        GroupControl1.Text = _judul
    End Sub

    Private Sub GetDataGrid()
        Grid.DataSource = _dt
        If GridView1.RowCount > 0 Then
            If _tipe = 0 Then
                GridView1.Columns(0).Visible = False
            End If
            GridView1.BestFitColumns()
            FormatGridView(GridView1)
        End If
    End Sub

    Public Overrides Sub Proc_Refresh()
        Dim dt As New DataTable
        ObjForecast = New forecast_price_models
        dt = ObjForecast.GetHargaSAPKAP_ADM
        Grid.DataSource = _dt
        If GridView1.RowCount > 0 Then
            GridView1.BestFitColumns()
            FormatGridView(GridView1)
        End If
    End Sub
    Public Overrides Sub Proc_Excel()
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        End If
    End Sub

    Private Sub BtnLookUpInvtID_Click(sender As Object, e As EventArgs) Handles BtnLookUpInvtID.Click

    End Sub

    Private Sub BtnLookUpInvtID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnLookUpInvtID.ButtonClick
        Dim InvtID As String = String.Empty
        Try
            If _tipe = 0 Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        InvtID = GridView1.GetRowCellValue(rowHandle, "InvtID")
                    End If
                Next rowHandle

                ObjForecast = New forecast_price_models

                Dim dt As New DataTable
                dt = ObjForecast.GetListInveortoryDetails(InvtID)

                If GridView1.GetSelectedRows.Length > 0 Then
                    Dim f As frmListAdmHargaDetails
                    f = New frmListAdmHargaDetails(dt)
                    f.WindowState = FormWindowState.Maximized
                    f.Show()
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class