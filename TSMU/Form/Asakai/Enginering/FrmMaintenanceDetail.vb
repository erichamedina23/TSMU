Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Imports System.IO
Imports ExcelDataReader
Imports GemBox.Spreadsheet
Imports System.Data.OleDb
Public Class FrmMaintenanceDetail

    Private dt As DataTable

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjMaintenanceDetail As New MaintenanceDetailModel
    Dim KodeTrans As String = ""
    Dim fc_Class As New MaintenanceModel
    Dim GridDtl As GridControl

    Private Sub FrmMaintenanceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

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

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Maintenance " & fs_Code
            Else
                Me.Text = "Maintenance"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmMaintenance"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    DtTanggalLaporan.Value = fc_Class.H_Tanggal
                    DtTanggalLaporan.Enabled = False
                    Plan_Mesin.Text = fc_Class.Mesin_Plan
                    Act_Mesin.Text = fc_Class.Mesin_Actual
                    Balance_Mesin.Text = fc_Class.Mesin_Balance
                    Ket_Mesin.Text = fc_Class.KeteranganMesin

                    Plan_Mold.Text = fc_Class.Mold_Plan
                    Act_Mold.Text = fc_Class.Mold_Actual
                    Balance_Mold.Text = fc_Class.Mold_Balance
                    Ket_Mold.Text = fc_Class.Keterangan_Mold

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        'Try
        '    If fs_Code <> "" Then
        '        Dim dtGridProblem As New DataTable
        '        dtGridProblem = fc_Class.GetDataDetailQualityProblem(fs_Code)
        '        Grid.DataSource = dtGridProblem
        '    Else
        '        'Code
        '    End If

        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message)
        'End Try
    End Sub



    Private Sub Plan_Mesin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Plan_Mesin.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If

        Dim Plan, Aktual, Balance As Integer
        Plan = Convert.ToInt32(Plan_Mesin.Text)
        Aktual = Convert.ToInt32(Act_Mesin.Text)

        Balance = Aktual - Plan
        Balance_Mesin.Text = Balance.ToString
    End Sub

    Private Sub Act_Mesin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Act_Mesin.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If

        'Dim Plan, Aktual, Balance As Integer
        'Plan = Convert.ToInt32(Plan_Mesin.Text)
        'Aktual = Convert.ToInt32(Act_Mesin.Text)

        'Balance = Aktual - Plan
        'Balance_Mesin.Text = Balance.ToString

    End Sub

    Private Sub Balance_Mesin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Balance_Mesin.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Plan_Mold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Plan_Mold.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If

        Dim Plan, Aktual, Balance As Integer
        Plan = Convert.ToInt32(Plan_Mold.Text)
        Aktual = Convert.ToInt32(Act_Mold.Text)

        Balance = Aktual - Plan
        Balance_Mold.Text = Balance.ToString
    End Sub

    Private Sub Act_Mold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Act_Mold.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
        Dim Plan, Aktual, Balance As Integer
        Plan = Convert.ToInt32(Plan_Mold.Text)
        Aktual = Convert.ToInt32(Act_Mold.Text)

        Balance = Aktual - Plan
        Balance_Mold.Text = Balance.ToString
    End Sub

    Private Sub Balance_Mold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Balance_Mold.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
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

            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTrans = fc_Class.IDTrans

                fc_Class = New MaintenanceModel
                With fc_Class
                    .H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                    .H_IDTransaksi = KodeTrans
                    .Mesin_Plan = Plan_Mesin.Text
                    .Mesin_Actual = Act_Mesin.Text
                    .Mesin_Balance = Balance_Mesin.Text
                    .KeteranganMesin = Ket_Mesin.Text

                    .Mold_Plan = Plan_Mold.Text
                    .Mold_Actual = Act_Mold.Text
                    .Mold_Balance = Balance_Mold.Text
                    .Keterangan_Mold = Ket_Mold.Text
                End With

                fc_Class.InsertMain(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else

                KodeTrans = fc_Class.IDTrans

                fc_Class = New MaintenanceModel
                With fc_Class
                    .H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                    .H_IDTransaksi = KodeTrans
                    .Mesin_Plan = Plan_Mesin.Text
                    .Mesin_Actual = Act_Mesin.Text
                    .Mesin_Balance = Balance_Mesin.Text
                    .KeteranganMesin = Ket_Mesin.Text
                    .Mold_Plan = Plan_Mold.Text
                    .Mold_Actual = Act_Mold.Text
                    .Mold_Balance = Balance_Mold.Text
                    .Keterangan_Mold = Ket_Mold.Text
                End With


                fc_Class.UpdateData(fs_Code)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
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
            If Plan_Mesin.Text = "" OrElse Act_Mesin.Text = "" OrElse Balance_Mesin.Text = "" OrElse Plan_Mold.Text = "" OrElse Act_Mold.Text = "" OrElse Balance_Mold.Text = "" Then

                MessageBox.Show("Inputan Tidak Boleh Kosong",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            Else

                lb_Validated = True

                If lb_Validated Then
                    With fc_Class


                        .H_Tanggal = Format(CDate(Format(DtTanggalLaporan.Value, "yyyy-MM-dd")))

                        If isUpdate = False Then
                            .ValidateInsert()
                        End If

                    End With

                End If

            End If


        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated

    End Function

    Public Sub TextBoxLoad()
        Plan_Mesin.Text = "0"
        Act_Mesin.Text = "0"
        Balance_Mesin.Text = "0"
        Plan_Mold.Text = "0"
        Act_Mold.Text = "0"
        Balance_Mold.Text = "0"
        Ket_Mesin.Text = ""
        Ket_Mold.Text = ""

    End Sub



    Private Sub Plan_Mold_Leave(sender As Object, e As EventArgs) Handles Plan_Mold.Leave

        Try
            HitungBalanceMold()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Act_Mold_Leave(sender As Object, e As EventArgs) Handles Act_Mold.Leave
        Try
            HitungBalanceMold()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Act_Mesin_Leave(sender As Object, e As EventArgs) Handles Act_Mesin.Leave

        Try
            HitungBalanceMesin()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Plan_Mesin_Leave(sender As Object, e As EventArgs) Handles Plan_Mesin.Leave
        Try
            HitungBalanceMesin()
        Catch ex As Exception

        End Try


    End Sub



    Private Sub DtTanggalLaporan_Leave(sender As Object, e As EventArgs) Handles DtTanggalLaporan.Leave
        Dim tgl As Date = Format(CDate(DtTanggalLaporan.Value), gs_FormatSQLDate)

        fc_Class.tahun = Convert.ToString(tgl.Year)
        fc_Class.bulan = Convert.ToString(tgl.Month)
        fc_Class.tanggal = Convert.ToString(tgl.Day)
        fc_Class.GetSumaryBalance()

        Mesin_Old.Text = fc_Class.SMesin
        Mold_Old.Text = fc_Class.SMold





    End Sub



    Private Sub HitungBalanceMesin()

        Try
            If Plan_Mesin.Text <> "" Or Act_Mesin.Text <> "" Then
                Dim Plan, Aktual, Balance, MesinOld As Integer
                Plan = Convert.ToInt32(Plan_Mesin.Text)
                Aktual = Convert.ToInt32(Act_Mesin.Text)
                MesinOld = Convert.ToInt32(Mesin_Old.Text)

                Balance = (Aktual - Plan)
                'Balance = (Aktual - Plan) + MesinOld
                Balance_Mesin.Text = Balance.ToString
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub HitungBalanceMold()

        Try
            If Plan_Mold.Text <> "" Or Act_Mold.Text <> "" Then
                Dim Plan, Aktual, Balance, MoldOld As Integer
                Plan = Convert.ToInt32(Plan_Mold.Text)
                Aktual = Convert.ToInt32(Act_Mold.Text)
                MoldOld = Convert.ToInt32(Mold_Old.Text)

                'Balance = (Aktual - Plan) + MoldOld
                Balance = (Aktual - Plan)
                Balance_Mold.Text = Balance.ToString
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DtTanggalLaporan_ValueChanged(sender As Object, e As EventArgs) Handles DtTanggalLaporan.ValueChanged

    End Sub

    Private Sub Balance_Mesin_TextChanged(sender As Object, e As EventArgs) Handles Balance_Mesin.TextChanged

    End Sub

    Private Sub Plan_Mesin_TextChanged(sender As Object, e As EventArgs) Handles Plan_Mesin.TextChanged

    End Sub
End Class
