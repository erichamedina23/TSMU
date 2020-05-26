Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmTravelSettleDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim ObjTravelHeader As New TravelHeaderModel
    Dim ObjTravelDetail As New TravelDetailModel
    Dim ObjTravelSettHeader As New TravelSettlementHeaderModel
    Dim ObjTravelSettDetail As New TravelSettlementDetailModel

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

    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _TravelID As String = ""
    Dim _TravelSettID As String
    Dim row As Integer
    Dim flag As Integer

    Dim AdvanceIDR As Decimal
    Dim SettIDR As Decimal
    Dim AdvanceYEN As Decimal
    Dim SettYEN As Decimal
    Dim AdvanceUSD As Decimal
    Dim SettUSD As Decimal
    Dim TotalAdvanceIDR As Decimal
    Dim TotalSettIDR As Decimal

    Dim ff_Detail7 As FrmEntertainSettleDetailDirect

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
        DtScan.Columns.AddRange(New DataColumn(6) {New DataColumn("Account", GetType(String)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double)),
                                                            New DataColumn("CuryID", GetType(String)),
                                                            New DataColumn("TSC Rare", GetType(String)),
                                                            New DataColumn("IDR Amount", GetType(Double))})
        GridTicket.DataSource = DtScan
        GridViewTicket.OptionsView.ShowAutoFilterRow = False

    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0, Optional ByVal IsNew As Boolean = True)
        If ff_Detail7 IsNot Nothing AndAlso ff_Detail7.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail7.Close()
        End If
        ff_Detail7 = New FrmEntertainSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, GridEntertain)
        ff_Detail7.MdiParent = MenuUtamaForm
        ff_Detail7.StartPosition = FormStartPosition.CenterScreen
        ff_Detail7.Show()
    End Sub

    Private Sub FrmTravelSettleDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
        Call InitialSetForm()

    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjTravelSettHeader.TravelSettID = fs_Code
                ObjTravelSettHeader.GetTravelSettById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Travel Settement Detail" + ": " + fs_Code
            Else
                Me.Text = "Travel Settement Detail"
            End If
            Call LoadTxtBox()
            LoadGridSummary()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmTravelSettle"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub EntertainID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CEntertainIDEntertain.ButtonClick
        Dim id As String = String.Empty
        Dim id2 As String = String.Empty

        Dim selectedRows() As Integer = GridViewEntertain.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                row = rowHandle
                id = IIf(GridViewEntertain.GetRowCellValue(rowHandle, "EntertainID") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(rowHandle, "EntertainID"))
                If id <> "" Then
                    id2 = ObjTravelSettDetail.GetSettleID(id)
                End If
            End If
        Next rowHandle

        Call CallFrm(id2, id, row)
        flag = 1
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                dtGrid = New DataTable
                ObjTravelSettDetail.TravelSettID = txtTravelSettID.Text
                dtGrid = ObjTravelSettDetail.GetTravelSettDetailByID()

                Dim FilteredRows As DataRow()

                FilteredRows = dtGrid.Select("ID = 1")
                GridTicket.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewTicket)
                FilteredRows = dtGrid.Select("ID = 2")
                GridTransport.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewTransport)
                FilteredRows = dtGrid.Select("ID = 3")
                GridHotel.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewHotel)
                FilteredRows = dtGrid.Select("ID = 4")
                GridEntertain.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewEntertain)
                FilteredRows = dtGrid.Select("ID = 5")
                GridAllowance.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewAllowance)
                FilteredRows = dtGrid.Select("ID = 6")
                GridPreTrip.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewPreTrip)
                FilteredRows = dtGrid.Select("ID >= 7")
                GridOther.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewOther)

                HitungAmountDetail(GridViewTicket, 0)
                HitungAmountDetail(GridViewTransport, 1)
                HitungAmountDetail(GridViewHotel, 2)
                HitungAmountDetail(GridViewEntertain, 3)
                HitungAmountDetail(GridViewAllowance, 4)
                HitungAmountDetail(GridViewPreTrip, 5)
                HitungAmountDetail(GridViewOther, 6)
            Else
                dtGrid = New DataTable
                ObjTravelDetail.TravelID = ""
                dtGrid = ObjTravelDetail.GetDataDetailByID()

                Dim FilteredRows As DataRow()

                FilteredRows = dtGrid.Select("ID = 1")
                GridTicket.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewTicket)
                FilteredRows = dtGrid.Select("ID = 2")
                GridTransport.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewTransport)
                FilteredRows = dtGrid.Select("ID = 3")
                GridHotel.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewHotel)
                FilteredRows = dtGrid.Select("ID = 4")
                GridEntertain.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewEntertain)
                FilteredRows = dtGrid.Select("ID = 5")
                GridAllowance.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewAllowance)
                FilteredRows = dtGrid.Select("ID = 6")
                GridPreTrip.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewPreTrip)
                FilteredRows = dtGrid.Select("ID >= 7")
                GridOther.DataSource = FilteredRows.CopyToDataTable
                GridCellFormat(GridViewOther)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjTravelSettHeader
                    txtTravelSettID.Text = .TravelSettID
                    TxtNoTravel.Text = .TravelID
                    TxtNama.Text = .Nama
                    TxtDep.Text = .DeptID
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
                    txtTotalSettIDR.Text = Format(.TotalSettIDR, gs_FormatBulat)
                    txtTotalSettYEN.Text = Format(.TotalSettYEN, gs_FormatBulat)
                    txtTotalSettUSD.Text = Format(.TotalSettUSD, gs_FormatBulat)
                    txtTotalAmountSettIDR.Text = Format(.TotalAmountSettIDR, gs_FormatBulat)
                    TxtArrDate.EditValue = .Arrdate
                    TxtDepDate.EditValue = .Depdate
                    txtTotalDay.Text = DateDiff(DateInterval.Day, TxtDepDate.EditValue, TxtArrDate.EditValue) + 1
                    TxtTgl.Enabled = False
                    TxtNama.Enabled = False
                    TxtNoTravel.Enabled = False
                End With
            Else
                TxtNama.Text = ""
                TxtNoTravel.Text = ""
                TxtDep.Text = ""
                TxtDestination.Text = ""
                txtVisa.Text = "YES"
                txtPurpose.Text = ""
                'txtPickUp.Text = ""
                TxtTgl.EditValue = DateTime.Today
                TxtTotalAdvanceIDR.Text = "0"
                TxtTotalAdvanceYEN.Text = "0"
                TxtTotalAdvanceUSD.Text = "0"
                TxtTotIDR.Text = "0"
                txtTotalSettIDR.Text = "0"
                txtTotalSettYEN.Text = "0"
                txtTotalSettUSD.Text = "0"
                txtTotalAmountSettIDR.Text = "0"
                txtBalanceTotalIDR.Text = "0"
                txtBalanceTotalYEN.Text = "0"
                txtBalanceTotalUSD.Text = "0"
                txtBalanceTotalAmountIDR.Text = "0"
                TxtArrDate.EditValue = DateTime.Today
                TxtDepDate.EditValue = DateTime.Today
                txtTotalDay.Text = DateDiff(DateInterval.Day, TxtArrDate.EditValue, TxtDepDate.EditValue) + 1
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If TxtNoTravel.Text = "" OrElse TxtNama.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If

            DataTravelSettDetail()
            For i As Integer = 0 To ObjTravelSettHeader.ObjSettDetails.Count - 1
                Dim _date As Date = ObjTravelSettHeader.ObjSettDetails(i).DetailDate
                Dim payType As String = ObjTravelSettHeader.ObjSettDetails(i).PaymentType
                Dim noRek As String = ObjTravelSettHeader.ObjSettDetails(i).Norek
                If _date = Nothing OrElse payType = "CC" And noRek = "" Then
                    Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
                End If
            Next

            If lb_Validated Then
                With ObjTravelSettHeader
                    _TravelSettID = txtTravelSettID.Text
                    .TravelSettID = _TravelSettID
                    .TravelID = TxtNoTravel.Text
                    .Nama = TxtNama.Text
                    .DeptID = TxtDep.Text
                    .Destination = TxtDestination.Text
                    .Purpose = txtPurpose.Text
                    .Term = TxtTerm.Text
                    .PickUp = ""
                    '.PickUp = txtPickUp.Text
                    .Visa = txtVisa.Text
                    .Tgl = TxtTgl.EditValue
                    .TotalAdvanceIDR = TxtTotalAdvanceIDR.Text
                    .TotalAdvanceYEN = TxtTotalAdvanceYEN.Text
                    .TotalAdvanceUSD = TxtTotalAdvanceUSD.Text
                    .TotalAdvIDR = TxtTotIDR.Text
                    .TotalSettIDR = txtTotalSettIDR.Text
                    .TotalSettYEN = txtTotalSettYEN.Text
                    .TotalSettUSD = txtTotalSettUSD.Text
                    .TotalAmountSettIDR = txtTotalAmountSettIDR.Text
                    .Arrdate = TxtArrDate.EditValue
                    .Depdate = TxtDepDate.EditValue
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CAccountTicket.ButtonClick, CAccountTransport.ButtonClick, CAccountHotel.ButtonClick, CAccountEntertain.ButtonClick, CAccountAllowance.ButtonClick, CAccountPreTrip.ButtonClick, CAccountOther.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelHeader.GetAccount
            ls_Judul = "Account"

            Dim editor As ButtonEdit = CType(sender, ButtonEdit)

            If editor.AccessibleName = CAccountTicket.Name Then
                ls_OldKode = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Account"))
            ElseIf editor.AccessibleName = CAccountTransport.Name Then
                ls_OldKode = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Account"))
            ElseIf editor.AccessibleName = CAccountHotel.Name Then
                ls_OldKode = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Account"))
            ElseIf editor.AccessibleName = CAccountEntertain.Name Then
                ls_OldKode = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Account"))
            ElseIf editor.AccessibleName = CAccountAllowance.Name Then
                ls_OldKode = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Account"))
            ElseIf editor.AccessibleName = CAccountPreTrip.Name Then
                ls_OldKode = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Account"))
            ElseIf editor.AccessibleName = CAccountOther.Name Then
                ls_OldKode = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Account"))
            End If

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
                If editor.AccessibleName = CAccountTicket.Name Then
                    GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = CAccountTransport.Name Then
                    GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = CAccountHotel.Name Then
                    GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = CAccountEntertain.Name Then
                    GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = CAccountAllowance.Name Then
                    GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = CAccountPreTrip.Name Then
                    GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = CAccountOther.Name Then
                    GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "Account", Value1)
                End If

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CNoRekening_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CNoRekTicket.ButtonClick, CNoRekTransport.ButtonClick, CNoRekHotel.ButtonClick, CNoRekEntertain.ButtonClick, CNoRekAllowance.ButtonClick, CNoRekPreTrip.ButtonClick, CNoRekOther.ButtonClick
        Try
            'ObjTravelSettHeader = New TravelSettlementHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dim paymentType As String = ""
            Dim norek As String = ""
            Dim NIK As String = ""

            Dim editor As ButtonEdit = CType(sender, ButtonEdit)

            If editor.AccessibleName = CNoRekTicket.Name Then
                ls_OldKode = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "PaymentType"))
            ElseIf editor.AccessibleName = CNoRekTransport.Name Then
                ls_OldKode = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "PaymentType"))
            ElseIf editor.AccessibleName = CNoRekHotel.Name Then
                ls_OldKode = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "PaymentType"))
            ElseIf editor.AccessibleName = CNoRekEntertain.Name Then
                ls_OldKode = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "PaymentType"))
            ElseIf editor.AccessibleName = CNoRekAllowance.Name Then
                ls_OldKode = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "PaymentType"))
            ElseIf editor.AccessibleName = CNoRekPreTrip.Name Then
                ls_OldKode = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "PaymentType"))
            ElseIf editor.AccessibleName = CNoRekOther.Name Then
                ls_OldKode = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "NoRekening") Is DBNull.Value, "", GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "NoRekening"))
                paymentType = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "PaymentType") Is DBNull.Value, "", GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "PaymentType"))
            End If

            If paymentType = "CC" Then
                NIK = ObjTravelSettHeader.NIK
                norek = ""
            Else
                NIK = ""
            End If

            dtSearch = ObjTravelSettHeader.GetTravelerCreditCard(NIK)
            ls_Judul = "Credit Card"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(1).ToString.Trim <> ls_OldKode Then
                norek = lF_SearchData.Values.Item(1).ToString.Trim
                If editor.AccessibleName = CNoRekTicket.Name Then
                    GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "NoRekening", norek)
                ElseIf editor.AccessibleName = CNoRekTransport.Name Then
                    GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "NoRekening", norek)
                ElseIf editor.AccessibleName = CNoRekHotel.Name Then
                    GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "NoRekening", norek)
                ElseIf editor.AccessibleName = CNoRekEntertain.Name Then
                    GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "NoRekening", norek)
                ElseIf editor.AccessibleName = CNoRekAllowance.Name Then
                    GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "NoRekening", norek)
                ElseIf editor.AccessibleName = CNoRekPreTrip.Name Then
                    GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "NoRekening", norek)
                ElseIf editor.AccessibleName = CNoRekOther.Name Then
                    GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "NoRekening", norek)
                End If
            End If

            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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
            If isUpdate = False Then
                _TravelSettID = ObjTravelSettHeader.TravelSettAutoNo
                ObjTravelSettHeader.TravelSettID = _TravelSettID
                DataTravelSettDetail()
                ObjTravelSettHeader.InsertDataTravelSett()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                DataTravelSettDetail()
                ObjTravelSettHeader.UpdateTravelSett()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjTravelSettHeader.GetTravelSettHeader()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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

    Private Sub TxtNama_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNama.ButtonClick

        Try
            ObjTravelSettHeader = New TravelSettlementHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelSettHeader.GetTravelerFromTravelID(TxtNoTravel.Text)
            ls_OldKode = TxtNama.Text
            ls_Judul = "Traveller"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim nama As String = ""
            Dim deptid As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ObjTravelSettHeader.NIK = lF_SearchData.Values.Item(1).ToString.Trim
                nama = lF_SearchData.Values.Item(2).ToString.Trim
                deptid = lF_SearchData.Values.Item(3).ToString.Trim
                TxtNama.Text = nama
                TxtDep.Text = deptid
                ResetGridDetail()
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtNoTravel_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoTravel.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim title As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelHeader.GetAdvanceTravel
            ls_OldKode = TxtNoTravel.Text
            title = "Travel"


            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & title
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim TravelID As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                TravelID = lF_SearchData.Values.Item(0).ToString.Trim
                TxtNoTravel.Text = TravelID
                ObjTravelHeader.TravelID = TravelID

                ObjTravelHeader.GetTravelByTravelID()

                With ObjTravelHeader
                    TxtNama.Text = ""
                    TxtDep.Text = ""
                    TxtDestination.Text = .Destination
                    txtPurpose.Text = .Purpose
                    TxtTerm.Text = .Term
                    'txtPickUp.Text = .PickUp
                    txtVisa.Text = .Visa
                    'TxtTgl.EditValue = .Tgl
                    TxtTotalAdvanceIDR.Text = Format(.TotalAdvanceIDR, gs_FormatBulat)
                    TxtTotalAdvanceYEN.Text = Format(.TotalAdvanceYEN, gs_FormatBulat)
                    TxtTotalAdvanceUSD.Text = Format(.TotalAdvanceUSD, gs_FormatBulat)
                    TxtTotIDR.Text = Format(.TotalAdvIDR, gs_FormatBulat)
                    TxtArrDate.EditValue = .Arrdate
                    TxtDepDate.EditValue = .Depdate
                    txtTotalDay.Text = DateDiff(DateInterval.Day, .Depdate, .Arrdate) + 1

                    ResetGridDetail()
                End With
            End If
            lF_SearchData.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ResetGridDetail()
        Dim dtGrid As New DataTable
        Dim FilteredRows As DataRow()

        ObjTravelDetail.TravelID = TxtNoTravel.Text
        dtGrid = ObjTravelDetail.GetDataDetailByID2()

        FilteredRows = dtGrid.Select("ID = 1")
        GridTicket.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewTicket)
        FilteredRows = dtGrid.Select("ID = 2")
        GridTransport.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewTransport)
        FilteredRows = dtGrid.Select("ID = 3")
        GridHotel.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewHotel)
        FilteredRows = dtGrid.Select("ID = 4")
        GridEntertain.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewEntertain)
        FilteredRows = dtGrid.Select("ID = 5")
        GridAllowance.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewAllowance)
        FilteredRows = dtGrid.Select("ID = 6")
        GridPreTrip.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewPreTrip)
        FilteredRows = dtGrid.Select("ID >= 7")
        GridOther.DataSource = FilteredRows.CopyToDataTable
        GridCellFormat(GridViewOther)

        HitungAmountDetail(GridViewTicket, 0)
        HitungAmountDetail(GridViewTransport, 1)
        HitungAmountDetail(GridViewHotel, 2)
        HitungAmountDetail(GridViewEntertain, 3)
        HitungAmountDetail(GridViewAllowance, 4)
        HitungAmountDetail(GridViewPreTrip, 5)
        HitungAmountDetail(GridViewOther, 6)
    End Sub

    Private Sub DataTravelSettDetail()
        ObjTravelSettHeader.ObjSettDetails.Clear()
        Dim seq As Integer
        'Data from grid ticket
        seq = 0
        For i As Integer = 0 To GridViewTicket.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 1 'GridViewTicket.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewTicket.GetRowCellValue(i, "Date")), Nothing, GridViewTicket.GetRowCellValue(i, "Date"))
                .AcctID = GridViewTicket.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewTicket.GetRowCellValue(i, "Description").ToString()
                .CuryID = GridViewTicket.GetRowCellValue(i, "CuryID")
                .Rate = GridViewTicket.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewTicket.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewTicket.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewTicket.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewTicket.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewTicket.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewTicket.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewTicket.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewTicket.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewTicket.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next

        'Data from grid transportasi
        seq = 0
        For i As Integer = 0 To GridViewTransport.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 2 'GridViewTransport.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewTransport.GetRowCellValue(i, "Date")), Nothing, GridViewTransport.GetRowCellValue(i, "Date"))
                .AcctID = GridViewTransport.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewTransport.GetRowCellValue(i, "Description").ToString()
                .CuryID = GridViewTransport.GetRowCellValue(i, "CuryID")
                .Rate = GridViewTransport.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewTransport.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewTransport.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewTransport.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewTransport.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewTransport.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewTransport.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewTransport.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewTransport.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewTransport.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next

        'Data from grid hotel
        seq = 0
        For i As Integer = 0 To GridViewHotel.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 3 'GridViewHotel.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewHotel.GetRowCellValue(i, "Date")), Nothing, GridViewHotel.GetRowCellValue(i, "Date"))
                .AcctID = GridViewHotel.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewHotel.GetRowCellValue(i, "Description").ToString()
                .CuryID = GridViewHotel.GetRowCellValue(i, "CuryID")
                .Rate = GridViewHotel.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewHotel.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewHotel.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewHotel.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewHotel.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewHotel.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewHotel.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewHotel.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewHotel.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewHotel.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next

        'Data from grid entertainment
        seq = 0
        For i As Integer = 0 To GridViewEntertain.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 4 'GridViewEntertain.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewEntertain.GetRowCellValue(i, "Date")), Nothing, GridViewEntertain.GetRowCellValue(i, "Date"))
                .AcctID = GridViewEntertain.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewEntertain.GetRowCellValue(i, "Description").ToString()
                .EntertainID = IIf(GridViewEntertain.GetRowCellValue(i, "EntertainID") Is Nothing, "", GridViewEntertain.GetRowCellValue(i, "EntertainID"))
                .CuryID = GridViewEntertain.GetRowCellValue(i, "CuryID")
                .Rate = GridViewEntertain.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewEntertain.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewEntertain.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewEntertain.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewEntertain.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewEntertain.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next

        'Data from grid poket allowance
        seq = 0
        For i As Integer = 0 To GridViewAllowance.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 5 'GridViewAllowance.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewAllowance.GetRowCellValue(i, "Date")), Nothing, GridViewAllowance.GetRowCellValue(i, "Date"))
                .AcctID = GridViewAllowance.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewAllowance.GetRowCellValue(i, "Description").ToString()
                .CuryID = GridViewAllowance.GetRowCellValue(i, "CuryID")
                .Rate = GridViewAllowance.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewAllowance.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewAllowance.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewAllowance.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewAllowance.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewAllowance.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewAllowance.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewAllowance.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewAllowance.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewAllowance.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next

        'Data from grid preparation B-Trip
        seq = 0
        For i As Integer = 0 To GridViewPreTrip.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 6 'GridViewPreTrip.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewPreTrip.GetRowCellValue(i, "Date")), Nothing, GridViewPreTrip.GetRowCellValue(i, "Date"))
                .AcctID = GridViewPreTrip.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewPreTrip.GetRowCellValue(i, "Description").ToString()
                .CuryID = GridViewPreTrip.GetRowCellValue(i, "CuryID")
                .Rate = GridViewPreTrip.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewPreTrip.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewPreTrip.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewPreTrip.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewPreTrip.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewPreTrip.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewPreTrip.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewPreTrip.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewPreTrip.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewPreTrip.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next

        'Data from grid other
        seq = 0
        For i As Integer = 0 To GridViewOther.RowCount - 1
            ObjTravelSettDetail = New TravelSettlementDetailModel
            With ObjTravelSettDetail
                .TravelSettID = _TravelSettID
                .TravelID = TxtNoTravel.Text
                .ID = 7 'GridViewOther.GetRowCellValue(i, "ID")
                seq = seq + 1
                .Seq = seq
                .DetailDate = IIf(String.IsNullOrEmpty(GridViewOther.GetRowCellValue(i, "Date")), Nothing, GridViewOther.GetRowCellValue(i, "Date"))
                .AcctID = GridViewOther.GetRowCellValue(i, "Account").ToString().TrimEnd
                .Description = GridViewOther.GetRowCellValue(i, "Description").ToString()
                .CuryID = GridViewOther.GetRowCellValue(i, "CuryID")
                .Rate = GridViewOther.GetRowCellValue(i, "Rate")
                .Amount = Convert.ToDouble(GridViewOther.GetRowCellValue(i, "Amount"))
                .AmountIDR = Convert.ToDouble(GridViewOther.GetRowCellValue(i, "AmountIDR"))
                .PaymentType = GridViewOther.GetRowCellValue(i, "PaymentType")
                .Norek = GridViewOther.GetRowCellValue(i, "NoRekening")
                .CuryIDSett = GridViewOther.GetRowCellValue(i, "CuryIDSett")
                .RateSett = GridViewOther.GetRowCellValue(i, "RateSett")
                .AmountSett = Convert.ToDouble(GridViewOther.GetRowCellValue(i, "AmountSett"))
                .AmountIDRSett = Convert.ToDouble(GridViewOther.GetRowCellValue(i, "AmountIDRSett"))
                .SubAcct = GridViewOther.GetRowCellValue(i, "SubAccount")
            End With
            ObjTravelSettHeader.ObjSettDetails.Add(ObjTravelSettDetail)
        Next
    End Sub

