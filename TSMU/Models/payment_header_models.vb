Imports System.Collections.ObjectModel

Public Class payment_header_models
    Public Property BankID As String
    Public Property BankName As String
    Public Property bankrek As String
    Public Property Biaya_Transfer As Double
    Public Property cek1 As Boolean
    Public Property cek2 As Boolean
    Public Property cek3 As Boolean
    Public Property cek4 As Boolean
    Public Property CM_DM As Double
    Public Property CuryID As String
    Public Property Descr As String
    Public Property detsupplier As String
    Public Property id As Integer
    Public Property norek As String
    Public Property penerima As String
    Public Property PPh As Double
    Public Property prosespay As Boolean
    Public Property tgl As Nullable(Of DateTime)
    Public Property Tot_DPP As Double
    Public Property Tot_PPN As Double
    Public Property Total_DPP_PPN As Double
    Public Property uploaded As Boolean
    Public Property VendID As String
    Public Property VendorName As String
    Public Property VendorName2 As String
    Public Property vrno As String
    Public Property PerPost As String
    Public Property cmdm_manual As String
    Public Property cmdm_manual_ket As String
    Public Property ObjPaymentDetails() As New Collection(Of payment_detail_models)
    Public Property ObjBatch() As New Collection(Of batch)
    Public Function GetDataGrid() As DataTable
        Try
            Dim sql As String = "SELECT [id]
                ,[vrno]
                ,[tgl]
                ,[BankID]
                ,[BankName]
                ,[VendID]
                ,[VendorName]
                ,[Descr]
                ,[Tot_DPP]
                ,[Tot_PPN]
                ,[Total_DPP_PPN]
                ,[PPh]
                ,[Biaya_Transfer]
                ,[CM_DM]
                ,[CuryID]
                ,[cek1]
                ,[cek2]
                ,[cek3]
                ,[cek4]
                ,[prosespay]
                ,[uploaded]
                ,[detsupplier]
                ,[bankrek]
                ,[norek]
                ,[penerima]
                ,[cmdm_manual]
                ,[cmdm_manual_ket]
            FROM [Payment_Header1] Order By id desc"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub GetPaymentByVoucherNo()
        Try
            Dim sql As String = "SELECT [id]
                    ,[vrno]
                    ,[tgl]
                    ,[BankID]
                    ,[BankName]
                    ,[VendID]
                    ,[VendorName]
                    ,[Descr]
                    ,[Tot_DPP]
                    ,[Tot_PPN]
                    ,[Total_DPP_PPN]
                    ,[PPh]
                    ,[Biaya_Transfer]
                    ,[CM_DM]
                    ,[CuryID]
                    ,[cek1]
                    ,[cek2]
                    ,[cek3]
                    ,[cek4]
                    ,[prosespay]
                    ,[uploaded]
                    ,[detsupplier]
                    ,[bankrek]
                    ,[norek]
                    ,[penerima]
                    ,[cmdm_manual]
                    ,[cmdm_manual_ket]
                    FROM [Payment_Header1] where id=" & QVal(id) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                Me.id = If(IsDBNull(dt.Rows(0).Item("id")), "", Trim(dt.Rows(0).Item("id").ToString()))
                Me.BankID = If(IsDBNull(dt.Rows(0).Item("BankID")), "", Trim(dt.Rows(0).Item("BankID").ToString()))
                Me.BankName = If(IsDBNull(dt.Rows(0).Item("BankName")), "", Trim(dt.Rows(0).Item("BankName").ToString()))
                Me.bankrek = If(IsDBNull(dt.Rows(0).Item("bankrek")), "", Trim(dt.Rows(0).Item("bankrek").ToString()))
                Me.Biaya_Transfer = If(IsDBNull(dt.Rows(0).Item("Biaya_Transfer")), "", Convert.ToDouble(Trim(dt.Rows(0).Item("Biaya_Transfer"))))
                Me.cek1 = If(IsDBNull(dt.Rows(0).Item("cek1")), False, Convert.ToBoolean(Trim(dt.Rows(0).Item("cek1"))))
                Me.cek2 = If(IsDBNull(dt.Rows(0).Item("cek2")), False, Convert.ToBoolean(Trim(dt.Rows(0).Item("cek2"))))
                Me.cek3 = If(IsDBNull(dt.Rows(0).Item("cek3")), False, Convert.ToBoolean(Trim(dt.Rows(0).Item("cek3"))))
                Me.cek4 = If(IsDBNull(dt.Rows(0).Item("cek4")), False, Convert.ToBoolean(Trim(dt.Rows(0).Item("cek4"))))
                Me.CM_DM = If(IsDBNull(dt.Rows(0).Item("CM_DM")), 0, Convert.ToDouble(Trim(dt.Rows(0).Item("CM_DM"))))
                Me.CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Trim(dt.Rows(0).Item("CuryID").ToString()))
                Me.Descr = If(IsDBNull(dt.Rows(0).Item("Descr")), "", Trim(dt.Rows(0).Item("Descr").ToString()))
                Me.detsupplier = If(IsDBNull(dt.Rows(0).Item("detsupplier")), "", Trim(dt.Rows(0).Item("detsupplier").ToString()))
                Me.norek = If(IsDBNull(dt.Rows(0).Item("norek")), "", Trim(dt.Rows(0).Item("norek").ToString()))
                Me.penerima = If(IsDBNull(dt.Rows(0).Item("penerima")), "", Trim(dt.Rows(0).Item("penerima").ToString()))
                Me.PPh = If(IsDBNull(dt.Rows(0).Item("PPh")), "", Convert.ToDouble(Trim(dt.Rows(0).Item("PPh"))))
                Me.prosespay = If(IsDBNull(dt.Rows(0).Item("prosespay")), False, Convert.ToBoolean(Trim(dt.Rows(0).Item("prosespay"))))
                Me.tgl = If(IsDBNull(dt.Rows(0).Item("tgl")), DateTime.Today, Convert.ToDateTime(Trim(dt.Rows(0).Item("tgl"))))
                Me.Total_DPP_PPN = If(IsDBNull(dt.Rows(0).Item("Total_DPP_PPN")), 0, Convert.ToDouble(Trim(dt.Rows(0).Item("Total_DPP_PPN"))))
                Me.Tot_DPP = If(IsDBNull(dt.Rows(0).Item("Tot_DPP")), 0, Convert.ToDouble(Trim(dt.Rows(0).Item("Tot_DPP"))))
                Me.Tot_PPN = If(IsDBNull(dt.Rows(0).Item("Tot_PPN")), 0, Convert.ToDouble(Trim(dt.Rows(0).Item("Tot_PPN"))))
                Me.uploaded = If(IsDBNull(dt.Rows(0).Item("uploaded")), False, Convert.ToBoolean(Trim(dt.Rows(0).Item("uploaded"))))
                Me.VendID = If(IsDBNull(dt.Rows(0).Item("VendID")), "", Trim(dt.Rows(0).Item("VendID").ToString()))
                Me.VendorName = If(IsDBNull(dt.Rows(0).Item("VendorName")), "", Trim(dt.Rows(0).Item("VendorName").ToString()))
                Me.vrno = If(IsDBNull(dt.Rows(0).Item("vrno")), "", Trim(dt.Rows(0).Item("vrno").ToString()))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO Payment_Header1 (vrno,tgl,BankID,BankName,VendID,VendorName,Descr,CuryID,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,cek1,cek2,cek3,cek4,prosespay,uploaded,detsupplier,bankrek,norek,penerima,cmdm_manual,cmdm_manual_ket) " & vbCrLf &
                                    "Values(" & QVal(Me.vrno) & ", " & vbCrLf &
                                    "       " & QVal(Me.tgl) & ", " & vbCrLf &
                                    "       " & QVal(Me.BankID) & ", " & vbCrLf &
                                    "       " & QVal(Me.BankName) & ", " & vbCrLf &
                                    "       " & QVal(Me.VendID) & ", " & vbCrLf &
                                    "       " & QVal(Me.VendorName) & ", " & vbCrLf &
                                    "       " & QVal(Me.Descr) & ", " & vbCrLf &
                                    "       " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_DPP) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_PPN) & ", " & vbCrLf &
                                    "       " & QVal(Me.Total_DPP_PPN) & ", " & vbCrLf &
                                    "       " & QVal(Me.PPh) & ", " & vbCrLf &
                                    "       " & QVal(Me.Biaya_Transfer) & ", " & vbCrLf &
                                    "       " & QVal(Me.CM_DM) & ", " & vbCrLf &
                                    "       " & QVal(Me.cek1) & ", " & vbCrLf &
                                    "       " & QVal(Me.cek2) & ", " & vbCrLf &
                                    "       " & QVal(Me.cek3) & ", " & vbCrLf &
                                    "       " & QVal(Me.cek4) & ", " & vbCrLf &
                                    "       " & QVal(Me.prosespay) & ", " & vbCrLf &
                                    "       " & QVal(Me.uploaded) & ", " & vbCrLf &
                                    "       " & QVal(Me.detsupplier) & ", " & vbCrLf &
                                    "       " & QVal(Me.bankrek) & ", " & vbCrLf &
                                    "       " & QVal(Me.norek) & ", " & vbCrLf &
                                    "       " & QVal(Me.penerima) & ", " & vbCrLf &
                                    "       " & QVal(Me.cmdm_manual) & ", " & vbCrLf &
                                    "       " & QVal(Me.cmdm_manual_ket) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub InsertHeaderDir()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO Payment_Header1 (cek4) " & vbCrLf &
                                    "Values(" & QVal(Me.cek4) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub UpdateHeader(ByVal FpNo As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Update Payment_Header1 " & vbCrLf &
                                    "SET    tgl = " & QVal(Me.tgl) & ", " & vbCrLf &
                                    "       BankID = " & QVal(Me.BankID) & ", " & vbCrLf &
                                    "       BankName = " & QVal(Me.BankName) & ", " & vbCrLf &
                                    "       VendID = " & QVal(Me.VendID) & ", " & vbCrLf &
                                    "       VendorName = " & QVal(Me.VendorName) & ", " & vbCrLf &
                                    "       Descr = " & QVal(Me.Descr) & ", " & vbCrLf &
                                    "       CuryID = " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       Tot_DPP = " & QVal(Me.Tot_DPP) & ", " & vbCrLf &
                                    "       Tot_PPN = " & QVal(Me.Tot_PPN) & ", " & vbCrLf &
                                    "       Total_DPP_PPN = " & QVal(Me.Total_DPP_PPN) & ", " & vbCrLf &
                                    "       PPh = " & QVal(Me.PPh) & ", " & vbCrLf &
                                    "       Biaya_Transfer = " & QVal(Me.Biaya_Transfer) & ", " & vbCrLf &
                                    "       CM_DM = " & QVal(Me.CM_DM) & ", " & vbCrLf &
                                    "       cek1 = " & QVal(Me.cek1) & ", " & vbCrLf &
                                    "       cek2 = " & QVal(Me.cek2) & ", " & vbCrLf &
                                    "       cek3 = " & QVal(Me.cek3) & ", " & vbCrLf &
                                    "       cek4 = " & QVal(Me.cek4) & ", " & vbCrLf &
                                    "       prosespay = " & QVal(Me.prosespay) & ", " & vbCrLf &
                                    "       uploaded = " & QVal(Me.uploaded) & ", " & vbCrLf &
                                    "       detsupplier = " & QVal(Me.detsupplier) & ", " & vbCrLf &
                                    "       bankrek = " & QVal(Me.bankrek) & ", " & vbCrLf &
                                    "       norek = " & QVal(Me.norek) & ", " & vbCrLf &
                                    "       penerima = " & QVal(Me.penerima) & ", " & vbCrLf &
                                    "       cmdm_manual = " & QVal(Me.cmdm_manual) & ", " & vbCrLf &
                                    "       cmdm_manual_ket = " & QVal(Me.cmdm_manual_ket) & " " & vbCrLf &
                                    "where vrno = '" & Me.vrno & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeader()

                        For i As Integer = 0 To Me.ObjPaymentDetails.Count - 1
                            With Me.ObjPaymentDetails(i)
                                .InsertDetails()
                                .UpdateApDocUser4()
                            End With
                        Next

                        For i As Integer = 0 To Me.ObjBatch.Count - 1
                            With Me.ObjBatch(i)
                                .UpdateBatch(Me.vrno)
                            End With
                        Next
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataDir()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderDir()

                        For i As Integer = 0 To Me.ObjPaymentDetails.Count - 1
                            With Me.ObjPaymentDetails(i)
                                .InsertDetailsDir()
                                .UpdateApDocUser4()
                            End With
                        Next

                        For i As Integer = 0 To Me.ObjBatch.Count - 1
                            With Me.ObjBatch(i)
                                .UpdateBatch(Me.vrno)
                            End With
                        Next
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(vrno)

                        Dim PaymentDetails As New payment_detail_models
                        PaymentDetails.DeleteDetail(vrno)

                        For i As Integer = 0 To Me.ObjPaymentDetails.Count - 1
                            With Me.ObjPaymentDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDataDir()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(vrno)

                        Dim PaymentDetails As New payment_detail_models
                        PaymentDetails.DeleteDetail(vrno)

                        For i As Integer = 0 To Me.ObjPaymentDetails.Count - 1
                            With Me.ObjPaymentDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub CancelData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(vrno)

                        Dim PaymentDetails As New payment_detail_models
                        PaymentDetails.DeleteDetail(vrno)

                        For i As Integer = 0 To Me.ObjPaymentDetails.Count - 1
                            With Me.ObjPaymentDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function VoucherNo() As String
        Try
            Dim auto As String
            Dim query As String = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = '" & Mid(PerPost, 6, 2) & "' " &
                "set @tahun = '" & Mid(PerPost, 1, 4) & "' " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(vrno)),4)+1 as varchar),4) " &
                "from Payment_Header1 " &
                "where SUBSTRING(vrno,4,4) = @tahun AND SUBSTRING(vrno,9,2) = @bulan) " &
                "select 'AP' + '-' + @tahun + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetDataGridApprove(ByVal Level As Integer) As DataTable
        Dim sql As String = "SELECT 
                                id
                                ,vrno as VoucherNo
                                ,tgl Tanggal
                                ,BankName
                                ,CuryID
                                ,VendorName
                                ,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as PaidAmount
                                , cek1 as Level1, cek2 as Level2, cek3 as Level3, cek4 as Direktur 
                            FROM payment_header1 "
        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If Level = 1 Then
                sql = sql & " ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 2 Then
                sql = sql & " WHERE cek1 ='1' AND cek2='0' AND cek3='0' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 3 Then
                sql = sql & " WHERE cek1 ='1' AND cek2='1' AND cek3='0' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            Else
                sql = sql & " WHERE cek1 ='1' AND cek2='1' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            End If

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetDataGridApproveByBank(ByVal Level As Integer, BankID As String) As DataTable
        Dim sql As String = "	
			SELECT 
                                payment_header1.id
                                ,payment_header1.vrno as VoucherNo
                                ,payment_header1.tgl Tanggal
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
                                ,(sum(payment_detail1.dpp)+sum(payment_detail1.Ppn)-sum(payment_detail1.pph))-payment_header1.cm_dm-payment_header1.Biaya_Transfer as PaidAmount
                                , payment_header1.cek1 as Level1, payment_header1.cek2 as Level2, payment_header1.cek3 as Level3, payment_detail1.cek4 as CheckDetail, payment_header1.cek4 as Direktur 
                            FROM payment_detail1  inner join payment_header1 on payment_detail1.vrno=payment_header1.vrno  
							 
							 					
