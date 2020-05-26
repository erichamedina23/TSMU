Public Class fp_pph_detail_models
    Public Property cek As String
    Public Property descr As String
    Public Property dpp As Double
    Public Property FPNo As String
    Public Property id As Integer
    Public Property invtid As String
    Public Property No_Faktur As String
    Public Property No_Invoice As String

    Public Function GetGridPphDetails(ByVal NoFP As String) As DataTable
        Try
            Dim sql As String =
            "SELECT [invtid] InvtID
                ,[descr] TranDesc
                ,[dpp] Amount
                ,convert(bit,[cek]) cek
            FROM [Fp_pph_detail] WHERE RTRIM(FPNo) = " & QVal(NoFP) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridPphDetailsApprove(ByVal No_Invoice As String) As DataTable
        Try
            Dim sql As String =
            "SELECT distinct [Fp_pph_detail].[FpNo] FpNo
                    ,[Fp_pph_detail].[invtid] InvtID
                    ,[Fp_pph_detail].[descr] TranDesc
                    ,[Fp_pph_detail].[dpp] Amount
                    ,convert(bit,[Fp_pph_detail].[cek]) cek
            FROM [Fp_pph_detail] inner join fp_detail on fp_pph_detail.FPNo = fp_detail.FPNo
            WHERE RTRIM(Fp_detail.No_Invoice) = " & QVal(No_Invoice) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetNoBUktiPotongByNoFP(ByVal NoFP As String) As DataTable
        Try
            Dim sql As String =
            "SELECT DISTINCT [No_Bukti_Potong]
            FROM [Fp_pph_detail] WHERE RTRIM(FPNo) = " & QVal(NoFP) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertDetail()
        Try
            Dim ls_SP As String = "" & vbCrLf &
                                "INSERT INTO FP_pph_detail (FPNo,No_Faktur,invtid,descr,Dpp,cek) " & vbCrLf &
                                "VALUES(" & QVal(Me.FPNo) & ", " & vbCrLf &
                                "   " & QVal(Me.No_Faktur) & ", " & vbCrLf &
                                "   " & QVal(Me.invtid) & ", " & vbCrLf &
                                "   " & QVal(Me.descr) & ", " & vbCrLf &
                                "   " & QVal(Me.dpp) & ", " & vbCrLf &
                                "   " & QVal(Me.cek) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal FPNo As String)
        Try
            Dim ls_SP As String = "DELETE FROM fp_pph_detail WHERE rtrim(FPNo)=" & QVal(FPNo.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
