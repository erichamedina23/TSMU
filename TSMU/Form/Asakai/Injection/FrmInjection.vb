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

Public Class FrmInjection

    Dim isUpdate As Boolean = False
    Dim FileLokasi As String = ""
    Dim sheet As String
    Dim CellValue As String
    Dim GridData As DataTable = Nothing
    Dim KolomTanggal As String = ""
    Dim KolomTanggalReject As String = ""

    Dim fc_Class As New InjectionModel
    Dim ObjInjectionDetail As New InjectionDetailModel


#Region "Data Table"

    Dim dtLimaBesar As DataTable
    Dim dtPPA As DataTable
    Dim dtRecovery As DataTable
    Dim dtPA As DataTable
    Dim dtReject As DataTable
    Dim dtGrid As DataTable

    Dim dtPPA_Mold As DataTable
    Dim dtPPA_Mesin As DataTable

#End Region



    Private Sub FrmInjection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Proc_EnableButtons(True, True, True, True, True, False, False, False)
        Call LoadGrid()


    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()

        ' If isUpdate = False Then


        If TxtFileName.Text = "" Then
                MessageBox.Show("Filih File Yang akan Di Upload")
            Else
                ObjInjectionDetail.D_date = Format(dtTanggal.Value, "yyyy-MM-dd")

                fc_Class.GetIDTransAuto()

                With fc_Class

                    .H_date = Format(dtTanggal.Value, "yyyy-MM-dd")

                End With


                fc_Class.InsertInjection()
                TxtFileName.Text = ""
                MessageBox.Show("File Saved")
            Call LoadGrid()
            TxtFileName.Text = ""
        End If

        'Else


        'End If



    End Sub
    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try

            lb_Validated = True
            If lb_Validated Then
                With fc_Class


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


    Public Overrides Sub Proc_InputNewData()



    End Sub


    Public Sub GetKolom()
        Dim Kolom As Integer
        Kolom = Convert.ToInt64(Format(dtTanggal.Value, "dd"))

        KolomTanggal = "F" & ((Kolom + 1)).ToString
        KolomTanggalReject = "F" & ((Kolom + 2)).ToString

#Region "IF Kolom"
        'If Kolom = 1 Then
        '    KolomTanggal = "F2"
        'ElseIf Kolom = 2 Then
        '    KolomTanggal = "F3"
        'ElseIf Kolom = 3 Then
        '    KolomTanggal = "F4"
        'ElseIf Kolom = 4 Then
        '    KolomTanggal = "F5"
        'ElseIf Kolom = 5 Then
        '    KolomTanggal = "F6"
        'ElseIf Kolom = 6 Then
        '    KolomTanggal = "F7"
        'ElseIf Kolom = 7 Then
        '    KolomTanggal = "F8"
        'ElseIf Kolom = 8 Then
        '    KolomTanggal = "F9"
        'ElseIf Kolom = 9 Then
        '    KolomTanggal = "F10"
        'ElseIf Kolom = 10 Then
        '    KolomTanggal = "F11"
        'ElseIf Kolom = 11 Then
        '    KolomTanggal = "F12"
        'ElseIf Kolom = 12 Then
        '    KolomTanggal = "F13"
        'ElseIf Kolom = 13 Then
        '    KolomTanggal = "F14"
        'ElseIf Kolom = 14 Then
        '    KolomTanggal = "F15"
        'ElseIf Kolom = 15 Then
        '    KolomTanggal = "F16"
        'ElseIf Kolom = 16 Then
        '    KolomTanggal = "F17"
        'ElseIf Kolom = 17 Then
        '    KolomTanggal = "F18"
        'ElseIf Kolom = 18 Then
        '    KolomTanggal = "F19"
        'ElseIf Kolom = 19 Then
        '    KolomTanggal = "F20"
        'ElseIf Kolom = 20 Then
        '    KolomTanggal = "F21"
        'ElseIf Kolom = 21 Then
        '    KolomTanggal = "F22"
        'ElseIf Kolom = 22 Then
        '    KolomTanggal = "F23"
        'ElseIf Kolom = 23 Then
        '    KolomTanggal = "F24"
        'ElseIf Kolom = 24 Then
        '    KolomTanggal = "F25"
        'ElseIf Kolom = 25 Then
        '    KolomTanggal = "F26"
        'ElseIf Kolom = 26 Then
        '    KolomTanggal = "F27"
        'ElseIf Kolom = 27 Then
        '    KolomTanggal = "F28"
        'ElseIf Kolom = 28 Then
        '    KolomTanggal = "F29"
        'ElseIf Kolom = 29 Then
        '    KolomTanggal = "F30"
        'ElseIf Kolom = 30 Then
        '    KolomTanggal = "F31"
        'ElseIf Kolom = 31 Then
        '    KolomTanggal = "F32"
        'End If
