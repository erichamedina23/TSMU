Public Class KanbanAdmModel
    Public Property CalcDate As DateTime
    Public Property CancelStatus As String
    Public Property DelCycle As String
    Public Property DelDate As DateTime
    Public Property DelTime As String
    Public Property DNType As String
    Public Property DocNo As String
    Public Property IdKanban As Integer
    Public Property JobNo As String
    Public Property Lane As Integer
    Public Property LP As String
    Public Property OrderDate As DateTime
    Public Property OrderKbn As Integer
    Public Property OrderNo As String
    Public Property OrderPcs As Integer
    Public Property OrderTime As String
    Public Property PartCategory As String
    Public Property PartName As String
    Public Property PartNo As String
    Public Property PlantCode As String
    Public Property PONo As String
    Public Property QtyBalance As Integer
    Public Property QtyKbn As Integer
    Public Property QtyReceive As Integer
    Public Property RecDate As DateTime
    Public Property RecStatus As String
    Public Property RecType As String
    Public Property Remark As String
    Public Property Route As String
    Public Property ShopCode As String
    Public Property Trip As String
    Public Property UploadedBy As String
    Public Property UploadedDate As DateTime
    Public Property VendorAlias As String
    Public Property VendorCode As String
    Public Property VendorSite As String
    Public Property VendorSiteAlias As String
    Public Function GetAllDataGrid() As DataTable
        Try
            Dim ls_SP As String =
            "SELECT [IdKanban] ID
                ,[PlantCode]
                ,[ShopCode]
                ,[PartCategory]
                ,[Route]
                ,[VendorCode]
                ,[VendorAlias]
                ,[VendorSite]
                ,[VendorSiteAlias]
                ,[OrderNo]
                ,[PONo]
                ,[CalcDate]
                ,[OrderDate]
                ,[OrderTime]
                ,[DelDate]
                ,[DelTime]
                ,[DelCycle]
                ,[DocNo]
                ,[RecStatus]
                ,[DNType]
                ,[RecDate]
                ,[RecType]
                ,[PartNo]
                ,[PartName]
                ,[JobNo]
                ,[Lane]
                ,[QtyKbn]
                ,[OrderKbn]
                ,[Scanned]
                ,isnull([OrderKbn],0)-isnull([Scanned],0) as OutStanding
                ,[OrderPcs]
                ,[QtyReceive]
                ,[QtyBalance]
                ,[ScannedDN]
                ,[CancelStatus]
                ,[Remark]
                ,[UploadedBy]
                ,[UploadedDate] 
            FROM [KanbanADM]"
            Dim dtTable As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dtTable = GetDataTable(ls_SP)
            Else
                dtTable = GetDataTableCKR(ls_SP)
            End If

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub InsertData()
        Try
            Dim Query As String = String.Empty
            Query = "INSERT INTO [KanbanADM] ([PlantCode]
            ,[ShopCode],[PartCategory],[Route],LP,Trip,[VendorCode]
            ,[VendorAlias],[VendorSite],[VendorSiteAlias],[OrderNo]
            ,[PONo],[CalcDate],[OrderDate],[OrderTime]
            ,[DelDate],[DelTime],[DelCycle],[DocNo]
            ,[RecStatus],[DNType],[RecDate],[RecType]
            ,[PartNo],[PartName],[JobNo],[Lane]
            ,[QtyKbn],[OrderKbn],[OrderPcs],[QtyReceive]
            ,[QtyBalance],[CancelStatus],[Remark],[UploadedBy],[UploadedDate])
            Values(" & QVal(PlantCode) & "," & QVal(ShopCode) & "," & QVal(PartCategory) & "
                ," & QVal(Route) & "," & QVal(LP) & "," & QVal(Trip) & "," & QVal(VendorCode) & "," & QVal(VendorAlias) & "," & QVal(VendorSite) & "
                ," & QVal(VendorSiteAlias) & "," & QVal(OrderNo) & "," & QVal(PONo) & "," & QVal(CalcDate) & "
                ," & QVal(OrderDate) & "," & QVal(OrderTime) & "," & QVal(DelDate) & "," & QVal(DelTime) & "
                ," & QVal(DelCycle) & "," & QVal(DocNo.TrimEnd) & "," & QVal(RecStatus) & "," & QVal(DNType) & "," & QVal(RecDate) & "," & QVal(RecType) & "
                ," & QVal(PartNo) & "," & QVal(PartName) & "," & QVal(JobNo) & "," & QVal(Lane) & "," & QVal(QtyKbn) & "," & QVal(OrderKbn) & "
                ," & QVal(OrderPcs) & "," & QVal(QtyReceive) & "," & QVal(QtyBalance) & "
                ," & QVal(CancelStatus) & "," & QVal(Remark) & "," & QVal(UploadedBy) & "," & QVal(UploadedDate) & ")"
            If gh_Common.Site.ToLower = "tng" Then
                ExecQuery(Query)
            Else
                ExecQueryCKR(Query)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetKanban() As DataTable
        Try
            Dim sql As String = "SELECT 
			                        CONVERT(varchar,[OrderDate],101) Tanggal,
			                        [DelCycle] Cycle,
			                        sum([OrderKbn]) Kanban,
                                    Shopcode
		                        FROM [KanbanADM]
		                        GROUP BY 
			                        CONVERT(varchar,[OrderDate],101),
			                        [DelCycle], Shopcode
		                        ORDER BY 
			                        CONVERT(varchar,[OrderDate],101),
			                        [DelCycle]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetKanbanCKR() As DataTable
        Try
            Dim sql As String = "SELECT 
	                                CONVERT(varchar,[OrderDate],101) Tanggal,
	                                [DelCycle] Cycle, 
                                    case when (Remark is null OR Remark<>'3A') then '3B' else '3A' END Remark,
	                                sum([OrderKbn]) Kanban,  
                                    COUNT(distinct OrderNo)TotDN, 
                                    ShopCode, 
                                    case PlantCode
		                                when 'D104' then 'SAP'
		                                when 'D105' then 'KAP'
	                                END as PlantCode
                                FROM [KanbanADM]
                                GROUP BY 
	                                CONVERT(varchar,[OrderDate],101),
	                                [DelCycle],Remark, Shopcode, PlantCode
                                ORDER BY 
	                                CONVERT(varchar,[OrderDate],101),
	                                [DelCycle]"
            Dim dt As New DataTable
            dt = GetDataTableCKR(sql)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub SaveKanbanSum(Tgl As String, Cycle As Integer, Kanban As Integer, ShopCode As String)
        Try
            Dim sql As String = "INSERT INTO [KanbanSum]
                                       ([Tanggal]
                                       ,[Cycle]
                                       ,[Kanban]
                                        ,[Open]
                                        ,ShopCode)
                                 VALUES
                                       (" & QVal(Tgl) & "
                                       ," & QVal(Cycle) & "
                                       ," & QVal(Kanban) & "
                                       ," & QVal(Kanban) & "
                                       ," & QVal(ShopCode) & ")"
            ExecQuery(sql)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub SaveKanbanSumCKR(Tgl As String, Cycle As Integer, Kanban As Integer, Remark As String, totDN As Integer, shopcode As String, plantCode As String)
        Try
            Dim sql As String = "INSERT INTO [KanbanSum]
                                       ([Tanggal]
                                        ,[Cycle]
                                        ,[Kanban]
                                        ,[Open]
                                        ,Remark
                                        ,TotDN
                                        ,OpenDN,ShopCode,PlantCode)
                                 VALUES
                                       (" & QVal(Tgl) & "
                                       ," & QVal(Cycle) & "
                                       ," & QVal(Kanban) & "
                                       ," & QVal(Kanban) & "
                                       ," & QVal(Remark) & "
                                       ," & QVal(totDN) & "
                                       , " & QVal(totDN) & ", " & QVal(shopcode) & "," & QVal(plantCode) & ")"

            ExecQueryCKR(sql)

            'Dim updateData As String = "UPDATE K
            '                SET K.NoDN = L.OrderNo, K.OpenDN=L.OpenDN 
            '                FROM kanbansum K
            '                INNER JOIN
            '                   (
            '                    SELECT 
            '                     orderDate, DelCycle, COUNT(OrderNo) OpenDN FROM KanbanADM 
            '                                    WHERE CONVERT(varchar,L.[OrderDate],101) = " & QVal(Tgl) & " AND DelCycle = " & QVal(Cycle) & " " &
            '                                "GROUP BY orderDate, DelCycle 
            '                   ) L ON K.Tanggal =  CONVERT(varchar,L.[OrderDate],101) AND K.Cycle = L.DelCycle"
            'ExecQueryCKR(updateData)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateKanbanSum(Tgl As String, Cycle As Integer, Kanban As Integer)
        Try
            Dim sql As String = "Update [KanbanSum]
                                 Set Kanban = Kanban + " & QVal(Kanban) & "
                                 Where Tanggal =" & QVal(Tgl) & " AND Cycle = " & QVal(Cycle) & ""
            If gh_Common.Site.ToLower = "tng" Then
                ExecQuery(sql)
            Else
                ExecQueryCKR(sql)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function IsKanbanExist(Tgl As String, Cycle As Integer, ShopCode As String) As Boolean
        Dim hasil As Boolean = False
        Try
            Dim sql As String = "SELECT * 
                                FROM KanbanSum 
                                WHERE Tanggal = " & QVal(Tgl) & " AND Cycle=" & QVal(Cycle) & " AND ShopCode = " & QVal(ShopCode) & ""
            Dim dt As New DataTable
            dt = GetDataTable(sql)

            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function IsKanbanExistCkr(Tgl As String, Cycle As Integer, Remark As String, shopcode As String) As Boolean
        Dim hasil As Boolean = False
        Try
            Dim sql As String = "SELECT * 
                                FROM KanbanSum 
                                WHERE Tanggal = " & QVal(Tgl) & "
                                    AND Cycle=" & QVal(Cycle) & " AND Remark=" & QVal(Remark) & " AND Shopcode = " & QVal(shopcode) & ""
            Dim dt As New DataTable

            dt = GetDataTableCKR(sql)
            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function IsDnNoExistCkr(orderNo As String) As Boolean
        Dim hasil As Boolean = False
        Try

            Dim sql As String = "SELECT * 
                                FROM KanbanAdmScanDN WHERE OrderNo = " & QVal(orderNo) & ""
            Dim dt As New DataTable

            dt = GetDataTableCKR(sql)
            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub SaveDN(noPolisi As String, orderNo As String, sopir As String)
        Dim tgl As String = String.Empty
        Dim tgl1 As String = String.Empty
        Dim shopCode As String = String.Empty
        Dim cycle As Integer = 0

        Try

            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        tgl = GetTglByOrderNo(orderNo)
                        'tgl1 = GetTglByOrderNo1(orderNo)
                        cycle = GetCycleByOrderNo(orderNo)
                        shopCode = GetShopCode(orderNo)

                        If tgl = "" OrElse cycle = 0 Then
                            Throw New Exception("Tgl atau Cycle tidak di temukan untuk DN '[" & orderNo & "]' !")
                        End If

                        Dim sql As String = "INSERT INTO [KanbanAdmScanDN]
                                       ([NoPolisi]
                                        ,[Sopir]
                                        ,[OrderNo]
                                        ,[CreatedBy]
                                        ,[CreatedDate])
                                 VALUES
                                       (" & QVal(noPolisi.ToUpper) & "
                                        ," & QVal(sopir.ToUpper) & "
                                        ," & QVal(orderNo) & "
                                        ," & QVal(gh_Common.Username) & "
                                        ,GETDATE())"

                        ExecQueryCKR(sql)



                        Dim udpateOpenDN As String = "Update KanbanSum 
                                        SET OpenDN = ISNULL(OpenDN,0) - 1, ClosedDN = ISNULL(ClosedDN,0) + 1 
                                        WHERE Remark = '3B' AND Tanggal = " & QVal(tgl) & " AND Cycle= " & QVal(cycle) & " AND Shopcode = " & QVal(shopCode) & ""
                        ExecQueryCKR(udpateOpenDN)

                        Dim udpateFlagDN As String = "Update KanbanADM 
                                        SET ScannedDN = 1 
                                        WHERE (Remark = '3B' OR Remark IS NULL) AND CONVERT(varchar,[OrderDate],101) = " & QVal(tgl) & " AND DelCycle= " & QVal(cycle) & " AND OrderNo=" & QVal(orderNo) & ""
                        ExecQueryCKR(udpateFlagDN)

                        Dim udpateStatus As String = "Update KanbanSum 
                                        SET StatusDN = 
                                                CASE 
                                                    When TotDN = ClosedDN Then 'CLosed' Else 'Open' End 
                                        WHERE Remark = '3B' AND Tanggal = " & QVal(tgl) & " AND Cycle= " & QVal(cycle) & " AND Shopcode = " & QVal(shopCode) & ""
                        ExecQueryCKR(udpateStatus)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetTglByOrderNo(orderNo) As String
        Dim hasil As String = String.Empty
        Try
            Dim sql1 As String = "SELECT TOP 1 CONVERT(varchar,[OrderDate],101) Tanggal FROM [KanbanADM]
                               WHERE OrderNo = '" & orderNo & "' AND (Remark is null OR Remark='3B')"
            Dim dt As New DataTable
            dt = GetDataTableCKR(sql1)
            If dt.Rows.Count > 0 Then
                hasil = dt.Rows(0)(0).ToString()
            End If
            Return hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetTglByOrderNo1(orderNo) As String
        Dim hasil As String = String.Empty
        Try
            Dim sql1 As String = "SELECT TOP OrderDate FROM [KanbanADM]
                               WHERE OrderNo = '" & orderNo & "' AND (Remark is null OR Remark='3B')"
            Dim dt As New DataTable
            dt = GetDataTableCKR(sql1)
            If dt.Rows.Count > 0 Then
                hasil = Convert.ToString(dt.Rows(0)(0))
            End If
            Return hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetCycleByOrderNo(orderNo) As String
        Dim hasil As String = 0
        Try
            Dim sql1 As String = "SELECT TOP 1 DelCycle Cycle FROM [KanbanADM] 
                               WHERE OrderNo = '" & orderNo & "' AND (Remark is null OR Remark='3B')"
            Dim dt As New DataTable
            dt = GetDataTableCKR(sql1)
            If dt.Rows.Count > 0 Then
                hasil = Convert.ToInt32(dt.Rows(0)(0))
            End If
            Return hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetShopCode(orderNo) As String
        Dim hasil As String = 0
        Try
            Dim sql1 As String = "SELECT TOP 1 ShopCode FROM [KanbanADM] 
                               WHERE OrderNo = '" & orderNo & "'"
            Dim dt As New DataTable
            dt = GetDataTableCKR(sql1)
            If dt.Rows.Count > 0 Then
                hasil = Convert.ToString(dt.Rows(0)(0))
            End If
            Return hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