#Region "Event From Grid Ticket"
    Private Sub GridTicket_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
        AddNewRow(GridViewTicket)
    End Sub

    Private Sub CDateTicket1_EditValueChanged(sender As Object, e As EventArgs) Handles CDateTicket1.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CAmountTicket_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountTicket.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Rate"))

        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewTicket, 0)

    End Sub

    Private Sub CRateTicket_EditValueChanged(sender As Object, e As EventArgs) Handles CRateTicket.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "Rate"))
        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "Rate", Rate)

        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewTicket, 0)

    End Sub

    Private Sub CCurryTicket_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryTicket.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CCuryIDSettTicket_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettTicket.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountSett")
        End If

        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CPayTypeTicket_EditValueChanged(sender As Object, e As EventArgs) Handles CPayTypeTicket.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "NoRekening", "")
        GridViewTicket.RefreshData()
    End Sub

    Private Sub CAmountSettTicket_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettTicket.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "RateSett")
        End If

        GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub GridViewTicket_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewTicket.KeyDown
        Dim index As Integer
        index = GridViewTicket.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewTicket.DeleteRow(GridViewTicket.FocusedRowHandle)
            GridViewTicket.RefreshData()
            HitungAmountDetail(GridViewTicket, 0)
        End If

        If e.KeyData = Keys.Insert Then
            GridViewTicket.AddNewRow()
        End If
    End Sub

