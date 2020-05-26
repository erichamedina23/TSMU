Imports System.Data.SqlClient

Public Class TMMINmodel

    Public Function GetKanban(etd As String, flag As Integer) As DataTable
        Dim dt As New DataTable
        Try

            Dim sql = "TMMINTrans_getDatataExcel"
            Dim param() As SqlParameter = New SqlParameter(1) {}
            param(0) = New SqlParameter("@etd", SqlDbType.VarChar)
            param(0).Value = etd
            param(1) = New SqlParameter("@flag", SqlDbType.Int)
            param(1).Value = flag
            dt = GetDataTableByCommand_StorePCKR(sql, param)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateFlag(ByVal KanbanID As String)
        Try
            Dim query As String = "TMMIN_update_flag"
            Dim param() As SqlParameter = New SqlParameter(0) {}
            param(0) = New SqlParameter("@kanban", SqlDbType.VarChar)
            param(0).Value = KanbanID
            ExecQueryByCommand_SPCKR(query, param)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
