Imports System.Collections.ObjectModel
Public Class InjectionModel


    Dim _Query As String
    Public Property IDTrans As String
    Public Property H_CreatedBy As Char
    Public Property H_CreatedDate As DateTime
    Public Property H_date As DateTime
    Public Property H_UpdatedBy As Char
    Public Property H_UpdatedDate As DateTime

    Public Property ObjDetailInjectionLB() As New Collection(Of InjectionDetailModel)
    Public Property ObjDetailInjectionPPA() As New Collection(Of InjectionDetailModel)
    Public Property ObjDetailInjectionPA() As New Collection(Of InjectionDetailModel)
    Public Property ObjDetailInjectionREJECT() As New Collection(Of InjectionDetailModel)
    Public Property ObjDetailInjectionRECOVERY() As New Collection(Of InjectionDetailModel)

#Region "Planing aktual"

    Public Property PA_ACTUAL_OK As Integer
    Public Property PA_BALANCE_RECOVERY As Integer
    Public Property PA_IdTransaksi As String
    Public Property PA_LOSS_PRODUKSI As Integer
    Public Property PA_PLANING_JPH As Integer
    Public Property PA_PRODUCTIVITY As Double
    Public Property PA_RECOVERY As Integer
    Public Property PA_STRAIGHT_PASS As Double
    Public Property PA_TARGET_RECOVERY As Integer
    Public Property PA_TOTAL_NG As Integer
    Public Property PA_TOTAL_PRODUKSI As Integer


#End Region


#Region "Reject Rate"
    Public Property RR_SCRAP_DANDORI As Double
    Public Property RR_TOTAL_NG As Double
    Public Property RR_TARGETNG As Double
    Public Property RR_PCS_SCRAP_DANDORI As Double
    Public Property RR_SCRAP_ISTIRAHAT As Double
    Public Property RR_PCS_SCRAP_ISTIRAHAT As Double
    Public Property RR_SCRAP_SETTING As Double
    Public Property RR_PCS_SCRAP_SETTING As Double
    Public Property RR_NG_PROSES As Double
    Public Property RR_PCS_NG_PROSES As Double
    Public Property RR_NG As Double
    Public Property RR_IdTransaksi As String
    Public Property RR_TARGET_SCRAP As Double
    Public Property RR_TARGET_SETTING As Double
    Public Property RR_Target_Persen_NG As Double
    Public Property RR_Total_Produksi As Double


#End Region