#End Region


    End Sub


    Public Sub SetLimaBesar()

#Region "Lima Besar"

        fc_Class.ObjDetailInjectionLB.Clear()

        For i As Integer = 0 To dtLimaBesar.Rows.Count - 1

            ObjInjectionDetail = New InjectionDetailModel
            With ObjInjectionDetail
                .LB_IdTransaksi = fc_Class.IDTrans
                .LB_Shift = dtLimaBesar.Rows(i).Item(1).ToString
                .LB_NoMC = dtLimaBesar.Rows(i).Item(2).ToString
                .LB_invtId = dtLimaBesar.Rows(i).Item(3).ToString
                .LB_InvtName = dtLimaBesar.Rows(i).Item(4).ToString

                If dtLimaBesar.Rows(i).Item(5) Is DBNull.Value Then
                    .LB_OK = "0"
                Else
                    .LB_OK = dtLimaBesar.Rows(i).Item(5)
                End If

                If dtLimaBesar.Rows(i).Item(6) Is DBNull.Value Then
                    .LB_Scrap_Dandori = "0"
                Else
                    .LB_Scrap_Dandori = dtLimaBesar.Rows(i).Item(6)
                End If

                If dtLimaBesar.Rows(i).Item(7) Is DBNull.Value Then
                    .LB_Scrap_Istirahat = "0"
                Else
                    .LB_Scrap_Istirahat = dtLimaBesar.Rows(i).Item(7)
                End If

                If dtLimaBesar.Rows(i).Item(8) Is DBNull.Value Then
                    .LB_NG_Setting = "0"
                Else
                    .LB_NG_Setting = dtLimaBesar.Rows(i).Item(8)
                End If

                If dtLimaBesar.Rows(i).Item(9) Is DBNull.Value Then
                    .LB_NG_Proses = "0"
                Else
                    .LB_NG_Proses = dtLimaBesar.Rows(i).Item(9)
                End If

                If dtLimaBesar.Rows(i).Item(10) Is DBNull.Value Then
                    .LB_NGPersen = "0"
                Else
                    .LB_NGPersen = dtLimaBesar.Rows(i).Item(10)
                End If

                If dtLimaBesar.Rows(i).Item(11) Is DBNull.Value Then
                    .LB_Jens_NG_Proses = "0"
                Else
                    .LB_Jens_NG_Proses = dtLimaBesar.Rows(i).Item(11)
                End If

                If dtLimaBesar.Rows(i).Item(12) Is DBNull.Value Then
                    .LB_Analisa_Problem_4_M = "0"
                Else
                    .LB_Analisa_Problem_4_M = dtLimaBesar.Rows(i).Item(12)
                End If

                If dtLimaBesar.Rows(i).Item(13) Is DBNull.Value Then
                    .LB_Perbaikan_Sementara = ""
                Else
                    .LB_Perbaikan_Sementara = dtLimaBesar.Rows(i).Item(13)
                End If

                If dtLimaBesar.Rows(i).Item(14) Is DBNull.Value Then
                    .LB_Perbaikan_Permanen = ""
                Else
                    .LB_Perbaikan_Permanen = dtLimaBesar.Rows(i).Item(14)
                End If

                If dtLimaBesar.Rows(i).Item(15) Is DBNull.Value Then
                    .LB_PIC = ""
                Else
                    .LB_PIC = dtLimaBesar.Rows(i).Item(15)
                End If

                If dtLimaBesar.Rows(i).Item(16) Is DBNull.Value Then
                    .LB_Target = ""
                Else
                    .LB_Target = dtLimaBesar.Rows(i).Item(16)
                End If

                If dtLimaBesar.Rows(i).Item(17) Is DBNull.Value Then
                    .LB_Status = ""
                Else
                    .LB_Status = dtLimaBesar.Rows(i).Item(17)
                End If

            End With
            fc_Class.ObjDetailInjectionLB.Add(ObjInjectionDetail)

        Next


