Public Class barcode_models
    Public Property alamatLawanTransaksi As String
    Public Property alamatPenjual As String
    Public Property diskon As String
    Public Property dpp As String
    Public Property fgPengganti As String
    Public Property hargaSatuan As String
    Public Property hargaTotal As String
    Public Property jumlahBarang As String
    Public Property jumlahDpp As String
    Public Property jumlahPpn As String
    Public Property jumlahPpnBm As String
    Public Property kdJenisTransaksi As String
    Public Property ling As String
    Public Property masapajak As String
    Public Property nama As String
    Public Property namaLawanTransaksi As String
    Public Property namaPenjual As String
    Public Property no As Short
    Public Property nomorFaktur As String
    Public Property npwpLawanTransaksi As String
    Public Property npwpPenjual As String
    Public Property ppn As String
    Public Property ppnbm As String
    Public Property statusApproval As String
    Public Property statusFaktur As String
    Public Property tahunpajak As String
    Public Property tanggalFaktur As String
    Public Property tarifPpnbm As String


    Public Function GetBarcodeByNoFaktur(ByVal NoFaktur As String) As DataTable
        Try
            Dim sql As String = "SELECT [kdJenisTransaksi]
                ,[fgPengganti]
                ,[nomorFaktur]
                ,[tanggalFaktur]
                ,[npwpPenjual]
                ,[namaPenjual]
                ,[alamatPenjual]
                ,[npwpLawanTransaksi]
                ,[namaLawanTransaksi]
                ,[alamatLawanTransaksi]
                ,[jumlahDpp]
                ,[jumlahPpn]
                ,[jumlahPpnBm]
                ,[statusApproval]
                ,[statusFaktur]
                ,[nama]
                ,[hargaSatuan]
                ,[jumlahBarang]
                ,[hargaTotal]
                ,[diskon]
                ,[dpp]
                ,[ppn]
                ,[tarifPpnbm]
                ,[ppnbm]
                ,[ling]
                ,[no]
                ,[masapajak]
                ,[tahunpajak]
                FROM [barcode_fp] WHERE RTRIM(nomorFaktur) = " & QVal(NoFaktur) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
