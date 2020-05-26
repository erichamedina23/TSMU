Public Class TravelPocketAllowanceModel
    Dim Query As String

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Query = " SELECT  TravelType ,
                                Golongan ,
                                CuryID ,
                                Amount
                        FROM    dbo.TravelPocketAllowance "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
