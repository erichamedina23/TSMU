Public Class FrmSystem_Filter
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
            '# Setting grid...
            '# Define styles...
            'Column Header
            Dim StyleColumn As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            'Normal Row
            Dim StyleNormal As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            'Alternate Row
            Dim StyleAlternate As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle

            With StyleColumn
                .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .BackColor = gcl_GridFixedDarkblue
                .Font = New System.Drawing.Font(gs_AppFontName, gsi_AppFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .ForeColor = gcl_GridFixedFore
                .SelectionBackColor = System.Drawing.SystemColors.Highlight
                .SelectionForeColor = System.Drawing.SystemColors.HighlightText
                .WrapMode = System.Windows.Forms.DataGridViewTriState.False
            End With
            StyleAlternate.BackColor = gcl_GridNormalBack1
            With StyleNormal
                .BackColor = gcl_GridAlternateBack1
                .WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                .Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
            End With

            With GridFilter
                .Font = Me.Font
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeRows = False
                .AllowUserToResizeColumns = True
                .AlternatingRowsDefaultCellStyle = StyleAlternate
                .Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
                .AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells

                .CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
                .ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
                .ColumnHeadersDefaultCellStyle = StyleColumn
                .ColumnHeadersHeight = 24
                .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
                .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                .EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
                .EnableHeadersVisualStyles = False
                .ReadOnly = True
                .RowHeadersVisible = False
                .RowsDefaultCellStyle = StyleNormal
                .ShowEditingIcon = False
                .ShowRowErrors = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False

            End With

            Dim query As String = ""

            If CustomQuery.Trim <> "" Then
                '# Query ditentukan sendiri :
                query = CustomQuery.Trim
            End If

            If GridData IsNot Nothing Then
                GridFilter.DataSource = GridData
            Else
                Dim dt As DataTable = MainModul.GetDataTable(query)
                GridFilter.DataSource = dt
                GridData = GridFilter.DataSource
            End If

            If _HiddenCols IsNot Nothing AndAlso _HiddenCols.Length > 0 Then
                For i As Integer = 0 To _HiddenCols.Length - 1
                    If _HiddenCols(i) > -1 AndAlso _HiddenCols(i) <= GridFilter.ColumnCount - 1 Then
                        GridFilter.Columns(_HiddenCols(i)).Visible = False
                    End If
                Next
            End If
            GridFilter.ClearSelection()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Call SelectValue()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub GridFilter_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridFilter.DataSourceChanged
        Dim GridView As DataGridView = sender
        With GridView
            For iCol As Integer = 0 To .Columns.Count - 1
                If .Columns(iCol).ValueType Is GetType(DateTime) Then
                    '# Date format...
                    .Columns(iCol).DefaultCellStyle.Format = "dd MMM yyyy - HH:mm:ss"
                ElseIf .Columns(iCol).ValueType Is GetType(Decimal) Then
                    .Columns(iCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(iCol).DefaultCellStyle.Format = gs_FormatDecimal
                End If
            Next
        End With
    End Sub

    Private Sub GridFilter_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridFilter.DoubleClick

    End Sub

    Private Sub SelectValue()
        With GridFilter
            If .CurrentRow IsNot Nothing Then
                'If .CurrentRow.Index >= 0 Then
                Me.SelectedValue = Trim(.Item(0, .CurrentRow.Index).Value & "")
                Me.SelectedDesc = Trim(.Item(1, .CurrentRow.Index).Value & "")
                Me.SelectedRow = TryCast(.CurrentRow.DataBoundItem, DataRowView)
                'Me.Close()
            End If
            Me.Close()
        End With
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.SendWait(vbTab)
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        '# Cari entry di Grid sesuai isi textbox...
        Dim searchEntry As String = TxtSearch.Text.Trim.ToLower
        searchEntry = "%" & searchEntry.Replace("%", " ") & "%"
        Dim dtfilter As New DataTable

        '# Filter query...
        Dim filterquery As String = _
        ""
        For iCol As Integer = 0 To GridData.Columns.Count - 1
            dtfilter.Columns.Add(GridData.Columns(iCol).ColumnName, GridData.Columns(iCol).DataType)
            If GridData.Columns(iCol).DataType Is GetType(Decimal) OrElse GridData.Columns(iCol).DataType Is GetType(Int32) Then
                If IsNumeric(searchEntry.Replace("%", "")) Then
                    filterquery &= _
                "[" & GridData.Columns(iCol).ColumnName & "] = " & QVal(NumValue(searchEntry.Replace("%", ""))) & " OR "
                End If
            ElseIf GridData.Columns(iCol).DataType Is GetType(Date) Then
                If IsDate(searchEntry.Replace("%", "")) Then
                    filterquery &= _
                "[" & GridData.Columns(iCol).ColumnName & "] = " & QVal(searchEntry.Replace("%", "")) & " OR "
                End If
            Else
                If GridData.Columns(iCol).ColumnName.Trim.ToLower <> "orderby" Then
                    filterquery &= _
                    "[" & GridData.Columns(iCol).ColumnName & "] LIKE " & QVal(searchEntry) & " OR "
                End If
            End If
        Next
        filterquery = filterquery.Remove(filterquery.LastIndexOf("OR "), 3)
        Dim filterrows As DataRow() = GridData.Select(filterquery)
        If filterrows IsNot Nothing Then
            With filterrows
                For iCount As Integer = 0 To .Length - 1
                    With dtfilter.Rows.Add
                        For iCol As Integer = 0 To GridData.Columns.Count - 1
                            .Item(iCol) = filterrows(iCount).Item(iCol)
                        Next
                    End With
                    'dtfilter.Rows.Add(filterrows(iCount))
                Next
            End With
        End If
        Dim found As Boolean = False
        GridFilter.DataSource = dtfilter
    End Sub

    Private Sub GridFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridFilter.KeyDown
        If e.KeyCode = Keys.Enter AndAlso GridFilter.CurrentRow IsNot Nothing Then
            BtnOK.PerformClick()
        ElseIf e.KeyCode = Keys.Up AndAlso GridFilter.CurrentRow IsNot Nothing AndAlso GridFilter.CurrentRow.Index = 0 Then
            Call SelectNextControl(GridFilter, False, True, False, False)
        End If
    End Sub

    Private Sub TextboxKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSearch.KeyPress
        If sender.GetType Is GetType(TextBox) Then
            If e.KeyChar = "'" Then e.Handled = True
            'If (Asc(e.KeyChar) < 48 OrElse Asc(e.KeyChar) > 57) _
            '    AndAlso (Asc(e.KeyChar) < Keys.A OrElse Asc(e.KeyChar) > Keys.Z) _
            '    AndAlso (Asc(e.KeyChar) < 97 OrElse Asc(e.KeyChar) > 122) _
            '    AndAlso Asc(e.KeyChar) <> Keys.Space AndAlso Asc(e.KeyChar) <> Keys.Back _
            '    AndAlso Asc(e.KeyChar) <> 46 AndAlso Asc(e.KeyChar) <> 44 Then
            '    e.Handled = True
            'End If
        End If
    End Sub

    Private Sub GridFilter_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridFilter.CellContentDoubleClick
        Call SelectValue()
    End Sub
End Class