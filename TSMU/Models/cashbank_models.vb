Imports System.Collections.ObjectModel
Public Class cashbank_models

    Public Property AcctID As String
    Public Property Keluar As Double
    Public Property Keterangan As String
    Public Property Masuk As Double
    Public Property NoBukti As String
    Public Property Noref As String
    Public Property Perpost As String
    Public Property Saldo As Double
    Public Property Saldo_Awal As Double
    Public Property SuspendAmount As Double
    Public Property SettleAmount As Double
    Public Property Tgl As DateTime
    Public Property Transaksi As String
    Public Property SuspendID As String
    Public Property SettleID As String
    Public Property curyid As String
    Public Property account() As String
    Public Property _id As String
    Public Property cek As Boolean
    Public Property rekonsal As Boolean
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Public Function GetUsernameLevel() As Integer
        Dim result As Integer = 0
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT top 1 Kol
            FROM akses_approval where Username = " & QVal(gh_Common.Username) & ""
            dt = GetDataTable(sql)
            result = Convert.ToInt32(dt.Rows(0)(0))
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetDirekPaymentById(_NoBukti As String)
        Try
            Dim sql As String =
            "Select Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,Perpost,Account.curyid,AcctID FROM cashbank2  inner join  Account on Account.Acct=cashbank2.AcctID WHERE  NoBukti=" & QVal(_NoBukti) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                NoBukti = If(IsDBNull(dt.Rows(0).Item("NoBukti")), "", Trim(dt.Rows(0).Item("NoBukti").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Transaksi = If(IsDBNull(dt.Rows(0).Item("Transaksi")), "", Trim(dt.Rows(0).Item("Transaksi").ToString()))
                SettleAmount = If(IsDBNull(dt.Rows(0).Item("SettleAmount")), 0, Convert.ToDouble(dt.Rows(0).Item("SettleAmount")))
                SuspendAmount = If(IsDBNull(dt.Rows(0).Item("SuspendAmount")), 0, Convert.ToDouble(dt.Rows(0).Item("SuspendAmount")))
                Masuk = If(IsDBNull(dt.Rows(0).Item("Masuk")), 0, Convert.ToDouble(dt.Rows(0).Item("Masuk")))
                Keluar = If(IsDBNull(dt.Rows(0).Item("Keluar")), 0, Convert.ToDouble(dt.Rows(0).Item("Keluar")))
                Perpost = If(IsDBNull(dt.Rows(0).Item("Perpost")), "", Trim(dt.Rows(0).Item("Perpost").ToString()))
                AcctID = If(IsDBNull(dt.Rows(0).Item("AcctID")), "", Convert.ToString(dt.Rows(0).Item("AcctID")))
                curyid = If(IsDBNull(dt.Rows(0).Item("curyid")), "", Convert.ToString(dt.Rows(0).Item("curyid")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTable()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
           ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(Keterangan) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Noref) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertToTable02()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank2]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTableB()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank2]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
           ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[flag]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(Keterangan) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Noref) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ,'1'
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTable2()
        Try

            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
            ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(Keterangan) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Noref) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateSuspend()

        Try

            Dim Query = "update suspend_header set pay=1,BankID=" & QVal(AcctID) & " where suspendid=" & QVal(SuspendID) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Sub UpdateVoucher()

        Try

            Dim Query = "update cashbank set AcctID=" & QVal(AcctID) & " where NoBukti=" & QVal(NoBukti) & ""
            MainModul.ExecQuery_Solomon(Query)


            Dim Query2 = "update cashbank2 set AcctID=" & QVal(AcctID) & " where NoBukti=" & QVal(NoBukti) & ""
            MainModul.ExecQuery_Solomon(Query2)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSuspend_hapus()

        Try
            Dim Query = "update suspend_header set pay=0 from suspend_header inner join cashbank on suspend_header.SuspendID = right(replace(cashbank.noref,' ',''),15) where cashbank.NoBukti=" & QVal(Me._id) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSettle()

        Try

            Dim Query = "update settle_header set pay=1 where settleid=" & QVal(SettleID) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function GetGridDetailSettleByAccountID03(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "SELECT Tgl,RTRIM([SubAcct]) SubAccount, RTRIM([AcctID]) Account,RTRIM(Description) Description,[SuspendAmount] SuspendAmount, [SettleAmount] SettleAmount FROM settle_detail WHERE SettleID=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateSettle_hapus()

        Try

            Dim Query = "update settle_header set pay=0 from settle_header inner join cashbank on settle_header.settleID = right(replace(cashbank.noref,' ',''),15) where cashbank.NoBukti=" & QVal(Me._id) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function GetGridDetailCashBankByAccountID() As DataTable
        Try
            Dim sql As String = "Select Tgl,NoBukti,Transaksi,Keterangan,Noref,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo FROM cashbank WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " order by nobukti"

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridDetailSuspendByAccountID03(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "SELECT RTRIM([SubAcct]) SubAccount, RTRIM([AcctID]) Account,RTRIM(Description) Description,[Amount] Amount FROM suspend_detail WHERE SuspendID=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailCashBankByAccountID03(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "Select Tgl,NoBukti,Transaksi,Keterangan,Noref,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo FROM cashbank WHERE  NoBukti=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailCashBankByAccountID02() As DataTable
        Try
            ' Dim sql As String = "Select Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,AcctID FROM cashbank2 WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " order by nobukti"
            Dim sql As String = "Select 0 as ID,Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,AcctID,cek as cek FROM cashbank2 WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " union select ID, Tgl,vrno as NoBukti, VendorName as Transaksi,0 as SuspendAmount,0 as SettleAmount, 0 as Masuk,(total_dpp_ppn)-pph-Biaya_Transfer as Keluar, 0 as Saldo,bankid as AcctID,cek5 as cek from Payment_Header1 where cek4=1 and substring(vrno,4,7)=" & QVal(Perpost) & " And bankid=" & QVal(AcctID) & ""
            ''Dim sql As String = "Select 0 as ID,Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,AcctID,cek as cek FROM cashbank2 WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " "

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function autononb() As String
        Try
            Dim auto2 As String
            Dim sql As String = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(nobukti)),4)+1 as varchar),4) " &
                "from cashbank2 " &
                "where SUBSTRING(nobukti,4,4) = RIGHT(@tahun,4) AND SUBSTRING(nobukti,9,2) = RIGHT(@bulan,2)) " &
                "select 'VC' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            auto2 = dt.Rows(0).Item(0).ToString
            Return auto2

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetNamaAccountbyid() As String
        Try
            Dim namaaccount As String
            Dim sql As String = "SELECT 
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account WHERE Acct = " & QVal(account) & ""

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            namaaccount = dt.Rows(0).Item(0).ToString
            Return namaaccount

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function saldo2() As Double
        Try
            Dim saldo As Single

            Dim sql As String = "Select isnull(saldo,0) as saldo from saldo_awal where acctid=" & QVal(account) & " and perpost=" & QVal(Perpost) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                saldo = Convert.ToDouble(dt.Rows(0).Item(0))
            Else
                saldo = 0
            End If

            Return saldo


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetGridDetailSuspendByAccountID() As DataTable
        Try

            ''            Dim sql As String = "Select suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark As Description, suspend_header.total As Amount, '' as AcctID, suspend_header.Proses,suspend_header.Currency from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'S' AND suspend_header.Status='Approved' AND suspend_header.Currency=" & QVal(curyid) & ""
            Dim sql As String = "Select suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark As Description, suspend_header.total As Amount, '' as AcctID, suspend_header.Proses,suspend_header.Currency from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'S' AND suspend_header.Status='Approved' "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridDetailSettleByAccountID() As DataTable
        Try
            ' Dim sql As String = "select settle_header.Tgl, settle_detail.SettleID, settle_header.SuspendID, settle_detail.Description,suspend_header.Total, settle_detail.SettleAmount, settle_detail.AcctID,suspend_header.BankID,settle_detail.Proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0"
            Dim sql As String = "Select  settle_header.Tgl, settle_header.SettleID, settle_header.SuspendID, settle_header.remark As Description,suspend_header.Total, sum(settle_detail.SettleAmount) As SettleAmount , '' as AcctID,suspend_header.BankID,settle_header.Proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0 group by settle_header.Tgl, settle_header.SettleID, settle_header.SuspendID, settle_header.remark,suspend_header.Total,suspend_header.BankID,settle_header.Proses"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridDetailEntertaintByAccountID() As DataTable
        Try
            '  Dim sql As String = "select  suspend_header.Tgl, suspend_detail.SuspendID, suspend_detail.Nama, suspend_detail.DeptID, suspend_detail.Tempat, suspend_detail.ALamat, suspend_detail.Jenis, suspend_detail.Amount, suspend_detail.AcctID, suspend_detail.Proses from suspend_header inner join  suspend_detail on suspend_detail.suspendid=suspend_header.suspendid where suspend_header.pay=0 and suspend_header.tipe = 'E'"

            Dim sql As String = "select  suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark as Description, suspend_header.DeptID, '' as Tempat, '' as ALamat, '' as Jenis, total as Amount, '' as AcctID,suspend_header.Proses from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'E' AND suspend_header.Status='Approved' AND suspend_header.Currency=" & QVal(curyid) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM cashbank2 " & vbCrLf &
            "WHERE NoBukti = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM cashbank " & vbCrLf &
            "WHERE NoBukti = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateCek()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE cashbank2 SET cek= " & QVal(cek) & " WHERE NoBukti=" & QVal(NoBukti.TrimEnd) & ""

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
