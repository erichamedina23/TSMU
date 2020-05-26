Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_FP

    Dim query As String = String.Empty
    Dim query1 As String = String.Empty
    Dim query2 As String = String.Empty
    Dim query3 As String = String.Empty
    Dim ObjFpHeader As New fp_header_models
    Dim ObjFpDetails As New fp_details_models
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
    Public Function supplier() As DataTable

        Try
            query = "Select VendID, Name FROM Vendor"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function autono() As String
        Try
            Dim auto As String = String.Empty
            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(FPNo)),4)+1 as varchar),4) " &
                "from Fp_Header " &
                "where SUBSTRING(FPNo,6,2) = RIGHT(@tahun,2)) " &
                "select 'FPA' + @bulan + RIGHT(@tahun,2) + coalesce(@seq, '0001')"


            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw
        End Try
    End Function

    'add by Haris
    Public Function GetDetailsGridFP(VendorId) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "PROSES_VOUCHER_APNOTPAYYMENT3"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@vendid", SqlDbType.VarChar)
            pParam(0).Value = VendorId
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function cekfaktur() As String
        Try
            Dim ada_faktur As String
            query = "select no_faktur from fp_pph_header where no_faktur='" & Fp & "' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            If dt.Rows.Count > 0 Then
                ada_faktur = dt.Rows(0).Item(0).ToString
            Else
                ada_faktur = ""
            End If

            Return ada_faktur

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function cekinv() As String
        Try
            Dim ada_invoice As String
            query = "select distinct no_invoice from fp_pph_detail where no_invoice='" & invcnbr & "' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            If dt.Rows.Count > 0 Then
                ada_invoice = dt.Rows(0).Item(0).ToString
            Else
                ada_invoice = ""
            End If

            Return ada_invoice

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function getalldataap_det() As DataTable
        Try

            ''     query = "SELECT InvcNbr,	InvcDate,		sum(Amount) as Amount,	CuryId,	sum(Ppn) as Ppn,	sum(Amount_before) as DPP,sum(Amount_before)*" & tarif / 100 & " as Pph,SUBSTRING(Replace(Replace(fp,'.',''),'-',''),4,13) as fp FROM FP_temp where VendId='" & _VendID & "'" & _
            ''               "group by  InvcNbr,	InvcDate,	CuryId, SUBSTRING(Replace(Replace(fp,'.',''),'-',''),4,13)   order by InvcNbr"

            ''           query = "Select APTran.InvtID,APTran.TranDesc,SUM(APTran.CuryTranAmt) AS Amount from APTran inner join APDoc on APDoc.BatNbr=APTran.BatNbr " & _
            ''                  "WHERE DocType='VO' and APTran.LineType='R' AND APTran.RefNbr=APDoc.RefNbr AND  APDoc.User1='" & _Fp & "' " & _
            ''                 "GROUP BY APTran.InvtID,APTran.TranDesc"

            query = "Select APTran.InvtID,APTran.TranDesc,SUM(APTran.CuryTranAmt) AS Amount, convert(bit,0) cek from APTran inner join APDoc on APDoc.BatNbr=APTran.BatNbr " &
                    "WHERE DocType='VO' and APTran.LineType='R' AND APTran.RefNbr=APDoc.RefNbr AND  APDoc.Invcnbr='" & invcnbr & "' " &
                    "GROUP BY APTran.InvtID,APTran.TranDesc"

            ''        query = "Select APDoc.InvcNbr,APDoc.User1,APTran.InvtID,APTran.TranDesc,SUM(APTran.CuryTranAmt) AS Amount from APTran inner join APDoc on APDoc.BatNbr=APTran.BatNbr " & _
            ''    "WHERE DocType='VO' and APTran.TranDesc!='PPN' AND APDoc.User1='" & _Fp & "' " & _
            ''  "GROUP BY APDoc.InvcNbr,APDoc.User1,APTran.InvtID,APTran.TranDesc"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldataap_det2() As DataTable
        Try

            ''           query = "select invtid,descr,dpp,cek from Fp_pph_detail " & _
            ''                "WHERE No_Faktur='" & _Fp & "' " 
            query = "select invtid InvtID,descr TranDesc,dpp Amount,cek from Fp_pph_detail " &
       "WHERE No_Invoice='" & invcnbr & "' "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldataap_det3() As DataTable
        Try

            query = "select no_invoice as NoinvcNbr, tgl_invoice as InvcDate,Jml_invoice as Amount,CuryID,PPN,DPP,PPh,No_Faktur as 'No. FP' from Fp_detail " & _
                   "WHERE FPNo='" & _Fp & "' "

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function autonoFP(bulan As String) As String
        'Try
        '    Dim auto As String
        '    Dim substring As String = _pph.Substring(4, 2)
        '    query = "declare  @bulan varchar(4), @site varchar(7), @tahun varchar(4),@pasal varchar(2),@seq varchar(4)  " &
        '        "set @site = '" & _lokasi & "'" &
        '        "set @pasal = '" & substring & "'" &
        '        "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2)  " &
        '        "set @tahun = datepart(year,getdate())  " &
        '        "set @seq= (select right('0000'+cast(LEFT(rtrim(max(No_Bukti_Potong)),4)+1 as varchar),4)  " &
        '        "from Fp_pph_header " &
        '        "where FPNo!='" & voucno & "' AND right(No_Bukti_Potong,4) = RIGHT(@tahun,4) AND SUBSTRING(No_Bukti_Potong,6,7)=@site AND SUBSTRING(No_Bukti_Potong,17,2)=@pasal) " &
        '        "select coalesce(@seq, '0001')+'/' + @site  +'/' +@bulan +'/' +@pasal +'/' + RIGHT(@tahun,4) "

        '    Dim dt As DataTable = New DataTable
        '    dt = MainModul.GetDataTable_Solomon(query)
        '    auto = dt.Rows(0).Item(0).ToString
        '    Return auto

        'Catch ex As Exception
        '    Throw

        'End Try

        Try
            Dim _bulan As String
            If Len(bulan) > 1 Then
                _bulan = bulan
            Else
                _bulan = "0" & bulan
            End If
            Dim auto As String
            Dim substring As String = _pph.Substring(4, 2)
            'query = "declare  @bulan varchar(4), @site varchar(7), @tahun varchar(4),@pasal varchar(2),@seq varchar(4)  " &
            '    "set @site = '" & _lokasi & "'" &
            '    "set @pasal = '" & substring & "'" &
            '    "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2)  " &
            '    "set @tahun = datepart(year,getdate())  " &
            '    "set @seq= (select right('0000'+cast(LEFT(rtrim(max(No_Bukti_Potong)),4)+1 as varchar),4)  " &
            '    "from Fp_pph_header " &
            '    "where FPNo!='" & voucno & "' AND right(No_Bukti_Potong,4) = RIGHT(@tahun,4) AND SUBSTRING(No_Bukti_Potong,6,7)=@site AND SUBSTRING(No_Bukti_Potong,17,2)=@pasal) " &
            '    "select coalesce(@seq, '0001')+'/' + @site  +'/' +@bulan +'/' +@pasal +'/' + RIGHT(@tahun,4) "
            query = "declare  @bulan varchar(4), @site varchar(7), @tahun varchar(4),@pasal varchar(2),@seq varchar(4)  " &
                "set @site = '" & _lokasi & "'" &
                "set @pasal = '" & substring & "'" &
                "set @bulan = '" & _bulan & "' " &
                "set @tahun = datepart(year,getdate())  " &
                "set @seq= (select right('0000'+cast(LEFT(rtrim(max(No_Bukti_Potong)),4)+1 as varchar),4)  " &
                "from Fp_pph_header " &
                "where FPNo!='" & voucno & "' AND right(No_Bukti_Potong,4) = RIGHT(@tahun,4) AND SUBSTRING(No_Bukti_Potong,6,7)=@site AND SUBSTRING(No_Bukti_Potong,17,2)=@pasal) " &
                "select coalesce(@seq, '0001')+'/' + @site  +'/' +@bulan +'/' +@pasal +'/' + RIGHT(@tahun,4) "
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function supplierbyid() As String
        Try
            Dim VendID1 As String
            query = "Select remitname,taxregnbr,user1 FROM Vendor where VendID='" & _VendID & "'"

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

            query = "Select name,taxregnbr,user1,ltrim(rtrim(remitname)) as remitname FROM Vendor where VendID='" & _VendID & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function supplierbyname2() As DataTable
        Try

            query = "Select VendID,taxregnbr,user1,ltrim(rtrim(remitname)) as remitname FROM Vendor where Name='" & _Vend_Name & "'"

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
            query = "Select VendID,taxregnbr,user1 FROM Vendor where Name='" & _Vend_Name & "'"

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

    Public Function pasal() As DataTable

        Try
            query = "select distinct pasal Pasal,tarif Tarif,ket_pph Ket from pph"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function ketpasal() As DataTable

        Try
            query = "select ket_pph,tarif from pph where pasal='" & _pph & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function pasalbyid() As String
        Try
            Dim pasal1 As String
            query = "Select ket_pph FROM pph where pasal='" & _pph & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            pasal1 = dt.Rows(0).Item(0).ToString
            Return pasal1

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function ketpasalbyid() As String
        Try
            Dim pasal2 As String
            query = "Select tarif,ket_pph FROM pph where pasal='" & Trim(_pph) & "' and ket_pph='" & Trim(_ket_pph) & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            pasal2 = dt.Rows(0).Item(0).ToString
            Return pasal2

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function bankbyname() As String
        Try
            Dim BankID2 As String
            query = "Select BankAcct FROM cashacct where CashAcctName='" & _BankName & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            BankID2 = dt.Rows(0).Item(0).ToString
            Return BankID2

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function bankbyid() As String
        Try
            Dim BankID1 As String
            query = "Select CashAcctName FROM cashacct where BankAcct='" & _BankID & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            BankID1 = dt.Rows(0).Item(0).ToString
            Return BankID1

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldata2(Dari As String, Sampai As String) As DataTable

        Try
            query = "Select id, FPNo
                    ,Tgl_fp Tanggal
                    ,VendID
                    ,Vend_Name VendorName
                    ,Jenis_Jasa JenisJasa
                    ,npwp NPWP
                    ,No_Bukti_Potong NoBuktiPotong
                    ,Pphid
                    ,Ket_Pph
                    ,Tarif
                    ,Tahun
                    ,Bulan
                    ,Lokasi
                    ,CuryID
                    ,Tot_Dpp_Invoice
                    ,Tot_Ppn,Tot_Voucher
                    ,Tot_Pph,Status
                    ,nama_vendor FROM Fp_Header
                    WHERE  Tgl_fp >=COALESCE(NULLIF(" & QVal(Dari) & ",''),Tgl_fp) AND Tgl_fp <= COALESCE(NULLIF(" & QVal(Sampai) & ",''),Tgl_fp) ORDER BY FPNo Desc"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function GetDataGridNew() As DataTable

        Try
            query = "Select id, FPNo
                    ,Tgl_fp Tanggal
                    ,VendID
                    ,Vend_Name VendorName
                    ,Jenis_Jasa JenisJasa
                    ,npwp NPWP
                    ,No_Bukti_Potong NoBuktiPotong
                    ,Pphid
                    ,Ket_Pph
                    ,Tarif
                    ,Tahun
                    ,Bulan
                    ,Lokasi
                    ,CuryID
                    ,Tot_Dpp_Invoice
                    ,Tot_Ppn,Tot_Voucher
                    ,Tot_Pph,Status
                    ,nama_vendor FROM Fp_Header ORDER BY FPNo Desc"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function GetSupplierLookup() As DataTable

        Try
            query = "SELECT DISTINCT 
                        RTRIM(VendID) VendID
                        ,RTRIM(Name) Name
                        ,RTRIM(User1) JenisJasa
                        ,RTRIM(TaxRegNbr) NPWP
                    FROM Vendor ORDER BY Name"
            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Sub updatedatasolomon()

        Try  

            query = "update apdoc set user3=1 where InvcNbr in (select no_invoice from fp_detail) "
            MainModul.ExecQuery_Solomon(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub

    Public Sub insertdata88()

        Tot_Dpp_Invoice = Tot_Dpp_Invoice.Replace(",", "")

        Tot_pph = Tot_pph.Replace(",", "")

        Try
            query = "INSERT INTO Fp_pph_header (FPNo,No_Bukti_Potong,Pphid,Ket_Pph,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,ket_dpp,Tot_Pph) " & _
                    "VALUES ('" & voucno & "'" & _
                       ",'" & No_Bukti_Potong & "'" & _
                       ",'" & pphid & "'" & _
                       ",'" & ket_pph & "'" & _
                       ",'" & tarif & "'" & _
                       ",'" & tahun & "'" & _
                       ",'" & bulan & "'" & _
                       ",'" & lokasi & "'" & _
                       ",'" & CuryID & "'" & _
                       ",'" & Tot_Dpp_Invoice & "'" & _
                       ",'" & No_Faktur & "'" & _
                        ",'" & ket_dpp & "'" & _
                       ",'" & Tot_pph & "') "
            MainModul.ExecQuery_Solomon(query)

        Catch ex As Exception
            Throw

        End Try
    End Sub

    Public Sub deletedatacek()
        Try
            ''query = "delete from Fp_Detail where FPNo='" & voucno & "' and link_barcode='False'"
            query = "delete from Fp_Detail where FPNo='" & voucno & "'"
            MainModul.ExecQuery_Solomon(query)

        Catch ex As Exception
            Throw

        End Try
    End Sub

    Public Sub deletedatapph()
        Try
            query = "delete from Fp_pph_Detail where FPNo='" & voucno & "' and No_Faktur='" & No_Faktur & "'"
            MainModul.ExecQuery_Solomon(query)
            query = "delete from Fp_pph_header where FPNo='" & voucno & "' and No_Faktur='" & No_Faktur & "'"
            MainModul.ExecQuery_Solomon(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub

    Public Sub GetFakturPajakById()
        Try
            Dim sql = "SELECT [FPNo]
                      ,[Tgl_fp]
                      ,[VendID]
                      ,[Vend_Name]
                      ,[Jenis_Jasa]
                      ,[npwp]
                      ,[No_Bukti_Potong]
                      ,[Pphid]
                      ,[Ket_Pph]
                      ,[Tarif]
                      ,[Tahun]
                      ,[Bulan]
                      ,[Lokasi]
                      ,[CuryID]
                      ,[Tot_Dpp_Invoice]
                      ,[Tot_Ppn]
                      ,[Tot_Voucher]
                      ,[Tot_Pph]
                      ,[Status]
                      ,[nama_vendor]
                  FROM [Fp_Header] where FPNo=" & QVal(ObjFpHeader.FPNo) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                With ObjFpHeader
                    .FPNo = Trim(dt.Rows(0).Item("FPNo"))
                    .Tgl_fp = Trim(dt.Rows(0).Item("Tgl_fp"))
                    .VendID = Trim(dt.Rows(0).Item("VendID"))
                    .Vend_Name = Trim(dt.Rows(0).Item("Vend_Name"))
                    .Jenis_Jasa = Trim(dt.Rows(0).Item("Jenis_Jasa"))
                    .npwp = Trim(dt.Rows(0).Item("npwp"))
                    .No_Bukti_Potong = Trim(dt.Rows(0).Item("No_Bukti_Potong"))
                    .Pphid = Trim(dt.Rows(0).Item("Pphid"))
                    .Ket_Pph = Trim(dt.Rows(0).Item("Ket_Pph"))
                    .Tarif = Trim(dt.Rows(0).Item("Tarif"))
                    .Tahun = Trim(dt.Rows(0).Item("Tahun"))
                    .Bulan = Trim(dt.Rows(0).Item("Bulan"))
                    .Lokasi = Trim(dt.Rows(0).Item("Lokasi"))
                    .CuryID = Trim(dt.Rows(0).Item("CuryID"))
                    .Tot_Dpp_Invoice = Trim(dt.Rows(0).Item("Tot_Dpp_Invoice"))
                    .Tot_Ppn = Trim(dt.Rows(0).Item("Tot_Ppn"))
                    .Tot_Voucher = Trim(dt.Rows(0).Item("Tot_Voucher"))
                    .Tot_Pph = Trim(dt.Rows(0).Item("Tot_Pph"))
                    .Status = Trim(dt.Rows(0).Item("Status"))
                    .nama_vendor = Trim(dt.Rows(0).Item("nama_vendor"))
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
