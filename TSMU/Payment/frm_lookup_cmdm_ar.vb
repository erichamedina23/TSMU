Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraEditors.Controls

Imports DevExpress.XtraGrid.Columns

Public Class frm_lookup_cmdm_ar
    Enum ReturnType As Byte
        Kode = 0
        Nama = 1
    End Enum

    Dim CustomQuery As String = ""    '# Query yang ditentukan sendiri...
    Dim CustomQuery2 As String = ""
    Dim novoucher As String = ""
    Dim fs_Code As String = ""
    Dim SelectedValue As String = ""
    Dim SelectedDesc As String = ""
    Dim SelectedRow As DataRowView = Nothing
    Dim GridData As DataTable = Nothing
    Dim GridData2 As DataTable = Nothing

    Dim _HiddenCols() As Integer
    Private _Total As Double = 0
    Dim InvoiceNo As New List(Of batch)
    Dim ObjPaymentHeader1 As New AR_Header_Models
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal Query As String, ByVal voucher As String)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        CustomQuery = Query
        novoucher = voucher
    End Sub
    Public Sub LoadGridDetail()

        Try
            If fs_Code <> "" Then
                Dim dtGrid As New DataTable
                ObjPaymentHeader1.vrno = Label3.Text
                dtGrid = ObjPaymentHeader1.GetDataDetailByID()

                Dim dt As New DataTable

                dt.Columns.Add("EntryId")
                dt.Columns.Add("SubAccount")
                dt.Columns.Add("Account")
                dt.Columns.Add("Description")
                dt.Columns.Add("Amount", GetType(Single))
                dt.Columns.Add("RcptDisbFlg")
                dt.Columns.Add("CMDMNo")

                Dim R As DataRow = dt.NewRow
                R("EntryId") = "PH"
                R("SubAccount") = "10000"
                R("Account") = "11708"
                R("Description") = "Prepaid PPH 23"
                R("Amount") = Convert.ToSingle(pph)
                R("RcptDisbFlg") = ""
                R("CMDMNo") = ObjPaymentHeader1.CMDMNo
                dt.Rows.Add(R)

                Dim A As DataRow = dt.NewRow
                A("EntryId") = "BC"
                A("SubAccount") = "10000"
                A("Account") = "62370"
                A("Description") = "Bank Charges"
                A("Amount") = Convert.ToSingle(bc)
                A("RcptDisbFlg") = ""
                Dim konter As String

                If Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) < 10 Then
                    konter = "000" & Convert.ToString((Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) + 1))
                ElseIf Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) < 100 Then
                    konter = "00" & Convert.ToString((Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) + 1))
                ElseIf Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) < 1000 Then
                    konter = "0" & Convert.ToString((Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) + 1))
                Else
                    konter = Convert.ToString((Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) + 1))
                End If

                ' A("CMDMNo") = Strings.Left(ObjPaymentHeader1.CMDMNo, 11) & Convert.ToString((Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) + 1))
                A("CMDMNo") = Strings.Left(ObjPaymentHeader1.CMDMNo, 11) & konter
                dt.Rows.Add(A)

                dtGrid.Merge(dt, True, MissingSchemaAction.Ignore)

                GridControl1.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridView2)
                End If
            Else
                Dim dtGrid As New DataTable
                ObjPaymentHeader1.vrno = ""
                dtGrid = ObjPaymentHeader1.GetDataDetailByID()
                GridControl1.DataSource = dtGrid
            End If
            '   GridView2.AddNewRow()
            GridView2.OptionsNavigation.AutoFocusNewRow = True
            GridView2.FocusedColumn = GridView2.VisibleColumns(0)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub New(ByVal dt As DataTable, ByVal st As String)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
        Label3.Text = st
        fs_Code = st
    End Sub

    ReadOnly Property Total() As Double
        Get
            Return _Total
        End Get
    End Property
    ReadOnly Property ListNoInvoice() As List(Of batch)
        Get
            Return InvoiceNo
        End Get
    End Property
    Public Property pph() As String
    Public Property bc() As String
    Private Sub frm_lookup_cmdm_ar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LoadGridDetail()
            'Dim query As String = ""
            'Dim query2 As String = ""
            'If CustomQuery.Trim <> "" Then
            '    '# Query ditentukan sendiri :
            '    query = CustomQuery.Trim
            'End If

            'If CustomQuery2.Trim <> "" Then
            '    '# Query ditentukan sendiri :
            '    query2 = CustomQuery2.Trim
            'End If

            'If GridData IsNot Nothing Then
            Grid.DataSource = GridData
            'Else
            '    Dim dt As DataTable = MainModul.GetDataTable(query)
            '    Grid.DataSource = dt
            'GridData = Grid.DataSource
            'End If

            'If GridData2 IsNot Nothing Then
            '    GridControl1.DataSource = GridData2
            'Else
            '    Dim dt As DataTable = MainModul.GetDataTable(query)
            '    GridControl1.DataSource = dt
            '    GridData2 = GridControl1.DataSource
            'End If

            'GridCellFormat(GridView1)
            'GridCellFormat(GridView2)
            ''Dim Check As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()
            ''Check.ValueChecked = 1
            ''Check.ValueUnchecked = 0
            ''GridView1.Columns("Check").ColumnEdit = Check
            'GridView1.ClearSelection()
            'GridView2.ClearSelection()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try


    End Sub
    Private Sub filterentry_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles filterentry.ButtonClick
        Try
            ObjPaymentHeader1 = New AR_Header_Models
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjPaymentHeader1.GetEntry
            ls_OldKode = IIf(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EntryId") Is DBNull.Value, "", GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EntryId"))
            ls_Judul = "EntryId"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            Dim Value4 As String = ""
            Dim Value5 As String = ""
            ''  Value5 = ObjPaymentHeader1.CMDMNo

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                Value4 = lF_SearchData.Values.Item(3).ToString.Trim
                ' Value5 = ObjPaymentHeader1.CMDMNo

                Dim konter2 As String
                Dim konter3 As String

                If GridView2.RowCount > 0 Then
                    konter2 = GridView2.RowCount + (Convert.ToSingle(Strings.Right(ObjPaymentHeader1.CMDMNo, 4)) - 1)
                End If

                If konter2 < 10 Then
                    konter3 = "000" & konter2
                ElseIf konter2 < 100 Then
                    konter3 = "00" & konter2
                ElseIf konter2 < 1000 Then
                    konter3 = "0" & konter2
                Else
                    konter3 = konter2
                End If
                Value5 = Strings.Left(ObjPaymentHeader1.CMDMNo, 11) & konter3
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "EntryId", Value1)
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Account", Value2)
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "SubAccount", Value3)
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Description", Value4)
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "CMDMNo", Value5)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Up AndAlso GridView1.GetSelectedRows IsNot Nothing AndAlso GridView1.FocusedRowHandle = 0 Then
            Call SelectNextControl(Grid, False, True, False, False)
        End If
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        GetTotalCM()
        GetInvoiceNo()
        GetTotalAR()
        Me.Close()
    End Sub

    'Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
    '    Try
    '        If e.Column.FieldName = "Check" Then
    '            _Total = 0
    '            If GridView1.GetRowCellValue(e.RowHandle, "cek") = True Then
    '                total_dpp = total_dpp + CDbl(GridView1.GetRowCellValue(e.RowHandle, "TotalCMDM"))
    '            Else
    '                total_dpp = total_dpp - CDbl(GridView1.GetRowCellValue(e.RowHandle, "TotalCMDM"))
    '            End If

    '        End If
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub GetTotalCM()
        Try
            ' _Total = 0
            'ObjPaymentHeader1.ObjBatch.Clear()
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    _Total = _Total + CDbl(GridView1.GetRowCellValue(i, "CuryCrTot"))
                    'Dim ObjBatch As New batch
                    'With ObjBatch
                    '    .InvNO = GridView1.GetRowCellValue(i, "no_invoice")
                    'End With
                    'ObjPaymentHeader1.ObjBatch.Add(ObjBatch)
                End If
            Next
            _Total = _Total - Convert.ToSingle(pph)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetInvoiceNo() As List(Of batch)
        Try
            Dim Batch As List(Of batch) = New List(Of batch)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    InvoiceNo.Add(New batch With {
                        .BatchNO = GridView1.GetRowCellValue(i, "batnbr")
                                  })
                End If
            Next
            Return InvoiceNo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    Private Sub GAmount_EditValueChanged(sender As Object, e As EventArgs) Handles GAmount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    'Private Sub tcmdmno_EditValueChanged(sender As Object, e As EventArgs) Handles tcmdmno.EditValueChanged
    '    Dim baseEdit = TryCast(sender, BaseEdit)
    '    Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
    '    gridView.PostEditor()
    '    gridView.UpdateCurrentRow()
    'End Sub
    Private Sub GetTotalAR()
        Try
            For i As Integer = 0 To GridView2.RowCount - 1

                _Total = _Total + CDbl(GridView2.GetRowCellValue(i, "Amount"))

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frm_lookup_cmdm_ar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView2.AddNewRow()
            GridView2.OptionsNavigation.AutoFocusNewRow = True
            GridView2.FocusedColumn = GridView2.VisibleColumns(0)
        End If
    End Sub

    Private Sub frm_lookup_cmdm_ar_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'LoadGridDetail()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GridView2.AddNewRow()
        GridView2.OptionsNavigation.AutoFocusNewRow = True
        GridView2.FocusedColumn = GridView2.VisibleColumns(0)
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class