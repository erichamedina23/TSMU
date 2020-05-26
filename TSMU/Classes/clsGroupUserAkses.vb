Imports System.Collections.ObjectModel
Public Class clsGroupUserAkses
    Private _Query As String
    Public Property UserGroupCode() As String
    Public Property UserGroupName() As String
    Public Property FlagActive() As Integer


    Public Sub New()
        _Query =
            "select 
            a.UserGroupCode [Group Code],
            a.UserGroupName [Group Name],
            c.MenuDescription [Menu Name],
            b.Access [View],
            b.[Insert],
            b.[Delete],
            b.[Update],
            b.[Special] [Report] 
            from I_AccessLevel a inner join 
            S_GroupPermission b on a.UserGroupCode = b.[Group] inner join
            S_UserMenu c on b.MenuCode = c.MenuCode
            where a.FlagActive =1 order by [Group Code] asc"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(_Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllGroup() As DataTable
        Try
            Dim ls_SP As String =
                "SELECT] [UserGroupCode] [Group Code] 
                ,   [UserGroupName] [Group Name]  
                FROM [I_AccessLevel]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllMenu() As DataTable
        Try
            Dim ls_SP As String =
                "SELECT] [UserGroupCode] [Group Code] 
                ,   [UserGroupName] [Group Name]  
                FROM [I_AccessLevel]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal GroupCode As String)
        Try
            Dim query As String =
                "SELECT RTRIM([UserGroupCode]) [Group Code] 
                ,   [UserGroupName] [Group Name]  
                ,   [FlagActive] [Status] 
                FROM [I_AccessLevel] WHERE [UserGroupCode] = " & QVal(GroupCode) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    UserGroupCode = .Item("Group Code").ToString
                    UserGroupName = .Item("Group Name").ToString
                    FlagActive = .Item("Status")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If UserGroupCode = "" OrElse UserGroupName = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 invtId from Inventory_lc where invtId = " & QVal(UserGroupCode) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & UserGroupCode & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String =
                "INSERT INTO [I_AccessLevel]
                    ([UserGroupCode]
                    ,[UserGroupName]
                    ,[AccessLevel]
                    ,[FlagActive])
                VALUES
                    (" & QVal(UserGroupCode) & "
                    ," & QVal(UserGroupName) & "
                    ,(SELECT hasil + 10 from
                        (SELECT TOP 1 CAST([AccessLevel] AS INT) Hasil from I_AccessLevel order by [AccessLevel] desc) a)
                    ," & QVal(FlagActive) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateHeader()
        Try
            Dim ls_SP As String =
            "UPDATE [dbo].[I_AccessLevel] 
                SET [UserGroupName] = " & QVal(UserGroupName) & "
                ,[FlagActive] = " & QVal(FlagActive) & "
            WHERE [UserGroupCode] = " & QVal(UserGroupCode) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteHeader()
        Try
            Dim ls_SP As String =
            "DELETE FROM [dbo].[I_AccessLevel]
            WHERE [UserGroupCode] = " & QVal(UserGroupCode) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class

