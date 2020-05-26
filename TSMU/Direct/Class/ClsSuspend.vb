Imports System.Collections.ObjectModel
Public Class ClsSuspend
    Dim _Query As String
    Public Property CreatedBy As String
    Public Property CreatedDate As DateTime
    Public Property Currency As String
    Public Property DeptID As String
    Public Property pay As Short
    Public Property PRNo As String
    Public Property Remark As String
    Public Property State As Integer
    Public Property Status As String
    Public Property SuspendHeaderID As Integer
    Public Property SuspendID As String
    Public Property Tgl As DateTime
    Public Property Tipe As String
    Public Property Total As Double
    Public Property UpdatedBy As String
    Public Property UpdatedDate As DateTime


    Public Property AcctID As String
    Public Property Alamat As String
    Public Property Amount As Double
    Public Property Description As String
    Public Property Jenis As String
    Public Property Ket As String
    Public Property Nama As String
    Public Property NoKwitansi As Char
    Public Property Proses As Boolean
    Public Property SubAcct As String
    Public Property SuspendDetailID As Integer
    Public Property Tempat As String
    Public Property ID() As String
    Public Property subaccount() As String
    Public Property account() As String
    Public Property perpost() As String

    Public Sub New()
        Me._Query = "select suspendID,Tgl,deptid,total,remark from suspend_header order by suspendID"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as suspendid,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "select suspendID,Tgl,Dept,total_suspend,remark from suspend_header order by suspendID"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Acct) [Account],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetBank() As DataTable
        Try

            Dim sql As String = "Select 
                                    RTrim(BankAcct) [Account],
	                                RTrim(CashAcctName) Descritiption, CuryID
                                From dbo.cashacct"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCustomer() As DataTable
        Try

            Dim sql As String = "Select 
                                    RTrim(custid) [CustID],
	                                RTrim(Name) Name
                                From dbo.Customer where status='A'"
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
                "from cashbank " &
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
    Public Function GetSubAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetSubAccountbyid() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct WHERE Consolsub = " & QVal(subaccount) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetNamaAccountbyid() As String
        Try
            Dim namaaccount As String
            Dim sql As String = "SELECT 
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account WHERE Acct = " & QVal(account) & ""

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(Sql)
            namaaccount = dt.Rows(0).Item(0).ToString
            Return namaaccount

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetGridDetailSuspendByAccountID() As DataTable
        Try
            Dim sql As String = "select  suspend_header.Tgl, suspend_detail.SuspendID, suspend_detail.Description, suspend_detail.Amount, suspend_detail.AcctID,suspend_detail.Proses from suspend_header inner join  suspend_detail on suspend_detail.suspendid=suspend_header.suspendid where suspend_header.pay=0 and suspend_detail.description NOT LIKE '%ENTERTAINMENT%'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSettleByAccountID() As DataTable
        Try
            Dim sql As String = "select  settle_header.Tgl, 
                                    settle_detail.SettleID, 
                                    settle_header.SuspendID, 
                                    settle_detail.Description,
                                    suspend_header.Total, 
                                    settle_detail.SettleAmount, 
                                    settle_detail.AcctID,
                                    settle_detail.proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailEntertaintByAccountID() As DataTable
        Try
            Dim sql As String = "select  suspend_header.Tgl, suspend_detail.SuspendID, suspend_detail.Description, suspend_detail.Amount, suspend_detail.AcctID from suspend_header inner join  suspend_detail on suspend_detail.suspendid=suspend_header.suspendid where suspend_header.pay=0 and suspend_detail.description  LIKE '%ENTERTAINMENT%'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSuspendPaymentByAccountID() As DataTable
        Try
            Dim sql As String = "SELECT tgl as Tgl      ,nobukti as NoBukti      ,transaksi as Transaksi      ,keterangan as Keterangan      ,masuk as Masuk      ,keluar as Keluar      ,saldo as Saldo FROM cashbank WHERE  perpost='" & perpost & "' and acctid='" & acctid & "' order by nobukti"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function saldo2() As Double
        Try
            Dim saldo As Single

            Dim sql As String = "Select saldo from saldo_awal where acctid=" & QVal(account) & " and perpost=" & QVal(perpost) & ""
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
    Public Function saldo() As DataTable
        Try
            Dim sql As String = "Select saldo from saldo_awal where acctid='" & QVal(account) & "' and perpost='" & QVal(perpost) & "'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select id,suspendID,Tgl,Dept,total_suspend,remark from suspend_header WHERE [ID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID") & "")
                    Me.suspendID = Trim(.Item("suspendID") & "")
                End With
            Else
                ID = ""
                suspendID = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.suspendID = "" OrElse Me.ID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 ID,suspendID,Tgl,Dept,total_suspend,remark where [ID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.ID & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [m_work_center]
                                           ([ID]
                                           ,[suspendid]
                                           ,[Created Date]
                                           ,[Created By])
                                     VALUES
                                           (" & QVal(ID) & " 
                                           ," & QVal(suspendID) & "
                                           ,GETDATE()
                                           ," & QVal(gh_Common.Username) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [m_work_center]
                                   SET [suspendid] = " & QVal(suspendID) & "
                                      ,[Updated Date] = GETDATE()
                                      ,[Updated By] = " & QVal(gh_Common.Username) & "
                                    WHERE ID = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [suspend_header] WHERE ID =" & QVal(suspendID) & ""
            MainModul.ExecQuery(ls_SP)
            Dim ls_SP2 As String = "DELETE FROM [suspend_detail] WHERE ID =" & QVal(suspendID) & ""
            MainModul.ExecQuery(ls_SP2)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
