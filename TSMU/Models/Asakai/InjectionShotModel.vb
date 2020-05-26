Imports System.Collections.ObjectModel
Public Class InjectionShotModel


    'Header
    Dim Query As String
    Public tahun As String
    Public bulan As String
    Public Tgl As String

    'Header
    Public Property CreatedBy As String
    Public Property CreatedDate As Date
    Public Property IDTransaksi As String
    Public Property Tanggal As Date
    Public Property Shift As String
    Public Property Pic As String
    Public Property UpdatedBy As String
    Public Property UpdatedDate As Date

    Public Property ObjDetailColection() As New Collection(Of InjectionShortDetailModel)



    Public Sub New()
        Me.Query = "SELECT IDTransaksi,CONVERT(varchar,Tanggal,105) As Tanggal,Shift,Pic From AsakaiInjectionAnalisaShot order by IDTransaksi Desc"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me.Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Tanggal]
                                  ,[Shift]
                                  ,[Pic]
                              FROM AsakaiInjectionAnalisaShot where IDTransaksi = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDTransaksi = Trim(.Item("IDTransaksi") & "")
                    Me.Tanggal = Trim(.Item("Tanggal") & "")
                    Me.Shift = Trim(.Item("Shift") & "")
                    Me.Pic = Trim(.Item("Pic") & "")
                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataDetail(ID As String) As DataTable
        Try

            Dim query As String = "Select [NoMC] as Mesin
                                  ,[Merek] as Merek
                                  ,[Part] as [Nama Part]
                                  ,[Type] as Type
                                  ,[1]
                                  ,[2]
                                  ,[3]
                                  ,[4]
                                  ,[5]
                                  ,[6]
                                  ,[7]
                                  ,[8]
                                  ,[9]
                                  ,[10]
                                  ,[Keterangan]
          FROM AsakaiInjectionAnalisaShotDetail where IDTransaksi  = '" & ID & "'"
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

            Dim ls_SP As String = "SELECT [IDTransaksi]                   
                                    FROM [AsakaiInjectionAnalisaShot] order by IDTransaksi desc" 'where IDTransaksi= " & QVal(IDTransaksi) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTransaksi = "IS" & Tahun & "0001"
            Else
                IDTransaksi = dtTable.Rows(0).Item("IDTransaksi")
                IDTransaksi = Microsoft.VisualBasic.Mid(IDTransaksi, 3, 2)
                If IDTransaksi <> Ulang Then
                    IDTransaksi = "IS" & Tahun & "0001"
                Else
                    IDTransaksi = dtTable.Rows(0).Item("IDTransaksi")
                    IDTransaksi = Val(Microsoft.VisualBasic.Mid(IDTransaksi, 5, 4)) + 1
                    If Len(IDTransaksi) = 1 Then
                        IDTransaksi = "IS" & Tahun & "000" & IDTransaksi & ""
                    ElseIf Len(IDTransaksi) = 2 Then
                        IDTransaksi = "IS" & Tahun & "00" & IDTransaksi & ""
                    ElseIf Len(IDTransaksi) = 3 Then
                        IDTransaksi = "IS" & Tahun & "0" & IDTransaksi & ""
                    Else
                        IDTransaksi = "IS" & Tahun & IDTransaksi & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "CRUD"

    Public Sub Insert()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader()
                        For i As Integer = 0 To ObjDetailColection.Count - 1
                            With ObjDetailColection(i)
                                .InsertDetail()
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


    Public Sub InsertHeader()
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiInjectionAnalisaShot
                                           ([IDTransaksi]
                                           ,[Tanggal]
                                           ,[Shift]
                                           ,[Pic]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(IDTransaksi) & " 
                                            ," & QVal(Tanggal) & "
                                            ," & QVal(Shift) & "
                                            ," & QVal(Pic) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"

            MainModul.ExecQuery(ls_SP)
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

                        DeleteDetail(IDTransaksi)

                        For i As Integer = 0 To ObjDetailColection.Count - 1
                            With ObjDetailColection(i)
                                .InsertDetail()
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

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiInjectionAnalisaShotDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal,Shift                  
                                    FROM [AsakaiInjectionAnalisaShot] where Tanggal = '" & Tanggal & "' and Shift = '" & Shift & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.Tanggal & Me.Shift & "]")

            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiInjectionAnalisaShot WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiInjectionAnalisaShotDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region


End Class

Public Class InjectionShortDetailModel

    Public Property D_Transaksi As String
    Public Property D_Mesin As String
    Public Property D_Merek As String
    Public Property D_Type As String
    Public Property D_NamaPart As String
    Public Property D_1 As String
    Public Property D_2 As String
    Public Property D_3 As String
    Public Property D_4 As String
    Public Property D_5 As String
    Public Property D_6 As String
    Public Property D_7 As String
    Public Property D_8 As String
    Public Property D_9 As String
    Public Property D_10 As String
    Public Property D_Keterangan As String



    Public Sub InsertDetail()
        Try

            Dim ls_SP As String = " " & vbCrLf &
                    "INSERT INTO [AsakaiInjectionAnalisaShotDetail]
                   ([IDTransaksi]
                   ,[NoMC]
                   ,[Merek]
                   ,[Part]
                   ,[Type]
                   ,[1]
                   ,[2]
                   ,[3]
                   ,[4]
                   ,[5]
                   ,[6]
                   ,[7]
                   ,[8]
                   ,[9]
                   ,[10]
                   ,[Keterangan]) " & vbCrLf &
            "Values(" & QVal(D_Transaksi) & ", " & vbCrLf &
            "       " & QVal(D_Mesin) & ", " & vbCrLf &
            "       " & QVal(D_Merek) & ", " & vbCrLf &
            "       " & QVal(D_NamaPart) & ", " & vbCrLf &
            "       " & QVal(D_Type) & ", " & vbCrLf &
            "       " & QVal(D_1) & ", " & vbCrLf &
            "       " & QVal(D_2) & ", " & vbCrLf &
            "       " & QVal(D_3) & ", " & vbCrLf &
            "       " & QVal(D_4) & ", " & vbCrLf &
            "       " & QVal(D_5) & ", " & vbCrLf &
            "       " & QVal(D_6) & ", " & vbCrLf &
            "       " & QVal(D_7) & ", " & vbCrLf &
            "       " & QVal(D_8) & ", " & vbCrLf &
            "       " & QVal(D_9) & ", " & vbCrLf &
            "       " & QVal(D_10) & ", " & vbCrLf &
            "       " & QVal(D_Keterangan) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub




End Class
