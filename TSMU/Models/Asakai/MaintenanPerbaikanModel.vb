Imports System.Collections.ObjectModel
Public Class MaintenanPerbaikanModel

    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String

    Public Property H_IDTransaksi As String
    Public Property H_Tanggal As DateTime

    Public Property ObjDetailMaintenancePerbaikan() As New Collection(Of MaintenancePerbaikanDetailModel)


    Public Sub New()
        Me._Query = "SELECT IDTransaksi,Convert(varchar,Tanggal,105) as Tanggal from AsakaiMaintenanPerbaikan order by IDTransaksi Desc"
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

    Public Function GetDataDetail(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [Tanggal]
                                  ,[IDTransaksi]
                                  ,[Jenis]
                                  ,[No]
                                  ,[Problem]
                                  ,[Action]
                                  ,[Dari]
                                  ,[Sampai]
                                  ,[Status] as Status
                                  ,[Keterangan] as Keterangan
                              From [AsakaiMaintenanPerbaikanDetail] where IDTransaksi  = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub DeleteDetail(ByVal ID As String)
        Try

            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiMaintenanPerbaikanDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteAll(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiMaintenanPerbaikan WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)

            'Delete Detail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiMaintenanPerbaikanDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetDataByID(ByVal ID As String)
        Try
            Dim query As String = "Select AsakaiMaintenanPerbaikan.Tanggal as Tanggal
                                  ,AsakaiMaintenanPerbaikan.[IDTransaksi] as IDTransaksi
                                  ,AsakaiMaintenanPerbaikanDetail.[Jenis]
                                  ,AsakaiMaintenanPerbaikanDetail.[No]
                                  ,AsakaiMaintenanPerbaikanDetail.[Problem]
                                  ,AsakaiMaintenanPerbaikanDetail.[Action]
                                  ,AsakaiMaintenanPerbaikanDetail.[Dari]
                                  ,AsakaiMaintenanPerbaikanDetail.[Sampai]
                                  ,AsakaiMaintenanPerbaikanDetail.[Status]
                                  ,AsakaiMaintenanPerbaikanDetail.[Keterangan]
                              FROM AsakaiMaintenanPerbaikanDetail inner join AsakaiMaintenanPerbaikan
                                   on AsakaiMaintenanPerbaikanDetail.[IDTransaksi] = AsakaiMaintenanPerbaikan.[IDTransaksi]
                                   where AsakaiMaintenanPerbaikan.IDTransaksi = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_IDTransaksi = Trim(.Item("IDTransaksi") & "")
                    Me.H_Tanggal = Trim(.Item("Tanggal") & "")



                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetIDTransAuto()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT Top 1 [IDTransaksi] FROM [AsakaiMaintenanPerbaikan] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                H_IDTransaksi = "MP" & Tahun & "0001"
            Else
                H_IDTransaksi = dtTable.Rows(0).Item("IDTransaksi")
                H_IDTransaksi = Microsoft.VisualBasic.Mid(H_IDTransaksi, 3, 2)
                If H_IDTransaksi <> Ulang Then
                    H_IDTransaksi = "MP" & Tahun & "0001"
                Else
                    H_IDTransaksi = dtTable.Rows(0).Item("IDTransaksi")
                    H_IDTransaksi = Val(Microsoft.VisualBasic.Mid(H_IDTransaksi, 5, 4)) + 1
                    If Len(H_IDTransaksi) = 1 Then
                        H_IDTransaksi = "MP" & Tahun & "000" & H_IDTransaksi & ""
                    ElseIf Len(H_IDTransaksi) = 2 Then
                        H_IDTransaksi = "MP" & Tahun & "00" & H_IDTransaksi & ""
                    ElseIf Len(H_IDTransaksi) = 3 Then
                        H_IDTransaksi = "MP" & Tahun & "0" & H_IDTransaksi & ""
                    Else
                        H_IDTransaksi = "MP" & Tahun & H_IDTransaksi & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertMain(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InserMaintenancePerbaikan(IdTransaksi)
                        For i As Integer = 0 To ObjDetailMaintenancePerbaikan.Count - 1
                            With ObjDetailMaintenancePerbaikan(i)
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

    Public Sub InserMaintenancePerbaikan(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiMaintenanPerbaikan]
                                           ([IDTransaksi]
                                           ,[Tanggal]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(idTransaksi) & " 
                                            ," & QVal(H_Tanggal) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
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
                        DeleteDetail(IdTransaksi)

                        For i As Integer = 0 To ObjDetailMaintenancePerbaikan.Count - 1
                            With ObjDetailMaintenancePerbaikan(i)
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





    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
                                    FROM [AsakaiMaintenanPerbaikan] where Tanggal = '" & H_Tanggal & "' "
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

    Public Function GetSumaryBalance() As DataTable
        Try
            Dim query As String = "SELECT Top 1
                                   AsakaiMaintenance.[IDTransaksi] 
                                  ,AsakaiMaintenance.[Tanggal] as Tanggal
                                  ,AsakaiMaintenanceMesin.[3. Balance] as Mesin
                                  ,AsakaiMaintenanceMold.[3. Balance] as Mold
                                From AsakaiMaintenance
                                    inner join AsakaiMaintenanceMesin on AsakaiMaintenance.[IDTransaksi] = AsakaiMaintenanceMesin.[IDTransaksi]
                                    inner join AsakaiMaintenanceMold on AsakaiMaintenance.[IDTransaksi] = AsakaiMaintenanceMold.[IDTransaksi]
                                    Where datepart(year, AsakaiMaintenance.[Tanggal]) = '" & tahun & "' AND datepart(month, AsakaiMaintenance.[Tanggal]) = '" & bulan & "' AND datepart(day, AsakaiMaintenance.[Tanggal]) < '" & tanggal & "'
                                    order by AsakaiMaintenance.[Tanggal] Desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)


            Dim Mesin As Double = 0
            Dim Mold As Double = 0

            For a As Integer = 0 To dtTable.Rows.Count - 1
                Mesin = (Mesin + dtTable.Rows(a).Item("Mesin"))
                Mold = (Mold + dtTable.Rows(a).Item("Mold"))
            Next



            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



End Class

Public Class MaintenancePerbaikanDetailModel

    Public Property D_IDTransaksi As String
    Public Property D_Tanggal As DateTime
    Public Property D_Jenis As String
    Public Property D_No As String
    Public Property D_Problem As String
    Public Property D_Action As String
    Public Property D_TanggalDari As DateTime
    Public Property D_TanggalSampai As DateTime
    Public Property D_Status As String
    Public Property D_Keterangan As String


    Public Sub InsertDetail(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiMaintenanPerbaikanDetail]
                                           ([Tanggal]
                                           ,[IDTransaksi]
                                           ,[Jenis]
                                           ,[No]
                                           ,[Problem]
                                           ,[Action]
                                           ,[Dari]
                                           ,[Sampai]
                                           ,[Status]
                                           ,[Keterangan])
                                     VALUES 
                                            (" & QVal(D_Tanggal) & " 
                                            ," & QVal(idTransaksi) & "
                                            ," & QVal(D_Jenis) & "
                                            ," & QVal(D_No) & "
                                            ," & QVal(D_Problem) & "
                                            ," & QVal(D_Action) & "
                                            ," & QVal(D_TanggalDari) & "
                                            ," & QVal(D_TanggalSampai) & "
                                            ," & QVal(D_Status) & "
                                            ," & QVal(D_Keterangan) & ")"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub



End Class