#End Region

#Region "Event From Grid Transportasi"
    Private Sub GridTransport_DoubleClick(sender As Object, e As EventArgs) Handles GridTransport.DoubleClick
        AddNewRow(GridViewTransport)
    End Sub

    Private Sub CDateTransport_EditValueChanged(sender As Object, e As EventArgs) Handles CDateTransport.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CAmountTransport_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountTransport.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Rate"))

        GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewTransport, 1)

    End Sub

    Private Sub CRateTransport_EditValueChanged(sender As Object, e As EventArgs) Handles CRateTransport.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "Rate"))

        GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewTransport, 1)

    End Sub

    Private Sub CCurryTransport_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryTransport.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTransport, 1)
    End Sub

    Private Sub CCuryIDSettTransport_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettTransport.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountSett")
        End If

        GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewTransport, 1)
    End Sub

    Private Sub CAmountSettTransport_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettTransport.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewTransport.GetRowCellValue(GridViewTransport.FocusedRowHandle, "RateSett")
        End If

        GridViewTransport.SetRowCellValue(GridViewTransport.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewTransport, 1)
    End Sub

    Private Sub GridViewTransport_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewTransport.KeyDown
        Dim index As Integer
        index = GridViewTransport.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewTransport.DeleteRow(GridViewTransport.FocusedRowHandle)
            GridViewTransport.RefreshData()
            HitungAmountDetail(GridViewTransport, 1)
        End If
        If e.KeyData = Keys.Insert Then
            GridViewTransport.AddNewRow()
        End If
    End Sub

