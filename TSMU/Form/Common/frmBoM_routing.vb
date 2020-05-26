Public Class frmBoM_routing
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsBoM
    Dim GridDtl As DataGridView

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim ff_detail As frmBoM_detail_input
    Dim boomId As String = String.Empty
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String, _
                   ByVal strCode2 As String, _
                   ByRef lf_FormParent As Form, _
                   ByVal li_GridRow As Integer, _
                   ByRef _Grid As DataGridView)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub frmBoM_routing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
        populateRoot()
        PopulateLvlone()
        PopulateLvltwo()
        PopulateLevel3()
        TreeLevel.ExpandAll()
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "BoM Routing " & fs_Code
            Else
                Me.Text = "BoM Routing"
            End If
            'Call LoadGridDetil()
            'Call LoadTxtBox()
            TabControl1.TabPages(0).BackColor = tabcolour
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmBoM"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    'Private Sub LoadTxtBox()
    '    Try
    '        If fs_Code <> "" Then
    '            With fc_Class
    '                _txtBoMID.Text = .BoMID
    '                _txtDate.Text = .Tgl
    '                _txtInvID.Text = .InvtID
    '                _txtDesc.Text = .Desc
    '                _cmbSite.Text = .SiteID
    '                _txtRunner.Text = .Runner
    '                _txtCycle.Text = .CycleTime
    '                _txtTon.Text = .MC
    '                btnCari.Focus()
    '            End With
    '        Else
    '            KodeOtomatis()
    '            '_txtBoMID.Text = 
    '            _txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy")
    '            _txtInvID.Text = ""
    '            _cmbSite.Text = ""
    '            _txtRunner.Text = ""
    '            _txtCycle.Text = ""
    '            _txtTon.Text = ""
    '            _txtDesc.Text = ""
    '            btnCari.Focus()
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub
    Public Overrides Sub Proc_Refresh()
        'Call LoadTxtBox()
        populateRoot()
        PopulateLvlone()
        PopulateLvltwo()
        PopulateLevel3()
        TreeLevel.ExpandAll()
    End Sub

    'Public Sub LoadGridDetil()
    '    Try
    '        Dim dtGrid As New DataTable
    '        dtGrid = fc_Class.getDetailBoM(fs_Code)
    '        GridDetail.DataSource = dtGrid
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub

    'Private Sub btnCari_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim ls_Judul As String = ""
    '        Dim dtSearch As New DataTable
    '        Dim ls_OldKode As String = ""


    '        If sender.Name = btnCari.Name Then
    '            dtSearch = fc_Class.getInvtItem
    '            ls_OldKode = _txtInvID.Text.Trim
    '            ls_Judul = "Items"

    '        End If

    '        'dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
    '        'dtSearch.Rows(0).Item(0) = "ALL"

    '        Dim lF_SearchData As FrmSystem_Filter
    '        lF_SearchData = New FrmSystem_Filter(dtSearch)
    '        lF_SearchData.Text = "Select Data " & ls_Judul
    '        lF_SearchData.ShowDialog()
    '        Dim ls_Kode As String = ""
    '        Dim ls_Nama As String = ""

    '        If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
    '            ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
    '            ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
    '            If sender.Name = btnCari.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
    '                _txtInvID.Text = ls_Kode
    '                _txtDesc.Text = ls_Nama
    '            End If
    '        End If
    '        lF_SearchData.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Private Sub KodeOtomatis()
    '    Try
    '        Dim dt As New DataTable
    '        dt = fc_Class.AutoNoBoMID()
    '        If dt.Rows.Count > 0 Then
    '            Dim bomId As String = dt.Rows(0).Item("bomid").ToString
    '            If Len(bomId) = "1" Then
    '                _txtBoMID.Text = "000000" & bomId
    '            ElseIf Len(bomId) = "2" Then
    '                _txtBoMID.Text = "00000" & bomId
    '            ElseIf Len(bomId) = "3" Then
    '                _txtBoMID.Text = "0000" & bomId
    '            ElseIf Len(bomId) = "4" Then
    '                _txtBoMID.Text = "000" & bomId
    '            ElseIf Len(bomId) = "5" Then
    '                _txtBoMID.Text = "00" & bomId
    '            ElseIf Len(bomId) = "6" Then
    '                _txtBoMID.Text = "0" & bomId
    '            ElseIf Len(bomId) = "7" Then
    '                _txtBoMID.Text = bomId
    '            End If
    '        Else
    '            _txtBoMID.Text = "0000001"
    '            '    _txtBoMID.Text = "0000001"
    '            'Else
    '            '    _txtBoMID.Text = Val(Microsoft.VisualBasic.Mid(dt.Rows(0).Item("bomid").ToString, 3, 2)) + 1
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnAdd_Click(sender As Object, e As EventArgs)
    '    Try
    '        If sender.name = btnAdd.Name Then
    '            CallForm()
    '        ElseIf sender.name = btnDelete.Name Then
    '            If GridDetail.Rows.Count < 0 Then Exit Sub
    '            GridDetail.Rows.Remove(GridDetail.SelectedRows(0))
    '            If GridDetail.Rows.Count > 1 Then GridDetail.RowCount = 1
    '            Exit Sub
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Public Sub CallForm(Optional ByVal InvtId As String = "", _
    '                    Optional ByVal Desc As String = "", _
    '                    Optional ByVal Qty As String = "", _
    '                    Optional ByVal Unit As String = "", _
    '                      Optional ByVal isnew As Boolean = True)

    '    ff_detail = New frmBoM_detail_input(InvtId, Desc, Qty, Unit, Me.Text, GridDetail, isnew)
    '    ff_detail.ShowDialog()
    'End Sub

    'Private Sub GridDetail_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If GridDtl.Rows.Count > 0 Then
    '        CallForm(GridDetail.SelectedRows(0).Cells(0).Value.ToString, _
    '                 GridDetail.SelectedRows(0).Cells(1).Value.ToString, _
    '                 GridDetail.SelectedRows(0).Cells(2).Value.ToString, _
    '                 GridDetail.SelectedRows(0).Cells(3).Value.ToString, False)
    '    End If
    'End Sub
    Sub populateRoot()
        Try

            Dim dt As New DataTable
            dt = fc_Class.getRoutingBoM(fs_Code2)
            TreeLevel.Nodes.Clear()
            TreeLevel.BeginUpdate()
            For i As Integer = 0 To dt.Rows.Count - 1
                'If dt.Rows.Count > 0 Then
                If dt.Rows(i).Item("FinishedGood") = "" Then
                Else
                    Dim node As New TreeNode
                    Dim str As String = "level 0 - " & dt.Rows(i)("FinishedGood").ToString
                    node = TreeLevel.Nodes.Add(str)
                    Dim tag As String = dt.Rows(i)("FinishedGood").ToString()
                    node.Tag = tag
                    'node.ImageIndex = ds.Tables(0).Rows(i)("imageindex")
                    'node.SelectedImageIndex = ds.Tables(0).Rows(i)("imageindex")
                    node.Name = dt.Rows(i)("FinishedGood")
                    node.Text = str
                    Exit For
                End If
            Next
            TreeLevel.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message & "Error : Add Root Tree", vbCritical)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Sub PopulateLvlone()

        Try
            TreeLevel.BeginUpdate()
            Dim dt As New DataTable
            dt = fc_Class.getRoutingBoM(TreeLevel.Nodes(0).Tag)

            Dim str As String = String.Empty
            For rw = 0 To dt.Rows.Count - 1

                Dim parent As String = dt.Rows(rw)("parentid").ToString
                If parent <> "" Then
                    If parent = TreeLevel.Nodes(0).Tag Then
                        Dim node As New TreeNode
                        str = "level 1 - " & dt.Rows(rw)("invtid").ToString
                        Dim strT = dt.Rows(rw)("invtid").ToString()
                        node = TreeLevel.Nodes(0).Nodes.Add(str)
                        node.Tag = strT
                    Else

                    End If
                End If
            Next
            TreeLevel.EndUpdate()
        Catch ex As Exception
            MsgBox(ex.Message & "Error : Add Node menu", vbCritical)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Sub PopulateLvltwo()

        Dim dt As New DataTable
        Try
            TreeLevel.BeginUpdate()
            For idx As Integer = 0 To TreeLevel.Nodes.Count - 1
                For i As Integer = 0 To TreeLevel.Nodes(idx).Nodes.Count - 1
                    dt = fc_Class.getRoutingBoM(TreeLevel.Nodes(0).Tag)

                    Dim str As String = String.Empty
                    For rw = 0 To dt.Rows.Count - 1
                        Dim parent As String = dt.Rows(rw)("parentid").ToString
                        If parent <> "" Then
                            If parent = TreeLevel.Nodes(idx).Nodes(i).Tag Then
                                Dim node As New TreeNode
                                str = "level 2 - " & dt.Rows(rw)("invtId").ToString
                                node = TreeLevel.Nodes(idx).Nodes(i).Nodes.Add(str)
                                node.Tag = dt.Rows(rw)("invtId").ToString()
                            End If
                        End If
                    Next rw
                Next
            Next
            TreeLevel.EndUpdate()
        Catch ex As Exception
            MsgBox(ex.Message & "Error : Add Node menu", vbCritical)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub PopulateLevel3()
        Dim dtTable As New DataTable
        Dim idx As Integer
        Dim rw As Integer
        Dim str As String = String.Empty
        Try
            ' Dim ct As Integer
            dtTable = fc_Class.getRoutingBoM(TreeLevel.Nodes(0).Tag)

            For idx = 0 To TreeLevel.Nodes(0).Nodes.Count - 1
                For i As Integer = 0 To TreeLevel.Nodes(0).Nodes(idx).Nodes.Count - 1
                    For rw = 0 To dtTable.Rows.Count - 1
                        Dim parent As String = dtTable.Rows(rw)("parentid").ToString
                        If parent <> "" Then
                            If parent = TreeLevel.Nodes(0).Nodes(idx).Nodes(i).Tag Then
                                Dim node As New TreeNode
                                str = "level 3 - " & dtTable.Rows(rw)("invtId").ToString
                                node = TreeLevel.Nodes(0).Nodes(idx).Nodes(i).Nodes.Add(str)
                                node.Tag = dtTable.Rows(rw)("invtId").ToString()
                            End If
                        End If
                    Next rw
                Next
            Next idx
        Catch ex As Exception
            MsgBox(ex.Message & "Error : Add Node menu", vbCritical)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub TreeLevel_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeLevel.AfterSelect
        Try
            Dim dt As New DataTable
            Dim dtheader As New DataTable
            'fc_Class.getDataByInvt(e.Node.Tag)
            dt = fc_Class.getDetailBoM_Part(e.Node.Tag)
            If dt.Rows.Count > 0 Then
                _txtDesc.Text = dt.Rows(0)("descr").ToString
                _txtQty.Text = dt.Rows(0)("qty").ToString
                _txtUnit.Text = dt.Rows(0)("unit").ToString
            Else
                _txtDesc.Text = ""
                _txtQty.Text = ""
                _txtUnit.Text = ""
            End If
            ''If dtheader.Rows.Count > 0 Then
            'With fc_Class
            '    _txtBoMID.Text = .BoMID
            '    _txtDate.Text = .Tgl
            '    _txtInvID.Text = .InvtID
            '    _txtDesc.Text = .Desc
            '    _cmbSite.Text = .SiteID
            '    _txtRunner.Text = .Runner
            '    _txtCycle.Text = .CycleTime
            '    _txtTon.Text = .MC
            '    btnCari.Focus()
            'End With
            ''End If
            ''If dt.Rows.Count > 0 Then
            'GridDetail.DataSource = dt
            ''End If

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        TreeLevel.ExpandAll()
    End Sub

    Private Sub btnCollapse_Click(sender As Object, e As EventArgs) Handles btnCollapse.Click
        TreeLevel.CollapseAll()
    End Sub
End Class
