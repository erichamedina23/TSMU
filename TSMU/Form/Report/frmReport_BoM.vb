Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid

Public Class frmReport_BoM
    Dim fc_class As New clsReport
    Dim fdtl_Config As DataTable = Nothing
    Dim BomHeader As New clsBoM
    Private Sub frmReport_BoM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
        Init()
        ProgBar.Visible = False
        PBMultiLevel.Visible = False
        PBMaterial.Visible = False
    End Sub
    Private Sub Init()
        cmbSite.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0
        cmbStatusM.SelectedIndex = 0
        Grid.DataSource = Nothing
        cmbSite.Focus()
        _txtInvID.Text = "ALL"

        _txtInvtID2.Text = "ALL"
        GridMultiLevel.DataSource = Nothing
        _txtInvtID2.Focus()

        '_txtIvtId3.Text = "ALL"
        GridMaterial.DataSource = Nothing
        '_txtIvtId3.Focus()
        LoadGridHeaderBoM()
    End Sub
    Sub LoadTxtBox()
        If TabControl1.SelectedTab Is TabPage1 Then
            If ProgBar.Visible = True Then
                MsgBox("Proses Routing masih berjalan !")
                Exit Sub
            Else
                cmbSite.SelectedIndex = 0
                cmbStatus.SelectedIndex = 0
                Grid.DataSource = Nothing
                cmbSite.Focus()
                _txtInvID.Text = "ALL"
            End If

        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            If PBMultiLevel.Visible = True Then
                MsgBox("Proses Multi Level masih berjalan !")
                Exit Sub
            Else
                _txtInvtID2.Text = "ALL"
                GridMultiLevel.DataSource = Nothing
                _txtInvtID2.Focus()
            End If

        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            If PBMaterial.Visible = True Then
                MsgBox("Proses Material masih berjalan !")
                Exit Sub
            Else
                '_txtIvtId3.Text = "ALL"
                GridMaterial.DataSource = Nothing
                '_txtIvtId3.Focus()
            End If
        Else
            If PBMaterial.Visible = True Then
                MsgBox("Proses Material masih berjalan !")
                Exit Sub
            Else
                '_txtIvtId3.Text = "ALL"
                GridHeaderBoM.DataSource = Nothing
                '_txtIvtId3.Focus()
            End If
        End If
    End Sub
    Public Overrides Sub Proc_Refresh()
        Try
            'If ProgBar.Visible = True OrElse PBMaterial.Visible = True OrElse PBMultiLevel.Visible = True Then
            '    Throw New Exception("Process already running, Please wait !")
            'End If
            Call LoadTxtBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Overrides Sub Proc_PrintPreview()
        PrintDokumen(True)
        'LoadAllReport()

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If TabControl1.SelectedTab Is TabPage3 Then
                If GridView3.RowCount > 0 Then
                    SaveToExcel(GridMaterial)
                Else
                    MsgBox("Grid Kosong !")
                End If

            ElseIf TabControl1.SelectedTab Is TabPage1 Then
                If GridView1.RowCount > 0 Then
                    SaveToExcel(Grid)
                Else
                    MsgBox("Grid Kosong !")
                End If
            ElseIf TabControl1.SelectedTab Is TabPage2 Then
                If GridView2.RowCount > 0 Then
                    SaveToExcel(GridMultiLevel)
                Else
                    MsgBox("Grid Kosong !")
                End If
            Else
                If GridView4.RowCount > 0 Then
                    SaveToExcel(GridHeaderBoM)
                Else
                    MsgBox("Grid Kosong !")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub cmbSite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSite.KeyPress, cmbStatus.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub frmReport_BoM_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cmbSite.Focus()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click, _btnFind.Click
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If sender.Name = btnCari.Name Then
                dtSearch = fc_class.getInvtItem
                ls_OldKode = _txtInvID.Text.Trim
                ls_Judul = "Part"
            ElseIf sender.Name = _btnFind.Name Then
                dtSearch = fc_class.getInvtItem
                ls_OldKode = _txtInvtID2.Text.Trim
                ls_Judul = "Part"
                'ElseIf sender.Name = btnFind3.Name Then
                '    dtSearch = fc_class.getInvtUsedBy
                '    ls_OldKode = _txtIvtId3.Text.Trim
                '    ls_Judul = "Part"
            End If

            dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            dtSearch.Rows(0).Item(0) = "ALL"
            dtSearch.Rows(0).Item(1) = "ALL"

            Dim lF_SearchData As FrmSystem_Filter
            lF_SearchData = New FrmSystem_Filter(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                If sender.Name = btnCari.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _txtInvID.Text = ls_Kode
                    _txtInvID.Focus()
                End If
                If sender.Name = _btnFind.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _txtInvtID2.Text = ls_Kode
                End If
                'If sender.Name = btnFind3.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                '    _txtIvtId3.Text = ls_Kode
                'End If
            End If

            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try

            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGrid())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GetDataGrid()
        Dim strSite As String = ""
        Dim strStatus As String = ""
        Dim strinvtID As String = ""
        Invoke(Sub()
                   strSite = cmbSite.Text
                   strStatus = cmbStatus.Text
                   strinvtID = _txtInvID.Text
               End Sub)
        Dim dt As New DataTable
        dt = fc_class.DataGridBoMRouting(strSite, strStatus, strinvtID)
        setDataSource(dt, Grid)

        Invoke(Sub()
                   ProgBar.Visible = False
                   If GridView1.RowCount > 0 Then
                       GridView1.BestFitColumns()
                   End If
               End Sub)

    End Sub

    Private Sub GetDataGridMultiLevel()
        Dim strinvtID As String = ""
        Invoke(Sub()
                   strinvtID = _txtInvtID2.Text
               End Sub)
        Dim dt As New DataTable
        dt = fc_class.MultiLevelBoM(strinvtID)
        setDataSource(dt, GridMultiLevel)
        Invoke(Sub()
                   PBMultiLevel.Visible = False
               End Sub)
        'If Not Me.InvokeRequired Then
        '    PBMultiLevel.Visible = False
        'End If
    End Sub
    Private Sub GetDataGridMaterialUsedBy()
        Dim strSite As String = ""
        Dim strStatus As String = ""
        Dim strinvtID As String = ""
        Invoke(Sub()
                   strSite = "ALL"
                   strStatus = "ALL"
                   'strinvtID = _txtIvtId3.Text
               End Sub)
        Dim dt As New DataTable
        dt = ShowGridMateriamUsedBy_New()
        'dt = ShowGridMateriamUsedBy(strinvtID)
        'ShowGridMateriamUsedBy_New
        '
        setDataSource(dt, GridMaterial)
        Invoke(Sub()
                   PBMaterial.Visible = False
                   If GridView3.RowCount > 0 Then
                       GridView3.BestFitColumns()
                   End If
               End Sub)
    End Sub

    Private Sub LoadGridHeaderBoM()
        Try
            Dim dtGrid As New DataTable
            dtGrid = BomHeader.GetAllDataTable(bs_Filter)
            GridHeaderBoM.DataSource = dtGrid
            If GridView4.RowCount > 0 Then
                GridCellFormat(GridView4)
                GridView4.BestFitColumns()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If ProgBar.Visible = True Then
        '    MsgBox("Please wait the process !")
        '    Exit Sub
        'End If
        'LoadTxtBox()
    End Sub

    Friend Delegate Sub SetDataSourceDelegate(table As DataTable, _Grid As GridControl)
    Private Sub setDataSource(table As DataTable, _Grid As GridControl)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table, _Grid)
        Else
            _Grid.DataSource = table
            'If ProgBar.Visible = True Then
            '    ProgBar.Visible = False
            'ElseIf PBMultiLevel.Visible = True Then
            '    PBMultiLevel.Visible = False
            'ElseIf PBMaterial.Visible = True Then
            '    PBMaterial.Visible = False
            'End If
        End If
    End Sub
    Public Sub PrintDokumen(Optional ByVal fb_Preview As Boolean = False)

    End Sub
    Dim dataTB As DataTable
    Dim dtFinal As DataTable

    Private Sub FillHeader_fdtlConfig()
        dataTB = New DataTable
        dataTB.Columns.Add("Material ID")
        dataTB.Columns.Add("Parent ID")
        dataTB.Columns.Add("Description")
        dataTB.Columns.Add("Unit")
        dataTB.Clear()
    End Sub

    Private Sub FillHeader_fdtlConfig_final()
        dtFinal = New DataTable
        dtFinal.Columns.Add("Material ID")
        dtFinal.Columns.Add("Parent ID")
        dtFinal.Columns.Add("Description")
        dtFinal.Columns.Add("Unit")
        dtFinal.Clear()
    End Sub

    Public Enum IndexCol As Byte
        material = 0
        parent = 1
        descr = 2
        unit = 3
    End Enum
    Dim exist As Boolean
    Private Function ShowGridMateriamUsedBy(ByVal strInvtId As String) As DataTable
        Try
            dtFinal = New DataTable
            Dim dtHeader As DataTable = fc_class.materialUsedBy_getParent()

            'If dtHeader Is Nothing Then
            '    Return dataTB
            'End If
            FillHeader_fdtlConfig_final()
            Call FillHeader_fdtlConfig()

            For i As Integer = 0 To dtHeader.Rows.Count - 1
                'exist = False

                Dim materialdt As New DataTable
                materialdt = fc_class.materialUsedBy_getMaterial(Trim(strInvtId), Trim(dtHeader.Rows(i).Item(0)))
                For k As Integer = 0 To materialdt.Rows.Count - 1
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.material) = Trim(materialdt.Rows(k).Item("Material ID") & "")
                    'dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.parent) = Trim(materialdt.Rows(k).Item("Parent ID") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.descr) = Trim(materialdt.Rows(k).Item("Description") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(materialdt.Rows(k).Item("Unit") & "")

                    Dim parentdt As New DataTable
                    parentdt = fc_class.materialUsedBy_getDataParent(Trim(strInvtId), Trim(dtHeader.Rows(i).Item(0)))
                    For j As Integer = 0 To parentdt.Rows.Count - 1

                        dataTB.Rows.Add()
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.material) = Trim(materialdt.Rows(k).Item("Material ID") & "")
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.parent) = Trim(parentdt.Rows(j).Item("Parent ID") & "")
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.descr) = Trim(parentdt.Rows(j).Item("Description") & "")
                        dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(parentdt.Rows(j).Item("Unit") & "")
                    Next

                Next
            Next

            Dim dt1 As New DataTable
            dt1 = fc_class.getInvtUsedBy
            Dim dv As DataView = New DataView(dataTB)

            For Each row As DataRow In dt1.Rows
                Dim str As String = row.Item("Invetory ID").ToString

                Dim dtFilter As New DataTable
                dv.RowFilter = "[Material ID] = '" & str & "'"
                dtFilter = dv.ToTable
                Dim distinctTable As New DataTable
                distinctTable = dtFilter.DefaultView.ToTable(True)
                For i As Integer = 0 To distinctTable.Rows.Count - 1
                    exist = False
                    For row1 As Integer = 0 To dtFinal.Rows.Count - 1
                        If str = dtFinal.Rows(row1)("Material ID").ToString Then
                            exist = True
                            Exit For
                        End If
                    Next
                    If exist Then
                        dtFinal.Rows.Add()
                        'dtFinal.Rows(dataTB.Rows.Count - 1).Item(IndexCol.material) = Trim(distinctTable.Rows(i).Item("Material ID") & "")
                        dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.parent) = Trim(distinctTable.Rows(i).Item("Parent ID") & "")
                        dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.descr) = Trim(distinctTable.Rows(i).Item("Description") & "")
                        dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.unit) = Trim(distinctTable.Rows(i).Item("Unit") & "")
                    Else
                        dtFinal.Rows.Add()
                        dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.material) = Trim(distinctTable.Rows(i).Item("Material ID") & "")
                        'dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.parent) = Trim(distinctTable.Rows(i).Item("Parent ID") & "")
                        dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.descr) = Trim(distinctTable.Rows(i).Item("Description") & "")
                        dtFinal.Rows(dtFinal.Rows.Count - 1).Item(IndexCol.unit) = Trim(distinctTable.Rows(i).Item("Unit") & "")
                    End If

                Next
            Next
            'dtFinal.Merge(dataTB)
            Return dtFinal

            'Return dataTB
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function ShowGridMateriamUsedBy_New() As DataTable
        Try
            dtFinal = New DataTable
            Dim dtHeader As New DataTable
            dtHeader = fc_class.GetMaterialUsedByNew()
            FillHeader_fdtlConfig_final()
            FillHeader_fdtlConfig()

            For i As Integer = 0 To dtHeader.Rows.Count - 1
                'exist = False
                Dim code As String = dtHeader.Rows(i)("code").ToString

                If code = "M" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.material) = Trim(dtHeader.Rows(i).Item("id") & "")
                    'dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.parent) = Trim(materialdt.Rows(i).Item("Parent ID") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.descr) = Trim(dtHeader.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(dtHeader.Rows(i).Item("unit") & "")
                Else
                    dataTB.Rows.Add()
                    'dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.material) = Trim(dtHeader.Rows(i).Item("Material ID") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.parent) = Trim(dtHeader.Rows(i).Item("id") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.descr) = Trim(dtHeader.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol.unit) = Trim(dtHeader.Rows(i).Item("unit") & "")
                End If
            Next
            Return dataTB
        Catch ex As Exception
            Throw
        End Try
    End Function
    Dim path As String
    Private Sub getPath()
        Try
            Dim folderBrowser As New FolderBrowserDialog
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
            If (folderBrowser.ShowDialog() = DialogResult.OK) Then
                path = folderBrowser.SelectedPath
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub SetGridViewSortState(ByVal dgv As DataGridView, ByVal sortMode As DataGridViewColumnSortMode)
        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = sortMode
        Next
    End Sub
    Private Async Sub tsbLoadMaterial_Click(sender As Object, e As EventArgs) Handles tsbLoadMaterial.Click
        Try
            If PBMaterial.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            PBMaterial.Visible = True
            PBMaterial.Style = ProgressBarStyle.Marquee

            Await Task.Run(Sub() GetDataGridMaterialUsedBy())
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub tsbMultiLevel_Click(sender As Object, e As EventArgs) Handles tsbMultiLevel.Click
        Try
            If PBMultiLevel.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            PBMultiLevel.Visible = True
            PBMultiLevel.Style = ProgressBarStyle.Marquee

            'Await Task.Run(Sub() GetDataGridMultiLevel())
            Await Task.Run(Sub() GeneraterMultiLevel())

        Catch ex As Exception
            PBMultiLevel.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim dtMultiLevel As DataTable
    Private Sub Dt_MultiLevel()
        dtMultiLevel = New DataTable
        dtMultiLevel.Columns.Add("Level")
        dtMultiLevel.Columns.Add("Inventory ID")
        'dtMultiLevel.Columns.Add("Description")
        'dtMultiLevel.Columns.Add("Qty")
        'dtMultiLevel.Columns.Add("Unit")
        dtMultiLevel.Clear()
    End Sub

    Private Sub GetMultiLevel_New()

        Dim strinvtID As String = ""
        Dim strStatus As String = ""
        Invoke(Sub()
                   strinvtID = _txtInvtID2.Text
                   strStatus = cmbStatusM.Text
               End Sub)

        Dim dt As New DataTable
        dt = fc_class.MultiLevelBoM_New(strinvtID, strStatus)
        Dim Level0 As String = ""
        Dim Level1 As String = ""
        Dim Level2 As String = ""
        Dim Level3 As String = ""
        Dim Level4 As String = ""

        Dt_MultiLevel()

        For i As Integer = 0 To dt.Rows.Count - 1
            If Trim(dt.Rows(i).Item("level0") & "").ToString <> "" And Trim(dt.Rows(i).Item("level0") & "").ToString <> Level0 Then
                Level0 = ""
                Level1 = ""
                Level2 = ""
                Level3 = ""
                Level4 = ""
                dtMultiLevel.Rows.Add()
                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 0"
                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level0") & "")
                Level0 = Trim(dt.Rows(i).Item("Level0") & "").ToString

                If Trim(dt.Rows(i).Item("level1") & "").ToString <> "" And Trim(dt.Rows(i).Item("level1") & "").ToString <> Level1 Then
                    dtMultiLevel.Rows.Add()
                    dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 1"
                    dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level1") & "")
                    Level1 = Trim(dt.Rows(i).Item("Level1") & "").ToString
                    If Trim(dt.Rows(i).Item("level2") & "").ToString <> "" And Trim(dt.Rows(i).Item("level2") & "").ToString <> Level2 Then
                        dtMultiLevel.Rows.Add()
                        dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 2"
                        dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level2") & "")
                        Level2 = Trim(dt.Rows(i).Item("Level2") & "").ToString
                        If Trim(dt.Rows(i).Item("level3") & "").ToString <> "" And Trim(dt.Rows(i).Item("level3") & "").ToString <> Level3 Then
                            dtMultiLevel.Rows.Add()
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 3"
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level3") & "")
                            Level3 = Trim(dt.Rows(i).Item("Level3") & "").ToString
                            If Trim(dt.Rows(i).Item("level4") & "").ToString <> "" And Trim(dt.Rows(i).Item("level4") & "").ToString <> Level4 Then
                                dtMultiLevel.Rows.Add()
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 4"
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level4") & "")
                                Level4 = Trim(dt.Rows(i).Item("Level4") & "").ToString
                            End If
                        End If
                    End If
                End If
            ElseIf Trim(dt.Rows(i).Item("level0") & "").ToString <> "" And Trim(dt.Rows(i).Item("level0") & "").ToString = Level0 Then
                If Trim(dt.Rows(i).Item("level1") & "").ToString <> "" And Trim(dt.Rows(i).Item("level1") & "").ToString <> Level1 Then
                    dtMultiLevel.Rows.Add()
                    dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 1"
                    dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level1") & "")
                    Level1 = Trim(dt.Rows(i).Item("Level1") & "").ToString
                    If Trim(dt.Rows(i).Item("level2") & "").ToString <> "" And Trim(dt.Rows(i).Item("level2") & "").ToString <> Level2 Then
                        dtMultiLevel.Rows.Add()
                        dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 2"
                        dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level2") & "")
                        Level2 = Trim(dt.Rows(i).Item("Level2") & "").ToString
                        If Trim(dt.Rows(i).Item("level3") & "").ToString <> "" And Trim(dt.Rows(i).Item("level3") & "").ToString <> Level3 Then
                            dtMultiLevel.Rows.Add()
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 3"
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level3") & "")
                            Level3 = Trim(dt.Rows(i).Item("Level3") & "").ToString
                            If Trim(dt.Rows(i).Item("level4") & "").ToString <> "" And Trim(dt.Rows(i).Item("level4") & "").ToString <> Level4 Then
                                dtMultiLevel.Rows.Add()
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 4"
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level4") & "")
                                Level4 = Trim(dt.Rows(i).Item("Level4") & "").ToString
                            End If
                        End If
                    End If
                ElseIf Trim(dt.Rows(i).Item("level1") & "").ToString <> "" And Trim(dt.Rows(i).Item("level1") & "").ToString = Level1 Then
                    If Trim(dt.Rows(i).Item("level2") & "").ToString <> "" And Trim(dt.Rows(i).Item("level2") & "").ToString <> Level2 Then
                        dtMultiLevel.Rows.Add()
                        dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 2"
                        dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level2") & "")
                        Level2 = Trim(dt.Rows(i).Item("Level2") & "").ToString
                        If Trim(dt.Rows(i).Item("level3") & "").ToString <> "" And Trim(dt.Rows(i).Item("level3") & "").ToString <> Level3 Then
                            dtMultiLevel.Rows.Add()
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 3"
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level3") & "")
                            Level3 = Trim(dt.Rows(i).Item("Level3") & "").ToString
                            If Trim(dt.Rows(i).Item("level4") & "").ToString <> "" And Trim(dt.Rows(i).Item("level4") & "").ToString <> Level4 Then
                                dtMultiLevel.Rows.Add()
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 4"
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level4") & "")
                                Level4 = Trim(dt.Rows(i).Item("Level4") & "").ToString
                            End If
                        End If
                    ElseIf Trim(dt.Rows(i).Item("level2") & "").ToString <> "" And Trim(dt.Rows(i).Item("level2") & "").ToString = Level2 Then
                        If Trim(dt.Rows(i).Item("level3") & "").ToString <> "" And Trim(dt.Rows(i).Item("level3") & "").ToString <> Level3 Then
                            dtMultiLevel.Rows.Add()
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 3"
                            dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level3") & "")
                            Level3 = Trim(dt.Rows(i).Item("Level3") & "").ToString
                            If Trim(dt.Rows(i).Item("level4") & "").ToString <> "" And Trim(dt.Rows(i).Item("level4") & "").ToString <> Level4 Then
                                dtMultiLevel.Rows.Add()
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 4"
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level4") & "")
                                Level4 = Trim(dt.Rows(i).Item("Level4") & "").ToString
                            End If
                        ElseIf Trim(dt.Rows(i).Item("level3") & "").ToString <> "" And Trim(dt.Rows(i).Item("level3") & "").ToString = Level3 Then
                            If Trim(dt.Rows(i).Item("level4") & "").ToString <> "" And Trim(dt.Rows(i).Item("level4") & "").ToString <> Level4 Then
                                dtMultiLevel.Rows.Add()
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(0) = "Level 4"
                                dtMultiLevel.Rows(dtMultiLevel.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level4") & "")
                                Level4 = Trim(dt.Rows(i).Item("Level4") & "").ToString
                            End If
                        End If
                    End If
                End If
            End If
        Next

        Dim dtHasil As New DataTable
        dtHasil = fc_class.GetMultiLevelDescription(dtMultiLevel)
        setDataSource(dtHasil, GridMultiLevel)

        Invoke(Sub()
                   PBMultiLevel.Visible = False
               End Sub)
    End Sub

    Private Sub GeneraterMultiLevel()
        Dim strinvtID As String = ""
        Dim strStatus As String = ""
        Invoke(Sub()
                   strinvtID = _txtInvtID2.Text
                   strStatus = cmbStatusM.Text
               End Sub)

        Dim dtMulti As New DataTable
        dtMulti = fc_class.MultiLevelBoM_New(strinvtID, strStatus)
        setDataSource(dtMulti, GridMultiLevel)
        Invoke(Sub()
                   PBMultiLevel.Visible = False
                   If GridView2.RowCount > 0 Then
                       GridView2.BestFitColumns()
                   End If
               End Sub)
    End Sub
End Class
