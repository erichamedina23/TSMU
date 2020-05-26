Imports System.Collections.ObjectModel
Public Class HancuranModel

    Public Property H_IDTransaksi() As String
    Public Property H_Tanggal() As Date
    Public Property H_StokAwal() As Int32
    Public Property H_Kirim() As Int32
    Public Property H_Kembali() As Int32
    Public Property H_Balance() As Int32
    Public Property H_Internal() As Int32
    Public Property H_Total() As Int32
    Public Property H_Target() As Int32
    Public Property IDTrans() As String


    Public Property HS_IDTransaksi() As String
    Public Property HS_Tanggal() As Date
    Public Property HS_StokPallet() As Int32
    Public Property HS_StokMix() As Int32
    Public Property HS_StokNG() As Int32
    Public Property HS_Target() As Int32
    Public Property HS_TotalOK() As Int32
    Public Property HS_TotalPagi() As Int32
    Public Property HS_IN() As Int32
    Public Property HS_OUT() As Int32
    Public Property HS_StokAhir() As Int32

    Dim _Query As String

    Public Property ObjDetailHancuran() As New Collection(Of HancuranDetailModel)


    Public Sub New()
        Me._Query = "SELECT [IDTransaksi]
                  ,[Tanggal]
                  ,[1. StokAwal] as [Stok Awal]
                  ,[2. Kirim] as Kirim
                  ,[3. Kembali] as Kembali
                  ,[4. Balance] as Balance
                  ,[5. Hancuran Internal] As [Hancuran Internal]
                  ,[6. Total] as Total
                  ,[7. Target] as Target
          FROM [AsakaiHancuranHeader] order by tanggal desc"
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


    Public Function GetDataLoad() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT [IDTransaksi]
                  ,convert(varchar,Tanggal,105) as Tanggal
                  ,[1. StokAwal] as [Stok Awal]
                  ,[2. Kirim] as Kirim
                  ,[3. Kembali] as Kembali
                  ,[4. Balance] as Balance
                  ,[5. Hancuran Internal] As [Hancuran Internal]
                  ,[6. Total] as Total
                  ,[7. Target] as Target
          FROM [AsakaiHancuranHeader] order By IDTransaksi Desc"
            'dt = GetDataTableByCommand(sql)
            dt = GetDataTableByCommand(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataLoad_HS() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT [IDTransaksi] as ID
              ,convert (varchar,Tanggal,105) AS TANGGAL
              ,[1. STOK GRI PROSES PALLET KG] AS [STOK PALLET]
              ,[2. STOK GRI PROSES MIX KG] AS [STOK MIX]
              ,[3. STOK GRI NG KG] AS [STOK NG]
              ,[4. TARGET] as TARGET
              ,[5. TOTAL HANCURAN OK] AS [TOTAL OK]
              ,[6. TOTAL HANCURAN PAGI] AS [TOTAL PAGI]
              ,[7. IN HANCURAN] AS MASUK
              ,[8. OUT HANCURAN] AS KELUAR
              ,[9. STOK AHIR] AS [STOK AHIR]
          FROM [AsakaiHancuranStok] order By IDTransaksi Desc"
            'dt = GetDataTableByCommand(sql)
            dt = GetDataTableByCommand(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllDataTable_HS(ByVal ls_Filter As String) As DataTable
        Try

            Dim dtTable As New DataTable
            Dim sql As String =
            "SELECT [IDTransaksi] as ID
              , convert (varchar,Tanggal,105) AS TANGGAL
              ,[1. STOK GRI PROSES PALLET KG] AS [STOK PALLET]
              ,[2. STOK GRI PROSES MIX KG] AS [STOK MIX]
              ,[3. STOK GRI NG KG] AS [STOK NG]
              ,[4. TARGET] as TARGET
              ,[5. TOTAL HANCURAN OK] AS [TOTAL OK]
              ,[6. TOTAL HANCURAN PAGI] AS [TOTAL PAGI]
              ,[7. IN HANCURAN] AS MASUK
              ,[8. OUT HANCURAN] AS KELUAR
              ,[9. STOK AHIR] AS [STOK AHIR]
          FROM [AsakaiHancuranStok] order by Tanggal desc"

            dtTable = MainModul.GetDataTableByCommand(sql)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub DeleteData_HS(ByVal ID As String)
        Try

            Dim ls_SP As String = "DELETE FROM AsakaiHancuranStok WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteData(ByVal ID As String)
        Try

            Dim ls_SP As String = "DELETE FROM AsakaiHancuranDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)

            Dim ls_SPD As String = "DELETE FROM AsakaiHancuranHeader WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SPD)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetData(ID As String)
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                      ,[Tanggal]
                                      ,[1. StokAwal] as stokawal
                                      ,[2. Kirim] as kirim
                                      ,[3. Kembali] as kembali
                                      ,[4. Balance] as balance
                                      ,[5. Hancuran Internal] as internal
                                      ,[6. Total] as total
                                      ,[7. Target] as target
                                  FROM AsakaiHancuranHeader  
                                    WHERE IDTransaksi = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    H_Tanggal = Trim(.Item("Tanggal") & "")
                    H_StokAwal = Trim(.Item("Internal") & "")
                    H_Kirim = Trim(.Item("Internal") & "")
                    H_Kembali = Trim(.Item("Internal") & "")
                    H_Balance = Trim(.Item("Internal") & "")
                    H_Internal = Trim(.Item("Internal") & "")
                    H_Target = Trim(.Item("Target") & "")
                    H_Total = Trim(.Item("Total") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub GetData_HS(ID As String)
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                      ,[Tanggal]
                                      ,[1. STOK GRI PROSES PALLET KG] as StokPallet
                                      ,[2. STOK GRI PROSES MIX KG] as StokMix
                                      ,[3. STOK GRI NG KG] as StokNG
                                      ,[4. TARGET] as Target
                                      ,[5. TOTAL HANCURAN OK] as OK
                                      ,[6. TOTAL HANCURAN PAGI] as Pagi
                                      ,[7. IN HANCURAN] as Masuk
                                      ,[8. OUT HANCURAN] as Keluar
                                      ,[9. STOK AHIR] as StokAhir
                                  FROM [AsakaiHancuranStok] 
                                    WHERE IDTransaksi = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    HS_IDTransaksi = Trim(.Item("IDTransaksi") & "")
                    HS_Tanggal = Trim(.Item("Tanggal") & "")
                    HS_StokPallet = Trim(.Item("StokPallet") & "")
                    HS_StokMix = Trim(.Item("StokMix") & "")
                    HS_StokNG = Trim(.Item("StokNG") & "")
                    HS_Target = Trim(.Item("Target") & "")
                    HS_TotalOK = Trim(.Item("OK") & "")
                    HS_TotalPagi = Trim(.Item("Pagi") & "")
                    HS_IN = Trim(.Item("Masuk") & "")
                    HS_OUT = Trim(.Item("Keluar") & "")
                    HS_StokAhir = Trim(.Item("StokAhir") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Function GetDataDetailHancuran(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Tanggal]
                                  ,[IDSupplier] AS [SUPPLIER]
                                  ,[StokAwal] AS [STOK AWAL]
                                  ,[Kirim] AS [KIRIM]
                                  ,[Kembali] AS [KEMBALI]
                                  ,[Balance] AS [BALANCE]
                              FROM [AsakaiHancuranDetail]
                                    WHERE [IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetIDTransAuto()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiHancuranHeader] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "HC" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "HC" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "HC" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "HC" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "HC" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "HC" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetIDTransAuto_HS()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiHancuranStok] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "HS" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "HS" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "HS" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "HS" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "HS" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "HS" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertData(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(IdTransaksi)
                        For i As Integer = 0 To ObjDetailHancuran.Count - 1
                            With ObjDetailHancuran(i)
                                .InsertDetail(IdTransaksi)
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

    Public Sub InsertHeader(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiHancuranHeader]
                                           ([IDTransaksi]
                                          ,[Tanggal]
                                           ,[1. StokAwal]
                                           ,[2. Kirim]
                                           ,[3. Kembali]
                                           ,[4. Balance]
                                           ,[5. Hancuran Internal]
                                           ,[6. Total]
                                           ,[7. Target]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(H_IDTransaksi) & " 
                                             ," & QVal(H_Tanggal) & "
                                             ," & QVal(H_StokAwal) & "
                                             ," & QVal(H_Kirim) & "
                                             ," & QVal(H_Kembali) & "
                                             ," & QVal(H_Balance) & "
                                             ," & QVal(H_Internal) & "
                                             ," & QVal(H_Total) & "
                                             ," & QVal(H_Target) & "
                                             ," & QVal(gh_Common.Username) & "
                                             ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
                                    FROM [AsakaiHancuranStok] where Tanggal = '" & H_Tanggal & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Format(Me.H_Tanggal, "dd-MM-yyyy") & "]")
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub ValidateInsertHancuran()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
                                    FROM [AsakaiHancuranHeader] where Tanggal = '" & H_Tanggal & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Format(Me.H_Tanggal, "dd-MM-yyyy") & "]")
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateData(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(IdTransaksi)
                        DeleteDetail(IdTransaksi)

                        For i As Integer = 0 To ObjDetailHancuran.Count - 1
                            With ObjDetailHancuran(i)
                                .InsertDetail(IdTransaksi)
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

    Public Sub UpdateHeader(ByVal _IDTrans As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiHancuranHeader" & vbCrLf &
                                    "SET Tanggal = " & QVal(H_Tanggal) & ", " & vbCrLf &
                                    "    [1. StokAwal] = " & QVal(H_StokAwal) & ", " & vbCrLf &
                                    "    [2. Kirim] = " & QVal(H_Kirim) & ", " & vbCrLf &
                                    "    [3. Kembali] = " & QVal(H_Kembali) & ", " & vbCrLf &
                                    "    [4. Balance]= " & QVal(H_Balance) & ", " & vbCrLf &
                                    "    [5. Hancuran Internal] = " & QVal(H_Internal) & ", " & vbCrLf &
                                    "    [6. Total] = " & QVal(H_Total) & ", " & vbCrLf &
                                    "    [7. Target] = " & QVal(H_Target) & ", " & vbCrLf &
                                    "    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiHancuranDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub




    Public Sub InsertData_HS(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        Insert_HS(IdTransaksi)

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

    Public Sub Insert_HS(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiHancuranStok]
                                           ([IDTransaksi]
                                          ,[Tanggal]
                                          ,[1. STOK GRI PROSES PALLET KG]
                                          ,[2. STOK GRI PROSES MIX KG]
                                          ,[3. STOK GRI NG KG]
                                          ,[4. TARGET]
                                          ,[5. TOTAL HANCURAN OK]
                                          ,[6. TOTAL HANCURAN PAGI]
                                          ,[7. IN HANCURAN]
                                          ,[8. OUT HANCURAN]
                                          ,[9. STOK AHIR]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(idTransaksi) & " 
                                             ," & QVal(HS_Tanggal) & "
                                             ," & QVal(HS_StokPallet) & "
                                             ," & QVal(HS_StokMix) & "
                                             ," & QVal(HS_StokNG) & "
                                             ," & QVal(HS_Target) & "
                                             ," & QVal(HS_TotalOK) & "
                                             ," & QVal(HS_TotalPagi) & "
                                             ," & QVal(HS_IN) & "
                                             ," & QVal(HS_OUT) & "
                                             ," & QVal(HS_StokAhir) & "
                                             ," & QVal(gh_Common.Username) & "
                                             ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateData_HS(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        Update_HS(IdTransaksi)

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

    Public Sub Update_HS(ByVal _IDTrans As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE [AsakaiHancuranStok]" & vbCrLf &
                                    "SET Tanggal = " & QVal(H_Tanggal) & ", " & vbCrLf &
                                    "    [1. STOK GRI PROSES PALLET KG] = " & QVal(HS_StokPallet) & ", " & vbCrLf &
                                    "    [2. STOK GRI PROSES MIX KG] = " & QVal(HS_StokMix) & ", " & vbCrLf &
                                    "    [3. STOK GRI NG KG] = " & QVal(HS_StokNG) & ", " & vbCrLf &
                                    "    [4. TARGET]= " & QVal(HS_Target) & ", " & vbCrLf &
                                    "    [5. TOTAL HANCURAN OK] = " & QVal(HS_TotalOK) & ", " & vbCrLf &
                                    "    [6. TOTAL HANCURAN PAGI] = " & QVal(HS_StokNG) & ", " & vbCrLf &
                                    "    [7. IN HANCURAN] = " & QVal(HS_IN) & ", " & vbCrLf &
                                    "    [8. OUT HANCURAN] = " & QVal(HS_OUT) & ", " & vbCrLf &
                                    "    [9. STOK AHIR] = " & QVal(HS_StokAhir) & ", " & vbCrLf &
                                    "    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

Public Class HancuranDetailModel

    Public Property D_IDTransaksi() As String
    Public Property D_Tanggal() As Date
    Public Property D_IDSupplier() As String
    Public Property D_Kirim() As Int32
    Public Property D_Kembali() As Int32
    Public Property D_StokAwal() As Int32
    Public Property D_Balance() As Int32


    Public Sub InsertDetail(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiHancuranDetail]
                   ([IDTransaksi]
                   ,[Tanggal]
                   ,[IDSupplier]
                   ,[StokAwal]
                   ,[Kirim]
                   ,[Kembali]
                   ,[Balance]) " & vbCrLf &
            "Values(" & QVal(D_IDTransaksi) & ", " & vbCrLf &
            "       " & QVal(D_Tanggal) & ", " & vbCrLf &
            "       " & QVal(D_IDSupplier) & ", " & vbCrLf &
            "       " & QVal(D_StokAwal) & ", " & vbCrLf &
            "       " & QVal(D_Kirim) & ", " & vbCrLf &
            "       " & QVal(D_Kembali) & ", " & vbCrLf &
            "       " & QVal(D_Balance) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
