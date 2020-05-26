Public Class ReportAdmModels
    Public Function GetDataGrid(ByVal strStatus As String, tgl As String, tgl1 As String, site As String) As DataTable
        Try
            Dim query As String = String.Empty
            Dim dt As New DataTable

            If gh_Common.Site.ToLower = "tng" Then
                query = "GetDataBarcode"

                Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
                pParam(0) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
                pParam(0).Value = strStatus
                pParam(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.Date)
                pParam(1).Value = tgl
                pParam(2) = New SqlClient.SqlParameter("@tgl1", SqlDbType.Date)
                pParam(2).Value = tgl1

                dt = GetDataTableByCommand_SP(query, pParam)

            Else
                query = "getBarcodeTSC_ADM"
                Dim pParam1() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
                pParam1(0) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
                pParam1(0).Value = strStatus
                pParam1(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.Date)
                pParam1(1).Value = tgl
                pParam1(2) = New SqlClient.SqlParameter("@tgl1", SqlDbType.Date)
                pParam1(2).Value = tgl1
                pParam1(3) = New SqlClient.SqlParameter("@site", SqlDbType.VarChar)
                pParam1(3).Value = site

                dt = GetDataTableByCommand_StorePCKR(query, pParam1)

            End If
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetDataGridBarcodeGenerate() As DataTable
        Try
            Dim query As String = "GetReportBarcodeGenerate"
            Dim dt As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dt = GetDataTableByCommand_SP(query)
            Else
                dt = GetDataTableByCommand_StorePCKR(query)
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class


Public Class ReportBarcodePrintLog

    Public Function GetDataGrid(tgl As String, tgl1 As String) As DataTable
        Try
            Dim query As String = "Select  
	            CustID, 
	            KodePart,
                InventoryID,
                PartName,
                PartNo,
	            Bulan,
	            [Site],
	            [No] LastNo,
	            PrintedBy,
	            PrintedDate
            from BarcodePrintLog
            where convert(date,PrintedDate) >= " & QVal(tgl) & " AND convert(date,PrintedDate) <= " & QVal(tgl1) & ""

            Dim query1 As String = "Select  
	            KodePart,
	            Bulan,
	            [Site],
	            [No] LastNo,
	            PrintedBy,
	            PrintedDate
            from BarcodePrintLog
            where convert(date,PrintedDate) >= " & QVal(tgl) & " AND convert(date,PrintedDate) <= " & QVal(tgl1) & ""
            Dim dt As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dt = GetDataTable(query)
            Else
                dt = GetDataTableCKR(query1)
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


End Class

Public Class ReportScanDN
    Public Function GetDataGrid(tgl As String, tgl1 As String, site As String, status As String) As DataTable
        Try
            Dim query As String = "SELECT 
	                                c.BarcodeADM, 
	                                c.BarcodeTSC, 
	                                c.BarcodeTSCOrg, 
	                                c.Status, 
	                                CONVERT(varchar,c.CreatedDate,105) CreatedDate, 
	                                d.DNNbr, 
	                                CONVERT(varchar,d.CreatedDate,105) as CreatedDateDN, 
                                    d.NoPolisi, 
	                                d.Sopir, 
	                                CONVERT(varchar,d.DelDate,105) DelDate, 
	                                CONVERT(VARCHAR(8),(CONVERT(TIME(0), d.DelTime,0))) AS DelTime 
                                FROM BarcodeCompareTable c left outer join 
	                                (SELECT 
		                                a.OrderNo AS DNNbr, 
		                                a.CreatedDate, 
		                                a.NoPolisi, 
		                                a.Sopir, 
		                                b.DelDate, 
		                                b.deltime 
	                                FROM KanbanAdmScanDN a join 
		                                (SELECT DISTINCT orderno, 
			                                Deldate, 
			                                deltime 
		                                FROM KanbanADM)b 
	                                ON a.OrderNo = b.OrderNo 
                                WHERE convert(date,a.CreatedDate) >= " & QVal(tgl) & " AND convert(date,a.CreatedDate) <= " & QVal(tgl1) & " 
                                AND a.OrderNo = COALESCE(NULLIF(" & QVal(site) & ",'ALL'),a.OrderNo))d
                                ON LEFT(c.barcodeadm,16) = d.DNNbr 
                                WHERE convert(date,c.CreatedDate) >= " & QVal(tgl) & " AND convert(date,c.CreatedDate) <= " & QVal(tgl) & " 
                                AND c.[status] = COALESCE(NULLIF(" & QVal(status) & ",'ALL'),c.[status])"
            Dim dt As New DataTable

            dt = GetDataTableCKR(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class

Public Class ReportYIM
    Public Function GetDataGrid(ByVal strStatus As String, tgl As String, tgl1 As String) As DataTable
        Try
            Dim query As String = String.Empty
            Dim dt As New DataTable

            query = "GetReportBarcodeYIM"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
            pParam(0).Value = strStatus
            pParam(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.Date)
            pParam(1).Value = tgl
            pParam(2) = New SqlClient.SqlParameter("@tgl1", SqlDbType.Date)
            pParam(2).Value = tgl1

            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class