Imports System.Data
Imports System.Data.SqlClient

Public Class Cls_cmdm
    Dim query As String = String.Empty

    Dim pilih As String = String.Empty

    Private _vrno As String
    Public Property vrno() As String
        Get
            Return _vrno
        End Get
        Set(ByVal value As String)
            _vrno = value
        End Set
    End Property

    Private _bankid As String
    Public Property bankid() As String
        Get
            Return _bankid
        End Get
        Set(ByVal value As String)
            _bankid = value
        End Set
    End Property

    Private _bankname As String
    Public Property bankname() As String
        Get
            Return _bankname
        End Get
        Set(ByVal value As String)
            _bankname = value
        End Set
    End Property

    Private _VendID As String
    Public Property VendID() As String
        Get
            Return _VendID
        End Get
        Set(ByVal value As String)
            _VendID = value
        End Set
    End Property

    Private _Vendname As String
    Public Property vendname() As String
        Get
            Return _Vendname
        End Get
        Set(ByVal value As String)
            _Vendname = value
        End Set
    End Property

    Private _tgl As Date
    Public Property tgl() As Date
        Get
            Return _tgl
        End Get
        Set(ByVal value As Date)
            _tgl = value
        End Set
    End Property

    Private _ket As String
    Public Property ket() As String
        Get
            Return _ket
        End Get
        Set(ByVal value As String)
            _ket = value
        End Set
    End Property

    Private _curyid As String
    Public Property curyid() As String
        Get
            Return _curyid
        End Get
        Set(ByVal value As String)
            _curyid = value
        End Set
    End Property

    Private _batch As String
    Public Property batch() As String
        Get
            Return _curyid
        End Get
        Set(ByVal value As String)
            _batch = value
        End Set
    End Property

    Private _noinvoice As String
    Public Property noinvoice() As String
        Get
            Return _noinvoice
        End Get
        Set(ByVal value As String)
            _noinvoice = value
        End Set
    End Property

    Private _totalcmdm As String
    Public Property totalcmdm() As String
        Get
            Return _totalcmdm
        End Get
        Set(ByVal value As String)
            _totalcmdm = value
        End Set
    End Property

    ''Private _pilih As Boolean
    'Public Property pilih() As Boolean
    '    Get
    '        Return _totalcmdm
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _pilih = value
    '    End Set
    'End Property

    Public Sub insertdata()
        Try
            query = "INSERT INTO Payment_Header1 (vrno,bankid,bankname,vendorid,vendorname,tgl,ket,curyid,batch,no_invoice,total_cmdm) " & _
                        "VALUES ('" & _vrno & "'" & _
                           ",'" & _bankid & "'" & _
                           ",'" & _bankname & "'" & _
                           ",'" & _VendID & "'" & _
                           ",'" & _Vendname & "'" & _
                           ",'" & _tgl & "'" & _
                           ",'" & _ket & "'" & _
                           ",'" & _curyid & "'" & _
                           ",'" & _batch & "'" & _
                           ",'" & _noinvoice & "'" & _
                           ",'" & _totalcmdm & "'"
            MainModul.ExecQuery_Solomon(query)

            '' query = "update apdoc set user3=1 where InvcNbr in (select no_invoice from fp_detail) "
            ''  mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Function Insertdata2() As DataTable
        Try
            query = "INSERT INTO Payment_CMDM (vrno,bankid,bankname,vendorid,vendorname,tgl,ket,curyid,batch,no_invoice,total_cmdm,pilih) " & _
                        "VALUES ('" & _vrno & "'" & _
                           ",'" & _bankid & "'" & _
                           ",'" & _bankname & "'" & _
                           ",'" & _VendID & "'" & _
                           ",'" & _Vendname & "'" & _
                           ",'" & _tgl & "'" & _
                           ",'" & _ket & "'" & _
                           ",'" & _curyid & "'" & _
                           ",'" & _batch & "'" & _
                           ",'" & _noinvoice & "'" & _
                           ",'" & _totalcmdm & "'" & _
                           ",'" & pilih & "') "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getalldatacmdm() As DataTable
        Try
            query = "select vrno,bankname,vendorname,tgl,ket,curyid,batch,no_invoice,total_cmdm,pilih from payment_cmdm"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getalldatacmdm1() As DataTable
        vrno = "" 'Frm_cmdm._vrno.Text
        bankname = "" ' Frm_cmdm._BankName.Text
        vendname = "" ' Frm_cmdm._Vend_Name.Text
        tgl = "" ' Frm_cmdm._Tgl.Text
        ket = "" ' Frm_cmdm._ket.Text
        curyid = "" ' Frm_cmdm._curyid.Text
        batch = "" ' Frm_cmdm._batch.Text
        noinvoice = "" ' Frm_cmdm._no_invoice.Text
        totalcmdm = "" ' Frm_cmdm._total_cmdm.Text
        Try
            query = "select vrno,bankname,vendorname,tgl,ket,curyid,batch,no_invoice,total_cmdm from payment_cmdm " &
                    "where vrno='" & vrno & "' and bankname='" & bankname & "' and vendorname='" & vendname & "' and no_invoice='" & noinvoice & "' and batch='" & batch & "' "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function datadt2() As DataTable
        vendname = "" ' Frm_Payment._Vend_Name.Text
        Try
            'query = "select vrno,tgl,ket,curyid,batch,no_invoice,total_cmdm from payment_cmdm " & _
            '        "where vendorname='" & vendname & "' "
            query = "select Ardoc.docdate as tgl,Ardoc.CuryId,Ardoc.batnbr as Bacth,Ardoc.refnbr as no_invoice,Batch.CuryCrTot as total_cmdm from Ardoc inner join CashAcct  on Ardoc.BankAcct=CashAcct.BankAcct  inner join Batch on Ardoc.BatNbr=Batch.BatNbr  inner join customer  on Ardoc.custid=customer.custid inner join vendor on customer.user5=vendor.vendid where Batch.user1='' " & _
                   "and vendor.name='" & vendname & "' "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function update1() As DataTable
        vrno = "" ' Frm_Payment._VocNo.Text
        batch = "" ' Frm_Payment.DataGridView2.SelectedRows(0).Cells(2).Value.ToString
        Try
            'query = "select vrno,tgl,ket,curyid,batch,no_invoice,total_cmdm from payment_cmdm " & _
            '        "where vendorname='" & vendname & "' "
            query = "update batch set user2='" & vrno & "' where batnbr='" & batch & "' "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   


    'Public Function update2() As DataTable
    '    vrno = Frm_Payment._VocNo.Text
    '    batch = Frm_Payment.DataGridView2.SelectedRows(0).Cells(2).Value.ToString
    '    Try
    '        'query = "select vrno,tgl,ket,curyid,batch,no_invoice,total_cmdm from payment_cmdm " & _
    '        '        "where vendorname='" & vendname & "' "
    '        query = "update batch set user5='" & vrno & "' where batnbr='" & batch & "' "
    '        Dim dt As DataTable = New DataTable
    '        dt = mdlmain.GetDataTableByCommand(query)
    '        Return dt
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function

    Public Function dt2() As DataTable
        'vendname = Frm_Payment._Vend_Name.Text
        'vrno = Frm_Payment._VocNo.Text
        'Try
        '    query = "select tgl,ket,curyid,batch,no_invoice,total_cmdm from payment_cmdm " & _
        '            "where vendorname='" & vendname & "' and vrno='" & vrno & "' "
        '    Dim dt As DataTable = New DataTable
        '    dt = mdlmain.GetDataTableByCommand(query)
        '    Return dt
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function

    Public Function updatedt2() As DataTable
        vrno = "" ' Frm_Payment._VocNo.Text
        noinvoice = "" ' Frm_Payment.DataGridView2.SelectedRows(0).Cells(4).Value.ToString
        pilih = "" ' Frm_Payment.DataGridView2.SelectedRows(0).Cells(6).Value.ToString
        Try
            query = "update payment_cmdm set vrno='" & vrno & "', pilih='" & pilih & "' " & _
                    "where vendorname='" & vendname & "' and no_invoice='" & noinvoice & "' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