#End Region

    End Sub

    Public Sub SetPPA()


#Region "PPA"

        fc_Class.ObjDetailInjectionPPA.Clear()
        For j As Integer = 0 To dtPPA.Rows.Count - 1

            ObjInjectionDetail = New InjectionDetailModel
            With ObjInjectionDetail

                .PPA_IdTransaksi = fc_Class.IDTrans



                If dtPPA.Rows(j).Item(1) Is DBNull.Value Then
                    .PPA_NoMC = ""
                Else
                    .PPA_NoMC = dtPPA.Rows(j).Item(1)
                End If

                If dtPPA.Rows(j).Item(2) Is DBNull.Value Then
                    .PPA_Shift = ""
                Else
                    .PPA_Shift = dtPPA.Rows(j).Item(2)
                End If

                If dtPPA.Rows(j).Item(3) Is DBNull.Value Then
                    .PPA_Grup_Leader = ""
                Else
                    .PPA_Grup_Leader = dtPPA.Rows(j).Item(3)
                End If

                If dtPPA.Rows(j).Item(4) Is DBNull.Value Then
                    .PPA_invtId = ""
                Else
                    .PPA_invtId = dtPPA.Rows(j).Item(4)
                End If


                If dtPPA.Rows(j).Item(5) Is DBNull.Value Then
                    .PPA_InvtName = ""
                Else
                    .PPA_InvtName = dtPPA.Rows(j).Item(5)
                End If

                If dtPPA.Rows(j).Item(6) Is DBNull.Value Then
                    .PPA_Targer_Per_Jam = "0"
                Else
                    .PPA_Targer_Per_Jam = dtPPA.Rows(j).Item(6)
                End If

                If dtPPA.Rows(j).Item(7) Is DBNull.Value Then
                    .PPA_Jam_Dari = ""
                Else
                    .PPA_Jam_Dari = Format((dtPPA.Rows(j).Item(7)), "h:mm tt").ToString
                End If

                If dtPPA.Rows(j).Item(9) Is DBNull.Value Then
                    .PPA_Jam_Sampai = "0"
                Else
                    .PPA_Jam_Sampai = Format((dtPPA.Rows(j).Item(9)), "h:mm tt").ToString
                End If


                If dtPPA.Rows(j).Item(10) Is DBNull.Value Then
                    .PPA_LossJam = "0"
                Else
                    .PPA_LossJam = dtPPA.Rows(j).Item(10).ToString
                End If

                If dtPPA.Rows(j).Item(11) Is DBNull.Value Then
                    .PPA_Loss_Produksi = "0"
                Else
                    .PPA_Loss_Produksi = dtPPA.Rows(j).Item(11)
                End If


                If dtPPA.Rows(j).Item(12) Is DBNull.Value Then
                    .PPA_Problem = "0"
                Else
                    .PPA_Problem = dtPPA.Rows(j).Item(12)
                End If

                If dtPPA.Rows(j).Item(13) Is DBNull.Value Then
                    .PPA_Kategori = "0"
                Else
                    .PPA_Kategori = dtPPA.Rows(j).Item(13)
                End If

                If dtPPA.Rows(j).Item(14) Is DBNull.Value Then
                    .PPA_Analisa = "0"
                Else
                    .PPA_Analisa = dtPPA.Rows(j).Item(14)
                End If

                If dtPPA.Rows(j).Item(15) Is DBNull.Value Then
                    .PPA_Perbaikan_Sementara = ""
                Else
                    .PPA_Perbaikan_Sementara = dtPPA.Rows(j).Item(15)
                End If

                If dtPPA.Rows(j).Item(16) Is DBNull.Value Then
                    .PPA_Perbaikan_Permanen = ""
                Else
                    .PPA_Perbaikan_Permanen = dtPPA.Rows(j).Item(16)
                End If

                If dtPPA.Rows(j).Item(17) Is DBNull.Value Then
                    .PPA_PIC = ""
                Else
                    .PPA_PIC = dtPPA.Rows(j).Item(17)
                End If

                If dtPPA.Rows(j).Item(18) Is DBNull.Value Then
                    MessageBox.Show("Upload Gagal, Tanggal Target Jangan Kosong")
                    Exit Sub
                Else
                    .PPA_Target = dtPPA.Rows(j).Item(18)
                End If

                If dtPPA.Rows(j).Item(19) Is DBNull.Value Then
                    .PPA_Status = ""
                Else
                    .PPA_Status = dtPPA.Rows(j).Item(19)
                End If



                fc_Class.ObjDetailInjectionPPA.Add(ObjInjectionDetail)

            End With


        Next

