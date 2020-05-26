Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class FrmTravelTicketDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim ObjTravelTicket As New TravelTicketModel
    Dim ObjTravelTicketDetail As New TravelTicketDetailModel

    Dim GridDtl As GridControl
    Dim dtGrid = New DataTable
    Dim row As Integer

    Public NoVoucher As String

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
        row = li_GridRow
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Private Sub FrmTravelTicketDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, True)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjTravelTicket.NoVoucher = fs_Code
                ObjTravelTicket.GetTravelTicketByID()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Travel Ticket Detail" + ": " + fs_Code
            Else
                Me.Text = "Travel Ticket Detail"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmTravelTicket"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                dtGrid = New DataTable
                ObjTravelTicket.NoVoucher = fs_Code
                dtGrid = ObjTravelTicket.GetTravelTicketDetail()

                GridTicket.DataSource = dtGrid
                GridCellFormat(GridViewTicket)
            Else
                dtGrid = New DataTable
                dtGrid = ObjTravelTicket.GetTravelTicketDetail()

                GridTicket.DataSource = dtGrid
                GridCellFormat(GridViewTicket)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjTravelTicket
                    txtNoVoucher.Text = .NoVoucher
                    dtTanggal.EditValue = .Tanggal
                    txtVendor.Text = .VendorID
                    txtNoInvoice.Text = .NoInvoice
                    txtCuryID.Text = .CuryID
                    txtTotAmount.Text = .TotAmount
                End With
            Else
                txtNoVoucher.Text = ""
                dtTanggal.EditValue = DateTime.Today
                txtVendor.Text = ""
                txtNoInvoice.Text = ""
                txtCuryID.Text = "IDR"
                txtTotAmount.Text = Format(0, gs_FormatDecimal)
            End If
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

            If txtNoInvoice.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If

            If lb_Validated Then
                If isUpdate = False Then
                    txtNoVoucher.Text = ObjTravelTicket.TravelAutoNoVoucher
                End If

                With ObjTravelTicket
                    .NoVoucher = txtNoVoucher.Text
                    .Tanggal = dtTanggal.EditValue
                    .VendorID = txtVendor.Text.Trim.ToUpper
                    .NoInvoice = txtNoInvoice.Text.Trim.ToUpper
                    .CuryID = txtCuryID.Text.Trim.ToUpper
                    .TotAmount = txtTotAmount.Text
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
            ObjTravelTicket.ObjTravelTicketDetail.Clear()

            Dim filterString As String = "[CheckList] = True"
            GridViewTicket.Columns("CheckList").FilterInfo = New ColumnFilterInfo(filterString)

            For i As Integer = 0 To GridViewTicket.RowCount - 1
                ObjTravelTicketDetail = New TravelTicketDetailModel
                With ObjTravelTicketDetail
                    .NoVoucher = txtNoVoucher.Text
                    .NoRequest = GridViewTicket.GetRowCellValue(i, "NoRequest").ToString().TrimEnd
                    .Seq = Convert.ToInt16(GridViewTicket.GetRowCellValue(i, "Seq"))
                    .TicketNumber = GridViewTicket.GetRowCellValue(i, "TicketNumber").ToString().TrimEnd
                    .CuryID = GridViewTicket.GetRowCellValue(i, "CuryID").ToString().TrimEnd
                    .Amount = IIf(GridViewTicket.GetRowCellValue(i, "Amount") Is DBNull.Value, 0, GridViewTicket.GetRowCellValue(i, "Amount"))
                End With
                ObjTravelTicket.ObjTravelTicketDetail.Add(ObjTravelTicketDetail)
            Next
            GridViewTicket.Columns("CheckList").ClearFilter()

            If isUpdate = False Then
                ObjTravelTicket.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjTravelTicket.NoVoucher = txtNoVoucher.Text
                ObjTravelTicket.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjTravelTicket.GetTravelTicket()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtTotAmount_EditValueChanged(sender As Object, e As EventArgs) Handles txtTotAmount.EditValueChanged
        If String.IsNullOrEmpty(txtTotAmount.Text) Then
            txtTotAmount.Text = 0
        End If
        txtTotAmount.Text = Format(Convert.ToDecimal(txtTotAmount.Text), gs_FormatDecimal)
    End Sub

    Private Sub CCheck_EditValueChanged(sender As Object, e As EventArgs) Handles CCheck.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        'If GridViewTicket.GetRowCellValue(GridViewTicket.FocusedRowHandle, "CheckList") = False Then
        '    GridViewTicket.SetRowCellValue(GridViewTicket.FocusedRowHandle, "Amount", 0)
        'End If
    End Sub

    Private Sub txtVendor_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtVendor.ButtonClick
        Try
            ObjTravelTicket = New TravelTicketModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelTicket.GetTravelVendor
            ls_OldKode = txtVendor.Text
            ls_Judul = "Vendor"

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
                txtVendor.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub HitungTotal()
        txtTotal.Text = Format(0, gs_FormatDecimal)
    End Sub

End Class
