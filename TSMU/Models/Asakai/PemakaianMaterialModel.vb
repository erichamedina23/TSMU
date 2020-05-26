Imports System.Collections.ObjectModel
Public Class PemakaianMaterialModel

    Dim _Query As String

    'Header
    Public Property IDTrans As String
    Public Property TanggalDari() As Date
    Public Property TanggalSampai() As Date
    Public Property Keterangan As String
    Public Property KolomQty As String
    Public Property KolomHarga As String
    Public Property KolomHargacek As String

    Public Property Sales() As Double
    Public Property AktualProduksi() As Double




    'Material

    Public Property MaterialAktualRP() As Double
    Public Property MaterialPercent1() As Double
    Public Property MaterialPercent2() As Double
    Public Property MaterialTarget() As Double

    'Komponen
    Public Property KomponenAktualRP() As Double
    Public Property KomponenPercent1() As Double
    Public Property KomponenPercent2() As Double
    Public Property KomponenTarget() As Double

    'Detail
    Public Property MaterialInvtId() As String
    Public Property MaterialJumlah() As Double
    Public Property MaterialHarga() As Double
    Public Property MaterialTotal() As Double

    Public Property KomponenInvtId() As String
    Public Property KomponenJumlah() As Double
    Public Property KomponenHarga() As Double
    Public Property KomponenTotal() As Double

    Public Property ObjDetailsMaterial() As New Collection(Of PemakaianMaterialDetail)
    Public Property ObjDetailsKomponen() As New Collection(Of PemakaianKomponenlDetail)

    Public Sub New()
        Me._Query = "SELECT IDTrans,CONVERT(varchar,tanggaldari,105) as TanggalDari,CONVERT(varchar,TanggalSampai,105) as TanggalSampai,Keterangan from AsakaiPemakaianMaterialKomponen order by IDTrans Desc "
        'Me._Query = "SELECT IDMaterialUsage[,Tanggal,TotalMaterial,Sales,Percent1[% Material],TotakAktualProduksi,Persent2[% Injection],Target[% Target] from AsakaiMaterialUsageHeader"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(Me._Query)
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT AsakaiPemakaianMaterialKomponen.IDTrans    
                                    ,AsakaiPemakaianMaterialKomponen.TanggalDari
                                    ,AsakaiPemakaianMaterialKomponen.TanggalSampai
                                    ,AsakaiPemakaianMaterialKomponen.Keterangan
                                    ,AsakaiPemakaianMaterial.[1.AktualRP]
                                    ,AsakaiPemakaianMaterial.[2.Sales]
                                    ,AsakaiPemakaianMaterial.[3.% Sales]
                                    ,AsakaiPemakaianMaterial.[4.AktualProduksi]
                                    ,AsakaiPemakaianMaterial.[5. % Inj ]
                                    ,AsakaiPemakaianMaterial.[6.Target]
                                    ,AsakaiPemakaianKomponen.[1.AktualRP]
                                    ,AsakaiPemakaianKomponen.[2.Sales]
                                    ,AsakaiPemakaianKomponen.[3.% Sales]
                                    ,AsakaiPemakaianKomponen.[4.AktualProduksi]
                                    ,AsakaiPemakaianKomponen.[5. % Inj ]
                                    ,AsakaiPemakaianKomponen.[6.Target]
                                    ,AsakaiPemakaianMaterialKomponen.KolomQty
                                    ,AsakaiPemakaianMaterialKomponen.KolomHarga
                                    FROM AsakaiPemakaianMaterialKomponen inner join AsakaiPemakaianMaterial on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianMaterial.IDTrans
                                    inner join AsakaiPemakaianKomponen on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianKomponen.IDTrans WHERE AsakaiPemakaianMaterialKomponen.IDTrans = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDTrans = Trim(.Item(0) & "")
                    Me.TanggalDari = Trim(.Item(1) & "")
                    Me.TanggalSampai = Trim(.Item(2) & "")
                    Me.Keterangan = Trim(.Item(3) & "")
                    Me.MaterialAktualRP = Trim(.Item(4) & "")
                    Me.Sales = Trim(.Item(5) & "")
                    Me.MaterialPercent1 = Trim(.Item(6) & "")
                    Me.AktualProduksi = Trim(.Item(7) & "")
                    Me.MaterialPercent2 = Trim(.Item(8) & "")
                    Me.MaterialTarget = Trim(.Item(9) & "")
                    Me.KomponenAktualRP = Trim(.Item(10) & "")
                    Me.KomponenPercent1 = Trim(.Item(12) & "")
                    Me.KomponenPercent2 = Trim(.Item(14) & "")
                    Me.KomponenTarget = Trim(.Item(15) & "")
                    Me.KolomQty = Trim(.Item(16) & "")
                    Me.KolomHarga = Trim(.Item(17) & "")
                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTrans],TanggalSampai,TanggalDari                  
                                    FROM [AsakaiPemakaianMaterialKomponen] where Tanggaldari = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.TanggalDari & "]")
            Else
                ' Dim ls_SP1 As String = "SELECT TOP 1 [IDTrans],KolomHarga                   
                '                      FROM [AsakaiPemakaianMaterialKomponen] where KolomHarga = '" & KolomHarga & "' "
                ' Dim dtTable1 As New DataTable
                ' dtTable1 = MainModul.GetDataTableByCommand(ls_SP1)
                ' If dtTable1 IsNot Nothing AndAlso dtTable1.Rows.Count > 0 Then
                '     Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                '"[" & Me.KolomHarga & "]")
                ' Else

                ' End If
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
                                    FROM [AsakaiPemakaianMaterialKomponen] order by IDTrans desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "M" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTrans")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 2, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "M" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTrans")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 4, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "M" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "M" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "M" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "M" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataDetailMaterial(ID As String) As DataTable
        Try
            Dim query As String = "SELECT 
                                    AsakaiPemakaianMaterialDetail.IDMaterial
                                    ,Inventory.Descr
                                    ,AsakaiPemakaianMaterialDetail.Quantity
                                    ,AsakaiPemakaianMaterialDetail.[Total Harga]
                                    FROM AsakaiPemakaianMaterialDetail Left join Inventory on AsakaiPemakaianMaterialDetail.IDMaterial =Inventory.InvtID where AsakaiPemakaianMaterialDetail.IDTrans  = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataDetailKomponen(ID As String) As DataTable
        Try
            Dim query As String = "SELECT 
                                    AsakaiPemakaianKomponenDetail.IDMaterial
                                    ,Inventory.Descr
                                    ,AsakaiPemakaianKomponenDetail.Quantity
                                    ,AsakaiPemakaianKomponenDetail.[Total Harga]
                                    FROM AsakaiPemakaianKomponenDetail Left join Inventory on AsakaiPemakaianKomponenDetail.IDMaterial =Inventory.InvtID where AsakaiPemakaianKomponenDetail.IDTrans  = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "CRUD"
    Public Sub InsertMaterialUsage()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader()
                        InsertHeaderMaterial()
                        InsertHeaderKomponen()

                        For i As Integer = 0 To ObjDetailsMaterial.Count - 1
                            With ObjDetailsMaterial(i)
                                .InsertAbsenDetails()
                            End With
                        Next

                        For j As Integer = 0 To ObjDetailsKomponen.Count - 1
                            With ObjDetailsKomponen(j)
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
                        InsertHeaderMaterial()
                        InsertHeaderKomponen()

                        For i As Integer = 0 To ObjDetailsMaterial.Count - 1
                            With ObjDetailsMaterial(i)
                                .InsertAbsenDetails()
                            End With
                        Next

                        For j As Integer = 0 To ObjDetailsKomponen.Count - 1
                            With ObjDetailsKomponen(j)
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

    Public Sub DeleteHeader(ByVal ID As String)
        Try
            Dim ls_PMK As String = "DELETE FROM AsakaiPemakaianMaterialKomponen WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_PMK)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteDetail(ByVal ID As String)
        Try
            Dim ls_PM As String = "DELETE FROM AsakaiPemakaianMaterial WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            'ExecQuery(ls_SPD)
            ExecQuery(ls_PM)

            Dim ls_PMD As String = "DELETE FROM AsakaiPemakaianMaterialDetail WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_PMD)

            Dim ls_PK As String = "DELETE FROM AsakaiPemakaianKomponen WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            'ExecQuery(ls_SPD)
            ExecQuery(ls_PK)

            Dim ls_PKD As String = "DELETE FROM AsakaiPemakaianKomponenDetail WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            'ExecQuery(ls_SPD)
            ExecQuery(ls_PKD)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHeader()
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiPemakaianMaterialKomponen]
                                           ([IDTrans]                     
                                           ,[TanggalDari]                     
                                           ,[TanggalSampai]                     
                                           ,[Keterangan]                     
                                           ,[KolomQty]                     
                                           ,[KolomHarga]                     
                                           ,[CreatedBy]                     
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(IDTrans) & " 
                                            ," & QVal(TanggalDari) & "
                                            ," & QVal(TanggalSampai) & "
                                            ," & QVal(Keterangan) & "
                                            ," & QVal(KolomQty) & "
                                            ," & QVal(KolomHarga) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"


            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHeaderMaterial()
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiPemakaianMaterial]
                                           ([IDTrans]                     
                                           ,[TanggalDari]                     
                                           ,[TanggalSampai]                     
                                           ,[Keterangan]                     
                                           ,[1.AktualRP]                     
                                           ,[2.Sales]                     
                                           ,[3.% Sales]                    
                                           ,[4.AktualProduksi]                   
                                           ,[5. % Inj ]                     
                                           ,[6.Target])
                                     VALUES
                                           (" & QVal(IDTrans) & " 
                                            ," & QVal(TanggalDari) & "
                                            ," & QVal(TanggalSampai) & "
                                            ," & QVal(Keterangan) & "
                                            ," & QVal(MaterialAktualRP) & "
                                            ," & QVal(Sales) & "
                                            ," & QVal(MaterialPercent1) & "
                                            ," & QVal(AktualProduksi) & "
                                            ," & QVal(MaterialPercent2) & "
                                            ," & QVal(MaterialTarget) & ")"


            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)


        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertHeaderKomponen()
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiPemakaianKomponen]
                                           ([IDTrans]                     
                                           ,[TanggalDari]                     
                                           ,[TanggalSampai]                     
                                           ,[Keterangan]                     
                                           ,[1.AktualRP]                     
                                           ,[2.Sales]                     
                                           ,[3.% Sales]                    
                                           ,[4.AktualProduksi]                   
                                           ,[5. % Inj ]                     
                                           ,[6.Target])
                                     VALUES
                                           (" & QVal(IDTrans) & " 
                                             ," & QVal(TanggalDari) & "
                                            ," & QVal(TanggalSampai) & "
                                            ," & QVal(Keterangan) & "
                                           ," & QVal(KomponenAktualRP) & "
                                            ," & QVal(Sales) & "
                                            ," & QVal(KomponenPercent1) & "
                                            ," & QVal(AktualProduksi) & "
                                            ," & QVal(KomponenPercent2) & "
                                            ," & QVal(KomponenTarget) & ")"


            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateHeader(ByVal _IDMaterialUsage As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiPemakaianMaterialKomponen" & vbCrLf &
                                    "SET    TanggalDari = " & QVal(TanggalDari) & ", " & vbCrLf &
                                    "    TanggalSampai = " & QVal(TanggalSampai) & ", " & vbCrLf &
                                    "    Keterangan = " & QVal(Keterangan) & ", " & vbCrLf &
                                    "    KolomQty = " & QVal(KolomQty) & ", " & vbCrLf &
                                    "    KolomHarga = " & QVal(KolomHarga) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE IDTrans = '" & _IDMaterialUsage & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region


End Class

'------------------------------------------------------------------------------

Public Class PemakaianMaterialDetail
    Dim _Query As String

    'Header


    'Detail
    Public Property IDTrans As String
    Public Property MaterialInvtId() As String
    Public Property MaterialJumlah() As Double
    Public Property MaterialHarga() As Double


    Public Sub InsertAbsenDetails()
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO AsakaiPemakaianMaterialDetail
            (IDTrans,IDMaterial,Quantity,[Total Harga]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(MaterialInvtId) & ", " & vbCrLf &
            "       " & QVal(MaterialJumlah) & ", " & vbCrLf &
            "       " & QVal(MaterialHarga) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal _IDMaterialUsage As String)
        Try
            Dim ls_SP As String = "DELETE FROM AsakaiMaterialUsageDetail WHERE rtrim(IDMaterialUsage)=" & QVal(_IDMaterialUsage) & ""
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class


Public Class PemakaianKomponenlDetail
    Dim _Query As String

    'Header
    Public Property IDTrans As String
    Public Property KomponenInvtId() As String
    Public Property KomponenJumlah() As Double
    Public Property KomponenHarga() As Double


    Public Sub InsertAbsenDetails()
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO AsakaiPemakaianKomponenDetail
            (IDTrans,IDMaterial,Quantity,[Total Harga]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(KomponenInvtId) & ", " & vbCrLf &
            "       " & QVal(KomponenJumlah) & ", " & vbCrLf &
            "       " & QVal(KomponenHarga) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal _IDMaterialUsage As String)
        Try
            Dim ls_SP As String = "DELETE FROM AsakaiMaterialUsageDetail WHERE rtrim(IDMaterialUsage)=" & QVal(_IDMaterialUsage) & ""
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class
