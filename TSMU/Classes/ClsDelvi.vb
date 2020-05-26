Public Class ClsDelvi

    Public Property BATNBR() As String
    Public Property SHIPPERID() As String
    Public Property CUSTORDNBR() As String
    Public Property InvcDate() As String
    Public Property RefNbr() As String
    Public Property NoFP() As String
    Public Property NoSertifikat() As String


    Public Function GetAllDataGrid() As DataTable
        Try
            Dim ls_SP As String = "sp_delvi"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP_Solomon(ls_SP)
            'If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '    With dtTable.Rows(0)
            '        Me._id = Trim(.Item("ID") & "")
            '    End With
            'End If
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetBatchNo(BatchNo As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[sp_delvi]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@batchNo", SqlDbType.VarChar)
            pParam(0).Value = BatchNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Sub ValidateInsert()
        If BATNBR = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 BATNBR from SJFinHeader where BATNBR = " & QVal(BATNBR) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTelahDigunakan) &
                "[" & Me.BATNBR & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Insert()
        Try
            Dim SQL As String =
                "
                INSERT INTO [SJFinHeader]
                    ([BATNBR]
                    ,[InvcDate]
                    ,[RefNbr]
                    ,[NoSertifikat]
                    ,[NoFP]
                    ,[CreatedBy]
                    ,[CreatedDate])
                VALUES
                    (
                    " & QVal(BATNBR) & "
                    ," & QVal(InvcDate) & "
                    ," & QVal(RefNbr) & "
                    ," & QVal(NoSertifikat) & "
                    ," & QVal(NoFP) & "
                    ," & QVal(gh_Common.Username) & "
                    ,Getdate()
                    )
                "
            MainModul.ExecQuery_Solomon(SQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertDetails()
        Try
            Dim SQL As String =
                "
                INSERT INTO [SJFinDetails]
                    ([BATNBR]
                    ,[SHIPPERID]
                    ,[CUSTORDNBR])
                VALUES
                (
                    " & QVal(BATNBR) & "
                    ," & QVal(SHIPPERID) & "
                    ," & QVal(CUSTORDNBR) & "
                )
                "
            MainModul.ExecQuery_Solomon(SQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