#End Region

#Region "Event From Grid Hotel"
    Private Sub GridHotel_DoubleClick(sender As Object, e As EventArgs) Handles GridHotel.DoubleClick
        AddNewRow(GridViewHotel)
    End Sub

    Private Sub CDateHotel_EditValueChanged(sender As Object, e As EventArgs) Handles CDateHotel.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CAmountHotel_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountHotel.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Rate"))

        GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewHotel, 2)
    End Sub

    Private Sub CRateHotel_EditValueChanged(sender As Object, e As EventArgs) Handles CRateHotel.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "Rate"))

        GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewHotel, 2)
    End Sub

    Private Sub CCurryHotel_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryHotel.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewHotel, 2)
    End Sub

    Private Sub CCuryIDSettHotel_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettHotel.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountSett")
        End If

        GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewHotel, 2)
    End Sub

    Private Sub CAmountSettHotel_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettHotel.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewHotel.GetRowCellValue(GridViewHotel.FocusedRowHandle, "RateSett")
        End If

        GridViewHotel.SetRowCellValue(GridViewHotel.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewHotel, 2)
    End Sub

    Private Sub GridViewHotel_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewHotel.KeyDown
        Dim index As Integer
        index = GridViewHotel.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewHotel.DeleteRow(GridViewHotel.FocusedRowHandle)
            GridViewHotel.RefreshData()
            HitungAmountDetail(GridViewHotel, 2)
        End If
        If e.KeyData = Keys.Insert Then
            GridViewHotel.AddNewRow()
        End If
    End Sub

