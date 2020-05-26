Imports System.Collections.ObjectModel
Public Class IPMIModel
    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String

    Public Property CreatedBy As String
    Public Property CreatedDate As Date
    Public Property H_Dibuat As String
    Public Property H_Mengetahui As String
    Public Property H_NOIPMI As String
    Public Property H_Part_Name As String
    Public Property H_Part_No As String
    Public Property H_Problem As String
    Public Property H_Foto As String
    Public Property H_Qty As Integer
    Public Property H_Tanggal As Date
    Public Property H_UpdatedBy As String
    Public Property H_UpdatedDate As Date

    Public Property ObjDetailIPMIPenyebabColection() As New Collection(Of IPMIDetailModel)
    Public Property ObjDetailIPMIPerbaikanColection() As New Collection(Of IPMIDetailModel)


    Public Sub New()
        Me._Query = "SELECT NOIPMI,CONVERT(varchar,Tanggal,105) as Tanggal from AsakaiIpmi  Where datepart(year, Tanggal) = '" & Format((Date.Now), "yyyy") & "' AND datepart(month, Tanggal) = '" & Format((Date.Now), "MM") & "' order by tanggal desc"
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

    Public Sub Delete(ByVal IPMI As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiIpmi WHERE rtrim(NOIPMI)=" & QVal(IPMI) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeletePenyebab As String = "DELETE FROM AsakaiIpmiPenyebab WHERE rtrim(NOIPMI)=" & QVal(IPMI) & ""
            MainModul.ExecQuery(ls_DeletePenyebab)

            Dim ls_DeletePerbaikan As String = "DELETE FROM AsakaiIpmiPerbaikan WHERE rtrim(NOIPMI)=" & QVal(IPMI) & ""
            MainModul.ExecQuery(ls_DeletePerbaikan)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [NOIPMI]
                                  ,[Tanggal]
                                  ,[Part No]
                                  ,[Part Name]
                                  ,[Qty]
                                  ,[Problem]
                                  ,[Dibuat]
                                  ,[Mengetahui]
                                  ,[Foto]
                                  ,[CreatedBy]
                                  ,[CreatedDate]
                                  ,[UpdatedBy]
                                  ,[UpdatedDate]
                              FROM [AsakaiIpmi] where NOIPMI = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_NOIPMI = Trim(.Item(0) & "")
                    Me.H_Tanggal = Trim(.Item(1) & "")
                    Me.H_Part_No = Trim(.Item(2) & "")
                    Me.H_Part_Name = Trim(.Item(3) & "")
                    Me.H_Qty = Trim(.Item(4) & "")
                    Me.H_Problem = Trim(.Item(5) & "")
                    Me.H_Dibuat = Trim(.Item(6) & "")
                    Me.H_Mengetahui = Trim(.Item(7) & "")
                    Me.H_Foto = Trim(.Item("Foto") & "")
                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataDetailPerbaikan(IPMI As String) As DataTable
        Try
            Dim query As String = "SELECT [Rencana Perbaikan] AS Perbaikan
                                      ,[Target]
                                      ,[PIC] as Pic
                                      ,[4M]
                                  FROM [AsakaiIpmiPerbaikan] where NOIPMI  = '" & IPMI & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataDetailPenyebab(IPMI As String) As DataTable
        Try
            Dim query As String = "SELECT [Penyebab] as Problem, [4M]
                                  FROM [AsakaiIpmiPenyebab] where NOIPMI  = '" & IPMI & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub InsertIPMI(NoIPMI As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(NoIPMI)
                        For J As Integer = 0 To ObjDetailIPMIPerbaikanColection.Count - 1
                            With ObjDetailIPMIPerbaikanColection(J)
                                .InsertDetailPerbaikan(NoIPMI)
                            End With
                        Next

                        For i As Integer = 0 To ObjDetailIPMIPenyebabColection.Count - 1
                            With ObjDetailIPMIPenyebabColection(i)
                                .InsertDetailPenyebab(NoIPMI)
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

    Public Sub InsertHeader(NoIPMI As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiIpmi]
                                       ([NOIPMI]
                                       ,[Tanggal]
                                       ,[Part No]
                                       ,[Part Name]
                                       ,[Qty]
                                       ,[Problem]
                                       ,[Dibuat]
                                       ,[Mengetahui]
                                       ,[Foto]
                                       ,[CreatedBy]
                                       ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(NoIPMI) & " 
                                            ," & QVal(H_Tanggal) & "
                                            ," & QVal(H_Part_No) & "
                                            ," & QVal(H_Part_Name) & "
                                            ," & QVal(H_Qty) & "
                                            ," & QVal(H_Problem) & "
                                            ," & QVal(H_Dibuat) & "
                                            ," & QVal(H_Mengetahui) & "
                                            ," & QVal(H_Foto) & "
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
            Dim ls_SP As String = "SELECT NOIPMI                  
                                    FROM [AsakaiIpmi] where NOIPMI = '" & H_NOIPMI & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Format(Me.H_NOIPMI) & "]")
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateData(NoIpmi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(NoIpmi)
                        DeleteDetail(NoIpmi)

                        For J As Integer = 0 To ObjDetailIPMIPerbaikanColection.Count - 1
                            With ObjDetailIPMIPerbaikanColection(J)
                                .InsertDetailPerbaikan(NoIpmi)
                            End With
                        Next

                        For i As Integer = 0 To ObjDetailIPMIPenyebabColection.Count - 1
                            With ObjDetailIPMIPenyebabColection(i)
                                .InsertDetailPenyebab(NoIpmi)
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

    Public Sub UpdateHeader(ByVal IPMI As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiIpmi" & vbCrLf &
                                    "SET [Tanggal] = " & QVal(H_Tanggal) & ", " & vbCrLf &
                                    " [Part No] = " & QVal(H_Part_No) & ", " & vbCrLf &
                                    " [Part Name] = " & QVal(H_Part_No) & ", " & vbCrLf &
                                    " [Qty] = " & QVal(H_Qty) & ", " & vbCrLf &
                                    " [Problem] = " & QVal(H_Problem) & ", " & vbCrLf &
                                    " [Dibuat] = " & QVal(H_Dibuat) & ", " & vbCrLf &
                                    " [Mengetahui] = " & QVal(H_Mengetahui) & ", " & vbCrLf &
                                    " [Foto] = " & QVal(H_Foto) & ", " & vbCrLf &
                                    " UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    " UpdatedDate = GETDATE() WHERE [NOIPMI] = '" & IPMI & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal IPMI As String)
        Try
            'DeleteDetail
            Dim ls_DeletePenyebab As String = "DELETE FROM AsakaiIpmiPenyebab WHERE rtrim(NOIPMI)=" & QVal(IPMI) & ""
            MainModul.ExecQuery(ls_DeletePenyebab)

            Dim ls_DeletePerbaikan As String = "DELETE FROM AsakaiIpmiPerbaikan WHERE rtrim(NOIPMI)=" & QVal(IPMI) & ""
            MainModul.ExecQuery(ls_DeletePerbaikan)

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class
Public Class IPMIDetailModel

    Public Property D_NOIPMI As String
    Public Property Penyebab As String
    Public Property EmpatMPenyebab As String
    Public Property EmpatMPerbaikan As String

    Public Property PIC As String
    Public Property Rencana_Perbaikan As String
    Public Property Target As String

    Public Sub InsertDetailPenyebab(NoIPMI As String)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiIpmiPenyebab]
                       ([NOIPMI]
                       ,[Penyebab]
                       ,[4M]) " & vbCrLf &
            "Values(" & QVal(NoIPMI) & ", " & vbCrLf &
            "       " & QVal(Penyebab) & ", " & vbCrLf &
            "       " & QVal(EmpatMPenyebab) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailPerbaikan(NOIPMI As String)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiIpmiPerbaikan]
                       ([NOIPMI]
                       ,[Rencana Perbaikan]
                       ,[Target]
                       ,[PIC]
                       ,[4M]) " & vbCrLf &
            "Values(" & QVal(NOIPMI) & ", " & vbCrLf &
            "       " & QVal(Rencana_Perbaikan) & ", " & vbCrLf &
            "       " & QVal(Target) & ", " & vbCrLf &
            "       " & QVal(PIC) & ", " & vbCrLf &
            "       " & QVal(EmpatMPerbaikan) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class
