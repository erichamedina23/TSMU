Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_barcode
    Dim query As String = String.Empty
    Private _kdJenisTransaksi As String
    Public Property kdJenisTransaksi() As String
        Get
            Return _kdJenisTransaksi
        End Get
        Set(ByVal value As String)
            _kdJenisTransaksi = value
        End Set
    End Property

    Private _fgPengganti As String
    Public Property fgPengganti() As String
        Get
            Return _fgPengganti
        End Get
        Set(ByVal value As String)
            _fgPengganti = value
        End Set
    End Property

    Private _nomorFaktur As String
    Public Property nomorFaktur() As String
        Get
            Return _nomorFaktur
        End Get
        Set(ByVal value As String)
            _nomorFaktur = value
        End Set
    End Property
    Private _tanggalFaktur As String
    Public Property tanggalFaktur() As String
        Get
            Return _tanggalFaktur
        End Get
        Set(ByVal value As String)
            _tanggalFaktur = value
        End Set
    End Property

    Private _npwpPenjual As String
    Public Property npwpPenjual() As String
        Get
            Return _npwpPenjual
        End Get
        Set(ByVal value As String)
            _npwpPenjual = value
        End Set
    End Property
    Private _alamatPenjual As String
    Public Property alamatPenjual() As String
        Get
            Return _alamatPenjual
        End Get
        Set(ByVal value As String)
            _alamatPenjual = value
        End Set
    End Property

    Private _namaPenjual As String
    Public Property namaPenjual() As String
        Get
            Return _namaPenjual
        End Get
        Set(ByVal value As String)
            _namaPenjual = value
        End Set
    End Property

    Private _npwpLawanTransaksi As String
    Public Property npwpLawanTransaksi() As String
        Get
            Return _npwpLawanTransaksi
        End Get
        Set(ByVal value As String)
            _npwpLawanTransaksi = value
        End Set
    End Property

    Private _namaLawanTransaksi As String
    Public Property namaLawanTransaksi() As String
        Get
            Return _namaLawanTransaksi
        End Get
        Set(ByVal value As String)
            _namaLawanTransaksi = value
        End Set
    End Property

    Private _alamatLawanTransaksi As String
    Public Property alamatLawanTransaksi() As String
        Get
            Return _alamatLawanTransaksi
        End Get
        Set(ByVal value As String)
            _alamatLawanTransaksi = value
        End Set
    End Property

    Private _jumlahDpp As String
    Public Property jumlahDpp() As String
        Get
            Return _jumlahDpp
        End Get
        Set(ByVal value As String)
            _jumlahDpp = value
        End Set
    End Property
    Private _jumlahPpn As String
    Public Property jumlahPpn() As String
        Get
            Return _jumlahPpn
        End Get
        Set(ByVal value As String)
            _jumlahPpn = value
        End Set
    End Property
    Private _jumlahPpnBm As String
    Public Property jumlahPpnBm() As String
        Get
            Return _jumlahPpnBm
        End Get
        Set(ByVal value As String)
            _jumlahPpnBm = value
        End Set
    End Property

    Private _statusApproval As String
    Public Property statusApproval() As String
        Get
            Return _statusApproval
        End Get
        Set(ByVal value As String)
            _statusApproval = value
        End Set
    End Property

    Private _statusFaktur As String
    Public Property statusFaktur() As String
        Get
            Return _statusFaktur
        End Get
        Set(ByVal value As String)
            _statusFaktur = value
        End Set
    End Property
    Private _nama As String
    Public Property nama() As String
        Get
            Return _nama
        End Get
        Set(ByVal value As String)
            _nama = value
        End Set
    End Property
    Private _hargaSatuan As String
    Public Property hargaSatuan() As String
        Get
            Return _hargaSatuan
        End Get
        Set(ByVal value As String)
            _hargaSatuan = value
        End Set
    End Property


    Private _jumlahBarang As String
    Public Property jumlahBarang() As String
        Get
            Return _jumlahBarang
        End Get
        Set(ByVal value As String)
            _jumlahBarang = value
        End Set
    End Property

    Private _hargaTotal As String
    Public Property hargaTotal() As String
        Get
            Return _hargaTotal
        End Get
        Set(ByVal value As String)
            _hargaTotal = value
        End Set
    End Property
    Private _diskon As String
    Public Property diskon() As String
        Get
            Return _diskon
        End Get
        Set(ByVal value As String)
            _diskon = value
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

    Private _ppn As String
    Public Property ppn() As String
        Get
            Return _ppn
        End Get
        Set(ByVal value As String)
            _ppn = value
        End Set
    End Property
    Private _tarifPpnbm As String
    Public Property tarifPpnbm() As String
        Get
            Return _tarifPpnbm
        End Get
        Set(ByVal value As String)
            _tarifPpnbm = value
        End Set
    End Property

    Private _ppnbm As String
    Public Property ppnbm() As String
        Get
            Return _ppnbm
        End Get
        Set(ByVal value As String)
            _ppnbm = value
        End Set
    End Property

    Private _ling As String
    Public Property ling() As String
        Get
            Return _ling
        End Get
        Set(ByVal value As String)
            _ling = value
        End Set
    End Property

    Private _no As String
    Public Property no() As String
        Get
            Return _no
        End Get
        Set(ByVal value As String)
            _no = value
        End Set
    End Property
    Private _masapajak As String
    Public Property masapajak() As String
        Get
            Return _masapajak
        End Get
        Set(ByVal value As String)
            _masapajak = value
        End Set
    End Property
    Private _tahunpajak As String
    Public Property tahunpajak() As String
        Get
            Return _tahunpajak
        End Get
        Set(ByVal value As String)
            _tahunpajak = value
        End Set
    End Property
    Public Sub insertdata_barcodefp()

        Try
            query = "INSERT INTO barcode_fp (kdJenisTransaksi,	fgPengganti,	nomorFaktur,	tanggalFaktur,	npwpPenjual,	namaPenjual,	alamatPenjual,	npwpLawanTransaksi,	namaLawanTransaksi,	alamatLawanTransaksi,	jumlahDpp,	jumlahPpn,	jumlahPpnBm,	statusApproval,	statusFaktur,	nama,	hargaSatuan,	jumlahBarang,	hargaTotal,	diskon,	dpp,	ppn,	tarifPpnbm,	ppnbm,	ling,	no,masapajak,tahunpajak) " & _
                    "VALUES ('" & kdJenisTransaksi & "'" & _
       ",'" & fgPengganti & "'" & _
      ",'" & nomorFaktur & "'" & _
      ",'" & tanggalFaktur & "'" & _
      ",'" & npwpPenjual & "'" & _
      ",'" & namaPenjual & "'" & _
      ",'" & alamatPenjual & "'" & _
      ",'" & npwpLawanTransaksi & "'" & _
      ",'" & namaLawanTransaksi & "'" & _
      ",'" & alamatLawanTransaksi & "'" & _
      ",'" & jumlahDpp & "'" & _
      ",'" & jumlahPpn & "'" & _
      ",'" & jumlahPpnBm & "'" & _
      ",'" & statusApproval & "'" & _
      ",'" & statusFaktur & "'" & _
      ",'" & nama & "'" & _
      ",'" & hargaSatuan & "'" & _
      ",'" & jumlahBarang & "'" & _
      ",'" & hargaTotal & "'" & _
      ",'" & diskon & "'" & _
      ",'" & dpp & "'" & _
      ",'" & ppn & "'" & _
      ",'" & tarifPpnbm & "'" & _
      ",'" & ppnbm & "'" & _
      ",'" & ling & "'" & _
       ",'" & no & "'" & _
      ",'" & masapajak & "'" & _
      ",'" & tahunpajak & "') "
            MainModul.ExecQuery_Solomon(query)

        Catch ex As Exception
            Throw

        End Try
    End Sub


    Public Function getdatabarcode() As DataTable

        Try
            query = "select kdJenisTransaksi, fgPengganti,nomorFaktur,tanggalFaktur,npwpPenjual,namaPenjual,alamatPenjual,jumlahDpp,jumlahPpn,jumlahPpnBm,masapajak,tahunpajak from barcode_fp where tahunpajak='" & _tahunpajak & "' and masapajak='" & _masapajak & "'"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
End Class
