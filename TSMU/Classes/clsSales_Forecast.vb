Imports System.Collections.ObjectModel
Public Class clsSales_Forecast
    Dim _Query As String

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _tahun As String
    Public Property Tahun() As String
        Get
            Return _tahun
        End Get
        Set(ByVal value As String)
            _tahun = value
        End Set
    End Property

    Private _custid As String
    Public Property CustomerId() As String
        Get
            Return _custid
        End Get
        Set(ByVal value As String)
            _custid = value
        End Set
    End Property

    Private _customer As String
    Public Property Customer() As String
        Get
            Return _customer
        End Get
        Set(ByVal value As String)
            _customer = value
        End Set
    End Property
    Private _invtid As String
    Public Property InvtId() As String
        Get
            Return _invtid
        End Get
        Set(ByVal value As String)
            _invtid = value
        End Set
    End Property
    Private _descr As String
    Public Property Descr() As String
        Get
            Return _descr
        End Get
        Set(ByVal value As String)
            _descr = value
        End Set
    End Property
    Private _partno As String
    Public Property PartNo() As String
        Get
            Return _partno
        End Get
        Set(ByVal value As String)
            _partno = value
        End Set
    End Property

    'Private _partname As String
    'Public Property PartNo() As String
    '    Get
    '        Return _partno
    '    End Get
    '    Set(ByVal value As String)
    '        _partno = value
    '    End Set
    'End Property

    Private _model As String
    Public Property Model() As String
        Get
            Return _model
        End Get
        Set(ByVal value As String)
            _model = value
        End Set
    End Property

    Private _oe_re As String
    Public Property Oe_Re() As String
        Get
            Return _oe_re
        End Get
        Set(ByVal value As String)
            _oe_re = value
        End Set
    End Property
    Private _in_sub As String
    Public Property In_Sub() As String
        Get
            Return _in_sub
        End Get
        Set(ByVal value As String)
            _in_sub = value
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

    Private _jan_qty01 As Integer
    Public Property Jan_Qty01() As Integer
        Get
            Return _jan_qty01
        End Get
        Set(ByVal value As Integer)
            _jan_qty01 = value
        End Set
    End Property

    Private _jan_qty02 As Integer
    Public Property Jan_Qty02() As Integer
        Get
            Return _jan_qty02
        End Get
        Set(ByVal value As Integer)
            _jan_qty02 = value
        End Set
    End Property

    Private _jan_qty03 As Integer
    Public Property Jan_Qty03() As Integer
        Get
            Return _jan_qty03
        End Get
        Set(ByVal value As Integer)
            _jan_qty03 = value
        End Set
    End Property

    Private _jan_po01 As Integer
    Public Property Jan_PO01() As Integer
        Get
            Return _jan_po01
        End Get
        Set(ByVal value As Integer)
            _jan_po01 = value
        End Set
    End Property

    Private _jan_po02 As Integer
    Public Property Jan_PO02() As Integer
        Get
            Return _jan_po02
        End Get
        Set(ByVal value As Integer)
            _jan_po02 = value
        End Set
    End Property

    Private _jan_po03 As Integer
    Public Property Jan_PO03() As Integer
        Get
            Return _jan_po03
        End Get
        Set(ByVal value As Integer)
            _jan_po03 = value
        End Set
    End Property

    Private _feb_qty01 As Integer
    Public Property Feb_Qty01() As Integer
        Get
            Return _feb_qty01
        End Get
        Set(ByVal value As Integer)
            _feb_qty01 = value
        End Set
    End Property

    Private _feb_qty02 As Integer
    Public Property Feb_Qty02() As Integer
        Get
            Return _feb_qty02
        End Get
        Set(ByVal value As Integer)
            _feb_qty02 = value
        End Set
    End Property

    Private _feb_qty03 As Integer
    Public Property Feb_Qty03() As Integer
        Get
            Return _feb_qty03
        End Get
        Set(ByVal value As Integer)
            _feb_qty03 = value
        End Set
    End Property

    Private _feb_po01 As Integer
    Public Property Feb_PO01() As Integer
        Get
            Return _feb_po01
        End Get
        Set(ByVal value As Integer)
            _feb_po01 = value
        End Set
    End Property

    Private _feb_po02 As Integer
    Public Property Feb_PO02() As Integer
        Get
            Return _feb_po02
        End Get
        Set(ByVal value As Integer)
            _feb_po02 = value
        End Set
    End Property

    Private _feb_po03 As Integer
    Public Property Feb_PO03() As Integer
        Get
            Return _feb_po03
        End Get
        Set(ByVal value As Integer)
            _feb_po03 = value
        End Set
    End Property

    Private _mar_qty01 As Integer
    Public Property Mar_Qty01() As Integer
        Get
            Return _mar_qty01
        End Get
        Set(ByVal value As Integer)
            _mar_qty01 = value
        End Set
    End Property

    Private _mar_qty02 As Integer
    Public Property Mar_Qty02() As Integer
        Get
            Return _mar_qty02
        End Get
        Set(ByVal value As Integer)
            _mar_qty02 = value
        End Set
    End Property

    Private _mar_qty03 As Integer
    Public Property Mar_Qty03() As Integer
        Get
            Return _mar_qty03
        End Get
        Set(ByVal value As Integer)
            _mar_qty03 = value
        End Set
    End Property


    Private _mar_po01 As Integer
    Public Property Mar_PO01() As Integer
        Get
            Return _mar_po01
        End Get
        Set(ByVal value As Integer)
            _mar_po01 = value
        End Set
    End Property

    Private _mar_po02 As Integer
    Public Property Mar_PO02() As Integer
        Get
            Return _mar_po02
        End Get
        Set(ByVal value As Integer)
            _mar_po02 = value
        End Set
    End Property

    Private _mar_po03 As Integer
    Public Property Mar_PO03() As Integer
        Get
            Return _mar_po03
        End Get
        Set(ByVal value As Integer)
            _mar_po03 = value
        End Set
    End Property

    Private _apr_qty01 As Integer
    Public Property Apr_Qty01() As Integer
        Get
            Return _apr_qty01
        End Get
        Set(ByVal value As Integer)
            _apr_qty01 = value
        End Set
    End Property

    Private _apr_qty02 As Integer
    Public Property Apr_Qty02() As Integer
        Get
            Return _apr_qty02
        End Get
        Set(ByVal value As Integer)
            _apr_qty02 = value
        End Set
    End Property

    Private _apr_qty03 As Integer
    Public Property Apr_Qty03() As Integer
        Get
            Return _apr_qty03
        End Get
        Set(ByVal value As Integer)
            _apr_qty03 = value
        End Set
    End Property

    Private _apr_po01 As Integer
    Public Property Apr_PO01() As Integer
        Get
            Return _apr_po01
        End Get
        Set(ByVal value As Integer)
            _apr_po01 = value
        End Set
    End Property

    Private _apr_po02 As Integer
    Public Property Apr_PO02() As Integer
        Get
            Return _apr_po02
        End Get
        Set(ByVal value As Integer)
            _apr_po02 = value
        End Set
    End Property

    Private _apr_po03 As Integer
    Public Property Apr_PO03() As Integer
        Get
            Return _apr_po03
        End Get
        Set(ByVal value As Integer)
            _apr_po03 = value
        End Set
    End Property

    Private _mei_qty01 As Integer
    Public Property Mei_Qty01() As Integer
        Get
            Return _mei_qty01
        End Get
        Set(ByVal value As Integer)
            _mei_qty01 = value
        End Set
    End Property

    Private _mei_qty02 As Integer
    Public Property Mei_Qty02() As Integer
        Get
            Return _mei_qty02
        End Get
        Set(ByVal value As Integer)
            _mei_qty02 = value
        End Set
    End Property

    Private _mei_qty03 As Integer
    Public Property Mei_Qty03() As Integer
        Get
            Return _mei_qty03
        End Get
        Set(ByVal value As Integer)
            _mei_qty03 = value
        End Set
    End Property


    Private _mei_po01 As Integer
    Public Property Mei_PO01() As Integer
        Get
            Return _mei_po01
        End Get
        Set(ByVal value As Integer)
            _mei_po01 = value
        End Set
    End Property

    Private _mei_po02 As Integer
    Public Property Mei_PO02() As Integer
        Get
            Return _mei_po02
        End Get
        Set(ByVal value As Integer)
            _mei_po02 = value
        End Set
    End Property

    Private _mei_po03 As Integer
    Public Property Mei_PO03() As Integer
        Get
            Return _mei_po03
        End Get
        Set(ByVal value As Integer)
            _mei_po03 = value
        End Set
    End Property

    Private _jun_qty01 As Integer
    Public Property Jun_Qty01() As Integer
        Get
            Return _jun_qty01
        End Get
        Set(ByVal value As Integer)
            _jun_qty01 = value
        End Set
    End Property

    Private _jun_qty02 As Integer
    Public Property Jun_Qty02() As Integer
        Get
            Return _jun_qty02
        End Get
        Set(ByVal value As Integer)
            _jun_qty02 = value
        End Set
    End Property

    Private _jun_qty03 As Integer
    Public Property Jun_Qty03() As Integer
        Get
            Return _jun_qty03
        End Get
        Set(ByVal value As Integer)
            _jun_qty03 = value
        End Set
    End Property

    Private _jun_po01 As Integer
    Public Property Jun_PO01() As Integer
        Get
            Return _jun_po01
        End Get
        Set(ByVal value As Integer)
            _jun_po01 = value
        End Set
    End Property

    Private _jun_po02 As Integer
    Public Property Jun_PO02() As Integer
        Get
            Return _jun_po02
        End Get
        Set(ByVal value As Integer)
            _jun_po02 = value
        End Set
    End Property

    Private _jun_po03 As Integer
    Public Property Jun_PO03() As Integer
        Get
            Return _jun_po03
        End Get
        Set(ByVal value As Integer)
            _jun_po03 = value
        End Set
    End Property

    Private _jul_qty01 As Integer
    Public Property Jul_Qty01() As Integer
        Get
            Return _jul_qty01
        End Get
        Set(ByVal value As Integer)
            _jul_qty01 = value
        End Set
    End Property

    Private _jul_qty02 As Integer
    Public Property Jul_Qty02() As Integer
        Get
            Return _jul_qty02
        End Get
        Set(ByVal value As Integer)
            _jul_qty02 = value
        End Set
    End Property

    Private _jul_qty03 As Integer
    Public Property Jul_Qty03() As Integer
        Get
            Return _jul_qty03
        End Get
        Set(ByVal value As Integer)
            _jul_qty03 = value
        End Set
    End Property

    Private _jul_po01 As Integer
    Public Property Jul_PO01() As Integer
        Get
            Return _jul_po01
        End Get
        Set(ByVal value As Integer)
            _jul_po01 = value
        End Set
    End Property

    Private _jul_po02 As Integer
    Public Property Jul_PO02() As Integer
        Get
            Return _jul_po02
        End Get
        Set(ByVal value As Integer)
            _jul_po02 = value
        End Set
    End Property

    Private _jul_po03 As Integer
    Public Property Jul_PO03() As Integer
        Get
            Return _jul_po03
        End Get
        Set(ByVal value As Integer)
            _jul_po03 = value
        End Set
    End Property

    Private _agt_qty01 As Integer
    Public Property Agt_Qty01() As Integer
        Get
            Return _agt_qty01
        End Get
        Set(ByVal value As Integer)
            _agt_qty01 = value
        End Set
    End Property

    Private _agt_qty02 As Integer
    Public Property Agt_Qty02() As Integer
        Get
            Return _agt_qty02
        End Get
        Set(ByVal value As Integer)
            _agt_qty02 = value
        End Set
    End Property

    Private _agt_qty03 As Integer
    Public Property Agt_Qty03() As Integer
        Get
            Return _agt_qty03
        End Get
        Set(ByVal value As Integer)
            _agt_qty03 = value
        End Set
    End Property

    Private _agt_po01 As Integer
    Public Property Agt_PO01() As Integer
        Get
            Return _agt_po01
        End Get
        Set(ByVal value As Integer)
            _agt_po01 = value
        End Set
    End Property

    Private _agt_po02 As Integer
    Public Property Agt_PO02() As Integer
        Get
            Return _agt_po02
        End Get
        Set(ByVal value As Integer)
            _agt_po02 = value
        End Set
    End Property

    Private _agt_po03 As Integer
    Public Property Agt_PO03() As Integer
        Get
            Return _agt_po03
        End Get
        Set(ByVal value As Integer)
            _agt_po03 = value
        End Set
    End Property

    Private _sep_qty01 As Integer
    Public Property Sep_Qty01() As Integer
        Get
            Return _sep_qty01
        End Get
        Set(ByVal value As Integer)
            _sep_qty01 = value
        End Set
    End Property

    Private _sep_qty02 As Integer
    Public Property Sep_Qty02() As Integer
        Get
            Return _sep_qty02
        End Get
        Set(ByVal value As Integer)
            _sep_qty02 = value
        End Set
    End Property

    Private _sep_qty03 As Integer
    Public Property Sep_Qty03() As Integer
        Get
            Return _sep_qty03
        End Get
        Set(ByVal value As Integer)
            _sep_qty03 = value
        End Set
    End Property

    Private _sep_po01 As Integer
    Public Property Sep_PO01() As Integer
        Get
            Return _sep_po01
        End Get
        Set(ByVal value As Integer)
            _sep_po01 = value
        End Set
    End Property

    Private _sep_po02 As Integer
    Public Property Sep_PO02() As Integer
        Get
            Return _sep_po02
        End Get
        Set(ByVal value As Integer)
            _sep_po02 = value
        End Set
    End Property

    Private _sep_po03 As Integer
    Public Property Sep_PO03() As Integer
        Get
            Return _sep_po03
        End Get
        Set(ByVal value As Integer)
            _sep_po03 = value
        End Set
    End Property

    Private _okt_qty01 As Integer
    Public Property Okt_Qty01() As Integer
        Get
            Return _okt_qty01
        End Get
        Set(ByVal value As Integer)
            _okt_qty01 = value
        End Set
    End Property

    Private _okt_qty02 As Integer
    Public Property Okt_Qty02() As Integer
        Get
            Return _okt_qty02
        End Get
        Set(ByVal value As Integer)
            _okt_qty02 = value
        End Set
    End Property

    Private _okt_qty03 As Integer
    Public Property Okt_Qty03() As Integer
        Get
            Return _okt_qty03
        End Get
        Set(ByVal value As Integer)
            _okt_qty03 = value
        End Set
    End Property

    Private _okt_po01 As Integer
    Public Property Okt_PO01() As Integer
        Get
            Return _okt_po01
        End Get
        Set(ByVal value As Integer)
            _okt_po01 = value
        End Set
    End Property

    Private _okt_po02 As Integer
    Public Property Okt_PO02() As Integer
        Get
            Return _okt_po02
        End Get
        Set(ByVal value As Integer)
            _okt_po02 = value
        End Set
    End Property

    Private _okt_po03 As Integer
    Public Property Okt_PO03() As Integer
        Get
            Return _okt_po03
        End Get
        Set(ByVal value As Integer)
            _okt_po03 = value
        End Set
    End Property

    Private _nov_qty01 As Integer
    Public Property Nov_Qty01() As Integer
        Get
            Return _nov_qty01
        End Get
        Set(ByVal value As Integer)
            _nov_qty01 = value
        End Set
    End Property

    Private _nov_qty02 As Integer
    Public Property Nov_Qty02() As Integer
        Get
            Return _nov_qty02
        End Get
        Set(ByVal value As Integer)
            _nov_qty02 = value
        End Set
    End Property

    Private _nov_qty03 As Integer
    Public Property Nov_Qty03() As Integer
        Get
            Return _nov_qty03
        End Get
        Set(ByVal value As Integer)
            _nov_qty03 = value
        End Set
    End Property

    Private _nov_po01 As Integer
    Public Property Nov_PO01() As Integer
        Get
            Return _nov_po01
        End Get
        Set(ByVal value As Integer)
            _nov_po01 = value
        End Set
    End Property

    Private _nov_po02 As Integer
    Public Property Nov_PO02() As Integer
        Get
            Return _nov_po02
        End Get
        Set(ByVal value As Integer)
            _nov_po02 = value
        End Set
    End Property

    Private _nov_po03 As Integer
    Public Property Nov_PO03() As Integer
        Get
            Return _nov_po03
        End Get
        Set(ByVal value As Integer)
            _nov_po03 = value
        End Set
    End Property

    Private _des_qty01 As Integer
    Public Property Des_Qty01() As Integer
        Get
            Return _des_qty01
        End Get
        Set(ByVal value As Integer)
            _des_qty01 = value
        End Set
    End Property

    Private _des_qty02 As Integer
    Public Property Des_Qty02() As Integer
        Get
            Return _des_qty02
        End Get
        Set(ByVal value As Integer)
            _des_qty02 = value
        End Set
    End Property

    Private _des_qty03 As Integer
    Public Property Des_Qty03() As Integer
        Get
            Return _des_qty03
        End Get
        Set(ByVal value As Integer)
            _des_qty03 = value
        End Set
    End Property

    Private _des_po01 As Integer
    Public Property Des_PO01() As Integer
        Get
            Return _des_po01
        End Get
        Set(ByVal value As Integer)
            _des_po01 = value
        End Set
    End Property

    Private _des_po02 As Integer
    Public Property Des_PO02() As Integer
        Get
            Return _des_po02
        End Get
        Set(ByVal value As Integer)
            _des_po02 = value
        End Set
    End Property

    Private _des_po03 As Integer
    Public Property Des_PO03() As Integer
        Get
            Return _des_po03
        End Get
        Set(ByVal value As Integer)
            _des_po03 = value
        End Set
    End Property

    Private _revisi As Integer
    Public Property Revisi() As Integer
        Get
            Return _revisi
        End Get
        Set(ByVal value As Integer)
            _revisi = value
        End Set
    End Property


    Public Sub New()
        'Me._Query = "select acctid as [Account ID], acctname [Account Name], tipe [Type] from tipeacct order by AcctID"
    End Sub
    Public Function GetAllDataGrid(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String = "sp_sales_forecast_GetDataGrid"
            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand_SP(ls_SP)
            'If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '    With dtTable.Rows(0)
            '        Me._id = Trim(.Item("ID") & "")
            '    End With
            'End If
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getCusst_Solomon() As DataTable
        Try
            Dim query As String = "select CustId [Customer ID], [Name] from Customer order by [Name]"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getCusstID_Solomon() As DataTable
        Try
            Dim query As String = "select distinct CustId from Customer where left(custid,1) <> '0'"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getPartNo_Solomon(ByVal cust As String) As DataTable
        Try
            Dim query As String = "select AlternateID,InvtID,Descr from itemxref where altIDType='C' and EntityID= " & QVal(cust) & " order by EntityID,AlternateID"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    'Public Function GetAllData() As DataTable
    '    Try
    '        Dim ls_SP As String = "select bomid as [BoM ID],invtid as [Inventory ID], descr as Description, siteid as Site " & _
    '            "from bomh order by bomid"
    '        Dim dtTable As New DataTable
    '        dtTable = GetDataTableByCommand(ls_SP)

    '        Return dtTable
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "sp_sales_forecast_getDatabyID"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

            pParam(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
            pParam(0).Value = ID

            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand_SP(query, pParam)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._id = Trim(.Item("ID") & "")
                    Me._tahun = Trim(.Item("tahun") & "")
                    Me._custid = Trim(.Item("custid") & "")
                    Me._customer = Trim(.Item("customer") & "")
                    Me._invtid = Trim(.Item("invtid") & "")
                    Me._descr = Trim(.Item("descr") & "")
                    Me._partno = Trim(.Item("partno") & "")
                    Me._model = Trim(.Item("model") & "")
                    Me._oe_re = Trim(.Item("oe_re") & "")
                    Me._in_sub = Trim(.Item("in_sub") & "")
                    Me._site = Trim(.Item("site") & "")

                    Me._jan_qty01 = Trim(.Item("jan_qty01") & "")
                    Me._jan_qty02 = Trim(.Item("jan_qty02") & "")
                    Me._jan_qty03 = Trim(.Item("jan_qty03") & "")
                    Me._jan_po01 = Trim(.Item("jan_po01") & "")
                    Me._jan_po02 = Trim(.Item("jan_po02") & "")
                    'Me._jan_po03 = Trim(.Item("jan_po03") & "")

                    Me._feb_qty01 = Trim(.Item("feb_qty01") & "")
                    Me._feb_qty02 = Trim(.Item("feb_qty02") & "")
                    Me._feb_qty03 = Trim(.Item("feb_qty03") & "")
                    Me._feb_po01 = Trim(.Item("feb_po01") & "")
                    Me._feb_po02 = Trim(.Item("feb_po02") & "")
                    'Me._feb_po03 = Trim(.Item("feb_po03") & "")

                    Me._mar_qty01 = Trim(.Item("mar_qty01") & "")
                    Me._mar_qty02 = Trim(.Item("mar_qty02") & "")
                    Me._mar_qty03 = Trim(.Item("mar_qty03") & "")
                    Me._mar_po01 = Trim(.Item("mar_po01") & "")
                    Me._mar_po02 = Trim(.Item("mar_po02") & "")
                    'Me._mar_po03 = Trim(.Item("mar_po03") & "")

                    Me._apr_qty01 = Trim(.Item("apr_qty01") & "")
                    Me._apr_qty02 = Trim(.Item("apr_qty02") & "")
                    Me._apr_qty03 = Trim(.Item("apr_qty03") & "")
                    Me._apr_po01 = Trim(.Item("apr_po01") & "")
                    Me._apr_po02 = Trim(.Item("apr_po02") & "")
                    'Me._apr_po03 = Trim(.Item("apr_po03") & "")

                    Me._mei_qty01 = Trim(.Item("mei_qty01") & "")
                    Me._mei_qty02 = Trim(.Item("mei_qty02") & "")
                    Me._mei_qty03 = Trim(.Item("mei_qty03") & "")
                    Me._mei_po01 = Trim(.Item("mei_po01") & "")
                    Me._mei_po02 = Trim(.Item("mei_po02") & "")
                    'Me._mei_po03 = Trim(.Item("mei_po03") & "")

                    Me._jun_qty01 = Trim(.Item("jun_qty01") & "")
                    Me._jun_qty02 = Trim(.Item("jun_qty02") & "")
                    Me._jun_qty03 = Trim(.Item("jun_qty03") & "")
                    Me._jun_po01 = Trim(.Item("jun_po01") & "")
                    Me._jun_po02 = Trim(.Item("jun_po02") & "")
                    'Me._jun_po03 = Trim(.Item("jun_po03") & "")

                    Me._jul_qty01 = Trim(.Item("jul_qty01") & "")
                    Me._jul_qty02 = Trim(.Item("jul_qty02") & "")
                    Me._jul_qty03 = Trim(.Item("jul_qty03") & "")
                    Me._jul_po01 = Trim(.Item("jul_po01") & "")
                    Me._jul_po02 = Trim(.Item("jul_po02") & "")
                    'Me._jul_po03 = Trim(.Item("jul_po03") & "")

                    Me._agt_qty01 = Trim(.Item("agt_qty01") & "")
                    Me._agt_qty02 = Trim(.Item("agt_qty02") & "")
                    Me._agt_qty03 = Trim(.Item("agt_qty03") & "")
                    Me._agt_po01 = Trim(.Item("agt_po01") & "")
                    Me._agt_po02 = Trim(.Item("agt_po02") & "")
                    'Me._agt_po03 = Trim(.Item("agt_po03") & "")

                    Me._sep_qty01 = Trim(.Item("sep_qty01") & "")
                    Me._sep_qty02 = Trim(.Item("sep_qty02") & "")
                    Me._sep_qty03 = Trim(.Item("sep_qty03") & "")
                    Me._sep_po01 = Trim(.Item("sep_po01") & "")
                    Me._sep_po02 = Trim(.Item("sep_po02") & "")
                    'Me._sep_po03 = Trim(.Item("sep_po03") & "")

                    Me._okt_qty01 = Trim(.Item("okt_qty01") & "")
                    Me._okt_qty02 = Trim(.Item("okt_qty02") & "")
                    Me._okt_qty03 = Trim(.Item("okt_qty03") & "")
                    Me._okt_po01 = Trim(.Item("okt_po01") & "")
                    Me._okt_po02 = Trim(.Item("okt_po02") & "")
                    'Me._okt_po03 = Trim(.Item("okt_po03") & "")

                    Me._nov_qty01 = Trim(.Item("nov_qty01") & "")
                    Me._nov_qty02 = Trim(.Item("nov_qty02") & "")
                    Me._nov_qty03 = Trim(.Item("nov_qty03") & "")
                    Me._nov_po01 = Trim(.Item("nov_po01") & "")
                    Me._nov_po02 = Trim(.Item("nov_po02") & "")
                    'Me._nov_po03 = Trim(.Item("nov_po03") & "")

                    Me._des_qty01 = Trim(.Item("des_qty01") & "")
                    Me._des_qty02 = Trim(.Item("des_qty02") & "")
                    Me._des_qty03 = Trim(.Item("des_qty03") & "")
                    Me._des_po01 = Trim(.Item("des_po01") & "")
                    Me._des_po02 = Trim(.Item("des_po02") & "")
                    'Me._des_po03 = Trim(.Item("des_po03") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me._partno = "" OrElse Me._tahun = "" OrElse Me._invtid = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 tahun,partno,invtid from Budget where tahun = " & QVal(Me._tahun) & " and invtid= " & QVal(Me._invtid) & " and partno = " & QVal(Me._partno) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) & _
                "[" & Me._partno & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()

        Try
            Dim query As String = "INSERT INTO Forecast " & vbCrLf & _
            "   ( " & vbCrLf & _
            "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf & _
            "       , [jan_qty01],[jan_qty02],[jan_qty03],[jan_po01],[jan_po02] " & vbCrLf & _
            "       , [feb_qty01],[feb_qty02],[feb_qty03],[feb_po01],[feb_po02] " & vbCrLf & _
            "       , [mar_qty01],[mar_qty02],[mar_qty03],[mar_po01],[mar_po02] " & vbCrLf & _
            "       , [apr_qty01],[apr_qty02],[apr_qty03],[apr_po01],[apr_po02] " & vbCrLf & _
            "       , [mei_qty01],[mei_qty02],[mei_qty03],[mei_po01],[mei_po02] " & vbCrLf & _
            "       , [jun_qty01],[jun_qty02],[jun_qty03],[jun_po01],[jun_po02] " & vbCrLf & _
            "       , [jul_qty01],[jul_qty02],[jul_qty03],[jul_po01],[jul_po02] " & vbCrLf & _
            "       , [agt_qty01],[agt_qty02],[agt_qty03],[agt_po01],[agt_po02] " & vbCrLf & _
            "       , [sep_qty01],[sep_qty02],[sep_qty03],[sep_po01],[sep_po02] " & vbCrLf & _
            "       , [okt_qty01],[okt_qty02],[okt_qty03],[okt_po01],[okt_po02] " & vbCrLf & _
            "       , [nov_qty01],[nov_qty02],[nov_qty03],[nov_po01],[nov_po02] " & vbCrLf & _
            "       , [des_qty01],[des_qty02],[des_qty03],[des_po01],[des_po02] " & vbCrLf & _
            "       , created_date, created_by " & vbCrLf & _
            "   ) " & vbCrLf & _
            "OUTPUT INSERTED.ID " & vbCrLf & _
            "VALUES " & vbCrLf & _
            "   ( " & vbCrLf & _
            "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf & _
            "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf & _
            "       , " & QVal(Me._jan_qty01) & "," & QVal(Me._jan_qty02) & "," & QVal(Me._jan_qty03) & "," & QVal(Me._jan_po01) & "," & QVal(Me._jan_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._feb_qty01) & "," & QVal(Me._feb_qty02) & "," & QVal(Me._feb_qty03) & "," & QVal(Me._feb_po01) & "," & QVal(Me._feb_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._mar_qty01) & "," & QVal(Me._mar_qty02) & "," & QVal(Me._mar_qty03) & "," & QVal(Me._mar_po01) & "," & QVal(Me._mar_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._apr_qty01) & "," & QVal(Me._apr_qty02) & "," & QVal(Me._apr_qty03) & "," & QVal(Me._apr_po01) & "," & QVal(Me._apr_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._mei_qty01) & "," & QVal(Me._mei_qty02) & "," & QVal(Me._mei_qty03) & "," & QVal(Me._mei_po01) & "," & QVal(Me._mei_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._jun_qty01) & "," & QVal(Me._jun_qty02) & "," & QVal(Me._jun_qty03) & "," & QVal(Me._jun_po01) & "," & QVal(Me._jun_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._jul_qty01) & "," & QVal(Me._jul_qty02) & "," & QVal(Me._jul_qty03) & "," & QVal(Me._jul_po01) & "," & QVal(Me._jul_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._agt_qty01) & "," & QVal(Me._agt_qty02) & "," & QVal(Me._agt_qty03) & "," & QVal(Me._agt_po01) & "," & QVal(Me._agt_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._sep_qty01) & "," & QVal(Me._sep_qty02) & "," & QVal(Me._sep_qty03) & "," & QVal(Me._sep_po01) & "," & QVal(Me._sep_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._okt_qty01) & "," & QVal(Me._okt_qty02) & "," & QVal(Me._okt_qty03) & "," & QVal(Me._okt_po01) & "," & QVal(Me._okt_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._nov_qty01) & "," & QVal(Me._nov_qty02) & "," & QVal(Me._nov_qty03) & "," & QVal(Me._nov_po01) & "," & QVal(Me._nov_po02) & " " & vbCrLf & _
            "       , " & QVal(Me._des_qty01) & "," & QVal(Me._des_qty02) & "," & QVal(Me._des_qty03) & "," & QVal(Me._des_po01) & "," & QVal(Me._des_po02) & " " & vbCrLf & _
            "       , GETDATE() " & vbCrLf & _
            "       , " & QVal(gh_Common.Username) & " " & vbCrLf & _
            "   )"
            'Dim li_Row = GetDataTableByCommand(query)
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._id = Trim(.Item("ID") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim revisi As Integer
            If Me._revisi = 0 Then
                revisi = 1
            ElseIf Me._revisi = 1 Then
                revisi = 2
            Else
                revisi = 2
            End If


            Dim query As String = "UPDATE Forecast " & vbCrLf & _
            "   SET [tahun] = " & QVal(Me._tahun) & " " & vbCrLf & _
            "      ,[custid] = " & QVal(Me._custid) & " " & vbCrLf & _
            "      ,[customer] = " & QVal(Me._customer) & " " & vbCrLf & _
            "      ,[invtid] = " & QVal(Me._invtid) & " " & vbCrLf & _
            "      ,[descr] = " & QVal(Me._descr) & " " & vbCrLf & _
            "      ,[partno] = " & QVal(Me._partno) & " " & vbCrLf & _
            "      ,[model] = " & QVal(Me._model) & " " & vbCrLf & _
            "      ,[oe_re] = " & QVal(_oe_re) & " " & vbCrLf & _
            "      ,[in_sub] = " & QVal(Me._in_sub) & " " & vbCrLf & _
            "      ,[site] = " & QVal(Me._site) & " " & vbCrLf & _
            "      ,[jan_qty01] = " & QVal(Me._jan_qty01) & " " & vbCrLf & _
            "      ,[jan_qty02] = " & QVal(Me._jan_qty02) & " " & vbCrLf & _
            "      ,[jan_qty03] = " & QVal(Me._jan_qty03) & " " & vbCrLf & _
            "      ,[feb_qty01] = " & QVal(Me._feb_qty01) & " " & vbCrLf & _
            "      ,[feb_qty02] = " & QVal(Me._feb_qty02) & " " & vbCrLf & _
            "      ,[feb_qty03] = " & QVal(Me._feb_qty03) & " " & vbCrLf & _
            "      ,[mar_qty01] = " & QVal(Me._mar_qty01) & " " & vbCrLf & _
            "      ,[mar_qty02] = " & QVal(Me._mar_qty02) & " " & vbCrLf & _
            "      ,[mar_qty03] = " & QVal(Me._mar_qty03) & " " & vbCrLf & _
            "      ,[apr_qty01] = " & QVal(Me._apr_qty01) & " " & vbCrLf & _
            "      ,[apr_qty02] = " & QVal(Me._apr_qty02) & " " & vbCrLf & _
            "      ,[apr_qty03] = " & QVal(Me._apr_qty03) & " " & vbCrLf & _
            "      ,[mei_qty01] = " & QVal(Me._mei_qty01) & " " & vbCrLf & _
            "      ,[mei_qty02] = " & QVal(Me._mei_qty02) & " " & vbCrLf & _
            "      ,[mei_qty03] = " & QVal(Me._mei_qty03) & " " & vbCrLf & _
            "      ,[jun_qty01] = " & QVal(Me._jun_qty01) & " " & vbCrLf & _
            "      ,[jun_qty02] = " & QVal(Me._jun_qty02) & " " & vbCrLf & _
            "      ,[jun_qty03] = " & QVal(Me._jun_qty03) & " " & vbCrLf & _
            "      ,[jul_qty01] = " & QVal(Me._jul_qty01) & " " & vbCrLf & _
            "      ,[jul_qty02] = " & QVal(Me._jul_qty02) & " " & vbCrLf & _
            "      ,[jul_qty03] = " & QVal(Me._jul_qty03) & " " & vbCrLf & _
            "      ,[agt_qty01] = " & QVal(Me._agt_qty01) & " " & vbCrLf & _
            "      ,[agt_qty02] = " & QVal(Me._agt_qty02) & " " & vbCrLf & _
            "      ,[agt_qty03] = " & QVal(Me._agt_qty03) & " " & vbCrLf & _
            "      ,[sep_qty01] = " & QVal(Me._sep_qty01) & " " & vbCrLf & _
            "      ,[sep_qty02] = " & QVal(Me._sep_qty02) & " " & vbCrLf & _
            "      ,[sep_qty03] = " & QVal(Me._sep_qty03) & " " & vbCrLf & _
            "      ,[okt_qty01] = " & QVal(Me._okt_qty01) & " " & vbCrLf & _
            "      ,[okt_qty02] = " & QVal(Me._okt_qty02) & " " & vbCrLf & _
            "      ,[okt_qty03] = " & QVal(Me._okt_qty03) & " " & vbCrLf & _
            "      ,[nov_qty01] = " & QVal(Me._nov_qty01) & " " & vbCrLf & _
            "      ,[nov_qty02] = " & QVal(Me._nov_qty02) & " " & vbCrLf & _
            "      ,[nov_qty03] = " & QVal(Me._nov_qty03) & " " & vbCrLf & _
            "      ,[des_qty01] = " & QVal(Me._des_qty01) & " " & vbCrLf & _
            "      ,[des_qty02] = " & QVal(Me._des_qty02) & " " & vbCrLf & _
            "      ,[jan_po01] = " & QVal(Me._jan_po01) & " " & vbCrLf & _
            "      ,[jan_po02] = " & QVal(Me._jan_po02) & " " & vbCrLf & _
            "      ,[feb_po01] = " & QVal(Me._feb_po01) & " " & vbCrLf & _
            "      ,[feb_po02] = " & QVal(Me._feb_po02) & " " & vbCrLf & _
            "      ,[mar_po01] = " & QVal(Me._mar_po01) & " " & vbCrLf & _
            "      ,[mar_po02] = " & QVal(Me._mar_po02) & " " & vbCrLf & _
            "      ,[apr_po01] = " & QVal(Me._apr_po01) & " " & vbCrLf & _
            "      ,[apr_po02] = " & QVal(Me._apr_po02) & " " & vbCrLf & _
            "      ,[mei_po01] = " & QVal(Me._mei_po01) & " " & vbCrLf & _
            "      ,[mei_po02] = " & QVal(Me._mei_po02) & " " & vbCrLf & _
            "      ,[jun_po01] = " & QVal(Me._jun_po01) & " " & vbCrLf & _
            "      ,[jun_po02] = " & QVal(Me._jun_po02) & " " & vbCrLf & _
            "      ,[jul_po01] = " & QVal(Me._jul_po01) & " " & vbCrLf & _
            "      ,[jul_po02] = " & QVal(Me._jul_po02) & " " & vbCrLf & _
            "      ,[agt_po01] = " & QVal(Me._agt_po01) & " " & vbCrLf & _
            "      ,[agt_po02] = " & QVal(Me._agt_po02) & " " & vbCrLf & _
            "      ,[sep_po01] = " & QVal(Me._sep_po01) & " " & vbCrLf & _
            "      ,[sep_po02] = " & QVal(Me._sep_po02) & " " & vbCrLf & _
            "      ,[okt_po01] = " & QVal(Me._okt_po01) & " " & vbCrLf & _
            "      ,[okt_po02] = " & QVal(Me._okt_po02) & " " & vbCrLf & _
            "      ,[nov_po01] = " & QVal(Me._nov_po01) & " " & vbCrLf & _
            "      ,[nov_po02] = " & QVal(Me._nov_po02) & " " & vbCrLf & _
            "      ,[des_po01] = " & QVal(Me._des_po01) & " " & vbCrLf & _
            "      ,[des_po02] = " & QVal(Me._des_po02) & " " & vbCrLf & _
            "      ,[update_date] = GETDATE() " & vbCrLf & _
            "      ,[updated_by] = " & QVal(gh_Common.Username) & " " & vbCrLf & _
            "   OUTPUT INSERTED.ID " & vbCrLf & _
            "   WHERE [id] = " & QVal(Me._id) & " "
            'Dim li_Row = ExecQuery(query)
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._id = Trim(.Item("ID") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM Forecast " & vbCrLf & _
            "WHERE id = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Delete_byTahun()
        Try
            Dim query As String = "DELETE FROM Forecast " & vbCrLf &
            "WHERE tahun = " & QVal(Me._tahun) & " AND partno= " & QVal(Me._partno) & " AND invtid = " & QVal(Me._invtid) & " AND custid = " & QVal(Me._custid) & ""
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete_All()
        Try
            Dim query As String = "DELETE FROM Forecast"
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteByTahun()
        Try
            Dim query As String = "DELETE FROM Forecast " & vbCrLf &
            "WHERE tahun = " & QVal(Me._tahun) & ""
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function IsDataExist() As Boolean
        Dim IsExist As Boolean = False
        Try
            Dim que As String =
                "SELECT * FROM Forecast WHERE tahun = " & QVal(Me._tahun) & " AND partno= " & QVal(Me._partno) & " AND invtid = " & QVal(Me._invtid) & " AND custid = " & QVal(Me._custid) & ""
            Dim dtExist As New DataTable
            dtExist = MainModul.GetDataTableByCommand(que)
            If dtExist.Rows.Count > 0 Then
                IsExist = True
            Else
                IsExist = False
            End If
        Catch ex As Exception
            IsExist = False
            Throw
        End Try
        Return IsExist
    End Function
#End Region
End Class

