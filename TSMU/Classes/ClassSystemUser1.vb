Imports System.Collections.ObjectModel
Public Class ClassSystemUser1
    Dim _Username As String
    Dim _Password As String
    Dim _Name As String
    Dim _Remark As String
    Dim _AdminStatus As Boolean
    Dim _FlagActive As Boolean
    Dim _UserGroupCode As String
    Dim _UserGroupName As String
    Dim _AccessLevel As String
    Dim _LastLogin As DateTime
    Dim _Site As String
    Dim _Level As String
    Dim ls_Error As String = ""
    Dim _Query As String

    Public Function Clone() As ClassSystemUser1
        Return DirectCast(Me.MemberwiseClone, ClassSystemUser1)
    End Function

    Public Sub New()
        Me._Query =
                    "SELECT RTrim(TU.[Username]) As [Username] " & vbCrLf &
                    "      ,TU.[Password] " & vbCrLf &
                    "      ,RTrim(TU.[Name]) As [Name] " & vbCrLf &
                    "      ,TU.[Remark] " & vbCrLf &
                    "      ,TU.[AdminStatus] AS [Admin Status] " & vbCrLf &
                    "      ,TU.[FlagActive] AS [Flag Active] " & vbCrLf &
                    "      ,TU.[UserGroupCode] AS [User Group Code] " & vbCrLf &
                    "      ,IAL.[UserGroupName] AS [User Group Name] " & vbCrLf &
                    "      ,IAL.[AccessLevel] AS [Access Level] " & vbCrLf &
                    "      ,COALESCE(TU.[LastLogin],0) AS [Last Login] " & vbCrLf &
                    "      ,TU.[Site] " & vbCrLf &
                    "      ,TU.[Level] " & vbCrLf &
                    "  FROM [S_User] TU " & vbCrLf &
                    "   Left Join I_AccessLevel IAL On TU.[UserGroupCode] = IAL.[UserGroupCode]" & vbCrLf &
                    " " & vbCrLf &
                    ""

        'Me._QueryComboAll = _
        '            "SELECT [Username], [Nama] FROM ( " & vbCrLf & _
        '            "SELECT '' As [Username] " & vbCrLf & _
        '            "      ,'' As [Nama] " & vbCrLf & _
        '            "      ,0 As [OrderBy] " & vbCrLf & _
        '            "UNION ALL " & vbCrLf & _
        '            "SELECT RTrim([Username]) As [Username] " & vbCrLf & _
        '            "      ,RTrim([Nama]) As [Nama] " & vbCrLf & _
        '            "      ,1 As [OrderBy] " & vbCrLf & _
        '            "  FROM [tb_User] " & vbCrLf & _
        '            ") A " & vbCrLf & _
        '            "Order By OrderBy, 1 " & vbCrLf & _
        '            " " & vbCrLf & _
        '            ""

        'Me._QueryNameList = _
        '            "SELECT RTrim([Username]) As [Username] " & vbCrLf & _
        '            "      ,RTrim([Nama]) As [Nama] " & vbCrLf & _
        '            "  FROM [tb_User] "
    End Sub

#Region "Properties"
    Property Username() As String
        Get
            Return Me._Username
        End Get
        Set(ByVal value As String)
            Me._Username = value
        End Set
    End Property

    Property Name() As String
        Get
            Return Me._Name
        End Get
        Set(ByVal value As String)
            Me._Name = value
        End Set
    End Property

    Property Password() As String
        Get
            Return Me._Password
        End Get
        Set(ByVal value As String)
            Me._Password = value
        End Set
    End Property

    Property Remark() As String
        Get
            Return Me._Remark
        End Get
        Set(ByVal value As String)
            Me._Remark = value
        End Set
    End Property

    Property LastLogin() As DateTime
        Get
            Return Me._LastLogin
        End Get
        Set(ByVal value As DateTime)
            Me._LastLogin = value
        End Set
    End Property

    Property AdminStatus() As Boolean
        Get
            Return Me._AdminStatus
        End Get
        Set(ByVal value As Boolean)
            Me._AdminStatus = value
        End Set
    End Property

    Property FlagActive() As Boolean
        Get
            Return Me._FlagActive
        End Get
        Set(ByVal value As Boolean)
            Me._FlagActive = value
        End Set
    End Property
    Property UserGroupCode() As String
        Get
            Return Me._UserGroupCode
        End Get
        Set(ByVal value As String)
            Me._UserGroupCode = value
        End Set
    End Property
    Property UserGroupName() As String
        Get
            Return Me._UserGroupName
        End Get
        Set(ByVal value As String)
            Me._UserGroupName = value
        End Set
    End Property
    Property AccessLevel() As String
        Get
            Return Me._AccessLevel
        End Get
        Set(ByVal value As String)
            Me._AccessLevel = value
        End Set
    End Property
    Property Site() As String
        Get
            Return Me._Site
        End Get
        Set(ByVal value As String)
            Me._Site = value
        End Set
    End Property
    Property Level() As String
        Get
            Return Me._Level
        End Get
        Set(ByVal value As String)
            Me._Level = value
        End Set
    End Property
