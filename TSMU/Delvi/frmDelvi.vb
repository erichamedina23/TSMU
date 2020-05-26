Imports DevExpress.Utils
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Localization
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmDelvi
    Dim ObjDelvi As ClsDelvi
    Dim ObjTrans As ClsDelviTransaction

    Dim isUpdate As Boolean = False
    Public IsClosed As Boolean = False

    Public Sub New()
        ObjDelvi = New ClsDelvi
        ObjTrans = New ClsDelviTransaction
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmDelvi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadGrid()
        Call Proc_EnableButtons(False, True, True, True, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            Cursor = Cursors.WaitCursor
            Dim dtGrid As New DataTable
            dtGrid = ObjDelvi.GetBatchNo(IIf(_txtBatch.Text = "", "", _txtBatch.Text))
            Grid.DataSource = dtGrid
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
            GridView1.BestFitColumns()
            'GridView1.OptionsClipboard.CopyColumnHeaders = False

            'GridView1.ClearSelection()

            'Dim star As Integer = 0
            'Dim akhir As Integer = GridView1.RowCount

            'Dim StarColumn As GridColumn = GridView1.Columns("CUSTORDNBR")
            'Dim EndColumn As GridColumn = GridView1.Columns("CUSTORDNBR")

            'GridView1.SelectCells(star, StarColumn, akhir, EndColumn)
            Cursor = Cursors.Default
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Cursor = Cursors.Default
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Private Sub Grid_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid.MouseDown
        Dim ghi As GridHitInfo = GridView1.CalcHitInfo(Grid.PointToClient(frmDelvi.MousePosition))

        If ghi.InColumnPanel Then
            GridView1.BeginSelection()
            GridView1.SelectCells(GridView1.GetVisibleRowHandle(0), ghi.Column, GridView1.GetVisibleRowHandle(GridView1.RowCount - 1), ghi.Column)
            GridView1.EndSelection()
            DXMouseEventArgs.GetMouseArgs(e).Handled = True
        End If
    End Sub

    Private Sub _txtBatch_KeyDown(sender As Object, e As KeyEventArgs) Handles _txtBatch.KeyDown
        If e.KeyCode = Keys.Enter Then
            'MsgBox(GridView1.OptionsClipboard.CopyColumnHeaders.ToString)
            If _txtBatch.Text = "" Then
                MsgBox("Batch No Kosong !")
                TxtInvDate.Text = ""
                txtRefNo.Text = ""
                txtNoFp.Text = ""
                LoadGrid()
            Else
                Dim dt As DataTable = New DataTable
                dt = ObjDelvi.GetBatchNo(_txtBatch.Text)
                If dt.Rows.Count > 0 Then
                    TxtInvDate.Text = dt.Rows(0)("InvcDate").ToString()
                    txtRefNo.Text = dt.Rows(0)("RefNbr").ToString()
                    txtNoFp.Text = dt.Rows(0)("NoFP").ToString()
                End If
                LoadGrid()
            End If
        End If
    End Sub

    Private Sub frmDelvi_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _txtBatch.Focus()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated = True Then
                With ObjTrans
                    .BATNBR = _txtBatch.Text.Trim
                    .InvcDate = TxtInvDate.Text.Trim
                    .RefNbr = txtRefNo.Text.Trim
                    .NoFP = txtNoFp.Text.Trim
                    .NoSertifikat = txtNoSertifikat.Text.Trim


                End With
                With ObjDelvi
                    .BATNBR = _txtBatch.Text.Trim
                    .ValidateInsert()
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try
            ObjTrans.ObjDelviDetails.Clear()
            For i As Integer = 0 To GridView1.RowCount - 1
                With ObjDelvi
                    .BATNBR = _txtBatch.Text.Trim
                    .SHIPPERID = GridView1.GetRowCellValue(i, GridView1.Columns("SHIPPERID"))
                    .CUSTORDNBR = GridView1.GetRowCellValue(i, GridView1.Columns("CUSTORDNBR"))
                End With
                ObjTrans.ObjDelviDetails.Add(ObjDelvi)
            Next

            ObjTrans.InsertData()

            IsClosed = False
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        _txtBatch.DoValidate()
        txtNoSertifikat.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(_txtBatch) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(txtNoSertifikat) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub
End Class