#End Region


    End Sub

    Public Sub SetRecovery()

#Region "Recovery"

        fc_Class.ObjDetailInjectionRECOVERY.Clear()

        For k As Integer = 0 To dtRecovery.Rows.Count - 1

            ObjInjectionDetail = New InjectionDetailModel
            With ObjInjectionDetail

                .R_IdTransaksi = fc_Class.IDTrans

                If dtRecovery.Rows(k).Item(1) Is DBNull.Value Then
                    .R_NoMC = ""
                Else
                    .R_NoMC = dtRecovery.Rows(k).Item(1)
                End If

                If dtRecovery.Rows(k).Item(2) Is DBNull.Value Then
                    .R_Kode_Part = ""
                Else
                    .R_Kode_Part = dtRecovery.Rows(k).Item(2)
                End If

                If dtRecovery.Rows(k).Item(3) Is DBNull.Value Then
                    .R_invtId = ""
                Else
                    .R_invtId = dtRecovery.Rows(k).Item(3)
                End If

                If dtRecovery.Rows(k).Item(4) Is DBNull.Value Then
                    .R_InvtName = ""
                Else
                    .R_InvtName = dtRecovery.Rows(k).Item(4)
                End If

                If dtRecovery.Rows(k).Item(5) Is DBNull.Value Then
                    .R_Plan = "0"
                Else
                    .R_Plan = dtRecovery.Rows(k).Item(5)
                End If

                If dtRecovery.Rows(k).Item(6) Is DBNull.Value Then
                    .R_OK_Part = "0"
                Else
                    .R_OK_Part = dtRecovery.Rows(k).Item(6)
                End If

                If dtRecovery.Rows(k).Item(7) Is DBNull.Value Then
                    .R_Qty_Reject = "0"
                Else
                    .R_Qty_Reject = dtRecovery.Rows(k).Item(7)
                End If

                If dtRecovery.Rows(k).Item(8) Is DBNull.Value Then
                    .R_Lost = "0"
                Else
                    .R_Lost = dtRecovery.Rows(k).Item(8)
                End If

                If dtRecovery.Rows(k).Item(9) Is DBNull.Value Then
                    .R_Recovery1 = "0"
                Else
                    .R_Recovery1 = dtRecovery.Rows(k).Item(9)
                End If

                If dtRecovery.Rows(k).Item(10) Is DBNull.Value Then
                    .R_Recovery2 = "0"
                Else
                    .R_Recovery2 = dtRecovery.Rows(k).Item(10)
                End If

                If dtRecovery.Rows(k).Item(11) Is DBNull.Value Then
                    .R_Recovery3 = "0"
                Else
                    .R_Recovery3 = dtRecovery.Rows(k).Item(11)
                End If

                If dtRecovery.Rows(k).Item(12) Is DBNull.Value Then
                    .R_Total_Recovery = "0"
                Else
                    .R_Total_Recovery = dtRecovery.Rows(k).Item(12)
                End If

                If dtRecovery.Rows(k).Item(13) Is DBNull.Value Then
                    .R_Target_Recovery = "0"
                Else
                    .R_Target_Recovery = dtRecovery.Rows(k).Item(13)
                End If

                If dtRecovery.Rows(k).Item(14) Is DBNull.Value Then
                    .R_Balance_Recovery = "0"
                Else
                    .R_Balance_Recovery = dtRecovery.Rows(k).Item(14)
                End If

                If dtRecovery.Rows(k).Item(15) Is DBNull.Value Then
                    .R_Balance_OP = "0"
                Else
                    .R_Balance_OP = dtRecovery.Rows(k).Item(15)
                End If

                If dtRecovery.Rows(k).Item(16) Is DBNull.Value Then
                    .R_Keterangan = "0"
                Else
                    .R_Keterangan = dtRecovery.Rows(k).Item(16)
                End If

            End With
            fc_Class.ObjDetailInjectionRECOVERY.Add(ObjInjectionDetail)

        Next


#End Region

    End Sub


    Public Sub SetPlaningAktual()

