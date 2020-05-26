Imports System.Collections.ObjectModel

Public Class SuspendHeaderModel
    Public Property Currency As String
    Public Property DeptID As String
    Public Property PRNo As String
    Public Property Remark As String
    Public Property Status As String
    Public Property SuspendHeaderID As Integer
    Public Property SuspendID As String
    Public Property Tgl As DateTime
    Public Property Tgld As DateTime
    Public Property Tgls As DateTime
    Public Property Tipe As String
    Public Property Total As Double
    Public Property ObjDetails() As New Collection(Of SuspendDetailModel)
    Public Property _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM suspend_header" & vbCrLf &
            "WHERE suspendid = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM suspend_detail " & vbCrLf &
            "WHERE suspendid = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID, SuspendID, Currency, DeptID, PRNo, Remark, Tgl, Total, Status 
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND  Tipe = 'S' and status<>'Close' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT suspend_header.SuspendHeaderID
      ,suspend_header.SuspendID
      ,suspend_header.Tipe
      ,suspend_header.Currency
      ,suspend_header.DeptID
      ,suspend_header.PRNo
      ,suspend_header.Remark
      ,suspend_header.Tgl
      ,suspend_header.Status
      ,suspend_header.Total
      ,suspend_header.pay
      ,suspend_header.State
      ,suspend_header.CirculationNo
      ,suspend_header.AmountReq
      ,suspend_header.BankID
      ,suspend_header.Proses
      ,suspend_detail.Description
      ,suspend_detail.Amount
      ,suspend_detail.AcctID
      ,suspend_detail.SubAcct
      ,suspend_detail.Nama
      ,suspend_detail.Tempat
      ,suspend_detail.Alamat
      ,suspend_detail.Jenis
      ,suspend_detail.NoKwitansi
      ,suspend_detail.Ket
  FROM suspend_header left join suspend_detail on suspend_detail.SuspendID=suspend_header.SuspendID where suspend_header.SuspendID='" & SuspendID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "suspend")
        Return ds

    End Function
    Public Function loadreport3() As DataSet
        Dim query As String
        query = "SELECT suspend_header.SuspendHeaderID
      ,suspend_header.SuspendID
      ,suspend_header.Tipe
      ,suspend_header.Currency
      ,suspend_header.DeptID
      ,suspend_header.PRNo
      ,suspend_header.Remark
      ,suspend_header.Tgl
      ,suspend_header.Status
      ,suspend_header.Total
      ,suspend_header.pay
      ,suspend_header.State
      ,suspend_header.CirculationNo
      ,suspend_header.AmountReq
      ,suspend_header.BankID
      ,suspend_header.Proses
      ,suspend_detail.Description
      ,suspend_detail.Amount
      ,suspend_detail.AcctID
      ,suspend_detail.SubAcct
      ,suspend_detail.Nama
      ,suspend_detail.Tempat
      ,suspend_detail.Alamat
      ,suspend_detail.Jenis
      ,suspend_detail.NoKwitansi
      ,suspend_detail.Ket
  FROM suspend_header left join suspend_detail on suspend_detail.SuspendID=suspend_header.SuspendID where suspend_header.DeptID='" & DeptID & "' AND suspend_header.Tgl>='" & Tgld & "' AND suspend_header.Tgl<='" & Tgls & "' "

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "suspend")
        Return ds

    End Function
    Public Function SubReport() As DataSet
        Dim query As String
        query = "SELECT [SuspendRelasiID]
                      ,[SuspendID]
                      ,[Nama]
                      ,[Posisi]
                      ,[Perusahaan]
                      ,[JenisUsaha]
                      ,[Remark]
                  FROM [SuspendRelasi] Where [SuspendID] = '" & SuspendID & "'"
        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "SuspendRelasi")
        Return ds

    End Function
    Public Function GetDept2() As List(Of String)
        Try
            Dim result As New List(Of String)

            Dim dt As New DataTable
            Dim sql As String =
            "select '''' + RTRIM(a.DeptID) + '''' DeptID from S_User u inner join
	            akses_approval a on u.Username = a.Username
            WHERE a.Username = " & QVal(gh_Common.Username) & ""
            dt = GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                result.Add(row("DeptID"))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataGrid2() As DataTable
        Try
            Dim dept As String()
            dept = GetDept2.ToArray
            Dim nilai = String.Join(",", GetDept2.ToArray)

            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID, SuspendID, Currency, DeptID, PRNo, Remark, Tgl, Total, Status 
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND Tipe = 'S' and status<>'Open' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SuspendAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(SuspendID)),4)+1 as varchar),4) " &
                "from suspend_Header " &
                "where SUBSTRING(SuspendID,1,7) = 'SP' + '-' + RIGHT(@tahun,4) AND SUBSTRING(SuspendID,9,2) = RIGHT(@bulan,2)) " &
                "select 'SP' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Sub GetSuspenById()
        Try
            Dim sql As String =
            "SELECT SuspendHeaderID, SuspendID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total
            FROM suspend_header where SuspendHeaderID=" & QVal(SuspendHeaderID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                SuspendHeaderID = If(IsDBNull(dt.Rows(0).Item("SuspendHeaderID")), "", Trim(dt.Rows(0).Item("SuspendHeaderID").ToString()))
                SuspendID = If(IsDBNull(dt.Rows(0).Item("SuspendID")), "", Trim(dt.Rows(0).Item("SuspendID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                PRNo = If(IsDBNull(dt.Rows(0).Item("PRNo")), "", Trim(dt.Rows(0).Item("PRNo").ToString()))
                Remark = If(IsDBNull(dt.Rows(0).Item("Remark")), "", Trim(dt.Rows(0).Item("Remark").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Status = If(IsDBNull(dt.Rows(0).Item("status")), "", Trim(dt.Rows(0).Item("status").ToString()))
                Total = If(IsDBNull(dt.Rows(0).Item("Total")), 0, Convert.ToDouble(dt.Rows(0).Item("Total")))
                Currency = If(IsDBNull(dt.Rows(0).Item("Currency")), "", Convert.ToString(dt.Rows(0).Item("Currency")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetDept() As DataTable
        Try
            Dim sql As String =
            "SELECT [IdDept]
                  ,[NamaDept]
              FROM [mDept]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Acct) [Account],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSubAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsSuspendOpen(SuspendHeaderID As String) As Boolean
        Dim Result As Boolean = False
        Try
            Dim sql As String = "Select Top 1 * from suspend_header where SuspendHeaderID = " & QVal(SuspendHeaderID) & " and Status <> 'Open' and State>=2"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                Result = True
            End If
            Return Result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_header (SuspendID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total, CreatedBy, CreatedDate) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(Tipe) & ", " & vbCrLf &
            "       " & QVal(Currency) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(PRNo) & ", " & vbCrLf &
            "       " & QVal(Remark) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Status) & ", " & vbCrLf &
            "       " & QVal(Total) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        'Try
        '    Dim ls_SP As String = "update suspend_header set status='Open' WHERE rtrim(SuspendID)=" & QVal(_SuspendID.TrimEnd) & ""
        '    ExecQuery_Solomon(ls_SP)
        'Catch ex As Exception
        '    Throw
        'End Try

    End Sub
    Public Sub UpdateHeader(ByVal _SuspendID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE suspend_header " & vbCrLf &
                                    "SET    Currency = " & QVal(Currency) & ", " & vbCrLf &
                                    "       DeptID = " & QVal(DeptID) & ", " & vbCrLf &
                                    "       PRNo = " & QVal(PRNo) & ", " & vbCrLf &
                                    "       Remark = " & QVal(Remark) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       Status = " & QVal(Status) & ", " & vbCrLf &
                                    "       Total = " & QVal(Total) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE SuspendID = '" & _SuspendID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

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

    Public Sub UpdateData(_SuspendID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(_SuspendID)

                        Dim ObjSuspendDetail As New SuspendDetailModel
                        ObjSuspendDetail.DeleteDetail(_SuspendID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
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
End Class
Public Class SuspendDetailModel
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property Amount As Double
    Public Property DeptID As String
    Public Property Description As String
    Public Property Jenis As String
    Public Property Nama As String
    Public Property NoKwitansi As Char
    Public Property SubAcct As String
    Public Property SuspendDetailID As Integer
    Public Property SuspendID As String
    Public Property Tempat As String
    Public Property Tgl As String

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_detail (SuspendID, Description, Amount, AcctID, SubAcct) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Amount) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteDetail(_suspendID)
        Try
            Dim ls_SP As String = "DELETE FROM suspend_detail WHERE rtrim(SuspendID)=" & QVal(_suspendID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetSubAccountbyid() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct WHERE Consolsub = " & QVal(SubAcct) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByID() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    [Amount] Amount
                                FROM suspend_detail WHERE SuspendID = " & QVal(SuspendID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetDataDetailByID1(_SuspendID As String) As DataTable
        Try
            Dim sql As String = "SELECT GETDATE() as Tgl,
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    RTRIM([Amount]) Amount,
                                    convert(numeric(18,2),0) ActualAmount 
                                FROM suspend_detail WHERE SuspendID = " & QVal(_SuspendID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
