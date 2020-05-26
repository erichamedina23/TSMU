Public Class clsCalcultateBoM
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
    Public Function GetBudgetSemester1(ByVal tahun As String) As DataTable
        Try
            Dim ls_SP As String = "select invtid, jan_qty,feb_qty,mar_qty,apr_qty,mei_qty, jun_qty 
                                from budget where tahun=" & QVal(tahun) & "" 'and invtid in('PMT-165-BES0-IACT','ADM-D01-GFPL-EAND')
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Function IsBudgetSemester1Exist(ByVal tahun As String, ByVal semester As String) As Boolean
        Try
            Dim ls_SP As String = "select * from calculated_Forecast where Tahun=" & QVal(tahun) & " AND Semester = " & QVal(semester) & "" 'and invtid in('PMT-165-BES0-IACT','ADM-D01-GFPL-EAND')
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
    Public Function GetBudgetSemester2(ByVal tahun As String) As DataTable
        Try
            Dim ls_SP As String = "select invtid, jul_qty, agt_qty, sep_qty, okt_qty, nov_qty, des_qty 
                                from budget where tahun=" & QVal(tahun) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetBudgetAllsemester(ByVal tahun As String) As DataTable
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

    Public Function GetDeletedBudget(ByVal tahun As String, ByVal semester As String) As DataTable
        Try
            Dim query As String =
                "Delete 
                from calculated_bom 
                output deleted.bomid
                where tahun=" & QVal(tahun) & " AND semester = " & QVal(semester) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetBomToCalculate() As DataTable
        Try
            Dim query As String = "GetBomToCalculate"
            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand_SP(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "CRUD"
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String =
            "INSERT INTO [calculated_bom]
                ([bomId]
                ,[invtid]
                ,[descr]
                ,[Semester]
                ,[Tahun]
                ,[Total]
                ,[created_by]
                ,[created_date])
            VALUES
                (" & QVal(bomId) & "
                ," & QVal(invtid) & "
                ," & QVal(descr) & "
                ," & QVal(Semester) & "
                ," & QVal(Tahun) & "
                ," & QVal(Total) & "
                ," & QVal(gh_Common.Username) & "
                ,GETDATE())"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteBugetByYearAndSemester(ByVal tahun As String, ByVal semester As String)
        Try
            Dim dt As New DataTable
            dt = GetDeletedBudget(tahun, semester)
            For Each row As DataRow In dt.Rows
                Dim query As String =
                "Delete 
                from calculated_bom_detail 
                where bomid =" & row.Item("bomid") & ""
                MainModul.ExecQuery(query)
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

End Class
