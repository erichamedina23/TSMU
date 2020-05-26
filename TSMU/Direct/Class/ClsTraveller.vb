Imports System.Collections.ObjectModel
Public Class ClsTraveller
    Dim _Query As String
    Public Property DeptID As String
    Public Property Nama As String
    Public Property NIK As String
    Public Property Golongan As String
    'Public Property PassExpDate As DateTime
    'Public Property PassNo As String
    'Public Property VisaExpDate As DateTime
    'Public Property VisaNo As String
    'Public Property IDLokasiDetail() As String

    Public Property ObjCreditCard() As New Collection(Of ClsTravelerDetail)

    Public Property ObjVisa() As New Collection(Of ClsTravelerVisa)

    Public Property ObjPaspor() As New Collection(Of ClsTravelerPaspor)

    '  Public Sub New()
    '      Me._Query = "SELECT NIK
    '    ,Nama
    '    ,DeptID
    '    ,VisaNo
    '    ,VisaExpDate
    '    ,PassNo
    '    ,PassExpDate
    'FROM Traveller"
    '  End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            _Query = "  SELECT  NIK ,
                                Nama ,
                                DeptID ,
                                Golongan
                        FROM    dbo.Traveler "

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(_Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT NIK
                                  ,Nama
                                  ,DeptID
                                  ,VisaNo
                                  ,VisaExpDate
                                  ,PassNo
                                  ,PassExpDate
                              FROM Traveler"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByID(ByVal NIK As String)
        Try
            Dim query As String = " SELECT  NIK ,
                                            Nama ,
                                            DeptID ,
                                            Golongan
                                    FROM    dbo.Traveler
                                    WHERE NIK = " & QVal(NIK) & " "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.NIK = Trim(.Item("NIK") & "")
                    Me.Nama = Trim(.Item("Nama") & "")
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    Me.Golongan = Trim(.Item("Golongan") & "")
                    'Me.VisaExpDate = Convert.ToDateTime(.Item("VisaExpDate") & "")
                    'Me.PassNo = Trim(.Item("PassNo") & "")
                    'Me.PassExpDate = Convert.ToDateTime(.Item("PassExpDate") & "")
                End With
            Else
                NIK = ""
                Nama = ""
                DeptID = ""
                Golongan = ""
                'VisaExpDate = DateTime.Today
                'PassNo = ""
                'PassExpDate = DateTime.Today
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDept() As DataTable
        Try
            Dim sql As String =
            "SELECT [IdDept]
                  ,[NamaDept]
              FROM [mDept]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListNegara() As DataTable
        Try
            Dim sql As String
            sql = "SELECT  KodeNegara ,
                            NamaNegara
                    FROM    dbo.TravelNegara"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ValidateInsert(_dataKosong As Integer)
        If Me.Nama = "" OrElse Me.NIK = "" OrElse _dataKosong = 1 Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT NIK
                                        ,Nama
                                        ,DeptID
                                        ,Golongan
                                    FROM Traveler WHERE [NIK]  = " & QVal(NIK) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.NIK & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "CRUD"

    Public Sub Insert()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertData()

                        For i As Integer = 0 To ObjVisa.Count - 1
                            With ObjVisa(i)
                                .InsertTravelerVisa()
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

    Public Sub InsertData()
        Try
            Dim ls_SP As String = "INSERT INTO [Traveler] 
                                               ([NIK]
                                               ,[Nama]
                                               ,[DeptID]
                                               ,[Golongan])
                                     VALUES
                                                (" & QVal(NIK) & "
                                               ," & QVal(Nama) & " 
                                               ," & QVal(DeptID) & " 
                                               ," & QVal(Golongan) & ")"

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Update()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        UpdateData(NIK)

                        Dim ObjTravelerVisa As New ClsTravelerVisa
                        ObjTravelerVisa.DeleteVisa(NIK)

                        For i As Integer = 0 To ObjVisa.Count - 1
                            With ObjVisa(i)
                                .InsertTravelerVisa()
                            End With
                        Next

                        Dim ObjTravelerPaspor As New ClsTravelerPaspor
                        ObjTravelerPaspor.DeletePaspor(NIK)

                        For i As Integer = 0 To ObjPaspor.Count - 1
                            With ObjPaspor(i)
                                .InsertTravelerPaspor()
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

    Public Sub UpdateData(ByVal NIK As String)
        Try
            Dim ls_SP As String = "UPDATE  Traveler  SET Nama = " & QVal(Nama) & "
                                  ,DeptID = " & QVal(DeptID) & "
                                  ,Golongan = " & QVal(Golongan) & "
                                    WHERE NIK = " & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Delete(ByVal NIK As String)
        Try
            Dim ls_SP As String = "DELETE FROM Traveler WHERE NIK =" & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)

            Dim ObjTravelerVisa As New ClsTravelerVisa
            ObjTravelerVisa.DeleteVisa(NIK)

            Dim ObjTravelerPaspor As New ClsTravelerPaspor
            ObjTravelerPaspor.DeletePaspor(NIK)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region
End Class

