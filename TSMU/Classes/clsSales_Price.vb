Imports System.Collections.ObjectModel
Public Class clsSales_Price
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

    Private _jan_harga01 As Single
    Public Property jan_harga01() As Single
        Get
            Return _jan_harga01
        End Get
        Set(ByVal value As Single)
            _jan_harga01 = value
        End Set
    End Property

    Private _jan_harga02 As Single
    Public Property jan_harga02() As Single
        Get
            Return _jan_harga02
        End Get
        Set(ByVal value As Single)
            _jan_harga02 = value
        End Set
    End Property

    Private _jan_harga03 As Single
    Public Property jan_harga03() As Single
        Get
            Return _jan_harga03
        End Get
        Set(ByVal value As Single)
            _jan_harga03 = value
        End Set
    End Property

    Private _jan_harga04 As Single
    Public Property jan_harga04() As Single
        Get
            Return _jan_harga04
        End Get
        Set(ByVal value As Single)
            _jan_harga04 = value
        End Set
    End Property

    Private _jan_harga05 As Single
    Public Property jan_harga05() As Single
        Get
            Return _jan_harga05
        End Get
        Set(ByVal value As Single)
            _jan_harga05 = value
        End Set
    End Property

    Private _feb_harga01 As Single
    Public Property feb_harga01() As Single
        Get
            Return _feb_harga01
        End Get
        Set(ByVal value As Single)
            _feb_harga01 = value
        End Set
    End Property

    Private _feb_harga02 As Single
    Public Property feb_harga02() As Single
        Get
            Return _feb_harga02
        End Get
        Set(ByVal value As Single)
            _feb_harga02 = value
        End Set
    End Property

    Private _feb_harga03 As Single
    Public Property feb_harga03() As Single
        Get
            Return _feb_harga03
        End Get
        Set(ByVal value As Single)
            _feb_harga03 = value
        End Set
    End Property

    Private _feb_harga04 As Single
    Public Property feb_harga04() As Single
        Get
            Return _feb_harga04
        End Get
        Set(ByVal value As Single)
            _feb_harga04 = value
        End Set
    End Property

    Private _feb_harga05 As Single
    Public Property feb_harga05() As Single
        Get
            Return _feb_harga05
        End Get
        Set(ByVal value As Single)
            _feb_harga05 = value
        End Set
    End Property

    Private _mar_harga01 As Single
    Public Property mar_harga01() As Single
        Get
            Return _mar_harga01
        End Get
        Set(ByVal value As Single)
            _mar_harga01 = value
        End Set
    End Property

    Private _mar_harga02 As Single
    Public Property mar_harga02() As Single
        Get
            Return _mar_harga02
        End Get
        Set(ByVal value As Single)
            _mar_harga02 = value
        End Set
    End Property

    Private _mar_harga03 As Single
    Public Property mar_harga03() As Single
        Get
            Return _mar_harga03
        End Get
        Set(ByVal value As Single)
            _mar_harga03 = value
        End Set
    End Property


    Private _mar_harga04 As Single
    Public Property mar_harga04() As Single
        Get
            Return _mar_harga04
        End Get
        Set(ByVal value As Single)
            _mar_harga04 = value
        End Set
    End Property

    Private _mar_harga05 As Single
    Public Property mar_harga05() As Single
        Get
            Return _mar_harga05
        End Get
        Set(ByVal value As Single)
            _mar_harga05 = value
        End Set
    End Property

    Private _apr_harga01 As Single
    Public Property apr_harga01() As Single
        Get
            Return _apr_harga01
        End Get
        Set(ByVal value As Single)
            _apr_harga01 = value
        End Set
    End Property

    Private _apr_harga02 As Single
    Public Property apr_harga02() As Single
        Get
            Return _apr_harga02
        End Get
        Set(ByVal value As Single)
            _apr_harga02 = value
        End Set
    End Property

    Private _apr_harga03 As Single
    Public Property apr_harga03() As Single
        Get
            Return _apr_harga03
        End Get
        Set(ByVal value As Single)
            _apr_harga03 = value
        End Set
    End Property

    Private _apr_harga04 As Single
    Public Property apr_harga04() As Single
        Get
            Return _apr_harga04
        End Get
        Set(ByVal value As Single)
            _apr_harga04 = value
        End Set
    End Property

    Private _apr_harga05 As Single
    Public Property apr_harga05() As Single
        Get
            Return _apr_harga05
        End Get
        Set(ByVal value As Single)
            _apr_harga05 = value
        End Set
    End Property

    Private _mei_harga01 As Single
    Public Property mei_harga01() As Single
        Get
            Return _mei_harga01
        End Get
        Set(ByVal value As Single)
            _mei_harga01 = value
        End Set
    End Property

    Private _mei_harga02 As Single
    Public Property mei_harga02() As Single
        Get
            Return _mei_harga02
        End Get
        Set(ByVal value As Single)
            _mei_harga02 = value
        End Set
    End Property

    Private _mei_harga03 As Single
    Public Property mei_harga03() As Single
        Get
            Return _mei_harga03
        End Get
        Set(ByVal value As Single)
            _mei_harga03 = value
        End Set
    End Property

    Private _mei_harga04 As Single
    Public Property mei_harga04() As Single
        Get
            Return _mei_harga04
        End Get
        Set(ByVal value As Single)
            _mei_harga04 = value
        End Set
    End Property

    Private _mei_harga05 As Single
    Public Property mei_harga05() As Single
        Get
            Return _mei_harga05
        End Get
        Set(ByVal value As Single)
            _mei_harga05 = value
        End Set
    End Property

    Private _jun_harga01 As Single
    Public Property jun_harga01() As Single
        Get
            Return _jun_harga01
        End Get
        Set(ByVal value As Single)
            _jun_harga01 = value
        End Set
    End Property

    Private _jun_harga02 As Single
    Public Property jun_harga02() As Single
        Get
            Return _jun_harga02
        End Get
        Set(ByVal value As Single)
            _jun_harga02 = value
        End Set
    End Property

    Private _jun_harga03 As Single
    Public Property jun_harga03() As Single
        Get
            Return _jun_harga03
        End Get
        Set(ByVal value As Single)
            _jun_harga03 = value
        End Set
    End Property

    Private _jun_harga04 As Single
    Public Property jun_harga04() As Single
        Get
            Return _jun_harga04
        End Get
        Set(ByVal value As Single)
            _jun_harga04 = value
        End Set
    End Property

    Private _jun_harga05 As Single
    Public Property jun_harga05() As Single
        Get
            Return _jun_harga05
        End Get
        Set(ByVal value As Single)
            _jun_harga05 = value
        End Set
    End Property

    Private _jul_harga01 As Single
    Public Property jul_harga01() As Single
        Get
            Return _jul_harga01
        End Get
        Set(ByVal value As Single)
            _jul_harga01 = value
        End Set
    End Property

    Private _jul_harga02 As Single
    Public Property jul_harga02() As Single
        Get
            Return _jul_harga02
        End Get
        Set(ByVal value As Single)
            _jul_harga02 = value
        End Set
    End Property

    Private _jul_harga03 As Single
    Public Property jul_harga03() As Single
        Get
            Return _jul_harga03
        End Get
        Set(ByVal value As Single)
            _jul_harga03 = value
        End Set
    End Property

    Private _jul_harga04 As Single
    Public Property jul_harga04() As Single
        Get
            Return _jul_harga04
        End Get
        Set(ByVal value As Single)
            _jul_harga04 = value
        End Set
    End Property

    Private _jul_harga05 As Single
    Public Property jul_harga05() As Single
        Get
            Return _jul_harga05
        End Get
        Set(ByVal value As Single)
            _jul_harga05 = value
        End Set
    End Property

    Private _agt_harga01 As Single
    Public Property agt_harga01() As Single
        Get
            Return _agt_harga01
        End Get
        Set(ByVal value As Single)
            _agt_harga01 = value
        End Set
    End Property

    Private _agt_harga02 As Single
    Public Property agt_harga02() As Single
        Get
            Return _agt_harga02
        End Get
        Set(ByVal value As Single)
            _agt_harga02 = value
        End Set
    End Property

    Private _agt_harga03 As Single
    Public Property agt_harga03() As Single
        Get
            Return _agt_harga03
        End Get
        Set(ByVal value As Single)
            _agt_harga03 = value
        End Set
    End Property

    Private _agt_harga04 As Single
    Public Property agt_harga04() As Single
        Get
            Return _agt_harga04
        End Get
        Set(ByVal value As Single)
            _agt_harga04 = value
        End Set
    End Property

    Private _agt_harga05 As Single
    Public Property agt_harga05() As Single
        Get
            Return _agt_harga05
        End Get
        Set(ByVal value As Single)
            _agt_harga05 = value
        End Set
    End Property

    Private _sep_harga01 As Single
    Public Property sep_harga01() As Single
        Get
            Return _sep_harga01
        End Get
        Set(ByVal value As Single)
            _sep_harga01 = value
        End Set
    End Property

    Private _sep_harga02 As Single
    Public Property sep_harga02() As Single
        Get
            Return _sep_harga02
        End Get
        Set(ByVal value As Single)
            _sep_harga02 = value
        End Set
    End Property

    Private _sep_harga03 As Single
    Public Property sep_harga03() As Single
        Get
            Return _sep_harga03
        End Get
        Set(ByVal value As Single)
            _sep_harga03 = value
        End Set
    End Property

    Private _sep_harga04 As Single
    Public Property sep_harga04() As Single
        Get
            Return _sep_harga04
        End Get
        Set(ByVal value As Single)
            _sep_harga04 = value
        End Set
    End Property

    Private _sep_harga05 As Single
    Public Property sep_harga05() As Single
        Get
            Return _sep_harga05
        End Get
        Set(ByVal value As Single)
            _sep_harga05 = value
        End Set
    End Property

    Private _okt_harga01 As Single
    Public Property okt_harga01() As Single
        Get
            Return _okt_harga01
        End Get
        Set(ByVal value As Single)
            _okt_harga01 = value
        End Set
    End Property

    Private _okt_harga02 As Single
    Public Property okt_harga02() As Single
        Get
            Return _okt_harga02
        End Get
        Set(ByVal value As Single)
            _okt_harga02 = value
        End Set
    End Property

    Private _okt_harga03 As Single
    Public Property okt_harga03() As Single
        Get
            Return _okt_harga03
        End Get
        Set(ByVal value As Single)
            _okt_harga03 = value
        End Set
    End Property

    Private _okt_harga04 As Single
    Public Property okt_harga04() As Single
        Get
            Return _okt_harga04
        End Get
        Set(ByVal value As Single)
            _okt_harga04 = value
        End Set
    End Property

    Private _okt_harga05 As Single
    Public Property okt_harga05() As Single
        Get
            Return _okt_harga05
        End Get
        Set(ByVal value As Single)
            _okt_harga05 = value
        End Set
    End Property

    Private _nov_harga01 As Single
    Public Property nov_harga01() As Single
        Get
            Return _nov_harga01
        End Get
        Set(ByVal value As Single)
            _nov_harga01 = value
        End Set
    End Property

    Private _nov_harga02 As Single
    Public Property nov_harga02() As Single
        Get
            Return _nov_harga02
        End Get
        Set(ByVal value As Single)
            _nov_harga02 = value
        End Set
    End Property

    Private _nov_harga03 As Single
    Public Property nov_harga03() As Single
        Get
            Return _nov_harga03
        End Get
        Set(ByVal value As Single)
            _nov_harga03 = value
        End Set
    End Property

    Private _nov_harga04 As Single
    Public Property nov_harga04() As Single
        Get
            Return _nov_harga04
        End Get
        Set(ByVal value As Single)
            _nov_harga04 = value
        End Set
    End Property

    Private _nov_harga05 As Single
    Public Property nov_harga05() As Single
        Get
            Return _nov_harga05
        End Get
        Set(ByVal value As Single)
            _nov_harga05 = value
        End Set
    End Property

    Private _des_harga01 As Single
    Public Property des_harga01() As Single
        Get
            Return _des_harga01
        End Get
        Set(ByVal value As Single)
            _des_harga01 = value
        End Set
    End Property

    Private _des_harga02 As Single
    Public Property des_harga02() As Single
        Get
            Return _des_harga02
        End Get
        Set(ByVal value As Single)
            _des_harga02 = value
        End Set
    End Property

    Private _des_harga03 As Single
    Public Property des_harga03() As Single
        Get
            Return _des_harga03
        End Get
        Set(ByVal value As Single)
            _des_harga03 = value
        End Set
    End Property

    Private _des_harga04 As Single
    Public Property des_harga04() As Single
        Get
            Return _des_harga04
        End Get
        Set(ByVal value As Single)
            _des_harga04 = value
        End Set
    End Property

    Private _des_harga05 As Single
    Public Property des_harga05() As Single
        Get
            Return _des_harga05
        End Get
        Set(ByVal value As Single)
            _des_harga05 = value
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
            Dim ls_SP As String = "sp_sales_price_GetDataGrid1"
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
            Dim query As String = "sp_sales_price_getDatabyID"

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

                    Me._jan_harga01 = Trim(.Item("jan_harga01") & "")
                    Me._jan_harga02 = Trim(.Item("jan_harga02") & "")
                    Me._jan_harga03 = Trim(.Item("jan_harga03") & "")
                    Me._jan_harga04 = Trim(.Item("jan_harga04") & "")
                    Me._jan_harga05 = Trim(.Item("jan_harga05") & "")
                    'Me._jan_harga03 = Trim(.Item("jan_harga03") & "")

                    Me._feb_harga01 = Trim(.Item("feb_harga01") & "")
                    Me._feb_harga02 = Trim(.Item("feb_harga02") & "")
                    Me._feb_harga03 = Trim(.Item("feb_harga03") & "")
                    Me._feb_harga04 = Trim(.Item("feb_harga04") & "")
                    Me._feb_harga05 = Trim(.Item("feb_harga05") & "")
                    'Me._feb_harga03 = Trim(.Item("feb_harga03") & "")

                    Me._mar_harga01 = Trim(.Item("mar_harga01") & "")
                    Me._mar_harga02 = Trim(.Item("mar_harga02") & "")
                    Me._mar_harga03 = Trim(.Item("mar_harga03") & "")
                    Me._mar_harga04 = Trim(.Item("mar_harga04") & "")
                    Me._mar_harga05 = Trim(.Item("mar_harga05") & "")
                    'Me._mar_harga03 = Trim(.Item("mar_harga03") & "")

                    Me._apr_harga01 = Trim(.Item("apr_harga01") & "")
                    Me._apr_harga02 = Trim(.Item("apr_harga02") & "")
                    Me._apr_harga03 = Trim(.Item("apr_harga03") & "")
                    Me._apr_harga04 = Trim(.Item("apr_harga04") & "")
                    Me._apr_harga05 = Trim(.Item("apr_harga05") & "")
                    'Me._apr_harga03 = Trim(.Item("apr_harga03") & "")

                    Me._mei_harga01 = Trim(.Item("mei_harga01") & "")
                    Me._mei_harga02 = Trim(.Item("mei_harga02") & "")
                    Me._mei_harga03 = Trim(.Item("mei_harga03") & "")
                    Me._mei_harga04 = Trim(.Item("mei_harga04") & "")
                    Me._mei_harga05 = Trim(.Item("mei_harga05") & "")
                    'Me._mei_harga03 = Trim(.Item("mei_harga03") & "")

                    Me._jun_harga01 = Trim(.Item("jun_harga01") & "")
                    Me._jun_harga02 = Trim(.Item("jun_harga02") & "")
                    Me._jun_harga03 = Trim(.Item("jun_harga03") & "")
                    Me._jun_harga04 = Trim(.Item("jun_harga04") & "")
                    Me._jun_harga05 = Trim(.Item("jun_harga05") & "")
                    'Me._jun_harga03 = Trim(.Item("jun_harga03") & "")

                    Me._jul_harga01 = Trim(.Item("jul_harga01") & "")
                    Me._jul_harga02 = Trim(.Item("jul_harga02") & "")
                    Me._jul_harga03 = Trim(.Item("jul_harga03") & "")
                    Me._jul_harga04 = Trim(.Item("jul_harga04") & "")
                    Me._jul_harga05 = Trim(.Item("jul_harga05") & "")
                    'Me._jul_harga03 = Trim(.Item("jul_harga03") & "")

                    Me._agt_harga01 = Trim(.Item("agt_harga01") & "")
                    Me._agt_harga02 = Trim(.Item("agt_harga02") & "")
                    Me._agt_harga03 = Trim(.Item("agt_harga03") & "")
                    Me._agt_harga04 = Trim(.Item("agt_harga04") & "")
                    Me._agt_harga05 = Trim(.Item("agt_harga05") & "")
                    'Me._agt_harga03 = Trim(.Item("agt_harga03") & "")

                    Me._sep_harga01 = Trim(.Item("sep_harga01") & "")
                    Me._sep_harga02 = Trim(.Item("sep_harga02") & "")
                    Me._sep_harga03 = Trim(.Item("sep_harga03") & "")
                    Me._sep_harga04 = Trim(.Item("sep_harga04") & "")
                    Me._sep_harga05 = Trim(.Item("sep_harga05") & "")
                    'Me._sep_harga03 = Trim(.Item("sep_harga03") & "")

                    Me._okt_harga01 = Trim(.Item("okt_harga01") & "")
                    Me._okt_harga02 = Trim(.Item("okt_harga02") & "")
                    Me._okt_harga03 = Trim(.Item("okt_harga03") & "")
                    Me._okt_harga04 = Trim(.Item("okt_harga04") & "")
                    Me._okt_harga05 = Trim(.Item("okt_harga05") & "")
                    'Me._okt_harga03 = Trim(.Item("okt_harga03") & "")

                    Me._nov_harga01 = Trim(.Item("nov_harga01") & "")
                    Me._nov_harga02 = Trim(.Item("nov_harga02") & "")
                    Me._nov_harga03 = Trim(.Item("nov_harga03") & "")
                    Me._nov_harga04 = Trim(.Item("nov_harga04") & "")
                    Me._nov_harga05 = Trim(.Item("nov_harga05") & "")
                    'Me._nov_harga03 = Trim(.Item("nov_harga03") & "")

                    Me._des_harga01 = Trim(.Item("des_harga01") & "")
                    Me._des_harga02 = Trim(.Item("des_harga02") & "")
                    Me._des_harga03 = Trim(.Item("des_harga03") & "")
                    Me._des_harga04 = Trim(.Item("des_harga04") & "")
                    Me._des_harga05 = Trim(.Item("des_harga05") & "")
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
            Dim ls_SP As String = "Select top 1 tahun,partno,invtid from harga where tahun = " & QVal(Me._tahun) & " and invtid= " & QVal(Me._invtid) & " and partno = " & QVal(Me._partno) & " and custid = " & QVal(Me._custid) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTelahDigunakan) &
                "[" & Me._partno & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ValidateUpdate() As Boolean
        Dim IsExist As Boolean = False
        'If Me._custid = "" OrElse Me._partno = "" OrElse Me._tahun = "" OrElse Me._invtid = "" Then
        '    IsExist = False
        '    'Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        'End If
        Try
            Dim ls_SP As String = "Select * from harga where tahun = " & QVal(Me._tahun) & " and invtid= " & QVal(Me._invtid) & " and partno = " & QVal(Me._partno) & " and custid = " & QVal(Me._custid) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                IsExist = True
            End If
        Catch ex As Exception
            IsExist = False
            Throw
        End Try
        Return IsExist
    End Function
