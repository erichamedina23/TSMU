Imports System.Collections.ObjectModel
Public Class KebijakanModel

    Dim _Query As String
    Dim _QueryKategoriAbsen As String
    Public Property ID() As String
    Public Property Kebijakan() As String



    Public Function GetDataLoad() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT ID,Kebijakan from AsakaiKebijakan order by ID"
            'dt = GetDataTableByCommand(sql)
            dt = GetDataTableByCommand(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteHeader(ByVal ID As Integer)
        Try

            Dim ls_SP As String = "DELETE FROM AsakaiKebijakan WHERE rtrim(ID)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetData(ID As String)
        Try
            Dim query As String = "SELECT 
                                    ID
                                   ,Kebijakan
                                    FROM AsakaiKebijakan WHERE ID = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID") & "")
                    Me.Kebijakan = Trim(.Item("Kebijakan") & "")
                    ''Me.IDAbsen = Trim(.Item("IDAbsen") & "")
                    'Me.Jumlah = Trim(.Item("Jumlah") & "")
                    ''Me.NoAbsen = Trim(.Item("NoAbsen") & "")
                    'Me.Percentage = Trim(.Item("Percentage") & "")
                End With
            Else
                ID = "0"
                Kebijakan = ""
                'IDAbsen = ""
                'Jumlah = "0"
                'Percentage = "0"
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub ValidateInsert()
        'If Me.NoAbsen = "" Then
        '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        'End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [ID]
                                     ,[ID]                     
                                     ,[Kebijakan]                     
                                    FROM AsakaiKebijakan where ID = " & ID & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.ID & "]")

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertDataKebijakan()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader()

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
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [AsakaiKebijakan]
                                           ([ID]                     
                                           ,[Kebijakan]                     
                                           ,[CreatedBy]                     
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(ID) & " 
                                            ," & QVal(Kebijakan) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"


            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)

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

                        UpdateHeader(ID)


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

    Public Sub UpdateHeader(ByVal _ID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiKebijakan" & vbCrLf &
                                    "SET    Kebijakan = " & QVal(Kebijakan) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE ID = '" & _ID & "'"
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class

