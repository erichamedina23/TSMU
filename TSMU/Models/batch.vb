Public Class batch
    Public Property BatchNO As String
    Public Sub UpdateBatch(VrNo As String)
        Try

            Dim ls_SP As String = "UPDATE Batch SET user2= " & QVal(VrNo) & " WHERE RTRIM(batnbr) = " & QVal(BatchNO.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
