Imports System.Collections.ObjectModel
Public Class ClsCutomer
    Dim _Query As String
    Public Property ID() As String
    Public Property custid() As String
    Public Property customer() As String
    Public Property kel() As String

    'Public Property IDLokasiDetail() As String

    Public Sub New()
        Me._Query = "SELECT [id]
      ,[custid]
      ,[customer]
      ,[kel] 
                FROM [urut_cust]"
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
            Dim ls_SP As String =
            "SELECT [id]
      ,[custid]
      ,[customer]
      ,[kel] 
                FROM [urut_cust]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal id As String)
        Try
            Dim query As String =
                "SELECT [id]
      ,[custid]
      ,[customer]
      ,[kel] 
                FROM [urut_cust] WHERE [CustID] = " & QVal(id) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("id") & "")
                    Me.custid = Trim(.Item("CustID") & "")
                    Me.customer = Trim(.Item("Customer") & "")
                    Me.kel = Trim(.Item("kel") & "")

                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.customer = "" OrElse Me.ID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [custid]
                                    ,[Customer]                     
                                    FROM [urut_cust] where [custid] = " & QVal(custid) & ""
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
            Dim ls_SP As String =
            "INSERT INTO [urut_cust]
                ([id]
                ,[custid]
                ,[customer]
                ,[kel])
            VALUES
                (" & QVal(ID) & "
                ," & QVal(custid) & "
                ," & QVal(customer) & "
                ," & QVal(kel) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal custid As String)
        Try
            Dim ls_SP As String =
            "UPDATE [urut_cust]
            SET [ID] = " & QVal(Me.ID) & "
            ,[custid] = " & QVal(custid) & "
            ,[customer] = " & QVal(customer) & "
            ,[kel] = " & QVal(kel) & "
            WHERE [custid] = " & QVal(custid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal custid As String)
        Try
            Dim ls_SP As String = "DELETE FROM [urut_cust] WHERE CustID =" & QVal(custid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
