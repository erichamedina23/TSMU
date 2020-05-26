Imports System.Collections.ObjectModel

Public Class PemakaianPaintingModel

    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String
    'Tahun = Format(Now, "yy")

    'Header
    Public Property HeadAktualLiter As Double
    Public Property HeadTotalLiter As Double
    Public Property HeadAktualRP As Double
    Public Property HeadAkumulasiLiterSebelumnya As Double
    Public Property HeadAkumulasiRpSebelumnya As Double
    Public Property HeadCreatedBy As String
    Public Property HeadCreatedDate As DateTime
    Public Property HeadKeterangan As String
    Public Property HeadTotalMasuk As Double
    Public Property HeadOutNonProduksi As Double
    Public Property HeadPercentPainting As Double
    Public Property HeadPercentSales As Double
    Public Property HeadPercentTarget As Double
    Public Property HeadPercentAll As Double
    Public Property HeadProduksiInjection As Double
    Public Property HeadProduksiPaint As Double
    Public Property HeadSales As Double
    Public Property HeadStokAwal As Double
    Public Property HeadTanggalDari As Date
    Public Property HeadTanggalSampai As Date
    Public Property HeadTotalOut As Double
    Public Property HeadTotalPemakaian As Double
    Public Property HeadTotalProduksi As Double
    Public Property HeadTotalRP As double
    Public Property HeadTotalStokAkhirHeader As Double
    Public Property HeadTotalStokAwalHeader As Double
    Public Property HeadUpdatedBy As String
    Public Property HeadUpdatedDate As DateTime
    Public SummaryPemakaianRP As Double = 0
    Public SummaryPemakaianLiter As Double = 0


    'Detail

    Public Property Harga As Double
    Public Property IDTrans As String
    Public Property invtId As String
    Public Property Masuk As Double
    Public Property Pemakaian As Double
    Public Property PemakaianNonProduksi As Double
    Public Property StokAkhirTNG02 As Double
    Public Property StokAkhirTNG04 As Double
    Public Property StokAkhirTNG04Pecah As Double
    Public Property StokAkhirTNG04Utuh As Double
    Public Property StokAwalTNG02 As Double
    Public Property StokAwalTNG02Konversi As Double
    Public Property StokAwalTNG04BelumKonversi As Double
    Public Property TotalRP As Double
    Public Property TotalStokAkhir As Double
    Public Property TotalStokawal As Double
    Public Property TotalStokTNG04 As Double


    Public Property ObjDetailPainting() As New Collection(Of PemakaianPaintinglDetailModel)


    Public Sub New()
        Me._Query = "SELECT IDTrans,CONVERT(varchar,tanggaldari,105) as TanggalDari,CONVERT(varchar,TanggalSampai,105) as TanggalSampai, Keterangan from AsakaiPemakaianPainting order by IDTrans Desc"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Function GetSumaryPemakaian() As DataTable
        Try
            Dim query As String = "SELECT 
                                   IDTrans,TanggalDari,[1.AktualRP] as AktualRp ,[10.AktualLiter] as AktualLiter From AsakaiPemakaianPainting Where datepart(year, TanggalDari) = '" & tahun & "' AND datepart(month, TanggalDari) = '" & bulan & "' AND datepart(day, TanggalDari) < '" & tanggal & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            'SummaryPemakaian = Convert.ToDouble(dtTable.Compute("SUM(TotalPemakaian)", "IDTrans > 2"))
            Dim hitungRp As Double = 0
            Dim HitungLiter As Double = 0

            For a As Integer = 0 To dtTable.Rows.Count - 1
                hitungRp = (hitungRp + dtTable.Rows(a).Item("AktualRp"))
                HitungLiter = (HitungLiter + dtTable.Rows(a).Item("AktualLiter"))
            Next
            SummaryPemakaianRP = hitungRp
            SummaryPemakaianLiter = HitungLiter

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT AsakaiPemakaianPainting.IDTrans    
                                    ,AsakaiPemakaianPainting.TanggalDari
                                    ,AsakaiPemakaianPainting.TanggalSampai
                                    ,AsakaiPemakaianPainting.Keterangan
                                    ,AsakaiPemakaianPainting.StokAwal
                                    ,AsakaiPemakaianPainting.Masuk
                                    ,AsakaiPemakaianPainting.TotalStokAwal
                                    ,AsakaiPemakaianPainting.TotalStokAkhir
                                    ,AsakaiPemakaianPainting.OutNonProduksi
                                    ,AsakaiPemakaianPainting.TotalPemakaian
                                    ,AsakaiPemakaianPainting.TotalRP
                                    ,AsakaiPemakaianPainting.AkumulasiRpSebelumnya
                                    ,AsakaiPemakaianPainting.AkumulasiLiterSebelumnya
                                    ,AsakaiPemakaianPainting.[1.AktualRP] as AktualRP
                                    ,AsakaiPemakaianPainting.[2.Sales] as Sales
                                    ,AsakaiPemakaianPainting.[3.% Sales] as PercentSales
                                    ,AsakaiPemakaianPainting.TotalLiter
                                    ,AsakaiPemakaianPainting.[10.AktualLiter] as AktualLiter
                                    ,AsakaiPemakaianPainting.[8.ProduksiPaint] as ProduksiPaint
                                    ,AsakaiPemakaianPainting.[9.ProduksiInjection] as ProduksiInjection
                                    ,AsakaiPemakaianPainting.[4.TotalProduksi] as TotalProduksi
                                   ,AsakaiPemakaianPainting.[5.Percent All] as PercentAll
                                   ,AsakaiPemakaianPainting.[7.PercentTarget] as PercentTarget
                                   ,AsakaiPemakaianPainting.[6.Percent Painting] as PercentPainting
                                    FROM AsakaiPemakaianPainting WHERE AsakaiPemakaianPainting.IDTrans = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDTrans = Trim(.Item(0) & "")
                    Me.HeadTanggalDari = Trim(.Item(1) & "")
                    Me.HeadTanggalSampai = Trim(.Item(2) & "")
                    Me.HeadAktualRP = Trim(.Item("AktualRP") & "")
                    Me.HeadTotalRP = Trim(.Item("TotalRP") & "")
                    Me.HeadAkumulasiRpSebelumnya = Trim(.Item("AkumulasiRpSebelumnya") & "")
                    Me.HeadSales = Trim(.Item("Sales") & "")
                    Me.HeadPercentSales = Trim(.Item("PercentSales") & "")
                    Me.HeadTotalLiter = Trim(.Item("TotalLiter") & "")
                    Me.HeadAkumulasiLiterSebelumnya = Trim(.Item("AkumulasiLiterSebelumnya") & "")
                    Me.HeadAktualLiter = Trim(.Item("AktualLiter") & "")
                    Me.HeadProduksiInjection = Trim(.Item("ProduksiInjection") & "")
                    Me.HeadProduksiPaint = Trim(.Item("ProduksiPaint") & "")
                    Me.HeadTotalProduksi = Trim(.Item("TotalProduksi") & "")
                    Me.HeadPercentAll = Trim(.Item("PercentAll") & "")
                    Me.HeadPercentTarget = Trim(.Item("PercentTarget") & "")
                    Me.HeadPercentPainting = Trim(.Item("PercentPainting") & "")

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataDetailPainting(ID As String) As DataTable
        Try
            Dim query As String = "SELECT 
                                    AsakaiPaintingDetail.invtId as InvtID
                                    ,Inventory.Descr as Material
                                    ,AsakaiPaintingDetail.StokAwalTNG02 as StockAwal02
                                    ,AsakaiPaintingDetail.StokAwalTNG04Konversi as StockAwal04
                                    ,AsakaiPaintingDetail.StokAwalTNG04BelumKonversi as StockAwal04Blm
                                    ,AsakaiPaintingDetail.Masuk as Masuk
                                    ,AsakaiPaintingDetail.TotalStokawal as TotalStokAwal
                                    ,AsakaiPaintingDetail.StokAkhirTNG02 as StockAkhir02
                                    ,AsakaiPaintingDetail.StokAkhirTNG04 as StockAkhir04
                                    ,AsakaiPaintingDetail.StokAkhirTNG04Utuh as StockAkhir04UTUH
                                    ,AsakaiPaintingDetail.StokAkhirTNG04Pecah as StockAkhir04Pecahan
                                    ,AsakaiPaintingDetail.TotalStokTNG04 as TotalStokAhir4
                                    ,AsakaiPaintingDetail.TotalStokAkhir as TotalStokAkhir
                                    ,AsakaiPaintingDetail.PemakaianNonProduksi as PemakaianNonProduksi
                                    ,AsakaiPaintingDetail.Pemakaian as Pemakaian
                                    ,AsakaiPaintingDetail.Harga as Harga
                                    ,AsakaiPaintingDetail.TotalRP as Amount
                                    FROM AsakaiPaintingDetail Left join Inventory on AsakaiPaintingDetail.invtId =Inventory.InvtID where AsakaiPaintingDetail.IDTrans  = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTrans],TanggalSampai                   
                                    FROM [AsakaiPemakaianPainting] where IDTrans = '" & IDTrans & "' or TanggalSampai >= '" & HeadTanggalSampai & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.IDTrans & "]")

            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetIDTransAuto()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT [IDTrans]                   
                                    FROM [AsakaiPemakaianPainting] order by IDTrans desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "P" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTrans")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 2, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "P" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTrans")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 4, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "P" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "P" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "P" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "P" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Function