#End Region

    Public Sub GetData(ByVal pKode As String, Optional ByVal pNotShownTidakKetemuMsg As Boolean = False)
        Try
            Que = Me._Query & vbCrLf & " WHERE TU.Username = " & QVal(pKode)
            Dim dt As DataTable = MainModul.GetDataTable(Que)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me._Username = Trim(.Item("Username") & "")
                    Me._Name = Trim(.Item("Name") & "")
                    'Me._Password = Trim(.Item("Password") & "")
                    Me._AdminStatus = IIf(Trim(.Item("Admin Status") & "") = "" OrElse Trim(.Item("Admin Status") & "") = "0", False, True)
                    Me._FlagActive = IIf(Trim(.Item("Flag Active") & "") = "" OrElse Trim(.Item("Flag Active") & "") = "0", False, True)
                    Me._Remark = Trim(.Item("Remark") & "")
                    If .Item("Last Login") < MyMinDate Then
                        Me._LastLogin = Nothing
                    Else
                        Me._LastLogin = .Item("Last Login")
                    End If
                    Me._UserGroupCode = Trim(.Item("User Group Code") & "")
                    Me._UserGroupName = Trim(.Item("User Group Name") & "")
                    Me._AccessLevel = Trim(.Item("Access Level") & "")
                    Me._Site = Trim(.Item("Site") & "")
                    Me._Level = Trim(.Item("Level") & "")
                End With
            Else
                If pNotShownTidakKetemuMsg = False Then
                    Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTidakKetemu))
                End If
            End If
        Catch Ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetAllData() As Collection(Of ClassSystemUser1)
        Try
            Dim query As String = Me._Query & vbCrLf & "ORDER BY Username ASC"
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Dim i As Integer
            Dim pObjList As New Collection(Of ClassSystemUser1)
            pObjList.Clear()

            For i = 0 To dt.Rows.Count - 1
                With dt.Rows(i)
                    Dim objClass As New ClassSystemUser1
                    objClass._Username = Trim(.Item("Username") & "")
                    objClass._Name = Trim(.Item("Name") & "")
                    objClass._Password = Trim(.Item("Password") & "")
                    objClass._AdminStatus = IIf(Trim(.Item("Admin Status") & "") = "", 0, .Item("Admin Status"))
                    objClass._FlagActive = IIf(Trim(.Item("Flag Active") & "") = "", 0, .Item("Flag Active"))
                    objClass._Remark = Trim(.Item("Remark") & "")
                    If .Item("Last Login") < MyMinDate Then
                        objClass._LastLogin = Now
                    Else
                        objClass._LastLogin = .Item("Last Login")
                    End If
                    objClass._UserGroupCode = Trim(.Item("UserGroupCode") & "")
                    objClass._UserGroupName = Trim(.Item("UserGroupName") & "")
                    objClass._AccessLevel = Trim(.Item("AccessLevel") & "")
                    pObjList.Add(objClass)
                    objClass = Nothing
                End With
            Next
            Return pObjList
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllDataTable() As DataTable
        Try
            Dim query As String = Me._Query '& QueryOrder
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllDataTableComboAll() As DataTable
        Try
            Dim query As String = _
                "SELECT [Username], [Name] " & vbCrLf & _
                "FROM " & vbCrLf & _
                "   ( " & vbCrLf & _
                "   SELECT '' As [Username] " & vbCrLf & _
                "       ,'' As [Name] " & vbCrLf & _
                "       ,0 As [OrderBy] " & vbCrLf & _
                "   UNION ALL " & vbCrLf & _
                "   SELECT RTrim([Username]) As [Username] " & vbCrLf & _
                "       ,RTrim([Name]) As [Name] " & vbCrLf & _
                "       ,1 As [OrderBy] " & vbCrLf & _
                "   FROM [S_User] " & vbCrLf & _
                "   ) A " & vbCrLf & _
                "Order By OrderBy, 1 " & vbCrLf & _
                " "
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllNameListDataTable() As DataTable
        Try
            Dim query As String = _
                "SELECT RTrim([Username]) As [Username] " & vbCrLf & _
                "      ,RTrim([Name]) As [Name] " & vbCrLf & _
                "FROM [S_User] " & vbCrLf & _
                "ORDER BY 1 ASC"
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllUserMenuDataTable() As DataTable
        Try
            Dim query As String = _
                "SELECT * FROM S_UserMenu " & vbCrLf & _
                "WHERE ParentMenu <> 'Setting' And FlagActive = '1' And AppID = '1' " & _
                "Order By APPID, SeqParentMenu, SeqMenu " & _
                ""
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function
    Public Function GetParentMenu() As DataTable
        Try
            Dim query As String = _
                "SELECT distinct parentmenu Main_Menu,cast(0 as bit) Access, cast(0 as bit) [Insert], cast(0 as bit) [Update] " & vbCrLf & _
                                    ",cast(0 as bit) [Delete] " & vbCrLf & _
                                    ",cast(0 as bit) Special " & vbCrLf & _
                "FROM S_UserMenu " & vbCrLf & _
                "WHERE FlagActive = '1' And AppID = '1' " & _
                ""
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function
    Public Function GetChildMenu(ByVal strParent As String) As DataTable
        Try
            Dim query As String = _
                "SELECT distinct a.MenuCode MenuCode, a.Title Menu_Child, cast(0 as bit) Access, cast(0 as bit) [Insert], cast(0 as bit) [Update], cast(0 as bit) [Delete], cast(0 as bit) Special FROM S_UserMenu a inner join" & vbCrLf & _
                "S_UserPermission b on a.menucode = b.menucode" & vbCrLf & _
                "WHERE a.ParentMenu = " & QVal(strParent) & " And a.FlagActive = '1' And a.AppID = '1' " & _
                ""
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Public Function GetUserAksesDataTableByUserName(ByVal ls_UserName As String) As DataTable
        Try
            Dim query As String = _
                "SELECT b.title,a.access,a.[insert],a.[update],a.[delete],a.special FROM S_UserPermission a inner join s_userMenu b on a.menucode=b.menucode " & vbCrLf & _
                "WHERE a.AppID = '1' And a.Username = " & QVal(ls_UserName) & _
                ""
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Public Function CheckLoginPassword(ByVal pUser As String, ByVal pPassword As String) As Boolean
        Dim lb_Result As Boolean = False
        Try
            Me.GetData(pUser, True)
            If Not Me._Username Is Nothing AndAlso Not Me._Password Is Nothing Then
                If StrComp(Me._Password, HashData(pPassword), CompareMethod.Binary) = 0 Then
                    lb_Result = True
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
        Return lb_Result
    End Function

    Public Function CheckLoginPasswordBinary(ByVal pUser As String, ByVal pPassword As String) As Boolean
        gs_Error = ""
        If Not Me._Username Is Nothing AndAlso Not Me._Password Is Nothing Then
            Dim query As String = "SELECT Username, Password, UserGroupCode, Site " & vbCrLf &
            "FROM S_User " & vbCrLf &
            "WHERE Username = " & QVal(Me._Username) & " " & vbCrLf &
            "AND Password = HASHBYTES('SHA1'," & QVal(Me._Password) & ") "
            Dim dtTable As DataTable = MainModul.GetDataTable(query)
            If dtTable.Rows.Count > 0 Then
                Me.GetData(pUser, True)
                Return True
            End If
        End If
        Return False
    End Function

    Public Function ValidateInsert() As String
        If Me._Username = "" Then
            Return "Please fill username !"
        ElseIf Me._Name = "" Then
            Return "Please fill name !"
        End If
        Try
            Que = "SELECT TOP 1 UserName FROM tb_User WHERE UserName = " & QVal(Me._Username) & " "
            Dim dt As DataTable = MainModul.GetDataTable(Que)
            If dt.Rows.Count > 0 Then
                Return "Username already exists !"
            End If
            Return ""
        Catch Ex As Exception
            Return "Get user data error! [" & Ex.Message & "]"
        End Try
    End Function

    Public Function ValidateUpdate() As String
        If Me._Username = "" Then
            Return "Please fill username !"
        ElseIf Me._Name = "" Then
            Return "Please fill name !"
        End If
        Return ""
    End Function

    Public Function ValidateDelete() As String
        Return ""
    End Function

    Public Sub InsertData()
        Try
            'Que = _
            '    "INSERT INTO [S_User] " & vbCrLf & _
            '    "	([Username] " & vbCrLf & _
            '    "	,[Password] " & vbCrLf & _
            '    "	,[Name] " & vbCrLf & _
            '    "	,[Remark] " & vbCrLf & _
            '    "	,[AdminStatus] " & vbCrLf & _
            '    "	,[FlagActive] " & vbCrLf & _
            '    "   ,[UserGroupCode] " & vbCrLf & _
            '    "	,[EntryDate] " & vbCrLf & _
            '    "	,[EntryUser]) " & vbCrLf & _
            '    "VALUES " & vbCrLf & _
            '    "	(" & QVal(Me._Username) & " " & vbCrLf & _
            '    "	," & QVal(HashData(Me._Password)) & " " & vbCrLf & _
            '    "	," & QVal(Me._Name) & " " & vbCrLf & _
            '    "	," & QVal(Me._Remark) & " " & vbCrLf & _
            '    "	," & QVal(Me._AdminStatus) & " " & vbCrLf & _
            '    "	," & QVal(Me._FlagActive) & " " & vbCrLf & _
            '    "	," & QVal(Me._UserGroupCode) & " " & vbCrLf & _
            '    "	,GETDATE() " & vbCrLf & _
            '    "	," & QVal(gh_Common.Username) & ") " & vbCrLf & _
            '    " "
            Que =
                "INSERT INTO [S_User] " & vbCrLf &
                "	([Username] " & vbCrLf &
                "	,[Password] " & vbCrLf &
                "	,[Name] " & vbCrLf &
                "	,[Remark] " & vbCrLf &
                "	,[AdminStatus] " & vbCrLf &
                "	,[FlagActive] " & vbCrLf &
                "   ,[UserGroupCode] " & vbCrLf &
                "   ,[Site] " & vbCrLf &
                "   ,[Level] " & vbCrLf &
                "	,[EntryDate] " & vbCrLf &
                "	,[EntryUser]) " & vbCrLf &
                "VALUES " & vbCrLf &
                "	(" & QVal(Me._Username) & " " & vbCrLf &
                "	,HASHBYTES('SHA1'," & QVal(Me._Password) & ") " & vbCrLf &
                "	," & QVal(Me._Name) & " " & vbCrLf &
                "	," & QVal(Me._Remark) & " " & vbCrLf &
                "	," & QVal(Me._AdminStatus) & " " & vbCrLf &
                "	," & QVal(Me._FlagActive) & " " & vbCrLf &
                "	," & QVal(Me._UserGroupCode) & " " & vbCrLf &
                "	," & QVal(Me._Site) & " " & vbCrLf &
                "	," & QVal(Me._Level) & " " & vbCrLf &
                "	,GETDATE() " & vbCrLf &
                "	," & QVal(gh_Common.Username) & ") " & vbCrLf &
                " "
            MainModul.ExecQuery(Que)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Que =
                "UPDATE [S_User] " & vbCrLf &
                "SET [Name] = " & QVal(Me._Name) & " " & vbCrLf &
                "	,[Remark] = " & QVal(Me._Remark) & " " & vbCrLf &
                "	,[AdminStatus] = " & QVal(Me._AdminStatus) & " " & vbCrLf &
                "	,[FlagActive] = " & QVal(Me._FlagActive) & " " & vbCrLf &
                "	,[UserGroupCode] = " & QVal(Me._UserGroupCode) & " " & vbCrLf &
                "	,[Site] = " & QVal(Me.Site) & " " & vbCrLf &
                "	,[Level] = " & QVal(Me.Level) & " " & vbCrLf &
                "	,[UpdateDate] = GETDATE() " & vbCrLf &
                "	,[UpdateUser] = " & QVal(gh_Common.Username) & " " & vbCrLf &
                "WHERE [Username] = " & QVal(Me._Username) & " " & vbCrLf &
                " "
            MainModul.ExecQuery(Que)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdatePassword()
        Try
            'Que = _
            '    "UPDATE [S_User] " & vbCrLf & _
            '    "SET [Password] = " & QVal(HashData(Me._Password)) & " " & vbCrLf & _
            '    "	,[UpdateDate] = GETDATE() " & vbCrLf & _
            '    "	,[UpdateUser] = " & QVal(gh_Common.Username) & " " & vbCrLf & _
            '    "WHERE [Username] = " & QVal(Me._Username) & " " & vbCrLf & _
            '    " "
            Que = _
                "UPDATE [S_User] " & vbCrLf & _
                "SET [Password] = HASHBYTES('SHA1'," & QVal(Me._Password) & ")" & vbCrLf & _
                "	,[UpdateDate] = GETDATE() " & vbCrLf & _
                "	,[UpdateUser] = " & QVal(gh_Common.Username) & " " & vbCrLf & _
                "WHERE [Username] = " & QVal(Me._Username) & " " & vbCrLf & _
                " "
            Dim li_Row = MainModul.ExecQuery(Que)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateLastLogin()
        Try
            Que = _
                "UPDATE [S_User] " & vbCrLf & _
                "SET [LastLogin] = GETDATE() " & vbCrLf & _
                "WHERE [Username] = " & QVal(Me._Username) & " " & vbCrLf & _
                " "
            Dim li_Row = MainModul.ExecQuery(Que)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteData()
        Try
            Que = _
                "DELETE [dbo].[S_User] " & vbCrLf & _
                "WHERE [UserName] = " & QVal(Me._Username) & " "
            Dim li_Row = MainModul.ExecQuery(Que)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetComboGroup() As DataTable
        Try
            Dim query As String = _
                "SELECT '' as UserGroupCode, '' as UserGroupName FROM I_AccessLevel UNION " & vbCrLf & _
                "SELECT UserGroupCode,UserGroupName FROM I_AccessLevel " & vbCrLf & _
                "WHERE FlagActive = '1' "
            Dim dt As DataTable = MainModul.GetDataTable(query)
            Return dt
        Catch Ex As Exception
            Throw
        End Try
    End Function
    Public Function getMenuAccess(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String = "sp_user_getMenuAccess"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

            pParam(0) = New SqlClient.SqlParameter("@username", SqlDbType.VarChar)
            pParam(0).Value = ls_Filter

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(ls_SP, pParam)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "USER NEW"
    Public Function getDataGrid(ByVal ls_Filter As String) As DataTable
        Try
            Dim Query As String =
                    "SELECT [Username] " & vbCrLf &
                    "   ,[Name] " & vbCrLf &
                    "   ,[Remark] " & vbCrLf &
                    "   ,[AdminStatus] " & vbCrLf &
                    "   ,[FlagActive] " & vbCrLf &
                    "   ,[UserGroupCode] " & vbCrLf &
                    "FROM [S_User]"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(Query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getDataByUsername1(ByVal username As String) As DataTable
        Try
            Dim Query As String =
                    "SELECT [Username] " & vbCrLf &
                    "   ,[Name] " & vbCrLf &
                    "   ,[Remark] " & vbCrLf &
                    "   ,[AdminStatus] " & vbCrLf &
                    "   ,[FlagActive] " & vbCrLf &
                    "   ,[UserGroupCode] " & vbCrLf &
                    "FROM [S_User] " & vbCrLf &
                    "WHERE Username = " & QVal(username) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(Query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByUserName(ByVal username As String)
        Try
            Dim Query As String = _
                    "SELECT a.[Username] [Username] " & vbCrLf & _
                    "   ,a.[Name] [Name] " & vbCrLf & _
                    "   ,a.[Password] [Password] " & vbCrLf & _
                    "   ,a.[Remark] [Remark] " & vbCrLf & _
                    "   ,a.[AdminStatus] [AdminStatus] " & vbCrLf & _
                    "   ,a.[FlagActive] [FlagActive] " & vbCrLf & _
                    "   ,b.[UserGroupName]  [UserGroupName] " & vbCrLf & _
                    "FROM [S_User] a INNER JOIN I_AccessLevel b ON a.UserGroupCode = b.UserGroupCode " & vbCrLf & _
                    "WHERE a.[Username] = " & QVal(username) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._Username = Trim(.Item("Username") & "")
                    Me._Name = Trim(.Item("Name") & "")
                    Me._Password = Convert.ToString(.Item("Password"))
                    Me._Remark = Trim(.Item("Remark") & "")
                    Me._AdminStatus = Trim(.Item("AdminStatus") & "")
                    Me._FlagActive = Trim(.Item("FlagActive") & "")
                    Me._UserGroupName = Trim(.Item("UserGroupName") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
