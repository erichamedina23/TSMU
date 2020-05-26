Public Class FrmSystem_FilterDev
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

    Property HiddenCols() As Integer
        Get
            Return _HiddenCols.Length
        End Get
        Set(ByVal value As Integer)
            If _HiddenCols Is Nothing Then
                ReDim Preserve _HiddenCols(0)
            Else
                ReDim Preserve _HiddenCols(_HiddenCols.Length)
            End If
            _HiddenCols(_HiddenCols.Length - 1) = value
        End Set
    End Property

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

    ReadOnly Property Result(Optional ByVal Item As ReturnType = ReturnType.Kode) As String
        Get
            If Item = ReturnType.Kode Then
                Return SelectedValue
            Else
                Return SelectedDesc
            End If
        End Get
    End Property

    ReadOnly Property Values() As DataRowView
        Get
            Return SelectedRow
        End Get
    End Property

    Private Sub FrmFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If _HiddenCols IsNot Nothing AndAlso _HiddenCols.Length > 0 Then
                For i As Integer = 0 To _HiddenCols.Length - 1
                    If _HiddenCols(i) > -1 AndAlso _HiddenCols(i) <= GridView1.Columns.Count - 1 Then
                        GridView1.Columns(_HiddenCols(i)).Visible = False
                    End If
                Next
            End If
            'Grid.ClearSelection()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    'Private Sub GridFilter_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim GridView As DataGridView = sender
    '    With GridView
    '        For iCol As Integer = 0 To .Columns.Count - 1
    '            If .Columns(iCol).ValueType Is GetType(DateTime) Then
    '                '# Date format...
    '                .Columns(iCol).DefaultCellStyle.Format = "dd MMM yyyy - HH:mm:ss"
    '            ElseIf .Columns(iCol).ValueType Is GetType(Decimal) Then
    '                .Columns(iCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                .Columns(iCol).DefaultCellStyle.Format = gs_FormatDecimal
    '            End If
    '        Next
    '    End With
    'End Sub

    Private Sub SelectValue()
        With GridView1
            If .GetFocusedDataRow IsNot Nothing Then
                'If .CurrentRow.Index >= 0 Then
                Me.SelectedValue = .GetFocusedRowCellValue("No Tanda Terima")
                'Me.SelectedDesc = Trim(.GetFocusedRowCellValue(1))
                Me.SelectedRow = TryCast(.GetRow(GridView1.FocusedRowHandle), DataRowView)
                'Me.Close()
            End If
            Me.Close()
        End With
    End Sub
    'Private Sub GridFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter AndAlso GridView1.GetFocusedDataRow IsNot Nothing Then
    '        BtnOK.PerformClick()
    '    ElseIf e.KeyCode = Keys.Up AndAlso GridView1.GetFocusedDataRow IsNot Nothing AndAlso GridView1.GetFocusedDataSourceRowIndex = 0 Then
    '        Call SelectNextControl(Grid, False, True, False, False)
    '    End If
    'End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Call SelectValue()
    End Sub
End Class