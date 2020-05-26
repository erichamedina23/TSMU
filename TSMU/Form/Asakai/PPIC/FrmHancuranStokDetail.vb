Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmHancuranStokDetail

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


    Private Sub FrmHancuranStokDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
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
                Fc_Class.GetData_HS(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Stok Hancuran" & fs_Code
            Else
                Me.Text = "Stok Hancuran"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmHancuranStok"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With Fc_Class
                    DtTanggal.Value = Fc_Class.HS_Tanggal
                    TxtStokPallet.Text = Fc_Class.HS_StokPallet
                    TxtStokMix.Text = Fc_Class.HS_StokMix
                    TxtStokNG.Text = Fc_Class.HS_StokNG
                    TxtTarget.Text = Fc_Class.HS_Target
                    TxtTotalOK.Text = Fc_Class.HS_TotalOK
                    TxtTotalPagi.Text = Fc_Class.HS_TotalPagi
                    TxtIN.Text = Fc_Class.HS_IN
                    TxtOut.Text = Fc_Class.HS_OUT
                    TxtStokAkhir.Text = Fc_Class.HS_StokAhir
                End With

            Else
                TxtStokPallet.Text = "0"
                TxtStokMix.Text = "0"
                TxtStokNG.Text = "0"
                TxtTarget.Text = "0"
                TxtTotalOK.Text = "0"
                TxtTotalPagi.Text = "0"
                TxtIN.Text = "0"
                TxtOut.Text = "0"
                TxtStokAkhir.Text = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
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

            If TxtStokPallet.Text = "" Then

                MessageBox.Show("STOK GRI PROSES PALLET KG JANGAN KOSONG", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf TxtStokMix.Text = "" Then
                MessageBox.Show("STOK GRI PROSES MIX KG JANGAN KOSONG", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf TxtStokNG.Text = "" Then
                MessageBox.Show("STOK GRI NG KG JANGAN KOSONG", "Warning",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button1)
            ElseIf TxtTarget.Text = "" Then
                MessageBox.Show("TARGET JANGAN KOSONG", "Warning",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation,
                          MessageBoxDefaultButton.Button1)
            ElseIf TxtTotalOK.Text = "" Then
                MessageBox.Show("TOTAL HANCURAN OK JANGAN KOSONG", "Warning",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1)
            ElseIf TxtTotalPagi.Text = "" Then
                MessageBox.Show("TOTAL HANCURAN PAGI JANGAN KOSONG", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf TxtIN.Text = "" Then
                MessageBox.Show("HANCURAN MASUK JANGAN KOSONG", "Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1)
            ElseIf TxtOut.Text = "" Then
                MessageBox.Show("HANCURAN KELUAR JANGAN KOSONG", "Warning",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation,
                      MessageBoxDefaultButton.Button1)
            ElseIf TxtStokAkhir.Text = "" Then
                MessageBox.Show("STOK AHIR JANGAN KOSONG", "Warning",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation,
                     MessageBoxDefaultButton.Button1)
            Else


                If isUpdate = False Then
                    Fc_Class.GetIDTransAuto_HS()
                    KodeTrans = Fc_Class.IDTrans
                    Fc_Class.HS_IDTransaksi = KodeTrans
                    Fc_Class.HS_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                    Fc_Class.HS_StokPallet = Convert.ToInt32(TxtStokPallet.Text)
                    Fc_Class.HS_StokMix = Convert.ToInt32(TxtStokMix.Text)
                    Fc_Class.HS_StokNG = Convert.ToInt32(TxtStokNG.Text)
                    Fc_Class.HS_Target = Convert.ToInt32(TxtTarget.Text)
                    Fc_Class.HS_TotalOK = Convert.ToInt32(TxtTotalOK.Text)
                    Fc_Class.HS_TotalPagi = Convert.ToInt32(TxtTotalPagi.Text)
                    Fc_Class.HS_IN = Convert.ToInt32(TxtIN.Text)
                    Fc_Class.HS_OUT = Convert.ToInt32(TxtOut.Text)
                    Fc_Class.HS_StokAhir = Convert.ToInt32(TxtStokAkhir.Text)
                    Fc_Class.InsertData_HS(KodeTrans)
                    GridDtl.DataSource = Fc_Class.GetAllDataTable_HS(bs_Filter)
                    IsClosed = True
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Else
                    KodeTrans = fs_Code
                    Fc_Class.H_IDTransaksi = KodeTrans
                    Fc_Class.HS_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                    Fc_Class.HS_StokPallet = Convert.ToInt32(TxtStokPallet.Text)
                    Fc_Class.HS_StokMix = Convert.ToInt32(TxtStokMix.Text)
                    Fc_Class.HS_StokNG = Convert.ToInt32(TxtStokNG.Text)
                    Fc_Class.HS_Target = Convert.ToInt32(TxtTarget.Text)
                    Fc_Class.HS_TotalOK = Convert.ToInt32(TxtTotalOK.Text)
                    Fc_Class.HS_TotalPagi = Convert.ToInt32(TxtTotalPagi.Text)
                    Fc_Class.HS_IN = Convert.ToInt32(TxtIN.Text)
                    Fc_Class.HS_OUT = Convert.ToInt32(TxtOut.Text)
                    Fc_Class.HS_StokAhir = Convert.ToInt32(TxtStokAkhir.Text)
                    Fc_Class.UpdateData_HS(fs_Code)
                    GridDtl.DataSource = Fc_Class.GetAllDataTable_HS(bs_Filter)
                    IsClosed = True
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                End If

                IsClosed = True
                Me.Hide()

            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try

            lb_Validated = True

            If lb_Validated Then
                With Fc_Class


                    .H_Tanggal = Format(CDate(Format(DtTanggal.Value, "yyyy-MM-dd")))

                    If isUpdate = False Then
                        .ValidateInsert()
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



















    Private Sub TxtStokPallet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStokPallet.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStokMix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStokMix.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStokNG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStokNG.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtTarget_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTarget.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtTotalOK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTotalOK.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtTotalPagi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTotalPagi.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIN.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtOut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOut.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStokAkhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStokAkhir.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub



    Private Sub TxtStokPallet_Leave(sender As Object, e As EventArgs) Handles TxtStokPallet.Leave

        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtStokMix_Leave(sender As Object, e As EventArgs) Handles TxtStokMix.Leave
        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtStokNG_Leave(sender As Object, e As EventArgs) Handles TxtStokNG.Leave
        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtTarget_Leave(sender As Object, e As EventArgs) Handles TxtTarget.Leave

        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtTotalOK_Leave(sender As Object, e As EventArgs) Handles TxtTotalOK.Leave

        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtTotalPagi_Leave(sender As Object, e As EventArgs) Handles TxtTotalPagi.Leave

        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtIN_Leave(sender As Object, e As EventArgs) Handles TxtIN.Leave

        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtOut_Leave(sender As Object, e As EventArgs) Handles TxtOut.Leave

        Try
            Dim pallet, mix, ng, target, ok, pagi, masuk, keluar, ahir As Integer

            If TxtStokPallet.Text = "" Then
                TxtStokPallet.Text = "0"
            ElseIf TxtStokMix.Text = "" Then
                TxtStokMix.Text = "0"
            ElseIf TxtStokNG.Text = "" Then
                TxtStokNG.Text = "0"
            ElseIf TxtTarget.Text = "" Then
                TxtTarget.Text = "0"
            ElseIf TxtTotalOK.Text = "" Then
                TxtTotalOK.Text = "0"
            ElseIf TxtTotalPagi.Text = "" Then
                TxtTotalPagi.Text = "0"
            ElseIf TxtIN.Text = "" Then
                TxtIN.Text = "0"
            ElseIf TxtOut.Text = "" Then
                TxtOut.Text = "0"
            ElseIf TxtStokAkhir.Text = "" Then
                TxtStokAkhir.Text = "0"
            End If

            pallet = TxtStokPallet.Text
            mix = TxtStokMix.Text
            ng = TxtStokNG.Text
            target = TxtTarget.Text

            ok = pallet + mix
            TxtTotalOK.Text = ok.ToString

            pagi = ok + ng
            TxtTotalPagi.Text = pagi.ToString

            masuk = TxtIN.Text
            keluar = TxtOut.Text

            ahir = pagi + masuk - keluar

            TxtStokAkhir.Text = ahir.ToString

        Catch ex As Exception

        End Try

    End Sub
End Class
