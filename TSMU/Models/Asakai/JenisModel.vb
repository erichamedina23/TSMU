Imports System.Collections.ObjectModel
Public Class JenisModel
    Dim _Query As String
    Public Property IDJenis() As String
    Public Property Description() As String

    Public Sub New()
        Me._Query = "SELECT IDJenis,Description FROM AsakaiJenis"
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
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllDataTableJenis() As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT 
                                    [IDJenis]
                                    ,[Description]
                                    FROM [AsakaiJenis] WHERE [IDJenis] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDJenis = Trim(.Item("IDJenis") & "")
                    Me.Description = Trim(.Item("Description") & "")
                End With
            Else
                IDJenis = ""
                Description = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.IDJenis = "" OrElse Me.Description = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDJenis]
                                    ,[Description]                     
                                    FROM [AsakaiJenis] where [IDJenis] = " & QVal(IDJenis) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.IDJenis & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


#Region "CRUD"

    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [AsakaiJenis]
                                           ([IDJenis]
                                           ,[Description]
                                           ,[Createdby]
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(IDJenis) & " 
                                           ," & QVal(Description) & "
                                           ," & QVal(gh_Common.Username) & "
                                           ,GETDATE())"

            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [AsakaiJenis]
                                   SET [Description] = " & QVal(Description) & "
                                      ,[UpdatedBy] = " & QVal(gh_Common.Username) & "
                                      ,[UpdatedDate] = GETDATE()
                                   WHERE IDJenis = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [AsakaiJenis] WHERE IDJenis =" & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region


End Class