#Region "CRUD"


    Public Sub InsertPainting()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader()
                        For i As Integer = 0 To ObjDetailPainting.Count - 1
                            With ObjDetailPainting(i)
                                .InsertAbsenDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(IDTrans)
                        DeleteDetail(IDTrans)

                        For i As Integer = 0 To ObjDetailPainting.Count - 1
                            With ObjDetailPainting(i)
                                .InsertAbsenDetails()
                            End With
                        Next



                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub InsertHeader()
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiPemakaianPainting]
                                           ([IDTrans]
                                           ,[TanggalDari]
                                           ,[TanggalSampai]
                                           ,[Keterangan]
                                           ,[Masuk]
                                           ,[TotalStokAwal]
                                           ,[TotalStokAkhir]
                                           ,[OutNonProduksi]
                                           ,[TotalPemakaian]
                                           ,[TotalRP]
                                           ,[AkumulasiRpSebelumnya]
                                           ,[TotalLiter]
                                           ,[AkumulasiLiterSebelumnya]
                                           ,[1.AktualRP]
                                           ,[2.Sales]
                                           ,[3.% Sales]
                                           ,[10.AktualLiter]
                                           ,[8.ProduksiPaint]
                                           ,[9.ProduksiInjection]
                                           ,[4.TotalProduksi]
                                           ,[5.Percent All]
                                           ,[7.PercentTarget]
                                           ,[6.Percent Painting]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(IDTrans) & " 
                                            ," & QVal(HeadTanggalDari) & "
                                            ," & QVal(HeadTanggalSampai) & "
                                            ," & QVal(HeadKeterangan) & "
                                            ," & QVal(HeadTotalMasuk) & "
                                            ," & QVal(HeadTotalStokAwalHeader) & "
                                            ," & QVal(HeadTotalStokAkhirHeader) & "
                                            ," & QVal(HeadOutNonProduksi) & "
                                            ," & QVal(HeadTotalPemakaian) & "
                                            ," & QVal(HeadTotalRP) & "
                                            ," & QVal(HeadAkumulasiRpSebelumnya) & "
                                            ," & QVal(HeadTotalLiter) & "
                                            ," & QVal(HeadAkumulasiLiterSebelumnya) & "
                                            ," & QVal(HeadAktualRP) & "
                                            ," & QVal(HeadSales) & "
                                            ," & QVal(HeadPercentSales) & "
                                            ," & QVal(HeadAktualLiter) & "
                                            ," & QVal(HeadProduksiPaint) & "
                                            ," & QVal(HeadProduksiInjection) & "
                                            ," & QVal(HeadTotalProduksi) & "
                                            ," & QVal(HeadPercentAll) & "
                                            ," & QVal(HeadPercentTarget) & "
                                            ," & QVal(HeadPercentPainting) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiPemakaianPainting WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiPaintingDetail WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiPaintingDetail WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateHeader(ByVal _IDMaterialUsage As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiPemakaianPainting" & vbCrLf &
                                    "SET TanggalDari = " & QVal(HeadTanggalDari) & ", " & vbCrLf &
                                    "    TanggalSampai = " & QVal(HeadTanggalSampai) & ", " & vbCrLf &
                                    "    Keterangan = " & QVal(HeadKeterangan) & ", " & vbCrLf &
                                    "    StokAwal = " & QVal(HeadStokAwal) & ", " & vbCrLf &
                                    "    Masuk = " & QVal(HeadTotalMasuk) & ", " & vbCrLf &
                                    "    TotalStokAwal = " & QVal(HeadTotalStokAwalHeader) & ", " & vbCrLf &
                                    "    TotalStokAkhir = " & QVal(HeadTotalStokAkhirHeader) & ", " & vbCrLf &
                                    "    OutNonProduksi = " & QVal(HeadOutNonProduksi) & ", " & vbCrLf &
                                    "    TotalPemakaian = " & QVal(HeadTotalPemakaian) & ", " & vbCrLf &
                                    "    TotalRP = " & QVal(HeadTotalRP) & ", " & vbCrLf &
                                    "    AkumulasiRpSebelumnya = " & QVal(HeadAkumulasiRpSebelumnya) & ", " & vbCrLf &
                                    "    TotalLiter = " & QVal(HeadTotalLiter) & ", " & vbCrLf &
                                    "    AkumulasiLiterSebelumnya = " & QVal(HeadAkumulasiLiterSebelumnya) & ", " & vbCrLf &
                                    "    [1.AktualRP] = " & QVal(HeadAktualRP) & ", " & vbCrLf &
                                    "    [2.Sales] = " & QVal(HeadSales) & ", " & vbCrLf &
                                    "    [3.% Sales] = " & QVal(HeadPercentSales) & ", " & vbCrLf &
                                    "    [10.AktualLiter] = " & QVal(HeadAktualLiter) & ", " & vbCrLf &
                                    "    [8.ProduksiPaint] = " & QVal(HeadProduksiPaint) & ", " & vbCrLf &
                                    "    [9.ProduksiInjection] = " & QVal(HeadProduksiInjection) & ", " & vbCrLf &
                                    "    [4.TotalProduksi] = " & QVal(HeadTotalProduksi) & ", " & vbCrLf &
                                    "    [5.Percent All] = " & QVal(HeadPercentAll) & ", " & vbCrLf &
                                    "    [7.PercentTarget] = " & QVal(HeadPercentTarget) & ", " & vbCrLf &
                                    "    [6.Percent Painting] = " & QVal(HeadPercentPainting) & ", " & vbCrLf &
                                    "    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTrans = '" & _IDMaterialUsage & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region







End Class



''''Detail

Public Class PemakaianPaintinglDetailModel

    Dim _Query As String

    Public Property Harga As Double
    Public Property IDTrans As String
    Public Property invtId As String
    Public Property Masuk As Double
    Public Property Pemakaian As Double
    Public Property PemakaianNonProduksi As Double
    Public Property StokAkhirTNG02 As Double
    Public Property StokAkhirTNG04 As Double
    Public Property StokAkhirTNG04Pecah As Double
    Public Property StokAkhirTNG04Utuh As Double
    Public Property StokAwalTNG02 As Double
    Public Property StokAwalTNG02Konversi As Double
    Public Property StokAwalTNG04 As Double
    Public Property StokAwalTNG04BelumKonversi As Double

    Public Property TotalRP As Double
    Public Property TotalStokAkhir As Double
    Public Property TotalStokawal As Double
    Public Property TotalStokTNG04 As Double

    Public Sub InsertAbsenDetails()
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO AsakaiPaintingDetail
                        ([IDTrans]
                       ,[invtId]
                       ,[StokAwalTNG02]
                       ,[StokAwalTNG04Konversi]
                       ,[StokAwalTNG04BelumKonversi]
                       ,[Masuk]
                       ,[TotalStokawal]
                       ,[StokAkhirTNG02]
                       ,[StokAkhirTNG04]
                       ,[StokAkhirTNG04Utuh]
                       ,[StokAkhirTNG04Pecah]
                       ,[TotalStokTNG04]
                       ,[TotalStokAkhir]
                       ,[PemakaianNonProduksi]
                       ,[Pemakaian]
                       ,[Harga]
                       ,[TotalRP]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(invtId) & ", " & vbCrLf &
            "       " & QVal(StokAwalTNG02) & ", " & vbCrLf &
            "       " & QVal(StokAwalTNG02Konversi) & ", " & vbCrLf &
            "       " & QVal(StokAwalTNG04BelumKonversi) & ", " & vbCrLf &
            "       " & QVal(Masuk) & ", " & vbCrLf &
            "       " & QVal(TotalStokawal) & ", " & vbCrLf &
            "       " & QVal(StokAkhirTNG02) & ", " & vbCrLf &
            "       " & QVal(StokAkhirTNG04) & ", " & vbCrLf &
            "       " & QVal(StokAkhirTNG04Utuh) & ", " & vbCrLf &
            "       " & QVal(StokAkhirTNG04Pecah) & ", " & vbCrLf &
            "       " & QVal(TotalStokTNG04) & ", " & vbCrLf &
            "       " & QVal(TotalStokAkhir) & ", " & vbCrLf &
            "       " & QVal(PemakaianNonProduksi) & ", " & vbCrLf &
            "       " & QVal(Pemakaian) & ", " & vbCrLf &
            "       " & QVal(Harga) & ", " & vbCrLf &
            "       " & QVal(TotalRP) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub



End Class

