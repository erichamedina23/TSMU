Public Class global_function_models

    Public Function getCusst_Solomon() As DataTable
        Try
            Dim query As String = "select RTRIM(CustId) [Customer ID], RTRIM([Name]) [Name] from Customer order by [Name]"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getPartNo_Solomon(ByVal cust As String) As DataTable
        Try
            Dim query As String = "select RTRIM(InvtID) InvtID, RTRIM(AlternateID) PartNo, RTRIM(Descr) Descr from itemxref where altIDType='C' and InvtID= " & QVal(cust) & " order by EntityID,AlternateID"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
