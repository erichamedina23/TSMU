Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class frm_payment_aprrove_details
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
    Dim IsNew As Boolean
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl, ByVal _IsNew As Boolean)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
            IsNew = _IsNew
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub frm_payment_aprrove_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNew Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, True, True, True)
        Else
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, True, True, False)
        End If
        Call InitialSetForm()
    End Sub

    Public Overridable Sub Proc_DeleteData()
        Try
            Dim result As DialogResult = XtraMessageBox.Show("Approve Voucher " & "'" & _txtVoucher.Text & "'" & " ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                If gh_Common.Level = 2 Then
                    ObjPaymentHeader.UpdateCek(2)
                ElseIf gh_Common.Level = 3 Then
                    ObjPaymentHeader.UpdateCek(3)
                ElseIf gh_Common.Level = 4 Then
                    ObjPaymentHeader.UpdateCek(4)
                End If
            Else
                If gh_Common.Level = 2 Then
                    ObjPaymentHeader.UpdateUnCek(2)
                    ObjPaymentHeader.ObjPaymentDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "Check") = False Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcId()
                            End With
                        End If
                    Next
                End If
            End If
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_next.PerformClick()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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
                Me.Text = "Approval " & fs_Code
            Else
                Me.Text = "Approval New Data"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_payment_approve"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjPaymentHeader
                    _TxtPerpost.Text = .id
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
                    Dim debit As Double = .Tot_DPP + .Tot_PPN - .PPh - .Biaya_Transfer - .CM_DM
                    _TxtDebit.Text = Format(debit, "##,0")
                    _TxtNoRek.Text = .norek
                    _TxtDpp.Text = Format(.Tot_DPP, "##,0")
                    _TxtTgl.Text = Format(.tgl, "dd-MM-yyyy")
                    _TxtTMV.Text = ""
                    _TxtPPH.Text = Format(.PPh, "##,0")
                    _TxtPPN.Text = Format(.Tot_PPN, "##,0")
                End With
            Else
                _txtVoucher.Text = ""
                _TxtVendorName.Text = ""
                _TxtVendorID.Text = ""
                _TxtTotal.Text = "0"
                _TxtAttentionTo.Text = ""
                _TxtBankID.Text = ""
                _TxtBankName.Text = ""
                _TxtBiaya.EditValue = "2,500"
                _TxtToBank.Text = ""
                _TxtCM.Text = "0"
                _TxtCurrency.Text = ""
                _TxtDebit.Text = "0"
                _TxtNoRek.Text = ""
                _TxtDpp.Text = "0"
                _TxtTgl.EditValue = DateTime.Today
                _TxtTMV.Text = "0"
                _TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-12")
                _TxtPPH.Text = "0"
                _TxtPPN.Text = "0"
                _TxtPerpost.Focus()
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
            dtGrid = ObjPaymentDetail.GetPaymentByVoucherNoApprove()
            GridInvoice.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()
        'Try

        '    If isUpdate = False Then
        '        ObjPaymentHeader.InsertData()
        '        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '    Else
        '    End If
        '    GridDtl.DataSource = ObjPaymentHeader.GetDataGrid()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        '    'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        'End Try

        Try
            Dim result As DialogResult = XtraMessageBox.Show("Save Details Voucher " & "'" & _txtVoucher.Text & "'" & " ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                '    If gh_Common.Level = 2 Then
                '        ObjPaymentHeader.UpdateCek(2)
                '    ElseIf gh_Common.Level = 3 Then
                '        ObjPaymentHeader.UpdateCek(3)
                '    ElseIf gh_Common.Level = 4 Then
                '        ObjPaymentHeader.UpdateUnCek(4)
                '    End If
                'Else
                If gh_Common.Level = 4 Then
                    ObjPaymentHeader.UpdateUnCek(1)
                    ObjPaymentHeader.UpdateUnCek(2)
                    ObjPaymentHeader.UpdateUnCek(3)
                    ObjPaymentHeader.UpdateUnCek(4)
                    ''ObjPaymentHeader.ObjPaymentDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "cek4") = False Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcIdDir0()
                            End With
                        ElseIf GridView1.GetRowCellValue(i, "cek4") = True Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcIdDir1()
                            End With
                        End If
                    Next
                End If
            End If
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            Me.Close()
            ''tsBtn_next.PerformClick()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        End Try

        'Try
        '    ObjPaymentHeader.ObjPaymentDetails.Clear()
        '    For i As Integer = 0 To GridView1.RowCount - 1
        '        If GridView1.GetRowCellValue(i, "cek4") = True Then
        '            Dim ObjDetails As New payment_detail_models
        '            With ObjDetails
        '                .cek1 = True
        '                .cek4 = True
        '            End With
        '            ObjPaymentHeader.ObjPaymentDetails.Add(ObjDetails)
        '        End If
        '    Next
        '    If isUpdate = True Then
        '        ''ObjPaymentHeader.InsertDataDir()
        '        ''Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '        ''Else
        '        ObjPaymentHeader.UpdateData()
        '        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '    End If
        '    ''GridDtl.DataSource = ObjPaymentHeader.GetDataGrid()
        '    ''IsClosed = True
        '    '' Me.Hide()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        '    'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        'End Try

    End Sub

    Public Overrides Sub Proc_Approve()
        Try
            Dim result As DialogResult = XtraMessageBox.Show("Approve Voucher " & "'" & _txtVoucher.Text & "'" & " ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                If gh_Common.Level = 2 Then
                    ObjPaymentHeader.UpdateCek(2)
                ElseIf gh_Common.Level = 3 Then
                    ObjPaymentHeader.UpdateCek(3)
                ElseIf gh_Common.Level = 4 Then
                    ''ObjPaymentHeader.UpdateCek(4)
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "cek4") = False Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcIdDir0()
                            End With
                        ElseIf GridView1.GetRowCellValue(i, "cek4") = True Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcIdDir1()
                            End With
                        End If
                    Next
                End If
            Else
                If gh_Common.Level = 2 Then
                    ObjPaymentHeader.UpdateUnCek(2)
                    ObjPaymentHeader.ObjPaymentDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "Check") = False Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcId()
                            End With
                        End If
                    Next
                End If
            End If
            Timer1.Enabled = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            ''RefreshDataApproval()
            'Me.Close()
            Dim BankID As String
            GridDtl.DataSource = ObjPaymentHeader.GetDataGridApproveByBank(gh_Common.Level, BankID)
            IsClosed = True
            Me.Hide()
            'LoadGridRefresh()
            'frm_payment_approve.Proc_Refresh()
            'tsBtn_next.PerformClick()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        End Try
    End Sub

    Private Sub RefreshDataApproval(BankID As String)
        '' Call RefreshDetailApproval("")
        ObjPaymentHeader.GetDataGridApproveByBank(gh_Common.Level, BankID)
    End Sub

    'Private Sub RefreshDataApproval1()
    '    Call RefreshDataApproval(bankid)
    'End Sub


    Private Sub RefreshDetailApproval(BankID As String)
        Dim dtGrid As New DataTable
        Try
            dtGrid = ObjPaymentHeader.GetDataGridApproveByBank(gh_Common.Level, BankID)
            frm_payment_approve.Grid.DataSource = dtGrid

            'If frm_payment_approve.GridView1.RowCount > 0 Then
            '    With frm_payment_approve.GridView1
            '        .Columns(0).Visible = False
            '        .BestFitColumns()
            '        '.FixedLineWidth = 1
            '        '.Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '        '.OptionsView.ColumnAutoWidth = True
            '    End With
            '    GridCellFormat(frm_payment_approve.GridView1)
            '    If gh_Common.Level = 1 Then
            '        frm_payment_approve.GridView1.OptionsBehavior.Editable = False
            '    ElseIf gh_Common.Level = 2 Then
            '        frm_payment_approve.GridView1.OptionsBehavior.Editable = True
            '        For i As Integer = 0 To frm_payment_approve.GridView1.Columns.Count - 1
            '            If frm_payment_approve.GridView1.Columns(i).VisibleIndex <> 7 Then
            '                frm_payment_approve.GridView1.Columns(i).OptionsColumn.AllowEdit = False
            '            Else
            '                frm_payment_approve.GridView1.Columns(i).OptionsColumn.AllowEdit = True
            '            End If
            '        Next

            '        'GridView1.Columns(15).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(16).OptionsColumn.AllowEdit = True
            '        'GridView1.Columns(17).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(18).OptionsColumn.AllowEdit = False
            '    ElseIf gh_Common.Level = 3 Then
            '        frm_payment_approve.GridView1.OptionsBehavior.Editable = True
            '        For i As Integer = 0 To GridView1.Columns.Count - 1
            '            If frm_payment_approve.GridView1.Columns(i).VisibleIndex <> 8 Then
            '                frm_payment_approve.GridView1.Columns(i).OptionsColumn.AllowEdit = False
            '            Else
            '                frm_payment_approve.GridView1.Columns(i).OptionsColumn.AllowEdit = True
            '            End If
            '        Next
            '    ElseIf gh_Common.Level = 4 Then

            '        frm_payment_approve.GridView1.OptionsBehavior.Editable = True
            '        For i As Integer = 0 To frm_payment_approve.GridView1.Columns.Count - 1

            '            'If GridView1.GetRowCellValue(i, GridView1.Columns("CheckDetail")) = False Then
            '            '    GridView1.Columns(i).AppearanceCell.BackColor = Color.Honeydew
            '            '    GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
            '            '    'ElseIf GridView1.GetRowCellValue(i, GridView1.Columns("CheckDetail")) = True Then
            '            '    '    GridView1.Columns(i).AppearanceCell.BackColor = Color.White
            '            '    '    GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
            '            'End If

            '            If frm_payment_approve.GridView1.Columns(i).VisibleIndex <> 10 Then
            '                frm_payment_approve.GridView1.Columns(i).OptionsColumn.AllowEdit = False
            '                ''GridView1.Columns(i).AppearanceCell.BackColor = Color.Honeydew
            '                ''GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
            '            Else
            '                frm_payment_approve.GridView1.Columns(i).OptionsColumn.AllowEdit = True
            '            End If

            '        Next
            '        'GridView1.OptionsBehavior.Editable = True
            '        'GridView1.Columns(15).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(16).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(17).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(18).OptionsColumn.AllowEdit = True
            '    Else
            '        frm_payment_approve.GridView1.OptionsBehavior.Editable = False
            '    End If

            'End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub



    Private Sub LoadGridRefresh(BankID As String)
        Dim dtGrid As DataTable

        Try
            dtGrid = ObjPaymentHeader.GetDataGridApproveByBank(gh_Common.Level, BankID)
            ''frm_payment_approve.Grid.DataSource = dtGrid

            'If GridView1.RowCount > 0 Then
            '    With GridView1
            '        .Columns(0).Visible = False
            '        .BestFitColumns()
            '        '.FixedLineWidth = 1
            '        '.Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '        '.OptionsView.ColumnAutoWidth = True
            '    End With
            '    GridCellFormat(GridView1)
            '    If gh_Common.Level = 1 Then
            '        GridView1.OptionsBehavior.Editable = False
            '    ElseIf gh_Common.Level = 2 Then
            '        GridView1.OptionsBehavior.Editable = True
            '        For i As Integer = 0 To GridView1.Columns.Count - 1
            '            If GridView1.Columns(i).VisibleIndex <> 7 Then
            '                GridView1.Columns(i).OptionsColumn.AllowEdit = False
            '            Else
            '                GridView1.Columns(i).OptionsColumn.AllowEdit = True
            '            End If
            '        Next

            '        'GridView1.Columns(15).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(16).OptionsColumn.AllowEdit = True
            '        'GridView1.Columns(17).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(18).OptionsColumn.AllowEdit = False
            '    ElseIf gh_Common.Level = 3 Then
            '        GridView1.OptionsBehavior.Editable = True
            '        For i As Integer = 0 To GridView1.Columns.Count - 1
            '            If GridView1.Columns(i).VisibleIndex <> 8 Then
            '                GridView1.Columns(i).OptionsColumn.AllowEdit = False
            '            Else
            '                GridView1.Columns(i).OptionsColumn.AllowEdit = True
            '            End If
            '        Next
            '    ElseIf gh_Common.Level = 4 Then

            '        GridView1.OptionsBehavior.Editable = True
            '        For i As Integer = 0 To GridView1.Columns.Count - 1

            '            'If GridView1.GetRowCellValue(i, GridView1.Columns("CheckDetail")) = False Then
            '            '    GridView1.Columns(i).AppearanceCell.BackColor = Color.Honeydew
            '            '    GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
            '            '    'ElseIf GridView1.GetRowCellValue(i, GridView1.Columns("CheckDetail")) = True Then
            '            '    '    GridView1.Columns(i).AppearanceCell.BackColor = Color.White
            '            '    '    GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
            '            'End If

            '            If GridView1.Columns(i).VisibleIndex <> 10 Then
            '                GridView1.Columns(i).OptionsColumn.AllowEdit = False
            '                ''GridView1.Columns(i).AppearanceCell.BackColor = Color.Honeydew
            '                ''GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
            '            Else
            '                GridView1.Columns(i).OptionsColumn.AllowEdit = True
            '            End If

            '        Next
            '        'GridView1.OptionsBehavior.Editable = True
            '        'GridView1.Columns(15).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(16).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(17).OptionsColumn.AllowEdit = False
            '        'GridView1.Columns(18).OptionsColumn.AllowEdit = True
            '    Else
            '        GridView1.OptionsBehavior.Editable = False
            '    End If

            'End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        GridInvoice.FocusedView.PostEditor()
    End Sub
    Private Sub RepositoryItemCheckEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        GridInvoice.FocusedView.PostEditor()
    End Sub


    Private Sub BtnScan1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnScan1.ButtonClick
        Try
            'If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
            Dim NoFaktur As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fp")
            Dim NoFakturNew As String = Microsoft.VisualBasic.Mid(Replace(Replace(NoFaktur.TrimEnd, ".", ""), "-", ""), 4, 14)
            If fs_Code <> "" Then
                Dim f As Frm_ScanFP = New Frm_ScanFP(NoFakturNew.TrimEnd, False)
                With f
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With
            Else
                Dim f As Frm_ScanFP = New Frm_ScanFP("", True)
                With f
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With
            End If

            ''Else
            ''XtraMessageBox.Show("Data belum di checklist !")
            ''End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnPPH1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnPPH1.ButtonClick
        ''MsgBox("coba")
        Dim FP As String = String.Empty
        Dim Voucher As String = String.Empty
        Dim InvcNbr As String = String.Empty
        Dim DPP As String = String.Empty
        Dim NoFaktur As String = String.Empty
        Try
            ''If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoFaktur = GridView1.GetRowCellValue(rowHandle, "fp")
                    InvcNbr = GridView1.GetRowCellValue(rowHandle, "InvcNbr")
                    DPP = GridView1.GetRowCellValue(rowHandle, "DPP")
                End If
            Next rowHandle

            If fs_Code <> "" Then
                Dim f As frm_lookup_pph_approve = New frm_lookup_pph_approve(FP, Voucher, InvcNbr, DPP, NoFaktur, False)
                With f
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With
            Else
                Dim f As frm_lookup_pph_approve = New frm_lookup_pph_approve(FP, Voucher, InvcNbr, DPP, NoFaktur, True)
                With f
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Pph", f.PPHDetails)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "NBP", f.NoBuktiPotong)
                ''_TxtNoBuktiPot.Text = f.NoBuktiPotong
                'GetTot()
            End If

            ''Else
            ''XtraMessageBox.Show("Data belum di checklist !")
            ''End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnPPH1_EditValueChanged(sender As Object, e As EventArgs) Handles BtnPPH1.EditValueChanged
        ''GridInvoice.FocusedView.PostEditor()

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendKeys.Send("{ENTER}")
        Timer1.Enabled = False
    End Sub
End Class
