Public Class clsReport
    Private _isactive As Boolean
    Public Property IsActive() As String
        Get
            Return _isactive
        End Get
        Set(ByVal value As String)
            _isactive = value
        End Set
    End Property
    Private _site As String
    Public Property Site() As String
        Get
            Return _site
        End Get
        Set(ByVal value As String)
            _site = value
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

#Region "General Function"
    Public Function getItem() As DataTable
        Try
            Dim query As String = "" & vbCrLf & _
                                    "   SELECT inventory.invtid,inventory.descr " & vbCrLf & _
                                    "   FROM " & vbCrLf & _
                                    "   itemxref INNER JOIN " & vbCrLf & _
                                    "   inventory on itemxref.invtid=inventory.invtid where inventory.transtatuscode='AC' and itemxref.altIDType='C' order by inventory.descr"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getCustomer() As DataTable
        Try
            Dim query As String = "SELECT distinct custid [Customer ID],name [Name] FROM customer order by name"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region
#Region "BoM"
    Public Function reportAllBoM(ByVal strStatus As String, ByVal strSite As String) As DataSet
        Try
            Dim query As String = "select " & _
                                    "h.parentid, " & _
                                    "d.invtid, " & _
                                    "d.qty, " & _
                                    "h.descr as h_desc, " & _
                                    "d.descr, " & _
                                    "d.unit StkUnit, " & _
                                    "h.siteid, " & _
                                    "h.runner, " & _
                                    "h.ct, " & _
                                    "h.mc, " & _
                                    "h.cavity, " & _
                                    "h.wc, " & _
                                    "h.allowance, " & _
                                    "h.status, " & _
                                    "h.active " & _
                                "from " & _
                                    "(SELECT  " & _
                                        "a.invtid as parentid " & _
                                        ",b.descr " & _
                                        ",b.StkUnit " & _
                                        ",a.siteid " & _
                                        ",a.runner " & _
                                        ",a.ct " & _
                                        ",a.mc " & _
                                        ",a.cavity " & _
                                        ",a.wc " & _
                                        ",a.allowance " & _
                                        ",a.status " & _
                                        ",a.active " & _
                                    "from  bomh a inner join inventory b on a.invtid=b.invtid) h cross join " & _
                                    "bom d where d.parentid = h.parentid"
            If strSite = "" AndAlso strStatus = "" Then
                query = query
            ElseIf strSite <> "" AndAlso strStatus <> "" Then
                query = query + " and h.siteid = " & QVal(strSite) & " and h.status = " & QVal(strStatus) & ""
            ElseIf strSite <> "" AndAlso strStatus = "" Then
                query = query + " and h.siteid = " & QVal(strSite) & ""
            ElseIf strSite = "" AndAlso strStatus <> "" Then
                query = query + " and h.status = " & QVal(strStatus) & ""
            End If

            Dim ds As New DataSet
            ds = GetDsReport(query, "view_bom")
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function View_BoMRouting(ByVal strSite As String, ByVal strStatus As String, ByVal strInvtid As String) As DataSet
        Try
            Dim query As String = "BoMRouting_Report"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@statusBoM", SqlDbType.VarChar)
            pParam(1).Value = strStatus
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            Dim ds As New DataSet
            ds = GetDataSetByCommand_SP(query, "BoM_Routing", pParam)
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function



    Public Function DataGridBoMRouting(ByVal strSite As String, ByVal strStatus As String, ByVal strInvtid As String) As DataTable
        Try
            Dim query As String = "BoMRouting"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@statusBoM", SqlDbType.VarChar)
            pParam(1).Value = strStatus
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function DataGridBoMUsedBy(ByVal strInvtid As String) As DataTable
        Try
            Dim query As String = "sp_BoM_UsedBy"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@parent1", SqlDbType.VarChar)
            pParam(0).Value = strInvtid

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    '''' <summary>
    '''' Get Data BoM Routing
    '''' </summary>
    '''' <param name="vpFilter"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function PrintBomRouting(ByVal strSite As String, ByVal strStatus As String, ByVal strInvtid As String, ByVal report As String) As Object
    '    Try
    '        'Dim CRPrint As New CR_VIC
    '        Dim fc_Class As New clsReport

    '        Dim CRPrint As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '        'Dim dt As New DataTable
    '        'dt = fc_Class.DataGridBoMRouting(strSite, strStatus, strInvtid)

    '        Dim ds As New DataSet
    '        ds = fc_Class.View_BoMRouting(strSite, strStatus, strInvtid)
    '        If report = "BoM_Routing" Then
    '            CRPrint.Load(Application.StartupPath & "\Report\BoM_Routing.rpt")
    '        Else
    '            CRPrint.Load(Application.StartupPath & "\Report\BoM_MaterialUsedBy.rpt")
    '        End If

    '        Dim crTableLogOnInfo As New CrystalDecisions.Shared.TableLogOnInfo

    '        Dim crConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo
    '        crConnectionInfo.ServerName = gs_DBServer
    '        crConnectionInfo.DatabaseName = gs_Database
    '        crConnectionInfo.UserID = gs_DBUserName
    '        crConnectionInfo.Password = gs_DBPassword
    '        crConnectionInfo.IntegratedSecurity = IIf(gs_DBAuthMode = "mixed", False, True)
    '        crTableLogOnInfo = CRPrint.Database.Tables(0).LogOnInfo
    '        crTableLogOnInfo.ConnectionInfo = crConnectionInfo
    '        CRPrint.Database.Tables(0).ApplyLogOnInfo(crTableLogOnInfo)

    '        CRPrint.SetDataSource(ds)

    '        Return CRPrint
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function


    Public Function Report_MultiLevelBoM(ByVal strInvtID As String) As DataSet
        Try
            Dim query As String = "sp_multi_level_BoM"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@inventoryID", SqlDbType.VarChar)
            pParam(0).Value = strInvtID
            'pParam(1) = New SqlClient.SqlParameter("@statusBoM", SqlDbType.VarChar)
            'pParam(1).Value = strStatus
            'pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            'pParam(2).Value = strInvtid
            Dim ds As New DataSet
            ds = GetDataSetByCommand_SP(query, "MultiLevelBoM", pParam)
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function MultiLevelBoM(ByVal strInvtID As String) As DataTable
        Try
            Dim query As String = "sp_multi_level_BoM"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@inventoryID", SqlDbType.VarChar)
            pParam(0).Value = strInvtID
            'pParam(1) = New SqlClient.SqlParameter("@statusBoM", SqlDbType.VarChar)
            'pParam(1).Value = strStatus
            'pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            'pParam(2).Value = strInvtid
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function MultiLevelBoM_New(ByVal strInvtID As String, status As String) As DataTable
        Try
            Dim query As String = "GenerateMultiLevel"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@ParentId", SqlDbType.VarChar)
            pParam(0).Value = strInvtID
            pParam(1) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
            pParam(1).Value = status
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetMultiLevelDescription(ByVal dttable As DataTable) As DataTable
        Try
            Dim dtResult As New DataTable
            dtResult.Columns.Add("Level")
            dtResult.Columns.Add("Inventory ID")
            dtResult.Columns.Add("Description")
            dtResult.Columns.Add("Qty")
            dtResult.Columns.Add("Unit")
            dtResult.Clear()
            For Each row As DataRow In dttable.Rows
                Dim sql As String =
                "select * from ( " &
