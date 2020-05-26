Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmSuratJalan
    Dim SuratJalan As New ClsSJ
    Dim btnState As ButtonState
    Dim dtGrid As DataTable
    Dim path As String
    Dim IP As String = String.Empty
    Dim Site1 As String
    Dim Username As String
    Dim Site2 As String
    Dim DtScan As DataTable
    Private Sub FrmSuratJalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
        Call Proc_EnableButtons(True, True, False, True, False, False, False, False)
    End Sub
    Public Overrides Sub Proc_InputNewData()
        GridView2.AddNewRow()
        GridView2.OptionsNavigation.AutoFocusNewRow = True
        GridView2.FocusedColumn = GridView2.VisibleColumns(0)
    End Sub
    Public Overrides Sub Proc_Refresh()
        Dim i As Integer = 0

        While i < GridView2.RowCount
            GridView2.DeleteRow(i)
        End While
    End Sub
    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(11) {New DataColumn("No Surat Jalan", GetType(String)),
                                                            New DataColumn("PO Customer", GetType(String)),
                                                            New DataColumn("SR YIM", GetType(String)),
                                                            New DataColumn("Tanggal Terima", GetType(DateTime)),
                                                            New DataColumn("Tanggal Kirim", GetType(DateTime)),
                                                            New DataColumn("Customer", GetType(String)),
                                                            New DataColumn("NoRec", GetType(String)),
                                                            New DataColumn("Tanggal SJ", GetType(String)),
                                                            New DataColumn("Sales Order", GetType(String)),
                                                            New DataColumn("Batch Invoice", GetType(String)),
                                                            New DataColumn("Ket", GetType(String)),
                                                            New DataColumn("Batch Issue", GetType(String))})

        GridTransaksi.DataSource = DtScan
        GridView2.OptionsView.ShowAutoFilterRow = False

    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            Dim IsEmpty As Boolean = False
            If GridView2.RowCount = 0 Then
                Throw New Exception("Data kosong !")
            End If
            'GridView2.PopulateColumns()

            For i As Integer = 0 To GridView2.RowCount - 1
                GridView2.MoveFirst()
                If GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal SJ")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Terima")).ToString = "" Then
                    IsEmpty = True
                    Exit For
                End If
            Next
            If IsEmpty Then
                Throw New Exception("Silahkan Hapus dulu baris yang kosong !")
            End If
            For i As Integer = 0 To GridView2.RowCount - 1
                Dim Checked As Boolean = False
                Dim ShipperID, NoRec As String
                Dim RelDate, RecDate, TglKirim As DateTime

                ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
                'Dim Dt As DateTime = DateTime.ParseExact(frm_pembayaran.txtTanggal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                RelDate = DateTime.ParseExact(GridView2.GetRowCellValue(i.ToString, GridView2.Columns("Tanggal SJ")), "dd-MM-yyyy", CultureInfo.InvariantCulture)
                RecDate = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Terima")) Is DBNull.Value, DateTime.Now, (GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Terima"))))
                TglKirim = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Kirim")) Is DBNull.Value, DateTime.Now, (GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Kirim"))))
                'Checked = GridView1.GetRowCellValue(i, "Check")
                NoRec = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("NoRec")) Is DBNull.Value, "", GridView2.GetRowCellValue(i, GridView2.Columns("NoRec")))
                'NoRec = GridView2.GetRowCellValue(i, GridView2.Columns("NoRec"))
                'Exit Sub
                Try
                    'If ShipperID = "" OrElse RelDate = "" OrElse RecDate = "" Then
                    '    Throw New Exception("Data kosong !")
                    'Else
                    Dim IsShipperExist1 As Boolean
                    With SuratJalan
                        .UpdateUser6(ShipperID, True)
                        .ShipperID = ShipperID
                        .RelDate = RelDate
                        .RecDate = Format(RecDate, gs_FormatSQLDate)
                        .TglKirim = Format(TglKirim, gs_FormatSQLDate)
                        .NoRec = NoRec
                        .NoTran = ""
                        .Checked = True
                        .CreatedBy = gh_Common.Username
                        IsShipperExist1 = .IsShipperIDExist
                        If IsShipperExist1 Then
                            .UpdateToTable_Scan()
                            'MsgBox("Data Sudah ada !")
                        Else
                            .InsertToTable()
                        End If
                    End With
                    'End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Continue For
                End Try
            Next
            'btnFilter.Enabled = False
            MsgBox("Data Saved !", MsgBoxResult.No)
            CreateTable()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridTransaksi_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridTransaksi.ProcessGridKey
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        Try
            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                e.Handled = True
            End If

            If e.KeyData = Keys.Enter Then
                If GridView2.FocusedColumn.FieldName = "No Surat Jalan" Then
                    If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "No Surat Jalan") Is DBNull.Value Then
                        GridView2.FocusedColumn = GridView2.VisibleColumns(0)
                        GridView2.ShowEditor()
                        Throw New Exception("No Surat Jalan  tidak boleh kosong !")
                    End If
                    Dim dt As New DataTable
                    dt = SuratJalan.GetSJ(GridView2.GetFocusedRowCellValue("No Surat Jalan").ToString(), gh_Common.Site)
                    If dt.Rows.Count > 0 Then
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Customer", dt.Rows(0)(0))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "No Surat Jalan", dt.Rows(0)(1))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PO Customer", dt.Rows(0)(3))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal SJ", dt.Rows(0)(4).ToString)
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Terima", dt.Rows(0)(5))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Sales Order", dt.Rows(0)(2))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "NoRec", dt.Rows(0)(7))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "SR YIM", dt.Rows(0)(8))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Kirim", dt.Rows(0)(6))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Invoice", dt.Rows(0)(9))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Ket", dt.Rows(0)(10))
                        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Issue", dt.Rows(0)(11))
                        GridView2.FocusedColumn = GridView2.VisibleColumns(3)
                        GridView2.ShowEditor()
                        'GridView2.PostEditor()
                        GridView2.UpdateCurrentRow()
                        'GridView2.PopulateColumns()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                    End If
                End If

                If GridView2.FocusedColumn.FieldName = "PO Customer" Then
                    If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "PO Customer") Is DBNull.Value Then
                        GridView2.FocusedColumn = GridView2.VisibleColumns(1)
                        GridView2.ShowEditor()
                        Throw New Exception("PO Customer  tidak boleh kosong !")
                    End If
                    Dim dt As New DataTable
                    dt = SuratJalan.GetSJByPOCustomer(GridView2.GetFocusedRowCellValue("PO Customer").ToString(), gh_Common.Site)
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If i = 0 Then
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Customer", dt.Rows(i)(0))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "No Surat Jalan", dt.Rows(i)(1))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PO Customer", dt.Rows(i)(3))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal SJ", dt.Rows(i)(4).ToString)
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Terima", dt.Rows(i)(5))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Sales Order", dt.Rows(i)(2))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "NoRec", dt.Rows(i)(7))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "SR YIM", dt.Rows(i)(8))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Kirim", dt.Rows(i)(6))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Invoice", dt.Rows(i)(9))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Ket", dt.Rows(i)(10))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Issue", dt.Rows(i)(11))
                                GridView2.FocusedColumn = GridView2.VisibleColumns(3)
                                GridView2.ShowEditor()
                                'GridView2.PopulateColumns()
                                'GridView2.PostEditor()
                                GridView2.UpdateCurrentRow()
                            Else
                                GridView2.AddNewRow()
                                GridView2.OptionsNavigation.AutoFocusNewRow = True
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Customer", dt.Rows(i)(0))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "No Surat Jalan", dt.Rows(0)(1))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PO Customer", dt.Rows(i)(3))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal SJ", dt.Rows(i)(4).ToString)
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Terima", dt.Rows(i)(5))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Sales Order", dt.Rows(i)(2))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "NoRec", dt.Rows(i)(7))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "SR YIM", dt.Rows(i)(8))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Kirim", dt.Rows(i)(6))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Invoice", dt.Rows(i)(9))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Ket", dt.Rows(i)(10))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Issue", dt.Rows(i)(11))
                                GridView2.FocusedColumn = GridView2.VisibleColumns(3)
                                GridView2.ShowEditor()
                                'GridView2.PopulateColumns()
                                'GridView2.PostEditor()
                                GridView2.UpdateCurrentRow()
                            End If

                        Next

                        'SendKeys.Send("{TAB}")
                        'GridView2.PostEditor()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                    End If
                End If

                If GridView2.FocusedColumn.FieldName = "SR YIM" Then
                    If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "SR YIM") Is DBNull.Value Then
                        GridView2.FocusedColumn = GridView2.VisibleColumns(2)
                        GridView2.ShowEditor()
                        Throw New Exception("RS YIM  tidak boleh kosong !")
                    End If
                    Dim dt As New DataTable
                    dt = SuratJalan.GetSJBySRYIM(GridView2.GetFocusedRowCellValue("SR YIM").ToString(), gh_Common.Site)
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If i = 0 Then
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Customer", dt.Rows(i)(0))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "No Surat Jalan", dt.Rows(i)(1))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PO Customer", dt.Rows(i)(3))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal SJ", dt.Rows(i)(4).ToString)
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Terima", dt.Rows(i)(5))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Sales Order", dt.Rows(i)(2))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "NoRec", dt.Rows(i)(7))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "SR YIM", dt.Rows(i)(8))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Kirim", dt.Rows(i)(6))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Invoice", dt.Rows(i)(9))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Ket", dt.Rows(i)(10))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Issue", dt.Rows(i)(11))
                                GridView2.FocusedColumn = GridView2.VisibleColumns(3)
                                GridView2.ShowEditor()
                                'GridView2.PopulateColumns()
                                'GridView2.PostEditor()
                                GridView2.UpdateCurrentRow()
                            Else
                                GridView2.AddNewRow()
                                GridView2.OptionsNavigation.AutoFocusNewRow = True
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Customer", dt.Rows(i)(0))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "No Surat Jalan", dt.Rows(i)(1))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PO Customer", dt.Rows(i)(3))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal SJ", dt.Rows(i)(4).ToString)
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Terima", dt.Rows(i)(5))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Sales Order", dt.Rows(i)(2))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "NoRec", dt.Rows(i)(7))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "SR YIM", dt.Rows(i)(8))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Tanggal Kirim", dt.Rows(i)(6))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Invoice", dt.Rows(i)(9))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Ket", dt.Rows(i)(10))
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Batch Issue", dt.Rows(i)(11))
                                GridView2.FocusedColumn = GridView2.VisibleColumns(3)
                                GridView2.ShowEditor()
                                'GridView2.PopulateColumns()
                                'GridView2.PostEditor()
                                GridView2.UpdateCurrentRow()
                            End If

                        Next
                        'SendKeys.Send("{TAB}")
                        'GridView2.PostEditor()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                    End If
                End If
                'GridView2.AddNewRow()
                'GridView2.UpdateCurrentRow()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub RepositoryItemDateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit2.EditValueChanged
        GridTransaksi.FocusedView.PostEditor()
    End Sub
    Private Sub RepositoryItemTextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1.EditValueChanged
        GridTransaksi.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemTextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit2.EditValueChanged
        GridTransaksi.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemTextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit3.EditValueChanged
        GridTransaksi.FocusedView.PostEditor()
    End Sub
    Private Sub RepositoryItemTextEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit4.EditValueChanged
        GridTransaksi.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemDateEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit4.EditValueChanged
        GridTransaksi.FocusedView.PostEditor()
    End Sub
    Private Sub GridView2_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView2.CustomDrawRowIndicator
        GridView2.IndicatorWidth = 50
        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)
            e.Appearance.DrawString(e.Cache, " No", e.Bounds)
            e.Handled = True
        End If
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle.ToString()
        End If
    End Sub

    Private Sub FrmSuratJalan_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Proc_InputNewData()
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridTransaksi_Click(sender As Object, e As EventArgs) Handles GridTransaksi.Click

    End Sub
End Class
