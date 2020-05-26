Imports System.Configuration
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frm_fp_new
    Dim dtGrid As DataTable
    Dim ObjFP As New Cls_FP
    Dim table As DataTable
    Dim tableDetail As DataTable
    Dim ff_Detail As frm_fp_details
    Dim TglDari As Nullable(Of DateTime)
    Dim TglSampai As Nullable(Of DateTime)
    Dim ObjFPTransaction As New fp_transaction_models
    Private Sub frm_fp_new_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        'Call LoadGrid()
        'Dim dtGrid As New DataTable
        'dtGrid = Grid.DataSource
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
        _TxtBulan.SelectedIndex = 0
        _TxtPeriode.SelectedIndex = 0
        '_TxtTglDari.EditValue = DateTime.Today.Year.ToString() & "-01-01"
        '_TxtTglSampai.EditValue = DateTime.Today.Year.ToString() & "-01-15"
        LoadGrid()
    End Sub
    Private Sub LoadGrid()
        Try
            If _TxtBulan.Text = "" AndAlso _TxtPeriode.Text = "" AndAlso _TxtTahun.Text = "" Then
                Dim dt As New DataTable
                dtGrid = ObjFP.GetDataGridNew()
                Grid.DataSource = dtGrid
                If GridView1.RowCount > 0 Then
                    With GridView1
                        .BestFitColumns()
                        .FixedLineWidth = 2
                        .Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                        .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End With
                    GridCellFormat(GridView1)

                End If
            Else
                dtGrid = ObjFP.getalldata2(Format(TglDari, gs_FormatSQLDate), Format(TglSampai, gs_FormatSQLDate))
                Grid.DataSource = dtGrid
                If GridView1.RowCount > 0 Then
                    With GridView1
                        .BestFitColumns()
                        .FixedLineWidth = 2
                        .Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                        .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End With
                    GridCellFormat(GridView1)

                End If
            End If


        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub SetTanggal()
        If _txtBulan.Text.ToLower = "januari" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-01-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-01-15")

            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-01-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-01-31")

            End If

        End If
        'FEBURARI
        If _txtBulan.Text.ToLower = "februari" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-02-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-02-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-02-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-02-28")
            End If
        End If

        'MARET
        If _TxtBulan.Text.ToLower = "maret" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-03-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-03-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-03-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-03-31")
            End If
        End If

        'APRIL
        If _TxtBulan.Text.ToLower = "april" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-04-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-04-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-04-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-04-30")
            End If
        End If

        'MEI
        If _TxtBulan.Text.ToLower = "mei" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-05-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-05-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-05-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-05-31")
            End If
        End If

        'JUNI
        If _TxtBulan.Text.ToLower = "juni" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-06-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-06-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-06-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-06-30")
            End If
        End If

        'JULI
        If _TxtBulan.Text.ToLower = "juli" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-07-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-07-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-07-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-07-31")
            End If
        End If

        'AGUSTUS
        If _TxtBulan.Text.ToLower = "agustus" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-08-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-08-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-08-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-08-31")
            End If
        End If

        'SEPTEMBER
        If _TxtBulan.Text.ToLower = "september" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-09-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-09-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-09-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-09-30")
            End If
        End If

        'Oktober
        If _TxtBulan.Text.ToLower = "oktober" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-10-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-10-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-10-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-10-31")
            End If
        End If

        'NOVEMBER
        If _TxtBulan.Text.ToLower = "november" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-11-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-11-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-11-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-11-31")
            End If
        End If

        'DESEMBER
        If _TxtBulan.Text.ToLower = "desember" Then
            If _TxtPeriode.Text = "1" Then
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-12-01")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-12-15")
            Else
                TglDari = Convert.ToDateTime(_TxtTahun.Text & "-12-16")
                TglSampai = Convert.ToDateTime(_TxtTahun.Text & "-12-31")
            End If
        End If
    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""

        Call LoadGrid()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frm_fp_details(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            FPNo = String.Empty
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    FPNo = GridView1.GetRowCellValue(rowHandle, "FPNo")
                End If
            Next rowHandle
            ObjFPTransaction.FPNo = FPNo.TrimEnd
            ObjFPTransaction.DeleteData()
            'Dim fc_Class1 As New clsBoMTrans
            'fc_Class1.BoMID = Trim(Grid.SelectedRows(0).Cells(0).Value)
            'fc_Class1.DeleteData()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
            'Grid.RemoveItem(Grid.Row)
            'If Grid.Rows.Count > Grid.Rows.Fixed Then
            '    Call Proc_EnableButtons(True, False, True, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(True, False, False, True, True, True, False, False)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Dim FPNo, id As String
    Private editor As BaseEdit
    Private Sub frm_fp_new_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                FPNo = String.Empty
                id = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView1.GetRowCellValue(rowHandle, "id")
                        FPNo = GridView1.GetRowCellValue(rowHandle, "FPNo")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(id,
                             FPNo,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _txtBulan_SelectedIndexChanged(sender As Object, e As EventArgs)
        SetTanggal()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = Grid.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                'Dim colCaption As String = If(info.Column Is Nothing, "N/A", info.Column.GetCaption())
                'MessageBox.Show(String.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption))

                FPNo = String.Empty
                id = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView1.GetRowCellValue(rowHandle, "id")
                        FPNo = GridView1.GetRowCellValue(rowHandle, "FPNo")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(id,
                             FPNo,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _TxtPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _TxtPeriode.SelectedIndexChanged
        SetTanggal()
    End Sub
End Class