#End Region

#Region "Event From Grid Entertainment"
    Private Sub GridEntertain_DoubleClick(sender As Object, e As EventArgs) Handles GridEntertain.DoubleClick
        AddNewRow(GridViewEntertain)
    End Sub

    Private Sub CAmountEntertain_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountEntertain.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Rate"))

        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewEntertain, 3)
    End Sub

    Private Sub CDateEntertain_EditValueChanged(sender As Object, e As EventArgs) Handles CDateEntertain.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CRateEntertain_EditValueChanged(sender As Object, e As EventArgs) Handles CRateEntertain.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Rate"))

        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewEntertain, 3)
    End Sub

    Private Sub CCurryEntertain_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryEntertain.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewEntertain, 3)
    End Sub

    Private Sub CCuryIDSettEntertain_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettEntertain.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett")
        End If

        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewEntertain, 3)
    End Sub

    Private Sub CAmountSettEntertain_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettEntertain.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "RateSett")
        End If

        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewEntertain, 3)
    End Sub

    Private Sub GridViewEntertain_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewEntertain.KeyDown
        Dim index As Integer
        index = GridViewEntertain.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewEntertain.DeleteRow(GridViewEntertain.FocusedRowHandle)
            GridViewEntertain.RefreshData()
            HitungAmountDetail(GridViewEntertain, 3)
        End If
        If e.KeyData = Keys.Insert Then
            GridViewEntertain.AddNewRow()
        End If
    End Sub

