Imports System.Collections.ObjectModel

Public Class DeliveryModel

    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public Tgl As String

    'Header
    Public Property CreatedBy As String
    Public Property CreatedDate As Date
    Public Property IDTrans As String
    Public Property Tanggal As Date
    Public Property Laporan As String
    Public Property UpdatedBy As String
    Public Property UpdatedDate As Date


    'Detail
    Public Property Customer As String
    Public Property Balance As Integer
    Public Property Delivery As Integer
    Public Property Delivery_Due_Date As Date
    Public Property invtId As String
    Public Property Jumlah As Integer
    Public Property Keterangan As String
    Public Property Qty_Order As Integer
    Public Property Stock_2nd As Integer
    Public Property Stock_Inject_Presisi As Integer
    Public Property Stock_Paint As Integer
    Public Property Stock_TNG_04_02_PNT As Integer
    Public Property Stock_TNG_05_WHJ As Integer
    Public Property Stock_TNG_06_SFG As Integer
    Public Property Stock_TNG_08_DEL As Integer
    Public Property Total_Stock As Integer
    Public Property WHP As Integer

    Public Property ObjDetailDelivery() As New Collection(Of DeliveryDetailModel)



    Public Sub New()
        Me._Query = "SELECT CONVERT(varchar,Tanggal,105) As Tanggal,Laporan,IDTrans from AsakaiDeliveryHeader  order by IDTrans Desc"
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
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiDeliveryHeader WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiDeliveryDetail WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

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
                              FROM AsakaiDeliveryHeader where IDTrans = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDTrans = Trim(.Item("IDTrans") & "")
                    Me.Tanggal = Trim(.Item("Tanggal") & "")
                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Function GetDataDetailDelivery(ID As String) As DataTable
        Try

            Dim query As String = "SELECT [IDTrans]
              ,[Customer]
              ,AsakaiDeliveryDetail.[invtId] as InvtId
              ,AsakaiDeliveryDetail.[invtId] as [Item Number]
              ,[Delivery Due Date]
              ,[Qty Order]
              ,[Delivery]
              ,[Jumlah]
              ,[Stock TNG 08 DEL] as [TNG 08]
              ,[Stock TNG 05 WHJ] as [TNG 05 06]
              ,[Stock Paint] as [Painting]
              ,[WHP] as Whp
              ,[Keterangan]
          FROM AsakaiDeliveryDetail Left join Inventory on AsakaiDeliveryDetail.invtId =Inventory.InvtID where AsakaiDeliveryDetail.IDTrans  = '" & ID & "'"
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
                                    FROM [AsakaiDeliveryHeader] order by IDTrans desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "D" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTrans")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 2, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "D" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTrans")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 4, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "D" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "D" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "D" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "D" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub InsertDelivery()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader()
                        For i As Integer = 0 To ObjDetailDelivery.Count - 1
                            With ObjDetailDelivery(i)
                                .InsertDeleveryDetails()
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
            Dim ls_SP As String = "SELECT TOP 1 [IDTrans],Tanggal                  
                                    FROM [AsakaiDeliveryHeader] where IDTrans = '" & IDTrans & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.Tanggal & "]")

            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHeader()
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiDeliveryHeader
                                           ([IDTrans]
                                           ,[Tanggal]
                                           ,[Laporan]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(IDTrans) & " 
                                            ," & QVal(Tanggal) & "
                                            ," & QVal(Laporan) & "
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

                        'UpdateHeader(IDTrans)
                        DeleteDetail(IDTrans)

                        For i As Integer = 0 To ObjDetailDelivery.Count - 1
                            With ObjDetailDelivery(i)
                                .InsertDeleveryDetails()
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
                                    "UPDATE AsakaiDeliveryHeader" & vbCrLf &
                                    "SET UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTrans = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiDeliveryDetail WHERE rtrim(IDTrans)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class



Public Class DeliveryDetailModel

    'Detail
    Public Property IDTrans As String

    Public Property Customer As String
    Public Property Balance As Integer
    Public Property Delivery As Integer
    Public Property Delivery_Due_Date As Date
    Public Property invtId As String
    Public Property invtName As String
    Public Property Jumlah As Integer
    Public Property Keterangan As String
    Public Property Qty_Order As Integer
    Public Property Stock_2nd As Integer
    Public Property Stock_Inject_Presisi As Integer
    Public Property Stock_Paint As Integer
    Public Property Stock_TNG_04_02_PNT As Integer
    Public Property Stock_TNG_05_WHJ As Integer
    Public Property Stock_TNG_06_SFG As Integer
    Public Property Stock_TNG_08_DEL As Integer
    Public Property Total_Stock As Integer
    Public Property WHP As Integer




    Public Sub InsertDeleveryDetails()
        Try

            Dim ls_SP As String = " " & vbCrLf &
                    "INSERT INTO [AsakaiDeliveryDetail]
                   ([IDTrans]
                   ,[Customer]
                   ,[invtId]
                   ,[InvtName]
                   ,[Delivery Due Date]
                   ,[Qty Order]
                   ,[Delivery]
                   ,[Jumlah]
                   ,[Stock TNG 08 DEL]
                   ,[Stock TNG 05 WHJ]
                   ,[Stock Paint]
                   ,[WHP]
                   ,[Total Stock]
                   ,[Balance]
                   ,[Keterangan]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(Customer) & ", " & vbCrLf &
            "       " & QVal(invtId) & ", " & vbCrLf &
            "       " & QVal(invtName) & ", " & vbCrLf &
            "       " & QVal(Delivery_Due_Date) & ", " & vbCrLf &
            "       " & QVal(Qty_Order) & ", " & vbCrLf &
            "       " & QVal(Delivery) & ", " & vbCrLf &
            "       " & QVal(Jumlah) & ", " & vbCrLf &
            "       " & QVal(Stock_TNG_08_DEL) & ", " & vbCrLf &
            "       " & QVal(Stock_TNG_05_WHJ) & ", " & vbCrLf &
            "       " & QVal(Stock_Paint) & ", " & vbCrLf &
            "       " & QVal(WHP) & ", " & vbCrLf &
            "       " & QVal(Total_Stock) & ", " & vbCrLf &
            "       " & QVal(Balance) & ", " & vbCrLf &
            "       " & QVal(Keterangan) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub



End Class
