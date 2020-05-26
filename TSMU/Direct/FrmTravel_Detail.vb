Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmTravel_Detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    ''   Dim fc_Class As New ClsTravel
    Dim ObjTravelHeader As New TravelHeaderModel
    Dim ObjTravelDetail As New TravelDetailModel
    Dim GridDtl As GridControl
    Dim f As FrmTravel_Detail
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable
    Dim DtScan2 As DataTable
    Dim DtScan3 As DataTable
    Dim DtScan4 As DataTable


    ''   Dim ObjTravel As New ClsTravel
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
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
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
    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(5) {New DataColumn("Date", GetType(String)),
                                                            New DataColumn("FromTF", GetType(String)),
                                                            New DataColumn("ToTF", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Currency", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})
        Grid.DataSource = DtScan
        GridView1.OptionsView.ShowAutoFilterRow = False

        DtScan2 = New DataTable
        DtScan2.Columns.AddRange(New DataColumn(3) {New DataColumn("Date", GetType(String)),
                                                    New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Currency", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})


        Grid2.DataSource = DtScan2
        GridView2.OptionsView.ShowAutoFilterRow = False

        DtScan3 = New DataTable
        DtScan3.Columns.AddRange(New DataColumn(3) {New DataColumn("Date", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Currency", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})
        Grid3.DataSource = DtScan3
        GridView3.OptionsView.ShowAutoFilterRow = False

        DtScan4 = New DataTable
        DtScan4.Columns.AddRange(New DataColumn(3) {New DataColumn("Date", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Currency", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})
        Grid4.DataSource = DtScan4
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub FrmTravel_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        ''Call CreateTable()
        Call InitialSetForm()

        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)

        GridView2.AddNewRow()
        GridView2.OptionsNavigation.AutoFocusNewRow = True
        GridView2.FocusedColumn = GridView2.VisibleColumns(0)

        GridView3.AddNewRow()
        GridView3.OptionsNavigation.AutoFocusNewRow = True
        GridView3.FocusedColumn = GridView3.VisibleColumns(0)

        GridView4.AddNewRow()
        GridView4.OptionsNavigation.AutoFocusNewRow = True
        GridView4.FocusedColumn = GridView4.VisibleColumns(0)
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
                Me.Text = "Travel " & fs_Code
            Else
                Me.Text = "Travel"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            LoadGridDetailStaying()
            LoadGridDetailSafety()
            LoadGridDetailPocket()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmTravel"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            Dim dtGrid As New DataTable
            ObjTravelDetail.TravelID = TxtNoTravel.Text
            dtGrid = ObjTravelDetail.GetDataDetailByID()
            Grid.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetailStaying()
        Try
            Dim dtGrid As New DataTable
            ObjTravelDetail.TravelID = TxtNoTravel.Text
            dtGrid = ObjTravelDetail.GetDataDetailStayingByID()
            Grid2.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView2)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetailSafety()
        Try
            Dim dtGrid As New DataTable
            ObjTravelDetail.TravelID = TxtNoTravel.Text
            dtGrid = ObjTravelDetail.GetDataDetailSafetyByID()
            Grid3.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView3)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetailPocket()
        Try
            Dim dtGrid As New DataTable
            ObjTravelDetail.TravelID = TxtNoTravel.Text
            dtGrid = ObjTravelDetail.GetDataDetailPocketByID()
            Grid4.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView4)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjTravelHeader
                    TxtNoTravel.Text = .TravelID
                    TxtNama.Text = .Nama
                    'TxtCurrency.SelectedText = .Currency
                    TxtDep.Text = .DeptID
                    TxtDestination.Text = .Destination
                    txtPurpose.Text = .Purpose
                    TxtTerm.Text = .Term
                    txtPickUp.Text = .PickUp
                    txtVisa.Text = .Visa
                    TxtTgl.EditValue = .Tgl
                    TxtTotalAdvanceIDR.Text = .TotalAdvanceIDR
                    TxtTotalAdvanceYEN.Text = .TotalAdvanceYEN
                    TxtTotalAdvanceUSD.Text = .TotalAdvanceUSD
                End With
                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True
            Else
                TxtNama.Text = ""
                TxtNoTravel.Text = ""
                TxtDep.Text = ""
                TxtDestination.Text = ""
                txtVisa.Text = "Yes"
                txtPurpose.Text = ""
                txtPickUp.Text = ""
                TxtTgl.EditValue = DateTime.Today
                TxtTotalAdvanceIDR.Text = "0"
                TxtTotalAdvanceYEN.Text = "0"
                TxtTotalAdvanceUSD.Text = "0"
                'TxtPrNo.Focus()
                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True

                GridView2.AddNewRow()
                GridView2.OptionsNavigation.AutoFocusNewRow = True

                GridView3.AddNewRow()
                GridView3.OptionsNavigation.AutoFocusNewRow = True

                GridView4.AddNewRow()
                GridView4.OptionsNavigation.AutoFocusNewRow = True
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
        LoadGridDetailStaying()
        LoadGridDetailSafety()
        LoadGridDetailPocket()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        'Dim lb_Validated As Boolean = False
        'Try

        '    If DxValidationProvider1.Validate Then
        '        lb_Validated = True
        '    Else
        '        Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
        '    End If

        '    If lb_Validated Then
        '        With ObjTravelHeader
        '            ''.Currency = TxtCurrency.Text
        '            .DeptID = TxtDep.Text
        '            ''.PRNo = TxtPrNo.Text
        '            .Remark = TxtDestination.Text
        '            .Status = TxtStatus.Text
        '            '.TravelID = .TravelAutoNo
        '            _TravelID = .TravelAutoNo
        '            ''.Tgl = TxtTgl.EditValue
        '            .Tipe = "T"
        '            ''.Total = TxtTotal.Text
        '            'If isUpdate = False Then
        '            '    .ValidateInsert()
        '            'Else
        '            '    .ValidateUpdate()
        '            'End If
        '        End With
        '    End If
        'Catch ex As Exception
        '    lb_Validated = False
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
        'Return lb_Validated
    End Function
    Public Sub CallForm(Optional ByVal ID As String = "", Optional ByVal Nama As String = "", Optional ByVal IsNew As Boolean = True)

        'f = New FrmTravel_Detail(ID, Nama, IsNew, dt, Grid)
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.MaximizeBox = False
        'f.ShowDialog()

    End Sub
    Public Overrides Sub Proc_Approve()
        ''CallForm()
    End Sub
    Public Overrides Sub Proc_SaveData()
        'Try
        '    Dim IsEmpty As Boolean = False
        '    For i As Integer = 0 To GridView1.RowCount - 1
        '        GridView1.MoveFirst()
        '        If GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString = "" OrElse
        '           GridView1.GetRowCellValue(i, GridView1.Columns("SubAccount")).ToString = "" OrElse
        '           GridView1.GetRowCellValue(i, GridView1.Columns("Amount")).ToString = "" Then
        '            IsEmpty = True
        '            GridView1.DeleteRow(i)
        '        End If
        '    Next
        '    'If IsEmpty Then
        '    '    Throw New Exception("Silahkan Hapus dulu baris yang kosong !")
        '    'End If

        '    If isUpdate = False Then
        '        ObjTravelHeader.ObjDetails.Clear()
        '        For i As Integer = 0 To GridView1.RowCount - 1
        '            If GridView1.GetRowCellValue(i, "Account") <> "" Then
        '                ObjTravelDetail = New TravelDetailModel
        '                With ObjTravelDetail
        '                    .TravelID = _TravelID
        '                    .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
        '                    .Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
        '                    .Description = GridView1.GetRowCellValue(i, "Description").ToString()
        '                    .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
        '                End With
        '                ObjTravelHeader.ObjDetails.Add(ObjTravelDetail)
        '            End If
        '        Next
        '        ObjTravelHeader.InsertData()
        '        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '    Else
        '        ObjTravelHeader.ObjDetails.Clear()
        '        For i As Integer = 0 To GridView1.RowCount - 1
        '            If GridView1.GetRowCellValue(i, "Account") <> "" Then
        '                ObjTravelDetail = New TravelDetailModel
        '                With ObjTravelDetail
        '                    .TravelID = TxtNama.Text
        '                    .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd
        '                    .Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
        '                    .Description = GridView1.GetRowCellValue(i, "Description").ToString()
        '                    .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
        '                End With
        '                ObjTravelHeader.ObjDetails.Add(ObjTravelDetail)
        '            End If
        '        Next
        '        ''ObjTravelHeader.UpdateData()
        '        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '    End If
        '    GridDtl.DataSource = ObjTravelHeader.GetDataGrid()
        '    IsClosed = True
        '    Me.Hide()
        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
    End Sub


    Private Function GetTotIdr() As Decimal
        Dim _totalidr1 As Decimal = 0
        Dim _totalidr2 As Decimal = 0
        Dim _totalidr3 As Decimal = 0
        Dim _totalidr4 As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Amount")) Then
                    If GridView1.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr1 = _totalidr1 + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr2 = _totalidr2 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView3.RowCount - 1
                If Not IsDBNull(GridView3.GetRowCellValue(i, "Amount")) Then
                    If GridView3.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr3 = _totalidr3 + Convert.ToDecimal(GridView3.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView4.RowCount - 1
                If Not IsDBNull(GridView4.GetRowCellValue(i, "Amount")) Then
                    If GridView4.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr4 = _totalidr4 + Convert.ToDecimal(GridView4.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            Return _totalidr1 + _totalidr2 + _totalidr3 + _totalidr4

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

            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd2 = _totalusd2 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView3.RowCount - 1
                If Not IsDBNull(GridView3.GetRowCellValue(i, "Amount")) Then
                    If GridView3.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd3 = _totalusd3 + Convert.ToDecimal(GridView3.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView4.RowCount - 1
                If Not IsDBNull(GridView4.GetRowCellValue(i, "Amount")) Then
                    If GridView4.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd4 = _totalusd4 + Convert.ToDecimal(GridView4.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            Return _totalusd1 + _totalusd2 + _totalusd3 + _totalusd4

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

            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalYEN2 = _totalYEN2 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView3.RowCount - 1
                If Not IsDBNull(GridView3.GetRowCellValue(i, "Amount")) Then
                    If GridView3.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalYEN3 = _totalYEN3 + Convert.ToDecimal(GridView3.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            For i As Integer = 0 To GridView4.RowCount - 1
                If Not IsDBNull(GridView4.GetRowCellValue(i, "Amount")) Then
                    If GridView4.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalYEN4 = _totalYEN4 + Convert.ToDecimal(GridView4.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next

            Return _totalYEN1 + _totalYEN2 + _totalYEN3 + _totalYEN4

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Sub GAmount_EditValueChanged(sender As Object, e As EventArgs)
        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        'gridView.UpdateCurrentRow()
    End Sub

    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs)
        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        'gridView.UpdateCurrentRow()
    End Sub

    Private Sub GridView1_Click(sender As Object, e As EventArgs)
        'GridView1.AddNewRow()
        'GridView1.OptionsNavigation.AutoFocusNewRow = True
        'GridView1.FocusedColumn = GridView1.VisibleColumns(0)
    End Sub


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
    'Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
    '    Dim Total As Double = 0
    '    For i As Integer = 0 To GridView1.RowCount - 1
    '        If Not GridView1.GetRowCellValue(i, "Amount") Is DBNull.Value Then
    '            Total = Total + GridView1.GetRowCellValue(i, "Amount")
    '        End If
    '    Next
    '    ''TxtTotal.Text = Format(Total, gs_FormatBulat)
    'End Sub

    Private Sub FrmTravel_Detail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView1.AddNewRow()
            GridView1.OptionsNavigation.AutoFocusNewRow = True
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            GridView2.AddNewRow()
            GridView2.OptionsNavigation.AutoFocusNewRow = True
            GridView2.FocusedColumn = GridView2.VisibleColumns(0)
            GridView3.AddNewRow()
            GridView3.OptionsNavigation.AutoFocusNewRow = True
            GridView3.FocusedColumn = GridView3.VisibleColumns(0)
            GridView4.AddNewRow()
            GridView4.OptionsNavigation.AutoFocusNewRow = True
            GridView4.FocusedColumn = GridView3.VisibleColumns(0)
        End If
    End Sub

    Private Sub TxtDep_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDep.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelHeader.GetDept
            ls_OldKode = TxtDep.Text
            ls_Judul = "Departemen"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                TxtDep.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _totIDR As Decimal = 0
                Dim _totUSD As Decimal = 0
                Dim _totYEN As Decimal = 0
                _totIDR = GetTotIdr()
                _totUSD = GetTotUSD()
                _totYEN = GetTotYEN()
                TxtTotalAdvanceIDR.Text = Format(_totIDR, gs_FormatBulat)
                TxtTotalAdvanceUSD.Text = Format(_totUSD, gs_FormatBulat)
                TxtTotalAdvanceYEN.Text = Format(_totYEN, gs_FormatBulat)
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter Then

                ObjTravelDetail = New TravelDetailModel
                If GridView1.FocusedColumn.FieldName = "Amount" Then
                    GridView1.ShowEditor()
                    GridView1.UpdateCurrentRow()
                    Dim _totidr As Decimal = GetTotIdr()
                    Dim _totusd As Decimal = GetTotUSD()
                Dim _totyen As Decimal = GetTotYEN()
                TxtTotalAdvanceIDR.Text = Format(_totidr, gs_FormatBulat)
                TxtTotalAdvanceUSD.Text = Format(_totusd, gs_FormatBulat)
                TxtTotalAdvanceYEN.Text = Format(_totyen, gs_FormatBulat)

                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True
                GridView1.FocusedColumn = GridView1.VisibleColumns(0)
            End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub jmltot_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    Private Sub jmltot2_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub jmltot3_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot3.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    Private Sub jmltot4_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot4.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    Private Sub Grid2_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid2.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _totIDR As Decimal = 0
                Dim _totUSD As Decimal = 0
                Dim _totYEN As Decimal = 0
                _totIDR = GetTotIdr()
                _totUSD = GetTotUSD()
                _totYEN = GetTotYEN()
                TxtTotalAdvanceIDR.Text = Format(_totIDR, gs_FormatBulat)
                TxtTotalAdvanceUSD.Text = Format(_totUSD, gs_FormatBulat)
                TxtTotalAdvanceYEN.Text = Format(_totYEN, gs_FormatBulat)
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter Then

                ObjTravelDetail = New TravelDetailModel
                If GridView2.FocusedColumn.FieldName = "Amount" Then
                    GridView2.ShowEditor()
                    GridView2.UpdateCurrentRow()
                    Dim _totidr As Decimal = GetTotIdr()
                    Dim _totusd As Decimal = GetTotUSD()
                    Dim _totyen As Decimal = GetTotYEN()
                    TxtTotalAdvanceIDR.Text = Format(_totidr, gs_FormatBulat)
                    TxtTotalAdvanceUSD.Text = Format(_totusd, gs_FormatBulat)
                    TxtTotalAdvanceYEN.Text = Format(_totyen, gs_FormatBulat)

                    GridView2.AddNewRow()
                    GridView2.OptionsNavigation.AutoFocusNewRow = True
                    GridView2.FocusedColumn = GridView2.VisibleColumns(0)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Grid3_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid3.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _totIDR As Decimal = 0
                Dim _totUSD As Decimal = 0
                Dim _totYEN As Decimal = 0
                _totIDR = GetTotIdr()
                _totUSD = GetTotUSD()
                _totYEN = GetTotYEN()
                TxtTotalAdvanceIDR.Text = Format(_totIDR, gs_FormatBulat)
                TxtTotalAdvanceUSD.Text = Format(_totUSD, gs_FormatBulat)
                TxtTotalAdvanceYEN.Text = Format(_totYEN, gs_FormatBulat)
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter Then

                ObjTravelDetail = New TravelDetailModel
                If GridView3.FocusedColumn.FieldName = "Amount" Then
                    GridView3.ShowEditor()
                    GridView3.UpdateCurrentRow()
                    Dim _totidr As Decimal = GetTotIdr()
                    Dim _totusd As Decimal = GetTotUSD()
                    Dim _totyen As Decimal = GetTotYEN()
                    TxtTotalAdvanceIDR.Text = Format(_totidr, gs_FormatBulat)
                    TxtTotalAdvanceUSD.Text = Format(_totusd, gs_FormatBulat)
                    TxtTotalAdvanceYEN.Text = Format(_totyen, gs_FormatBulat)

                    GridView3.AddNewRow()
                    GridView3.OptionsNavigation.AutoFocusNewRow = True
                    GridView3.FocusedColumn = GridView3.VisibleColumns(0)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Grid4_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid4.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _totIDR As Decimal = 0
                Dim _totUSD As Decimal = 0
                Dim _totYEN As Decimal = 0
                _totIDR = GetTotIdr()
                _totUSD = GetTotUSD()
                _totYEN = GetTotYEN()
                TxtTotalAdvanceIDR.Text = Format(_totIDR, gs_FormatBulat)
                TxtTotalAdvanceUSD.Text = Format(_totUSD, gs_FormatBulat)
                TxtTotalAdvanceYEN.Text = Format(_totYEN, gs_FormatBulat)
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter Then

                ObjTravelDetail = New TravelDetailModel
                If GridView4.FocusedColumn.FieldName = "Amount" Then
                    GridView4.ShowEditor()
                    GridView4.UpdateCurrentRow()
                    Dim _totidr As Decimal = GetTotIdr()
                    Dim _totusd As Decimal = GetTotUSD()
                    Dim _totyen As Decimal = GetTotYEN()
                    TxtTotalAdvanceIDR.Text = Format(_totidr, gs_FormatBulat)
                    TxtTotalAdvanceUSD.Text = Format(_totusd, gs_FormatBulat)
                    TxtTotalAdvanceYEN.Text = Format(_totyen, gs_FormatBulat)

                    GridView4.AddNewRow()
                    GridView4.OptionsNavigation.AutoFocusNewRow = True
                    GridView4.FocusedColumn = GridView4.VisibleColumns(0)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtDep_EditValueChanged(sender As Object, e As EventArgs) Handles TxtDep.EditValueChanged

    End Sub

    Private Sub TxtNama_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNama.EditValueChanged

    End Sub

    Private Sub TxtNama_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNama.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelHeader.GetTraveler
            ls_OldKode = TxtNama.Text
            ls_Judul = "Traveller"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                TxtNama.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
