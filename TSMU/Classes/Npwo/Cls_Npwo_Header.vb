Public Class Cls_Npwo_Header



    Public Function Get_NPP() As DataTable
        Try
            Dim query As String = "[NPP_Get_NPP]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_NPWO() As DataTable
        Try
            Dim query As String = "[NPWO_Get_NPWO]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Sub Delete(NPWO_ As String)
        Try



            Dim ls_SP As String = "DELETE FROM [Npwo_Head]
                                     WHERE No_Npwo = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_SP)


            Dim ls_Detail As String = "DELETE FROM [Npwo_Detail]
                                     WHERE No_Npwo = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail)

            Dim ls_Detail1 As String = "DELETE FROM [NpwoDetail1]
                                     WHERE No_Npwo = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail1)

        Catch ex As Exception

        End Try


    End Sub


End Class
