Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmTravelRequestDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim dtCost As New DataTable
    Dim row_ As DataRow
    Dim firstravel As Boolean = False
    Dim amountFirstTravel As Double
    Dim descFirstTravel As String

    Dim departureDate_ As Date
    Dim arrivalDate_ As Date
    Dim days As Integer
    Dim NoRequest As String
    Dim dtGrid As DataTable
    Dim GridDtl As GridControl

    Dim ObjTravelRequest As New TravelRequestModel
    Dim ObjTravelRequestDetail As New TravelRequestDetailModel
    Dim ObjTravelRequestCost As New TravelRequestCostModel

    Dim ff_Direct As FrmTravelTicketDetail
    'Dim ObjTravelRequestAllowance As New TravelRequestAllowanceModel

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

    Private Sub FrmTravelRequestDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjTravelRequest.GetRequestHeaderByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Travel Request : " & fs_Code
            Else
                Me.Text = "New Travel Request"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmTravelRequest"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            CreateDataTable()
            ListItemsNegara()

            If fs_Code <> "" Then
                dtGrid = New DataTable
                ObjTravelRequestDetail.NoRequest = txtNoRequest.Text
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid
                GridCellFormat(GridViewDetail)

                ObjTravelRequestCost.NoRequest = txtNoRequest.Text
                dtGrid = ObjTravelRequestCost.GetCostByID()
                GridAdvance.DataSource = dtGrid
                GridCellFormat(GridViewAdvance)

                Dim FilteredRows As DataRow()
                FilteredRows = dtGrid.Select("CostType = 'FT'")
                row_ = FilteredRows(0)
                'row_ = dtCost.NewRow
                'dtCost.Rows.Add(row_.ItemArray)

                FilteredRows = dtGrid.Select("CostType = 'AT'")
                If FilteredRows.Count > 0 Then
                    txtAdvanceIDR.Text = Format(FilteredRows(0).Item("AdvanceIDR"), gs_FormatDecimal)
                    txtAdvanceUSD.Text = Format(FilteredRows(0).Item("AdvanceUSD"), gs_FormatDecimal)
                    txtAdvanceYEN.Text = Format(FilteredRows(0).Item("AdvanceYEN"), gs_FormatDecimal)
                End If

            Else
                dtGrid = New DataTable
                ObjTravelRequestDetail.NoRequest = ""
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid
                GridCellFormat(GridViewDetail)

                ObjTravelRequestCost.NoRequest = ""
                dtGrid = ObjTravelRequestCost.GetCostByID()
                GridAdvance.DataSource = dtGrid
                GridCellFormat(GridViewAdvance)

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            ListItemsGolongan()
            Dim objTravelHeader = New TravelHeaderModel
            Dim ketRateUSD As String
            Dim ketRateYEN As String

            If fs_Code <> "" Then
                With ObjTravelRequest
                    txtNoRequest.Text = .NoRequest
                    txtNIK.Text = .NIK
                    txtNama.Text = .Nama
                    'dtTanggal.EditValue = .Tanggal
                    txtDepartement.Text = .DeptID
                    txtTravelType.Text = .TravelType
                    txtGolongan.Text = .Golongan
                    txtPurpose.Text = .Purpose
                End With
                ketRateUSD = Format(objTravelHeader.GetRate("USD", ObjTravelRequest.Tanggal), gs_FormatDecimal)
                ketRateYEN = Format(objTravelHeader.GetRate("JPY", ObjTravelRequest.Tanggal), gs_FormatDecimal)
            Else
                txtNoRequest.Text = ""
                ''dtTanggal.EditValue = DateTime.Today
                txtDepartement.Text = gh_Common.GroupID
                txtNIK.Text = ""
                txtNama.Text = ""
                txtGolongan.Text = ""
                txtPurpose.Text = ""
                txtTravelType.Text = "LN"
                txtAdvanceIDR.Text = Format(0, gs_FormatDecimal)
                txtAdvanceUSD.Text = Format(0, gs_FormatDecimal)
                txtAdvanceYEN.Text = Format(0, gs_FormatDecimal)
                txtNIK.Focus()
                ketRateUSD = Format(objTravelHeader.GetRate("USD", DateTime.Today), gs_FormatDecimal)
                ketRateYEN = Format(objTravelHeader.GetRate("JPY", DateTime.Today), gs_FormatDecimal)
            End If
            Label1.Text = "1USD : " & ketRateUSD & "   |   1YEN : " & ketRateYEN & ""

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim success As Boolean = True

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If isUpdate Then
                If ObjTravelRequest.Status = "Approved" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah di Approve oleh atasan !")
                ElseIf ObjTravelRequest.Status = "Reject" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah di Reject oleh atasan !")
                End If
            End If

            If txtNIK.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If

            Dim i As Integer
            If String.IsNullOrEmpty(txtGolongan.Text) Then
                i = "0"
            Else
                i = Convert.ToInt16(txtGolongan.Text)
            End If

            If lb_Validated Then
                With ObjTravelRequest
                    NoRequest = .TravelRequestAutoNo
                    .NoRequest = NoRequest
                    .Nama = txtNama.Text.Trim.ToUpper
                    '.Tanggal = Date.Today
                    .DeptID = txtDepartement.Text.Trim.ToUpper
                    .TravelType = txtTravelType.Text.Trim.ToUpper
                    .NIK = txtNIK.Text.Trim.ToUpper
                    .Golongan = i
                    .Purpose = txtPurpose.Text
                    .Status = "Open"
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Public Overrides Sub Proc_SaveData()
        Try
            Dim seq As Integer = 0
            If isUpdate = False Then
                ObjTravelRequest.ObjRequestDetails.Clear()
                For i As Integer = 0 To GridViewDetail.RowCount - 1
                    seq = seq + 1
                    ObjTravelRequestDetail = New TravelRequestDetailModel
                    With ObjTravelRequestDetail
                        .NoRequest = NoRequest
                        .Seq = seq
                        .Destination = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd.ToUpper
                        .Negara = GridViewDetail.GetRowCellValue(i, "Negara").ToString().TrimEnd
                        .Visa = GridViewDetail.GetRowCellValue(i, "Visa").ToString().TrimEnd
                        .DepartureDate = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
                        .ArrivalDate = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
                    End With
                    ObjTravelRequest.ObjRequestDetails.Add(ObjTravelRequestDetail)
                Next

                ObjTravelRequest.ObjRequestCost.Clear()
                For i As Integer = 0 To GridViewAdvance.RowCount - 1
                    ObjTravelRequestCost = New TravelRequestCostModel
                    With ObjTravelRequestCost
                        .NoRequest = NoRequest
                        .CostType = GridViewAdvance.GetRowCellValue(i, "CostType").ToString().TrimEnd.ToUpper
                        .Description = GridViewAdvance.GetRowCellValue(i, "Description").ToString().TrimEnd
                        .Days = Convert.ToInt16(GridViewAdvance.GetRowCellValue(i, "Days"))
                        .AdvanceIDR = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceIDR"))
                        .AdvanceUSD = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceUSD"))
                        .AdvanceYEN = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceYEN"))
                    End With
                    ObjTravelRequest.ObjRequestCost.Add(ObjTravelRequestCost)
                Next

                ObjTravelRequest.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            Else
                ObjTravelRequest.ObjRequestDetails.Clear()
                For i As Integer = 0 To GridViewDetail.RowCount - 1
                    seq = seq + 1
                    ObjTravelRequestDetail = New TravelRequestDetailModel
                    With ObjTravelRequestDetail
                        .NoRequest = txtNoRequest.Text
                        .Seq = seq
                        .Destination = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd.ToUpper
                        .Negara = GridViewDetail.GetRowCellValue(i, "Negara").ToString().TrimEnd
                        .Visa = GridViewDetail.GetRowCellValue(i, "Visa").ToString().TrimEnd
                        .DepartureDate = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
                        .ArrivalDate = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
                    End With
                    ObjTravelRequest.ObjRequestDetails.Add(ObjTravelRequestDetail)
                Next

                ObjTravelRequest.ObjRequestCost.Clear()
                For i As Integer = 0 To GridViewAdvance.RowCount - 1
                    ObjTravelRequestCost = New TravelRequestCostModel
                    With ObjTravelRequestCost
                        .NoRequest = txtNoRequest.Text
                        .CostType = GridViewAdvance.GetRowCellValue(i, "CostType").ToString().TrimEnd.ToUpper
                        .Description = GridViewAdvance.GetRowCellValue(i, "Description").ToString().TrimEnd
                        .Days = Convert.ToInt16(GridViewAdvance.GetRowCellValue(i, "Days"))
                        .AdvanceIDR = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceIDR"))
                        .AdvanceUSD = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceUSD"))
                        .AdvanceYEN = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceYEN"))
                    End With
                    ObjTravelRequest.ObjRequestCost.Add(ObjTravelRequestCost)
                Next

                ObjTravelRequest.NoRequest = txtNoRequest.Text
                ObjTravelRequest.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjTravelRequest.GetAllDataTable("")
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridViewDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewDetail.KeyDown
        If e.KeyData = Keys.Delete Then
            GridViewDetail.DeleteRow(GridViewDetail.FocusedRowHandle)
            GridViewDetail.RefreshData()
            'HitungTotalAmount()
        End If
        If e.KeyData = Keys.Insert Then
            GridViewDetail.AddNewRow()
        End If
    End Sub

    Private Sub txtNIK_EditValueChanged(sender As Object, e As EventArgs) Handles txtNIK.EditValueChanged
        CheckFirstTravel()
    End Sub

    Private Sub txtGolongan_EditValueChanged(sender As Object, e As EventArgs) Handles txtGolongan.EditValueChanged
        If GridViewDetail.RowCount > 0 Then
            HitungTotalAmount()
        End If
    End Sub

    Private Sub txtTravelType_EditValueChanged(sender As Object, e As EventArgs) Handles txtTravelType.EditValueChanged
        If txtTravelType.Text <> "" Then
            ListItemsNegara()
        End If

        Dim negara As String = "INDONESIA"
        If txtTravelType.Text = "LN" Then
            negara = ""
        End If

        For i As Integer = 0 To GridViewDetail.RowCount - 1
            GridViewDetail.SetRowCellValue(i, "Negara", negara)
        Next
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara", negara)
        'HitungTotalAmount()
    End Sub

    Private Sub txtAdvanceIDR_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceIDR.EditValueChanged
        If GridViewDetail.RowCount > 0 Then
            'HitungTotalAmount()
        End If
        If String.IsNullOrEmpty(txtAdvanceIDR.Text) Then
            txtAdvanceIDR.Text = 0
        End If
        txtAdvanceIDR.Text = Format(Convert.ToDecimal(txtAdvanceIDR.Text), gs_FormatDecimal)
    End Sub

    Private Sub txtAdvanceUSD_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceUSD.EditValueChanged
        If GridViewDetail.RowCount > 0 Then
            'HitungTotalAmount()
        End If
        If String.IsNullOrEmpty(txtAdvanceUSD.Text) Then
            txtAdvanceUSD.Text = 0
        End If
        txtAdvanceUSD.Text = Format(Convert.ToDecimal(txtAdvanceUSD.Text), gs_FormatDecimal)
    End Sub

    Private Sub txtAdvanceYEN_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceYEN.EditValueChanged
        If GridViewDetail.RowCount > 0 Then
            'HitungTotalAmount()
        End If
        If String.IsNullOrEmpty(txtAdvanceYEN.Text) Then
            txtAdvanceYEN.Text = 0
        End If
        txtAdvanceYEN.Text = Format(Convert.ToDecimal(txtAdvanceYEN.Text), gs_FormatDecimal)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNIK.Text = "" Or txtGolongan.Text = "" Then
            MessageBox.Show("Harap lengkapi data header dulu",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        GridViewDetail.AddNewRow()
        GridViewDetail.OptionsNavigation.AutoFocusNewRow = True
        GridViewDetail.RefreshData()
        'HitungTotalAmount()
    End Sub

    Private Sub CDepartureDate_EditValueChanged(sender As Object, e As EventArgs) Handles CDepartureDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        departureDate_ = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate"))
        arrivalDate_ = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate"))
        If arrivalDate_ = Nothing Or departureDate_ > arrivalDate_ Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate", departureDate_)
        End If

        For i As Integer = 0 To GridViewDetail.RowCount - 1
            Dim _date As Date
            _date = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
            If _date <> Nothing And (departureDate_ > _date Or departureDate_ = Nothing) Then
                departureDate_ = GridViewDetail.GetRowCellValue(i, "DepartureDate")
                'days = DateDiff(DateInterval.Day, departureDate_, arrivalDate_) + 1
            End If
            _date = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
            If _date <> Nothing And (arrivalDate_ < _date Or arrivalDate_ = Nothing) Then
                arrivalDate_ = GridViewDetail.GetRowCellValue(i, "ArrivalDate")
                'days = DateDiff(DateInterval.Day, departureDate_, arrivalDate_) + 1
            End If
        Next

        CheckFirstTravel()
        HitungTotalAmount()
    End Sub

    Private Sub CArrivalDate_EditValueChanged(sender As Object, e As EventArgs) Handles CArrivalDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        'HitungTotalAmount()
    End Sub

    Private Sub CNegara_EditValueChanged(sender As Object, e As EventArgs) Handles CNegara.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim negara As String
        Dim visa As String
        negara = GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara")
        visa = ObjTravelRequestDetail.GetVisa(txtNIK.Text, negara)
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Visa", visa)
    End Sub

    Private Sub ListItemsGolongan()
        Dim dt = New DataTable
        dt = ObjTravelRequest.GetListGolongan()
        Dim itemsCollection As ComboBoxItemCollection = txtGolongan.Properties.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(0))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub ListItemsNegara()
        Dim dt = New DataTable
        dt = ObjTravelRequest.GetListNegara(txtTravelType.Text)
        Dim itemsCollection As ComboBoxItemCollection = CNegara.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(0))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub CreateDataTable()
        dtCost.Columns.Add("NoRequest", GetType(String))
        dtCost.Columns.Add("CostType", GetType(String))
        dtCost.Columns.Add("Description", GetType(String))
        dtCost.Columns.Add("Days", GetType(Integer))
        dtCost.Columns.Add("AdvanceIDR", GetType(Double))
        dtCost.Columns.Add("AdvanceUSD", GetType(Double))
        dtCost.Columns.Add("AdvanceYEN", GetType(Double))
    End Sub

    Private Sub CheckFirstTravel()
        If String.IsNullOrEmpty(txtNoRequest.Text) Then
            Dim firstTravel As Integer
            If firstTravel = 0 And departureDate_ <> Nothing Then
                firstTravel = ObjTravelRequest.GetFirstTravel(txtNIK.Text, txtTravelType.Text, departureDate_.Year.ToString())
            Else
                firstTravel = 1
            End If

            If firstTravel <> 1 Then
                Dim dt As DataTable = ObjTravelRequest.GetPocketAllowance(txtTravelType.Text, IIf(String.IsNullOrEmpty(txtGolongan.Text), 0, txtGolongan.Text))
                If dt.Rows.Count > 0 Then
                    amountFirstTravel = dt.Rows(0).Item("FirstTravel")
                End If
                firstravel = True
                descFirstTravel = "1YR TAVEL (" + departureDate_.Year.ToString() + ")"
            End If
        Else
            firstravel = True
            If row_ IsNot Nothing Then
                amountFirstTravel = row_("AdvanceIDR")
                descFirstTravel = row_("Description")
            End If
        End If
    End Sub

    Private Sub GridDetail_DoubleClick(sender As Object, e As EventArgs) Handles GridDetail.DoubleClick
        Try
            Dim Dep = String.Empty
            Dim NIK = String.Empty
            Dim row As Integer
            Dim selectedRows() As Integer = GridViewDetail.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    row = rowHandle
                    NoRequest = GridViewDetail.GetRowCellValue(rowHandle, "NoRequest")
                    NIK = GridViewDetail.GetRowCellValue(rowHandle, "NIK")
                End If
            Next rowHandle

            If GridViewDetail.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         NIK,
                         row)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0, Optional ByVal IsNew As Boolean = True)
        If ff_Direct IsNot Nothing AndAlso ff_Direct.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Direct.Close()
        End If
        ff_Direct = New FrmTravelTicketDetail(ls_Code, ls_Code2, Me, li_Row, GridDetail)
        ff_Direct.StartPosition = FormStartPosition.CenterScreen
        ff_Direct.ShowDialog()
    End Sub

    Private Sub HitungTotalAmount()

        If txtTravelType.Text = "DN" Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara", "INDONESIA")
        End If

        Dim dt = New DataTable
        Dim amountIDR As Double
        Dim amountUSD As Double
        Dim amountYEN As Double

        If txtTravelType.Text <> "" And txtGolongan.Text <> "" Then
            dt = ObjTravelRequest.GetPocketAllowance(txtTravelType.Text, txtGolongan.Text)
            If dt.Rows.Count > 0 Then
                amountIDR = dt.Rows(0).Item(1).ToString()
                amountUSD = dt.Rows(0).Item(2).ToString()
                amountYEN = dt.Rows(0).Item(3).ToString()
            End If
        End If

        Dim advanceIDR As Double = IIf(String.IsNullOrEmpty(txtAdvanceIDR.Text), 0, txtAdvanceIDR.Text)
        Dim advanceUSD As Double = IIf(String.IsNullOrEmpty(txtAdvanceUSD.Text), 0, txtAdvanceUSD.Text)
        Dim advanceYEN As Double = IIf(String.IsNullOrEmpty(txtAdvanceYEN.Text), 0, txtAdvanceYEN.Text)

        dtCost.Clear()
        days = DateDiff(DateInterval.Day, departureDate_, arrivalDate_) + 1
        If firstravel Then
            dtCost.Rows.Add(txtNoRequest.Text, "FT", descFirstTravel, days, amountFirstTravel, 0, 0)
        End If
        dtCost.Rows.Add(txtNoRequest.Text, "PA", "POCKET ALLOWANCE", days, amountIDR * days, amountUSD * days, amountYEN * days)
        dtCost.Rows.Add(txtNoRequest.Text, "AT", "ADVANCE", days, advanceIDR, advanceUSD, advanceYEN)
        GridAdvance.DataSource = dtCost

    End Sub

End Class
