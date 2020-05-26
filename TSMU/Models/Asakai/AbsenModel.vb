Imports System.Collections.ObjectModel
Public Class AbsenModel
    Dim _Query As String
    Dim _QueryKategoriAbsen As String
    Public Property ID() As Integer
    Public Property TanggalAbsen() As Date
    Public Property DeptID() As String
    Public Property IDAbsen() As String
    Public Property Jumlah() As Integer
    Public Property JumlahKaryawan() As Integer
    Public Property Percentage() As Double

    Public Property NoIncrement As Integer


    Public Property ObjDetails() As New Collection(Of AbsenModelDetail)

    Public Sub New()
        Me._Query = "SELECT NoAbsen,TanggalAbsen FROM Absen"
        Me._QueryKategoriAbsen = "select IDAbsen as No,[Description],convert(int,'0') as Jumlah, Status from KategoriAbsen"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            'dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllDataTableKategoriAbsen() As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._QueryKategoriAbsen)
            'dtTable = MainModul.GetDataTableByCommand(Me._QueryKategoriAbsen)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT
                                     '' ID
                                    ,'' [TanggalAbsen]
                                    ,'' [DeptID]
                                    ,'' [Percentage]
                                    FROM [Absen] 
                                    UNION 
                                    SELECT 
                                    [ID]
                                    ,[TanggalAbsen]
                                    ,[DeptID]
                                    ,[Percentage]
                                    FROM [Absen]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataLoad() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "SELECT Absen.[ID]
                         ,Absen.[TanggalAbsen]
                         ,Absen.[DeptID]
                         ,Absen.[Percentage]
                         ,Absen.[JumlahKaryawan] as Jumlah
                         FROM [Absen] inner join [departemen] on Absen.DeptID = Departemen.DeptID WHERE Absen.DeptID = " & QVal(gh_Common.GroupID) & ""
            '"SELECT ID,TanggalAbsen,DeptID,Percentage,CreatedBy,CreatedDate from absen"
            dt = GetDataTableByCommand(sql)
            'dt = GetDataTableByCommand(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Public Sub getDataByID(ByVal ID As String)
    '    Try
    '        Dim query As String = "SELECT 
    '                                [ID]
    '                               ,[TanggalAbsen]
    '                               ,[DeptID]
    '                               ,[Percentage]
    '                                FROM [Absen] WHERE [DeptID] = " & QVal(DeptID) & ""
    '        Dim dtTable As New DataTable
    '        'dtTable = MainModul.GetDataTableByCommand(query)
    '        dtTable = MainModul.GetDataTableByCommand(query)
    '        If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
    '            With dtTable.Rows(0)
    '                Me.ID = Trim(.Item("ID") & "")
    '                Me.TanggalAbsen = Trim(.Item("TanggalAbsen") & "")
    '                Me.DeptID = Trim(.Item("DeptID") & "")
    '                'Me.IDAbsen = Trim(.Item("IDAbsen") & "")
    '                'Me.Jumlah = Trim(.Item("Jumlah") & "")
    '                Me.Percentage = Trim(.Item("Percentage") & "")
    '            End With
    '        Else
    '            ID = "0"
    '            DeptID = ""
    '            IDAbsen = ""
    '            Jumlah = "0"
    '            Percentage = "0"
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub

    Public Function GetDataByDate(tgl As String) As DataTable
        Try
            Dim query As String = "SELECT 
                                    Absen.[ID]
                                   ,Absen.[TanggalAbsen]
                                   ,Absen.[DeptID]
                                   ,Absen.[Percentage]
                                   ,Absen.[JumlahKaryawan]
                                    FROM [Absen] inner join [departemen] on Absen.DeptID = Departemen.DeptID WHERE Absen.DeptID = " & QVal(DeptID) & " and Absen.TanggalAbsen = " & QVal(tgl) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID") & "")
                    Me.TanggalAbsen = Trim(.Item("TanggalAbsen") & "")
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    'Me.IDAbsen = Trim(.Item("IDAbsen") & "")
                    Me.Jumlah = Trim(.Item("JumlahKaryawan") & "")
                    'Me.NoAbsen = Trim(.Item("NoAbsen") & "")
                    Me.Percentage = Trim(.Item("Percentage") & "")
                End With
            Else
                ID = "0"
                DeptID = ""
                IDAbsen = ""
                Jumlah = "0"
                Percentage = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataByID(ID As String) As DataTable
        Try
            Dim query As String = "SELECT ID,Kebijakan
                                    FROM AsakaiKebijakan where ID ='" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID") & "")
                    Me.TanggalAbsen = Trim(.Item("TanggalAbsen") & "")
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    'Me.IDAbsen = Trim(.Item("IDAbsen") & "")
                    Me.Jumlah = Trim(.Item("Jumlah") & "")
                    'Me.NoAbsen = Trim(.Item("NoAbsen") & "")
                    Me.Percentage = Trim(.Item("Percentage") & "")
                End With
            Else
                ID = "0"
                DeptID = ""
                IDAbsen = ""
                Jumlah = "0"
                Percentage = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function GetDataDetailByDate(tgl As String) As DataTable
        Try
            Dim query As String = "SELECT 
                                    KategoriAbsen.[IDAbsen] as No
                                   ,KategoriAbsen.[Description]
                                    ,KategoriAbsen.[Status]
                                   ,AbsenDetail.[Jumlah]
                                    FROM [Absen] inner join [AbsenDetail] on Absen.ID = AbsenDetail.ID inner join KategoriAbsen on KategoriAbsen.IDAbsen = AbsenDetail.IDAbsen WHERE Absen.DeptID = " & QVal(DeptID) & " and Absen.TanggalAbsen = " & QVal(tgl) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub ValidateInsert()
        'If Me.NoAbsen = "" Then
        '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        'End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [ID]
                                     ,[TanggalAbsen]                     
                                     ,[DeptID]                     
                                     ,[Percentage]                     
                                    FROM [Absen] where [TanggalAbsen] = " & QVal(TanggalAbsen) & " and DeptID = " & QVal(DeptID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.IDAbsen & "]")
                'Else

                '    Dim ls_SPNoAbsen As String = "SELECT TOP 1 [ID]
                '                         ,[NoAbsen]                     
                '                         ,[TanggalAbsen]                     
                '                         ,[DeptID]                     
                '                         ,[Percentage]                     
                '                        FROM [Absen] where [NoAbsen] = " & QVal(NoAbsen) & ""
                '    Dim dtTable1 As New DataTable
                '    dtTable1 = MainModul.GetDataTableByCommand(ls_SPNoAbsen)
                '    If dtTable1 IsNot Nothing AndAlso dtTable1.Rows.Count > 0 Then
                '        Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                '        "[" & Me.IDAbsen & "]")
                '    End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


