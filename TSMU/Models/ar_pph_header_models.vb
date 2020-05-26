Public Class ar_pph_header_models
    Public Property Bulan As String
    Public Property CuryID As String
    Public Property CMDMNo As String
    Public Property Acctid As String
    Public Property SubAcct As String
    Public Property EntryId As String
    Public Property RcptDisbFlg As String
    Public Property FPNo As String
    Public Property id As Integer
    Public Property ket_dpp As String
    Public Property Ket_Pph As String
    Public Property Lokasi As String
    Public Property No_Bukti_Potong As String
    Public Property No_Faktur As String
    Public Property Pphid As String
    Public Property Tahun As String
    Public Property Tarif As Double
    Public Property Tot_Dpp_Invoice As Double
    Public Property Tot_Pph As Double
    Public Property No_Invoice As String
    '  Public Property FPNo As String
    Public Function GetFPByNo(ByVal NoFP As String) As DataTable
        Try
            Dim sql As String = "SELECT [id]
                    ,[FPNo]
                    ,[No_Bukti_Potong]
                    ,[Pphid]
                    ,[Ket_Pph]
                    ,[Tarif]
                    ,[Tahun]
                    ,[Bulan]
                    ,[Lokasi]
                    ,[CuryID]
                    ,[Tot_Dpp_Invoice]
                    ,[No_Faktur]
                    ,[Tot_Pph]
                    ,[ket_dpp]
                    ,[CMDMNo]
                FROM [ar_pph_header] WHERE RTRIM(FPNo) = " & QVal(NoFP) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetFPByNoApprove(ByVal No_Invoice As String) As DataTable
        Try
            Dim sql As String = "SELECT [ar_pph_header].[id]
                    ,[ar_pph_header].[FPNo]
                    ,[ar_pph_header].[No_Bukti_Potong]
                    ,[Pphid]
                    ,[Ket_Pph]
					,[Fp_detail].[No_Invoice]
                    ,[Tarif]
                    ,[Tahun]
                    ,[Bulan]
                    ,[Lokasi]
                    ,[ar_pph_header].[CuryID]
                    ,replace(convert(varchar,cast((([Tot_Dpp_Invoice])) as money), 1), '.00', '') as 'Tot_Dpp_Invoice'
                    ,[ar_pph_header].[No_Faktur]
                    ,replace(convert(varchar,cast((([Tot_Pph])) as money), 1), '.00', '') as 'Tot_Pph'
                    ,[ket_dpp]
                FROM [ar_pph_header]  inner join fp_detail on ar_pph_header.FPNo = fp_detail.FPNo  WHERE RTRIM(No_Invoice) =" & QVal(No_Invoice) & "
				group by ar_pph_header.id,ar_pph_header.FPNo,ar_pph_header.No_Bukti_Potong
                    ,ar_pph_header.Pphid ,ar_pph_header.Ket_Pph,Fp_detail.No_Invoice,ar_pph_header.Tarif,ar_pph_header.Tahun
                    ,ar_pph_header.Bulan,ar_pph_header.Lokasi,ar_pph_header.CuryID,ar_pph_header.Tot_Dpp_Invoice
					,ar_pph_header.No_Faktur
                    ,ar_pph_header.Tot_Pph
                    ,ar_pph_header.ket_dpp"

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO ar_pph_header (FPNo,No_Bukti_Potong,Pphid,Ket_Pph,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,ket_dpp,Tot_Pph,CMDMNo) " & vbCrLf &
                                    "Values(" & QVal(Me.FPNo) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Bukti_Potong) & ", " & vbCrLf &
                                    "       " & QVal(Me.Pphid) & ", " & vbCrLf &
                                    "       " & QVal(Me.Ket_Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tarif) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tahun) & ", " & vbCrLf &
                                    "       " & QVal(Me.Bulan) & ", " & vbCrLf &
                                    "       " & QVal(Me.Lokasi) & ", " & vbCrLf &
                                    "       " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Dpp_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Faktur) & ", " & vbCrLf &
                                    "       " & QVal(Me.ket_dpp) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.CMDMNo) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHeadercm()
        Acctid = "10000"
        SubAcct = "11708"
        EntryId = "PH"
        RcptDisbFlg = "D"
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO OffsetAR (vrno,Description,Acctid,SubAcct,EntryId,Amount,RcptDisbFlg,CMDMNo) " & vbCrLf &
                                    "Values(" & QVal(Me.FPNo) & ", " & vbCrLf &
                                    "       " & QVal(Me.Ket_Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.Acctid) & ", " & vbCrLf &
                                    "       " & QVal(Me.SubAcct) & ", " & vbCrLf &
                                    "       " & QVal(Me.EntryId) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.RcptDisbFlg) & ", " & vbCrLf &
                                    "       " & QVal(Me.CMDMNo) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteHeader(ByVal FPNo As String)
        Try
            Dim ls_SP As String = "DELETE FROM ar_pph_header WHERE rtrim(FPNo) =" & QVal(FPNo.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
