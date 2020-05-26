Imports System.Collections.ObjectModel
Public Class clsBoM_Budget_Calculated

    Private _bomid As String
    Public Property BoMID() As String
        Get
            Return _bomid
        End Get
        Set(ByVal value As String)
            _bomid = value
        End Set
    End Property
    Private _tgl As Date
    Public Property Tgl() As Date
        Get
            Return _tgl
        End Get
        Set(ByVal value As Date)
            _tgl = value
        End Set
    End Property

    Private _invtid As String
    Public Property InvtID() As String
        Get
            Return _invtid
        End Get
        Set(ByVal value As String)
            _invtid = value
        End Set
    End Property

    Private _desc As String
    Public Property Desc() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Private _siteid As String
    Public Property SiteID() As String
        Get
            Return _siteid
        End Get
        Set(ByVal value As String)
            _siteid = value
        End Set
    End Property

    Private _runner As String
    Public Property Runner() As String
        Get
            Return _runner
        End Get
        Set(ByVal value As String)
            _runner = value
        End Set
    End Property

    Private _ct As String
    Public Property CycleTime() As String
        Get
            Return _ct
        End Get
        Set(ByVal value As String)
            _ct = value
        End Set
    End Property
    Private _mc As String
    Public Property MC() As String
        Get
            Return _mc
        End Get
        Set(ByVal value As String)
            _mc = value
        End Set
    End Property
    Private _allowance As Integer
    Public Property Allowance() As Integer
        Get
            Return _allowance
        End Get
        Set(ByVal value As Integer)
            _allowance = value
        End Set
    End Property

    Private _mp As String
    Public Property MP() As String
        Get
            Return _mp
        End Get
        Set(ByVal value As String)
            _mp = value
        End Set
    End Property
    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
    Private _active As Boolean
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property
    Public Property Tahun() As String
    Public Property Semester() As String
    Public Property Total() As String
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String =
            "SELECT a.[ID]
            ,a.[Tahun]
            ,a.[invtid] [Inventory ID]
            ,a.[descr] [Description]
            ,a.[Semester]
            ,(SELECT SUM(Jan_qty + feb_qty + mar_qty + apr_qty+mei_qty+jun_qty+jul_qty+agust_qty+sep_qty+okt_qty+nov_qty+des_qty)
            from calculated_bom_detail where id = a.id) as TOTAL
            FROM [calculated_bom] a"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String =
            "SELECT a.[ID]
                ,a.[Tahun]
                ,a.[bomId]
                ,a.[invtid]
                ,a.[descr]
                ,a.[Semester]
                ,(SELECT SUM(Jan_qty + feb_qty + mar_qty + apr_qty+mei_qty+jun_qty+jul_qty+agust_qty+sep_qty+okt_qty+nov_qty+des_qty) 
                from calculated_bom_detail where bomId = a.bomId) as TOTAL
            FROM [calculated_bom] a where a.ID = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._bomid = Trim(.Item("bomid") & "")
                    Me._invtid = Trim(.Item("invtid") & "")
                    Me._desc = Trim(.Item("descr") & "")
                    Me.Semester = Trim(.Item("semester") & "")
                    Me.Tahun = Trim(.Item("Tahun") & "")
                    Me.Total = Trim(.Item("TOTAL") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getDetailBoM(ByVal BoMID As String, semester As String) As DataTable
        Try
            Dim dtTable As New DataTable

            If semester = "1" Then
                Dim query As String =
                "SELECT ROW_NUMBER() OVER (ORDER BY bomId) AS NO 
                    ,[invtid] [Inventory ID]
                    ,[descr] [Description]
                    ,[unit] [Unit]
                    ,[Level]
                    ,[Jan_qty] [Qty Jan]
                    ,[feb_qty] [Qty Feb]
                    ,[mar_qty] [Qty March]
                    ,[apr_qty] [Qty Apr]
                    ,[mei_qty] [Qty Mei]
                    ,[jun_qty] [Qty Jun]
                FROM [calculated_bom_detail] where bomid = " & QVal(BoMID) & ""
                dtTable = MainModul.GetDataTableByCommand(query)
            Else
                Dim query As String =
                "SELECT ROW_NUMBER() OVER (ORDER BY bomId) AS NO 
                    ,[invtid]
                    ,[descr]
                    ,[unit]
                    ,[Level]
                    ,[jul_qty]
                    ,[agust_qty]
                    ,[sep_qty]
                    ,[okt_qty]
                    ,[nov_qty]
                    ,[des_qty]
                FROM [calculated_bom_detail] where bomid = " & QVal(BoMID) & ""
                dtTable = MainModul.GetDataTableByCommand(query)
            End If
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function


    '#Region "CRUD"
    '    Public Sub InsertHeader()
    '        Try
    '            Dim ls_SP As String = " " & vbCrLf &
    '                                    "Insert into bomh(bomid,tgl,invtid,descr,siteid,runner,ct,mc,allowance, mp, [status],active,created_by,created_date) " & vbCrLf &
    '                                    "       OUTPUT  Inserted.bomid, " & vbCrLf &
    '                                    "               Inserted.tgl, " & vbCrLf &
    '                                    "               Inserted.invtid, " & vbCrLf &
    '                                    "               Inserted.descr, " & vbCrLf &
    '                                    "               Inserted.siteid, " & vbCrLf &
    '                                    "               Inserted.runner, " & vbCrLf &
    '                                    "               Inserted.ct, " & vbCrLf &
    '                                    "               Inserted.mc, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               Inserted.allowance, " & vbCrLf &
    '                                    "               Inserted.mp, " & vbCrLf &
    '                                    "               Inserted.[status], " & vbCrLf &
    '                                    "               Inserted.[active], " & vbCrLf &
    '                                    "               0, " & vbCrLf &
    '                                    "               Inserted.created_by, " & vbCrLf &
    '                                    "               Inserted.created_date, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               NULL " & vbCrLf &
    '                                    "       Into bom_header_history " & vbCrLf &
    '                                    "Values(" & QVal(Me._bomid) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._tgl) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._invtid) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._desc) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._siteid) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._runner) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._ct) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._mc) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._allowance) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._mp) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._status) & ", " & vbCrLf &
    '                                    "       " & QVal(Me._active) & ", " & vbCrLf &
    '                                    "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
    '                                    "       getdate())"
    '            ExecQuery(ls_SP)
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Sub
    '    Public Sub UpdateHeader(ByVal rev As Int32)
    '        Try
    '            Dim ls_SP As String = " " & vbCrLf &
    '                                    "Update bomh " & vbCrLf &
    '                                    "SET    tgl = " & QVal(Me._tgl) & ", " & vbCrLf &
    '                                    "       invtid = " & QVal(Me._invtid) & ", " & vbCrLf &
    '                                    "       descr = " & QVal(Me._desc) & ", " & vbCrLf &
    '                                    "       siteid = " & QVal(Me._siteid) & ", " & vbCrLf &
    '                                    "       runner = " & QVal(Me._runner) & ", " & vbCrLf &
    '                                    "       ct = " & QVal(Me._ct) & ", " & vbCrLf &
    '                                    "       mc = " & QVal(Me._mc) & ", " & vbCrLf &
    '                                    "       allowance = " & QVal(Me._allowance) & ", " & vbCrLf &
    '                                    "       mp = " & QVal(Me._mp) & ", " & vbCrLf &
    '                                    "       [status] = " & QVal(Me._status) & ", " & vbCrLf &
    '                                    "       [active] = " & QVal(Me._active) & ", " & vbCrLf &
    '                                    "       [updated_by] = " & QVal(gh_Common.Username) & ", " & vbCrLf &
    '                                    "       updated_date = getdate() " & vbCrLf &
    '                                    "       OUTPUT  '" & Me._bomid & "', " & vbCrLf &
    '                                    "               Inserted.tgl, " & vbCrLf &
    '                                    "               Inserted.invtid, " & vbCrLf &
    '                                    "               Inserted.descr, " & vbCrLf &
    '                                    "               Inserted.siteid, " & vbCrLf &
    '                                    "               Inserted.runner, " & vbCrLf &
    '                                    "               Inserted.ct, " & vbCrLf &
    '                                    "               Inserted.mc, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               Inserted.allowance, " & vbCrLf &
    '                                    "               Inserted.mp, " & vbCrLf &
    '                                    "               Inserted.[status], " & vbCrLf &
    '                                    "               Inserted.[active], " & vbCrLf &
    '                                    "               " & QVal(rev) & " + 1, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               NULL, " & vbCrLf &
    '                                    "               Inserted.updated_by, " & vbCrLf &
    '                                    "               Inserted.updated_date " & vbCrLf &
    '                                    "       Into bom_header_history " & vbCrLf &
    '                                    "       where bomid = '" & Me._bomid & "'"
    '            ExecQuery(ls_SP)
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Sub
    '    Public Sub DeleteHeader(ByVal bomid As String)
    '        Try
    '            Dim ls_SP As String = "Delete from bomh where bomid =" & QVal(bomid) & ""
    '            ExecQuery(ls_SP)
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Sub
    '#End Region
End Class

