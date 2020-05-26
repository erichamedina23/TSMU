Imports System.Data.SqlClient

Public Class KaryawanModel
    Public Property Id As Integer
    Public Property Nama As String
    Public Property NIK As String
    Public Property NoAnggota As String
    Public Property Seksi As String
    Public Property Site As String


    Public Function GetDataGrid() As DataTable
        Dim dt As New DataTable
        Try
            Dim sql = "Karyawan_GetDataGrid"
            dt = GetDataTableByCommand_StorePCKR(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insert()
        Try
            Dim sql = "Karyawa_UploadData"
            Dim param() As SqlParameter = New SqlParameter(5) {}
            param(0) = New SqlParameter("@site", SqlDbType.VarChar)
            param(0).Value = Site
            param(1) = New SqlParameter("@nik", SqlDbType.VarChar)
            param(1).Value = NIK
            param(2) = New SqlParameter("@noanggota", SqlDbType.VarChar)
            param(2).Value = NoAnggota
            param(3) = New SqlParameter("@nama", SqlDbType.VarChar)
            param(3).Value = Nama
            param(4) = New SqlParameter("@seksi", SqlDbType.VarChar)
            param(4).Value = Seksi
            param(5) = New SqlParameter("@uploadedby", SqlDbType.VarChar)
            param(5).Value = gh_Common.Username
            ExecQueryByCommand_SPCKR(sql, param)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