#Region "CRUD"
    Public Sub Insert()

        Try
            Dim query As String = "INSERT INTO harga " & vbCrLf & _
            "   ( " & vbCrLf & _
            "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf & _
            "       , [jan_harga01],[jan_harga02],[jan_harga03],[jan_harga04],[jan_harga05] " & vbCrLf & _
            "       , [feb_harga01],[feb_harga02],[feb_harga03],[feb_harga04],[feb_harga05] " & vbCrLf & _
            "       , [mar_harga01],[mar_harga02],[mar_harga03],[mar_harga04],[mar_harga05] " & vbCrLf & _
            "       , [apr_harga01],[apr_harga02],[apr_harga03],[apr_harga04],[apr_harga05] " & vbCrLf & _
            "       , [mei_harga01],[mei_harga02],[mei_harga03],[mei_harga04],[mei_harga05] " & vbCrLf & _
            "       , [jun_harga01],[jun_harga02],[jun_harga03],[jun_harga04],[jun_harga05] " & vbCrLf & _
            "       , [jul_harga01],[jul_harga02],[jul_harga03],[jul_harga04],[jul_harga05] " & vbCrLf & _
            "       , [agt_harga01],[agt_harga02],[agt_harga03],[agt_harga04],[agt_harga05] " & vbCrLf & _
            "       , [sep_harga01],[sep_harga02],[sep_harga03],[sep_harga04],[sep_harga05] " & vbCrLf & _
            "       , [okt_harga01],[okt_harga02],[okt_harga03],[okt_harga04],[okt_harga05] " & vbCrLf & _
            "       , [nov_harga01],[nov_harga02],[nov_harga03],[nov_harga04],[nov_harga05] " & vbCrLf & _
            "       , [des_harga01],[des_harga02],[des_harga03],[des_harga04],[des_harga05] " & vbCrLf & _
            "       , created_date, created_by " & vbCrLf & _
            "   ) " & vbCrLf & _
            "OUTPUT INSERTED.ID " & vbCrLf & _
            "VALUES " & vbCrLf & _
            "   ( " & vbCrLf & _
            "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf & _
            "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf & _
            "       , " & QVal(Me._jan_harga01) & "," & QVal(Me._jan_harga02) & "," & QVal(Me._jan_harga03) & "," & QVal(Me._jan_harga04) & "," & QVal(Me._jan_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._feb_harga01) & "," & QVal(Me._feb_harga02) & "," & QVal(Me._feb_harga03) & "," & QVal(Me._feb_harga04) & "," & QVal(Me._feb_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._mar_harga01) & "," & QVal(Me._mar_harga02) & "," & QVal(Me._mar_harga03) & "," & QVal(Me._mar_harga04) & "," & QVal(Me._mar_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._apr_harga01) & "," & QVal(Me._apr_harga02) & "," & QVal(Me._apr_harga03) & "," & QVal(Me._apr_harga04) & "," & QVal(Me._apr_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._mei_harga01) & "," & QVal(Me._mei_harga02) & "," & QVal(Me._mei_harga03) & "," & QVal(Me._mei_harga04) & "," & QVal(Me._mei_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._jun_harga01) & "," & QVal(Me._jun_harga02) & "," & QVal(Me._jun_harga03) & "," & QVal(Me._jun_harga04) & "," & QVal(Me._jun_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._jul_harga01) & "," & QVal(Me._jul_harga02) & "," & QVal(Me._jul_harga03) & "," & QVal(Me._jul_harga04) & "," & QVal(Me._jul_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._agt_harga01) & "," & QVal(Me._agt_harga02) & "," & QVal(Me._agt_harga03) & "," & QVal(Me._agt_harga04) & "," & QVal(Me._agt_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._sep_harga01) & "," & QVal(Me._sep_harga02) & "," & QVal(Me._sep_harga03) & "," & QVal(Me._sep_harga04) & "," & QVal(Me._sep_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._okt_harga01) & "," & QVal(Me._okt_harga02) & "," & QVal(Me._okt_harga03) & "," & QVal(Me._okt_harga04) & "," & QVal(Me._okt_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._nov_harga01) & "," & QVal(Me._nov_harga02) & "," & QVal(Me._nov_harga03) & "," & QVal(Me._nov_harga04) & "," & QVal(Me._nov_harga05) & " " & vbCrLf & _
            "       , " & QVal(Me._des_harga01) & "," & QVal(Me._des_harga02) & "," & QVal(Me._des_harga03) & "," & QVal(Me._des_harga04) & "," & QVal(Me._des_harga05) & " " & vbCrLf & _
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


            Dim query As String = "UPDATE harga " & vbCrLf & _
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
            "      ,[jan_harga01] = " & QVal(Me._jan_harga01) & " " & vbCrLf & _
            "      ,[jan_harga02] = " & QVal(Me._jan_harga02) & " " & vbCrLf & _
            "      ,[jan_harga03] = " & QVal(Me._jan_harga03) & " " & vbCrLf & _
            "      ,[jan_harga04] = " & QVal(Me._jan_harga04) & " " & vbCrLf & _
            "      ,[jan_harga05] = " & QVal(Me._jan_harga05) & " " & vbCrLf & _
            "      ,[feb_harga01] = " & QVal(Me._feb_harga01) & " " & vbCrLf & _
            "      ,[feb_harga02] = " & QVal(Me._feb_harga02) & " " & vbCrLf & _
            "      ,[feb_harga03] = " & QVal(Me._feb_harga03) & " " & vbCrLf & _
            "      ,[feb_harga04] = " & QVal(Me._feb_harga04) & " " & vbCrLf & _
            "      ,[feb_harga05] = " & QVal(Me._feb_harga05) & " " & vbCrLf & _
            "      ,[mar_harga01] = " & QVal(Me._mar_harga01) & " " & vbCrLf & _
            "      ,[mar_harga02] = " & QVal(Me._mar_harga02) & " " & vbCrLf & _
            "      ,[mar_harga03] = " & QVal(Me._mar_harga03) & " " & vbCrLf & _
            "      ,[mar_harga04] = " & QVal(Me._mar_harga04) & " " & vbCrLf & _
            "      ,[mar_harga05] = " & QVal(Me._mar_harga05) & " " & vbCrLf & _
            "      ,[apr_harga01] = " & QVal(Me._apr_harga01) & " " & vbCrLf & _
            "      ,[apr_harga02] = " & QVal(Me._apr_harga02) & " " & vbCrLf & _
            "      ,[apr_harga03] = " & QVal(Me._apr_harga03) & " " & vbCrLf & _
            "      ,[apr_harga04] = " & QVal(Me._apr_harga04) & " " & vbCrLf & _
            "      ,[apr_harga05] = " & QVal(Me._apr_harga05) & " " & vbCrLf & _
            "      ,[mei_harga01] = " & QVal(Me._mei_harga01) & " " & vbCrLf & _
            "      ,[mei_harga02] = " & QVal(Me._mei_harga02) & " " & vbCrLf & _
            "      ,[mei_harga03] = " & QVal(Me._mei_harga03) & " " & vbCrLf & _
            "      ,[mei_harga04] = " & QVal(Me._mei_harga04) & " " & vbCrLf & _
            "      ,[mei_harga05] = " & QVal(Me._mei_harga05) & " " & vbCrLf & _
            "      ,[jun_harga01] = " & QVal(Me._jun_harga01) & " " & vbCrLf & _
            "      ,[jun_harga02] = " & QVal(Me._jun_harga02) & " " & vbCrLf & _
            "      ,[jun_harga03] = " & QVal(Me._jun_harga03) & " " & vbCrLf & _
            "      ,[jun_harga04] = " & QVal(Me._jun_harga04) & " " & vbCrLf & _
            "      ,[jun_harga05] = " & QVal(Me._jun_harga05) & " " & vbCrLf & _
            "      ,[jul_harga01] = " & QVal(Me._jul_harga01) & " " & vbCrLf & _
            "      ,[jul_harga02] = " & QVal(Me._jul_harga02) & " " & vbCrLf & _
            "      ,[jul_harga03] = " & QVal(Me._jul_harga03) & " " & vbCrLf & _
            "      ,[jul_harga04] = " & QVal(Me._jul_harga04) & " " & vbCrLf & _
            "      ,[jul_harga05] = " & QVal(Me._jul_harga05) & " " & vbCrLf & _
            "      ,[agt_harga01] = " & QVal(Me._agt_harga01) & " " & vbCrLf & _
            "      ,[agt_harga02] = " & QVal(Me._agt_harga02) & " " & vbCrLf & _
            "      ,[agt_harga03] = " & QVal(Me._agt_harga03) & " " & vbCrLf & _
            "      ,[agt_harga04] = " & QVal(Me._agt_harga04) & " " & vbCrLf & _
            "      ,[agt_harga05] = " & QVal(Me._agt_harga05) & " " & vbCrLf & _
            "      ,[sep_harga01] = " & QVal(Me._sep_harga01) & " " & vbCrLf & _
            "      ,[sep_harga02] = " & QVal(Me._sep_harga02) & " " & vbCrLf & _
            "      ,[sep_harga03] = " & QVal(Me._sep_harga03) & " " & vbCrLf & _
            "      ,[sep_harga04] = " & QVal(Me._sep_harga04) & " " & vbCrLf & _
            "      ,[sep_harga05] = " & QVal(Me._sep_harga05) & " " & vbCrLf & _
            "      ,[okt_harga01] = " & QVal(Me._okt_harga01) & " " & vbCrLf & _
            "      ,[okt_harga02] = " & QVal(Me._okt_harga02) & " " & vbCrLf & _
            "      ,[okt_harga03] = " & QVal(Me._okt_harga03) & " " & vbCrLf & _
            "      ,[okt_harga04] = " & QVal(Me._okt_harga04) & " " & vbCrLf & _
            "      ,[okt_harga05] = " & QVal(Me._okt_harga05) & " " & vbCrLf & _
            "      ,[nov_harga01] = " & QVal(Me._nov_harga01) & " " & vbCrLf & _
            "      ,[nov_harga02] = " & QVal(Me._nov_harga02) & " " & vbCrLf & _
            "      ,[nov_harga03] = " & QVal(Me._nov_harga03) & " " & vbCrLf & _
            "      ,[nov_harga04] = " & QVal(Me._nov_harga04) & " " & vbCrLf & _
            "      ,[nov_harga05] = " & QVal(Me._nov_harga05) & " " & vbCrLf & _
            "      ,[des_harga01] = " & QVal(Me._des_harga01) & " " & vbCrLf & _
            "      ,[des_harga02] = " & QVal(Me._des_harga02) & " " & vbCrLf & _
            "      ,[des_harga04] = " & QVal(Me._des_harga04) & " " & vbCrLf & _
            "      ,[des_harga05] = " & QVal(Me._des_harga05) & " " & vbCrLf & _
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
            Dim query As String = "DELETE FROM harga " & vbCrLf &
            "WHERE id = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Delete_byTahun()
        Try
            Dim query As String = "DELETE FROM harga " & vbCrLf &
            "WHERE tahun = " & QVal(Me._tahun) & " AND partno= " & QVal(Me._partno) & " AND invtid = " & QVal(Me._invtid) & " AND custid = " & QVal(Me._custid) & ""
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Update_New(Bulan As String)
        Dim Query As String = String.Empty
        Dim Harga As Double = 0
        Dim Harga_jan As Double = 0
        Dim Harga_feb As Double = 0
        Dim Harga_mar As Double = 0
        Dim Harga_apr As Double = 0
        Dim Harga_mei As Double = 0
        Dim Harga_jun As Double = 0
        Dim Harga_jul As Double = 0
        Dim Harga_agt As Double = 0
        Dim Harga_sep As Double = 0
        Dim Harga_okt As Double = 0
        Dim Harga_nov As Double = 0
        Dim Harga_des As Double = 0
        'Harga = GetLastPriceOfMonth(Bulan)
        'Exit Sub
        Try
            If Bulan.ToLower = "januari" Then

                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[jan_harga01] = " & QVal(Me._jan_harga01) & "
                             ,[jan_harga02] =  " & QVal(Me._jan_harga02) & "
                             ,[jan_harga03] =  " & QVal(Me._jan_harga03) & "
                             ,[jan_harga04] =  " & QVal(Me._jan_harga04) & "
                             ,[jan_harga05] = " & QVal(Me._jan_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "
                MainModul.ExecQuery(Query)

                Harga_jan = GetLastPriceOfJanuary()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [feb_harga01] = " & QVal(Harga_jan) & "
                             ,[mar_harga01] = " & QVal(Harga_jan) & "
                             ,[apr_harga01] = " & QVal(Harga_jan) & "
                             ,[mei_harga01] = " & QVal(Harga_jan) & "
                             ,[jun_harga01] = " & QVal(Harga_jan) & "
                             ,[jul_harga01] = " & QVal(Harga_jan) & "
                             ,[agt_harga01] = " & QVal(Harga_jan) & "
                             ,[sep_harga01] = " & QVal(Harga_jan) & "
                             ,[okt_harga01] = " & QVal(Harga_jan) & "
                             ,[nov_harga01] = " & QVal(Harga_jan) & "
                             ,[des_harga01] = " & QVal(Harga_jan) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "februari" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[feb_harga01] = " & QVal(Me._feb_harga01) & "
                             ,[feb_harga02] = " & QVal(Me._feb_harga02) & "
                             ,[feb_harga03] = " & QVal(Me._feb_harga03) & "
                             ,[feb_harga04] = " & QVal(Me._feb_harga04) & "
                             ,[feb_harga05] = " & QVal(Me._feb_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "
                MainModul.ExecQuery(Query)

                Harga_feb = GetLastPriceOfFebruari()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [mar_harga01] = " & QVal(Harga_feb) & "
                             ,[apr_harga01] = " & QVal(Harga_feb) & "
                             ,[mei_harga01] = " & QVal(Harga_feb) & "
                             ,[jun_harga01] = " & QVal(Harga_feb) & "
                             ,[jul_harga01] = " & QVal(Harga_feb) & "
                             ,[agt_harga01] = " & QVal(Harga_feb) & "
                             ,[sep_harga01] = " & QVal(Harga_feb) & "
                             ,[okt_harga01] = " & QVal(Harga_feb) & "
                             ,[nov_harga01] = " & QVal(Harga_feb) & "
                             ,[des_harga01] = " & QVal(Harga_feb) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "maret" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[mar_harga01] = " & QVal(Me._mar_harga01) & "
                             ,[mar_harga02] = " & QVal(Me._mar_harga02) & "
                             ,[mar_harga03] = " & QVal(Me._mar_harga03) & "
                             ,[mar_harga04] = " & QVal(Me._mar_harga04) & "
                             ,[mar_harga05] = " & QVal(Me._mar_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_mar = GetLastPriceOfMaret()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [apr_harga01] = " & QVal(Harga_mar) & "
                             ,[mei_harga01] = " & QVal(Harga_mar) & "
                             ,[jun_harga01] = " & QVal(Harga_mar) & "
                             ,[jul_harga01] = " & QVal(Harga_mar) & "
                             ,[agt_harga01] = " & QVal(Harga_mar) & "
                             ,[sep_harga01] = " & QVal(Harga_mar) & "
                             ,[okt_harga01] = " & QVal(Harga_mar) & "
                             ,[nov_harga01] = " & QVal(Harga_mar) & "
                             ,[des_harga01] = " & QVal(Harga_jan) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "april" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[apr_harga01] = " & QVal(Me._apr_harga01) & "
                             ,[apr_harga02] = " & QVal(Me._apr_harga02) & "
                             ,[apr_harga03] = " & QVal(Me._apr_harga03) & "
                             ,[apr_harga04] = " & QVal(Me._apr_harga04) & "
                             ,[apr_harga05] = " & QVal(Me._apr_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_apr = GetLastPriceOfApril()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [mei_harga01] = " & QVal(Harga_apr) & "
                             ,[jun_harga01] = " & QVal(Harga_apr) & "
                             ,[jul_harga01] = " & QVal(Harga_apr) & "
                             ,[agt_harga01] = " & QVal(Harga_apr) & "
                             ,[sep_harga01] = " & QVal(Harga_apr) & "
                             ,[okt_harga01] = " & QVal(Harga_apr) & "
                             ,[nov_harga01] = " & QVal(Harga_apr) & "
                             ,[des_harga01] = " & QVal(Harga_apr) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "mei" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[mei_harga01] = " & QVal(Me._mei_harga01) & "
                             ,[mei_harga02] = " & QVal(Me._mei_harga02) & "
                             ,[mei_harga03] = " & QVal(Me._mei_harga03) & "
                             ,[mei_harga04] = " & QVal(Me._mei_harga04) & "
                             ,[mei_harga05] = " & QVal(Me._mei_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_mei = GetLastPriceOfMei()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [jun_harga01] = " & QVal(Harga_mei) & "
                             ,[jul_harga01] = " & QVal(Harga_mei) & "
                             ,[agt_harga01] = " & QVal(Harga_mei) & "
                             ,[sep_harga01] = " & QVal(Harga_mei) & "
                             ,[okt_harga01] = " & QVal(Harga_mei) & "
                             ,[nov_harga01] = " & QVal(Harga_mei) & "
                             ,[des_harga01] = " & QVal(Harga_mei) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "juni" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[jun_harga01] = " & QVal(Me._jun_harga01) & "
                             ,[jun_harga02] = " & QVal(Me._jun_harga02) & "
                             ,[jun_harga03] = " & QVal(Me._jun_harga03) & "
                             ,[jun_harga04] = " & QVal(Me._jun_harga04) & "
                             ,[jun_harga05] = " & QVal(Me._jun_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_jun = GetLastPriceOfJun()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [jul_harga01] = " & QVal(Harga_jun) & "
                             ,[agt_harga01] = " & QVal(Harga_jun) & "
                             ,[sep_harga01] = " & QVal(Harga_jun) & "
                             ,[okt_harga01] = " & QVal(Harga_jun) & "
                             ,[nov_harga01] = " & QVal(Harga_jun) & "
                             ,[des_harga01] = " & QVal(Harga_jun) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "juli" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[jul_harga01] = " & QVal(Me._jul_harga01) & "
                             ,[jul_harga02] = " & QVal(Me._jul_harga02) & "
                             ,[jul_harga03] = " & QVal(Me._jul_harga03) & "
                             ,[jul_harga04] = " & QVal(Me._jul_harga04) & "
                             ,[jul_harga05] = " & QVal(Me._jul_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_jul = GetLastPriceOfJul()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [agt_harga01] = " & QVal(Harga_jul) & "
                             ,[sep_harga01] = " & QVal(Harga_jul) & "
                             ,[okt_harga01] = " & QVal(Harga_jul) & "
                             ,[nov_harga01] = " & QVal(Harga_jul) & "
                             ,[des_harga01] = " & QVal(Harga_jul) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)


            ElseIf Bulan.ToLower = "agt" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[agt_harga01] = " & QVal(Me._agt_harga01) & "
                             ,[agt_harga02] = " & QVal(Me._agt_harga02) & "
                             ,[agt_harga03] = " & QVal(Me._agt_harga03) & "
                             ,[agt_harga04] = " & QVal(Me._agt_harga04) & "
                             ,[agt_harga05] = " & QVal(Me._agt_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_agt = GetLastPriceOfAgustus()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [sep_harga01] = " & QVal(Harga_agt) & "
                             ,[okt_harga01] = " & QVal(Harga_agt) & "
                             ,[nov_harga01] = " & QVal(Harga_agt) & "
                             ,[des_harga01] = " & QVal(Harga_agt) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "september" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[sep_harga01] = " & QVal(Me._sep_harga01) & "
                             ,[sep_harga02] = " & QVal(Me._sep_harga02) & "
                             ,[sep_harga03] = " & QVal(Me._sep_harga03) & "
                             ,[sep_harga04] = " & QVal(Me._sep_harga04) & "
                             ,[sep_harga05] = " & QVal(Me._sep_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_sep = GetLastPriceOfSeptember()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [okt_harga01] = " & QVal(Harga_sep) & "
                             ,[nov_harga01] = " & QVal(Harga_sep) & "
                             ,[des_harga01] = " & QVal(Harga_sep) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "oktober" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[okt_harga01] = " & QVal(Me._okt_harga01) & "
                             ,[okt_harga02] = " & QVal(Me._okt_harga02) & "
                             ,[okt_harga03] = " & QVal(Me._okt_harga03) & "
                             ,[okt_harga04] = " & QVal(Me._okt_harga04) & "
                             ,[okt_harga05] = " & QVal(Me._okt_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_okt = GetLastPriceOfOktober()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [nov_harga01] = " & QVal(Harga_okt) & "
                             ,[des_harga01] = " & QVal(Harga_okt) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "november" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[nov_harga01] = " & QVal(Me._nov_harga01) & "
                             ,[nov_harga02] = " & QVal(Me._nov_harga02) & "
                             ,[nov_harga03] = " & QVal(Me._nov_harga03) & "
                             ,[nov_harga04] = " & QVal(Me._nov_harga04) & "
                             ,[nov_harga05] = " & QVal(Me._nov_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_nov = GetLastPriceOfNovember()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [des_harga01] = " & QVal(Harga_nov) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)

            ElseIf Bulan.ToLower = "desember" Then
                Query = "UPDATE harga
                        SET [tahun] = " & QVal(Me._tahun) & "
                             ,[custid] = " & QVal(Me._custid) & "
                             ,[customer] = " & QVal(Me._customer) & "
                             ,[invtid] = " & QVal(Me._invtid) & "
                             ,[descr] = " & QVal(Me._descr) & "
                             ,[partno] = " & QVal(Me._partno) & "
                             ,[model] = " & QVal(Me._model) & "
                             ,[oe_re] = " & QVal(_oe_re) & "
                             ,[in_sub] = " & QVal(Me._in_sub) & "
                             ,[site] = " & QVal(Me._site) & "
                             ,[des_harga01] = " & QVal(Me._des_harga01) & "
                             ,[des_harga02] = " & QVal(Me._des_harga02) & "
                             ,[des_harga03] = " & QVal(Me._des_harga03) & "
                             ,[des_harga04] = " & QVal(Me._des_harga04) & "
                             ,[des_harga05] = " & QVal(Me._des_harga05) & "
                             ,[update_date] = GETDATE() 
                             ,[updated_by] = " & QVal(gh_Common.Username) & "
                        where Tahun = " & QVal(Me._tahun) & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " "

                MainModul.ExecQuery(Query)

                Harga_des = GetLastPriceOfDesember()

                Dim Query1 As String =
                    "
                        UPDATE harga
                        SET  [jan_harga01] = " & QVal(Harga_des) & "
                        where Tahun = " & QVal(Me._tahun) + 1 & " And InvtId = " & QVal(Me._invtid) & " And PartNo = " & QVal(Me._partno) & " And custid = " & QVal(Me._custid) & " 
                    "

                MainModul.ExecQuery(Query1)
            End If

            'Exit Sub
            'If Query <> "" Then
            '    Dim dtTable As New DataTable
            '    dtTable = MainModul.GetDataTableByCommand(Query)
            '    If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '        With dtTable.Rows(0)
            '            Me._id = Trim(.Item("ID") & "")
            '        End With
            '    End If
            'End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Insert_New(Bulan As String)
        Dim Query As String = String.Empty
        Try

            If Bulan.ToLower = "januari" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [jan_harga01],[jan_harga02],[jan_harga03],[jan_harga04],[jan_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._jan_harga01) & "," & QVal(Me._jan_harga02) & "," & QVal(Me._jan_harga03) & "," & QVal(Me._jan_harga04) & "," & QVal(Me._jan_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "februari" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [feb_harga01],[feb_harga02],[feb_harga03],[feb_harga04],[feb_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._feb_harga01) & "," & QVal(Me._feb_harga02) & "," & QVal(Me._feb_harga03) & "," & QVal(Me._feb_harga04) & "," & QVal(Me._feb_harga05) & "  " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "maret" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [mar_harga01],[mar_harga02],[mar_harga03],[mar_harga04],[mar_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._mar_harga01) & "," & QVal(Me._mar_harga02) & "," & QVal(Me._mar_harga03) & "," & QVal(Me._mar_harga04) & "," & QVal(Me._mar_harga05) & "  " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "april" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [apr_harga01],[apr_harga02],[apr_harga03],[apr_harga04],[apr_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._apr_harga01) & "," & QVal(Me._apr_harga02) & "," & QVal(Me._apr_harga03) & "," & QVal(Me._apr_harga04) & "," & QVal(Me._apr_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "mei" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [mei_harga01],[mei_harga02],[mei_harga03],[mei_harga04],[mei_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._mei_harga01) & "," & QVal(Me._mei_harga02) & "," & QVal(Me._mei_harga03) & "," & QVal(Me._mei_harga04) & "," & QVal(Me._mei_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "juni" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [jun_harga01],[jun_harga02],[jun_harga03],[jun_harga04],[jun_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._jun_harga01) & "," & QVal(Me._jun_harga02) & "," & QVal(Me._jun_harga03) & "," & QVal(Me._jun_harga04) & "," & QVal(Me._jun_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "juli" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [jul_harga01],[jul_harga02],[jul_harga03],[jul_harga04],[jul_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._jul_harga01) & "," & QVal(Me._jul_harga02) & "," & QVal(Me._jul_harga03) & "," & QVal(Me._jul_harga04) & "," & QVal(Me._jul_harga05) & "  " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "agustus" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [agt_harga01],[agt_harga02],[agt_harga03],[agt_harga04],[agt_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._agt_harga01) & "," & QVal(Me._agt_harga02) & "," & QVal(Me._agt_harga03) & "," & QVal(Me._agt_harga04) & "," & QVal(Me._agt_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "september" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [sep_harga01],[sep_harga02],[sep_harga03],[sep_harga04],[sep_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._sep_harga01) & "," & QVal(Me._sep_harga02) & "," & QVal(Me._sep_harga03) & "," & QVal(Me._sep_harga04) & "," & QVal(Me._sep_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "oktober" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [okt_harga01],[okt_harga02],[okt_harga03],[okt_harga04],[okt_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._okt_harga01) & "," & QVal(Me._okt_harga02) & "," & QVal(Me._okt_harga03) & "," & QVal(Me._okt_harga04) & "," & QVal(Me._okt_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "november" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [nov_harga01],[nov_harga02],[nov_harga03],[nov_harga04],[nov_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._nov_harga01) & "," & QVal(Me._nov_harga02) & "," & QVal(Me._nov_harga03) & "," & QVal(Me._nov_harga04) & "," & QVal(Me._nov_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            ElseIf Bulan.ToLower = "desember" Then
                Query = "INSERT INTO harga " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       [tahun],[custid],[customer],[invtid],[descr],[partno],[model],[oe_re],[in_sub],[site] " & vbCrLf &
                    "       , [des_harga01],[des_harga02],[des_harga03],[des_harga04],[des_harga05]" & vbCrLf &
                    "       , created_date, created_by " & vbCrLf &
                    "   ) " & vbCrLf &
                    "OUTPUT INSERTED.ID " & vbCrLf &
                    "VALUES " & vbCrLf &
                    "   ( " & vbCrLf &
                    "       " & QVal(Me._tahun) & "," & QVal(Me._custid) & "," & QVal(Me._customer) & "," & QVal(Me._invtid) & "," & QVal(Me._descr) & "," & QVal(Me._partno) & " " & vbCrLf &
                    "       , " & QVal(Me._model) & "," & QVal(Me._oe_re) & "," & QVal(Me._in_sub) & "," & QVal(Me._site) & " " & vbCrLf &
                    "       , " & QVal(Me._des_harga01) & "," & QVal(Me._des_harga02) & "," & QVal(Me._des_harga03) & "," & QVal(Me._des_harga04) & "," & QVal(Me._des_harga05) & " " & vbCrLf &
                    "       , GETDATE() " & vbCrLf &
                    "       , " & QVal(gh_Common.Username) & " " & vbCrLf &
                    "   )"
            End If
            Exit Sub
            If Query <> "" Then
                Dim dtTable As New DataTable
                dtTable = MainModul.GetDataTableByCommand(Query)
                If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                    With dtTable.Rows(0)
                        Me._id = Trim(.Item("ID") & "")
                    End With
                End If
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetLastPriceOfJanuary() As Double
        Dim HargaJan As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_jan =
	                    case 
	                    WHEN jan_harga01!=0 and jan_harga02=0  and jan_harga03=0  and jan_harga04=0  and jan_harga05=0 THEN jan_harga01  
	                    WHEN jan_harga01!=0 and jan_harga02!=0 and jan_harga03=0  and jan_harga04=0  and jan_harga05=0 THEN jan_harga02  
	                    WHEN jan_harga01!=0 and jan_harga02!=0 and jan_harga03!=0 and jan_harga04=0  and jan_harga05=0 THEN jan_harga03  
	                    WHEN jan_harga01!=0 and jan_harga02!=0 and jan_harga03!=0 and jan_harga04!=0 and jan_harga05=0 THEN jan_harga04 
	                    WHEN jan_harga01!=0 and jan_harga02!=0 and jan_harga03!=0 and jan_harga04!=0 and jan_harga05!=0 THEN jan_harga05 
	                    WHEN jan_harga01=0  and jan_harga02!=0 and jan_harga03=0  and jan_harga04=0  and jan_harga05=0 THEN jan_harga02  
	                    WHEN jan_harga01=0  and jan_harga03!=0 and jan_harga04=0  and jan_harga05=0 THEN jan_harga03  
	                    WHEN jan_harga01=0  and jan_harga04!=0 and jan_harga05=0 THEN jan_harga04  
	                    WHEN jan_harga01=0  and jan_harga05!=0 THEN jan_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                HargaJan = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return HargaJan
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfFebruari() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_feb =
	                    case 
	                    WHEN feb_harga01!=0 and feb_harga02=0  and feb_harga03=0  and feb_harga04=0  and feb_harga05=0 THEN feb_harga01  
	                    WHEN feb_harga01!=0 and feb_harga02!=0 and feb_harga03=0  and feb_harga04=0  and feb_harga05=0 THEN feb_harga02  
	                    WHEN feb_harga01!=0 and feb_harga02!=0 and feb_harga03!=0 and feb_harga04=0  and feb_harga05=0 THEN feb_harga03  
	                    WHEN feb_harga01!=0 and feb_harga02!=0 and feb_harga03!=0 and feb_harga04!=0 and feb_harga05=0 THEN feb_harga04 
	                    WHEN feb_harga01!=0 and feb_harga02!=0 and feb_harga03!=0 and feb_harga04!=0 and feb_harga05!=0 THEN feb_harga05 
	                    WHEN feb_harga01=0  and feb_harga02!=0 and feb_harga03=0  and feb_harga04=0  and feb_harga05=0 THEN feb_harga02  
	                    WHEN feb_harga01=0  and feb_harga03!=0 and feb_harga04=0  and feb_harga05=0 THEN feb_harga03  
	                    WHEN feb_harga01=0  and feb_harga04!=0 and feb_harga05=0 THEN feb_harga04  
	                    WHEN feb_harga01=0  and feb_harga05!=0 THEN feb_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfMaret() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_mar =
	                    case 
	                    WHEN mar_harga01!=0 and mar_harga02=0  and mar_harga03=0  and mar_harga04=0  and mar_harga05=0 THEN mar_harga01  
	                    WHEN mar_harga01!=0 and mar_harga02!=0 and mar_harga03=0  and mar_harga04=0  and mar_harga05=0 THEN mar_harga02  
	                    WHEN mar_harga01!=0 and mar_harga02!=0 and mar_harga03!=0 and mar_harga04=0  and mar_harga05=0 THEN mar_harga03  
	                    WHEN mar_harga01!=0 and mar_harga02!=0 and mar_harga03!=0 and mar_harga04!=0 and mar_harga05=0 THEN mar_harga04 
	                    WHEN mar_harga01!=0 and mar_harga02!=0 and mar_harga03!=0 and mar_harga04!=0 and mar_harga05!=0 THEN mar_harga05 
	                    WHEN mar_harga01=0  and mar_harga02!=0 and mar_harga03=0  and mar_harga04=0  and mar_harga05=0 THEN mar_harga02  
	                    WHEN mar_harga01=0  and mar_harga03!=0 and mar_harga04=0  and mar_harga05=0 THEN mar_harga03  
	                    WHEN mar_harga01=0  and mar_harga04!=0 and mar_harga05=0 THEN mar_harga04  
	                    WHEN mar_harga01=0  and mar_harga05!=0 THEN mar_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfApril() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_apr =
	                    case 
	                    WHEN apr_harga01!=0 and apr_harga02=0  and apr_harga03=0  and apr_harga04=0  and apr_harga05=0 THEN apr_harga01  
	                    WHEN apr_harga01!=0 and apr_harga02!=0 and apr_harga03=0  and apr_harga04=0  and apr_harga05=0 THEN apr_harga02  
	                    WHEN apr_harga01!=0 and apr_harga02!=0 and apr_harga03!=0 and apr_harga04=0  and apr_harga05=0 THEN apr_harga03  
	                    WHEN apr_harga01!=0 and apr_harga02!=0 and apr_harga03!=0 and apr_harga04!=0 and apr_harga05=0 THEN apr_harga04 
	                    WHEN apr_harga01!=0 and apr_harga02!=0 and apr_harga03!=0 and apr_harga04!=0 and apr_harga05!=0 THEN apr_harga05 
	                    WHEN apr_harga01=0  and apr_harga02!=0 and apr_harga03=0  and apr_harga04=0  and apr_harga05=0 THEN apr_harga02  
	                    WHEN apr_harga01=0  and apr_harga03!=0 and apr_harga04=0  and apr_harga05=0 THEN apr_harga03  
	                    WHEN apr_harga01=0  and apr_harga04!=0 and apr_harga05=0 THEN apr_harga04  
	                    WHEN apr_harga01=0  and apr_harga05!=0 THEN apr_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfMei() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_mei =
	                    case 
	                    WHEN mei_harga01!=0 and mei_harga02=0  and mei_harga03=0  and mei_harga04=0  and mei_harga05=0 THEN mei_harga01  
	                    WHEN mei_harga01!=0 and mei_harga02!=0 and mei_harga03=0  and mei_harga04=0  and mei_harga05=0 THEN mei_harga02  
	                    WHEN mei_harga01!=0 and mei_harga02!=0 and mei_harga03!=0 and mei_harga04=0  and mei_harga05=0 THEN mei_harga03  
	                    WHEN mei_harga01!=0 and mei_harga02!=0 and mei_harga03!=0 and mei_harga04!=0 and mei_harga05=0 THEN mei_harga04 
	                    WHEN mei_harga01!=0 and mei_harga02!=0 and mei_harga03!=0 and mei_harga04!=0 and mei_harga05!=0 THEN mei_harga05 
	                    WHEN mei_harga01=0  and mei_harga02!=0 and mei_harga03=0  and mei_harga04=0  and mei_harga05=0 THEN mei_harga02  
	                    WHEN mei_harga01=0  and mei_harga03!=0 and mei_harga04=0  and mei_harga05=0 THEN mei_harga03  
	                    WHEN mei_harga01=0  and mei_harga04!=0 and mei_harga05=0 THEN mei_harga04  
	                    WHEN mei_harga01=0  and mei_harga05!=0 THEN mei_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfJun() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_jun =
	                    case 
	                    WHEN jun_harga01!=0 and jun_harga02=0  and jun_harga03=0  and jun_harga04=0  and jun_harga05=0 THEN jun_harga01  
	                    WHEN jun_harga01!=0 and jun_harga02!=0 and jun_harga03=0  and jun_harga04=0  and jun_harga05=0 THEN jun_harga02  
	                    WHEN jun_harga01!=0 and jun_harga02!=0 and jun_harga03!=0 and jun_harga04=0  and jun_harga05=0 THEN jun_harga03  
	                    WHEN jun_harga01!=0 and jun_harga02!=0 and jun_harga03!=0 and jun_harga04!=0 and jun_harga05=0 THEN jun_harga04 
	                    WHEN jun_harga01!=0 and jun_harga02!=0 and jun_harga03!=0 and jun_harga04!=0 and jun_harga05!=0 THEN jun_harga05 
	                    WHEN jun_harga01=0  and jun_harga02!=0 and jun_harga03=0  and jun_harga04=0  and jun_harga05=0 THEN jun_harga02  
	                    WHEN jun_harga01=0  and jun_harga03!=0 and jun_harga04=0  and jun_harga05=0 THEN jun_harga03  
	                    WHEN jun_harga01=0  and jun_harga04!=0 and jun_harga05=0 THEN jun_harga04  
	                    WHEN jun_harga01=0  and jun_harga05!=0 THEN jun_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfJul() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_jul =
	                    case 
	                    WHEN jul_harga01!=0 and jul_harga02=0  and jul_harga03=0  and jul_harga04=0  and jul_harga05=0 THEN jul_harga01  
	                    WHEN jul_harga01!=0 and jul_harga02!=0 and jul_harga03=0  and jul_harga04=0  and jul_harga05=0 THEN jul_harga02  
	                    WHEN jul_harga01!=0 and jul_harga02!=0 and jul_harga03!=0 and jul_harga04=0  and jul_harga05=0 THEN jul_harga03  
	                    WHEN jul_harga01!=0 and jul_harga02!=0 and jul_harga03!=0 and jul_harga04!=0 and jul_harga05=0 THEN jul_harga04 
	                    WHEN jul_harga01!=0 and jul_harga02!=0 and jul_harga03!=0 and jul_harga04!=0 and jul_harga05!=0 THEN jul_harga05 
	                    WHEN jul_harga01=0  and jul_harga02!=0 and jul_harga03=0  and jul_harga04=0  and jul_harga05=0 THEN jul_harga02  
	                    WHEN jul_harga01=0  and jul_harga03!=0 and jul_harga04=0  and jul_harga05=0 THEN jul_harga03  
	                    WHEN jul_harga01=0  and jul_harga04!=0 and jul_harga05=0 THEN jul_harga04  
	                    WHEN jul_harga01=0  and jul_harga05!=0 THEN jul_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetLastPriceOfAgustus() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_agt =
	                    case 
	                    WHEN agt_harga01!=0 and agt_harga02=0  and agt_harga03=0  and agt_harga04=0  and agt_harga05=0 THEN agt_harga01  
	                    WHEN agt_harga01!=0 and agt_harga02!=0 and agt_harga03=0  and agt_harga04=0  and agt_harga05=0 THEN agt_harga02  
	                    WHEN agt_harga01!=0 and agt_harga02!=0 and agt_harga03!=0 and agt_harga04=0  and agt_harga05=0 THEN agt_harga03  
	                    WHEN agt_harga01!=0 and agt_harga02!=0 and agt_harga03!=0 and agt_harga04!=0 and agt_harga05=0 THEN agt_harga04 
	                    WHEN agt_harga01!=0 and agt_harga02!=0 and agt_harga03!=0 and agt_harga04!=0 and agt_harga05!=0 THEN agt_harga05 
	                    WHEN agt_harga01=0  and agt_harga02!=0 and agt_harga03=0  and agt_harga04=0  and agt_harga05=0 THEN agt_harga02  
	                    WHEN agt_harga01=0  and agt_harga03!=0 and agt_harga04=0  and agt_harga05=0 THEN agt_harga03  
	                    WHEN agt_harga01=0  and agt_harga04!=0 and agt_harga05=0 THEN agt_harga04  
	                    WHEN agt_harga01=0  and agt_harga05!=0 THEN agt_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfSeptember() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_sep =
	                    case 
	                    WHEN sep_harga01!=0 and sep_harga02=0  and sep_harga03=0  and sep_harga04=0  and sep_harga05=0 THEN sep_harga01  
	                    WHEN sep_harga01!=0 and sep_harga02!=0 and sep_harga03=0  and sep_harga04=0  and sep_harga05=0 THEN sep_harga02  
	                    WHEN sep_harga01!=0 and sep_harga02!=0 and sep_harga03!=0 and sep_harga04=0  and sep_harga05=0 THEN sep_harga03  
	                    WHEN sep_harga01!=0 and sep_harga02!=0 and sep_harga03!=0 and sep_harga04!=0 and sep_harga05=0 THEN sep_harga04 
	                    WHEN sep_harga01!=0 and sep_harga02!=0 and sep_harga03!=0 and sep_harga04!=0 and sep_harga05!=0 THEN sep_harga05 
	                    WHEN sep_harga01=0  and sep_harga02!=0 and sep_harga03=0  and sep_harga04=0  and sep_harga05=0 THEN sep_harga02  
	                    WHEN sep_harga01=0  and sep_harga03!=0 and sep_harga04=0  and sep_harga05=0 THEN sep_harga03  
	                    WHEN sep_harga01=0  and sep_harga04!=0 and sep_harga05=0 THEN sep_harga04  
	                    WHEN sep_harga01=0  and sep_harga05!=0 THEN sep_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetLastPriceOfOktober() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_okt =
	                    case 
	                    WHEN okt_harga01!=0 and okt_harga02=0  and okt_harga03=0  and okt_harga04=0  and okt_harga05=0 THEN okt_harga01  
	                    WHEN okt_harga01!=0 and okt_harga02!=0 and okt_harga03=0  and okt_harga04=0  and okt_harga05=0 THEN okt_harga02  
	                    WHEN okt_harga01!=0 and okt_harga02!=0 and okt_harga03!=0 and okt_harga04=0  and okt_harga05=0 THEN okt_harga03  
	                    WHEN okt_harga01!=0 and okt_harga02!=0 and okt_harga03!=0 and okt_harga04!=0 and okt_harga05=0 THEN okt_harga04 
	                    WHEN okt_harga01!=0 and okt_harga02!=0 and okt_harga03!=0 and okt_harga04!=0 and okt_harga05!=0 THEN okt_harga05 
	                    WHEN okt_harga01=0  and okt_harga02!=0 and okt_harga03=0  and okt_harga04=0  and okt_harga05=0 THEN okt_harga02  
	                    WHEN okt_harga01=0  and okt_harga03!=0 and okt_harga04=0  and okt_harga05=0 THEN okt_harga03  
	                    WHEN okt_harga01=0  and okt_harga04!=0 and okt_harga05=0 THEN okt_harga04  
	                    WHEN okt_harga01=0  and okt_harga05!=0 THEN okt_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfNovember() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_nov =
	                    case 
	                    WHEN nov_harga01!=0 and nov_harga02=0  and nov_harga03=0  and nov_harga04=0  and nov_harga05=0 THEN nov_harga01  
	                    WHEN nov_harga01!=0 and nov_harga02!=0 and nov_harga03=0  and nov_harga04=0  and nov_harga05=0 THEN nov_harga02  
	                    WHEN nov_harga01!=0 and nov_harga02!=0 and nov_harga03!=0 and nov_harga04=0  and nov_harga05=0 THEN nov_harga03  
	                    WHEN nov_harga01!=0 and nov_harga02!=0 and nov_harga03!=0 and nov_harga04!=0 and nov_harga05=0 THEN nov_harga04 
	                    WHEN nov_harga01!=0 and nov_harga02!=0 and nov_harga03!=0 and nov_harga04!=0 and nov_harga05!=0 THEN nov_harga05 
	                    WHEN nov_harga01=0  and nov_harga02!=0 and nov_harga03=0  and nov_harga04=0  and nov_harga05=0 THEN nov_harga02  
	                    WHEN nov_harga01=0  and nov_harga03!=0 and nov_harga04=0  and nov_harga05=0 THEN nov_harga03  
	                    WHEN nov_harga01=0  and nov_harga04!=0 and nov_harga05=0 THEN nov_harga04  
	                    WHEN nov_harga01=0  and nov_harga05!=0 THEN nov_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLastPriceOfDesember() As Double
        Dim Harga As Double = 0
        Dim sql As String = String.Empty
        Try
            sql =
                "
                    SELECT
                        Harga_des =
	                    case 
	                    WHEN des_harga01!=0 and des_harga02=0  and des_harga03=0  and des_harga04=0  and des_harga05=0 THEN des_harga01  
	                    WHEN des_harga01!=0 and des_harga02!=0 and des_harga03=0  and des_harga04=0  and des_harga05=0 THEN des_harga02  
	                    WHEN des_harga01!=0 and des_harga02!=0 and des_harga03!=0 and des_harga04=0  and des_harga05=0 THEN des_harga03  
	                    WHEN des_harga01!=0 and des_harga02!=0 and des_harga03!=0 and des_harga04!=0 and des_harga05=0 THEN des_harga04 
	                    WHEN des_harga01!=0 and des_harga02!=0 and des_harga03!=0 and des_harga04!=0 and des_harga05!=0 THEN des_harga05 
	                    WHEN des_harga01=0  and des_harga02!=0 and des_harga03=0  and des_harga04=0  and des_harga05=0 THEN des_harga02  
	                    WHEN des_harga01=0  and des_harga03!=0 and des_harga04=0  and des_harga05=0 THEN des_harga03  
	                    WHEN des_harga01=0  and des_harga04!=0 and des_harga05=0 THEN des_harga04  
	                    WHEN des_harga01=0  and des_harga05!=0 THEN des_harga05  
	                    ELSE 0
	                    end
                    FROM Harga
                    WHERE
                        tahun =  " & QVal(_tahun) & " AND
                        partno = " & QVal(_partno) & " AND
                        invtid = " & QVal(_invtid) & " AND
                        custid = " & QVal(_custid) & "
                "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Harga = Double.Parse(dt.Rows(0)(0).ToString())
            End If
            Return Harga
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class

