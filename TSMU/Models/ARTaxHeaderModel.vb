Imports System.Collections.ObjectModel

Public Class ARTaxHeaderModel
    Public Property Bulan As String
    Public Property CMDMNo As String
    Public Property CuryID As String
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

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            '           Dim sql As String = "SELECT id,FPNo,No_Bukti_Potong,Pphid,Ket_Pph,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,Tot_Pph,ket_dpp,CMDMNo  FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND  Tipe = 'S' and status<>'Close' Order by SuspendID"
            Dim sql As String = "SELECT id,FPNo,No_Bukti_Potong,CMDMNo,Pphid,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,Tot_Pph,ket_dpp  FROM ar_pph_header WHERE No_Bukti_Potong='' or No_Bukti_Potong is null Order by FPNo"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataGrid2() As DataTable
        Try
            Dim dt As New DataTable
            '           Dim sql As String = "SELECT id,FPNo,No_Bukti_Potong,Pphid,Ket_Pph,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,Tot_Pph,ket_dpp,CMDMNo  FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND  Tipe = 'S' and status<>'Close' Order by SuspendID"
            Dim sql As String = "SELECT id,FPNo,No_Bukti_Potong,CMDMNo,Pphid,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,Tot_Pph,ket_dpp  FROM ar_pph_header WHERE No_Bukti_Potong!='' Order by FPNo "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM ar_pph_header " & vbCrLf &
            "WHERE FPNo = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM ar_pph_header " & vbCrLf &
            "WHERE FPNo = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub GetARPphById()
        Try
            Dim sql As String = "SELECT id ,FPNo ,No_Bukti_Potong ,Pphid ,Ket_Pph ,Tarif ,Tahun ,Bulan ,Lokasi ,CuryID ,Tot_Dpp_Invoice ,No_Faktur ,Tot_Pph ,ket_dpp ,CMDMNo  FROM ar_pph_header where ID=" & QVal(id) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                id = If(IsDBNull(dt.Rows(0).Item("id")), "", Trim(dt.Rows(0).Item("id").ToString()))
                FPNo = If(IsDBNull(dt.Rows(0).Item("FPNo")), "", Trim(dt.Rows(0).Item("FPNo").ToString()))
                No_Bukti_Potong = If(IsDBNull(dt.Rows(0).Item("No_Bukti_Potong")), "", Trim(dt.Rows(0).Item("No_Bukti_Potong").ToString()))
                Pphid = If(IsDBNull(dt.Rows(0).Item("Pphid")), "", Trim(dt.Rows(0).Item("Pphid").ToString()))
                Ket_Pph = If(IsDBNull(dt.Rows(0).Item("Ket_Pph")), "", Trim(dt.Rows(0).Item("Ket_Pph").ToString()))
                Tarif = If(IsDBNull(dt.Rows(0).Item("Tarif")), "", Trim(dt.Rows(0).Item("Tarif").ToString()))
                Tot_Dpp_Invoice = If(IsDBNull(dt.Rows(0).Item("Tot_Dpp_Invoice")), "", Trim(dt.Rows(0).Item("Tot_Dpp_Invoice").ToString()))
                Tahun = If(IsDBNull(dt.Rows(0).Item("Tahun")), "", Trim(dt.Rows(0).Item("Tahun").ToString()))
                Bulan = If(IsDBNull(dt.Rows(0).Item("Bulan")), "", Trim(dt.Rows(0).Item("Bulan").ToString()))
                Lokasi = If(IsDBNull(dt.Rows(0).Item("Lokasi")), "", Trim(dt.Rows(0).Item("Lokasi").ToString()))
                Tot_Pph = If(IsDBNull(dt.Rows(0).Item("Tot_Pph")), "", Trim(dt.Rows(0).Item("Tot_Pph").ToString()))
                ket_dpp = If(IsDBNull(dt.Rows(0).Item("ket_dpp")), "", Trim(dt.Rows(0).Item("ket_dpp").ToString()))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateHeader()
        Try
            Dim ls_sp As String = " " & vbCrLf &
   "update ar_pph_header " & vbCrLf &
   "set fpno = " & QVal(FPNo) & ", " & vbCrLf &
   "       no_bukti_potong = " & QVal(No_Bukti_Potong) & ", " & vbCrLf &
   "       pphid = " & QVal(Pphid) & ", " & vbCrLf &
   "       ket_pph = " & QVal(Ket_Pph) & ", " & vbCrLf &
   "       tarif = " & QVal(Tarif) & ", " & vbCrLf &
   "       tahun = " & QVal(Tahun) & ", " & vbCrLf &
   "       bulan = " & QVal(Bulan) & ", " & vbCrLf &
   "       lokasi = " & QVal(Lokasi) & ", " & vbCrLf &
   "       curyid = " & QVal(CuryID) & ", " & vbCrLf &
   "       tot_dpp_invoice = " & QVal(Tot_Dpp_Invoice) & ", " & vbCrLf &
   "       no_faktur = " & QVal(No_Faktur) & ", " & vbCrLf &
   "       tot_pph = " & QVal(Tot_Pph) & ", " & vbCrLf &
   "       ket_dpp = " & QVal(ket_dpp) & ", " & vbCrLf &
   "       cmdmno = " & QVal(CMDMNo) & " where fpno= '" & FPNo & "'"

            'Dim ls_SP As String = " " & vbCrLf &
            '                        "UPDATE suspend_header " & vbCrLf &
            '                        "SET    Currency = " & QVal(Ket_Pph) & ", " & vbCrLf &
            '                        "       DeptID = " & QVal(Ket_Pph) & ", " & vbCrLf &
            '                        "       PRNo = " & QVal(Ket_Pph) & ", " & vbCrLf &
            '                        "       Remark = " & QVal(Ket_Pph) & ", " & vbCrLf &
            '                        "       Tgl = " & QVal(Ket_Pph) & ", " & vbCrLf &
            '                        "       Status = " & QVal(Ket_Pph) & ", " & vbCrLf &
            '                        "       Total = " & QVal(Tot_Pph) & ", " & vbCrLf &
            '                        "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
            '                        "       UpdatedDate = GETDATE() WHERE SuspendID = '" & Tot_Pph & "'"

            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
