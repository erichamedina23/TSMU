Imports System.Collections.ObjectModel
Public Class ClaimCustomerModel
    Dim Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String



    Public Property H_IDTransaksi As String
    Public Property H_Tanggal As DateTime
    Public Property IDTrans As String





    Public Property ObjDetailClaimCustomer() As New Collection(Of ClaimCustomerDetailModel)




    Public Sub New()
        Me.Query = "SELECT IDTransaksi,CONVERT(varchar,Tanggal,105) As Tanggal from AsakaiQCClaim  order by IDTransaksi Desc"
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

    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiQCClaim WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiQcClaimDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Tanggal]
                                  ,[CreatedBy]
                                  ,[CreatedDate]
                                  ,[UpdatedBy]
                                  ,[UpdatedDate]
                              FROM [AsakaiQCClaim] where IDTransaksi = '" & ID & "'"
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

    Public Function GetDataDetailClaimCustomer(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Customer]
                                  ,[TanggalClaim]
                                  ,[InvtID] as InvtId
                                  ,[InvtName] As [Invt Name]
                                  ,[Problem]
                                  ,[Qty]
                                  ,[RESP] as Pic
                                  ,[Status]
                                  ,[Dokumen]
                                  ,TargetClose
                                  ,Foto as Gambar
                                  ,Lot
                                 ,Type
                                 ,Foto as [Gambar Hapus]
                                 ,Path
                              From [AsakaiQcClaimDetail] where IDTransaksi  = '" & ID & "'"
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

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiQCClaim] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "QC" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "QC" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "QC" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "QC" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "QC" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "QC" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertClaimCustomer(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(IdTransaksi)
                        For i As Integer = 0 To ObjDetailClaimCustomer.Count - 1
                            With ObjDetailClaimCustomer(i)
                                .InsertClaimDetail(IdTransaksi)
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

    Public Sub ValidateInsert()
        Try
            'Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
            '                        FROM [AsakaiQCClaim] where Tanggal = '" & H_Tanggal & "' "
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


    Public Sub InsertHeader(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiQCClaim
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

                        UpdateHeader(IdTransaksi)
                        DeleteDetail(IdTransaksi)

                        For i As Integer = 0 To ObjDetailClaimCustomer.Count - 1
                            With ObjDetailClaimCustomer(i)
                                .InsertClaimDetail(IdTransaksi)
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
                                    "UPDATE AsakaiQCClaim" & vbCrLf &
                                    "SET UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    " UpdatedDate = GETDATE() WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiQcClaimDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetRekapClaim(TanggalAwal As Date, TanggalAhir As Date) As DataTable
        Try
            Dim query As String = "SELECT AsakaiQcClaimDetail.InvtID as [Part No],
                                    AsakaiQcClaimDetail.InvtName as [Part Name],
                                    SUM (Qty) as Qty 
                                    FROM AsakaiQcClaimDetail 
                                    inner join AsakaiQCClaim on AsakaiQcClaimDetail.IDTransaksi = AsakaiQCClaim.IDTransaksi
                                    where AsakaiQCClaim.Tanggal >= '" + (TanggalAwal) + "' and AsakaiQCClaim.Tanggal <= '" + (TanggalAhir) + "'" +
                                    "GROUP BY AsakaiQcClaimDetail.InvtID,AsakaiQcClaimDetail.InvtName " +
                                    "union SELECT 'TOTAL','', SUM(Qty) as Qty FROM AsakaiQcClaimDetail inner join AsakaiQCClaim on AsakaiQcClaimDetail.IDTransaksi = AsakaiQCClaim.IDTransaksi
                                    where AsakaiQCClaim.Tanggal >= '" + (TanggalAwal) + "' and AsakaiQCClaim.Tanggal <= '" + (TanggalAhir) + "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class

Public Class ClaimCustomerDetailModel

    Public Property D_Customer As String
    Public Property D_Dokumen As String
    Public Property D_IDTransaksi As String
    Public Property D_InvtID As String
    Public Property D_InvtName As String
    Public Property D_JUDGEMENT As String
    Public Property D_Penanganan As String
    Public Property D_Problem As String
    Public Property D_Qty As Integer
    Public Property D_RESP As String
    Public Property D_Status As String
    Public Property D_TanggalClaim As DateTime
    Public Property D_TanggalClose As DateTime
    Public Property D_Lot As String
    Public Property D_Foto As String
    Public Property D_Type As String

    Public Sub InsertClaimDetail(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiQcClaimDetail]
                       ([IDTransaksi]
                       ,[Customer]
                       ,[TanggalClaim]
                       ,[TargetClose]
                       ,[InvtID]
                       ,[InvtName]
                       ,[Problem]
                       ,[Qty]
                       ,[RESP]
                       ,[Dokumen]
                       ,[Foto]
                       ,[Lot]
                       ,[Type]
                       ,[Status]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(D_Customer) & ", " & vbCrLf &
            "       " & QVal(D_TanggalClaim) & ", " & vbCrLf &
            "       " & QVal(D_TanggalClose) & ", " & vbCrLf &
            "       " & QVal(D_InvtID) & ", " & vbCrLf &
            "       " & QVal(D_InvtName) & ", " & vbCrLf &
            "       " & QVal(D_Problem) & ", " & vbCrLf &
            "       " & QVal(D_Qty) & ", " & vbCrLf &
            "       " & QVal(D_RESP) & ", " & vbCrLf &
            "       " & QVal(D_Dokumen) & ", " & vbCrLf &
            "       " & QVal(D_Foto) & ", " & vbCrLf &
            "       " & QVal(D_Lot) & ", " & vbCrLf &
            "       " & QVal(D_Type) & ", " & vbCrLf &
            "       " & QVal(D_Status) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class
