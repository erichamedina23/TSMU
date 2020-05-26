Public Class TransferModel
    Public Property AcctID_Asal As String
    Public Property AcctID_tujuan As String
    Public Property CheckNo As String
    Public Property CurryID As String
    Public Property Descr_Asal As String
    Public Property Descr_tujuan As String
    Public Property Jumlah As Double
    Public Property NoBukti As String
    Public Property Perpost As String
    Public Property Remark As String
    Public Property Tgl As DateTime
    Public Property NoVouch As String
    Public Property CuryID_tujuan As String
    Public Property Rate_Solomon As String
    Public Property Rate_Transaksi As String
    Public Property Selisih_Kursi As Double


    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT Tgl
      ,NoBukti
      ,Perpost
      ,AcctID_Asal
      ,Descr_Asal
      ,CheckNo
      ,AcctID_tujuan
      ,Descr_tujuan
      ,CurryID
      ,Jumlah
      ,Remark
      ,CuryID_tujuan
      ,Rate_Solomon
      ,Rate_Transaksi
      ,Selisih_Kursi
  FROM banktransfer where NoBukti='" & NoBukti & "'"

        Dim ds As New dsLaporan2
        ds = GetDsReport2_Solomon(query, "banktransfer")
        Return ds

    End Function


    Public Function GetRate(VendorId) As String
        Try
            Dim dt As New DataTable
            Dim rate As String
            Dim sql As String =
                "Rate"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CuryID", SqlDbType.VarChar)
            pParam(0).Value = VendorId
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
            rate = dt.Rows(0).Item(1).ToString

            Return rate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insert()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [banktransfer]
           ([Tgl]
           ,[NoBukti]
           ,[Perpost]
           ,[AcctID_Asal]
           ,[Descr_Asal]
           ,[CheckNo]
           ,[AcctID_tujuan]
           ,[Descr_tujuan]
           ,[CurryID]
           ,[Jumlah]
           ,[Remark]
           ,[CuryID_tujuan]
           ,[Rate_Solomon]
           ,[Rate_Transaksi]
           ,[Selisih_Kursi])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID_Asal) & "
           ," & QVal(Descr_Asal) & "
           ," & QVal(CheckNo) & "
           ," & QVal(AcctID_tujuan) & "
           ," & QVal(Descr_tujuan) & "
           ," & QVal(CurryID) & "
           ," & QVal(Jumlah) & "
           ," & QVal(Remark) & "
           ," & QVal(CuryID_tujuan) & "
           ," & QVal(Rate_Solomon) & "
           ," & QVal(Rate_Transaksi) & "
           ," & QVal(Selisih_Kursi) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertToTable2()
        Try

            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If

            Dim ket As String = "Transfer"
            Dim sql As String =
            "INSERT INTO [cashbank2]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
            ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoVouch) & "
           ," & QVal(ket) & "
           ," & 0 & "
          ," & 0 & "
           ," & QVal(Jumlah) & "
           ," & 0 & "
           ," & 0 & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID_tujuan) & "
           ," & 0 & ")"
            MainModul.ExecQuery_Solomon(sql)



            Dim sql2 As String =
 "INSERT INTO [cashbank]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
            ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoVouch) & "
           ," & QVal(ket) & "
           ," & QVal(Remark) & "
           ," & 0 & "
          ," & 0 & "
           ," & QVal(Jumlah) & "
           ," & 0 & "
           ," & 0 & "
           ," & QVal(NoBukti) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID_tujuan) & "
           ," & 0 & ")"
            MainModul.ExecQuery_Solomon(sql2)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTable3()
        Try
            If CuryID_tujuan <> CurryID Then
                Jumlah = Jumlah * Rate_Solomon
            End If
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim ket As String = "Transfer"
            Dim sql As String =
            "INSERT INTO [cashbank2]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
            ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoVouch) & "
           ," & QVal(ket) & "
           ," & 0 & "
          ," & 0 & "
           ," & 0 & "
           ," & QVal(Jumlah) & "
           ," & 0 & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID_Asal) & "
           ," & 0 & ")"
            MainModul.ExecQuery_Solomon(sql)

            Dim sql2 As String =
 "INSERT INTO [cashbank]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
            ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoVouch) & "
           ," & QVal(ket) & "
           ," & QVal(Remark) & "
           ," & 0 & "
          ," & 0 & "
           ," & 0 & "
           ," & QVal(Jumlah) & "
           ," & 0 & "
           ," & QVal(NoBukti) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID_Asal) & "
           ," & 0 & ")"
            MainModul.ExecQuery_Solomon(sql2)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function autononb() As String
        Try
            Dim auto2 As String
            Dim sql As String = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(nobukti)),4)+1 as varchar),4) " &
                "from cashbank " &
                "where SUBSTRING(nobukti,4,4) = RIGHT(@tahun,4) AND SUBSTRING(nobukti,9,2) = RIGHT(@bulan,2)) " &
                "select 'VC' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            auto2 = dt.Rows(0).Item(0).ToString
            Return auto2

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT [Tgl]
      ,[NoBukti]
      ,[Perpost]
      ,[AcctID_Asal]
      ,[Descr_Asal]
      ,[CheckNo]
      ,[AcctID_tujuan]
      ,[Descr_tujuan]
      ,[CurryID]
      ,[Jumlah]
      ,[Remark]
  FROM [banktransfer] "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TransferAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(NoBukti)),4)+1 as varchar),4) " &
                "from banktransfer " &
                "where SUBSTRING(NoBukti,1,7) = 'TR' + '-' + RIGHT(@tahun,4) AND SUBSTRING(NoBukti,9,2) = RIGHT(@bulan,2)) " &
                "select 'TR' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Sub Update()
        Try
            Dim ls_SP As String = ""
            ls_SP = "update banktransfer SET Tgl= " & QVal(Tgl) & ", " &
                                          " Perpost= " & QVal(Perpost) & ", " &
                                          " AcctID_Asal= " & QVal(AcctID_Asal) & ", " &
                                          " Descr_Asal= " & QVal(Descr_Asal) & ", " &
                                          " CheckNo= " & QVal(CheckNo) & ", " &
                                          " AcctID_tujuan= " & QVal(AcctID_tujuan) & ", " &
                                          " Descr_tujuan= " & QVal(Descr_tujuan) & ", " &
                                          " CurryID= " & QVal(CurryID) & ", " &
                                          " Jumlah= " & QVal(Jumlah) & ", " &
                                          " Remark= " & QVal(Remark) & " WHERE NoBukti = " & QVal(NoBukti) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select * from banktransfer where NoBukti = " & QVal(ID) & " order by NoBukti"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Tgl = Trim(.Item("Tgl") & "")
                    NoBukti = Trim(.Item("NoBukti") & "")
                    Perpost = Trim(.Item("Perpost") & "")
                    AcctID_Asal = Trim(.Item("AcctID_Asal") & "")
                    Descr_Asal = Trim(.Item("Descr_Asal") & "")
                    CheckNo = Trim(.Item("CheckNo") & "")
                    AcctID_tujuan = Trim(.Item("AcctID_tujuan") & "")
                    Descr_tujuan = Trim(.Item("Descr_tujuan") & "")
                    CurryID = Trim(.Item("CurryID") & "")
                    Jumlah = Trim(.Item("Jumlah") & "")
                    Remark = Trim(.Item("Remark") & "")
                    CuryID_tujuan = Trim(.Item("CuryID_tujuan") & "")
                    Rate_Transaksi = Trim(.Item("Rate_Transaksi") & "")
                    Rate_Solomon = Trim(.Item("Rate_Solomon") & "")
                    Selisih_Kursi = Trim(.Item("Selisih_Kursi") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetNamaAccountbyid() As String
        Try
            Dim namaaccount As String
            Dim sql As String = "SELECT 
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account WHERE Acct = " & QVal(AcctID_Asal) & ""

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            namaaccount = dt.Rows(0).Item(0).ToString
            Return namaaccount

        Catch ex As Exception
            Throw

        End Try
    End Function
End Class