"select a.invtid, a.descr, '1' qty, b.stkunit unit from bomh a left join inventory b on a.invtid = b.invtid " &
"union " &
"select invtid, descr, qty, unit from bom " &
") bom where invtid = " & QVal(row("Inventory ID")) & ""
                '"Select b.descr, a.Qty, b.StkUnit from bom a inner join Inventory b on a.invtid = b.invtid where a.invtid = " & QVal(row("Inventory ID")) & ""
                Dim dt1 As New DataTable
                dt1 = MainModul.GetDataTableByCommand(sql)
                If dt1.Rows.Count > 0 Then
                    dtResult.Rows.Add()
                    dtResult.Rows(dtResult.Rows.Count - 1).Item(0) = row("level")
                    dtResult.Rows(dtResult.Rows.Count - 1).Item(1) = row("Inventory ID")
                    dtResult.Rows(dtResult.Rows.Count - 1).Item(2) = Trim(dt1.Rows(0).Item("descr") & "")
                    dtResult.Rows(dtResult.Rows.Count - 1).Item(3) = Trim(dt1.Rows(0).Item("Qty") & "")
                    dtResult.Rows(dtResult.Rows.Count - 1).Item(4) = Trim(dt1.Rows(0).Item("unit") & "")
                End If
            Next

            Return dtResult
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function getBoMheader() As DataTable
        Try
            Dim ls_SP As String = "SELECT  " & _
                                    "bomh.invtid as parentid " & _
                                    ",inventory.descr " & _
                                    ",bomh.siteid " & _
                                    ",bomh.runner " & _
                                    ",bomh.ct " & _
                                    ",bomh.mc " & _
                                    ",bomh.cavity " & _
                                    ",bomh.wc " & _
                                    ",bomh.allowance " & _
                                    ",bomh.status " & _
                                    ",bomh.active " & _
                                "from " & _
                                    "bomh inner join  " & _
                                    "inventory on inventory.invtid=bomh.invtid order by parentid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getBoMDetils(ByVal strParent As String) As DataTable
        Try
            Dim ls_SP As String = "SELECT  " & _
                                    "invtid " & _
                                    ",descr " & _
                                    ",qty " & _
                                    ",unit " & _
                                "from " & _
                                    "bom where parentid = " & QVal(strParent) & " order by invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getInvtItem() As DataTable
        Try
            Dim query As String = "select InvtID as [Invetory ID], Descr as Description from bomh order by invtId"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getInvtUsedBy() As DataTable
        Try
            Dim query As String = "select distinct RTRIM(InvtID) as [Invetory ID], Descr as Description from bom order by [Invetory ID]"
            'Dim query As String = "select distinct InvtID as [Invetory ID], Descr as Description from bom where invtid in('BB0-POM-0004-00','BB0-PP0-0018-00')"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function materialUsedBy_getMaterial(ByVal invtId As String, ByVal parentid As String) As DataTable
        Try
            Dim ls_SP As String =
            "select 
                a.invtid [Material ID],a.qty, b.StkUnit Unit, b.descr Description
            from 
                dbo.fn_GetMultiLevelBOM(" & QVal(parentid) & ") a inner join Inventory b on RTRIM(a.invtid) = RTRIM(b.InvtID) 
            where RTRIM(a.invtid) = Coalesce(nullif(" & QVal(invtId) & ",'ALL'),RTRIM(a.invtid))"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function materialUsedBy_getDataParent(ByVal invtId As String, ByVal parentid As String) As DataTable
        Try
            Dim ls_SP As String =
            "select 
                a.FinishedGood [Parent ID],a.qty, b.StkUnit Unit, b.descr Description
            from 
                dbo.fn_GetMultiLevelBOM(" & QVal(parentid) & ") a inner join Inventory b on RTRIM(a.FinishedGood) = RTRIM(*b.InvtID) 
            where RTRIM(a.invtid) = Coalesce(nullif(" & QVal(invtId) & ",'ALL'),RTRIM(a.invtid))"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function materialUsedBy_getParent() As DataTable
        Try
            Dim ls_SP As String =
            "select distinct 
            bom.parentid 
            from bom inner join Inventory on RTRIM(bom.parentid)=RTRIM(Inventory.InvtID)"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetMaterialUsedByNew() As DataTable
        Try
            Dim query As String = "GenerateMaterialUsedBy"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@ParentId", SqlDbType.VarChar)
            'pParam(0).Value = strInvtID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region


