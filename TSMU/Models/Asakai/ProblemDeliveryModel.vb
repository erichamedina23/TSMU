Imports System.Collections.ObjectModel

Public Class ProblemDeliveryModel

    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String

    'Header
    Public Property H_CreatedBy As String
    Public Property H_CreatedDate As DateTime
    Public Property H_IDTrans As String
    Public Property H_Tanggal As DateTime
    Public Property H_UpdatedBy As Char
    Public Property H_UpdatedDate As DateTime
    Public Property IDTrans As String

    Public Property ObjDetailProblemDelivery() As New Collection(Of ProblemDeliveryDetailModel)


    Public Sub New()
        Me._Query = "SELECT Tanggal,IDTrans from AsakaiProblemDeliveryHeader  Where datepart(year, Tanggal) = '" & Format((Date.Now), "yyyy") & "' AND datepart(month, Tanggal) = '" & Format((Date.Now), "MM") & "' order by tanggal Desc"
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

    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTrans],Tanggal                   
                                    FROM [AsakaiProblemDeliveryHeader] where IDTrans = '" & H_IDTrans & "' "
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

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [IDTrans]
                                          ,[Tanggal]
                                          ,[CreatedBy]
                                          ,[CreatedDate]
                                          ,[UpdatedBy]
                                          ,[UpdatedDate]
                                      FROM AsakaiProblemDeliveryHeader where IDTrans = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_IDTrans = Trim(.Item(0) & "")
                    Me.H_Tanggal = Trim(.Item(1) & "")

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataDetailProblemDelivery(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [Customer] 
                                  ,[Standar]
                                  ,[Aktual] 
                                  ,[Kirim Kurang] 
                                  ,[Campur]
                                  ,[Kirim Lebih Isi]
                                  ,[Salah Isi]
                                  ,[Salah Passcard] as [Salah Passcard]
                                  ,[Transporter]
                                  ,[Keterangan]
                                  ,[Lain Lain]
                                  ,[Gambar]
                              From [AsakaiProblemDeliveryUpload] where IDTrans  = '" & ID & "'"
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

            Dim ls_SP As String = "SELECT [IDTrans]                   
                                    FROM [AsakaiProblemDeliveryHeader] order by IDTrans desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "PD" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTrans")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "PD" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTrans")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "PD" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "PD" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "PD" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "PD" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub InsertProblemDelivery(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(IdTransaksi)
                        For i As Integer = 0 To ObjDetailProblemDelivery.Count - 1
                            With ObjDetailProblemDelivery(i)
                                .InsertAbsenDetails(IdTransaksi)
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


            Dim ls_SP As String = "INSERT INTO [AsakaiProblemDeliveryHeader]
                                           ([IDTrans]
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

                        UpdateHeader(IdTransaksi)
                        DeleteDetail(IdTransaksi)

                        For i As Integer = 0 To ObjDetailProblemDelivery.Count - 1
                            With ObjDetailProblemDelivery(i)
                                .InsertAbsenDetails(IdTransaksi)
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
                                    "UPDATE AsakaiProblemDeliveryHeader" & vbCrLf &
                                    "SET    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTrans = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiProblemDeliveryUpload WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiProblemDeliveryHeader WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiProblemDeliveryUpload WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class


Public Class ProblemDeliveryDetailModel
    'Public Property D_Aktual As String
    'Public Property D_InvtID As String
    'Public Property D_InvtName As String
    'Public Property D_Customer As String
    'Public Property D_IDTrans As String
    'Public Property D_PIC As String
    'Public Property D_Qty As Integer
    'Public Property D_Standar As String
    'Public Property D_Status As String
    'Public Property D_Gambar As String
    'Public Property D_Tanggal_Kejadian As Date
    'Public Property D_Target_Close As Date

    'Public Property D_Tanggal As Date
    'Public Property D_Tanggal_Kiriman As Date

    'Public Property D_JenisProblem As String


    Public Property D_IDTrans As String
    Public Property D_Customer As String
    Public Property D_Standar As String
    Public Property D_Aktual As String
    Public Property D_KirimKurang As Integer
    Public Property D_Campur As Integer
    Public Property D_KirimLebihIsi As Integer
    Public Property D_SalahIsi As Integer
    Public Property D_LainLain As Integer
    Public Property D_SalahPasscard As Integer
    Public Property D_Transporter As Integer
    Public Property D_Keterangan As String
    Public Property D_Gambar As String





    Public Sub InsertAbsenDetails(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiProblemDeliveryUpload]
                   ([IDTrans]
                   ,[Customer]
                   ,[Standar]
                   ,[Aktual]
                   ,[Kirim Kurang]
                   ,[Campur]
                   ,[Kirim Lebih Isi]
                   ,[Salah Isi]
                   ,[Salah PassCard]
                   ,[Transporter]
                   ,[Lain Lain]
                   ,[Keterangan]
                   ,[Gambar]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(D_Customer) & ", " & vbCrLf &
            "       " & QVal(D_Standar) & ", " & vbCrLf &
            "       " & QVal(D_Aktual) & ", " & vbCrLf &
            "       " & QVal(D_KirimKurang) & ", " & vbCrLf &
            "       " & QVal(D_Campur) & ", " & vbCrLf &
            "       " & QVal(D_KirimLebihIsi) & ", " & vbCrLf &
            "       " & QVal(D_SalahIsi) & ", " & vbCrLf &
            "       " & QVal(D_SalahPasscard) & ", " & vbCrLf &
            "       " & QVal(D_Transporter) & ", " & vbCrLf &
            "       " & QVal(D_LainLain) & ", " & vbCrLf &
            "       " & QVal(D_Keterangan) & ", " & vbCrLf &
            "       " & QVal(D_Gambar) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub




End Class


