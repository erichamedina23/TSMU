Public Class ClsReportMatome

    Public Function Proses_ReportMatome(ByVal strYear As String) As DataTable
        Try
            Dim query As String = "stp_sales4"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PerPost", SqlDbType.VarChar)
            pParam(0).Value = strYear
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Proses_stp_sales4(ByVal strYear As String) As DataTable
        Try
            Dim query As String = "stp_sales4"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PerPost", SqlDbType.VarChar)
            pParam(0).Value = strYear
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Proses_stp_sales6(ByVal strYear As String) As DataTable
        Try
            Dim query As String = "Stp_SalesMkt_Aktual"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PerPost", SqlDbType.VarChar)
            pParam(0).Value = strYear
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Sub ProsesActualReport(ByVal strYear As String)
        Try
            Console.WriteLine("Proses Start")
            Dim query As String = "Stp_Sales_Aktual"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PerPost", SqlDbType.VarChar)
            pParam(0).Value = strYear
            MainModul.ExecQueryByCommand_SP_Solomon(query, pParam)

            Console.WriteLine("Done stp4")

            Dim query1 As String = "Stp_SalesMkt_Aktual"
            Dim pParam1() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam1(0) = New SqlClient.SqlParameter("@PerPost", SqlDbType.VarChar)
            pParam1(0).Value = strYear
            MainModul.ExecQueryByCommand_SP_Solomon(query1, pParam1)
            Console.WriteLine("Done Stp_SalesMkt_Aktual")

            Dim ls_SP As String = "update SalesMkt_Aktual set amount=(QtyShip*CuryRate)*CurySlsPrice where CurySlsPriceGab=0"
            MainModul.ExecQuery_Solomon(ls_SP)

            Console.WriteLine("Done SalesMkt2 1")

            Dim ls_SP1 As String = "update SalesMkt_Aktual set amount=(QtyShip*CuryRate)*CurySlsPriceGab where CurySlsPriceGab!=0"
            MainModul.ExecQuery_Solomon(ls_SP1)

            Console.WriteLine("Done SalesMkt2 2")

            Dim ls_SP3 As String = "Delete from SalesMkt3 where Perpost='" & strYear & "'"
            MainModul.ExecQuery_Solomon(ls_SP3)

            Console.WriteLine("Done Delete from SalesMkt3")

            Dim ls_SP4 As String =
            "INSERT INTO SalesMkt3
                (CustOrdNbr,CustID,Name,RelDate,ShipperID,OrdNbr
                ,   InvtID ,AlternateID ,Descr ,QtyShip
                ,   CuryID,   CuryRate,   CurySlsPrice,   CurySlsPriceGab
                ,   CurySlsPrice_SO
                ,   Amount,   OrdDate,   Status,   InvcNbr
                ,   DocType,   Account,   BatNbr,   SiteID,   OrigShipperID,   Perpost)
            SELECT 
                CustOrdNbr
                ,	CustID,	Name,RelDate,	ShipperID,	OrdNbr
                ,	InvtID,	AlternateID,	Descr,	QtyShip
                ,	CuryID,	CuryRate,	CurySlsPrice,	CurySlsPriceGab
                ,	CurySlsPrice_SO,	 Amount ,OrdDate,	Status,	InvcNbr
                ,	DocType,	Account,	BatNbr,	SiteID,	OrigShipperID, '" & strYear & "' FROM SalesMkt_Aktual"
            MainModul.ExecQuery_Solomon(ls_SP4)

            Console.WriteLine("Done INSERT INTO SalesMkt3")

            Dim query3 As String = "update_sales"
            Dim pParam2() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam2(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.VarChar)
            pParam2(0).Value = Microsoft.VisualBasic.Left(strYear, 4)
            MainModul.ExecQueryByCommand_SP(query3, pParam2)

            Console.WriteLine("Done update_sales")
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateSalesMkt2_AmountPriceGab()
        Try
            Dim ls_SP As String = "update SalesMkt2 set amount=(QtyShip*CuryRate)*CurySlsPriceGab where CurySlsPriceGab!=0"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSalesMkt3(ByVal strYear As String)
        Try
            Dim ls_SP As String = "Delete from SalesMkt3 where Perpost='" & strYear & "'"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertSalesMkt3(ByVal strYear As String)
        Try
            Dim ls_SP As String =
            "INSERT INTO SalesMkt3
                (CustOrdNbr,CustID,Name,RelDate,ShipperID,OrdNbr
                ,   InvtID ,AlternateID ,Descr ,QtyShip
                ,   CuryID,   CuryRate,   CurySlsPrice,   CurySlsPriceGab
                ,   CurySlsPrice_SO
                ,   Amount,   OrdDate,   Status,   InvcNbr
                ,   DocType,   Account,   BatNbr,   SiteID,   OrigShipperID,   Perpost)
            SELECT 
                CustOrdNbr
                ,	CustID,	Name,RelDate,	ShipperID,	OrdNbr
                ,	InvtID,	AlternateID,	Descr,	QtyShip
                ,	CuryID,	CuryRate,	CurySlsPrice,	CurySlsPriceGab
                ,	CurySlsPrice_SO,	 Amount ,OrdDate,	Status,	InvcNbr
                ,	DocType,	Account,	BatNbr,	SiteID,	OrigShipperID, '" & strYear & "' FROM SalesMkt3"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function UpdateSales(ByVal strYear As String) As DataTable
        Try
            Dim query As String = "update_sales"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.VarChar)
            pParam(0).Value = Left(strYear, 4)
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Generate_Report_Matome(strYear As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            'Dim query As String = "[GetREportMatome_New2]"
            Dim query As String = "[Matome]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(0).Value = Left(strYear, 4)
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class
