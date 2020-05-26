Imports System.Configuration
Imports System.Data.OleDb
Imports System.Globalization
Imports DevExpress.XtraGrid
Imports DevExpress.XtraSplashScreen

Public Class frmBoM
    Dim ff_Detail As frmBoM_detail
    Dim dtGrid As DataTable
    Dim BomHeader As New clsBoM
    Dim BomDetails As New clsBoMdetails
    Dim ff_routing As frmBoM_routing
    Dim OFD As New OpenFileDialog
    Dim path As String
    Dim table As DataTable
    Dim tableDetail As DataTable

    Private Sub frmBoM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False

        'Dim dtGrid As New DataTable
        'dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            dtGrid = BomHeader.GetAllDataTable(bs_Filter)
            Grid.DataSource = dtGrid
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
                GridView1.BestFitColumns()
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            OFD.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = OFD.ShowDialog()
            ' Test result.
            If result = System.Windows.Forms.DialogResult.OK Then
                path = OFD.FileName
                Dim text As String = System.IO.File.ReadAllText(path)
                'Me.Text = text.Length.ToString
            Else
                Exit Sub
            End If

            If path = "" Then
                Throw New Exception("Excel file not found !")
            End If
            Dim connString As String = String.Empty
            Dim extension As String = System.IO.Path.GetExtension(path)
            Select Case extension
                Case ".xls"
                    'Excel 97-03

                    connString = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                    Exit Select
                Case ".xlsx"
                    'Excel 07 or higher
                    connString = ConfigurationManager.ConnectionStrings("Excel07+ConString").ConnectionString
                    Exit Select

            End Select
            connString = String.Format(connString, path)
            Using excel_con As New OleDbConnection(connString)
                excel_con.Open()
                Dim Sheet1 As String = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
                'Dim _detail As String = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(2)("TABLE_NAME").ToString()

                'Dim dt As New DataTable
                'dt = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                'For i = 0 To dt.Rows.Count - 1

                '    MessageBox.Show(dt.Rows(i)("TABLE_NAME"))

                'Next
                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & Sheet1) + "]", excel_con)
                    table = New DataTable
                    oda.Fill(table)
                End Using

                'Using odaDetail As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & _detail) + "]", excel_con)
                '    tableDetail = New DataTable
                '    odaDetail.Fill(tableDetail)
                'End Using
                excel_con.Close()
            End Using
            'ImportBoMUpdateTon()
            'ImportBoMUpdateCT()
            'ImportBoMUpdateQtyDetails()
            'ImportBoMHeader()
            'Exit Sub
            If table.Rows.Count > 0 Then
                If table.Columns.Count > 10 Then
                    ImportBoMHeader()
                Else
                    ImportBoMDetails()
                End If
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub ImportBoMUpdateTon()

        Try
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomHeader

                        If table.Rows(i)("M/C Ton") Is DBNull.Value OrElse table.Rows(i)("M/C Ton").ToString = "" Then
                            .MC = ""
                        Else
                            .MC = table.Rows(i)("M/C Ton").ToString
                        End If
                        .UpdateHeaderManual(table.Rows(i)("Parent ID"))
                    End With
                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "invtid", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub ImportBoMUpdateCT()

        Try
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomHeader

                        If table.Rows(i)("Cycle Time") Is DBNull.Value OrElse table.Rows(i)("Cycle Time").ToString = "" Then
                            .CycleTime = ""
                        Else
                            .CycleTime = table.Rows(i)("Cycle Time").ToString
                        End If
                        .UpdateHeaderManualCT(table.Rows(i)("Parent ID"))
                    End With
                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "invtid", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ImportBoMUpdateQtyDetails()

        Try
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomDetails
                        Dim qty As String = Replace(table.Rows(i)("Qty").ToString, ",", ".")
                        Dim sQty As Single = Single.Parse(qty)
                        Dim sQty1 As Single = Convert.ToSingle(qty)
                        If table.Rows(i)("Qty") Is DBNull.Value OrElse table.Rows(i)("Qty").ToString = "" Then
                            .Qty = 0
                        Else
                            .Qty = sQty 'Convert.ToSingle(Replace(table.Rows(i)("Qty").ToString, ",", "."))
                        End If
                        .UpdateQtyDetailsManual(table.Rows(i)("Parent ID"), table.Rows(i)("Invt ID Material"))
                    End With
                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "Invt ID Material", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ImportBoMDetails()
        Try
            'Dim ls_Judul As String = "BoM"IMModels

            'table.Columns.Add("bomid")
            'table.Columns.Add("parentid")
            'table.Columns.Add("invtid")
            'table.Columns.Add("descr")
            'table.Columns.Add("qty")
            'table.Columns.Add("unit")
            Cursor = Cursors.WaitCursor
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomDetails

                        If table.Rows(i)("BOM ID") Is DBNull.Value OrElse table.Rows(i)("BOM ID").ToString = "" Then
                            .BoMID = ""
                        Else
                            .BoMID = table.Rows(i)("BOM ID").ToString
                        End If
                        If table.Rows(i)("Parent ID") Is DBNull.Value OrElse table.Rows(i)("Parent ID").ToString = "" Then
                            .Parentid = ""
                        Else
                            .Parentid = table.Rows(i)("Parent ID").ToString
                        End If
                        If table.Rows(i)("Inventory ID") Is DBNull.Value OrElse table.Rows(i)("Inventory ID").ToString = "" Then
                            .inventId = ""
                        Else
                            .inventId = table.Rows(i)("Inventory ID").ToString
                        End If
                        If table.Rows(i)("Description") Is DBNull.Value OrElse table.Rows(i)("Description").ToString = "" Then
                            .Descr_detail = ""
                        Else
                            .Descr_detail = table.Rows(i)("Description").ToString
                        End If
                        If table.Rows(i)("Qty") Is DBNull.Value OrElse table.Rows(i)("Qty").ToString = "" Then
                            .Qty = 0
                        Else
                            .Qty = Replace(table.Rows(i)("Qty"), ",", ".")
                        End If
                        If table.Rows(i)("Unit") Is DBNull.Value OrElse table.Rows(i)("Unit").ToString = "" Then
                            .Unit = ""
                        Else
                            .Unit = table.Rows(i)("Unit").ToString
                        End If

                        '.DeleteDetailByParentAndInvt(.Parentid, .inventId)
                        .InsertDetail()

                    End With

                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "Invt ID Material", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Cursor = Cursors.Default
            LoadGrid()
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw
        End Try
    End Sub
    Private Sub ImportBoMHeader()
        Try
            Cursor = Cursors.WaitCursor
            'Dim ls_Judul As String = "BoM"

            'table.Columns.Add("bomid")
            'table.Columns.Add("invtid")
            'table.Columns.Add("descr")
            'table.Columns.Add("siteid")
            'table.Columns.Add("runner")
            'table.Columns.Add("ct")
            'table.Columns.Add("mc")
            'table.Columns.Add("cavity")
            'table.Columns.Add("wc")
            'table.Columns.Add("allowance")
            'table.Columns.Add("mp")
            'table.Columns.Add("status")
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomHeader

                        If table.Rows(i)("BOM ID") Is DBNull.Value OrElse table.Rows(i)("BOM ID").ToString = "" Then
                            .BoMID = ""
                        Else
                            .BoMID = table.Rows(i)("BOM ID").ToString
                        End If
                        .Tgl = DateTime.Today
                        If table.Rows(i)("InvID") Is DBNull.Value OrElse table.Rows(i)("InvID").ToString = "" Then
                            .InvtID = ""
                        Else
                            .InvtID = table.Rows(i)("InvID").ToString
                        End If
                        If table.Rows(i)("Description") Is DBNull.Value OrElse table.Rows(i)("Description").ToString = "" Then
                            .Desc = ""
                        Else
                            .Desc = table.Rows(i)("Description").ToString
                        End If
                        If table.Rows(i)("Site") Is DBNull.Value OrElse table.Rows(i)("Site").ToString = "" Then
                            .SiteID = ""
                        Else
                            .SiteID = table.Rows(i)("Site").ToString
                        End If
                        If table.Rows(i)("Runner") Is DBNull.Value OrElse table.Rows(i)("Runner").ToString = "" Then
                            .Runner = ""
                        Else
                            .Runner = table.Rows(i)("Runner").ToString
                        End If
                        If table.Rows(i)("CT") Is DBNull.Value OrElse table.Rows(i)("CT").ToString = "" Then
                            .CycleTime = "0"
                        Else
                            .CycleTime = table.Rows(i)("CT")
                        End If
                        If table.Rows(i)("MC") Is DBNull.Value OrElse table.Rows(i)("MC").ToString = "" Then
                            .MC = ""
                        Else
                            .MC = table.Rows(i)("MC").ToString
                        End If

                        If table.Rows(i)("Cavity") Is DBNull.Value OrElse table.Rows(i)("Cavity").ToString = "" Then
                            .cavity = ""
                        Else
                            .cavity = table.Rows(i)("Cavity").ToString
                        End If
                        If table.Rows(i)("WC") Is DBNull.Value OrElse table.Rows(i)("WC").ToString = "" Then
                            .WC = ""
                        Else
                            .WC = table.Rows(i)("WC").ToString
                        End If
                        If table.Rows(i)("Allow") Is DBNull.Value OrElse table.Rows(i)("Allow").ToString = "" Then
                            .Allowance = 0
                        Else
                            .Allowance = table.Rows(i)("Allow")
                        End If
                        If table.Rows(i)("MP") Is DBNull.Value OrElse table.Rows(i)("MP").ToString = "" Then
                            .MP = "0"
                        Else
                            .MP = table.Rows(i)("MP")
                        End If
                        If table.Rows(i)("Status") Is DBNull.Value OrElse table.Rows(i)("Status") = "" Then
                            .Status = ""
                        Else
                            .Status = table.Rows(i)("Status")
                        End If
                        If table.Rows(i)("Active") Is DBNull.Value OrElse table.Rows(i)("Active").ToString = "" Then
                            .Active = 1
                        Else
                            .Status = table.Rows(i)("Active")
                        End If
                        '.DeleteHeaderByInvtID(.InvtID)
                        '.DeleteHeader(.BoMID)
                        .InsertHeader(.Status)

                    End With

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "InvID", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Cursor = Cursors.Default
            LoadGrid()
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""

        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data BoM"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub

    Private Sub FilterGrid()
        Try
            'Grid.all = False
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmBoM_detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub
    'Public Overrides Function ValidateDelete() As Boolean
    '    Try
    '        If Grid.Row < Grid.Rows.Fixed Then Return False
    '        Dim ls_Code As String = Grid.Item(Grid.Row, 0)
    '        fc_ClassCustomer.GetData(ls_Code)
    '        fc_ClassCustomerBranch.GetData(ls_Code)
    '        fc_ClassCustomer.ValidateDelete()
    '        'fc_ClassCustomerBranch.ValidateDelete()
    '        fc_ClassCusomerTempalte.GetData(ls_Code)
    '        fc_ClassCusomerTempalte.ValidateDelete()

    '    Catch ex As Exception
    '        Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '        Return False
    '    End Try
    '    Return True
    'End Function
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

    Private Sub Grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim objGrid As DataGridView = sender
            If objGrid.Rows.Count > 0 Then
                Call CallFrm(objGrid.SelectedRows(0).Cells(0).Value.ToString,
                             objGrid.SelectedRows(0).Cells(1).Value.ToString,
                             objGrid.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim invtID, bomid As String

    Private Sub frmBoM_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                invtID = String.Empty
                bomid = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                        bomid = GridView1.GetRowCellValue(rowHandle, "BOM ID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(bomid,
                             invtID,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            invtID = String.Empty
            bomid = String.Empty
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                    bomid = GridView1.GetRowCellValue(rowHandle, "BOM ID")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                'Dim objGrid As DataGridView = sender
                Call CallFrm(bomid,
                         invtID,
                         GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub frmBoM_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadGrid()
    End Sub
End Class
