Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmTravel_Detail2
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim ObjTravelHeader As New TravelHeaderModel
    Dim ObjTravelDetail As New TravelDetailModel
    Dim ObjTravelerDetail As New TravelerDetailModel
    Dim ObjTravelSettHeader As New TravelSettlementHeaderModel

    Dim GridDtl As GridControl
    Dim f As FrmTravel_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable
    Dim DtScan2 As DataTable
    Dim DtScan3 As DataTable
    Dim DtScan4 As DataTable

    Dim dtTraveler As New DataTable

    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _TravelID As String = ""
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal strTabPage As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        'Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            fs_Code3 = strTabPage
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(6) {New DataColumn("Account", GetType(String)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double)),
                                                            New DataColumn("CuryID", GetType(String)),
                                                            New DataColumn("TSC Rare", GetType(String)),
                                                            New DataColumn("IDR Amount", GetType(Double))})
        Grid.DataSource = DtScan
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub

    Private Sub FrmTravel_Detail2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, True)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjTravelHeader.TravelHeaderID = fs_Code
                ObjTravelHeader.GetTravelById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Travel " & ObjTravelHeader.TravelID
            Else
                Me.Text = "Travel"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            If fs_Code3 = "XtraTabPage3" Then
                ViewApprove()
                Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, True)
            ElseIf fs_Code3 = "XtraTabPage2" Or fs_Code3 = "XtraTabPage4" Then
                ViewApprove()
                Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False)
            End If
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmTravel"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try

            If fs_Code <> "" Then
                Dim dtGrid As New DataTable
                ObjTravelDetail.TravelID = TxtNoTravel.Text
                dtGrid = ObjTravelDetail.GetDataDetailByID2()
                Grid.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridView1)
                End If
            Else
                Dim dtGrid As New DataTable
                ObjTravelDetail.TravelID = ""
                dtGrid = ObjTravelDetail.GetDataDetailByID()
                Grid.DataSource = dtGrid
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            Dim dtGrid As New DataTable
            If fs_Code <> "" Then
                With ObjTravelHeader
                    TxtNoTravel.Text = .TravelID
                    'TxtNama.Text = .Nama
                    'TxtCurrency.SelectedText = .Currency
                    'TxtDep.Text = .DeptID
                    TxtDestination.Text = .Destination
                    txtPurpose.Text = .Purpose
                    TxtTerm.Text = .Term
                    'txtPickUp.Text = .PickUp
                    txtVisa.Text = .Visa
                    TxtTgl.EditValue = .Tgl
                    TxtTotalAdvanceIDR.Text = Format(.TotalAdvanceIDR, gs_FormatBulat)
                    TxtTotalAdvanceYEN.Text = Format(.TotalAdvanceYEN, gs_FormatBulat)
                    TxtTotalAdvanceUSD.Text = Format(.TotalAdvanceUSD, gs_FormatBulat)
                    TxtTotIDR.Text = Format(.TotalAdvIDR, gs_FormatBulat)
                    TxtArrDate.EditValue = .Arrdate
                    TxtDepDate.EditValue = .Depdate
                End With
                dtGrid = ObjTravelerDetail.GetTravelerDetail(TxtNoTravel.Text)
                AddItemsTraveler(dtGrid)
            Else
                TxtNama.Text = ""
                TxtNoTravel.Text = ""
                TxtDep.Text = ""
                TxtDestination.Text = ""
                txtVisa.Text = "YES"
                txtPurpose.Text = ""
                'txtPickUp.Text = ""
                TxtTerm.Text = ""
                TxtTgl.EditValue = DateTime.Today
                TxtTotalAdvanceIDR.Text = "0"
                TxtTotalAdvanceYEN.Text = "0"
                TxtTotalAdvanceUSD.Text = "0"
                TxtTotIDR.Text = "0"
                TxtArrDate.EditValue = DateTime.Today
                TxtDepDate.EditValue = DateTime.Today
                AddItemsTraveler(dtGrid)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub

    Private Sub ViewApprove()
        btnAdd.Enabled = False
        TxtTgl.Enabled = False
        TxtNama.Enabled = False
        TxtDestination.Enabled = False
        txtPurpose.Enabled = False
        TxtTerm.Enabled = False
        TxtArrDate.Enabled = False
        txtVisa.Enabled = False
        TxtDepDate.Enabled = False

        GridView1.OptionsBehavior.Editable = False
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If TxtNama.Text = "" OrElse TxtDestination.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If

            Dim dt As DataTable
            dt = ObjTravelSettHeader.GetTravelSettHeaderByTravelID(TxtNoTravel.Text)
            Dim ada As Integer
            ada = dt.Rows.Count()

            If lb_Validated Then
                If ada > 0 Then
                    Err.Raise(ErrNumber, , "Travel ID " & TxtNoTravel.Text & " dalam proses settlement !")
                Else
                    With ObjTravelHeader
                        .TravelID = .TravelAutoNo
                        _TravelID = .TravelAutoNo
                        .Nama = TxtNama.Text
                        .DeptID = TxtDep.Text
                        .Destination = TxtDestination.Text
                        .Purpose = txtPurpose.Text
                        .Term = TxtTerm.Text
                        '.PickUp = txtPickUp.Text // Di take out
                        .Visa = txtVisa.Text
                        .Tgl = TxtTgl.EditValue
                        .TotalAdvanceIDR = TxtTotalAdvanceIDR.Text
                        .TotalAdvanceYEN = TxtTotalAdvanceYEN.Text
                        .TotalAdvanceUSD = TxtTotalAdvanceUSD.Text
                        .TotalAdvIDR = TxtTotIDR.Text
                        .Arrdate = TxtArrDate.EditValue
                        .Depdate = TxtDepDate.EditValue
                    End With
                End If
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") > 7 Then
                dtSearch = ObjTravelHeader.GetAccount

                ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account"))
                ls_Judul = "Account"

                Dim lF_SearchData As FrmSystem_LookupGrid
                lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
                lF_SearchData.Text = "Select Data " & ls_Judul
                lF_SearchData.StartPosition = FormStartPosition.CenterScreen
                lF_SearchData.ShowDialog()
                Dim Value1 As String = ""
                Dim Value2 As String = ""

                If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim

                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Description", "OTHERS")
                End If
                lF_SearchData.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

    End Sub

    Public Sub CallForm(Optional ByVal ID As String = "", Optional ByVal Nama As String = "", Optional ByVal IsNew As Boolean = True)

        'f = New FrmTravel_Detail2(ID, Nama, IsNew, dt, Grid)
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.MaximizeBox = False
        'f.ShowDialog()

    End Sub

    Public Overrides Sub Proc_Approve()
        ''CallForm()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.MoveFirst()
                If GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString = "" OrElse
                    GridView1.GetRowCellValue(i, GridView1.Columns("Amount")).ToString = "" Then
                    IsEmpty = True
                    GridView1.DeleteRow(i)
                End If
            Next

            If isUpdate = False Then
                ObjTravelHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjTravelDetail = New TravelDetailModel
                        With ObjTravelDetail
                            .TravelID = _TravelID
                            .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
                            .ID = Convert.ToInt64(GridView1.GetRowCellValue(i, "ID"))
                            .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                            .CuryID = GridView1.GetRowCellValue(i, "CuryID")
                            .Rate = GridView1.GetRowCellValue(i, "Rate")
                            .AmountIDR = Convert.ToDouble(GridView1.GetRowCellValue(i, "AmountIDR"))
                        End With
                        ObjTravelHeader.ObjDetails.Add(ObjTravelDetail)
                    End If
                Next

                ObjTravelHeader.ObjTravelerDetails.Clear()

                For Each item As CheckedListBoxItem In TxtNama.Properties.GetItems()
                    If item.CheckState = CheckState.Checked Then
                        ObjTravelerDetail = New TravelerDetailModel
                        Dim FilteredRows As DataRow()
                        Dim deptid As String
                        FilteredRows = dtTraveler.Select("NIK = " + item.Value)
                        deptid = (FilteredRows.FirstOrDefault().Item("DeptID"))

                        With ObjTravelerDetail
                            .TravelID = ObjTravelHeader.TravelID
                            .NIK = item.Value
                            .Nama = item.Description
                            .DeptID = deptid
                            .Status = 0
                        End With
                        ObjTravelHeader.ObjTravelerDetails.Add(ObjTravelerDetail)
                    End If
                Next

                ObjTravelHeader.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            Else
                ObjTravelHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjTravelDetail = New TravelDetailModel
                        With ObjTravelDetail
                            .TravelID = TxtNoTravel.Text
                            .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
                            .ID = Convert.ToInt16(IIf(GridView1.GetRowCellValue(i, "ID") Is DBNull.Value, 0, GridView1.GetRowCellValue(i, "ID")))
                            .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = IIf(GridView1.GetRowCellValue(i, "SubAccount") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "SubAccount"))
                            .CuryID = GridView1.GetRowCellValue(i, "CuryID")
                            .Rate = GridView1.GetRowCellValue(i, "Rate")
                            .AmountIDR = Convert.ToDouble(GridView1.GetRowCellValue(i, "AmountIDR"))
                        End With
                        ObjTravelHeader.ObjDetails.Add(ObjTravelDetail)
                    End If
                Next

                ObjTravelHeader.ObjTravelerDetails.Clear()

                For Each item As CheckedListBoxItem In TxtNama.Properties.GetItems()
                    If item.CheckState = CheckState.Checked Then
                        ObjTravelerDetail = New TravelerDetailModel
                        Dim FilteredRows As DataRow()
                        Dim deptid As String
                        FilteredRows = dtTraveler.Select("NIK = " + item.Value)
                        deptid = (FilteredRows.FirstOrDefault().Item("DeptID"))

                        With ObjTravelerDetail
                            .TravelID = TxtNoTravel.Text
                            .NIK = item.Value
                            .Nama = item.Description
                            .DeptID = deptid
                        End With
                        ObjTravelHeader.ObjTravelerDetails.Add(ObjTravelerDetail)
                    End If
                Next

                ObjTravelHeader.TravelID = TxtNoTravel.Text
                ObjTravelHeader.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjTravelHeader.GetDataGrid()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_print()
        FrmReportTravel.StartPosition = FormStartPosition.CenterScreen
        FrmReportTravel.txtTravelID.Text = TxtNoTravel.Text
        FrmReportTravel.Show()
    End Sub

    Private Function GetTotIdr() As Decimal
        Dim _totalidr1 As Decimal = 0

        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Amount")) Then
                    If GridView1.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr1 = _totalidr1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If
                End If
            Next

            Return _totalidr1

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetTotUSD() As Decimal
        Dim _totalusd1 As Decimal = 0
        Dim _totalusd2 As Decimal = 0
        Dim _totalusd3 As Decimal = 0
        Dim _totalusd4 As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Amount")) Then
                    If GridView1.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd1 = _totalusd1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If
                End If
            Next

            Return _totalusd1

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetTotYEN() As Decimal
        Dim _totalYEN1 As Decimal = 0
        Dim _totalYEN2 As Decimal = 0
        Dim _totalYEN3 As Decimal = 0
        Dim _totalYEN4 As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Amount")) Then
                    If GridView1.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalYEN1 = _totalYEN1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If
                End If
            Next

            Return _totalYEN1

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        'Dim ignoreCancel As Boolean = False
        'TxtPrNo.DoValidate()
        'TxtDep.DoValidate()

        'If DxValidationProvider1.GetInvalidControls().Contains(TxtPrNo) _
        '    OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtDep) Then
        '    ignoreCancel = True
        'Else
        '    ignoreCancel = True
        'End If

        'MyBase.OnFormClosing(e)''
        'e.Cancel = Not ignoreCancel
        ''Me.Close()
    End Sub

    Private Sub FrmTravel_Detail2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView1.AddNewRow()
            GridView1.OptionsNavigation.AutoFocusNewRow = True
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)

        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim _totalidr1 As Decimal = 0
        Dim _totalusd1 As Decimal = 0
        Dim _totalyen1 As Decimal = 0
        Dim _totalidr2 As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Amount")) Then
                    If GridView1.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr1 = _totalidr1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If
                    If GridView1.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd1 = _totalusd1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If
                    If GridView1.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalyen1 = _totalyen1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If
                    _totalidr2 = _totalidr2 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "AmountIDR"))
                End If
            Next

            TxtTotalAdvanceIDR.Text = Format(_totalidr1, gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(_totalusd1, gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(_totalyen1, gs_FormatBulat)
            TxtTotIDR.Text = Format(_totalidr2, gs_FormatBulat)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub jmltot_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount")) Then
            jumlah = 0
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", jumlah)
        Else
            jumlah = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount")
        End If

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate")) Then
            vrate = 1
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", vrate)
        Else
            vrate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate")
        End If
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub Grate_EditValueChanged(sender As Object, e As EventArgs) Handles Grate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount")) Then
            jumlah = 0
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", jumlah)
        Else
            jumlah = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount")
        End If

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate")) Then
            vrate = 1
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", vrate)
        Else
            vrate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate")
        End If
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub Gcury_EditValueChanged(sender As Object, e As EventArgs) Handles Gcury.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CuryID") = "YEN", "JPY", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CuryID"))
        vrate = ObjTravelHeader.GetRate(curyID, TxtTgl.EditValue)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", vrate)

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount")) Then
            jumlah = 0
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", jumlah)
        Else
            jumlah = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount")
        End If
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub TxtDepDate_EditValueChanged(sender As Object, e As EventArgs) Handles TxtDepDate.EditValueChanged
        Dim startDate As Date = TxtDepDate.EditValue
        Dim EndDate As Date = TxtArrDate.EditValue
        txtTotalDay.Text = DateDiff(DateInterval.Day, startDate, EndDate) + 1
    End Sub

    Private Sub TxtArrDate_EditValueChanged(sender As Object, e As EventArgs) Handles TxtArrDate.EditValueChanged
        Dim startDate As Date = TxtDepDate.EditValue
        Dim EndDate As Date = TxtArrDate.EditValue
        txtTotalDay.Text = DateDiff(DateInterval.Day, startDate, EndDate) + 1
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "SubAccount", "")
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "CuryID", "IDR")
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", 1)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "AmountIDR", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ID", 8)
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Dim index As Integer
        index = GridView1.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index > 6 Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub

    Private Sub AddItemsTraveler(param As DataTable)
        Dim value As String
        Dim desc As String
        Dim isChecked As CheckState
        TxtNama.Properties.Items.Clear()
        dtTraveler = ObjTravelHeader.GetTraveler
        If dtTraveler.Rows.Count > 0 And param.Rows.Count > 0 Then
            For i As Integer = 0 To dtTraveler.Rows.Count - 1
                value = If(IsDBNull(dtTraveler.Rows(i).Item("NIK")), "", Trim(dtTraveler.Rows(i).Item("NIK").ToString()))
                desc = If(IsDBNull(dtTraveler.Rows(i).Item("Nama")), "", Trim(dtTraveler.Rows(i).Item("Nama").ToString()))
                Dim ada As Integer = param.Select("NIK = " + value).Count()
                isChecked = 0
                If ada = 1 Then
                    isChecked = 1
                End If
                TxtNama.Properties.Items.Add(value, desc, isChecked, True)
            Next
        Else
            For i As Integer = 0 To dtTraveler.Rows.Count - 1
                value = If(IsDBNull(dtTraveler.Rows(i).Item("NIK")), "", Trim(dtTraveler.Rows(i).Item("NIK").ToString()))
                desc = If(IsDBNull(dtTraveler.Rows(i).Item("Nama")), "", Trim(dtTraveler.Rows(i).Item("Nama").ToString()))
                TxtNama.Properties.Items.Add(value, desc, isChecked, True)
            Next
        End If
    End Sub

    Private Sub TxtNama_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNama.EditValueChanged
        Dim dept As String = String.Empty
        Dim list As New List(Of String)()

        For Each item As CheckedListBoxItem In TxtNama.Properties.GetItems()
            If item.CheckState = CheckState.Checked Then
                Dim FilteredRows As DataRow()
                FilteredRows = dtTraveler.Select("NIK = " + item.Value)
                list.Add(FilteredRows.FirstOrDefault().Item("DeptID"))
                dept = String.Join(",", list)
            End If
        Next
        TxtDep.Text = dept
    End Sub

End Class