#Region "Planging Aktual"

        'fc_Class.ObjDetailInjectionPA.Clear()

        'For l As Integer = 0 To dtRecovery.Rows.Count - 1

        'fc_Class = New InjectionModel
        With fc_Class

            .PA_IdTransaksi = fc_Class.IDTrans

            If dtPA.Rows(0).Item(1) Is DBNull.Value Or dtPA.Rows(0).Item(1).ToString = "#VALUE!" Then
                .PA_PLANING_JPH = "0"
            Else

                .PA_PLANING_JPH = dtPA.Rows(0).Item(1)
            End If

            If dtPA.Rows(1).Item(1) Is DBNull.Value Or dtPA.Rows(1).Item(1).ToString = "#VALUE!" Then
                .PA_ACTUAL_OK = "0"
            Else
                .PA_ACTUAL_OK = dtPA.Rows(1).Item(1)
            End If

            If dtPA.Rows(2).Item(1) Is DBNull.Value Or dtPA.Rows(2).Item(1).ToString = "#VALUE!" Then
                .PA_TOTAL_NG = "0"
            Else
                .PA_TOTAL_NG = dtPA.Rows(2).Item(1)
            End If

            If dtPA.Rows(3).Item(1) Is DBNull.Value Or dtPA.Rows(3).Item(1).ToString = "#VALUE!" Then
                .PA_LOSS_PRODUKSI = "0"
            Else
                .PA_LOSS_PRODUKSI = dtPA.Rows(3).Item(1)
            End If

            If dtPA.Rows(4).Item(1) Is DBNull.Value Or dtPA.Rows(4).Item(1).ToString = "#VALUE!" Then
                .PA_TARGET_RECOVERY = "0"
            Else
                .PA_TARGET_RECOVERY = dtPA.Rows(4).Item(1)
            End If

            If dtPA.Rows(5).Item(1) Is DBNull.Value Or dtPA.Rows(5).Item(1).ToString = "#VALUE!" Then
                .PA_RECOVERY = "0"
            Else
                .PA_RECOVERY = dtPA.Rows(5).Item(1)
            End If

            If dtPA.Rows(6).Item(1) Is DBNull.Value Or dtPA.Rows(6).Item(1).ToString = "#VALUE!" Then
                .PA_BALANCE_RECOVERY = "0"
            Else
                .PA_BALANCE_RECOVERY = dtPA.Rows(6).Item(1)
            End If

            If dtPA.Rows(7).Item(1) Is DBNull.Value Or dtPA.Rows(7).Item(1).ToString = "#VALUE!" Then
                .PA_TOTAL_PRODUKSI = "0"
            Else
                .PA_TOTAL_PRODUKSI = dtPA.Rows(7).Item(1)
            End If

            If dtPA.Rows(8).Item(1) Is DBNull.Value Or dtPA.Rows(8).Item(1).ToString = "#VALUE!" Then
                .PA_PRODUCTIVITY = "0"
            Else
                .PA_PRODUCTIVITY = dtPA.Rows(8).Item(1)
            End If

            If dtPA.Rows(9).Item(1) Is DBNull.Value Or dtPA.Rows(9).Item(1).ToString = "#VALUE!" Then
                .PA_STRAIGHT_PASS = "0"
            Else
                .PA_STRAIGHT_PASS = dtPA.Rows(9).Item(1)
            End If




        End With
        'fc_Class.ObjDetailInjectionPA.Add(ObjInjectionDetail)

        ' Next


#End Region

    End Sub




    Public Sub SetRejectRate()

