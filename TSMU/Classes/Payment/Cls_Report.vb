Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_report
    Dim query As String = String.Empty

    Private tglawal As Date
    Public Property TanggalAwal() As Date
        Get
            Return tglawal
        End Get
        Set(ByVal value As Date)
            tglawal = value
        End Set
    End Property

    Private tglakhir As Date
    Public Property TanggalAkhir() As Date
        Get
            Return tglakhir
        End Get
        Set(ByVal value As Date)
            tglakhir = value
        End Set
    End Property


    Private tglawal1 As Date
    Public Property TanggalAwal1() As Date
        Get
            Return tglawal1
        End Get
        Set(ByVal value As Date)
            tglawal1 = value
        End Set
    End Property

    Private tglakhir1 As Date
    Public Property TanggalAkhir1() As Date
        Get
            Return tglakhir1
        End Get
        Set(ByVal value As Date)
            tglakhir1 = value
        End Set
    End Property
    Private _bankname As String
    Public Property BankName() As String
        Get
            Return _bankname
        End Get
        Set(ByVal value As String)
            _bankname = value
        End Set
    End Property

    Private _supplier As String
    Public Property supplier() As String
        Get
            Return _supplier
        End Get
        Set(ByVal value As String)
            _supplier = value
        End Set
    End Property

    Public Function cmbsupplier() As DataTable
        Try
            query = "Select VendID, Name FROM Vendor where status='A' order by name"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTableByCommand_sol(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function cmbsupplierall() As DataTable
        Try
            query = "Select VendID, Name FROM Vendor order by name"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private _customer As String
    Public Property customer() As String
        Get
            Return _customer
        End Get
        Set(ByVal value As String)
            _customer = value
        End Set
    End Property

    Public Function cmbcustomer() As DataTable
        Try
            query = "Select CustID, Name FROM Customer where status='A' order by name"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTableByCommand_sol(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function cmbcustomerall() As DataTable
        Try
            query = "Select CustID, Name FROM Customer order by name"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DataGridViewPayment(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewPayment"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DataGridViewAR(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewAR"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridViewReportEntertainmentTaxAdvance(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewReportEntertainmentAdvance"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function DXReportUploadToMizuho() As DataSet
        Throw New NotImplementedException()
    End Function

    Public Function DataGridViewUploadToSolomon(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewUploadSolomon_PilihSupplier"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridViewPPNTax(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewPPNTax"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridUploadToSolomon(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewUploadToSolomon"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridUploadToSolomonOk(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewUploadToSolomonOk"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function AR_UploadToSolomon(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "AR_UploadToSolomon"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function DataGridUploadToSolomonUploaded(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewUploadToSolomonUploaded"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridUploadToSolomonchecked(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewUploadToSolomonChecked"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridUploadToSolomonCheck(ByVal date1 As String, ByVal date2 As String, ByVal check As Boolean, ByVal vrno As String) As DataTable
        Try
            Dim query As String = "ViewUploadToSolomonCheck"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            pParam(2) = New SqlClient.SqlParameter("@check", SqlDbType.Bit)
            pParam(2).Value = check
            pParam(3) = New SqlClient.SqlParameter("@vrno", SqlDbType.VarChar)
            pParam(3).Value = vrno
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Function DataGridViewUploadMizuho(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ViewUploadMizuho"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridSyncTemplate(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "SyncBasedOnTemplate"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridSyncMizuho(ByVal Date3 As String, ByVal Date4 As String) As DataTable
        Try
            Dim query As String = "SyncMizuho"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@Date3", SqlDbType.VarChar)
            pParam(0).Value = Date3
            pParam(1) = New SqlClient.SqlParameter("@Date4", SqlDbType.VarChar)
            pParam(1).Value = Date4
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function DataGridViewTemplateMizuho() As DataTable
        Try
            Dim query As String = "TemplateMizuho"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            'pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            'pParam(0).Value = date1
            'pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            'pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Mizuho(ByVal date1 As String, ByVal date2 As String) As DataSet
        Dim ds As dsLaporan
        Try
            Dim query As String = "ViewUploadMizuho"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.DateTime)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.DateTime)
            pParam(1).Value = date2
            ds = New dsLaporan
            ds = MainModul.GetDataSetByCommand_StoreP(query, "mizuho", pParam)
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Function GetdataGrid(date1 As String, date2 As String) As DataTable
        Try
            Dim sql As String = "ViewUploadMizuho"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            'dt = MainModul.GetDataTable_solomon(sql)
            'CultureInfo.CurrentCulture = New CultureInfo("id-ID")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ReportMizuho()
        Try
            Dim sql As String = "ViewUploadMizuho"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function DataGridReportUploadSolomon(ByVal date1 As String, ByVal date2 As String) As DataTable
        Try
            Dim query As String = "ReportUploadToSolomon"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DXReportUploadToMizuho(ByVal date1 As String, ByVal date2 As String) As DataSet
        'Try
        '    Dim query As String = "ViewUploadMizuho"
        '    Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        '    pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
        '    pParam(0).Value = date1
        '    pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
        '    pParam(1).Value = date2
        '    'Dim ds As New DataSet
        '    'ds = MainModul.GetDataSetByCommand_StoreP(query, pParam)
        '    'Return ds

        '    ''Dim query As String
        '    ''date1 = Form2.DateEdit1.Text + " 00:00:00"
        '    ''date2 = Form2.DateEdit2.Text + " 00:00:00"

        '    ''query = "ViewUploadMizuho"
        '    Dim ds As New DataSet
        '    ds = MainModul.GetDataSetByCommand_StoreP(query, "mizuho")
        '    Return ds
        'Catch ex As Exception
        '    ''Throw
        'End Try
        Try
            'date1 = Form2.DateEdit1.Text + " 00:00:00"
            'date2 = Form2.DateEdit2.Text + " 00:00:00"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2

            Dim query As String = "ViewUploadMizuho"
            Dim ds As New DataSet
            ds = GetDataSetByCommand_StoreP(query, "mizuho")
            Return ds
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function DataGridViewPPhTax(ByVal date1 As String, ByVal date2 As String, ByVal pph As String, ByVal site As String) As DataTable
        Try
            Dim query As String = "ViewPPhTax"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@date1", SqlDbType.VarChar)
            pParam(0).Value = date1
            pParam(1) = New SqlClient.SqlParameter("@date2", SqlDbType.VarChar)
            pParam(1).Value = date2
            pParam(2) = New SqlClient.SqlParameter("@pph", SqlDbType.VarChar)
            pParam(2).Value = pph
            pParam(3) = New SqlClient.SqlParameter("@site", SqlDbType.VarChar)
            pParam(3).Value = site
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function DataGridViewPaymentSup(ByVal datesup1 As String, ByVal datesup2 As String, ByVal suppliername As String) As DataTable
        Try
            Dim query As String = "ViewPaymentSup"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@datesup1", SqlDbType.VarChar)
            pParam(0).Value = datesup1
            pParam(1) = New SqlClient.SqlParameter("@datesup2", SqlDbType.VarChar)
            pParam(1).Value = datesup2
            pParam(2) = New SqlClient.SqlParameter("@suppliername", SqlDbType.VarChar)
            pParam(2).Value = suppliername
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataGridViewReportEntertainmentTaxSettle(ByVal datesup1 As String, ByVal datesup2 As String) As DataTable
        Try
            Dim query As String = "ViewReportEntertainmentSettle"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@datesup1", SqlDbType.VarChar)
            pParam(0).Value = datesup1
            pParam(1) = New SqlClient.SqlParameter("@datesup2", SqlDbType.VarChar)
            pParam(1).Value = datesup2
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_StoreP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
