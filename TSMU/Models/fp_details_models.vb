Public Class fp_details_models
    Public Property CuryID As String
    Public Property Dpp As Double
    Public Property FPNo As String
    Public Property id As Integer
    Public Property Jml_Invoice As Double
    Public Property link_barcode As String
    Public Property No_Faktur As String
    Public Property No_Invoice As String
    Public Property Pph As Double
    Public Property Ppn As Double
    Public Property Tgl_Invoice As DateTime
    Public Property No_Bukti_Potong As String
    Public Property Check_PPN As String

    Public Sub InsertDetails()
        Try

            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO FP_Detail (FPNo,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Check_PPN,Dpp,Pph,No_Faktur,link_barcode,No_Bukti_Potong) " & vbCrLf &
                                    "Values(" & QVal(Me.FPNo) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tgl_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.Jml_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Ppn) & ", " & vbCrLf &
                                    "       " & QVal(Me.Check_PPN) & ", " & vbCrLf &
                                    "       " & QVal(Me.Dpp) & ", " & vbCrLf &
                                    "       " & QVal(Me.Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Faktur) & ", " & vbCrLf &
                                    "       " & QVal(Me.link_barcode) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Bukti_Potong) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateApDocUser3()

        Try

            Dim Query = "UPDATE ApDoc set User3=1 where rtrim(InvcNbr) =" & QVal(No_Invoice) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Sub DeleteDetail(ByVal FPNo As String)
        Try
            Dim ls_SP As String = "DELETE FROM fp_detail WHERE rtrim(FPNo)=" & QVal(FPNo.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class