#End Region

#Region "Event From Grid Allowance"
    Private Sub GridAllowance_DoubleClick(sender As Object, e As EventArgs) Handles GridAllowance.DoubleClick
        AddNewRow(GridViewAllowance)
    End Sub

    Private Sub CDateAllowance_EditValueChanged(sender As Object, e As EventArgs) Handles CDateAllowance.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CAmountAllowance_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountAllowance.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Rate"))

        GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewAllowance, 4)
    End Sub

    Private Sub CRateAllowance_EditValueChanged(sender As Object, e As EventArgs) Handles CRateAllowance.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "Rate"))

        GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewAllowance, 4)
    End Sub

    Private Sub CCurryAllowance_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryAllowance.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewAllowance, 4)
    End Sub

    Private Sub CCuryIDSettAllowance_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettAllowance.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountSett")
        End If

        GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewAllowance, 4)
    End Sub

    Private Sub CAmountSettAllowance_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettAllowance.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewAllowance.GetRowCellValue(GridViewAllowance.FocusedRowHandle, "RateSett")
        End If

        GridViewAllowance.SetRowCellValue(GridViewAllowance.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewAllowance, 4)
    End Sub

    Private Sub GridViewAllowance_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewAllowance.KeyDown
        Dim index As Integer
        index = GridViewAllowance.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewAllowance.DeleteRow(GridViewAllowance.FocusedRowHandle)
            GridViewAllowance.RefreshData()
            HitungAmountDetail(GridViewAllowance, 4)
        End If
        If e.KeyData = Keys.Insert Then
            GridViewAllowance.AddNewRow()
        End If
    End Sub

#End Region

#Region "Event From Grid B-Trip"
    Private Sub GridPreTrip_DoubleClick(sender As Object, e As EventArgs) Handles GridPreTrip.DoubleClick
        AddNewRow(GridViewPreTrip)
    End Sub

    Private Sub CDatePreTrip_EditValueChanged(sender As Object, e As EventArgs) Handles CDatePreTrip.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CAmountPreTrip_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountPreTrip.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Rate"))

        GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewPreTrip, 5)
    End Sub

    Private Sub CRatePreTrip_EditValueChanged(sender As Object, e As EventArgs) Handles CRatePreTrip.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "Rate"))

        GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewPreTrip, 5)
    End Sub

    Private Sub CCurryPreTrip_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryPreTrip.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewPreTrip, 5)
    End Sub

    Private Sub CCuryIDSettPreTrip_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettPreTrip.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountSett")
        End If

        GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewPreTrip, 5)
    End Sub

    Private Sub CAmountSettPreTrip_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettPreTrip.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewPreTrip.GetRowCellValue(GridViewPreTrip.FocusedRowHandle, "RateSett")
        End If

        GridViewPreTrip.SetRowCellValue(GridViewPreTrip.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewPreTrip, 5)
    End Sub

    Private Sub GridViewPreTrip_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewPreTrip.KeyDown
        Dim index As Integer
        index = GridViewPreTrip.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewPreTrip.DeleteRow(GridViewPreTrip.FocusedRowHandle)
            GridViewPreTrip.RefreshData()
            HitungAmountDetail(GridViewPreTrip, 5)
        End If
        If e.KeyData = Keys.Insert Then
            GridViewPreTrip.AddNewRow()
        End If
    End Sub