#Region "Maintenance"
    Public Property Aktual_Mold As Double
    Public Property Aktual_Mesin As Double

    Public Property Target_Mold As Double
    Public Property Target_Mesin As Double

    Public Sub GetTargetMold()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [1. Target] as Target,Tanggal                 
                                    FROM [AsakaiMaintenaceDTMold] where Tanggal = '" & H_date & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Target_Mold = dtTable.Rows(0).Item("Target")
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub GetTargetMesin()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [1. Target] as Target,Tanggal                 
                                    FROM [AsakaiMaintenaceDTMesin] where Tanggal = '" & H_date & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Target_Mesin = dtTable.Rows(0).Item("Target")
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IdTransaksi],Tanggal                   
                                    FROM [AsakaiInjectionHeader] where Tanggal = '" & H_date & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.H_date & " ")

            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub New()
        Me._Query = "SELECT IdTransaksi,CONVERT(varchar,Tanggal,105) as Tanggal  FROM AsakaiInjectionHeader order by IdTransaksi Desc "
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetIDTransAuto()
        Dim fc_ClassDetail As New InjectionDetailModel
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT [IdTransaksi]                   
                                    FROM [AsakaiInjectionHeader] order by IdTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "INJ" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IdTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 4, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "INJ" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IdTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 6, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "INJ" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "INJ" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "INJ" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "INJ" & Tahun & IDTrans & ""
                    End If

                End If

            End If

            fc_ClassDetail.D_IdTransaksi = IDTrans

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertInjection()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader()


                        For i As Integer = 0 To ObjDetailInjectionLB.Count - 1
                            With ObjDetailInjectionLB(i)
                                .InsertInjectionDetailsLB(IDTrans)
                            End With
                        Next

                        For j As Integer = 0 To ObjDetailInjectionPPA.Count - 1
                            With ObjDetailInjectionPPA(j)
                                .InsertInjectionDetailsPPA(IDTrans)
                            End With
                        Next


                        For k As Integer = 0 To ObjDetailInjectionRECOVERY.Count - 1
                            With ObjDetailInjectionRECOVERY(k)
                                .InsertInjectionDetailsRecovery(IDTrans)
                            End With
                        Next


                        InsertInjectionDetailsPlanAktual()
                        InsertInjectionDetailsRejectRate()
                        UpdateDTMold()
                        UpdateDTMesin()


                        Trans1.Commit()

                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub InsertInjectionDetailsPlanAktual()
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiInjectionPA]
                        ([IdTransaksi]
                       ,[Tanggal]
                       ,[A. PLANING JPH]
                       ,[B. ACTUAL OK]
                       ,[C. TOTAL NG]
                       ,[D. LOSS PRODUKSI]
                       ,[E. TARGET RECOVERY]
                       ,[F. RECOVERY]
                       ,[G. BALANCE RECOVERY]
                       ,[H. TOTAL PRODUKSI]
                       ,[I. PRODUCIVITY]
                       ,[J. STRAIGHT PASS]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(H_date) & ", " & vbCrLf &
            "       " & QVal(PA_PLANING_JPH) & ", " & vbCrLf &
            "       " & QVal(PA_ACTUAL_OK) & ", " & vbCrLf &
            "       " & QVal(PA_TOTAL_NG) & ", " & vbCrLf &
            "       " & QVal(PA_LOSS_PRODUKSI) & ", " & vbCrLf &
            "       " & QVal(PA_TARGET_RECOVERY) & ", " & vbCrLf &
            "       " & QVal(PA_RECOVERY) & ", " & vbCrLf &
            "       " & QVal(PA_BALANCE_RECOVERY) & ", " & vbCrLf &
            "       " & QVal(PA_TOTAL_PRODUKSI) & ", " & vbCrLf &
            "       " & QVal(PA_PRODUCTIVITY) & ", " & vbCrLf &
            "       " & QVal(PA_STRAIGHT_PASS) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertInjectionDetailsRejectRate()
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiInjectionRejectRate]
                        ([IdTransaksi]
                       ,Tanggal
                       ,[A. % SCRAP DANDORI]
                       ,[B. PCS SCRAP DANDORI]
                       ,[C. % SCRAP ISTIRAHAT]
                       ,[D. PCS SCRAP ISTIRAHAT]
                       ,[E. % SCRAP SETTING]
                       ,[F. PCS SCRAP SETTING]
                       ,[G. % NG PROSES]
                       ,[H. PCS NG PROSES]
                       ,[I. % NG]
                       ,[J. TOTAL NG]
                       ,[K. TARGET NG]
                       ,[L. TARGET SCRAP]
                       ,[M. TARGET SETTING]
                       ,[N. TARGET % NG]
                       ,[O.TOTAL PRODUKSI]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(H_date) & ", " & vbCrLf &
            "       " & QVal(RR_SCRAP_DANDORI) & ", " & vbCrLf &
            "       " & QVal(RR_PCS_SCRAP_DANDORI) & ", " & vbCrLf &
            "       " & QVal(RR_SCRAP_ISTIRAHAT) & ", " & vbCrLf &
            "       " & QVal(RR_PCS_SCRAP_ISTIRAHAT) & ", " & vbCrLf &
            "       " & QVal(RR_SCRAP_SETTING) & ", " & vbCrLf &
            "       " & QVal(RR_PCS_SCRAP_SETTING) & ", " & vbCrLf &
            "       " & QVal(RR_NG_PROSES) & ", " & vbCrLf &
            "       " & QVal(RR_PCS_NG_PROSES) & ", " & vbCrLf &
            "       " & QVal(RR_NG) & ", " & vbCrLf &
            "       " & QVal(RR_TOTAL_NG) & ", " & vbCrLf &
            "       " & QVal(RR_TARGETNG) & ", " & vbCrLf &
            "       " & QVal(RR_TARGET_SCRAP) & ", " & vbCrLf &
            "       " & QVal(RR_TARGET_SETTING) & ", " & vbCrLf &
            "       " & QVal(RR_Target_Persen_NG) & ", " & vbCrLf &
            "       " & QVal(RR_Total_Produksi) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertHeader()
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiInjectionHeader]
                                           ([IdTransaksi]
                                           ,[Tanggal]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(IDTrans) & " 
                                            ," & QVal(Me.H_date) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateDTMold()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiMaintenaceDTMold" & vbCrLf &
                                    "SET [2. Aktual] = " & Math.Round(QVal(Aktual_Mold), 2) & ", " & vbCrLf &
                                    "    [3. Balance] = " & Math.Round(QVal(Aktual_Mold - Target_Mold), 2) & ", " & vbCrLf &
                                    "    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE Tanggal = '" & H_date & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateDTMesin()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiMaintenaceDTMesin" & vbCrLf &
                                    "SET [2. Aktual] = " & QVal(Aktual_Mesin) & ", " & vbCrLf &
                                    "    [3. Balance] = " & QVal(Aktual_Mesin - Target_Mesin) & ", " & vbCrLf &
                                    "    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE Tanggal = '" & H_date & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiInjectionHeader WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeletePA As String = "DELETE FROM AsakaiInjectionPA WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeletePA)

            Dim ls_DeleteRecovery As String = "DELETE FROM AsakaiInjectionRecovery WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteRecovery)

            Dim ls_DeleteRejectRate As String = "DELETE FROM AsakaiInjectionRejectRate WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteRejectRate)

            Dim ls_DeletePPA As String = "DELETE FROM AsakaiInjectioPPA WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeletePPA)

            Dim ls_DeleteLima As String = "DELETE FROM AsakaiJnjectionLimaBesar WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteLima)

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class




Public Class InjectionDetailModel

    Public Property D_date As DateTime
    Public Property D_IdTransaksi As String

#Region "LB"
    Public Property LB_Analisa_Problem_4_M As String
    Public Property LB_IdTransaksi As String
    Public Property LB_invtId As String
    Public Property LB_InvtName As String
    Public Property LB_Jens_NG_Proses As String
    Public Property LB_NGPersen As Double
    Public Property LB_NG_Proses As Double
    Public Property LB_NG_Setting As Double
    Public Property LB_NoMC As String
    Public Property LB_OK As Double
    Public Property LB_Perbaikan_Permanen As String
    Public Property LB_Perbaikan_Sementara As String
    Public Property LB_PIC As String
    Public Property LB_Scrap_Dandori As Double
    Public Property LB_Scrap_Istirahat As Double
    Public Property LB_Shift As String
    Public Property LB_Status As String
    Public Property LB_Target As DateTime
#End Region


#Region "PPA"

    Public Property PPA_Analisa As String
    Public Property PPA_Grup_Leader As String
    Public Property PPA_IdTransaksi As String
    Public Property PPA_invtId As String
    Public Property PPA_InvtName As String
    Public Property PPA_Jam_Dari As String
    Public Property PPA_Jam_Sampai As String
    Public Property PPA_Kategori As String
    Public Property PPA_LossJam As String
    Public Property PPA_Loss_Produksi As Integer
    Public Property PPA_NoMC As String
    Public Property PPA_Perbaikan_Permanen As String
    Public Property PPA_Perbaikan_Sementara As String
    Public Property PPA_PIC As String
    Public Property PPA_Problem As String
    Public Property PPA_Shift As String
    Public Property PPA_Status As String
    Public Property PPA_Targer_Per_Jam As Integer
    Public Property PPA_Target As DateTime

#End Region

#Region "Recovery"

    Public Property R_Balance_OP As Integer
    Public Property R_Balance_Recovery As Integer
    Public Property R_IdTransaksi As String
    Public Property R_invtId As String
    Public Property R_InvtName As String
    Public Property R_Keterangan As String
    Public Property R_Kode_Part As String
    Public Property R_NoMC As String
    Public Property R_OK_Part As Integer
    Public Property R_Plan As Integer
    Public Property R_Qty_Reject As Integer
    Public Property R_Recovery1 As Integer
    Public Property R_Recovery2 As Integer
    Public Property R_Recovery3 As Integer
    Public Property R_Target_Recovery As Integer
    Public Property R_Total_Recovery As Integer
    Public Property R_Lost As String

#End Region


#Region "PA"

    Public Property PA_ACTUAL_OK As Integer
    Public Property PA_BALANCE_RECOVERY As Integer
    Public Property PA_IdTransaksi As String
    Public Property PA_LOSS_PRODUKSI As Integer
    Public Property PA_PLANING_JPH As Integer
    Public Property PA_PRODUCTIVITY As Double
    Public Property PA_RECOVERY As Integer
    Public Property PA_STRAIGHT_PASS As Double
    Public Property PA_TARGET_RECOVERY As Integer
    Public Property PA_TOTAL_NG As Integer
    Public Property PA_TOTAL_PRODUKSI As Integer

#End Region

#Region "Reject Rate"
    Public Property RR_SCRAP_DANDORI As Double
    Public Property RR_TOTAL_NG As Double
    Public Property RR_TARGETNG As Double
    Public Property RR_PCS_SCRAP_DANDORI As Double
    Public Property RR_SCRAP_ISTIRAHAT As Double
    Public Property RR_PCS_SCRAP_ISTIRAHAT As Double
    Public Property RR_SCRAP_SETTING As Double
    Public Property RR_PCS_SCRAP_SETTING As Double
    Public Property RR_NG_PROSES As Double
    Public Property RR_PCS_NG_PROSES As Double
    Public Property RR_NG As Double
    Public Property RR_IdTransaksi As String
#End Region

    Public Sub InsertInjectionDetailsLB(IDTrans As String)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiJnjectionLimaBesar]
                        ([IdTransaksi]
                           ,[Shift]
                           ,[NoMC]
                           ,[invtId]
                           ,[InvtName]
                           ,[OK]
                           ,[Scrap Dandori]
                           ,[Scrap Istirahat]
                           ,[NG Setting]
                           ,[NG Proses]
                           ,[NG%]
                           ,[Jens NG Proses]
                           ,[Analisa Problem 4 M]
                           ,[Perbaikan Sementara]
                           ,[Perbaikan Permanen]
                           ,[PIC]
                           ,[Target]
                           ,[Status]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(LB_Shift) & ", " & vbCrLf &
            "       " & QVal(LB_NoMC) & ", " & vbCrLf &
            "       " & QVal(LB_invtId) & ", " & vbCrLf &
            "       " & QVal(LB_InvtName) & ", " & vbCrLf &
            "       " & QVal(LB_OK) & ", " & vbCrLf &
            "       " & QVal(LB_Scrap_Dandori) & ", " & vbCrLf &
            "       " & QVal(LB_Scrap_Istirahat) & ", " & vbCrLf &
            "       " & QVal(LB_NG_Setting) & ", " & vbCrLf &
            "       " & QVal(LB_NG_Proses) & ", " & vbCrLf &
            "       " & QVal(LB_NGPersen) & ", " & vbCrLf &
            "       " & QVal(LB_Jens_NG_Proses) & ", " & vbCrLf &
            "       " & QVal(LB_Analisa_Problem_4_M) & ", " & vbCrLf &
            "       " & QVal(LB_Perbaikan_Sementara) & ", " & vbCrLf &
            "       " & QVal(LB_Perbaikan_Permanen) & ", " & vbCrLf &
            "       " & QVal(LB_PIC) & ", " & vbCrLf &
            "       " & QVal(LB_Target) & ", " & vbCrLf &
            "       " & QVal(LB_Status) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertInjectionDetailsPPA(IDTrans As String)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiInjectioPPA]
                        ([IdTransaksi]
                           ,[NoMC]
                           ,[Shift]
                           ,[Grup Leader]
                           ,[invtId]
                           ,[InvtName]
                           ,[Targer Per Jam]
                           ,[Jam Dari]
                           ,[Jam Sampai]
                           ,[Loss]
                           ,[Loss Produksi]
                           ,[Problem]
                           ,[Kategori]
                           ,[Analisa]
                           ,[Perbaikan Sementara]
                           ,[Perbaikan Permanen]
                           ,[PIC]
                           ,[Target]
                           ,[Status]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(PPA_NoMC) & ", " & vbCrLf &
            "       " & QVal(PPA_Shift) & ", " & vbCrLf &
            "       " & QVal(PPA_Grup_Leader) & ", " & vbCrLf &
            "       " & QVal(PPA_invtId) & ", " & vbCrLf &
            "       " & QVal(PPA_InvtName) & ", " & vbCrLf &
            "       " & QVal(PPA_Targer_Per_Jam) & ", " & vbCrLf &
            "       " & QVal(PPA_Jam_Dari) & ", " & vbCrLf &
            "       " & QVal(PPA_Jam_Sampai) & ", " & vbCrLf &
            "       " & QVal(PPA_LossJam) & ", " & vbCrLf &
            "       " & QVal(PPA_Loss_Produksi) & ", " & vbCrLf &
            "       " & QVal(PPA_Problem) & ", " & vbCrLf &
            "       " & QVal(PPA_Kategori) & ", " & vbCrLf &
            "       " & QVal(PPA_Analisa) & ", " & vbCrLf &
            "       " & QVal(PPA_Perbaikan_Sementara) & ", " & vbCrLf &
            "       " & QVal(PPA_Perbaikan_Permanen) & ", " & vbCrLf &
            "       " & QVal(PPA_PIC) & ", " & vbCrLf &
            "       " & QVal(PPA_Target) & ", " & vbCrLf &
            "       " & QVal(PPA_Status) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertInjectionDetailsRecovery(IDTrans As String)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiInjectionRecovery]
                        ([IdTransaksi]
                       ,[NoMC]
                       ,[Kode Part]
                       ,[invtId]
                       ,[InvtName]
                       ,[Plan]
                       ,[OK Part]
                       ,[Qty Reject]
                       ,[Recovery1]
                       ,[Recovery2]
                       ,[Recovery3]
                       ,[Total Recovery]
                       ,[Target Recovery]
                       ,[Balance Recovery]
                       ,[Balance OP]
                       ,[Keterangan]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(R_NoMC) & ", " & vbCrLf &
            "       " & QVal(R_Kode_Part) & ", " & vbCrLf &
            "       " & QVal(R_invtId) & ", " & vbCrLf &
            "       " & QVal(R_InvtName) & ", " & vbCrLf &
            "       " & QVal(R_Plan) & ", " & vbCrLf &
            "       " & QVal(R_OK_Part) & ", " & vbCrLf &
            "       " & QVal(R_Qty_Reject) & ", " & vbCrLf &
            "       " & QVal(R_Recovery1) & ", " & vbCrLf &
            "       " & QVal(R_Recovery2) & ", " & vbCrLf &
            "       " & QVal(R_Recovery3) & ", " & vbCrLf &
            "       " & QVal(R_Total_Recovery) & ", " & vbCrLf &
            "       " & QVal(R_Target_Recovery) & ", " & vbCrLf &
            "       " & QVal(R_Balance_Recovery) & ", " & vbCrLf &
            "       " & QVal(R_Balance_OP) & ", " & vbCrLf &
            "       " & QVal(R_Keterangan) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub




End Class