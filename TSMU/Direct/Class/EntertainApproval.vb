Imports System.Collections.ObjectModel

Public Class EntertainApprovalHeaderModel
    Public Property Currency As String
    Public Property DeptID As String
    Public Property PRNo As String
    Public Property Remark As String
    Public Property Status As String
    Public Property SuspendHeaderID As Integer
    Public Property SuspendID As String
    Public Property Tgl As DateTime
    Public Property Tipe As String
    Public Property Total As Double
    Public Property ObjDetails() As New Collection(Of EntertainApprovalDetailModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim dept As String()
            dept = GetDept.ToArray
            Dim nilai = String.Join(",", GetDept.ToArray)

            Dim level As Integer = GetUsernameLevel()

            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID, SuspendID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total
            FROM suspend_header where deptid in(" & nilai & ") and State = " & QVal(level) - 1 & " Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
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
    Public Function GetDept() As List(Of String)
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

    Public Function IsEntertainIsApprovedStepAhead(SuspendID As String) As Boolean
        Dim Hasil As Boolean = False
        Try
            Dim level As Integer = GetUsernameLevel()
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendID 
            FROM suspend_header where SuspendID= " & QVal(SuspendID) & "  AND State = " & QVal(level) & ""
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                Hasil = True
            End If
            Return Hasil
        Catch ex As Exception
            Throw ex
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

    Public Sub UpdateHeader(ByVal _SuspendID As String, level As Integer)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE suspend_header " & vbCrLf &
                                    "SET State = " & QVal(level) & " WHERE SuspendID = '" & _SuspendID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateStatusEntertain(ByVal _SuspendID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE suspend_header " & vbCrLf &
                                    "SET Status = 'Approved' WHERE SuspendID = '" & _SuspendID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateHeaderCancel(ByVal _SuspendID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE suspend_header " & vbCrLf &
                                    "SET State = 0 WHERE SuspendID = '" & _SuspendID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteApprove(ByVal _SuspendID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Delete From  SuspendApproval WHERE SuspendID = '" & _SuspendID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertHeader(SuspendID As String, Level As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [SuspendApproval]
                    ([SuspendID]
                    ,[ApprovedBy]
                    ,[ApprovedDate],[Level]) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE()," & QVal(Level) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertRejectedApproval(SuspendID As String, Level As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [SuspendApproval]
                    ([SuspendID]
                    ,[RejectedBy]
                    ,[RejectedDate],[Level]) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE()," & QVal(Level) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub ApproveData(ByVal _SuspendID As String, level As Integer)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(_SuspendID, level)
                        UpdateStatusEntertain(_SuspendID)

                        InsertHeader(_SuspendID, level)


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

    Public Sub CancelApproveData(ByVal _SuspendID As String, Level As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeaderCancel(_SuspendID)
                        DeleteApprove(_SuspendID)
                        InsertRejectedApproval(_SuspendID, Level)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .UpdateKet(_SuspendID)
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
Public Class EntertainApprovalDetailModel
    Public Property Ket() As String
    Public Function GetDataDetailByID(SuspendID As String) As DataTable
        Try
            Dim sql As String = "SELECT SuspendID
                                    ,[Description]
                                    ,[Amount]
                                    ,[AcctID]
                                    ,[SubAcct]
                                    ,[Tgl]
                                    ,[Nama]
                                    ,[Tempat]
                                    ,[Alamat]
                                    ,[DeptID]
                                    ,[Jenis]
                                    ,[NoKwitansi]
                                    ,[Proses]
                                    ,[Ket]
                                FROM suspend_detail WHERE RTRIM(SuspendID) = " & QVal(SuspendID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailRelasi(SuspendDetailID As String) As DataTable
        Try
            Dim sql As String = "SELECT 
                                    [Nama]
                                    ,[Posisi]
                                    ,[Perusahaan]
                                    ,[JenisUsaha]
                                    ,[Remark]
                                FROM [SuspendRelasi] WHERE RTRIM(SuspendID) = " & QVal(SuspendDetailID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateKet(ByVal _SuspendID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE suspend_detail " & vbCrLf &
                                    "SET Ket = " & QVal(Ket) & " WHERE SuspendID = '" & _SuspendID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
