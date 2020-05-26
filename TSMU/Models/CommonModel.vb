Public Class CommonModel
    Public Function GeCustID() As DataTable
        Try
            Dim sql As String = "select RTRIM(CustId) CustId from Customer "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetInvtID() As DataTable
        Try
            Dim sql As String = "select RTRIM(InvtID) InvtID from Inventory order by InvtID"

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
