Public Class ReceiptModel
    Public Property AcctID_tujuan As String
    Public Property AcctID As String
    Public Property AcctID_Name As String
    Public Property CheckNo As String
    Public Property CurryID As String
    Public Property Descr_tujuan As String
    Public Property Jumlah As Double
    Public Property NoBukti As String
    Public Property Perpost As String
    Public Property Remark As String
    Public Property Tgl As DateTime
    Public Property NoVouch As String
    Public Property CustID As String
    Public Property Customer As String

    Public Sub Insert()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [bankreceipt]
           ([Tgl]
           ,[NoBukti]
           ,[Perpost]
           ,[CheckNo]
           ,[AcctID_tujuan]
           ,[Descr_tujuan]
           ,[CurryID]
           ,[Jumlah]
            ,[CustID]
            ,[Customer]
            ,[AcctID]
           ,[AcctID_Name]
           ,[Remark])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Perpost) & "
           ," & QVal(CheckNo) & "
           ," & QVal(AcctID_tujuan) & "
           ," & QVal(Descr_tujuan) & "
           ," & QVal(CurryID) & "
           ," & QVal(Jumlah) & "
           ," & QVal(CustID) & "
           ," & QVal(Customer) & "
           ," & QVal(AcctID) & "
           ," & QVal(AcctID_Name) & "
           ," & QVal(Remark) & ")"
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


            Dim ket As String = "Receipt"
            Dim Customer2 As String = ""
            If String.IsNullOrEmpty(Customer) Then
                Customer2 = ""
            Else
                Customer2 = Customer
            End If
            Remark = Remark + Customer2
            Dim sql As String =
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
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTable3()
        Try

            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim ket As String = "Receipt"
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
      ,[CheckNo]
      ,[AcctID_tujuan]
      ,[Descr_tujuan]
      ,[CurryID]
      ,[Jumlah]
      ,[Remark]
      ,[CustID]
      ,[Customer]
  FROM [bankreceipt] "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function receiptAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(NoBukti)),4)+1 as varchar),4) " &
                "from bankreceipt " &
                "where SUBSTRING(NoBukti,1,7) = 'RV' + '-' + RIGHT(@tahun,4) AND SUBSTRING(NoBukti,9,2) = RIGHT(@bulan,2)) " &
                "select 'RV' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

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
            ls_SP = "update bankreceipt SET Tgl= " & QVal(Tgl) & ", " &
                                          " Perpost= " & QVal(Perpost) & ", " &
                                          " CheckNo= " & QVal(CheckNo) & ", " &
                                          " AcctID_tujuan= " & QVal(AcctID_tujuan) & ", " &
                                          " Descr_tujuan= " & QVal(Descr_tujuan) & ", " &
                                          " CurryID= " & QVal(CurryID) & ", " &
                                          " Jumlah= " & QVal(Jumlah) & ", " &
                                          " CustID= " & QVal(CustID) & ", " &
                                          " Customer= " & QVal(Customer) & ", " &
                                          " AcctID= " & QVal(AcctID) & ", " &
                                          " AcctID_Name= " & QVal(AcctID_Name) & ", " &
                                          " Remark= " & QVal(Remark) & " WHERE NoBukti = " & QVal(NoBukti) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select * from bankreceipt where NoBukti = " & QVal(ID) & " order by NoBukti"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Tgl = Trim(.Item("Tgl") & "")
                    NoBukti = Trim(.Item("NoBukti") & "")
                    Perpost = Trim(.Item("Perpost") & "")
                    CheckNo = Trim(.Item("CheckNo") & "")
                    AcctID_tujuan = Trim(.Item("AcctID_tujuan") & "")
                    Descr_tujuan = Trim(.Item("Descr_tujuan") & "")
                    CurryID = Trim(.Item("CurryID") & "")
                    CustID = Trim(.Item("CustID") & "")
                    Customer = Trim(.Item("Customer") & "")
                    Jumlah = Trim(.Item("Jumlah") & "")
                    AcctID = Trim(.Item("AcctID") & "")
                    AcctID_Name = Trim(.Item("AcctID_Name") & "")
                    Remark = Trim(.Item("Remark") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class