#Region "Reject Rate"

        'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

        With fc_Class

            .RR_IdTransaksi = fc_Class.IDTrans

            If dtReject.Rows(0).Item(1) Is DBNull.Value Then
                .RR_SCRAP_DANDORI = fc_Class.IDTrans
            Else
                .RR_SCRAP_DANDORI = Math.Round(Val(dtReject.Rows(0).Item(1)), 2)
            End If

            If dtReject.Rows(1).Item(1) Is DBNull.Value Then
                .RR_PCS_SCRAP_DANDORI = "0"
            Else
                .RR_PCS_SCRAP_DANDORI = Math.Round(Val(dtReject.Rows(1).Item(1)), 2)
            End If


            If dtReject.Rows(2).Item(1) Is DBNull.Value Then
                .RR_SCRAP_ISTIRAHAT = "0"
            Else
                .RR_SCRAP_ISTIRAHAT = Math.Round(Val(dtReject.Rows(2).Item(1)), 2)
            End If

            If dtReject.Rows(3).Item(1) Is DBNull.Value Then
                .RR_PCS_SCRAP_ISTIRAHAT = "0"
            Else
                .RR_PCS_SCRAP_ISTIRAHAT = Math.Round(Val(dtReject.Rows(3).Item(1)), 2)
            End If

            If dtReject.Rows(4).Item(1) Is DBNull.Value Then
                .RR_SCRAP_SETTING = "0"
            Else
                .RR_SCRAP_SETTING = Math.Round(Val(dtReject.Rows(4).Item(1)), 2)
            End If

            If dtReject.Rows(5).Item(1) Is DBNull.Value Then
                .RR_PCS_SCRAP_SETTING = "0"
            Else
                .RR_PCS_SCRAP_SETTING = Math.Round(Val(dtReject.Rows(5).Item(1)), 2)
            End If

            If dtReject.Rows(6).Item(1) Is DBNull.Value Then
                .RR_NG_PROSES = "0"
            Else
                .RR_NG_PROSES = Math.Round(Val(dtReject.Rows(6).Item(1)), 2)
            End If

            If dtReject.Rows(7).Item(1) Is DBNull.Value Then
                .RR_PCS_NG_PROSES = "0"
            Else
                .RR_PCS_NG_PROSES = Math.Round(Val(dtReject.Rows(7).Item(1)), 2)
            End If

            If dtReject.Rows(8).Item(1) Is DBNull.Value Then
                .RR_NG = "0"
            Else
                .RR_NG = Math.Round(Val(dtReject.Rows(8).Item(1)), 2)
            End If

            If dtReject.Rows(9).Item(1) Is DBNull.Value Then
                .RR_TOTAL_NG = "0"
            Else
                .RR_TOTAL_NG = Math.Round(Val(dtReject.Rows(9).Item(1)), 2)
            End If

            If dtReject.Rows(10).Item(1) Is DBNull.Value Then
                .RR_TARGETNG = "0"
            Else
                .RR_TARGETNG = Math.Round(Val(dtReject.Rows(10).Item(1)), 2)
            End If

            If dtReject.Rows(11).Item(1) Is DBNull.Value Then
                .RR_TARGET_SCRAP = "0"
            Else
                .RR_TARGET_SCRAP = Math.Round(Val(dtReject.Rows(11).Item(1)), 2)
            End If

            If dtReject.Rows(12).Item(1) Is DBNull.Value Then
                .RR_TARGET_SETTING = "0"
            Else
                .RR_TARGET_SETTING = Math.Round(Val(dtReject.Rows(12).Item(1)), 2)
            End If

            If dtReject.Rows(13).Item(1) Is DBNull.Value Then
                .RR_Target_Persen_NG = "0"
            Else
                .RR_Target_Persen_NG = Math.Round(Val(dtReject.Rows(13).Item(1)), 2)
            End If

            If dtReject.Rows(14).Item(1) Is DBNull.Value Then
                .RR_Total_Produksi = "0"
            Else
                .RR_Total_Produksi = Math.Round(Val(dtReject.Rows(14).Item(1)), 2)
            End If


        End With

