Imports System.Collections.ObjectModel
Public Class MaintenanceModel
    Dim Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String

    Public Property H_IDTransaksi As String
    Public Property H_Tanggal As DateTime
    Public Property IDTrans As String

    Public Property Mesin_Plan As Integer
    Public Property Mesin_Actual As Integer
    Public Property Mesin_Balance As Integer
    Public Property KeteranganMesin As String

    Public Property Mold_Plan As Integer
    Public Property Mold_Actual As Integer
    Public Property Mold_Balance As Integer
    Public Property Keterangan_Mold As String


    Public SMesin As Double = 0
    Public SMold As Double = 0





    Public Property ObjDetailMaintenance() As New Collection(Of MaintenanceDetailModel)


    Public Sub New()
        Me.Query = "SELECT IDTransaksi,Convert(varchar,Tanggal,105) as Tanggal from AsakaiMaintenance order by IDTransaksi Desc"
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

    Public Function GetAllDataTableDownTime(ByVal ls_Filter As String) As DataTable
        Try
            Dim Script As String = "SELECT IDTransaksi as ID,Convert(varchar,Tanggal,105) as Tanggal from AsakaiMaintenanceDownTime  Where datepart(year, Tanggal) = '" & Format((Date.Now), "yyyy") & "' AND datepart(month, Tanggal) = '" & Format((Date.Now), "MM") & "' order by Tanggal Desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Script)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiMaintenance WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetailMesin As String = "DELETE FROM AsakaiMaintenanceMesin WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetailMesin)

            Dim ls_DeleteDetailMold As String = "DELETE FROM AsakaiMaintenanceMold WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetailMold)


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT AsakaiMaintenance.IDTransaksi
                                  ,AsakaiMaintenance.Tanggal
                                  ,AsakaiMaintenanceMesin.[1. Plan] As MesinPlan
                                  ,AsakaiMaintenanceMesin.[2. Actual] as MesinAktual
                                  ,AsakaiMaintenanceMesin.[3. Balance] as MesinBalance
                                  ,AsakaiMaintenanceMesin.[4. Keterangan] as MesinKeterangan
                                  ,AsakaiMaintenanceMold.[1. Plan] As MoldPlan
                                  ,AsakaiMaintenanceMold.[2. Actual] as MoldAktual
                                  ,AsakaiMaintenanceMold.[3. Balance] as MoldBalance
                                  ,AsakaiMaintenanceMold.[4. Keterangan] as MoldKeterangan
                              FROM AsakaiMaintenance inner join AsakaiMaintenanceMesin on AsakaiMaintenance.IDTransaksi = AsakaiMaintenanceMesin.IDTransaksi
                              inner Join AsakaiMaintenanceMold on AsakaiMaintenance.IDTransaksi = AsakaiMaintenanceMold.IDTransaksi  where AsakaiMaintenance.IDTransaksi = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_IDTransaksi = Trim(.Item(0) & "")
                    Me.H_Tanggal = Trim(.Item(1) & "")
                    Me.Mesin_Plan = Trim(.Item("MesinPlan") & "")
                    Me.Mesin_Actual = Trim(.Item("MesinAktual") & "")
                    Me.Mesin_Balance = Trim(.Item("MesinBalance") & "")
                    Me.KeteranganMesin = Trim(.Item("MesinKeterangan"))
                    Me.Mold_Plan = Trim(.Item("MoldPlan") & "")
                    Me.Mold_Actual = Trim(.Item("MoldAktual") & "")
                    Me.Mold_Balance = Trim(.Item("MoldBalance") & "")
                    Me.Keterangan_Mold = Trim(.Item("MoldKeterangan") & "")

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

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiMaintenance] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "MT" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "MT" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "MT" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "MT" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "MT" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "MT" & Tahun & IDTrans & ""
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
                        InserMaintenance(IdTransaksi)
                        InserMaintenanceMesin(IdTransaksi)
                        InserMaintenanceMold(IdTransaksi)
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

    Public Sub InserMaintenance(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiMaintenance
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

    Public Sub InserMaintenanceMesin(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiMaintenanceMesin
                                          ([IDTransaksi]
                                           ,[Tanggal]
                                           ,[1. Plan]
                                           ,[2. Actual]
                                           ,[3. Balance]
                                           ,[4. Keterangan])
                                     VALUES 
                                            (" & QVal(idTransaksi) & " 
                                            ," & QVal(H_Tanggal) & "
                                            ," & QVal(Mesin_Plan) & "
                                            ," & QVal(Mesin_Actual) & "
                                            ," & QVal(Mesin_Balance) & "
                                            ," & QVal(KeteranganMesin) & ")"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InserMaintenanceMold(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiMaintenanceMold
                                           ([IDTransaksi]
                                           ,[Tanggal]
                                           ,[1. Plan]
                                           ,[2. Actual]
                                           ,[3. Balance]
                                           ,[4. Keterangan])
                                     VALUES 
                                            (" & QVal(idTransaksi) & " 
                                            ," & QVal(H_Tanggal) & "
                                            ," & QVal(Mold_Plan) & "
                                            ," & QVal(Mold_Actual) & "
                                            ," & QVal(Mold_Balance) & "
                                            ," & QVal(Keterangan_Mold) & ")"

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
                        UpdateMesin(IdTransaksi)
                        UpdateMold(IdTransaksi)

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
                                    "UPDATE AsakaiMaintenance" & vbCrLf &
                                    "SET UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateMesin(ByVal _IDTrans As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiMaintenanceMesin" & vbCrLf &
                                    "SET [1. Plan]  = " & QVal(Mesin_Plan) & ", " & vbCrLf &
                                     "    [2. Actual]  = " & QVal(Mesin_Actual) & ", " & vbCrLf &
                                   "    [3. Balance]  = " & QVal(Mesin_Balance) & ", " & vbCrLf &
                                    "    [4. Keterangan]= " & QVal(KeteranganMesin) & " WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateMold(ByVal _IDTrans As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiMaintenanceMold" & vbCrLf &
                                    "SET [1. Plan]  = " & QVal(Mold_Plan) & ", " & vbCrLf &
                                    "    [2. Actual]  = " & QVal(Mold_Actual) & ", " & vbCrLf &
                                    "    [3. Balance]  = " & QVal(Mold_Balance) & ", " & vbCrLf &
                                    "    [4. Keterangan]= " & QVal(Keterangan_Mold) & " WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
                                    FROM [AsakaiMaintenance] where Tanggal = '" & H_Tanggal & "' "
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

            SMesin = Mesin
            SMold = Mold

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function




End Class

Public Class MaintenanceDetailModel

End Class
