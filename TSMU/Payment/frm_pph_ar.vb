Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public Class frm_pph_ar
    Dim _FP As String
    Dim _Voucher As String
    Dim _invcNbr As String
    Dim _DPP As String
    Dim ObjFP As Cls_FP = New Cls_FP()
    Dim tes As Boolean = True
    Dim total_dpp As Double = 0
    Dim IsNew As Boolean
    Dim ObjHeader As New ar_pph_header_models
    Dim ObjDetails As New ar_pph_detail_models
    Dim ObjPPHTransaction As New ar_pph_transaction_models
    Private _Total As Double = 0
    Dim ObjPaymentHeader1 As New AR_Header_Models
    Dim _dt As DataTable
    Public Sub New(invcNbr As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(FP As String, Voucher As String, invcNbr As String, DPP As String, _IsNew As Boolean, ByVal dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _FP = FP
        _Voucher = Voucher
        _invcNbr = invcNbr
        _DPP = DPP
        IsNew = _IsNew
        _dt = New DataTable
        _dt = dt
    End Sub
    Private Sub frm_pph_ar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initial()
        'For i As Integer = 0 To GridView1.RowCount - 1
        '    _TxtDPP.Text = GridView1.GetRowCellValue(i, "Amount").ToString().TrimEnd
        'Next
    End Sub

    Private Sub Initial()
        Try
            If IsNew Then
                ObjFP.Fp = _FP
                ObjFP.invcnbr = _invcNbr
                _TxtFP.Text = _FP
                _TxtVoucher.Text = _Voucher
                _TxtInvcNbr.Text = _invcNbr
                _TxtDPP.Text = _DPP
                _TxtCekInv.Text = ObjFP.cekinv
                _TxtCekFaktur.Text = ObjFP.cekfaktur
                _TxtTahun.Text = DateTime.Now.Year.ToString
                _TxtBulan.Text = DateTime.Now.Month.ToString
                _TxtPPh.Enabled = True
                _TsbOk.Enabled = True
                TextEdit1.Text = ObjPaymentHeader1.CMDMNo
                ''_TxtKetDPP.d= _dt
                GridControl1.DataSource = _dt
            Else
                Dim dt As New DataTable
                dt = ObjHeader.GetFPByNo(_Voucher.TrimEnd)
                If dt.Rows.Count > 0 Then
                    _TxtVoucher.Text = dt.Rows(0).Item("FPNo").ToString().TrimEnd
                    _TxtFP.Text = dt.Rows(0).Item("FPNo").ToString()
                    _TxtNoBuktiPot.Text = dt.Rows(0).Item("No_Bukti_Potong").ToString().TrimEnd
                    _TxtPPh.Text = dt.Rows(0).Item("Pphid")
                    _TxtKetPPh.Text = dt.Rows(0).Item("Ket_Pph").ToString().TrimEnd
                    _TxtTarif.Text = dt.Rows(0).Item("Tarif")
                    _TxtDPP.Text = dt.Rows(0).Item("Tot_Dpp_Invoice")
                    _TxtTahun.Text = dt.Rows(0).Item("Tahun").ToString().TrimEnd
                    _TxtBulan.Text = dt.Rows(0).Item("Bulan").ToString().TrimEnd
                    _TxtLokasi.Text = dt.Rows(0).Item("Lokasi").ToString().TrimEnd
                    _TxtNilaiPPh.Text = dt.Rows(0).Item("Tot_Pph")
                    _TxtKetDPP.Text = dt.Rows(0).Item("ket_dpp").ToString()
                    '_TxtInvcNbr.Text = Trim(dt.Rows(0).Item("tahunpajak"))
                    TextEdit1.Text = dt.Rows(0).Item("CMDMNo").ToString()
                End If
                'For Each ctl As Control In Me.LayoutControl1.Controls
                '    ctl.Enabled = False
                'Next
                _TsbOk.Enabled = False
                '_TxtPPh.Enabled = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub


    ReadOnly Property PPHDetails As Double
        Get
            Return Convert.ToDouble(_TxtNilaiPPh.Text)
        End Get
    End Property
    ReadOnly Property NoBuktiPotong As String
        Get
            Return _TxtNoBuktiPot.Text
        End Get
    End Property
    Public Property pph() As String
    ReadOnly Property Total() As Double
        Get
            Return _Total
        End Get
    End Property
    Private Sub GetTotalCM()
        Try
            ' _Total = 0
            'ObjPaymentHeader1.ObjBatch.Clear()

            _Total = _Total - Convert.ToSingle(pph)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GetTotalAR()
        Try

            _Total = _Total + _TxtNilaiPPh.Text


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub _TsbOk_Click(sender As Object, e As EventArgs) Handles _TsbOk.Click
        Try
            Dim lb_Validated As Boolean = False
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated Then
                With ObjPPHTransaction
                    .Bulan = _TxtBulan.Text
                    .CuryID = ""
                    .FPNo = _TxtVoucher.Text
                    .ket_dpp = _TxtKetDPP.Text
                    .Ket_Pph = _TxtKetPPh.Text
                    .Lokasi = _TxtLokasi.Text
                    .No_Bukti_Potong = _TxtNoBuktiPot.Text
                    .No_Faktur = _TxtFP.Text
                    .Pphid = _TxtPPh.Text
                    .Tahun = _TxtTahun.Text
                    .Tarif = _TxtTarif.Text
                    .Tot_Dpp_Invoice = _TxtDPP.Text
                    .Tot_Pph = _TxtNilaiPPh.Text
                    .CMDMNo = TextEdit1.Text
                End With
                ObjPPHTransaction.ObjPPHDetails.Clear()

                ObjPPHTransaction.InsertData()
            End If
            XtraMessageBox.Show("Data telah di simpan")
            GetTotalCM()
            GetTotalAR()
            Me.Close()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub _TxtPPh_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _TxtPPh.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            If sender.Name = _TxtPPh.Name Then
                ObjFP = New Cls_FP()
                dtSearch = ObjFP.pasal
                ls_OldKode = _TxtPPh.Text.Trim
                ls_Judul = "PPH"
            End If
            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                If sender.Name = _TxtPPh.Name AndAlso Value1 <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _TxtPPh.Text = Value1
                    _TxtKetPPh.Text = Value3
                    _TxtTarif.Text = Value2
                End If

                If IsNew Then
                    If _TxtTarif.Text <> "" AndAlso _TxtDPP.Text <> "" Then
                        _TxtNilaiPPh.Text = Format(Val(_TxtDPP.Text * _TxtTarif.Text / 100), "#,#.##")
                    End If
                End If

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _TxtLokasi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _TxtLokasi.SelectedIndexChanged
        Try
            With ObjFP
                .pph = _TxtPPh.Text
                .tarif = _TxtTarif.Text
                .lokasi = _TxtLokasi.Text
                .voucno = _TxtVoucher.Text
                _TxtNoBuktiPot.Text = .autonoFP(_TxtBulan.Text)
            End With

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        _TxtPPh.DoValidate()
        _TxtLokasi.DoValidate()
        _TxtTarif.DoValidate()
        _TxtNilaiPPh.DoValidate()
        _TxtFP.DoValidate()
        _TxtVoucher.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(_TxtPPh) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtLokasi) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtTarif) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtNilaiPPh) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtFP) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(_TxtVoucher) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub _TxtPPh_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtPPh.EditValueChanged

    End Sub
End Class