Imports System.Collections.ObjectModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class frmSales_ForecastPrice
    Dim ff_Detail As frmSales_ForecastPrice_details
    Dim dtGrid As DataTable
    Dim ObjForecast As New forecast_price_models
    Dim ObjHeader As New forecast_price_models_header

    Dim temp As RepositoryItemCheckedComboBoxEdit = Nothing
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'LoadGrid()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmSales_ForecastPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False

        'Dim dtGrid As New DataTable
        'dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
        'AturGrid(Grid, Me)
        'ProgressBar1.Location = New Point(500, 500)
        'CenterControl()
        'ProgressBar1.Visible = False
    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub
    Private Sub LoadGrid()
        Try

            SplashScreenManager.ShowForm(GetType(FrmWait))

            dtGrid = New DataTable
            dtGrid = ObjForecast.GetAllDataGrid(bs_Filter)
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = FixedStyle.Left
                .Columns(2).Fixed = FixedStyle.Left
                .Columns(3).Fixed = FixedStyle.Left
                .Columns(5).Fixed = FixedStyle.Left
                .Columns(6).Fixed = FixedStyle.Left
                .OptionsView.ShowFooter = True
                '.OptionsBehavior.Editable = False
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                    If col.Name.ToLower = "colinvtid" Then
                        col.OptionsColumn.AllowEdit = True
                    Else
                        col.OptionsColumn.AllowEdit = False
                    End If
                Next
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub SetEditColumnGrid()
        Try
            Dim cmbOE As RepositoryItemComboBox = New RepositoryItemComboBox()
            AddHandler cmbOE.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler GridView1.ValidateRow, AddressOf gridView1_ValidateRow

            cmbOE.Items.AddRange(New String() {"OE", "PE"})
            GridView1.Columns("Oe/Pe").ColumnEdit = cmbOE
            Grid.RepositoryItems.Add(cmbOE)
            'AddHandler GridView1.CustomColumnDisplayText, AddressOf GridView1_CustomColumnDisplayText
            'AddHandler GridView1.ShowingEditor, AddressOf GridView1_ShowingEditor
            'AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub ComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        'Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)

        'If GridView1.IsNewItemRow(rowHandle) Then
        '    GridView1.SetRowCellValue(rowHandle, GridView1.Columns("OE/PE"), val1)
        'End If
        GridView1.PostEditor()
    End Sub

    'Private Sub GridView1_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
    '    If ShouldCustomize((TryCast(sender, GridView)).GetRowHandle(e.ListSourceRowIndex), e.Column.FieldName) Then e.DisplayText = String.Empty
    'End Sub

    'Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
    '    If ShouldCustomize(e.RowHandle, e.Column.FieldName) Then e.Appearance.BackColor = System.Drawing.Color.LightGray
    'End Sub

    'Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Dim view As GridView = TryCast(sender, GridView)
    '    If ShouldCustomize(view.FocusedRowHandle, view.FocusedColumn.FieldName) Then e.Cancel = True
    'End Sub

    'Private Function ShouldCustomize(ByVal rowHandle As Integer, ByVal fieldName As String) As Boolean
    '    Dim value As String = GridView1.GetRowCellValue(rowHandle, "Oe/Pe").ToString()
    '    Return value = "ReadOnly" AndAlso fieldName = "Age"
    'End Function

    Public Overrides Sub Proc_InputNewData()
        'GridView1.AddNewRow()

        CallFrm()
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Forecast/Price"
        Dim Bulan As String = ""
        Dim BulanAngka As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcel1
        frmExcel = New FrmSystemExcel1(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        If frmExcel.tab = 0 Then
            strTahun = frmExcel.Tahun
            strCustomer = frmExcel.Customer
            Bulan = frmExcel.Bulan
            BulanAngka = frmExcel.BulanAngka

            Try
                Dim dv As DataView = New DataView(table)
                Dim dtFilter As New DataTable

                If strCustomer <> "" AndAlso strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "' AND [Cust ID] = '" & strCustomer & "'"
                    dtFilter = dv.ToTable
                ElseIf strCustomer = "" AndAlso strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "'"
                    dtFilter = dv.ToTable
                ElseIf strCustomer <> "" AndAlso strTahun = "" Then
                    dv.RowFilter = "[Cust ID] = '" & strCustomer & "'"
                    dtFilter = dv.ToTable
                Else
                    dtFilter = dv.ToTable
                End If

                If dtFilter.Rows.Count > 0 Then

                    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    ObjHeader.ObjForecastCollection.Clear()
                    For Each row As DataRow In dtFilter.Rows
                        Try
                            ObjForecast = New forecast_price_models
                            'Dim ObjCollection As New forecast_price_models
                            With ObjForecast
                                .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun"))
                                .CustID = If(row("Cust ID") Is DBNull.Value, "", row("Cust ID"))
                                .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer"))
                                .InvtID = If(row("Invt ID") Is DBNull.Value, "", row("Invt ID"))
                                .Description = If(row("Description") Is DBNull.Value, "", row("Description"))
                                .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No"))
                                .Model = If(row("Model") Is DBNull.Value, "", row("Model"))
                                .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe"))
                                .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB"))
                                .Site = If(row("Site") Is DBNull.Value, "", row("Site"))
                                .Flag = If(row("Flag") Is DBNull.Value, "N/A", row("Flag").ToString())
                                .JanQty1 = If(row("Jan Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty1")))
                                .FebQty1 = If(row("Feb Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty1")))
                                .MarQty1 = If(row("Mar Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty1")))
                                .AprQty1 = If(row("Apr Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty1")))
                                .MeiQty1 = If(row("Mei Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty1")))
                                .JunQty1 = If(row("Jun Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty1")))
                                .JulQty1 = If(row("Jul Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty1")))
                                .AgtQty1 = If(row("Agt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty1")))
                                .SepQty1 = If(row("Sep Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty1")))
                                .OktQty1 = If(row("Okt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty1")))
                                .NovQty1 = If(row("Nov Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty1")))
                                .DesQty1 = If(row("Des Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty1")))

                                .JanQty2 = If(row("Jan Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty2")))
                                .FebQty2 = If(row("Feb Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty2")))
                                .MarQty2 = If(row("Mar Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty2")))
                                .AprQty2 = If(row("Apr Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty2")))
                                .MeiQty2 = If(row("Mei Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty2")))
                                .JunQty2 = If(row("Jun Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty2")))
                                .JulQty2 = If(row("Jul Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty2")))
                                .AgtQty2 = If(row("Agt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty2")))
                                .SepQty2 = If(row("Sep Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty2")))
                                .OktQty2 = If(row("Okt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty2")))
                                .NovQty2 = If(row("Nov Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty2")))
                                .DesQty2 = If(row("Des Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty2")))

                                .JanQty3 = If(row("Jan Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty3")))
                                .FebQty3 = If(row("Feb Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty3")))
                                .MarQty3 = If(row("Mar Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty3")))
                                .AprQty3 = If(row("Apr Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty3")))
                                .MeiQty3 = If(row("Mei Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty3")))
                                .JunQty3 = If(row("Jun Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty3")))
                                .JulQty3 = If(row("Jul Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty3")))
                                .AgtQty3 = If(row("Agt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty3")))
                                .SepQty3 = If(row("Sep Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty3")))
                                .OktQty3 = If(row("Okt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty3")))
                                .NovQty3 = If(row("Nov Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty3")))
                                .DesQty3 = If(row("Des Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty3")))

                                .Jan_PO1 = If(row("Jan PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO1")))
                                .Feb_PO1 = If(row("Feb PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO1")))
                                .Mar_PO1 = If(row("Mar PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO1")))
                                .Apr_PO1 = If(row("Apr PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO1")))
                                .Mei_PO1 = If(row("Mei PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO1")))
                                .Jun_PO1 = If(row("Jun PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO1")))
                                .Jul_PO1 = If(row("Jul PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO1")))
                                .Agt_PO1 = If(row("Agt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO1")))
                                .Sep_PO1 = If(row("Sep PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO1")))
                                .Okt_PO1 = If(row("Okt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO1")))
                                .Nov_PO1 = If(row("Nov PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO1")))
                                .Des_PO1 = If(row("Des PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO1")))

                                .Jan_PO2 = If(row("Jan PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO2")))
                                .Feb_PO2 = If(row("Feb PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO2")))
                                .Mar_PO2 = If(row("Mar PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO2")))
                                .Apr_PO2 = If(row("Apr PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO2")))
                                .Mei_PO2 = If(row("Mei PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO2")))
                                .Jun_PO2 = If(row("Jun PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO2")))
                                .Jul_PO2 = If(row("Jul PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO2")))
                                .Agt_PO2 = If(row("Agt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO2")))
                                .Sep_PO2 = If(row("Sep PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO2")))
                                .Okt_PO2 = If(row("Okt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO2")))
                                .Nov_PO2 = If(row("Nov PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO2")))
                                .Des_PO2 = If(row("Des PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO2")))

                                .created_date = DateTime.Today
                                .created_by = gh_Common.Username
                            End With
                            ObjHeader.ObjForecastCollection.Add(ObjForecast)
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, 0, "Invt ID", gh_Common.Username)
                            Continue For
                        End Try
                    Next
                    With ObjHeader
                        .Tahun = strTahun
                        .CustID = strCustomer
                        .Bulan = Bulan
                        .BulanAngka = BulanAngka
                        .InsertData1()

                        SplashScreenManager.CloseForm()
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        LoadGrid()
                    End With
                    'ObjForecast.UpdateDataByBulanNew(Bulan)
                End If
            Catch ex As Exception
                Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            End Try

        End If

    End Sub
    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Forecast"
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
        ff_Detail = New frmSales_ForecastPrice_details(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle
            ObjForecast.Id = ID
            ObjForecast.Delete()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim InvtID As String
    Dim ID As Integer
    Private Sub frmSales_ForecastPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                InvtID = String.Empty
                ID = 0
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        InvtID = GridView1.GetRowCellValue(rowHandle, "InvtID")
                        ID = GridView1.GetRowCellValue(rowHandle, "Id")
                    End If
                Next rowHandle
                Dim n As Integer = 0
                If GridView1.GetSelectedRows.Length > 0 Then
                    For i As Integer = 0 To GridView1.FocusedRowHandle - 1
                        n += 1
                    Next
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID, InvtID, n)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            InvtID = String.Empty
            ID = 0
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    InvtID = GridView1.GetRowCellValue(rowHandle, "InvtID")
                    ID = GridView1.GetRowCellValue(rowHandle, "Id")
                End If
            Next rowHandle
            Dim n As Integer = 0
            If GridView1.GetSelectedRows.Length > 0 Then
                For i As Integer = 0 To GridView1.FocusedRowHandle - 1
                    n += 1
                Next
                'Dim objGrid As DataGridView = sender
                Call CallFrm(ID, InvtID, n)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ExportToExcelTSM_Click(sender As Object, e As EventArgs) Handles ExportToExcelTSM.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Grid Kosong !")
        End If
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    ContextMenuStrip1.Show(e.Location)
        'End If
    End Sub

    Private Sub CekHargaADMTSM_Click(sender As Object, e As EventArgs) Handles CekHargaADMTSM.Click
        Try
            ObjForecast = New forecast_price_models
            Dim dt As New DataTable
            dt = ObjForecast.GetHargaSAPKAP_ADM

            If Not isOpen("frmListHargaADM") Then
                Dim f = frmListHargaADM
                f = New frmListHargaADM(dt, "LIST HARGA INVENTORY SAMA TAPI HARGA BEDA", 0)
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Else
                XtraMessageBox.Show("Form sudah terbuka !")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub gridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsNewItemRow(e.RowHandle) Then
            Dim column As GridColumn = view.Columns("OE/PE")
            Dim val As Object = view.GetRowCellValue(e.RowHandle, column)
            If val Is Nothing OrElse val.ToString() = String.Empty Then
                e.Valid = False
                view.SetColumnError(column, "Value cannot be empty")
            End If
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle

        'Dim id As Object = GridView1.GetRowCellValue(e.RowHandle, "ID")
        'Dim rHandle As Integer = GridView1.LocateByValue("ID", id, Nothing)
        'If rHandle < 0 Then e.Appearance.BackColor = Color.Orange
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle >= 0 Then
            Dim _tahun As String = view.GetRowCellDisplayText(view.FocusedRowHandle, "Tahun")
            Dim _custId As String = view.GetRowCellDisplayText(view.FocusedRowHandle, "CustID")
            Dim _invtId As String = view.GetRowCellDisplayText(view.FocusedRowHandle, "InvtID")
            Dim _partNo As String = view.GetRowCellDisplayText(view.FocusedRowHandle, "PartNo")
            Dim _flag As String = view.GetRowCellDisplayText(view.FocusedRowHandle, "Flag")

            Dim _tahun1 As String = view.GetRowCellDisplayText(e.RowHandle, "Tahun")
            Dim _custId1 As String = view.GetRowCellDisplayText(e.RowHandle, "CustID")
            Dim _invtId1 As String = view.GetRowCellDisplayText(e.RowHandle, "InvtID")
            Dim _partNo1 As String = view.GetRowCellDisplayText(e.RowHandle, "PartNo")
            Dim _flag1 As String = view.GetRowCellDisplayText(e.RowHandle, "Flag")

            If _tahun = _tahun1 AndAlso _custId = _custId1 AndAlso _invtId = _invtId1 Then
                'If _flag = "SAP TSC1" Then
                '    e.Appearance.BackColor = Color.Salmon
                '    e.HighPriority = True
                'Else
                e.Appearance.BackColor = Color.Salmon
                e.HighPriority = True
                'End If
            End If
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim view As GridView = TryCast(sender, GridView)
        view.LayoutChanged()
    End Sub

    Private Sub CekInventory1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CekInventory1ToolStripMenuItem.Click
        Try
            ObjForecast = New forecast_price_models
            Dim dt As New DataTable
            dt = ObjForecast.GetDoubleInvtID

            If Not isOpen("frmListHargaADM") Then
                Dim f = frmListHargaADM
                f = New frmListHargaADM(dt, "LIST INVENTORY ID YANG LEBIH DARI 1", 1)
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Else
                XtraMessageBox.Show("Form sudah terbuka !")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub frmSales_ForecastPrice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadGrid()
    End Sub
    Dim dtTemp As DataTable
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Tahun", GetType(String))
        dtTemp.Columns.Add("CustID", GetType(String))
        dtTemp.Columns.Add("InvtID", GetType(String))
        dtTemp.Columns.Add("PartNo", GetType(String))
        dtTemp.Clear()
    End Sub
    Private Sub SinkronasiDataTsm_Click(sender As Object, e As EventArgs) Handles SinkronasiDataTsm.Click
        Try
            TempTable()

            For i As Integer = 0 To GridView1.RowCount - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = Trim(GridView1.GetRowCellValue(i, "Tahun") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(GridView1.GetRowCellValue(i, "CustID") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(GridView1.GetRowCellValue(i, "InvtID") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(GridView1.GetRowCellValue(i, "PartNo") & "")
            Next
            If dtTemp.Rows.Count > 0 Then
                Dim frm As FrmSales_ForecastPriceSync
                frm = New FrmSales_ForecastPriceSync(dtTemp)
                frm.Text = "Sync. Data"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowDialog()
            Else
                XtraMessageBox.Show("Silahkan Filter data yang akan di sinkronisasi !")
            End If
            LoadGrid()
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    'Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
    '    Dim view As GridView = TryCast(sender, GridView)
    '    If e.Column = view.Columns("YourFieldName") AndAlso e.RowHandle > 0 AndAlso e.RowHandle < view.RowCount Then
    '        If CInt(Math.Truncate(e.CellValue)) > CInt(Math.Truncate(view.GetRowCellValue(e.RowHandle - 1, e.Column))) Then
    '            e.Appearance.BackColor = Color.Red
    '        End If
    '    End If
    'End Sub
End Class
