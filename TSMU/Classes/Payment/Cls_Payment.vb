Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_Payment
    Dim query As String = String.Empty
    Dim query1 As String = String.Empty
    Dim query2 As String = String.Empty
    Dim query3 As String = String.Empty

    Dim chek1 As String = String.Empty
    Dim chek2 As String = String.Empty
    Dim chek3 As String = String.Empty
    Dim chek4 As String = String.Empty
    ''Dim prosespay As String = String.Empty

    Private _txtcari As String
    Public Property txtcari() As String
        Get
            Return _txtcari
        End Get
        Set(ByVal value As String)
            _txtcari = value
        End Set
    End Property

    Private _cmbcari As String
    Public Property cmbcari() As String
        Get
            Return _cmbcari
        End Get
        Set(ByVal value As String)
            _cmbcari = value
        End Set
    End Property

    Private _Fp As String
    Public Property Fp() As String
        Get
            Return _Fp
        End Get
        Set(ByVal value As String)
            _Fp = value
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

    Private _tahun As String
    Public Property tahun() As String
        Get
            Return _tahun
        End Get
        Set(ByVal value As String)
            _tahun = value
        End Set
    End Property

    Private _bulan As String
    Public Property bulan() As String
        Get
            Return _bulan
        End Get
        Set(ByVal value As String)
            _bulan = value
        End Set
    End Property

    Private _voucno As String
    Public Property voucno() As String
        Get
            Return _voucno
        End Get
        Set(ByVal value As String)
            _voucno = value
        End Set
    End Property
    Private _invcnbr As String
    Public Property invcnbr() As String
        Get
            Return _invcnbr
        End Get
        Set(ByVal value As String)
            _invcnbr = value
        End Set
    End Property
    Private _tgl_fp As String
    Public Property tgl_fp() As DateTime
        Get
            Return _tgl_fp
        End Get
        Set(ByVal value As DateTime)
            _tgl_fp = value
        End Set
    End Property

    Private _Vend_Name As String
    Public Property Vend_Name() As String
        Get
            Return _Vend_Name
        End Get
        Set(ByVal value As String)
            _Vend_Name = value
        End Set
    End Property

    Private _jenis_jasa As String
    Public Property jenis_jasa() As String
        Get
            Return _jenis_jasa
        End Get
        Set(ByVal value As String)
            _jenis_jasa = value
        End Set
    End Property

    Private _BankID As String
    Public Property BankID() As String
        Get
            Return _BankID
        End Get
        Set(ByVal value As String)
            _BankID = value
        End Set
    End Property
    Private _CuryID As String
    Public Property CuryID() As String
        Get
            Return _CuryID
        End Get
        Set(ByVal value As String)
            _CuryID = value
        End Set
    End Property

    Private _npwp As String
    Public Property npwp() As String
        Get
            Return _npwp
        End Get
        Set(ByVal value As String)
            _npwp = value
        End Set
    End Property

    Private _nama_vendor As String
    Public Property nama_vendor() As String
        Get
            Return _nama_vendor
        End Get
        Set(ByVal value As String)
            _nama_vendor = value
        End Set
    End Property

    Private _BankName As String
    Public Property BankName() As String
        Get
            Return _BankName
        End Get
        Set(ByVal value As String)
            _BankName = value
        End Set
    End Property
    Private _pph As String
    Public Property pph() As String
        Get
            Return _pph
        End Get
        Set(ByVal value As String)
            _pph = value
        End Set
    End Property
    Private _tarif As String
    Public Property tarif() As String
        Get
            Return _tarif
        End Get
        Set(ByVal value As String)
            _tarif = value
        End Set
    End Property

    Private _Tot_Dpp_Invoice As String
    Public Property Tot_Dpp_Invoice() As String
        Get
            Return _Tot_Dpp_Invoice
        End Get
        Set(ByVal value As String)
            _Tot_Dpp_Invoice = value
        End Set
    End Property

    Private _Tot_ppn As String
    Public Property Tot_ppn() As String
        Get
            Return _Tot_ppn
        End Get
        Set(ByVal value As String)
            _Tot_ppn = value
        End Set
    End Property

    Private _Tot_voucher As String
    Public Property Tot_voucher() As String
        Get
            Return _Tot_voucher
        End Get
        Set(ByVal value As String)
            _Tot_voucher = value
        End Set
    End Property

    Private _Tot_pph As String
    Public Property Tot_pph() As String
        Get
            Return _Tot_pph
        End Get
        Set(ByVal value As String)
            _Tot_pph = value
        End Set
    End Property

    Private _status As String
    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _ket_pph As String
    Public Property ket_pph() As String
        Get
            Return _ket_pph
        End Get
        Set(ByVal value As String)
            _ket_pph = value
        End Set
    End Property

    Private _lokasi As String
    Public Property lokasi() As String
        Get
            Return _lokasi
        End Get
        Set(ByVal value As String)
            _lokasi = value
        End Set
    End Property
    Private _pphid As String
    Public Property pphid() As String
        Get
            Return _pphid
        End Get
        Set(ByVal value As String)
            _pphid = value
        End Set
    End Property
    Private _No_Bukti_Potong As String
    Public Property No_Bukti_Potong() As String
        Get
            Return _No_Bukti_Potong
        End Get
        Set(ByVal value As String)
            _No_Bukti_Potong = value
        End Set
    End Property


    Private _invtid As String
    Public Property invtid() As String
        Get
            Return _invtid
        End Get
        Set(ByVal value As String)
            _invtid = value
        End Set
    End Property

    Private _descr As String
    Public Property descr() As String
        Get
            Return _descr
        End Get
        Set(ByVal value As String)
            _descr = value
        End Set
    End Property

    Private _dpp As String
    Public Property dpp() As String
        Get
            Return _dpp
        End Get
        Set(ByVal value As String)
            _dpp = value
        End Set
    End Property
    Private _ket_dpp As String
    Public Property ket_dpp() As String
        Get
            Return _ket_dpp
        End Get
        Set(ByVal value As String)
            _ket_dpp = value
        End Set
    End Property
    Private _No_Faktur As String
    Public Property No_Faktur() As String
        Get
            Return _No_Faktur
        End Get
        Set(ByVal value As String)
            _No_Faktur = value
        End Set
    End Property
    Private _Biaya_Transfer As String
    Public Property Biaya_Transfer() As String
        Get
            Return _Biaya_Transfer
        End Get
        Set(ByVal value As String)
            _Biaya_Transfer = value
        End Set
    End Property
    Private _cm_dm As String
    Public Property cm_dm() As String
        Get
            Return _cm_dm
        End Get
        Set(ByVal value As String)
            _cm_dm = value
        End Set
    End Property

    Private _tglawal As Date
    Public Property tglawal() As Date
        Get
            Return _tglawal
        End Get
        Set(ByVal value As Date)
            _tglawal = value
        End Set
    End Property

    Private _tglakhir As Date
    Public Property tglakhir() As Date
        Get
            Return _tglakhir
        End Get
        Set(ByVal value As Date)
            _tglakhir = value
        End Set
    End Property
    Private _prosespay As String
    Public Property prosespay() As String
        Get
            Return _prosespay
        End Get
        Set(ByVal value As String)
            _prosespay = value
        End Set
    End Property
    Private _vrno As String
    Public Property vrno() As String
        Get
            Return _vrno
        End Get
        Set(ByVal value As String)
            _vrno = value
        End Set
    End Property
    Private _perpost As String
    Public Property perpost() As String
        Get
            Return _perpost
        End Get
        Set(ByVal value As String)
            _perpost = value
        End Set
    End Property
    Private _abanknorek As String
    Public Property abanknorek() As String
        Get
            Return _abanknorek
        End Get
        Set(ByVal value As String)
            _abanknorek = value
        End Set
    End Property
    Private _anorek As String
    Public Property anorek() As String
        Get
            Return _anorek
        End Get
        Set(ByVal value As String)
            _anorek = value
        End Set
    End Property
    Private _adetsupplier As String
    Public Property adetsupplier() As String
        Get
            Return _adetsupplier
        End Get
        Set(ByVal value As String)
            _adetsupplier = value
        End Set
    End Property

    Private _acuryid As String
    Public Property acuryid() As String
        Get
            Return _acuryid
        End Get
        Set(ByVal value As String)
            _acuryid = value
        End Set
    End Property

    Private _namerek As String
    Public Property namerek() As String
        Get
            Return _namerek
        End Get
        Set(ByVal value As String)
            _namerek = value
        End Set
    End Property

    Private _vendidrek As String
    Public Property vendidrek() As String
        Get
            Return _vendidrek
        End Get
        Set(ByVal value As String)
            _vendidrek = value
        End Set
    End Property

    Private _namedetailrek As String
    Public Property namedetailrek() As String
        Get
            Return _namedetailrek
        End Get
        Set(ByVal value As String)
            _namedetailrek = value
        End Set
    End Property

    Private _bankrekening As String
    Public Property bankrekening() As String
        Get
            Return _bankrekening
        End Get
        Set(ByVal value As String)
            _bankrekening = value
        End Set
    End Property

    Private _norekrek As String
    Public Property norekrek() As String
        Get
            Return _norekrek
        End Get
        Set(ByVal value As String)
            _norekrek = value
        End Set
    End Property

    Private _curyidrek As String
    Public Property curyidrek() As String
        Get
            Return _curyidrek
        End Get
        Set(ByVal value As String)
            _curyidrek = value
        End Set
    End Property

    Private _namerekdt As String
    Public Property namerekdt() As String
        Get
            Return _namerekdt
        End Get
        Set(ByVal value As String)
            _namerekdt = value
        End Set
    End Property

    Private _vendidrekdt As String
    Public Property vendidrekdt() As String
        Get
            Return _vendidrekdt
        End Get
        Set(ByVal value As String)
            _vendidrekdt = value
        End Set
    End Property

    Private _namedetailrekdt As String
    Public Property namedetailrekdt() As String
        Get
            Return _namedetailrekdt
        End Get
        Set(ByVal value As String)
            _namedetailrekdt = value
        End Set
    End Property
    Private _apenerima As String
    Public Property apenerima() As String
        Get
            Return _apenerima
        End Get
        Set(ByVal value As String)
            _apenerima = value
        End Set
    End Property



    Public Function uploadbank() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        'Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text
        Try
            query = "Select namedetail,norek,bank,name1 from payment_norek1 where namedetail like '%" & _adetsupplier & "%' order by namedetail "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function uploadnorek() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        ''Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text
        Try
            query = "Select norek FROM payment_norek1 where namedetail like '%" & _adetsupplier & "%' "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function supplier() As DataTable
        Try
            query = "Select rtrim(VendID)VendID, rtrim(Name)Name FROM Vendor where status='A' order by name"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function nameforbank() As DataTable
        Try
            query = "Select namedetail,norek,bank from payment_norek1 order by Namedetail"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function nameforbank1() As DataTable
        Try
            query = "Select distinct namedetail from payment_norek1 order by Namedetail"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function uploadall() As DataTable
        Try
            query = "Select name,bank,norek from payment_norek where name like '%" & _adetsupplier & "%' and curyid like '%" & _acuryid & "%' order by name order by name"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function norek() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        'Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text
        Try
            query = "Select norek FROM payment_norek1 where namedetail like '%" & _adetsupplier & "%' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function penerima() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        'Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text
        Try
            query = "Select name1 FROM payment_norek1 where namedetail like '%" & _adetsupplier & "%' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function banknorek() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        'Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text
        Try
            query = "Select bank FROM payment_norek1 where namedetail like '%" & _adetsupplier & "%' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function


    Public Function detsupplier() As DataTable

        Try
            query = "Select namedetail,bank,norek FROM payment_norek order by namedetail"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function autonopv2() As String
        Try
            Dim auto As String
            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " & _
                 "set @bulan = '" & Mid(_perpost, 6, 2) & "' " & _
                "set @tahun = '" & Mid(_perpost, 1, 4) & "' " & _
                "set @seq= (select right('0000'+cast(right(rtrim(max(vrno)),4)+1 as varchar),4) " & _
                "from Payment_Header1 " & _
                "where SUBSTRING(vrno,4,4) = @tahun AND SUBSTRING(vrno,9,2) = @bulan) " & _
                "select 'AP' + '-' + @tahun + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function autoperpost() As String
        Try
            Dim auto As String
            query = "declare  @bulan varchar(4), @tahun varchar(4) " & _
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " & _
                "set @tahun = datepart(year,getdate()) " & _
                "select RIGHT(@tahun,4) + '-' + @bulan "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function supplierbyid() As String
        Try
            Dim VendID1 As String
            query = "Select remitname,taxregnbr,user1 FROM Vendor where VendID='" & _VendID & "' and status='A' order by name"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            VendID1 = dt.Rows(0).Item(0).ToString
            Return VendID1

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function supplierbyid2() As DataTable
        Try

            query = "Select name,taxregnbr,user1,ltrim(rtrim(remitname)) as remitname FROM Vendor where VendID='" & _VendID & "' and status='A' order by name"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function detsupbybank() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        ''Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text

        Try
            query = "Select bank FROM payment_norek1 where namedetail like '%" & _adetsupplier & "%' "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function detsupbynorek() As DataTable
        adetsupplier = "" ' Frm_Payment._detsupplier.Text
        ''Frm_Payment._detsupplier.Text = Frm_Payment._Vend_Name.Text
        Try
            query = "Select norek FROM payment_norek1 where namedetail like '%" & _adetsupplier & "%'  "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function detsupbydetail() As DataTable
        Try
            query = "Select namedetail,norek,bank FROM payment_norek where namedetail='" & _adetsupplier & "' order by namedetail"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function supplierbyname2() As DataTable
        Try

            query = "Select VendID,taxregnbr,user1,ltrim(rtrim(remitname)) as remitname FROM Vendor where Name='" & _Vend_Name & "' and status='A' order by name"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function


    Public Function norektampil() As DataTable
        Vend_Name = "" ' Frm_Payment._Vend_Name.Text
        acuryid = "" ' Frm_Payment._curyid.Text
        Try
            query = "Select namedetail,name,nore,bank from payment_norek where name like '%" & _Vend_Name & "%' and curyid like '%" & _acuryid & "%' order by namedetail"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function supplierbyname() As String
        Try
            Dim VendID2 As String
            query = "Select VendID,taxregnbr,user1 FROM Vendor where Name='" & _Vend_Name & "' and status='A' order by name"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            VendID2 = dt.Rows(0).Item(0).ToString
            Return VendID2

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function bank() As DataTable

        Try
            query = "select BankAcct,CashAcctName from cashacct"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function bankbyname2() As DataTable
        Try

            query = "Select BankAcct,CashAcctName from cashacct where CashAcctName='" & _BankName & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function bankbyid2() As DataTable
        Try

            query = "Select CashAcctName from cashacct where BankAcct='" & _BankID & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function autonopv() As String
        Try
            Dim auto As String
            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " & _
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " & _
                "set @tahun = datepart(year,getdate()) " & _
                "set @seq= (select right('0000'+cast(right(rtrim(max(vrno)),4)+1 as varchar),4) " & _
                "from Payment_Header1 " & _
                "where SUBSTRING(vrno,4,4) = RIGHT(@tahun,4) AND SUBSTRING(vrno,9,2) = RIGHT(@bulan,2)) " & _
                "select 'AP' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldataap2() As DataTable
        Try

            query2 = "SELECT InvcNbr,	InvcDate,		sum(Amount) as Amount,	CuryId,	sum(Ppn) as Ppn,	sum(Amount_before) as DPP,sum(Pph) AS PPH,fp FROM FP_temp2 where VendId='" & _VendID & "'" &
                     "group by  InvcNbr,	InvcDate,	CuryId, fp   order by InvcNbr"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query2)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function ProsesVoucher() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "PROSES_VOUCHER_APNOTPAYYMENT"
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ProsesVoucher1() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "PROSES_VOUCHER_APNOTPAYYMENT1"
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
