Imports System.Collections.ObjectModel
Public Class ReportAbsenModel
    Public Property IDAbsen As String
    Public Property Description As String
    Public Property CreatedBy As String
    Public Property CreatedDate As DateTime
    Public Property TglFrom As Date
    Public Property TglTo As Date


    Public Property ObjDetails() As New Collection(Of SuspendDetailModel)



    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT IDAbsen
      ,Description
      ,CreatedBy
      ,CreatedDate
        FROM KategoriAbsen"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "KategoriAbsen")
        Return ds

    End Function

    Public Function LoadMaterialUsageReportPertanggal(_tglfrom As String, tglto As String) As DataSet
        Dim query As String
        query = "SELECT AsakaiPemakaianMaterialKomponen.IDTrans
      ,TanggalDari
      ,TanggalSampai
      ,Keterangan
      ,AktualRP
      ,Sales
      ,Percent1
      ,AktualProduksi
      ,Persent2
      ,Target
        FROM AsakaiPemakaianMaterialKomponen 
        inner join AsakaiPemakaianMaterial on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianMaterial.IDTrans 
        where (TanggalDari) >= '" & (_tglfrom) & "' and (TanggalDari) <= '" & (tglto) & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "PemakaianMaterial")
        Return ds


    End Function

    Public Function LoadMaterialUsageReportPertanggalKomponen(_tglfrom As String, tglto As String) As DataSet
        Dim query As String
        query = "SELECT AsakaiPemakaianMaterialKomponen.IDTrans
      ,TanggalDari
      ,TanggalSampai
      ,Keterangan
      ,AktualRP
      ,Sales
      ,Percent1
      ,AktualProduksi
      ,Persent2
      ,Target
        FROM AsakaiPemakaianMaterialKomponen 
        inner join AsakaiPemakaianKomponen on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianKomponen.IDTrans 
        where (TanggalDari) >= '" & (_tglfrom) & "' and (TanggalDari) <= '" & (tglto) & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "PemakaianKomponen")
        Return ds


    End Function

    Public Function LoadMaterialUsageReport() As DataSet
        Dim query As String
        query = "SELECT AsakaiPemakaianMaterialKomponen.IDTrans
      ,TanggalDari
      ,TanggalSampai
      ,Keterangan
      ,AktualRP
      ,Sales
      ,Percent1
      ,AktualProduksi
      ,Persent2
      ,Target
        FROM AsakaiPemakaianMaterialKomponen 
        inner join AsakaiPemakaianMaterial on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianMaterial.IDTrans "

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "PemakaianMaterial")
        Return ds

    End Function
    Public Function LoadKomponenUsageReport() As DataSet
        Dim query As String
        query = "SELECT AsakaiPemakaianMaterialKomponen.IDTrans
      ,TanggalDari
      ,TanggalSampai
      ,Keterangan
      ,AktualRP
      ,Sales
      ,Percent1
      ,AktualProduksi
      ,Persent2
      ,Target
        FROM AsakaiPemakaianMaterialKomponen 
        inner join AsakaiPemakaianKomponen on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianKomponen.IDTrans "

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "PemakaianKomponen")
        Return ds

    End Function

End Class
