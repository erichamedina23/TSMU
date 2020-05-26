Imports System.Collections.ObjectModel
Public Class QualityProblemModel
    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String



    Public Property H_IDTransaksi As String
    Public Property H_Tanggal As DateTime
    Public Property IDTrans As String

    Public Property ObjDetailQualityProblem() As New Collection(Of QualityProblemDetailModel)
    Public Sub New()
        Me._Query = "SELECT Distinct AsakaiQualityProblem.IDTransaksi,Convert(varchar,AsakaiQualityProblem.Tanggal,105) as Tanggal,AsakaiQualityProblemDetail.Shift 
                    from AsakaiQualityProblem inner join AsakaiQualityProblemDetail
                    on AsakaiQualityProblem.IDTransaksi = AsakaiQualityProblemDetail.IDTransaksi
                    Order by  AsakaiQualityProblem.IDTransaksi Desc"

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

    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiQualityProblem WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiQualityProblemDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Tanggal]
                                  ,[CreatedBy]
                                  ,[CreatedDate]
                                  ,[UpdatedBy]
                                  ,[UpdatedDate]
                              FROM [AsakaiQualityProblem] where IDTransaksi = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_IDTransaksi = Trim(.Item(0) & "")
                    Me.H_Tanggal = Trim(.Item(1) & "")

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataDetailQualityProblem(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Tanggal]
                                  ,[Shift]
                                  ,[Status]
                                  ,[Customer]
                                  ,[InvtId]
                                  ,[InvtName]
                                  ,[Type]
                                  ,[Qty]
                                  ,[Foto] as Gambar
                                  ,[Problem]
                                  ,[Analisis]
                                  ,[Lot Produksi] as [Lot No]
                                  ,[CORRECTIVE ACTION] as [Correction Action]
                                  ,[PREVENTIVE ACTION] as [Preventive Action]
                                  ,[Pic]
                                  ,[Target]
                                  ,[Path]  
                                  ,[Foto] as [Gambar Hapus]
                              From [AsakaiQualityProblemDetail] where IDTransaksi  = '" & ID & "'"
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

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiQualityProblem] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "QP" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "QP" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "QP" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "QP" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "QP" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "QP" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertQualityProblem(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(IdTransaksi)
                        For i As Integer = 0 To ObjDetailQualityProblem.Count - 1
                            With ObjDetailQualityProblem(i)
                                .InsertQualityProblemDetail(IdTransaksi)
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


            Dim ls_SP As String = "INSERT INTO AsakaiQualityProblem
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

    Public Sub ValidateInsert()
        Try
            'Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
            '                        FROM [AsakaiQualityProblem] where Tanggal = '" & H_Tanggal & "' "
            'Dim dtTable As New DataTable
            ''dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
            '    "[" & Format(Me.H_Tanggal, "dd-MM-yyyy") & "]")
            'Else

            'End If

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

                        For i As Integer = 0 To ObjDetailQualityProblem.Count - 1
                            With ObjDetailQualityProblem(i)
                                .InsertQualityProblemDetail(IdTransaksi)
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
                                    "UPDATE AsakaiQualityProblem" & vbCrLf &
                                    "SET Tanggal = " & QVal(H_Tanggal) & ", " & vbCrLf &
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
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiQualityProblemDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class QualityProblemDetailModel

    Public Property D_Analisis As String
    Public Property D_CORRECTIVE_ACTION As String
    Public Property D_Customer As String
    'Public Property D_Foto As Byte[]
    Public Property D_IDTransaksi As String
    Public Property D_InvtId As String
    Public Property D_InvtName As String
    Public Property D_Pic As String
    Public Property D_PREVENTIVE_ACTION As String
    Public Property D_Problem As String
    Public Property D_Qty As Integer
    Public Property D_Shift As String
    Public Property D_Status As String
    Public Property D_Tanggal As DateTime
    Public Property D_Target As DateTime
    Public Property D_Type As String
    Public Property D_Lot As String
    Public Property D_Gambar As String


    Public Sub InsertQualityProblemDetail(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiQualityProblemDetail]
                   ([IDTransaksi]
                   ,[Tanggal]
                   ,[Shift]
                   ,[Status]
                   ,[Customer]
                   ,[InvtId]
                   ,[InvtName]
                   ,[Type]
                   ,[QTY]
                   ,[Foto]
                   ,[Problem]
                   ,[Lot Produksi]
                   ,[Analisis]
                   ,[CORRECTIVE ACTION]
                   ,[PREVENTIVE ACTION]
                   ,[Pic]
                   ,[Target]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(D_Tanggal) & ", " & vbCrLf &
            "       " & QVal(D_Shift) & ", " & vbCrLf &
            "       " & QVal(D_Status) & ", " & vbCrLf &
            "       " & QVal(D_Customer) & ", " & vbCrLf &
            "       " & QVal(D_InvtId) & ", " & vbCrLf &
            "       " & QVal(D_InvtName) & ", " & vbCrLf &
            "       " & QVal(D_Type) & ", " & vbCrLf &
            "       " & QVal(D_Qty) & ", " & vbCrLf &
            "       " & QVal(D_Gambar) & ", " & vbCrLf &
            "       " & QVal(D_Problem) & ", " & vbCrLf &
            "       " & QVal(D_Lot) & ", " & vbCrLf &
            "       " & QVal(D_Analisis) & ", " & vbCrLf &
            "       " & QVal(D_CORRECTIVE_ACTION) & ", " & vbCrLf &
            "       " & QVal(D_PREVENTIVE_ACTION) & ", " & vbCrLf &
            "       " & QVal(D_Pic) & ", " & vbCrLf &
            "       " & QVal(D_Target) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
