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

Public Class frm_AR
    Dim dtGrid As DataTable
    Dim dtGrid2 As DataTable
    Dim dtGrid3 As DataTable
    Dim ObPayment As New Cls_Payment
    Dim table As DataTable
    Dim tableDetail As DataTable
    Dim ff_Detail As frm_AR_details
    Dim ObjPaymentHeader As New AR_Header_Models

    Private Sub frm_AR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = ObjPaymentHeader.GetDataGrid()
            Grid.DataSource = dtGrid
            With GridView1
                .Columns(0).Visible = False
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With
            GridCellFormat(GridView1)


            dtGrid2 = ObjPaymentHeader.GetDataGrid2()
            GridControl1.DataSource = dtGrid2
            With GridView2
                .Columns(0).Visible = False
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With
            GridCellFormat(GridView2)

            dtGrid2 = ObjPaymentHeader.GetDataGrid2()
            GridControl1.DataSource = dtGrid2
            With GridView2
                .Columns(0).Visible = False
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With
            GridCellFormat(GridView2)

            dtGrid3 = ObjPaymentHeader.GetDataGrid3()
            GridControl2.DataSource = dtGrid3
            With GridView3
                .Columns(0).Visible = False
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With
            GridCellFormat(GridView3)

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""

        Call LoadGrid()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal ls_Code4 As String = "", Optional ByVal ls_Code5 As String = "", Optional ByVal ls_Code6 As Double = 0, Optional ByVal sts_screen As Byte = 0, Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frm_AR_details(ls_Code, ls_Code2, ls_Code3, ls_Code4, ls_Code5, ls_Code6, sts_screen, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Dim ff_Detail2 As frm_AR_details
    Private Sub CallFrm2(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal sts_screen As Byte = 0, Optional ByVal li_Row As Integer = 0)
        If ff_Detail2 IsNot Nothing AndAlso ff_Detail2.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail2.Close()
        End If
        ff_Detail2 = New frm_AR_details(ls_Code, ls_Code2, sts_screen, Me, li_Row, GridControl1)
        ff_Detail2.MdiParent = FrmMain
        ff_Detail2.StartPosition = FormStartPosition.CenterScreen
        ff_Detail2.Show()
    End Sub
    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridControl1.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                id = String.Empty
                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView2.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView2.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView2.GetSelectedRows.Length > 0 Then
                    Call CallFrm2(id,
                             NoVoucher, 1,
                             GridView2.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridControl2.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                id = String.Empty
                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView3.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView3.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView3.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView3.GetSelectedRows.Length > 0 Then
                    Call CallFrm2(id,
                             NoVoucher, 1,
                             GridView3.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Public Overrides Sub Proc_DeleteData()
        Try

            'Dim fc_Class1 As New clsBoMTrans
            'fc_Class1.BoMID = Trim(Grid.SelectedRows(0).Cells(0).Value)
            'fc_Class1.DeleteData()
            'Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            'tsBtn_refresh.PerformClick()
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
    Dim NoVoucher, id, NoBukti As String
    Dim CustID, Customer, AcctID_tujuan, Descr_tujuan, CurryID As String

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Dim Jumlah As Double

    Private editor As BaseEdit
    Private Sub frm_AR_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView1.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView1.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(id,
                             NoVoucher,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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

                NoBukti = String.Empty
                CustID = String.Empty
                Customer = String.Empty
                AcctID_tujuan = String.Empty
                Descr_tujuan = String.Empty
                CurryID = String.Empty
                Jumlah = 0

                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        NoBukti = GridView1.GetRowCellValue(rowHandle, "NoBukti")
                        CustID = GridView1.GetRowCellValue(rowHandle, "CustID")
                        Customer = GridView1.GetRowCellValue(rowHandle, "Customer")
                        AcctID_tujuan = GridView1.GetRowCellValue(rowHandle, "AcctID_tujuan")
                        Descr_tujuan = GridView1.GetRowCellValue(rowHandle, "Descr_tujuan")
                        CurryID = GridView1.GetRowCellValue(rowHandle, "CurryID")
                        Jumlah = GridView1.GetRowCellValue(rowHandle, "Jumlah")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(NoBukti, Customer, AcctID_tujuan, Descr_tujuan, CurryID, Jumlah, 0, GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


End Class
