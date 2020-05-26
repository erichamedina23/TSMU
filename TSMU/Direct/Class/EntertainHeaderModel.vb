Imports System.Collections.ObjectModel

Public Class EntertainHeaderModel
    Public Property Currency As String
    Public Property PRNo As String
    Public Property Status As String
    Public Property SuspendHeaderID As Integer
    Public Property SuspendID As String
    Public Property Tgl As DateTime
    Public Property Tipe As String
    Public Property Total As Double
    Public Property SubAcct As Double
    Public Property AcctId As Double
    Public Property Description As String
    Public Property DeptID As String
    Public Property Nama As String
    Public Property NamaRelasi As String
    Public Property perusahaanrelasi As String

    Public Property Tempat As String
    Public Property Alamat As String
    Public Property Jenis As String
    Public Property NoKwitansi As String
    Public Property Amount As String
    Public Property Posisi As String
    Public Property Perusahaan As String
    Public Property JenisUsaha As String
    Public Property Remark As String
    Public Property AmountReq As String
    Public Property CirculationNo As String
    Public Property SettleID As String
    Public Property ObjDetails() As New Collection(Of EntertainDetailModel)

    Public Sub InsertRelasiSettleEnt()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO SettleRelasi (SettleID,Nama,Posisi,Perusahaan,JenisUsaha,Remark ) " & vbCrLf &
            "Values(" & QVal(SettleID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Perusahaan) & ", " & vbCrLf &
            "       " & QVal(JenisUsaha) & ", " & vbCrLf &
            "       " & QVal(Remark) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID, SuspendID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' and Tipe = 'E' and status<>'Close'  Order by SuspendID "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataGrid2() As DataTable
        Try
            Dim dt2 As New DataTable
            Dim sql2 As String =
            "SELECT SuspendHeaderID, SuspendID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' and Tipe = 'E' and status='Approved' Order by SuspendID  "
            dt2 = GetDataTable_Solomon(sql2)
            Return dt2
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
                "where SUBSTRING(SuspendID,1,7) = 'EN' + '-' + RIGHT(@tahun,4) AND SUBSTRING(SuspendID,9,2) = RIGHT(@bulan,2)) " &
                "select 'EN' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

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

    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_header (SuspendID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total, CreatedBy,AmountReq,CirculationNo, CreatedDate) " & vbCrLf &
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
            "       " & QVal(AmountReq) & ", " & vbCrLf &
            "       " & QVal(CirculationNo) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
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
            ExecQuery(ls_SP)
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

    Public Sub InsertDataRelasi()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        ''InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertRelasi()
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



    Public Sub InsertDataRelasiSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        ''InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertRelasiSettle()
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



    Public Sub UpdateData()
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

    Public Sub UpdateDataRelasi()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(SuspendID)

                        Dim ObjSuspendDetail As New SuspendDetailModel
                        ObjSuspendDetail.DeleteDetail(SuspendID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertRelasi()
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

    'Public Sub UpdateDataRelasiSettle()
    '    Try
    '        Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
    '            Conn1.Open()
    '            Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
    '                gh_Trans = New InstanceVariables.TransactionHelper
    '                gh_Trans.Command.Connection = Conn1
    '                gh_Trans.Command.Transaction = Trans1

    '                Try

    '                    UpdateHeader(SettleID)

    '                    Dim ObjSuspendDetail As New SuspendDetailModel
    '                    ObjSuspendDetail.DeleteDetail(SuspendID)

    '                    For i As Integer = 0 To ObjDetails.Count - 1
    '                        With ObjDetails(i)
    '                            .InsertRelasi()
    '                        End With
    '                    Next

    '                    Trans1.Commit()
    '                Catch ex As Exception
    '                    Trans1.Rollback()
    '                    Throw
    '                Finally
    '                    MainModul.gh_Trans = Nothing
    '                End Try
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

End Class
Public Class EntertainDetailModel
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property Amount As Double
    Public Property DeptID As String
    Public Property Description As String
    Public Property Jenis As String
    Public Property Nama As String
    Public Property NoKwitansi As String
    Public Property SubAcct As String
    Public Property SuspendDetailID As Integer
    Public Property SuspendID As String
    Public Property Tempat As String
    Public Property Tgl As Date
    Public Property Posisi As String
    Public Property Perusahaan As String
    Public Property JenisUSaha As String
    Public Property Remark As String
    Public Property SettleID As String
    Public Property Relasi As String
    Public Property JenisRelasi As String
    Public Property Nota As String
    Public Property NamaRelasi As String


    Public Sub InsertRelasiSettleEnt()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO Settle_Relasi (SettleID,Nama,Posisi,Perusahaan,JenisUsaha,Remark ) " & vbCrLf &
            "Values(" & QVal(SettleID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Perusahaan) & ", " & vbCrLf &
            "       " & QVal(JenisUSaha) & ", " & vbCrLf &
            "       " & QVal(Remark) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_detail (SuspendID,AcctID,SubAcct,Description,Tgl,DeptID,Nama,Tempat,Alamat,Jenis,NoKwitansi,Amount ) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Tempat) & ", " & vbCrLf &
            "       " & QVal(Alamat) & ", " & vbCrLf &
            "       " & QVal(Jenis) & ", " & vbCrLf &
            "       " & QVal(NoKwitansi) & ", " & vbCrLf &
            "       " & QVal(Amount) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertRelasi()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO SuspendRelasi (SuspendID,Nama,Posisi,Perusahaan,JenisUsaha,Remark ) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Perusahaan) & ", " & vbCrLf &
            "       " & QVal(JenisUSaha) & ", " & vbCrLf &
            "       " & QVal(Remark) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub




    Public Sub InsertRelasiSettle()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settlerelasi (SettleID,Nama,Posisi,Perusahaan,JenisUsaha,Remark ) " & vbCrLf &
            "Values(" & QVal(SettleID) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Relasi) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi) & ", " & vbCrLf &
            "       " & QVal(Nota) & ")"
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
                                    Tgl,
                                    RTRIM(DeptID) DeptID,
                                    RTRIM(Nama) Nama,
                                    RTRIM(Tempat) Tempat,
                                    RTRIM(Alamat) Alamat,
                                    RTRIM(Jenis) Jenis,
                                    RTRIM(NoKwitansi) NoKwitansi,
                                    [Amount] Amount
                                FROM suspend_detail WHERE SuspendID = " & QVal(SuspendID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByIDSettleENt() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    Tgl,
                                    RTRIM(DeptID) DeptID,
                                    RTRIM(Nama) Nama,
                                    RTRIM(Tempat) Tempat,
                                    RTRIM(Alamat) Alamat,
                                    RTRIM(Jenis) Jenis,
                                    RTRIM(NoKwitansi) NoKwitansi,
                                    [Amount] Amount
                                FROM suspend_detail WHERE SuspendID = " & QVal(SuspendID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetDataDetailByIDEnt() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    Tgl,
                                    RTRIM(DeptID) DeptID,
                                    RTRIM(Nama) Nama,
                                    RTRIM(Tempat) Tempat,
                                    RTRIM(Alamat) Alamat,
                                    RTRIM(Jenis) Jenis,
                                    RTRIM(NoKwitansi) NoKwitansi,
                                    Amount
                                FROM suspend_detail WHERE SuspendID = " & QVal(SuspendID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByID1Ent(_SuspendID As String) As DataTable
        Try
            Dim sql As String = "SELECT GETDATE() as Tgl,
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    Amount,
                                    0 ActualAmount 
                                FROM suspend_detail WHERE SuspendID = " & QVal(_SuspendID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByIDtrial() As DataTable
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


End Class

Public Class EntertainSetteleHeader

End Class