#Region "CRUD"


    Public Sub InsertDataAbsen()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        Dim Auto As Integer
                        Auto = InsertHeader()
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertAbsenDetails(Auto)
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



    Dim ObjAbsenDetail As New AbsenModelDetail
    Public Function InsertHeader() As Integer
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO [Absen]
                                           ([TanggalAbsen]                     
                                           ,[DeptID]                     
                                           ,[JumlahKaryawan]                     
                                           ,[Percentage]                     
                                           ,[CreatedBy]                     
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(TanggalAbsen) & " 
                                            ," & QVal(DeptID) & "
                                            ," & QVal(JumlahKaryawan) & "
                                            ," & QVal(Percentage) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE()) Select @@IDENTITY as identityvalue"


            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            result = dtTable.Rows(0).Item("identityvalue")
            Return result


        Catch ex As Exception
            Throw
        End Try
    End Function

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

                        Dim ObjAbsenDetail As New AbsenModelDetail
                        'Delete Detail
                        ObjAbsenDetail.DeleteDetail(ID)
                        Dim auto As Integer
                        auto = ID
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertAbsenDetails(auto)
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

    Public Sub UpdateHeader(ByVal _NoIncrement As Integer)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE Absen" & vbCrLf &
                                    "SET    Percentage = " & QVal(Percentage) & ", " & vbCrLf &
                                    "       JumlahKaryawan = " & QVal(JumlahKaryawan) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE ID = '" & _NoIncrement & "'"
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteHeader(ByVal ID As Integer)
        Try
            Dim ls_SP As String = "DELETE FROM Absen WHERE rtrim(ID)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)

            Dim ls_SPD As String = "DELETE FROM AbsenDetail WHERE rtrim(ID)=" & QVal(ID) & ""
            'ExecQuery(ls_SPD)
            ExecQuery(ls_SPD)

        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub DeleteData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        Dim ObjAbsen As New AbsenModel
                        ' ObjAbsen.DeleteHeader(_NoAbsen)



                        Dim ObjAbsenDetail As New AbsenModelDetail


                        'Untuk Delete Detail
                        'ObjAbsenDetail.DeleteDetail(_NoAbsen)

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
#End Region




End Class

Public Class AbsenModelDetail
    Public Property ID As Integer
    Public Property NoAbsen As String
    Public Property TanggalAbsen As DateTime
    Public Property DeptID As String
    Public Property Percentage As String
    Public Property IDAbsen As String
    Public Property Jumlah As Integer
    Public Property NoIncrement As Integer


    Public Sub InsertAbsenDetails(NoIncrement As String)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO AbsenDetail
            (ID,IDAbsen,Jumlah) " & vbCrLf &
            "Values(" & QVal(NoIncrement) & ", " & vbCrLf &
            "       " & QVal(ID) & ", " & vbCrLf &
            "       " & QVal(Jumlah) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub DeleteDetail(ByVal _NoIncremen As Integer)
        Try
            Dim ls_SP As String = "DELETE FROM AbsenDetail WHERE rtrim(ID)=" & QVal(_NoIncremen) & ""
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub



End Class
