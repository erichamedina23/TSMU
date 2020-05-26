Public Class clsSalesBudgetCalculate
    Public Property ID() As Integer
    Public Property bomId() As String
    Public Property invtid() As String
    Public Property descr() As String
    Public Property Semester() As String
    Public Property Tahun() As String
    Public Property Total() As Single

    Public Function level0(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String = "select distinct a.bomid, a.invtid Level0,'' level1, '' level2,'' level3,'' level4, a.descr, 1 qty, 'PCS' unit from bomh a inner join
                                    bom b on a.bomid = b.bomid order by a.bomid" 'and invtid in('PMT-165-BES0-IACT','ADM-D01-GFPL-EAND')
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function level0_View(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String =
                "SELECT bomid [BoM ID], invtid Level0, '' level1, '' level2,'' level3,'' level4, a.descr, 1 qty, 'PCS' unit FROM calculated_bom"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function level1(ByVal bomid As String) As DataTable
        Try
            Dim ls_SP As String = "select '' bomid, '' Level0, b.invtid level1, '' level2,'' level3,'' level4, b.descr, b.qty, b.unit from bomh a inner join
                                    bom b on a.bomid = b.bomid where a.bomid= " & QVal(bomid) & " order by b.invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function level1_view(ByVal bomid As String) As DataTable
        Try
            Dim ls_SP As String =
            "SELECT [bomId] [BoM ID]
                ,'' level0
                ,[invtid] level1
                ,'' level2
                ,'' level3
                ,'' level4
                ,[descr]
                ,[unit]
                ,[Jan_qty]
                ,[feb_qty]
                ,[mar_qty]
                ,[apr_qty]
                ,[mei_qty]
                ,[jun_qty]
                ,[jul_qty]
                ,[agust_qty]
                ,[sep_qty]
                ,[okt_qty]
                ,[nov_qty]
                ,[des_qty]
            FROM [calculated_bom_detail]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function level2(ByVal invtId As String)
        Try
            Dim query As String = "select '' bomid,'' level0,'' level1, b.invtid level2,'' level3,'' level4 , a.descr, qty,unit from fn_GetMultiLevelBOM('" & invtId & "')b 
                                   inner join inventory a on b.invtid = a.invtid"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function level3(ByVal invtId As String)
        Try
            Dim query As String = "select '' bomid,'' level0,'' level1,'' level2, b.invtid level3,'' level4 , a.descr,qty,unit from fn_GetMultiLevelBOM('" & invtId & "') b 
                                   inner join inventory a on b.invtid = a.invtid"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function level4(ByVal invtId As String)
        Try
            Dim query As String = "select '' bomid,'' level0,'' level1,'' level2, '' level3, b.invtid level4 , a.descr, qty,unit from fn_GetMultiLevelBOM('" & invtId & "') b 
                                   inner join inventory a on b.invtid = a.invtid"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetForecastSemester1(ByVal tahun As String) As DataTable
        Try
            Dim ls_SP As String = "select invtid, jan_qty,feb_qty,mar_qty,apr_qty,mei_qty, jun_qty 
                                from budget where tahun=" & QVal(tahun) & "" 'and invtid in('PMT-165-BES0-IACT','ADM-D01-GFPL-EAND')
            Dim sql As String =
            "SELECT [id]
                ,[tahun]
                ,[custid]
                ,[customer]
                ,[invtid]
                ,[descr]
                ,[partno]
                ,[model]
                ,[oe_re]
                ,[in_sub]
                ,[site]
                ,[jan_qty01]
                ,[jan_qty02]
                ,[jan_qty03]
                ,[jan_po01]
                ,[jan_po02]
                ,[feb_qty01]
                ,[feb_qty02]
                ,[feb_qty03]
                ,[feb_po01]
                ,[feb_po02]
                ,[mar_qty01]
                ,[mar_qty02]
                ,[mar_qty03]
                ,[mar_po01]
                ,[mar_po02]
                ,[apr_qty01]
                ,[apr_qty02]
                ,[apr_qty03]
                ,[apr_po01]
                ,[apr_po02]
                ,[mei_qty01]
                ,[mei_qty02]
                ,[mei_qty03]
                ,[mei_po01]
                ,[mei_po02]
                ,[jun_qty01]
                ,[jun_qty02]
                ,[jun_qty03]
                ,[jun_po01]
                ,[jun_po02]
            FROM [forecast] 
            WHERE tahun=" & QVal(tahun) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(sql)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Function IsForecastSemester1Exist(ByVal tahun As String, ByVal semester As String) As Boolean
        Try
            Dim ls_SP As String = "select bomid from calculated_Forecast where Tahun=" & QVal(tahun) & " AND Semester = " & QVal(semester) & "" 'and invtid in('PMT-165-BES0-IACT','ADM-D01-GFPL-EAND')
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetForecasttSemester2(ByVal tahun As String) As DataTable
        Try
            Dim ls_SP As String =
            "SELECT [id]
                ,[tahun]
                ,[custid]
                ,[customer]
                ,[invtid]
                ,[descr]
                ,[partno]
                ,[model]
                ,[oe_re]
                ,[in_sub]
                ,[site]
                ,[jul_qty01]
                ,[jul_qty02]
                ,[jul_qty03]
                ,[jul_po01]
                ,[jul_po02]
                ,[agt_qty01]
                ,[agt_qty02]
                ,[agt_qty03]
                ,[agt_po01]
                ,[agt_po02]
                ,[sep_qty01]
                ,[sep_qty02]
                ,[sep_qty03]
                ,[sep_po01]
                ,[sep_po02]
                ,[okt_qty01]
                ,[okt_qty02]
                ,[okt_qty03]
                ,[okt_po01]
                ,[okt_po02]
                ,[nov_qty01]
                ,[nov_qty02]
                ,[nov_qty03]
                ,[nov_po01]
                ,[nov_po02]
                ,[des_qty01]
                ,[des_qty02]
                ,[des_qty03]
                ,[des_po01]
                ,[des_po02]
            FROM [forecast] WHERE tahun=" & QVal(tahun) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetForecastAllsemester(ByVal tahun As String) As DataTable
        Try
            Dim ls_SP As String = "select invtid, jan_qty,feb_qty,mar_qty,apr_qty,mei_qty, jun_qty , jul_qty, agt_qty, sep_qty, okt_qty, nov_qty, des_qty 
                                from budget where tahun=" & QVal(tahun) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDeletedForecast(ByVal tahun As String, ByVal semester As String) As DataTable
        Try
            Dim query As String =
                "Delete 
                from calculated_Forecast 
                output deleted.bomid
                where tahun=" & QVal(tahun) & " AND semester = " & QVal(semester) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "CRUD"
    Public Function InsertHeader() As Integer
        Dim ID As Integer = 0
        Try
            Dim ls_SP As String =
            "INSERT INTO [calculated_Forecast]
                ([invtid]
                ,[descr]
                ,[Semester]
                ,[Tahun]
                ,[Total Qty]
                ,[created_by]
                ,[created_date])
            OUTPUT  Inserted.bomid 
            VALUES
                (" & QVal(invtid) & "
                ," & QVal(descr) & "
                ," & QVal(Semester) & "
                ," & QVal(Tahun) & "
                ," & QVal(Total) & "
                ," & QVal(gh_Common.Username) & "
                ,GETDATE())"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(ls_SP)
            If dt.Rows.Count > 0 Then
                ID = Convert.ToInt32(dt.Rows(0)(0))
            End If
            Return ID
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub DeleteForecastByYearAndSemester(ByVal tahun As String, ByVal semester As String)
        Try
            Dim dt As New DataTable
            dt = GetDeletedForecast(tahun, semester)
            For Each row As DataRow In dt.Rows
                Dim query As String =
                "   Delete 
                    FROM calculated_forecast_detail 
                    WHERE bomid =" & row.Item("bomid") & ""
                MainModul.ExecQuery(query)
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

End Class
