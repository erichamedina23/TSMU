Imports System.Collections.ObjectModel
Public Class DepartemenModel
    Dim _Query As String
    Public Property DeptID() As String
    Public Property Nama() As String
    Public Property Jumlah() As Integer
    Public Property Lokasi() As String

    Public Sub New()
        Me._Query = "SELECT DeptID,Nama,Jumlah,Lokasi FROM departemen"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(Me._Query)
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT
                                    '' DeptID
                                    ,'' [Nama]
                                    ,'' [Jumlah]
                                    FROM [departemen] 
                                    UNION 
                                    SELECT 
                                    [DeptID]
                                    ,[Nama]
                                    ,[Jumlah]
                                    FROM [departemen]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT 
                                    [DeptID]
                                    ,[Nama]
                                    ,[Jumlah]
                                    ,[Lokasi]
                                    FROM [departemen] WHERE [DeptID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    Me.Nama = Trim(.Item("Nama") & "")
                    Me.Jumlah = Trim(.Item("Jumlah") & "")
                End With
            Else
                DeptID = ""
                Nama = ""
                Jumlah = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function getDataDepartemenByID(ByVal ID As String) As DataTable
        Try
            Dim query As String = "SELECT 
                                    [DeptID]
                                    ,[Nama]
                                    ,[Jumlah]
                                    FROM [departemen] WHERE [DeptID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    Me.Nama = Trim(.Item("Nama") & "")
                    Me.Jumlah = Trim(.Item("Jumlah") & "")
                End With
            Else
                DeptID = ""
                Nama = ""
                Jumlah = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub ValidateInsert()
        If Me.Nama = "" OrElse Me.DeptID = "" OrElse Me.Jumlah = vbNull Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [DeptID]
                                    ,[Nama]                     
                                    ,[Jumlah]                     
                                    FROM [departemen] where [DeptID] = " & QVal(DeptID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.DeptID & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [departemen]
                                           ([DeptID]
                                           ,[Nama]
                                           ,[Jumlah]
                                           ,[Lokasi]
                                           ,[Createdby]
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(DeptID) & " 
                                           ," & QVal(Nama) & "
                                           ," & QVal(Jumlah) & "
                                           ," & QVal(Lokasi) & "
                                           ," & QVal(gh_Common.Username) & "
                                           ,GETDATE())"

            ExecQuery(ls_SP)
            'MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [departemen]
                                   SET [Nama] = " & QVal(Nama) & "
                                      ,[Jumlah] = " & QVal(Jumlah) & "
                                      ,[Lokasi] = " & QVal(Lokasi) & "
                                      ,[UpdatedBy] = " & QVal(gh_Common.Username) & "
                                      ,[UpdatedDate] = GETDATE()
                                   WHERE DeptID = " & QVal(id) & ""
            ExecQuery(ls_SP)
            'MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [departemen] WHERE DeptID =" & QVal(id) & ""
            ExecQuery(ls_SP)
            'MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

End Class