#End Region

#Region "Event From Grid Others"
    Private Sub GridOther_DoubleClick(sender As Object, e As EventArgs) Handles GridOther.DoubleClick
        AddNewRow(GridViewOther)
    End Sub

    Private Sub CDateOther_EditValueChanged(sender As Object, e As EventArgs) Handles CDateOther.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewTicket, 0)
    End Sub

    Private Sub CAmountOther_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountOther.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Rate"))

        GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewOther, 6)
    End Sub

    Private Sub CRateOther_EditValueChanged(sender As Object, e As EventArgs) Handles CRateOther.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim Amount As Double
        Dim Rate As Double

        Amount = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Amount"))
        Rate = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Rate") Is DBNull.Value, 1, GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "Rate"))

        GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "AmountIDR", Amount * Rate)
        HitungAmountDetail(GridViewOther, 6)
    End Sub

    Private Sub CCurryOther_EditValueChanged(sender As Object, e As EventArgs) Handles CCurryOther.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        HitungAmountDetail(GridViewOther, 6)
    End Sub

    Private Sub CCuryIDSettOther_EditValueChanged(sender As Object, e As EventArgs) Handles CCuryIDSettOther.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double
        Dim curyID As String

        curyID = IIf(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "CuryIDSett") = "YEN", "JPY", GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "CuryIDSett"))
        vrate = ObjTravelHeader.GetRate(curyID)
        GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "RateSett", vrate)

        If IsDBNull(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "AmountSett")
        End If

        GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewOther, 6)
    End Sub

    Private Sub CAmountSettOther_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountSettOther.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double
        Dim vrate As Double

        If IsDBNull(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "AmountSett")) Then
            jumlah = 0
            GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "AmountSett", jumlah)
        Else
            jumlah = GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "AmountSett")
        End If

        If IsDBNull(GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "RateSett")) Then
            vrate = 1
            GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "RateSett", jumlah)
        Else
            vrate = GridViewOther.GetRowCellValue(GridViewOther.FocusedRowHandle, "RateSett")
        End If

        GridViewOther.SetRowCellValue(GridViewOther.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)

        HitungAmountDetail(GridViewOther, 6)
    End Sub

    Private Sub GridViewOther_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewOther.KeyDown
        Dim index As Integer
        index = GridViewOther.GetFocusedDataSourceRowIndex()

        If e.KeyData = Keys.Delete And index <> 0 Then
            GridViewOther.DeleteRow(GridViewOther.FocusedRowHandle)
            GridViewOther.RefreshData()
            HitungAmountDetail(GridViewOther, 6)
        End If
        If e.KeyData = Keys.Insert Then
            GridViewOther.AddNewRow()
        End If
    End Sub

