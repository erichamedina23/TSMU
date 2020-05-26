Public Class Cls_NPP_Header

    Public Function Get_NPP() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[NPP_Get_NPP]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)
            'pParam(0).Value = Dept
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetDelete(NP As String) As DataTable
        Try

            Dim ls_SP As String = "SELECT A.[No_NPP] 
                                        FROM [NPP_Head] A Inner join [NPWO_HEAD] B 
                                        ON A.[No_NPP] = B.[No_NPP]
                                        where A.[No_NPP] = '" & NP & "'"
            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub Delete(NPP_ As String)
        Try



            Dim ls_SP As String = "DELETE FROM [NPP_Head] WHERE No_NPP = '" & NPP_ & "'"

            MainModul.ExecQueryByCommand(ls_SP)



            Dim ls_Detail As String = "DELETE FROM [NPP_Detail]
                                     WHERE No_NPP = '" & NPP_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail)



            Dim ls_Sp_History As String = "DELETE FROM [NPP_Head_History]
                                     WHERE No_NPP = '" & NPP_ & "'"

            MainModul.ExecQueryByCommand(ls_Sp_History)

            Dim ls_Detail_History As String = "DELETE FROM [NPP_Detail_History]
                                     WHERE No_NPP = '" & NPP_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail_History)

            Dim ls_Detail_Rev As String = "DELETE FROM [NPP_Rev_Information]
                                     WHERE No_NPP = '" & NPP_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail_Rev)


        Catch ex As Exception

        End Try


    End Sub


End Class
