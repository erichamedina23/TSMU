Imports System.Collections.ObjectModel

Public Class HarigamiModels
    Public Property ObjDetails() As New Collection(Of HarigamiDetailsModels)
    Public Function GetAllDataGridCKR() As DataTable
        Try
            Dim data As String =
            "SELECT
                Id, FileNo, InvtId , FilePath, Type 
            FROM [TbHarigamiMaster]"
            Dim dtTable As New DataTable

            dtTable = GetDataTableCKR(Data)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetReportHarigami(Tgl1 As String, Tgl2 As String) As DataTable
        Try
            Dim data As String = "SELECT
                h.Id,
	            h.FileNo,
                m.InvtId,
	            m.FilePath,
	            h.Type,
	            h.LastCounter,
	            d.CreatedDate,
	            d.Status,
	            d.Counter
            FROM TbHarigami h left join
            TbHarigamiDetails d on h.Id = d.Id left join
            TbHarigamiMaster m on h.FileNo = m.FileNo AND h.Type = m.Type
            WHERE Convert(Date,h.CreatedDate) >= " & QVal(Tgl1) & " AND Convert(Date,h.CreatedDate) <= " & QVal(Tgl2) & " Order By h.Id"
            Dim dtTable As New DataTable
            dtTable = GetDataTableCKR(data)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub DeleteData()
        Try
            Dim sql As String = "Delete From TbHarigamiMaster"

            ExecQueryCKR(sql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteData()
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertData()
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
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .UpdateData()
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
            Throw ex
        End Try
    End Sub
End Class
Public Class HarigamiDetailsModels
    Public Property Id() As Integer
    Public Property FileNo() As String
    Public Property FilePath() As String
    Public Property Type() As String
    Public Property InvtId() As String


    Public Sub InsertData()
        Try
            Dim Query As String = String.Empty
            Query = "INSERT INTO [TbHarigamiMaster]([FileNo],[FilePath],[Type],InvtId,[CreatedDate])
                    Values(" & QVal(FileNo) & "," & QVal(FilePath) & "," & QVal(Type) & "," & QVal(InvtId) & ", GETDATE())"

            ExecQueryCKR(Query)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Dim Query As String = String.Empty
            Query = "Update [TbHarigamiMaster]
                    Set [FileNo] = " & QVal(FileNo) & " 
                        ,[FilePath] = " & QVal(FilePath) & "
                        ,[InvtId] = " & QVal(InvtId) & "
                        ,[Type]) = " & QVal(Type) & " where Id = " & QVal(Id) & ""

            ExecQueryCKR(Query)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