#End Region

    Private Sub AddNewRow(ByVal view As GridView)
        view.AddNewRow()
        view.OptionsNavigation.AutoFocusNewRow = True
        view.FocusedColumn = view.VisibleColumns(0)

        view.SetRowCellValue(view.FocusedRowHandle, "Date", "")
        view.SetRowCellValue(view.FocusedRowHandle, "Account", "")
        view.SetRowCellValue(view.FocusedRowHandle, "CuryID", "IDR")
        view.SetRowCellValue(view.FocusedRowHandle, "Rate", 1)
        view.SetRowCellValue(view.FocusedRowHandle, "Amount", 0)
        view.SetRowCellValue(view.FocusedRowHandle, "AmountIDR", 0)
        view.SetRowCellValue(view.FocusedRowHandle, "PaymentType", "CASH")
        view.SetRowCellValue(view.FocusedRowHandle, "NoRekening", "")
        view.SetRowCellValue(view.FocusedRowHandle, "CuryIDSett", "IDR")
        view.SetRowCellValue(view.FocusedRowHandle, "RateSett", 1)
        view.SetRowCellValue(view.FocusedRowHandle, "AmountSett", 0)
        view.SetRowCellValue(view.FocusedRowHandle, "AmountIDRSett", 0)
        view.SetRowCellValue(view.FocusedRowHandle, "ID", view.GetRowCellValue(0, "ID"))
        view.SetRowCellValue(view.FocusedRowHandle, "SubAccount", view.GetRowCellValue(0, "SubAccount"))
    End Sub

    Private Sub HitungAmountHeader()
        txtTotalSettIDR.Text = Format(GridViewSummary.Columns("SettIDR").SummaryItem.SummaryValue, gs_FormatBulat)
        txtTotalSettYEN.Text = Format(GridViewSummary.Columns("SettYEN").SummaryItem.SummaryValue, gs_FormatBulat)
        txtTotalSettUSD.Text = Format(GridViewSummary.Columns("SettUSD").SummaryItem.SummaryValue, gs_FormatBulat)
        txtTotalAmountSettIDR.Text = Format(GridViewSummary.Columns("TotalSettIDR").SummaryItem.SummaryValue, gs_FormatBulat)

        txtBalanceTotalIDR.Text = Format(TxtTotalAdvanceIDR.Text - txtTotalSettIDR.Text, gs_FormatBulat)
        txtBalanceTotalYEN.Text = Format(TxtTotalAdvanceYEN.Text - txtTotalSettYEN.Text, gs_FormatBulat)
        txtBalanceTotalUSD.Text = Format(TxtTotalAdvanceUSD.Text - txtTotalSettUSD.Text, gs_FormatBulat)
        txtBalanceTotalAmountIDR.Text = Format(TxtTotIDR.Text - txtTotalAmountSettIDR.Text, gs_FormatBulat)
    End Sub

    Private Sub HitungAmountDetail(ByVal view As GridView, ByVal row As Integer)
        AdvanceIDR = 0
        SettIDR = 0
        AdvanceYEN = 0
        SettYEN = 0
        AdvanceUSD = 0
        SettUSD = 0
        TotalAdvanceIDR = 0
        TotalSettIDR = 0

        Try
            For i As Integer = 0 To view.RowCount - 1
                If Not IsDBNull(view.GetRowCellValue(i, "Amount")) Then
                    If view.GetRowCellValue(i, "CuryID") = "IDR" Then
                        AdvanceIDR = AdvanceIDR + Convert.ToDecimal(view.GetRowCellValue(i, "Amount"))
                    End If
                    If view.GetRowCellValue(i, "CuryID") = "USD" Then
                        AdvanceUSD = AdvanceUSD + Convert.ToDecimal(view.GetRowCellValue(i, "Amount"))
                    End If
                    If view.GetRowCellValue(i, "CuryID") = "YEN" Then
                        AdvanceYEN = AdvanceYEN + Convert.ToDecimal(view.GetRowCellValue(i, "Amount"))
                    End If
                    TotalAdvanceIDR = TotalAdvanceIDR + Convert.ToDecimal(view.GetRowCellValue(i, "AmountIDR"))
                End If
            Next

            For i As Integer = 0 To view.RowCount - 1
                If Not IsDBNull(view.GetRowCellValue(i, "AmountSett")) Then
                    If view.GetRowCellValue(i, "CuryIDSett") = "IDR" Then
                        SettIDR = SettIDR + Convert.ToDecimal(view.GetRowCellValue(i, "AmountSett"))
                    End If
                    If view.GetRowCellValue(i, "CuryIDSett") = "USD" Then
                        SettUSD = SettUSD + Convert.ToDecimal(view.GetRowCellValue(i, "AmountSett"))
                    End If
                    If view.GetRowCellValue(i, "CuryIDSett") = "YEN" Then
                        SettYEN = SettYEN + Convert.ToDecimal(view.GetRowCellValue(i, "AmountSett"))
                    End If
                    TotalSettIDR = TotalSettIDR + Convert.ToDecimal(view.GetRowCellValue(i, "AmountIDRSett"))
                End If
            Next

            If row = 0 Then
                TxtTotTicketIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotTicketYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotTicketUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotTicketIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            ElseIf row = 1 Then
                TxtTotTransIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotTransYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotTransUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotTransIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            ElseIf row = 2 Then
                TxtTotHotelIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotHotelYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotHotelUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotHotelIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            ElseIf row = 3 Then
                TxtTotEnterIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotEnterYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotEnterUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotEnterIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            ElseIf row = 4 Then
                TxtTotPocketIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotPocketYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotPocketUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotPocketIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            ElseIf row = 5 Then
                TxtTotTripIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotTripYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotTripUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotTripIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            Else
                TxtTotOtherIDR.Text = Format(AdvanceIDR, gs_FormatBulat)
                TxtTotOtherYEN.Text = Format(AdvanceYEN, gs_FormatBulat)
                TxtTotOtherUSD.Text = Format(AdvanceUSD, gs_FormatBulat)
                TxtTotOtherIDRAmt.Text = Format(TotalAdvanceIDR, gs_FormatBulat)
            End If

            HitungSummary(row)
            HitungAmountHeader()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HitungSummary(ByVal row As Integer)
        GridViewSummary.SetRowCellValue(row, "AdvanceIDR", AdvanceIDR)
        GridViewSummary.SetRowCellValue(row, "SettIDR", SettIDR)
        GridViewSummary.SetRowCellValue(row, "AdvanceYEN", AdvanceYEN)
        GridViewSummary.SetRowCellValue(row, "SettYEN", SettYEN)
        GridViewSummary.SetRowCellValue(row, "AdvanceUSD", AdvanceUSD)
        GridViewSummary.SetRowCellValue(row, "SettUSD", SettUSD)
        GridViewSummary.SetRowCellValue(row, "TotalAdvanceIDR", TotalAdvanceIDR)
        GridViewSummary.SetRowCellValue(row, "TotalSettIDR", TotalSettIDR)

        GridViewSummary.RefreshData()
    End Sub

    Private Sub LoadGridSummary()
        dtGrid = New DataTable
        dtGrid = ObjTravelSettDetail.GetDataSummary()

        GridSummary.DataSource = dtGrid
        GridCellFormat(GridViewSummary)
    End Sub

    Private Sub FrmTravelSettleDetail_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If flag = 1 Then
            Dim EntertainID As String
            Dim IDSettle As String
            Dim jumlah As Double
            Dim vrate As Double

            EntertainID = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "EntertainID") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "EntertainID"))

            If EntertainID <> "" Then
                IDSettle = ObjTravelSettDetail.GetSettleID(EntertainID)
                GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "IDSettle", IDSettle)
            End If

            jumlah = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett") Is DBNull.Value, 0, GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountSett"))
            vrate = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "RateSett") Is DBNull.Value, 1, GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "RateSett"))

            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "AmountIDRSett", jumlah * vrate)
            HitungAmountDetail(GridViewEntertain, 3)
            flag = 0
        End If
    End Sub

End Class