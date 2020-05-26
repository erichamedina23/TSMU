Public Class ClassSystemConfiguration
    Dim _KodeSetting As String
    Dim _NamaPerusahaan As String
    Dim _DefaultAreaCode As String
    Dim _Alamat As String
    Dim _Telp As String
    Dim _Fax As String
    Dim _PPN As Double
    Dim _PPNPurchase As Double
    Dim _MetodeStok As String
    Dim _MetodeProfit As String

    Dim _PrefixPenjualan As String
    Dim _PrefixFakturPenjualan As String
    Dim _PrefixPembayaranAR As String
    Dim _PrefixPengaturanAR As String
    Dim _PrefixFakturPembelian As String
    Dim _PrefixPembayaranAP As String
    Dim _PrefixPengaturanAP As String
    Dim _PrefixPembukuan As String

    Dim _JumlahRounding As Double
    Dim _RoundingUp As Boolean
    Dim _PercentPurchase As Double
    Dim _PercentReceive As Double

    Dim _Query As String
    Dim ls_Error As String = ""

    Public Function Clone() As ClassSystemConfiguration
        Return DirectCast(Me.MemberwiseClone, ClassSystemConfiguration)
    End Function

    Property KodeSetting() As String
        Get
            Return Me._KodeSetting
        End Get
        Set(ByVal value As String)
            Me._KodeSetting = value
        End Set
    End Property

    Property NamaPerusahaan() As String
        Get
            Return Me._NamaPerusahaan
        End Get
        Set(ByVal value As String)
            Me._NamaPerusahaan = value
        End Set
    End Property
    Property DefaultAreaCode() As String
        Get
            Return Me._DefaultAreaCode
        End Get
        Set(ByVal value As String)
            Me._DefaultAreaCode = value
        End Set
    End Property

    Property Alamat() As String
        Get
            Return Me._Alamat
        End Get
        Set(ByVal value As String)
            Me._Alamat = value
        End Set
    End Property

    Property Telp() As String
        Get
            Return Me._Telp
        End Get
        Set(ByVal value As String)
            Me._Telp = value
        End Set
    End Property

    Property Fax() As String
        Get
            Return Me._Fax
        End Get
        Set(ByVal value As String)
            Me._Fax = value
        End Set
    End Property

    Property PPN() As Double
        Get
            Return Me._PPN
        End Get
        Set(ByVal value As Double)
            Me._PPN = value
        End Set
    End Property

    Property PPNPurchase() As Double
        Get
            Return Me._PPNPurchase
        End Get
        Set(ByVal value As Double)
            Me._PPNPurchase = value
        End Set
    End Property

    Property MetodeStok() As String
        Get
            Return Me._MetodeStok
        End Get
        Set(ByVal value As String)
            Me._MetodeStok = value
        End Set
    End Property

    Property MetodeProfit() As String
        Get
            Return Me._MetodeProfit
        End Get
        Set(ByVal value As String)
            Me._MetodeProfit = value
        End Set
    End Property

    Property PrefixPenjualan() As String
        Get
            Return Me._PrefixPenjualan
        End Get
        Set(ByVal value As String)
            Me._PrefixPenjualan = value
        End Set
    End Property

    Property PrefixFakturPenjualan() As String
        Get
            Return Me._PrefixFakturPenjualan
        End Get
        Set(ByVal value As String)
            Me._PrefixFakturPenjualan = value
        End Set
    End Property

    Property PrefixPembayaranAR() As String
        Get
            Return Me._PrefixPembayaranAR
        End Get
        Set(ByVal value As String)
            Me._PrefixPembayaranAR = value
        End Set
    End Property

    Property PrefixPengaturanAR() As String
        Get
            Return Me._PrefixPengaturanAR
        End Get
        Set(ByVal value As String)
            Me._PrefixPengaturanAR = value
        End Set
    End Property

    Property PrefixFakturPembelian() As String
        Get
            Return Me._PrefixFakturPembelian
        End Get
        Set(ByVal value As String)
            Me._PrefixFakturPembelian = value
        End Set
    End Property

    Property PrefixPembayaranAP() As String
        Get
            Return Me._PrefixPembayaranAP
        End Get
        Set(ByVal value As String)
            Me._PrefixPembayaranAP = value
        End Set
    End Property

    Property PrefixPengaturanAP() As String
        Get
            Return Me._PrefixPengaturanAP
        End Get
        Set(ByVal value As String)
            Me._PrefixPengaturanAP = value
        End Set
    End Property

    Property PrefixPembukuan() As String
        Get
            Return Me._PrefixPembukuan
        End Get
        Set(ByVal value As String)
            Me._PrefixPembukuan = value
        End Set
    End Property

    Property JumlahRounding() As Double
        Get
            Return Me._JumlahRounding
        End Get
        Set(ByVal value As Double)
            Me._JumlahRounding = value
        End Set
    End Property

    Property RoundingUp() As Boolean
        Get
            Return Me._RoundingUp
        End Get
        Set(ByVal value As Boolean)
            Me._RoundingUp = value
        End Set
    End Property

    Property PercentPurchase() As Double
        Get
            Return Me._PercentPurchase
        End Get
        Set(ByVal value As Double)
            Me._PercentPurchase = value
        End Set
    End Property

    Property PercentReceive() As Double
        Get
            Return Me._PercentReceive
        End Get
        Set(ByVal value As Double)
            Me._PercentReceive = value
        End Set
    End Property

    ReadOnly Property Query() As String
        Get
            Return Me._Query
        End Get
    End Property

    Public Sub New()
        Me._Query = "SELECT KodeSetting AS [Kode Setting] " & vbCrLf & _
        "	, NamaPerusahaan AS [Nama Perusahaan] " & vbCrLf & _
        "	, DefaultAreaCode AS [Default Area Code] " & vbCrLf & _
        "	, Alamat AS [Alamat] " & vbCrLf & _
        "	, Telp AS [Telp] " & vbCrLf & _
        "	, Fax AS [Fax] " & vbCrLf & _
        "	, PPN AS [PPN] " & vbCrLf & _
        "/*	, PPNPurchase AS [PPN Purchase] " & vbCrLf & _
        "	, MetodeStok AS [Metode Stok] " & vbCrLf & _
        "	, MetodeProfit AS [Metode Profit] " & vbCrLf & _
        "	, PrefixPenjualan AS [Prefix Penjualan] " & vbCrLf & _
        "	, PrefixFakturPenjualan AS [Prefix Faktur Penjualan] " & vbCrLf & _
        "	, PrefixPembayaranAR AS [Prefix Pembayaran AR] " & vbCrLf & _
        "	, PrefixPengaturanAR AS [Prefix Pengaturan AR] " & vbCrLf & _
        "	, PrefixFakturPembelian AS [Prefix Faktur Pembelian] " & vbCrLf & _
        "	, PrefixPembayaranAP AS [Prefix Pembayaran AP] " & vbCrLf & _
        "	, PrefixPengaturanAP AS [Prefix Pengaturan AP] " & vbCrLf & _
        "	, PrefixPembukuan AS [Prefix Pembukuan] " & vbCrLf & _
        "	, PercentPurchase AS [Percent Purchase] " & vbCrLf & _
        "	, PercentReceive AS [Percent Receive] " & vbCrLf & _
        "*/FROM tb_Setting "
    End Sub

    Public Sub GetData()
        Try
            'Dim query As String = Me._Query & vbCrLf & _
            '"WHERE KodeSetting = (SELECT TOP 1 KodeSetting FROM tb_Setting) " & QueryOrder
            'Dim dtTable As DataTable = GetDataTable(query)
            'If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '    With dtTable.Rows(0)
            '        Me._KodeSetting = Trim(.Item("Kode Setting") & "")
            '        Me._NamaPerusahaan = Trim(.Item("Nama Perusahaan") & "")
            '        Me._DefaultAreaCode = Trim(.Item("Default Area Code") & "")
            '        Me._Alamat = Trim(.Item("Alamat") & "")
            '        Me._Telp = Trim(.Item("Telp") & "")
            '        Me._Fax = Trim(.Item("Fax") & "")
            '        Me._PPN = NumValue(.Item("PPN"))
            '        'Me._PPNPurchase = NumValue(.Item("PPN Purchase"))
            '        'Me._MetodeStok = Trim(.Item("Metode Stok") & "")
            '        'Me._MetodeProfit = Trim(.Item("Metode Profit") & "")
            '        'Me._PrefixPenjualan = Trim(.Item("Prefix Penjualan") & "")
            '        'Me._PrefixFakturPenjualan = Trim(.Item("Prefix Faktur Penjualan") & "")
            '        'Me._PrefixPembayaranAR = Trim(.Item("Prefix Pembayaran AR") & "")
            '        'Me._PrefixPengaturanAR = Trim(.Item("Prefix Pengaturan AR") & "")
            '        'Me._PrefixFakturPembelian = Trim(.Item("Prefix Faktur Pembelian") & "")
            '        'Me._PrefixPembayaranAP = Trim(.Item("Prefix Pembayaran AP") & "")
            '        'Me._PrefixPengaturanAP = Trim(.Item("Prefix Pengaturan AP") & "")
            '        'Me._PrefixPembukuan = Trim(.Item("Prefix Pembukuan") & "")
            '        'Me._PercentPurchase = NumValue(.Item("Percent Purchase"))
            '        'Me._PercentReceive = NumValue(.Item("Percent Receive"))
            '    End With
            'End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetAllDataTable() As DataTable
        Try
            'Dim query As String = Me._Query & QueryOrder
            'Dim dtTable As DataTable = GetDataTable(query)
            'Return dtTable
            Return Nothing
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub ValidateInsert()
        Try
            If Me._KodeSetting = "" AndAlso Me._NamaPerusahaan Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If
            'Dim query As String = "SELECT KodeSetting FROM tb_SystemSetting " & vbCrLf & _
            '"WHERE KodeSetting = " & QVal(Me._KodeSetting) & " "
            'Dim dtTable As DataTable = GetDataTable(query)
            'If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) & "[" & Me._KodeSetting & "]")
            'End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertData()
        Try
            'DeleteData()
            'Dim query As String = "INSERT INTO tb_Setting " & vbCrLf & _
            '"	( " & vbCrLf & _
            '"		KodeSetting, NamaPerusahaan,DefaultAreaCode, Alamat, Telp, Fax " & vbCrLf & _
            '"		, PPN, PPNPurchase, MetodeStok, MetodeProfit " & vbCrLf & _
            '"		, PrefixPenjualan, PrefixFakturPenjualan " & vbCrLf & _
            '"		, PrefixPembayaranAR, PrefixPengaturanAR " & vbCrLf & _
            '"		, PrefixFakturPembelian, PrefixPembayaranAP " & vbCrLf & _
            '"		, PrefixPengaturanAP, PrefixPembukuan " & vbCrLf & _
            '"		, JumlahRounding, RoundingUP " & vbCrLf & _
            '"		, PercentPurchase, PercentReceive " & vbCrLf & _
            '"		, UpdateDate, UpdateUser " & vbCrLf & _
            '"	) " & vbCrLf & _
            '"VALUES " & vbCrLf & _
            '"	( " & vbCrLf & _
            '"		" & QVal(Me._KodeSetting) & " " & vbCrLf & _
            '"		, " & QVal(Me._NamaPerusahaan) & " " & vbCrLf & _
            '"		, " & QVal(Me._DefaultAreaCode) & " " & vbCrLf & _
            '"		, " & QVal(Me._Alamat) & " " & vbCrLf & _
            '"		, " & QVal(Me._Telp) & " " & vbCrLf & _
            '"		, " & QVal(Me._Fax) & " " & vbCrLf & _
            '"		, " & QVal(Me._PPN) & " " & vbCrLf & _
            '"		, " & QVal(Me._PPNPurchase) & " " & vbCrLf & _
            '"		, " & QVal(Me._MetodeStok) & " " & vbCrLf & _
            '"		, " & QVal(Me._MetodeProfit) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixPenjualan) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixFakturPenjualan) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixPembayaranAR) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixPengaturanAR) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixFakturPembelian) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixPembayaranAP) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixPengaturanAP) & " " & vbCrLf & _
            '"		, " & QVal(Me._PrefixPembukuan) & " " & vbCrLf & _
            '"		, " & QVal(Me._JumlahRounding) & " " & vbCrLf & _
            '"		, " & QVal(Me._RoundingUp) & " " & vbCrLf & _
            '"		, " & QVal(Me._PercentPurchase) & " " & vbCrLf & _
            '"		, " & QVal(Me._PercentReceive) & " " & vbCrLf & _
            '"		, GETDATE() " & vbCrLf & _
            '"		, " & QVal(gs_LoginNamaUser) & " " & vbCrLf & _
            '"	) "
            'Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteData()
        Try
            'Dim query As String = "DELETE FROM tb_Setting"
            'Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
