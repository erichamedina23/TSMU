Public Class sales_model
    Public Function SalesLoadDataGrid(Perpost As String) As DataTable
        Try
            Dim query As String = "Stp_Sales"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PerPost", SqlDbType.VarChar)
            pParam(0).Value = Perpost

            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_SP_Solomon(query, pParam)

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class
