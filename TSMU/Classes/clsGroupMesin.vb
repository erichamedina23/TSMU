Imports System.Collections.ObjectModel
Public Class clsGroupMesin
    Dim _Query As String
    Public Property ID() As String
    Public Property Deskripsi() As String
    Public Property Tonnase() As Integer
    'Public Property IDLokasiDetail() As String

    Public Sub New()
        Me._Query = "SELECT ID 
                    , [ID Group]
                    , Deskripsi
                    FROM m_group_mesin"
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
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT 
                                    '' [ID Group]
                                    ,'' [Deskripsi]
                                    FROM [m_group_mesin] 
                                    UNION 
                                    SELECT 
                                    [ID Group]
                                    ,[Deskripsi]
                                    FROM [m_group_mesin]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT 
                                    [ID Group]
                                    ,[Deskripsi]
                                    ,ISNULL(Tonnase,0) Tonnase 
                                    FROM [m_group_mesin] WHERE [ID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID Group") & "")
                    Me.Deskripsi = Trim(.Item("Deskripsi") & "")
                    Me.Tonnase = .Item("Tonnase")
                End With
            Else
                ID = ""
                Deskripsi = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.Deskripsi = "" OrElse Me.ID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [ID Group]
                                    ,[Deskripsi]                     
                                    FROM [m_group_mesin] where [ID Group] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.ID & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [m_group_mesin]
                                           ([ID Group]
                                           ,[Deskripsi]
                                           ,[Created Date]
                                           ,[Created By])
                                     VALUES
                                           (" & QVal(ID) & " 
                                           ," & QVal(Deskripsi) & "
                                           ,GETDATE()
                                           ," & QVal(gh_Common.Username) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [m_group_mesin]
                                   SET [ID Group] = " & QVal(Me.ID) & "
                                      ,[Deskripsi] = " & QVal(Deskripsi) & "
                                      ,[Updated Date] = GETDATE()
                                      ,[Updated By] = " & QVal(gh_Common.Username) & "
                                    WHERE ID = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [m_group_mesin] WHERE ID =" & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class

