Imports System
Imports System.Data.SqlClient
Imports System.Data
Namespace InstanceVariables

    Public Class CommonHelper
        Dim _Username As String
        Dim _Name As String
        Dim _AdminStatus As Boolean
        Dim _group As String
        Dim _groupId As String
        Dim _Site As String
        Dim _Level As String

        Public Property Username() As String
            Get
                Return _Username
            End Get
            Set(ByVal value As String)
                _Username = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property AdminStatus() As Boolean
            Get
                Return _AdminStatus
            End Get
            Set(ByVal value As Boolean)
                _AdminStatus = value
            End Set
        End Property
        Public Property Group() As String
            Get
                Return _group
            End Get
            Set(ByVal value As String)
                _group = value
            End Set
        End Property
        Public Property GroupID() As String
            Get
                Return _groupId
            End Get
            Set(ByVal value As String)
                _groupId = value
            End Set
        End Property
        Public Property Site() As String
            Get
                Return _Site
            End Get
            Set(ByVal value As String)
                _Site = value
            End Set
        End Property
        Public Property Level() As String
            Get
                Return _Level
            End Get
            Set(ByVal value As String)
                _Level = value
            End Set
        End Property
    End Class



    Public Class TransactionHelper
        Dim _Cmd As New SqlCommand
        Public Property Command() As SqlCommand
            Get
                Return _Cmd
            End Get
            Set(ByVal value As SqlCommand)
                _Cmd = value
            End Set
        End Property
    End Class

    'Public Class SQLHelper

    '    Public Function GetDataSet(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 30) As DataSet
    '        Dim conn As SqlConnection = Nothing
    '        Dim da As SqlDataAdapter = Nothing
    '        Dim dsa As New DataSet
    '        Try
    '            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
    '                gh_Trans.Command.CommandType = CommandType.Text
    '                gh_Trans.Command.CommandText = pQuery
    '                gh_Trans.Command.CommandTimeout = pTimeOut
    '                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
    '            Else
    '                conn = New SqlConnection(GetConnString)
    '                da = New SqlDataAdapter(pQuery, conn)
    '            End If
    '            da.Fill(dsa)
    '            da = Nothing
    '            Return dsa
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Function

    '    Public Function GetDataSetByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataSet
    '        Dim conn As SqlConnection = Nothing
    '        Dim da As SqlDataAdapter = Nothing
    '        Dim dsa As New DataSet
    '        Try
    '            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
    '                gh_Trans.Command.CommandType = CommandType.StoredProcedure
    '                gh_Trans.Command.CommandText = pQuery
    '                gh_Trans.Command.CommandTimeout = pTimeOut
    '                gh_Trans.Command.Parameters.Clear()
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        gh_Trans.Command.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
    '            Else
    '                conn = New SqlConnection(GetConnString)
    '                conn.Open()
    '                Dim cmd As New SqlCommand
    '                cmd.CommandType = CommandType.StoredProcedure
    '                cmd.CommandText = pQuery
    '                cmd.Connection = conn
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        cmd.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                conn.Open()
    '                da = New SqlDataAdapter(cmd)
    '            End If
    '            da.Fill(dsa)
    '            da = Nothing
    '            Return dsa
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Function

    '    Public Function GetDataTable(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 30) As DataTable
    '        Dim conn As SqlConnection = Nothing
    '        Dim dta As New DataTable
    '        Dim da As SqlDataAdapter = Nothing
    '        Try
    '            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
    '                gh_Trans.Command.CommandType = CommandType.Text
    '                gh_Trans.Command.CommandText = pQuery
    '                gh_Trans.Command.CommandTimeout = pTimeOut
    '                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
    '            Else
    '                conn = New SqlConnection(GetConnString)
    '                da = New SqlDataAdapter(pQuery, conn)
    '            End If
    '            da.Fill(dta)
    '            da = Nothing
    '            Return dta
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Function

    '    Public Function GetDataTableByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataTable
    '        Dim conn As SqlConnection = Nothing
    '        Dim dta As New DataTable
    '        Dim da As SqlDataAdapter = Nothing
    '        Try
    '            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
    '                gh_Trans.Command.CommandType = CommandType.StoredProcedure
    '                gh_Trans.Command.CommandText = pQuery
    '                gh_Trans.Command.CommandTimeout = pTimeOut
    '                gh_Trans.Command.Parameters.Clear()
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        gh_Trans.Command.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
    '            Else
    '                conn = New SqlConnection(GetConnString)
    '                conn.Open()
    '                Dim cmd As New SqlCommand
    '                cmd.CommandType = CommandType.StoredProcedure
    '                cmd.CommandText = pQuery
    '                cmd.Connection = conn
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        cmd.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                conn.Open()
    '                da = New SqlDataAdapter(cmd)
    '            End If
    '            da.Fill(dta)
    '            da = Nothing
    '            Return dta
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Function

    '    Public Function ExecQuery(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 30) As Integer
    '        Dim pRowAff As Integer = -1
    '        Try
    '            If gh_Trans IsNot Nothing AndAlso IsNothing(gh_Trans.Command) = False Then
    '                gh_Trans.Command.CommandType = CommandType.Text
    '                gh_Trans.Command.CommandText = pQuery
    '                gh_Trans.Command.CommandTimeout = pTimeOut
    '                pRowAff = gh_Trans.Command.ExecuteNonQuery()
    '            Else
    '                Using Conn1 As New SqlClient.SqlConnection
    '                    Conn1.ConnectionString = GetConnString()
    '                    Dim cmd As New SqlClient.SqlCommand(pQuery, Conn1)
    '                    Conn1.Open()
    '                    pRowAff = cmd.ExecuteNonQuery()
    '                End Using
    '            End If
    '            Return pRowAff
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Function

    '    Public Function ExecQueryByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 30) As Integer
    '        Dim pRowAff As Integer = -1
    '        Try
    '            If gh_Trans IsNot Nothing AndAlso IsNothing(gh_Trans.Command) = False Then
    '                gh_Trans.Command.CommandType = CommandType.StoredProcedure
    '                gh_Trans.Command.CommandText = pQuery
    '                gh_Trans.Command.CommandTimeout = pTimeOut
    '                gh_Trans.Command.Parameters.Clear()
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        gh_Trans.Command.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                pRowAff = gh_Trans.Command.ExecuteNonQuery()
    '            Else
    '                Using Conn1 As New SqlClient.SqlConnection
    '                    If pConnStr <> "" Then
    '                        Conn1.ConnectionString = pConnStr
    '                    Else
    '                        Conn1.ConnectionString = GetConnString()
    '                    End If
    '                    Dim cmd As New SqlCommand
    '                    cmd.CommandType = CommandType.StoredProcedure
    '                    cmd.CommandText = pQuery
    '                    cmd.Connection = Conn1
    '                    If pParam IsNot Nothing Then
    '                        For i As Integer = 0 To pParam.Length - 1
    '                            cmd.Parameters.Add(pParam(i))
    '                        Next
    '                    End If
    '                    Conn1.Open()
    '                    pRowAff = cmd.ExecuteNonQuery()
    '                End Using
    '            End If
    '            Return pRowAff
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Function

    'End Class

End Namespace