Public Class ClsTravelerDetail
    Dim Query As String
    Public Property NIK As String
    Public Property NoRekening As String
    Public Property AccountName As String
    Public Property BankName As String
    Public Property Type As String
    Public Property ExpDate As Date

    Public Function GetTravelerCreditCard() As DataTable
        Try
            Query = "SELECT  NIK ,
                            NoRekening ,
                            AccountName ,
                            BankName ,
                            Type ,
                            ExpDate
                    FROM    TravelerCreditCard
                    WHERE   NIK = " & QVal(NIK) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub InsertTravelerCreditCard()
        Try
            Query = " INSERT INTO [dbo].[TravelerCreditCard]
                                ([NIK]
                                ,[NoRekening]
                                ,[AccountName]
                                ,[BankName]
                                ,[Type]
                                ,[ExpDate])
                            VALUES
                                (" & QVal(NIK) & "
                                ," & QVal(NoRekening) & "
                                ," & QVal(AccountName) & "
                                ," & QVal(BankName) & "
                                ," & QVal(Type) & "
                                ," & QVal(ExpDate) & ")"

            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal NIK As String)
        Try
            Dim ls_SP As String = "DELETE FROM TravelerCreditCard WHERE NIK =" & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class ClsTravelerVisa
    Dim Query As String
    Public Property NIK As String
    Public Property NoVisa As String
    Public Property Negara As String
    Public Property Category As String
    Public Property DateIssued As Date
    Public Property DateExpired As Date

    'Public Function GetTravelerCreditCard() As DataTable
    '    Try
    '        Query = "SELECT  NIK ,
    '                        NoRekening ,
    '                        AccountName ,
    '                        BankName ,
    '                        Type ,
    '                        ExpDate
    '                FROM    TravelerCreditCard
    '                WHERE   NIK = " & QVal(NIK) & ""
    '        Dim dtTable As New DataTable
    '        dtTable = MainModul.GetDataTable_Solomon(Query)

    '        Return dtTable
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function

    Public Function GetTravelerVisa() As DataTable
        Try
            Query = " SELECT  NIK ,
                            NoVisa ,
                            Negara ,
                            Category ,
                            DateIssued ,
                            DateExpired
                    FROM    dbo.TravelerVisa
                    WHERE   NIK = " & QVal(NIK) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(Query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub InsertTravelerVisa()
        Try
            Query = " INSERT INTO [dbo].[TravelerVisa]
                                ([NIK]
                                ,[NoVisa]
                                ,[Negara]
                                ,[Category]
                                ,[DateIssued]
                                ,[DateExpired])
                            VALUES
                                (" & QVal(NIK) & "
                                ," & QVal(NoVisa) & "
                                ," & QVal(Negara) & "
                                ," & QVal(Category) & "
                                ," & QVal(DateIssued) & "
                                ," & QVal(DateExpired) & ")"
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteVisa(ByVal NIK As String)
        Try
            Dim ls_SP As String = "DELETE FROM TravelerVisa WHERE NIK =" & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class ClsTravelerPaspor
    Dim Query As String
    Public Property NIK As String
    Public Property NoPaspor As String
    Public Property Nama As String
    Public Property KodeNegara As String
    Public Property TanggalLahir As Date
    Public Property JenisKelamin As String
    Public Property TanggalKeluar As Date
    Public Property ExpiredDate As Date
    Public Property TempatKeluar As String

    'Public Function GetTravelerCreditCard() As DataTable
    '    Try
    '        Query = "SELECT  NIK ,
    '                        NoRekening ,
    '                        AccountName ,
    '                        BankName ,
    '                        Type ,
    '                        ExpDate
    '                FROM    TravelerCreditCard
    '                WHERE   NIK = " & QVal(NIK) & ""
    '        Dim dtTable As New DataTable
    '        dtTable = MainModul.GetDataTable_Solomon(Query)

    '        Return dtTable
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function

    Public Function GetTravelerPaspor() As DataTable
        Try
            Query = " SELECT  NIK ,
                            NoPaspor ,
                            Nama ,
                            KodeNegara ,
                            TanggalLahir ,
                            JenisKelamin ,
                            TanggalKeluar ,
                            ExpiredDate ,
                            TempatKeluar
                    FROM    dbo.TravelerPaspor
                    WHERE   NIK = " & QVal(NIK) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(Query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub InsertTravelerPaspor()
        Try
            Query = " INSERT INTO [dbo].[TravelerPaspor]
                                ([NIK]
                                ,[NoPaspor]
                                ,[Nama]
                                ,[KodeNegara]
                                ,[TanggalLahir]
                                ,[JenisKelamin]
                                ,[TanggalKeluar]
                                ,[ExpiredDate]
                                ,[TempatKeluar])
                            VALUES
                                (" & QVal(NIK) & "
                                ," & QVal(NoPaspor) & "
                                ," & QVal(Nama) & "
                                ," & QVal(KodeNegara) & "
                                ," & QVal(TanggalLahir) & "
                                ," & QVal(JenisKelamin) & "
                                ," & QVal(TanggalKeluar) & "
                                ," & QVal(ExpiredDate) & "
                                ," & QVal(TempatKeluar) & ")"
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeletePaspor(ByVal NIK As String)
        Try
            Dim ls_SP As String = "DELETE FROM TravelerPaspor WHERE NIK =" & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
