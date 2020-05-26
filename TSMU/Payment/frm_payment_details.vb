Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class frm_payment_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjPaymentHeader As New payment_header_models
    Dim ObjPaymentDetail As New payment_detail_models
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"

    Dim ObjFP As New Cls_FP
    Dim ObjPayment As New Cls_Payment
    Dim ObjCM As New Cls_cmdm

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
    Private Sub frm_payment_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjPaymentHeader.id = fs_Code
                ObjPaymentHeader.GetPaymentByVoucherNo()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Payment " & fs_Code
            Else
                Me.Text = "Payment New Data"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_payment"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjPaymentHeader
                    _txtVoucher.Text = .vrno
                    _TxtVendorName.Text = .VendorName
                    _TxtVendorID.Text = .VendID
                    _TxtTotal.Text = Format(.Tot_DPP + .Tot_PPN, "##,0")
                    _TxtAttentionTo.Text = .penerima
                    _TxtBankID.Text = .BankID
                    _TxtBankName.Text = .BankName
                    _TxtBiaya.EditValue = Format(.Biaya_Transfer, "##,0")
                    _TxtToBank.Text = .bankrek
                    _TxtCM.Text = Format(.CM_DM, "##,0")
                    _TxtCurrency.Text = .CuryID
                    _TxtDebit.Text = Format((.Total_DPP_PPN) - .PPh - .Biaya_Transfer - .CM_DM - .cmdm_manual, "##,0")
                    _TxtNoRek.Text = .norek
                    _TxtDpp.Text = Format(.Tot_DPP, "##,0")
                    _TxtTgl.Text = .tgl
                    _TxtTMV.Text = ""
                    _TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")
                    _TxtPPH.Text = Format(.PPh, "##,0")
                    _TxtPPN.Text = Format(.Tot_PPN, "##,0")
                    _txtCMDMmanual.Text = Format(.cmdm_manual, "##,0")
                    _txtKetCMDMmanual.Text = .cmdm_manual_ket
                    _txtnamasupllier.Text = .detsupplier
                End With
            Else
                _txtVoucher.Text = ""
                _TxtVendorName.Text = ""
                _TxtVendorID.Text = ""
                _TxtTotal.Text = "0"
                _TxtAttentionTo.Text = ""
                _TxtBankID.Text = "11240"
                _TxtBankName.Text = "MIZUHO IDR"
                _TxtBiaya.EditValue = "2500"
                _TxtToBank.Text = ""
                _TxtCM.Text = "0"
                _TxtCurrency.Text = "IDR"
                _TxtDebit.Text = "0"
                _TxtNoRek.Text = ""
                _TxtDpp.Text = "0"
                _TxtTgl.EditValue = DateTime.Today
                _TxtTMV.Text = "0"
                _TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")
                _TxtPPH.Text = "0"
                _TxtPPN.Text = "0"
                _TxtPerpost.Focus()
                _txtCMDMmanual.Text = "0"
                _txtKetCMDMmanual.Text = ""
                _txtnamasupllier.Text = ""

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        LoadGridDetail()
        Call LoadTxtBox()
    End Sub

    Public Sub LoadGridDetailNew()
        Try
            Dim dtGrid As New DataTable
            dtGrid = ObjPayment.getalldataap2()

            If dtGrid.Rows.Count > 0 Then
                GridInvoice.DataSource = dtGrid
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            Dim dtGrid As New DataTable
            ObjPaymentDetail.vrno = _txtVoucher.Text
            dtGrid = ObjPaymentDetail.GetPaymentByVoucherNo()
            GridInvoice.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If
            If lb_Validated Then
                With ObjPaymentHeader
                    .BankID = _TxtBankID.Text
                    .BankName = _TxtBankName.Text
                    .bankrek = _TxtToBank.Text
                    .Biaya_Transfer = _TxtBiaya.Text
                    .cek1 = "1"
                    .cek2 = "0"
                    .cek3 = "0"
                    .cek4 = "0"
                    .CM_DM = _TxtCM.Text
                    .CuryID = _TxtCurrency.Text
                    .Descr = ""
                    .detsupplier = _txtnamasupllier.Text
                    .norek = _TxtNoRek.Text
                    .penerima = _TxtAttentionTo.Text
                    .PPh = _TxtPPH.Text
                    .prosespay = "0"
                    .tgl = _TxtTgl.EditValue
                    .Total_DPP_PPN = _TxtTotal.Text
                    .Tot_DPP = _TxtDpp.Text
                    .Tot_PPN = _TxtPPN.Text
                    .uploaded = "0"
                    .VendID = _TxtVendorID.Text
                    ''.VendorName2 = _TxtVendorName.Text
                    .vrno = _txtVoucher.Text
                    .cmdm_manual = _txtCMDMmanual.Text
                    .cmdm_manual_ket = _txtKetCMDMmanual.Text
                    .VendorName = _TxtVendorName.Text
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
            ObjPaymentHeader.ObjPaymentDetails.Clear()
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    Dim ObjDetails As New payment_detail_models
                    With ObjDetails
                        .vrno = _txtVoucher.Text.TrimEnd
                        .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                        .Tgl_Invoice = DateTime.Parse(GridView1.GetRowCellValue(i, "InvcDate").ToString())
                        .Jml_Invoice = GridView1.GetRowCellValue(i, "Amount")
                        .CuryID = GridView1.GetRowCellValue(i, "CuryId")
                        .Ppn = GridView1.GetRowCellValue(i, "Ppn")
                        .Dpp = GridView1.GetRowCellValue(i, "DPP")
                        .Pph = GridView1.GetRowCellValue(i, "PPH")
                        .No_Faktur = GridView1.GetRowCellValue(i, "fp").ToString().TrimEnd
                        .cek1 = True
                    End With
                    ObjPaymentHeader.ObjPaymentDetails.Add(ObjDetails)
                End If
            Next
            If isUpdate = False Then
                ObjPaymentHeader.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjPaymentHeader.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjPaymentHeader.GetDataGrid()
            ''IsClosed = True
            ''Me.Hide()

            LoadGridDetail()
            ''_txtVoucher.Text = ""
            _TxtVendorName.Text = ""
            _TxtVendorID.Text = ""
            _TxtTotal.Text = "0"
            _TxtAttentionTo.Text = ""
            _TxtBankID.Text = "11240"
            _TxtBankName.Text = "MIZUHO IDR"
            _TxtBiaya.EditValue = "2500"
            _TxtToBank.Text = ""
            _TxtCM.Text = "0"
            _TxtCurrency.Text = "IDR"
            _TxtDebit.Text = "0"
            _TxtNoRek.Text = ""
            _TxtDpp.Text = "0"
            ''_TxtTgl.EditValue = DateTime.Today
            _TxtTMV.Text = "0"
            ''_TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-12")
            _TxtPPH.Text = "0"
            _TxtPPN.Text = "0"
            _TxtPerpost.Focus()
            _txtCMDMmanual.Text = "0"
            _txtKetCMDMmanual.Text = ""
            _txtnamasupllier.Text = ""



            ''GridView1.ClearDocument()
            ''GridView1.DataSource.nothing()
            ''GridView1.RefreshData()

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub _TxtVendorID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _TxtVendorID.ButtonClick,
                                                                                                _TxtBankID.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            ObjPaymentDetail.CuryID = _TxtCurrency.Text
            If sender.Name = _TxtVendorID.Name Then
                dtSearch = ObjPaymentDetail.GetVendor
                ls_OldKode = _TxtVendorID.Text.Trim
                ls_Judul = "Vendor"
            ElseIf sender.Name = _TxtBankID.Name Then
                dtSearch = ObjPaymentDetail.GetBank
                ls_OldKode = _TxtBankID.Text.Trim
                ls_Judul = "Bank"
            Else
                dtSearch = ObjPaymentDetail.GetDataGridCM_New(_TxtVendorID.Text)
                ls_OldKode = _TxtCM.Text.Trim
                ls_Judul = "CM/DM"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            Dim Value4 As String = ""
            Dim Value5 As String = ""
            Dim Value6 As String = ""
            ''Dim value7 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _TxtVendorID.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    Value4 = lF_SearchData.Values.Item(3).ToString.Trim
                    Value5 = lF_SearchData.Values.Item(4).ToString.Trim
                    Value6 = lF_SearchData.Values.Item(5).ToString.Trim
                    ''alue6 = lF_SearchData.Values.Item(6).ToString.Trim
                    _TxtVendorID.Text = Value1
                    _TxtVendorName.Text = Value2
                    _TxtToBank.Text = Value3
                    _TxtNoRek.Text = Value4
                    _TxtAttentionTo.Text = Value5
                    _txtnamasupllier.Text = Value6


                    Dim dtGrid As New DataTable
                    dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID(Value1.TrimEnd)

                    If dtGrid.Rows.Count > 0 Then
                        GridInvoice.DataSource = dtGrid
                        GridCellFormat(GridView1)
                    End If
                ElseIf sender.Name = _TxtBankID.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    _TxtBankID.Text = Value1
                    _TxtBankName.Text = Value2
                    _TxtCurrency.Text = Value3
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _TxtCM_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _TxtCM.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjPaymentDetail.GetDataGridCM_New(_TxtVendorID.Text)
            ls_OldKode = _TxtCM.Text.Trim
            ls_Judul = "CM/DM"


            Dim f As frm_lookup_cmdm
            f = New frm_lookup_cmdm(dtSearch)
            f.Text = "Select Data " & ls_Judul
            f.StartPosition = FormStartPosition.CenterScreen
            f.ShowDialog()
            If f.Total > 0 Then
                _TxtCM.Text = Format(f.Total, gs_FormatBulat)
            End If


            'ObjPaymentHeader.ObjBatch.Clear()
            'For i As Integer = 0 To f.ListNoInvoice.Count - 1
            '    Dim Batch As New batch
            '    With Batch
            '        .InvNO = f.ListNoInvoice.Item(i).ToString()
            '    End With
            '    ObjPaymentHeader.ObjBatch.Add(Batch)
            'Next

            ObjPaymentHeader.ObjBatch.Clear()
            For Each item In f.ListNoInvoice
                Dim Batch As New batch
                With Batch
                    .BatchNO = item.BatchNO.ToString()
                End With
                ObjPaymentHeader.ObjBatch.Add(Batch)
            Next
            f.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim TotPPH As Double
    Dim TotAmount As Double
    Dim TotDpp As Double
    Dim TotPPn As Double
    Private Sub GetTot()
        TotPPH = 0
        TotAmount = 0
        TotDpp = 0
        TotPPn = 0
        ''GrandTotal = 0
        Dim cek As Boolean
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    TotPPH = TotPPH + CDbl(GridView1.GetRowCellValue(i, "PPH"))
                    'TotAmount = TotAmount + CDbl(GridView1.GetRowCellValue(i, "Amount"))
                    'CDbl(GridView1.GetRowCellValue(i, "DPP")) + CDbl(GridView1.GetRowCellValue(i, "Ppn"))
                    TotDpp = TotDpp + CDbl(GridView1.GetRowCellValue(i, "DPP"))
                    TotPPn = TotPPn + CDbl(GridView1.GetRowCellValue(i, "Ppn"))
                    TotAmount = TotDpp + TotPPn
                End If

            Next

            If TotPPn = 0 Then
                _TxtPPN.Text = "0"
            Else
                _TxtPPN.Text = Format(TotPPn, gs_FormatBulat)
            End If

            If TotDpp = 0 Then
                _TxtDpp.Text = "0"
            Else
                _TxtDpp.Text = Format(TotDpp, gs_FormatBulat)
            End If

            If TotAmount = 0 Then
                _TxtTotal.Text = "0"
            Else

                _TxtTotal.Text = Format(TotAmount, gs_FormatBulat)
            End If
            If TotPPH = 0 Then
                _TxtPPH.Text = "0"
            Else

                _TxtPPH.Text = Format(TotPPH, gs_FormatBulat)
            End If
            Dim debit As Double = TotAmount - TotPPH - _TxtCM.Text - _txtCMDMmanual.Text - _TxtBiaya.Text
            _TxtDebit.Text = Format(debit, gs_FormatBulat)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If e.Column.FieldName = "Check" Then
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
                    GetTot()
                Else
                    GetTot()

                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        GridInvoice.FocusedView.PostEditor()
    End Sub

    Private Sub _TxtPerpost_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtPerpost.EditValueChanged
        Try
            If fs_Code <> "" Then
            Else
                ObjPaymentHeader.PerPost = _TxtPerpost.Text
                _txtVoucher.Text = ObjPaymentHeader.VoucherNo
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub _TxtBankID_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtBankID.EditValueChanged

    End Sub

    Private Sub _txtVoucher_EditValueChanged(sender As Object, e As EventArgs) Handles _txtVoucher.EditValueChanged

    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        _TxtBankID.DoValidate()
        _TxtTgl.DoValidate()
        _txtVoucher.DoValidate()
        _TxtTotal.DoValidate()
        _TxtCurrency.DoValidate()
        _TxtVendorID.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(_TxtBankID) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtTgl) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_txtVoucher) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtTotal) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtCurrency) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtVendorID) Then


            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub _TxtVendorID_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtVendorID.EditValueChanged

    End Sub

    Private Sub _TxtPerpost_LostFocus(sender As Object, e As EventArgs) Handles _TxtPerpost.LostFocus
        Try
            If fs_Code <> "" Then
            Else
                ObjPaymentHeader.PerPost = _TxtPerpost.Text
                _txtVoucher.Text = ObjPaymentHeader.VoucherNo
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