#Region "Report Sales Budget"

    Public Function SB_LoadDataGrid(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataTable
        Try
            Dim query As String = "Sales_Budget_report"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function SB_LoadReport(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataSet
        Try
            Dim query As String = "Sales_Budget_report_View"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim ds As New DataSet
            ds = MainModul.GetDataSetByCommand_SP(query, "dt_sales_budget", pParam)
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region
#Region "Report Sales Price"

    Public Function SP_LoadDataGrid(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataTable
        Try
            Dim query As String = "Sales_ForecastPrice_Report_DataGrid"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function SP_LoadReport(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataSet
        Try
            Dim query As String = "Sales_Price_report_View"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim ds As New DataSet
            ds = MainModul.GetDataSetByCommand_SP(query, "SalesPriceTable", pParam)
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region

#Region "Report Sales Forecast"
    Public Function SF_LoadDataGrid(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataTable
        Try
            Dim query As String = "Sales_Forecast_report_DataGrid"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Sales_ForecastPrice_report_DataGrid(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataTable
        Try
            Dim query As String = "Sales_ForecastPrice_report_DataGrid"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function POAmount_report(ByVal strSite As Integer) As DataTable
        Try
            Dim query As String = "tForecast_getDataGrid_report1"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.Int)
            pParam(0).Value = strSite
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function ForecastPrice_report(ByVal strSite As Integer) As DataTable
        Try
            Dim query As String = "tForecast_report_Forecast"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.Int)
            pParam(0).Value = strSite
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function SF_LoadReport(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataSet
        Try
            Dim query As String = "Sales_Forecast_report_View"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@siteid", SqlDbType.VarChar)
            pParam(0).Value = strSite
            pParam(1) = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            pParam(1).Value = strYear
            pParam(2) = New SqlClient.SqlParameter("@Invtid_", SqlDbType.VarChar)
            pParam(2).Value = strInvtid
            pParam(3) = New SqlClient.SqlParameter("@customer", SqlDbType.VarChar)
            pParam(3).Value = strCust
            Dim ds As New DataSet
            ds = GetDataSetByCommand_SP(query, "SalesForecastTable", pParam)
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region

#Region "Report Sales Order"
    Public Function SO_LoadDataGrid(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataTable
        Try
            Dim query As String = ""
            query = "" & vbCrLf & _
                "SELECT RowNum No" & vbCrLf & _
                "       ,[Customer] " & vbCrLf & _
                "      ,[Inventory ID] " & vbCrLf & _
                "      ,[Part No] " & vbCrLf & _
                "      ,[Part Name] " & vbCrLf & _
                "      ,[Site] " & vbCrLf & _
                "      ,CASE when [Jan Qty] <> 0 then [Harga] else '0' end [Jan Harga] " & vbCrLf & _
                "      ,[Jan Qty] " & vbCrLf & _
                "      ,CASE when [Feb Qty] <> 0 then [Harga] else '0' end [Feb Harga] " & vbCrLf & _
                "      ,[Feb Qty] " & vbCrLf & _
                "      ,CASE when [Mar Qty] <> 0 then [Harga] else '0' end [Mar Harga] " & vbCrLf & _
                "      ,[Mar Qty] " & vbCrLf & _
                "      ,CASE when [Apr Qty] <> 0 then [Harga] else '0' end [Apr Harga] " & vbCrLf & _
                "      ,[Apr Qty] " & vbCrLf & _
                "      ,CASE when [Mei Qty] <> 0 then [Harga] else '0' end [Mei Harga] " & vbCrLf & _
                "      ,[Mei Qty] " & vbCrLf & _
                "      ,CASE when [Jun Qty] <> 0 then [Harga] else '0' end [Jun Harga] " & vbCrLf & _
                "      ,[Jun Qty] " & vbCrLf & _
                "      ,CASE when [Jul Qty] <> 0 then [Harga] else '0' end [Jul Harga] " & vbCrLf & _
                "      ,[Jul Qty] " & vbCrLf & _
                "      ,CASE when [Agt Qty] <> 0 then [Harga] else '0' end [Agt Harga] " & vbCrLf & _
                "      ,[Agt Qty] " & vbCrLf & _
                "      ,CASE when [Sep Qty] <> 0 then [Harga] else '0' end [Sep Harga] " & vbCrLf & _
                "      ,[Sep Qty] " & vbCrLf & _
                "      ,CASE when [Okt Qty] <> 0 then [Harga] else '0' end [Okt Harga] " & vbCrLf & _
                "      ,[Okt Qty] " & vbCrLf & _
                "      ,CASE when [Nov Qty] <> 0 then [Harga] else '0' end [Nov Harga] " & vbCrLf & _
                "      ,[Nov Qty] " & vbCrLf & _
                "      ,CASE when [Des Qty] <> 0 then [Harga] else '0' end [Des Harga] " & vbCrLf & _
                "      ,[Des Qty] " & vbCrLf & _
                "FROM( " & vbCrLf & _
                            "SELECT soheader.custid AS [Customer] " & vbCrLf & _
                            "      ,soline.alternateid AS [Inventory ID] " & vbCrLf & _
                            "      ,soline.invtid AS [Part No] " & vbCrLf & _
                            "      ,soline.descr [Part Name] " & vbCrLf & _
                            "      ,soline.curyslsprice [Harga] " & vbCrLf & _
                            "      ,soline.siteid AS [Site] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=1 THEN soline.qtyord ELSE 0 END) AS [Jan Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=2 THEN soline.qtyord ELSE 0 END) AS [Feb Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=3 THEN soline.qtyord ELSE 0 END) AS [Mar Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=4 THEN soline.qtyord ELSE 0 END) AS [Apr Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=5 THEN soline.qtyord ELSE 0 END) AS [Mei Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=6 THEN soline.qtyord ELSE 0 END) AS [Jun Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=7 THEN soline.qtyord ELSE 0 END) AS [Jul Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=8 THEN soline.qtyord ELSE 0 END) AS [Agt Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=9 THEN soline.qtyord ELSE 0 END) AS [Sep Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=10 THEN soline.qtyord ELSE 0 END) AS [Okt Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=11 THEN soline.qtyord ELSE 0 END) AS [Nov Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=12 THEN soline.qtyord ELSE 0 END) AS [Des Qty] " & vbCrLf & _
                            "      ,ROW_NUMBER() OVER (ORDER BY soheader.custid asc) AS RowNum " & vbCrLf & _
                            "FROM soline inner join soheader on soline.ORDNBR=soheader.ORDNBR " & vbCrLf & _
                            "WHERE right(ltrim(rtrim(soline.ordnbr)),1)!='R' AND soheader.sotypeid='SO' and soheader.custid=coalesce(nullif(" & QVal(strCust) & ",'ALL'),soheader.custid) " & vbCrLf & _
                            "      and soline.invtid=coalesce(nullif(" & QVal(strInvtid) & ",'ALL'),soline.invtid) and soline.siteid =coalesce(nullif(" & QVal(strSite) & ",'ALL'),soline.siteid) " & vbCrLf & _
                            "      and year(soline.promdate)=coalesce(nullif(" & QVal(strYear) & ",'ALL'),year(soline.promdate)) " & vbCrLf & _
                            "GROUP BY soheader.custid,soline.alternateid,soline.invtid,soline.descr, soline.curyslsprice, soline.siteid " & vbCrLf & _
                    ") Orders"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function SO_LoadReport(ByVal strSite As String, ByVal strYear As String, ByVal strInvtid As String, ByVal strCust As String) As DataSet
        Try
            Dim query As String = ""
            query = "" & vbCrLf & _
                "SELECT " & vbCrLf & _
                "      [Customer] " & vbCrLf & _
                "      ,[Inventory ID] " & vbCrLf & _
                "      ,[Part No] " & vbCrLf & _
                "      ,[Part Name] " & vbCrLf & _
                "      ,[Site] " & vbCrLf & _
                "      ,CASE when [Jan Qty] <> 0 then [Harga] else '0' end [Jan Harga] " & vbCrLf & _
                "      ,[Jan Qty] " & vbCrLf & _
                "      ,CASE when [Feb Qty] <> 0 then [Harga] else '0' end [Feb Harga] " & vbCrLf & _
                "      ,[Feb Qty] " & vbCrLf & _
                "      ,CASE when [Mar Qty] <> 0 then [Harga] else '0' end [Mar Harga] " & vbCrLf & _
                "      ,[Mar Qty] " & vbCrLf & _
                "      ,CASE when [Apr Qty] <> 0 then [Harga] else '0' end [Apr Harga] " & vbCrLf & _
                "      ,[Apr Qty] " & vbCrLf & _
                "      ,CASE when [Mei Qty] <> 0 then [Harga] else '0' end [Mei Harga] " & vbCrLf & _
                "      ,[Mei Qty] " & vbCrLf & _
                "      ,CASE when [Jun Qty] <> 0 then [Harga] else '0' end [Jun Harga] " & vbCrLf & _
                "      ,[Jun Qty] " & vbCrLf & _
                "      ,CASE when [Jul Qty] <> 0 then [Harga] else '0' end [Jul Harga] " & vbCrLf & _
                "      ,[Jul Qty] " & vbCrLf & _
                "      ,CASE when [Agt Qty] <> 0 then [Harga] else '0' end [Agt Harga] " & vbCrLf & _
                "      ,[Agt Qty] " & vbCrLf & _
                "      ,CASE when [Sep Qty] <> 0 then [Harga] else '0' end [Sep Harga] " & vbCrLf & _
                "      ,[Sep Qty] " & vbCrLf & _
                "      ,CASE when [Okt Qty] <> 0 then [Harga] else '0' end [Okt Harga] " & vbCrLf & _
                "      ,[Okt Qty] " & vbCrLf & _
                "      ,CASE when [Nov Qty] <> 0 then [Harga] else '0' end [Nov Harga] " & vbCrLf & _
                "      ,[Nov Qty] " & vbCrLf & _
                "      ,CASE when [Des Qty] <> 0 then [Harga] else '0' end [Des Harga] " & vbCrLf & _
                "      ,[Des Qty] " & vbCrLf & _
                "FROM( " & vbCrLf & _
                            "SELECT soheader.custid AS [Customer] " & vbCrLf & _
                            "      ,soline.alternateid AS [Inventory ID] " & vbCrLf & _
                            "      ,soline.invtid AS [Part No] " & vbCrLf & _
                            "      ,soline.descr [Part Name] " & vbCrLf & _
                            "      ,soline.curyslsprice [Harga] " & vbCrLf & _
                            "      ,soline.siteid AS [Site] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=1 THEN soline.qtyord ELSE 0 END) AS [Jan Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=2 THEN soline.qtyord ELSE 0 END) AS [Feb Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=3 THEN soline.qtyord ELSE 0 END) AS [Mar Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=4 THEN soline.qtyord ELSE 0 END) AS [Apr Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=5 THEN soline.qtyord ELSE 0 END) AS [Mei Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=6 THEN soline.qtyord ELSE 0 END) AS [Jun Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=7 THEN soline.qtyord ELSE 0 END) AS [Jul Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=8 THEN soline.qtyord ELSE 0 END) AS [Agt Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=9 THEN soline.qtyord ELSE 0 END) AS [Sep Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=10 THEN soline.qtyord ELSE 0 END) AS [Okt Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=11 THEN soline.qtyord ELSE 0 END) AS [Nov Qty] " & vbCrLf & _
                            "      ,SUM(CASE WHEN month(soline.promdate)=12 THEN soline.qtyord ELSE 0 END) AS [Des Qty] " & vbCrLf & _
                            "      ,ROW_NUMBER() OVER (ORDER BY soheader.custid asc) AS RowNum " & vbCrLf & _
                            "FROM soline inner join soheader on soline.ORDNBR=soheader.ORDNBR " & vbCrLf & _
                            "WHERE right(ltrim(rtrim(soline.ordnbr)),1)!='R' AND soheader.sotypeid='SO' and soheader.custid=coalesce(nullif(" & QVal(strCust) & ",'ALL'),soheader.custid) " & vbCrLf & _
                            "      and soline.invtid=coalesce(nullif(" & QVal(strInvtid) & ",'ALL'),soline.invtid) and soline.siteid =coalesce(nullif(" & QVal(strSite) & ",'ALL'),soline.siteid) " & vbCrLf & _
                            "      and year(soline.promdate)=coalesce(nullif(" & QVal(strYear) & ",'ALL'),year(soline.promdate)) " & vbCrLf & _
                            "GROUP BY soheader.custid,soline.alternateid,soline.invtid,soline.descr, soline.curyslsprice, soline.siteid " & vbCrLf & _
                    ") Orders"
            Dim ds As New DataSet
            ds = MainModul.GetDsReport_Solomon(query, "SalesOrderTable")
            Return ds
        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region

End Class
