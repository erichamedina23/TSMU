Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraEditors.Repository

Public Class frm_lookup_cmdm
    Enum ReturnType As Byte
        Kode = 0
        Nama = 1
    End Enum

    Dim CustomQuery As String = ""    '# Query yang ditentukan sendiri...
    Dim SelectedValue As String = ""
    Dim SelectedDesc As String = ""
    Dim SelectedRow As DataRowView = Nothing
    Dim GridData As DataTable = Nothing
    Dim _HiddenCols() As Integer
    Private _Total As Double
    Dim InvoiceNo As New List(Of batch)
    Dim ObjPaymentHeader1 As New payment_header_models
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal Query As String)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        CustomQuery = Query
    End Sub

    Public Sub New(ByVal dt As DataTable)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
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
    Private Sub FrmSystem_LookupGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim query As String = ""

            If CustomQuery.Trim <> "" Then
                '# Query ditentukan sendiri :
                query = CustomQuery.Trim
            End If

            If GridData IsNot Nothing Then
                Grid.DataSource = GridData
            Else
                Dim dt As DataTable = MainModul.GetDataTable(query)
                Grid.DataSource = dt
                GridData = Grid.DataSource
            End If
            GridCellFormat(GridView1)
            'Dim Check As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()
            'Check.ValueChecked = 1
            'Check.ValueUnchecked = 0
            'GridView1.Columns("Check").ColumnEdit = Check
            GridView1.ClearSelection()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
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
            _Total = 0
            'ObjPaymentHeader1.ObjBatch.Clear()
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    _Total = _Total + CDbl(GridView1.GetRowCellValue(i, "TotalCMDM"))
                    'Dim ObjBatch As New batch
                    'With ObjBatch
                    '    .InvNO = GridView1.GetRowCellValue(i, "no_invoice")
                    'End With
                    'ObjPaymentHeader1.ObjBatch.Add(ObjBatch)
                End If
            Next
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
                        .BatchNO = GridView1.GetRowCellValue(i, "Bacth")
                                  })
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class