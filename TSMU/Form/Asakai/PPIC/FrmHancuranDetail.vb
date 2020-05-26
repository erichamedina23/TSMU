Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmHancuranDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

    Private dt As DataTable

    Dim DeptID As String
    Dim KodeTrans As String = ""
    Dim Fc_Class As New HancuranModel
    Dim ObjHancuranDetail As New HancuranDetailModel

    Private Sub FrmHancuranDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = New DataTable
        dt.Columns.Add("ID SUPPLIER")
        dt.Columns.Add("SUPPLIER")
        dt.Columns.Add("STOK AWAL")
        dt.Columns.Add("KIRIM")
        dt.Columns.Add("KEMBALI")
        dt.Columns.Add("BALANCE")
        Grid.DataSource = dt

        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(ByVal strCode As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                Fc_Class.H_IDTransaksi = fs_Code
                Fc_Class.GetData(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Hancuran" & fs_Code
            Else
                Me.Text = "Hancuran"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmHancuran"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With Fc_Class
                    DtTanggal.Value = Fc_Class.H_Tanggal
                    txtHancuranInternal.Text = Fc_Class.H_Internal
                    txtTotal.Text = Fc_Class.H_Total
                    txtTarget.Text = Fc_Class.H_Target
                End With

            Else
                txtHancuranInternal.Text = "0"
                txtTotal.Text = "0"
                txtTarget.Text = "0"
                txtKirim.Text = "0"
                txtStokAwal.Text = "0"
                txtBalnce.Text = "0"
                txtKembali.Text = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGrid As New DataTable
                dtGrid = Fc_Class.GetDataDetailHancuran(fs_Code)
                Grid.DataSource = dtGrid
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub txtStokAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStokAwal.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtKirim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKirim.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txkKembali_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKembali.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBalnce_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBalnce.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not tombol = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtHancuranInternal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHancuranInternal.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtHancuranSupplier_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotal.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not tombol = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTarget_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarget.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If CmbSuplier.Text = "" Then
            MessageBox.Show("Harap Pilih Supplier",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
        ElseIf txtStokAwal.Text = "" Or txtKirim.Text = "" Or txtKembali.Text = "" Or txtBalnce.Text = "" Then
            MessageBox.Show("Periksa Inputan Ada Yang Kosong",
                               "Warning",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation,
                              MessageBoxDefaultButton.Button1)
        ElseIf txtHancuranInternal.Text = "" Or txtTotal.Text = "" Or txtTarget.Text = "" Then
            MessageBox.Show("Periksa Inputan Ada Yang Kosong",
                              "Warning",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation,
                              MessageBoxDefaultButton.Button1)
        Else

            GridView1.AddNewRow()
            'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, IdSupplier, CmbSuplier.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, SUPPLIER, CmbSuplier.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, STOKAWAL, txtStokAwal.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, KIRIM, txtKirim.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, KEMBALI, txtKembali.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, BALANCE, txtBalnce.Text)
            GridView1.UpdateCurrentRow()


            Dim _Internal, _Total, _Balance As Integer

            _Internal = txtHancuranInternal.Text

            If Convert.ToString(GridView1.Columns("BALANCE").SummaryItem.SummaryValue) = "" Then
                _Balance = 0
            Else
                _Balance = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)

            End If
            '_Balance = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)
            _Total = _Balance + _Internal
            txtTotal.Text = _Total.ToString


            'Convert.ToDouble(GridView1.Columns("Pemakaian").SummaryItem.SummaryValue)
            Call BersihText()
        End If


        Try
            If txtHancuranInternal.Text <> "" Then
                Dim internal, TotalSupplier, total As Integer
                internal = Convert.ToInt32(txtHancuranInternal.Text)
                TotalSupplier = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)

                total = internal + TotalSupplier
                txtTotal.Text = total.ToString
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub BersihText()
        txtKirim.Text = "0"
        txtStokAwal.Text = "0"
        txtBalnce.Text = "0"
        txtKembali.Text = "0"
        'txtHancuranInternal.Text = "0"
        'txtTotal.Text = "0"
        'txtTarget.Text = "0"
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub


    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub getdataview1()
        Try
            Dim IsEmpty As Boolean = False

            If GridView1.RowCount = 0 Then

                MessageBox.Show("Belum Melakukan Inputan", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If isUpdate = False Then
                Fc_Class.GetIDTransAuto()
                KodeTrans = Fc_Class.IDTrans
                Fc_Class.H_IDTransaksi = KodeTrans
                Fc_Class.H_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                Fc_Class.H_StokAwal = Convert.ToInt32(GridView1.Columns("STOK AWAL").SummaryItem.SummaryValue)
                Fc_Class.H_Kirim = Convert.ToInt32(GridView1.Columns("KIRIM").SummaryItem.SummaryValue)
                Fc_Class.H_Kembali = Convert.ToInt32(GridView1.Columns("KEMBALI").SummaryItem.SummaryValue)
                Fc_Class.H_Balance = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)
                Fc_Class.H_Internal = txtHancuranInternal.Text
                Fc_Class.H_Total = txtTotal.Text
                Fc_Class.H_Target = txtTarget.Text
                Fc_Class.H_IDTransaksi = KodeTrans

                'Insert To ObjDetailMaterial
                Fc_Class.ObjDetailHancuran.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjHancuranDetail = New HancuranDetailModel
                    With ObjHancuranDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                        .D_IDSupplier = Convert.ToString(GridView1.GetRowCellValue(i, "SUPPLIER"))
                        .D_StokAwal = Convert.ToInt32(GridView1.GetRowCellValue(i, "STOK AWAL"))
                        .D_Kirim = Convert.ToInt32(GridView1.GetRowCellValue(i, "KIRIM"))
                        .D_Kembali = Convert.ToInt32(GridView1.GetRowCellValue(i, "KEMBALI"))
                        .D_Balance = Convert.ToInt32(GridView1.GetRowCellValue(i, "BALANCE"))

                    End With
                    Fc_Class.ObjDetailHancuran.Add(ObjHancuranDetail)

                Next

                Fc_Class.InsertData(KodeTrans)
                GridDtl.DataSource = Fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fs_Code
                Fc_Class.H_IDTransaksi = KodeTrans
                Fc_Class.H_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                Fc_Class.H_StokAwal = Convert.ToInt32(GridView1.Columns("STOK AWAL").SummaryItem.SummaryValue)
                Fc_Class.H_Kirim = Convert.ToInt32(GridView1.Columns("KIRIM").SummaryItem.SummaryValue)
                Fc_Class.H_Kembali = Convert.ToInt32(GridView1.Columns("KEMBALI").SummaryItem.SummaryValue)
                Fc_Class.H_Balance = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)
                Fc_Class.H_Internal = txtHancuranInternal.Text
                Fc_Class.H_Total = txtTotal.Text
                Fc_Class.H_Target = txtTarget.Text
                Fc_Class.H_IDTransaksi = KodeTrans

                'Insert To ObjDetailMaterial
                Fc_Class.ObjDetailHancuran.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjHancuranDetail = New HancuranDetailModel
                    With ObjHancuranDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                        .D_IDSupplier = Convert.ToString(GridView1.GetRowCellValue(i, "SUPPLIER"))
                        .D_StokAwal = Convert.ToInt32(GridView1.GetRowCellValue(i, "STOK AWAL"))
                        .D_Kirim = Convert.ToInt32(GridView1.GetRowCellValue(i, "KIRIM"))
                        .D_Kembali = Convert.ToInt32(GridView1.GetRowCellValue(i, "KEMBALI"))
                        .D_Balance = Convert.ToInt32(GridView1.GetRowCellValue(i, "BALANCE"))

                    End With
                    Fc_Class.ObjDetailHancuran.Add(ObjHancuranDetail)

                Next

                Fc_Class.UpdateData(fs_Code)
                GridDtl.DataSource = Fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If GridView1.RowCount < 1 Then

                MessageBox.Show("Belum Melakukan Inputan",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Else
                lb_Validated = True

            End If

            If lb_Validated Then
                With Fc_Class


                    .H_Tanggal = Format(CDate(Format(DtTanggal.Value, "yyyy-MM-dd")))

                    If isUpdate = False Then
                        .ValidateInsertHancuran()
                    End If

                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated

    End Function

    Private Sub txtKembali_Leave(sender As Object, e As EventArgs) Handles txtKembali.Leave
        Try
            If txtStokAwal.Text = "" Then
                txtStokAwal.Text = "0"
            ElseIf txtKirim.Text = "" Then
                txtKirim.Text = "0"
            ElseIf txtKembali.Text = "" Then
                txtKembali.Text = "0"
            ElseIf txtBalnce.Text = "" Then
                txtBalnce.Text = "0"
            ElseIf txtHancuranInternal.Text = "" Then
                txtHancuranInternal.Text = "0"
            ElseIf txtTotal.Text = "" Then
                txtTotal.Text = "0"
            ElseIf txtTarget.Text = "" Then
                txtTarget.Text = "0"

            End If

            Dim Stok, Kirim, Kembali, Balance As Integer


            Stok = txtStokAwal.Text
            Kirim = txtKirim.Text
            Kembali = txtKembali.Text


            Balance = Stok + Kirim - Kembali
            txtBalnce.Text = Balance.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtKirim_Leave(sender As Object, e As EventArgs) Handles txtKirim.Leave
        Try
            If txtStokAwal.Text = "" Then
                txtStokAwal.Text = "0"
            ElseIf txtKirim.Text = "" Then
                txtKirim.Text = "0"
            ElseIf txtKembali.Text = "" Then
                txtKembali.Text = "0"
            ElseIf txtBalnce.Text = "" Then
                txtBalnce.Text = "0"
            ElseIf txtHancuranInternal.Text = "" Then
                txtHancuranInternal.Text = "0"
            ElseIf txtTotal.Text = "" Then
                txtTotal.Text = "0"
            ElseIf txtTarget.Text = "" Then
                txtTarget.Text = "0"
            End If

            Dim Stok, Kirim, Kembali, Balance As Integer


            Stok = txtStokAwal.Text
            Kirim = txtKirim.Text
            Kembali = txtKembali.Text

            Balance = Stok + Kirim - Kembali
            txtBalnce.Text = Balance.ToString



        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtStokAwal_Leave(sender As Object, e As EventArgs) Handles txtStokAwal.Leave
        Try
            If txtStokAwal.Text = "" Then
                txtStokAwal.Text = "0"
            ElseIf txtKirim.Text = "" Then
                txtKirim.Text = "0"
            ElseIf txtKembali.Text = "" Then
                txtKembali.Text = "0"
            ElseIf txtBalnce.Text = "" Then
                txtBalnce.Text = "0"
            ElseIf txtHancuranInternal.Text = "" Then
                txtHancuranInternal.Text = "0"
            ElseIf txtTotal.Text = "" Then
                txtTotal.Text = "0"
            ElseIf txtTarget.Text = "" Then
                txtTarget.Text = "0"
            End If

            Dim Stok, Kirim, Kembali, Balance As Integer


            Stok = txtStokAwal.Text
            Kirim = txtKirim.Text
            Kembali = txtKembali.Text

            Balance = Stok + Kirim - Kembali
            txtBalnce.Text = Balance.ToString



        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHancuranInternal_Leave(sender As Object, e As EventArgs) Handles txtHancuranInternal.Leave
        Try

            Dim _Internal, _Total, _Balance As Integer

            _Internal = txtHancuranInternal.Text

            If Convert.ToString(GridView1.Columns("BALANCE").SummaryItem.SummaryValue) = "" Then
                _Balance = 0
            Else
                _Balance = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)

            End If
            '_Balance = Convert.ToInt32(GridView1.Columns("BALANCE").SummaryItem.SummaryValue)
            _Total = _Balance + _Internal
            txtTotal.Text = _Total.ToString


        Catch ex As Exception

        End Try
    End Sub


End Class
