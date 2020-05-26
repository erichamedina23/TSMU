Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class Frm_AR_Tax_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim ObjAR_Pph As New ARTaxHeaderModel
    Dim ObjSuspendDetail As New SuspendDetailModel
    Dim GridDtl As GridControl
    Dim f As Frm_AR_Tax_detail
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable

    Dim ObjSuspend As New ClsSuspend
    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _SuspendID As String = ""

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

    Private Sub Frm_AR_Tax_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)

        Call InitialSetForm()

    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjAR_Pph.ID = fs_Code
                ObjAR_Pph.GetARPphById()

                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "AR TAX " & fs_Code
            Else
                Me.Text = "AR TAX"
            End If
            Call LoadTxtBox()

            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "Frm_AR_Tax"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjAR_Pph
                    _TxtVoucher.Text = .FPNo
                    _TxtFP.Text = .FPNo
                    _TxtNoBuktiPot.Text = .No_Bukti_Potong
                    _TxtPPh.Text = .Pphid
                    _TxtKetPPh.Text = .Ket_Pph
                    _TxtTarif.Text = .Tarif
                    _TxtDPP.Text = Format(.Tot_Dpp_Invoice, gs_FormatBulat)
                    _TxtTahun.Text = .Tahun
                    _TxtBulan.Text = .Bulan
                    _TxtLokasi.Text = .Lokasi
                    _TxtNilaiPPh.Text = Format(.Tot_Pph, gs_FormatBulat)
                    _TxtKetDPP.Text = .ket_dpp

                End With
                'GridView1.AddNewRow()
                'GridView1.OptionsNavigation.AutoFocusNewRow = True
            Else
                _TxtVoucher.Text = ""
                _TxtFP.Text = ""
                _TxtNoBuktiPot.Text = ""
                _TxtPPh.Text = ""
                _TxtKetPPh.Text = ""
                _TxtTarif.Text = 0
                _TxtDPP.Text = 0
                _TxtTahun.Text = ""
                _TxtBulan.Text = ""
                _TxtLokasi.Text = ""
                _TxtNilaiPPh.Text = 0
                _TxtKetDPP.Text = ""
                'GridView1.AddNewRow()
                'GridView1.OptionsNavigation.AutoFocusNewRow = True
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            With ObjAR_Pph
                .FPNo = _TxtVoucher.Text
                .FPNo = _TxtFP.Text
                .No_Bukti_Potong = _TxtNoBuktiPot.Text
                .Pphid = _TxtPPh.Text
                .Ket_Pph = _TxtKetPPh.Text
                .Tarif = _TxtTarif.Text
                ''  .Tot_Dpp_Invoice = Format(_TxtDPP.Text, gs_FormatBulat)
                .Tot_Dpp_Invoice = _TxtDPP.Text
                .Tahun = _TxtTahun.Text
                .Bulan = _TxtBulan.Text
                .Lokasi = _TxtLokasi.Text
                ' .Tot_Pph = Format(_TxtNilaiPPh.Text, gs_FormatBulat)
                .Tot_Pph = _TxtNilaiPPh.Text
                .ket_dpp = _TxtKetDPP.Text
            End With
            ObjAR_Pph.UpdateHeader()
            GridDtl.DataSource = ObjAR_Pph.GetDataGrid()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            'Throw
        End Try
    End Sub
End Class
