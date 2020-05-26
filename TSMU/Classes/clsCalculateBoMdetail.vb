Public Class clsCalculateBoMdetail
    Public Property bomId() As String
    Public Property invtid() As String
    Public Property descr() As String
    Public Property unit() As String
    Public Property level() As String
    Public Property Jan_qty() As Single
    Public Property feb_qty() As Single
    Public Property mar_qty() As Single
    Public Property apr_qty() As Single
    Public Property mei_qty() As Single
    Public Property jun_qty() As Single
    Public Property jul_qty() As Single
    Public Property agt_qty() As Single
    Public Property sep_qty() As Single
    Public Property okt_qty() As Single
    Public Property nov_qty() As Single
    Public Property des_qty() As Single

    Public Property Jan_po() As Single
    Public Property feb_po() As Single
    Public Property mar_po() As Single
    Public Property apr_po() As Single
    Public Property mei_po() As Single
    Public Property jun_po() As Single
    Public Property jul_po() As Single
    Public Property agt_po() As Single
    Public Property sep_po() As Single
    Public Property okt_po() As Single
    Public Property nov_po() As Single
    Public Property des_po() As Single
    'Public Property Qty() As Single
    'Public Property PO() As Single
    'Public Property Price() As Long

#Region "CRUD"
    Public Sub InsertDetails(ID As Integer)
        Try
            Dim ls_SP As String =
            "INSERT INTO [calculated_forecast_detail]
                ([Id],[invtid],[descr],[unit],[Level]
               ,[Jan_qty],[Jan_po]
               ,[feb_qty],[feb_po]
               ,[mar_qty],[mar_po]
               ,[apr_qty],[apr_po]
               ,[mei_qty],[mei_po]
               ,[jun_qty],[jun_po]
               ,[jul_qty],[jul_po]
               ,[agt_qty],[agt_po]
               ,[sep_qty],[sep_po]
               ,[okt_qty],[okt_po]
               ,[nov_qty],[nov_po]
               ,[des_qty],[des_po])
            VALUES
                (" & QVal(ID) & "," & QVal(invtid) & "," & QVal(descr) & "," & QVal(unit) & "," & QVal(level) & "
                ," & QVal(Jan_qty) & "," & QVal(Jan_po) & "
                ," & QVal(feb_qty) & "," & QVal(feb_po) & "
                ," & QVal(mar_qty) & "," & QVal(mar_po) & "
                ," & QVal(apr_qty) & "," & QVal(apr_po) & "
                ," & QVal(mei_qty) & "," & QVal(mei_po) & "
                ," & QVal(jun_qty) & "," & QVal(jun_po) & "
                ," & QVal(jul_qty) & "," & QVal(jul_po) & "
                ," & QVal(agt_qty) & "," & QVal(agt_po) & "
                ," & QVal(sep_qty) & "," & QVal(sep_po) & "
                ," & QVal(okt_qty) & "," & QVal(okt_po) & "
                ," & QVal(nov_qty) & "," & QVal(nov_po) & "
                ," & QVal(des_qty) & "," & QVal(des_po) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertCalculatedForecastDetails(ID As Integer, Qty As Single, PO As Single, Bulan As String, Tahun As String)
        Try
            Dim ls_SP As String =
            "INSERT INTO [CalculatedForecastDetails]
                ([ID],[Tahun],[Bulan],[Invtid],[Description],[Unit],[Level],[Qty],[PO],[Type])
            VALUES
                (" & QVal(ID) & "," & QVal(Tahun) & "," & QVal(Bulan) & "," & QVal(invtid) & "," & QVal(descr) & "," & QVal(unit) & "," & QVal(level) & "
                ," & QVal(Qty) & "," & QVal(PO) & "," & QVal("F") & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateCalculatedForecastDetails(ID As Integer, Qty As Single, PO As Single, Bulan As String, Tahun As String, Invtid As String)
        Try
            Dim ls_SP As String =
            "UPDATE D
            SET D.[Invtid] = " & QVal(Invtid) & "
                ,D.[Description] = " & QVal(descr) & "
                ,D.[Unit] = " & QVal(unit) & "
                ,D.[Level] = " & QVal(level) & "
                ,D.[Qty] = " & QVal(Qty) & "
                ,D.[PO] = " & QVal(PO) & " 
            FROM [CalculatedForecastDetails] D Inner Join calculated_Forecast H on D.ID = H.ID 
            WHERE D.ID = " & QVal(ID) & " AND D.Bulan = " & QVal(Bulan) & " AND D.Type ='F' AND H.Tahun = " & QVal(Tahun) & " AND D.Invtid = " & QVal(Invtid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertCalculatedBudgetDetails(ID As Integer, Price As Long, Bulan As String, Tahun As String)
        Try
            Dim ls_SP As String =
            "INSERT INTO [CalculatedForecastDetails]
                ([ID],[Tahun],[Bulan],[Invtid],[Description],[Unit],[Level],[Qty],[PO],[Price],[Type])
            VALUES
                (" & QVal(ID) & "," & QVal(Tahun) & "," & QVal(Bulan) & "," & QVal(invtid) & "," & QVal(descr) & "," & QVal(unit) & "," & QVal(level) & "
                ," & QVal(0) & "," & QVal(0) & "," & QVal(Price) & "," & QVal("P") & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateCalculatedBudgetDetails(ID As Integer, Price As Long, Bulan As String, Tahun As String, Invtid As String)
        Try
            Dim ls_SP As String =
            "UPDATE D 
            SET D.[Invtid] = " & QVal(Invtid) & "
                ,D.[Description] = " & QVal(descr) & "
                ,D.[Unit] = " & QVal(unit) & "
                ,D.[Level] = " & QVal(level) & "
                ,D.[Price] = " & QVal(Price) & "
            FROM [CalculatedForecastDetails] D Inner Join calculated_Forecast H on D.ID = H.ID 
            WHERE D.ID = " & QVal(ID) & " AND D.Bulan = " & QVal(Bulan) & " AND D.Type ='P' AND H.Tahun = " & QVal(Tahun) & " AND D.Invtid = " & QVal(Invtid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertDetails()
        Try
            Dim ls_SP As String =
            "INSERT INTO [calculated_forecast_detail]
                (Id
                ,[invtid]
                ,[descr]
                ,[unit]
                ,[level]
                ,[Jan_qty]
                ,[feb_qty]
                ,[mar_qty]
                ,[apr_qty]
                ,[mei_qty]
                ,[jun_qty]
                ,[jul_qty]
                ,[agu_qty]
                ,[sep_qty]
                ,[okt_qty]
                ,[nov_qty]
                ,[des_qty])
            VALUES
                (" & QVal(1) & "
                ," & QVal(invtid) & "
                ," & QVal(descr) & "
                ," & QVal(unit) & "
                ," & QVal(level) & "
                ," & QVal(Jan_qty) & "
                ," & QVal(feb_qty) & "
                ," & QVal(mar_qty) & "
                ," & QVal(apr_qty) & "
                ," & QVal(mei_qty) & "
                ," & QVal(jun_qty) & "
                ," & QVal(jul_qty) & "
                ," & QVal(agt_qty) & "
                ," & QVal(sep_qty) & "
                ," & QVal(okt_qty) & "
                ," & QVal(nov_qty) & "
                ," & QVal(des_qty) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