#End Region

    End Sub

    Private Sub BtnUploadExcel_Click_1(sender As Object, e As EventArgs) Handles BtnUploadExcel.Click


        fc_Class.H_date = Format(CDate(dtTanggal.Value))

        dtLimaBesar = New DataTable
        dtPPA = New DataTable
        dtRecovery = New DataTable
        dtPA = New DataTable
        dtReject = New DataTable


        ProgressBar1.Value = 0
        TxtFileName.Text = ""
        Timer1.Stop()
        GetKolom()

        Dim LimaBesar As String = "5BESAR$B5:z1000"
        Dim PPA As String = "PROBLEM_PLAN_ACTUAL$B4:z5000"
        Dim Recovery As String = "RECOVERY$B4:Z1000"
        Dim PA As String = "PLAN_ACTUAL$A7:AG30"
        Dim Reject As String = "REJECT RATE$C4:Aj30"
        Dim cek As String = ""

        Dim tanggal As Date = Format(dtTanggal.Value, "yyyy-MM-dd")
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}

            If ofd.ShowDialog() = DialogResult.OK Then
                FileLokasi = ofd.FileName
                TxtFileName.Text = FileLokasi
                '_filelokasi.Text = FileLokasi
                If IO.File.Exists(FileLokasi) Then
                    Dim cbLimaBesar As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbLimaBesar.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbLimaBesar.ConnectionString}
                    cn.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [" & LimaBesar & "] where F1 =  #" & tanggal & "#", cn) '
                    'Dim dtLimaBesar As New DataTable
                    dtLimaBesar = New DataTable
                    dtLimaBesar.Load(cmd.ExecuteReader)

                    Dim cbPPA As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbPPA.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn1 As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbPPA.ConnectionString}
                    cn1.Open()
                    Dim cmd1 As OleDbCommand = New OleDbCommand("SELECT * FROM [" & PPA & "] where F1 = #" & tanggal & "# ", cn1) '
                    'Dim dtPPA As New DataTable
                    dtPPA = New DataTable
                    dtPPA.Load(cmd1.ExecuteReader)

                    Dim cbRecovery As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbRecovery.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn2 As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbRecovery.ConnectionString}
                    cn2.Open()
                    Dim cmd2 As OleDbCommand = New OleDbCommand("SELECT * FROM [" & Recovery & "] where F1 = #" & tanggal & "# ", cn2) '
                    'Dim dtRecovery As New DataTable
                    dtRecovery = New DataTable
                    dtRecovery.Load(cmd2.ExecuteReader)

                    Dim cbPA As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbPA.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn3 As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbPA.ConnectionString}
                    cn3.Open()
                    Dim cmd3 As OleDbCommand = New OleDbCommand("SELECT F1 as Description," & KolomTanggal & " as Nilai FROM [" & PA & "] where F1 <> '' ", cn3) '
                    'Dim dtPA As New DataTable
                    dtPA = New DataTable
                    dtPA.Load(cmd3.ExecuteReader)

                    Dim cbReject As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbReject.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn4 As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbReject.ConnectionString}
                    cn4.Open()
                    Dim cmd4 As OleDbCommand = New OleDbCommand("SELECT F1 as Description," & KolomTanggalReject & " as Nilai FROM [" & Reject & "] where F1 <> ''", cn4) '
                    'Dim dtReject As New DataTable
                    dtReject = New DataTable
                    dtReject.Load(cmd4.ExecuteReader)


                    Dim cbPPA_Mold As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbPPA_Mold.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn1_mold As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbPPA_Mold.ConnectionString}
                    cn1_mold.Open()
                    Dim cmd1_Mold As OleDbCommand = New OleDbCommand("SELECT SUM (F11) as Mold FROM [" & PPA & "] where F1 = #" & tanggal & "#  and F14 = 'MOLD'", cn1_mold) '
                    'Dim dtPPA As New DataTable
                    dtPPA_Mold = New DataTable
                    dtPPA_Mold.Load(cmd1_Mold.ExecuteReader)


                    Dim cbPPA_Mesin As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbPPA_Mesin.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn1_Mesin As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbPPA_Mesin.ConnectionString}
                    cn1_Mesin.Open()
                    Dim cmd1_Mesin As OleDbCommand = New OleDbCommand("SELECT SUM (F11) as Mesin FROM [" & PPA & "] where F1 = #" & tanggal & "#  and F14 = 'MESIN'", cn1_Mesin) '
                    'Dim dtPPA As New DataTable
                    dtPPA_Mesin = New DataTable
                    dtPPA_Mesin.Load(cmd1_Mesin.ExecuteReader)

#Region "Maintenance"
                    If dtPPA_Mold.Rows(0).Item(0) Is DBNull.Value Then
                        fc_Class.Aktual_Mold = "0"
                    Else
                        fc_Class.Aktual_Mold = dtPPA_Mold.Rows(0).Item(0)
                    End If


                    If dtPPA_Mesin.Rows(0).Item(0) Is DBNull.Value Then
                        fc_Class.Aktual_Mesin = "0"
                    Else
                        fc_Class.Aktual_Mesin = dtPPA_Mesin.Rows(0).Item(0)
                    End If
#End Region