"
        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If Level = 1 Then
                sql = sql & " WHERE payment_header1.BankID = COALESCE(NULLIF('" & BankID & "',''),BankID) group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
                                ,Payment_Detail1.cek4
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            ElseIf Level = 2 Then
                sql = sql & " WHERE payment_header1.BankID = COALESCE(NULLIF('" & BankID & "',''),BankID) AND payment_header1.cek1 ='1' AND payment_header1.cek2='0' AND payment_header1.cek3='0' AND payment_header1.cek4='0' group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
                                ,Payment_Detail1.cek4
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            ElseIf Level = 3 Then
                sql = sql & " WHERE payment_header1.BankID = COALESCE(NULLIF('" & BankID & "',''),BankID) AND payment_header1.cek1 ='1' AND payment_header1.cek2='1' AND payment_header1.cek3='0' AND payment_header1.cek4='0' group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
                                ,Payment_Detail1.cek4
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            Else
                sql = sql & " WHERE payment_header1.BankID = COALESCE(NULLIF('" & BankID & "',''),BankID) AND payment_header1.cek1 ='1' AND payment_header1.cek2='1' AND payment_header1.cek4='0' group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
                                ,Payment_Detail1.cek4
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            End If

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetDataGridReject(ByVal Level As Integer) As DataTable
        Dim sql As String = "SELECT 
                                id
                                ,vrno as VoucherNo
                                ,tgl Tanggal
                                ,BankName
                                ,CuryID
                                ,VendorName
                                ,(Total_DPP_PPN-PPh)-cm_dm-Biaya_Transfer as PaidAmount
                                , cek1 as Level1, cek2 as Level2, cek3 as Level3, cek4 as Direktur 
                            FROM payment_header1 "
        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            'If Level = 1 Then
            '    sql = sql & " WHERE BankID = COALESCE(NULLIF('" & BankID & "',''),BankID) ORDER BY tgl, vendorname, vrno"
            'ElseIf Level = 2 Then
            '    sql = sql & " WHERE cek1 ='0' AND cek2='0' AND cek3='0' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            'ElseIf Level = 3 Then
            '    sql = sql & " WHERE cek1 ='0' AND cek2='1' AND cek3='0' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            'Else
            '    sql = sql & " WHERE cek1 ='0' AND cek2='1' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            'End If

            If Level = 1 Then
                sql = sql & " WHERE cek1='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 2 Then
                sql = sql & " WHERE cek2='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 3 Then
                sql = sql & " WHERE cek3='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 4 Then
                sql = sql & " WHERE cek4='0' and cek2='0' and cek3='0' and cek1='0' ORDER BY tgl, vendorname, vrno"
            End If


            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetDataGridReject1(ByVal Level As Integer) As DataTable
        Dim sql As String = "select payment_header1.id
                                ,payment_header1.vrno as VoucherNo
                                ,payment_header1.tgl Tanggal
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
                                ,(sum(payment_detail1.dpp)+sum(payment_detail1.Ppn)-sum(payment_detail1.pph))-payment_header1.cm_dm-payment_header1.Biaya_Transfer as PaidAmount
                                , payment_header1.cek1 as Level1, payment_header1.cek2 as Level2, payment_header1.cek3 as Level3, payment_header1.cek4 as Direktur 
                            FROM payment_detail1  inner join payment_header1 on payment_detail1.vrno=payment_header1.vrno "
        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            'If Level = 1 Then
            '    sql = sql & " WHERE BankID = COALESCE(NULLIF('" & BankID & "',''),BankID) ORDER BY tgl, vendorname, vrno"
            'ElseIf Level = 2 Then
            '    sql = sql & " WHERE cek1 ='0' AND cek2='0' AND cek3='0' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            'ElseIf Level = 3 Then
            '    sql = sql & " WHERE cek1 ='0' AND cek2='1' AND cek3='0' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            'Else
            '    sql = sql & " WHERE cek1 ='0' AND cek2='1' AND cek4='0' ORDER BY tgl, vendorname, vrno"
            'End If

            If Level = 1 Then
                sql = sql & " where payment_detail1.cek1='0'
							 group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno "
            ElseIf Level = 2 Then
                sql = sql & " where payment_detail1.cek1='0' and  payment_detail1.cek2='0' and Payment_Header1.cek4=0
							 group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno "
            ElseIf Level = 3 Then
                sql = sql & " where payment_detail1.cek1='0' and  payment_detail1.cek3='0' and Payment_Header1.cek4=0
							 group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno "
            ElseIf Level = 4 Then
                sql = sql & " where payment_detail1.cek1='0' and  payment_detail1.cek4='0' and Payment_Header1.cek4=0
							 group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
								ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno "
            End If


            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function



    Public Function GetDataGridApproveDone(ByVal Level As Integer) As DataTable
        Dim sql As String = "SELECT 
                                payment_header1.id
                                ,payment_header1.vrno as VoucherNo
                                ,payment_header1.tgl Tanggal
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
                                ,(sum(payment_detail1.dpp)+sum(payment_detail1.Ppn)-sum(payment_detail1.pph))-payment_header1.cm_dm-payment_header1.Biaya_Transfer as PaidAmount
                            FROM payment_detail1  inner join payment_header1 on payment_detail1.vrno=payment_header1.vrno  "
        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If Level = 2 Then
                sql = sql & " WHERE payment_header1.cek2='1' group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
							ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            ElseIf Level = 3 Then
                sql = sql & " WHERE payment_header1.cek3='1' group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
							ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            ElseIf Level = 4 Then
                sql = sql & " WHERE payment_header1.cek4='1' group by payment_header1.id
                                ,payment_header1.vrno 
                                ,payment_header1.tgl
                                ,payment_header1.BankName
                                ,payment_header1.CuryID
                                ,payment_header1.VendorName
								,payment_header1.cek1, 
								payment_header1.cek2, 
								payment_header1.cek3, payment_header1.cek4 
								,payment_header1.cm_dm
								,payment_header1.Biaya_Transfer
							ORDER BY payment_header1.tgl, payment_header1.vendorname, payment_header1.vrno"
            End If

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridApproveReject(ByVal Level As Integer) As DataTable
        Dim sql As String = "SELECT 
                                id
                                ,vrno as VoucherNo
                                ,tgl Tanggal
                                ,BankName
                                ,CuryID
                                ,VendorName
                                ,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as PaidAmount
                            FROM payment_header1 "
        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If Level = 1 Then
                sql = sql & " WHERE cek1='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 2 Then
                sql = sql & " WHERE cek2='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 3 Then
                sql = sql & " WHERE cek3='0' ORDER BY tgl, vendorname, vrno"
            ElseIf Level = 4 Then
                sql = sql & " WHERE cek4='0' ORDER BY tgl, vendorname, vrno"
            End If

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateCek(ByVal Level As Integer)
        Try
            Dim ls_SP As String = String.Empty
            If Level = 2 Then
                ls_SP = "UPDATE payment_header1 SET cek2= " & QVal(True) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 3 Then
                ls_SP = "UPDATE payment_header1 SET cek3= " & QVal(True) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 4 Then
                ls_SP = "UPDATE payment_header1 SET cek4= " & QVal(True) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            End If
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateUnCek(ByVal Level As Integer)
        Try
            Dim ls_SP As String = String.Empty
            If Level = 1 Then
                ls_SP = "UPDATE payment_header1 SET cek1= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 2 Then
                ls_SP = "UPDATE payment_header1 SET cek2= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 3 Then
                ls_SP = "UPDATE payment_header1 SET cek3= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 4 Then
                ls_SP = "UPDATE payment_header1 SET cek4= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            End If
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateUnCekDir(ByVal Level As Integer)
        Try
            Dim ls_SP As String = String.Empty
            If Level = 2 Then
                ls_SP = "UPDATE payment_header1 SET cek2= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 3 Then
                ls_SP = "UPDATE payment_header1 SET cek3= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            ElseIf Level = 4 Then
                ls_SP = "UPDATE payment_header1 SET cek4= " & QVal(False) & " WHERE vrno=" & QVal(vrno.TrimEnd) & ""
            End If
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
