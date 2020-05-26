Public Class FrmSystem_FilterData
    Public strWhereClause As String
    Public strWhereClauseWithoutWhere As String
    Public isCancel As Boolean = False
    Dim CboField As New ComboBox
    Dim CboType As New ComboBox
    Dim ls_Error As String
    Dim fb_Clear As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmSystem_FilterData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnClearFilter_Click(sender, e)
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
            '.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill

            '.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
            .ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
            .ColumnHeadersDefaultCellStyle = StyleColumn
            .ColumnHeadersHeight = 30
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
            .EnableHeadersVisualStyles = False
            .ReadOnly = False
            .RowHeadersVisible = False
            .RowsDefaultCellStyle = StyleNormal
            .ShowEditingIcon = False
            .ShowRowErrors = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
        End With
        GridFilter.ClearSelection()
    End Sub
    Public Sub New(ByVal strQuery As String)
        Me.new()
        Try
            ' This call is required by the Windows Form Designer.
            Dim Que As String
            Dim i As Integer
            Dim strFilter As String = ""

            Que = "SELECT * FROM (" & strQuery & ")tbAsal WHERE 1=2"
            Dim dt As DataTable = MainModul.GetDataTable(Que)
            GridFilter.RowCount = 2
            'GridFilter.
            isCancel = False
            CboField.Items.Clear()
            CboType.Items.Clear()
            For i = 0 To dt.Columns.Count - 1
                strFilter = strFilter & Trim(dt.Columns(i).ColumnName) & "|"
                CboField.Items.Add(Trim(dt.Columns(i).ColumnName))
                CboType.Items.Add(Trim(dt.Columns(i).DataType.ToString))
            Next
            strFilter = strFilter.Remove(strFilter.LastIndexOf("|"))
            'GridFilter.Columns("ColFilter").ComboList = strFilter
            'GridFilter.Select(1, GridFilter.Cols("ColFilter").Index)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Public Sub SetGrid(ByVal dtGrid As DataTable)
        ' This call is required by the Windows Form Designer.
        Dim dt As New DataTable
        Dim i As Integer
        Dim strFilter As String = ""

        dt = dtGrid
        'GridFilter.Rows.Count = 2
        isCancel = False
        CboField.Items.Clear()
        CboType.Items.Clear()
        For i = 0 To dt.Columns.Count - 1
            strFilter = strFilter & Trim(dt.Columns(i).ColumnName) & "|"
            CboField.Items.Add(Trim(dt.Columns(i).ColumnName))
            CboType.Items.Add(Trim(dt.Columns(i).DataType.ToString))
        Next
        strFilter = strFilter.Remove(strFilter.LastIndexOf("|"))
        'GridFilter.Cols("ColFilter").ComboList = strFilter
        'GridFilter.Select(1, GridFilter.Cols("ColFilter").Index)
    End Sub
    Public Sub New(ByVal dtGrid As DataTable)

        ' This call is required by the Windows Form Designer.
        Me.new()

        Dim dt As New DataTable
        'Dim i As Integer
        Dim strFilter As String = ""

        dt = dtGrid
        GridFilter.RowCount = 1
        isCancel = False
        CboField.Items.Clear()
        CboType.Items.Clear()
        For i = 0 To dt.Columns.Count - 1
            strFilter = strFilter & Trim(dt.Columns(i).ColumnName) & "|"
            CboField.Items.Add(Trim(dt.Columns(i).ColumnName))
            CboType.Items.Add(Trim(dt.Columns(i).DataType.ToString))
        Next
        Dim colNames = From dc As DataColumn In _
                       dt.Columns _
                       Select dc.ColumnName
        CType(GridFilter.Columns(0), DataGridViewComboBoxColumn).DataSource = colNames.ToList()
    End Sub
   
    Private Sub BtnClearFilter_Click(sender As Object, e As EventArgs) Handles BtnClearFilter.Click
        ClearAllFilter()
    End Sub
    Public Sub ClearAllFilter()
        'GridFilter.RowCount = 0
        Dim i As Integer
        For i = 0 To GridFilter.ColumnCount - 1
            GridFilter.Item(i, 0).Value = ""
        Next
        'GridFilter.Col = 0
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        strWhereClause = ""
        strWhereClauseWithoutWhere = ""
        isCancel = True
        Me.Hide()
    End Sub
    Private Function generateWhereClause(Optional ByVal lb_NoWhere As Boolean = False) As String
        Dim i As Integer
        Dim strWhere As String = " "
        Dim ls_Type As String = ""
        Dim ls_Kutip As String = "'"
        Dim ls_Nilai As String = ""
        Dim ls_Operator2 As String = ""
        With GridFilter
            If .Rows.Count = 1 AndAlso .Item(0, 0).Value.ToString = "" AndAlso .Item(1, 0).Value.ToString = "" Then
                strWhere = ""
                fb_Clear = True
            Else
                fb_Clear = False
                For i = 0 To .Rows.Count - 1
                    If .Item(0, i).ToString <> "" AndAlso .Item(1, i).Value.ToString <> "" Then
                        ls_Operator2 = ""
                        If i > 1 Then
                            ls_Operator2 = vbCrLf & .Item(1, i - 1).Value.ToString
                        End If
                        ls_Nilai = Trim(.Item(2, i).Value.ToString & "")
                        ls_Nilai = CStr(ls_Nilai & "").Replace("'", "''")
                        If ls_Nilai <> "" Then
                            ls_Type = CboType.Items(CboField.FindStringExact(.Item(0, i).Value.ToString.Trim))
                            If ls_Type = "System.Decimal" OrElse ls_Type = "System.Int32" Then
                                ls_Kutip = ""
                                ls_Nilai = NumValue(ls_Nilai)
                                If .Item(1, i).Value.ToString.Trim = "LIKE" Then
                                    ShowMessage("Numeric tidak bisa menggunakan operator LIKE !", MessageTypeEnum.ErrorMessage)
                                    '.Col = .Cols("Coloperator").Index
                                    '.Rows = i
                                    .Focus()
                                    Return ""
                                End If
                            ElseIf ls_Type = "System.DateTime" Then
                                If IsDate(ls_Nilai) = False Then
                                    ShowMessage("Nilai untuk tanggal salah!", MessageTypeEnum.ErrorMessage)
                                    '.Row = i
                                    .Focus()
                                    Return ""
                                ElseIf .Item(1, 0).Value.ToString.Trim = "LIKE" Then
                                    ShowMessage("DateTime tidak bisa menggunakan operator LIKE !", MessageTypeEnum.ErrorMessage)
                                    '.Col = .Cols("Coloperator").Index
                                    '.Row = i
                                    .Focus()
                                    Return ""
                                End If
                            End If
                            strWhere = strWhere & ls_Operator2 & " ( [" & .Item(0, i).Value.ToString & "] " & .Item(1, i).Value.ToString & " " & ls_Kutip & IIf(.Item(1, i).Value.ToString = "LIKE", "%", "") & IIf(.Item(1, i).Value.ToString = "LIKE", ls_Nilai.Replace("%", " "), ls_Nilai) & IIf(.Item(1, i).Value.ToString = "LIKE", "%", "") & ls_Kutip & " ) "
                        Else
                            ls_Type = CboType.Items(CboField.FindStringExact(.Item(0, i).Value.ToString.Trim))
                            If ls_Type = "System.String" Then
                                strWhere = strWhere & ls_Operator2 & " ( [" & .Item(1, i).Value.ToString & "] " & .Item(1, i).Value.ToString & " " & ls_Kutip & IIf(.Item(1, i).Value.ToString = "LIKE", "%", "") & IIf(.Item(1, i).Value.ToString = "LIKE", ls_Nilai.Replace("%", " "), ls_Nilai) & IIf(.Item(1, i).Value.ToString = "LIKE", "%", "") & ls_Kutip & " ) "
                            Else
                                ShowMessage("Nilai tidak boleh kosong untuk filter selain tipe string!", MessageTypeEnum.ErrorMessage)
                                Return ""
                            End If
                        End If
                    Else
                        ShowMessage("Filter dan Operator tidak boleh kosong!", MessageTypeEnum.ErrorMessage)
                        Return ""
                    End If
                Next
                If Trim(strWhere) <> "" AndAlso lb_NoWhere = False Then strWhere = " WHERE " & strWhere
            End If
        End With
        Return strWhere
    End Function

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Try
            strWhereClause = generateWhereClause()
            If fb_Clear = True OrElse strWhereClause <> "" Then
                strWhereClauseWithoutWhere = generateWhereClause(True)
                isCancel = False
                Me.Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
End Class