#Region "Lima Besar"

                    fc_Class.ObjDetailInjectionLB.Clear()

                    For i As Integer = 0 To dtLimaBesar.Rows.Count - 1

                        ObjInjectionDetail = New InjectionDetailModel
                        With ObjInjectionDetail
                            .LB_IdTransaksi = fc_Class.IDTrans
                            .LB_Shift = dtLimaBesar.Rows(i).Item(1).ToString
                            .LB_NoMC = dtLimaBesar.Rows(i).Item(2).ToString
                            .LB_invtId = dtLimaBesar.Rows(i).Item(3).ToString
                            .LB_InvtName = dtLimaBesar.Rows(i).Item(4).ToString

                            If dtLimaBesar.Rows(i).Item(5) Is DBNull.Value Then
                                .LB_OK = "0"
                            Else
                                .LB_OK = dtLimaBesar.Rows(i).Item(5)
                            End If

                            If dtLimaBesar.Rows(i).Item(6) Is DBNull.Value Then
                                .LB_Scrap_Dandori = "0"
                            Else
                                .LB_Scrap_Dandori = dtLimaBesar.Rows(i).Item(6)
                            End If

                            If dtLimaBesar.Rows(i).Item(7) Is DBNull.Value Then
                                .LB_Scrap_Istirahat = "0"
                            Else
                                .LB_Scrap_Istirahat = dtLimaBesar.Rows(i).Item(7)
                            End If

                            If dtLimaBesar.Rows(i).Item(8) Is DBNull.Value Then
                                .LB_NG_Setting = "0"
                            Else
                                .LB_NG_Setting = dtLimaBesar.Rows(i).Item(8)
                            End If

                            If dtLimaBesar.Rows(i).Item(9) Is DBNull.Value Then
                                .LB_NG_Proses = "0"
                            Else
                                .LB_NG_Proses = dtLimaBesar.Rows(i).Item(9)
                            End If

                            If dtLimaBesar.Rows(i).Item(10) Is DBNull.Value Then
                                .LB_NGPersen = "0"
                            Else
                                .LB_NGPersen = dtLimaBesar.Rows(i).Item(10)
                            End If

                            If dtLimaBesar.Rows(i).Item(11) Is DBNull.Value Then
                                .LB_Jens_NG_Proses = "0"
                            Else
                                .LB_Jens_NG_Proses = dtLimaBesar.Rows(i).Item(11)
                            End If

                            If dtLimaBesar.Rows(i).Item(12) Is DBNull.Value Then
                                .LB_Analisa_Problem_4_M = "0"
                            Else
                                .LB_Analisa_Problem_4_M = dtLimaBesar.Rows(i).Item(12)
                            End If

                            If dtLimaBesar.Rows(i).Item(13) Is DBNull.Value Then
                                .LB_Perbaikan_Sementara = ""
                            Else
                                .LB_Perbaikan_Sementara = dtLimaBesar.Rows(i).Item(13)
                            End If

                            If dtLimaBesar.Rows(i).Item(14) Is DBNull.Value Then
                                .LB_Perbaikan_Permanen = ""
                            Else
                                .LB_Perbaikan_Permanen = dtLimaBesar.Rows(i).Item(14)
                            End If

                            If dtLimaBesar.Rows(i).Item(15) Is DBNull.Value Then
                                .LB_PIC = ""
                            Else
                                .LB_PIC = dtLimaBesar.Rows(i).Item(15)
                            End If

                            'If dtLimaBesar.Rows(i).Item(16) Is DBNull.Value Then
                            '    .LB_Target = ""
                            'Else
                            '    .LB_Target = dtLimaBesar.Rows(i).Item(16)
                            'End If

                            If dtLimaBesar.Rows(i).Item(17) Is DBNull.Value Then
                                .LB_Status = ""
                            Else
                                .LB_Status = dtLimaBesar.Rows(i).Item(17)
                            End If

                        End With
                        fc_Class.ObjDetailInjectionLB.Add(ObjInjectionDetail)

                    Next


#End Region
                    'Call SetLimaBesar()
                    Call SetPPA()
                    Call SetRecovery()
                    Call SetPlaningAktual()
                    Call SetRejectRate()

                    cn.Close()
                    cn1.Close()
                    cn2.Close()
                    cn3.Close()
                    cn4.Close()
                    Timer1.Start()

                    fc_Class.GetTargetMold()
                    fc_Class.GetTargetMesin()



                End If
            End If
        End Using
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
        End If
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim IDTrans As String = ""

        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()

            If GridView1.RowCount > 0 Then
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "IdTransaksi")
                    End If
                Next rowHandle

                fc_Class.Delete(IDTrans)
                Call LoadGrid()
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            Else
                MessageBox.Show("No Data Found")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub dtTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtTanggal.ValueChanged
        TxtFileName.Text = ""
    End Sub
End Class
